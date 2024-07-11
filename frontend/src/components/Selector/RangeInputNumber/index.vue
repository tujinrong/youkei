<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（数字）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.05.19
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <a-input-number
      class="flex-1"
      :value="value.value1"
      :disabled="disabled"
      :placeholder="placeholder"
      :precision="precision"
      :max="value.value2"
      string-mode
      allow-clear
      @change="changeInput1"
    />
    <span>～</span>
    <a-input-number
      class="flex-1"
      :value="value.value2"
      :disabled="disabled"
      :placeholder="placeholder"
      :precision="precision"
      :min="value.value1"
      string-mode
      allow-clear
      @change="changeInput2"
    />
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: {
    value1: string | number | null
    value2: string | number | null
  }
  disabled?: boolean
  placeholder?: string
  /**数値の精度 */
  precision?: number
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const changeInput1 = (value) => {
  emit('update:value', { ...props.value, value1: value })
  formItemContext.onFieldChange()
}
const changeInput2 = (value) => {
  emit('update:value', { ...props.value, value2: value })
  formItemContext.onFieldChange()
}
</script>
