<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 郵便番号
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.11.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input-group compact>
    <a-input
      v-model:value="value1"
      maxlength="3"
      style="width: 50px; text-align: center; border-right: 0"
      @change="onChange"
    />
    <a-input
      style="width: 30px; border-left: 0; pointer-events: none; background-color: #fff"
      placeholder="-"
      tabindex="-1"
    />
    <a-input
      v-model:value="value2"
      maxlength="4"
      style="width: 60px; text-align: center; border-left: 0"
      @change="onChange"
    />
    <slot></slot>
  </a-input-group>
</template>

<script setup lang="ts">
import { EnumRegex } from '#/Enums'
import { replaceText } from '@/utils/util'
import { Form } from 'ant-design-vue'
import { watchEffect, ref } from 'vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  value?: string
}>()
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const formItemContext = Form.useInjectFormItemContext()
const value1 = ref('')
const value2 = ref('')

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  const parts = (props.value ?? '').split('-')
  value1.value = parts[0] ?? ''
  value2.value = parts[1] ?? ''
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onChange() {
  value1.value = replaceText(value1.value, EnumRegex.半角数字)
  value2.value = replaceText(value2.value, EnumRegex.半角数字)

  const code = `${value1.value}-${value2.value}`
  emit('update:value', code === '-' ? '' : code)

  formItemContext.onFieldChange()
}
</script>
