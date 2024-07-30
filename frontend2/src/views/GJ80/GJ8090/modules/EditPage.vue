<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>契約者農場マスタメンテナンス</h1>
    <div class="self_adaption_table form max-w-160">
      <b>第{{ formData.KI }}期</b>
      <a-form>
        <a-row>
          <a-col span="24">
            <th>契約者</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="formData.KEIYAKUSYA_CD"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  disabled
                  type="number"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <div class="my-2 header_operation flex justify-between w-full">
          <a-space :size="20">
            <a-button class="warning-btn" @click="saveData">登録</a-button>
            <a-button
              type="primary"
              danger
              :disabled="isNew"
              @click="deleteData"
              >削除</a-button
            >
            <!-- <a-button v-if="!isNew" :icon="h(LeftOutlined)"></a-button
          ><span v-if="!isNew">2/5</span>
          <a-button v-if="!isNew" :icon="h(RightOutlined)"></a-button> -->
          </a-space>
          <a-button type="primary" class="text-end" @click="goList"
            >一覧へ</a-button
          >
        </div>
        <b>契約者農場基本登録項目</b>
        <a-row>
          <a-col span="24">
            <th class="required">契約者農場</th>
            <td>
              <a-form-item v-bind="validateInfos.NOJO_CD">
                <a-input-number
                  v-model:value="formData.NOJO_CD"
                  :min="0"
                  :max="999"
                  :maxlength="3"
                  :disabled="!isNew"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th class="required">農場名称</th>
            <td>
              <a-form-item v-bind="validateInfos.NOJO_NAME">
                <a-input
                  v-model:value="formData.NOJO_NAME"
                  :maxlength="20"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
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
          <a-col span="24">
            <th class="required">明細番号</th>
            <td>
              <a-form-item v-bind="validateInfos.MEISAINO">
                <a-input-number
                  v-model:value="formData.MEISAINO"
                  :min="0"
                  :max="999"
                  :maxlength="3"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </a-form>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { PageSatatus } from '@/enum'
import { nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { showDeleteModal, showInfoModal } from '@/utils/modal'
import {
  DELETE_OK_INFO,
  ITEM_REQUIRE_ERROR,
  SAVE_OK_INFO,
} from '@/constants/msg'
import { Form, message } from 'ant-design-vue'
import { showSaveModal } from '@/utils/modal'
import PostCode from '@/components/Selector/PostCode/index.vue'
import { convertToFullWidth } from '@/utils/util'
import { KeiyakuNojoSearchDetailVM } from '../type'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
  KI: number
  KEIYAKUSYA_CD: number
  NOJO_CD: number | undefined
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageSatatus.New

const keiyakuNojoSearchDetail = reactive({
  KI: props.KI,
  KEIYAKUSYA_CD: props.KEIYAKUSYA_CD,
  NOJO_CD: props.NOJO_CD,
  KEIYAKUSYA_NAME: '',
  NOJO_NAME: '東京都千代田区農場',
  KEN_CD: 13,
  ADDR_POST: '100-0001',
  ADDR_1: '東京都',
  ADDR_2: '千代田区',
  ADDR_3: '丸の内',
  ADDR_4: '1丁目1-1',
  MEISAINO: 234,
} as KeiyakuNojoSearchDetailVM & {
  KI: number
  KEIYAKUSYA_CD: number
  NOJO_CD: number | undefined
})

const fakeFormData1 = reactive({
  KI: props.KI,
  KEIYAKUSYA_CD: props.KEIYAKUSYA_CD,
  NOJO_CD: undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_NAME: '',
  KEN_CD: undefined as number | undefined,
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  MEISAINO: undefined as number | undefined,
} as KeiyakuNojoSearchDetailVM & {
  KI: number
  KEIYAKUSYA_CD: number
  NOJO_CD: number | undefined
})

const formData = reactive(fakeFormData1)

const KEIYAKUSYA_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '永玉田中' },
  { value: 2, label: '尾三玉田' },
  { value: 3, label: '史玉浅海' },
])

const KEN_CD_NAME_LIST = ref<DaSelectorModel[]>([
  { value: 1, label: '北海道' },
  { value: 2, label: '青森県' },
  { value: 3, label: '岩手県' },
  { value: 4, label: '宮城県' },
  { value: 5, label: '秋田県' },
  { value: 6, label: '山形県' },
  { value: 7, label: '福島県' },
  { value: 8, label: '茨城県' },
  { value: 9, label: '栃木県' },
  { value: 10, label: '群馬県' },
  { value: 11, label: '埼玉県' },
  { value: 12, label: '千葉県' },
  { value: 13, label: '東京都' },
  { value: 14, label: '神奈川県' },
  { value: 15, label: '新潟県' },
  { value: 16, label: '富山県' },
  { value: 17, label: '石川県' },
  { value: 18, label: '福井県' },
  { value: 19, label: '山梨県' },
  { value: 20, label: '長野県' },
  { value: 21, label: '岐阜県' },
  { value: 22, label: '静岡県' },
  { value: 23, label: '愛知県' },
  { value: 24, label: '三重県' },
  { value: 25, label: '滋賀県' },
  { value: 26, label: '京都府' },
  { value: 27, label: '大阪府' },
  { value: 28, label: '兵庫県' },
  { value: 29, label: '奈良県' },
  { value: 30, label: '和歌山県' },
  { value: 31, label: '鳥取県' },
  { value: 32, label: '島根県' },
  { value: 33, label: '岡山県' },
  { value: 34, label: '広島県' },
  { value: 35, label: '山口県' },
  { value: 36, label: '徳島県' },
  { value: 37, label: '香川県' },
  { value: 38, label: '愛媛県' },
  { value: 39, label: '高知県' },
  { value: 40, label: '福岡県' },
  { value: 41, label: '佐賀県' },
  { value: 42, label: '長崎県' },
  { value: 43, label: '熊本県' },
  { value: 44, label: '大分県' },
  { value: 45, label: '宮崎県' },
  { value: 46, label: '鹿児島県' },
  { value: 47, label: '沖縄県' },
])

const rules = reactive({
  NOJO_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場番号'),
    },
  ],
  NOJO_NAME: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '農場名称'),
    },
  ],
  KEN_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '都道府県'),
    },
  ],
  ADDR_POST: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号'),
    },
  ],
  ADDR_2: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所2'),
    },
  ],
  MEISAINO: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '明細番号'),
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
onMounted(async () => {
  if (props.status === PageSatatus.Edit) {
    Object.assign(formData, keiyakuNojoSearchDetail)
  }
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.status,
  () => Object.assign(formData, keiyakuNojoSearchDetail),
  { deep: true }
)

//都道府県を選択した場合、住所（住所１）の値をセットする
watch(
  () => formData.KEN_CD,
  (newVal) => {
    formData.ADDR_1 =
      KEN_CD_NAME_LIST.value.find((item) => item.value === newVal)?.label || ''
  }
)

watch(
  () => [formData.NOJO_NAME, formData.ADDR_2, formData.ADDR_3, formData.ADDR_4],
  ([newNOJO_NAME, newADDR_2, newADDR_3, newADDR_4]) => {
    formData.NOJO_NAME = convertToFullWidth(newNOJO_NAME)
    formData.ADDR_2 = convertToFullWidth(newADDR_2)
    formData.ADDR_3 = convertToFullWidth(newADDR_3)
    formData.ADDR_4 = convertToFullWidth(newADDR_4)
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  clearValidate()
  resetFields()
  router.push({ name: route.name as string })
}
const saveData = async () => {
  if (isNew) {
    switch (formData.NOJO_CD) {
      case 100:
      case 101:
      case 102:
      case 103:
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: '入力されたコードは、すでに登録されています。',
        })
        return
        break
    }
    await validate()
    showSaveModal({
      content: 'データを登録します。\nよろしいですか？',
      onOk: () => {
        router.push({ name: route.name as string })
        message.success(SAVE_OK_INFO.Msg)
      },
    })
  } else {
    await validate()
    showSaveModal({
      content: 'データを更新します。\nよろしいですか？',
      onOk: () => {
        router.push({ name: route.name as string })
        message.success(SAVE_OK_INFO.Msg)
      },
    })
  }
}
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    content: '指定されたデータを削除します。\nよろしいですか？',
    onOk() {
      router.push({ name: route.name as string })
      message.success(DELETE_OK_INFO.Msg)
    },
  })
}
</script>

<style scoped lang="scss">
th {
  width: 130px;
}
h1 {
  font-size: 24px;
}
:deep(.ant-form-item) {
  width: 100%;
  margin-bottom: 0;
}
</style>
