<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 保健指導管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.12
 * 作成者　　: 王
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status === PageSatatus.Edit">
    <EditPage />
  </div>
  <div v-if="status === PageSatatus.Detail">
    <DetailPage />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'
import DetailPage from './components/DetaiPage.vue'
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

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00301G') {
      status.value = route.query.status ? +route.query.status : PageSatatus.List
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
