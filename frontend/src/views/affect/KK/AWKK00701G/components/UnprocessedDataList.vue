<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div class="m-t-1 flex justify-between">
        <a-space class="">
          <a-button type="primary" danger :disabled="checkedList.length == 0" @click="deleteTable"
            >削除</a-button
          >
        </a-space>
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
          @change="getTableList"
        />
      </div>

      <div class="w-full" :style="{ height: tableHeight }">
        <vxe-table
          ref="tableRef"
          height="100%"
          :header-cell-style="{ backgroundColor: '#ffffe1' }"
          :column-config="{ resizable: true }"
          :row-config="{ isCurrent: true, isHover: true }"
          :data="tableList"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
          :loading="pageLoading"
          @sort-change="(e) => tableChange(e)"
        >
          <vxe-column
            field="impno"
            :params="{ order: 1 }"
            title="一括取込入力No"
            width="150"
            :resizable="true"
            sortable
          >
            <template #default="{ row }">
              <a @click="onExecute(row)">{{ row.impno }}</a>
            </template>
          </vxe-column>
          <vxe-column field="impnm" :params="{ order: 2 }" width="250" :resizable="true" sortable>
            <template #header>{{ impnmText }}</template>
            <template #default="{ row }">
              <a @click="onExecute(row)">{{ row.impnm }}</a>
            </template>
          </vxe-column>
          <vxe-column
            field="gyoumukbn"
            :params="{ order: 3 }"
            title="業務"
            width="150"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="filename"
            :params="{ order: 4 }"
            title="ファイル"
            width="250"
            :resizable="true"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="totalcnt"
            :params="{ order: 5 }"
            title="件数"
            width="100"
            :resizable="true"
            sortable
          ></vxe-column>
          <vxe-column
            field="errcnt"
            :params="{ order: 6 }"
            title="エラー件数"
            width="100"
            :resizable="true"
            sortable
          ></vxe-column>
          <vxe-column
            field="upduserid"
            :params="{ order: 7 }"
            title="前回更新者"
            :resizable="true"
            min-width="150"
            sortable
          ></vxe-column>
          <vxe-column
            field="upddttmShow"
            :params="{ order: 8 }"
            title="前回更新時間"
            min-width="250"
            :resizable="true"
            sortable
          ></vxe-column>
        </vxe-table>
      </div>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//一覧へ
//--------------------------------------------------------------------------
import { ref, onMounted, toRef, computed, watch } from 'vue'
import { message } from 'ant-design-vue'
import { useRoute, useRouter } from 'vue-router'
import { changeTableSort } from '@/utils/util'
import { getHeight } from '@/utils/height'
import { showDeleteModal } from '@/utils/modal'
import { DELETE_OK_INFO } from '@/constants/msg'
import { KimpDataRowVM, LockVM, SearchKimpListRequest } from '../type'
import { DeleteKimpList, InitSearchKimpDataList } from '../service'
import { Enum取込区分 } from '#/Enums'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  gyoumukbn: string
  impkbn: string
}>()
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
//ページャー
const currentPage = ref(1)
const pageSize = ref(25)
const totalCount = ref(0)
const oldPageSize = ref(0)
//ローディング
const pageLoading = ref(false)
const loading = ref(false)
//ビューモデル
const tableList = ref<KimpDataRowVM[]>([])
const checkedList = ref<KimpDataRowVM[]>([])
const queryParam = ref<SearchKimpListRequest>({
  gyoumukbn: '1',
  pagenum: 1,
  pagesize: 25,
  impnm: ''
})
const tableRef = ref()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  let screenHeight = window.innerHeight
  let computeHeight = 0
  if (screenHeight >= 1080) {
    computeHeight = 232
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

watch(
  () => tableRef.value?.getCurrentRecord(),
  (newValue) => {
    if (newValue) {
      checkedList.value = [newValue]
    } else {
      checkedList.value = []
    }
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  queryParam.value.gyoumukbn = props.gyoumukbn || (route.query.gyoumukbn as string)
  queryParam.value.impkbn = props.impkbn || (route.query.impkbn as string)
  getInitData()
})

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  loading.value = true
  getTableList(1, pageSize.value)
  loading.value = false
}

//検索処理
const getTableList = (index, size) => {
  pageLoading.value = true
  if (oldPageSize.value != size) {
    queryParam.value.pagenum = 1
  } else {
    queryParam.value.pagenum = index
  }
  queryParam.value.pagesize = size
  oldPageSize.value = size
  InitSearchKimpDataList(queryParam.value)
    .then((res) => {
      tableList.value = res.kimpDataList
      totalCount.value = res.totalrowcount
    })
    .finally(() => {
      pageLoading.value = false
      checkedList.value = []
    })
}
//画面遷移
const onExecute = (val: KimpDataRowVM) => {
  router.push({
    path: route.name as string,
    query: {
      impexeid: val.impexeid,
      impno: val.impno,
      gyoumukbn: queryParam.value.gyoumukbn,
      impkbn: queryParam.value.impkbn,
      status: '1',
      mode: '2'
    }
  })
}

//削除処理
const deleteTable = () => {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        const lockList: LockVM[] = checkedList.value.map((item) => {
          return { impexeid: item.impexeid + '', upddttm: item.upddttm }
        })
        loading.value = true
        await DeleteKimpList({ lockList: lockList })
        message.success(DELETE_OK_INFO.Msg)
        getTableList(queryParam.value.pagenum, queryParam.value.pagesize)
        loading.value = false
      } catch (e) {
        getTableList(queryParam.value.pagenum, queryParam.value.pagesize)
        loading.value = false
      }
    }
  })
}
//ソート
const tableChange = (e) => {
  changeTableSort(e, toRef(queryParam.value, 'orderby'))
  getTableList(queryParam.value.pagenum, queryParam.value.pagesize)
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}
</style>
