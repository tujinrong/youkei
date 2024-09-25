<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約農場別明細 增羽情報(入力)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.09.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-show="detailKbn === FarmManage.Detail"
    :visible="modalVisible"
    centered
    title="契約農場別明細 增羽情報(入力)"
    width="1000px"
    :body-style="{ height: '800px', overflowY: 'scroll' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="parent-container">
      <div class="edit_table form">
        <a-row>
          <a-col span="24">
            <th class="required">農場</th>
            <td>
              <a-form-item v-bind="validateInfos.NOJO_CD">
                <ai-select
                  v-model:value="formData.NOJO_CD"
                  :options="LIST"
                  split-val
                ></ai-select>
              </a-form-item>
              <a-button class="mx-2" type="primary" @click="addNojo"
                >農場登録</a-button
              >
            </td>
          </a-col>
          <a-col span="24" class="mt-2">
            <read-only-pop thWidth="115" th="農場住所" td="" :hideTd="true" />
            <read-only-pop th="　〒　" thWidth="50" :td="nojoData.ADDR_POST" />
            <read-only-pop thWidth="60" th="住所1" :td="nojoData.ADDR_1" />
            <read-only-pop thWidth="60" th="住所2" :td="nojoData.ADDR_2" />
          </a-col>
          <a-col span="7"></a-col>
          <a-col span="17">
            <read-only-pop thWidth="132" th="" :hideTd="true" />
            <read-only-pop thWidth="60" th="住所3" :td="nojoData.ADDR_3" />
            <read-only-pop thWidth="60" th="住所4" :td="nojoData.ADDR_4" />
          </a-col>
          <a-col span="13">
            <th class="required">鳥の種類</th>
            <td>
              <a-form-item v-bind="validateInfos.TORI_KBN">
                <ai-select
                  v-model:value="formData.TORI_KBN"
                  :options="LIST"
                  class="w-full"
                  split-val
                ></ai-select>
              </a-form-item>
            </td> </a-col
        ></a-row>
        <a-row
          ><a-col span="7">
            <th class="required">増羽数</th>
            <td>
              <a-form-item v-bind="validateInfos.ZOGEN_HASU">
                <a-input-number
                  v-model:value="formData.ZOGEN_HASU"
                  :min="0"
                  :max="99999999"
                  :maxlength="10"
                  class="w-28"
                  v-bind="{ ...mathNumber }"
                ></a-input-number>
              </a-form-item>
            </td> </a-col></a-row
        ><a-row>
          <a-col span="7" class="mt-2">
            <read-only-pop
              th="契約羽数(増羽前)"
              th-width="132"
              :td="KEIYAKU_HASU"
            />
          </a-col>
          <a-col span="8" class="mt-2 thleft">
            <read-only-pop
              thWidth="160"
              th="契約羽数(増羽後)"
              :td="
                Number(formData.ZOGEN_HASU) + Number(KEIYAKU_HASU) || undefined
              "
            />
          </a-col>
          <a-col span="13">
            <th class="required">増羽年月日</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
                <DateJp
                  v-model:value="formData.KEIYAKU_DATE_FROM"
                  class="w-50!"
                ></DateJp>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">検索方法</th>
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
        </a-row>
      </div>
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
  <NoJoJoHo
    v-if="detailKbn === FarmManage.FarmInfo"
    v-model:detailKbn="detailKbn"
  />
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
import NoJoJoHo from '../../../GJ10/GJ1010/modules/Popup/PopUp_1013.vue'
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
    NOJO_CD: undefined,
    TORI_KBN: undefined,
    ZOGEN_HASU: undefined,
    KEIYAKU_DATE_FROM: new Date(),
    SYORI_KBN: 1,
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
  width: 130px;
}
.thleft {
  :deep(th) {
    text-align: right;
  }
}
</style>
