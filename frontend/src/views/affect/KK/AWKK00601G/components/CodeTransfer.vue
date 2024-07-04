<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between">
      <a-space>
        <a-button :disabled="!cdchange" type="primary" @click="add">行追加</a-button>
        <a-button type="primary" :disabled="canDelete" @click="deleteRow">行削除</a-button>
      </a-space>
    </div>
    <a-row :gutter="[0, 10]" style="margin-top: 10px">
      <a-col :xs="12" :sm="12" :md="12" :lg="12" :xl="8" :xxl="8" style="margin-bottom: 0px">
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 100px">変換区分</th>
                <td>
                  <ai-select
                    v-model:value="cdchange"
                    :options="trasnferOptions"
                    style="width: 100%"
                    split-val
                    type="number"
                  ></ai-select>
                </td>
              </tr>
            </tbody>
          </table>
        </div> </a-col
    ></a-row>
    <div class="m-t-1 w-full">
      <vxe-table
        ref="xTableRef"
        class="mytable-style"
        :height="Math.max(tableHeight, 400)"
        :data="tableList"
        :column-config="{ resizable: true }"
        :header-cell-class-name="'bg-editable'"
        :mouse-config="{ selected: true }"
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
          showStatus: false
        }"
        :valid-config="{ showMessage: false }"
        :empty-render="{ name: 'NotData' }"
        :row-class-name="props.borderWarning ? rowClassName : ''"
        @edit-closed="onCloseCellEdit"
      >
        <vxe-colgroup title="ファイルコード">
          <vxe-column
            field="oldcode"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            min-width="110"
          >
            <template #header>コード</template>
            <template #edit="scope">
              <a-textarea
                v-model:value="scope.row.oldcode"
                :maxlength="30"
                :auto-size="{ minRows: 1 }"
                show-count
              ></a-textarea>
            </template>
          </vxe-column>
          <vxe-column
            field="oldcodememo"
            title="説明"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            min-width="110"
          >
            <template #edit="{ row }">
              <a-textarea
                v-model:value="row.oldcodememo"
                :maxlength="200"
                :auto-size="{ minRows: 1 }"
                show-count
              ></a-textarea>
            </template>
          </vxe-column>
        </vxe-colgroup>
        <vxe-colgroup title="本システムコード">
          <vxe-column
            field="newcode"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            min-width="110"
          >
            <template #header>コード</template>
            <template #edit="scope">
              <ai-select v-model:value="scope.row.newcode" :options="codeOptions"></ai-select>
            </template>
            <template #default="scope">
              {{ scope.row.newcode }} {{ scope.row.newcode ? ':' : '' }}
              {{ codeOptions?.find((item) => item.value == scope.row.newcode)?.label }}
            </template>
          </vxe-column>
          <vxe-column
            field="newcodememo"
            title="説明"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            min-width="110"
          >
            <template #edit="{ row }">
              <a-textarea
                v-model:value="row.newcodememo"
                :maxlength="200"
                :auto-size="{ minRows: 1 }"
                show-count
              ></a-textarea>
            </template>
          </vxe-column>
        </vxe-colgroup>
      </vxe-table>
    </div>
  </a-spin>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//変換コード
//--------------------------------------------------------------------------
import { ref, watch, computed, onMounted, Ref } from 'vue'
import { SelectProps } from 'ant-design-vue/lib/vc-select'
import { showDeleteModal } from '@/utils/modal'
import { CodeChangeVM, CodeChangeDetailVM, ChangeCodeMainVM } from '../type'
import { InitSysCodeList } from '../service'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  headRef: Ref
  isChange: boolean
  borderWarning: boolean
  data?: CodeChangeVM[]
  gyoumukbn: string
  impno?: string
  options: SelectProps['options']
  changeCodeMainList?: ChangeCodeMainVM[]
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
const tableList = ref<CodeChangeDetailVM[]>([])

const cdchange = ref<number>()
const trasnferOptions = ref<SelectProps['options']>([])
const codeOptions = ref<SelectProps['options']>([])
const xTableRef = ref()
const currentRow = ref<CodeChangeDetailVM | null>(null)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//行削除フラグ取得
const canDelete = computed(() => {
  //削除権限がない場合、新規データのみ削除可能
  return !currentRow.value
})
//表の高さ
const { tableHeight } = useTableHeight(props.headRef, -100)
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
//変換区分
watch(
  () => cdchange.value,
  (val) => {
    if (props.data && val) {
      const index = props.data.findIndex((item) => item.cdchangekbn === val)
      if (props.data && index != undefined && index > -1) {
        tableList.value = props.data[index].codechangedetailList
      } else {
        tableList.value = []
      }
      const changeCodeMain = props.changeCodeMainList?.find((item) => item.codehenkankbn === +val)
      if (changeCodeMain) {
        loading.value = true
        //本システムコード取得
        InitSysCodeList({
          changeCodeMainData: changeCodeMain
        })
          .then((res) => {
            codeOptions.value = res.systemcodeList
          })
          .finally(() => {
            loading.value = false
          })
      }
    } else {
      tableList.value = []
    }
  }
)
watch(
  () => props.gyoumukbn,
  (newValue) => {
    getInitData()
  },
  { deep: true }
)
watch(
  () => props.impno,
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
  trasnferOptions.value = props.options
}

//行追加
const add = async () => {
  const $table = xTableRef.value
  if ($table) {
    $table.setCurrentRow(null)
    const { row: newRow } = await $table.insertAt({ oldFlg: true }, -1)
    $table.setCurrentRow(newRow)
    const kbn = cdchange.value
    tableList.value.push({
      cdchangekbn: kbn,
      oldcode: '',
      newcode: ''
    })
    setTimeout(() => {
      $table.setEditCell(newRow, 'code')
    }, 0)
  }
}
//行削除
const deleteRow = async () => {
  const current = xTableRef.value?.getCurrentRecord()
  if (current) {
    showDeleteModal({
      onOk() {
        const index = tableList.value.findIndex((item) => item.oldcode === current.oldcode)
        tableList.value.splice(index, 1)
        xTableRef.value?.removeCurrentRow()
        onCloseCellEdit()
      }
    })
  }
}
//編集状態
const onCloseCellEdit = () => {
  emit('update:isChange', true)
  emit('getData', 'codeTransfer', getTableData(), true)
}
//画面データ取得
const getTableData = () => {
  const tableData = xTableRef.value?.getTableData().tableData || []
  tableData.forEach((item) => {
    item.impno = props.impno
    item.newcode = item.newcode?.split(':')[0]?.trim()
  })
  const index = props.data?.findIndex((item) => item.cdchangekbn === cdchange.value)
  if (props.data && index != undefined && index > -1) {
    props.data[index].codechangedetailList = tableData
  } else {
    const data: CodeChangeVM = { cdchangekbn: cdchange.value!, codechangedetailList: tableData }
    props.data?.push(data)
  }
  return props.data
}
const rowClassName = ({ row }) => {
  if (!row['oldcode']) {
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
