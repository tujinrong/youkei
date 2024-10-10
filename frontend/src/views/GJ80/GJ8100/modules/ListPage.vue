<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card :bordered="false" class="staticWidth">
      <h1>（GJ8100）消費税率一覧</h1>
      <div class="my-2 flex justify-between">
        <a-space :size="20">
          <a-button type="primary" @click="add">新規登録</a-button>
        </a-space>
        <EndButton /></div
    ></a-card>
    <a-card ref="cardRef" class="flex-1 staticWidth">
      <vxe-table
        class="h-full"
        ref="xTableRef"
        min-height="650px"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        @cell-dblclick="({ row }) => edit(row.TAX_DATE_FROM)"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column
          header-align="center"
          field="TAX_DATE_FROM"
          title="適用開始日"
          width="160"
          align="center"
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
          :resizable="true"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditModal
    v-model:visible="visible"
    ref="editModalRef"
    v-bind="{ editkbn }"
    @getTableList="searchAll"
  />
</template>
<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { VxeTableInstance } from 'vxe-pc-ui'
import EditModal from './EditPage.vue'
import { getDateJpText } from '@/utils/util'
import { EnumEditKbn } from '@/enum'
import { Search } from '../service'
import { SearchRowVM } from '../type'
const visible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const editModalRef = ref()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchRowVM[]>([])
const cardRef = ref()

onMounted(async () => {
  await searchAll()
})
const searchAll = async () => {
  const res = await Search({})
  tableData.value = res.KEKKA_LIST
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
