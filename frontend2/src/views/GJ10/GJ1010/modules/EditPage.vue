<template>
  <a-card :bordered="false" class="mb2 h-full">
    <h1>互助基金契約者マスタメンテナンス（基本情報入力）</h1>
    <div class="self_adaption_table form ml-5">
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
      <h2 class="text-lg font-bold">申請者基本情報1</h2>
      <a-form class="mb-2">
        <a-row>
          <a-col span="12">
            <th class="required">契約者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>経営安定対策事業生産者番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
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
                  class="w-full"
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>日鶏協番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required">契約区分</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th>契約日</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <DateJp v-model:value="formData.b" unknown format="YYYY-MM-DD"
              /></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th>契約状況</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12" class="flex">
            <th>入金日、返還日(入金完了時)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <h2 class="text-lg font-bold mt-3">申請者基本情報2</h2>
      <a-form class="mb-2">
        <a-row>
          <a-col span="8">
            <th>申込者名(フリガナ)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="8">
            <th>申込者名(個人・団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="8">
            <th>代表者名(団体)</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input :disabled="!isNew"> </a-input
              ></a-form-item>
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
              <a-form-item v-bind="validateInfos.ADDR_3">
                <a-input
                  v-model:value="formData.ADDR_3"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
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
              <a-form-item v-bind="validateInfos.ADDR_2">
                <a-input
                  v-model:value="formData.ADDR_2"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col :span="7">
            <th>電話2</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_2"
                :maxlength="15"
              ></a-input>
            </td>
          </a-col>
          <a-col class="flex-1">
            <th>FAX</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_2"
                :maxlength="15"
              ></a-input>
            </td>
          </a-col>
          <a-col span="24">
            <th style="border-top: none">　</th>
            <th>メールアドレス</th>
            <td>
              <a-input
                v-model:value="formData.ADDR_2"
                :maxlength="15"
              ></a-input>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">事務委託先</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
      <h2 class="text-lg font-bold">申請者基本情報3</h2>
      <a-form>
        <a-row>
          <a-col span="24">
            <th>金融機関入力情報有無</th>
            <td>
              <a-radio-group v-model:value="value" 　class="ml-2 pt-1">
                <a-radio value="1">有</a-radio>
                <a-radio value="2">無</a-radio>
              </a-radio-group>
              <span class="pt-1">(有の時、下記の項目は必須入力)</span>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">金融機関</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col span="12">
            <th class="required">本支店</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :span="12">
            <th class="required">口座種別</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select></ai-select
              ></a-form-item>
            </td>
          </a-col>
          <a-col :span="12">
            <th class="required">口座番号</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <a-input
                  v-model:value="formData.ADDR_2"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col>
            <th class="required">口座名義人</th>
          </a-col>
          <a-col :span="11">
            <td>
              <a-form-item v-bind="validateInfos.ADDR_2">
                <a-input
                  v-model:value="formData.ADDR_2"
                  :maxlength="15"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
          <a-col class="flex-1">
            <td>
              <a-input
                v-model:value="formData.ADDR_2"
                :maxlength="15"
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
                  <a-radio-group v-model:value="value" class="ml-2 h-full pt-1">
                    <a-radio value="1">有</a-radio>
                    <a-radio value="2">無</a-radio>
                  </a-radio-group>
                </td>
              </a-col>
              <a-col class="w-full">
                <th>廃業日</th>
                <td>
                  <DateJp
                    v-model:value="formData.b"
                    unknown
                    format="YYYY-MM-DD"
                  />
                </td>
              </a-col>
            </a-row>
          </a-col>
          <a-col :span="12"
            ><th>備考</th>
            <td>
              <a-textarea v-model:value="formData.a" /></td
          ></a-col>
        </a-row>
      </a-form>
    </div>
  </a-card>
</template>
<script setup lang="ts">
import { PageSatatus } from '@/enum'
import { useRoute, useRouter } from 'vue-router'
import { Form } from 'ant-design-vue'
import { reactive, nextTick, onMounted } from 'vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { Judgement } from '@/utils/judge-edited'
const props = defineProps<{
  status: PageSatatus
}>()
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageSatatus.New
const editJudge = new Judgement()
const createDefaultParams = reactive({})
const formData = reactive(createDefaultParams)
const rules = reactive({
  KEIYAKUSYA_CD: [
    {
      required: true,
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
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    router.push({ name: route.name as string })
  })
}
</script>
<style lang="scss" scoped>
h1 {
  font-size: 24px;
}
:deep(.ant-form-item) {
  width: 100%;
  margin-bottom: 0;
}
th {
  min-width: 120px;
}
</style>
