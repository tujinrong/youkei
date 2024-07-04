<template>
  <vxe-table
    ref="xTableRef"
    :loading="loading"
    :height="450"
    :column-config="{ resizable: true }"
    :row-config="{ isCurrent: true, isHover: true }"
    :data="data"
    :empty-render="{ name: 'NotData' }"
    header-cell-class-name="bg-editable"
  >
    <vxe-column field="hyojiflg" title="表示" width="110">
      <template #default="{ row }">
        <a-checkbox
          v-model:checked="row.hyojiflg"
          @change="() => editJudge.setEdited()"
        ></a-checkbox>
      </template>
    </vxe-column>
    <vxe-column field="hyojinm" title="詳細条件表示名" width="75%" />
    <vxe-column field="sort" title="並び" :resizable="false">
      <template #default="{ row, rowIndex }">
        <a-button
          type="primary"
          :disabled="rowIndex === 0"
          @click="goUpOrDown(row, rowIndex, 'UP')"
        >
          <template #icon><ArrowUpOutlined /></template>
        </a-button>
        <a-button
          type="primary"
          :disabled="rowIndex === data.length - 1"
          class="m-l-1"
          @click="goUpOrDown(row, rowIndex, 'DOWN')"
        >
          <template #icon><ArrowDownOutlined /></template>
        </a-button>
      </template>
    </vxe-column>
  </vxe-table>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { ArrowDownOutlined, ArrowUpOutlined } from '@ant-design/icons-vue'
import { VxeTableInstance } from 'vxe-table'
import { Judgement } from '@/utils/judge-edited'

const props = defineProps<{
  data: any[]
  loading: boolean
  editJudge: Judgement
}>()
const emit = defineEmits(['update:data'])

const xTableRef = ref<VxeTableInstance>()

//並び順
const goUpOrDown = (row, index: number, type: 'UP' | 'DOWN') => {
  const start = type === 'UP' ? index - 1 : index + 1
  const newArr = JSON.parse(JSON.stringify(props.data))
  newArr[index] = newArr.splice(start, 1, newArr[index])[0]
  emit('update:data', newArr)

  props.editJudge.setEdited()
  setTimeout(() => {
    xTableRef.value?.setCurrentRow(row)
  }, 0)
}
</script>
