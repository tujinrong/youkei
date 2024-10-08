<template>
  <a-modal
    :open="visible"
    :body-style="{ height: '450px' }"
    width="800px"
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
              <DateJp v-model:value="formData.TAX_DATE_FROM" class="max-w-50" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">適用終了日</th>
          <td>
            <a-form-item v-bind="validateInfos.TAX_DATE_TO">
              <DateJp v-model:value="formData.TAX_DATE_TO" class="max-w-50" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">消費税率（%）</th>
          <td>
            <a-form-item v-bind="validateInfos.TAX_RITU" class="max-w-15">
              <a-input-number
                v-model:value="formData.TAX_RITU"
                :min="0"
                :max="99"
                :maxlength="2"
                class="max-w-15"
              />
            </a-form-item>
            <span class="flex items-center ml-2">%</span>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="save"> 保存 </a-button>

          <a-button class="danger-btn" @click="deleteData"> 削除 </a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, reactive, watch } from 'vue'
import { Delete, InitDetail, Save } from '../service'
import { SearchRowVM } from '../type'
import { EnumEditKbn } from '@/enum'

const props = defineProps<{
  editkbn: EnumEditKbn
}>()
const emit = defineEmits(['update:visible', 'getTableList'])
let upddttm
const isNew = computed(() => props.editkbn === EnumEditKbn.Add)
const model = defineModel('visible')
const editJudge = new Judgement()
const formData = reactive<SearchRowVM>({
  TAX_DATE_FROM: undefined,
  TAX_DATE_TO: undefined,
  TAX_RITU: undefined,
})

watch(
  () => model.value,
  async (newValue) => {
    if (newValue) {
      if (newValue && !isNew.value) {
        await init()
      }
      nextTick(() => {
        editJudge.reset()
        clearValidate()
      })
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
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)

//初期化処理
const init = async () => {
  try {
    const res = await InitDetail({
      TAX_DATE_FROM: formData.TAX_DATE_FROM,
      EDIT_KBN: props.editkbn,
    })
    Object.assign(formData, res.TAX)
    upddttm = res.TAX.UP_DATE
  } catch (error) {}
}

//登録処理
const save = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Save({
          TAX: { ...formData, UP_DATE: upddttm },
          EDIT_KBN: props.editkbn,
        })
        message.success(SAVE_OK_INFO.Msg)
        closeModal()
        emit('getTableList')
      } catch (error) {}
    },
  })
}

//削除処理
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: DELETE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Delete({
          TAX_DATE_FROM: formData.TAX_DATE_FROM,
          UP_DATE: upddttm,
        })
        closeModal()
        emit('getTableList')
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
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
    nextTick(() => {
      clearValidate()
    })
  })
}

const setEditModal = (data) => {
  formData.TAX_DATE_FROM = data
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
