<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ホーム
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="m-[-10px] mb-0">
    <a-tabs v-model:activeKey="activeKey" destroy-inactive-tab-pane>
      <template #rightExtra>
        <YearJp v-model:value="globalYear" class="mr-1 w-120px" @change="changeYear" />
      </template>
      <a-tab-pane key="1" tab="">
        <InfoTab />
      </a-tab-pane>
      <!-- <a-tab-pane key="2" tab="スケジュール">
        <a-card :bordered="false"> スケジュール </a-card>
      </a-tab-pane>
      <a-tab-pane key="3" tab="受診状況グラフ">
        <a-card :bordered="false"> 受診状況グラフ </a-card>
      </a-tab-pane>
      <a-tab-pane key="4" tab="予定表">
        <a-card :bordered="false"> 予定表 </a-card>
      </a-tab-pane>
      <a-tab-pane key="5" tab="動画マニュアル">
        <a-card :bordered="false"> 動画マニュアル </a-card>
      </a-tab-pane>-->
      <a-tab-pane v-if="IS_DEV" key="6" tab="　　　">
        <a-card :bordered="false"> <Test /> </a-card>
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script lang="ts" setup>
import { onMounted, ref } from 'vue'
import InfoTab from './components/InfoTab/index.vue'
import { ss } from '@/utils/storage'
import { GLOBAL_YEAR, MAX_YEAR } from '@/constants/mutation-types'
import YearJp from '@/components/Selector/YearJp/index.vue'
import Test from './components/Test.vue'
import { IS_DEV } from '@/constants/constant'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const activeKey = ref('1')
const globalYear = ref(ss.get(GLOBAL_YEAR))
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const GlobalYear = ss.get(GLOBAL_YEAR)
  if (!GlobalYear) {
    globalYear.value = ss.get(MAX_YEAR)
    ss.set(GLOBAL_YEAR, ss.get(MAX_YEAR))
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//グローバル年度変更(他の画面の初期値)
const changeYear = (value) => {
  ss.set(GLOBAL_YEAR, value)
}
</script>

<style lang="less" scoped>
:deep(.ant-tabs-nav) {
  background-color: #fff;
  padding: 0 10px;
}
:deep(.ant-tabs-content) {
  padding: 0 12px;
}
</style>
