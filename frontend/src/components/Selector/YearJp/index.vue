<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 和暦(年度)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input-number
    ref="inputYear"
    v-model:value="modelValue"
    :formatter="yearFormatter"
    :parser="parser"
    :max="max ?? ss.get(MAX_YEAR)"
    :min="min ?? 0"
    style="width: 120px"
  />
</template>

<script lang="ts" setup>
import { ss } from '@/utils/storage'
import { yearFormatter } from '@/utils/util'
import { GLOBAL_YEAR, MAX_YEAR } from '@/constants/mutation-types'
import { computed, ref, onMounted } from 'vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  value: number | string
  max?: number
  min?: number
}
const props = withDefaults(defineProps<Props>(), {
  value: new Date().getFullYear(),
  max: undefined,
  min: undefined
})
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['update:value'])
const inputYear = ref()
const modelValue = computed({
  get: () => +props.value,
  set: (val) => emit('update:value', val)
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
  if (!props.value) {
    const GlobalYear = ss.get(GLOBAL_YEAR)
    if (GlobalYear) {
      modelValue.value = Number(GlobalYear)
    }
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const parser = (value: string) => {
  if (!value) return ss.get(GLOBAL_YEAR)
  return value
}
</script>

<style lang="less" scoped>
:deep(.ant-input-number-handler-wrap) {
  opacity: 1;
}
</style>
