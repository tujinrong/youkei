<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px flex">
    <a-card :bordered="false">
      <h1>（GJ3010）互助基金契約者情報変更(增羽)</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col span="24">
            <th class="required">期</th>
            <td>
              <a-form-item v-bind="validateInfos.KI">
                <a-input-number
                  v-model:value="searchParams.KI"
                  :min="0"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                  @change="getInitData(searchParams.KI, false)"
                ></a-input-number>
              </a-form-item>
            </td> </a-col></a-row
        ><a-row>
          <a-col span="24">
            <th class="required">契約者</th>
            <td>
              <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                <ai-select
                  v-model:value="searchParams.KEIYAKUSYA_CD"
                  :options="KEIYAKUSYA_CD_NAME_LIST"
                  class="max-w-115"
                  split-val
                ></ai-select>
              </a-form-item>
            </td> </a-col
        ></a-row>
      </div>
      <div class="flex mt-2">
        <a-space :size="20">
          <a-button type="primary" :disabled="isSearched" @click="search"
            >検索</a-button
          ><a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button type="primary" :disabled="!isSearched" @click="add"
            >新規登録</a-button
          ><a-button
            class="ml-20"
            type="primary"
            @click="turnExportPage"
            :disabled="!isDataSelected"
            >請求書発行
          </a-button>
        </a-space>
        <close-page /></div
    ></a-card>
    <a-card class="flex-1">
      <div class="flex justify-between">
        <h2>契約農場別明細 增羽情報(表示)</h2>
        <a-pagination
          v-model:current="pageParams.PAGE_NUM"
          v-model:page-size="pageParams.PAGE_SIZE"
          :total="totalCount"
          :page-size-options="['10', '25', '50', '100']"
          :show-total="(total) => `抽出件数： ${total} 件`"
          show-less-items
          show-size-changer
          class="m-b-1 text-end"
        />
      </div>
      <vxe-table
        class="my-1"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          align="center"
          field="KEIYAKU_DATE_FROM"
          title="増羽年月日"
          min-width="100"
          sortable
          formatter="jpDate"
          :params="{ order: 1 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          min-width="250"
          sortable
          :params="{ order: 2 }"
          ><template #default="{ row }">
            <a @click="edit()">{{ row.NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="TORI_KBN_NAME"
          title="鳥の種類"
          min-width="100"
          sortable
          :params="{ order: 3 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="ZO_HASU"
          title="増羽数"
          min-width="100"
          sortable
          :params="{ order: 4 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU_MAE"
          title="契約羽数(増羽前)"
          min-width="100"
          sortable
          :params="{ order: 5 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="KEIYAKU_HASU"
          title="契約羽数(増羽後)"
          min-width="100"
          sortable
          :params="{ order: 6 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SYORI_KBN"
          title="処理区分"
          min-width="50"
          sortable
          :params="{ order: 7 }"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          align="right"
          field="SEIKYU_KAISU"
          title="請求回数"
          min-width="100"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
      <Detail v-model:visible="detailVisible" :editkbn="editkbn"></Detail>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'

import { onMounted, reactive, ref, toRef, computed } from 'vue'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, mathNumber } from '@/utils/util'
import { useRoute, useRouter } from 'vue-router'
import { EnumEditKbn, PageStatus } from '@/enum'
import { VxeTableInstance } from 'vxe-table'
import { SearchRowVM } from '../type'
import { nextTick } from 'process'
import Detail from './DetailPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const createDefaultParams = () => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams = reactive(createDefaultParams())
const isSearched = ref(false)

const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 555, NAME: '契約者名契約者名契約者名契約者名契約者名契約者名契' },
])
const LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKUSYA_CD: [
    {
      required: true,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
const xTableRef = ref<VxeTableInstance>()
const tableDefault = {
  KI: 2024, // 期
  KEIYAKUSYA_CD: 123456, // 契約者番号
  KEIYAKU_DATE_TO: new Date('2024-12-31'), // 契約年月日To (Date类型)
  NOJO_CD: 101, // 農場コード
  KEIYAKU_KBN: 1, // 契約区分
  TORI_KBN: 2, // 鳥の種類コード
  KEIYAKU_DATE_FROM: new Date('2024-01-01'), // 増羽年月日 (Date类型)
  NOJO_NAME: '亜伊伊伊伊（伊）', // 農場名 (String类型)
  TORI_KBN_NAME: '肉用', // 鳥の種類名 (String类型)
  ZO_HASU: 1573, // 増羽数 (Number类型)
  KEIYAKU_HASU_MAE: 1500, // 契約羽数(増羽前) (Number类型，可选)
  KEIYAKU_HASU: 1600, // 契約羽数(増羽後) (Number类型)
  SYORI_KBN: '入力確定', // 処理区分 (String类型)
  SEIKYU_KAISU: 216, // 請求回数 (Number类型，可选)
}
const detailVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const router = useRouter()
const route = useRoute()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isDataSelected = computed(() => {
  return tableData.value.length > 0 && xTableRef.value?.getCurrentRecord()
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  nextTick(() => clearValidate())
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
}
//検索処理
function search() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
  isSearched.value = true
}
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})

//条件クリア
const reset = () => {
  clear()
  clearValidate()
  isSearched.value = false
}
//新規
const add = () => {
  detailVisible.value = true
  editkbn.value = EnumEditKbn.Add
}
//編集
const edit = () => {
  detailVisible.value = true
  editkbn.value = EnumEditKbn.Edit
}
//登録
const save = () => {}
//キャンセル
const cancel = () => {}

//請求書発行
const turnExportPage = () => {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
    },
  })
}
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
.search-disabled-mask {
  position: absolute;
  background-color: #f5f5f5;
  width: 100%;
  height: 100%;
  top: 0;
  z-index: 99;
  opacity: 0.5;
}
.parent-container {
  position: relative; /* 确保相对定位 */
}
</style>
