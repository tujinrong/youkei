// axios構成、設定  プロジェクトに応じて自分で変更を加えることができます。このファイルを変更するだけで、他のファイルは変更しないでおくことができます。
import { VAxios } from './Axios'
import type { AxiosTransform } from './axios-transform'
import axios from 'axios'
import type { AxiosResponse } from 'axios'
import { checkStatus } from './check-status'
import { Modal, message as Message } from 'ant-design-vue'
import { RequestEnum, ContentTypeEnum, EnumServiceResult } from '#/Enums'
import { serialize } from 'xe-utils'
import { isString } from '@/utils/is/index'
import type { RequestOptions, Result } from './types'
import router from '@/router'
import { getUserToken, getUserInfo } from '@/utils/user'
import UAParser from 'ua-parser-js'
import { showConfirmModal, showInfoModal } from '@/utils/modal'
import { ss } from '@/utils/storage'
import { REGSISYO } from '@/constants/mutation-types'
import { CM_DBTIMEOUT_ERROR, CM_HTTP_ERROR, E001008 } from '@/constants/msg'
import { GlobalStore } from '@/store'
/**
 * @description: データ処理、さまざまな処理方法を簡単に区別
 */
const transform: AxiosTransform = {
  /**
   * @description: リクエストデータを処理する
   */
  transformRequestData: (res: AxiosResponse<Result>, options: RequestOptions) => {
    const { data } = res
    const message = data?.message
    const code = data?.returncode
    // リクエストは成功しました
    const hasSuccess = data && Reflect.has(data, 'code') && code === EnumServiceResult.OK

    if (!data) {
      // return '[HTTP] Request has no return value';
      return Promise.reject(data)
    }

    // インターフェイス要求は成功し、結果が直接返されます
    if (code === EnumServiceResult.OK) {
      return data
    }
    // インターフェイス要求が間違っている場合、統一されたエラーメッセージが表示されます。
    if (code === EnumServiceResult.ServiceError) {
      showInfoModal({
        type: 'error',
        content: message,
        onOk: () => options.onNextOk?.(data)
      })
      return Promise.reject(message)
    }
    if (code === EnumServiceResult.ServiceAlert) {
      showConfirmModal({
        title: 'アラート',
        content: message,
        onOk: () => options.onNextOk?.(data),
        onCancel: () => options.onNextCancel?.(data)
      })
      return Promise.reject(message)
    }
    if (code === EnumServiceResult.ServiceAlert2) {
      showInfoModal({
        type: 'warning',
        content: message,
        onOk: () => options.onNextOk?.(data)
      })
      return Promise.reject(message)
    }
    if (code == EnumServiceResult.Hidden) {
      return Promise.reject()
    }
    if (code === EnumServiceResult.Exception) {
      showInfoModal({
        title: '例外',
        type: 'error',
        content: message
      })
      return Promise.reject(message)
    }
    if (code === EnumServiceResult.AuthError) {
      Modal.destroyAll()
      showConfirmModal({
        title: 'エラー',
        content: 'ホームページに戻りますか？',
        onOk: () => {
          router.replace({
            path: '/index'
          })
        }
      })
      return Promise.reject()
    }
    if (code === EnumServiceResult.InterruptionError) {
      showInfoModal({
        title: 'エラー',
        type: 'error',
        content: message,
        onOk: () => {
          options.onNextOk ? options.onNextOk?.(data) : router.back()
        }
      })
      return Promise.reject(message)
    }

    // このロジックは、プロジェクトに応じて変更できます
    if (!hasSuccess) {
      if (message) {
        Message.error({
          content: message || '失敗！',
          duration: 5,
          style: {
            'white-space': 'pre-wrap'
          },
          key: message || '失敗！'
        })
      }
      return Promise.reject(message)
    }
    return data
  },

  beforeRequestHook: (config, options) => {
    const { apiUrl } = options
    // config.url = IS_DEV ? `/api${config.url}` : `${apiUrl || ''}${config.url}`
    config.url = `${apiUrl || ''}${config.url}`

    if (config.method === RequestEnum.GET) {
      const now = new Date().getTime()
      if (!isString(config.params)) {
        config.data = {
          //キャッシュからデータを取得しないように、リクエストをgetするためのタイムスタンプパラメータを追加します 。
          params: Object.assign(config.params || {}, {
            _t: now
          })
        }
      } else {
        config.url = config.url + config.params + `?_t=${now}`
        config.params = {}
      }
    } else {
      if (!isString(config.params)) {
        config.data = config.params
        config.params = {}
      } else {
        config.url = config.url + config.params
        config.params = {}
      }
    }
    return config
  },
  /**
   * @description: responseインターセプター処理
   */
  responseInterceptors: (response) => {
    if (response.data.message) {
      response.data.message = response.data.message.replace(/\\n/g, '\n')
    }
    if (response.config.headers?.loading) {
      GlobalStore.setLoading(false)
    }
    return response
  },
  /**
   * @description: リクエストインターセプター処理
   */
  requestInterceptors: (config) => {
    // リクエスト前に config を処理する
    const token = getUserToken()
    const userInfo = getUserInfo()

    if (config.headers) {
      // jwt token
      if (token) {
        if (userInfo) {
          config.headers.userid = userInfo.userid
          config.headers.regsisyo = ss.get(REGSISYO).sisyocd
        }
        config.headers.token = token
      }

      //get info from user-agent
      const parser = new UAParser()
      config.headers.os = JSON.stringify(parser.getOS())
      config.headers.browser = JSON.stringify(parser.getBrowser())

      //機能ID(画面)
      config.headers.kinoid = router.currentRoute.value.name
      //loading
      if (config.headers.loading) {
        GlobalStore.setLoading(true)
      }
    }

    return config
  },

  /**
   * @description: 応答エラー処理
   */
  responseInterceptorsCatch: (error: any) => {
    const { response, code, message } = error || {}
    const msg: string = response?.data?.error?.message || response?.data?.message || ''
    GlobalStore.setLoading(false)

    try {
      if (code === 'ECONNABORTED' && message.indexOf('timeout') !== -1) {
        // Message.error(CM_DBTIMEOUT_ERROR.Msg)
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: CM_DBTIMEOUT_ERROR.Msg
        })
        return
      }
      if (code === 'ERR_NETWORK') {
        showInfoModal({
          type: 'error',
          content: CM_HTTP_ERROR.Msg
        })
        return
      }
    } catch (error: any) {
      throw new Error(error)
    }
    // リクエストがキャンセルされたかどうか
    const isCancel = axios.isCancel(error)
    // if (!isCancel) {
    //   checkStatus(error.response && error.response.status, msg)
    // } else {
    //   console.warn(error, 'リクエストがキャンセルされました！')
    // }
    return error
  }
}

const Axios = new VAxios({
  timeout: 60 * 10000,
  // ベース インターフェイス アドレス
  // baseURL: globSetting.apiUrl,
  headers: { 'Content-Type': ContentTypeEnum.JSON },
  // データ処理方法
  transform,
  requestOptions: {
    // インターフェイス path
    apiUrl:
      import.meta.env.VITE_APP_API_URL ??
      `${window.location.protocol}//${window.location.hostname}${
        window.location.port ? `:${window.location.port}` : ''
      }/api`
  },
  withCredentials: false
})

export default Axios
