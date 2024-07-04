<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>

  <div v-if="status === PageSatatus.Detail || status === PageSatatus.Preview">
    <ListPage2 v-show="status === PageSatatus.Detail" />
    <DetailPage v-if="status === PageSatatus.Preview" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage from './components/ListPage.vue'
import ListPage2 from './components/ListPage2.vue'
import DetailPage from './components/DetailPage.vue'
import { PageSatatus } from '#/Enums'

const route = useRoute()
const status = ref(PageSatatus.List)

onMounted(() => {
  if (route.query.prevno) {
    status.value = PageSatatus.Preview
  } else if (route.query.atenano) {
    status.value = PageSatatus.Detail
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00101G') {
      status.value = route.query.atenano
        ? route.query.prevno
          ? PageSatatus.Preview
          : PageSatatus.Detail
        : PageSatatus.List
    }
  },
  { deep: true }
)
</script>
<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
