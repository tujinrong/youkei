/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: vxe-table レンダリング
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.07.12
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Textarea, InputNumber, Form } from 'ant-design-vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import DateTime from '@/components/Selector/DateTime/index.vue'
import AiSelect from '@/components/Selector/AiSelect/index.vue'
import Atenano from '@/views/affect/AF/AWAF00705D/InputSearch.vue'
import dayjs from 'dayjs'
import { EnumRegex, Enum入力タイプ } from '#/Enums'
import OrganizeButton from '@/views/affect/AF/AWAF00702D/button.vue'
import StaffButton from '@/views/affect/AF/AWAF00704D/button.vue'
import { SearchVM as OrganizeVM } from '@/views/affect/AF/AWAF00702D/type'
import { SearchVM as StaffVM } from '@/views/affect/AF/AWAF00704D/type'
import { replaceText } from '@/utils/util'
import { nextTick } from 'vue'

/**文字 */
const RenderText = ({ row, validateInfo = {}, extra = '', events }) => {
  if (
    [Enum入力タイプ.全角文字_全角_改行可, Enum入力タイプ.全角半角文字_全角半角_改行可].includes(
      row.inputtypekbn
    )
  ) {
    //複数行の文字
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <Textarea
          rows={row.rows ? row.rows : 3}
          maxlength={row.keta1}
          v-model:value={row.value}
          onPressEnter={(e) => e.stopPropagation()}
          onBlur={() => events.onFinish?.(row)}
          onChange={() => {
            if (row.inputtypekbn === Enum入力タイプ.全角文字_全角_改行可) {
              row.value = replaceText(row.value, EnumRegex.全角_改行可)
            }
            if (row.inputtypekbn === Enum入力タイプ.全角半角文字_全角半角_改行可) {
              row.value = replaceText(row.value, EnumRegex.全角半角_改行可)
            }
            events.onChange?.(row)
          }}
        />
      </Form.Item>
    )
  } else {
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <Textarea
          autoSize
          maxlength={row.keta1}
          v-model:value={row.value}
          onBlur={() => {
            if (row.inputtypekbn === Enum入力タイプ.半角文字_時刻) {
              if (!/^\d{2}:\d{2}$/.test(row.value)) {
                row.value = ''
              }
            }
            events.onFinish?.(row)
          }}
          onPressEnter={(e) => e.stopPropagation()}
          onChange={() => {
            if (row.inputtypekbn === Enum入力タイプ.全角文字_全角_改行不可) {
              row.value = replaceText(row.value, EnumRegex.全角)
            }
            if (row.inputtypekbn === Enum入力タイプ.全角半角文字_全角半角_改行不可) {
              row.value = replaceText(row.value, EnumRegex.全角半角)
            }
            if (
              [
                Enum入力タイプ.半角文字_半角数字,
                Enum入力タイプ.半角文字_年,
                Enum入力タイプ.半角文字_年_不詳あり
              ].includes(row.inputtypekbn)
            ) {
              row.value = replaceText(row.value, EnumRegex.半角数字)
            }
            if (row.inputtypekbn === Enum入力タイプ.半角文字_半角英数字) {
              row.value = replaceText(row.value, EnumRegex.半角英数)
            }
            if (row.inputtypekbn === Enum入力タイプ.半角文字_年月) {
              row.value = row.value.replace(/[^0-9\-\/]/g, '')
            }
            if (row.inputtypekbn === Enum入力タイプ.半角文字_年月_不詳あり) {
              row.value = row.value.replace(/[^Aa0-9\-\/]/g, '')
            }
            if (row.inputtypekbn === Enum入力タイプ.半角文字_時刻) {
              row.value = row.value.replace(/[^0-9:]/g, '')
            }
            if (row.inputtypekbn === Enum入力タイプ.半角文字_半角) {
              row.value = replaceText(row.value, EnumRegex.半角)
            }
            if (row.isageflg) {
              row.value = row.value.replace(/[^-,0-9]/g, '')
            }
            events.onChange?.(row)
          }}
        />
      </Form.Item>
    )
  }
}

/**数値 */
const RenderNum = ({ row, validateInfo = {}, extra = '', events }) => {
  //only have keta1
  const onlyketa1 = row.hanif === '' && row.hanit === '' && row.keta1
  const keta1range = [
    Math.pow(10, row.keta1 - 1),
    Math.pow(10, row.keta1) - (row.keta2 ? 0.1 ** row.keta2 : 1)
  ]
  let min
  let max

  function clearUnvalid(e) {
    if (onlyketa1 && e.target.value > -keta1range[0] && e.target.value < keta1range[0]) {
      row.value = null
    }
  }
  function onStep(v, { type }) {
    if (onlyketa1 && v > -keta1range[0] && v < keta1range[0]) {
      row.value = type === 'up' ? keta1range[0] : -keta1range[0]
    }
  }

  if (row.inputtypekbn === Enum入力タイプ.数値_小数点付き実数) {
    if (onlyketa1) {
      min = -keta1range[1]
      max = keta1range[1]
    }
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <InputNumber
          min={row.hanif || min}
          max={row.hanit || max}
          v-model:value={row.value}
          stringMode
          precision={row.keta2 || 0}
          step={row.keta2 ? 0.1 ** row.keta2 : 1}
          class="w-full"
          onBlur={() => events.onFinish?.(row)}
          onChange={() => events.onChange?.(row)}
          onPressEnter={clearUnvalid}
          onStep={onStep}
        />
      </Form.Item>
    )
  }

  if (row.inputtypekbn === Enum入力タイプ.数値_符号付き整数) {
    if (onlyketa1) {
      min = -keta1range[1]
      max = keta1range[1]
    }
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <InputNumber
          min={row.hanif || min}
          max={row.hanit || max}
          v-model:value={row.value}
          precision={0}
          class="w-full"
          onBlur={() => events.onFinish?.(row)}
          onChange={() => events.onChange?.(row)}
          onPressEnter={clearUnvalid}
          onStep={onStep}
        />
      </Form.Item>
    )
  }

  // default:Enum入力タイプ.数値_整数
  if (onlyketa1) {
    min = keta1range[0]
    max = keta1range[1]
  }
  return (
    <Form.Item extra={extra} {...validateInfo}>
      <InputNumber
        min={row.hanif || min || 0}
        max={row.hanit || max}
        v-model:value={row.value}
        precision={0}
        class="w-full"
        onBlur={() => events.onFinish?.(row)}
        onChange={() => events.onChange?.(row)}
      />
    </Form.Item>
  )
}

/**選択 */
const RenderSelect = ({ row, validateInfo = {}, extra = '', events, defaultOpen = false }) => {
  return (
    <Form.Item extra={extra} {...validateInfo}>
      <AiSelect
        class="vxe-table--ignore-clear"
        v-model:value={row.value}
        get-popup-container={null}
        defaultOpen={defaultOpen}
        options={row.cdlist}
        onChange={(_, __, oldVal) => {
          events.onChange?.(row, oldVal)
          nextTick(() => events.onFinish?.(row))
        }}
      />
    </Form.Item>
  )
}

/**日付 */
const RenderDate = ({ row, validateInfo = {}, extra = '', events }) => {
  function changeDate(v) {
    row.value = v ? dayjs(v).format('YYYY-MM-DD') : null
    events.onChange?.(row)
    nextTick(() => events.onFinish?.(row))
  }

  if (row.inputtypekbn === Enum入力タイプ.日付_年月日_不詳あり) {
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <DateJp
          value={row.value}
          unknown={true}
          hanif={row.hanif}
          hanit={row.hanit}
          onChange={changeDate}
          onEmitUnknownDate={(v) => (row.value = v)}
          style={{ maxWidth: '190px' }}
        />
      </Form.Item>
    )
  }

  if (row.inputtypekbn === Enum入力タイプ.日時_年月日時分秒) {
    return (
      <Form.Item extra={extra} {...validateInfo}>
        <DateTime
          v-model:value={row.value}
          hanif={row.hanif}
          hanit={row.hanit}
          onChange={() => {
            events.onChange?.(row)
            nextTick(() => events.onFinish?.(row))
          }}
        />
      </Form.Item>
    )
  }

  // default:Enum入力タイプ.日付_年月日
  return (
    <Form.Item extra={extra} {...validateInfo}>
      <DateJp
        value={row.value}
        hanif={row.hanif}
        hanit={row.hanit}
        onChange={changeDate}
        style={{ maxWidth: '170px' }}
      />
    </Form.Item>
  )
}

/**検索 */
const RenderSearch1 = ({ row, validateInfo = {}, extra = '', events }) => {
  return (
    <div class="flex">
      <Form.Item extra={extra} {...validateInfo} class="flex-1 mr-[4px]">
        {row.inputtypekbn === Enum入力タイプ.宛名番号 && (
          <Atenano
            v-model:value={row.value}
            onSearch={(val: string) => {
              row.value = val
              events.onChange?.(row)
              nextTick(() => events.onFinish?.(row))
            }}
            onBlur={() => events.onFinish?.(row)}
          />
        )}
      </Form.Item>
    </div>
  )
}
/**選択_検索 */
const RenderSearch2 = ({ row, validateInfo = {}, extra = '', events, defaultOpen = false }) => {
  return (
    <div class="flex">
      <Form.Item extra={extra} {...validateInfo} class="flex-1 mr-[4px]">
        <AiSelect
          id={'event-tab-stop-' + Math.floor(Math.random() * 900000)}
          v-model:value={row.value}
          get-popup-container={null}
          splitVal
          defaultOpen={defaultOpen}
          options={row.cdlist}
          onChange={() => {
            events.onChange?.(row)
            nextTick(() => events.onFinish?.(row))
          }}
        />
      </Form.Item>

      {[Enum入力タイプ.医療機関, Enum入力タイプ.検診実施機関].includes(row.inputtypekbn) && (
        <OrganizeButton
          jigyocds={row.jigyocds}
          onSelect={(val: OrganizeVM) => {
            row.value =
              row.inputtypekbn === Enum入力タイプ.医療機関 ? val.kikancd : val.hokenkikancd
            events.onChange?.(row)
            nextTick(() => events.onFinish?.(row))
          }}
        />
      )}
      {row.inputtypekbn === Enum入力タイプ.事業従事者 && (
        <StaffButton
          jigyocds={row.jigyocds}
          onSelect={(val: StaffVM) => {
            row.value = val.staffid
            events.onChange?.(row)
            nextTick(() => events.onFinish?.(row))
          }}
        />
      )}
    </div>
  )
}

export { RenderText, RenderNum, RenderDate, RenderSelect, RenderSearch1, RenderSearch2 }
