/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
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

export const commonRoutes = [
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
  return {
    key: '',
    name: 'index',
    path: '/',
    component: 'BasicLayout',
    redirect: '/home',
    meta: {
      title: 'ホーム'
    },
    children: [
      {
        path: '/home',
        name: 'AWAF00301G',
        component: 'Home',
        meta: { title: 'ホーム', icon: 'common-manage' }
      },
      {
        path: '/AWAF00901G',
        name: 'AWAF00901G',
        component: 'AWAF00901G',
        meta: { title: 'ユーザー管理', hidden: true, disabled: !getUserInfo().kanrisyaflg }
      }
    ]
  }
}

//お気に入り
export function createCollectRouter(): Router {
  return {
    path: '/Collect',
    name: 'Collect',
    meta: { title: 'お気に入り', isfolder: true, icon: 'file-open' },
    children: []
  }
}
