<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
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
    :disabled="disabled"
    :filter-option="filterOption"
    :get-popup-container="(triggerNode) => triggerNode.parentNode"
    :title="curVal"
  >
    <slot></slot>

    <ai-select-option
      v-for="opt in options"
      :key="opt"
      :value="opt.NAME ? opt.CODE + ' : ' + opt.NAME : opt.CODE"
      :title="opt.NAME"
      :disabled="opt.disabled"
    >
      {{ opt.CODE ? opt.CODE + ' : ' + opt.NAME : opt.NAME }}
    </ai-select-option>
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
  options: CmCodeNameModel[]
  /**切値: 'value' or 'value : label'*/
  splitVal?: boolean
  disabled?: boolean
  /**'number'が設定されている場合、最終的に数値の値を出力します*/
  type: 'string' | 'number'
}
const props = withDefaults(defineProps<Props>(), {
  options: () => [],
  splitVal: false,
  disabled: false,
  type: 'string',
})
const emit = defineEmits(['update:value', 'change'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get() {
    const item = props.options?.find((item) => {
      return item.CODE == props.value
    })
    if (item) {
      return item.CODE ? item.CODE + ' : ' + item.NAME : ''
    }
    return props.value
  },
  set(val) {
    const oldVal = curVal.value

    const curOpt = props.options.find((item) => {
      const value = val?.split(' : ')[0]
      const label = val?.split(' : ')[1]
      return item.CODE === value && item.NAME === label
    })
    let v: string | number | undefined
    if (props.type === 'number') {
      v = val ? Number(val.split(' : ')[0]) : undefined
    } else {
      v = props.splitVal ? val?.split(' : ')[0] : val
    }
    emit('update:value', v)
    emit('change', v, curOpt, oldVal)
  },
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const filterOption = (input, option) => {
  return (
    option.key.NAME.indexOf(input) >= 0 ||
    String(option.key.CODE ?? '').indexOf(input) >= 0
  )
}
</script>
