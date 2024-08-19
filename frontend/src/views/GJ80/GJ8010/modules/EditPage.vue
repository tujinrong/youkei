<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>コードマスタメンテナンス</h1>
    <div class="self_adaption_table form max-w-160">
      <a-form>
        <a-row>
          <a-col span="24">
            <th class="bg-readonly">種類区分</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.SYURUI_KBN" disabled></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <div class="my-2 header_operation flex justify-between w-full">
          <a-space :size="20">
            <a-button class="warning-btn" @click="saveData">登録</a-button>
            <a-button
              type="primary"
              danger
              :disabled="isNew"
              @click="deleteData"
              >削除</a-button
            >
          </a-space>
          <a-button type="primary" class="text-end" @click="goList"
            >一覧へ</a-button
          >
        </div>
        <a-row>
          <a-col span="24">
            <th class="required">名称コード</th>
            <td>
              <a-form-item v-bind="validateInfos.MEISYO_CD">
                <a-input-number
                  v-model:value="formData.MEISYO_CD"
                  :min="0"
                  :maxlength="2"
                  :disabled="!isNew"
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
  </a-card>
</template>
<script setup lang="ts">
import { Enum編集区分, PageSatatus } from '@/enum'
import { Judgement } from '@/utils/judge-edited'
import { reactive, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { DetailVM } from '../type'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { Form, message } from 'ant-design-vue'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Delete, Save } from '../service'

const props = defineProps<{
  status: PageSatatus
}>()
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageSatatus.New
const editJudge = new Judgement('GJ8010')
let upddttm
const formData = reactive({
  SYURUI_KBN: '',
  MEISYO_CD: undefined as number | undefined,
  MEISYO: '',
  RYAKUSYO: '',
} as DetailVM)

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
//監視定義
//--------------------------------------------------------------------------

watch(formData, () => editJudge.setEdited())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    router.push({ name: route.name })
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
          CODE_VM: {
            ...formData,
            UP_DATE: isNew ? undefined : upddttm,
          },
          EDIT_KBN: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
        })
        router.push({ name: route.name as string, query: { refresh: '1' } })
        message.success(SAVE_OK_INFO.Msg)
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
          SYURUI_KBN: formData.SYURUI_KBN,
          MEISYO_CD: formData.MEISYO_CD,
          UP_DATE: upddttm,
        })
        router.push({ name: route.name as string, query: { refresh: '1' } })
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 130px;
}
h1 {
  font-size: 24px;
}
:deep(.ant-form-item) {
  width: 100%;
  margin-bottom: 0;
}
</style>
