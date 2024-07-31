<template>
  <div>
    <div v-show="status === PageSatatus.List" class="h-full">
      <ListPage :KI="KI" :KEIYAKUSYA_CD_NAME_LIST="KEIYAKUSYA_CD_NAME_LIST" />
    </div>
    <div
      v-if="status === PageSatatus.New || status === PageSatatus.Edit"
      class="h-full"
    >
      <!-- <EditPage :status="status" /> -->
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
import { Init } from './service'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()

const status = ref(PageSatatus.List)

//TODO
const KI = ref<number>(8)

const KEIYAKUSYA_CD_NAME_LIST = ref<DaSelectorModel[]>([])

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
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
    console.log('route.name: ', route.name)
    if (route.name === 'gj80_gj8090') {
      status.value = route.query.status ? +route.query.status : PageSatatus.List
    }
  },
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  Init().then((res) => {
    KI.value = res.KI
    KEIYAKUSYA_CD_NAME_LIST.value = res.KEIYAKUSYA_CD_NAME_LIST
  })
}
</script>

<style lang="less" scoped></style>
