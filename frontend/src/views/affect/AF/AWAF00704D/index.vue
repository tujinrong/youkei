<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者検索
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.26
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    title="事業従事者検索"
    width="1000px"
    centered
    destroy-on-close
    class="vxe-table--ignore-clear"
  >
    <a-spin :spinning="loading">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :sm="7">
            <th width="120px">事業従事者氏名</th>
            <td>
              <a-input v-model:value="searchParams.staffsimei" allow-clear />
            </td>
          </a-col>
          <a-col :span="7">
            <th width="80px">職種</th>
            <td>
              <ai-select v-model:value="searchParams.syokusyu" :options="options1" />
            </td>
          </a-col>
          <a-col :span="6">
            <th width="80px">活動区分</th>
            <td>
              <ai-select v-model:value="searchParams.katudokbn" :options="options2" />
            </td>
          </a-col>
          <a-col :span="4" class="items-center justify-end">
            <a-button type="primary" @click="searchData">検索</a-button>
            <a-button type="primary" class="m-l-1" @click="reset">クリア</a-button>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2">
        <a-pagination
          v-model:current="pageParams.pagenum"
          v-model:page-size="pageParams.pagesize"
          :total="totalCount"
          :page-size-options="$pagesizes"
          show-less-items
          show-size-changer
          class="m-b-1 text-end"
        />
        <vxe-table
          ref="xTableRef"
          height="465"
          :column-config="{ resizable: true }"
          :row-config="{ keyField: 'staffid', isCurrent: true, isHover: true }"
          :data="tableData"
          :sort-config="{
            trigger: 'cell',
            remote: true
          }"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => selectItem(row)"
          @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
        >
          <vxe-column field="staffid" :params="{ order: 1 }" title="事業従事者ID" sortable>
          </vxe-column>
          <vxe-column field="staffsimei" :params="{ order: 2 }" title="事業従事者氏名" sortable>
          </vxe-column>
          <vxe-column
            field="kanastaffsimei"
            :params="{ order: 3 }"
            title="事業従事者カナ氏名"
            sortable
          >
          </vxe-column>
          <vxe-column field="syokusyunm" :params="{ order: 4 }" title="職種" sortable> </vxe-column>
          <vxe-column
            field="katudokbnnm"
            :params="{ order: 5 }"
            title="活動区分"
            sortable
          ></vxe-column>
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
import { changeTableSort } from '@/utils/util'
import { Init, Search } from './service'
import { useRoute } from 'vue-router'
import { SearchVM } from './type'
import { VxeTableInstance } from 'vxe-table'
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

const options1 = ref<DaSelectorModel[]>([])
const options2 = ref<DaSelectorModel[]>([])
const searchParams = reactive(createDefaultSearchModel())
function createDefaultSearchModel() {
  return {
    patternno: route.query.patternno as string,
    staffsimei: undefined,
    syokusyu: undefined,
    katudokbn: undefined,
    hasStopFlg: Boolean(props.hasStopFlg)
  }
}

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
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (val) => {
    if (val && tableData.value.length === 0) {
      searchData()
      const res = await Init()
      options1.value = res.selectorlist1
      options2.value = res.selectorlist2
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

const reset = () => {
  Object.assign(searchParams, createDefaultSearchModel())
  clear()
  xTableRef.value?.clearSort()
  xTableRef.value?.clearCurrentRow()
}

//閉じるボタン(×を含む)
const closeModal = () => {
  modalVisible.value = false
}
</script>
