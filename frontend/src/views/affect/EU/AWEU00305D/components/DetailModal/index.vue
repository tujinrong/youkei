<template>
  <a-modal
    :visible="visible"
    title="出力詳細"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    width="600px"
  >
    <h4>総件数：{{ props.currentRow?.num ?? 0 }}</h4>
    <vxe-table
      :row-config="{ isHover: true }"
      :data="currentRow?.jyokenlist"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="jyokenlabel" title="作成条件"> </vxe-column>
      <vxe-column field="value" title="値"> </vxe-column>
    </vxe-table>
    <template #footer>
      <a-button key="back" type="primary" @click="() => emit('update:visible', false)"
        >閉じる</a-button
      >
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { RirekiVM } from '../../type'

const props = defineProps<{
  visible: boolean
  currentRow: RirekiVM | null
}>()
const emit = defineEmits(['update:visible'])
</script>
