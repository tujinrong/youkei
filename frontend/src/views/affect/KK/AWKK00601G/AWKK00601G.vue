<template>
  <div v-show="status == PageSatatus.List">
    <data-list />
  </div>
  <div v-if="status == PageSatatus.Detail">
    <data-detail />
  </div>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//一括データ登録
//--------------------------------------------------------------------------
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import dataList from './components/DataList.vue'
import dataDetail from './components/DataDetail.vue'
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
// const stateType = ref()
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00601G') {
      status.value = route.query.status ? PageSatatus.Detail : PageSatatus.List
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query?.status == undefined) {
    status.value = PageSatatus.List
  } else if (route.query?.status == '1') {
    status.value = PageSatatus.Detail
  }
})
</script>
