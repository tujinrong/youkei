/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ルーター作成
 * 　　　　　  ルーター関連
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router'
import { setupBeforeEach, setupAfterEach } from './router-guard'
import { commonRoutes } from './common-routes'
// import generateAsyncRoutes from './generate-async-routes'
import { ss } from '@/utils/storage'
import { ACCESS_TOKEN } from '@/constants/mutation-types'
import { stringifyQuery, parseQuery } from '@/utils/encrypt/parameter'
const env = {
  VITE_PUBLIC_PATH: import.meta.env.VITE_PUBLIC_PATH
}
const router = createRouter({
  history: createWebHistory(env.VITE_PUBLIC_PATH === '/' ? '' : env.VITE_PUBLIC_PATH),
  // 暗号化
  stringifyQuery: stringifyQuery,
  parseQuery: parseQuery,
  routes: commonRoutes as unknown as RouteRecordRaw[]
})

router.onError((error, to) => {
  console.log('error: ', error)
  if (error.message.includes('Failed to fetch dynamically imported module')) {
    window.location.href = to.fullPath
  }
})

window.addEventListener('vite:preloadError', (event) => {
  window.location.reload()
})

setupBeforeEach(router)

setupAfterEach(router)

if (ss.get(ACCESS_TOKEN)) {
  // generateAsyncRoutes()
}

export default router
