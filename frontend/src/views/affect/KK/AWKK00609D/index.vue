<template>
  <a-modal v-model:visible="modalVisible" title="変換区分管理" width="1200px" destroy-on-close>
    <CloseModalBtn @click="closeModal" />
    <a-spin :spinning="loading">
      <div class="m-t-1 flex justify-between">
        <a-space>
          <a-button type="primary" @click="add">行追加</a-button>
          <a-button type="primary" @click="deleteRow" @keydown="handleTabKey">行削除</a-button>
        </a-space>
      </div>
      <div class="m-t-1 w-full" :style="{ height: '50vh' }">
        <vxe-table
          ref="xTableRef"
          class="mytable-style"
          height="100%"
          :data="tableList"
          :column-config="{ resizable: true }"
          :header-cell-class-name="'bg-editable'"
          :mouse-config="{ selected: true }"
          :row-config="{ isCurrent: true, height: 36 }"
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
              if (
                column.field === 'codehenkankbn' &&
                props.data &&
                props.data.some((item) => item.codehenkankbn === row.codehenkankbn)
              ) {
                return false
              } else {
                return true
              }
            }
          }"
          :valid-config="{ showMessage: false }"
          :empty-render="{ name: 'NotData' }"
          :edit-rules="rules"
          @edit-actived="editActivedEvent"
        >
          >
          <vxe-column
            field="codehenkankbn"
            title="コード変換区分"
            :edit-render="{ autofocus: '.ant-input' }"
            :class-name="({ row }) => (!row.codehenkankbn ? 'bg-errorcell' : '')"
            min-width="110"
          >
            <template #edit="{ row }">
              <a-input v-model:value="row.codehenkankbn" min="1" max="9999" type="number"></a-input>
            </template>
          </vxe-column>
          <vxe-column
            field="henkankbnnm"
            title="変換区分名称"
            :edit-render="{ autofocus: '.ant-input', autoselect: true }"
            :class-name="({ row }) => (!row.henkankbnnm ? 'bg-errorcell' : '')"
            min-width="110"
          >
            <template #edit="{ row }">
              <a-textarea
                v-model:value="row.henkankbnnm"
                :maxlength="30"
                :auto-size="{ minRows: 1 }"
                type="text"
              ></a-textarea>
            </template>
          </vxe-column>

          <vxe-column
            field="codekanritablenm"
            title="コード管理テーブル名"
            :edit-render="{
              autofocus: 'input',
              autoselect: true
            }"
            :class-name="({ row }) => (!row.codekanritablenm ? 'bg-errorcell' : '')"
            min-width="130"
          >
            <template #edit="{ row }">
              <ai-select
                v-model:value="row.codekanritablenm"
                allow-clear
                split-val
                :options="codeManagerTableList"
                @change="onChangeTableName(row)"
              >
              </ai-select>
            </template>
            <template #default="{ row }">
              {{ row.codekanritablenm }} {{ row.codekanritablenm ? ':' : '' }}
              {{ codeManagerTableList?.find((item) => item.value == row.codekanritablenm)?.label }}
            </template>
          </vxe-column>
          <vxe-column
            field="maincd"
            title="メインコード"
            :edit-render="{ autofocus: 'input', autoselect: true }"
            :class-name="({ row }) => (!row.maincd ? 'bg-errorcell' : '')"
            min-width="110"
          >
            <template #edit="{ row }">
              <ai-select
                v-if="row.codekanritablenm"
                v-model:value="row.maincd"
                :options="row.rowMaincdList"
                split-val
                @change="onChangeMaincd(row)"
              ></ai-select>
            </template>
            <template #default="{ row }">
              {{ row.maincd }} {{ row.maincd ? ':' : '' }}
              {{ row.rowMaincdList?.find((item) => item.value == row.maincd)?.label }}
            </template>
          </vxe-column>
          <vxe-column
            field="subcd"
            title="サブコード"
            :edit-render="{ autofocus: 'input', autoselect: true }"
            :class-name="({ row }) => (!row.subcd ? 'bg-errorcell' : '')"
            min-width="110"
          >
            <template #edit="{ row }">
              <ai-select
                v-if="row.maincd"
                v-model:value="row.subcd"
                :options="row.rowSubcdList"
                split-val
              ></ai-select>
            </template>
            <template #default="{ row }">
              {{ row.subcd }} {{ row.subcd ? ':' : '' }}
              {{ row.rowSubcdList?.find((item) => item.value == row.subcd)?.label }}
            </template>
          </vxe-column>
          <vxe-column
            field="sonotajoken"
            title="その他条件"
            :edit-render="{ autofocus: 'input', autoselect: true }"
            min-width="110"
          >
            <template #edit="{ row }">
              <a-textarea
                v-model:value="row.sonotajoken"
                maxlength="200"
                show-count
                :auto-size="{ minRows: 1 }"
              ></a-textarea>
            </template>
          </vxe-column>
        </vxe-table>
      </div>
    </a-spin>
    <template #footer>
      <a-button type="primary" style="float: left" @click="onSet">設定</a-button>
      <a-button key="back" type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, nextTick, onMounted, ref, watch } from 'vue'
import { showDeleteModal } from '@/utils/modal'
import { ChangeCodeMainVM } from '../AWKK00601G/type'
import { VXETable, VxeTableEvents, VxeTableInstance, VxeTablePropTypes } from 'vxe-table'
import { InitDetail, InitMaincdList, InitSubcdList } from './service'
import { ChangeCodeMainExVM } from './type'
import { Judgement } from '@/utils/judge-edited'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  visible: boolean
  isChange: boolean
  impno?: string
  data?: ChangeCodeMainVM[]
}
interface CachePnameVO {
  ptype: string
  subcdList: DaSelectorModel[]
}
const props = defineProps<Props>()
const emit = defineEmits(['update:visible', 'update:isChange', 'getData', 'updOptions'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const loading = ref(false)
const editJudge = new Judgement()
const tableList = ref<ChangeCodeMainExVM[]>([])
const xTableRef = ref<VxeTableInstance<ChangeCodeMainExVM>>()
const codeManagerTableList = ref<DaSelectorModel[]>([])
const cachePnameList = ref<CachePnameVO[]>([])
const rules = ref<VxeTablePropTypes.EditRules<ChangeCodeMainVM>>({
  codehenkankbn: [
    { required: true, max: 4 },
    {
      validator({ cellValue, rowIndex, $table }) {
        return new Promise((resolve, reject) => {
          if (rowIndex === 0) {
            resolve()
          }
          const prevHenkankbn = $table.getTableData().tableData[rowIndex - 1].codehenkankbn

          if (cellValue > 0 && cellValue > prevHenkankbn) {
            resolve()
          } else {
            reject()
          }
        })
      }
    }
  ],
  henkankbnnm: [{ required: true }],
  codekanritablenm: [{ required: true }],
  maincd: [{ required: true }],
  subcd: [{ required: true }]
})
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

watch(tableList, () => editJudge.setEdited(), { deep: true })
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  }
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  VXETable.interceptor.add('event.keydown', (params) => {
    const { $event, $table } = params
    const rowIndex = $table.getRowIndex($table.getCurrentRecord())
    const tableData = $table.getTableData().fullData
    if (
      $event.key === 'Tab' &&
      $table.getEditRecord().column.field === 'subcd' &&
      rowIndex === tableData.length - 1
    ) {
      $table.clearEdit()
      $table.clearCurrentRow()
    }
  })
})
//--------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------

//modal閉じる
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    modalVisible.value = false
  })
}

const getInitData = () => {
  loading.value = true
  const data = JSON.parse(JSON.stringify(props.data))
  InitDetail({ changeCodeMainList: data })
    .then((res) => {
      codeManagerTableList.value = res.codeManagerTableList
      tableList.value = res.changeCodeMainExList
      nextTick(() => editJudge.reset())
      loading.value = false
    })
    .catch(() => {
      loading.value = false
    })
  for (let item of tableList.value) {
    InitSubcdList({ tablename: item.codekanritablenm, maincd: item.maincd }).then((res) => {
      cachePnameList.value.push({ ptype: item.maincd, subcdList: res.subcdList })
    })
  }
}

//行追加
const add = async () => {
  const $table = xTableRef.value
  if ($table) {
    $table.setCurrentRow(null)
    let maxCodehenkankbn = tableList.value.reduce(
      (max, item) => (max.codehenkankbn > item.codehenkankbn ? max : item),
      { codehenkankbn: 0 }
    ).codehenkankbn
    const { row: newRow } = await $table.insertAt({ codehenkankbn: maxCodehenkankbn + 1 }, -1)
    $table.setCurrentRow(newRow)
    tableList.value.push(newRow)
    setTimeout(() => {
      $table.setEditCell(newRow, 'codehenkankbn')
    }, 0)
  }
}

//行削除
const deleteRow = async () => {
  const current = xTableRef.value?.getCurrentRecord()
  if (current) {
    showDeleteModal({
      onOk() {
        const index = tableList.value.findIndex(
          (item) => item.codehenkankbn === current.codehenkankbn
        )
        tableList.value.splice(index, 1)
        xTableRef.value?.removeCurrentRow()
      }
    })
  }
}

//設定
const onSet = async () => {
  const $table = xTableRef.value
  const errMap = await $table?.validate(true)
  if (errMap) return Promise.reject()
  else {
    emit('update:isChange', true)
    let changeCodeMainList: ChangeCodeMainVM[] = tableList.value.map((item) => {
      let { rowMaincdList, rowSubcdList, ...rest } = item
      rest.codehenkankbn = +rest.codehenkankbn
      return rest
    })
    emit('getData', 'changeCodeMainList', changeCodeMainList)
    emit('updOptions', changeCodeMainList)
    editJudge.reset()
    closeModal()
  }
}

//コード管理テーブル名変更処理
const onChangeTableName = (row: ChangeCodeMainExVM) => {
  row.maincd = ''
  row.subcd = ''
  updateMaincdList(row)
}

//メインコード変更処理
const onChangeMaincd = (row: ChangeCodeMainExVM) => {
  row.subcd = ''
  updateSubcdList(row)
}

//【メインコード】のドロップダウンリスト更新
const updateMaincdList = (row: ChangeCodeMainExVM) => {
  InitMaincdList({ tablename: row.codekanritablenm }).then((res) => {
    row.rowMaincdList = res.maincdList
  })
}

//【サブコード】のドロップダウンリスト更新
const updateSubcdList = (row: ChangeCodeMainExVM) => {
  InitSubcdList({ tablename: row.codekanritablenm, maincd: row.maincd }).then((res) => {
    row.rowSubcdList = res.subcdList
  })
}

//編集状態でドロップダウンリスト更新
const editActivedEvent: VxeTableEvents.EditActived<ChangeCodeMainExVM> = ({ row }) => {
  updateMaincdList(row)
  updateSubcdList(row)
}

function handleTabKey(event) {
  if (event.key === 'Tab' && !event.shiftKey) {
    const nextRow = xTableRef.value?.getData(0)
    setTimeout(() => {
      xTableRef.value?.setCurrentRow(nextRow)
      xTableRef.value?.setEditCell(nextRow, 'henkankbnnm')
    }, 0)
  }
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
</style>
