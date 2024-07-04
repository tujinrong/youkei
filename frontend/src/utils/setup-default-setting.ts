import { ls } from './storage'
import {
  SITE_SETTINGS,
  TOGGLE_COLOR,
  TOGGLE_FIXED_SIDERBAR,
  TOGGLE_FIXED_HEADER,
  TOGGLE_MULTI_TAB
} from '@/constants/mutation-types'
import store from '@/store'
import config from '@/config/default-settings'
import { ConfigProvider } from 'ant-design-vue'

export default (): void => {
  const siteSettings = ls.get(SITE_SETTINGS)
  if (siteSettings) {
    siteSettings[TOGGLE_FIXED_SIDERBAR] = config.fixSiderbar
    siteSettings[TOGGLE_FIXED_HEADER] = config.fixedHeader
    siteSettings[TOGGLE_MULTI_TAB] = config.multiTab
    for (const s in siteSettings) {
      // Set the theme color if there is one
      if (s === TOGGLE_COLOR && siteSettings[TOGGLE_COLOR]) {
        ConfigProvider.config({
          theme: {
            primaryColor: siteSettings[TOGGLE_COLOR]
          }
        })
      }

      store.commit(s, siteSettings[s])
    }
  }
}
