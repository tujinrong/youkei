<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者マスタ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.27
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false" class="mb2 h-full">
    <h1>（GJ1011）互助基金契約者マスタメンテナンス（基本情報入力）</h1>
    <div class="self_adaption_table form">
      <b>第8期</b>
      <div class="mb-2 header_operation flex justify-between w-full">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
        </a-space>
        <a-button type="primary" class="text-end" @click="goList"
          >一覧へ</a-button
        >
      </div>
      <h2>申請者基本情報1</h2>
      <a-form class="mb-1">
        <a-row>
          <a-col span="12">
            <th class="required">契約者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_CD"
                  :disabled="!isNew"
                  :maxlength="5"
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
                  :options="KEN_CD_NAME_LIST"
                  split-val
                  class="w-full"
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
                  :maxlength="10"
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
                  :options="KEIYAKU_KBN_CD_NAME_LIST"
                  split-val
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
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12" class="flex">
            <th>入金日、返還日(入金完了時)</th>
            <td>
              <a-form-item v-bind="validateInfos.NYU_HEN_DATE">
                <DateJp v-model:value="formData.NYU_HEN_DATE" disabled></DateJp>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <h2>申請者基本情報2</h2>
      <a-form class="mb-1">
        <a-row>
          <a-col span="8">
            <th class="required">申込者名(フリガナ)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_KANA">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_KANA"
                  :maxlength="50"
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
          <a-col span="8">
            <th class="required">申込者名(個人・団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_NAME">
                <a-input
                  v-model:value="formData.KEIYAKUSYA_NAME"
                  :maxlength="25"
                  @input="
                    changeType('full', $event.target.value, 'KEIYAKUSYA_NAME')
                  "
                >
                </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="8">
            <th>代表者名(団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.DAIHYO_NAME">
                <a-input
                  v-model:value="formData.DAIHYO_NAME"
                  :maxlength="25"
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
            <td class="flex-col">
              <a-row>
                <a-col
                  ><a-form-item v-bind="validateInfos.ADDR_POST">
                    <PostCode v-model:value="formData.ADDR_POST">
                      <a-input
                        v-model:value="formData.ADDR_1"
                        class="!w-40"
                        disabled
                      ></a-input
                    ></PostCode> </a-form-item></a-col
                ><a-col class="flex-1">
                  <a-form-item v-bind="validateInfos.ADDR_2">
                    <a-input
                      v-model:value="formData.ADDR_2"
                      :maxlength="15"
                      @input="changeType('full', $event.target.value, 'ADDR_2')"
                    ></a-input> </a-form-item></a-col
              ></a-row>
              <a-form-item v-bind="validateInfos.ADDR_3">
                <a-input
                  v-model:value="formData.ADDR_3"
                  :maxlength="15"
                  @input="changeType('full', $event.target.value, 'ADDR_3')"
                  @change="validate('ADDR_4')"
                ></a-input>
              </a-form-item>
              <a-form-item v-bind="validateInfos.ADDR_4">
                <a-input
                  v-model:value="formData.ADDR_4"
                  :maxlength="20"
                  @input="changeType('full', $event.target.value, 'ADDR_4')"
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
              <a-form-item v-bind="validateInfos.ADDR_TEL1">
                <a-input
                  v-model:value="formData.ADDR_TEL1"
                  :maxlength="15"
                  @input="changeType('tel', $event.target.value, 'ADDR_TEL1')"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col :span="7">
            <th>電話2</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_TEL2"
                :maxlength="15"
                @input="changeType('tel', $event.target.value, 'ADDR_TEL2')"
              ></a-input>
            </td>
          </a-col>
          <a-col class="flex-1">
            <th>FAX</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_FAX"
                :maxlength="15"
                @input="changeType('tel', $event.target.value, 'ADDR_FAX')"
              ></a-input>
            </td>
          </a-col>
          <a-col span="24">
            <th style="border-top: none">　</th>
            <th>メールアドレス</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_E_MAIL"
                :maxlength="50"
                @input="changeType('half', $event.target.value, 'ADDR_E_MAIL')"
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.JIMUITAKU_CD">
                <ai-select
                  v-model:value="formData.JIMUITAKU_CD"
                  :option="JIMUITAKUSENN_LIST"
                  split-val
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <h2>申請者基本情報3</h2>
      <a-form>
        <a-row>
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
          <a-col span="12">
            <th :class="hasnyuryoku ? 'required' : ''">金融機関</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_BANK_CD">
                <ai-select
                  v-model:value="formData.FURI_BANK_CD"
                  :option="FURI_BANK_LIST"
                  split-val
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th :class="hasnyuryoku ? 'required' : ''">本支店</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_BANK_SITEN_CD">
                <ai-select
                  v-model:value="formData.FURI_BANK_SITEN_CD"
                  :option="FURI_BANK_SITEN_LIST"
                  split-val
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="12">
            <th :class="hasnyuryoku ? 'required' : ''">口座種別</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_SYUBETU">
                <ai-select
                  v-model:value="formData.FURI_KOZA_SYUBETU"
                  :option="KOUZAISYUBETU_LIST"
                  split-val
                  :disabled="!hasnyuryoku"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col :span="12">
            <th :class="hasnyuryoku ? 'required' : ''">口座番号</th>
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_NO">
                <a-input
                  v-model:value="formData.FURI_KOZA_NO"
                  :maxlength="7"
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
          <a-col>
            <th :class="hasnyuryoku ? 'required' : ''">口座名義人</th>
          </a-col>
          <a-col :span="11">
            <td>
              <a-form-item v-bind="validateInfos.FURI_KOZA_MEIGI_KANA">
                <a-input
                  v-model:value="formData.FURI_KOZA_MEIGI_KANA"
                  :maxlength="80"
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
          <a-col class="flex-1">
            <td>
              <a-input
                v-model:value="formData.FURI_KOZA_MEIGI"
                :maxlength="40"
                :disabled="!hasnyuryoku"
                @input="
                  changeType('full', $event.target.value, 'FURI_KOZA_MEIGI')
                "
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="12">
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
          <a-col :span="12"
            ><th>備考</th>
            <td>
              <a-textarea
                v-model:value="formData.BIKO"
                :maxlength="40"
                @input="changeType('full', $event.target.value, 'BIKO')"
              /></td
          ></a-col>
        </a-row>
      </a-form>
    </div>
  </a-card>
</template>
<script setup lang="ts">
import { PageStatus } from '@/enum'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { reactive, nextTick, onMounted, ref, computed } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showInfoModal } from '@/utils/modal'
import {
  DELETE_CONFIRM,
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
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
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  status: PageStatus
}>()
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageStatus.New
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
const hasnyuryoku = ref(false)
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const KEIYAKU_KBN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const KEIYAKU_JYOKYO_LIST = ref<CmCodeNameModel[]>([])
const KOUZAISYUBETU_LIST = ref<CmCodeNameModel[]>([])
const FURI_BANK_SITEN_LIST = ref<CmCodeNameModel[]>([])

const FURI_BANK_LIST = ref<CmCodeNameModel[]>([])
const JIMUITAKUSENN_LIST = ref<CmCodeNameModel[]>([])

const rules = reactive({
  KEIYAKUSYA_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace(
        '{0}',
        '経営安定対策事業生産者番号'
      ),
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
onMounted(() => {
  nextTick(() => editJudge.reset())
  if (!isNew && formData.FURI_BANK_CD) hasnyuryoku.value = true
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

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
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    router.push({ name: route.name })
  })
}

const saveData = () => {
  if (!editJudge.isPageEdited()) {
    showInfoModal({
      content: '変更したデータはありません。',
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
        router.push({ name: route.name, query: { refresh: '1' } })
        message.success(DELETE_OK_INFO.Msg)
      } catch (error) {}
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
