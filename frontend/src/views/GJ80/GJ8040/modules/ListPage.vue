<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>（GJ8040）使用者一覧</h1>
      <div class="mt-1 flex">
        <a-space>
          <a-button type="primary" @click="forwardNew">新規</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card :bordered="false" class="sm:flex-1-hidden" ref="cardRef">
      <vxe-table
        class="h-full"
        :column-config="{ resizable: true }"
        :height="height - 30"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(row.USER_ID)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          field="USER_ID"
          title="ユーザーID"
          width="120"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.USER_ID)">{{ row.USER_ID }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="USER_NAME"
          title="ユーザ名"
          min-width="150"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.USER_ID)">{{ row.USER_NAME }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="SIYO_KBN"
          title="使用区分"
          width="120"
          sortable
          :params="{ order: 3 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="TEISI_DATE"
          title="使用停止日"
          min-width="150"
          sortable
          :params="{ order: 4 }"
          :resizable="true"
        ></vxe-column>
        <vxe-column
          field="TEISI_RIYU"
          title="使用停止理由"
          min-width="400"
          :resizable="false"
        ></vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { useElementSize } from '@vueuse/core'
import { reactive, ref, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { SearchRowVM } from '../type'
import { PageStatus } from '@/enum'
import { changeTableSort } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const cardRef = ref()
const { height } = useElementSize(cardRef)
const tableData = ref<SearchRowVM[]>([
  {
    USER_ID: 'gjs',
    USER_NAME: 'テスト管理者',
    SIYO_KBN: 10,
    TEISI_DATE: undefined,
    TEISI_RIYU: '',
  },
])

const router = useRouter()
const route = useRoute()
const pageParams = reactive({
  ORDER_BY: 0,
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function forwardEdit(USER_ID) {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.Edit,
      USER_ID: USER_ID,
    },
  })
}
function forwardNew() {
  router.push({
    name: route.name,
    query: {
      status: PageStatus.New,
    },
  })
}
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
  }
})
</script>
<style lang="scss" scoped></style>
