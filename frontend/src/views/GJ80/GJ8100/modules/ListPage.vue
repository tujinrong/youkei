<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>(GJ8100)消費税率一覧</h1>
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
</template>
<script setup lang="ts">
import { PageStatus } from '@/enum'
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-pc-ui'

const route = useRoute()
const router = useRouter()

const xTableRef = ref<VxeTableInstance>()
const tableData = ref([
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '1' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '2' },
  { TAX_DATE_FROM: '1', TAX_DATE_TO: '1', TAX_RITU: '3' },
])

const add = () => {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
    },
  })
}
const edit = () => {
  const currentRow = xTableRef.value?.getCurrentRecord()
  if (currentRow) {
    router.push({
      name: route.name,
      query: {
        status: PageStatus.Edit,
        TAX_DATE_FROM: currentRow.TAX_DATE_FROM,
        TAX_DATE_TO: currentRow.TAX_DATE_TO,
        TAX_RITU: currentRow.TAX_RITU,
      },
    })
  } else {
    console.log('请选择一行')
  }
  console.log('edit')
}
</script>
<style lang="scss" scoped></style>
