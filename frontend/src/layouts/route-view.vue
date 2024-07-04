<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 画面共通モデル(モデル内に各画面の内容を入れる)
 * 　　　　　  共通レイアウト
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <router-view v-slot="{ Component }">
    <keep-alive :include="cachedViews">
      <component :is="wrapComponent($route.name as string, Component)" :key="$route.name" />
    </keep-alive>
  </router-view>
</template>

<script setup lang="ts">
import { computed, watch } from 'vue'
import { useStore } from 'vuex'
import { useRouter } from 'vue-router'
import { h } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const store = useStore()
const router = useRouter()
const cachedViews = computed(() => store.state.app.cachedViews)
const cacheMap = new Map()

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => router.currentRoute.value,
  () => {
    store.dispatch('addCachedView', router.currentRoute.value)
  },
  { immediate: true }
)

//Wrap the component with route name
const wrapComponent = (name: string, component) => {
  let cache
  if (cacheMap.has(name)) {
    cache = cacheMap.get(name)
  } else {
    cache = {
      name,
      render() {
        return h(component, { kinoid: name })
      }
    }
    cacheMap.set(name, cache)
  }
  return h(cache)
}
</script>
