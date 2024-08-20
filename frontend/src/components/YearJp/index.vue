<!------------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 和暦(年度)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.19
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input-number
    ref="inputYear"
    v-model:value="modelValue"
    :formatter="yearFormatter"
    :parser="parser"
    style="width: 120px"
  />
</template>

<script lang="ts" setup>
import { yearFormatter } from '@/utils/util'
import { computed, ref, onMounted } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  value: number | string
  max?: number
}
const props = withDefaults(defineProps<Props>(), {
  value: new Date().getFullYear(),
  max: undefined,
})
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['update:value'])
const inputYear = ref()
const modelValue = computed({
  get: () => +props.value,
  set: (val) => emit('update:value', val),
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const inputDom = inputYear.value.$el.querySelector('.ant-input-number-input')
  if (inputDom) {
    inputDom.addEventListener('keydown', function (event) {
      if (event.key === 'Backspace') {
        event.preventDefault()
      }
    })
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const parser = (value: string) => {
  return value
}
</script>

<style lang="scss" scoped>
:deep(.ant-input-number-handler-wrap) {
  opacity: 1;
}
</style>
