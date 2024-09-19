<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
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
                  class="w-full"
                  @change="getInitData(searchParams.KI, false)"
                ></a-input-number>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>都道府県</th>
            <td>
              <a-form-item v-bind="validateInfos.KEN_CD">
                <range-select
                  v-model:value="searchParams.KEN_CD"
                  :options="KEN_CD_NAME_LIST"
                ></range-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col v-bind="layout">
            <th>事務委託先名</th>
            <td>
              <a-form-item>
                <a-input
                  v-model:value="searchParams.ITAKU_NAME"
                  :maxlength="20"
                ></a-input>
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
                  class="w-full"
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
                  :max="999"
                  :maxlength="3"
                  class="w-full"
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
      <div class="flex">
        <a-space :size="20">
          <a-button type="primary" @click="searchAll">検索</a-button>
          <a-button type="primary" @click="reset">条件クリア</a-button>
          <a-button class="ml-20" type="primary" @click="forwardNew"
            >新規登録</a-button
          >
          <a-button class="ml-20" type="primary" @click="reset"
            >CSV出力</a-button
          >
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" class="sm:flex-1-hidden" ref="cardRef">
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
        :height="height - 64"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
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
    @getTableList="searchAll"
  />
</template>

<script lang="ts" setup>
import { ref, reactive, toRef, watch, onMounted, computed, nextTick } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { EnumAndOr, EnumEditKbn, PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort, convertToFullWidth } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { SearchRowVM, SearchRequest } from '@/views/GJ80/GJ8060/type'
import { Init, Search } from '../service'
import { Form } from 'ant-design-vue'
import { VxeTableInstance } from 'vxe-table'
import EditPage from './EditPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const xTableRef = ref<VxeTableInstance>()
const createDefaultParams = () => {
  return {
    KI: -1,
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

const KEIYAKUSYA_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
const tableData = ref<SearchRowVM[]>([])
const mockData: SearchRowVM = {
  ADDR: '東京都千代田区丸の内1-1-1',
  ITAKU_CD: 67890,
  ITAKU_NAME: '株式会社大手',
  ADDR_TEL: '03-1234-5678',
  ADDR_POST: '100-0005',
}

const KEN_CD_NAME_LIST = ref<CmCodeNameModel[]>([])
//表の高さ
const headRef = ref(null)
const layout = {
  md: 24,
  lg: 12,
  xl: 8,
  xxl: 6,
}
const cardRef = ref()
const { height } = useElementSize(cardRef)
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
  // if (!KI && KI !== 0) {
  //   return
  // }
  // Init({ KI: KI, EDIT_KBN: EnumEditKbn.Add }).then((res) => {
  //   if (initflg) searchParams.KI = res.KI
  //   // searchParams.KEIYAKUSYA_CD = undefined
  //   KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST
  //   nextTick(() => clearValidate())
  // })
}

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.PAGE_NUM = 1
    searchAll()
  }
})
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
  editVisible.value = true
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
  xTableRef.value?.clearSort()
  clear()
}

const searchAll = async () => {
  // const res = await searchData()
  tableData.value.push(mockData)
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
