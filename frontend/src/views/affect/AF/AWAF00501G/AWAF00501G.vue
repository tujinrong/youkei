<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status === PageSatatus.New || status === PageSatatus.Edit">
    <EditPage :status="status" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.status) {
    status.value = +route.query.status
  }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWAF00501G') {
      status.value = route.query.status ? +route.query.status : PageSatatus.List
    }
  },
  { deep: true }
)
</script>

<style lang="less" scoped></style>
