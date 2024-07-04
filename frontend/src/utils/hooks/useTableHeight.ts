import { MenuType } from '#/Enums'
import { layoutMode, multiTab } from '@/store/use-site-settings'
import { useElementSize, useWindowSize } from '@vueuse/core'
import { Ref, computed } from 'vue'
import config from '@/config/default-settings'

/**
 * 表の高さ
 * @param {booble} element header Ref
 * @param {string} offset オフセット値
 */
export default function useTableHeight(element: Ref<any> | null = null, offset = 0) {
  const { height } = useElementSize(element)

  const bodyHeight = computed(() => {
    const { height } = useWindowSize()
    if (multiTab.value && layoutMode.value == MenuType.Top) {
      return height.value - 140 - config.headerTabHeight
    }
    return height.value - 140
  })

  const tableHeight = computed(() => bodyHeight.value - height.value + offset)

  return {
    tableHeight,
    bodyHeight
  }
}
