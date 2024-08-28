<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <div class="self_adaption_table form max-w-160">
      <b>第{{ formData.KI }}期</b>
      <a-form>
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
            <!-- <a-button v-if="!isNew" :icon="h(LeftOutlined)"></a-button
          ><span v-if="!isNew">2/5</span>
          <a-button v-if="!isNew" :icon="h(RightOutlined)"></a-button> -->
          </a-space>
          <a-button type="primary" class="text-end" @click="goList"
            >一覧へ</a-button
          >
        </div>
        <b>事務委託先基本登録項目</b>
        <a-row>
          <a-col span="24">
            <th :class="!isNew ? 'bg-readonly' : 'required'">事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.ITAKU_CD">
                <a-input-number
                  v-model:value="formData.ITAKU_CD"
                  :min="0"
                  :max="999"
                  :maxlength="3"
                  :disabled="!isNew"
                ></a-input-number>
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
                  class="w-full"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">事務委託先名称 正式</th>
            <td>
              <a-form-item v-bind="validateInfos.ITAKU_NAME">
                <a-input
                  v-model:value="formData.ITAKU_NAME"
                  :maxlength="50"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">事務委託先名称 略称</th>
            <td>
              <a-form-item v-bind="validateInfos.ITAKU_RYAKU">
                <a-input
                  v-model:value="formData.ITAKU_RYAKU"
                  :maxlength="30"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>代表者氏名</th>
            <td>
              <a-form-item v-bind="validateInfos.DAIHYO_NAME">
                <a-input
                  v-model:value="formData.DAIHYO_NAME"
                  :maxlength="50"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>担当者氏名</th>
            <td>
              <a-form-item v-bind="validateInfos.TANTO_NAME">
                <a-input
                  v-model:value="formData.TANTO_NAME"
                  :maxlength="50"
                ></a-input>
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
                    class="!w-40"
                  ></a-input
                ></PostCode>
              </a-form-item>
              <a-form-item v-bind="validateInfos.ADDR_2">
                <a-input
                  v-model:value="formData.ADDR_2"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
              <a-input
                v-model:value="formData.ADDR_3"
                :maxlength="15"
                @change="validate('ADDR_4')"
              ></a-input>
              <a-form-item v-bind="validateInfos.ADDR_4">
                <a-input
                  v-model:value="formData.ADDR_4"
                  :maxlength="20"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col>
            <th class="required">連絡先</th>
          </a-col>
          <a-col :span="7">
            <th class="required">電話</th>
            <td>
              <a-form-item v-bind="validateInfos.ADDR_TEL">
                <a-input
                  v-model:value="formData.ADDR_TEL"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col class="flex-1">
            <th>FAX</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_FAX"
                :maxlength="15"
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>メールアドレス</th>
            <td>
              <a-form-item v-bind="validateInfos.ADDR_E_MAIL">
                <a-input
                  v-model:value="formData.ADDR_E_MAIL"
                  :maxlength="50"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">金融機関入力情報有無</th>
            <td>
              <a-radio-group
                v-model:value="formData.BANK_INJI_KBN"
                class="ml-2 pt-1"
              >
                <a-radio value="1">有</a-radio>
                <a-radio value="2">無</a-radio>
              </a-radio-group>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>まとめ先</th>
            <td>
              <a-form-item v-bind="validateInfos.MATOMESAKI">
                <a-input-number
                  v-model:value="formData.MATOMESAKI"
                  :min="0"
                  :max="9"
                  :maxlength="1"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>申込書類</th>
            <td>
              <a-form-item v-bind="validateInfos.MOSIKOMISYORUI">
                <a-input
                  v-model:value="formData.MOSIKOMISYORUI"
                  :maxlength="70"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>請求書・契約書</th>
            <td>
              <a-form-item v-bind="validateInfos.SEIKYUSYO">
                <a-input
                  v-model:value="formData.SEIKYUSYO"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>入金方法</th>
            <td>
              <a-form-item v-bind="validateInfos.NYUKINHOHO">
                <a-input
                  v-model:value="formData.NYUKINHOHO"
                  :maxlength="70"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>ラベル発行</th>
            <td>
              <a-form-item v-bind="validateInfos.LABELHAKKO">
                <a-input-number
                  v-model:value="formData.LABELHAKKO"
                  :min="0"
                  :max="9"
                  :maxlength="1"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th>除外フラグ</th>
            <td>
              <a-form-item v-bind="validateInfos.JYOGAI_FLG">
                <a-input-number
                  v-model:value="formData.JYOGAI_FLG"
                  :min="0"
                  :max="99"
                  :maxlength="2"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="24"
            ><th>備考</th>
            <td>
              <a-textarea v-model:value="formData.BIKO" /></td
          ></a-col>
        </a-row>
      </a-form>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
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
import { DetailVM } from '../type'
import { Judgement } from '@/utils/judge-edited'
import { InitDetail, Save, Delete } from '../service'
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
const editJudge = new Judgement('GJ8060')

const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
let upddttm
const formData = reactive({
  KI: undefined as number | undefined,
  ITAKU_CD: undefined as number | undefined,
  KEN_CD: undefined as number | undefined,
  ITAKU_NAME: '',
  ITAKU_RYAKU: '',
  DAIHYO_NAME: '',
  TANTO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  ADDR_TEL: '',
  ADDR_FAX: '',
  ADDR_E_MAIL: '',
  BANK_INJI_KBN: undefined as number | undefined,
  MATOMESAKI: undefined as number | undefined,
  MOSIKOMISYORUI: '',
  SEIKYUSYO: '',
  NYUKINHOHO: '',
  LABELHAKKO: undefined as number | undefined,
  JYOGAI_FLG: undefined as number | undefined,
  BIKO: '',
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
onMounted(async () => {
  formData.KI = Number(route.query.KI)
  if (!isNew) {
    formData.ITAKU_CD = Number(route.query.ITAKU_CD)
  }

  // InitDetail({
  //   KI: formData.KI,
  //   KEIYAKUSYA_CD: formData.ITAKU_CD,
  //   NOJO_CD: formData.NOJO_CD,
  //   EDIT_KBN: isNew ? EnumEditKbn.Add : EnumEditKbn.Edit,
  // })
  //   .then((res) => {
  //     KEN_CD_NAME_LIST.value = res.KEN_CD_NAME_LIST
  //     if (!isNew) {
  //       Object.assign(formData, res.KEIYAKUSYA_NOJO)
  //       formData.ADDR_1 = res.KEIYAKUSYA_NOJO.ADDR_1
  //       upddttm = res.KEIYAKUSYA_NOJO.UP_DATE
  //     }
  //     nextTick(() => editJudge.reset())
  //   })
  //   .catch((error) => {
  //     router.push({ name: route.name, query: { refresh: '1' } })
  //   })
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

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
        await Save({
          KEIYAKUSYA_NOJO: {
            ...formData,
            UP_DATE: isNew ? undefined : upddttm,
          },
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
        await Delete({
          KI: formData.KI,
          KEIYAKUSYA_CD: formData.ITAKU_CD,
          NOJO_CD: formData.NOJO_CD,
          UP_DATE: upddttm,
          EDIT_KBN: EnumEditKbn.Edit,
        })
        router.push({ name: route.name, query: { refresh: '1' } })
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
