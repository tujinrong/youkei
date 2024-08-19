<template>
  <div>
    <div v-show="status === PageSatatus.List" class="h-full">
      <ListPage />
    </div>
    <div
      v-if="status === PageSatatus.New || status === PageSatatus.Edit"
      class="h-full"
    >
      <EditPage :status="status" />
    </div>
  </div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '@/enum'
import ListPage from './modules/ListPage.vue'
import EditPage from './modules/EditPage.vue'

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
    if (route.name === 'gj80_gj8100') {
      status.value = route.query.status ? +route.query.status : PageSatatus.List
    }
  },
  { deep: true }
)
</script>
<style lang="scss" scoped></style>
