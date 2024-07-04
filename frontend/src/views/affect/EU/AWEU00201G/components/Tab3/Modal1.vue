<template>
  <a-modal
    v-model:visible="modalVisible"
    :title="tableIndex > -1 ? (copyflg ? '項目コピー' : '項目詳細') : '項目追加'"
    width="800px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <div class="self_adaption_table form">
      <a-row>
        <a-col v-bind="layout">
          <th class="bg-readonly">項目ID</th>
          <TD>{{ formData.yosikiitemid }}</TD>
        </a-col>
        <a-col v-bind="layout">
          <th :class="formData.reportoutputflg ? 'required' : ''">帳票項目名</th>
          <td>
            <a-form-item v-bind="validateInfos.reportitemnm">
              <a-input v-model:value="formData.reportitemnm" maxlength="50" />
            </a-form-item>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th :class="formData.csvoutputflg ? 'required' : ''">CSV項目名</th>
          <td>
            <a-form-item v-bind="validateInfos.csvitemnm"
              ><a-input v-model:value="formData.csvitemnm" maxlength="50"
            /></a-form-item>
          </td> </a-col
        ><a-col v-if="props.yosikikbn == Enum様式種別詳細.単純集計表" v-bind="layout">
          <th class="required">集計区分</th>
          <td>
            <a-form-item v-bind="validateInfos.crosskbn">
              <a-select
                v-model:value="formData.crosskbn"
                :options="transferToSyukeiEnumOption(options.selectorlist1)"
                style="width: 100%"
                @change="onChangeCrosskbn"
              ></a-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col
          v-if="
            props.yosikikbn == Enum様式種別詳細.単純集計表 && formData.crosskbn == Enum集計区分.集計
          "
          span="24"
        >
          <th class="required">集計方法</th>
          <td>
            <a-form-item v-bind="validateInfos.syukeihoho">
              <ai-select
                v-model:value="formData.syukeihoho"
                :options="syukeihohoList"
                split-val
                type="number"
                @change="onChange"
              ></ai-select
            ></a-form-item></td
        ></a-col>
        <a-col v-bind="layout">
          <th class="bg-readonly">SQLカラム</th>
          <TD>{{ formData.sqlcolumn }}</TD>
        </a-col>

        <a-col v-bind="layout">
          <th class="required">項目区分</th>
          <td>
            <a-form-item v-bind="validateInfos.itemkbn">
              <ai-select
                v-model:value="formData.itemkbn"
                :options="transferToEnumOptions(options.selectorlist2)"
                split-val
                style="width: 100%"
                allow-clear
              ></ai-select
            ></a-form-item>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>出力</th>
          <td>
            <a-form-item v-bind="errorInfos">
              <a-checkbox v-model:checked="formData.reportoutputflg">帳票出力</a-checkbox>
              <a-checkbox v-model:checked="formData.csvoutputflg">CSV出力</a-checkbox>
            </a-form-item>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th class="required">並び替え</th>
          <td>
            <a-select
              v-model:value="formData.orderkbn"
              :options="
                transferToEnumOptions(options.selectorlist3).map((e) => {
                  if (e.value == Enum並び替え.無し) {
                    e.label = 'ᅳ'
                  }
                  return e
                })
              "
              style="width: 100%"
              :disabled="yosikikbn == Enum様式種別詳細.単純集計表"
            ></a-select>
          </td>
        </a-col>
        <a-col v-if="!disabled_kaipageflg" v-bind="layout">
          <th>改ページ</th>
          <td>
            <a-checkbox
              :checked="formData.kaipageflg"
              :disabled="disabled_kaipageflg"
              @change="onChangeKaipageflg"
              >値が変わるとき改ページする</a-checkbox
            >
          </td>
        </a-col>
        <a-col v-if="yosikikbn == Enum様式種別詳細.経年表" v-bind="layout">
          <th>改列</th>
          <td>
            <a-checkbox :checked="formData.headerflg" @change="onChangeHeaderflg"
              >年度フラグ</a-checkbox
            >
          </td>
        </a-col>
      </a-row>

      <h3 class="mt-2">フォーマット</h3>
      <a-row>
        <a-col v-bind="layout">
          <th>白紙時出力</th>
          <td>
            <a-input v-model:value="formData.blankvalue" maxlength="100"></a-input>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>区分</th>
          <td>
            <a-select
              v-model:value="formData.formatkbn"
              :options="formatlist"
              style="width: 100%"
              :field-names="{ label: 'formatnm', value: 'formatkbn' }"
              allow-clear
              @change="
                () => {
                  formData.formatkbn2 = undefined
                  formData.formatsyosai = undefined
                  formData.height = undefined
                  formData.width = undefined
                  formData.offsetx = undefined
                  formData.offsety = undefined
                }
              "
            ></a-select>
          </td>
        </a-col>
      </a-row>
      <!-- 文字について -->
      <a-row
        v-show="formData.formatkbn && (!isImage || +formData.formatkbn === ArEnumFormat.バーコード)"
      >
        <a-col v-bind="layout">
          <th>詳細</th>
          <td>
            <a-select
              v-model:value="formData.formatkbn2"
              style="width: 100%"
              allow-clear
              :options="syosailist"
              :field-names="{
                label: [
                  ArEnumFormat.年,
                  ArEnumFormat.年月日,
                  ArEnumFormat.年月日時分秒,
                  ArEnumFormat.時分秒
                ].includes(Number(formData.formatkbn))
                  ? 'formatsyosai'
                  : 'formattypenm',
                value: 'formatkbn2'
              }"
              @change="onChangeFormatkbn2"
            >
              <template #option="option">
                {{ getSyosaiLabel(option) }}
              </template>
            </a-select>
          </td>
        </a-col>
        <template v-if="isTwoNum">
          <a-col v-show="showCustomSyosai" v-bind="layout">
            <th>開始位置</th>
            <td>
              <a-input-number
                :value="curSyosai.a"
                style="width: 100%"
                :min="1"
                :max="99"
                @change="
                  (val) =>
                    (curSyosai = {
                      a: val,
                      b: curSyosai.b
                    })
                "
              ></a-input-number></td
          ></a-col>
          <a-col v-show="showCustomSyosai" v-bind="layout">
            <th>文字数</th>
            <td>
              <a-input-number
                :value="curSyosai.b"
                style="width: 100%"
                :min="1"
                :max="99"
                @change="
                  (val) =>
                    (curSyosai = {
                      a: curSyosai.a,
                      b: val
                    })
                "
              ></a-input-number></td
          ></a-col>
        </template>
        <a-col v-else v-show="showCustomSyosai" v-bind="layout">
          <th>フォーマッター</th>
          <td>
            <a-input v-model:value="formData.formatsyosai" maxlength="50"></a-input></td
        ></a-col>
      </a-row>
      <!-- QRコードについて -->
      <a-row v-show="isImage">
        <a-col v-show="Number(formData.formatkbn) !== ArEnumFormat.QRコード" v-bind="layout">
          <th class="required">高さ</th>
          <td>
            <a-form-item v-bind="validateInfos.height">
              <a-input-number
                v-model:value="formData.height"
                style="width: 100%"
                :max="99"
                :min="1"
                placeholder="10"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th class="required">幅</th>
          <td>
            <a-form-item v-bind="validateInfos.width">
              <a-input-number
                v-model:value="formData.width"
                style="width: 100%"
                :max="99"
                :min="1"
                :placeholder="Number(formData.formatkbn) !== ArEnumFormat.QRコード ? 30 : 15"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>水平調整</th>
          <td>
            <a-input-number
              v-model:value="formData.offsetx"
              style="width: 100%"
              :max="99"
              :min="-99"
            ></a-input-number>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>垂直調整</th>
          <td>
            <a-input-number
              v-model:value="formData.offsety"
              style="width: 100%"
              :max="99"
              :min="-99"
            ></a-input-number>
          </td>
        </a-col>
      </a-row>
    </div>

    <template #footer>
      <a-space class="float-left">
        <a-button type="primary" @click="saveItem">確定</a-button>
        <a-button type="primary" danger :disabled="copyflg" @click="deleteItem">削除</a-button>
      </a-space>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, ref, watch, reactive, nextTick } from 'vue'
import { message, Form } from 'ant-design-vue'
import {
  Enumデータタイプ as ArEnumFormat,
  Enum並び替え,
  Enum出力項目区分,
  Enum明細有無,
  Enum様式作成方法,
  Enum様式種別詳細,
  Enum行列固定,
  Enum集計区分,
  Enum集計方法
} from '#/Enums'
import { showDeleteModal, showInfoModal } from '@/utils/modal'
import {
  A060001,
  A060002,
  E001008,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR
} from '@/constants/msg'
import { ReportItemDetailVM } from '../../type'
import { InitResponse, FormatVM, FormatSyosaiVM } from '@/views/affect/EU/AWEU00205D/type'
import { InitFormat } from '@/views/affect/EU/AWEU00205D/service'
import { EUCStore, GlobalStore } from '@/store'
import { toArray } from 'xe-utils'
import emitter from '@/utils/event-bus'
import { Judgement } from '@/utils/judge-edited'
import { Check } from '@/views/affect/EU/AWEU00204D/service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------

const layout = {
  span: 24
}

const props = defineProps<{
  visible: boolean
  tableList: ReportItemDetailVM[]
  options: Omit<InitResponse, keyof DaResponseBase>
  tableIndex: number
  yosikikbn: Enum様式種別詳細
  yosikihouhou: Enum様式作成方法
  pdfflg: boolean
  excelflg: boolean
  otherflg: boolean
  /**コピーフラグ */
  copyflg: boolean
}>()
const emit = defineEmits(['update:visible', 'update:tableList'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement()
function createDefaultForm(): ReportItemDetailVM {
  return {
    yosikiitemid: '',
    reportitemnm: '',
    csvitemnm: '',
    sqlcolumn: '',
    tablealias: '',
    orderkbn: Enum並び替え.無し,
    reportoutputflg: false,
    csvoutputflg: false,
    headerflg: false,
    kaipageflg: false,
    itemkbn: Enum出力項目区分.普通項目,
    formatkbn: '',
    formatkbn2: '',
    formatsyosai: '',
    height: undefined,
    width: undefined,
    offsetx: undefined,
    offsety: undefined,
    blankvalue: '',
    mastercd: '',
    masterpara: '',
    keyvaluepairsjson: '',
    crosskbn: Enum集計区分.集計,
    syukeihoho: Enum集計方法.Count,
    level: undefined,
    daibunrui: ''
  }
}
const formData = reactive<ReportItemDetailVM>(createDefaultForm())
const rules = reactive({
  reportitemnm: [
    {
      validator: (_rule, value: string) => {
        if (formData.reportoutputflg && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票項目名'))
        }
        return Promise.resolve()
      }
    }
  ],
  csvitemnm: [
    {
      validator: (_rule, value: string) => {
        if (formData.csvoutputflg && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'CSV項目名'))
        }
        return Promise.resolve()
      }
    }
  ],
  crosskbn: [
    {
      required: props.yosikikbn == Enum様式種別詳細.単純集計表,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '集計区分')
    }
  ],
  syukeihoho: [
    {
      validator: (_rule, value: any) => {
        if (
          !value &&
          props.yosikikbn == Enum様式種別詳細.単純集計表 &&
          formData.crosskbn == Enum集計区分.集計
        ) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '集計方法'))
        }
        return Promise.resolve()
      }
    }
  ],
  itemkbn: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '項目区分')
    }
  ],
  height: [
    {
      validator: (_rule, value: any) => {
        if (!value && Number(formData.formatkbn) == ArEnumFormat.バーコード) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '高さ'))
        }
        return Promise.resolve()
      }
    }
  ],
  width: [
    {
      validator: (_rule, value: any) => {
        if (
          !value &&
          (Number(formData.formatkbn) == ArEnumFormat.バーコード ||
            Number(formData.formatkbn) == ArEnumFormat.QRコード)
        ) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '幅'))
        }
        return Promise.resolve()
      }
    }
  ]
})

const rules2 = reactive({
  csvoutputflg: [
    {
      validator: (_rule, value1: any) => {
        if (value1 && !props.otherflg) {
          return Promise.reject(
            A060001.Msg.replace('{0}', 'CSV出力形式').replace('{1}', '様式設定')
          )
        }
        return Promise.resolve()
      },
      trigger: 'change'
    }
  ],
  reportoutputflg: [
    {
      validator: (_rule, value1: any) => {
        if (value1 && !props.pdfflg && !props.excelflg) {
          return Promise.reject(
            A060001.Msg.replace('{0}', '帳票出力形式').replace('{1}', '様式設定')
          )
        }
        return Promise.resolve()
      },
      trigger: 'change'
    }
  ]
})

const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)
const formatlist = ref<FormatVM[]>([])
const syukeihohoList = reactive<DaSelectorModel[]>([
  { value: '1', label: 'Count' },
  { value: '2', label: 'Sum' }
])

const {
  validate: validate2,
  validateInfos: validateInfos2,
  mergeValidateInfo
} = Form.useForm(formData, rules2)
const errorInfos = computed(() => {
  return mergeValidateInfo(toArray(validateInfos2))
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})

const isImage = computed(() =>
  // [ArEnumFormat.バーコード, ArEnumFormat.QRコード, ArEnumFormat.図].includes(
  //   Number(formData.formatkbn)
  // )
  [ArEnumFormat.バーコード, ArEnumFormat.QRコード].includes(Number(formData.formatkbn))
)

//最大ソート値
const maxSortSeq = computed(() => {
  if (props.tableList.length === 0) return 0
  const maxItem = props.tableList.reduce((max, cur) => {
    return Number(cur.orderseq) > Number(max.orderseq) ? cur : max
  })
  return maxItem.orderseq ?? 0
})
//詳細
const syosailist = computed(() => {
  return formatlist.value.find((item) => String(item.formatkbn) === String(formData.formatkbn))
    ?.syosailist
})
//改ページ
const disabled_kaipageflg = computed(
  () =>
    !(
      props.yosikikbn == Enum様式種別詳細.一覧表 ||
      (props.yosikikbn == Enum様式種別詳細.台帳 && EUCStore['meisaiflg']) ||
      props.yosikikbn == Enum様式種別詳細.経年表
    )
)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      InitFormat().then((res) => (formatlist.value = res.formatlist))
      if (props.tableIndex > -1) {
        Object.assign(formData, props.tableList[props.tableIndex])
        if (props.copyflg) {
          formData.yosikiitemid += '_1'
          formData.reportitemnm += '_1'
          formData.csvitemnm += '_1'
        }
        formData.syukeihoho = formData.sqlcolumn.startsWith('COUNT')
          ? Enum集計方法.Count
          : formData.sqlcolumn.startsWith('SUM')
          ? Enum集計方法.Sum
          : undefined
      } else {
        Object.assign(formData, createDefaultForm())
        clearValidate('yosikiitemid')
        clearValidate('reportitemnm')
      }
      //単純集計表の場合、並び替え無効化
      if (props.yosikikbn == Enum様式種別詳細.単純集計表) {
        formData.orderkbn = Enum並び替え.無し
      }
      nextTick(() => editJudge.reset())
    }
  }
)

//並びシーケンス
watch(
  () => formData.orderkbn,
  () => {
    if (formData.orderkbn !== Enum並び替え.無し) {
      formData.orderseq = maxSortSeq.value + 1
    } else {
      formData.orderseq = undefined
    }
  }
)
watch(
  () => formData,
  () => {
    editJudge.setEdited()
  },
  { deep: true }
)

//集計COUNT,SUMを補います
const onChangeCrosskbn = () => {
  formData.syukeihoho = undefined

  const regex1 = /count\(([^)]*)\)/i
  const regex2 = /sum\(([^)]*)\)/i
  if (formData.sqlcolumn.match(regex1)) {
    formData.sqlcolumn = formData.sqlcolumn.replace(regex1, '$1')
  } else if (formData.sqlcolumn.match(regex2)) {
    formData.sqlcolumn = formData.sqlcolumn.replace(regex2, '$1')
  }
}
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//詳細(ユーザー定義)
const showCustomSyosai = computed(() => {
  return syosailist.value?.find((el) => el.formatkbn2 === formData.formatkbn2)?.userdefinedflg
})
const isTwoNum = computed(
  () => Number(formData.formatkbn) === ArEnumFormat.文字 && formData.formatkbn2 === '1'
)
const curSyosai = computed({
  get() {
    const [a, b] = (formData.formatsyosai ?? ',').split(',')
    return { a, b }
  },
  set({ a, b }) {
    formData.formatsyosai = (a ?? '') + ',' + (b ?? '')
  }
})
function onChangeFormatkbn2(_, opt: FormatSyosaiVM) {
  formData.formatsyosai = opt?.formattypenm === '丸空白' ? '〇/' : opt?.formatsyosai

  if (opt && Number(formData.formatkbn) === ArEnumFormat.文字) {
    if (opt.formatkbn2 === '1') {
      // isTwoNum.value = true
      formData.formatsyosai = ',1'
    } else {
      formData.formatsyosai = opt.formatsyosai ?? '{0}様'
    }
  }
}

//項目詳細削除
const deleteItem = () => {
  showDeleteModal({
    onOk() {
      const array = JSON.parse(JSON.stringify(props.tableList))
      array.splice(props.tableIndex, 1)
      emit('update:tableList', array)
      editJudge.reset()
      closeModal()
    }
  })
}

//項目詳細登録処理
const saveItem = async () => {
  await Promise.all([validate(), validate2()])

  //重複チェック
  //if (checkDuplicate('yosikiitemid', '帳票項目ID')) return
  if (checkDuplicate('reportitemnm', '帳票項目名')) return
  if (checkDuplicate('csvitemnm', 'CSV項目名')) return

  //check フォーマット区分
  if (props.yosikihouhou == Enum様式作成方法.データソース) {
    try {
      await Check({
        sqlcolumn: formData.sqlcolumn,
        formatkbn: formData.formatkbn,
        formatkbn2: formData.formatkbn2
      })
    } catch (error) {
      console.log(error)
      return
    }
  }

  const array = JSON.parse(JSON.stringify(props.tableList))
  if (props.copyflg) {
    array.splice(props.tableIndex + 1, 0, JSON.parse(JSON.stringify(formData)))
  } else {
    array.splice(props.tableIndex, 1, JSON.parse(JSON.stringify(formData)))
  }

  emit('update:tableList', array)
  const result = array
    .filter((el) => el.orderkbn !== Enum並び替え.無し)
    .sort((a, b) => Number(a.orderkbnseq) - Number(b.orderkbnseq))
    .map((el) => {
      return {
        reportitemid: el.yosikiitemid,
        descflg: el.orderkbn === Enum並び替え.降順,
        pageflg: false
      }
    })
  emitter.emit('sortsublist', result)
  editJudge.reset()
  closeModal()
}

//項目詳細閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    Object.assign(formData, createDefaultForm())
    emit('update:visible', false)
    nextTick(() => editJudge.reset())
  })
}

function transferToEnumOptions(opts: DaSelectorModel[]) {
  return opts.map((opt) => ({ label: opt.label, value: parseInt(opt.value) }))
}
function transferToSyukeiEnumOption(opts: DaSelectorModel[]) {
  let options = transferToEnumOptions(opts)
    .filter((e) => e.value != Enum集計区分.GroupBy横)
    .map((item) => (item.value == Enum集計区分.GroupBy縦 ? { ...item, label: 'GroupBy' } : item))
  return options
}

//改ページ
function onChangeKaipageflg(e) {
  if (props.tableList.toSpliced(props.tableIndex, 1).some((el) => el.kaipageflg)) {
    message.warning(A060002.Msg.replace('{0}', '改ページ'))
  } else {
    formData.kaipageflg = e.target.checked
  }
}
//改ページ
function onChangeHeaderflg(e) {
  if (props.tableList.toSpliced(props.tableIndex, 1).some((el) => el.headerflg)) {
    message.warning(A060002.Msg.replace('{0}', '改列'))
  } else {
    formData.headerflg = e.target.checked
  }
}

const onChange = () => {
  if (formData.crosskbn == Enum集計区分.集計)
    formData.sqlcolumn = getUpperSqlcolumn(formData.syukeihoho, formData.sqlcolumn)
  //単純集計帳票項目名
  if (formData.crosskbn == Enum集計区分.集計 && formData.reportoutputflg) {
    const fixes = ['の件数', 'の合計']
    const endfix =
      formData.syukeihoho === Enum集計方法.Count
        ? fixes[0]
        : formData.syukeihoho === Enum集計方法.Sum
        ? fixes[1]
        : ''
    fixes.forEach((fix) => {
      if (formData.reportitemnm.endsWith(fix) && fix !== endfix) {
        formData.reportitemnm = formData.reportitemnm.slice(0, -fix.length)
      }
      if (formData.csvitemnm.endsWith(fix) && fix !== endfix) {
        formData.csvitemnm = formData.csvitemnm.slice(0, -fix.length)
      }
    })
    if (endfix && !formData.reportitemnm.endsWith(endfix)) {
      formData.reportitemnm += endfix
    }
    if (endfix && !formData.csvitemnm.endsWith(endfix)) {
      formData.csvitemnm += endfix
    }
  }
}

const getUpperSqlcolumn = (syukeihoho, sqlcolumn: string) => {
  let array = sqlcolumn.match(/\((.*?)\)/g)
  if (array && !syukeihoho) {
    return sqlcolumn
  }
  let result = array ? array.map((item) => item.slice(1, -1))[0] : sqlcolumn
  if (Number(syukeihoho) == Enum集計方法.Count) {
    return 'COUNT(' + result + ')'
  } else if (Number(syukeihoho) == Enum集計方法.Sum) {
    return 'SUM(' + result + ')'
  }
  return result
}

function checkDuplicate(propertyName, displayName) {
  const isDuplicate = props.tableList.some((item, index) => {
    return (
      item[propertyName] === formData[propertyName] && (index !== props.tableIndex || props.copyflg)
    )
  })
  if (formData[propertyName] && isDuplicate) {
    showInfoModal({
      type: 'error',
      title: 'エラー',
      content: E001008.Msg.replace('{0}', displayName)
    })
    return true
  }
  return false
}

//詳細のlabel
const getSyosaiLabel = (option) => {
  if (
    [ArEnumFormat.年, ArEnumFormat.年月日, ArEnumFormat.年月日時分秒, ArEnumFormat.時分秒].includes(
      Number(formData.formatkbn)
    )
  ) {
    return option.formatsyosai
      ? `${option.formatsyosai}（${option.formatexample}）`
      : option.formattypenm ?? ''
  }
  if (Number(formData.formatkbn) === ArEnumFormat.論理型) {
    return option.formatsyosai ? `${option.formatsyosai}` : ''
  }
  return option.formattypenm ?? ''
}
</script>
<style lang="less" scoped>
.ant-form-item {
  width: 100%;
  margin-bottom: 0px;
}
th {
  width: 130px;
}
</style>
