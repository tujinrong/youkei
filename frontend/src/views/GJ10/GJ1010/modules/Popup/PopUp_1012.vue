<template>
  <a-modal
    v-show="detailKbn === FarmManage.Detail"
    :open="visible"
    centered
    title="2.契約農場別登録明細情報(入力)"
    width="1000px"
    :body-style="{
      height: '600px',
      paddingRight: '30px',
      paddingLeft: '30px',
      paddingTop: '50px',
    }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form w-full">
      <a-row>
        <a-col span="5">
          <read-only-pop
            th="明細番号"
            thWidth="90"
            :td="formData.MEISAI_NO"
          ></read-only-pop>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">農場</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_CD">
              <ai-select
                v-model:value="formData.NOJO_CD"
                type="number"
                :options="NOJO_LIST"
                split-val
              ></ai-select>
            </a-form-item>
            <a-button class="ml-2" type="primary" @click="addNoJo"
              >農場登録</a-button
            >
          </td>
        </a-col>
      </a-row>
      <a-row class="mt-2">
        <a-col span="2">
          <read-only-pop thWidth="110" th="住所" td="" :hideTd="true" />
        </a-col>
        <a-col span="4">
          <read-only-pop th="　〒　" :td="formData.ADDR_POST" />
        </a-col>
        <a-col span="1"></a-col>
      </a-row>
      <a-row class="mt-2">
        <a-col span="2">
          <read-only-pop thWidth="120" th="" td="" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop thWidth="50" th="住所1" :td="formData.ADDR_1" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="11">
          <read-only-pop thWidth="50" th="住所2" :td="formData.ADDR_2" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="2">
          <read-only-pop thWidth="110" th="" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop thWidth="50" th="住所3" :td="formData.ADDR_3" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="11">
          <read-only-pop thWidth="50" th="住所4" :td="formData.ADDR_4" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="23">
          <th class="required">鶏の種類</th>
          <td>
            <a-form-item v-bind="validateInfos.TORI_KBN">
              <ai-select
                v-model:value="formData.TORI_KBN"
                :options="TORI_KBN_LIST"
                type="number"
                class="max-w-40"
                split-val
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="30">
          <th class="required">契約羽数</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_HASU">
              <a-input-number
                v-model:value="formData.KEIYAKU_HASU"
                :min="0"
                :max="99999999"
                :maxlength="10"
                v-bind="{ ...mathNumber }"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">契約年月日</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_DATE" class="w-90!">
              <range-date
                v-model:value="formData.KEIYAKU_DATE"
                :disabled2="true"
                class="w-full"
              />
            </a-form-item>
            <span class="flex items-center"
              >(契約日を入力する二とで单価を取得します)</span
            >
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="23">
          <th>備考</th>
          <td>
            <a-input v-model:value="formData.BIKO"></a-input>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20" class="mb-2">
          <a-button class="warning-btn" @click="continueSave">
            保存して継続登録 </a-button
          ><a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
          <a-button type="primary" @click="reset">キャンセル</a-button></a-space
        >
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <Detail2
    v-if="detailKbn === FarmManage.FarmInfo"
    v-model:detailKbn="detailKbn"
    v-bind="{
      KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
      KEIYAKUSYA_NAME,
      editkbn,
    }"
  />
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { reactive, ref, computed, watch, nextTick } from 'vue'
import Detail2 from '../Popup/PopUp_1013.vue'
import { EnumEditKbn } from '@/enum'
import { Form, message } from 'ant-design-vue'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { FarmManage } from '../../constant'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { mathNumber } from '@/utils/util'
import { SearchRowVM } from '../../service/1012/type'
import { Delete, Save } from '../../service/1012/service'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  editkbn: EnumEditKbn
  row?: SearchRowVM
  NOJO_LIST: CmCodeNameModel[]
  TORI_KBN_LIST: CmCodeNameModel[]
  KEIYAKU_KBN: number
  KEIYAKUSYA_NAME: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])

const detailKbn = ref(FarmManage.Detail)
const formData = reactive({
  SEQNO: undefined as number | undefined,
  KI: undefined as number | undefined,
  KEIYAKUSYA_CD: undefined as number | undefined,
  NOJO_CD: undefined as number | undefined,
  NOJO_NAME: '',
  ADDR_POST: '136-0073',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  MEISAI_NO: undefined as number | undefined,
  TORI_KBN: undefined as number | undefined,
  KEIYAKU_HASU: undefined as number | undefined,
  KEIYAKU_DATE: undefined as CmDateFmToModel | undefined,
  BIKO: '',
})

const editJudge = new Judgement()

const rules = reactive({
  MEISAI_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '明細番号'),
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

const isNew = computed(() => props.editkbn === EnumEditKbn.Add)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (!newValue) return
    if (!isNew.value) {
      Object.assign(formData, props.row)
    }
    nextTick(() => editJudge.reset())
  }
)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const closeModal = () => {
  resetFields()
  clearValidate()
  modalVisible.value = false
}
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: DELETE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Delete({ SEQNO: formData.SEQNO, UP_DATE: new Date() })
        message.success(DELETE_OK_INFO.Msg)
        closeModal()
      } catch (error) {}
    },
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
      try {
        await Save({
          ...formData,
          KEIYAKU_KBN: props.KEIYAKU_KBN,
          UP_DATE: new Date(),
          EDIT_KBN: props.editkbn,
        })
        emit('getTableList')
        message.success(SAVE_OK_INFO.Msg)
        if (isNew.value) {
          resetFields()
        }
      } catch (error) {}
      clearValidate()
    },
  })
}
const reset = () => {
  resetFields()
}

const addNoJo = () => {
  detailKbn.value = FarmManage.FarmInfo
}
</script>
<style lang="scss" scoped>
th {
  min-width: 90px;
}
</style>
