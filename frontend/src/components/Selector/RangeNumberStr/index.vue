<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（数字）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.10.03
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <a-input-number
      v-model:value="value1"
      class="flex-1"
      :disabled="disabled"
      :placeholder="placeholder"
      :precision="precision"
      :max="value2"
      string-mode
    />
    <span>～</span>
    <a-input-number
      v-model:value="value2"
      class="flex-1"
      :disabled="disabled"
      :placeholder="placeholder"
      :precision="precision"
      :min="value1"
      string-mode
    />
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
import { computed } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: string
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
//計算定義
//--------------------------------------------------------------------------
const value1 = computed({
  get() {
    return props.value ? props.value.split(',')[0] : ''
  },
  set(val) {
    emit('update:value', (val ?? '') + ',' + (value2.value ?? ''))
    if (!val && !value2.value) emit('update:value', '')
    formItemContext.onFieldChange()
  }
})
const value2 = computed({
  get() {
    return props.value ? props.value.split(',')[1] : ''
  },
  set(val) {
    emit('update:value', (value1.value ?? '') + ',' + (val ?? ''))
    if (!val && !value1.value) emit('update:value', '')
    formItemContext.onFieldChange()
  }
})
</script>
