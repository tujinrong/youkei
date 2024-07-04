<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-2">
      <a-space>
        <a-button type="primary" @click="openDetail({}, -1)">行追加</a-button>
      </a-space>
      <div class="self_adaption_table">
        <a-col
          ><th style="width: 70px; line-height: 26px">項目数</th>
          <TD style="width: 100px; line-height: 26px">{{ tableList.length }}</TD></a-col
        >
      </div>
    </div>
    <div class="w-full">
      <vxe-table
        ref="tableRef"
        class="mytable-style"
        :height="Math.max(tableHeight, 400)"
        :header-cell-style="{ backgroundColor: '#ffffe1' }"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableList"
        :sort-config="{
          trigger: 'cell',
          remote: true
        }"
        :empty-render="{ name: 'NotData' }"
        :row-class-name="props.borderWarning ? rowClassName : ''"
      >
        <vxe-column field="fileitemseq" title="項目No" width="70" :resizable="false">
          <template #default="{ row, rowIndex }: { row: FileIFVM, rowIndex: number }">
            <a @click="openDetail(row, rowIndex)">{{ row.fileitemseq }}</a>
          </template>
        </vxe-column>
        <vxe-column field="itemnm" title="項目名" width="350" :resizable="true">
          <template #default="{ row, rowIndex }: { row: FileIFVM, rowIndex: number }">
            <a @click="openDetail(row, rowIndex)">{{ row.itemnm }}</a>
          </template>
        </vxe-column>
        <vxe-column field="keyflg" title="キー(参照)" width="100" :resizable="true">
          <template #default="{ row }: { row: FileIFVM }">
            <span v-if="row.keyflg">○</span>
          </template>
        </vxe-column>
        <vxe-column field="requiredflg" title="必須(参照)" width="100" :resizable="true">
          <template #default="{ row }: { row: FileIFVM }">
            <span v-if="row.requiredflg">○</span>
          </template>
        </vxe-column>
        <vxe-column
          field="datatypeName"
          title="データ型"
          width="250"
          :resizable="true"
        ></vxe-column>
        <vxe-column field="len" title="桁数" width="60" :resizable="true">
          <template #default="{ row }: { row: FileIFVM }">
            <span v-if="row.len2">{{ row.len + ',' + row.len2 }}</span>
            <span v-else>{{ row.len }}</span>
          </template>
        </vxe-column>
        <vxe-column
          field="formatName"
          title="フォーマット"
          width="140"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="fmtcheckName"
          title="フォーマットチェック"
          width="200"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="fmtchangeName"
          title="フォーマット変換"
          width="180"
          :resizable="true"
        ></vxe-column>
        <vxe-column field="memo" title="備考" width="155" :resizable="true"></vxe-column>
      </vxe-table>
    </div>
  </a-spin>
  <InterfaceModal
    v-model:visible="visible"
    :param="param"
    :index="tableIndex"
    :impno="props.impno"
    @update="updateItem"
    @delete="deleteItem"
  ></InterfaceModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//ファイルI/F
//--------------------------------------------------------------------------
import { ref, watch, onMounted, Ref } from 'vue'
import InterfaceModal from '../../AWKK00602D/index.vue'
import { FileIFVM } from '../type'
import TD from '@/components/Common/TableTD/index.vue'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  headRef: Ref
  isChange: boolean
  data?: FileIFVM[]
  impno?: string
  borderWarning: boolean
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
const visible = ref(false)
//ビューモデル
const tableList = ref<FileIFVM[]>([])
const param = ref<FileIFVM>({ fileitemseq: -1, itemnm: '' })
const tableIndex = ref(-1)
const tableRef = ref()
const maxFileitemseq = ref()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//表の高さ
const { tableHeight } = useTableHeight(props.headRef, -48)

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.data,
  (newValue) => {
    getInitData()
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
  if (props.data && props.data.length > 0) {
    tableList.value = props.data
    maxFileitemseq.value = Math.max(...props.data.map((item) => item.fileitemseq))
    param.value.fileitemseq = maxFileitemseq.value
  } else {
    tableList.value = []
    maxFileitemseq.value = 0
    param.value.fileitemseq = maxFileitemseq.value + 1
  }
}
//詳細
const openDetail = (record, index) => {
  visible.value = true
  tableIndex.value = index
  param.value = record
  if (index < 0) {
    param.value.fileitemseq = maxFileitemseq.value + 1
  }
}
//削除処理
const deleteItem = () => {
  tableList.value.splice(tableIndex.value, 1)
  emit('update:isChange', true)
  emit('getData', 'fileInterface', tableList.value, true)
}
//登録処理
const updateItem = (record) => {
  if (tableIndex.value < 0) {
    tableList.value.push(record)
  } else {
    tableList.value[tableIndex.value] = { ...record }
    tableRef.value.reloadData(tableList.value)
  }
  emit('update:isChange', true)
  emit('getData', 'fileInterface', tableList.value, true)
}

const rowClassName = ({ row }) => {
  if (!row['itemnm']) {
    return 'row-red'
  }
  return ''
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
::v-deep(.mytable-style.vxe-table .vxe-body--row.row-red) {
  box-shadow: 0 0 0 2px #ff4d4f inset !important;
  color: #fff;
}
</style>
