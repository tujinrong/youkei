<template>
  <div>
    <a-card :bordered="false" class="mb-2 h-full">
      <h1>（GJ8051）金融機関マスタメンテナンス</h1>
      <div class="self_adaption_table form max-w-160">
        <div class="my-2 header_operation flex justify-between w-full">
          <a-space :size="20">
            <a-button class="warning-btn" @click="saveData">保存</a-button>
            <a-button class="danger-btn" :disabled="isNew" @click="deleteData"
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
              <th class="required">金融機関コード</th>
              <td>
                <a-form-item v-bind="validateInfos.BANK_CD">
                  <a-input
                    v-model:value="formData.BANK_CD"
                    :disabled="!isNew"
                    :maxlength="4"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">金融機関名（ｶﾅ）</th>
              <td>
                <a-form-item v-bind="validateInfos.BANK_KANA">
                  <a-input v-model:value="formData.BANK_KANA"></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">金融機関名（漢字）</th>
              <td>
                <a-form-item v-bind="validateInfos.BANK_NAME">
                  <a-input v-model:value="formData.BANK_NAME"></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </a-form>
      </div>
    </a-card>
  </div>
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
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import { DeleteBank, InitBankDetail, SaveBank } from '../service/8051/service'
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
const editJudge = new Judgement('GJ8051')
let upddttm

const formData = reactive({
  BANK_CD: '',
  BANK_KANA: '',
  BANK_NAME: '',
})

const rules = reactive({
  BANK_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '金融機関コード'),
    },
    {
      min: 4,
      message: '桁数が正しくない、桁数は4です。',
    },
  ],
  BANK_KANA: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '金融機関（ｶﾅ）'),
    },
  ],
  BANK_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場名称（漢字）'),
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
  if (!isNew) {
    formData.BANK_CD = String(route.query.BANK_CD)
    InitBankDetail({
      BANK_CD: formData.BANK_CD ?? '',
      EDIT_KBN: EnumEditKbn.Edit,
    })
      .then((res) => {
        Object.assign(formData, res.BANK)
        upddttm = res.BANK.UP_DATE
        nextTick(() => {
          editJudge.reset()
          clearValidate()
        })
      })
      .catch((error) => {
        router.push({ name: route.name, query: { refresh: '1' } })
      })
  }
})

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
    router.push({ name: route.name, query: { refresh: '1' } })
  })
}

//登録処理
const saveData = async () => {
  if (!isNew) {
    if (!editJudge.isPageEdited()) {
      showInfoModal({
        content: '変更したデータはありません。',
      })
      return
    }
  }
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await SaveBank({
          BANK: { ...formData, UP_DATE: upddttm },
          EDIT_KBN: isNew ? EnumEditKbn.Add : EnumEditKbn.Edit,
        })
        router.push({ name: route.name, query: { refresh: '1' } })
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
        await DeleteBank({
          BANK_CD: formData.BANK_CD,
          UP_DATE: upddttm,
        })
        router.push({ name: route.name, query: { refresh: 'delete1' } })
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 150px;
}
</style>
