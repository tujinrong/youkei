/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 計算定義(共通フレーム)
 * 　　　　　  データストア設定
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { computed } from 'vue'
import store from '@/store'
import { MenuType } from '#/Enums'
const state = store.state

export const layoutMode = computed(() => state.app.layout)
export const primaryColor = computed(() => state.app.color)
export const fixedHeader = computed(() => state.app.fixedHeader)
export const fixSiderbar = computed(() => state.app.fixSiderbar)
export const fixSidebar = computed(() => state.app.fixSiderbar)
export const contentWidth = computed(() => state.app.contentWidth)
export const sidebarOpened = computed(() => state.app.sidebar)
export const multiTab = computed(() => state.app.multiTab)
export const closePageTab = computed(() => state.app.closePageTab)

export const isTopMenu = () => layoutMode.value === MenuType.Top
export const isSideMenu = () => layoutMode.value === MenuType.Side
