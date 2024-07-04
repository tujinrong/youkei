<template>
  <a-spin :spinning="historyLoading">
    <a-card ref="headerRef" :bordered="false">
      <div class="m-t-1 flex justify-between">
        <div style="clear: both"></div>
        <a-space class="">
          <close-page></close-page>
        </a-space>
      </div>
      <div class="m-t-1 flex justify-between">
        <div></div>
        <a-pagination
          v-model:current="currentPage"
          v-model:page-size="pageSize"
          :total="totalCount"
          :show-size-changer="true"
          :page-size-options="$pagesizes"
          style="float: right; margin-bottom: 10px"
          @change="getHistoryList"
        />
      </div>
      <div class="w-full" :style="{ height: tableHeight }">
        <vxe-table
          ref="tableRef"
          height="100%"
          :header-cell-style="{ backgroundColor: '#ffffe1' }"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="resumeList"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
          @sort-change="(e) => tableChange(e)"
        >
          <vxe-column
            field="rirekiid"
            :params="{ order: 1 }"
            title="取込履歴No"
            width="120"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="regdttm"
            :params="{ order: 2 }"
            title="実行日時"
            width="250"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="reguserid"
            :params="{ order: 3 }"
            title="担当者"
            width="150"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="gyoumukbn"
            :params="{ order: 4 }"
            title="業務"
            width="150"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column field="impnm" :params="{ order: 5 }" width="250" :resizable="true" sortable>
            <template #header>{{ impnmText }}</template>
          </vxe-column>
          <vxe-column
            field="impkbn"
            :params="{ order: 6 }"
            title="一括取込入力区分"
            width="150"
            :resizable="true"
            sortable
          ></vxe-column>
          <vxe-column
            field="filename"
            :params="{ order: 7 }"
            title="ファイル"
            width="250"
            :resizable="true"
            sortable
          >
            <template #default="{ row }">
              <a @click="downloadFile(row.rirekiid)">{{ row.filename }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="regcnt"
            :params="{ order: 8 }"
            title="処理件数"
            width="140"
            :resizable="true"
            sortable
          ></vxe-column>
          <vxe-column
            field="errcnt"
            :params="{ order: 9 }"
            title="エラー件数"
            min-width="140"
            :resizable="true"
            sortable
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//取込履歴
//---------------------------------------------------------------------------

import { computed, onMounted, ref, toRef, watch } from 'vue'
import { changeTableSort } from '@/utils/util'
import { getHeight } from '@/utils/height'
import { KimpHistoryRowVM, SearchKimpListRequest } from '../type'
import { InitSearchKimpHistoryList, KimpHistoryFileDown } from '../service'
import { Enum取込区分 } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  gyoumukbn: string
  impkbn: string
}>()
//---------------------------------------------------------------------------
//データ定義(data(ref…))
//---------------------------------------------------------------------------
//ページャー
const totalCount = ref(0)
const currentPage = ref(1)
const pageSize = ref(25)
const oldPageSize = ref(0)
//ローディング
const historyLoading = ref(false)
//ビューモデル
const resumeList = ref<KimpHistoryRowVM[]>([])
const queryParam = ref<SearchKimpListRequest>({
  pagenum: 1,
  pagesize: 25,
  gyoumukbn: '',
  impnm: ''
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  let screenHeight = window.innerHeight
  let computeHeight = 0
  if (screenHeight >= 1080) {
    computeHeight = 231
  } else {
    computeHeight = 220
  }
  return getHeight(computeHeight)
})

const impnmText = computed(() => {
  if (queryParam.value.impkbn) {
    return queryParam.value.impkbn === Enum取込区分.ファイル取込.toString()
      ? '一括取込内容'
      : '一括入力内容'
  }
  return ''
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  queryParam.value.gyoumukbn = props.gyoumukbn
  queryParam.value.impkbn = props.impkbn
  getHistoryList(1, 10)
})
//--------------------------------------------------------------------------
//メソッド(methods)
//---------------------------------------------------------------------------

//出力履歴検索処理
const getHistoryList = (index, size) => {
  historyLoading.value = true
  if (oldPageSize.value != size) {
    queryParam.value.pagenum = 1
  } else {
    queryParam.value.pagenum = index
  }
  queryParam.value.pagesize = size
  oldPageSize.value = size
  InitSearchKimpHistoryList(queryParam.value)
    .then((res) => {
      resumeList.value = res.kimpHistoryList
      totalCount.value = res.totalrowcount
    })
    .finally(() => {
      historyLoading.value = false
    })
}
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(queryParam.value, () => {
  if (resumeList.value.length > 0 || totalCount.value > 0)
    getHistoryList(queryParam.value.pagenum, queryParam.value.pagesize)
})
//ソート
const tableChange = (e) => {
  changeTableSort(e, toRef(queryParam.value, 'orderby'))
}
//
const downloadFile = (id) => {
  historyLoading.value = true
  KimpHistoryFileDown({ rirekiid: id }).finally(() => {
    historyLoading.value = false
  })
}
</script>
<style scoped lang="less">
:deep(.ant-table-thead > tr > th) {
  border-bottom: 1px solid #606266;
  font-weight: bold;
}

:deep(.ant-table.ant-table-bordered > .ant-table-container > .ant-table-content > table) {
  border: 1px solid #606266;
}
:deep(
    .ant-table.ant-table-bordered
      > .ant-table-container
      > .ant-table-content
      > table
      > tbody
      > tr
      > td
  ) {
  border-right: 1px solid #c0c4cc;
}
:deep(
    .ant-table.ant-table-bordered
      > .ant-table-container
      > .ant-table-content
      > table
      > thead
      > tr
      > th
  ) {
  border-right: 1px solid #c0c4cc;
}
:deep(.ant-table-tbody > tr > td) {
  border-bottom: 1px solid #606266;
}

:deep(.ant-table.ant-table-middle .ant-table-tbody > tr > td) {
  padding: 6px !important;
}

:deep(.ant-table.ant-table-middle .ant-table-thead > tr > th) {
  padding: 6px !important;
}

:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}

:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}

:deep(.ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
</style>
