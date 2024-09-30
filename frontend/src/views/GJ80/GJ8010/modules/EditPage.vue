<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="（GJ8011）コードマスタメンテナンス"
    width="800px"
    :body-style="{ height: '450px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
    ><div class="modal-container">
      <div class="edit_table form w-130">
        <a-form>
          <a-row>
            <a-col span="10">
              <read-only-pop
                th="種類区分"
                th-width="100"
                :td="formData.SYURUI_NM"
                :maxlength="20"
                class="w-120!"
              ></read-only-pop>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">名称コード</th>
              <td>
                <a-form-item v-bind="validateInfos.MEISYO_CD">
                  <a-input-number
                    v-model:value="formData.MEISYO_CD"
                    :min="0"
                    :max="99"
                    :maxlength="2"
                    :disabled="!isNew"
                    class="w-14"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">名称</th>
              <td>
                <a-form-item v-bind="validateInfos.MEISYO">
                  <a-input
                    v-model:value="formData.MEISYO"
                    :maxlength="25"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">略称</th>
              <td>
                <a-form-item v-bind="validateInfos.RYAKUSYO">
                  <a-input
                    v-model:value="formData.RYAKUSYO"
                    :maxlength="5"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData"> 保存 </a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData">
            削除
          </a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { Judgement } from '@/utils/judge-edited'
import { computed, nextTick, reactive, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { DetailVM } from '../type'
import { convertToFullWidth } from '@/utils/util'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { Form, message } from 'ant-design-vue'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Delete, InitDetail, Save } from '../service'

const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
  SYURUI_KBN?: number
  MEISYO_CD?: number
  SYURUI_NM?: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])

const editJudge = new Judgement('')
let upddttm
const formData = reactive({
  SYURUI_NM: '',
  SYURUI_KBN: undefined as number | undefined,
  MEISYO_CD: undefined as number | undefined,
  MEISYO: '',
  RYAKUSYO: '',
})

const rules = reactive({
  MEISYO_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '名称コード'),
    },
  ],
  MEISYO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '名称'),
    },
  ],
  RYAKUSYO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '略称'),
    },
  ],
})

const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
const isNew = computed(() => (props.editkbn === EnumEditKbn.Add ? true : false))
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (!newValue) return
    formData.SYURUI_NM = props.SYURUI_NM ?? ''
    formData.SYURUI_KBN = props.SYURUI_KBN
    if (!isNew.value) {
      try {
        formData.MEISYO_CD = props.MEISYO_CD
        const res = await InitDetail({
          MEISYO_CD: formData.MEISYO_CD || 0,
          SYURUI_KBN: formData.SYURUI_KBN,
          EDIT_KBN: EnumEditKbn.Edit,
        })
        Object.assign(formData, res.CODE)
        upddttm = res.CODE.UP_DATE
      } catch (error) {
        closeModal()
      }
    }
    nextTick(() => editJudge.reset())
  }
)

watch(formData, () => editJudge.setEdited())

watch(
  () => formData.MEISYO,
  (newValue) => {
    if (newValue) formData.MEISYO = convertToFullWidth(newValue)
  }
)

watch(
  () => formData.RYAKUSYO,
  (newValue) => {
    if (newValue) formData.RYAKUSYO = convertToFullWidth(newValue)
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const closeModal = () => {
  resetFields()
  clearValidate()
  modalVisible.value = false
  emit('getTableList')
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

//登録処理
const saveData = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Save({
          CODE: {
            ...formData,
            UP_DATE: isNew.value ? undefined : upddttm,
          },
          EDIT_KBN: isNew.value ? EnumEditKbn.Add : EnumEditKbn.Edit,
        })
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {
        // closeModal()
      }
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
          SYURUI_KBN: formData.SYURUI_KBN,
          MEISYO_CD: formData.MEISYO_CD,
          UP_DATE: upddttm,
        })
        closeModal()
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {
        // closeModal()
      }
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 100px;
}
.modal-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  width: 100%;
}
</style>
