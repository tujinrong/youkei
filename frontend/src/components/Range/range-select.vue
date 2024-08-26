<!------------------------------------------------------------------
 * 業務名称　:
 * 機能概要　: 範囲選択（プルダウンリスト）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.08
 * 作成者　　: 高
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="flex items-center w-full">
    <ai-select
      :value="value.VALUE_FM"
      :options="options"
      split-val
      :disabled="disabled"
      @change="change1"
    />
    <span>～</span>
    <ai-select
      :value="value.VALUE_TO"
      :options="options"
      split-val
      :disabled="disabled"
      @change="change2"
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
    VALUE_FM: number | undefined
    VALUE_TO: number | undefined
  }
  options: CodeNameModel[]
  disabled?: boolean
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
    VALUE_FM: Number(val),
    VALUE_TO: props.value.VALUE_TO ? Number(props.value.VALUE_TO) : Number(val),
  })
  formItemContext.onFieldChange()
}
function change2(val) {
  emit('update:value', {
    VALUE_FM: props.value.VALUE_FM ? Number(props.value.VALUE_FM) : Number(val),
    VALUE_TO: Number(val),
  })
  formItemContext.onFieldChange()
}
</script>
