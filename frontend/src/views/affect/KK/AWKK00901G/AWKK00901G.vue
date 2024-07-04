<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予定管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.01
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <a-tabs v-model:activeKey="activeKey" type="card" size="large" class="card-container">
      <a-tab-pane key="1" tab="日程">
        <ListPage1 :options="options" />
      </a-tab-pane>
      <a-tab-pane key="2" tab="コース">
        <ListPage2 :options="options" />
      </a-tab-pane>
    </a-tabs>
  </div>
  <div v-if="status === PageSatatus.Detail">
    <DetailPage1 v-if="activeKey === '1'" />
    <DetailPage2 v-if="activeKey === '2'" />
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage1 from './components/ListPage1.vue'
import ListPage2 from './components/ListPage2.vue'
import DetailPage1 from './components/DetailPage1.vue'
import DetailPage2 from './components/DetailPage2.vue'
import { InitList } from './service'
import { InitListResponse } from './type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
const activeKey = ref('1')
const options = ref<Omit<InitListResponse, keyof DaResponseBase>>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: []
})
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  if (route.query.nitteino || route.query.courseno) {
    status.value = PageSatatus.Detail
    if (route.query.courseno) activeKey.value = '2'
  }
  InitList().then((res) => (options.value = res))
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00901G') {
      status.value =
        route.query.nitteino || route.query.courseno ? PageSatatus.Detail : PageSatatus.List
    }
  },
  { deep: true }
)
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}

:deep(.card-container .ant-tabs-nav) {
  margin: -1px !important;
}
</style>
