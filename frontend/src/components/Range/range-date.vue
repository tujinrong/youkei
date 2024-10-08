<!------------------------------------------------------------------
 * 業務名称　:
 * 機能概要　: 範囲選択（日付プルダウンリスト）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center w-full">
    <DateJp :value="value.VALUE_FM" :disabled="disabled1" @change="change1" />
    <span>～</span>
    <DateJp :value="value.VALUE_TO" :disabled="disabled2" @change="change2" />
  </div>
</template>

<script setup lang="ts">
import { Form } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: {
    VALUE_FM: Date | undefined
    VALUE_TO: Date | undefined
  }
  disabled1?: boolean
  disabled2?: boolean
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
    VALUE_FM: val ?? undefined,
    VALUE_TO: props.value.VALUE_TO,
  })
  formItemContext.onFieldChange()
}
function change2(val) {
  emit('update:value', {
    VALUE_FM: props.value.VALUE_FM,
    VALUE_TO: val ?? undefined,
  })
  formItemContext.onFieldChange()
}
</script>
