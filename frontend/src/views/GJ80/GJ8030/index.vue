<template>
  <div>
    <a-card
      :bordered="false"
      class="mb-4 h-full"
      style="background-color: aliceblue"
    >
      <h1>（GJ8030）日本養鶏協会マスタメンテナンス</h1>
      <div class="edit_table form">
        <a-row>
          <a-col span="13" :order="1">
            <th class="required">協会名称</th>
            <td>
              <a-form-item v-bind="validateInfos.KYOKAI_NAME">
                <a-input
                  v-model:value="formData.KYOKAI_NAME"
                  v-fullwidth-limit
                  :maxlength="30"
              /></a-form-item>
            </td>
          </a-col>
          <a-col span="13" :order="3">
            <th class="required">役職名</th>
            <td>
              <a-form-item v-bind="validateInfos.YAKUMEI">
                <a-input
                  v-model:value="formData.YAKUMEI"
                  v-fullwidth-limit
                  :maxlength="30"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="13" :order="4">
            <th class="required">会長名</th>
            <td>
              <a-form-item v-bind="validateInfos.KAICHO_NAME">
                <a-input
                  v-model:value="formData.KAICHO_NAME"
                  v-fullwidth-limit
                  :maxlength="30"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="11" :order="2">
            <th class="required text-end!">支援事業名</th>
            <td>
              <a-form-item v-bind="validateInfos.JIGYO_NAME">
                <a-input
                  v-model:value="formData.JIGYO_NAME"
                  v-fullwidth-limit
                  :maxlength="30"
                />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="11" :order="5">
            <th class="text-end!">予備</th>
            <td>
              <a-form-item v-bind="validateInfos.YOBI1">
                <a-input
                  v-model:value="formData.YOBI1"
                  v-fullwidth-limit
                  :maxlength="30"
                />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">住所</th>
            <a-row class="flex-1">
              <a-col span="24">
                <td>
                  <a-form-item v-bind="validateInfos.POST">
                    <PostCode v-model:value="formData.POST"></PostCode>
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="24">
                <td>
                  <a-form-item v-bind="validateInfos.ADDR1">
                    <a-input
                      v-model:value="formData.ADDR1"
                      class="max-w-228"
                      v-fullwidth-limit
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="16">
                <td>
                  <a-form-item v-bind="validateInfos.ADDR2">
                    <a-input
                      v-model:value="formData.ADDR2"
                      class="max-w-228"
                      v-fullwidth-limit
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="8">
                <th class="required">発行番号・漢字</th>
                <td>
                  <a-form-item v-bind="validateInfos.HAKKO_NO_KANJI">
                    <a-input
                      v-model:value="formData.HAKKO_NO_KANJI"
                      :maxlength="2"
                      class="max-w-40"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="24">
            <th class="required">連絡先１</th>
            <a-row class="flex-1">
              <a-col span="5">
                <th class="required w-18!">電話１</th>
                <td>
                  <a-form-item v-bind="validateInfos.TEL1">
                    <a-input v-model:value="formData.TEL1" :maxlength="14" />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="1"></a-col>
              <a-col span="6">
                <th class="required w-21!">ＦＡＸ１</th>
                <td>
                  <a-form-item v-bind="validateInfos.FAX1">
                    <a-input v-model:value="formData.FAX1" :maxlength="14" />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="12">
                <th class="text-end!">E-mail１</th>
                <td>
                  <a-form-item v-bind="validateInfos.E_MAIL1">
                    <a-input
                      v-model:value="formData.E_MAIL1"
                      :maxlength="100"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="24">
            <th>連絡先２</th>
            <a-row class="flex-1">
              <a-col span="5">
                <th class="w-18!">電話２</th>
                <td>
                  <a-form-item v-bind="validateInfos.TEL2">
                    <a-input v-model:value="formData.TEL2" :maxlength="14" />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="1"></a-col>
              <a-col span="6">
                <th class="w-21!">ＦＡＸ２</th>
                <td>
                  <a-form-item v-bind="validateInfos.FAX2">
                    <a-input v-model:value="formData.FAX2" :maxlength="14" />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="12">
                <th class="text-end!">E-mail２</th>
                <td>
                  <a-form-item v-bind="validateInfos.E_MAIL2">
                    <a-input
                      v-model:value="formData.E_MAIL2"
                      :maxlength="100"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="16">
            <th class="required">ホームページURL</th>
            <td>
              <a-form-item v-bind="validateInfos.HP_URL">
                <a-input v-model:value="formData.HP_URL" :maxlength="50"
              /></a-form-item>
            </td>
          </a-col>
          <a-col span="8">
            <th class="required text-end!">登録番号</th>
            <td>
              <a-form-item v-bind="validateInfos.TOUROKU_NO">
                <a-input v-model:value="formData.TOUROKU_NO" :maxlength="14" />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row class="mt-4">
          <a-col span="24">
            <th style="font-weight: 700">
              振込口座情報<span style="color: #ff0000; font-weight: 400"
                >＊</span
              >
            </th>
            <a-row class="flex-1">
              <a-col span="12">
                <th class="required">金融機関</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_BANK_CD">
                    <ai-select
                      v-model:value="formData.FURI_BANK_CD"
                      :options="option1.BANK_LIST"
                      split-val
                      @change="onChangeFuriBank"
                    ></ai-select>
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="12">
                <th class="required text-end!">本支店</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_BANK_SITEN_CD">
                    <ai-select
                      v-model:value="formData.FURI_BANK_SITEN_CD"
                      :options="option1.SITEN_LIST"
                      split-val
                    ></ai-select>
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="8">
                <th class="required">口座種別</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_SYUBETU">
                    <ai-select
                      v-model:value="formData.FURI_KOZA_SYUBETU"
                      :options="option1.KOZA_SYUBETU_LIST"
                      type="number"
                    ></ai-select>
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="8">
                <th class="required text-end!">口座番号</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_NO">
                    <a-input-number
                      v-model:value="formData.FURI_KOZA_NO"
                      string-mode
                      :min="0"
                      :max="9999999"
                      :maxlength="7"
                      style="width: 100%"
                    ></a-input-number>
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="8">
                <th class="required text-end!">種別コード</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_SYUBETU">
                    <a-input-number
                      v-model:value="formData.FURI_SYUBETU"
                      string-mode
                      :min="0"
                      :max="99"
                      :maxlength="2"
                      style="width: 100%"
                    ></a-input-number>
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="24" :xxl="24">
                <th class="required w-40!">口座名義人（カナ）</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_MEIGI_KANA">
                    <a-input
                      v-model:value="formData.FURI_KOZA_MEIGI_KANA"
                      :maxlength="80"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="24" :xxl="24">
                <th class="required w-40!">口座名義人（漢字）</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_MEIGI">
                    <a-input
                      v-model:value="formData.FURI_KOZA_MEIGI"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-row class="mt-4">
          <a-col span="24">
            <th>
              <span style="font-weight: 700">支払口座情報</span
              ><br />（全銀手順で使用）
            </th>
            <a-row class="flex-1">
              <a-col span="12">
                <th>金融機関</th>
                <td>
                  <ai-select
                    v-model:value="formData.KOFU_BANK_CD"
                    :options="option2.BANK_LIST"
                    split-val
                    @change="onChangeKofuBank"
                  >
                  </ai-select>
                </td>
              </a-col>
              <a-col span="12">
                <th class="text-end!">本支店</th>
                <td>
                  <ai-select
                    v-model:value="formData.KOFU_BANK_SITEN_CD"
                    :options="option2.SITEN_LIST"
                    split-val
                  >
                  </ai-select>
                </td>
              </a-col>
              <a-col span="6">
                <th>口座種別</th>
                <td>
                  <ai-select
                    v-model:value="formData.KOFU_KOZA_SYUBETU"
                    :options="option2.KOZA_SYUBETU_LIST"
                    type="number"
                  >
                  </ai-select>
                </td>
              </a-col>
              <a-col span="6">
                <th class="text-end!">口座番号</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_KOZA_NO"
                    string-mode
                    :min="0"
                    :max="9999999"
                    :maxlength="7"
                    style="width: 100%"
                  >
                  </a-input-number>
                </td>
              </a-col>
              <a-col span="6">
                <th class="text-end!">種別コード</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_SYUBETU"
                    string-mode
                    :min="0"
                    :max="99"
                    :maxlength="2"
                    style="width: 100%"
                  >
                  </a-input-number>
                </td>
              </a-col>
              <a-col span="6">
                <th class="text-end!">コード区分</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_CD_KBN"
                    string-mode
                    :min="0"
                    :max="9"
                    :maxlength="1"
                    style="width: 100%"
                  ></a-input-number>
                </td>
              </a-col>
              <a-col span="6">
                <th>依頼人コード</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_KAISYA_CD"
                    string-mode
                    :maxlength="10"
                    style="width: 100%"
                  >
                  </a-input-number>
                </td>
              </a-col>
              <a-col span="18">
                <th class="w-58! text-end!">振込依頼人名（ﾌﾘｶﾞﾅ）</th>
                <td>
                  <a-input
                    v-model:value="formData.KOFU_KAISYA_NAME"
                    style="width: 100%"
                    :maxlength="40"
                  >
                  </a-input>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
      </div>
      <div class="py-2 my-4 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="save">保存</a-button>
          <a-button type="primary" @click="cancel">キャンセル</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form, message } from 'ant-design-vue'
import { onMounted, reactive, ref, watch } from 'vue'
import { InitDetail, Save, SearchDetail } from './service'
import { DetailVM } from './type'
import { showConfirmModal, showSaveModal } from '@/utils/modal'
import {
  CLOSE_CONFIRM,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import {
  convertToTel,
  convertToFullWidth,
  convertToAllowedCharacters,
  convertKanaToHalfWidth,
  convertToHalfWidthAndUpperCase,
} from '@/utils/util'

const formData = reactive<DetailVM>({
  KYOKAI_NAME: '',
  JIGYO_NAME: '',
  YAKUMEI: '',
  KAICHO_NAME: '',
  YOBI1: '',
  POST: '',
  ADDR1: '',
  ADDR2: '',
  HAKKO_NO_KANJI: '',
  TEL1: '',
  FAX1: '',
  E_MAIL1: '',
  TEL2: '',
  FAX2: '',
  E_MAIL2: '',
  HP_URL: '',
  TOUROKU_NO: '',
  FURI_BANK_CD: '',
  FURI_BANK_SITEN_CD: '',
  FURI_KOZA_SYUBETU: 0,
  FURI_KOZA_NO: '',
  FURI_SYUBETU: 0,
  FURI_KOZA_MEIGI_KANA: '',
  FURI_KOZA_MEIGI: '',
  KOFU_BANK_CD: '',
  KOFU_BANK_SITEN_CD: '',
  KOFU_KOZA_SYUBETU: 0,
  KOFU_KOZA_NO: '',
  KOFU_SYUBETU: 0,
  KOFU_CD_KBN: 0,
  KOFU_KAISYA_CD: 0,
  KOFU_KAISYA_NAME: '',
  KYOKAI_KBN: 0,
})

/**振込口座プルダウンリスト */
const option1 = reactive({
  BANK_LIST: [],
  SITEN_LIST: [],
  KOZA_SYUBETU_LIST: [],
})

const maxLength = ref(30)

/**支払口座プルダウンリスト  */
const option2 = reactive({
  BANK_LIST: [],
  SITEN_LIST: [],
  KOZA_SYUBETU_LIST: [],
})
const editJudge = new Judgement('GJ8030')
const rules = reactive({
  KYOKAI_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '協会名称'),
    },
  ],
  JIGYO_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '支援事業名'),
    },
  ],
  YAKUMEI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '役職名'),
    },
  ],
  KAICHO_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '会長名'),
    },
  ],
  YOBI1: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '予備'),
    },
  ],
  POST: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号'),
    },
  ],
  ADDR1: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所1'),
    },
  ],
  ADDR2: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所2'),
    },
  ],
  HAKKO_NO_KANJI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '発行番号・漢字'),
    },
  ],
  TEL1: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '電話１'),
    },
  ],
  FAX1: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ＦＡＸ１'),
    },
  ],
  E_MAIL1: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'E-mail１'),
    },
  ],
  TEL2: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '電話２'),
    },
  ],
  FAX2: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ＦＡＸ２'),
    },
  ],
  E_MAIL2: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'E-mail２'),
    },
  ],
  HP_URL: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ホームページURL'),
    },
  ],
  TOUROKU_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '登録番号'),
    },
  ],
  FURI_BANK_CD: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '金融機関'),
    },
  ],
  FURI_BANK_SITEN_CD: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '本支店'),
    },
  ],
  FURI_KOZA_SYUBETU: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '口座種別'),
    },
  ],
  FURI_KOZA_NO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '口座番号'),
    },
  ],
  FURI_SYUBETU: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '種別コード'),
    },
  ],
  FURI_KOZA_MEIGI_KANA: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '口座名義人（カナ）'),
      max: 80,
    },
  ],
  FURI_KOZA_MEIGI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '口座名義人（漢字）'),
    },
  ],
})

const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
onMounted(async () => {
  const res1 = await InitDetail({ BANK_CD: '' })
  Object.assign(option1, res1)
  Object.assign(option2, res1)
  const res = await SearchDetail({})
  Object.assign(formData, res.KYOKAI)
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
/** 発行番号・漢字 */
watch(
  () => formData.HAKKO_NO_KANJI,
  (newVal) => {
    if (newVal) {
      formData.HAKKO_NO_KANJI = convertToFullWidth(newVal)
    }
  },
  { deep: true }
)

/** 電話1 */
watch(
  () => formData.TEL1,
  (newVal) => {
    if (newVal) {
      formData.TEL1 = convertToTel(newVal)
    }
  },
  { deep: true }
)

/** FAX1 */
watch(
  () => formData.FAX1,
  (newVal) => {
    if (newVal) {
      formData.FAX1 = convertToTel(newVal)
    }
  },
  { deep: true }
)

/** E-Mail1 */
watch(
  () => formData.E_MAIL1,
  (newVal) => {
    if (newVal) {
      formData.E_MAIL1 = convertToAllowedCharacters(newVal)
    }
  },
  { deep: true }
)

/** 電話2 */
watch(
  () => formData.TEL2,
  (newVal) => {
    if (newVal) {
      formData.TEL2 = convertToTel(newVal)
    }
  },
  { deep: true }
)

/** FAX2 */
watch(
  () => formData.FAX2,
  (newVal) => {
    if (newVal) {
      formData.FAX2 = convertToTel(newVal)
    }
  },
  { deep: true }
)

/** E-Mail2 */
watch(
  () => formData.E_MAIL2,
  (newVal) => {
    if (newVal) {
      formData.E_MAIL2 = convertToAllowedCharacters(newVal)
    }
  },
  { deep: true }
)

/** ホームページURL */
watch(
  () => formData.HP_URL,
  (newVal) => {
    if (newVal) {
      formData.HP_URL = convertToAllowedCharacters(newVal)
    }
  },
  { deep: true }
)

/** 登録番号 */
watch(
  () => formData.TOUROKU_NO,
  (newVal) => {
    if (newVal) {
      formData.TOUROKU_NO = convertToHalfWidthAndUpperCase(newVal)
    }
  },
  { deep: true }
)

/** 振込　口座名義人（カナ） */
watch(
  () => formData.FURI_KOZA_MEIGI_KANA,
  (newVal) => {
    if (newVal) {
      formData.FURI_KOZA_MEIGI_KANA = convertKanaToHalfWidth(newVal)
    }
  },
  { deep: true }
)

/** 振込　口座名義人（漢字） */
watch(
  () => formData.FURI_KOZA_MEIGI,
  (newVal) => {
    if (newVal) {
      formData.FURI_KOZA_MEIGI = convertToFullWidth(newVal)
    }
  },
  { deep: true }
)

/** 支払　振込依頼人名（ﾌﾘｶﾞﾅ） */
watch(
  () => formData.KOFU_KAISYA_NAME,
  (newVal) => {
    if (newVal) {
      formData.KOFU_KAISYA_NAME = convertKanaToHalfWidth(newVal)
    }
  },
  { deep: true }
)

watch(
  () => formData,
  () => {
    editJudge.setEdited()
  }
)

//振込　金融機関
watch(
  () => formData.FURI_BANK_CD,
  async (newValue) => {
    const res = await InitDetail({ BANK_CD: newValue })
    Object.assign(option1, res)
  }
)

//支払　金融機関
watch(
  () => formData.KOFU_BANK_CD,
  async (newValue) => {
    const res = await InitDetail({ BANK_CD: newValue })
    Object.assign(option2, res)
  }
)
const onChangeFuriBank = () => {
  //クリア
  formData.FURI_BANK_SITEN_CD = ''
  formData.FURI_KOZA_SYUBETU = undefined
}

const onChangeKofuBank = () => {
  //クリア
  formData.KOFU_BANK_SITEN_CD = ''
  formData.KOFU_KOZA_SYUBETU = undefined
}

/** 登録処理 */
const save = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Save({ KYOKAI: formData })
        message.success(SAVE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}

/** キャンセル処理 */
const cancel = () => {
  showConfirmModal({
    content: CLOSE_CONFIRM.Msg,
    onOk: async () => {
      const res = await SearchDetail({})
      Object.assign(formData, res.KYOKAI)
    },
  })
}
</script>

<style lang="scss" scoped>
th {
  width: 140px;
}
</style>
