<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div v-show="status === PageSatatus.List">
    <ListPage
      v-bind="{
        selectorlist1,
        selectorlist2,
        selectorlist3
      }"
    />
  </div>
  <div v-if="status === PageSatatus.New || status === PageSatatus.Edit">
    <EditPage
      :status="status"
      v-bind="{
        selectorlist4,
        selectorlist5
      }"
    />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { PageSatatus } from '#/Enums'
import ListPage from './components/ListPage.vue'
import EditPage from './components/EditPage.vue'
import { InitDetail, InitList } from './service'
import { StaffJigyocdVM } from './type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)

const selectorlist1 = ref<DaSelectorModel[]>([])
const selectorlist2 = ref<DaSelectorModel[]>([])
const selectorlist3 = ref<StaffJigyocdVM[]>([])
const selectorlist4 = ref<DaSelectorModel[]>([])
const selectorlist5 = ref<DaSelectorModel[]>([])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (route.query.status) {
    status.value = +route.query.status
  }
  //初期化処理(ドロップダウンリスト)
  InitList().then((res) => {
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    selectorlist3.value = res.selectorlist3
  })
  InitDetail().then((res) => {
    selectorlist4.value = res.selectorlist4
    selectorlist5.value = res.selectorlist5
  })
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWKK00501G') {
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
