<template>
  <div>
    <a-card :bordered="false" class="mb-4 h-full">
      <h1>（GJ8030）日本養鶏協会マスタメンテナンス</h1>
      <div class="my-4 flex justify-between">
        <a-space :size="20">
          <a-button class="warning-btn" @click="save">保存</a-button>
          <a-button type="primary" danger @click="cancel">キャンセル</a-button>
        </a-space>
        <close-page />
      </div>
      <div class="self_adaption_table form">
        <a-row>
          <a-col span="12">
            <th class="required">協会名称</th>
            <td>
              <a-form-item v-bind="validateInfos.KYOKAI_NAME">
                <a-input v-model:value="formData.KYOKAI_NAME" :maxlength="30"
              /></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">支援事業名</th>
            <td>
              <a-form-item v-bind="validateInfos.JIGYO_NAME">
                <a-input v-model:value="formData.JIGYO_NAME" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="24" :lg="24" :xl="12" :xxl="12">
            <th class="required">役職名</th>
            <td>
              <a-form-item v-bind="validateInfos.YAKUMEI">
                <a-input v-model:value="formData.YAKUMEI" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required">会長名</th>
            <td>
              <a-form-item v-bind="validateInfos.KAICHO_NAME">
                <a-input v-model:value="formData.KAICHO_NAME" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>予備</th>
            <td>
              <a-input v-model:value="formData.YOBI1" :maxlength="30" />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">住所</th>
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="12" :xxl="10">
                <td>
                  <a-form-item v-bind="validateInfos.POST">
                    <a-input v-model:value="formData.POST" :maxlength="8"
                  /></a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="18">
                <td>
                  <a-form-item v-bind="validateInfos.ADDR1">
                    <a-input v-model:value="formData.ADDR1" />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="18">
                <td>
                  <a-input v-model:value="formData.ADDR2" />
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="12" :xxl="6">
                <th class="required">発行番号・漢字</th>
                <td>
                  <a-form-item v-bind="validateInfos.HAKKO_NO_KANJI">
                    <a-input
                      v-model:value="formData.HAKKO_NO_KANJI"
                      :maxlength="4"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="24">
            <th class="required">連絡先１</th>
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th class="required">電話１</th>
                <td>
                  <a-form-item v-bind="validateInfos.TEL1">
                    <a-input v-model:value="formData.TEL1" :maxlength="13"
                  /></a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th class="required">ＦＡＸ１</th>
                <td>
                  <a-form-item v-bind="validateInfos.FAX1">
                    <a-input v-model:value="formData.FAX1" :maxlength="13"
                  /></a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th>E-mail１</th>
                <td>
                  <a-input v-model:value="formData.E_MAIL1" :maxlength="30" />
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="24">
            <th>連絡先２</th>
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th>電話２</th>
                <td>
                  <a-input v-model:value="formData.TEL2" :maxlength="13" />
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th>ＦＡＸ２</th>
                <td>
                  <a-input v-model:value="formData.FAX2" :maxlength="13" />
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="12" :xxl="8">
                <th>E-mail２</th>
                <td>
                  <a-input v-model:value="formData.E_MAIL2" :maxlength="30" />
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col span="24">
            <th class="required">ホームページURL</th>
            <td>
              <a-form-item v-bind="validateInfos.HP_URL">
                <a-input v-model:value="formData.HP_URL" :maxlength="50"
              /></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row class="mt-4">
          <a-col span="24">
            <th class="required">振込口座情報</th>
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="12" :xxl="12">
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
              <a-col :md="24" :lg="12" :xl="12" :xxl="12">
                <th class="required">本支店</th>
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
              <a-col :md="24" :lg="12" :xl="12" :xxl="6">
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
              <a-col :md="24" :lg="12" :xl="12" :xxl="6">
                <th class="required">口座番号</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_NO">
                    <a-input-number
                      v-model:value="formData.FURI_KOZA_NO"
                      string-mode
                      :min="1"
                      :max="9999999"
                      :maxlength="7"
                      style="width: 100%"
                    ></a-input-number>
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="12" :xxl="6">
                <th class="required">種別コード</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_SYUBETU">
                    <a-input-number
                      v-model:value="formData.FURI_SYUBETU"
                      string-mode
                      :min="1"
                      :max="99"
                      :maxlength="2"
                      style="width: 100%"
                    ></a-input-number>
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="24" :xxl="24">
                <th class="required">口座名義人（カナ）</th>
                <td>
                  <a-form-item v-bind="validateInfos.FURI_KOZA_MEIGI_KANA">
                    <a-input
                      v-model:value="formData.FURI_KOZA_MEIGI_KANA"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="24" :xxl="24">
                <th class="required">口座名義人（漢字）</th>
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
            <th>支払口座情報<br />（全銀手順で使用）</th>
            <a-row class="flex-1">
              <a-col :md="24" :lg="12" :xl="12" :xxl="12">
                <th>金融機関/th></th>
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
              <a-col :md="24" :lg="12" :xl="12" :xxl="12">
                <th>本支店</th>
                <td>
                  <ai-select
                    v-model:value="formData.KOFU_BANK_SITEN_CD"
                    :options="option2.SITEN_LIST"
                    split-val
                  >
                  </ai-select>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="8" :xxl="6">
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
              <a-col :md="24" :lg="12" :xl="8" :xxl="6">
                <th>口座番号</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_KOZA_NO"
                    string-mode
                    :min="1"
                    :max="9999999"
                    :maxlength="7"
                    style="width: 100%"
                  >
                  </a-input-number>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="8" :xxl="6">
                <th>種別コード</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_SYUBETU"
                    string-mode
                    :min="1"
                    :max="99"
                    :maxlength="2"
                    style="width: 100%"
                  >
                  </a-input-number>
                </td>
              </a-col>
              <a-col :md="24" :lg="12" :xl="8" :xxl="6">
                <th>コード区分</th>
                <td>
                  <a-input-number
                    v-model:value="formData.KOFU_CD_KBN"
                    string-mode
                    :min="1"
                    :max="9"
                    :maxlength="1"
                    style="width: 100%"
                  ></a-input-number>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="20" :xxl="6">
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
              <a-col :md="24" :lg="24" :xl="20" :xxl="18">
                <th>振込依頼人名（ﾌﾘｶﾞﾅ）</th>
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
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form, message } from 'ant-design-vue'
import { onMounted, reactive, watch } from 'vue'
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
  TOUROKU_NO: '',
})

/**振込口座プルダウンリスト */
const option1 = reactive({
  BANK_LIST: [],
  SITEN_LIST: [],
  KOZA_SYUBETU_LIST: [],
})

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
  HP_URL: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'ホームページURL'),
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
      max: 40,
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
  width: 160px;
}
</style>
