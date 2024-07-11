<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者（担当者）保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.11
 * 作成者　　: 高智輝
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status === PageSatatus.New || status === PageSatatus.Edit">
    <EditPage :status="status" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'
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
    if (route.name === 'AWKK00203G') {
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
