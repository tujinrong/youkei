<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メニュー(サイドメニュー：レイアウト変換用)
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-layout-sider
    v-model:collapsed="sideMenuCollapsed"
    :class="['sider', 'dark', fixSiderbar ? 'ant-fixed-sidemenu' : null]"
    width="300px"
    collapsible
    :trigger="null"
  >
    <logo />
    <Menu :collapsed="collapsed" :menu="menus" :mode="mode"></Menu>
  </a-layout-sider>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue'
import Logo from '@/components/Frame/Logo/index.vue'
import Menu from './menu.vue'
import { fixSiderbar } from '@/store/use-site-settings'
import { Router } from '@/router/types'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  menus: Router[]
  mode?: string
  collapsed?: boolean
}
const props = withDefaults(defineProps<Props>(), {
  mode: 'inline',
  collapsed: false
})

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const sideMenuCollapsed = ref(false)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.collapsed,
  (newVal) => (sideMenuCollapsed.value = newVal),
  { immediate: true }
)
</script>
