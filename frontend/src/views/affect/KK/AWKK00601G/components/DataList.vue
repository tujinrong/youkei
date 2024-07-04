<template>
  <a-card ref="headRef" :bordered="false">
    <div class="self_adaption_table form">
      <a-row :gutter="[0, 0]">
        <a-col :md="18" :xl="8" :xxl="8">
          <th>業務</th>
          <td>
            <ai-select
              v-model:value="queryParam.gyoumukbn"
              :options="groupOptions"
              style="width: 100%"
              tabindex="1"
              split-val
            ></ai-select></td
        ></a-col>
        <a-col :md="18" :xl="8" :xxl="8">
          <th>一括取込入力名</th>
          <td>
            <a-input v-model:value="queryParam.impnm" style="width: 100%" />
          </td>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 flex justify-between">
      <a-space>
        <a-button type="primary" @click.prevent="getTableList(1, queryParam.pagesize)"
          >検索</a-button
        >
        <a-button type="primary" :disabled="!addflg" @click.prevent="onExecute">新規</a-button>
        <a-button type="primary" :disabled="!currentRowStatus" @click="download"
          >ダウンロード</a-button
        >
        <a-button
          type="primary"
          :disabled="!updflg || !currentRowStatus"
          @click.prevent="upload(Enum編集区分.変更)"
          >アップロード(更新)</a-button
        >
        <a-button type="primary" :disabled="!addflg" @click.prevent="upload(Enum編集区分.新規)"
          >アップロード(新規)</a-button
        >
      </a-space>
      <a-space class="">
        <close-page></close-page>
      </a-space>
    </div>
  </a-card>
  <a-card class="mt-2">
    <a-pagination
      v-model:current="queryParam.pagenum"
      v-model:page-size="queryParam.pagesize"
      :total="totalCount"
      :show-size-changer="true"
      :page-size-options="$pagesizes"
      show-less-items
      class="text-end mb-2"
      @change="pageChange"
    />
    <vxe-table
      ref="xTable"
      :height="tableHeight"
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
        <template #default="{ row }: { row: RowVM, rowIndex: number }">
          <a @click="onExecute(row)">{{ row.impno }}</a>
        </template>
      </vxe-column>
      <vxe-column
        field="impnm"
        :params="{ order: 2 }"
        title="一括取込入力名"
        width="350"
        :resizable="true"
        sortable
      >
        <template #default="{ row }: { row: RowVM, rowIndex: number }">
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
        :resizable="true"
        sortable
      ></vxe-column>
    </vxe-table>
  </a-card>
  <UploadModal
    v-model:visible="outputVisible"
    :impnm="curr?.impnm"
    :impno="curr?.impno"
    :editkbn="editkbn"
    @init-data="initTabData"
  ></UploadModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//一覧へ
//--------------------------------------------------------------------------
import { ref, onMounted, toRef, watch, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { SelectProps, message } from 'ant-design-vue'
import { SearchListRequest, RowVM } from '../type'
import { Download, InitList, Search } from '../service'
import { EnumServiceResult } from '#/Enums'
import { changeTableSort } from '@/utils/util'
import { useTableHeight } from '@/utils/hooks'
import UploadModal from '../../AWKK00606D/index.vue'
import { VxeTableInstance } from 'vxe-table'
import { Enum編集区分 } from '#/Enums'
import { ImporterStore } from '@/store'
import { showConfirmModal } from '@/utils/modal'
import { DOWNLOAD_CONFIRM, DOWNLOAD_OK_INFO } from '@/constants/msg'
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const xTable = ref<VxeTableInstance>()
//ページャー
const totalCount = ref(0)
const oldPageSize = ref(25)
const editkbn = ref<Enum編集区分>(Enum編集区分.新規)
//ローディング
const loading = ref(false)
const addflg = ref(false)
const updflg = ref(false)
const outputVisible = ref(false)
//ビューモデル
const tableList = ref<RowVM[]>([])
const curr = ref<RowVM>()
const queryParam = ref<SearchListRequest>({ pagenum: 1, pagesize: 25 })
const groupOptions = ref<SelectProps['options']>([])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)
const currentRowStatus = computed<boolean>(() => {
  if (xTable.value?.getCurrentRecord()) return true
  return false
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => xTable.value?.getCurrentRecord(),
  (val) => {
    curr.value = val === null ? undefined : val
  }
)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  addflg.value = route.meta.addflg as boolean
  updflg.value = route.meta.updflg as boolean
  InitList().then((res) => {
    groupOptions.value = res.gyoumuSelectorList
  })
}

//検索処理
const getTableList = (index, size) => {
  if (oldPageSize.value != size) {
    queryParam.value.pagenum = 1
  } else {
    queryParam.value.pagenum = index
  }
  queryParam.value.pagesize = size
  oldPageSize.value = size
  Search(queryParam.value).then((res) => {
    if (res.returncode === EnumServiceResult.OK) {
      tableList.value = res.kekkaList
      totalCount.value = res.totalrowcount
    } else {
      tableList.value = []
    }
  })
}

//画面遷移
const onExecute = (val) => {
  router.push({
    path: 'AWKK00601G',
    query: {
      ...val,
      status: '1'
    }
  })
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

//アップロード処理
const upload = (editkbnn: Enum編集区分) => {
  editkbn.value = editkbnn
  if (editkbn.value === Enum編集区分.新規) {
    xTable.value?.setCurrentRow(null)
  }
  outputVisible.value = true
}
const initTabData = (data, isFileImport: string) => {
  ImporterStore.setUploadData(data)
  router.push({
    path: 'AWKK00601G',
    query: {
      isUpload: '1',
      impno: curr.value?.impno,
      isFileImport,
      status: '1'
    }
  })
}

//ダウンロード処理
const download = () => {
  executeDownload()
}
const executeDownload = () => {
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      try {
        await Download({ impno: curr.value?.impno })
        message.success(DOWNLOAD_OK_INFO.Msg)
      } catch (error) {}
    }
  })
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

th {
  width: 120px;
}
</style>
