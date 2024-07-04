/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ルーターガード
 * 　　　　　  ルーター関連
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { ACCESS_TOKEN } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import { setDocumentTitle } from '@/utils/dom-util'
import type { Router } from 'vue-router'
import NProgress from 'nprogress'
import '@/style/nprogress.less'
import { KensinAuthCheck, servicename } from '@/views/affect/SH/AWSH001/service'
import { GlobalStore } from '@/store'

NProgress.configure({ showSpinner: false })
const whiteList = ['login']

export const setupBeforeEach = (router: Router): void => {
  router.beforeEach(async (to, from) => {
    NProgress.start()
    GlobalStore.setLoading(true)
    setDocumentTitle(to)
    if (ss.get(ACCESS_TOKEN)) {
      if (to.path === '/user/login') {
        NProgress.done()
        return '/'
      } else {
        if (to.meta.disabled) {
          NProgress.done()
          return '/exception/403'
        } else {
          //新規無追加権限チェック処理(URL遷移)
          if (!to.meta.addflg && to.query.atenano && String(to.name).includes(servicename)) {
            const res = await KensinAuthCheck({
              nendo: Number(to.query.nendo),
              atenano: String(to.query.atenano)
            })
            return res.authflg ? true : '/exception/403'
          }
          return true
        }
      }
    } else {
      if (whiteList.includes(to.name as string)) {
        return true
      } else {
        NProgress.done()
        // next({ path: '/user/login', query: { redirect: to.fullPath } })
        return '/user/login'
      }
    }
  })
}

export const setupAfterEach = (router: Router): void => {
  router.afterEach((to, from, failure) => {
    GlobalStore.setLoading(false)
    NProgress.done()
  })
}
