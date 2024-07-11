<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 範囲選択（日付時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.09.11
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center">
    <date-time
      :value="value.value1"
      :hanit="value.value2 ?? undefined"
      :disabled="disabled"
      @change="onChange1"
    />
    <span>～</span>
    <date-time
      :value="value.value2"
      :hanif="value.value1 ?? undefined"
      :disabled="disabled"
      is-end
      @change="onChange2"
    />
  </div>
</template>
<script setup lang="ts">
import { Form } from 'ant-design-vue'
import DateTime from '../DateTime/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: {
    value1: string | null
    value2: string | null
  }
  disabled?: boolean
}>()
const emit = defineEmits(['update:value', 'change'])
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()
function onChange1(value) {
  emit('update:value', { ...props.value, value1: value })
  emit('change', { ...props.value, value1: value })
  formItemContext.onFieldChange()
}
function onChange2(value) {
  emit('update:value', { ...props.value, value2: value })
  emit('change', { ...props.value, value2: value })
  formItemContext.onFieldChange()
}
</script>
