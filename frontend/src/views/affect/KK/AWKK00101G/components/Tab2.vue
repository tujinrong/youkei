<template>
  <a-spin :spinning="loading">
    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">個人住民税課税情報</div>
      <a-space>
        <SimplePagination :current="current1" :count="count1" @change="changeCurrent1" />
        <a-button type="primary" @click="visible1 = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table">
        <Column :rows="row_kazei" :data="data1" />
      </div>
    </div>

    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">納税義務者情報</div>
      <a-space>
        <SimplePagination :current="current2" :count="count2" @change="changeCurrent2" />
        <a-button type="primary" @click="visible2 = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table">
        <Column :rows="row_nozei" :data="data2" />
      </div>
    </div>

    <ResumeModal
      v-model:visible="visible1"
      title="個人住民税課税情報履歷"
      :columns="columns_103"
      service="AWKK00103D"
      @select="selectRow1"
    />
    <ResumeModal
      v-model:visible="visible2"
      title="納税義務者情報履歷"
      :columns="columns_104"
      service="AWKK00104D"
      @select="selectRow2"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import Column from './Column.vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import ResumeModal from '@/views/components/ResumeModal/index.vue'
import { columns as columns_103 } from '@/views/affect/KK/AWKK00103D/content'
import { columns as columns_104 } from '@/views/affect/KK/AWKK00104D/content'
import { SearchKaZeiDetail, SearchNoZeiDetail } from '../service'
import { useRoute } from 'vue-router'
import { KazeiVM, NozeiVM } from '../type'
import { row_kazei, row_nozei } from '../content'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const visible1 = ref(false)
const visible2 = ref(false)
const data1 = ref<KazeiVM | null>(null)
const data2 = ref<NozeiVM | null>(null)
const count1 = ref(0)
const count2 = ref(0)
const current1 = ref(0)
const current2 = ref(0)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  loading.value = true
  Promise.all([searchKaZeiDetail(1), searchNoZeiDetail(1)]).finally(() => {
    loading.value = false
  })
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const searchKaZeiDetail = async (rirekinum: number) => {
  try {
    const res = await SearchKaZeiDetail({
      rirekinum,
      atenano: route.query.atenano as string
    })
    data1.value = res.detailinfo
    count1.value = res.rirekitotal
    current1.value = res.rirekinum
  } catch (error) {}
}
const searchNoZeiDetail = async (rirekinum: number) => {
  try {
    const res = await SearchNoZeiDetail({
      rirekinum,
      atenano: route.query.atenano as string
    })
    data2.value = res.detailinfo
    count2.value = res.rirekitotal
    current2.value = res.rirekinum
  } catch (error) {}
}
function changeCurrent1(val) {
  current1.value = val
  loading.value = true
  searchKaZeiDetail(current1.value).finally(() => {
    loading.value = false
  })
}
function changeCurrent2(val) {
  current2.value = val
  loading.value = true
  searchNoZeiDetail(current2.value).finally(() => {
    loading.value = false
  })
}
function selectRow1(row) {
  changeCurrent1(row.rirekinum)
}
function selectRow2(row) {
  changeCurrent2(row.rirekinum)
}
</script>
