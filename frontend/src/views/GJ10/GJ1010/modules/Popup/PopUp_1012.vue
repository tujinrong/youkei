<template>
  <a-modal
    v-show="detailKbn === FarmManage.Detail"
    :visible="visible"
    centered
    title="2.契約農場別登録明細情報(入力)"
    width="800px"
    :body-style="{
      height: '450px',
      minWidth: '800px',
      paddingRight: '50px',
      paddingTop: '20px',
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
                :options="NOJO_CD_CD_NAME_LIST"
                split-val
              ></ai-select>
            </a-form-item>
            <a-button class="ml-2" type="primary" @click="addNoJo"
              >農場登録</a-button
            >
          </td>
        </a-col>
      </a-row>
      <a-row class="mt-1">
        <a-col span="3">
          <read-only-pop thWidth="90" th="住所" td="" :hideTd="true" /></a-col
        ><a-col span="5"
          ><read-only-pop th="　〒　" :td="formData.ADDR_POST" /></a-col
        ><a-col span="5"
          ><read-only-pop th="住所1" :td="formData.ADDR_1" /></a-col
        ><a-col span="11"
          ><read-only-pop th="住所2" :td="formData.ADDR_2"
        /></a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only-pop
            thWidth="250"
            th=""
            :hideTd="true"
            :td="formData.ADDR_POST"
          />
          <read-only-pop th="住所3" :td="formData.ADDR_3" />
          <read-only-pop th="住所4" :td="formData.ADDR_4" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="23">
          <th class="required">鶏の種類</th>
          <td>
            <a-form-item v-bind="validateInfos.KEI_SYURUI">
              <ai-select
                v-model:value="formData.KEI_SYURUI"
                :options="KEI_SYURUI_CD_NAME_LIST"
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
            <a-form-item v-bind="validateInfos.KEIYAKU_YMD_FM" class="!w-40">
              <DateJp v-model:value="formData.KEIYAKU_YMD_FM"
            /></a-form-item>
            <span class="mx-2">～</span>
            <a-form-item class="!w-40">
              <DateJp
                v-model:value="formData.KEIYAKU_YMD_TO"
                disabled /></a-form-item
            ><span class="flex items-center ml-2"
              >(契約日を入力する二とで单価を取得します)</span
            >
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="23">
          <th class="required">備考</th>
          <td>
            <a-input v-model:value="formData.BIKO"></a-input>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20" class="mb-2">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button class="warning-btn" @click="continueSave">
            保存して継続登録 </a-button
          ><a-button class="danger-btn" @click="deleteData">削除</a-button>
          <a-button type="primary" @click="reset">キャンセル</a-button></a-space
        >
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <Detail2
    v-if="detailKbn === FarmManage.FarmInfo"
    v-model:detailKbn="detailKbn"
  />
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { reactive, ref, toRef, computed } from 'vue'
import Detail2 from '../Popup/PopUp_1013.vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import { Form, message } from 'ant-design-vue'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { FarmManage } from '../../constant'
import { VxeTableInstance } from 'vxe-table'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { mathNumber } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])

const detailKbn = ref(FarmManage.Detail)
const formData = reactive({
  KI: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_CD: undefined as number | undefined,
  NOJO_NAME: '',
  ADDR_POST: '136-0073',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  MEISAI_NO: undefined as number | undefined,
  KEI_SYURUI: undefined as number | undefined,
  KEIYAKU_HASU: undefined as number | undefined,
  KEIYAKU_YMD_FM: undefined as Date | undefined,
  KEIYAKU_YMD_TO: undefined as Date | undefined,
  BIKO: '',
})

const hasuGokei = reactive({
  SAIRANKEI_SEIKEI: undefined,
  SAIRANKEI_IKUSEIKEI: undefined,
  NIKUYOUKEI: undefined,
  SYUKEI_SEIKEI: undefined,
  SYUKEI_IKUSEIKEI: undefined,
  UZURA: undefined,
  AHIRU: undefined,
  KIJI: undefined,
  HOROHOROTORI: undefined,
  SICHIMENCHOU: undefined,
  DACHOU: undefined,
  TOTAL: undefined,
})

const isEdit = ref(false)

const editJudge = new Judgement()

const NOJO_CD_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 666, NAME: '農場名農場名農場名農場名農場名農場名農場' },
])
const KEI_SYURUI_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 1, NAME: 'ホロホロ鳥' },
])

const tableRef = ref<VxeTableInstance>()
const devicePixelRatio = ref(window.devicePixelRatio)
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
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

window.addEventListener('resize', function () {
  devicePixelRatio.value = window.devicePixelRatio
})
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

const addData = () => {
  isEdit.value = true
}
const changeData = () => {
  const a = tableRef.value?.getCurrentRecord()
  isEdit.value = true
}
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: DELETE_CONFIRM.Msg,
    onOk: async () => {
      message.success(DELETE_OK_INFO.Msg)
      closeModal()
    },
  })
}
const saveData = () => {
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
const reset = () => {
  resetFields()
}
function goForward(status: PageStatus, row?: any) {}

const addNoJo = () => {
  detailKbn.value = FarmManage.FarmInfo
}
</script>
<style lang="scss" scoped>
th {
  min-width: 90px;
}
</style>
