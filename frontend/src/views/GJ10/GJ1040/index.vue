<!------------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 契約者別契約情報入力確認チェックリスト（Ｂ４サイズ）
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px">
      <div>
        <h1>(GJ1040)契約者別契約情報入力確認チエックリスト作成処理</h1>
        <div class="self_adaption_table form max-w-200" ref="headRef">
          <a-row>
            <a-col span="24">
              <th class="required">対象期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <span class="!align-middle">第</span>
                  <a-input-number
                    v-model:value="formData.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    style="width: 120px"
                  ></a-input-number>
                  <span class="!align-middle">期</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>
                <a-radio-group v-model:value="formData.a">
                  <a-radio :value="true">登録日範囲</a-radio>
                </a-radio-group>
              </th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD">
                  <range-date
                    v-model:value="formData.date"
                    :disabled="!formData.a"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th :style="{ borderTop: 'none' }">
                <a-radio-group v-model:value="formData.a">
                  <a-radio :value="false">更新日範囲</a-radio>
                </a-radio-group>
              </th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD">
                  <range-date
                    v-model:value="formData.date"
                    :disabled="formData.a"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>契約区分</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN_CD">
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN_CD"
                    :options="LIST"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">契約状況</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKU_JYOKYO">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in KEIYAKU_JYOKYO_LABELS"
                      :key="key"
                      v-model:checked="formData.KEIYAKU_JYOKYO[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">入力状況</th>
              <td>
                <a-form-item v-bind="validateInfos.NYURYOKU_JYOKYO">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in NYURYOKU_JYOKYO_LABELS"
                      :key="key"
                      v-model:checked="formData.NYURYOKU_JYOKYO[key]"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">契約日</th>
              <td>
                <a-form-item v-bind="validateInfos.NYURYOKU_KBN">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in NYURYOKU_KBN_LABELS"
                      :key="key"
                      v-model:checked="formData.NYURYOKU_KBN[key]"
                      @change="handle"
                    >
                      {{ label }}
                    </a-checkbox></a-space
                  ></a-form-item
                >
              </td></a-col
            >
            <a-col span="24"
              ><th :style="{ borderTop: 'none' }"></th>
              <td>
                <range-date
                  v-model:value="formData.date"
                  :disabled="!formData.NYURYOKU_KBN.ing"
                /></td
            ></a-col>
            <a-col span="24">
              <th>入力者</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <range-select
                    v-model:value="formData.ITAKU_CD"
                    :options="LIST"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>事業委託先</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <range-select
                    v-model:value="formData.ITAKU_CD"
                    :options="LIST"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>契約者番号</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                  <range-select
                    v-model:value="formData.KEIYAKUSYA_CD"
                    :options="LIST"
                /></a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row class="m-t-1">
            <a-col :span="24">
              <div class="mb-2 header_operation flex justify-between w-full">
                <a-space :size="20">
                  <a-button type="primary">プレビュー</a-button>
                  <a-button type="primary">クリア</a-button>
                </a-space>
                <close-page />
              </div>
            </a-col>
          </a-row>
        </div>
      </div>
    </a-card>
  </div>
</template>

<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { onMounted, reactive, ref } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    a: true,
    date: {
      VALUE_FM: undefined as Date | undefined,
      VALUE_TO: undefined as Date | undefined,
    },
    KI: -1,

    TAISYOBI_YMD: new Date().toISOString().split('T')[0],
    KEIYAKU_KBN_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEIYAKU_JYOKYO: {
      SHINKI: true,
      KEIZOKU: true,
      CHUSHI: true,
    },
    NYURYOKU_JYOKYO: {
      ing: true,
      ed: true,
    },
    NYURYOKU_KBN: {
      ing: true,
      ed: true,
    },
    ITAKU_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
    KEIYAKUSYA_CD: {
      VALUE_FM: undefined as number | undefined,
      VALUE_TO: undefined as number | undefined,
    },
  }
}
const formData = reactive(createDefaultParams())
const KEIYAKU_JYOKYO_LABELS = {
  SHINKI: '新規契約者',
  KEIZOKU: '継続契約者',
  CHUSHI: '中止者',
}
const clearFromToValue = {
  VALUE_FM: undefined,
  VALUE_TO: undefined,
}
const NYURYOKU_JYOKYO_LABELS = {
  ing: '入力中',
  ed: '入力確認',
}
const NYURYOKU_KBN_LABELS = {
  ing: '入力のみ',
  ed: '未入力のみ',
}
const LIST = ref<CmCodeNameModel[]>([])
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
        const result = rangeCheck(value.VALUE_FM, value.VALUE_TO, '事業委託先')
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
const handle = () => {
  if (!formData.NYURYOKU_KBN.ing) {
    Object.assign(formData.date, clearFromToValue)
  }
}

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
