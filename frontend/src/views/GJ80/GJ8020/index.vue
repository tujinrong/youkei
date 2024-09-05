<template>
  <a-card :bordered="false" class="mb-4 h-full">
    <h1>(GJ8020)処理対象期・年度マスタメンテナンス</h1>
    <div class="my-4 flex justify-between">
      <a-space :size="20">
        <a-button class="warning-btn" @click="save">保存</a-button>
        <a-button type="primary" danger @click="cancel">キャンセル</a-button>
      </a-space>
      <close-page />
    </div>
    <div class="self_adaption_table form max-w-240">
      <a-row :gutter="[0, 16]">
        <a-col span="24">
          <th class="required">事業対象期·年度</th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.KI"
              style="width: 33.3%"
              :max="99"
              :min="1"
            >
              <template #addonAfter>期</template>
            </a-input-number>
            <YearJp
              v-model:value="formData.JIGYO_NENDO"
              style="width: 33.3%"
            /><span>～</span>
            <YearJp
              v-model:value="formData.JIGYO_SYURYO_NENDO"
              style="width: 33.3%"
              disabled
            />
          </td>
        </a-col>
        <a-col span="24">
          <th>1.前期積立金取込日</th>
          <td>
            <a-form-item>
              <DateJp
                v-model:value="formData.ZENKI_TUMITATE_DATE"
                style="width: 33.3%"
              />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>2.前期交付金取込日</th>
          <td>
            <a-form-item>
              <DateJp
                v-model:value="formData.ZENKI_KOFU_DATE"
                style="width: 33.3%"
              />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>3.返還金計算日</th>
          <td>
            <a-form-item>
              <DateJp
                v-model:value="formData.HENKAN_KEISAN_DATE"
                style="width: 33.3%"
              />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>積立金返還人数</th>
          <td>
            <a-form-item>
              <a-input-number
                v-model:value="formData.HENKAN_NINZU"
                style="width: 33.3%"
                :max="9999"
                :min="0"
                disabled
              >
                <template #addonAfter> (人) </template></a-input-number
              >
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>積立金返還額合計</th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.HENKAN_GOKEI"
              style="width: 33.3%"
              :max="999999999"
              :min="0"
              disabled
            >
              <template #addonAfter> (円) </template> </a-input-number
            ><span>(左記項目は積立金返還処理で算定した结果を保存、表示)</span>
          </td> </a-col
        ><a-col span="24">
          <th>前期積立金返還率</th>
          <td>
            <a-form-item>
              <a-input-number
                v-model:value="formData.HENKAN_RITU"
                style="width: 33.3%"
                :precision="7"
                :max="99.9999999"
                :min="0"
                disabled
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">対象年度(現在処理中)</th>
          <td>
            <a-form-item>
              <YearJp
                v-model:value="formData.TAISYO_NENDO"
                style="width: 33.3%"
              />
            </a-form-item>
          </td>
        </a-col>

        <a-col span="24">
          <th>当初対象積立金納付期限</th>
          <td>
            <a-form-item>
              <DateJp
                v-model:value="formData.NOFU_KIGEN"
                style="width: 33.3%"
              />
              (左記期限までに入金済みの時は、契約日は4月1 日となる。)
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>現在の認定回数</th>
          <td>
            <a-input-number
              v-model:value="formData.HASSEI_KAISU"
              style="width: 33.3%"
              :max="99"
              :min="1"
            >
              <template #addonAfter> 回 </template></a-input-number
            >
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
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form, message } from 'ant-design-vue'
import { onMounted, reactive, watch } from 'vue'
import { InitDetail, Save } from './service'
import { DetailVM } from './type'
import { CLOSE_CONFIRM, SAVE_CONFIRM, SAVE_OK_INFO } from '@/constants/msg'
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
const rules = {}
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
  try {
    showSaveModal({
      content: SAVE_CONFIRM.Msg,
      onOk: async () => {
        try {
          await Save({ SYORI_KI: formData })
          message.success(SAVE_OK_INFO.Msg)
        } catch (error) {}
      },
    })
  } catch (error) {}
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
