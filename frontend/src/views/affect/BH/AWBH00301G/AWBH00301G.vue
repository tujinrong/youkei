<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 妊産婦情報管理	
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.31
 * 作成者　　: gaof
 * 変更履歴　:
 * ---------------------------------------------------------------->
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
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'

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
  if (route.query.atenano) {
    status.value = PageSatatus.Edit
  }
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
