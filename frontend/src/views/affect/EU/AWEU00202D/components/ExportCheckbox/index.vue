<template>
  <a-space>
    <a-checkbox
      :checked="value.excelflg"
      @change="(e:CheckboxChangeEvent) => excelChange(e, 'excelflg')"
      >EXCEL</a-checkbox
    >
    <a-checkbox
      :checked="value.pdfflg"
      @change="(e:CheckboxChangeEvent) => excelChange(e, 'pdfflg')"
      >PDF</a-checkbox
    >
    <a-checkbox
      :checked="value.otherflg"
      :disabled="isDisabledCsv"
      @change="(e:CheckboxChangeEvent) => excelChange(e, 'otherflg')"
      >CSV</a-checkbox
    >
  </a-space>
</template>

<script setup lang="ts">
import { CheckboxChangeEvent } from 'ant-design-vue/es/checkbox/interface'
import { Form } from 'ant-design-vue'

interface ExportValueType {
  excelflg: boolean
  pdfflg: boolean
  otherflg: boolean
}

const props = defineProps<{
  value: ExportValueType
  isDisabledCsv: boolean
}>()

const emit = defineEmits(['update:value'])

const formItemContext = Form.useInjectFormItemContext()

const excelChange = (e: CheckboxChangeEvent, type: keyof ExportValueType) => {
  emit('update:value', { ...props.value, [type]: e.target.checked })
  formItemContext.onFieldChange()
}
</script>
