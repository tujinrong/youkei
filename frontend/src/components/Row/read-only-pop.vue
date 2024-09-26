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
    v-if="!hideTh"
    :style="{
      width: thWidth ? thWidth + 'px' : undefined,
      borderTop: th ? undefined : 'none',
    }"
  >
    {{ th }}
  </th>
  <td v-if="!hideTd" class="ellipsis">
    <template v-if="isNumber(td)"
      ><div class="w-full text-right">
        <span> {{ td?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',') }}</span>
      </div>
    </template>
    <template v-else>
      {{ td }}
    </template>
  </td>
  <span v-if="after" class="ellipsis1">{{ after }}</span>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  thWidth?: string
  th?: string
  td?: string | number
  hideTh?: boolean
  hideTd?: boolean
  after?: string
}>()

function isNumber(value) {
  return !isNaN(value) && typeof value === 'number'
}
</script>

<style scoped>
.ellipsis {
  margin-left: 3px !important;
  padding: 0px 6px !important;
  padding-top: 4px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  /* background-color: white; */
  /* background-color: #9bafd4; */
  border: 1px solid gray !important;
  width: fit-content;
  min-height: 26px;
  display: flex;
}
.ellipsis1 {
  padding: 0px 6px !important;
  padding-top: 6px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: fit-content;
  display: flex;
}
/* th {
  padding: 0px 8px !important;
  padding-top: 0px !important;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: fit-content;
  height: fit-content;
  min-height: 26px;
  display: flex;
} */
</style>
