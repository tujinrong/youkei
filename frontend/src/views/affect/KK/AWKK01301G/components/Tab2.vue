<template>
  <div>
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
      class="text-end"
    />
    <vxe-table
      class="mt-2"
      :height="Math.max(tableHeight, 300)"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList2"
      :sort-config="{ trigger: 'cell', remote: true }"
      :empty-render="{ name: 'NotData' }"
      :header-cell-class-name="'bg-editable'"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
    >
      <vxe-column
        v-if="nendoflg"
        field="nendo"
        :params="{ order: 1 }"
        title="年度"
        width="120"
        min-width="70"
        sortable
      >
      </vxe-column>
      <vxe-column
        field="tyusyututaisyonm"
        :params="{ order: 2 }"
        title="抽出対象"
        width="500"
        min-width="90"
        sortable
      >
      </vxe-column>

      <vxe-column
        field="tyusyutunaiyo"
        :params="{ order: 3 }"
        title="抽出内容"
        width="450"
        min-width="100"
        sortable
      ></vxe-column>
      <vxe-column
        field="tyusyutunum"
        :params="{ order: 4 }"
        title="抽出人数"
        width="150"
        min-width="90"
        sortable
      ></vxe-column>
      <vxe-column
        field="regdttm"
        :params="{ order: 5 }"
        title="登録日時"
        min-width="90"
        sortable
      ></vxe-column>
    </vxe-table>
  </div>
</template>
<script setup lang="ts">
import { ref, reactive, toRef, onMounted, watchEffect, watch } from 'vue'
import { RowVM } from '../type'
import { changeTableSort } from '@/utils/util'
const props = defineProps<{
  tableList2: RowVM[]
  pageParams
  totalCount
  tableHeight
  nendoflg
}>()
const emit = defineEmits(['update:pageParams', 'update:totalCount'])
watch(
  () => props.pageParams,
  () => {
    emit('update:pageParams', props.pageParams)
    emit('update:totalCount', props.totalCount)
  }
)
</script>
<style lang="less" scoped></style>
