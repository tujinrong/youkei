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
            <a-form-item v-bind="validateInfos.TAX_DATE_FROM">
              <DateJp v-model:value="formData.TAX_DATE_FROM" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">適用終了日</th>
          <td>
            <a-form-item v-bind="validateInfos.TAX_DATE_TO">
              <DateJp v-model:value="formData.TAX_DATE_TO" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">消費税率（%）</th>
          <td>
            <a-form-item v-bind="validateInfos.TAX_RITU">
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
          <a-button class="warning-btn" @click="continueSave">
            保存して継続登録
          </a-button>
          <a-button class="danger-btn" @click="delete"> 削除 </a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { ITEM_REQUIRE_ERROR, SAVE_CONFIRM, SAVE_OK_INFO } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showInfoModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
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
const rules = reactive({
  TAX_DATE_FROM: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '適用開始日'),
    },
  ],
  TAX_DATE_TO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '適用終了日'),
    },
  ],
  TAX_RITU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '消費税率（%）'),
    },
  ],
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const save = () => {
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      message.success(SAVE_OK_INFO.Msg)
      closeModal()
    },
  })
}
const continueSave = () => {
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      message.success(SAVE_OK_INFO.Msg)
      resetFields()
    },
  })
}
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
