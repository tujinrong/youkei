<template>
  <div>
    <div class="self_adaption_table form" style="width: 100%">
      <a-row>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">様式種別</th>
          <TD>{{ Enum様式種別[form.yosikisyubetu] }} </TD>
        </a-col>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">様式種別詳細</th>
          <TD>{{ yosikisyubetu ? yosikisyubetu : '' }} </TD>
        </a-col>
      </a-row>
      <a-row class="my-4">
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="bg-readonly">作成方法</th>
          <TD>{{ Enum様式作成方法[yosikihouhou] }}</TD>
        </a-col>
        <a-col :md="12" :xl="9" :xxl="6">
          <th>並びシーケンス</th>
          <td>
            <a-input-number v-model:value="form.orderseq" :max="32767" :min="0" class="w-full" />
          </td>
        </a-col>
        <template v-if="false">
          <a-col :md="12" :xl="9" :xxl="6">
            <th class="bg-readonly">データソースID</th>
            <TD>{{ props.rptdatasourceid || props.datasourceid }}</TD>
          </a-col>
          <a-col :md="12" :xl="9" :xxl="6">
            <th class="bg-readonly">データソース名</th>
            <TD>{{ !isNew ? form.datasourcenm : props.datasourcenm }}</TD>
          </a-col>
        </template>
      </a-row>

      <a-row class="mt-4">
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="required">出力形式</th>
          <td>
            <a-space>
              <a-checkbox v-model:checked="form.excelflg">EXCEL</a-checkbox>
              <a-checkbox v-model:checked="form.pdfflg">PDF</a-checkbox>
              <a-checkbox v-model:checked="form.otherflg" :disabled="!isDisabledCsv"
                >CSV</a-checkbox
              >
            </a-space>
          </td>
        </a-col>
      </a-row>

      <a-row>
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="required">内外区分</th>
          <td>
            <a-form-item v-bind="validateInfos.naigaikbn">
              <ai-select
                v-model:value="form.naigaikbn"
                :options="naigaikbnOpts"
                type="number"
                @change="handleNaigaikbn"
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>

      <a-row v-show="isShowDistinctflg">
        <a-col :md="12" :xl="9" :xxl="6">
          <th>重複データ排除</th>
          <td>
            <a-checkbox v-model:checked="form.distinctflg"></a-checkbox>
          </td>
        </a-col>
      </a-row>
      <a-row v-show="isShowNullZeroFlg">
        <a-col :md="12" :xl="9" :xxl="6">
          <th>空白値ゼロ出力</th>
          <td>
            <a-checkbox v-model:checked="form.nulltozeroflg"></a-checkbox>
          </td>
        </a-col>
      </a-row>
      <a-row v-show="!isInside">
        <a-col :md="12" :xl="9" :xxl="6">
          <th>課</th>
          <td>
            <a-select v-model:value="form.kacd" style="width: 100%" :options="kacdList"></a-select>
          </td>
        </a-col>
        <a-col :md="12" :xl="9" :xxl="6">
          <th>係</th>
          <td>
            <a-select
              v-model:value="form.kakaricd"
              style="width: 100%"
              :options="kakaricdList"
            ></a-select>
          </td>
        </a-col>
        <a-col :md="16" :xl="12" :xxl="8">
          <th>問い合わせ</th>
          <td>
            <a-select
              v-model:value="form.toiawasesakicd"
              style="width: 100%"
              :options="settinglistOptions"
              :field-names="{ label: 'label', value: 'value' }"
              @change="handleSetting"
            ></a-select>
          </td>
        </a-col>

        <a-col v-bind="fullLayout">
          <th>公印</th>
          <td>
            <a-space>
              <a-checkbox v-model:checked="form.koinnmflg">市区町村印字</a-checkbox>
              <a-checkbox v-model:checked="form.koinpicflg">電子更新印字公印</a-checkbox>
              <a-checkbox v-model:checked="form.dairisyaflg">職務代理者適用</a-checkbox>
            </a-space>
          </td>
        </a-col>
      </a-row>

      <a-row v-if="EUCStore['yosikihimonm']" class="mb-4">
        <a-col :md="12" :xl="9" :xxl="6">
          <th class="required">様式紐付け値</th>
          <td>
            <a-form-item v-bind="validateInfos.himozukevalue">
              <ai-select
                v-model:value="form.himozukevalue"
                :options="himozukevalueOption"
                split-val
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row
        ><a-col :md="12" :xl="9" :xxl="6">
          <th>帳票発行履歴更新</th>
          <td>
            <a-checkbox v-model:checked="form.hakoflg"></a-checkbox>
          </td> </a-col
      ></a-row>
      <a-row class="mt-4" style="display: flex">
        <a-col v-bind="fullLayout">
          <th class="content-center">更新プロシージャ</th>
          <td>
            <a-checkbox :checked="form.updateflg" @change="onchangeSql"></a-checkbox>
            <div v-if="form.updateflg" style="border: 1px solid #606266">
              <a-form-item v-bind="validateInfos.updatesql">
                <codemirror
                  v-model="form.updatesql"
                  style="width: 100%"
                  v-bind="updateSqlConfig(parammeterOption)"
                ></codemirror>
              </a-form-item>
            </div>
          </td>
        </a-col>
      </a-row>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, watch, computed, nextTick, Ref } from 'vue'
import { Codemirror } from 'vue-codemirror'
import { useRoute } from 'vue-router'
import { Form } from 'ant-design-vue'
import {
  Enum内外区分,
  Enum様式種別,
  Enum様式種別詳細,
  Enum様式作成方法,
  Enum明細有無,
  Enum帳票様式,
  Enum検索条件区分,
  Enum行列固定,
  Enum編集区分
} from '#/Enums'
import { Judgement } from '@/utils/judge-edited'
import emitter from '@/utils/event-bus'
import { YosikiTabInfoVM, SearchConditionVM } from '../../type'
import { fullLayout } from '../../constants'
import { updateSqlConfig } from './constants'
import { SearchYosikiTab } from '../../service'
import { showConfirmModal } from '@/utils/modal'
import {
  ITEM_SELECTREQUIRE_ERROR,
  ITEM_REQUIRE_ERROR,
  DELETE_CONFIRM,
  LOGIC_DELETE_CONFIRM
} from '@/constants/msg'
import { EUCStore } from '@/store'
import { SearchOtherConditionTab } from '@/views/affect/EU/AWEU00101G/service'
import TD from '@/components/Common/TableTD/index.vue'
import SearchModal from '@/views/affect/EU/AWEU00106D/index.vue'

type formType = YosikiTabInfoVM & {
  datasourceid: string
  datasourcenm: string
}

const props = defineProps<{
  rptid: string
  rptnm: string
  yosikiid: string
  yosikieda: number
  datasourceid: string
  rptdatasourceid: string
  datasourcenm: string
  sql: string
  procnm: string
  yosikihouhou: Enum様式作成方法
  kbn: Enum帳票様式 | string //Enum帳票様式
  naigaikbnOptions: DaSelectorModel[]
  settinglistOptions: DaSelectorModel[]
  himozukevalueList: SearchConditionVM[]
  editJudge: Judgement
  kakaricdList: DaSelectorModel[]
  kacdList: DaSelectorModel[]
  keishouflg: boolean //継承フラグ
  completions: { label: string; type: string }[]
  tab1Ref: Ref
  tab4Ref: Ref
}>()
const emit = defineEmits(['update:isChangeProcedure', 'update:isHenshu'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const routes = useRoute()
const isNew = Boolean(routes.query.isNew)

function createDefaultForm(): formType {
  return {
    yosikisyubetu: Enum様式種別.一覧表, // 様式種別
    meisaikoteikbn: '', // 行（列）固定区分
    meisaiflg: false, // 明細有無
    yosikikbn: Enum様式種別詳細.一覧表, // 様式種別詳細
    pdfflg: false, // PDF 出力形式
    excelflg: false, // EXCEL 出力形式
    otherflg: false, // other 出力形式
    updateflg: false, // 更新フラグ
    sortptnno: undefined, //出力順パターン
    updatesql: '', // 更新SQL
    naigaikbn: Enum内外区分.内部帳票, // 内外区分
    koinnmflg: false, // 市区町村印字 公印
    koinpicflg: false, // 電子更新印字公印
    dairisyaflg: false, // 職務代理者適用 公印
    toiawasesakicd: '', // 問い合わせ
    hanyocd: '', // 問い合わせ内容
    hakoflg: undefined, //帳票発行履歴更新
    yosikihouhou: Enum様式作成方法.データソース, // 作成方法
    datasourceid: '', //データソースID
    datasourcenm: '',
    yosikisyosaiUpddttm: '',
    yosikiUpddttm: '',
    himozukevalue: '', // 様式紐付け値
    himozukejyokenid: undefined,
    hakokbn: '', // 帳票発行履歴区分
    distinctflg: false, //重複データ排除フラグ
    nulltozeroflg: false, //空白値ゼロ出力フラグ
    orderseq: undefined
  }
}
const form = reactive<formType>(createDefaultForm())
/** 新規別様式の場合、使用 */
const oldRptid = ref('')

const rules = computed(() => ({
  himozukevalue: [
    {
      validator: (_rule, value: string) => {
        if (EUCStore['yosikihimonm'] && !value && value != '0') {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '様式紐付け値'))
        }
        return Promise.resolve()
      }
    }
  ],
  naigaikbn: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '内外区分')
    }
  ],
  updatesql: [
    {
      validator: (_rule, value: string) => {
        if (form.updateflg && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '更新プロシージャ'))
        }
        return Promise.resolve()
      }
    }
  ]
}))

const { validate, validateInfos, resetFields, clearValidate } = Form.useForm(form, rules)

const route = useRoute()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isInside = computed(() => form.naigaikbn == Enum内外区分.内部帳票 || !form.naigaikbn)

const isDisabledCsv = computed(() =>
  [Enum様式種別詳細.一覧表, Enum様式種別詳細.単純集計表].includes(Number(form.yosikikbn))
)

const isShowNullZeroFlg = computed(() => Number(form.yosikikbn) === Enum様式種別詳細.クロス集計)

const isShowDistinctflg = computed(() => {
  const yosikikbnValue = Number(form.yosikikbn)
  return (
    yosikikbnValue !== Enum様式種別詳細.単純集計表 && yosikikbnValue !== Enum様式種別詳細.クロス集計
  )
})

const yosikisyubetu = computed(() => {
  switch (+form.yosikisyubetu) {
    // 一覧表場合
    case Enum様式種別.一覧表:
      return form.meisaikoteikbn
        ? Enum様式種別[form.yosikisyubetu] + '(' + '行' + Enum行列固定[form.meisaikoteikbn] + ')'
        : Enum様式種別詳細[form.yosikikbn]
    //台帳場合
    case Enum様式種別.台帳:
      return form.meisaiflg
        ? Enum様式種別[form.yosikisyubetu] +
            '(' +
            Enum明細有無[Number(form.meisaiflg)] +
            '/' +
            '行' +
            Enum行列固定[form.meisaikoteikbn] +
            ')'
        : Enum様式種別[form.yosikisyubetu] + '(' + Enum明細有無[Number(form.meisaiflg)] + ')'
    //集計表場合
    case Enum様式種別.集計表:
      return Number(form.yosikikbn) === Enum様式種別詳細.クロス集計
        ? Enum様式種別[form.yosikisyubetu] +
            '(' +
            Enum様式種別詳細[form.yosikikbn] +
            '/' +
            '行列' +
            Enum行列固定[form.meisaikoteikbn] +
            ')'
        : Enum様式種別[form.yosikisyubetu] + '(' + Enum様式種別詳細[form.yosikikbn] + ')'
    //カスタマイズ場合
    case Enum様式種別.カスタマイズ:
      return Enum様式種別[form.yosikisyubetu] + '(' + Enum様式種別詳細[form.yosikikbn] + ')'
    default:
      return Enum様式種別詳細[form.yosikikbn]
  }
})
//内外区分disabled
const naigaikbnOpts = computed(() => {
  return props.naigaikbnOptions.map((opt) => {
    return {
      ...opt,
      disabled:
        (+opt.value === Enum内外区分.外部帳票 && +form.yosikisyubetu === Enum様式種別.集計表) ||
        (+opt.value === Enum内外区分.内部帳票 && +form.yosikisyubetu === Enum様式種別.カスタマイズ)
    }
  })
})
const himozukevalueOption = computed(
  () =>
    props.tab4Ref.value
      ?.getFieldsValue()
      .find((item) => String(item.jyokenid) === String(EUCStore['yosikihimonm']))?.selectlist ?? []
)

const parammeterOption = computed(() => {
  const tyusyutupanels = [
    '@年度',
    '@抽出シーケンス',
    '@帳票出力区分',
    '@様式種別',
    '@発行データ詳細区分'
  ]
  if (props.tab1Ref.value && props.tab1Ref.value.getFieldsValue().tyusyutupanelflg) {
  }
  return [
    ...(props.tab1Ref.value?.getFieldsValue().tyusyutupanelflg
      ? props.completions
      : props.completions.filter((e) => !tyusyutupanels.includes(e.label))),
    ...props.tab4Ref.value?.getFieldsValue().map((e) => ({
      label: `@${e.jyokenlabel}`,
      type: 'variable'
    }))
  ]
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(form, () => props.editJudge.setEdited(), { deep: true })

watch(
  () => [props.rptid, props.yosikiid, props.yosikieda, props.datasourceid],
  () => {
    if (isNew && props.kbn == Enum帳票様式.帳票) {
      return
    }

    if (props.rptid && props.yosikiid && props.rptid == oldRptid.value) {
      const params = {
        rptid: props.rptid,
        yosikiid: props.yosikiid,
        yosikieda: props.yosikieda,
        datasourceid: props.datasourceid,
        kbn: Number(props.kbn),
        editkbn: route.query.isNew ? Enum編集区分.新規 : Enum編集区分.変更
      }
      SearchYosikiTab(params).then((res) => {
        if (!isNew) {
          Object.assign(form, {
            ...res.styleDetailParam
          })
        } else {
          const {
            yosikisyubetu,
            yosikikbn,
            excelflg,
            pdfflg,
            otherflg,
            naigaikbn,
            meisaikoteikbn,
            meisaiflg,
            ...rest
          } = res.styleDetailParam
          Object.assign(form, {
            ...rest
          })
        }
        nextTick(() => {
          props.editJudge.reset()
        })
      })
    }
  }
)

watch(
  () => form.meisaiflg,
  (newValue) => {
    EUCStore['meisaiflg'] = newValue
  },
  {
    immediate: true
  }
)
watch(
  () => props.himozukevalueList,
  (newvalue) => {
    if (newvalue && !newvalue.find((e) => e.jyokenid === Number(form.himozukevalue))) {
      form.himozukevalue = ''
    }
  }
)

watch(
  () => [form.naigaikbn, form.koinnmflg, form.koinpicflg],
  ([newValue1, newValue2, newValue3]) => {
    EUCStore['naigaikbn'] = newValue1
    EUCStore['koinnmflg'] = newValue2
    EUCStore['koinpicflg'] = newValue3
  }
)
watch(
  () => form.meisaikoteikbn,
  (newValue) => {
    EUCStore['meisaikoteikbn'] = newValue
  },
  { immediate: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const handleSetting = () => {
  //todo
  // form.hanyocd =
  //   props.settinglistOptions.find((item) => item.toiawasesakicd === form.toiawasesakicd)?.detail ??
  //   ''
}
//更新プロシージャ
const onchangeSql = () => {
  if (!form.updateflg) {
    form.updateflg = true
    return
  }
  if (!form.updatesql) {
    form.updateflg = false
    return
  }
  showConfirmModal({
    content: LOGIC_DELETE_CONFIRM.Msg.replace('{0}', 'プロシージャ'),
    onOk: async () => {
      form.updatesql = ''
      form.updateflg = false
    }
  })
}

const handleNaigaikbn = () => {
  if (form.naigaikbn == Enum内外区分.内部帳票) {
    Object.assign(form, {
      toiawasesakicd: '',
      hanyocd: '',
      kakaricd: '',
      kacd: '',
      koinnmflg: false,
      koinpicflg: false,
      dairisyaflg: false
    })
  }
}

const setFieldsValue = (data) => {
  Object.assign(form, data)
  EUCStore['naigaikbn'] = form.naigaikbn
  EUCStore['koinnmflg'] = form.koinnmflg
  EUCStore['koinpicflg'] = form.koinpicflg
  oldRptid.value = data.rptid
}

const getFieldsValue = () => {
  return {
    ...form,
    datasourceid: props.rptdatasourceid,
    himozukevalue: form.himozukevalue,
    himozukejyokenid: EUCStore['yosikihimonm']
  }
}

emitter.once('escapeValidate', () => {
  form.himozukevalue = undefined
  nextTick(() => {
    clearValidate('himozukevalue')
  })
})

defineExpose({
  validate,
  setFieldsValue,
  getFieldsValue
})
</script>

<style lang="less" src="./index.less" scoped></style>
