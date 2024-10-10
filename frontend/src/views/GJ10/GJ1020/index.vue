<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助基金契約者情報変更
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px lt-sm:overflow-auto px-4 py-4"
  >
    <a-card :bordered="false" class="staticWidth">
      <div class="max-w-584px">
        <h1>（GJ1020）互助基金契約者情報変更（移動）</h1>
        <div class="self_adaption_table form mt-1">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <a-input-number
                    v-model:value="searchParams.KI"
                    :min="0"
                    :max="99"
                    :maxlength="2"
                    :disabled="isSearched"
                    class="w-14"
                    @change="getInitData(searchParams.KI, false)"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th class="required">契約者</th>
              <td>
                <a-form-item v-bind="validateInfos.KEIYAKUSYA_CD">
                  <ai-select
                    v-model:value="searchParams.KEIYAKUSYA_CD"
                    :options="KEIYAKUSYA_CD_NAME_LIST"
                    split-val
                    class="max-w-115"
                    :disabled="isSearched"
                  ></ai-select>
                </a-form-item>
              </td> </a-col
          ></a-row>
        </div>
      </div>
      <div class="flex mt-2">
        <a-space :size="20">
          <a-button type="primary" @click="search" :disabled="isSearched"
            >検索</a-button
          >
          <a-button
            type="primary"
            :disabled="!isSearched || isEditing"
            @click="add"
            >新規登録</a-button
          >
          <a-button type="primary" @click="reset">キャンセル</a-button>
        </a-space>
        <EndButton />
      </div> </a-card
    ><a-card class="flex-1 staticWidth"
      ><h2>1.契約農場別明細 移動情報(表示)</h2>
      <div class="flex justify-between">
        <a-pagination
          v-model:current="pageParams.PAGE_NUM"
          v-model:page-size="pageParams.PAGE_SIZE"
          :total="totalCount"
          :page-size-options="['10', '25', '50', '100']"
          :show-total="(total) => `抽出件数： ${total} 件`"
          show-less-items
          show-size-changer
          class="ml-a"
        />
      </div>
      <vxe-table
        class="my-1"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        height="520px"
        :sort-config="{ trigger: 'cell', orders: ['asc', 'desc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => edit()"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="KEIYAKU_DATE_FROM"
          title="移動開始日"
          min-width="150px"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
          :formatter="({ cellValue }) => getDateJpText(new Date(cellValue))"
          ><template #default="{ row }">
            <a @click="edit()">{{
              getDateJpText(new Date(row.KEIYAKU_DATE_FROM))
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="TORI_KBN"
          title="鳥の種類"
          min-width="120px"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="IDO_HASU"
          title="移動羽数"
          min-width="120px"
          sortable
          align="right"
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME_MOTO"
          title="農場名(移動元)"
          sortable
          width="333px"
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_HASU_MOTO_ATO"
          title="契約羽数(移動元)"
          min-width="150px"
          align="right"
          sortable
          :params="{ order: 5 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME_SAKI"
          title="農場名(移動先)"
          width="333px"
          sortable
          :params="{ order: 6 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="KEIYAKU_HASU_SAKI_ATO"
          title="契約羽数(移動先)"
          min-width="150px"
          align="right"
          sortable
          :params="{ order: 7 }"
          :resizable="true"
        >
        </vxe-column>
        <vxe-column
          header-align="center"
          field="SYORI_KBN_NAME"
          title="処理区分"
          min-width="120px"
          sortable
          :params="{ order: 8 }"
          :resizable="false"
        >
        </vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage v-model:visible="editVisible" :editkbn="editkbn" />
</template>
<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { onMounted, reactive, ref, toRef } from 'vue'
import { NojoAddrVM, SearchRequest, SearchRowVM } from './type'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, mathNumber } from '@/utils/util'
import { Search } from './service'
import { getDateJpText } from '@/utils/util'
import { VxeTableInstance } from 'vxe-table'
import { EnumEditKbn, PageStatus } from '@/enum'
import EditPage from './Popup/EditPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const createDefaultParams = (): Omit<
  SearchRequest,
  keyof CmSearchRequestBase
> => {
  return {
    KI: 8,
    KEIYAKUSYA_CD: undefined,
  }
}
const searchParams = reactive(createDefaultParams())

const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([
  { CODE: 555, NAME: '契約者名契約者名契約者名契約者名契約者名契約者名契' },
])
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchRowVM[]>([])
const tableDefault = {
  KEIYAKU_DATE_FROM: new Date('2024-01-15'),
  TORI_KBN: 1,
  TORI_KBN_NAME: '鶏の種類A',
  IDO_HASU: 1000,
  NOJO_CD_MOTO: 101,
  NOJO_NAME_MOTO: '農場A',
  KEIYAKU_HASU_MOTO_ATO: 500,
  NOJO_CD_SAKI: 102,
  NOJO_NAME_SAKI: '農場B',
  KEIYAKU_HASU_SAKI_ATO: 500,
  SYORI_KBN_NAME: '処理区分A',
}

const isEditing = ref(false)
const isSearched = ref(false)
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const rules = reactive({
  KI: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '期') },
  ],
  KEIYAKUSYA_CD: [
    {
      required: false,
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '契約者'),
    },
  ],
})
const { validate, clearValidate, validateInfos } = Form.useForm(
  searchParams,
  rules
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

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
//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
}
//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})
function search() {
  tableData.value.push(tableDefault)
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
  isSearched.value = true
}
//新規
const add = () => {
  editVisible.value = true
  editkbn.value = EnumEditKbn.Add
}
//編集
const edit = () => {
  editVisible.value = true
  editkbn.value = EnumEditKbn.Edit
}

//キャンセル
const reset = () => {
  clear()
  clearValidate()
  isSearched.value = false
  isEditing.value = false
}
//
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
