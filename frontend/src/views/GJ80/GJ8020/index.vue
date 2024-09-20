<template>
  <div>
    <a-card :bordered="false" class="mb-4 h-full">
      <h1>（GJ8020）処理対象期・年度マスタメンテナンス</h1>
      <div class="my-4 flex justify-between">
        <a-space :size="20">
          <a-button class="warning-btn" @click="save">保存</a-button>
          <a-button type="primary" @click="cancel">キャンセル</a-button>
        </a-space>
        <close-page />
      </div>
      <div class="self_adaption_table form">
        <a-row>
          <a-col span="24">
            <th class="required">事業対象期·年度</th>
            <td>
              <a-form-item v-bind="validateInfos.KI" class="w-70!">
                <a-input-number
                  class="w-20"
                  name="KI"
                  v-model:value="formData.KI"
                  :max="99"
                  :min="1"
                  :maxlength="2"
                >
                </a-input-number
                ><span class="!align-middle ml-2">期</span></a-form-item
              >
              <div class="w-full">
                <YearSelector
                  v-model:value="formData.JIGYO_NENDO"
                  class="w-50"
                /><span>～</span>
                <YearSelector
                  v-model:value="formData.JIGYO_SYURYO_NENDO"
                  class="w-50"
                  disabled
                />
              </div>
            </td>
          </a-col>
          <a-col span="24">
            <th>1.前期積立金取込日</th>
            <td>
              <DateJp
                v-model:value="formData.ZENKI_TUMITATE_DATE"
                class="w-50!"
              />
            </td>
          </a-col>
          <a-col span="24">
            <th>2.前期交付金取込日</th>
            <td>
              <DateJp v-model:value="formData.ZENKI_KOFU_DATE" class="w-50!" />
            </td>
          </a-col>
          <a-col span="24">
            <th>3.返還金計算日</th>
            <td>
              <DateJp
                v-model:value="formData.HENKAN_KEISAN_DATE"
                class="w-50!"
              />
            </td>
          </a-col>
          <a-col span="24">
            <th>積立金返還人数</th>
            <td>
              <a-input-number
                v-model:value="formData.HENKAN_NINZU"
                class="w-20"
                :max="9999"
                :min="0"
                disabled
              >
              </a-input-number
              ><span class="mt-1 ml-2">(人)</span>
            </td>
          </a-col>
          <a-col span="24">
            <th>積立金返還額合計</th>
            <td class="flex items-center">
              <a-input-number
                v-model:value="formData.HENKAN_GOKEI"
                class="w-50!"
                :max="999999999999999"
                :min="0"
                disabled
              >
              </a-input-number
              ><span class="mt-1 mr-5"> (円) </span
              ><span>(左記項目は積立金返還処理で算定した结果を保存、表示)</span>
            </td> </a-col
          ><a-col span="24">
            <th>前期積立金返還率</th>
            <td>
              <a-form-item>
                <a-input-number
                  v-model:value="formData.HENKAN_RITU"
                  class="w-20"
                  :max="99"
                  :min="0"
                  disabled
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col span="24">
            <th class="required">対象年度(現在処理中)</th>
            <td>
              <a-form-item v-bind="validateInfos.TAISYO_NENDO">
                <YearSelector
                  v-model:value="formData.TAISYO_NENDO"
                  class="w-30!"
                />
              </a-form-item>
            </td>
          </a-col>

          <a-col span="24">
            <th>当初対象積立金納付期限</th>
            <td>
              <DateJp v-model:value="formData.NOFU_KIGEN" class="w-50!" />
              <span class="mt-1">
                (左記期限までに入金済みの時は、契約日は4月1日となる。)</span
              >
            </td>
          </a-col>
          <a-col span="24">
            <th>現在の認定回数</th>
            <td>
              <a-input-number
                v-model:value="formData.HASSEI_KAISU"
                class="w-20"
                :max="99"
                :min="1"
                :maxlength="2"
              >
              </a-input-number
              ><span class="mt-1 ml-1">回</span>
            </td>
          </a-col>
          <a-col span="24">
            <th>備考</th>
            <td>
              <a-input v-model:value="formData.BIKO" :maxlength="80"></a-input>
            </td>
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
import { InitDetail, Save } from './service'
import { DetailVM } from './type'
import {
  CLOSE_CONFIRM,
  ITEM_REQUIRE_ERROR,
  SAVE_CONFIRM,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { showConfirmModal, showSaveModal } from '@/utils/modal'

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
})

const editJudge = new Judgement('GJ8020')

/** ルール */
const rules = reactive({
  KI: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事業対象期'),
    },
  ],
  TAISYO_NENDO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '対象年度'),
    },
  ],
})
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)

onMounted(async () => {
  init()
})

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

/** 初期化処理 */
const init = async () => {
  const res = await InitDetail({})
  Object.assign(formData, res.SYORI_KI)
}

/** 登録処理 */
const save = async () => {
  await validate()
  showSaveModal({
    content: SAVE_CONFIRM.Msg,
    onOk: async () => {
      try {
        await Save({ SYORI_KI: formData })
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
      init()
    },
  })
}
</script>
<style lang="scss" scoped>
th {
  width: 200px;
}
</style>
