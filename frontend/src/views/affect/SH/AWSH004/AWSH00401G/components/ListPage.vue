<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診予定管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.14
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="required">年度</th>
            <td>
              <YearJp v-model:value="searchParams.nendo" />
            </td>
          </a-col>
          <a-col :md="24" :lg="16" :xxl="18">
            <th>実施予定日</th>
            <td>
              <RangeDate
                v-model:value1="searchParams.yoteiymdf"
                v-model:value2="searchParams.yoteiymdt"
              />
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>事業名</th>
            <td>
              <ai-select
                v-model:value="searchParams.jigyocd"
                :options="options.selectorlist1"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>会場</th>
            <td>
              <ai-select
                v-model:value="searchParams.kaijocd"
                :options="options.selectorlist2"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>医療機関</th>
            <td>
              <ai-select
                v-model:value="searchParams.kikancd"
                :options="options.selectorlist3"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>担当者</th>
            <td>
              <ai-select
                v-model:value="searchParams.staffid"
                :options="options.selectorlist4"
                split-val
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" @click="handleSearch">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="goDetail({ nitteino: -1 })"
            >新規</a-button
          >
          <a-button
            type="primary"
            :disabled="!addFlg || !copyCode"
            @click="goDetail({ nitteino: copyCode, iscopy: true })"
            >コピー</a-button
          >
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <div>
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="text-end mb-2"
        />
        <vxe-table
          ref="xTableRef"
          :height="Math.max(tableHeight, 400)"
          :data="tableList"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => goDetail(row)"
        >
          <vxe-column
            v-if="columns.length > 0"
            field="nitteino"
            title="日程番号"
            width="100"
            fixed="left"
          >
            <template #default="{ row }">
              <a @click="goDetail(row)">{{ row.nitteino }}</a>
            </template>
          </vxe-column>
          <vxe-column
            v-for="item in columns.slice(1)"
            :key="item.key"
            :field="item.key"
            :title="item.title"
            min-width="150"
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import RangeDate from '@/components/Selector/RangeDate/index2.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { useTableHeight } from '@/utils/hooks'
import { ss } from '@/utils/storage'
import { computed, onMounted, reactive, ref, toRef, watch } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { InitList, SearchList } from '../service'
import { InitListResponse, SearchListRequest } from '../type'
import { useSearch } from '@/utils/hooks'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const xTableRef = ref<VxeTableInstance>()

const createDefaultParams = (): Omit<SearchListRequest, keyof CmSearchRequestBase> => ({
  nendo: ss.get(GLOBAL_YEAR),
  yoteiymdf: undefined,
  yoteiymdt: undefined,
  jigyocd: undefined,
  kaijocd: undefined,
  kikancd: undefined,
  staffid: undefined
})
const searchParams = reactive(createDefaultParams())
const options = ref<Omit<InitListResponse, keyof DaResponseBase>>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: []
})

const columns = ref<ColumnInfoVM[]>([])
const tableList = ref<StrObj[]>([])

const { loading, pageParams, totalCount, searchData } = useSearch({
  service: SearchList,
  source: tableList,
  params: toRef(() => searchParams),
  keyvalueflg: true
})
//権限フラグ
const addFlg = route.meta.addflg

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => (options.value = res))
})
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    searchData()
  }
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

const copyCode = computed<string>(() => {
  const curRow = xTableRef.value?.getCurrentRecord()
  return curRow?.nitteino ?? ''
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function handleSearch() {
  const res = await searchData()
  columns.value = res.columnInfos
  //検索結果1件の場合、詳細画面へ遷移
  if (res.totalrowcount === 1 && res.totalpagecount === 1) {
    goDetail({ nitteino: res.kekkalist[0][0].value })
  }
}

function goDetail({ nitteino, iscopy = false }) {
  router.push({
    name: route.name as string,
    query: {
      nitteino,
      nendo: searchParams.nendo,
      iscopy: iscopy ? '1' : undefined
    }
  })
}

function reset() {
  Object.assign(searchParams, createDefaultParams())
  columns.value = []
  tableList.value = []
  totalCount.value = 0
  pageParams.pagenum = 1
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 110px;
}
</style>
