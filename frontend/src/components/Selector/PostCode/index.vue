<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 郵便番号
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.7.24
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input-group compact>
    <a-input
      v-model:value="value1"
      :maxlength="3"
      style="width: 64px; text-align: center; border-right: 0"
      @blur="onBlur"
    >
      <template #prefix> 〒 </template>
    </a-input>
    <a-input
      style="
        width: 30px;
        border-left: 0;
        pointer-events: none;
        background-color: #fff;
      "
      placeholder="-"
      tabindex="-1"
    />
    <a-input
      v-model:value="value2"
      :maxlength="4"
      style="width: 60px; text-align: center; border-left: 0"
      @blur="onBlur"
    />
    <slot></slot>
  </a-input-group>
</template>

<script setup lang="ts">
// import { EnumRegex } from '#/Enums'
// import { replaceText } from '@/utils/util'
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
  const value = props.value ?? ''
  value1.value = value.substring(0, 3)
  value2.value = value.substring(3)
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function onBlur() {
  value1.value = value1.value.replace(/[^0-9]/g, '')
  value2.value = value2.value.replace(/[^0-9]/g, '')
  const code = `${value1.value}-${value2.value}`
  emit('update:value', code === '-' ? '' : code.replace('-', ''))

  formItemContext.onFieldChange()
}
</script>
