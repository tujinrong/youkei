<template>
  <a-modal
    :visible="props.visible"
    title="条件メモ"
    :closable="false"
    :mask-closable="false"
    destroy-on-close
    width="700px"
    @cancel="emit('update:visible', false)"
  >
    <a-textarea
      :rows="4"
      :value="props.memo"
      @change="(e) => emit('update:memo', e.target.value)"
    />

    <template #footer>
      <a-button style="float: left" type="primary" @click="closeModal">確定</a-button>

      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue'

const props = defineProps<{
  visible: boolean
  memo: string
}>()

const emit = defineEmits(['update:visible', 'update:memo'])

const closeModal = () => {
  emit('update:visible', false)
}
</script>
