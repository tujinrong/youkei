<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card :bordered="false">
      <h1>（GJ8100）消費税率一覧</h1>
      <div class="my-2 flex justify-between">
        <a-space :size="20">
          <a-button type="primary" @click="add">新規登録</a-button>
        </a-space>
        <close-page /></div
    ></a-card>
    <a-card ref="cardRef" class="flex-1">
      <vxe-table
        class="h-full"
        ref="xTableRef"
        :height="height - 64"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        @cell-dblclick="() => edit()"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column
          header-align="center"
          field="TAX_DATE_FROM"
          title="適用開始日"
          min-width="80"
          align="center"
          :resizable="true"
          ><template #default="{ row }">
            <a @click="edit">{{ row.TAX_DATE_FROM }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TAX_DATE_TO"
          title="適用終了日"
          min-width="160"
          align="center"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TAX_RITU"
          title="消費税率（%）"
          min-width="100"
          align="right"
          :resizable="true"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditModal v-model:visible="visible" ref="editModalRef" />
</template>
<script setup lang="ts">
import { ref } from 'vue'
import { VxeTableInstance } from 'vxe-pc-ui'
import EditModal from './EditPage.vue'
import { useElementSize } from '@vueuse/core'
const visible = ref(false)
const editModalRef = ref()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref([
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '1' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '2' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '3' },
])
const cardRef = ref()
const { height } = useElementSize(cardRef)
const add = () => {
  visible.value = true
}
const edit = () => {
  const currentRow = xTableRef.value?.getCurrentRecord()
  if (currentRow) {
    editModalRef.value.setEditModal(currentRow)
    visible.value = true
  } else {
  }
}
</script>
<style lang="scss" scoped></style>
