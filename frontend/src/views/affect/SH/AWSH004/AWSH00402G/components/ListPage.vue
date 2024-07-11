<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.21
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
          <a-col :md="12" :lg="8" :xxl="6">
            <th>宛名番号</th>
            <td>
              <AtenanoSearch
                ref="atenanoRef"
                v-model:loading="loading"
                :params="searchParams"
                :search-request="SearchList"
                @finish="goDetailRow"
              />
            </td>
          </a-col>
          <a-col v-if="personalnoflg" :md="12" :lg="8" :xxl="6">
            <th>個人番号</th>
            <td>
              <PersonalnoSearch
                ref="personalnoRef"
                v-model:loading="loading"
                v-model:totalCount="totalCount"
                v-model:tableList="tableList"
                :params="searchParams"
                :search-request="SearchList"
                @finish="goDetailRow"
              />
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" @click="handleSearch">検索</a-button>
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
          :column-config="{ resizable: true, useKey: true }"
          :row-config="{ isCurrent: true, isHover: true, useKey: true }"
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
            :formatter="formatExceedText"
            :class-name="({ columnIndex }) => (columnIndex === 3 ? 'bg-readonly' : '')"
            :show-overflow="false"
            type="html"
            min-width="150"
            :resizable="Boolean(item.title)"
            :width="item.title ? undefined : 80"
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import RangeDate from '@/components/Selector/RangeDate/index2.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { useTableHeight } from '@/utils/hooks'
import { ss } from '@/utils/storage'
import { formatExceedText } from '@/utils/util'
import { onMounted, reactive, ref, toRef, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { InitListResponse } from '../../AWSH00401G/type'
import { InitList, SearchList } from '../service'
import { SearchListRequest } from '../type'
import { useSearch } from '@/utils/hooks'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
//テンプレート参照
const xTableRef = ref<VxeTableInstance>()
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const personalnoRef = ref<InstanceType<typeof PersonalnoSearch> | null>(null)

const createDefaultParams = (): Omit<SearchListRequest, keyof CmSearchRequestBase> => ({
  nendo: ss.get(GLOBAL_YEAR),
  yoteiymdf: undefined,
  yoteiymdt: undefined,
  jigyocd: undefined,
  kaijocd: undefined,
  kikancd: undefined,
  staffid: undefined,
  atenano: undefined,
  personalno: undefined
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
//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => (options.value = res))
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

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

function goDetail({ nitteino }) {
  router.push({
    name: route.name as string,
    query: {
      nitteino,
      nendo: searchParams.nendo
    }
  })
}

function goDetailRow(record: DataInfoVM[]) {
  router.push({
    name: route.name as string,
    query: {
      nitteino: record[0].value,
      nendo: searchParams.nendo
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
  width: 120px;
}
</style>
