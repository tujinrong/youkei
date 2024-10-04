<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ8051）金融機関マスタメンテナンス"
    width="1000px"
    :body-style="{
      minHeight: '600px',
      paddingTop: '50px',
      paddingLeft: '50px',
    }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
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
                  class="max-w-15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">金融機関名（ｶﾅ）</th>
            <td>
              <a-form-item v-bind="validateInfos.BANK_KANA">
                <a-input
                  v-model:value="formData.BANK_KANA"
                  :maxlength="60"
                  class="max-w-150"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">金融機関名（漢字）</th>
            <td>
              <a-form-item v-bind="validateInfos.BANK_NAME">
                <a-input
                  v-model:value="formData.BANK_NAME"
                  class="max-w-75"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData"> 保存 </a-button>
          <a-button
            class="warning-btn"
            :disabled="!isNew"
            @click="continueSave"
          >
            保存して継続登録
          </a-button>

          <a-button class="danger-btn" :disabled="isNew" @click="deleteData">
            削除
          </a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template></a-modal
  >
</template>
<script setup lang="ts">
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { EnumEditKbn } from '@/enum'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, reactive, ref, watch } from 'vue'
import { Judgement } from '@/utils/judge-edited'
import { DeleteBank, InitBankDetail, SaveBank } from '../service/8051/service'
import {
  validateLength,
  convertKanaToHalfWidth,
  convertToHalfNumber,
} from '@/utils/util'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
  bankcd?: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const editJudge = new Judgement('GJ8051')
let upddttm: Date | undefined

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
    if (newValue && !isNew.value) {
      formData.BANK_CD = props.bankcd ?? ''
      await init()
    }
    nextTick(() => {
      editJudge.reset()
      clearValidate()
    })
  }
)
watch(formData, () => editJudge.setEdited())

watch(
  () => formData.BANK_CD,
  (newVal) => {
    if (newVal) {
      formData.BANK_CD = String(convertToHalfNumber(newVal))
    }
  },
  { deep: true }
)

watch(
  () => formData.BANK_KANA,
  (newVal) => {
    if (newVal) {
      formData.BANK_KANA = convertKanaToHalfWidth(newVal)
    }
  },
  { deep: true }
)

watch(
  () => formData.BANK_NAME,
  (newVal) => {
    const maxLength = 30
    formData.BANK_NAME = validateLength(newVal, maxLength)
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const closeModal = () => {
  resetFields()
  clearValidate()
  modalVisible.value = false
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}
//初期化処理
const init = async () => {
  try {
    const res = await InitBankDetail({
      BANK_CD: formData.BANK_CD ?? '',
      EDIT_KBN: EnumEditKbn.Edit,
    })
    Object.assign(formData, res.BANK)
    upddttm = res.BANK.UP_DATE
    nextTick(() => {
      editJudge.reset()
      clearValidate()
    })
  } catch (error) {
    emit('getTableList', false)
  }
}
//登録処理
const saveDB = async () => {
  await SaveBank({
    BANK: { ...formData, UP_DATE: upddttm },
    EDIT_KBN: isNew.value ? EnumEditKbn.Add : EnumEditKbn.Edit,
  })
}

const saveData = async () => {
  if (!isNew.value) {
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
        await saveDB()
        emit('getTableList', false)
        closeModal()
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}

//保存して継続登録(新規モードのみ)
const continueSave = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      await saveDB()
      message.success(SAVE_OK_INFO.Msg)
      resetFields()
      clearValidate()
      nextTick(() => {
        editJudge.reset()
      })
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
        closeModal()
        emit('getTableList', true)
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 200px;
}
</style>
