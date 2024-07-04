//ブラウザーのタブ名称を変更
import config from '@/config/default-settings'

export const setDocumentTitle = function (to) {
  if (config.dynamicBrowserTab) {
    const title = to?.meta?.title
    if (!title) return
    document.title = (title ? title + ' - ' : '') + config.title

    const ua = navigator.userAgent
    const regex = /\bMicroMessenger\/([\d\.]+)/
    if (regex.test(ua) && /ip(hone|od|ad)/i.test(ua)) {
      const i = document.createElement('iframe')
      i.src = '/favicon.ico'
      i.style.display = 'none'
      i.onload = function () {
        setTimeout(function () {
          i.remove()
        }, 9)
      }
      document.body.appendChild(i)
    }
  }
}
