<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 成人健（検）診対象者設定
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.31
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card class="mt-2">
    <a-space class="mb-2">
      <a-button class="btn-round" type="primary" :disabled="!canAdd" @click="addRow"
        >行追加</a-button
      >
      <a-button
        v-if="!hideDelete"
        class="btn-round"
        type="primary"
        :disabled="!canDelete"
        @click="deleteRow"
        >行削除</a-button
      >
    </a-space>
    <vxe-table
      ref="xTableRef"
      :height="tableHeight"
      :loading="loading"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true, isCurrent: true }"
      :data="tableData"
      :sort-config="{ trigger: 'cell' }"
      :empty-render="{ name: 'NotData' }"
      :cell-style="
        ({ row }) => ({
          'background-image': `linear-gradient(#ddd, #ddd), linear-gradient(${
            row.lastflag ? '#ddd' : '#ffffff00'
          }, ${row.lastflag ? '#ddd' : '#ffffff00'})`
        })
      "
      @cell-dblclick="visible = true"
    >
      <vxe-column type="seq" title="No." width="60" min-width="60"></vxe-column>
      <vxe-column field="jigyocd" title="検診種別">
        <template #default="{ row }: { row: ItemVM }">
          <a @click="showModal">{{ getLabelByValue(row.jigyocd, options.selectorlist1) }}</a>
        </template>
      </vxe-column>
      <vxe-column field="kensahohocd" title="検査方法／内訳">
        <template #default="{ row }: { row: ItemVM }">
          <a @click="showModal">{{
            getLabelByValue(row.kensahohocd, options.selectorlist2, row.jigyocd)
          }}</a>
        </template>
      </vxe-column>
      <vxe-colgroup title="対象者条件" align="center">
        <vxe-column field="sex" title="性別" width="70">
          <template #default="{ row }: { row: ItemVM }">
            {{ getLabelByValue(row.sex, options.selectorlist3) || 'すべて' }}
          </template>
        </vxe-column>
        <vxe-column field="age" title="年齢"></vxe-column>
        <vxe-column field="kijunymd" title="年齢計算基準日">
          <template #default="{ row }: { row: ItemVM }">
            {{
              row.kijunkbn === String(Enum年齢基準日区分.受診日時点)
                ? '受診日時点'
                : getDateJpText(new Date(row.kijunymd))
            }}
          </template>
        </vxe-column>
        <vxe-column field="hokenkbn" title="保険区分">
          <template #default="{ row }: { row: ItemVM }">
            {{ getLabelByValue(row.hokenkbn, options.selectorlist5) }}
          </template>
        </vxe-column>
        <vxe-column field="tokusyu" title="特殊">
          <template #default="{ row }: { row: ItemVM }">
            {{ getLabelByValue(row.tokusyu, options.selectorlist6) }}
          </template>
        </vxe-column>
        <vxe-column field="sql" title="SQL" :resizable="false"></vxe-column>
      </vxe-colgroup>
    </vxe-table>
  </a-card>
  <Modal
    v-model:visible="visible"
    :table-data="tableData"
    :row="currentRow"
    :options="options"
    :disabled="disabled"
    @set-row="setRow"
  />
</template>

<script setup lang="ts">
import { useTableHeight } from '@/utils/hooks'
import { showDeleteModal } from '@/utils/modal'
import { getDateJpText, getLabelByValue } from '@/utils/util'
import { Ref, computed, ref, toRef, watchEffect } from 'vue'
import { VxeTableInstance, VxeTablePropTypes } from 'vxe-table'
import { ItemVM, OptionsVM } from '../type'
import Modal from './Modal.vue'
import { Enum年齢基準日区分 } from '#/Enums'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  headRef: Ref
  tableData: ItemVM[]
  canAdd: boolean
  options: OptionsVM
  disabled?: boolean
  hideDelete?: boolean
}>()
const emit = defineEmits(['setlastflag'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const visible = ref(false)
const loading = ref(false)

const xTableRef = ref<VxeTableInstance>()

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限フラグ
const canDelete = computed(() => {
  return Boolean(currentRow.value) && currentRow.value?.newflg && !props.disabled
})
//表の高さ
const { tableHeight } = useTableHeight(toRef(() => props.headRef))
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//現在行
const currentRow = ref<ItemVM | null>(null)
watchEffect(() => {
  currentRow.value = xTableRef.value?.getCurrentRecord()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//行追加
function addRow() {
  xTableRef.value?.clearCurrentRow()
  visible.value = true
}

//行削除
function deleteRow() {
  showDeleteModal({
    onOk: () => {
      const $table = xTableRef.value
      if ($table) {
        const currentIndex = $table.getRowIndex(currentRow.value)
        props.tableData.splice(currentIndex, 1)
      }
    }
  })
}

//設定
function setRow(row: ItemVM) {
  const $table = xTableRef.value
  if ($table) {
    if (currentRow.value) {
      //編集
      const currentIndex = $table.getRowIndex(currentRow.value)
      props.tableData.splice(currentIndex, 1, row)
      emit('setlastflag')
      $table.reloadData(props.tableData)
      $table.setCurrentRow(row)
    } else {
      //追加
      const lastIndex = props.tableData.findLastIndex((el) => el.jigyocd === row.jigyocd)
      const newRow = { ...row, newflg: true, _X_ROW_KEY: String(Date.now()) } //add new flag
      if (lastIndex >= 0) {
        props.tableData.splice(lastIndex + 1, 0, newRow)
        $table.reloadData(props.tableData)
      } else {
        props.tableData.push(newRow)
      }
      emit('setlastflag')
    }
  }
}

function showModal() {
  setTimeout(() => (visible.value = true), 0)
}

// 行合併（同じデータ列を1行にまとめます） //:span-method="mergeRowMethod"
const mergeRowMethod: VxeTablePropTypes.SpanMethod<ItemVM> = ({
  row,
  _rowIndex,
  column,
  visibleData
}) => {
  const fields = ['jigyocd']
  const cellValue = row[column.field]
  if (cellValue && fields.includes(column.field)) {
    const prevRow = visibleData[_rowIndex - 1]
    let nextRow = visibleData[_rowIndex + 1]
    if (prevRow && prevRow[column.field] === cellValue) {
      return { rowspan: 0, colspan: 0 }
    } else {
      let countRowspan = 1
      while (nextRow && nextRow[column.field] === cellValue) {
        nextRow = visibleData[++countRowspan + _rowIndex]
      }
      if (countRowspan > 1) {
        return { rowspan: countRowspan, colspan: 1 }
      }
    }
  }
  return
}
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
