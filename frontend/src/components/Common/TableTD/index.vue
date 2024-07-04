import { nextTick } from 'vue';
<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 明細value部(省略内容Tipsで表示)
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <td v-td class="ellipsis">
    <slot></slot>
  </td>
</template>

<script setup lang="ts">
import { isString } from '@/utils/is'
import { useSlots, nextTick } from 'vue'

const slots = useSlots()

//Directive: v-td
const vTd = {
  mounted(el) {
    getTitle(el)
  },
  updated(el) {
    getTitle(el)
  }
}

const getTitle = (el: HTMLElement) => {
  const text = slots.default?.()?.[0].children ?? ''
  if (isString(text)) {
    el.innerText = text.split(' : ').length === 2 ? text.split(' : ')[1] : text
  }
  nextTick(() => {
    el.title = el.scrollWidth > el.clientWidth ? el.innerText : ''
  })
}
</script>

<style lang="less" scoped>
.ellipsis {
  padding: 2px 14px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 0;
}
</style>
