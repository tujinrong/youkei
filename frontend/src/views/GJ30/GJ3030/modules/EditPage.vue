<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="（GJ3031）互助基金契約者情報変更（讓渡） 請求書発行"
    width="800px"
    :body-style="{ height: '450px', paddingTop: '30px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="self_adaption_table form mt-1 max-w-250">
      <b>第 {{ searchParams.KI }} 期</b>

      <a-row
        ><a-col :span="24"
          ><read-only
            th="契約者"
            th-width="100"
            td="47074:亜伊伊伊伊（伊）"
          ></read-only
        ></a-col>
      </a-row>
      <a-row
        ><a-col :span="24"
          ><th>出力区分</th>
          <td>
            <a-radio-group
              v-model:value="searchParams.SYUTURYOKU_KBN"
              class="mt-1"
            >
              <a-radio :value="1">仮発行</a-radio>
              <a-radio :value="2">初回発行</a-radio>
              <a-radio :value="3">再発行(初回と同内容)</a-radio>
              <a-radio :value="4"
                >修正発行(納付期限、発行日、発行番号変更可能)</a-radio
              >
              <a-radio :value="5">通知書取消</a-radio>
            </a-radio-group>
          </td></a-col
        ></a-row
      >
      <a-col :span="24"
        ><th class="required">納付期限</th>
        <td>
          <a-form-item v-bind="validateInfos.NOFUKIGEN_DATE">
            <DateJp
              v-model:value="searchParams.NOFUKIGEN_DATE"
              :disabled="!hakou"
              class="max-w-50"
            ></DateJp
          ></a-form-item></td></a-col
      ><a-col :span="24"
        ><th class="required">発行日</th>
        <td>
          <a-form-item v-bind="validateInfos.SEIKYU_HAKKO_DATE">
            <DateJp
              v-model:value="searchParams.SEIKYU_HAKKO_DATE"
              :disabled="!hakou"
              class="max-w-50"
            ></DateJp
          ></a-form-item></td
      ></a-col>
      <a-row
        ><a-col :span="24"
          ><th class="required">発信番号</th>
          <td>
            <a-form-item
              v-bind="validateInfos.SEIKYU_HAKKO_NO_NEN"
              class="w-40!"
              >日鶏
              <a-input
                v-model:value="searchParams.SEIKYU_HAKKO_NO_NEN"
                :disabled="!hakou"
                class="w-14!"
                :maxlength="2"
              ></a-input>
              発</a-form-item
            >
            <a-form-item v-bind="validateInfos.SEIKYU_HAKKO_NO_RENBAN"
              >第
              <a-input
                v-model:value="searchParams.SEIKYU_HAKKO_NO_RENBAN"
                :disabled="!hakou"
                class="w-17!"
                :maxlength="4"
              ></a-input>
              号</a-form-item
            >
          </td></a-col
        ></a-row
      >
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button type="primary">プレビュー</a-button>
          <a-button type="primary" :disabled="searchParams.SYUTURYOKU_KBN !== 5"
            >通知書取消</a-button
          >
          <a-button type="primary">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template></a-modal
  >
</template>
<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { PageStatus } from '@/enum'
import { Form } from 'ant-design-vue'
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: 8,
    KEIYAKUSYA_CD: undefined,
    SEIKYU_KAISU: 2,
    TUMITATE_KBN: 1,
    SYUTURYOKU_KBN: 1,
    NOFUKIGEN_DATE: undefined,
    SEIKYU_HAKKO_DATE: undefined,
    SEIKYU_HAKKO_NO_NEN: undefined,
    SEIKYU_HAKKO_NO_RENBAN: undefined,
  }
}
const searchParams = reactive(createDefaultParams())
const KEIYAKUSYA = ref('')
const router = useRouter()
const route = useRoute()

const LIST = ref<CmCodeNameModel[]>([])
const rules = reactive({
  NOFUKIGEN_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '納付期限'),
    },
  ],
  SEIKYU_HAKKO_DATE: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '発行日'),
    },
  ],
  SEIKYU_HAKKO_NO_NEN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '発信番号'),
    },
  ],
  SEIKYU_HAKKO_NO_RENBAN: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '発信番号'),
    },
  ],
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const hakou = computed(() => {
  return searchParams.SYUTURYOKU_KBN === 2 || searchParams.SYUTURYOKU_KBN === 4
})
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
//画面遷移
const closeModal = () => {
  clearValidate()
  modalVisible.value = false
}
const goList = () => {
  closeModal()
}
</script>

<style lang="scss" scoped>
th {
  width: 100px;
}
</style>
