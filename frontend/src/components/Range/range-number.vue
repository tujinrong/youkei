<!------------------------------------------------------------------
 * 業務名称　:
 * 機能概要　: 範囲選択（インプット）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.09.05
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center w-full">
    <a-input-number
      :value="value.VALUE_FM"
      :disabled="disabled"
      :maxLength="maxLength"
      :max="max"
      :min="min"
      @change="change1"
      :style="{ width: width ? width + 'px' : undefined }"
    />
    <span v-if="unit" class="ml-1">{{ unit }}</span>
    <span class="ml-1 mr-1">～</span>
    <a-input-number
      :value="value.VALUE_TO"
      :disabled="disabled"
      :maxLength="maxLength"
      :max="max"
      :min="min"
      @change="change2"
      :style="{ width: width ? width + 'px' : undefined }"
    />
    <span v-if="unit" class="ml-1">{{ unit }}</span>
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: {
    VALUE_FM: number | undefined
    VALUE_TO: number | undefined
  }
  disabled?: boolean
  unit?: string
  width?: string
  maxLength?: number
  max?: number
  min?: number
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function change1(val) {
  emit('update:value', {
    VALUE_FM: val ? Number(val) : undefined,
    VALUE_TO: props.value.VALUE_TO,
  })
  formItemContext.onFieldChange()
}
function change2(val) {
  emit('update:value', {
    VALUE_FM: props.value.VALUE_FM,
    VALUE_TO: val ? Number(val) : undefined,
  })
  formItemContext.onFieldChange()
}
</script>
