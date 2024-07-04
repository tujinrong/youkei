<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>業務</th>
            <td>
              <ai-select
                v-model:value="searchParams.gyomukbn"
                :options="opts"
                split-val
                @change="onChangeOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="16" :xxl="12">
            <th>実施予定日</th>
            <td>
              <RangeDate
                v-model:value1="searchParams.jissiyoteiymdf"
                v-model:value2="searchParams.jissiyoteiymdt"
              />
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>事業名</th>
            <td>
              <ai-select
                v-model:value="searchParams.jigyocd"
                :options="keyoptions"
                split-val
                @change="onChangeKeyOpt"
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>コース名</th>
            <td>
              <a-input v-model:value="searchParams.coursenm" allow-clear :maxlength="50"></a-input>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>回数</th>
            <td>
              <a-input-number
                v-model:value="searchParams.kaisu"
                :min="1"
                :max="99"
                :precision="0"
              ></a-input-number>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>会場</th>
            <td>
              <ai-select
                v-model:value="searchParams.kaijocd"
                :options="options.selectorlist3"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>医療機関</th>
            <td>
              <ai-select
                v-model:value="searchParams.kikancd"
                :options="options.selectorlist4"
                split-val
              ></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>担当者</th>
            <td>
              <ai-select
                v-model:value="searchParams.staffid"
                :options="options.selectorlist5"
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
                :search-request="SearchNitteiList"
                @finish="goNextList"
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
                v-model:tableList="tableData"
                :params="searchParams"
                :search-request="SearchNitteiList"
                @finish="goNextList"
              />
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex">
        <a-space>
          <a-button
            type="primary"
            :disabled="atenanoRef?.focused || personalnoRef?.focused"
            @click="handleSearch"
            >検索</a-button
          >
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>

    <a-card class="mt-2">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :total="totalCount"
        :page-size-options="$pagesizes"
        show-less-itemsw
        show-size-changer
        class="text-end mb-2"
      />
      <vxe-table
        ref="xTableRef"
        :height="Math.max(tableHeight, 400)"
        :loading="pageLoading"
        :column-config="{ resizable: true, useKey: true }"
        :row-config="{ isCurrent: true, isHover: true, keyField: 'nitteino', useKey: true }"
        :data="tableData"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goNextList(row, row.courseno != null)"
      >
        <vxe-column field="nitteino" title="日程番号" width="100" min-width="100">
          <template #default="{ row }">
            <a @click="goNextList(row)">{{ row.nitteino }}</a>
          </template>
        </vxe-column>
        <vxe-column field="gyomukbnnm" title="業務" min-width="100"></vxe-column>
        <vxe-column field="courseno" title="コース番号" min-width="100">
          <template #default="{ row }">
            <a @click="goNextList(row, true)">{{ row.courseno }}</a>
          </template>
        </vxe-column>
        <vxe-column field="coursenm" title="コース名" min-width="100"></vxe-column>
        <vxe-column field="kaisu" title="回数" min-width="100"></vxe-column>
        <vxe-column field="jigyonm" title="事業名" min-width="100"></vxe-column>
        <vxe-column field="jissinaiyo" title="実施内容" min-width="100"></vxe-column>
        <vxe-column
          field="jissiyoteiymd"
          title="実施予定日"
          formatter="jpDate"
          min-width="100"
        ></vxe-column>
        <vxe-column field="time" title="時間" min-width="100"></vxe-column>
        <vxe-column field="kaijonm" title="会場" min-width="100"></vxe-column>
        <vxe-column field="kikannm" title="医療機関" min-width="100"></vxe-column>
        <vxe-column field="staffidnms" title="担当者" min-width="100"></vxe-column>
        <vxe-column
          field="status"
          title="状態"
          type="html"
          :formatter="formatExceedText"
          min-width="100"
        ></vxe-column>
        <vxe-column field="ninzu" title="申/定員" min-width="100"></vxe-column>
        <vxe-column field="taikinum" title="待機" min-width="100"></vxe-column>
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { reactive, ref, toRef } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { useLinkOption, useTableHeight, useSearch } from '@/utils/hooks'
import { VxeTableInstance } from 'vxe-table'
import RangeDate from '@/components/Selector/RangeDate/index2.vue'
import AtenanoSearch from '@/components/Search/AtenanoSearch.vue'
import PersonalnoSearch from '@/components/Search/PersonalnoSearch.vue'
import { formatExceedText } from '@/utils/util'
import { InitNitteiListResponse, NitteiRowVM, SearchNitteiListRequest } from '../type'
import { SearchNitteiList } from '../service'
import dayjs, { Dayjs } from 'dayjs'

enum PageStatus {
  List1 = 1,
  List2,
  List3
}
const props = defineProps<{
  options: Omit<InitNitteiListResponse, keyof DaResponseBase>
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const xTableRef = ref<VxeTableInstance>()
const atenanoRef = ref<InstanceType<typeof AtenanoSearch> | null>(null)
const personalnoRef = ref<InstanceType<typeof PersonalnoSearch> | null>(null)
const createDefaultParams = (): Omit<SearchNitteiListRequest, keyof CmSearchRequestBase> => ({
  gyomukbn: undefined,
  jissiyoteiymdf: dayjs().format('YYYY-MM-DD'),
  jissiyoteiymdt: undefined,
  jigyocd: undefined,
  kaijocd: undefined,
  kikancd: undefined,
  staffid: undefined,
  coursenm: undefined,
  kaisu: undefined,
  atenano: undefined,
  personalno: undefined
})

const searchParams = reactive(createDefaultParams())
const tableData = ref<NitteiRowVM[]>([])
const {
  loading: pageLoading,
  pageParams,
  totalCount,
  searchData,
  clear
} = useSearch({
  service: SearchNitteiList,
  source: tableData,
  params: toRef(() => searchParams)
})

//Options連動(事業名、業務)
const {
  keyoptions,
  options: opts,
  onChangeKeyOpt,
  onChangeOpt,
  resetOpts
} = useLinkOption(
  toRef(() => props.options.selectorlist2),
  toRef(() => props.options.selectorlist1)
)
//権限フラグ
const personalnoflg = route.meta.personalnoflg

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

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
  //検索結果1件の場合、詳細画面へ遷移
  if (res.totalrowcount === 1 && res.totalpagecount === 1) {
    goNextList(res.kekkalist[0], res.kekkalist[0].courseno != null)
  }
}

//画面遷移
const goNextList = (record: NitteiRowVM, goCourse = false) => {
  router.push({
    name: route.name as string,
    query: {
      nitteino: record.nitteino,
      courseno: record.courseno,
      status: goCourse ? PageStatus.List2 : PageStatus.List3
    }
  })
}

function reset() {
  resetOpts()
  clear()
  Object.assign(searchParams, createDefaultParams())
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 130px;
}
</style>
