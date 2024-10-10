<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 家畜防疫互助基金事業加入状况表
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false" class="h-330px min-h-330px staticWidth">
      <div class="max-w-1150px">
        <h1>（GJ1060）家畜防疫互助基金事業加入状況表作成</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <span class="!align-middle">第 </span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    class="w-14"
                  ></a-input-number>
                  <span class="!align-middle"> 期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">出力区分</th>
              <td class="flex">
                <a-radio-group
                  v-model:value="formData.SYUTURYOKU_KBN"
                  class="mt-1"
                >
                  <a-radio :value="1">契約者＆合計</a-radio>
                  <a-radio :value="2">合計</a-radio>
                </a-radio-group>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">指定日</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
                  <DateJp
                    v-model:value="formData.KEIYAKU_DATE_FROM"
                    class="max-w-50"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約区分</th>
              <td>
                <a-space class="flex-wrap">
                  <a-checkbox
                    v-for="(label, key) in LABELS"
                    :key="key"
                    class="w-20"
                    v-model:checked="formData.KEIYAKU_KBN[key]"
                  >
                    {{ label }}
                  </a-checkbox></a-space
                >
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>都道府県</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEN_CD">
                  <range-select
                    v-model:value="formData.KEN_CD"
                    :options="KEN_CD_NAME_LIST"
                    class="w-90!"
                /></a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>契約者番号</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                  <range-select
                    v-model:value="formData.KEIYAKUSYA_CD"
                    :options="LIST"
                    class="max-w-full!"
                /></a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
      </div>
      <div>
        <a-row class="m-t-1">
          <a-col :span="24">
            <div class="mb-2 header_operation flex justify-between w-full">
              <a-space :size="20">
                <a-button type="primary">EXCEL出力</a-button>
                <a-button type="primary">キャンセル</a-button>
              </a-space>
              <EndButton />
            </div>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </div>
</template>
<script lang="ts" setup>
import { reactive, ref, watch, computed, onMounted, onUnmounted } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { ExcelExportRequest } from './type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = (): ExcelExportRequest => {
  return {
    KI: 8,
    SYUTURYOKU_KBN: 1,
    KEIYAKU_DATE_FROM: new Date(),
    KEIYAKU_KBN: {
      KAZOKU: true,
      KIGYO: true,
      KEIIGAI: true,
    },
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    KEIYAKUSYA_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
  }
}

const formData = reactive(createDefaultParams())
const LIST = ref<CmCodeNameModel[]>([])
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 46, NAME: '鹿児島県' },
])
const LABELS = {
  KAZOKU: '家族',
  KIGYO: '企業',
  KEIIGAI: '鶏以外',
}
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
    },
  ],
  KEIYAKU_KBN_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '契約区分')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  KEIYAKU_JYOKYO: [
    {
      validator: (_rule, value) => {
        const values = Object.values(value)
        if (!values.some((el) => el === true)) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約状況')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  ITAKU_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '事務委託先')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  KEIYAKUSYA_CD: [
    {
      validator: (
        _rule,
        value: {
          VALUE_FM
          VALUE_TO
        }
      ) => {
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '契約者番号')
        if (!result.flag) return Promise.reject(result.content)
        return Promise.resolve()
      },
    },
  ],
  TAISYOBI_YMD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象日(現在)'),
    },
  ],
})

const { validate, validateInfos } = Form.useForm(formData, rules)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const rangeCheck = (from: number, to: number, itemName: string) => {
  let result = { flag: true, content: '' }
  if (from && !to) {
    result.flag = false
    result.content = ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'To')
  }
  if (!from && to) {
    result.flag = false
    result.content = ITEM_REQUIRE_ERROR.Msg.replace('{0}', itemName + 'From')
  }
  if (from > to) {
    result.flag = false
    result.content = '指定された' + itemName + 'の範囲が正しくありません。'
  }
  return result
}
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
