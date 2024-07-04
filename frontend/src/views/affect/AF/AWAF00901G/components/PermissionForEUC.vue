<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ユーザー管理(詳細画面：権限（EUC帳票）)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <vxe-table
      :height="Math.max(tableHeight, 400)"
      align="center"
      show-header-overflow="title"
      :column-config="{ resizable: true }"
      :row-config="{ isHover: true }"
      :data="_tableData"
      :header-row-class-name="set ? 'bg-editable' : 'bg-readonly'"
    >
      <vxe-column
        field="reportgroupnm"
        title="帳票グループ名"
        width="280"
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
        <vxe-column field="tutisyooutflg" :visible="false">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="tutisyooutChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'tutisyooutflg')"
            />通知書出力
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.tutisyooutflg !== null && set"
              :checked="row.tutisyooutflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.tutisyooutflg" />
          </template>
        </vxe-column>
        <vxe-column field="pdfoutflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="pdfoutChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'pdfoutflg')"
            />PDF出力
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.pdfoutflg !== null && set"
              :checked="row.pdfoutflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.pdfoutflg" />
          </template>
        </vxe-column>
        <vxe-column field="exceloutflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="exceloutChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'exceloutflg')"
            />EXCEL出力
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.exceloutflg !== null && set"
              :checked="row.exceloutflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.exceloutflg" />
          </template>
        </vxe-column>
        <vxe-column field="othersflg">
          <template #header>
            <a-checkbox
              v-if="set && hasAnyAccess"
              v-model:checked="othersChecked"
              class="mr1"
              @change="(e) => changeHeaderCheck(e, 'othersflg')"
            />その他出力
          </template>
          <template #default="{ row, column: { field } }">
            <a-checkbox
              v-if="row.othersflg !== null && set"
              :checked="row.othersflg"
              :disabled="!row.viewflg"
              @change="(e) => changeSingleCheck(e, { row, field })"
            ></a-checkbox>
            <CheckBox v-else :flag="row.othersflg" />
          </template>
        </vxe-column>
        <vxe-column
          field="personalnoflg"
          :header-class-name="set && pnoeditflg ? 'bg-editable' : 'bg-readonly'"
          :visible="false"
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
import { ref, onMounted, watch, computed, onUnmounted, Ref } from 'vue'
import { ReportVM } from '../type'
import emitter from '@/utils/event-bus'
import { KengenStore } from '@/store'
import { useTableHeight } from '@/utils/hooks'
import CheckBox from './CheckBox.vue'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  set: boolean
  data: ReportVM[]
  fixedData?: ReportVM[]
  /** 所属継承可能列 */
  hasExtend?: boolean
  headRef: Ref
}>()

//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { editJudge, pnoeditflg } = KengenStore
const fields = pnoeditflg
  ? ['tutisyooutflg', 'pdfoutflg', 'exceloutflg', 'othersflg', 'personalnoflg']
  : ['tutisyooutflg', 'pdfoutflg', 'exceloutflg', 'othersflg']
const tableData = ref<ReportVM[]>([])
//ヘッダー行チェックボックス
const accessChecked = ref(false)
const allChecked = ref(false)
const tutisyooutChecked = ref(false)
const pdfoutChecked = ref(false)
const exceloutChecked = ref(false)
const othersChecked = ref(false)
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
    tutisyooutChecked.value = data.filter((i) => i.viewflg).every((i) => i.tutisyooutflg !== false)
    pdfoutChecked.value = data.filter((i) => i.viewflg).every((i) => i.pdfoutflg !== false)
    exceloutChecked.value = data.filter((i) => i.viewflg).every((i) => i.exceloutflg !== false)
    othersChecked.value = data.filter((i) => i.viewflg).every((i) => i.othersflg !== false)
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
function getTableData(data: ReportVM[]) {
  tableData.value = data.map((item) => ({
    ...item,
    allflg: false,
    keisyoflg: item.keisyoflg === null ? item.viewflg : item.keisyoflg
  }))
}
//単一チェック(セルごと)
function changeSingleCheck(e, { row, field }) {
  if (row[field] === null) return
  row[field] = e.target.checked
  //継承可能フラグ初期値設定
  if (field === 'viewflg' && e.target.checked && props.hasExtend) {
    row.keisyoflg = true
  }

  editJudge.setEdited()
}
//全選チェック(「全て」)
function changeAllCheck(e, row) {
  row.allflg = e.target.checked
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
  return tableData.value.filter((item) => item.viewflg)
}

defineExpose({ submit })
</script>
