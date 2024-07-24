<template>
  <th :class="{ required }">{{ label }}</th>
  <td v-if="canEdit">
    <a-form-item v-bind="validateInfos[key]">
      <a-input
        v-if="type === 'input'"
        v-model:value="model"
        :maxlength="length"
      />
      <a-textarea
        v-else-if="type === 'textarea'"
        v-model:value="model"
        :maxlength="length"
      />
      <a-input-number
        v-else-if="type === 'number'"
        v-model:value="model"
        :max="max"
        :min="min"
      />
    </a-form-item>
  </td>
  <TD v-else>{{ model }}</TD>
</template>

<script setup lang="ts">
import { validateInfos } from 'ant-design-vue/es/form/useForm'
const model = defineModel()

const props = defineProps<{
  canEdit?: boolean
  validateInfos?: validateInfos
  label: string
  key: string
  type: 'input' | 'textarea' | 'number' | 'select' | 'date'
  required?: boolean
  length?: number
  max?: number
  min?: number
  options?: DaSelectorModel[]
}>()
</script>

<style scoped></style>
