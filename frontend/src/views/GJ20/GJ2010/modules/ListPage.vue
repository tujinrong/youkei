<template>
  <div
    class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto"
  >
    <a-card ref="headRef" :bordered="false">
      <h1>(GJ2010)契約者積立金・互助金単価マスタ一覧</h1>
      <div class="mt-1 flex">
        <a-space :size="20">
          <a-button type="primary" @click="forwardEdit">新規登録</a-button>
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
          field="TAISYO_DATE_FROM"
          title="年月日(自)"
          min-width="80"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.TAISYO_DATE_FROM)">{{
              row.TAISYO_DATE_FROM
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="TAISYO_DATE_TO"
          title="年月日(至)"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.TAISYO_DATE_TO)">{{
              row.TAISYO_DATE_TO
            }}</a>
          </template>
        </vxe-column>
      </vxe-table>
    </a-card>
  </div>
</template>
<script setup lang="ts">
import { useElementSize } from '@vueuse/core'
import { reactive, ref, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { DetailVM } from '../type'
import { PageStatus } from '@/enum'
import { changeTableSort } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const cardRef = ref()
const { height } = useElementSize(cardRef)
const tableData = ref<DetailVM[]>([
  {
    TAISYO_DATE_FROM: '平成24/04/01',
    TAISYO_DATE_TO: '平成27/03/31',
    KEIYAKU_KBN: 0,
    TORI_KBN: 0,
    TUMITATE_TANKA: 0,
    KEIEISIEN_TANKA: 0,
    SYOKYAKU_TANKA: 0,
    TESURYO_RITU: 0,
    KOFU_RITU: 0,
  },
  {
    TAISYO_DATE_FROM: '平成27/04/01',
    TAISYO_DATE_TO: '平成30/03/31',
    KEIYAKU_KBN: 0,
    TORI_KBN: 0,
    TUMITATE_TANKA: 0,
    KEIEISIEN_TANKA: 0,
    SYOKYAKU_TANKA: 0,
    TESURYO_RITU: 0,
    KOFU_RITU: 0,
  },
  {
    TAISYO_DATE_FROM: '平成33/04/01',
    TAISYO_DATE_TO: '平成36/03/31',
    KEIYAKU_KBN: 0,
    TORI_KBN: 0,
    TUMITATE_TANKA: 0,
    KEIEISIEN_TANKA: 0,
    SYOKYAKU_TANKA: 0,
    TESURYO_RITU: 0,
    KOFU_RITU: 0,
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
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
  }
})
</script>
<style lang="scss" scoped></style>
