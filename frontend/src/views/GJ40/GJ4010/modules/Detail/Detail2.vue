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
    <div class="edit_table form w-full">
      <a-row>
        <a-col span="12">
          <read-only-pop
            th="契約者番号"
            thWidth="110"
            :td="formData.KEIYAKUSYA_CD"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="12">
          <read-only-pop
            thWidth="110"
            th="契約区分"
            td=""
            :td="formData.KEIYAKUSYA_NAME"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="8">
          <read-only-pop th="対象農場名" thWidth="110" :td="formData.KI" />
        </a-col>
        <a-col span="6" push="1">
          <read-only-pop th="鶏の種類" thWidth="70" :td="formData.KI" />
        </a-col>
        <a-col span="6" push="2">
          <read-only-pop th="契約羽数" thWidth="70" :td="formData.KI" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="2">
          <read-only-pop thWidth="110" th="住所" td="" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop thWidth="50" th="住所1" :td="formData.ADDR_1" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="7">
          <read-only-pop thWidth="50" th="住所2" :td="formData.ADDR_2" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="2">
          <read-only-pop thWidth="110" th="" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop thWidth="50" th="住所3" :td="formData.ADDR_3" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="7">
          <read-only-pop thWidth="50" th="住所4" :td="formData.ADDR_4" />
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
                class="input w-full"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
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
                class="input w-full"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
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
                class="input w-full"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
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
                class="input w-full"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
              />
            </td>
            <td style="border-bottom: none">÷</td>
            <td style="border-bottom: none">
              {{ hasuGokei.SAIRANKEI_IKUSEIKEI }}
            </td>
            <td style="border-bottom: none">＝</td>
            <td style="border-bottom: none">
              {{ hasuGokei.SYUKEI_SEIKEI }}
            </td>
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
                class="input w-full"
                v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                :min="1"
                size="small"
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
      <a-row>
        <a-col span="4">
          <read-only-pop
            thWidth="150"
            th="経営支援互助金 算定"
            :hideTd="true"
          />
        </a-col>
        <a-col span="8">
          <th style="width: 210px">対象羽数(導入羽数等)</th>
          <td style="align-items: center">
            <a-input-number
              class="input w-full"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
            />
          </td>
        </a-col>
        <a-col span="0.5">
          <span class="symbol">×</span>
        </a-col>
        <a-col span="5">
          <read-only-pop
            thWidth="100"
            th="最終決定単価"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
          />
        </a-col>
        <a-col span="6">
          <read-only-pop
            th="＝"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
            after="※1&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4">
          <read-only-pop th="家伝法違反減額" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop
            thWidth="210"
            th="経営支援互助金 算定(※1)"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
          />
        </a-col>
        <a-col span="0.5">
          <span class="symbol">×</span>
        </a-col>
        <a-col span="5">
          <th style="width: 120px">家伝法違反減額率</th>
          <td style="align-items: center">
            <a-input-number
              class="input mr-1"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
            />%
          </td>
        </a-col>
        <a-col span="6">
          <read-only-pop
            th="＝"
            :td="hasuGokei.SYUKEI_SEIKEI"
            after="(円未満切り上げ)※2"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4">
          <read-only-pop th="&emsp;①積立金交付金額" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop
            thWidth="210"
            th="経営支援互助金 算定(※1-※2)"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
          />
        </a-col>
        <a-col span="0.5">
          <span class="symbol">×</span>
        </a-col>
        <a-col span="5">
          <read-only-pop thWidth="150" th="１/２" :hideTd="true" />
        </a-col>
        <a-col span="6">
          <read-only-pop
            th="＝"
            :td="hasuGokei.SYUKEI_SEIKEI"
            after="(円未満切り上げ)※3"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4" />
        <a-col span="8">
          <read-only-pop thWidth="210" th="" :td="hasuGokei.SAIRANKEI_SEIKEI" />
        </a-col>
        <a-col span="0.5">
          <span class="symbol">×</span>
        </a-col>
        <a-col span="5">
          <th style="width: 100px">互助金交付率</th>
          <td style="align-items: center">
            <a-input-number
              class="input2 mr-1 w-full"
              v-model:value="formData.SAIRANKEI_IKUSEIKEI"
              :min="1"
            />%
          </td>
        </a-col>
        <a-col span="6">
          <read-only-pop
            th="＝"
            :td="hasuGokei.SYUKEI_SEIKEI"
            after="(円未満切り上げ)①&nbsp;"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4">
          <read-only-pop th="&emsp;②国庫交付金額" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop
            thWidth="210"
            th="経営支援互助金 算定(※1-※2)"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
          />
        </a-col>
        <a-col span="0.5">
          <span class="symbol">—</span>
        </a-col>
        <a-col span="6">
          <read-only-pop
            thWidth="130"
            th="積立金交付金額※3"
            :td="hasuGokei.SAIRANKEI_IKUSEIKEI"
          />
        </a-col>
        <a-col span="5">
          <read-only-pop th="＝" :td="hasuGokei.SYUKEI_SEIKEI" after="②" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4">
          <read-only-pop th="&emsp;③経営支援互助金" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop
            :hideTh="true"
            :td="hasuGokei.SAIRANKEI_SEIKEI"
            after="①積立金交付金額 ＋ ②国庫交付金額"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="4">
          <th class="required">&emsp;入力確認有無</th>
        </a-col>
        <a-col span="8">
          <td style="align-items: center; height: 100%">
            <a-radio-group v-model:value="formData.SYORI_JOKYO_KBN">
              <a-radio :value="1">入力中</a-radio>
              <a-radio :value="2">審査中</a-radio>
              <a-radio :value="3">交付確定</a-radio>
            </a-radio-group>
          </td>
        </a-col>
        <a-col span="12">
          <th>確定年月日</th>
          <td>
            <DateJp
              v-model:value="formData.TANKA_MST_DATE"
              :disabled="formData.SYORI_JOKYO_KBN !== 3"
              class="w-50!"
            />
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button type="primary" @click="closeModal">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, ref, watch } from 'vue'
import { EnumEditKbn } from '@/enum'
import { SearchRequest } from '../../type'
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
const formData = reactive({
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
const tab = ref('1')
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
    tab.value = '1'
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
  border: 1px solid #808080;
  // background-color: #ffffe1;
  font-weight: 100;
  padding: 2px 5px;
}
tr td {
  border: 1px solid #808080;
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
.edit_table .ant-col {
  align-items: center;
}
.symbol {
  width: 15px;
  text-align: center;
  margin: 0 3px;
}
.input {
  background-color: #c0ffc0;
}
.input2 {
  background-color: #ffd700;
}
</style>
