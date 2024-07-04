<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">{{ title }}</div>
      <a-space>
        <SimplePagination :current="current" :count="count" @change="changeCurrent" />
        <a-button type="primary" @click="visible = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table">
        <Column :rows="detailRows" :data="data" />
      </div>
    </div>
    <ResumeModal
      v-model:visible="visible"
      :title="title + '履歷'"
      :columns="modalColumns"
      :service="service"
      @select="selectRow"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import Column from './Column.vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import ResumeModal from '@/views/components/ResumeModal/index.vue'
import { useRoute } from 'vue-router'
import {
  DataAndVM,
  DataOrVM,
  DetailRow,
  SearchCommonRequest,
  SearchDetailResponseBase
} from '../type'

interface SearchResponse extends SearchDetailResponseBase {
  detailinfo: DataOrVM
}

const props = defineProps<{
  title: string
  detailRows: DetailRow<DataAndVM>[]
  modalColumns: { title: string; field: string; width: string }[]
  service: string
  searchRequest: (params: SearchCommonRequest) => Promise<SearchResponse>
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const visible = ref(false)
const data = ref<DataOrVM | null>(null)

const count = ref(0)
const current = ref(0)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchDetail(1)
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const searchDetail = async (rirekinum: number) => {
  loading.value = true
  try {
    const res = await props.searchRequest({
      rirekinum,
      atenano: route.query.atenano as string
    })
    data.value = res.detailinfo
    count.value = res.rirekitotal
    current.value = res.rirekinum
  } catch (error) {}
  loading.value = false
}

function changeCurrent(val) {
  current.value = val
  searchDetail(current.value)
}

function selectRow(row) {
  changeCurrent(row.rirekinum)
}
</script>
