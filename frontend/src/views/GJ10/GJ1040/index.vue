<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者別契約情報入力確認チェックリスト（Ｂ４サイズ）
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px staticWidth">
      <div class="max-w-1150px">
        <h1>（GJ1040）契約者別契約情報入力確認チエックリスト作成処理</h1>
        <div class="self_adaption_table form" ref="headRef">
          <a-row>
            <a-col span="24">
              <th class="required">対象期</th>
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
            <a-col span="24">
              <th :class="CHOOSE_REG_DATE ? 'required' : ''">
                <a-radio-group v-model:value="CHOOSE_REG_DATE">
                  <a-radio :value="true">登録日範囲</a-radio>
                </a-radio-group>
              </th>
              <td>
                <a-form-item v-bind="validateInfos.REG_DATE">
                  <range-date
                    v-model:value="formData.REG_DATE"
                    :disabled="!CHOOSE_REG_DATE"
                    class="max-w-110"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th
                :style="{ borderTop: 'none' }"
                :class="CHOOSE_REG_DATE ? '' : 'required'"
              >
                <a-radio-group v-model:value="CHOOSE_REG_DATE">
                  <a-radio :value="false">更新日範囲</a-radio>
                </a-radio-group>
              </th>
              <td>
                <a-form-item v-bind="validateInfos.UP_DATE">
                  <range-date
                    v-model:value="formData.UP_DATE"
                    :disabled="CHOOSE_REG_DATE"
                    class="max-w-110"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>契約区分</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.KEIYAKU_KBN">
                  <range-select
                    v-model:value="formData.KEIYAKU_KBN"
                    :options="LIST"
                    class="max-w-78"
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
                      class="w-30"
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
                      class="w-30"
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
                <a-form-item v-bind="validateInfos.KEIYAKUBI">
                  <a-space class="flex-wrap">
                    <a-checkbox
                      v-for="(label, key) in KEIYAKUBI_LABELS"
                      :key="key"
                      class="w-30"
                      v-model:checked="formData.KEIYAKUBI[key]"
                      @change="handleKeiyakubi"
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
                  v-model:value="formData.KEIYAKUBI_YMD"
                  :disabled="!formData.KEIYAKUBI.NYURYOKU_NOMI"
                  class="max-w-110"
                /></td
            ></a-col>
            <a-col span="24">
              <th>入力者</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.NYURYOKUSYA_CD">
                  <range-select
                    v-model:value="formData.NYURYOKUSYA_CD"
                    :options="NYURYOKUSYA_LIST"
                    class="max-w-230"
                    type="string"
                /></a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>事務委託先</th>
              <td class="flex">
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <range-select
                    v-model:value="formData.ITAKU_CD"
                    :options="ITAKU_LIST"
                    class="max-w-full!"
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
                <a-button type="primary">プレビュー</a-button>
                <a-button type="primary" @click="clear">条件クリア</a-button>
              </a-space>
              <close-page />
            </div>
          </a-col>
        </a-row>
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
    KI: -1, // 対象期
    // 登録日範囲
    REG_DATE: {
      VALUE_FM: undefined as Date | undefined, // 開始日
      VALUE_TO: undefined as Date | undefined, // 終了日
    },
    // 更新日範囲
    UP_DATE: {
      VALUE_FM: undefined as Date | undefined, // 開始日
      VALUE_TO: undefined as Date | undefined, // 終了日
    },
    // 契約区分
    KEIYAKU_KBN: {
      VALUE_FM: undefined as number | undefined, // 開始番号
      VALUE_TO: undefined as number | undefined, // 終了番号
    },
    // 契約状況
    KEIYAKU_JYOKYO: {
      SHINKI: true, // 新規契約者
      KEIZOKU: true, // 継続契約者
      CHUSHI: true, // 中止契約者
    },
    // 入力状況
    NYURYOKU_JYOKYO: {
      NYURYOKU_TYU: true, // 入力中
      NYURYOKU_KAKUTEI: true, // 入力確定
    },
    // 契約日
    KEIYAKUBI: {
      NYURYOKU_NOMI: true, // 入力のみ
      MIRYOKU_NOMI: true, // 未入力のみ
    },
    // 契約日（日付範囲）
    KEIYAKUBI_YMD: {
      VALUE_FM: undefined as Date | undefined, // 開始日
      VALUE_TO: undefined as Date | undefined, // 終了日
    },
    // 入力者
    NYURYOKUSYA_CD: {
      VALUE_FM: undefined as number | undefined, // 開始番号
      VALUE_TO: undefined as number | undefined, // 終了番号
    },
    // 事務委託先
    ITAKU_CD: {
      VALUE_FM: undefined as number | undefined, // 開始番号
      VALUE_TO: undefined as number | undefined, // 終了番号
    },
    // 契約者番号
    KEIYAKUSYA_CD: {
      VALUE_FM: undefined as number | undefined, // 開始番号
      VALUE_TO: undefined as number | undefined, // 終了番号
    },
  }
}

const formData = reactive(createDefaultParams())
const CHOOSE_REG_DATE = ref(true)
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
  NYURYOKU_TYU: '入力中',
  NYURYOKU_KAKUTEI: '入力確認',
}
const KEIYAKUBI_LABELS = {
  NYURYOKU_NOMI: '入力のみ',
  MIRYOKU_NOMI: '未入力のみ',
}
const LIST = ref<CmCodeNameModel[]>([])
const ITAKU_LIST = ref<CmCodeNameModel[]>([
  { CODE: 666, NAME: '事務委託先事務委託先事務委託先事務委託先事務委託先' },
])

const NYURYOKUSYA_LIST = ref<CmStrCodeNameModel[]>([
  { CODE: 'user_name1', NAME: 'ユーザー名ユーザー名' },
])
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
const handleKeiyakubi = () => {
  if (!formData.KEIYAKUBI.NYURYOKU_NOMI) {
    Object.assign(formData.KEIYAKUBI_YMD, clearFromToValue)
  }
}
const clear = () => {
  Object.assign(formData, createDefaultParams())
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
  min-width: 140px;
}
</style>
