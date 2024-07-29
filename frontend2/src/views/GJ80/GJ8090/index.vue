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
      <!-- <EditPage
        :status="status"
        :KI="KI"
        :KEIYAKUSYA_CD="KEIYAKUSYA_CD"
        :NOJO_CD="NOJO_CD"
      /> -->
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
// const props = defineProps<{
//   KI: number
//   KEIYAKUSYA_CD: string
//   NOJO_CD: string
// }>()
const status = ref(PageSatatus.List)
// const KI = ref(props.KI)
// const KEIYAKUSYA_CD = ref(props.KEIYAKUSYA_CD)
// const NOJO_CD = ref(props.NOJO_CD)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.status) {
    status.value = +route.query.status
    // KI.value = route.query.KI
    // KEIYAKUSYA_CD.value = route.query.KEIYAKUSYA_CD
    // NOJO_CD.value = route.query.NOJO_CD
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
    console.log('route.name: ', route.name)
    if (route.name === 'gj80_gj8090') {
      status.value = route.query.status ? +route.query.status : PageSatatus.List
    }
  },
  { deep: true }
)
</script>

<style lang="less" scoped></style>
