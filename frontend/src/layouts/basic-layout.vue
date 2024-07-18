<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 空白画面
 * 　　　　　  共通レイアウト
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin id="global_loading" :spinning="loading">
    <a-layout class="layout">
      <side-menu
        v-if="isSideMenu()"
        mode="inline"
        :menus="menus"
        :collapsed="collapsed"
      ></side-menu>
      <a-layout
        :class="[layoutMode, `content-width-${contentWidth}`]"
        :style="{ paddingLeft: contentPaddingLeft, minHeight: '100vh' }"
      >
        <global-header
          :mode="layoutMode"
          :menus="menus"
          :collapsed="collapsed"
          @toggle="toggle"
          @refresh="onRefresh"
        />
        <a-layout-content
          :style="{
            height: '100%',
            margin: '24px 24px 0',
            paddingTop: fixedHeader ? '48px' : '0'
          }"
        >
          <multi-tab v-if="multiTab && layoutMode == MenuType.Top"></multi-tab>
          <transition name="page-transition">
            <section>
              <route-view v-if="showRouter" />
            </section>
          </transition>
        </a-layout-content>
        <setting-drawer></setting-drawer>
      </a-layout>
    </a-layout>
  </a-spin>
</template>

<script setup lang="ts">
import { ref, computed, watch, onMounted, nextTick, watchEffect, h, render } from 'vue'
import RouteView from './route-view.vue'
import MultiTab from '@/components/Frame/MultiTab/index.vue'
import SideMenu from '@/components/Frame/Menu/side-menu.vue'
import GlobalHeader from '@/components/Frame/GlobalHeader/index.vue'
import SettingDrawer from '@/components/Frame/SettingDrawer/index.vue'
import { SET_SIDEBAR_TYPE } from '@/constants/mutation-types'
import {
  fixSidebar,
  sidebarOpened,
  multiTab,
  layoutMode,
  contentWidth,
  fixedHeader,
  isSideMenu
} from '@/store/use-site-settings'
import { useStore } from 'vuex'
import { useRouter } from 'vue-router'
import emitter from '@/utils/event-bus'
import { MenuType } from '#/Enums'
import { GlobalStore } from '@/store/index'
import { Spin } from 'ant-design-vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const collapsed = ref(false)
const menus = ref<any>([])
const store = useStore()
const showRouter = ref(true)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const contentPaddingLeft = computed(() => {
  if (!fixSidebar.value) {
    return '0'
  }
  if (layoutMode.value == MenuType.Top) {
    return '0px'
  } else {
    if (sidebarOpened.value) {
      return '300px'
    }
    return '80px'
  }
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => sidebarOpened.value,
  (val) => {
    collapsed.value = !val
  }
)

emitter.once('renderMenu', () => renderMenu())

//Modal Global loading------------------------------------------------------
const loading = ref(false)
watchEffect(async () => {
  if (!GlobalStore.loading) {
    loading.value = false
  }

  const modals = document.getElementsByClassName('ant-modal-content')
  if (modals.length === 0) {
    loading.value = GlobalStore.loading
    return
  }

  if (GlobalStore.loading) {
    if (modals.length > 0) {
      await nextTick()
      const modalElement = modals[modals.length - 1]
      const { width, height } = modalElement.getBoundingClientRect()

      const spin = h(
        Spin,
        {
          key: Date.now(),
          wrapperClassName: 'loading-wrapper'
        },
        [
          h('div', {
            style: {
              width: `${width}px`,
              height: `${height}px`
            }
          })
        ]
      )
      render(spin, modalElement)

      const wrapper = document.querySelector('.loading-wrapper') as HTMLElement
      wrapper.style.position = 'absolute'
      wrapper.style.top = wrapper.style.left = '0'
    }
  } else {
    const loadingWrapper = document.querySelector('.loading-wrapper') as HTMLElement
    if (loadingWrapper) {
      loadingWrapper.remove()
    }
  }
})
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  const userAgent = navigator.userAgent
  if (userAgent.indexOf('Edge') > -1) {
    nextTick(() => {
      collapsed.value = !collapsed.value
      setTimeout(() => {
        collapsed.value = !collapsed.value
      }, 16)
    })
  }
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const renderMenu = () => {
  const orginRoutes = router.getRoutes()
  const routes = orginRoutes.find((item) => item.path === '/')
  menus.value = (routes && routes.children) || []
  collapsed.value = !sidebarOpened.value
}

renderMenu()

const toggle = () => {
  collapsed.value = !collapsed.value
  store.commit(SET_SIDEBAR_TYPE, !collapsed.value)
}

const onRefresh = () => {
  emitter.all.clear()
  showRouter.value = false
  nextTick(() => (showRouter.value = true))
}
</script>

<style lang="less">
.page-transition-enter {
  opacity: 0;
}
.page-transition-leave-active {
  opacity: 0;
}
.page-transition-enter .page-transition-container,
.page-transition-leave-active .page-transition-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>
