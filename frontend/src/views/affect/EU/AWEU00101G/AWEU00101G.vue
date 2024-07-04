<template>
  <div v-show="status == PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status == PageSatatus.Edit">
    <EditPage />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'

import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.datasourceid) {
    status.value = PageSatatus.Edit
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWEU00101G') {
      status.value = route.query.datasourceid ? PageSatatus.Edit : PageSatatus.List
    }
  },
  { deep: true }
)
</script>
