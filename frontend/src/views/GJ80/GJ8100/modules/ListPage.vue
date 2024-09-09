<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>（GJ8100）消費税率一覧</h1>
    <div class="my-2 flex justify-between">
      <a-space :size="20">
        <a-button type="primary" @click="add">新規登録</a-button>
        <a-button type="primary" @click="edit">変更（表示）</a-button>
      </a-space>
      <close-page />
    </div>
    <vxe-table
      class="h-full"
      ref="xTableRef"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column
        field="TAX_DATE_FROM"
        title="適用開始日"
        min-width="80"
        :resizable="true"
      >
      </vxe-column>
      <vxe-column
        field="TAX_DATE_TO"
        title="適用終了日"
        min-width="160"
        :resizable="true"
      >
      </vxe-column>
      <vxe-column
        field="TAX_RITU"
        title="消費税率（%）"
        min-width="100"
        :resizable="true"
      ></vxe-column>
    </vxe-table>
  </a-card>
  <EditModal v-model:visible="visible" ref="editModalRef" />
</template>
<script setup lang="ts">
import { ref } from 'vue'
import { VxeTableInstance } from 'vxe-pc-ui'
import EditModal from './EditPage.vue'
const visible = ref(false)
const editModalRef = ref()
const xTableRef = ref<VxeTableInstance>()
const tableData = ref([
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '1' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '2' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '3' },
])

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
