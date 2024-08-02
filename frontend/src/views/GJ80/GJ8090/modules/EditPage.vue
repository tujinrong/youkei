<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>契約者農場マスタメンテナンス</h1>
    <div class="self_adaption_table form max-w-160">
      <b>第{{ formData.KI }}期</b>
      <a-form>
        <a-row>
          <a-col span="24">
            <th class="bg-readonly">契約者</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="formData.KEIYAKUSYA_NAME"
                  :maxlength="20"
                  disabled
                ></a-input>
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
            <th :class="!isNew ? 'bg-readonly' : 'required'">契約者農場</th>
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
  ITEM_ILLEGAL_ERROR,
  ITEM_REQUIRE_ERROR,
  SAVE_OK_INFO,
} from '@/constants/msg'
// import { KEN_CD_NAME_LIST } from '../constant'
import { Form, message } from 'ant-design-vue'
import { showSaveModal } from '@/utils/modal'
import PostCode from '@/components/Selector/PostCode/index.vue'
import { convertToFullWidth } from '@/utils/util'
import { KeiyakuNojoSearchDetailVM } from '../type'
import { Judgement } from '@/utils/judge-edited'
import { InitDetail, SearchDetail } from '../service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
  // KI: number|undefined
  // KEIYAKUSYA_CD: number|undefined
  // NOJO_CD: number|undefined
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const isNew = props.status === PageSatatus.New
const editJudge = new Judgement()

const KEN_CD_NAME_LIST = ref<DaSelectorModel[]>([])

const formData = reactive({
  KI: undefined as number | undefined,
  KEIYAKUSYA_CD: undefined as number | undefined,
  NOJO_CD: undefined as number | undefined,
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
  NOJO_CD: number
  KEIYAKUSYA_NAME: string
})
const keyakusyaList = ref<DaSelectorModel[]>([
  { value: 1, label: '永玉田中' },
  { value: 2, label: '尾三玉田' },
  { value: 3, label: '史玉浅海' },
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
      validator: async (_rule, value: string) => {
        if (!value) {
          return Promise.reject(
            ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号')
          )
        } else if (value.replace(/[^0-9]/g, '').length < 7) {
          return Promise.reject(
            ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '郵便番号')
          )
        }
        return Promise.resolve()
      },
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
  if (route.query.KI) {
    formData.KI = +route.query.KI
  }
  if (route.query.KEIYAKUSYA_CD) {
    formData.KEIYAKUSYA_CD = +route.query.KEIYAKUSYA_CD
  }
  if (route.query.NOJO_CD) {
    formData.NOJO_CD = +route.query.NOJO_CD
  }
  await InitDetail().then((res) => {
    formData.KEIYAKUSYA_NAME =
      formData.KEIYAKUSYA_CD +
      ' : ' +
      keyakusyaList.value.find((el) => el.value == formData.KEIYAKUSYA_CD)
        ?.label
    KEN_CD_NAME_LIST.value = res.KEN_CD_NAME_LIST
  })
  if (props.status === PageSatatus.Edit) {
    await SearchDetail({
      KI: formData.KI,
      KEIYAKUSYA_CD: formData.KEIYAKUSYA_CD,
      NOJO_CD: formData.NOJO_CD,
    }).then((res) => {
      formData.NOJO_NAME = res.KEIYAKUSYA_NOJO.NOJO_NAME
      formData.KEN_CD = res.KEIYAKUSYA_NOJO.KEN_CD
      formData.ADDR_POST = res.KEIYAKUSYA_NOJO.ADDR_POST
      formData.ADDR_1 = res.KEIYAKUSYA_NOJO.ADDR_1
      formData.ADDR_2 = res.KEIYAKUSYA_NOJO.ADDR_2
      formData.ADDR_3 = res.KEIYAKUSYA_NOJO.ADDR_3
      formData.ADDR_4 = res.KEIYAKUSYA_NOJO.ADDR_4
      formData.MEISAINO = res.KEIYAKUSYA_NOJO.MEISAINO
    })
  }
  nextTick(() => editJudge.reset())
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(formData, () => editJudge.setEdited())

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
  editJudge.judgeIsEdited(() => {
    // clearValidate()
    // resetFields()
    router.push({ name: route.name })
  })
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
    }
    await validate()
    showSaveModal({
      content: 'データを登録します。\nよろしいですか？',
      onOk: () => {
        router.push({ name: route.name })
        message.success(SAVE_OK_INFO.Msg)
      },
    })
  } else {
    await validate()
    showSaveModal({
      content: 'データを更新します。\nよろしいですか？',
      onOk: () => {
        router.push({ name: route.name })
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
      router.push({ name: route.name })
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
