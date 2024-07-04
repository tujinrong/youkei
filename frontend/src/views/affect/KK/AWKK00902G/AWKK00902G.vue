<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageStatus.List1">
    <ListPage1 :options="options" />
  </div>

  <div v-if="status !== PageStatus.List1">
    <ListPage2 v-show="status === PageStatus.List2" />
    <ListPage3 v-if="status === PageStatus.List3" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage1 from './components/ListPage1.vue'
import { InitNitteiListResponse } from './type'
import { InitNitteiList } from './service'
import ListPage2 from './components/ListPage2.vue'
import ListPage3 from './components/ListPage3.vue'

enum PageStatus {
  List1 = 1,
  List2,
  List3
}
const route = useRoute()
const status = ref(PageStatus.List1)
const options = ref<Omit<InitNitteiListResponse, keyof DaResponseBase>>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  selectorlist6: []
})

onMounted(() => {
  InitNitteiList().then((res) => (options.value = res))
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.query.nitteino) {
      status.value = Number(route.query.status)
    } else {
      status.value = PageStatus.List1
    }
  },
  { deep: true, immediate: true }
)
</script>
<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
</style>
