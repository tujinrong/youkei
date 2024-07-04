<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 予防接種情報管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.07.01
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status !== PageSatatus.List">
    <DetailPage />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage from './components/ListPage.vue'
import DetailPage from './components/DetailPage.vue'
import { PageSatatus } from '#/Enums'

const route = useRoute()
const status = ref(PageSatatus.List)

onMounted(() => {
  if (route.query.atenano) {
    status.value = PageSatatus.Detail
  }
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWYS00101G') {
      status.value = route.query.atenano ? PageSatatus.Detail : PageSatatus.List
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
