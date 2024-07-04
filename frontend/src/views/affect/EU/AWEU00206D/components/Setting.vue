<template>
  <div style="height: 450px">
    <div ref="el" style="width: 580px; margin-bottom: 10px">
      <div class="description-table mt-3">
        <table>
          <tbody>
            <tr>
              <th>電子公印の職務代理者適用年月日</th>
              <td>
                <div class="flex items-center">
                  <date-jp
                    style="width: 170px"
                    :value="props.dairiyTime.start"
                    :hanit="(props.dairiyTime.end as string)"
                    @change="(v) => handleTimeChange(v, 'start')"
                  />
                  <span>～</span>
                  <date-jp
                    style="width: 170px"
                    :value="props.dairiyTime.end"
                    :hanif="(props.dairiyTime.start as string)"
                    @change="(v) => handleTimeChange(v, 'end')"
                  />
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <vxe-table
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="kekkalist1"
      :height="450 - height"
      style="width: 1000px"
      :sort-config="{
        trigger: 'cell'
      }"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="rptnm" title="帳票名" :width="220"> </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        field="koinnmflg"
        title="市区町村長名の印字"
        min-width="150"
      >
        <template #default="{ row, rowIndex }">
          <a-checkbox
            v-model:checked="row.koinnmflg"
            @change="(e) => handlePrintChange(e, rowIndex, 'koinpicflg')"
          ></a-checkbox>
        </template>
      </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        field="koinpicflg"
        title="電子公印の印字"
        min-width="150"
      >
        <template #default="{ row, rowIndex }">
          <a-checkbox
            v-model:checked="row.koinpicflg"
            @change="(e) => handlePrintChange(e, rowIndex, 'koinnmflg')"
          ></a-checkbox>
        </template>
      </vxe-column>
      <vxe-column
        header-class-name="bg-editable"
        field="dairisyaflg"
        min-width="350"
        :resizable="false"
      >
        <template #header>
          <a-checkbox
            v-if="!props.kekkalist1.every((item) => !item.koinpicflg && !item.koinnmflg)"
            v-model:checked="checkedAll"
            :disabled="props.kekkalist1.length === 0"
            @change="isCheckAllChange"
          ></a-checkbox>
          市区町村長名・電子公印の職務代理者適用
        </template>
        <template #default="{ row }">
          <a-checkbox
            v-model:checked="row.dairisyaflg"
            :disabled="!row.koinpicflg && !row.koinnmflg"
            @change="editJudge.setEdited()"
          ></a-checkbox>
        </template>
      </vxe-column>
    </vxe-table>
  </div>
</template>
<script setup lang="ts">
import { ref, watch } from 'vue'
import { CheckboxChangeEvent } from 'ant-design-vue/es/checkbox/interface'
import dayjs from 'dayjs'
import { useElementSize } from '@vueuse/core'
import { KoinReportVM } from '../type'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Judgement } from '@/utils/judge-edited'
const props = defineProps<{
  dairiyTime: { start: string | Date; end: string | Date }
  kekkalist1: KoinReportVM[]
  editJudge: Judgement
}>()

const emit = defineEmits(['update:kekkalist1', 'update:dairiyTime'])

const el = ref(null)
const { width, height } = useElementSize(el)

const checkedAll = ref<boolean>(false)

watch(
  () => props.kekkalist1,
  (newKekkalist1) => {
    if (newKekkalist1.length === 0) {
      checkedAll.value = false
      return
    }

    let flag = true
    newKekkalist1.forEach((item) => {
      if ((item.koinpicflg || item.koinnmflg) && item.dairisyaflg === false) {
        flag = false
      }
    })

    checkedAll.value = flag
  },
  {
    immediate: true,
    deep: true
  }
)

const isCheckAllChange = (e: CheckboxChangeEvent) => {
  const flag = e.target.checked
  if (flag) {
    const tempDataSource = [...props.kekkalist1].map((item) => {
      if (item.koinpicflg || item.koinnmflg) {
        item.dairisyaflg = true
      }

      return item
    })
    emit('update:kekkalist1', tempDataSource)
  } else {
    const tempDataSource = [...props.kekkalist1].map((item) => {
      item.dairisyaflg = false
      return item
    })
    emit('update:kekkalist1', tempDataSource)
  }
  props.editJudge.setEdited()
}

// 市区町村長名の印字,電子公印の印字 change
const handlePrintChange = (
  e: CheckboxChangeEvent,
  rowIndex: number,
  type: 'koinpicflg' | 'koinnmflg'
) => {
  const flag = e.target.checked
  if (!flag && !props.kekkalist1[rowIndex][type]) {
    props.kekkalist1[rowIndex].dairisyaflg = false
    emit('update:kekkalist1', props.kekkalist1)
  }
  props.editJudge.setEdited()
}

const handleTimeChange = (v, type: 'start' | 'end') => {
  const dateStr = dayjs.isDayjs(v) ? dayjs(v).format('YYYY-MM-DD') : v
  emit('update:dairiyTime', {
    ...props.dairiyTime,
    [type]: dateStr
  })
  props.editJudge.setEdited()
}
</script>

<style scoped lang="less"></style>
