<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票発行履歴管理(一覧画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="tableLoading">
    <a-card :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="8">
            <th style="width: 130px">帳票名</th>
            <td>
              <ai-select v-model:value="searchParams.rptid" :options="rptidList"></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="8">
            <th style="width: 130px">様式名</th>
            <td>
              <ai-select v-model:value="searchParams.yosikiid" :options="yosikiidList"></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="8">
            <th>年度</th>
            <td>
              <year-jp v-model:value="searchParams.nendo" />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :lg="8" :xxl="8">
            <th style="width: 130px">抽出対象</th>
            <td>
              <ai-select v-model:value="searchParams.taisyocd" :options="taisyocdList"></ai-select>
            </td>
          </a-col>
          <a-col :md="12" :lg="16" :xxl="8">
            <th>発行日時</th>
            <td>
              <RangeDate v-model:value="searchParams.hakkodtTime" />
            </td>
          </a-col>
        </a-row>
      </div>

      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="getTableList">検索</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="my-2" :style="{ height: tableHeight }">
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
          :height="tableHeight"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="dataSource"
          :empty-render="{ name: 'NotData' }"
        >
          <vxe-column field="yosikinm" title="様式名" width="330"></vxe-column>
          <vxe-column field="rptnm" title="帳票名" width="330"></vxe-column>
          <vxe-column field="nendo" title="年度" width="130"></vxe-column>
          <vxe-column field="hakkodttm" title="発行日時" width="300"></vxe-column>
          <vxe-column field="hakkoninsu" title="発行人数" width="130"></vxe-column>
          <vxe-column field="taisyocd" title="抽出対象" width="400"></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import { useTableHeight } from '@/utils/hooks'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import { RowVM } from '../type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const tableLoading = ref(false)
//ページャー
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1
})
const createDefaultParams = () => {
  return {
    rptid: '',
    yosikiid: '',
    nendo: ss.get(GLOBAL_YEAR),
    taisyocd: '',
    hakkodtTime: { value1: '', value2: '' }
  }
}
const searchParams = reactive(createDefaultParams())
const rptidList = ref<DaSelectorModel[]>([])
const yosikiidList = ref<DaSelectorModel[]>([])
const taisyocdList = ref<DaSelectorModel[]>([])
const dataSource = ref<RowVM[]>([])

//Options連動

//新规権限フラグ
const addFlg = route.meta.addflg

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (dataSource.value.length > 0 || totalCount.value > 0) getTableList()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => {
    rptidList.value = res.selectorlist1
    yosikiidList.value = res.selectorlist2
    taisyocdList.value = res.selectorlist3
  })
})
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    getTableList()
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function forwardNew() {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New
    }
  })
}

//検索処理
const getTableList = () => {
  tableLoading.value = true
  SearchList({
    ...pageParams,
    ...searchParams,
    hakkodttmf: searchParams.hakkodtTime.value1,
    hakkodttmt: searchParams.hakkodtTime.value2
  })
    .then((res) => {
      totalCount.value = res.totalrowcount
      dataSource.value = res.kekkalist
    })
    .finally(() => {
      tableLoading.value = false
    })
}
const resetFields = () => {
  Object.assign(searchParams, createDefaultParams())
  dataSource.value = []
  totalCount.value = 0
  pageParams.pagenum = 1
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
