<template>
  <div class="h-full">
    <ListPage />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageStatus } from '@/enum'
import ListPage from './modules/ListPage.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

const status = ref(PageStatus.List)
const editPage = ref()

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.status) {
    status.value = +route.query.status
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'gj80_gj8050') {
      status.value = route.query.status ? +route.query.status : PageStatus.List
      editPage.value = route.query.editPage
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
</script>

<style lang="scss" scoped></style>
