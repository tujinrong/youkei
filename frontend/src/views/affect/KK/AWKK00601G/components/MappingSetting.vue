<template>
  <a-spin :spinning="loading">
    <vxe-table
      ref="tableRef"
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
    >
      <vxe-colgroup title="画面項目">
        <vxe-column field="pageitemseq" title="項目No" width="70" :resizable="false">
          <template #default="{ row, rowIndex }: { row: ItemMappingVM, rowIndex: number }">
            <a @click="openDetail(row, rowIndex)">{{ row.pageitemseq }}</a>
          </template>
        </vxe-column>
        <vxe-column field="pageitemnm" title="項目名" width="300" :resizable="true">
          <template #default="{ row, rowIndex }: { row: ItemMappingVM, rowIndex: number }">
            <a @click="openDetail(row, rowIndex)">{{ row.pageitemnm }}</a>
          </template>
        </vxe-column>
      </vxe-colgroup>

      <vxe-column field="mappingkbnName" title="マッピング区分" width="200" :resizable="true">
      </vxe-column>
      <vxe-column field="mappingmethodName" title="マッピング方法" width="200" :resizable="true">
      </vxe-column>

      <vxe-column field="fileitemseqName" title="ファイル項目" :resizable="true"></vxe-column>
      <vxe-column field="len" title="指定桁数" width="100" :resizable="true">
        <template #default="{ row }: { row: ItemMappingVM }">
          <span v-if="row.substrto">{{ row.substrfrom + '~' + row.substrto }}</span>
          <span v-else>{{ row.substrfrom }}</span>
        </template>
      </vxe-column>
    </vxe-table>
  </a-spin>
  <MappingAddModal
    v-model:visible="visible"
    :param="param"
    :index="tableIndex"
    :editkbn="props.editkbn"
    :fileitem-list="props.fileitemList"
    @delete="deleteItem"
    @update="updateItem"
  ></MappingAddModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//マッピング設定
//--------------------------------------------------------------------------
import { ref, onMounted, watch, Ref } from 'vue'
import MappingAddModal from '../../AWKK00603D/index.vue'
import { ItemMappingVM, FileIFVM } from '../type'
import { Enum編集区分 } from '#/Enums'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  headRef: Ref
  isChange: boolean
  data?: ItemMappingVM[]
  editkbn: Enum編集区分
  fileitemList?: FileIFVM[]
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
const tableIndex = ref(0)
//ビューモデル
const tableList = ref<ItemMappingVM[]>([])
const maxIndex = ref(-1)
const param = ref<ItemMappingVM>({ pageitemnm: '', pageitemseq: -1 })
const tableRef = ref()
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(props.headRef, -8)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})

watch(
  () => props.data,
  () => getInitData()
)
//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  if (props.data) {
    tableList.value = props.data
    maxIndex.value = tableList.value.length
  } else {
    tableList.value = []
    maxIndex.value = 0
  }
}

//詳細
const openDetail = (record, index) => {
  visible.value = true
  tableIndex.value = index
  param.value = record
  if (index < 0) {
    param.value.pageitemseq = maxIndex.value + 1
  }
}
//削除処理
const deleteItem = () => {
  tableList.value.splice(tableIndex.value, 1)
  emit('update:isChange', true)
  emit('getData', 'mappingSetting', tableList.value, true)
}
//登録処理
const updateItem = (record) => {
  if (tableIndex.value < 0) {
    maxIndex.value += 1
    tableList.value.push(record)
  } else {
    tableList.value[tableIndex.value] = record
    tableRef.value.reloadData(tableList.value)
  }
  emit('update:isChange', true)
  emit('getData', 'mappingSetting', tableList.value, true)
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
