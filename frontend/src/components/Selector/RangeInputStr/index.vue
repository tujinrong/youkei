<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（文字/時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.09.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <a-input
      v-model:value="value1"
      :disabled="disabled"
      :placeholder="placeholder"
      allow-clear
      :maxlength="maxlength"
      @blur="onBlur1"
    />
    <span>～</span>
    <a-input
      v-model:value="value2"
      :disabled="disabled"
      :placeholder="placeholder"
      allow-clear
      :maxlength="maxlength"
      @blur="onBlur2"
    />
  </div>
</template>

<script setup lang="ts">
import { REGEX_time } from '@/constants/constant'
import { Form } from 'ant-design-vue'
import { computed } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: string
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

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//as 時間処理
function onBlur1() {
  if (props.limitTime && !REGEX_time.test(value1.value)) {
    emit('update:value', ',' + (value2.value ?? ''))
    formItemContext.onFieldChange()
  }
}
function onBlur2() {
  if (props.limitTime && !REGEX_time.test(value2.value)) {
    emit('update:value', (value1.value ?? '') + ',')
    formItemContext.onFieldChange()
  }
}
</script>
