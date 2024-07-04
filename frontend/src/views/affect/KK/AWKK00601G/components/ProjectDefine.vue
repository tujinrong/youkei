<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-2">
      <a-space>
        <a-button type="primary" @click="openAddModal({}, -1)">行追加</a-button>
      </a-space>
    </div>
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
      :cell-class-name="getCellClassName"
      :empty-render="{ name: 'NotData' }"
    >
      <vxe-column field="pageitemseq" title="項目No" width="70" :resizable="false">
        <template #default="{ row, rowIndex }: { row: PageItemVM, rowIndex: number }">
          <a @click="openAddModal(row, rowIndex)">{{ row.pageitemseq }}</a>
        </template>
      </vxe-column>
      <vxe-column field="itemnm" title="項目名" width="200" :resizable="true">
        <template #default="{ row, rowIndex }: { row: PageItemVM, rowIndex: number }">
          <a @click="openAddModal(row, rowIndex)">{{ row.itemnm }}</a>
        </template>
      </vxe-column>
      <vxe-column
        field="wktablecolnm"
        title="ワークテープルカラム名"
        width="200"
        :resizable="true"
      />
      <vxe-column field="itemkbnName" title="項目特定区分" width="200" :resizable="true" />
      <vxe-column field="inputkbnName" title="入力区分" width="100" :resizable="true"> </vxe-column>
      <vxe-column field="inputtypeName" title="入力方法" width="220" :resizable="true"> </vxe-column
      ><vxe-column field="hikisuName" title="引数" width="220" :resizable="true"> </vxe-column>
      <vxe-column field="jigyocdName" title="実施事業" width="150" :resizable="true"></vxe-column>

      <vxe-column field="len" title="桁数" width="60" :resizable="true">
        <template #default="{ row }: { row: PageItemVM }">
          <span v-if="row.len2">{{ row.len + ',' + row.len2 }}</span>
          <span v-else>{{ row.len }}</span>
        </template>
      </vxe-column>
      <vxe-column field="width" title="幅" width="60" :resizable="true"></vxe-column>
      <vxe-column
        field="formatName"
        title="フォーマット"
        width="120"
        :resizable="true"
      ></vxe-column>
      <vxe-column field="requiredflgName" title="必須" width="80" :resizable="true"> </vxe-column>
      <vxe-column field="uniqueflg" title="一意" width="60" :resizable="true">
        <template #default="{ row }: { row: PageItemVM }">
          <span v-if="row.uniqueflg">○</span>
        </template>
      </vxe-column>
      <vxe-column field="dispinputkbnName" title="表示入力設定" width="120" :resizable="true" />
      <vxe-column field="sortno" title="並び順" width="70" :resizable="true" />
      <vxe-column
        field="yearchkflgName"
        title="年度チェック"
        width="120"
        :resizable="true"
      ></vxe-column>
      <vxe-column field="nendoflg" title="年度" width="60" :resizable="true">
        <template #default="{ row }: { row: PageItemVM }">
          <span v-if="row.nendoflg">○</span>
        </template>
      </vxe-column>

      <vxe-column field="seiki" title="正規表現" width="150" :resizable="true" />
      <vxe-column field="minval" title="最小値" width="80" :resizable="true" />
      <vxe-column field="maxval" title="最大値" width="80" :resizable="true" />
      <vxe-column field="defaultval" title="初期値" width="120" :resizable="true" />
      <vxe-column field="fixedval" title="固定値" width="120" :resizable="true" />
      <vxe-colgroup title="マスタ参照">
        <vxe-column
          field="fromfieldidName"
          title="参照元フィールド"
          width="150"
          :resizable="true"
        />
        <vxe-column field="fromitemseqName" title="参照元項目" width="100" :resizable="true" />
        <vxe-column
          field="targetfieldidName"
          title="取得先フィールド"
          width="150"
          :resizable="true"
        />
      </vxe-colgroup>
      <vxe-colgroup title="マスタ存在">
        <vxe-column field="msttableName" title="マスタテーブル" width="150" :resizable="true" />
        <vxe-column field="mstjyoken" title="条件" width="150" :resizable="true" />
        <vxe-column field="mstfieldName" title="項目" width="100" :resizable="true" />
      </vxe-colgroup>
      <vxe-colgroup title="条件必須">
        <vxe-column field="jherrlelkbnName" title="エラーレベル" width="120" :resizable="true" />
        <vxe-column field="jhitemseqName" title="項目ID" width="150" :resizable="true" />
        <vxe-column field="jhenzanName" title="演算子" width="120" :resizable="true" />
        <vxe-column field="jhval" title="値" width="100" :resizable="true" />
      </vxe-colgroup>
    </vxe-table>
  </a-spin>
  <DefineModal
    v-model:add-visible="addVisible"
    v-model:param="param"
    v-model:index="codeIndex"
    :impno="props.impno"
    :gyoumukbn="props.gyoumukbn"
    :pageitem-list="props.data"
    :editkbn="props.editkbn"
    :is-file-import="props.isFileImport"
    :changekbn-list="props.changekbnList"
    @add="add"
    @delete="deleteCode"
  ></DefineModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//項目定義
//--------------------------------------------------------------------------
import { ref, onMounted, watch, Ref } from 'vue'
import DefineModal from '../../AWKK00604D/index.vue'
import { PageItemVM, ItemMappingVM } from '../type'
import { Enum編集区分 } from '#/Enums'
import { useTableHeight } from '@/utils/hooks'
import { SelectProps } from 'ant-design-vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  headRef: Ref
  isChange: boolean
  data?: PageItemVM[]
  gyoumukbn: string
  impno?: string
  editkbn: Enum編集区分
  isFileImport: boolean
  mappingSetting?: ItemMappingVM[]
  changekbnList: SelectProps['options']
  errorClassMap?: any
}
const props = withDefaults(defineProps<Props>(), {
  isChange: false
})
const emit = defineEmits(['update:isChange', 'getData'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
//ローディング
const pageLoading = ref(false)
const loading = ref(false)
//ビューモデル
const tableList = ref<PageItemVM[]>([])
const param = ref<PageItemVM>({
  pageitemseq: 0,
  itemnm: '',
  inputkbn: '',
  jherrlelkbn: '',
  jherrlelkbnName: '',
  wktablecolnm: ''
})
const addVisible = ref(false)
const codeIndex = ref(-1)
const maxIndex = ref(-1)
const tableRef = ref()
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
watch(
  () => props.isFileImport,
  (newValue) => {
    console.log(newValue)
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
  if (props.data && props.data.length != 0) {
    tableList.value = props.data
    maxIndex.value = Math.max(...tableList.value.map((item) => item.pageitemseq))
  } else {
    maxIndex.value = 0
    loading.value = true
    getTableList()
    loading.value = false
  }
}

//検索処理
const getTableList = () => {
  pageLoading.value = true
  tableList.value = []
  pageLoading.value = false
}
//modalの表示
const openAddModal = (record, index) => {
  param.value = record
  codeIndex.value = index
  if (index < 0) {
    param.value.pageitemseq = maxIndex.value + 1
  }
  addVisible.value = true
}
//追加処理
const add = (val) => {
  if (codeIndex.value > -1) {
    //項目名変更
    if (tableList.value[codeIndex.value].itemnm != val.itemnm) {
      const item = tableList.value[codeIndex.value]
      const mapItem = props.mappingSetting?.find((i) => i.pageitemnm == item.itemnm)
      if (mapItem != undefined) {
        mapItem.pageitemnm = val.itemnm
      }
    }
    tableList.value[codeIndex.value] = val
    tableRef.value.reloadData(tableList.value)
  } else {
    //画面項目は増加する時、マッピング設定タブに反映する
    props.mappingSetting?.push({
      pageitemnm: val.itemnm,
      pageitemseq: maxIndex.value + 1
    })
    tableList.value.push(val)
    maxIndex.value += 1
  }
  emit('update:isChange', true)
  emit('getData', 'projectDefine', tableList.value)
}
//削除処理
const deleteCode = () => {
  const item = tableList.value[codeIndex.value]
  const index = props.mappingSetting?.findIndex((i) => i.pageitemnm == item.itemnm)
  //画面項目は減少する時、マッピング設定タブに反映する
  if (index != undefined && index > -1) {
    props.mappingSetting?.splice(index, 1)
  }
  tableList.value.splice(codeIndex.value, 1)
  maxIndex.value = Math.max(...tableList.value.map((item) => item.pageitemseq))
  emit('update:isChange', true)
  emit('getData', 'projectDefine', tableList.value, true)
}

//状態
const getCellClassName = ({ row, column, rowIndex, columnIndex }) => {
  if (props.errorClassMap[row.pageitemseq] && column.field === 'inputtypeName') {
    return props.errorClassMap[row.pageitemseq]
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
.tableHiddle {
  display: none;
}
:deep(.warning) {
  border: 1px solid #ff4d4f;
}
</style>
