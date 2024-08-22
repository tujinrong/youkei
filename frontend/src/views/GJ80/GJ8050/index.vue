<template>
  <div>
    <div v-show="status === PageSatatus.List" class="h-full">
      <ListPage />
    </div>
    <div
      v-if="
        (status === PageSatatus.New || status === PageSatatus.Edit) &&
        editPage === 1
      "
      class="h-full"
    >
      <EditPage :status="status" />
    </div>
    <div
      v-if="
        (status === PageSatatus.New || status === PageSatatus.Edit) &&
        editPage === 2
      "
      class="h-full"
    >
      <EditPage2 :status="status" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '@/enum'
import ListPage from './modules/ListPage.vue'
import EditPage from './modules/EditPage.vue'
import EditPage2 from './modules/EditPage2.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

const status = ref(PageSatatus.List)
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
      status.value = route.query.status ? +route.query.status : PageSatatus.List
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
