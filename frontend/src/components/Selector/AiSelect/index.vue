<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ドロップダウンリスト(検索)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-select
    v-model:value="curVal"
    class="w-full"
    show-search
    allow-clear
    :filter-option="filterOption"
    :get-popup-container="(triggerNode) => triggerNode.parentNode"
    :title="curVal"
  >
    <slot></slot>

    <a-select-option
      v-for="opt in options"
      :key="opt"
      :value="opt.value ? opt.value + ' : ' + opt.label : opt.value"
      :title="opt.label"
      :disabled="opt.disabled"
    >
      {{ opt.value ? opt.value + ' : ' + opt.label : opt.label }}
    </a-select-option>
  </a-select>
</template>

<script lang="ts" setup>
import { computed } from 'vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  /**'value' and 'value : label' both OK*/
  value: any
  options: DaSelectorModel[]
  /**切値: 'value' or 'value : label'*/
  splitVal?: boolean
  /**'number'が設定されている場合、最終的に数値の値を出力します*/
  type: 'string' | 'number'
}
const props = withDefaults(defineProps<Props>(), {
  options: () => [],
  splitVal: false,
  type: 'string'
})
const emit = defineEmits(['update:value', 'change'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    const item = props.options?.find((item) => {
      return item.value == props.value
    })
    if (item) {
      return item.value ? item.value + ' : ' + item.label : ''
    }
    return props.value
  },
  set(val) {
    const oldVal = curVal.value

    const curOpt = props.options.find((item) => {
      const value = val?.split(' : ')[0]
      const label = val?.split(' : ')[1]
      return item.value === value && item.label === label
    })
    let v: string | number | undefined
    if (props.type === 'number') {
      v = val ? Number(val.split(' : ')[0]) : undefined
    } else {
      v = props.splitVal ? val?.split(' : ')[0] : val
    }
    emit('update:value', v)
    emit('change', v, curOpt, oldVal)
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const filterOption = (input, option) => {
  return option.key.label.indexOf(input) >= 0 || String(option.key.value ?? '').indexOf(input) >= 0
}
</script>
