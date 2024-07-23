import { login } from '../request/common-service'
import { request } from '../request'
import { encryptBySHA256 } from '@/utils/encrypt/data'

/** ログイン処理 */
export const Login = (
  data: Api.Auth.LoginRequest
): Promise<Api.Auth.LoginResponse> => {
  const params = JSON.parse(JSON.stringify(data))
  //パスワード暗号化
  params.pword = encryptBySHA256(data.pword, data.userid)
  const methodname = 'Login'
  return login('AWAF00101G', methodname, params)
}

/** Get user info */
export function fetchGetUserInfo() {
  return request<Api.Auth.UserInfo>({ url: '/auth/getUserInfo' })
}
