<template>
  <a-modal
    :visible="visible"
    :body-style="{ height: '800px' }"
    width="1000px"
    title="（GJ8101）消費税率マスタメンテナンス"
    centered
    destroy-on-close
    :mask-closable="false"
    @cancel="closeModal"
  >
    <div class="edit_table form max-w-160 flex-1 p-10">
      <a-row>
        <a-col span="24">
          <th class="required">適用開始日</th>
          <td>
            <DateJp v-model:value="formData.TAX_DATE_FROM" />
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">適用終了日</th>
          <td>
            <a-form-item>
              <DateJp v-model:value="formData.TAX_DATE_TO" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">消費税率（%）</th>
          <td>
            <a-form-item>
              <a-input v-model:value="formData.TAX_RITU" :maxlength="30" />
            </a-form-item>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="save"> 保存 </a-button>
          <a-button class="danger-btn" @click="delete"> 削除 </a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { nextTick, onMounted, reactive, watch } from 'vue'
// interface Props {
//   visible: boolean
// }
const model = defineModel('visible')
const editJudge = new Judgement()
const formData = reactive({
  TAX_DATE_FROM: undefined,
  TAX_DATE_TO: undefined,
  TAX_RITU: undefined,
})

onMounted(() => {
  nextTick(() => editJudge.reset())
})
watch(
  () => model.value,
  (newValue) => {
    if (newValue) {
      nextTick(() => editJudge.reset())
    }
  }
)

watch(
  () => formData,
  () => {
    editJudge.setEdited()
  },
  { deep: true }
)

const save = () => {}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    Object.assign(formData, {
      TAX_DATE_FROM: undefined,
      TAX_DATE_TO: undefined,
      TAX_RITU: undefined,
    })
    model.value = false
  })
}

const setEditModal = (data) => {
  Object.assign(formData, data)
}
defineExpose({
  setEditModal,
})
</script>
<style lang="scss" scoped>
th {
  width: 160px;
}
</style>
