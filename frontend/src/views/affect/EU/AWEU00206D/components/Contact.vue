<template>
  <div style="height: 450px">
    <vxe-table
      class="mt-3"
      height="460"
      style="width: 1000px"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :data="kekkalist2"
      :sort-config="{
        trigger: 'cell'
      }"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="rptnm" title="帳票名" :width="200"> </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        class-name="col"
        field="hanyokbn2"
        title="課"
        min-width="150"
      >
        <template #default="{ row }">
          <a-select
            v-model:value="row.kacd"
            :options="kacdList"
            allow-clear
            @change="editJudge.setEdited()"
          ></a-select>
        </template>
      </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        class-name="col"
        field="hanyokbn3"
        title="係"
        min-width="150"
      >
        <template #default="{ row }">
          <a-select
            v-model:value="row.kakaricd"
            :options="kakaricdList"
            allow-clear
            @change="editJudge.setEdited()"
          ></a-select>
        </template>
      </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        field="toiawasesakicd"
        title="問い合わせ先"
        min-width="350"
        class-name="col"
        :resizable="false"
      >
        <template #default="{ row }">
          <a-select
            v-model:value="row.toiawasesakicd"
            :options="toiawasesakicdList"
            allow-clear
            @change="(value) => handleChange(value, row)"
          ></a-select>
        </template>
      </vxe-column>
    </vxe-table>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, watch } from 'vue'
import { ContactInfoReportVM } from '../type'
import {} from '../service'
import { Judgement } from '@/utils/judge-edited'
const props = defineProps<{
  kekkalist2: ContactInfoReportVM[]
  kacdList: DaSelectorModel[]
  kakaricdList: DaSelectorModel[]
  toiawasesakicdList: DaSelectorModel[]
  editJudge: Judgement
}>()

const emit = defineEmits(['update:kekkalist2'])
const options = ref<{ label: string; value: string; detail: string }[]>([])

const handleChange = (value, row) => {
  row.detail = options.value.find((item) => item.value === value)?.detail
  emit('update:kekkalist2', props.kekkalist2)
  props.editJudge.setEdited()
}
</script>
<style scoped lang="less">
:deep(.col) {
  .vxe-cell {
    padding: 0;
  }
}
</style>
