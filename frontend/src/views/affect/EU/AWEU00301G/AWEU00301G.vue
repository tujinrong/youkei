<template>
  <div v-show="status == PageSatatus.List">
    <data-list />
  </div>
  <div v-if="status == PageSatatus.Detail">
    <data-detail />
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import DataList from './components/DataList.vue'
import DataDetail from './components/DataDetail/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWEU00301G') {
      status.value = route.query.rptid ? PageSatatus.Detail : PageSatatus.List
    }
  }
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.rptid) {
    status.value = PageSatatus.Detail
  }
})
</script>
