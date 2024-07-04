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
      ref="xTableRef"
      class="mt-2"
      :height="Math.max(tableHeight, 300)"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList1"
      :sort-config="{ trigger: 'cell', remote: true }"
      :header-cell-class-name="'bg-editable'"
      :empty-render="{ name: 'NotData' }"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      @cell-dblclick="({ row }) => forwardEdit(row)"
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
        <template #default="{ row }">
          <a @click="forwardEdit(row)">{{ row.tyusyututaisyonm }}</a>
        </template>
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
import { ref, reactive, toRef, onMounted, watchEffect } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { RowVM } from '../type'
import { changeTableSort } from '@/utils/util'
import { Enum抽出モード, PageSatatus } from '#/Enums'
import { watch } from 'vue'
const props = defineProps<{
  tableList1: RowVM[]
  pageParams
  totalCount
  tableHeight
  nendoflg
}>()
const emit = defineEmits(['update:pageParams', 'update:totalCount'])
const router = useRouter()
const route = useRoute()
const forwardEdit = (val: RowVM) => {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      tyusyukbn: Enum抽出モード.全体抽出,
      tyusyututaisyocd: val.tyusyututaisyocd,
      tyusyutunaiyo: val.tyusyutunaiyo,
      nendo: val.nendo,
      tyusyutuseq: val.tyusyutuseq
    }
  })
}

watch(
  () => props.pageParams,
  () => {
    emit('update:pageParams', props.pageParams)
    emit('update:totalCount', props.totalCount)
  }
)
</script>
<style lang="less" scoped></style>
