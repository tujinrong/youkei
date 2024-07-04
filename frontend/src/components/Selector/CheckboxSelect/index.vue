<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: checkbox 選択
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.01.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-tree-select
    v-model:value="curVal"
    class="w-full"
    :tree-data="curOpts"
    tree-checkable
    allow-clear
    tree-node-filter-prop="label"
    tree-default-expand-all
    max-tag-count="responsive"
    dropdown-class-name="select-dropdown"
  />
</template>

<script lang="ts" setup>
import { computed } from 'vue'

const props = withDefaults(
  defineProps<{
    value: string[]
    options: DaSelectorModel[]
    /**すべて */
    fullSelect?: boolean
  }>(),
  { value: () => [] }
)
const emit = defineEmits(['update:value'])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curVal = computed({
  get: () => {
    return props.value
  },
  set: (val) => {
    emit('update:value', val)
  }
})
const curOpts = computed(() => {
  if (props.fullSelect) {
    return [
      {
        label: 'すべて',
        value: 'Full',
        children: props.options
      }
    ]
  } else {
    return props.options
  }
})
</script>

<style lang="less">
.select-dropdown {
  padding-left: 8px !important;
  .ant-select-tree-switcher {
    display: none;
  }
  .ant-select-tree-indent {
    display: none;
  }
}
</style>
