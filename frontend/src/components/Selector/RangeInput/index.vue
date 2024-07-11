<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（文字/時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.05.19
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <a-input
      :value="value.value1"
      :disabled="disabled"
      :placeholder="placeholder"
      allow-clear
      :maxlength="maxlength"
      @change="changeInput1"
      @blur="onBlur1"
    />
    <span>～</span>
    <a-input
      :value="value.value2"
      :disabled="disabled"
      :placeholder="placeholder"
      allow-clear
      :maxlength="maxlength"
      @change="changeInput2"
      @blur="onBlur2"
    />
  </div>
</template>

<script setup lang="ts">
import { REGEX_time } from '@/constants/constant'
import { Form } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: {
    value1: string | null
    value2: string | null
  }
  disabled?: boolean
  placeholder?: string
  maxlength?: number
  limitTime?: boolean
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function changeInput1(e: InputEvent) {
  emit('update:value', { ...props.value, value1: (e.target as any).value })
  formItemContext.onFieldChange()
}
function changeInput2(e) {
  emit('update:value', { ...props.value, value2: (e.target as any).value })
  formItemContext.onFieldChange()
}

//as 時間処理
function onBlur1() {
  if (props.limitTime && !REGEX_time.test(props.value.value1 as string)) {
    emit('update:value', { ...props.value, value1: '' })
    formItemContext.onFieldChange()
  }
}
function onBlur2() {
  if (props.limitTime && !REGEX_time.test(props.value.value2 as string)) {
    emit('update:value', { ...props.value, value2: '' })
    formItemContext.onFieldChange()
  }
}
</script>
