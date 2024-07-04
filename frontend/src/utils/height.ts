//高さ計算
import { multiTab, layoutMode, sidebarOpened } from '@/store/use-site-settings'
import { MenuType } from '#/Enums'
import config from '@/config/default-settings'
import { computed } from 'vue'

export function getHeight(h: number): string {
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
}

/** Responsive  */
export const XXL = 1600
export const XL = 1200
export const LG = 992
export const MD = 768
export const SM = 576

//共通バー 左側px
export const barLeft = computed(() => {
  if (layoutMode.value == MenuType.Top) {
    return '0'
  } else {
    if (sidebarOpened.value) {
      return '256px'
    }
    return '80px'
  }
})
