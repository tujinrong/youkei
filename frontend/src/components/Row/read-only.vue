<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 表示のみ行
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.08.27
 * 作成者　　: 魏
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <th
    class="bg-readonly"
    :style="{
      width: thWidth ? thWidth + 'px' : undefined,
      borderTop: th ? undefined : 'none',
    }"
  >
    {{ th }}
  </th>
  <td v-if="!hideTd" class="ellipsis">{{ td }}　{{ after }}</td>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  thWidth?: string
  th?: string
  td?: string | number
  hideTd?: boolean
  after?: string
}>()
</script>

<style scoped>
.ellipsis {
  padding: 2px 14px !important;
  padding-top: 8px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 0;
  display: flex;
}
</style>
