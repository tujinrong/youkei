<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px">
    <a-card ref="headRef" :bordered="false" class="staticWidth">
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
    <a-card :bordered="false" class="flex-1 staticWidth" ref="cardRef">
      <vxe-table
        class="h-full"
        align="center"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="tableData"
        height="650px"
        :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardEdit(PageStatus.Edit, row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))"
      >
        <vxe-column
          field="TAISYO_DATE_FROM"
          title="年月日(自)"
          width="160"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(PageStatus.Edit, row)">{{
              row.TAISYO_DATE_FROM
            }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="TAISYO_DATE_TO"
          title="年月日(至)"
          width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(PageStatus.Edit, row)">{{
              row.TAISYO_DATE_TO
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
import { reactive, ref, toRef } from 'vue'
import { onBeforeRouteUpdate, useRoute, useRouter } from 'vue-router'
import { DetailVM } from '../type'
import { EnumEditKbn, PageStatus } from '@/enum'
import { changeTableSort } from '@/utils/util'
import EditPage from './EditPage.vue'

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
const editVisible = ref(false)
const editkbn = ref<EnumEditKbn>(EnumEditKbn.Add)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
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
