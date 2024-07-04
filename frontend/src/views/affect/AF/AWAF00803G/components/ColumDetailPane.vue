<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理(詳細画面：項目値変更情報)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="self_adaption_table form mb-2 ml-[1px]">
    <a-row>
      <a-col :sm="8" :xxl="5">
        <th class="w-26">変更テーブル</th>
        <td>
          <ai-select
            v-model:value="searchParams.table"
            :options="options"
            @change="onChangeOpt"
          ></ai-select>
        </td>
      </a-col>
      <a-col :sm="8" :xxl="5">
        <th class="w-26">変更項目</th>
        <td>
          <ai-select
            v-model:value="searchParams.item"
            :options="keyoptions"
            @change="onChangeKeyOpt"
          ></ai-select>
        </td>
      </a-col>
      <a-col :sm="8" :xxl="5">
        <th class="w-26">変更区分</th>
        <td>
          <ai-select v-model:value="searchParams.henkokbn" :options="options3"></ai-select>
        </td>
      </a-col>
    </a-row>
  </div>
  <div class="flex justify-between mb-2">
    <a-button type="primary" @click="searchData">検索</a-button>
    <a-pagination
      v-model:current="pageParams.pagenum"
      v-model:page-size="pageParams.pagesize"
      :total="totalCount"
      :page-size-options="$pagesizes"
      show-less-items
      show-size-changer
    />
  </div>
  <vxe-table
    :height="tableHeight"
    :loading="loading"
    :column-config="{ resizable: true }"
    :row-config="{ isCurrent: true, isHover: true }"
    :data="tableList"
    :sort-config="{
      trigger: 'cell',
      remote: true
    }"
    :empty-render="{ name: 'NotData' }"
    @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
  >
    <vxe-column
      v-for="(item, index) in column"
      :key="item.field"
      v-bind="item"
      :params="{ order: index + 1 }"
      sortable
    >
      <template #default="{ row }">
        <span>{{ row[item.field] }}</span>
      </template>
    </vxe-column>
  </vxe-table>
</template>

<script setup lang="ts">
import { ref, reactive, toRef, onMounted, watch, computed } from 'vue'
import { useRoute } from 'vue-router'
import { VxeColumnProps } from 'vxe-table'
import { useLinkOption } from '@/utils/hooks'
import { changeTableSort } from '@/utils/util'
import { InitColumDetail, SearchColumnDetail } from '../service'
import { ColumnRowVM, SearchColumnDetailRequest } from '../type'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  outHeight: number
  column: VxeColumnProps
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
//ページ データ
const tableList = ref<ColumnRowVM[]>([])
const totalCount = ref(0)
const searchParams = reactive<Pick<SearchColumnDetailRequest, 'table' | 'item' | 'henkokbn'>>({
  table: undefined,
  item: undefined,
  henkokbn: undefined
})
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const options1 = ref<DaSelectorModel[]>([]) //変更テーブル
const options2 = ref<DaSelectorKeyModel[]>([]) //変更項目
const options3 = ref<DaSelectorModel[]>([]) //変更区分
//Options連動
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(options2, options1)

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(async () => {
  const res = await InitColumDetail({ sessionseq: Number(route.query.sessionseq) })
  options1.value = res.selectorlist1
  options2.value = res.selectorlist2
  options3.value = res.selectorlist3

  searchData()
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (tableList.value.length > 0 || totalCount.value > 0) searchData()
})
watch(
  () => searchParams.table,
  () => {
    searchParams.item = undefined
    searchParams.henkokbn = undefined
  }
)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const tableHeight = computed(() => props.outHeight - 155)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await SearchColumnDetail({
      ...pageParams,
      ...searchParams,
      sessionseq: Number(route.query.sessionseq)
    })
    tableList.value = res.kekkalist
    totalCount.value = res.totalrowcount
  } catch (error) {}
  loading.value = false
}
</script>

<style lang="less" scoped></style>
