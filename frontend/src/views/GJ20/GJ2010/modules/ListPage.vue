<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card
      ref="headRef"
      :bordered="false"
      class="staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <h1>（GJ2010）契約者積立金・互助金単価マスタ一覧</h1>
      <div class="mt-1 flex">
        <a-space :size="20">
          <a-button type="primary" @click="forwardEdit(PageStatus.New)"
            >新規登録</a-button
          >
        </a-space>
        <EndButton />
      </div>
    </a-card>
    <a-card
      :bordered="false"
      class="flex-1 staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <a-pagination
        v-model:current="pageParams.PAGE_NUM"
        v-model:page-size="pageParams.PAGE_SIZE"
        :total="totalCount"
        :page-size-options="['10', '25', '50', '100']"
        :show-total="(total) => `抽出件数： ${total} 件`"
        show-less-items
        show-size-changer
        class="m-b-1 text-end"
      />
      <vxe-table
        ref="xTableRef"
        class="h-full"
        align="center"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        height="650px"
        :sort-config="{ trigger: 'cell', orders: ['asc', 'desc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(PageStatus.Edit, row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          field="VALUE_FM"
          title="年月日(自)"
          width="160"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(PageStatus.Edit, row)">{{
              row.VALUE_FM ? getDateJpText(new Date(row.VALUE_FM)) : ''
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="VALUE_TO"
          title="年月日(至)"
          width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(PageStatus.Edit, row)">{{
              row.VALUE_TO ? getDateJpText(new Date(row.VALUE_TO)) : ''
            }}</a>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage v-model:visible="editVisible" :editkbn="editkbn" />
</template>
<script setup lang="ts">
import { useElementSize } from '@vueuse/core'
import { onMounted, reactive, ref, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { EnumEditKbn, PageStatus } from '@/enum'
import { changeTableSort, getDateJpText } from '@/utils/util'
import EditPage from './EditPage.vue'
import useSearch from '@/hooks/useSearch'
import { Search } from '../service'
import { VxeTableInstance } from 'vxe-pc-ui'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const cardRef = ref()
const { height } = useElementSize(cardRef)

const router = useRouter()
const route = useRoute()

const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)
const tableData = ref<CmDateFmToModel[]>([])
const xTableRef = ref<VxeTableInstance>()

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

onMounted(async () => {
  await handleSearch()
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: tableData,
  params: null,
})

const handleSearch = async () => {
  tableData.value = []
  const res = await searchData()
  if (xTableRef.value && tableData.value.length > 0) {
    xTableRef.value.setCurrentRow(tableData.value[0])
  }
}

function forwardEdit(status: PageStatus, row?: any) {
  if (status === PageStatus.Edit || status === PageStatus.New) {
    editVisible.value = true
    editkbn.value =
      status === PageStatus.Edit ? EnumEditKbn.Edit : EnumEditKbn.Add
    return
  }
}
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
  }
})
</script>
<style lang="scss" scoped></style>
