<script setup lang="ts">
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import type { MenuInfo, MenuMode } from 'ant-design-vue/es/menu/src/interface'
import { SimpleScrollbar } from '@sa/materials'
import { transformColorWithOpacity } from '@sa/utils'
import type { RouteKey } from '@elegant-router/types'
import { useAppStore } from '@/store/modules/app'
import { useThemeStore } from '@/store/modules/theme'
import { useRouteStore } from '@/store/modules/route'
import { useRouterPush } from '@/hooks/common/router'

defineOptions({
  name: 'BaseMenu',
})

interface Props {
  darkTheme?: boolean
  mode?: MenuMode
  menus: App.Global.Menu[]
}

const props = withDefaults(defineProps<Props>(), {
  mode: 'inline',
})

const route = useRoute()
const appStore = useAppStore()
const themeStore = useThemeStore()
const routeStore = useRouteStore()
const { routerPushByKey } = useRouterPush()

const menuTheme = computed(() => (props.darkTheme ? 'dark' : 'light'))

const isHorizontal = computed(() => props.mode === 'horizontal')

const siderCollapse = computed(
  () => themeStore.layout.mode === 'vertical' && appStore.siderCollapse
)

const inlineCollapsed = computed(() =>
  props.mode === 'inline' ? siderCollapse.value : undefined
)

const selectedKeys = computed(() => {
  const { hideInMenu, activeMenu } = route.meta
  const name = route.name as string

  const routeName = (hideInMenu ? activeMenu : name) || name

  return [routeName]
})

const openKeys = computed(() => {
  if (isHorizontal.value || inlineCollapsed.value) return []

  const [selectedKey] = selectedKeys.value

  if (!selectedKey) return []

  return routeStore.getSelectedMenuKeyPath(selectedKey)
})

const headerHeight = computed(() => `${themeStore.header.height}px`)

const selectedBgColor = computed(() => {
  const { darkMode, themeColor } = themeStore

  const light = transformColorWithOpacity(themeColor, 0.1, '#ffffff')
  const dark = transformColorWithOpacity(themeColor, 0.3, '#000000')

  return darkMode ? dark : light
})

function handleClickMenu(menuInfo: MenuInfo) {
  const key = menuInfo.key as RouteKey

  const query = routeStore.getRouteQueryOfMetaByKey(key)

  routerPushByKey(key, { query })
}

//右クリックメニュー------------------------------------------------------
const menuVisible = ref(false)
const menuStyle = reactive({
  top: '0px',
  left: '0px',
})
let currentPath = ''

onMounted(() => {
  const menuItems = document.querySelectorAll('.ant-menu-item')
  menuItems.forEach((item) => {
    const disabled = item.classList.contains('ant-menu-item-disabled')
    if (!disabled) {
      item.addEventListener('contextmenu', (event) => {
        event.preventDefault()
        showMenu(event)
        currentPath = item.getAttribute('routepath') ?? ''
      })
    }
  })
})

function showMenu(event) {
  event.stopPropagation()
  menuStyle.top = `${event.clientY}px`
  menuStyle.left = `${event.clientX}px`
  menuVisible.value = true
  document.addEventListener('click', hideMenu)
}
function hideMenu() {
  menuVisible.value = false
  document.removeEventListener('click', hideMenu)
}

const openNew = () => {
  const width = 1600
  const height = 900
  const left = window.screen.width / 2 - width / 2
  const top = window.screen.height / 2 - height / 2
  const features = `width=${width},height=${height},left=${left},top=${top},toolbar=yes,menubar=yes,location=yes,status=yes`
  const host = window.location.href.includes('localhost')
    ? 'localhost:9527'
    : '61.213.76.155:65534'

  window.open(`http://${host}${currentPath}`, '_blank')
}
//---------------------------------------------------------------------
</script>

<template>
  <SimpleScrollbar class="menu-wrapper" :class="{ 'select-menu': !darkTheme }">
    <AMenu
      :mode="mode"
      :theme="menuTheme"
      :items="menus"
      :selected-keys="selectedKeys"
      :open-keys="openKeys"
      :inline-collapsed="inlineCollapsed"
      :inline-indent="18"
      class="size-full transition-300 border-0!"
      :class="{ 'bg-container!': !darkTheme, 'horizontal-menu': isHorizontal }"
      @click="handleClickMenu"
    />
    <Teleport to="body">
      <a-menu v-if="menuVisible" :style="menuStyle" class="context-menu">
        <a-menu-item @click="openNew">新しいタブを開く</a-menu-item>
      </a-menu>
    </Teleport>
  </SimpleScrollbar>
</template>

<style lang="scss" scoped>
.menu-wrapper {
  :deep(.ant-menu-inline) {
    .ant-menu-item {
      width: calc(100% - 16px);
      margin-inline: 8px;
    }
  }

  :deep(.ant-menu-submenu-title) {
    width: calc(100% - 16px);
    margin-inline: 8px;
  }

  :deep(.ant-menu-inline-collapsed) {
    > .ant-menu-item {
      padding-inline: calc(50% - 14px);
    }

    .ant-menu-item-icon {
      vertical-align: -0.25em;
    }

    .ant-menu-submenu-title {
      padding-inline: calc(50% - 14px);
    }
  }

  :deep(.ant-menu-horizontal) {
    .ant-menu-item {
      display: flex;
      align-items: center;
    }

    .ant-menu-submenu-title {
      display: flex;
      align-items: center;
    }
  }
}

.select-menu {
  :deep(.ant-menu-inline) {
    .ant-menu-item-selected {
      background-color: v-bind(selectedBgColor);
    }
  }
}

.horizontal-menu {
  line-height: v-bind(headerHeight);
}

.context-menu {
  position: absolute;
  z-index: 999;
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);
  border-radius: 4px;
}
</style>
