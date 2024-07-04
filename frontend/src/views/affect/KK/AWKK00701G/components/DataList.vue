<template>
  <a-card :bordered="false">
    <a-row :gutter="[0, 10]">
      <a-col :xs="12" :sm="12" :md="12" :lg="12" :xl="9" :xxl="6">
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 50px">{{ impnmText }}</th>
                <td style="width: 110px">
                  <a-input v-model:value="queryParam.impnm" style="width: 100%" />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-col>
    </a-row>
    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button type="primary" @click.prevent="getTableList(1, queryParam.pagesize)"
          >検索</a-button
        >
      </a-space>
      <a-space class="">
        <close-page></close-page>
      </a-space>
    </div>
  </a-card>
  <a-card class="flex-1 m-t-1">
    <a-pagination
      v-model:current="queryParam.pagenum"
      v-model:page-size="queryParam.pagesize"
      :total="totalCount"
      :show-size-changer="true"
      :page-size-options="$pagesizes"
      style="float: right; margin-bottom: 10px"
      @change="pageChange"
    />
    <div class="m-t-1 w-full" :style="{ height: tableHeight }">
      <vxe-table
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
          <template #default="{ row }: { row: KimpRowVM, rowIndex: number }">
            <a @click="onExecute(row)">{{ row.impno }}</a>
          </template>
        </vxe-column>
        <vxe-column field="impnm" :params="{ order: 2 }" width="350" :resizable="true" sortable>
          <template #header>{{ impnmText }}</template>
          <template #default="{ row }: { row: KimpRowVM, rowIndex: number }">
            <a @click="onExecute(row)">{{ row.impnm }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="impkbn"
          :params="{ order: 3 }"
          title="一括取込入力区分"
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
        <vxe-column
          field="memo"
          :params="{ order: 5 }"
          title="説明"
          min-width="500"
          :resizable="true"
          sortable
        ></vxe-column>
      </vxe-table>
    </div>
  </a-card>
  <FileUploadModal
    v-model:visible="visible"
    :param="param"
    :impno="param?.impno!"
  ></FileUploadModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//一覧へ
//--------------------------------------------------------------------------
import { ref, computed, toRef, watch, onMounted } from 'vue'
import { KimpRowVM, SearchKimpListRequest } from '../type'
import FileUploadModal from '../../AWKK00702D/index.vue'
import { getHeight } from '@/utils/height'
import { changeTableSort } from '@/utils/util'
import { SearchKimpList } from '../service'
import { useRoute, useRouter } from 'vue-router'
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
const route = useRoute()
const router = useRouter()
//ページャー
const totalCount = ref(0)
const oldPageSize = ref(25)
//ビューモデル
const tableList = ref<KimpRowVM[]>([])
const queryParam = ref<SearchKimpListRequest>({
  pagenum: 1,
  pagesize: 25,
  gyoumukbn: '',
  impnm: ''
})
const visible = ref(false)
const param = ref<KimpRowVM>()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => {
  let screenHeight = window.innerHeight
  let computeHeight = 0
  if (screenHeight >= 1080) {
    computeHeight = 100
  } else {
    computeHeight = 290
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
  queryParam.value.gyoumukbn = props.gyoumukbn || (route.query.gyoumukbn as string)
  queryParam.value.impkbn = props.impkbn || (route.query.impkbn as string)
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props,
  () => {
    queryParam.value.gyoumukbn = props.gyoumukbn
    queryParam.value.impkbn = props.impkbn
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理

//検索処理
const getTableList = (index, size) => {
  if (oldPageSize.value != size) {
    queryParam.value.pagenum = 1
  } else {
    queryParam.value.pagenum = index
  }
  queryParam.value.pagesize = size
  oldPageSize.value = size
  if (queryParam.value.gyoumukbn) {
    queryParam.value.gyoumukbn = queryParam.value.gyoumukbn.split(':')[0].trim()
  }
  SearchKimpList(queryParam.value).then((res) => {
    tableList.value = res.kimpList
    totalCount.value = res.totalrowcount
  })
}
//画面遷移
const onExecute = (val: KimpRowVM) => {
  //一括取込入力区分がファイル取込の場合、一覧のリンクでファイルアップロード画面を表示する
  if (val.impkbn == 'ファイル取込') {
    param.value = val
    visible.value = true
  }
  //一括取込入力区分が一括入力の場合、一覧のリンクでデータ編集画面の新規モードに遷移する
  else {
    router.push({
      path: route.name as string,
      query: {
        impno: val.impno,
        status: '1',
        mode: '1'
      }
    })
  }
}
//ソート
const tableChange = (e) => {
  changeTableSort(e, toRef(queryParam.value, 'orderby'))
  if (tableList.value.length > 0 || totalCount.value > 0) {
    getTableList(queryParam.value.pagenum, queryParam.value.pagesize)
  }
}
//ページバー
const pageChange = () => {
  if (tableList.value.length > 0 || totalCount.value > 0) {
    getTableList(queryParam.value.pagenum, queryParam.value.pagesize)
  }
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

.flex-1 :deep(.ant-card-body) {
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: end;
}
</style>
