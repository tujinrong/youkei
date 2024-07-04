<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: フォロー管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.10.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageStatus.List">
    <ListPage />
  </div>

  <div v-if="status !== PageStatus.List">
    <ListPage2 v-show="status === PageStatus.List2" v-model:header="header" />
    <ResultPage v-if="status === PageStatus.Result" :header="header" />
    <OperationFooter ref="footerRef" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, provide, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage from './components/ListPage.vue'
import ListPage2 from './components/ListPage2.vue'
import ResultPage from './components/ResultPage.vue'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'

enum PageStatus {
  List,
  List2,
  Result
}

const route = useRoute()
const status = ref(PageStatus.List)

const header = ref<GamenHeaderBase2VM | null>(null)

const footerRef = ref(null)
const { height } = useElementSize(footerRef)
provide('barHeight', height ?? 0)

onMounted(() => {
  if (route.query.follownaiyoedano) {
    status.value = PageStatus.Result
  } else if (route.query.atenano) {
    status.value = PageStatus.List2
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00401G') {
      status.value = route.query.atenano
        ? route.query.follownaiyoedano
          ? PageStatus.Result
          : PageStatus.List2
        : PageStatus.List
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
