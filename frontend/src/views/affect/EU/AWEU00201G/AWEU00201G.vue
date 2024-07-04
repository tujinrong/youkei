<template>
  <div v-show="status == PageSatatus.List">
    <DataList v-bind="{ selector1Options, selector2Options, selector3Options, selector4Options }" />
  </div>
  <div v-if="status == PageSatatus.Edit || status == PageSatatus.New">
    <DataAdd v-bind="{ selector2Options }" />
  </div>
</template>

<script setup lang="ts">
import { PageSatatus } from '#/Enums'
import { onMounted, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import DataList from './components/DataList.vue'
import DataAdd from './components/DataAdd.vue'
import { InitList } from './service'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const status = ref(PageSatatus.List)
/**業務 */
const selector1Options = ref<DaSelectorModel[]>([])
/**帳票グループ */
const selector2Options = ref<DaSelectorModel[]>([])
/**帳票様式 */
const selector3Options = ref<DaSelectorModel[]>([])
/**帳票種別 */
const selector4Options = ref<DaSelectorModel[]>([])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  status.value = (route.query.status as unknown as PageSatatus) || PageSatatus.List
  getInitData()
})
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [route.name, route.query],
  () => {
    if (route.name === 'AWEU00201G') {
      status.value = (route.query.status as unknown as PageSatatus) || PageSatatus.List
    }
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//初期化処理
const getInitData = () => {
  InitList().then((res) => {
    selector1Options.value = res.selectorlist1
    selector2Options.value = res.selectorlist2
    selector3Options.value = res.selectorlist3.filter((el) => el.label != 'サブ様式')
    selector4Options.value = res.selectorlist4.filter((el) => el.label != 'カスタマイズ')
  })
}
</script>
