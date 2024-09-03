<template>
  <a-card :bordered="false" class="mb-4 h-full">
    <h1>(GJ2021)契約者積立金・互助金単価マスタメンテナンス</h1>
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
    <div class="self_adaption_table form max-w-240">
      <a-row :gutter="[0, 16]">
        <a-col span="24">
          <th>年 月 日</th>
          <td class="flex items-center">
            <DateJp
              v-model:value="formData.START_DATE"
              style="width: 50%"
            /><span>～</span>
            <DateJp v-model:value="formData.END_DATE" style="width: 50%" />
          </td>
        </a-col>
      </a-row>
      <a-row class="mt-4 mb-4">
        <div style="width: 100%; text-align: end">(单位：円)</div>
        <a-row>
          <a-col span="4">
            <th>契約区分</th>
          </a-col>
          <a-col span="5">
            <th>鳥の種類</th>
          </a-col>
          <a-col span="5">
            <th>契約者積立金</th>
          </a-col>
          <a-col span="5">
            <th>経営支援互助金</th>
          </a-col>
          <a-col span="5">
            <th>焼却·埋却等互助金</th>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="4">
            <th>家族型</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>採卵鶏(成鶏)</th>
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.HENKAN_NINZU"
                      class="w-full"
                      :maxLength="5"
                      :precision="1"
                      :max="999.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.HENKAN_GOKEI"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :maxlength="6"
                      :min="0"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.HENKAN_RITU"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :maxlength="5"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>採卵鶏(育成鶏)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>肉用鶏</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>種鶏(成鷄)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>種鶏(育成鷄)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="4">
            <th>企業型</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>採卵鶏(成鶏)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>採卵鶏(育成鶏)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>肉用鶏</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>種鶏(成鷄)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>種鶏(育成鷄)</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="4">
            <th>鶏以外</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>うずら</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>あひる</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>きじ</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>ほろほろ鳥</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>七面鳥</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col :md="24" :lg="24" :xl="24" :xxl="24">
                <th>だちよう</th>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
                <td>
                  <a-form-item>
                    <a-input
                      v-model:value="formData.HENKAN_NINZU"
                      :maxlength="40"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
      </a-row>
      <a-row>
        <a-col span="24">
          <th>手数料率</th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.ZENKI_TUMITATE_DATE"
              :max="99"
              :min="1"
              class="w-full"
            >
              <template #addonAfter>%</template>
            </a-input-number>
          </td>
          <th>互助金交付率</th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.ZENKI_KOFU_DATE"
              :max="100"
              :min="1"
              class="w-full"
            >
              <template #addonAfter>%</template>
            </a-input-number>
          </td>
        </a-col>
      </a-row>
    </div>
  </a-card>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { reactive, watch } from 'vue'
import { PageStatus } from '@/enum'
import { DetailVM } from '../type'
import { useRoute, useRouter } from 'vue-router'
import { mathNumber } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  status: PageStatus
}>()
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageStatus.New
const formData = reactive<DetailVM>({
  KI: undefined as number | undefined,
  JIGYO_NENDO: undefined as number | undefined,
  JIGYO_SYURYO_NENDO: undefined as number | undefined,
  ZENKI_TUMITATE_DATE: '',
  ZENKI_KOFU_DATE: '',
  HENKAN_KEISAN_DATE: undefined as number | undefined,
  HENKAN_NINZU: '',
  HENKAN_GOKEI: '',
  HENKAN_RITU: '',
  TAISYO_NENDO: undefined as number | undefined,
  NOFU_KIGEN: '',
  HASSEI_KAISU: undefined as number | undefined,
  BIKO: undefined as number | undefined,
  START_DATE: '',
  END_DATE: '',
})

const editJudge = new Judgement()
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
watch(
  () => formData,
  () => {
    editJudge.setEdited()
  }
)

watch(
  () => formData.JIGYO_NENDO,
  (newValue) => {
    if (newValue) {
      formData.JIGYO_SYURYO_NENDO = newValue + 2
    }
  },
  { immediate: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    router.push({ name: route.name })
  })
}

// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}
</script>
<style lang="scss" scoped>
th {
  width: 200px;
  border-right: 1px solid #8a8d92 !important;
}
</style>
