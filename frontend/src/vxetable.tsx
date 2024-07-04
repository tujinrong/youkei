import VXETable, { VxeColumnPropTypes, VxeGlobalRendererHandles } from 'vxe-table'
import TablePluginAntd from '@/utils/table-plugin-antd'
import { h } from 'vue'
import XEUtils from 'xe-utils'
import jaJPLocat from 'vxe-table/lib/locale/lang/ja-JP'
import { Empty, Form } from 'ant-design-vue'
import {
  getDateHmsJpText,
  getDateJpText,
  getSimpleDateJpText,
  getSimpleDateHmsJpText,
  yearFormatter,
  getUnKnownDateJpText,
  formatTime,
  formatYubin
} from './utils/util'
import 'vxe-table/lib/style.css'
import '@/style/vxe.scss'
import { EnumDataType, EnumMsgCtrlKbn, Enum並び替え, Enum画面項目入力 } from '#/Enums'
import * as Msgs from '@/constants/msg'
import {
  RenderText,
  RenderNum,
  RenderDate,
  RenderSelect,
  RenderSearch1,
  RenderSearch2
} from '@/components/Common/VxeRender/index'
import { SearchVM } from './views/affect/AF/AWAF00802G/type'
import RangeInput from '@/components/Selector/RangeInput/index.vue'
import RangeInputNumber from '@/components/Selector/RangeInputNumber/index.vue'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import { Textarea, InputNumber, Input } from 'ant-design-vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { REGEX_time } from './constants/constant'

//グローバルパラメータ
VXETable.setup({
  i18n: (key, args) => XEUtils.toFormatString(XEUtils.get(jaJPLocat, key), args),
  loadingText: null,
  table: {
    border: true,
    showOverflow: 'tooltip'
  }
})
//フォーマット
VXETable.formats.mixin({
  //和暦
  jpTime({ cellValue }) {
    return cellValue ? getDateHmsJpText(new Date(cellValue)) : ''
  },
  jpDate({ cellValue }) {
    return cellValue ? getDateJpText(new Date(cellValue)) : ''
  },
  jpTimeSimple({ cellValue }) {
    return cellValue ? getSimpleDateHmsJpText(new Date(cellValue)) : ''
  },
  jpDateSimple({ cellValue }) {
    return cellValue ? getSimpleDateJpText(new Date(cellValue)) : ''
  },
  jpYear({ cellValue }) {
    return cellValue ? yearFormatter(cellValue) : ''
  },
  jpUnknownDate({ cellValue }) {
    return cellValue ? getUnKnownDateJpText(cellValue) : ''
  },

  //まる
  maru({ cellValue }) {
    return cellValue ? '○' : ''
  },
  //並び替え
  sort({ cellValue }) {
    if (cellValue === Enum並び替え.無し) {
      return 'ᅳ'
    }
    return Enum並び替え[cellValue]
  },
  //数値千の桁区切り
  localeNum({ cellValue }) {
    if (cellValue === null || cellValue === undefined) return ''
    return Number(cellValue).toLocaleString()
  },
  //0000 => 00:00
  splitTime({ cellValue }) {
    return formatTime(cellValue)
  },
  //郵便番号
  yubin({ cellValue }) {
    return formatYubin(cellValue)
  }
})
//空のデータ Renderer
VXETable.renderer.add('NotData', {
  renderEmpty() {
    return h(Empty, { image: Empty.PRESENTED_IMAGE_SIMPLE })
  }
})

//カスタム Renderer
VXETable.renderer.add('CustomCell', {
  renderDefault(renderOpts, params) {
    const { props } = renderOpts
    if (props?.readonly) {
      return render_read(renderOpts, params)
    } else {
      return render_edit(renderOpts, params)
    }
  }
})
VXETable.renderer.add('CustomEdit', {
  autofocus: 'input,textarea',
  autoselect: true,
  renderEdit(renderOpts, params) {
    return render_edit(renderOpts, params)
  }
})
//AF802
VXETable.renderer.add('CustomEdit2', {
  autofocus: 'input,textarea',
  autoselect: true,
  renderEdit(renderOpts, params) {
    return render_edit2(renderOpts, params)
  }
})

//読むだけ
function render_read(
  renderOpts: VxeColumnPropTypes.EditRender,
  params: VxeGlobalRendererHandles.RenderEditParams<FixFreeItemBaseVM>
) {
  const { row } = params

  if (row.inputkbn === Enum画面項目入力.日付) {
    if (row.value) {
      return <span>{getDateJpText(new Date(row.value))}</span>
    }
  }
  if ([Enum画面項目入力.選択].includes(row.inputkbn)) {
    return <span>{row.value?.split(' : ')[1]}</span>
  }
  return <span>{row.value}</span>
}

function render_edit(
  renderOpts: VxeColumnPropTypes.EditRender,
  params: VxeGlobalRendererHandles.RenderEditParams<FixFreeItemBaseVM>
) {
  const { events, props } = renderOpts
  const { row } = params
  const validateInfo = props?.validateInfos?.[row.itemcd]

  //---------------------------------------------
  let alertMsg = ''
  for (const key in Msgs) {
    if (props?.alertMsgid === Msgs[key].No) {
      alertMsg = Msgs[key].Msg
      break
    }
  }
  function getExtra(row: FixFreeItemBaseVM) {
    if (
      row.warntextflg &&
      row.hissuflg &&
      row.msgkbn == EnumMsgCtrlKbn.アラート &&
      !row.value &&
      row.value !== 0
    ) {
      return alertMsg.replace('{0}', row.itemnm)
    }
  }
  //---------------------------------------------

  switch (row.inputkbn) {
    case Enum画面項目入力.文字:
      return (
        <RenderText row={row} validateInfo={validateInfo} extra={getExtra(row)} events={events} />
      )
    case Enum画面項目入力.数値:
      return (
        <RenderNum row={row} validateInfo={validateInfo} extra={getExtra(row)} events={events} />
      )
    case Enum画面項目入力.選択:
      return (
        <RenderSelect
          row={row}
          validateInfo={validateInfo}
          extra={getExtra(row)}
          events={events}
          defaultOpen={props?.optionsDefaultOpen}
        />
      )
    case Enum画面項目入力.日付:
      return (
        <RenderDate row={row} validateInfo={validateInfo} extra={getExtra(row)} events={events} />
      )
    case Enum画面項目入力.検索:
      return (
        <RenderSearch1
          row={row}
          validateInfo={validateInfo}
          extra={getExtra(row)}
          events={events}
        />
      )
    case Enum画面項目入力.選択_検索:
      return (
        <RenderSearch2
          row={row}
          validateInfo={validateInfo}
          extra={getExtra(row)}
          events={events}
        />
      )
    default:
      return <span>{row.value}</span>
  }
}

function render_edit2(
  renderOpts: VxeColumnPropTypes.EditRender,
  params: VxeGlobalRendererHandles.RenderEditParams<SearchVM>
) {
  const { props } = renderOpts
  const { row } = params
  const validateInfo = props?.validateInfos[row.ctrlcd]

  switch (row.datatype) {
    case EnumDataType.整数:
      if (row.rangeflg) {
        return (
          <Form.Item {...validateInfo}>
            <RangeInputNumber v-model:value={row.value} precision={0} />
          </Form.Item>
        )
      }
      return (
        <Form.Item {...validateInfo}>
          <InputNumber v-model:value={row.value} precision={0} class="w-full" />
        </Form.Item>
      )
    case EnumDataType.小数:
      if (row.rangeflg) {
        return (
          <Form.Item {...validateInfo}>
            <RangeInputNumber v-model:value={row.value} />
          </Form.Item>
        )
      }
      return (
        <Form.Item {...validateInfo}>
          <InputNumber v-model:value={row.value} stringMode class="w-full" />
        </Form.Item>
      )
    case EnumDataType.文字列:
      if (row.rangeflg) {
        return (
          <Form.Item {...validateInfo}>
            <RangeInput v-model:value={row.value} maxlength={100} />
          </Form.Item>
        )
      }
      return (
        <Form.Item {...validateInfo}>
          <Textarea autoSize v-model:value={row.value} maxlength={100} />
        </Form.Item>
      )
    case EnumDataType.日付:
      if (row.rangeflg) {
        return (
          <Form.Item {...validateInfo}>
            <RangeDate v-model:value={row.value} />
          </Form.Item>
        )
      }
      return (
        <Form.Item {...validateInfo}>
          <DateJp v-model:value={row.value} format="YYYY-MM-DD" style={{ width: '190px' }} />
        </Form.Item>
      )
    case EnumDataType.時間:
      if (row.rangeflg) {
        return (
          <Form.Item {...validateInfo}>
            <RangeInput v-model:value={row.value} limitTime />
          </Form.Item>
        )
      }
      return (
        <Form.Item {...validateInfo}>
          <Input
            v-model:value={row.value}
            onBlur={() => {
              if (!REGEX_time.test(row.value as string)) row.value = ''
            }}
          />
        </Form.Item>
      )
    case EnumDataType.フラグ:
      return (
        <Form.Item {...validateInfo}>
          <a-radio-group v-model:value={row.value} buttonStyle="solid">
            <a-radio-button value="1">TRUE</a-radio-button>
            <a-radio-button value="0">FALSE</a-radio-button>
          </a-radio-group>
        </Form.Item>
      )
    default:
      return <div></div>
  }
}

//イベント遮断機
VXETable.interceptor.add('event.keydown', (params) => {
  const { $event, $table } = params

  if ($event.key === 'Tab') {
    //id: event-tab-stop
    if ($event.target.id.indexOf('event-tab-stop') > -1) {
      return false
    }
    //date popup
    if (document.querySelector('.ant-picker-panel-focused')) {
      return false
    }
  }
  // if ($event.key === 'Enter' && $event.target.nodeName === 'BUTTON') {
  //   return false
  // }

  //SH001
  function processRow(rowIndex: number, direction: 'next' | 'last') {
    const nextRow =
      direction === 'next' ? $table.getData(rowIndex + 1) : $table.getData(rowIndex - 1)
    if (nextRow) {
      if (nextRow.inputflg) {
        $table.setCurrentRow(nextRow)
        $table.setEditCell(nextRow, 'value')
        $table.setEditCell(nextRow, 'value')
      } else {
        processRow(direction === 'next' ? rowIndex + 1 : rowIndex - 1, direction)
      }
    } else {
      $table.clearEdit()
      $table.clearCurrentRow()
    }
  }
  if (
    $event.key === 'Tab' &&
    $table.props.id === 'kensin_right_table' &&
    $table.getEditRecord()?.column.field === 'value'
  ) {
    processRow($table.getEditRecord().rowIndex, $event.shiftKey ? 'last' : 'next')
    return false
  }
})

VXETable.interceptor.add('event.clearActived', (params) => {
  // if (params.cell.textContent === '検 索') return false
})

VXETable.use(TablePluginAntd)

export default VXETable
