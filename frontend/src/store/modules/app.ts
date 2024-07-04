/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ベース
 * 　　　　　  データストア設定
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { ls } from '@/utils/storage'
import {
  SITE_SETTINGS,
  SET_SIDEBAR_TYPE,
  TOGGLE_FIXED_HEADER,
  TOGGLE_CONTENT_WIDTH,
  TOGGLE_COLOR,
  TOGGLE_MULTI_TAB,
  SET_SETTING_DRAWER,
  TOGGLE_FIXED_SIDERBAR,
  TOGGLE_LAYOUT_MODE,
  TAB_PAGES_CLOSE,
  TAB_PAGES_CACHED
} from '@/constants/mutation-types'
import { ActionContext } from 'vuex'
import { MenuType } from '#/Enums'

const app = {
  state: {
    sidebar: true,
    layout: MenuType.Side,
    contentWidth: 'Fluid',
    fixedHeader: true,
    fixSiderbar: true,
    color: null,
    multiTab: true,
    showSettings: false,
    closePageTab: false,
    cachedViews: []
  },
  mutations: {
    [SET_SIDEBAR_TYPE]: (state, type) => {
      state.sidebar = type
      cache({ [SET_SIDEBAR_TYPE]: type })
    },
    [TOGGLE_LAYOUT_MODE]: (state, layout) => {
      if (layout === MenuType.Side) {
        state.contentWidth = 'Fluid'
        cache({ [TOGGLE_CONTENT_WIDTH]: 'Fluid' })
      }
      cache({ [TOGGLE_LAYOUT_MODE]: layout })
      state.layout = layout
    },
    [TOGGLE_FIXED_HEADER]: (state, fixed) => {
      cache({ [TOGGLE_FIXED_HEADER]: fixed })
      state.fixedHeader = fixed
    },
    [TOGGLE_FIXED_SIDERBAR]: (state, fixed) => {
      cache({ [TOGGLE_FIXED_SIDERBAR]: fixed })
      state.fixSiderbar = fixed
    },
    [TOGGLE_CONTENT_WIDTH]: (state, type) => {
      cache({ [TOGGLE_CONTENT_WIDTH]: type })
      state.contentWidth = type
    },
    [TOGGLE_COLOR]: (state, color) => {
      cache({ [TOGGLE_COLOR]: color })
      state.color = color
    },
    [TOGGLE_MULTI_TAB]: (state, bool) => {
      cache({ [TOGGLE_MULTI_TAB]: bool })
      state.multiTab = bool
    },
    [SET_SETTING_DRAWER]: (state, type) => {
      state.showSettings = type
    },
    [TAB_PAGES_CLOSE]: (state, closePageTab) => {
      state.closePageTab = closePageTab
    },
    [TAB_PAGES_CACHED]: (state, cachedViews) => {
      state.cachedViews = cachedViews
    }
  },
  actions: {
    async addCachedView({ commit, state }: ActionContext<any, unknown>, view: any) {
      if (state.cachedViews.includes(view.name)) {
        return Promise.resolve('')
      }
      if (!view.meta.noCache) {
        state.cachedViews.push(view.name)
      }
      return Promise.resolve('')
    }
  }
}

function cache(o) {
  ls.setObj(SITE_SETTINGS, o)
}

export default app
