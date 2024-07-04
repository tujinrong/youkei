<template>
  <a-modal
    :visible="props.visible"
    title="帳票新規作成"
    width="800px"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
  >
    <a-form ref="formRef" :model="formParam">
      <div class="self_adaption_table form">
        <a-row>
          <a-col v-bind="layout">
            <a-radio-group v-model:value="formParam.kbn" :options="rptsbtOptions" />
          </a-col>

          <b class="mt-5 mb-1">帳票情報</b>
          <a-col v-if="isChouhyou" v-bind="layout">
            <th class="required">帳票No</th>
            <td>
              <a-form-item v-bind="validateInfos.rptid">
                <a-input
                  v-model:value="formParam.rptid"
                  allow-clear
                  :maxlength="4"
                  @change="formParam.rptid = replaceText(formParam.rptid, EnumRegex.半角数字)"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th class="required">帳票名</th>
            <td>
              <a-form-item v-if="isChouhyou" v-bind="validateInfos.rptnm">
                <a-input v-model:value="formParam.rptnm" maxlength="50" allow-clear />
              </a-form-item>

              <a-form-item v-else v-bind="validateInfos.rptnm">
                <ai-select
                  v-model:value="formParam.rptid"
                  :options="
                    otherOptionInfo?.reportlist?.map((item) => ({
                      label: item.rptnm,
                      value: item.rptid
                    })) ?? []
                  "
                  split-val
                  @change="handleChange"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-if="isSubStyle" v-bind="layout">
            <th class="required">様式名</th>
            <td>
              <a-form-item v-bind="validateInfos.yosikiid">
                <ai-select
                  v-model:value="formParam.yosikiid"
                  :options="
                    subOptionInfo.find((item) => item.rptnm === formParam.rptnm)?.selectorlist ?? []
                  "
                  split-val
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <template v-if="isChouhyou">
            <a-col v-bind="layout">
              <th :class="isChouhyou ? 'required' : ''">業務</th>
              <td>
                <a-form-item v-bind="validateInfos.gyoumucd">
                  <ai-select
                    v-model:value="formParam.gyoumucd"
                    :options="gyomuOptionInfo.selectorlist1"
                    :disabled="!isChouhyou"
                    @change="handleGyoumucd"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-show="formParam.gyoumucd" v-bind="layout">
              <th :class="isChouhyou ? 'required' : 'bg-readonly'">帳票グループ</th>
              <td>
                <a-form-item v-bind="validateInfos.rptgroupnm">
                  <ai-select
                    v-model:value="formParam.rptgroupnm"
                    :options="rptgroupnmOptions"
                    :disabled="!isChouhyou"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th :class="classNames">宛名フラグ</th>
              <td>
                <a-checkbox
                  v-model:checked="formParam.atenaflg"
                  :disabled="!isChouhyou"
                ></a-checkbox>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th :class="classNames">オプション帳票</th>
              <td>
                <a-checkbox v-model:checked="formParam.addresssealflg" :disabled="!isChouhyou"
                  >アドレスシール</a-checkbox
                >
                <a-checkbox v-model:checked="formParam.barcodesealflg" :disabled="!isChouhyou"
                  >バーコード</a-checkbox
                >
                <a-checkbox v-model:checked="formParam.hagakiflg" :disabled="!isChouhyou"
                  >はがき</a-checkbox
                >
                <a-checkbox v-model:checked="formParam.atenadaityoflg" :disabled="!isChouhyou"
                  >宛名台帳</a-checkbox
                >
                <a-checkbox v-model:checked="formParam.kensuhyonenreiflg" :disabled="!isChouhyou"
                  >件数表(年齢別)</a-checkbox
                >
                <a-checkbox v-model:checked="formParam.kensuhyogyoseikuflg" :disabled="!isChouhyou"
                  >件数表(行政区別)</a-checkbox
                >
              </td>
            </a-col>
          </template>

          <b v-if="isChouhyou" class="mt-5 mb-1">データ取得元</b>
          <a-col v-if="isChouhyou || !formParam.keishouflg" v-bind="layout">
            <th class="required">作成方法</th>
            <td>
              <a-form-item v-bind="validateInfos.yosikihouhou">
                <ai-select
                  v-model:value="formParam.yosikihouhou"
                  split-val
                  :options="gyomuOptionInfo.selectorlist2"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col
            v-if="isChouhyou ? isDataSource : isDataSource && !formParam.keishouflg"
            v-bind="layout"
          >
            <th class="required">データソース</th>
            <td>
              <a-form-item v-bind="validateInfos.datasource">
                <ai-select
                  v-model:value="formParam.datasource"
                  :options="
                    gyomuOptionInfo.datasourcelist?.map((item) => ({
                      label: item.datasourcenm,
                      value: item.datasourceid
                    }))
                  "
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col
            v-if="isChouhyou ? isProcedure : isProcedure && !formParam.keishouflg"
            v-bind="layout"
          >
            <th class="required">プロシージャ</th>
            <td>
              <a-form-item v-bind="validateInfos.procnm">
                <a-select
                  v-model:value="formParam.procnm"
                  :options="functionlist"
                  :field-names="{ label: 'value', value: 'value' }"
                  allow-clear
                ></a-select>
              </a-form-item>
            </td>
          </a-col>

          <b class="mt-5 mb-1">様式情報</b>
          <a-col v-bind="layout">
            <th class="required">
              {{ isSubStyle ? 'サブ様式名' : '様式名' }}
            </th>
            <td>
              <a-form-item v-bind="validateInfos.yosikinm">
                <a-input v-model:value="formParam.yosikinm" maxlength="50" allow-clear />
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th :class="isSubStyle ? 'bg-readonly' : 'required'">帳票種類</th>
            <td>
              <a-form-item v-bind="validateInfos.yosikisyubetu">
                <ai-select
                  v-model:value="formParam.yosikisyubetu"
                  :disabled="isSubStyle"
                  :options="selector4Options"
                  split-val
                  @change="handleYosikisyubetu"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <template v-if="!isDaichou">
            <a-col v-if="isShowYosikikbn" v-bind="layout">
              <th class="required">様式種別詳細</th>
              <td>
                <a-form-item v-bind="validateInfos.yosikikbn">
                  <ai-select
                    v-model:value="formParam.yosikikbn"
                    :options="
                      gyomuOptionInfo.yoshikitypelist?.find(
                        (item) => String(item.yosikisyubetu) == String(formParam.yosikisyubetu)
                      )?.yosikikbnlist ?? []
                    "
                    split-val
                  ></ai-select>
                </a-form-item>
              </td>
            </a-col>
          </template>
          <a-col v-if="isDaichou" v-bind="layout">
            <th class="required">種別</th>
            <td>
              <a-form-item v-bind="validateInfos.meisaiflg">
                <a-select
                  v-model:value="formParam.meisaiflg"
                  style="width: 100%"
                  allow-clear
                  :options="meisaiflgOptions"
                ></a-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-if="!isSubStyle" v-bind="layout">
            <th class="required">通知種類</th>
            <td>
              <a-form-item v-bind="validateInfos.naigaikbn">
                <ai-select
                  v-model:value="formParam.naigaikbn"
                  :options="naigaikbnOpts"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="meisaikoteiflg" v-bind="layout">
            <th :class="meisaikoteikbn_required ? 'required' : ''">行列区分(固定・可変)</th>
            <td>
              <a-form-item v-bind="validateInfos.meisaikoteikbn">
                <ai-select
                  v-model:value="formParam.meisaikoteikbn"
                  split-val
                  :options="meisaikoteikbnOptions"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>

          <a-col v-if="!isSubStyle" v-bind="layout">
            <th class="required">出力形式</th>
            <td>
              <a-form-item name="exportFlags" v-bind="validateInfos.exportFlags">
                <ExportCheckbox
                  v-model:value="formParam.exportFlags"
                  v-bind="{ isDisabledCsv: !isDisabledCsv }"
                />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <template #footer>
      <a-button style="float: left" type="warn" @click="openNext">次へ</a-button>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive, watch, computed, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Form } from 'ant-design-vue'
import {
  Enum帳票様式,
  Enum様式作成方法,
  Enum様式種別,
  Enum様式種別詳細,
  EnumRegex,
  PageSatatus,
  Enum内外区分,
  Enum編集区分,
  EnumServiceResult
} from '#/Enums'
import { InitReport, InitOtherYosiki, Check, InitSubReport } from './service'
import {
  InitReportResponse,
  InitOtherYosikiResponse,
  InitSubReportResponse,
  ReportWithYosikiVM
} from './type'
import { rptsbtOptions, meisaikoteikbnOptions, meisaiflgOptions, layout } from './constants'
import { replaceText } from '@/utils/util'
import { EUCStore, GlobalStore } from '@/store'
import { ITEM_REQUIRE_ERROR, ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'

import ExportCheckbox from './components/ExportCheckbox/index.vue'
import { InitDetail } from '../AWEU00201G/service'
import { Judgement } from '@/utils/judge-edited'

interface Props {
  visible: boolean
  selector4Options: DaSelectorModel[]
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const useForm = Form.useForm
const routes = useRoute()
const router = useRouter()
const emit = defineEmits(['update:visible'])

const editJudge = new Judgement()

function createDefaultForm() {
  return {
    kbn: Enum帳票様式.帳票,
    rptid: '', // 帳票No
    rptnm: '', // 帳票名
    gyoumucd: '', // 業務
    rptgroupnm: '', // 帳票グループ
    atenaflg: false, // 宛名フラグ
    keishouflg: true, // 使用区分
    addresssealflg: false, // アドレスシール
    barcodesealflg: false, // バーコード
    hagakiflg: false, //はがき
    atenadaityoflg: false, // 宛名台帳
    kensuhyonenreiflg: false, //件数表(年齢別)
    kensuhyogyoseikuflg: false, // 件数表(行政区別)
    yosikihouhou: undefined, // 作成方法
    datasource: '', // データソース
    procnm: '', // プロシージャ
    yosikinm: '', // 様式名
    yosikisyubetu: '', // 帳票種類
    yosikikbn: '', // 様式種別詳細
    meisaiflg: false, // 種別
    naigaikbn: undefined, // 通知種類
    exportFlags: {
      excelflg: false, // EXCEL
      pdfflg: false, // PDF
      otherflg: false // other
    },
    meisaikoteikbn: '', //
    yosikiid: '',
    yosikieda: 0,
    datasourceid: ''
  }
}

const formParam = reactive(createDefaultForm())
const isDaichou = computed(() => Number(formParam.yosikisyubetu) == Enum様式種別.台帳)
const isShowYosikikbn = computed(() =>
  [Enum様式種別.台帳, Enum様式種別.カスタマイズ, Enum様式種別.集計表].includes(
    Number(formParam.yosikisyubetu)
  )
)
const keishouOptions = [
  { label: '帳票設定を使用(おすすめ)', value: true },
  { label: '独自で設定する', value: false }
]
const isChouhyou = computed(() => formParam.kbn == Enum帳票様式.帳票)
const isSubStyle = computed(() => formParam.kbn == Enum帳票様式.サブ様式)
const isDataSource = computed(() => {
  const res = formParam.yosikihouhou as unknown as string
  if (!res) return false
  return Number(res) === Enum様式作成方法.データソース
})
const isProcedure = computed(() => {
  const res = formParam.yosikihouhou as unknown as string
  if (!res) return false
  return Number(res) === Enum様式作成方法.プロシージャ
})
const meisaikoteikbn_required = computed(
  () =>
    (meisaikoteiflg.value && formParam.yosikisyubetu !== Enum様式種別.一覧表.toString()) ||
    (formParam.yosikisyubetu === Enum様式種別.一覧表.toString() &&
      (formParam.exportFlags.excelflg || formParam.exportFlags.pdfflg))
)
const rptgroupnmOptions = ref<DaSelectorModel[]>([])
//項目の設定
const rules = reactive({
  yosikihouhou: [
    {
      validator: (_rule, value: string) => {
        if (isChouhyou.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '作成方法'))
        }

        return Promise.resolve()
      }
    }
  ],
  rptgroupnm: [
    {
      validator: (_rule, value: string) => {
        if (isChouhyou.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票グループ'))
        }

        return Promise.resolve()
      }
    }
  ],
  datasource: [
    {
      validator: (_rule, value: string) => {
        if (isChouhyou.value && isDataSource.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'データソース'))
        }

        return Promise.resolve()
      }
    }
  ],
  procnm: [
    {
      validator: (_rule, value: string) => {
        if (isChouhyou.value && isProcedure.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'プロシージャ'))
        }

        return Promise.resolve()
      }
    }
  ],
  yosikinm: [
    {
      validator: (_rule, value: string) => {
        if (formParam.kbn == Enum帳票様式.サブ様式 && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブ様式名'))
        } else if (formParam.kbn != Enum帳票様式.サブ様式 && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '様式名'))
        }

        return Promise.resolve()
      }
    }
  ],
  yosikisyubetu: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票種類')
    }
  ],
  keishouflg: [
    {
      validator: (_rule, value: string) => {
        if (!isChouhyou.value && value == null) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '使用区分'))
        }
        return Promise.resolve()
      }
    }
  ],
  meisaikoteikbn: [
    {
      validator: (_rule, value: string) => {
        if (meisaikoteikbn_required.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '行列区分(固定・可変)'))
        }
        return Promise.resolve()
      }
    }
  ],
  exportFlags: [
    {
      validator: (_rule, value: { excelflg: boolean; pdfflg: boolean; otherflg: boolean }) => {
        if (!isSubStyle.value && !value.excelflg && !value.pdfflg && !value.otherflg) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '出力形式'))
        }

        return Promise.resolve()
      }
    }
  ],
  naigaikbn: [
    {
      validator: (_rule, value: string) => {
        if (!isSubStyle.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '通知種類'))
        }

        return Promise.resolve()
      }
    }
  ],
  meisaiflg: [
    {
      validator: (_rule, value) => {
        if (isDaichou.value && value === undefined) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '種別'))
        }

        return Promise.resolve()
      }
    }
  ],
  yosikikbn: [
    {
      validator: (_rule, value) => {
        if (!isDaichou.value && isShowYosikikbn.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '様式種別詳細'))
        }
        return Promise.resolve()
      }
    }
  ],
  rptnm: [
    {
      validator: (_rule, value) => {
        if (isChouhyou.value && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票名'))
        } else if (!isChouhyou.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '帳票名'))
        }

        return Promise.resolve()
      }
    }
  ],
  gyoumucd: [
    {
      validator: (_rule, value) => {
        if (isChouhyou.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '業務'))
        }

        return Promise.resolve()
      }
    }
  ],
  rptid: [
    {
      validator: (_rule, value) => {
        if (isChouhyou.value && !value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '帳票No'))
        }
        if (isChouhyou.value && value && !/^[01]\d*$/.test(value)) {
          return Promise.reject('0または1で始まる数字を入力してください。')
        }
        if (isChouhyou.value && value && !/^\d{4}$/.test(value)) {
          return Promise.reject('帳票Noは4桁の数字です。')
        }
        return Promise.resolve()
      }
    }
  ],
  yosikiid: [
    {
      validator: (_rule, value) => {
        if (isSubStyle.value && !value) {
          return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '様式名'))
        }
        return Promise.resolve()
      }
    }
  ]
})

const { validate, validateInfos, resetFields, clearValidate } = useForm(formParam, rules)

const gyomuOptionInfo = ref<Partial<InitReportResponse>>({}) // 帳票
const otherOptionInfo = ref<Partial<InitOtherYosikiResponse>>({}) // 別様式
const subOptionInfo = ref<ReportWithYosikiVM[]>([]) // サブ帳票
const functionlist = ref<DaSelectorModel[]>([]) //プロシージャ

const classNames = computed(() => (isChouhyou.value ? '' : 'bg-readonly'))
const isShowRow = computed(() => formParam.meisaiflg)

const isDisabledCsv = computed(
  () =>
    Number(formParam.yosikisyubetu) === Enum様式種別.一覧表 ||
    Number(formParam.yosikikbn) === Enum様式種別詳細.単純集計表 ||
    formParam.yosikisyubetu === ''
)

//内外区分disabled
const naigaikbnOpts = computed(() => {
  return (gyomuOptionInfo.value.selectorlist4 ?? []).map((opt) => {
    return {
      ...opt,
      disabled:
        (+opt.value === Enum内外区分.外部帳票 &&
          +formParam.yosikisyubetu === Enum様式種別.集計表) ||
        (+opt.value === Enum内外区分.内部帳票 &&
          +formParam.yosikisyubetu === Enum様式種別.カスタマイズ)
    }
  })
})

const meisaikoteiflg = computed(() => {
  return (
    formParam.yosikisyubetu === Enum様式種別.一覧表.toString() ||
    formParam.yosikikbn === Enum様式種別詳細.クロス集計.toString() ||
    formParam.meisaiflg
  )
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => formParam.kbn,
  (newValue) => {
    resetFields()
    formParam.kbn = newValue
    if (newValue == Enum帳票様式.サブ様式) {
      formParam.yosikisyubetu = Enum様式種別.台帳.toString()
    }
    nextTick(() => editJudge.reset())
  }
)

watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      const promises = [InitReport(), InitOtherYosiki(), InitSubReport()]
      Promise.all(promises).then((res) => {
        gyomuOptionInfo.value = {
          ...res[0],
          selectorlist4: (res[0] as InitReportResponse)?.selectorlist4
        }
        functionlist.value = (res[0] as InitReportResponse)?.functionlist
        otherOptionInfo.value = res[1]
        subOptionInfo.value = (res[2] as InitSubReportResponse).reportwithyosikilist
        nextTick(() => editJudge.reset())
      })
    }
  }
)

watch(formParam, () => editJudge.setEdited())

const handleChange = () => {
  const item = otherOptionInfo.value.reportlist?.find((item) => item.rptid === formParam.rptid)
  formParam.rptnm = item?.rptnm ?? ''
}

const handleGyoumucd = () => {
  rptgroupnmOptions.value =
    gyomuOptionInfo.value.rptgrouplist
      ?.filter((item) => item.gyoumucd === splitCode(formParam.gyoumucd))
      .map((item) => ({
        label: item.rptgroupnm,
        value: item.rptgroupid
      })) ?? []
  formParam.rptgroupnm = ''
}

const handleYosikisyubetu = () => {
  formParam.yosikikbn = ''
  formParam.meisaiflg = false
  formParam.meisaikoteikbn = ''
  formParam.naigaikbn = undefined
  if (!isDisabledCsv.value) {
    formParam.exportFlags.otherflg = false
  }
  nextTick(() => clearValidate())
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
    resetFields()
  })
}

const splitCode = (str: string) => {
  if (!str) return str
  return str.indexOf(' : ') > -1 ? str.split(' : ')[0] : str
}

const openNext = async () => {
  await validate()
  if (formParam.yosikihouhou == Enum様式作成方法.データソース) {
    await Check({
      kbn: formParam.kbn,
      rptid: formParam.rptid,
      rptnm: formParam.rptnm,
      yosikinm: formParam.yosikinm
    })
  }

  const arr = [Enum様式種別詳細.一覧表, Enum様式種別詳細.台帳, Enum様式種別詳細.経年表]
  const index = [Enum様式種別.一覧表, Enum様式種別.台帳, Enum様式種別.経年表].findIndex(
    (item) => item === Number(formParam.yosikisyubetu)
  )

  const res = await InitDetail(
    {
      ...formParam,
      datasourceid: formParam.datasource?.split(' : ')[0],
      kbn: Number(formParam.kbn),
      editkbn: Enum編集区分.新規,
      procnm: formParam.procnm == '新規作成' ? '' : formParam.procnm
    },
    (response: DaResponseBase) => {
      if (response.returncode === EnumServiceResult.InterruptionError) {
        editJudge.reset()
        closeModal()
      }
    }
  )
  formParam.yosikieda = res.yosikieda as number
  formParam.datasourceid = res.datasourceid as string //主
  if (formParam.kbn == Enum帳票様式.別様式 && res.yosikiid) {
    formParam.yosikiid = res.yosikiid
  }

  //新規時201_params
  EUCStore['201_params'] = {
    ...formParam,
    ...formParam.exportFlags,
    rptdatasourceid: formParam.datasource?.split(' : ')[0],
    datasourcenm: formParam.datasource?.split(' : ')[1],
    gyoumu: formParam.gyoumucd?.split(' : ')[1],
    gyoumucd: splitCode(formParam.gyoumucd),
    rptgroupid: splitCode(formParam.rptgroupnm),
    rptgroupnm: formParam.rptgroupnm.split(' : ')[1],
    yosikihouhou: formParam.yosikihouhou,
    yosikikbn: index > -1 ? arr[index].toString() : formParam.yosikikbn,
    functionlist: functionlist.value
  }

  router.push({
    name: routes.name as string,
    query: {
      status: PageSatatus.Edit,
      isNew: '1',
      datasourceid: formParam.datasource?.split(' : ')[0]
    }
  })
  editJudge.reset()
  closeModal()
}
</script>

<style lang="less" src="./index.less" scoped></style>
