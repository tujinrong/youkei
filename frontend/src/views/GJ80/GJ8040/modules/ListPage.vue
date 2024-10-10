<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card
      ref="headRef"
      :bordered="false"
      class="staticWidth"
      :body-style="{ backgroundColor: 'aliceblue' }"
    >
      <h1>（GJ8040）使用者一覧</h1>
      <div class="mt-1 flex">
        <a-space :size="20">
          <a-button type="primary" @click="goForward(PageStatus.New)"
            >新規登録</a-button
          >
        </a-space>
        <EndButton />
      </div>
    </a-card>
    <a-card
      :bordered="false"
      class="flex-1 staticWidth"
      ref="cardRef"
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
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        height="650px"
        :sort-config="{ trigger: 'cell', orders: ['asc', 'desc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => goForward(PageStatus.Edit, row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          header-align="center"
          field="USER_ID"
          title="ユーザーID"
          width="120"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="goForward(PageStatus.Edit, row)">{{ row.USER_ID }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          field="USER_NAME"
          title="ユーザ名"
          min-width="140"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="goForward(PageStatus.Edit, row)">{{ row.USER_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          header-align="center"
          align="center"
          field="SIYO_KBN_NAME"
          title="使用区分"
          width="120"
          sortable
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          header-align="center"
          field="TEISI_DATE"
          title="使用停止日"
          min-width="150"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        >
          <template #default="{ row }">
            {{ row.TEISI_DATE ? getDateJpText(new Date(row.TEISI_DATE)) : '' }}
          </template></vxe-column
        >
        <vxe-column
          header-align="center"
          field="TEISI_RIYU"
          title="使用停止理由"
          sortable
          :params="{ order: 5 }"
          min-width="400"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
  <EditPage
    v-model:visible="editVisible"
    :editkbn="editkbn"
    :user-data="userData"
    @getTableData="handleSearch"
  />
</template>

<script setup lang="ts">
import { useElementSize } from '@vueuse/core'
import { onMounted, reactive, ref, toRef, watch } from 'vue'
import { SearchRowVM } from '../type'
import { EnumEditKbn, PageStatus } from '@/enum'
import { changeTableSort, getDateJpText } from '@/utils/util'
import EditPage from './EditPage.vue'
import { Search } from '../service'
import { VxeTableInstance } from 'vxe-pc-ui'
import useSearch from '@/hooks/useSearch'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const cardRef = ref()
const { height } = useElementSize(cardRef)
const tableData = ref<SearchRowVM[]>([])
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)

const userData = ref<SearchRowVM>()
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

function goForward(status: PageStatus, row?: any) {
  editVisible.value = true
  if (status === PageStatus.Edit) {
    editkbn.value = EnumEditKbn.Edit
    userData.value = row
  } else {
    editkbn.value = EnumEditKbn.Add
  }
}
</script>
<style lang="scss" scoped></style>
