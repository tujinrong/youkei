<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者マスタ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.27
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="（GJ1011）互助基金契約者マスタメンテナンス（基本情報入力）"
    width="1000px"
    :body-style="{ height: '800px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
      <b>第8期</b>
      <a-form class="border-t-1">
        <a-row class="mt-2">
          <a-col span="12">
            <th class="required">契約者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_CD"
                  :disabled="!isNew"
                  :maxlength="5"
                  class="w-20"
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>経営安定対策事業生産者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.SEISANSYA_CD">
                <a-input
                  v-model:value="formData.SEISANSYA_CD"
                  :maxlength="5"
                  class="w-20"
                  @input="
                    changeType('number', $event.target.value, 'SEISANSYA_CD')
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required">都道府県</th>
            <td>
              <a-form-item v-bind="validateInfos.KEN_CD">
                <ai-select
                  v-model:value="formData.KEN_CD"
                  :options="KEN_LIST"
                  split-val
                  class="max-w-50"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>日鶏協番号</th>
            <td>
              <a-form-item v-bind="validateInfos.NIKKEIKYO_CD">
                <a-input
                  v-model:value="formData.NIKKEIKYO_CD"
                  :maxlength="5"
                  class="w-20"
                  @input="
                    changeType('number', $event.target.value, 'SEISANSYA_CD')
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required">契約区分</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKU_KBN">
                <ai-select
                  v-model:value="formData.KEIYAKU_KBN"
                  :options="KEIYAKU_KBN_LIST"
                  split-val
                  class="max-w-45"
                  placeholder="家族型、企業型、鶏以外"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>契約日</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKU_DATE">
                <DateJp
                  v-model:value="formData.KEIYAKU_DATE"
                  :disabled="formData.NYU_HEN_DATE"
              /></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required">契約状況</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKU_JYOKYO">
                <ai-select
                  v-model:value="formData.KEIYAKU_JYOKYO"
                  :option="KEIYAKU_JYOKYO_LIST"
                  class="max-w-45"
                  placeholder="継続契約、新規契約、未契約者"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12" class="flex mb-2">
            <th>入金日、返還日</th>
            <td>
              <a-form-item v-bind="validateInfos.NYU_HEN_DATE">
                <DateJp v-model:value="formData.NYU_HEN_DATE" disabled></DateJp
                >(入金完了時)
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <a-form class="border-t-1">
        <a-row class="mt-2">
          <a-col span="24">
            <th class="required">申込者名(フリガナ)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_KANA">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_KANA"
                  :maxlength="50"
                  class="w-160"
                  @input="
                    changeType(
                      'furikana',
                      $event.target.value,
                      'KEIYAKUSYA_KANA'
                    )
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">申込者名(個人・団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_NAME">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_NAME"
                  :maxlength="25"
                  class="w-160"
                  @input="
                    changeType('full', $event.target.value, 'KEIYAKUSYA_NAME')
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th>代表者名(団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.DAIHYO_NAME">
                <a-input
                  v-model:value="formData.DAIHYO_NAME"
                  :maxlength="25"
                  class="w-160"
                  @input="
                    changeType('full', $event.target.value, 'DAIHYO_NAME')
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">住所</th>
            <td class="flex-col" style="height: fit-content">
              <a-row>
                <a-col
                  ><a-form-item v-bind="validateInfos.ADDR_POST">
                    <PostCode v-model:value="formData.ADDR_POST">
                      <a-input
                        v-model:value="formData.ADDR_1"
                        class="!w-23"
                        disabled
                      ></a-input
                    ></PostCode> </a-form-item></a-col
                ><a-col class="flex-1">
                  <a-form-item v-bind="validateInfos.ADDR_2">
                    <a-input
                      v-model:value="formData.ADDR_2"
                      :maxlength="15"
                      class="!w-80"
                      @input="changeType('full', $event.target.value, 'ADDR_2')"
                    ></a-input> </a-form-item
                ></a-col>
              </a-row>
              <a-row>
                <a-col span="5"></a-col>
                <a-col span="5">
                  <a-form-item v-bind="validateInfos.ADDR_3">
                    <a-input
                      v-model:value="formData.ADDR_3"
                      :maxlength="15"
                      class="!w-80"
                      @input="changeType('full', $event.target.value, 'ADDR_3')"
                      @change="validate('ADDR_4')"
                    ></a-input>
                  </a-form-item>
                </a-col>
              </a-row>
              <a-row>
                <a-col span="5"></a-col>
                <a-col span="5">
                  <a-form-item v-bind="validateInfos.ADDR_4">
                    <a-input
                      v-model:value="formData.ADDR_4"
                      :maxlength="20"
                      class="!w-103"
                      @input="changeType('full', $event.target.value, 'ADDR_4')"
                    ></a-input>
                  </a-form-item>
                </a-col>
              </a-row>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col>
            <th class="required">連絡先</th>
          </a-col>
          <a-col :span="6">
            <th class="required" style="width: fit-content">電話</th>
            <td>
              <a-form-item v-bind="validateInfos.ADDR_TEL1">
                <a-input
                  v-model:value="formData.ADDR_TEL1"
                  :maxlength="14"
                  class="w-40"
                  @input="changeType('tel', $event.target.value, 'ADDR_TEL1')"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col :span="6">
            <th style="width: fit-content">電話2</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_TEL2"
                :maxlength="14"
                class="w-40"
                @input="changeType('tel', $event.target.value, 'ADDR_TEL2')"
              ></a-input>
            </td>
          </a-col>
          <a-col class="flex-1">
            <th style="width: fit-content">FAX</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_FAX"
                :maxlength="14"
                class="w-40"
                @input="changeType('tel', $event.target.value, 'ADDR_FAX')"
              ></a-input>
            </td>
          </a-col>
          <a-col span="24">
            <th></th>
            <th style="width: fit-content">メールアドレス</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_E_MAIL"
                :maxlength="50"
                class="w-140"
                @input="changeType('half', $event.target.value, 'ADDR_E_MAIL')"
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24" class="mb-2">
            <th class="required">事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.JIMUITAKU_CD">
                <ai-select
                  v-model:value="formData.JIMUITAKU_CD"
                  :option="ITAKU_LIST"
                  class="max-w-123"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <a-form class="border-t-1">
        <a-row class="mt-2">
          <a-col span="24">
            <th>金融機関入力情報有無</th>
            <td>
              <a-radio-group v-model:value="hasnyuryoku" class="ml-2 pt-1">
                <a-radio :value="true">有</a-radio>
                <a-radio :value="false">無</a-radio>
              </a-radio-group>
              <span class="pt-1">(有の時、下記の項目は必須入力)</span>
            </td>
          </a-col>
          <a-col span="13">
            <th :class="hasnyuryoku ? 'required' : ''">金融機関</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_BANK_CD">
                <ai-select
                  v-model:value="formData.FURI_BANK_CD"
                  :option="BANK_LIST"
                  split-val
                  class="max-w-65"
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="11">
            <th
              :class="hasnyuryoku ? 'required' : ''"
              style="width: fit-content"
            >
              本支店
            </th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_BANK_SITEN_CD">
                <ai-select
                  v-model:value="formData.FURI_BANK_SITEN_CD"
                  :option="SITEN_LIST"
                  split-val
                  class="max-w-65"
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="13">
            <th :class="hasnyuryoku ? 'required' : ''">口座種別</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_SYUBETU">
                <ai-select
                  v-model:value="formData.FURI_KOZA_SYUBETU"
                  :option="KOZA_SYUBETU_LIST"
                  split-val
                  class="max-w-40"
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col :span="11">
            <th
              :class="hasnyuryoku ? 'required' : ''"
              style="width: fit-content"
            >
              口座番号
            </th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_NO">
                <a-input
                  v-model:value="formData.FURI_KOZA_NO"
                  :maxlength="7"
                  class="w-20"
                  :disabled="!hasnyuryoku"
                  @input="
                    changeType('number', $event.target.value, 'FURI_KOZA_NO')
                  "
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="24">
            <th :class="hasnyuryoku ? 'required' : ''">口座名義人</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_MEIGI_KANA">
                <a-input
                  v-model:value="formData.FURI_KOZA_MEIGI_KANA"
                  :maxlength="80"
                  class="w-160"
                  :disabled="!hasnyuryoku"
                  @input="
                    changeType(
                      'half',
                      $event.target.value,
                      'FURI_KOZA_MEIGI_KANA'
                    )
                  "
                ></a-input>
              </a-form-item>
            </td>
          </a-col>

          <a-col :span="24">
            <th class="border-t-0"></th>
            <td>
              <a-input
                v-model:value="formData.FURI_KOZA_MEIGI"
                :maxlength="40"
                class="w-160"
                :disabled="!hasnyuryoku"
                @input="
                  changeType('full', $event.target.value, 'FURI_KOZA_MEIGI')
                "
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="10">
            <a-row class="flex-rol w-full"
              ><a-col class="w-full">
                <th class="required">入力確認有無</th>
                <td>
                  <a-radio-group
                    v-model:value="formData.NYURYOKU_JYOKYO"
                    class="ml-2 h-full pt-1"
                  >
                    <a-radio :value="1">有</a-radio>
                    <a-radio :value="2">無</a-radio>
                  </a-radio-group>
                </td>
              </a-col>
              <a-col class="w-full">
                <th>廃業日</th>
                <td>
                  <DateJp v-model:value="formData.HAIGYO_DATE" />
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col :span="14"
            ><th style="width: fit-content">備考</th>
            <td>
              <a-textarea
                class="font-size-3"
                v-model:value="formData.BIKO"
                :maxlength="200"
                :auto-size="{ minRows: 5, maxRows: 5 }"
                @input="changeType('full', $event.target.value, 'BIKO')"
              /></td
          ></a-col>
        </a-row>
      </a-form>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { EnumEditKbn, PageStatus } from '@/enum'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { reactive, nextTick, onMounted, ref, watch, computed } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { DetailVM } from '../../type'
import {
  convertALLToHalfWidth,
  convertToFullWidth,
  convertToTel,
  convertToHalfNumber,
  convertToKaNa,
  convertToFuRiGaNa,
} from '@/utils/util'
import { InitDetail, Save, SearchDetail } from '../../service'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])

const editJudge = new Judgement()
const createDefaultParams = () => {
  return {
    KI: undefined as number | undefined, //期
    KEIYAKUSYA_CD: undefined as number | undefined, //契約者番号
    SEISANSYA_CD: undefined as number | undefined, //経営安定対策事業生産者番号
    KEN_CD: undefined as number | undefined, //都道府県
    NIKKEIKYO_CD: undefined as number | undefined, //日鶏協番号
    KEIYAKU_KBN: undefined as number | undefined, //契約区分
    KEIYAKU_DATE: new Date() as Date | undefined, //契約日
    KEIYAKU_JYOKYO: undefined as number | undefined, //契約状況
    NYU_HEN_DATE: undefined as Date | undefined, //入金日、返還日
    KEIYAKUSYA_KANA: '', //申込者名(ﾌﾘｶﾞﾅ)
    KEIYAKUSYA_NAME: '', //申込者名(個人・団体
    DAIHYO_NAME: '', //代表者名(団体)
    ADDR_POST: '', //住所（郵便番号）
    ADDR_1: '', //
    ADDR_2: '', //
    ADDR_3: '', //
    ADDR_4: '', //
    ADDR_TEL1: '', //連絡先（電話）
    ADDR_TEL2: '', //連絡先（電話2)
    ADDR_FAX: '', //連絡先（FAX）
    ADDR_E_MAIL: '', //メールアドレス
    JIMUITAKU_CD: undefined as number | undefined, //事務委託先番号
    FURI_BANK_CD: '', //金融機関コード
    FURI_BANK_SITEN_CD: '', //本支店コード
    FURI_KOZA_SYUBETU: undefined as number | undefined, //口座種別コード
    FURI_KOZA_NO: '', //口座番号
    FURI_KOZA_MEIGI_KANA: '', //口座名義人（カナ）
    FURI_KOZA_MEIGI: '', //口座名義人（漢字）
    NYURYOKU_JYOKYO: 2 as number | undefined, //入力確認有無(入力状況)
    BIKO: '', //備考
    HAIGYO_DATE: new Date() as Date | undefined, //廃業日
    UP_DATE: new Date() as Date | undefined, //データ更新日
  } as DetailVM
}
const formData = reactive(createDefaultParams())
const hasnyuryoku = ref(true)

const KEN_LIST = ref<CmCodeNameModel[]>([{ CODE: 46, NAME: '鹿児島県' }]) // 都道府県情報プルダウンリスト
const KEIYAKU_KBN_LIST = ref<CmCodeNameModel[]>([
  { CODE: 1, NAME: '家族' },
  { CODE: 2, NAME: '企業' },
  { CODE: 3, NAME: '鶏以外' },
])
// 契約区分情報プルダウンリスト
const KEIYAKU_JYOKYO_LIST = ref<CmCodeNameModel[]>([]) // 契約状況情報プルダウンリスト
const ITAKU_LIST = ref<CmCodeNameModel[]>([
  // { CODE: 666, NAME: '事務委託先事務委託先事務委託先事務委託先事務委託先' },
]) // 事務委託先情報プルダウンリスト
const BANK_LIST = ref<CmCodeNameModel[]>([
  { CODE: 6666, NAME: '金融機関テスト金融機関テスト金' },
]) // 金融機関情報プルダウンリスト
const SITEN_LIST = ref<CmCodeNameModel[]>([]) // 本支店情報プルダウンリスト
const KOZA_SYUBETU_LIST = ref<CmCodeNameModel[]>([]) // 口座種別情報プルダウンリスト
const NYURYOKU_JYOKYO_LIST = ref<CmCodeNameModel[]>([]) // 入力確認有無情報プルダウンリスト

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
      if (!isNew && formData.FURI_BANK_CD) hasnyuryoku.value = true
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
const changeType = (type: string, input: any, name: string) => {
  const typeMap = {
    half: convertALLToHalfWidth,
    full: convertToFullWidth,
    tel: convertToTel,
    number: convertToHalfNumber,
    kana: convertToKaNa,
    furikana: convertToFuRiGaNa,
  }
  nextTick(() => {
    if (typeMap[type]) formData[name] = typeMap[type](input)
  })
}

//画面遷移
const goList = () => {
  closeModal()
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    Object.assign(formData, createDefaultParams())
    hasnyuryoku.value = false
    clearValidate()
    emit('update:visible', false)
  })
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
          await Save({ KEIYAKUSYA: formData })
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
</script>
<style lang="scss" scoped>
th {
  width: 200px;
}
</style>
