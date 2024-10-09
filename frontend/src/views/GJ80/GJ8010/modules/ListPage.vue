<template>
  <div class="h-full min-h-450px flex-col-stretch gap-12px staticWidth">
    <div>
      <a-card
        ref="headRef"
        :bordered="false"
        class="staticWidth"
        :body-style="{ backgroundColor: 'aliceblue' }"
      >
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
          <CloseButton />
        </div>
        <vxe-table
          ref="xTableRef"
          class="mt-2"
          :column-config="{ resizable: true }"
          :row-config="{
            isCurrent: true,
            isHover: true,
          }"
          :data="tableData"
          height="680px"
          :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
          :empty-render="{ name: 'NotData' }"
          @cell-dblclick="({ row }) => goForward(PageStatus.Edit, row)"
          @sort-change="
            (e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))
          "
        >
          <vxe-column
            header-align="center"
            align="right"
            field="MEISYO_CD"
            title="名称コード"
            width="120"
            sortable
            :params="{ order: 1 }"
            :resizable="true"
          >
            <template #default="{ row }">
              <a @click="goForward(PageStatus.Edit, row)">{{
                row.MEISYO_CD
              }}</a>
            </template>
          </vxe-column>
          <vxe-column
            header-align="center"
            align="left"
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
            align="left"
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
  </div>
  <EditPage
    v-model:visible="editVisible"
    :editkbn="editkbn"
    :SYURUI_KBN="searchParams.SYURUI_KBN"
    :SYURUI_NM="SYURUI_NM"
    :MEISYO_CD="meisyocd"
    @get-table-list="searchData"
  />
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
import { VxeTableInstance } from 'vxe-pc-ui'
import { showInfoModal } from '@/utils/modal'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const createDefaultParams = (): SearchRequest => {
  return {
    SYURUI_KBN: undefined,
  } as SearchRequest
}
const SYURUI_KBN_LIST = ref<CmCodeNameModel[]>([])
const searchParams = reactive(createDefaultParams())
const xTableRef = ref<VxeTableInstance>()
const tableData = ref<SearchRowVM[]>([])
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const meisyocd = ref()
const SYURUI_NM = ref()
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//初期化処理
onMounted(() => {
  getInitData()
})

const getInitData = () => {
  Init({ ...searchParams }).then((res) => {
    SYURUI_KBN_LIST.value = res.SYURUI_KBN_LIST
  })
}

const changeKbn = () => {
  searchData()
}
//検索処理
const { pageParams, searchData } = useSearch({
  service: Search,
  source: tableData,
  params: toRef(() => searchParams),
  tableRef: xTableRef,
})

function goForward(status: PageStatus, row?: SearchRowVM) {
  if (status === PageStatus.Edit || status === PageStatus.New) {
    if (status === PageStatus.Edit && !row) {
      showInfoModal({
        content: 'データが選択されていません。',
      })
      return
    }
    editkbn.value =
      status === PageStatus.Edit ? EnumEditKbn.Edit : EnumEditKbn.Add
    meisyocd.value = row?.MEISYO_CD || 0
    SYURUI_NM.value = SYURUI_KBN_LIST.value.find(
      (e) => e.CODE == searchParams.SYURUI_KBN
    )?.NAME

    editVisible.value = true
  }
}
</script>
<style lang="scss" scoped>
th {
  width: 120px;
}
</style>
