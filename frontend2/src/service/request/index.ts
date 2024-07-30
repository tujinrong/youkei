import { BACKEND_ERROR_CODE, createRequest } from '@sa/axios'
import { useAuthStore } from '@/store/modules/auth'
import { localStg } from '@/utils/storage'
import { getServiceBaseURL } from '@/utils/service'
import { showErrorMsg } from './shared'
import type { RequestInstanceState } from './type'
import { EnumServiceResult } from '@/enum'
import { showConfirmModal, showInfoModal } from '@/utils/modal'
import { Modal } from 'ant-design-vue'
import { CM_LOGINTIMEOUT_ERROR } from '@/constants/msg'
import { router } from '@/router'
import type { InternalAxiosRequestConfig } from 'axios'

const isHttpProxy =
  import.meta.env.DEV && import.meta.env.VITE_HTTP_PROXY === 'Y'
const { baseURL, otherBaseURL } = getServiceBaseURL(
  import.meta.env,
  isHttpProxy
)

type RequestConfig = InternalAxiosRequestConfig & {
  extra?: {
    onNextOk?: (data?: DaResponseBase) => void
    onNextCancel?: (data?: DaResponseBase) => void
  }
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

      const token = localStg.get('token')
      const authStore = useAuthStore()
      // const userid = authStore.userInfo.userName
      // Object.assign(headers, { token, userid })
      Object.assign(headers, { token })

      return config
    },
    isBackendSuccess(response) {
      return response.data.returncode === EnumServiceResult.OK
    },
    async onBackendFail(response, instance) {
      const { extra } = response.config as RequestConfig
      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      const { data } = response
      const message = data?.message
      const code = data?.returncode
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
      // when the request is fail, you can show error message
      const authStore = useAuthStore()
      function handleLogout() {
        authStore.resetStore()
      }

      let message = error.message
      // get backend error message and code
      if (error.code === BACKEND_ERROR_CODE) {
        message = error.response?.data?.message || message
      } else {
        showErrorMsg(request.state, message)
      }

      if (error.response?.status === 401) {
        Modal.destroyAll()
        showInfoModal({
          type: 'warning',
          content: CM_LOGINTIMEOUT_ERROR.Msg,
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
