<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー管理(詳細画面：権限（個別画面）)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <vxe-table
      align="center"
      :height="Math.max(tableHeight, 400)"
      show-header-overflow="title"
      :column-config="{ resizable: true }"
      :row-config="{ keyField: 'kinoid', isHover: true }"
      :tree-config="{
        transform: true,
        expandAll: true,
        rowField: 'kinoid',
        parentField: 'parentid'
      }"
      :data="_tableData"
      :header-row-class-name="set ? 'bg-editable' : 'bg-readonly'"
    >
      <vxe-column
        field="kinonm"
        title="機能名"
        width="280"
        tree-node
        align="left"
        header-class-name="bg-readonly"
        :class-name="
          ({ row }) => (set && hasExtend && row.viewflg && !row.keisyoflg ? 'c-red' : '')
        "
      ></vxe-column>
      <vxe-column field="viewflg">
        <template #header>
          <a-checkbox
            v-if="set"
            v-model:checked="accessChecked"
            class="mr1"
            @change="(e) => changeHeaderCheck(e, 'viewflg')"
          />アクセス権限
        </template>
        <template #default="{ row, column: { field } }">
          <a-checkbox
            v-if="set"
            :checked="row.viewflg"
            @change="(e) => changeSingleCheck(e, { row, field })"
          ></a-checkbox>
          <CheckBox v-else :flag="row.viewflg" />
        </template>
      </vxe-column>
      <vxe-colgroup title="操作権限">
        <vxe-column field="allflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="allChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'allflg')"
            />全て
          </template>
          <template #default="{ row }">
            <a-checkbox
              v-if="row.allflg !== null && set"
              :checked="row.allflg"
              :disabled="!row.viewflg"
              @change="(e) => changeAllCheck(e, row)"
            ></a-checkbox>
            <CheckBox v-else :flag="row.allflg" />
          </template>
        </vxe-column>
        <vxe-column field="addflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="addChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'addflg')"
            />追加
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.addflg !== null && set"
              :checked="row.addflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.addflg" />
          </template>
        </vxe-column>
        <vxe-column field="updflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="updChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'updflg')"
            />修正
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.updflg !== null && set"
              :checked="row.updflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.updflg" />
          </template>
        </vxe-column>
        <vxe-column field="delflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="delChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'delflg')"
            />削除
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.delflg !== null && set"
              :checked="row.delflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.delflg" />
          </template>
        </vxe-column>
        <vxe-column
          field="personalnoflg"
          :header-class-name="set && pnoeditflg ? 'bg-editable' : 'bg-readonly'"
        >
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess && pnoeditflg"
              v-model:checked="noChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'personalnoflg')"
            />個人番号利用
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.personalnoflg !== null && set"
              :checked="row.personalnoflg"
              :disabled="!row.viewflg || !pnoeditflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.personalnoflg" />
          </template>
        </vxe-column>
      </vxe-colgroup>
      <vxe-column v-if="set && hasExtend" field="keisyoflg">
        <template #header>
          <a-checkbox
            v-if="hasAnyAccess"
            v-model:checked="extendChecked"
            class="mr1"
            @change="(e) => changeHeaderCheck(e, 'keisyoflg')"
          />所属継承可能
        </template>
        <template #default="{ row, column: { field } }">
          <a-checkbox
            :checked="row.keisyoflg"
            :disabled="!row.viewflg"
            @change="(e) => changeSingleCheck(e, { row, field })"
          ></a-checkbox>
        </template>
      </vxe-column>
    </vxe-table>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, watch, onUnmounted, Ref } from 'vue'
import { GamenVM } from '../type'
import { getUserMenu } from '@/utils/user'
import { Enumプログラム区分 } from '#/Enums'
import emitter from '@/utils/event-bus'
import { KengenStore } from '@/store'
import { useTableHeight } from '@/utils/hooks'
import CheckBox from './CheckBox.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface VM extends GamenVM {
  parentid: string
  isfolder: boolean
}

const props = defineProps<{
  /** ユーザー個別に設定 */
  set: boolean
  data: GamenVM[]
  fixedData?: GamenVM[]
  /** 所属継承可能列 */
  hasExtend?: boolean
  headRef: Ref
}>()

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { editJudge, pnoeditflg } = KengenStore
const fields = pnoeditflg
  ? ['addflg', 'updflg', 'delflg', 'personalnoflg']
  : ['addflg', 'updflg', 'delflg']
const tableData = ref<VM[]>([])
//ヘッダー行チェックボックス
const accessChecked = ref(false)
const allChecked = ref(false)
const addChecked = ref(false)
const updChecked = ref(false)
const delChecked = ref(false)
const noChecked = ref(false)
const extendChecked = ref(false)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getTableData(props.set ? props.data : props.fixedData ?? [])
  emitter.on('afterChangeSyzoku', () => {
    if (!props.set) getTableData(props.fixedData ?? [])
  })
})
onUnmounted(() => {
  emitter.clearKey('afterChangeSyzoku')
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.set,
  () => getTableData(props.fixedData ?? [])
)

//設定処理(ヘッダー行：全て)
watch(
  tableData,
  (data) => {
    accessChecked.value = data.every((i) => i.viewflg)
    extendChecked.value = data.filter((i) => i.viewflg).every((i) => i.keisyoflg !== false)
    allChecked.value = data.filter((i) => i.viewflg).every((i) => i.allflg !== false)
    addChecked.value = data.filter((i) => i.viewflg).every((i) => i.addflg !== false)
    updChecked.value = data.filter((i) => i.viewflg).every((i) => i.updflg !== false)
    delChecked.value = data.filter((i) => i.viewflg).every((i) => i.delflg !== false)
    if (pnoeditflg)
      noChecked.value = data.filter((i) => i.viewflg).every((i) => i.personalnoflg !== false)
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(props.headRef, props.hasExtend ? -38 : -5)

//アクセス権限設定連動処理
const hasAnyAccess = computed(() => {
  return tableData.value.some((i) => i.viewflg)
})

//「全て」列設定連動処理
const _tableData = computed(() => {
  for (const item of tableData.value) {
    if (
      fields
        .map((field) => item[field])
        .filter((item) => item !== null)
        .includes(false)
    ) {
      item.allflg = false
    }
    if (
      fields
        .map((field) => item[field])
        .filter((item) => item !== null)
        .every((el) => el === true)
    ) {
      item.allflg = true
    }
    if (fields.map((field) => item[field]).every((el) => el === null)) {
      item.allflg = null
    }
  }
  return tableData.value
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
function getTableData(data: GamenVM[]) {
  const MenuData: VM[] = getUserMenu().map((item) => ({
    programkbn: Enumプログラム区分.画面,
    kinonm: item.menuname,
    kinoid: item.menuid,
    parentid: item.parentid,
    isfolder: item.isfolder,
    allflg: false,
    viewflg: false,
    addflg: null,
    updflg: null,
    delflg: null,
    personalnoflg: null,
    keisyoflg: null,
    upddttm: ''
  }))
  for (const item of data) {
    const findMenu = MenuData.find((m) => m.kinoid === item.kinoid)
    if (findMenu) {
      //継承可能フラグtrueを設定
      Object.assign(findMenu, item.keisyoflg === null ? { ...item, keisyoflg: item.viewflg } : item)
    }
  }
  tableData.value = MenuData
  transferData(tableData.value.filter((item) => !item.isfolder))
}

//画面ごとに親メニューを再帰してフラグ設定
function transferData(data) {
  const allFields = ['addflg', 'delflg', 'updflg', 'personalnoflg', 'viewflg', 'keisyoflg']
  for (const item of data) {
    for (const field of allFields) {
      if (item[field] === true) setFieldRecursively2(item, field)
      if (item[field] === false) setFieldRecursively3(item, field)
    }
  }
}

//チェックボックス連動処理：親階層変更する時、子も変更する
function setFieldRecursively(row, field, checked) {
  if (row.children.length > 0) {
    for (const el of row.children) {
      if (el[field] !== null) el[field] = checked
      el.color = checked ? 'c-red' : 'c-black'
      setFieldRecursively(el, field, checked)
    }
  }
}
//チェックボックス連動処理：子変更する時、親階層も変更する=>全ての子がtrueの場合、trueに変更
function setFieldRecursively2(row, field) {
  if (row.parentid) {
    const parentItem = tableData.value.find((el) => el.kinoid === row.parentid)
    const brotherItems = tableData.value.filter((el) => el.parentid === row.parentid)
    if (parentItem && brotherItems.every((el) => el[field] !== false)) {
      parentItem[field] = true
      setFieldRecursively2(parentItem, field)
    }
  }
}
//チェックボックス連動処理：子変更する時、親階層も変更する=>いづれの子がfalseの場合、falseに変更
function setFieldRecursively3(row, field) {
  if (row.parentid) {
    const parentItem = tableData.value.find((el) => el.kinoid === row.parentid)
    if (parentItem) {
      parentItem[field] = false
      setFieldRecursively3(parentItem, field)
    }
  }
}
//単一チェック(セルごと)
function changeSingleCheck(e, { row, field }) {
  if (row[field] === null) return
  row[field] = e.target.checked
  setFieldRecursively(row, field, e.target.checked)
  if (e.target.checked) {
    setFieldRecursively2(row, field)
  } else {
    setFieldRecursively3(row, field)
  }

  //継承可能フラグ初期値設定
  if (field === 'viewflg' && e.target.checked && props.hasExtend) {
    row.keisyoflg = true
    setFieldRecursively(row, 'keisyoflg', true)
    setFieldRecursively2(row, 'keisyoflg')
  }

  editJudge.setEdited()
}

//全選チェック(「全て」)
function changeAllCheck(e, row) {
  row.allflg = e.target.checked
  setFieldRecursively(row, 'allflg', e.target.checked)
  if (e.target.checked) {
    setFieldRecursively2(row, 'allflg')
  } else {
    setFieldRecursively3(row, 'allflg')
  }
  fields.forEach((field) => {
    changeSingleCheck(e, { row, field })
  })
}
//ヘッダー行チェック(列ごと)
function changeHeaderCheck(e, flgname) {
  if (flgname === 'allflg') {
    for (const item of tableData.value) {
      if (item.viewflg && item.allflg !== null) changeAllCheck(e, item)
    }
  } else {
    for (const item of tableData.value) {
      if (item.viewflg || flgname === 'viewflg') {
        changeSingleCheck(e, { row: item, field: flgname })
      }
    }
  }
}

function submit() {
  return tableData.value.filter((item) => item.viewflg && !item.isfolder)
}

defineExpose({ submit })
</script>
