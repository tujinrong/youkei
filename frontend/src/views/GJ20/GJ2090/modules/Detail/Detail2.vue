<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ2092）契約者積立金等分割入金確認"
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
              thWidth="110"
              :td="String(formData.KEIYAKUSYA_CD)"
            ></read-only-pop>
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="都道府県"
              thWidth="110"
              :td="formData.KEN_CD_NAME"
            ></read-only-pop>
          </a-col>
          <a-col span="8">
            <read-only-pop
              th="処理状況"
              thWidth="110"
              :td="formData.SYORI_JOKYO_KBN_NAME"
            ></read-only-pop>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <read-only-pop
              thWidth="110"
              th="契約者名"
              :td="formData.KEIYAKUSYA_NAME"
            />
          </a-col>
        </a-row>
        <h2 class="mt3 mb1">請求入金内容</h2>
        <a-row>
          <a-col span="24">
            <read-only-pop
              th="対象期"
              thWidth="110"
              :td="String(formData.KI)"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <read-only-pop
              th="請求日"
              thWidth="110"
              :td="getDateJpText(formData.SEIKYU_DATE)"
            />
          </a-col>
          <a-col span="12">
            <read-only-pop
              th="請求回数"
              thWidth="110"
              :td="formData.SEIKYU_KAISU"
              after="回"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="6">
            <read-only-pop
              thWidth="110"
              th="請求金額"
              :td="formData.SAGUKU_SEIKYU_KIN"
              v-bind="{ ...mathNumber }"
              after="円"
            />
          </a-col>
          <a-col span="6">
            <read-only-pop
              thWidth="110"
              th="積立金額"
              :td="formData.TUMITATE_KIN"
              v-bind="{ ...mathNumber }"
              after="円"
            />
          </a-col>
          <a-col span="6" style="flex-flow: column">
            <div class="flex">
              <read-only-pop
                thWidth="110"
                th="手数料"
                :td="formData.TESURYO"
                v-bind="{ ...mathNumber }"
                after="円"
              />
            </div>
            <div class="flex">
              <read-only-pop
                thWidth="110"
                th="積立金等総計"
                :td="formData.SEIKYU_KIN"
                after="円"
              />
            </div>
          </a-col>
          <a-col span="6">
            <read-only-pop
              thWidth="140"
              th="返還金額(預かり金)"
              :td="formData.TESURYO"
              v-bind="{ ...mathNumber }"
              after="円"
            />
          </a-col>
        </a-row>
        <a-row class="mt4">
          <a-col span="16">
            <vxe-table
              ref="xTableRef"
              class="vxe-table-pop"
              :column-config="{ resizable: true }"
              max-height="300px"
              :row-config="{ isCurrent: true, isHover: true }"
              :data="tableData"
              :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
              :empty-render="{ name: 'NotData' }"
            >
              <vxe-column
                header-align="center"
                align="center"
                field="BANGO"
                title="番号"
                min-width="60"
                sortable
              ></vxe-column>
              <vxe-column
                header-align="center"
                align="center"
                field="NYUKIN_DATE"
                title="入金日"
                min-width="120"
                sortable
              ></vxe-column>
              <vxe-column
                header-align="center"
                align="right"
                field="NYUKIN_TUMITATE"
                title="積立金額"
                min-width="100"
                sortable
              ></vxe-column>
              <vxe-column
                header-align="center"
                align="right"
                field="NYUKIN_TESU"
                title="手数料額"
                min-width="100"
                sortable
              ></vxe-column>
              <vxe-column
                header-align="center"
                align="right"
                field="NYUKIN_GOKEI"
                title="合計額"
                min-width="100"
                sortable
              ></vxe-column>
              <vxe-column
                header-align="center"
                align="right"
                field="NYUKIN_GAKU"
                title="入金額"
                min-width="100"
                sortable
              ></vxe-column>
            </vxe-table>
          </a-col>
          <a-col span="8">
            <a-row>
              <a-col span="24">
                <read-only-pop
                  thWidth="80"
                  th="積立金額計"
                  :td="formData.SEIKYU_KIN"
                  after="円"
                />
              </a-col>
              <a-col span="24">
                <read-only-pop
                  thWidth="80"
                  th="手数料額計"
                  :td="formData.SEIKYU_KIN"
                  after="円"
                />
              </a-col>
              <a-col span="24">
                <read-only-pop
                  thWidth="80"
                  th="入金額計"
                  :td="formData.SEIKYU_KIN"
                  after="円"
                />
              </a-col>
              <a-col span="24">
                <read-only-pop
                  thWidth="80"
                  th="入金額残"
                  :td="formData.SEIKYU_KIN"
                  after="円"
                />
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-space :size="20" class="mb-2 mt3">
          <a-button>新規入金</a-button>
          <a-button>変更(表示)</a-button>
          <a-button>削除</a-button>
        </a-space>
        <a-row>
          <a-col span="24">
            <th class="required" style="width: 110px">入金・振込日</th>
            <td style="border-bottom: none">
              <a-form-item v-bind="validateInfos.NYUKIN_DATE">
                <DateJp v-model:value="formData.NYUKIN_DATE" />
              </a-form-item>
            </td>
            <read-only-pop
              thWidth="100"
              th="積立金額"
              :td="formData.BANK_NAME"
              after="(返還金額(預かり金) + 入金額)"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th style="width: 110px; border-top: none"></th>
            <td style="border-bottom: none; border-top: none"></td>
            <read-only-pop
              thWidth="100"
              th="手数料額"
              :td="formData.FURI_KOZA_NO"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th style="width: 110px; border-top: none"></th>
            <td style="border-top: none"></td>
            <read-only-pop
              thWidth="100"
              th="入金額"
              :td="formData.FURI_KOZA_MEIGI_KANA"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="24">
            <th style="width: 110px">備考</th>
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
          <a-button
            class="warning-btn"
            :disabled="!formData.NYUKIN_DATE"
            @click="saveData"
            >保存</a-button
          >
          <a-button :disabled="!formData.NYUKIN_DATE" @click="closeModal"
            >キャンセル</a-button
          >
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
import { EnumEditKbn, PageStatus } from '@/enum'
import { DetailVM, SearchRequest } from '../../type'
import { changeTableSort, mathNumber, getDateJpText } from '@/utils/util'
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
const tableData = ref<SearchRequest[]>([])

const editJudge = new Judgement()
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const formDefault = {
  TUMITATE_KBN: 1,
  KEIYAKUSYA_CD: 987654,
  KEN_CD: 12,
  KEN_CD_NAME: '東京都',
  SYORI_JOKYO_KBN: 3,
  SYORI_JOKYO_KBN_NAME: '処理済み',
  KEIYAKUSYA_NAME: '譲渡元株式会社',
  KEIYAKUSYA_KANA: 'ジョウトモトカブシキガイシャ',
  ADDR_POST: '100-0001',
  ADDR: '東京都千代田区1-1-1',
  ADDR_TEL1: '03-1234-5678',
  ADDR_TEL2: '03-9876-5432',
  ADDR_FAX: '03-1111-2222',
  FURI_BANK_CD: '0001',
  BANK_NAME: 'みずほ銀行',
  FURI_BANK_SITEN_CD: '001',
  SITEN_NAME: '本店',
  FURI_KOZA_SYUBETU: 2,
  FURI_KOZA_SYUBETU_NAME: '普通',
  FURI_KOZA_NO: '',
  FURI_KOZA_MEIGI_KANA: 'ジョウトモト',
  JIMUITAKU_CD: 1001,
  ITAKU_NAME: '事務委託株式会社',
  KI: 8,
  SEIKYU_DATE: new Date('2024-09-13'),
  SEIKYU_KAISU: 2,
  SEIKYU_HENKAN_KBN: 1,
  SEIKYU_HENKAN_KBN_NAME: '返還済み',
  NYUKIN_DATE: new Date('2024-09-14'),
  SAGUKU_SEIKYU_KIN: 50000,
  TUMITATE_KIN: 20000,
  TESURYO: 300,
  SEIKYU_KIN: 70300,
  BIKO: '備考内容テスト',
}
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
      Object.assign(formData, formDefault)
      nextTick(() => {
        setPaddingToZero()
        editJudge.reset()
      })
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

// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}

const setPaddingToZero = () => {
  const table = document.querySelector('.vxe-table-pop') as HTMLElement
  if (table) {
    table.style.setProperty('--vxe-ui-table-column-padding-default', '0px')
  }
}
</script>
<style lang="scss" scoped>
th {
  width: 200px;
  border-right: 1px solid #8a8d92 !important;
}
</style>
