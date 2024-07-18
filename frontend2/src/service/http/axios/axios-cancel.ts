import axios, { AxiosRequestConfig, Canceler } from 'axios'
import qs from 'qs'

import { isFunction } from '@/utils/is'

// 各リクエストのIDとキャンセル機能を保存するマップを宣言します
let pendingMap = new Map<string, Canceler>()

export const getPendingUrl = (config: AxiosRequestConfig) =>
  [
    config.method,
    config.url,
    qs.stringify(config.data),
    qs.stringify(config.params),
  ].join('&')

export class AxiosCanceler {
  /**
   * リクエストを追加
   * @param {Object} config
   */
  addPending(config: AxiosRequestConfig) {
    this.removePending(config)
    const url = getPendingUrl(config)
    config.cancelToken =
      config.cancelToken ||
      new axios.CancelToken((cancel) => {
        if (!pendingMap.has(url)) {
          // 保留中の現在のリクエストがない場合は、追加します
          pendingMap.set(url, cancel)
        }
      })
  }

  /**
   * @description: 保留中のすべてをクリア
   */
  removeAllPending() {
    pendingMap.forEach((cancel) => {
      cancel && isFunction(cancel) && cancel()
    })
    pendingMap.clear()
  }

  /**
   * 削除リクエスト
   * @param {Object} config
   */
  removePending(config: AxiosRequestConfig) {
    const url = getPendingUrl(config)

    if (pendingMap.has(url)) {
      // 現在のリクエストIDが保留中の場合は、現在のリクエストをキャンセルして削除する必要があります
      const cancel = pendingMap.get(url)
      cancel && cancel(url)
      pendingMap.delete(url)
    }
  }

  /**
   * @description: リセット
   */
  reset(): void {
    pendingMap = new Map<string, Canceler>()
  }
}
