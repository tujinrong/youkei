<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>(GJ8010)コード一覧</h1>
      <div class="self_adaption_table form mt-1">
        <a-row>
          <a-col :span="12">
            <th class="required">種類区分</th>
            <td>
              <ai-select
                v-model:value="searchParams.SYURUI_KBN"
                :options="SYURUI_KBN_LIST"
                split-val
                @change="changeKbn"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex">
        <a-space>
          <a-button
            type="primary"
            :disabled="!searchParams.SYURUI_KBN"
            @click="forwardNew"
            >新規</a-button
          >
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" class="sm:flex-1-hidden" ref="cardRef">
      <vxe-table
        class="mt-2"
        :column-config="{ resizable: true }"
        :height="height - 40"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.MEISYO_CD)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          field="MEISYO_CD"
          title="名称コード"
          width="120"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.MEISYO_CD)">{{ row.MEISYO_CD }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="MEISYO"
          title="名称"
          min-width="300"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.MEISYO_CD)">{{ row.MEISYO }}</a>
          </template>
        </vxe-column>
        <vxe-column
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
</template>
<script setup lang="ts">
import { ref, reactive, toRef, watch, onMounted, computed } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { PageStatus } from '@/enum'
import useSearch from '@/hooks/useSearch'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { changeTableSort, convertToFullWidth } from '@/utils/util'
import { useTabStore } from '@/store/modules/tab'
import { useElementSize } from '@vueuse/core'
import { SearchRequest, SearchRowVM } from '../type'
import { Init, Search } from '../service'
import { Form } from 'ant-design-vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
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

onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    searchData()
  }
})

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

function forwardNew() {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
      SYURUI_KBN: searchParams.SYURUI_KBN,
    },
  })
}
function forwardEdit(MEISYO_CD) {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
      SYURUI_KBN: searchParams.SYURUI_KBN,
      MEISYO_CD: MEISYO_CD,
    },
  })
}
</script>
<style lang="scss" scoped></style>
