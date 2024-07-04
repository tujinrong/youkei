<template>
  <a-card ref="headRef" :bordered="false">
    <div class="self_adaption_table form">
      <a-row>
        <a-col v-bind="layout">
          <th>業務</th>
          <td>
            <ai-select
              v-model:value="searchParams.gyoumucd"
              :options="selector1Options"
              style="width: 100%"
              allow-clear
            ></ai-select>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>帳票グループ</th>
          <td>
            <ai-select
              v-model:value="searchParams.rptgroupid"
              split-val
              :options="selector2Options"
              style="width: 100%"
              allow-clear
            ></ai-select>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>帳票名</th>
          <td>
            <a-input v-model:value="searchParams.rptnm" style="width: 100%" />
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>様式名</th>
          <td>
            <a-input v-model:value="searchParams.yosikinm" style="width: 100%"></a-input>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>様式分類</th>
          <td>
            <a-select
              v-model:value="searchParams.yoshikibunrui"
              :options="selector3Options"
              style="width: 100%"
              allow-clear
            ></a-select>
          </td>
        </a-col>
        <a-col v-bind="layout">
          <th>様式種別</th>
          <td>
            <a-select
              v-model:value="searchParams.yosikisyubetu"
              :options="selector4Options"
              style="width: 100%"
              allow-clear
            ></a-select>
          </td>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button type="primary" @click="searchData">検索</a-button>
        <a-button type="primary" :disabled="!addFlg" @click="handleNew">新規</a-button>
        <a-button type="primary" @click="handleManage">公印設定</a-button>
        <a-button type="primary" @click="reset">クリア</a-button>
      </a-space>
      <a-space class="">
        <close-page></close-page>
      </a-space>
    </div>
  </a-card>
  <a-card class="mt-2">
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
      class="mb-2 text-end"
    />
    <vxe-table
      :height="Math.max(tableHeight, 400)"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableList"
      :sort-config="{
        trigger: 'cell',
        remote: true
      }"
      :empty-render="{ name: 'NotData' }"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      @cell-dblclick="({ row }) => openEdit(row)"
    >
      <vxe-column field="gyoumu" :params="{ order: 1 }" title="業務" width="100" sortable>
      </vxe-column>
      <vxe-column
        field="rptgroupnm"
        :params="{ order: 2 }"
        title="帳票グループ"
        min-width="150"
        sortable
      >
      </vxe-column>
      <vxe-column field="rptid" :params="{ order: 3 }" title="帳票ID" min-width="80" sortable>
      </vxe-column>
      <vxe-column field="rptnm" :params="{ order: 4 }" title="帳票名" min-width="260" sortable>
      </vxe-column>
      <vxe-column field="yosikiideda" :params="{ order: 5 }" title="様式ID" min-width="80" sortable>
        <template #default="{ row }">
          <a @click="openEdit(row)">{{ row.yosikiideda }}</a>
        </template>
      </vxe-column>
      <vxe-column field="yosikidenm" :params="{ order: 6 }" title="様式名" min-width="320" sortable>
        <template #default="{ row }">
          <a @click="openEdit(row)">{{ row.yosikidenm }}</a>
        </template>
      </vxe-column>
      <vxe-column field="kbn" :params="{ order: 7 }" title="様式分類" min-width="100" sortable>
        <template #default="{ row }"> {{ Enum帳票様式[row.kbn] }} </template>
      </vxe-column>
      <vxe-column
        field="yosikisyubetu"
        :params="{ order: 8 }"
        title="帳票種別"
        min-width="100"
        sortable
      >
        <template #default="{ row }">
          {{ Enum様式種別[row.yosikisyubetu] }}
        </template>
      </vxe-column>
      <vxe-column
        field="datasourcenm"
        :params="{ order: 9 }"
        title="データソース"
        min-width="360"
        sortable
        :resizable="false"
      >
      </vxe-column>
    </vxe-table>
  </a-card>

  <AddModal v-model:visible="addVisible" v-bind="{ selector4Options }"></AddModal>
  <ManageModal v-model:visible="manageVisible"></ManageModal>
</template>

<script setup lang="ts">
import { ref, reactive, toRef } from 'vue'
import { onBeforeRouteUpdate, useRouter, useRoute } from 'vue-router'
import AddModal from '@/views/affect/EU/AWEU00202D/AWEU00202D.vue'
import ManageModal from '@/views/affect/EU/AWEU00206D/index.vue'
import { SearchList } from '../service'
import { SearchListRequest, SearchVM } from '../type'
import { changeTableSort } from '@/utils/util'
import { PageSatatus, Enum様式種別, Enum帳票様式 } from '#/Enums'
import { EUCStore } from '@/store'
import { useTableHeight } from '@/utils/hooks'
import { useSearch } from '@/utils/hooks'

const layout = {
  md: 8,
  xxl: 8
}

const props = defineProps<{
  selector1Options: DaSelectorModel[]
  selector2Options: DaSelectorModel[]
  selector3Options: DaSelectorModel[]
  selector4Options: DaSelectorModel[]
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

//ビューモデル
const addVisible = ref<boolean>(false)
const manageVisible = ref<boolean>(false)

const createDefaultParams = () => ({
  gyoumucd: undefined, // 業務コード
  rptgroupid: undefined, // 帳票グループID
  rptnm: undefined, //　帳票名
  yosikisyubetu: undefined, // 様式種別
  yoshikibunrui: undefined, // 様式分類
  yosikinm: undefined //様式名
})

const searchParams = reactive<Partial<SearchListRequest>>(createDefaultParams())

const tableList = ref<SearchVM[]>([])

const { pageParams, totalCount, searchData, clear } = useSearch({
  service: SearchList,
  source: tableList,
  params: toRef(() => searchParams)
})
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)
const addFlg = route.meta.addflg

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

onBeforeRouteUpdate((to, from) => {
  if (from.query.status) {
    searchData()
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const handleNew = () => {
  addVisible.value = true
}

// 帳票管理
const handleManage = () => {
  manageVisible.value = true
}

//画面遷移
const openEdit = (rowValue: SearchVM) => {
  EUCStore['201_params'] = rowValue
  router.push({
    name: 'AWEU00201G',
    query: {
      status: PageSatatus.Edit
    }
  })
}

//クリア
function reset() {
  Object.assign(searchParams, createDefaultParams())
  clear()
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}

th {
  width: 120px;
}

td {
  width: 140px;
}
</style>
