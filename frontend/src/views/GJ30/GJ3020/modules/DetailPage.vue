<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="契約区分情報(入力)"
    width="800px"
    :body-style="{ height: '450px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
      <a-row>
        <a-col span="24">
          <th class="required">変更年月日</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
              <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="9" class="mt-2 ml-5">
          <read-only-pop
            thWidth="130"
            th="契約区分(変更前)"
            :td="formData.KEIYAKU_KBN_MAE"
          />
        </a-col> </a-row
      ><a-row>
        <a-col span="9" class="ml-5">
          <read-only-pop
            thWidth="130"
            th="契約区分(変更後)"
            :td="formData.KEIYAKU_KBN_ATO"
          /> </a-col></a-row
      ><a-row>
        <a-col span="11">
          <th class="required">入力確認有無</th>
          <td>
            <a-radio-group
              v-model:value="formData.SYORI_KBN"
              class="ml-2 h-full pt-1"
            >
              <a-radio :value="1">入力中</a-radio>
              <a-radio :value="2">入力確定</a-radio>
            </a-radio-group>
          </td>
        </a-col>
        <a-col span="5" class="ml-5">
          <read-only-pop :td="formData.KEIYAKU_KBN_ATO" />
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20" class="mb-2">
          <a-button class="warning-btn" @click="saveData">保存</a-button
          ><a-button class="danger-btn" :disabled="isNew">削除</a-button>
          <a-button type="primary">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { Form, message } from 'ant-design-vue'
import { reactive, nextTick, onMounted, ref, watch, computed } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { mathNumber } from '@/utils/util'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { FarmManage } from '@/views/GJ10/GJ1010/constant'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])

const editJudge = new Judgement()
const createDefaultform = () => {
  return {
    KEIYAKU_DATE_FROM: new Date(),
    KEIYAKU_KBN_MAE: '',
    KEIYAKU_KBN_ATO: '',
    SYORI_KBN: 1,
    UP_DATE: undefined,
  }
}

const formData = reactive(createDefaultform())
const detailKbn = ref(FarmManage.Detail)
const hasnyuryoku = ref(true)
const LIST = ref<CmCodeNameModel[]>([])
const createDefaultnojo = () => {
  return {
    NOJO_CD: undefined,
    ADDR_POST: '',
    ADDR_1: '',
    ADDR_2: '',
    ADDR_3: '',
    ADDR_4: '',
  }
}

const nojoData = reactive(createDefaultnojo())
const KEIYAKU_HASU = ref(undefined) //契約羽数(増羽前)
const rules = reactive({
  KEIYAKUSYA_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者番号'),
    },
  ],
  KEN_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '都道府県'),
    },
  ],
  KEIYAKU_JYOKYO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約状況'),
    },
  ],
  KEIYAKU_KBN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約区分'),
    },
  ],
  KEIYAKUSYA_KANA: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '申込者名(フリガナ)'),
    },
  ],
  KEIYAKUSYA_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '申込者名(個人・団体)'),
    },
  ],
  ADDR_TEL1: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '電話番号'),
    },
  ],
  JIMUITAKU_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事務委託先'),
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
  (newValue) => {
    if (newValue) {
      // InitDetail()
      // SearchDetail()
      nextTick(() => editJudge.reset())
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
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}

const closeModal = () => {
  Object.assign(formData, createDefaultform())
  hasnyuryoku.value = false
  clearValidate()
  emit('update:visible', false)
}

const saveData = async () => {
  await validate()
  if (!editJudge.isPageEdited()) {
    showInfoModal({
      content: '変更したデータはありません。',
    })
  } else {
    showSaveModal({
      content: SAVE_CONFIRM.Msg,
      onOk: async () => {
        try {
          closeModal()
          message.success(SAVE_OK_INFO.Msg)
        } catch (error) {}
      },
    })
  }
}
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: DELETE_CONFIRM.Msg,
    onOk: async () => {
      try {
        // await Delete({
        //   KI: formData.KI,
        //   KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
        //   NOJO_CD: formData.NOJO_CD,
        //   UP_DATE: upddttm,
        //   EDIT_KBN: EnumEditKbn.Edit,
        // })
        closeModal()
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
//農場登録
const addNojo = () => {
  detailKbn.value = FarmManage.FarmInfo
}
</script>
<style lang="scss" scoped>
th {
  width: 150px;
}
.thleft {
  :deep(th) {
    text-align: right;
  }
}
</style>
