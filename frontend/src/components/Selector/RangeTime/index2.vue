<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 範囲選択（時間）
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.02.21
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-time-range-picker
    v-model:value="curVal"
    separator="～"
    value-format="HHmm"
    format="HH:mm"
    :allow-empty="allowEmpty"
  />
</template>

<script setup lang="ts">
import { computed } from 'vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  value: string
  symbol: string
  allowEmpty: [boolean, boolean]
}
const props = withDefaults(defineProps<Props>(), {
  value: '',
  symbol: ',',
  allowEmpty: () => [true, true]
})
const emit = defineEmits(['update:value'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    return props.value
      ? [props.value.split(props.symbol)[0], props.value.split(props.symbol)[1]]
      : null
  },
  set(val) {
    emit('update:value', val ? (val[0] ?? '') + props.symbol + (val[1] ?? '') : '')
  }
})
</script>
