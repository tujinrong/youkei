<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 画面タブ(ヘッダー部共有)
 * 　　　　　  共通フレーム
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="ant-pro-multi-tab">
    <div class="ant-pro-multi-tab-wrapper">
      <a-tabs
        v-model:activeKey="activeKey"
        hide-add
        type="editable-card"
        :tab-bar-style="{ margin: 0, paddingLeft: '16px', paddingTop: '1px' }"
        @edit="onEdit"
      >
        <a-tab-pane
          v-for="(page, index) in pages"
          :key="page.fullPath"
          :closable="index > 0"
          style="height: 0"
        >
          <template #tab>
            <a-dropdown :trigger="['contextmenu']">
              <span :style="{ userSelect: 'none' }"
                >{{ getTitle(page.meta.customTitle || page.meta.title) }}
              </span>
              <template #overlay>
                <a-menu v-if="IS_DEV" @click="removeAll">
                  <a-menu-item>タブをすべて閉じる</a-menu-item>
                </a-menu>
              </template>
            </a-dropdown>
          </template>
        </a-tab-pane>
      </a-tabs>
    </div>
  </div>
</template>
<script lang="ts" setup>
import { ref, reactive, watch, onMounted } from 'vue'
import { useRouter, RouteLocationNormalizedLoaded } from 'vue-router'
import { closePageTab } from '@/store/use-site-settings'
import { useStore } from 'vuex'
import { TAB_PAGES_CLOSE, TAB_PAGES_CACHED } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import { PAGE_DATA } from '@/constants/mutation-types'
import { showConfirmModal } from '@/utils/modal'
import { CLOSE_CONFIRM } from '@/constants/msg'
import { judgeStore } from '@/store'
import { getUserMenu } from '@/utils/user'
import { IS_DEV } from '@/constants/constant'
import { computed } from 'vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { commit } = useStore()
const Homepage: RouteLocationNormalizedLoaded = {
  fullPath: '/home',
  path: '/home',
  name: 'AWAF00301G',
  meta: { title: 'ホーム' }
} as unknown as RouteLocationNormalizedLoaded
let fullPathList: string[] = []
const pages = reactive<Array<RouteLocationNormalizedLoaded>>([])
const activeKey = ref('')
const router = useRouter()
const selectedLastPath = () => {
  activeKey.value = fullPathList[fullPathList.length - 1]
}
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => closePageTab.value,
  () => {
    if (closePageTab.value) {
      remove(router.currentRoute.value.fullPath)
      commit(TAB_PAGES_CLOSE, false)
    }
  }
)

watch(
  () => router.currentRoute.value,
  (newVal) => {
    addCurrentRoute(newVal)
  }
)

watch(activeKey, (newPathKey) => {
  let activePage = pages.find((page) => page.fullPath === newPathKey) || pages[0]
  if (activePage.fullPath === router.currentRoute.value.fullPath) return
  router.push(activePage).then((r) => {
    activeKey.value = router.currentRoute.value.fullPath
    addCurrentRoute(router.currentRoute.value)
  })
})

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------

onMounted(() => {
  const pageData = ss.get(PAGE_DATA)
  if (pageData) {
    pages.push(...pageData)
    pageData.forEach((item) => {
      fullPathList.push(item.fullPath)
    })
  } else {
    pages.push(Homepage)
    fullPathList.push(Homepage.fullPath)
    savePageData(pages)
  }
  //Enter the uncached label from the url
  const currentMenu =
    getUserMenu()?.find((item) => item.path === router.currentRoute.value.path) ||
    ['AWAF00901G', 'more...'].includes(router.currentRoute.value.name as string) //Fixed route

  const sameMenu = pages.find((p) => p.path === router.currentRoute.value.path)
  if (sameMenu) {
    sameMenu.fullPath = router.currentRoute.value.fullPath
  }

  if (!pages.find((p) => p.path === router.currentRoute.value.path) && currentMenu) {
    pages.push(router.currentRoute.value)
    fullPathList.push(router.currentRoute.value.fullPath)
    savePageData(pages)
  }

  activeKey.value = router.currentRoute.value.fullPath
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

const onEdit = (targetKey: string, action) => {
  for (let key in judgeStore) {
    if (judgeStore[key] === false) {
      delete judgeStore[key]
    }
  }
  const arr: string[] = Object.keys(judgeStore)
  const isShowModal = arr.some((el) => targetKey.includes(el))

  if (action == 'remove') {
    if (isShowModal) {
      showConfirmModal({
        content: CLOSE_CONFIRM.Msg,
        onOk: () => {
          remove(targetKey)
        }
      })
    } else {
      remove(targetKey)
    }
  }
}
const remove = (targetKey) => {
  const temp = pages.filter((page) => page.fullPath !== targetKey)
  pages.length = 0
  pages.push(...temp)
  fullPathList = fullPathList.filter((path) => path !== targetKey)
  if (!fullPathList.includes(activeKey.value)) {
    selectedLastPath()
  }
  savePageData(pages)
}
const removeAll = () => {
  pages.length = 0
  pages.push(Homepage)
  fullPathList = [Homepage.fullPath]
  selectedLastPath()
  savePageData(pages)
}

const getTitle = (title: any) => {
  return title.replace(/\([^)]*\)/g, '').trim()
}

const savePageData = (pages) => {
  let pagesData = pages.map((page) => {
    return {
      fullPath: page.fullPath,
      path: page.path,
      name: page.name,
      meta: page.meta,
      query: page.query,
      params: page.params,
      hash: page.hash
    }
  })

  ss.set(PAGE_DATA, pagesData)
  const cachedViews = pages.map((page) => {
    return page.name
  })
  commit(TAB_PAGES_CACHED, cachedViews)
}
//タブ追加
const addCurrentRoute = (currentRouteNewVal) => {
  let activePage = pages.find((page) => page.path === currentRouteNewVal.path)
  if (activePage) {
    fullPathList[fullPathList.indexOf(activePage.fullPath)] = currentRouteNewVal.fullPath
    pages.splice(pages.indexOf(activePage), 1, currentRouteNewVal)
  }
  if (fullPathList.indexOf(currentRouteNewVal.fullPath) < 0) {
    fullPathList.push(currentRouteNewVal.fullPath)
    if (!pages.includes(currentRouteNewVal)) pages.push(currentRouteNewVal)
  }
  savePageData(pages)
  activeKey.value = currentRouteNewVal.fullPath
}
</script>
<style src="./index.less"></style>
