<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card
      :bordered="false"
      class="staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <h1>（GJ8100）消費税率一覧</h1>
      <div class="my-2 flex justify-between">
        <a-space :size="20">
          <a-button type="primary" @click="add">新規登録</a-button>
        </a-space>
        <EndButton /></div
    ></a-card>
    <a-card
      ref="cardRef"
      class="flex-1 staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `抽出件数： ${total} 件`"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        class="h-full"
        ref="xTableRef"
        min-height="650px"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        @cell-dblclick="({ row }) => edit(row.TAX_DATE_FROM)"
        :sort-config="{ trigger: 'cell', orders: ['asc', 'desc'] }"
        :empty-render="{ name: 'NotData' }"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="TAX_DATE_FROM"
          title="適用開始日"
          width="160"
          align="center"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
          ><template #default="{ row }">
            <a @click="edit(row.TAX_DATE_FROM)">{{
              row.TAX_DATE_FROM
                ? getDateJpText(new Date(row.TAX_DATE_FROM))
                : ''
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TAX_DATE_TO"
          title="適用終了日"
          width="160"
          align="center"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
          ><template #default="{ row }">
            <a @click="edit(row.TAX_DATE_FROM)">{{
              row.TAX_DATE_TO ? getDateJpText(new Date(row.TAX_DATE_TO)) : ''
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TAX_RITU"
          title="消費税率（%）"
          width="120"
          align="right"
          sortable
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditModal
    v-model:visible="visible"
    ref="editModalRef"
    v-bind="{ editkbn }"
    @getTableList="handleSearch"
  />
</template>
<script setup lang="ts">
import { onMounted, ref, toRef } from 'vue'
import { VxeTableInstance } from 'vxe-pc-ui'
import EditModal from './EditPage.vue'
import { changeTableSort, getDateJpText } from '@/utils/util'
import { EnumEditKbn } from '@/enum'
import { Search } from '../service'
import { SearchRowVM } from '../type'
import useSearch from '@/hooks/useSearch'

const visible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const editModalRef = ref()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchRowVM[]>([])
const cardRef = ref()

onMounted(async () => {
  await handleSearch()
})

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: null,
})

const handleSearch = async () => {
  tableData.value = []
  const res = await searchData()
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}

const add = () => {
  editkbn.value = EnumEditKbn.Add
  visible.value = true
}
const edit = (val) => {
  editModalRef.value.setEditModal(val)
  editkbn.value = EnumEditKbn.Edit
  visible.value = true
}
</script>
<style lang="scss" scoped></style>
