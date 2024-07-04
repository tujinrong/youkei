<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status === PageSatatus.Detail">
    <DetailPage />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch, nextTick } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'
import ListPage from './components/ListPage.vue'
import DetailPage from './components/DetailPage.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.sessionseq) {
    status.value = PageSatatus.Detail
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWAF00803G') {
      status.value = route.query.sessionseq ? PageSatatus.Detail : PageSatatus.List
    }
    //ホーム画面から遷移する場合、タブをリフレッシュ
    if (route.query.logkbn) {
      status.value = PageSatatus.List
      nextTick(() => {
        status.value = PageSatatus.Detail
      })
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
