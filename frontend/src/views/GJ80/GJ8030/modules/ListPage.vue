<template>
  <a-card :bordered="false" class="mb-4 h-full" >
      <h1>契約者別基本情報・農場登録情報のＣＳＶデータ作成</h1>
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
              <a-input v-model:value="formData.KYOKAI_NAME" :maxlength="30" />
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">支援事業名</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.JIGYO_NAME" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">役職名</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.YAKUMEI" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col><a-col span="12"></a-col>
          <a-col span="12">
            <th class="required">会長名</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.KAICHO_NAME" :maxlength="30" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>予備</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.YOBI1"  :maxlength="30"/>
              </a-form-item>
            </td>
          </a-col></a-row><a-row>
          <a-col span="8">
            <th class="required">住所</th>
            <td>
              <a-input v-model:value="formData.POST"  :maxlength="8"/>
            </td>
          </a-col><a-col span="20">
            <th style="border-top: none;"></th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.ADDR1" :maxlength="60" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="20">
            <th style="border-top: none;"></th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.ADDR2"  :maxlength="60"/>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="4">
            <th class="required">発行番号・漢字</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.HAKKO_NO_KANJI" :maxlength="4" />
              </a-form-item>
            </td>
          </a-col>
          <a-col span="10">
            <th>連絡先１</th>
            <th class="required">電話１</th>
            <td>
              <a-input v-model:value="formData.TEL1" :maxlength="13">
                </a-input>
            </td>
          </a-col>
          <a-col span="6">
            <th class="required">ＦＡＸ１</th>
            <td>
              <a-input v-model:value="formData.FAX1" :maxlength="13" </a-input>
            </td>
          </a-col>
          <a-col span="8">
            <th>E-mail１</th>
            <td>
              <a-input v-model:value="formData.E_MAIL1" :maxlength="30" </a-input>
            </td>
          </a-col>
          <a-col span="10">
            <th>連絡先２</th>
            <th>電話２</th>
            <td>
              <a-input v-model:value="formData.TEL2" :maxlength="13" </a-input>
            </td>
          </a-col>
          <a-col span="6">
            <th>ＦＡＸ２</th>
            <td>
              <a-input v-model:value="formData.FAX2" :maxlength="13" </a-input>
            </td>
          </a-col>
          <a-col span="8">
            <th>E-mail２</th>
            <td>
              <a-input v-model:value="formData.E_MAIL2" :maxlength="30" </a-input>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">ホームページURL</th>
            <td>
              <a-input v-model:value="formData.HP_URL" :maxlength="50" </a-input>
            </td>
          </a-col>
        </a-row>
        <a-row class="mt-4">
          <a-col span="14">
            <th class="required">振込口座情報</th>
            <th>金融機関</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.FURI_BANK_CD"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="10">
            <th>本支店</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.FURI_BANK_SITEN_CD"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="11">
            <th  style="border-top: none;"></th>
            <th>口座種別</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.FURI_KOZA_SYUBETU"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="7">
            <th>口座番号</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.FURI_KOZA_NO"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="6">
            <th>種別コード</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.FURI_SYUBETU"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="24">
            <th style="border-top: none;"></th>
            <th>口座名義人（カナ）</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.FURI_KOZA_MEIGI_KANA" :maxlength="40" />
              </a-form-item>
            </td>
          </a-col><a-col span="24">
            <th style="border-top: none;"></th>
            <th>口座名義人（漢字）</th>
            <td>
              <a-form-item>
                <a-input v-model:value="formData.FURI_KOZA_MEIGI" :maxlength="40"/>
              </a-form-item>
            </td>
          </a-col></a-row>
          <a-row class="mt-4">
         <a-col span="14">
            <th>支払口座情報</th>
            <th>金融機関</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_BANK_CD"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="10">
            <th>本支店</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_BANK_SITEN_CD"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="9">
            <th  style="border-top: none;"></th>
            <th>口座種別</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_KOZA_SYUBETU"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="5">
            <th>口座番号</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_KOZA_NO"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="5">
            <th>種別コード</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_SYUBETU"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="5">
            <th>コード区分</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_CD_KBN"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col><a-col span="24">
            <th style="border-top: none;"></th>
            <th>依頼人</th>
            <td>
              <a-form-item>
                <ai-select v-model:value="formData.KOFU_KAISYA_CD"
                 ></ai-select>
              </a-form-item>
            </td>
          </a-col></a-row>
      </div>
  </a-card>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited';
import { Form } from 'ant-design-vue';
import { reactive, watch } from 'vue';
import { Enum編集区分 } from '@/enum';

const formData = reactive({
  KYOKAI_NAME: undefined,
  JIGYO_NAME: undefined,
  YAKUMEI: undefined,
  KAICHO_NAME: undefined,
  YOBI1: undefined,
  POST: undefined,
  ADDR1: undefined,
  ADDR2: undefined,
  HAKKO_NO_KANJI: undefined,
  TEL1: undefined,
  FAX1: undefined,
  E_MAIL1: undefined,
  TEL2: undefined,
  FAX2: undefined,
  E_MAIL2: undefined,
  HP_URL: undefined,
  FURI_BANK_CD: undefined,
  FURI_BANK_SITEN_CD: undefined,
  FURI_KOZA_SYUBETU: undefined,
  FURI_KOZA_NO: undefined,
  FURI_SYUBETU: undefined,
  FURI_KOZA_MEIGI_KANA: undefined,
  FURI_KOZA_MEIGI: undefined,
  KOFU_BANK_CD: undefined,
  KOFU_BANK_SITEN_CD: undefined,
  KOFU_KOZA_SYUBETU: undefined,
  KOFU_KOZA_NO: undefined,
  KOFU_SYUBETU: undefined,
  KOFU_CD_KBN: undefined,
  KOFU_KAISYA_CD: undefined,
});


const editJudge = new Judgement('GJ8030')
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
watch(() => formData,
() => {
  editJudge.setEdited()
},
)


const save = async () => {
  await validate()
}

const cancel = () => { }
</script>
<style lang="scss" scoped>
th {
  width: 160px;
}
</style>

