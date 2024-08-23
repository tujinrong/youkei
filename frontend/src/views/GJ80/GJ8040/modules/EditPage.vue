<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>使用者マスタメンテナンス</h1>
    <div class="self_adaption_table form max-w-160">
      <div class="my-2 header_operation flex justify-between w-full">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
        </a-space>
        <a-button type="primary" class="text-end" @click="goList"
          >一覧へ</a-button
        >
      </div>
      <a-form>
        <a-row>
          <a-col span="24">
            <th class="required">ユーザーID</th>
            <td>
              <a-form-item v-bind="validateInfos.USER_ID">
                <a-input
                  v-model:value="formData.USER_ID"
                  :maxlength="10"
                  :disabled="!isNew"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">ユーザー名</th>
            <td>
              <a-form-item v-bind="validateInfos.USER_NAME">
                <a-input
                  v-model:value="formData.USER_NAME"
                  :maxlength="20"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">パスワード</th>
            <td>
              <a-form-item v-bind="validateInfos.PASS">
                <a-input
                  v-model:value="formData.PASS"
                  :maxlength="20"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>パスワード有効期限</th>
            <td>
              <DateJp v-model:value="formData.PASS_KIGEN_DATE" disabled />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>パスワード変更日</th>
            <td>
              <DateJp v-model:value="formData.PASS_UP_DATE" disabled />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">使用区分</th>
            <td>
              <a-form-item v-bind="validateInfos.SIYO_KBN">
                <ai-select
                  v-model:value="formData.SIYO_KBN"
                  :options="SIYO_KBN_LIST"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>使用停止日</th>
            <td>
              <DateJp v-model:value="formData.TEISI_DATE" disabled />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>使用停止理由</th>
            <td>
              <a-input v-model:value="formData.TEISI_RIYU" disabled />
            </td>
          </a-col>
        </a-row>
      </a-form>
    </div>
  </a-card>
</template>
<script setup lang="ts">
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { EnumEditKbn, PageStatus } from '@/enum'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { nextTick, onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Delete, InitDetail, Save } from '../service'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageStatus
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageStatus.New
const editJudge = new Judgement('GJ8040')
let upddttm
const formData = reactive({
  USER_ID: '',
  USER_NAME: '',
  PASS: '',
  PASS_KIGEN_DATE: new Date(),
  PASS_UP_DATE: new Date(),
  SIYO_KBN: 0,
  TEISI_DATE: new Date(),
  TEISI_RIYU: '',
})
const SIYO_KBN_LIST = ref<CodeNameModel[]>([])
const rules = reactive({
  USER_ID: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザーID'),
    },
  ],
  USER_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ユーザー名'),
    },
  ],
  PASS: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'パスワード'),
    },
  ],
  SIYO_KBN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '使用区分'),
    },
  ],
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  formData.USER_ID = String(route.query.USER_ID)

  // InitDetail({
  //   USER_ID: formData.USER_ID,
  //   EDIT_KBN: isNew ? EnumEditKbn.Add : EnumEditKbn.Edit,
  // })
  //   .then((res) => {
  //     SIYO_KBN_LIST.value = res.SIYO_KBN_LIST
  //     if (!isNew) {
  //       Object.assign(formData, res.CODE_VM)
  //       upddttm = res.CODE_VM.UP_DATE
  //     }
  //     nextTick(() => editJudge.reset())
  //   })
  //   .catch((error) => {
  //     router.push({ name: route.name, query: { refresh: '1' } })
  //   })
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    resetFields()
    router.push({ name: route.name, query: { refresh: '1' } })
  })
}

//登録処理
const saveData = async () => {
  await validate()
  // showSaveModal({
  //   content: SAVE_CONFIRM.Msg,
  //   onOk: async () => {
  //     try {
  //       await Save({
  //         CODE_VM: {
  //           ...formData,
  //           UP_DATE: isNew ? undefined : upddttm,
  //         },
  //         EDIT_KBN: isNew ? EnumEditKbn.Add : EnumEditKbn.Edit,
  //       })
  //       router.push({ name: route.name, query: { refresh: '1' } })
  //       message.success(SAVE_OK_INFO.Msg)
  //     } catch (error) {}
  //   },
  // })
}

//削除処理
const deleteData = () => {
  // showDeleteModal({
  //   handleDB: true,
  //   content: DELETE_CONFIRM.Msg,
  //   onOk: async () => {
  //     try {
  //       await Delete({
  //         USER_ID: formData.USER_ID,
  //         UP_DATE: upddttm,
  //         EDIT_KBN: EnumEditKbn.Edit,
  //       })
  //       router.push({ name: route.name, query: { refresh: '1' } })
  //       message.success(DELETE_OK_INFO.Msg)
  //     } catch (error) {}
  //   },
  // })
}
</script>
<style lang="scss" scoped>
th {
  width: 150px;
}
</style>
