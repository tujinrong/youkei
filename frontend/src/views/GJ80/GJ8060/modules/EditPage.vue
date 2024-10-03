<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ8061）事務委託先マスタメンテナンス"
    width="1200px"
    :body-style="{ minHeight: '600px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
      <b>第{{ formData.KI }}期</b>
      <h2>事務委託先基本登録項目</h2>
      <div class="ml-10">
        <a-form>
          <a-row>
            <a-col span="24">
              <th class="required">事務委託先</th>
              <td>
                <a-form-item v-bind="validateInfos.ITAKU_CD">
                  <a-input-number
                    v-model:value="formData.ITAKU_CD"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    :disabled="!isNew"
                    class="w-15"
                  ></a-input-number>
                </a-form-item>
              </td> </a-col></a-row
          ><a-row>
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
              </td> </a-col
          ></a-row>
          <a-row
            ><a-col span="24">
              <th class="required">事務委託先名称 正式</th>
              <td>
                <a-form-item v-bind="validateInfos.ITAKU_NAME">
                  <a-input
                    v-model:value="formData.ITAKU_NAME"
                    :maxlength="25"
                    class="w-140"
                  ></a-input>
                </a-form-item>
              </td> </a-col></a-row
          ><a-row>
            <a-col span="24">
              <th class="required" style="text-align: end">略称</th>
              <td>
                <a-form-item v-bind="validateInfos.ITAKU_RYAKU">
                  <a-input
                    v-model:value="formData.ITAKU_RYAKU"
                    :maxlength="15"
                    class="max-w-110"
                  ></a-input>
                </a-form-item>
              </td> </a-col></a-row
          ><a-row>
            <a-col span="24">
              <th>代表者氏名</th>
              <td>
                <a-form-item v-bind="validateInfos.DAIHYO_NAME">
                  <a-input
                    v-model:value="formData.DAIHYO_NAME"
                    :maxlength="25"
                    class="max-w-140"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>担当者氏名</th>
              <td>
                <a-form-item v-bind="validateInfos.TANTO_NAME">
                  <a-input
                    v-model:value="formData.TANTO_NAME"
                    :maxlength="25"
                    class="max-w-140"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>

          <a-row>
            <a-col span="24">
              <th class="required">住所</th>
              <td class="flex-col">
                <a-row>
                  <a-col>
                    <a-form-item v-bind="validateInfos.ADDR_POST">
                      <PostCode v-model:value="formData.ADDR_POST">
                        <a-input
                          v-model:value="formData.ADDR_1"
                          disabled
                          class="!w-30"
                        ></a-input>
                      </PostCode> </a-form-item></a-col
                  ><a-col>
                    <a-form-item v-bind="validateInfos.ADDR_2">
                      <a-input
                        v-model:value="formData.ADDR_2"
                        :maxlength="15"
                        class="w-90"
                      ></a-input></a-form-item></a-col
                ></a-row>
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
                    class="w-105"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
          <a-row>
            <a-col>
              <th class="required">連絡先</th>
            </a-col>
            <a-col :span="5">
              <th class="required" style="width: 50px">電話</th>
              <td>
                <a-form-item v-bind="validateInfos.ADDR_TEL">
                  <a-input
                    v-model:value="formData.ADDR_TEL"
                    :maxlength="14"
                    class="max-w-35"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col :span="8">
              <th style="width: 70px; text-align: end">ＦＡＸ</th>
              <td>
                <a-input
                  v-model:value="formData.ADDR_FAX"
                  :maxlength="14"
                  class="max-w-35"
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
                    class="max-w-160"
                  ></a-input>
                </a-form-item>
              </td> </a-col
          ></a-row>
          <a-row>
            <a-col span="24">
              <th class="required" style="width: 170px">
                金融機関入力情報有無
              </th>
              <td>
                <a-radio-group
                  v-model:value="formData.BANK_INJI_KBN"
                  class="ml-2 pt-1"
                >
                  <a-radio :value="1">有</a-radio>
                  <a-radio :value="2">無</a-radio>
                </a-radio-group>
              </td>
            </a-col>
            <a-col span="24">
              <th>まとめ先</th>
              <td>
                <a-form-item v-bind="validateInfos.MATOMESAKI">
                  <a-input-number
                    v-model:value="formData.MATOMESAKI"
                    :min="0"
                    :max="9"
                    :maxlength="1"
                    class="w-10"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="23">
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
            <a-col span="24">
              <th>請求書・契約書</th>
              <td>
                <a-form-item v-bind="validateInfos.SEIKYUSYO">
                  <a-input
                    v-model:value="formData.SEIKYUSYO"
                    :maxlength="15"
                    class="max-w-48"
                  ></a-input>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="23">
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
            <a-col span="24">
              <th>ラベル発行</th>
              <td>
                <a-form-item v-bind="validateInfos.LABELHAKKO">
                  <a-input-number
                    v-model:value="formData.LABELHAKKO"
                    :min="0"
                    :max="9"
                    :maxlength="1"
                    class="w-10"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>除外フラグ</th>
              <td>
                <a-form-item v-bind="validateInfos.JYOGAI_FLG">
                  <a-input-number
                    v-model:value="formData.JYOGAI_FLG"
                    :min="0"
                    :max="99"
                    :maxlength="2"
                    class="w-15"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col :span="23"
              ><th>備考</th>
              <td>
                <a-textarea
                  v-model:value="formData.BIKO"
                  :maxlength="127"
                  :auto-size="{ minRows: 3, maxRows: 5 }"
                /></td
            ></a-col>
          </a-row>
        </a-form>
      </div>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
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
import { EnumEditKbn, PageStatus } from '@/enum'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
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
  editkbn: EnumEditKbn
  visible: boolean
  ITAKU_CD: string
}>()
const emit = defineEmits(['update:visible', 'getTableList'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement('GJ8060')

const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
let upddttm
const formData = reactive({
  KI: 8,
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
  BANK_INJI_KBN: 1,
  MATOMESAKI: undefined as number | undefined,
  MOSIKOMISYORUI: '',
  SEIKYUSYO: '',
  NYUKINHOHO: '',
  LABELHAKKO: undefined as number | undefined,
  JYOGAI_FLG: undefined as number | undefined,
  BIKO: '',
} as DetailVM)

const rules = reactive({
  ITAKU_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事務委託先'),
    },
  ],
  KEN_CD: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '都道府県'),
    },
  ],
  ITAKU_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事務委託先名称（正式）'),
    },
  ],
  ITAKU_RYAKU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事務委託先名称（略称）'),
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
  ADDR_TEL: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '電話番号'),
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
const isNew = computed(() => props.editkbn === EnumEditKbn.Add)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (newValue) => {
    if (newValue) {
      const res = await InitDetail({
        KI: formData.KI,
        ITAKU_CD: +props.ITAKU_CD,
        EDIT_KBN: props.editkbn,
      })
      if (!isNew.value) {
        Object.assign(formData, res.ITAKU)
      }
      KEN_CD_NAME_LIST.value = res.KEN_CD_NAME_LIST
    }
    nextTick(() => {
      editJudge.reset()
      clearValidate()
    })
  }
)
watch(formData, () => editJudge.setEdited())

//都道府県を選択した場合、住所（住所１）の値をセットする
watch(
  () => formData.KEN_CD,
  (newVal) => {
    if (KEN_CD_NAME_LIST.value && KEN_CD_NAME_LIST.value.length > 0)
      formData.ADDR_1 =
        KEN_CD_NAME_LIST.value.find((item) => item.CODE === newVal)?.NAME || ''
  }
)

// watch(
//   () => [formData.NOJO_NAME, formData.ADDR_2, formData.ADDR_3, formData.ADDR_4],
//   ([newNOJO_NAME, newADDR_2, newADDR_3, newADDR_4]) => {
//     formData.NOJO_NAME = convertToFullWidth(newNOJO_NAME)
//     formData.ADDR_2 = convertToFullWidth(newADDR_2)
//     formData.ADDR_3 = convertToFullWidth(newADDR_3)
//     formData.ADDR_4 = convertToFullWidth(newADDR_4)
//   }
// )

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

//登録処理
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
        await Save({
          ITAKU: {
            ...formData,
            UP_DATE: isNew.value ? undefined : upddttm,
          },
        })
        closeModal()
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
          ITAKU_CD: formData.ITAKU_CD,
          UP_DATE: upddttm,
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
  width: 155px;
}
</style>
