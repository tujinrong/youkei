<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 汎用情報保守(共通編集部分)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <div class="m-b-1">
      <a-button
        class="btn-round m-r-1"
        type="primary"
        :disabled="!canCreate"
        tabindex="6"
        @click="addRow()"
        >行追加</a-button
      >
      <a-button
        class="btn-round"
        type="primary"
        :disabled="!canDelete"
        tabindex="7"
        @click="handleDeleteRow()"
        >行削除</a-button
      >
    </div>
    <div tabindex="8" :style="{ height: tableHeight }">
      <vxe-table
        ref="xTableRef"
        height="100%"
        :data="tableList ?? undefined"
        :column-config="{ resizable: true }"
        :header-cell-class-name="updFlg || addFlg || delFlg ? 'bg-editable' : 'bg-readonly'"
        :mouse-config="{ selected: true }"
        :edit-rules="rules"
        :row-config="{ isCurrent: true, height: 70 }"
        :keyboard-config="{
          isTab: true,
          isEdit: true,
          isEnter: true,
          enterToTab: true
        }"
        :edit-config="{
            trigger: 'click',
            mode: 'cell',
            showStatus: false,
            beforeEditMethod({ row, column }) {
              if (column.field === 'hanyocd') {
                return canEdit as unknown as boolean && row.hanyocdEditFlg
              } else {
                return canEdit as unknown as boolean
              }
            }
          }"
        :valid-config="{ showMessage: false }"
        :empty-render="{ name: 'NotData' }"
        @edit-closed="onCloseCellEdit"
      >
        <vxe-column
          field="hanyocd"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          :class-name="
            ({ row }) =>
              !row.hanyocd || hasRepeated(row.hanyocd) || compareHanyocd(row.hanyocd, row.pkgCdFlg)
                ? 'bg-errorcell'
                : ''
          "
          min-width="110"
        >
          <template #header
            >コード<span v-show="updFlg || addFlg || delFlg" class="request-mark"
              >＊</span
            ></template
          >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.hanyocd"
              type="text"
              :maxlength="codeColKeta"
              :auto-size="{ minRows: 1 }"
              show-count
              @change="row.hanyocd = row.hanyocd?.replaceAll(/[^0-9]/g, '')"
              @blur="onBlurHanyocd(row)"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="nm"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          :class-name="({ row }) => (!row.nm ? 'bg-errorcell' : '')"
          min-width="110"
        >
          <template #header
            >名称<span v-show="updFlg || addFlg || delFlg" class="request-mark">＊</span></template
          >
          <template #edit="scope">
            <a-textarea
              v-model:value="scope.row.nm"
              :maxlength="100"
              :auto-size="{ minRows: 1 }"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="kananm"
          title="カナ名称"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.kananm"
              :maxlength="100"
              :auto-size="{ minRows: 1 }"
              show-count
              type="text"
              @change="row.kananm = row.kananm?.replaceAll(/[^\u30A0-\u30FFa-zA-Z0-9]+/g, '')"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="shortnm"
          title="略称"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.shortnm"
              :auto-size="{ minRows: 1 }"
              :maxlength="50"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="biko"
          title="備考"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.biko"
              :auto-size="{ minRows: 1 }"
              :maxlength="200"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="hanyokbn1"
          title="汎用区分１"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.hanyokbn1"
              :auto-size="{ minRows: 1 }"
              :maxlength="1000"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="hanyokbn2"
          title="汎用区分2"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.hanyokbn2"
              :auto-size="{ minRows: 1 }"
              :maxlength="1000"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="hanyokbn3"
          title="汎用区分3"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="110"
        >
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.hanyokbn3"
              :auto-size="{ minRows: 1 }"
              :maxlength="1000"
              show-count
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="stopflg"
          title="停止"
          :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
          min-width="60"
        >
          <template #edit="{ row }">
            <a-checkbox v-model:checked="row.stopflg"></a-checkbox>
          </template>
          <template #default="{ row }">
            <a-checkbox :checked="row.stopflg" :disabled="!canEdit" />
          </template>
        </vxe-column>
        <vxe-column
          field="orderseq"
          title="並び順"
          :edit-render="{ autofocus: 'input', autoselect: true }"
          min-width="60"
        >
          <template #edit="{ row }">
            <a-input-number v-model:value="row.orderseq" :min="0" max="9999" :precision="0" />
          </template>
        </vxe-column>
      </vxe-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, watch, nextTick } from 'vue'
import VXETable, { VxeTableInstance, VxeTablePropTypes } from 'vxe-table'
import { message } from 'ant-design-vue'
import { Save, Search } from '../service'
import { HanyoVM, LockVM } from '../type'
import { E004011, E004012, SAVE_OK_INFO } from '@/constants/msg'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { getHeight } from '@/utils/height'
import { Judgement } from '@/utils/judge-edited'
import { getUserMenu } from '@/utils/user'
import { isNaN } from 'xe-utils'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  mainCode: string
  subCode: string
  tabledata?: HanyoVM[]
  inPage?: boolean
  kinoid?: string
  editflgs?: {
    updflg: boolean
    addflg: boolean
    delflg: boolean
  }
  keta?: number | null
  issearched?: boolean
}>()
const emit = defineEmits(['afterSave'])

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const editJudge = new Judgement(props.inPage ? 'AWAF00801G' : '')
//テンプレート参照
const xTableRef = ref<VxeTableInstance>()
//ビューモデル
const currentRow = ref<HanyoVM | null>(null)
const tableList = ref<HanyoVM[] | null>(null)
const codeColKeta = ref(20) //コード列 桁数
let rawDataJson = ''
let locklist: LockVM[] = []
//項目の設定
const rules = ref({
  hanyocd: [
    { required: true },
    {
      validator({ cellValue, row }) {
        return new Promise((resolve, reject) => {
          if (hasRepeated(cellValue)) {
            reject()
          } else if (compareHanyocd(cellValue, row.pkgCdFlg)) {
            reject()
          } else {
            resolve()
          }
        })
      }
    }
  ],
  nm: [{ required: true }]
} as VxeTablePropTypes.EditRules)

/** ユーザ領域開始コード */
const userryoikikaisicd = ref<number | null>(null)
/** 最大汎用コード */
const maxHanyocd = ref<number | null>(null)

//----------------------------------------------------------------------------------------
//操作権限フラグ
const pageMeta = getUserMenu().find((el) => el.menuid === props.kinoid)
//サブコード操作権限フラグ
const subEditFlgs = ref({
  updflg: true,
  addflg: true,
  delflg: true
})
//更新権限
const updFlg = computed(() => {
  return props.editflgs ? props.editflgs.updflg : pageMeta?.updateflg && subEditFlgs.value.updflg
})
//追加権限
const addFlg = computed(() => {
  return props.editflgs ? props.editflgs.addflg : pageMeta?.addflg && subEditFlgs.value.addflg
})
//削除権限
const delFlg = computed(() => {
  return props.editflgs ? props.editflgs.delflg : pageMeta?.deleteflg && subEditFlgs.value.delflg
})
//行編集フラグ取得
const canEdit = computed(() => {
  //更新権限がある場合、編集可能
  if (updFlg.value) return true
  //更新権限がない場合、新規データのみ編集可能
  return Boolean(currentRow.value && !currentRow.value.upddttm)
})
//行追加フラグ取得
const canCreate = computed(() => {
  //追加権限があって、最終行が必須チェックをクリアの場合(編集画面)、行追加可能
  return !isLastRowCheckFaild.value && addFlg.value && tableList.value
})
//行削除フラグ取得
const canDelete = computed(() => {
  //削除権限がある場合、行削除可能
  if (delFlg.value) return Boolean(currentRow.value)
  //削除権限がない場合、新規データのみ削除可能
  return Boolean(currentRow.value && !currentRow.value.upddttm)
})
//有無任意権限
const hasPermission = computed(() => {
  return updFlg.value || delFlg.value || addFlg.value
})
//------------------------------------------------------------------------------------------

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//最終行必須項目の必須チェック
const isLastRowCheckFaild = computed(() => {
  const data = getTableData()
  if (data.length > 0) {
    const lastCell: HanyoVM = data[data.length - 1]
    return !(lastCell.hanyocd && lastCell.nm)
  }
  return false
})

//明細部の高さの計算
const tableHeight = computed(() => getHeight(props.issearched ? 277 : 240))

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//現在行
watch(
  () => xTableRef.value?.getCurrentRecord(),
  (val) => {
    currentRow.value = val
  }
)
//データ設定
watch(
  () => props.tabledata,
  (val) => {
    if (val) {
      tableList.value = val
      nextTick(() => {
        rawDataJson = JSON.stringify(tableList.value)
      })
    }
  }
)
//コード列 桁数
watch(
  () => props.keta,
  (val) => {
    codeColKeta.value = val ?? 20
  }
)
//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//自動行追加
VXETable.interceptor.add('event.keydown', (params) => {
  const { $event, $table } = params
  if ($event.key === 'Enter' && $table.getEditRecord()?.column.field === 'orderseq') {
    addRow({ rowIndex: $table.getRowIndex($table.getCurrentRecord()) })
  }
})

//検索処理
const searchData = async () => {
  try {
    const res = await Search({
      hanyomaincd: props.mainCode,
      hanyosubcd: props.subCode
    })
    tableList.value = res.kekkalist
    codeColKeta.value = res.keta ?? 20
    subEditFlgs.value = {
      updflg: res.uflg,
      addflg: res.iflg,
      delflg: res.dflg
    }
    userryoikikaisicd.value = res.userryoikikaisicd
    maxHanyocd.value = res.maxHanyocd
    locklist = res.locklist
    nextTick(() => {
      rawDataJson = JSON.stringify(tableList.value)
    })
    return Promise.resolve(res)
  } catch (error) {
    return Promise.reject(error)
  }
}
//保存処理
const saveData = async (outerlocklist?) => {
  const $table = xTableRef.value
  $table?.setCurrentRow(null)
  const errMap = await $table?.validate(true)
  if (!errMap) {
    showSaveModal({
      onOk: async () => {
        return Save({
          hanyomaincd: props.mainCode,
          hanyosubcd: props.subCode,
          savelist: getTableData(),
          locklist: outerlocklist ?? locklist
        }).then(() => {
          message.success(SAVE_OK_INFO.Msg)
          editJudge.reset()
          tableList.value = null
          emit('afterSave')
        })
      }
    })
  }
  return
}

//行追加
const addRow = async (val?: { rowIndex: number }) => {
  const $table = xTableRef.value
  if ($table) {
    $table.setCurrentRow(null)
    const tableData = getTableData()
    const lastItem = tableData[tableData.length - 1]
    //Enterキーを押す
    if (val) {
      //最終行判断
      if (tableData.length > val.rowIndex + 1) {
        $table.setCurrentRow(tableData[val.rowIndex + 1])
        setTimeout(() => {
          $table.setEditCell(tableData[val.rowIndex + 1], 'hanyocd')
        }, 0)
        return
      }
      if (!lastItem.hanyocd) {
        $table.clearEdit()
        setTimeout(() => {
          $table.setEditCell(lastItem, 'hanyocd')
        }, 0)
        return
      }
      if (!lastItem.nm) {
        $table.clearEdit()
        setTimeout(() => {
          $table.setEditCell(lastItem, 'nm')
        }, 0)
        return
      }
      if (hasRepeated(lastItem.hanyocd)) {
        $table.clearEdit()
        setTimeout(() => {
          $table.setEditCell(lastItem, 'hanyocd')
        }, 0)
        return
      }
    }
    // 自動採番
    let hanyocd = ''
    if (userryoikikaisicd.value) {
      const codes = tableData.map((el) => +el.hanyocd).filter((el) => !isNaN(el))
      hanyocd = (() => {
        for (let i = 0; i < codes.length; i++) {
          if (!codes.includes(userryoikikaisicd.value + i)) {
            return String(userryoikikaisicd.value + i)
          }
        }
        return String(userryoikikaisicd.value + codes.length)
      })()

      if (hanyocd && maxHanyocd.value && +hanyocd > maxHanyocd.value) {
        showInfoModal({
          type: 'error',
          content: E004011.Msg.replace('{0}', String(maxHanyocd.value))
        })
        return
      }
    }

    const { row: newRow } = await $table.insertAt(
      { hanyocd, stopflg: false, hanyocdEditFlg: true, pkgCdFlg: false },
      -1
    )
    $table.setCurrentRow(newRow)
    setTimeout(() => {
      $table.setEditCell(newRow, 'hanyocd')
    }, 0)
    editJudge.setEdited()
  }
}

//行削除
const handleDeleteRow = () => {
  const current = xTableRef.value?.getCurrentRecord()
  if (current) {
    showDeleteModal({
      onOk() {
        xTableRef.value?.removeCurrentRow()
        editJudge.setEdited()
      }
    })
  }
}

//画面データ取得
const getTableData = () => {
  const tableData = xTableRef.value?.getTableData().tableData || []
  return tableData
}

//重複チェック
const hasRepeated = (cell: string) => {
  const duplicateData = getTableData().filter((item) => {
    return item.hanyocd === cell
  })
  return duplicateData.length > 1
}
//編集状態
function onCloseCellEdit() {
  if (JSON.stringify(getTableData()) !== rawDataJson) {
    editJudge.setEdited()
  }
}

function onBlurHanyocd(row: HanyoVM) {
  //補0
  if (userryoikikaisicd.value) {
    row.hanyocd = row.hanyocd.padStart(codeColKeta.value, '0')
  }
  if (userryoikikaisicd.value && compareHanyocd(row.hanyocd, row.pkgCdFlg)) {
    if (row.pkgCdFlg) {
      showInfoModal({
        type: 'error',
        content: E004012.Msg.replace('{0}', 'PKG')
          .replace('{1}', '1')
          .replace('{2}', String(userryoikikaisicd.value - 1))
      })
    } else {
      showInfoModal({
        type: 'error',
        content: E004012.Msg.replace('{0}', '自治体独自')
          .replace('{1}', String(userryoikikaisicd.value))
          .replace('{2}', String(maxHanyocd.value))
      })
    }
    return
  }
}

//コード比較
const compareHanyocd = (cell: string, pkgCdFlg: boolean) => {
  if (userryoikikaisicd.value && cell) {
    return (
      (pkgCdFlg && Number(cell) >= userryoikikaisicd.value) ||
      (!pkgCdFlg &&
        (Number(cell) > Number(maxHanyocd.value) || Number(cell) < userryoikikaisicd.value))
    )
  }
  return false
}

defineExpose({
  saveData,
  searchData,
  editJudge,
  tableList,
  hasPermission,
  clear: () => {
    tableList.value = null
    subEditFlgs.value = {
      updflg: true,
      addflg: true,
      delflg: true
    }
    editJudge.reset()
  }
})
</script>

<style lang="less" scoped>
:deep(.ant-input-textarea-show-count::after) {
  color: #ffffff;
}
:deep(.ant-input-textarea) {
  margin-top: 10px;
}
:deep(.vxe-header--column .vxe-cell--required-icon) {
  display: none;
}
</style>
