import { nextTick } from 'vue';
<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
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
import { useSlots, nextTick } from 'vue'

const slots = useSlots()

//Directive: v-td
const vTd = {
  mounted(el) {
    getTitle(el)
  },
  updated(el) {
    getTitle(el)
  },
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

//文字かどうかを判断する
function isString(val: unknown): val is string {
  return is(val, 'String')
}
//値が特定の型ではないかどうかを判断する
function is(val: unknown, type: string) {
  return toString.call(val) === `[object ${type}]`
}
</script>

<style scoped>
.ellipsis {
  padding: 2px 14px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 0;
}
</style>
