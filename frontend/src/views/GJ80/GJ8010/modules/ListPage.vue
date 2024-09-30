<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px staticWidth">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
      <h1>（GJ8010）コード一覧</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col
            v-bind="{
              md: 24,
              lg: 16,
              xl: 12,
              xxl: 8,
            }"
          >
            <th class="required">種類区分</th>
            <td>
              <ai-select
                v-model:value="searchParams.SYURUI_KBN"
                :options="SYURUI_KBN_LIST"
                split-val
                class="w-full!"
                @change="changeKbn"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex">
        <a-space :size="20">
          <a-button
            type="primary"
            :disabled="!searchParams.SYURUI_KBN"
            @click="goForward(PageStatus.New)"
            >新規登録</a-button
          >
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" class="flex-1 staticWidth" ref="cardRef">
      <vxe-table
        class="mt-2"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        min-height="600px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goForward(PageStatus.Edit, row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="MEISYO_CD"
          title="名称コード"
          width="120"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="goForward(PageStatus.Edit, row)">{{ row.MEISYO_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="MEISYO"
          title="名称"
          min-width="300"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="goForward(PageStatus.Edit, row)">{{ row.MEISYO }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="RYAKUSYO"
          title="略称"
          width="200"
          sortable
          :params="{ order: 3 }"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage v-model:visible="editVisible" :editkbn="editkbn" />
</template>
<script setup lang="ts">
import { ref, reactive, toRef, watch, onMounted, computed } from 'vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { changeTableSort, convertToFullWidth } from '@/utils/util'
import { useElementSize } from '@vueuse/core'
import { SearchRequest, SearchRowVM } from '../type'
import { Init, Search } from '../service'
import EditPage from './EditPage.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const createDefaultParams = (): SearchRequest => {
  return {
    SYURUI_KBN: undefined,
  } as SearchRequest
}
const SYURUI_KBN_LIST = ref<CmCodeNameModel[]>([
  { CODE: '1', NAME: '契約者区分' },
])
const searchParams = reactive(createDefaultParams())
const cardRef = ref()
const { height } = useElementSize(cardRef)
const tableData = ref<SearchRowVM[]>([])
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => editVisible.value,
  (newValue) => {
    // if (!newValue) searchData()
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//初期化処理
onMounted(() => {
  // getInitData()
})

const getInitData = () => {
  Init().then((res) => {
    SYURUI_KBN_LIST.value = res.SYURUI_KBN_LIST
  })
}

const changeKbn = () => {
  // searchData()
  tableData.value = [
    {
      MEISYO_CD: 1,
      MEISYO: '家族',
      RYAKUSYO: '家',
    },
  ]
}
//検索処理
const { pageParams, searchData } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
})

function goForward(status: PageStatus, row?: any) {
  if (status === PageStatus.Edit || status === PageStatus.New) {
    editVisible.value = true
    editkbn.value =
      status === PageStatus.Edit ? EnumEditKbn.Edit : EnumEditKbn.Add
  }
}
</script>
<style lang="scss" scoped>
th {
  width: 120px;
}
</style>
