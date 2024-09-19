<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ4011）経営支援互助金申請情報入力（契約・交付情報表示）"
    width="1200px"
    :body-style="{ height: '800px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="parent-container">
      <div class="edit_table form">
        <div>
          <a-row>
            <a-col span="24">
              <read-only-pop
                thWidth="110"
                th="契約者番号"
                :td="searchParams.KEIYAKUSYA_CD"
                :after="searchParams.KEIYAKUSYA_NAME"
              />
            </a-col>
          </a-row>
          <a-row>
            <a-col span="12">
              <th class="required">認定回数</th>
              <td>
                <a-form-item v-bind="validateInfos.HASSEI_KAISU">
                  <a-input-number
                    v-model:value="searchParams.HASSEI_KAISU"
                    :min="0"
                    class="w-full"
                  ></a-input-number>
                </a-form-item>
                <a-button class="ml-2" type="primary" @click="search"
                  >検索</a-button
                >
              </td>
            </a-col>
          </a-row>
        </div>
      </div>
      <h2 class="my-1">1.契約農場別明細情報(交付情報)(表示)</h2>
      <div class="edit_table form">
        <div>
          <a-row type="flex" justify="space-between">
            <a-col span="10">
              <th class="required">申請日</th>
              <td>
                <a-form-item v-bind="validateInfos.SINSEI_DATE">
                  <DateJp
                    v-model:value="searchParams.SINSEI_DATE"
                    :notAllowClear="true"
                  />
                </a-form-item>
              </td>
            </a-col>
            <a-col span="14" style="justify-content: end;">
              <a-pagination
                v-model:current="pageParams.PAGE_NUM"
                v-model:page-size="pageParams.PAGE_SIZE"
                :total="totalCount"
                :page-size-options="['10', '25', '50', '100']"
                :show-total="(total) => `件数： ${total} `"
                show-less-items
                show-size-changer
                class="m-b-1 text-end"
              />
            </a-col>
          </a-row>
        </div>
      </div>

      <vxe-table
        ref="xTableRef"
        class="mt-2 vxe-table-pop"
        :column-config="{ resizable: true }"
        max-height="200px"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-click="({ row }) => changeData()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="right"
          field="MEISAI_NO"
          title="明細番号"
          width="80"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          width="150"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR"
          title="農場住所"
          min-width="250"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="TORI_KBN_NAME"
          title="鳥の種類"
          min-width="80"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEISAN_KAISU"
          title="計算回数"
          min-width="80"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SYORI_JOKYO_KBN_NAME"
          title="処理状況"
          min-width="80"
          :resizable="false"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KOFU_HASU"
          title="互助金対象羽数"
          min-width="150"
          :resizable="false"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="GENGAKU_RITU"
          title="減額率(%)"
          min-width="100"
          :resizable="false"
        ></vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KOFU_KIN"
          title="経営支援互助金額"
          min-width="130"
          :resizable="false"
        ></vxe-column>
      </vxe-table>

      <div class="flex" style="align-items: end">
        <table v-if="devicePixelRatio <= 1.5" class="my-2 table-fixed">
          <tr>
            <th class="!w-10">鶏の種類</th>
            <th>採卵鶏(成鷄)</th>
            <th colspan="1">採卵鶏(育成鶏)</th>
            <th rowspan="1">肉用鶏</th>
            <th>種鶏(成鶏)</th>
            <th>種鶏(育成鶏)</th>
          </tr>
          <tr>
            <th style="width: 160px !important">互助金交付対象羽数</th>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>{{ hasuGokei.NIKUYOUKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_IKUSEIKEI }}</td>
          </tr>
          <tr>
            <th style="width: 160px !important">経営支援互助金交付額</th>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>{{ hasuGokei.NIKUYOUKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_IKUSEIKEI }}</td>
          </tr>
          <tr>
            <th>うずら</th>
            <th>あひる</th>
            <th>きじ</th>
            <th>ほろほろ鳥</th>
            <th>七面鳥</th>
            <th>だちょう</th>
            <th>合計</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.UZURA }}</td>
            <td>{{ hasuGokei.AHIRU }}</td>
            <td>{{ hasuGokei.KIJI }}</td>
            <td>{{ hasuGokei.HOROHOROTORI }}</td>
            <td>{{ hasuGokei.SICHIMENCHOU }}</td>
            <td>{{ hasuGokei.DACHOU }}</td>
            <td>
              {{ hasuGokei.TOTAL || 0 }}
            </td>
          </tr>
          <tr>
            <td>{{ hasuGokei.UZURA }}</td>
            <td>{{ hasuGokei.AHIRU }}</td>
            <td>{{ hasuGokei.KIJI }}</td>
            <td>{{ hasuGokei.HOROHOROTORI }}</td>
            <td>{{ hasuGokei.SICHIMENCHOU }}</td>
            <td>{{ hasuGokei.DACHOU }}</td>
            <td>
              {{ hasuGokei.TOTAL || 0 }}
            </td>
          </tr>
        </table>

        <table v-if="devicePixelRatio > 1.5" class="my-2 table-fixed">
          <tr>
            <th>鶏の種類</th>
            <th>採卵鶏(成鷄)</th>
            <th colspan="1">採卵鶏(育成鶏)</th>
            <th rowspan="1">肉用鶏</th>
          </tr>
          <tr>
            <th>契約羽数合計</th>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}</td>
            <td>{{ hasuGokei.NIKUYOUKEI }}</td>
          </tr>
          <tr>
            <th>種鶏(成鶏)</th>
            <th>種鶏(育成鶏)</th>
            <th>うずら</th>
            <th>あひる</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
            <td>{{ hasuGokei.SYUKEI_IKUSEIKEI }}</td>
            <td>{{ hasuGokei.UZURA }}</td>
            <td>{{ hasuGokei.AHIRU || 0 }}</td>
          </tr>
          <tr>
            <th>きじ</th>
            <th>ほろほろ鳥</th>
            <th>七面鳥</th>
            <th>だちょう</th>
            <th>合計</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.KIJI }}</td>
            <td>{{ hasuGokei.HOROHOROTORI }}</td>
            <td>{{ hasuGokei.SICHIMENCHOU }}</td>
            <td>{{ hasuGokei.DACHOU }}</td>
            <td>{{ hasuGokei.TOTAL || 0 }}</td>
          </tr>
        </table>

        <a-button class="danger-btn m2" :disabled="!isEdit" @click="deleteData">削除</a-button>
      </div>
      <h2 class="my-1">2.契約農場別登録明細情報(確認用)</h2>
      <div class="parent-container">
        <div class="edit_table form w-full">
          <a-row>
            <a-col span="24">
              <read-only-pop thWidth="110" th="農場" :td="formData.NOJO_CD" />
            </a-col>
          </a-row>
          <a-row>
            <a-col span="24">
              <read-only-pop thWidth="110" th="住所" td="" :hideTd="true" />
              <read-only-pop th="　〒　" :td="formData.ADDR_POST" />
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
          <a-row>
            <a-col span="24">
              <read-only-pop
                thWidth="110"
                th="鶏の種類"
                :td="formData.TORI_KBN"
              />
            </a-col>
            <a-col span="24">
              <read-only-pop
                thWidth="110"
                th="契約羽数"
                :td="formData.KEIYAKU_HASU"
              />
            </a-col>
            <a-col span="24">
              <read-only-pop
                thWidth="150"
                th="互助金交付対象羽数"
                :td="formData.KOFU_HASU"
              />
              <read-only-pop
                thWidth="100"
                th="互助金交付率"
                :td="formData.KOFU_RITU"
              />
              <read-only-pop
                thWidth="150"
                th="家伝法違反減額率"
                :td="formData.GENGAKU_RITU"
              />
            </a-col>
            <a-col span="24">
              <read-only-pop
                thWidth="150"
                th="経営支援互助金交付額"
                :td="formData.KOFU_KIN"
              />
              <read-only-pop
                thWidth="100"
                th="積立金交付額"
                :td="formData.SEI_TUMITATE_KIN"
              />
              <read-only-pop
                thWidth="150"
                th="国庫交付額"
                :td="formData.KUNI_KOFU_KIN"
              />
            </a-col>
          </a-row>
        </div>
      </div>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button type="primary" :disabled="!isEdit" @click="openGJ4012">互助金明細入力</a-button>
          <a-button type="primary" :disabled="!isEdit" @click="closeModal">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <Detail2 v-model:visible="GJ4012Visible" :editkbn="GJ4012kbn" />
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, watch, ref, toRef } from 'vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import { GJ4011DetailVM, SearchRequest, SearchRowVM } from '../../type'
import { useRoute, useRouter } from 'vue-router'
import { changeTableSort, mathNumber } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import Detail2 from '@/views/GJ40/GJ4010/modules/Detail/Detail2.vue'
import useSearch from '@/hooks/useSearch'
import { VxeTableInstance } from 'vxe-table'

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
const xTableRef = ref<VxeTableInstance>()
const searchParams = reactive({
  KEIYAKUSYA_CD: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  HASSEI_KAISU: undefined as number | undefined,
  SINSEI_DATE: new Date().toISOString().split('T')[0],
})
const formData = reactive({
  KEIYAKU_KBN: undefined as number | undefined,
  NOJO_CD: undefined as number | undefined,
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  TORI_KBN: '',
  KEIYAKU_HASU: undefined as number | undefined,
  KOFU_HASU: undefined as number | undefined,
  KOFU_RITU: undefined as number | undefined,
  GENGAKU_RITU: undefined as number | undefined,
  KOFU_KIN: undefined as number | undefined,
  SEI_TUMITATE_KIN: undefined as number | undefined,
  KUNI_KOFU_KIN: undefined as number | undefined,
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
const tableDefault = {
  MEISAI_NO: 0,
  NOJO_NAME: '(宇)宇宇イイアイ-',
  NOJO_ADDR: '北海道亜宇亜亜亜宇亜宇亜亜亜宇亜宇亜亜亜',
  TORISYURUI: '揉卵成鶏',
  KEIYAKUHASU: '111',
  BIKO: '',
}
const isEdit = ref(false)

const editJudge = new Judgement()
const devicePixelRatio = ref(window.devicePixelRatio)
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => formData),
})
const GJ4012Visible = ref(false)
const GJ4012kbn = ref<EnumEditKbn>(EnumEditKbn.Add)

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
window.addEventListener('resize', function () {
  devicePixelRatio.value = window.devicePixelRatio
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
function search() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}
//画面遷移
const goList = () => {
  closeModal()
}

const changeData = () => {
  const a = xTableRef.value?.getCurrentRecord()
  isEdit.value = true
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    emit('update:visible', false)
  })
}

function openGJ4012(row?: any) {
  GJ4012Visible.value = true
}
// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}
</script>
<style lang="scss" scoped>
th {
  min-width: 110px; //絶対変えられない
}

tr th {
  text-align: center;
  border: 1px solid rgb(190, 190, 190);
  background-color: #ffffe1;
  font-weight: 100;
  width: 0.8rem !important;
}
tr td {
  text-align: right;
  border: 1px solid rgb(190, 190, 190);
  width: 0.8rem !important;
}
</style>
