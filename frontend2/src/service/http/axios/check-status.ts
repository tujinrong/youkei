import { Modal, message as Message } from 'ant-design-vue'
import { router } from '@/router'
import { useAuthStore } from '@/store/modules/auth'
import { CM_LOGINTIMEOUT_ERROR } from '@/constants/msg'
import { showInfoModal } from '@/utils/modal'
const error = Message.error

export function checkStatus(status: number, msg: string): void {
  const { resetStore } = useAuthStore()

  switch (status) {
    case 400:
      error(`${msg}`)
      break

    case 401: {
      if (router.currentRoute.value.name == 'login') return
      Modal.destroyAll()
      showInfoModal({
        type: 'warning',
        content: CM_LOGINTIMEOUT_ERROR.Msg,
        onOk: () => {
          router.replace({
            name: 'login',
            query: {
              redirect: router.currentRoute.value.fullPath,
            },
          })
          resetStore()
        },
      })
      break
    }
    case 403:
      error('ユーザーは許可されていますが、アクセスは禁止されています。')
      break
    case 404:
      error('ネットワークリクエストエラー、リソースが見つかりませんでした!')
      break
    case 405:
      error(
        'ネットワークリクエストエラー、リクエストメソッドが許可されていません!'
      )
      break
    case 408:
      error('ネットワークリクエストタイムアウト!')
      break
    case 500:
      showInfoModal({
        type: 'error',
        content: 'サーバーエラーです。管理者に連絡してください。',
      })
      break
    case 501:
      error('ネットワークが実装されていません。')
      break
    case 502:
      error('ネットワークエラー!')
      break
    case 503:
      error(
        'サービスは使用できません。サーバは一時的にオーバーロードまたはメンテナンスされます。'
      )
      break
    case 504:
      error('ネットワークタイムアウト!')
      break
    case 505:
      error('httpバージョンではリクエストはサポートされていません!')
      break
    default:
      error(msg)
  }
}
