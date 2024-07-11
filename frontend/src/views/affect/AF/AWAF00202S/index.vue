<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 使用履歴
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.02.27
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-menu @click="clickHistory">
    <a-divider>使用履歴</a-divider>
    <div v-for="item in tt_afsiyorireki" :key="item.kinoid">
      <a-menu-item :key="item.kinoid" :disabled="item.disabled">
        <a>{{ item.hyojinm }}</a>
      </a-menu-item>
    </div>
  </a-menu>
</template>

<script setup lang="ts">
import type { MenuProps } from 'ant-design-vue'
import { useRouter, useRoute, RouteLocationNormalizedLoaded } from 'vue-router'
import { computed } from 'vue'
import { useStore } from 'vuex'
import { SiyorirekiVM } from './type'
import { ss } from '@/utils/storage'
import { PAGE_DATA } from '@/constants/mutation-types'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const store = useStore()
const route = useRoute()
const router = useRouter()
const tt_afsiyorireki = computed<SiyorirekiVM[]>(() => store.state.bussiness.historyList)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const clickHistory: MenuProps['onClick'] = ({ key }) => {
  const kinoid = key as string
  if (route.name === kinoid) return
  const currentOpenedPages = ss.get(PAGE_DATA) || ([] as Array<RouteLocationNormalizedLoaded>)
  const page = currentOpenedPages.find((item) => item.name === kinoid)
  if (currentOpenedPages.length > 0 && page) {
    router.push(page)
  } else {
    router.push({ name: kinoid })
  }
}
</script>

<style scoped></style>
