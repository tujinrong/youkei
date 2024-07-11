/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: URL生成
 * 　　　　　  動的ルーター
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { ss } from '@/utils/storage'
import { MENU_NAV, PROGRAM_LIST } from '@/constants/mutation-types'
import emitter from '@/utils/event-bus'
import router from './index'
import { GetMenu } from '@/views/affect/AF/AWAF00301G/service'
import { Router } from './types'
import { getRoutePages } from '@/utils/batchImportFiles'
import { createrRootRouter, notFoundRouter } from './common-routes'
import { BasicLayout, RouteView, BlankLayout } from '@/layouts'
import Home from '@/views/affect/AF/AWAF00301G/AWAF00301G.vue'

//URL遷移ページ事前設定
let _data
const constantRouterComponents = () => {
  if (!_data) {
    const data = {
      BasicLayout,
      BlankLayout,
      RouteView,
      Home,
      ...getRoutePages(),
      '404': () => import('@/views/exception/404.vue')
    }

    //多重化ページ
    const programlist: ProgramModel[] = ss.get(PROGRAM_LIST) ?? []
    for (const { kinoid, menuids } of programlist) {
      for (const id of menuids) {
        data[id] = data[kinoid]
      }
    }

    _data = data
    console.log('data: ', data)
    return data
  } else {
    return _data
  }
}

//ルーター設定
const generateAsyncRoutes = async (list?: string[]): Promise<void> => {
  debugger;
  const rootRouter = createrRootRouter()
  let lsMenu: MenuModel[] = []
  // if (ss.get(MENU_NAV)) {
  //   lsMenu = ss.get(MENU_NAV)
  // } else {
  //   const res = await GetMenu()
  //   ss.set(MENU_NAV, res.menulist)
  //   ss.set(PROGRAM_LIST, res.programlist)
  //   lsMenu = res.menulist
  // }
  const menu: Router[] = lsMenu.map((el) => {
    return {
      key: el.menuid,
      path: el.path,
      name: el.menuid,
      meta: {
        title: el.menuname,
        disabled: !el.enabled,
        isfolder: el.isfolder,
        icon: el.parentid ? (el.isfolder ? 'bx-analyse' : 'comprehensive-data') : 'file-open',
        paramkeisyoflg: el.paramkeisyoflg,
        enabled: el.enabled,
        addflg: el.addflg,
        delflg: el.deleteflg,
        updflg: el.updateflg,
        personalnoflg: el.personalnoflg
      },
      parentId: el.parentid || 0,
      id: el.menuid
    }
  })
  //お気に入り
  let collectKeys: string[] = []
  // if (list) {
  //   collectKeys = list
  // } else {
  //   const res = await Search()
  //   collectKeys = res.kekkalist || []
  // }
  // collectKeys.forEach((el) => {
  //   const findItem = menu.find((item) => item.key === el)
  //   findItem && collectRouter.children?.push(findItem)
  // })
  // rootRouter.children?.push(collectRouter)
  //メニュー
  const childrenNav = []
  listToTree(menu, childrenNav, menu[0]?.parentId || 0)
  rootRouter.children?.push(...childrenNav)
  const routers = menuToRouter([rootRouter])
  router.removeRoute('index')
  router.addRoute(routers[0])
  router.addRoute(notFoundRouter)
  router.replace(window.location.pathname + window.location.search)
  emitter.emit('renderMenu')
}
//バックエンドからのメニューデータをフロントエンドのルーターに変更
export const menuToRouter = (routerMap, parent?) => {
  return routerMap.map((item) => {
    const { hidden, isfolder } = item.meta || {}
    const currentRouter: any = {
      path: item.path || `${(parent && parent.path) || ''}/${item.key}`,
      name: item.name || item.key || '',
      component: isfolder
        ? null
        : constantRouterComponents()[item.component || item.key] ||
          constantRouterComponents()['404'],
      meta: item.meta
    }

    //非表示(親フォルダー単位)
    hidden && (currentRouter.hidden = true)
    //リダイレクト
    item.redirect && (currentRouter.redirect = item.redirect)
    //ルーター設定(再帰)
    if (item.children && item.children.length > 0) {
      currentRouter.children = menuToRouter(item.children, currentRouter)
    }
    return currentRouter
  })
}
//リストモデルからツリーモデルに変換
export const listToTree = (list, tree, parentId) => {
  list.forEach((item) => {
    if (item.parentId === parentId) {
      const child = {
        ...item,
        key: item.key || item.name,
        children: []
      }
      //再帰
      listToTree(list, child.children, item.id)
      if (child.children.length <= 0) {
        delete child.children
      }
      tree.push(child)
    }
  })
}

export default generateAsyncRoutes
