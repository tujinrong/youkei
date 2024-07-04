<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between">
      <a-space>
        <a-button type="primary" @click="copyRecord()">レコード追加</a-button>
        <a-button type="primary" :disabled="deleteStatus" @click="deleteTransfer"
          >レコード削除</a-button
        >
      </a-space>
    </div>
    <a-row :gutter="[0, 10]" style="margin-top: 10px">
      <a-col :xs="24" :sm="24" :md="24" :lg="12" :xl="12" :xxl="8">
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 100px">テーブル</th>
                <td>
                  <ai-select v-model:value="tableid" :options="tableOptions" split-val></ai-select>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-col>
    </a-row>
    <div class="m-t-1 w-full" :style="{ width: '74%' }">
      <vxe-table
        ref="tableRef"
        :height="Math.max(tableHeight, 400)"
        :auto-resize="true"
        :header-cell-style="{ backgroundColor: '#ffffe1' }"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{
          trigger: 'cell',
          remote: true
        }"
        :empty-render="{ name: 'NotData' }"
        @cell-click="rowSelected"
      >
        <vxe-column field="recno" title="レコード" width="80" :resizable="false">
          <template #default="{ row, rowIndex }: { row: InsertDetailVM, rowIndex: number }">
            <a @click="openAddModal(row, rowIndex)">{{ row.recno }}</a>
          </template>
        </vxe-column>
        <vxe-column field="fieldnm" title="フィールド" width="150" :resizable="true">
          <template #default="{ row, rowIndex }: { row: InsertDetailVM, rowIndex: number }">
            <a @click="openAddModal(row, rowIndex)">{{ row.fieldnm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="syorikbnName" title="処理区分" width="220" :resizable="true">
        </vxe-column>
        <vxe-column field="itemnm" title="データ元項目" width="200" :resizable="true" />
        <vxe-column field="fixedval" title="固定値" width="100" :resizable="true" />
        <vxe-column
          field="datamototableronrinm"
          title="データ元テーブル"
          width="150"
          :resizable="true"
        />
        <vxe-column
          field="datamotofieldronrinm"
          title="データ元フィールド"
          width="160"
          :resizable="true"
        />
        <vxe-column field="saibankeyronrinm" title="採番キー" width="130" :resizable="true" />
      </vxe-table>
    </div>
  </a-spin>
  <ProjectTransferAddModalVue
    v-model:addVisible="addVisible"
    v-model:param="param"
    :index="transferIndex"
    :table-options="tableOptions"
    :pageitem-list="props.pageitemList"
    @add="addTransfer"
    @delete="deleteTransfer"
  ></ProjectTransferAddModalVue>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//登録仕様
//--------------------------------------------------------------------------
import { ref, onMounted, watch, computed, nextTick, Ref } from 'vue'
import { SelectProps } from 'ant-design-vue'
import ProjectTransferAddModalVue from '../../AWKK00605D/index.vue'
import { InsertVM, InsertDetailVM, PageItemVM } from '../type'
import { IniTableFieldList } from '../service'
import { showDeleteModal } from '@/utils/modal'
import { VxeTableInstance } from 'vxe-table'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  headRef: Ref
  isChange: boolean
  regupdkbn: string
  data?: InsertVM[]
  seletedTableidList: string[]
  pageitemList?: PageItemVM[]
  originalTableOptions: SelectProps['options']
}
const props = withDefaults(defineProps<Props>(), {
  isChange: false
})
const emit = defineEmits(['update:isChange', 'getData'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
//ローディング
const loading = ref(false)
//ビューモデル
const tableRef = ref<VxeTableInstance>()
const tableList = ref<InsertDetailVM[]>([])
const originalList = ref<InsertDetailVM[]>([])
const param = ref<InsertDetailVM>()
const addVisible = ref(false)
const tableOptions = ref<SelectProps['options']>([])
const tableid = ref()
const transferIndex = ref(-1)
const originalIndex = ref(-1)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(props.headRef, -95)

//レコード削除非活性
const deleteStatus = computed(() => {
  //1レコードの場合使用不可
  let currentList = tableList.value.filter((e) => e.tableid === tableid.value)
  return transferIndex.value < 0 || currentList.every((item) => item.recno === currentList[0].recno)
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//テーブル
watch(
  () => tableid.value,
  (val) => {
    getFieldList()
  }
)
watch(
  () => props.seletedTableidList,
  (val) => {
    getInitData()
  }
)
watch(
  () => props.data,
  (val) => {
    getFieldList()
  },
  { deep: true }
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
  tableOptions.value = []
  props.seletedTableidList.forEach((s) => {
    const options: SelectProps['options'] = props.originalTableOptions?.filter((o) => o.value === s)
    if (options) {
      tableOptions.value = tableOptions.value?.concat(options)
    }
  })
  if (props.data && props.data.length > 0) {
    const firstSelectedTableID = props.seletedTableidList[0]
    tableid.value = firstSelectedTableID
  } else {
    tableList.value = []
  }
}
// 項目明細情報リスト
const getFieldList = () => {
  transferIndex.value = -1
  originalIndex.value = -1
  const index = props.data?.findIndex((item) => item.tableid === tableid.value)
  //詳細データの存在
  if (props.data && index != undefined && index > -1) {
    originalList.value = props.data[index].insertdetailList
    if (originalList.value.length > 0) {
      autoFieldDisp()
      return
    }
  }
  //詳細データが存在しません
  loading.value = true
  IniTableFieldList({ tableid: tableid.value })
    .then((res) => {
      originalList.value = res.insertVM.insertdetailList
      autoFieldDisp()
      handleTransfer()
    })
    .finally(() => {
      loading.value = false
    })
}

//コードmodalの表示
const openAddModal = (record, index) => {
  param.value = record
  transferIndex.value = index
  addVisible.value = true
}
//
const rowSelected = (rows) => {
  const record = rows.row
  param.value = record
  transferIndex.value = rows.rowIndex
  originalIndex.value = originalList.value.findIndex(
    (item) =>
      item.recno + item.tableid + item.fieldid === record.recno + record.tableid + record.fieldid
  )
}
//追加コード
const addTransfer = (val) => {
  if (transferIndex.value > -1) {
    tableList.value[transferIndex.value] = val
    originalList.value[originalIndex.value] = val
  } else {
    tableList.value.push(val)
    originalList.value.push(val)
  }
  handleTransfer()
}
//削除コード
const deleteTransfer = () => {
  //recnoの取得
  let temp = tableList.value[transferIndex.value]
  showDeleteModal({
    onOk() {
      let residueTableList = tableList.value.filter((t) => t.recno != temp.recno)
      let residueOriginalList = originalList.value.filter((t) => t.recno != temp.recno)
      tableList.value = [...residueTableList]
      originalList.value = [...residueOriginalList]
      handleTransfer()
    }
  })
}
//データ処理
const handleTransfer = () => {
  const index = props.data?.findIndex((item) => item.tableid === tableid.value)
  if (props.data && index != undefined && index > -1) {
    props.data[index].insertdetailList = tableList.value
  } else if (index != undefined && index < 0) {
    const data: InsertVM = { tableid: tableid.value, insertdetailList: tableList.value }
    props.data?.push(data)
  }
  emit('update:isChange', true)
  emit('getData', 'projectTransfer', props.data, true)
}

const copyRecord = () => {
  const minRecno = originalList.value.reduce((p, c) => (p.recno < c.recno ? p : c)).recno
  const copyTable = JSON.parse(
    JSON.stringify(originalList.value.filter((item) => item.recno === minRecno))
  )
  const maxRecno = originalList.value.reduce((p, c) => (p.recno > c.recno ? p : c)).recno
  copyTable.forEach((item) => {
    item.recno = maxRecno + 1
  })
  for (let i in copyTable) {
    let item = copyTable[i]
    tableList.value.push(item)
    originalList.value.push(item)
  }
  nextTick(() => {
    const $table = tableRef.value
    if ($table) {
      const row = $table.getData(tableList.value.length - copyTable.length)
      $table.setCurrentRow(row)
      setTimeout(() => $table.scrollToRow(row), 0)
    }
  })
  handleTransfer()
}
//自動項目非表示処理
const autoFieldDisp = () => {
  let tempList = JSON.parse(JSON.stringify(originalList.value))
  //table自動生成された_X_ROW_KEY
  for (let i in tempList) {
    let temp = tempList[i]
    temp['_X_ROW_KEY'] = null

    tableList.value = tempList
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
</style>
z
