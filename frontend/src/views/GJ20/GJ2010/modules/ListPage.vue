<template>
  <div class="h-full min-h-500px flex-col-stretch gap-12px overflow-hidden lt-sm:overflow-auto">
    <a-card ref="headRef" :bordered="false">
      <h1>(GJ2010)契約者積立金・互助金単価マスタ一覧</h1>
      <div class="mt-1 flex">
        <a-space>
          <a-button type="primary" @click="forwardEdit">新規</a-button>
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
          field="START_DATE"
          title="年月日(自)"
          min-width="80"
          sortable
          :params="{ order: 1 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.START_DATE)">{{ row.START_DATE }}</a>
          </template>
        </vxe-column>
        <vxe-column
          field="END_DATE"
          title="年月日(至)"
          min-width="160"
          sortable
          :params="{ order: 2 }"
          :resizable="true"
        >
          <template #default="{ row }">
            <a @click="forwardEdit(row.END_DATE)">{{ row.END_DATE }}</a>
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
import {DetailVM} from '../type'
import { PageStatus } from '@/enum'
import { changeTableSort } from '@/utils/util'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const cardRef = ref()
const { height } = useElementSize(cardRef)
const tableData = ref<DetailVM[]>([
  {
    START_DATE: '平成24/04/01',
    END_DATE: '平成27/03/31',
    KI: 0,
    JIGYO_NENDO: 0,
    JIGYO_SYURYO_NENDO: 0,
    ZENKI_TUMITATE_DATE: '',
    ZENKI_KOFU_DATE: '',
    HENKAN_KEISAN_DATE: 0,
    HENKAN_NINZU: '',
    HENKAN_GOKEI: '',
    HENKAN_RITU: '',
    TAISYO_NENDO: 0,
    NOFU_KIGEN: '',
    HASSEI_KAISU: 0,
    BIKO: 0,
  },
  {
    START_DATE: '平成27/04/01',
    END_DATE: '平成30/03/31',
    KI: 0,
    JIGYO_NENDO: 0,
    JIGYO_SYURYO_NENDO: 0,
    ZENKI_TUMITATE_DATE: '',
    ZENKI_KOFU_DATE: '',
    HENKAN_KEISAN_DATE: 0,
    HENKAN_NINZU: '',
    HENKAN_GOKEI: '',
    HENKAN_RITU: '',
    TAISYO_NENDO: 0,
    NOFU_KIGEN: '',
    HASSEI_KAISU: 0,
    BIKO: 0,
  },
  {
    START_DATE: '平成33/04/01',
    END_DATE: '平成36/03/31',
    KI: 0,
    JIGYO_NENDO: 0,
    JIGYO_SYURYO_NENDO: 0,
    ZENKI_TUMITATE_DATE: '',
    ZENKI_KOFU_DATE: '',
    HENKAN_KEISAN_DATE: 0,
    HENKAN_NINZU: '',
    HENKAN_GOKEI: '',
    HENKAN_RITU: '',
    TAISYO_NENDO: 0,
    NOFU_KIGEN: '',
    HASSEI_KAISU: 0,
    BIKO: 0,
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
