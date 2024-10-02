import {
  BACKEND_ERROR_CODE,
  createDownloadRequest,
  createRequest,
} from '@sa/axios'
import { useAuthStore } from '@/store/modules/auth'
import { sessionStg } from '@/utils/storage'
import { getServiceBaseURL } from '@/utils/service'
import { showErrorMsg } from './shared'
import type { RequestInstanceState } from './type'
import { EnumServiceResult } from '@/enum'
import { showConfirmModal, showInfoModal } from '@/utils/modal'
import { Modal } from 'ant-design-vue'
import { CM_AUTH_ERROR } from '@/constants/msg'
import { router } from '@/router'
import type { InternalAxiosRequestConfig } from 'axios'
import { useAppStore } from '@/store/modules/app'

const isHttpProxy =
  import.meta.env.DEV && import.meta.env.VITE_HTTP_PROXY === 'Y'
const { baseURL, otherBaseURL } = getServiceBaseURL(
  import.meta.env,
  isHttpProxy
)

type RequestConfig = InternalAxiosRequestConfig & {
  extra?: Api.Common.RequestConfigExtra
}

export const request = createRequest<
  App.Service.Response,
  RequestInstanceState
>(
  {
    baseURL,
    timeout: 18 * 60 * 10000,
    headers: {
      //
    },
  },
  {
    async onRequest(config) {
      const { headers } = config

      const token = sessionStg.get('token')
      Object.assign(headers, { token })

      //Global Loading
      const { extra } = config as RequestConfig
      if (extra?.loading) {
        const appStore = useAppStore()
        appStore.setLoading(true)
      }

      return config
    },
    isBackendSuccess(response) {
      closeGlobalLoading(response.config)

      return response.data.RETURN_CODE === EnumServiceResult.OK
    },
    async onBackendFail(response, instance) {
      closeGlobalLoading(response.config)

      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      const { extra } = response.config as RequestConfig
      const { data } = response
      const message = data?.MESSAGE
      const code = data?.RETURN_CODE
      // インターフェイス要求が間違っている場合、統一されたエラーメッセージが表示されます。
      if (code === EnumServiceResult.ServiceError) {
        showInfoModal({
          type: 'error',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
        })
      } else if (code === EnumServiceResult.ServiceAlert) {
        showConfirmModal({
          title: 'アラート',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
          onCancel: () => extra?.onNextCancel?.(data),
        })
      } else if (code === EnumServiceResult.ServiceAlert2) {
        showInfoModal({
          type: 'warning',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
        })
      } else if (code === EnumServiceResult.Exception) {
        showInfoModal({
          title: '例外',
          type: 'error',
          content: message,
        })
      } else if (code === EnumServiceResult.AuthError) {
        Modal.destroyAll()
        handleLogout()
      } else if (code === EnumServiceResult.InterruptionError) {
        Modal.destroyAll()
        showInfoModal({
          title: 'エラー',
          type: 'error',
          content: message,
          onOk: () => {
            extra?.onNextOk ? extra?.onNextOk?.(data) : router.back()
          },
        })
      }
      return null
    },
    transformBackendResponse(response) {
      return response.data
    },
    onError(error) {
      closeGlobalLoading(error.response?.config)

      // when the request is fail, you can show error message
      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      let message = error.message
      // get backend error message and code
      if (error.code === BACKEND_ERROR_CODE) {
        message = error.response?.data?.MESSAGE || message
      } else {
        showErrorMsg(request.state, message)
      }

      if (error.response?.status === 401) {
        Modal.destroyAll()
        showInfoModal({
          type: 'warning',
          content: CM_AUTH_ERROR.Msg,
          onOk: () => handleLogout(),
        })
      }
      if (error.response?.status === 500) {
        showInfoModal({
          type: 'error',
          content: 'サーバーエラーです。管理者に連絡してください。',
        })
      }
    },
  }
)

export const downloadReq = createDownloadRequest<any, RequestInstanceState>(
  {
    baseURL,
    timeout: 18 * 60 * 10000,
    headers: {
      //
    },
  },
  {
    async onRequest(config) {
      const { headers } = config
      config.responseType = 'blob'
      const token = sessionStg.get('token')
      Object.assign(headers, { token })
      config.headers['Accept'] = 'application/stream'

      //Global Loading
      const { extra } = config as RequestConfig
      if (extra?.loading) {
        const appStore = useAppStore()
        appStore.setLoading(true)
      }

      return config
    },
    isBackendSuccess(response) {
      closeGlobalLoading(response.config)

      return response.data.RETURN_CODE === EnumServiceResult.OK
    },
    async onBackendFail(response, instance) {
      closeGlobalLoading(response.config)

      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      const { extra } = response.config as RequestConfig
      const { data } = response
      const message = data?.MESSAGE
      const code = data?.RETURN_CODE
      // インターフェイス要求が間違っている場合、統一されたエラーメッセージが表示されます。
      if (code === EnumServiceResult.ServiceError) {
        showInfoModal({
          type: 'error',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
        })
      } else if (code === EnumServiceResult.ServiceAlert) {
        showConfirmModal({
          title: 'アラート',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
          onCancel: () => extra?.onNextCancel?.(data),
        })
      } else if (code === EnumServiceResult.ServiceAlert2) {
        showInfoModal({
          type: 'warning',
          content: message,
          onOk: () => extra?.onNextOk?.(data),
        })
      } else if (code === EnumServiceResult.Exception) {
        showInfoModal({
          title: '例外',
          type: 'error',
          content: message,
        })
      } else if (code === EnumServiceResult.AuthError) {
        Modal.destroyAll()
        handleLogout()
      } else if (code === EnumServiceResult.InterruptionError) {
        Modal.destroyAll()
        showInfoModal({
          title: 'エラー',
          type: 'error',
          content: message,
          onOk: () => {
            extra?.onNextOk ? extra?.onNextOk?.(data) : router.back()
          },
        })
      }
      return null
    },
    transformBackendResponse(response) {
      return response
    },
    onError(error) {
      closeGlobalLoading(error.response?.config)

      // when the request is fail, you can show error message
      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      let message = error.message
      // get backend error message and code
      if (error.code === BACKEND_ERROR_CODE) {
        message = error.response?.data?.MESSAGE || message
      } else {
        showErrorMsg(request.state, message)
      }

      if (error.response?.status === 401) {
        Modal.destroyAll()
        showInfoModal({
          type: 'warning',
          content: CM_AUTH_ERROR.Msg,
          onOk: () => handleLogout(),
        })
      }
      if (error.response?.status === 500) {
        showInfoModal({
          type: 'error',
          content: 'サーバーエラーです。管理者に連絡してください。',
        })
      }
    },
  }
)

//close global loading
function closeGlobalLoading(config?: InternalAxiosRequestConfig) {
  if (!config) return

  const { extra } = config as RequestConfig
  if (extra?.loading) {
    const appStore = useAppStore()
    appStore.setLoading(false)
  }
}
