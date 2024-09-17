<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金納付·互助金交付·基金残高管理表
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card :bordered="false" class="h-full min-h-500px">
      <div>
        <h1>（GJ5010）互助基金納付·互助金交付·基金残高管理表</h1>
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
              <th class="required">事業対象年度</th>
              <td>
                <a-form-item v-bind="validateInfos.JIGYO_SYURYO_NENDO">
                  <year-jp v-model:value="formData.JIGYO_SYURYO_NENDO" /><span
                    class="!align-middle"
                    >年度(指定年度まで集計)</span
                  ></a-form-item
                >
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">出力区分</th>
              <td>
                <a-form-item v-bind="validateInfos.SEIKYU_HENKAN_KBN">
                  <a-radio-group v-model:value="formData.SEIKYU_HENKAN_KBN">
                    <a-radio :value="1">積立金・請求ベース</a-radio>
                    <a-radio :value="2"
                      >積立金・入金ベース</a-radio
                    ></a-radio-group
                  ></a-form-item
                >
              </td>
            </a-col>
          </a-row>
          <a-row class="m-t-1">
            <a-col :span="24">
              <div class="mb-2 header_operation flex justify-between w-full">
                <a-space :size="20">
                  <a-button type="primary">プレビュー</a-button>
                  <a-button type="primary" @click="clear">キャンセル</a-button>
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
    KI: -1,
    JIGYO_SYURYO_NENDO: 2023,
    SEIKYU_HENKAN_KBN: 1,
  }
}

const formData = reactive(createDefaultParams())

const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象期'),
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

const clear = () => {
  Object.assign(formData, createDefaultParams())
}
</script>

<style lang="scss" scoped>
th {
  min-width: 140px;
}
</style>
