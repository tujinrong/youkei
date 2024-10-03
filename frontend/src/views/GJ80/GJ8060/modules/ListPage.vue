<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px flex">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <div class="max-w-780px">
        <h1>（GJ8060）事務委託先一覧</h1>
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
                    class="w-14"
                    @change="getInitData(searchParams.KI, false)"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>都道府県</th>
              <td>
                <div class="w-90">
                  <a-form-item v-bind="validateInfos.KEN_CD">
                    <range-select
                      v-model:value="searchParams.KEN_CD"
                      :options="KEN_CD_NAME_LIST"
                      class="w-90!"
                    ></range-select>
                  </a-form-item>
                </div>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先名</th>
              <td class="w-fit">
                <a-form-item>
                  <a-input
                    v-model:value="searchParams.ITAKU_NAME"
                    :maxlength="25"
                    class="max-w-150"
                  ></a-input>
                  <span>(部分一致)</span>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>事務委託先</th>
              <td>
                <a-form-item>
                  <a-input-number
                    v-model:value="searchParams.ITAKU_CD"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    class="w-20"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>まとめ先</th>
              <td>
                <a-form-item>
                  <a-input-number
                    v-model:value="searchParams.MATOMESAKI"
                    :min="0"
                    :max="9"
                    :maxlength="1"
                    class="w-10"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
          </a-row>
        </div>
        <div class="my-2 flex">
          <a-space
            ><span>検索方法</span>
            <a-radio-group v-model:value="searchParams.SEARCH_METHOD">
              <a-radio :value="EnumAndOr.AndCode">すべてを含む(AND)</a-radio>
              <a-radio :value="EnumAndOr.OrCode">いずれかを含む(OR)</a-radio>
            </a-radio-group></a-space
          >
        </div>
      </div>
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="searchAll">検索</a-button>
          <a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button class="ml-50%" type="primary" @click="forwardNew"
            >新規登録</a-button
          >
          <a-button class="ml-100%" type="primary" @click="csvOutput"
            >CSV出力</a-button
          > </a-space
        ><close-page /></div
    ></a-card>
    <a-card :bordered="false" class="flex-1 staticWidth" ref="cardRef">
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
      <vxe-table
        class="mt-2"
        ref="xTableRef"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        height="390px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.NOJO_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="ITAKU_CD"
          title="事務委託先"
          min-width="100"
          align="right"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.ITAKU_CD)">{{ row.ITAKU_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="ITAKU_NAME"
          title="事務委託先名"
          min-width="400"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.ITAKU_CD)">{{ row.ITAKU_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR_TEL"
          title="電話番号"
          min-width="160"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR_POST"
          title="郵便番号"
          min-width="200"
          sortable
          :params="{ order: 4 }"
          :resizable="false"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR"
          title="住所"
          min-width="600"
          sortable
          :params="{ order: 5 }"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage
    v-model:visible="editVisible"
    :editkbn="editkbn"
    v-bind="{ ITAKU_CD: ITAKU_CD }"
    @getTableList="searchAll"
  />
</template>

<script lang="ts" setup>
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { EnumAndOr, EnumEditKbn } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { changeTableSort } from '@/utils/util'
import { SearchRowVM } from '@/views/GJ80/GJ8060/type'
import { Form } from 'ant-design-vue'
import { nextTick, onMounted, reactive, ref, toRef } from 'vue'
import { VxeTableInstance } from 'vxe-table'
import { CsvExport, Init, Search } from '../service'
import EditPage from './EditPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const xTableRef = ref<VxeTableInstance>()
const createDefaultParams = () => {
  return {
    KI: 8,
    KEN_CD: {
      VALUE_FM: undefined,
      VALUE_TO: undefined,
    },
    ITAKU_NAME: undefined,
    ITAKU_CD: undefined,
    MATOMESAKI: undefined,
    SEARCH_METHOD: EnumAndOr.AndCode,
  }
}
const searchParams = reactive(createDefaultParams())
const ITAKU_CD = ref('')
const tableData = ref<SearchRowVM[]>([])
const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
//表の高さ
const headRef = ref(null)
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const cardRef = ref()
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
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
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(searchParams.KI, true)
  nextTick(() => clearValidate())
})

//初期化処理
const getInitData = (KI: number | undefined, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
  Init({ KI: KI, EDIT_KBN: EnumEditKbn.Add }).then((res) => {
    if (initflg) searchParams.KI = res.KI
    KEN_CD_NAME_LIST.value = res.KEN_LIST
    nextTick(() => clearValidate())
  })
}

// onBeforeRouteUpdate((to, from) => {
//   if (to.query.refresh) {
//     pageParams.PAGE_NUM = 1
//     searchAll()
//   }
// })
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function forwardNew() {
  await validate()
  editkbn.value = EnumEditKbn.Add
  editVisible.value = true
}
async function forwardEdit(NOJO_CD) {
  editkbn.value = EnumEditKbn.Edit
  ITAKU_CD.value = NOJO_CD
  editVisible.value = true
}

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => ({ NYURYOKU_JOHO: searchParams })),
  validate,
})

//クリア
async function reset() {
  xTableRef.value?.clearSort()
  clear()
}

const searchAll = async () => {
  tableData.value = []
  await searchData()
}

const csvOutput = async () => {
  await CsvExport({ NYURYOKU_JOHO: searchParams })
}
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
</script>

<style lang="scss" scoped>
:deep(th) {
  min-width: 100px;
}
</style>
