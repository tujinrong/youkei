<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 文字入力
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.06.19
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-textarea
    v-if="textarea"
    v-bind="$attrs"
    :value="value"
    @change="onChange"
    @keydown="onKeyDown"
  ></a-textarea>
  <a-input v-else v-bind="$attrs" :value="value" @change="onChange" @keydown="onKeyDown"></a-input>
</template>

<script setup lang="ts">
import { watch, reactive } from 'vue'
import { replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value: string | null | undefined
  regex: EnumRegex
  textarea?: boolean
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const history = reactive<string[]>([])
let tempValue = ''

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.value,
  (val) => (tempValue = val ?? '')
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onChange(e) {
  const inputElement = e.target as HTMLInputElement
  const start = inputElement.selectionStart as number

  const text = replaceText(inputElement.value, props.regex)
  const count = inputElement.value.length - text.length
  if (text != tempValue) {
    history.push(tempValue)
  }
  emit('update:value', text)

  //カーソル
  setTimeout(() => {
    inputElement.setSelectionRange(start - count, start - count)
  }, 0)
}

//rewrite ctrl+z
function onKeyDown(event) {
  if (event.ctrlKey && event.key === 'z') {
    event.preventDefault()
    if (history.length > 0) {
      const previousValue = history.pop() as string
      tempValue = previousValue
      emit('update:value', previousValue)
    }
  }
}
</script>
