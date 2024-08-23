<template>
  <div>
    <div v-show="status === PageStatus.List" class="h-full">
      <ListPage />
    </div>
    <div
      v-if="status === PageStatus.New || status === PageStatus.Edit"
      class="h-full"
    >
      <EditPage :status="status" />
    </div>
  </div>
</template>
<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageStatus } from '@/enum'
import ListPage from './modules/ListPage.vue'
import EditPage from './modules/EditPage.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageStatus.List)

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
    if (route.name === 'gj10_gj1040') {
      status.value = route.query.status ? +route.query.status : PageStatus.List
    }
  },
  { deep: true }
)
</script>
<style lang="scss" scoped></style>
