<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ2091）契約者積立金等入金・返還確認"
    width="1000px"
    :body-style="{ height: '800px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="parent-container">
      <div class="edit_table form w-full">
        <a-row>
          <a-col span="8">
            <read-only-pop
              th="契約者番号"
              thWidth="140"
              :td="formData.KEIYAKUSYA_CD"
            />
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="都道府県"
              thWidth="110"
              :td="formData.KEN_CD_NAME"
            />
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="処理状況"
              thWidth="110"
              :td="formData.SYORI_JOKYO_KBN_NAME"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop
              thWidth="140"
              th="契約者名"
              td=""
              :td="formData.KEIYAKUSYA_NAME"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="" :hideTd="true" />
            <read-only-pop :hideTh="true" :td="formData.KEIYAKUSYA_KANA" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="住所" :hideTd="true" />
            <read-only-pop th="　〒　" :td="formData.ADDR_POST" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="" :td="formData.ADDR" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="10">
            <read-only-pop th="連絡先" thWidth="140" :hideTd="true" />
            <read-only-pop th="電話1" thWidth="80" :td="formData.ADDR_TEL1" />
          </a-col>
          <a-col span="7">
            <read-only-pop th="電話2" thWidth="80" :td="formData.ADDR_TEL2" />
          </a-col>
          <a-col span="7">
            <read-only-pop th="FAX" thWidth="80" :td="formData.ADDR_FAX" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="振込・返還口座情報" :hideTd="true" />
            <read-only-pop thWidth="130" th="金融機関" :td="formData.BANK_NAME" />
            <read-only-pop thWidth="130" th="支店" :td="formData.SITEN_NAME" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="" :hideTd="true" />
            <read-only-pop
              thWidth="130"
              th="口座種別"
              :td="formData.FURI_KOZA_SYUBETU_NAME"
            />
            <read-only-pop
              thWidth="130"
              th="口座番号"
              :td="formData.FURI_KOZA_NO"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop thWidth="140" th="" :hideTd="true" />
            <read-only-pop
              thWidth="130"
              th="口座名義人(カナ)"
              :td="formData.FURI_KOZA_MEIGI_KANA"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop
              th="事務委託先"
              thWidth="140"
              :td="formData.JIMUITAKU_CD"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop
              th="事務委託先名"
              thWidth="140"
              :td="formData.ITAKU_NAME"
            />
          </a-col>
        </a-row>
        <h2 class="mt3 mb1">請求入金内容</h2>
        <a-row>
          <a-col span="24">
            <read-only-pop th="対象期" thWidth="140" :td="formData.KI" />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8">
            <read-only-pop
              th="請求・返還日"
              thWidth="140"
              :td="formData.SEIKYU_DATE"
            />
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="請求・返還回数"
              thWidth="110"
              :td="formData.SEIKYU_KAISU"
              after="回"
            />
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="請求・返還区分"
              thWidth="110"
              :td="formData.SEIKYU_HENKAN_KBN_NAME"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8">
            <th class="required" style="width: 140px">入金・振込日</th>
            <td>
              <a-form-item v-bind="validateInfos.NYUKIN_DATE">
                <DateJp v-model:value="formData.NYUKIN_DATE" />
              </a-form-item>
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop
              thWidth="140"
              th="請求・返還金額"
              :td="formData.SAGUKU_SEIKYU_KIN"
              v-bind="{ ...mathNumber }"
              after="円"
            />
            <read-only-pop
              thWidth="130"
              th="積立金額"
              :td="formData.TUMITATE_KIN"
              v-bind="{ ...mathNumber }"
              after="円"
            />
            <read-only-pop
              thWidth="130"
              th="手数料"
              :td="formData.TESURYO"
              v-bind="{ ...mathNumber }"
              after="円"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8" :offset="16">
            <read-only-pop
              thWidth="130"
              th="積立金等総計"
              :td="formData.SEIKYU_KIN"
              after="円"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th style="width: 140px">備考</th>
            <td>
              <a-input v-model:value="formData.BIKO"></a-input>
            </td>
          </a-col>
        </a-row>
      </div>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">入金登録</a-button>
          <a-button :disabled="!formData.NYUKIN_DATE" @click="closeModal"
            >入金取消</a-button
          >
          <a-button :disabled="!formData.NYUKIN_DATE" @click="openGJ2092"
            >分割入金</a-button
          >
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <Detail2 v-model:visible="GJ2092Visible" :editkbn="GJ2092kbn" />
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, watch, ref } from 'vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import { DetailVM } from '../../type'
import { useRoute, useRouter } from 'vue-router'
import { mathNumber } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import Detail2 from '@/views/GJ20/GJ2090/modules/Detail/Detail2.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
const router = useRouter()
const route = useRoute()
const formData = reactive<DetailVM>({
  TUMITATE_KBN: undefined as number | undefined,
  KEIYAKUSYA_CD: undefined as number | undefined,
  KEN_CD: undefined as number | undefined,
  KEN_CD_NAME: '',
  SYORI_JOKYO_KBN: undefined as number | undefined,
  SYORI_JOKYO_KBN_NAME: '',
  KEIYAKUSYA_NAME: '',
  KEIYAKUSYA_KANA: '',
  ADDR_POST: '',
  ADDR: '',
  ADDR_TEL1: '',
  ADDR_TEL2: '',
  ADDR_FAX: '',
  FURI_BANK_CD: '',
  BANK_NAME: '',
  FURI_BANK_SITEN_CD: '',
  SITEN_NAME: '',
  FURI_KOZA_SYUBETU: undefined as number | undefined,
  FURI_KOZA_SYUBETU_NAME: '',
  FURI_KOZA_NO: '',
  FURI_KOZA_MEIGI_KANA: '',
  JIMUITAKU_CD: undefined as number | undefined,
  ITAKU_NAME: '',
  KI: undefined as number | undefined,
  SEIKYU_DATE: undefined as Date | undefined,
  SEIKYU_KAISU: undefined as number | undefined,
  SEIKYU_HENKAN_KBN: undefined as number | undefined,
  SEIKYU_HENKAN_KBN_NAME: '',
  NYUKIN_DATE: undefined as Date | undefined,
  SAGUKU_SEIKYU_KIN: undefined as number | undefined,
  TUMITATE_KIN: undefined as number | undefined,
  TESURYO: undefined as number | undefined,
  SEIKYU_KIN: undefined as number | undefined,
  BIKO: '',
})

const editJudge = new Judgement()
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const GJ2092Visible = ref(false)
const GJ2092kbn = ref<EnumEditKbn>(EnumEditKbn.Add)

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
      nextTick(() => editJudge.reset())
    }
  }
)
watch(
  () => formData,
  () => {
    editJudge.setEdited()
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  closeModal()
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    emit('update:visible', false)
  })
}

function openGJ2092(row?: any) {
  GJ2092Visible.value = true
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
.edit_table .ant-col {
  align-items: center;
}
</style>
