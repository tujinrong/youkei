<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 世帯検索
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="modalVisible"
    width="1300px"
    title="世帯検索"
    destroy-on-close
    :mask-closable="false"
    centered
    @ok="onOk"
  >
    <div class="self_adaption_table form mb-2">
      <a-row>
        <a-col span="8">
          <th>世帯主カナ氏名</th>
          <td>
            <a-input v-model:value="searchParams.kname" />
          </td>
        </a-col>
        <a-col span="8">
          <th>氏名</th>
          <td class="mincho">
            <a-input v-model:value="searchParams.name" />
          </td>
        </a-col>
        <a-col span="8">
          <th>世帯郵便番号</th>
          <td>
            <PostCode v-model:value="searchParams.adrs_yubin"></PostCode>
          </td>
        </a-col>
        <a-col span="24">
          <th>世帯住所</th>
          <td>
            <a-input v-model:value="searchParams.adrs" />
          </td>
        </a-col>
      </a-row>
    </div>
    <a-space>
      <a-button type="primary" @click="searchData">検索</a-button>
      <a-button type="primary" @click="reset">クリア</a-button>
    </a-space>

    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
      class="text-end mb-2"
    />
    <vxe-table
      height="500"
      :loading="loading"
      :column-config="{ resizable: true }"
      :row-config="{ isCurrent: true, isHover: true }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
      :sort-config="{ trigger: 'cell', remote: true }"
      @current-change="clickRow"
      @cell-dblclick="onDbclickCell"
      @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
    >
      <vxe-column field="setaino" title="世帯番号" sortable :params="{ order: 1 }"></vxe-column>
      <vxe-column field="atenano" title="宛名番号" sortable :params="{ order: 2 }"></vxe-column>
      <vxe-column field="name" title="氏名" sortable :params="{ order: 3 }"></vxe-column>
      <vxe-column field="sex" title="性別" sortable :params="{ order: 4 }"></vxe-column>
      <vxe-column field="juminkbn" title="住民区分" sortable :params="{ order: 5 }"></vxe-column>
      <vxe-column field="bymd" title="生年月日" sortable :params="{ order: 6 }"></vxe-column>
      <vxe-column
        field="adrs_yubin"
        title="郵便番号"
        sortable
        :params="{ order: 7 }"
        formatter="yubin"
      ></vxe-column>
      <vxe-column field="adrs" title="住所" sortable :params="{ order: 8 }"></vxe-column>
    </vxe-table>
    <template #footer>
      <div style="float: left">
        <a-button type="primary" :disabled="!selectedRow" @click="onOk">選択</a-button>
      </div>
      <a-button type="primary" @click="modalVisible = false">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script lang="ts" setup>
import { computed, watch, ref, reactive, toRef } from 'vue'
import PostCode from '@/components/Selector/PostCode/index.vue'
import { Search } from './service'
import { SearchVM } from './type'
import { useSearch } from '@/utils/hooks'
import { changeTableSort } from '@/utils/util'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  visible: boolean
}>()
const emit = defineEmits(['update:visible', 'select'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const createDefaultParams = () => {
  return {
    kname: '',
    name: '',
    adrs_yubin: '',
    adrs: ''
  }
}
const searchParams = reactive(createDefaultParams())

const tableData = ref<SearchVM[]>([])
const selectedRow = ref<SearchVM | null>(null)

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => ({
    ...searchParams,
    adrs_yubin: searchParams.adrs_yubin.replace('-', '')
  }))
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
  (val) => {
    selectedRow.value = null
    tableData.value = []
    pageParams.pagenum = 1
  }
)

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//行選択(行をクリック)
function clickRow({ row }) {
  selectedRow.value = row
}
//行をダブルクリック
function onDbclickCell({ row }) {
  selectedRow.value = row
  onOk()
}
//選択ボタン
const onOk = () => {
  modalVisible.value = false
  emit('select', selectedRow.value)
}

//クリア
const reset = () => {
  Object.assign(searchParams, createDefaultParams())
  selectedRow.value = null
  clear()
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
</style>
