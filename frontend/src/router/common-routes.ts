/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 固定ルーター
 * 　　　　　  ルーター関連
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { UserLayout } from '@/layouts'
import { Router } from './types'
import { RouteRecordRaw } from 'vue-router'
import { getUserInfo } from '@/utils/user'
import AWAF00501G from '@/views/affect/AF/AWAF00501G/AWAF00501G.vue'
import { BasicLayout, RouteView, BlankLayout } from '@/layouts'
import Home from '@/views/affect/AF/AWAF00301G/AWAF00301G.vue'

export const commonRoutes = [
  {
    key: '',
    name: 'index',
    path: '/',
    component: BasicLayout,
    redirect: '/home',
    meta: {
      title: 'ホーム'
    },
    children: [
      {
        path: '/home',
        name: 'AWAF00301G',
        component: Home,
        meta: { title: 'ホーム', icon: 'common-manage' }
      },
      {
        path: '/GJ10',
        name: 'GJ10',
        meta: { title: '参加申込', icon: 'file-open' },
        children: [
          {
            path: '/GJ10/GJ1030',
            name: 'AWAF00601G',
            component: () => import('@/views/affect/AF/AWAF00601G/AWAF00601G.vue'),
            meta: { title: '(GJ1010)契約者一覧表(連絡用)', icon: 'comprehensive-data' }
          }
        ]
      },
      {
        path: '/GJ80',
        name: 'GJ80',
        meta: { title: 'マスタメンテナンス', icon: 'file-open' },
        children: [
          {
            path: '/GJ80/GJ8090',
            name: 'GJ8090',
            component: () => import('@/views/affect/AF/AWAF00501G/AWAF00501G.vue'),
            meta: { title: '(GJ8090)契約者農場マスタ', icon: 'comprehensive-data' }
          }
        ]
      },
      {
        path: '/AWAF00901G',
        name: 'AWAF00901G',
        component: 'AWAF00901G',
        meta: { title: 'ユーザー管理', hidden: true, disabled: !getUserInfo().kanrisyaflg }
      }
    ]
  },
  {
    path: '/user',
    name: 'user',
    component: UserLayout,
    redirect: '/user/login',
    hidden: true,
    children: [
      {
        path: 'login',
        name: 'login',
        component: () => import('@/views/affect/AF/AWAF00101G/index.vue'),
        meta: { title: 'ログイン' }
      }
    ]
  },
  {
    path: '/exception/403',
    name: '403',
    component: () => import('@/views/exception/403.vue')
  }
] as Router[]

//404ページ設定
export const notFoundRouter: RouteRecordRaw = {
  path: '/:path(.*)',
  name: 'NoMatch',
  component: () => import('@/views/exception/404.vue')
}

//ルートメニュー
export function createrRootRouter(): Router {
  // return {
  //   key: '',
  //   name: 'index',
  //   path: '/',
  //   component: 'BasicLayout',
  //   redirect: '/home',
  //   meta: {
  //     title: 'ホーム'
  //   },
  //   children: [
  //     {
  //       path: '/home',
  //       name: 'AWAF00301G',
  //       component: 'Home',
  //       meta: { title: 'ホーム', icon: 'common-manage' },
  //     },
  //     {
  //       path: '/GJ10',
  //       name: 'GJ10',
  //       meta: { title: '参加申込', icon: 'common-manage' },
  //       children: [
  //         {
  //           path: '/GJ10/GJ1030',
  //           name: 'AWAF00501G',
  //           component: () => import('@/views/affect/AF/AWAF00501G/components/EditPage-unuse.vue'),
  //           meta: { title: '(GJ1010) 契約者マスタメンテナンス', icon: 'common-manage' }
  //         },
  //       ]
  //     },
  //     {
  //       path: '/GJ80',
  //       name: 'GJ80',
  //       meta: { title: 'マスタメンテナンス', icon: 'common-manage' },
  //       children: [
  //         {
  //           path: '/GJ80/GJ8090',
  //           name: 'GJ8090',
  //           component: () => import('@/views/affect/AF/AWAF00501G/AWAF00501G.vue'),
  //           meta: { title: '(GJ8090) 契約者農場マスタメンテナンス', icon: 'common-manage' }
  //         },
  //       ]
  //     },
  //     {
  //       path: '/AWAF00901G',
  //       name: 'AWAF00901G',
  //       component: 'AWAF00901G',
  //       meta: { title: 'ユーザー管理', hidden: true, disabled: !getUserInfo().kanrisyaflg }
  //     }
  //   ]
  // }
}

//お気に入り
export function createCollectRouter(): Router {
  return null
  // return {
  //   path: '/Collect',
  //   name: 'Collect',
  //   meta: { title: 'お気に入り', isfolder: true, icon: 'file-open' },
  //   children: []
  // }
}
