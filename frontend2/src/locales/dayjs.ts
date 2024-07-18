import { locale } from 'dayjs'
import 'dayjs/locale/ja'
import 'dayjs/locale/en'
import { localStg } from '@/utils/storage'

/**
 * Set dayjs locale
 *
 * @param lang
 */
export function setDayjsLocale(lang: App.I18n.LangType = 'ja-JP') {
  const localMap = {
    'ja-JP': 'ja',
    'en-US': 'en',
  } satisfies Record<App.I18n.LangType, string>

  const l = lang || localStg.get('lang') || 'ja-JP'

  locale(localMap[l])
}
