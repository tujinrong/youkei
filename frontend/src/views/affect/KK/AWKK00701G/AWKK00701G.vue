<template>
  <div v-if="status == PageSatatus.List">
    <main-page v-model:tabActiveKey="tabActiveKey" />
  </div>
  <div v-else-if="status == PageSatatus.Detail">
    <input-page :tab-active-key="tabActiveKey" />
  </div>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//取込
//--------------------------------------------------------------------------
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import mainPage from './components/MainPage.vue'
import inputPage from './components/InputPage.vue'

//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
const props = defineProps<{
  kinoid: string
}>()
const tabActiveKey = ref('A')
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => route.query?.status,
  (val) => {
    if (route.name === props.kinoid) {
      if (val == undefined) {
        status.value = PageSatatus.List
        if (route.query.tabActiveKey) {
          tabActiveKey.value = route.query.tabActiveKey as string
        }
      } else if (val == '1') {
        status.value = PageSatatus.Detail
      } else if (val == '2') {
        status.value = PageSatatus.Edit
      }
    }
  }
)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query?.status == undefined) {
    status.value = PageSatatus.List
  } else if (route.query?.status == '2') {
    status.value = PageSatatus.Edit
  } else if (route.query?.status == '1') {
    status.value = PageSatatus.Detail
  }
})
</script>
