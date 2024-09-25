<script setup lang="ts">
import { computed, h, nextTick, ref, render, watchEffect } from 'vue'
import { ConfigProvider, Spin } from 'ant-design-vue'
import { useAppStore } from './store/modules/app'
import { useThemeStore } from './store/modules/theme'
import { antdLocales } from './locales/antd'

defineOptions({
  name: 'App',
})

const appStore = useAppStore()
const themeStore = useThemeStore()

const antdLocale = computed(() => {
  return antdLocales[appStore.locale]
})

//Modal Global loading------------------------------------------------------
const loading = ref(false)
watchEffect(async () => {
  if (!appStore.loading) {
    loading.value = false
  }

  const modals = document.getElementsByClassName('ant-modal-content')
  //排除confirm modal
  const filteredModals = Array.from(modals).filter((modal) => {
    const parent = modal.parentElement
    if (parent) {
      return !parent.classList.contains('ant-modal-confirm')
    }
    return false
  })

  if (filteredModals.length === 0) {
    loading.value = appStore.loading
    return
  }

  if (appStore.loading) {
    if (filteredModals.length > 0) {
      await nextTick()
      const modalElement = filteredModals[filteredModals.length - 1]
      const { width, height } = modalElement.getBoundingClientRect()

      const spin = h(
        Spin,
        {
          key: Date.now(),
          wrapperClassName: 'loading-wrapper',
        },
        [
          h('div', {
            style: {
              width: `${width}px`,
              height: `${height}px`,
            },
          }),
        ]
      )
      render(spin, modalElement)

      const wrapper = document.querySelector('.loading-wrapper') as HTMLElement
      wrapper.style.position = 'absolute'
      // wrapper.style.zIndex = '11' // more than some component
      wrapper.style.top = wrapper.style.left = '0'
    }
  } else {
    const loadingWrapper = document.querySelector(
      '.loading-wrapper'
    ) as HTMLElement
    if (loadingWrapper) {
      loadingWrapper.remove()
    }
  }
})
//--------------------------------------------------------------------------
</script>

<template>
  <ConfigProvider
    :theme="themeStore.antdTheme"
    :locale="antdLocale"
    :autoInsertSpaceInButton="false"
  >
    <a-spin id="global_loading" :spinning="loading" wrapperClassName="h-full">
      <AppProvider>
        <RouterView class="bg-layout" />
      </AppProvider>
    </a-spin>
  </ConfigProvider>
</template>

<style scoped>
:deep(.ant-spin-container) {
  height: 100%;
}
:deep(.ant-spin.ant-spin-spinning) {
  max-height: fit-content;
}
</style>
