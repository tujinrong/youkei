<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.07.24
 * 作成者　　: wx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px my-4 mx-4">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <div class="max-w-900px">
        <h1>（GJ8090）契約者農場一覧</h1>
        <div class="self_adaption_table form mt-1">
          <a-row>
            <a-col v-bind="layout">
              <th class="required">期</th>
              <td>
                <a-form-item v-bind="validateInfos.KI">
                  <a-input-number
                    v-model:value="searchParams.KI"
                    :min="1"
                    :max="99"
                    :maxlength="2"
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
                    class="max-w-200"
                    split-val
                  ></ai-select>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>農場番号</th>
              <td>
                <a-form-item>
                  <a-input-number
                    v-model:value="searchParams.NOJO_CD"
                    :min="0"
                    :max="999"
                    :maxlength="3"
                    class="w-20"
                  ></a-input-number>
                </a-form-item>
              </td>
            </a-col>
            <a-col v-bind="layout">
              <th>農場名</th>
              <td>
                <a-form-item>
                  <a-input
                    v-model:value="searchParams.NOJO_NAME"
                    :maxlength="20"
                    class="w-100"
                  ></a-input>
                  <span>(部分一致)</span>
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
          <a-button type="primary" @click="forwardNew">新規登録</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
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
        height="440px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.NOJO_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="NOJO_CD"
          title="農場コード"
          width="100"
          align="right"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.NOJO_CD)">{{ row.NOJO_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="NOJO_NAME"
          title="農場名"
          width="300"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.NOJO_CD)">{{ row.NOJO_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="ADDR"
          title="農場住所"
          width="500"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage
    v-model:visible="editVisible"
    :editkbn="editkbn"
    :params="searchParams"
    :keys="keyList"
    :name="name"
    @getTableList="searchAll"
  />
</template>

<script lang="ts" setup>
import { ref, reactive, toRef, watch, onMounted, computed, nextTick } from 'vue'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort, convertToFullWidth } from '@/utils/util'
import { useElementSize } from '@vueuse/core'
import { SearchRowVM, SearchRequest } from '@/views/GJ80/GJ8090/type'
import { Init, Search } from './service'
import EditPage from './modules/EditPage.vue'
import { Form } from 'ant-design-vue'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const xTableRef = ref<VxeTableInstance>()
const createDefaultParams = (): SearchRequest => {
  return {
    KI: -1,
    KEIYAKUSYA_CD: undefined,
    NOJO_CD: undefined,
    NOJO_NAME: undefined,
    SEARCH_METHOD: EnumAndOr.AndCode,
  } as SearchRequest
}
const searchParams = reactive(createDefaultParams())

const keyList = reactive({
  KI: undefined,
  KEIYAKUSYA_CD: undefined,
  KEIYAKUSYA_NAME: '',
  NOJO_CD: undefined,
})
const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])

//表の高さ
const headRef = ref(null)
const layout = {
  md: 24,
  lg: 24,
  xl: 24,
  xxl: 24,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const name = computed(() => {
  return (
    KEIYAKUSYA_CD_NAME_LIST.value.find(
      (el) => el.CODE === Number(searchParams.KEIYAKUSYA_CD)
    )?.NAME || ''
  )
})
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
const isDataSelected = computed(() => {
  return tableData.value.length > 0 && xTableRef.value?.getCurrentRecord()
})
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(searchParams.KI, true)
})

//初期化処理
const getInitData = (KI: number, initflg: boolean) => {
  if (!KI && KI !== 0) {
    return
  }
  Init({ KI: KI, EDIT_KBN: EnumEditKbn.Add }).then((res) => {
    if (initflg) searchParams.KI = res.KI
    searchParams.KEIYAKUSYA_CD = undefined
    KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST
    nextTick(() => clearValidate())
  })
}

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function forwardNew() {
  await validate()
  editVisible.value = true
  editkbn.value = EnumEditKbn.Add
  console.log(name.value)
}
async function forwardEdit(NOJO_CD) {
  await validate()
  editVisible.value = true
  editkbn.value = EnumEditKbn.Edit
  keyList.NOJO_CD = NOJO_CD
}

//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  validate,
})

//クリア
async function reset() {
  searchParams.NOJO_CD = undefined
  searchParams.NOJO_NAME = undefined
  searchParams.SEARCH_METHOD = EnumAndOr.AndCode
  getInitData(-1, true)
  xTableRef.value?.clearSort()
  clear()
}

const searchAll = async () => {
  tableData.value = []
  const res = await searchData()
  keyList.KI = res.KI
  keyList.KEIYAKUSYA_CD = res.KEIYAKUSYA_CD
  keyList.KEIYAKUSYA_NAME =
    KEIYAKUSYA_CD_NAME_LIST.value.find((el) => el.CODE === res.KEIYAKUSYA_CD)
      ?.NAME || ''
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => searchParams.NOJO_NAME,
  (newVal) => {
    if (newVal) {
      searchParams.NOJO_NAME = convertToFullWidth(newVal)
    }
  }
)
</script>

<style lang="scss" scoped>
:deep(th) {
  min-width: 100px;
}

:deep(.ant-form-item) {
  margin-bottom: 0;
  width: 100%;
}
</style>
