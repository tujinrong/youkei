<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.07.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="（GJ8091）契約者農場マスタメンテナンス"
    width="800px"
    :body-style="{ minHeight: '450px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
      <b>第{{ formData.KI }}期</b>
      <a-form>
        <a-row>
          <a-col span="12">
            <read-only-pop
              th="契約者"
              th-width="130"
              :td="formData.KEIYAKUSYA_NAME"
            ></read-only-pop>
          </a-col> </a-row
      ></a-form>
      <h2 class="mt-4">契約者農場基本登録項目</h2>
      <div class="ml-10">
        <a-form>
          <a-row>
            <a-col span="24">
              <th class="required">契約者農場</th>
              <td>
                <a-form-item v-bind="validateInfos.NOJO_CD">
                  <a-input-number
                    v-model:value="formData.NOJO_CD"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    :disabled="!isNew"
                    class="w-20"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">農場名称</th>
              <td>
                <a-form-item v-bind="validateInfos.NOJO_NAME">
                  <a-input
                    v-model:value="formData.NOJO_NAME"
                    :maxlength="20"
                    class="w-105"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">都道府県</th>
              <td>
                <a-form-item v-bind="validateInfos.KEN_CD">
                  <ai-select
                    v-model:value="formData.KEN_CD"
                    :options="KEN_CD_NAME_LIST"
                    class="max-w-50"
                    type="number"
                  ></ai-select>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">住所</th>
              <td class="flex-col">
                <a-form-item v-bind="validateInfos.ADDR_POST">
                  <PostCode v-model:value="formData.ADDR_POST">
                    <a-input
                      v-model:value="formData.ADDR_1"
                      disabled
                      class="!w-30"
                    ></a-input
                  ></PostCode>
                </a-form-item>
                <a-form-item v-bind="validateInfos.ADDR_2">
                  <a-input
                    v-model:value="formData.ADDR_2"
                    :maxlength="15"
                    class="max-w-90"
                  ></a-input>
                </a-form-item>
                <a-input
                  v-model:value="formData.ADDR_3"
                  :maxlength="15"
                  class="max-w-90"
                  @change="validate('ADDR_4')"
                ></a-input>
                <a-form-item v-bind="validateInfos.ADDR_4">
                  <a-input
                    v-model:value="formData.ADDR_4"
                    :maxlength="20"
                    class="max-w-105"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <th class="required">明細番号</th>
              <td>
                <a-form-item v-bind="validateInfos.MEISAI_NO">
                  <a-input-number
                    v-model:value="formData.MEISAI_NO"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    class="w-20"
                  ></a-input-number>
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
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button class="warning-btn" @click="continueSave">
            保存して継続登録
          </a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { Form, message } from 'ant-design-vue'
import PostCode from '@/components/Selector/PostCode/index.vue'
import { convertToFullWidth } from '@/utils/util'
import { DetailVM, SearchRequest } from '../type'
import { Judgement } from '@/utils/judge-edited'
import { InitDetail, Save, Delete } from '../service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
  keys: any
  params: SearchRequest
  name: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const editJudge = new Judgement('GJ8090')

const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
let upddttm
const formData = reactive({
  KI: undefined as number | undefined,
  KEIYAKUSYA_CD: undefined as number | undefined,
  NOJO_CD: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_NAME: '',
  KEN_CD: undefined as number | undefined,
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  MEISAI_NO: undefined as number | undefined,
} as DetailVM)

const rules = reactive({
  NOJO_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場番号'),
    },
  ],
  NOJO_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場名称'),
    },
  ],
  KEN_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '都道府県'),
    },
  ],
  ADDR_POST: [
    {
      validator: async (_rule, value: string) => {
        if (!value) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号')
          )
        } else if (value.replace(/[^0-9]/g, '').length < 7) {
          return Promise.reject(
            // ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '郵便番号')
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号')
          )
        }
        return Promise.resolve()
      },
    },
  ],
  ADDR_2: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所２'),
    },
  ],
  MEISAI_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '明細番号'),
    },
  ],
  ADDR_4: [
    {
      validator: async (_rule, value: string) => {
        if (value && !formData.ADDR_3) {
          return Promise.reject('前の住所入力欄が未入力です。')
        }
        return Promise.resolve()
      },
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
  async (newV) => {
    if (newV) {
      if (isNew.value) {
        formData.KI = props.params.KI
        formData.KEIYAKUSYA_CD = props.params.KEIYAKUSYA_CD
        formData.KEIYAKUSYA_NAME =
          props.params.KEIYAKUSYA_CD + '：' + props.name
      } else {
        // Object.assign(formData,props.keys)
        formData.KI = props.keys.KI
        formData.KEIYAKUSYA_CD = props.keys.KEIYAKUSYA_CD
        formData.KEIYAKUSYA_NAME =
          props.keys.KEIYAKUSYA_CD + '：' + props.keys.KEIYAKUSYA_NAME
        formData.NOJO_CD = props.keys.NOJO_CD
      }
      await init(!isNew.value)
      nextTick(() => {
        editJudge.reset()
        clearValidate()
      })
    }
  }
)
watch(formData, () => editJudge.setEdited())

//都道府県を選択した場合、住所（住所１）の値をセットする
watch(
  () => formData.KEN_CD,
  (newVal) => {
    if (KEN_CD_NAME_LIST.value.length > 0)
      formData.ADDR_1 =
        KEN_CD_NAME_LIST.value.find((item) => item.CODE === newVal)?.NAME || ''
  }
)

watch(
  () => [formData.NOJO_NAME, formData.ADDR_2, formData.ADDR_3, formData.ADDR_4],
  ([newNOJO_NAME, newADDR_2, newADDR_3, newADDR_4]) => {
    formData.NOJO_NAME = convertToFullWidth(newNOJO_NAME)
    formData.ADDR_2 = convertToFullWidth(newADDR_2)
    formData.ADDR_3 = convertToFullWidth(newADDR_3)
    formData.ADDR_4 = convertToFullWidth(newADDR_4)
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const closeModal = () => {
  resetFields()
  clearValidate()
  emit('getTableList')
  modalVisible.value = false
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

//初期化処理
const init = async (isEditOrContinue: boolean) => {
  try {
    const res = await InitDetail({
      KI: formData.KI,
      KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
      NOJO_CD: formData.NOJO_CD ?? 0,
      EDIT_KBN: !isEditOrContinue ? EnumEditKbn.Add : EnumEditKbn.Edit,
    })
    KEN_CD_NAME_LIST.value = res.KEN_CD_NAME_LIST
    if (isEditOrContinue) {
      Object.assign(formData, res.KEIYAKUSYA_NOJO)
      formData.ADDR_1 = res.KEIYAKUSYA_NOJO.ADDR_1
      upddttm = res.KEIYAKUSYA_NOJO.UP_DATE
    }
    nextTick(() => {
      editJudge.reset()
      clearValidate()
    })
  } catch (error) {
    closeModal()
    emit('getTableList')
  }
}
//登録処理
const saveDB = async () => {
  await Save({
    KEIYAKUSYA_NOJO: {
      ...formData,
      UP_DATE: isNew.value ? undefined : upddttm,
    },
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
      await saveDB()
      closeModal()
      message.success(SAVE_OK_INFO.Msg)
    },
  })
}

//保存して継続登録
const continueSave = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      await saveDB()
      message.success(SAVE_OK_INFO.Msg)
      await init(true)
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
          KI: formData.KI,
          KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
          NOJO_CD: formData.NOJO_CD,
          UP_DATE: upddttm,
          EDIT_KBN: EnumEditKbn.Edit,
        })
        closeModal()
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
</script>

<style scoped lang="scss">
th {
  width: 130px;
}

:deep(.ant-form-item) {
  width: 100%;
  margin-bottom: 0;
}
</style>
