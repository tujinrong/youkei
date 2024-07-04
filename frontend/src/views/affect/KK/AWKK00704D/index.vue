<template>
  <a-modal
    v-model:visible="props.visible"
    title="エラー一覧"
    :closable="false"
    :maskClosable="false"
    width="1200px"
    destroy-on-close
    @cancel="closeModal"
  >
    <a-spin :spinning="loading">
      <div class="flex-1" :bordered="false">
        <a-pagination
          v-model:current="currentPage"
          v-model:page-size="pageSize"
          :total="totalCount"
          :show-size-changer="true"
          :pageSizeOptions="$pagesizes"
          style="margin-bottom: 10px; float: right"
          @change="getTableList"
        />

        <div class="m-t-1 w-full" style="height: 600px">
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
            @sort-change="(e) => changeTableSort(e, toRef(searchParams, 'orderby'))"
          >
            <vxe-column field="no" title="No" width="100" :resizable="true"> </vxe-column>
            <vxe-column field="rowno" title="行" width="100" :resizable="true">
              <template #default="{ row }">
                <a @click="setCurrentRow(row.rowno)">{{ row.rowno }}</a>
              </template>
            </vxe-column>
            <vxe-column
              field="atenano"
              :params="{ order: 2 }"
              title="宛名番号"
              width="150"
              :resizable="true"
              sortable
            ></vxe-column>
            <vxe-column
              field="shimei"
              :params="{ order: 2 }"
              title="氏名"
              width="150"
              :resizable="true"
              sortable
            ></vxe-column>
            <vxe-column field="itemnm" title="項目名" width="150" :resizable="true"> </vxe-column>
            <vxe-column field="val" title="項目値" width="100" :resizable="true"> </vxe-column>
            <vxe-column
              field="msg"
              title="エラー内容"
              min-width="300"
              :resizable="true"
            ></vxe-column>
          </vxe-table>
        </div>
      </div>
    </a-spin>
    <template #footer>
      <a-button
        type="primary"
        :loading="loading"
        style="float: left"
        @click.prevent="downloadFile"
        :disabled="tableList.length === 0"
        >エラー出力</a-button
      >
      <a-button key="back" :loading="loading" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//エラー一覧
//--------------------------------------------------------------------------
import { reactive, ref, watch, toRef } from 'vue'
import { KimpErrRowVM } from './type'
import { Download, InitList } from './service'
import { changeTableSort } from '@/utils/util'
import { showConfirmModal } from '@/utils/modal'
import { C002007 } from '@/constants/msg'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  impexeid: number
  currentRowIndex: number
}
const props = withDefaults(defineProps<Props>(), {
  visible: false
})
const emit = defineEmits(['update:visible', 'update:currentRowIndex'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
//ページャー
const currentPage = ref(1)
const pageSize = ref(25)
const totalCount = ref(0)
const oldPageSize = ref(10)
const searchParams = reactive({
  orderby: 0
})
//ローディング
const loading = ref(false)
//ビューモデル
const tableList = ref<KimpErrRowVM[]>([])
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      getInitData()
    }
  },
  { deep: true }
)
watch(
  () => searchParams.orderby,
  () => {
    if (tableList.value.length > 0) getTableList(currentPage.value, pageSize.value)
  },
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  getTableList(1, 25)
}

//検索処理
const getTableList = (index, size) => {
  loading.value = true
  if (oldPageSize.value != size) {
    currentPage.value = 1
  } else {
    currentPage.value = index
  }
  pageSize.value = size
  oldPageSize.value = size
  currentPage.value = index
  InitList({
    impexeid: props.impexeid,
    pagenum: currentPage.value,
    pagesize: pageSize.value,
    orderby: searchParams.orderby
  })
    .then((res) => {
      tableList.value = res.kimpErrList
      totalCount.value = res.totalrowcount
    })
    .finally(() => {
      loading.value = false
    })
}

//エラー一覧
const closeModal = () => {
  tableList.value = []
  totalCount.value = 0
  emit('update:visible', false)
}
//エラー出力
const downloadFile = () => {
  loading.value = true
  showConfirmModal({
    content: C002007.Msg,
    onOk: () => {
      Download({ kimpErrList: tableList.value, files: [] }).finally(() => [(loading.value = false)])
    },
    onCancel: () => {
      loading.value = false
    }
  })
}
//選択した行数のページを表示します
const setCurrentRow = (rowno) => {
  emit('update:currentRowIndex', rowno)
  closeModal()
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

:deep(.flex-1) {
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: end;
}
</style>
