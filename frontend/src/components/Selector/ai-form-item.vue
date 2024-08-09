<template>
  <a-col v-bind="layout">
    <th :class="{ required }">{{ label }}</th>
    <td v-if="!readonly">
      <a-form-item v-bind="validateInfos?.[key]" class="w-full">
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
          class="w-full"
        />
        <ai-select
          v-else-if="type === 'select'"
          v-model:value="model"
          :options="options"
        />
      </a-form-item>
    </td>
    <TD v-else>{{ model }}</TD>
  </a-col>
</template>

<script setup lang="ts">
import type { validateInfos } from 'ant-design-vue/es/form/useForm'
const model = defineModel<any>('value')

const props = defineProps<{
  /**Col */
  layout: {
    span?: number
    md?: number
    lg?: number
    xl?: number
    xxl?: number
  }
  /**項目名 */
  label: string
  /**変数名 */
  key: string
  /**コントロール */
  type: 'input' | 'textarea' | 'number' | 'select' | 'date'
  /**チェック情報 */
  validateInfos?: validateInfos
  /**必須 */
  required?: boolean
  readonly?: boolean
  /**桁数 */
  length?: number
  /**最大値 */
  max?: number
  /**最小値 */
  min?: number
  /**選択肢 */
  options?: CodeNameModel[]
}>()
</script>

<style lang="scss" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
