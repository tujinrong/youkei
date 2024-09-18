<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ4012）経営支援互助金申請明細入力・算定（算定条件入力）"
    width="1200px"
    :body-style="{ height: '800px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <a-radio-group v-model:value="tab" class="mb-2">
      <a-radio :value="1">申請者名等</a-radio>
      <a-radio :value="2">農場別種類別互助金申請明細登録</a-radio>
    </a-radio-group>
    <div v-show="tab === 1" class="edit_table form w-full">
      <a-row>
        <a-col span="24">
          <read-only-pop
            th="契約者番号"
            thWidth="110"
            :td="formData.KEIYAKUSYA_CD"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only-pop
            thWidth="110"
            th="契約区分"
            td=""
            :td="formData.KEIYAKUSYA_NAME"
          />
        </a-col>
      </a-row>
    </div>
    <div v-if="tab === 2" class="edit_table form w-full">
      <a-row>
        <a-col span="8">
          <read-only-pop th="対象農場名" thWidth="110" :td="formData.KI" />
        </a-col>
        <a-col span="8">
          <read-only-pop th="鶏の種類" thWidth="110" :td="formData.KI" />
        </a-col>
        <a-col span="8">
          <read-only-pop th="契約羽数" thWidth="110" :td="formData.KI" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only-pop thWidth="110" th="住所" td="" :hideTd="true" />
          <read-only-pop thWidth="100" th="住所1" :td="formData.ADDR_1" />
          <read-only-pop thWidth="100" th="住所2" :td="formData.ADDR_2" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <read-only-pop thWidth="110" th="" :hideTd="true" />
          <read-only-pop thWidth="100" th="住所3" :td="formData.ADDR_3" />
          <read-only-pop thWidth="100" th="住所4" :td="formData.ADDR_4" />
        </a-col>
      </a-row>
      <div class="my-2 my-table">
        <table>
          <tr>
            <th style="width: 160px">補正区分</th>
            <th style="width: 160px">交付上限単価における</th>
            <th style="width: 30px"></th>
            <th style="width: 160px">
              交付対象農場における<br />1羽1ヶ月当たりの
            </th>
            <th style="width: 30px"></th>
            <th style="width: 160px">生産費における<br />1羽1ヶ月当たりの</th>
            <th style="width: 30px"></th>
            <th style="width: 140px">算定単価<br />(補正係数)</th>
          </tr>
          <tr>
            <th rowspan="2" style="text-align: left">①雇用労賃の補正</th>
            <th>(雇用労賃)</th>
            <th></th>
            <th>(雇用労賃)</th>
            <th></th>
            <th>(雇用労賃)</th>
            <th></th>
            <th></th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>×</td>
            <td>
              <a-input-number
                class="input"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
                style="width: 100%"
              />
            </td>
            <td>÷</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>＝</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          </tr>
          <tr>
            <th rowspan="2" style="text-align: left">②地代の補正</th>
            <th>(地代)</th>
            <th></th>
            <th>(地代)</th>
            <th></th>
            <th>(地代)</th>
            <th></th>
            <th></th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>×</td>
            <td>
              <a-input-number
                class="input"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
                style="width: 100%"
              />
            </td>
            <td>÷</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>＝</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          </tr>
          <tr>
            <th rowspan="2" style="text-align: left">③減価償却</th>
            <th>(減価償却)</th>
            <th></th>
            <th>(減価償却)</th>
            <th></th>
            <th>(減価償却)</th>
            <th></th>
            <th></th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>×</td>
            <td>
              <a-input-number
                class="input"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
                style="width: 100%"
              />
            </td>
            <td>÷</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>＝</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          </tr>
          <tr>
            <th rowspan="2" style="text-align: left; border-bottom: none">
              ④空舎期間の補正
            </th>
            <th colspan="3">⑥交付対象農場の可家畜導入計画における空舎期間</th>
            <th></th>
            <th style="text-align: left">⑦交付上限単価における空舎期間</th>
            <th></th>
            <th></th>
          </tr>
          <tr>
            <td colspan="3" style="border-bottom: none">
              <a-input-number
                class="input"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
                style="width: 100%"
              />
            </td>
            <td style="border-bottom: none">÷</td>
            <td style="border-bottom: none">
              {{ hasuGokei.SAIRANKEI_IKUSEIKEI }}
            </td>
            <td style="border-bottom: none">＝</td>
            <td style="border-bottom: none">{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          </tr>
        </table>
        <table>
          <tr>
            <th rowspan="2" style="width: 160px; text-align: left">
              互助金交付単価の算定
            </th>
            <th style="width: 100px">①</th>
            <th style="width: 25px"></th>
            <th style="width: 100px">②</th>
            <th style="width: 25px"></th>
            <th style="width: 100px">③</th>
            <th style="width: 30px"></th>
            <th style="width: 160px">④その他固定費</th>
            <th style="width: 30px"></th>
            <th style="width: 140px">⑤＝①＋②＋③﹢④</th>
            <th style="width: 140px">⑧＝⑤×⑥／⑦</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>＋</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>＋</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>＋</td>
            <td>
              <a-input-number
                class="input"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
                style="width: 100%"
              />
            </td>
            <td>＝</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          </tr>
        </table>
        <table>
          <tr>
            <th
              rowspan="2"
              style="width: 160px; text-align: left; border-top: none"
            >
              互助金交付単価の算定
            </th>
            <th style="width: 190px; border-top: none">別表２の交付上限単価</th>
            <th style="width: 190px; border-top: none">⑧算定交付上限単価</th>
            <th style="width: 190px; border-top: none">決定交付上限単価</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}30</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
          </tr>
        </table>
      </div>
      <table class="last-table">
        <tr>
          <th style="width: 150px">経営支援互助金 算定</th>
          <th style="width: 210px">対象羽数(導入羽数等)</th>
          <td style="width: 100px">
            <a-input-number
              class="input"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
              size="small"
              style="width: 100%"
            />
          </td>
          <th style="width: 30px; text-align: center">×</th>
          <th style="width: 130px">最終決定単価</th>
          <th style="width: 100px"></th>
          <th style="width: 30px; text-align: center">＝</th>
          <th style="width: 100px"></th>
          <th style="width: 150px">※1</th>
        </tr>
        <tr>
          <th style="text-align: left">家伝法違反減額</th>
          <th style="text-align: left">経営支援互助金 算定(※1)</th>
          <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
          <th style="text-align: center">×</th>
          <th>家伝法違反減額率</th>
          <td class="flex" style="border: none">
            <a-input-number
              class="input"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
              size="small"
              style="width: 100%"
            />%
          </td>
          <td style="text-align: center">＝</td>
          <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          <th>(円未満切り上げ)※2</th>
        </tr>
        <tr>
          <th rowspan="2" style="text-align: left">①積立金交付金額</th>
          <th rowspan="2" style="text-align: left">
            経営支援互助金 算定(※1-※2)
          </th>
          <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
          <th style="text-align: center">×</th>
          <th colspan="2" style="text-align: left" class="pl2">1/2</th>
          <td style="text-align: center">＝</td>
          <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          <th>(円未満切り上げ)※3</th>
        </tr>
        <tr>
          <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
          <th style="text-align: center">×</th>
          <th>互助金交付率</th>
          <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}%</td>
          <td style="text-align: center">＝</td>
          <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          <th>(円未満切り上げ)①</th>
        </tr>
        <tr>
          <th style="text-align: left">②国庫交付金額</th>
          <th style="text-align: left">経営支援互助金 算定(※1-※2)</th>
          <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
          <th style="text-align: center">—</th>
          <th>積立金交付金額※3</th>
          <td>
            <a-input-number
              class="input2"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
              size="small"
              style="width: 100%"
            />
          </td>
          <td style="text-align: center">＝</td>
          <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
          <th>②</th>
        </tr>
        <tr>
          <th style="text-align: left">③経営支援互助金</th>
          <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
          <td colspan="7" style="text-align: left">
            ①積立金交付金額 ＋ ②国庫交付金額
          </td>
        </tr>
        <tr>
          <th class="required" style="text-align: left">入力確認有無</th>
          <td colspan="3" style="text-align: left">
            <a-radio-group v-model:value="formData.SYORI_JOKYO_KBN">
              <a-radio :value="1">入力中</a-radio>
              <a-radio :value="2">審査中</a-radio>
              <a-radio :value="3">交付確定</a-radio>
            </a-radio-group>
          </td>
          <th style="text-align: left">確定年月日</th>
          <td colspan="4" style="text-align: left">
            <DateJp
              v-model:value="formData.TANKA_MST_DATE"
              :disabled="formData.SYORI_JOKYO_KBN !== 3"
            />
          </td>
        </tr>
      </table>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button @click="closeModal">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, ref, toRef, watch } from 'vue'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import { DetailVM, SearchRequest } from '../../type'
import { changeTableSort, mathNumber } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
const xTableRef = ref<VxeTableInstance>()
const formData = reactive<DetailVM>({
  TUMITATE_KBN: undefined as number | undefined,
  KEIYAKUSYA_CD: undefined as number | undefined,
  KEN_CD: undefined as number | undefined,
  KEN_CD_NAME: '',
  SYORI_JOKYO_KBN: 1,
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

const hasuGokei = reactive({
  SAIRANKEI_SEIKEI: undefined,
  SAIRANKEI_IKUSEIKEI: undefined,
  NIKUYOUKEI: undefined,
  SYUKEI_SEIKEI: undefined,
  SYUKEI_IKUSEIKEI: undefined,
  UZURA: undefined,
  AHIRU: undefined,
  KIJI: undefined,
  HOROHOROTORI: undefined,
  SICHIMENCHOU: undefined,
  DACHOU: undefined,
  TOTAL: undefined,
})

const tableData = ref<SearchRequest[]>([])

const editJudge = new Judgement()
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const tab = ref(1)
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
    tab.value = 1
    clearValidate()
    resetFields()
    emit('update:visible', false)
  })
}

// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}
</script>
<style lang="scss" scoped>
th {
  //min-width: 110px; //絶対変えられない
}
tr th {
  border: 1px solid rgb(190, 190, 190);
  // background-color: #ffffe1;
  font-weight: 100;
  padding: 2px 5px;
}
tr td {
  border: 1px solid rgb(190, 190, 190);
}
.my-table {
  tr th {
    text-align: center;
  }
  tr td {
    text-align: center;
  }
}
.last-table {
  tr th {
    text-align: left;
  }
  tr td {
    text-align: left;
  }
}
.input {
  background-color: #c0ffc0;
}
.input2 {
  background-color: #ffd700;
}
</style>
