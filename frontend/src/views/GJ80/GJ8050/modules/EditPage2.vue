<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ8052）支店マスタメンテナンス"
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
                  class="max-w-15"
                  disabled
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">支店コード</th>
            <td>
              <a-form-item v-bind="validateInfos.SITEN_CD">
                <a-input
                  v-model:value="formData.SITEN_CD"
                  :maxlength="3"
                  :disabled="!isNew"
                  class="max-w-15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">支店名（ｶﾅ）</th>
            <td>
              <a-form-item v-bind="validateInfos.SITEN_KANA">
                <a-input
                  v-model:value="formData.SITEN_KANA"
                  :maxlength="60"
                  class="max-w-150"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">支店名（漢字）</th>
            <td>
              <a-form-item v-bind="validateInfos.SITEN_NAME">
                <a-input
                  v-model:value="formData.SITEN_NAME"
                  v-fullwidth-limit
                  :maxlength="30"
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
          <a-button class="warning-btn" @click="continueSave">
            保存して継続登録
          </a-button>

          <a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
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
import { EnumEditKbn, PageStatus } from '@/enum'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Judgement } from '@/utils/judge-edited'
import {
  DeleteSiten,
  InitSitenDetail,
  SaveSiten,
} from '../service/8052/service'
import {
  convertKanaToHalfWidth,
  convertToHalfWidthProhibitLetter,
} from '@/utils/util'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
  bankcd: string
  sitencd: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const editJudge = new Judgement('GJ8052')
let upddttm

const formData = reactive({
  BANK_CD: '',
  SITEN_CD: '',
  SITEN_KANA: '',
  SITEN_NAME: '',
})

const rules = reactive({
  BANK_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '金融機関コード'),
    },
  ],
  SITEN_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '支店コード'),
    },
    {
      min: 3,
      message: '桁数が正しくない、桁数は4です。',
    },
  ],
  SITEN_KANA: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '支店名（ｶﾅ）'),
    },
  ],
  SITEN_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '支店名（漢字）'),
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
    if (newValue) {
      formData.BANK_CD = props.bankcd
      if (!isNew.value) {
        formData.SITEN_CD = props.sitencd ?? ''
        await init()
      }
      nextTick(() => {
        editJudge.reset()
        clearValidate()
      })
    }
  }
)
watch(formData, () => editJudge.setEdited())

/**支店コード */
watch(
  () => formData.SITEN_CD,
  (newVal) => {
    if (newVal) {
      formData.SITEN_CD = convertToHalfWidthProhibitLetter(newVal)
    }
  },
  { deep: true }
)

/**支店名（ｶﾅ） */
watch(
  () => formData.SITEN_KANA,
  (newVal) => {
    if (newVal) {
      formData.SITEN_KANA = convertKanaToHalfWidth(newVal)
    }
  },
  { deep: true }
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
    const res = await InitSitenDetail({
      BANK_CD: formData.BANK_CD ?? '',
      SITEN_CD: formData.SITEN_CD ?? '',
      EDIT_KBN: EnumEditKbn.Edit,
    })
    Object.assign(formData, res.SITEN)
    upddttm = res.SITEN.UP_DATE
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
  await SaveSiten({
    SITEN: { ...formData, UP_DATE: upddttm },
    EDIT_KBN: isNew.value ? EnumEditKbn.Add : EnumEditKbn.Edit,
  })
}

//保存して継続登録
const continueSave = async () => {
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
      await saveDB()
      emit('getTableList', true)
      message.success(SAVE_OK_INFO.Msg)
      if (isNew.value) {
        Object.assign(formData, {
          SITEN_CD: '',
          SITEN_KANA: '',
          SITEN_NAME: '',
        })
      }
      nextTick(() => {
        clearValidate()
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
        await DeleteSiten({
          BANK_CD: formData.BANK_CD,
          SITEN_CD: formData.SITEN_CD,
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
  width: 150px;
}
</style>
