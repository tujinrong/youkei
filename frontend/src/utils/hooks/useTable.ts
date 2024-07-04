import { Ref, onMounted, ref, unref, watch } from 'vue'
import { showDeleteModal } from '@/utils/modal'
import { VXETable, VxeTableInstance } from 'vxe-table'

export default function useTable(
  xTableRef: Ref<VxeTableInstance | undefined>,
  firstKey: string,
  lastKey = '',
  /**追加行のデータ */
  insertObj?: { [x: string]: any } | Ref<{ [x: string]: any }>
) {
  //現在の行のデータ
  const currentRow = ref<any>(null)

  onMounted(() => {
    //自動行追加
    if (lastKey) {
      VXETable.interceptor.add('event.keydown', (params) => {
        const { $event, $table } = params
        if ($event.key === 'Enter' && $table.getEditRecord()?.column.field === lastKey) {
          addRow($table.getCurrentRecord())
        }
      })
    }
  })

  //データ取得
  const getTableData = () => {
    const tableData = xTableRef.value?.getTableData().tableData ?? []
    return tableData
  }

  //現在行
  watch(
    () => xTableRef.value?.getCurrentRecord(),
    (val) => (currentRow.value = val)
  )

  //行追加
  const addRow = async (currentRow?) => {
    const $table = xTableRef.value
    if ($table) {
      $table.setCurrentRow(null)
      const tableData = getTableData()

      //Enterキーを押す
      if (currentRow) {
        const rowIndex = $table.getRowIndex(currentRow)
        //最終行判断
        if (tableData.length > rowIndex + 1) {
          $table.setCurrentRow(tableData[rowIndex + 1])
          setTimeout(() => {
            $table.setEditCell(tableData[rowIndex + 1], firstKey)
          }, 0)
          return
        }
        //判断拡張...
        // const lastItem = tableData[tableData.length - 1]
        // //require
        // const requireKeys: string[] = []
        // for (const key of requireKeys) {
        //   if (!lastItem[key]) {
        //     $table.clearEdit()
        //     setTimeout(() => {
        //       $table.setEditCell(lastItem, key)
        //     }, 0)
        //     break
        //   }
        // }
        // //repeat
        // const repertKeys: string[] = []
        // for (const key of repertKeys) {
        //   if (hasRepeated(lastItem[key], key)) {
        //     $table.clearEdit()
        //     setTimeout(() => {
        //       $table.setEditCell(lastItem, key)
        //     }, 0)
        //     break
        //   }
        // }
      }

      const { row: newRow } = await $table.insertAt(unref(insertObj) ?? {}, -1)

      $table.setCurrentRow(newRow)
      setTimeout(() => {
        $table.setEditCell(newRow, firstKey)
      }, 0)
    }
  }

  //行削除
  const deleteRow = async () => {
    return new Promise<void>((resolve) => {
      const current = xTableRef.value?.getCurrentRecord()
      if (current) {
        showDeleteModal({
          async onOk() {
            await xTableRef.value?.removeCurrentRow()
            resolve()
          }
        })
      }
    })
  }

  //重複チェック
  const hasRepeated = (value: string, cellname: string) => {
    if (!value) return false
    const tableData = getTableData()
    const duplicateData = tableData.filter((item) => {
      return item[cellname] === value
    })
    return duplicateData.length > 1
  }

  return {
    hasRepeated,
    getTableData,
    deleteRow,
    addRow,
    currentRow
  }
}
