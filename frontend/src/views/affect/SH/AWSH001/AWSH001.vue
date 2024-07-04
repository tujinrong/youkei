<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ロジック共通仕様処理(検診)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage />
  </div>
  <div v-if="status === PageSatatus.Edit">
    <EditPage />
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import { onActivated, onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'
import { ProgramStore } from '@/store'

const props = defineProps<{
  kinoid: string
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  ProgramStore.setId(props.kinoid)
  if (route.query.atenano) {
    status.value = PageSatatus.Edit
  }
})
onActivated(() => {
  ProgramStore.setId(props.kinoid)
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === props.kinoid) {
      status.value = route.query.atenano ? PageSatatus.Edit : PageSatatus.List
    }
  },
  { deep: true }
)
</script>

<style lang="less" scoped>
:deep(.ant-form-item) {
  margin-bottom: 0;
}
:deep(.ant-form-item-extra) {
  color: #faad14;
}
</style>
