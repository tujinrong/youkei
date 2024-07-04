<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 拡張事業・その他予約日程事業・保健指導事業
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card>
      <h3 class="font-bold">その他予約日程事業・保健指導事業</h3>
      <div class="flex justify-between mt-2 mb-4">
        <a-button type="warn" :disabled="!canSave" @click="saveData">登録</a-button>
        <close-page />
      </div>
      <a-space class="mb-2">
        <a-button class="btn-round" type="primary" :disabled="!canCreate" @click="addRow()"
          >行追加</a-button
        >
        <a-button class="btn-round" type="primary" :disabled="!canDelete" @click="deleteRow"
          >行削除</a-button
        >
      </a-space>
      <vxe-table
        ref="xTableRef"
        :data="tableData"
        :height="Math.max(tableHeight, 400)"
        :column-config="{ resizable: true }"
        :header-cell-class-name="canSave ? 'bg-editable' : 'bg-readonly'"
        :mouse-config="{ selected: true }"
        :edit-rules="rules"
        :row-config="{ isCurrent: true, height: 48 }"
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
        beforeEditMethod({row,column}) {
          if(disabledRowShidoukbn(row) && ['homonriyoflg','sodanriyoflg','syudanriyoflg'].includes(column.field)){
            return false
          }
          if(column.field === 'jigyocd' && row.upddttm){
            return false
          }
          return canEdit as unknown as boolean
        }
      }"
        :valid-config="{ showMessage: false }"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column
          field="jigyocd"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          :class-name="
            ({ row }) => (hasRepeated(row.jigyocd, 'jigyocd') || !row.jigyocd ? 'bg-errorcell' : '')
          "
          min-width="100"
        >
          <template #header>コード<span v-show="canSave" class="request-mark">＊</span></template>
          <template #edit="{ row }">
            <a-input
              v-model:value="row.jigyocd"
              :maxlength="5"
              placeholder="頭1、2 桁が「21」固定"
              @change="row.jigyocd = handleInputJigyocd(row.jigyocd)"
              @blur="row.jigyocd = handleBlurJigyocd(row.jigyocd)"
            ></a-input>
          </template>
        </vxe-column>
        <vxe-column
          field="jigyonm"
          :edit-render="{ autofocus: '.ant-input', autoselect: true }"
          min-width="200"
          :class-name="({ row }) => (!row.jigyonm ? 'bg-errorcell' : '')"
        >
          <template #header>
            その他予約日程事業・保健指導事業名<span v-show="canSave" class="request-mark">＊</span>
          </template>
          <template #edit="{ row }">
            <a-textarea
              v-model:value="row.jigyonm"
              :maxlength="100"
              :auto-size="{ minRows: 1 }"
              type="text"
            ></a-textarea>
          </template>
        </vxe-column>
        <vxe-column
          field="stopflg"
          title="使用停止"
          :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
          align="center"
        >
          <template #edit="{ row }">
            <a-checkbox v-model:checked="row.stopflg"></a-checkbox>
          </template>
          <template #default="{ row }">
            <a-checkbox :checked="row.stopflg" :disabled="!canEdit" />
          </template>
        </vxe-column>
        <vxe-column
          field="gyomukbncdnm"
          :edit-render="{ autofocus: '.ant-select-selection-search-input', autoselect: true }"
          :class-name="({ row }) => (!row.gyomukbncdnm ? 'bg-errorcell' : '')"
          min-width="120"
        >
          <template #header>業務<span v-show="canSave" class="request-mark">＊</span></template>
          <template #edit="{ row }">
            <ai-select v-model:value="row.gyomukbncdnm" :options="selectorlist"></ai-select>
          </template>
        </vxe-column>
        <vxe-column
          field="yoyakuriyoflg"
          title="予約"
          :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
          align="center"
        >
          <template #edit="{ row }">
            <a-checkbox v-model:checked="row.yoyakuriyoflg"></a-checkbox>
          </template>
          <template #default="{ row }">
            <a-checkbox :checked="row.yoyakuriyoflg" :disabled="!canEdit" />
          </template>
        </vxe-column>
        <vxe-colgroup title="保健指導 指導区分" align="center">
          <vxe-column
            field="homonriyoflg"
            title="訪問"
            :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
            :class-name="({ row }) => (disabledRowShidoukbn(row) ? 'bg-disabled' : '')"
            align="center"
          >
            <template #edit="{ row }">
              <a-checkbox v-model:checked="row.homonriyoflg"></a-checkbox>
            </template>
            <template #default="{ row }">
              <a-checkbox
                :checked="row.homonriyoflg"
                :disabled="disabledRowShidoukbn(row) || !canEdit"
              />
            </template>
          </vxe-column>
          <vxe-column
            field="sodanriyoflg"
            title="相談"
            :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
            :class-name="({ row }) => (disabledRowShidoukbn(row) ? 'bg-disabled' : '')"
            align="center"
          >
            <template #edit="{ row }">
              <a-checkbox v-model:checked="row.sodanriyoflg"></a-checkbox>
            </template>
            <template #default="{ row }">
              <a-checkbox
                :checked="row.sodanriyoflg"
                :disabled="disabledRowShidoukbn(row) || !canEdit"
              />
            </template>
          </vxe-column>
          <vxe-column
            field="syudanriyoflg"
            title="集団"
            :edit-render="{ autofocus: '.ant-checkbox-input', autoselect: true }"
            :resizable="false"
            :class-name="({ row }) => (disabledRowShidoukbn(row) ? 'bg-disabled' : '')"
            align="center"
          >
            <template #edit="{ row }">
              <a-checkbox v-model:checked="row.syudanriyoflg"></a-checkbox>
            </template>
            <template #default="{ row }">
              <a-checkbox
                :checked="row.syudanriyoflg"
                :disabled="disabledRowShidoukbn(row) || !canEdit"
              />
            </template>
          </vxe-column>
        </vxe-colgroup>
      </vxe-table>
    </a-card>
  </a-spin>
</template>

<script setup lang="ts">
import { computed, nextTick, onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { YoyakuSidoJigyoRowVM } from '../type'
import { InitYoyakuSidoJigyoList, SaveYoyakuSidoJigyoList } from '../service'
import { useTableHeight, useTable } from '@/utils/hooks'
import { showSaveModal } from '@/utils/modal'
import { message } from 'ant-design-vue'
import { SAVE_OK_INFO } from '@/constants/msg'
import { editStore1 } from '@/store'
import { Enum拡張予約指導業務区分 } from '#/Enums'

const emit = defineEmits(['update:data', 'change'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const { editJudge } = editStore1

const tableData = ref<YoyakuSidoJigyoRowVM[]>([])
const selectorlist = ref<DaSelectorModel[]>([])
let locklist
//項目の設定
const rules = ref({
  jigyocd: [
    { required: true },
    {
      validator({ cellValue }) {
        if (hasRepeated(cellValue, 'jigyocd')) {
          return new Error()
        }
        return
      }
    }
  ],
  jigyonm: [{ required: true }],
  gyomukbncdnm: [{ required: true }]
})

const xTableRef = ref<VxeTableInstance>()
const { hasRepeated, deleteRow, addRow, currentRow, getTableData } = useTable(
  xTableRef,
  'jigyocd',
  'syudanriyoflg',
  {
    stopflg: false,
    yoyakuriyoflg: false,
    homonriyoflg: false,
    sodanriyoflg: false,
    syudanriyoflg: false,
    editflg: true
  }
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchData()
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(tableData, () => editJudge.setEdited(), { deep: true })
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(null, -75)
//行編集フラグ取得
const canEdit = computed(() => {
  //更新権限がある場合、編集可能
  if (route.meta.updflg) return true
  //更新権限がない場合、新規データのみ編集可能
  return Boolean(currentRow.value && !currentRow.value.upddttm)
})
//行削除フラグ取得
const canDelete = computed(() => {
  //削除権限がある場合、行削除可能
  if (route.meta.delflg) return Boolean(currentRow.value?.editflg)
  //削除権限がない場合、新規データのみ削除可能
  return Boolean(currentRow.value && !currentRow.value.upddttm)
})
//行追加フラグ取得
const canCreate = route.meta.addflg
//登録フラグ取得
const canSave = route.meta.addflg || route.meta.updflg || route.meta.delflg
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitYoyakuSidoJigyoList()
    tableData.value = res.kekkalist
    selectorlist.value = res.selectorlist
    locklist = tableData.value.map((el) => ({
      jigyocd: el.jigyocd,
      upddttm: el.upddttm
    }))
  } catch (error) {}
  loading.value = false
  nextTick(() => editJudge.reset())
}

//保存処理
async function saveData() {
  tableData.value = getTableData()
  const errMap = await xTableRef.value?.validate(true)
  if (errMap) return Promise.reject()

  showSaveModal({
    onOk: async () => {
      try {
        await SaveYoyakuSidoJigyoList({
          kekkalist: tableData.value,
          locklist
        })
        message.success(SAVE_OK_INFO.Msg)
        searchData()
      } catch (error) {}
    }
  })
}

//頭1、2 桁が「21」固定
function handleInputJigyocd(inputValue) {
  let str = inputValue.replace(/\D/g, '')
  if (str) {
    if (str === '2') str = '21'
    if (!str.startsWith('21')) {
      str = ('21' + str).slice(0, 5)
    }
  }
  return str
}
function handleBlurJigyocd(str = '') {
  if (str && str.length < 5) {
    str = '21' + '0'.repeat(5 - str.length) + str.slice(2, str.length)
  }
  return str
}

function disabledRowShidoukbn(row) {
  return +row.gyomukbncdnm?.split(' : ')[0] === Enum拡張予約指導業務区分.予防接種
}
</script>

<style lang="less" scoped>
:deep(.vxe-header--column .vxe-cell--required-icon) {
  display: none;
}
</style>
