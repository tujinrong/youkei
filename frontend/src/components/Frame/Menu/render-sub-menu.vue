<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メニュー(共通モデル内：機能親フォルダー単位)
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-sub-menu
    v-if="menu.children"
    :key="menu.path"
    popup-class-name="popupSubMenu"
    :popup-offset="[0, 0]"
  >
    <template #icon>
      <svg-icon v-if="menu.meta?.icon" :name="menu.meta.icon" />
    </template>
    <template #title>{{ menu.meta?.title }}</template>
    <template v-for="sub in menu.children" :key="sub.path">
      <render-sub-menu :menu="sub" />
    </template>
  </a-sub-menu>
  <a-menu-item
    v-else-if="!menu.meta?.hidden"
    :key="menu.path"
    :disabled="menu.meta?.disabled"
    @click="filterParams(menu)"
  >
    <template #icon>
      <svg-icon v-if="menu.meta?.icon" :name="menu.meta.icon" />
    </template>

    <a-dropdown :trigger="['contextmenu']">
      <span>{{ menu.meta?.title }}</span>
      <template #overlay>
        <a-menu>
          <a-menu-item @click="() => menuClick(menu.path)">コピー</a-menu-item>
        </a-menu>
      </template>
    </a-dropdown>
  </a-menu-item>
</template>
<script lang="ts" setup>
import SvgIcon from '@/components/Common/SvgIcon/index.vue'
import { RouteLocationNormalizedLoaded, useRouter, useRoute } from 'vue-router'
import { Router } from '@/router/types'
import { showConfirmModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { PAGE_DATA } from '@/constants/mutation-types'
import { GlobalStore } from '@/store'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  menu: Router
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//ページ遷移
const filterParams = (menu: Router) => {
  const { name, children, meta } = menu
  if (!children && meta?.isfolder) return
  if (route.name === name) return
  if (GlobalStore.loading) return

  const currentOpenedPages = ss.get(PAGE_DATA) || ([] as Array<RouteLocationNormalizedLoaded>)
  const page = currentOpenedPages.find((item) => item.name === name)
  if (currentOpenedPages.length > 0 && page) {
    router.push(page)
    return
  }
  let routeQuery = route.query
  if (routeQuery.atenano && meta?.paramkeisyoflg && route.meta.paramkeisyoflg) {
    showConfirmModal({
      content: `${routeQuery.atenano} さんの情報を引き続きますか？`, //todo:msg
      onOk() {
        router.push({
          name,
          query: { atenano: routeQuery.atenano, nendo: routeQuery.nendo }
        })
      },
      onCancel() {
        router.push({ name })
      }
    })
  } else {
    router.push({ name })
  }
}

const menuClick = (path: string) => {
  const width = 1000
  const height = 800
  const left = window.screen.width / 2 - width / 2
  const top = window.screen.height / 2 - height / 2
  const features = `width=${width},height=${height},left=${left},top=${top},toolbar=yes,menubar=yes,location=yes,status=yes`
  window.open(`http://localhost:3000${path}`, '_blank', features)
}
</script>
<style lang="less" scoped>
.menuName {
  svg,
  span {
    vertical-align: middle;
  }
  svg {
    margin-right: 10px;
  }
}
</style>
