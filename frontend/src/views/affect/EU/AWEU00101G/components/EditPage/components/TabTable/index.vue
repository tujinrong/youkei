<template>
  <a-spin :spinning="loading">
    <a-space>
      <a-button class="btn-round" type="primary" :disabled="!updflg" @click.stop="openFreeItemModal"
        >項目選択</a-button
      >
      <a-button class="btn-round" type="primary" :disabled="!updflg" @click="() => handleAppend()"
        >項目追加</a-button
      >
      <a-button class="btn-round" type="primary" @click="openTransferModal(Enum使用区分.一覧項目)"
        >項目ツリー</a-button
      >
      <a-button
        v-show="false"
        class="btn-round"
        type="primary"
        @click="openTransferModal(Enum使用区分.集計項目)"
        >集計項目ツリー</a-button
      >
      <a-button type="primary" danger :disabled="isDisabledDel" class="btn-round" @click="handleDel"
        >削除</a-button
      >
    </a-space>
    <div class="m-t-1">
      <a-collapse v-model:activeKey="activeKey" accordion>
        <template #expandIcon="{ isActive }">
          <MinusOutlined v-if="isActive"></MinusOutlined>
          <PlusOutlined v-else></PlusOutlined>
        </template>
        <a-collapse-panel v-for="item in collapsePanel" :key="item.key" :header="item.header">
          <vxe-table
            ref="tableRef"
            auto-resize
            :data="dataSource"
            :height="500"
            :row-config="{ isHover: true, keyField: 'tableid' }"
            :column-config="{ resizable: true }"
            :empty-render="{ name: 'NotData' }"
            :expand-config="{ reserve: true, trigger: 'cell' }"
          >
            <vxe-column type="expand" width="50" header-class-name="bg-editable">
              <template #content="{ row, rowIndex }">
                <div class="p-4">
                  <vxe-table
                    ref="childTableRef"
                    :height="392"
                    :data="row.itemlist"
                    :row-config="{ isHover: true, isCurrent: true, keyField: 'sqlcolumn' }"
                    :column-config="{ resizable: true }"
                    :empty-render="{ name: 'NotData' }"
                    header-cell-class-name="bg-readonly"
                  >
                    <vxe-column type="checkbox" width="50"></vxe-column>
                    <vxe-column field="itemid" title="項目ID">
                      <template #default="{ row: row2 }">
                        <a @click="openEditField(row2, row.itemid, rowIndex)">{{ row2.itemid }}</a>
                      </template>
                    </vxe-column>
                    <vxe-column field="itemhyojinm" title="項目名">
                      <template #default="{ row: row2 }">
                        <a @click="openEditField(row2, row.tableid, rowIndex)">{{
                          row2.itemhyojinm
                        }}</a>
                      </template>
                    </vxe-column>
                    <vxe-column field="sqlcolumn" title="物理名/SQL"></vxe-column>
                    <vxe-column field="daibunrui" title="大分類"></vxe-column>
                    <vxe-column field="tyubunrui" title="中分類"></vxe-column>
                    <vxe-column field="syobunrui" title="小分類" :resizable="false"></vxe-column>
                  </vxe-table>
                </div>
              </template>
            </vxe-column>

            <vxe-column field="tablealias" title="別名"></vxe-column>
            <vxe-column field="tablehyojinm" title="テーブル名称"></vxe-column>
            <vxe-column field="tablenm" title="テーブル物理名" :resizable="false"></vxe-column>
          </vxe-table>
        </a-collapse-panel>
      </a-collapse>
    </div>
  </a-spin>
  <tree-modal
    v-model:visible="modalVisible"
    :groupid="props.groupid"
    :syukekbn="syukekbn"
  ></tree-modal>

  <free-modal
    v-model:visible="freeItemVisible"
    :groupid="props.groupid"
    :table-list="dataSource"
    :table-index="tableIndex"
    :form="freeForm"
    :total-table="totalTable"
    @refresh="init"
  ></free-modal>

  <project-modal
    v-model:visible="fieldAddVisible"
    :sqlcolumn="sqlcolumn"
    :table-list="alltable"
    @refresh="init"
  />
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//項目一覧
//---------------------------------------------------------------------------
import { onMounted, ref, reactive, computed, nextTick } from 'vue'
import { PlusOutlined, MinusOutlined } from '@ant-design/icons-vue'
import { message } from 'ant-design-vue'
import { VxeTableInstance } from 'vxe-table'
import { Enum使用区分 } from '#/Enums'
import { showDeleteModal } from '@/utils/modal'
import { DELETE_OK_INFO } from '@/constants/msg'
import { totalTableLlistType, DatasourceTableVM } from '@/views/affect/EU/AWEU00101G/type'
import { InitDetailTab, DeleteItems } from '@/views/affect/EU/AWEU00101G/service'

import TreeModal from '@/views/affect/EU/AWEU00107D/index.vue'
import ProjectModal from '@/views/affect/EU/AWEU00104D/index.vue'
import FreeModal from '@/views/affect/EU/AWEU00103D/index.vue'
import { useRoute } from 'vue-router'

enum EnumType {
  メインテーブル = '1',
  トランザクションテーブル = '2',
  マスタ = '3',
  フリー項目 = '4',
  View = '5'
}
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  groupid: string
}

const props = withDefaults(defineProps<Props>(), {})
const emit = defineEmits(['setInfo'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
//テンプレート参照
//モード表示
const modalVisible = ref(false)
const fieldAddVisible = ref(false)
const freeItemVisible = ref(false)
//ローディング
const loading = ref(false)
//ビューモデル
const syukekbn = ref<Enum使用区分 | null>(null)
const activeKey = ref<EnumType | ''>('')
const parentIndex = ref(-1)
const tableIndex = ref(-1)
const tableList = ref<DatasourceTableVM[]>([])
const translationList = ref<DatasourceTableVM[]>([])
const masterList = ref<DatasourceTableVM[]>([])
const freeList = ref<DatasourceTableVM[]>([])
const viewList = ref<DatasourceTableVM[]>([])
const maxFieldId = ref(0)
const idMap = reactive({
  maindataIdMap: { maxTableId: 0 },
  joindataIdMap: { maxTableId: 0 },
  masterdataIdMap: { maxTableId: 0 },
  freedataIdMap: { maxTableId: 0 },
  viewdataIdMap: { maxTableId: 0 },
  fixeddataIdMap: { maxTableId: 0 },
  sqldataIdMap: { maxTableId: 0 }
})

const sqlcolumn = ref('')

const freeForm = ref({
  division: '',
  bindingAlias: '',
  bindingKey: '',
  bindingName: '',
  additionalCondition: '',
  tableid: '',
  upddttm: ''
})

const tableRef = ref<VxeTableInstance[]>([])
const childTableRef = ref<VxeTableInstance[]>([])

const collapsePanel = computed(() => {
  return [
    {
      key: EnumType.メインテーブル,
      header: 'メインテーブル（' + tableList.value.length + '）'
    },
    {
      key: EnumType.トランザクションテーブル,
      header: 'トランザクションテーブル（' + translationList.value.length + '）'
    },
    { key: EnumType.マスタ, header: 'マスタ（' + masterList.value.length + '）' },
    { key: EnumType.フリー項目, header: 'フリー項目（' + freeList.value.length + '）' },
    { key: EnumType.View, header: 'View（' + viewList.value.length + '）' }
  ]
})

//権限フラグ
const route = useRoute()
const updflg = route.meta.updflg

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

const dataSource = computed<totalTableLlistType[]>(() => {
  const obj: Record<EnumType, DatasourceTableVM[]> = {
    [EnumType.メインテーブル]: tableList.value,
    [EnumType.トランザクションテーブル]: translationList.value,
    [EnumType.マスタ]: masterList.value,
    [EnumType.フリー項目]: freeList.value,
    [EnumType.View]: viewList.value
  }

  return obj[activeKey.value] || []
})

const alltable = computed<DatasourceTableVM[]>(() => [
  ...tableList.value,
  ...translationList.value,
  ...masterList.value,
  ...freeList.value,
  ...viewList.value
])

const totalTable = computed<DatasourceTableVM[]>(() => {
  const key: string = activeKey.value
  if (key === EnumType.メインテーブル) {
    return tableList.value
  } else if (key === EnumType.トランザクションテーブル) {
    return translationList.value
  } else if (key === EnumType.マスタ) {
    return masterList.value
  } else if (key === EnumType.フリー項目) {
    return [...tableList.value, ...masterList.value, ...translationList.value, ...viewList.value]
  } else if (key === EnumType.View) {
    return viewList.value
  }
  return []
})

const isDisabledDel = computed(() => {
  let params: any[] = []
  for (const el of childTableRef.value) {
    params = params.concat(el.getCheckboxRecords())
  }
  return params.length === 0 || !updflg
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------

onMounted(() => {
  init()
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化
const init = (options?: { expend: boolean }) => {
  InitDetailTab({ datasourceid: String(props.groupid) }).then((res) => {
    tableList.value = [res.maindata]
    masterList.value = res.masterdata ?? []
    viewList.value = res.viewdata ?? []
    freeList.value = res.freedata ?? []
    translationList.value = res.joindata ?? []

    emit('setInfo', res)

    if (options?.expend) {
      nextTick(() => expandRow())
    }
  })
}

const handleAppend = (sql = '') => {
  fieldAddVisible.value = true
  sqlcolumn.value = sql
}

//フィールド編集modal表示
const openEditField = (val, tableid: string, tIndex: number) => {
  tableIndex.value = tIndex
  parentIndex.value = tIndex
  getMaxFieldId(tableid)
  handleAppend(val.sqlcolumn)
}

//別名の取得
const getBindingAlias = (key: string) => {
  const obj: Record<EnumType, string> = {
    [EnumType.メインテーブル]: 'T',
    [EnumType.トランザクションテーブル]: 'T' + (idMap.joindataIdMap.maxTableId + 1),
    [EnumType.マスタ]: 'M' + (idMap.masterdataIdMap.maxTableId + 1),
    [EnumType.フリー項目]: 'F' + (idMap.freedataIdMap.maxTableId + 1),
    [EnumType.View]: 'V' + (idMap.viewdataIdMap.maxTableId + 1)
  }
  return obj[key]
}

//トランザクションmodal表示
const openTransferModal = (type: Enum使用区分) => {
  syukekbn.value = type
  modalVisible.value = true
}

//フリー項目modal表示
const openFreeItemModal = () => {
  parentIndex.value = -1
  freeForm.value.bindingName = getBindingAlias('4')
  freeForm.value.bindingAlias = ''
  tableIndex.value = -1
  freeItemVisible.value = true
}

//最大IDの取得
const getMaxFieldId = (tableid) => {
  const obj: Record<EnumType, number> = {
    [EnumType.メインテーブル]: idMap.maindataIdMap[tableid],
    [EnumType.トランザクションテーブル]: idMap.joindataIdMap[tableid],
    [EnumType.マスタ]: idMap.masterdataIdMap[tableid],
    [EnumType.フリー項目]: idMap.freedataIdMap[tableid],
    [EnumType.View]: idMap.viewdataIdMap[tableid]
  }
  maxFieldId.value = obj[activeKey.value] || 0
}

//行展開
const expandRow = () => {
  for (const el of tableRef.value) {
    el.clearRowExpand()
    el.setRowExpand(el.getData()[el.getData().length - 1], true)
  }
}

// 削除
const handleDel = async () => {
  let params: any[] = []
  let mainTableTotal = 0
  for (const el of childTableRef.value) {
    params = params.concat(el.getCheckboxRecords())
    mainTableTotal = mainTableTotal + el.getData().length
  }
  if (activeKey.value == EnumType.メインテーブル && mainTableTotal == params.length) {
    message.warning('メインテーブルの項目をすべて削除できません。')
    return
  }
  if (params.length > 0) {
    const delReq = async (checkflg: boolean) => {
      await DeleteItems({
        deleteitemlist: params,
        datasourceid: String(props.groupid),
        checkflg
      })
    }
    await delReq(true)
    showDeleteModal({
      handleDB: true,
      async onOk() {
        try {
          await delReq(false)
          message.success(DELETE_OK_INFO.Msg)
          init({ expend: true })
        } catch (error) {}
      }
    })
  }
}
</script>

<style scoped lang="less" src="./index.less"></style>
