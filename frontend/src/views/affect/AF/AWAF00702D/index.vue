<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 医療機関検索
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="医療機関検索"
    width="1000px"
    centered
    destroy-on-close
    class="vxe-table--ignore-clear"
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :sm="8">
            <th width="120px">医療機関名</th>
            <td>
              <a-input v-model:value="searchParams.kikannm" allow-clear />
            </td>
          </a-col>
          <a-col :span="8">
            <th width="120px">医療機関名カナ</th>
            <td>
              <a-input v-model:value="searchParams.kanakikannm" allow-clear />
            </td>
          </a-col>
          <a-col :span="8">
            <th width="140px">保険医療機関コード</th>
            <td>
              <a-input v-model:value="searchParams.hokenkikancd" allow-clear />
            </td>
          </a-col>
        </a-row>
      </div>
      <div>
        <div class="m-t-1 flex justify-between">
          <div class="flex gap-2">
            <a-button type="primary" @click="searchData">検索</a-button>
            <a-button type="primary" @click="reset">クリア</a-button>
          </div>
          <a-pagination
            v-model:current="pageParams.pagenum"
            v-model:page-size="pageParams.pagesize"
            :page-size-options="$pagesizes"
            :total="totalCount"
            show-less-items
            show-size-changer
            class="m-b-1 text-end"
          />
        </div>
        <vxe-table
          ref="xTableRef"
          height="450"
          :column-config="{ resizable: true }"
          :row-config="{ keyField: 'kikancd', isCurrent: true, isHover: true }"
          :data="tableData"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => selectItem(row)"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        >
          <vxe-column
            field="kikancd"
            :params="{ order: 1 }"
            title="医療機関コード"
            sortable
            width="16%"
          />
          <vxe-column
            field="hokenkikancd"
            :params="{ order: 2 }"
            title="保険医療機関コード"
            sortable
            width="18%"
          />
          <vxe-column
            field="kikannm"
            :params="{ order: 3 }"
            title="医療機関名"
            sortable
            width="22%"
          />
          <vxe-column
            field="kanakikannm"
            :params="{ order: 4 }"
            title="医療機関名カナ"
            sortable
            width="22%"
          />
          <vxe-column
            field="adrsfull"
            :params="{ order: 5 }"
            title="住所"
            sortable
            :resizable="false"
          />
        </vxe-table>
      </div>
    </a-spin>
    <template #footer>
      <div class="float-left">
        <a-button type="primary" :disabled="!selectedRow" @click="onOk">選択</a-button>
      </div>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { reactive, ref, watch, toRef, computed, watchEffect } from 'vue'
import { Search } from './service'
import { SearchRequest, SearchVM } from './type'
import { changeTableSort } from '@/utils/util'
import { VxeTableInstance } from 'vxe-table'
import { useRoute } from 'vue-router'
import { useSearch } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
  /**実施事業 */
  jigyocds?: string
  /**使用停止sql */
  hasStopFlg?: boolean
}>()
const emit = defineEmits<{
  (e: 'update:visible', visible: boolean): void
  (e: 'select', value: SearchVM): void
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

const createDefaultSearchModel = (): Omit<SearchRequest, keyof CmSearchRequestBase> => {
  return {
    patternno: route.query.patternno as string,
    kikannm: '',
    kanakikannm: '',
    hokenkikancd: '',
    hasStopFlg: Boolean(props.hasStopFlg)
  }
}
const searchParams = reactive(createDefaultSearchModel())
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchVM[]>([])
const selectedRow = ref<SearchVM | null>(null)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => ({ ...searchParams, jigyocds: props.jigyocds }))
})
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
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(
  () => props.visible,
  (val) => {
    if (val && tableData.value.length === 0) {
      searchData()
    }
  }
)
watchEffect(() => {
  selectedRow.value = xTableRef.value?.getCurrentRecord()
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//キー項目選択
const selectItem = (record: SearchVM) => {
  emit('select', record)
  closeModal()
}

//選択ボタン
const onOk = () => {
  if (selectedRow.value) {
    selectItem(selectedRow.value)
  }
}

//閉じるボタン(×を含む)
const closeModal = () => {
  modalVisible.value = false
}

//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultSearchModel())
  clear()
}
</script>
