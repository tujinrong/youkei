import { login, api } from '../request/common-service'
import { encryptBySHA256 } from '@/utils/encrypt/data'

const servicename = 'GJ0000'

/** ログイン処理 */
export const Login = (
  data: Api.Auth.LoginRequest
): Promise<Api.Auth.LoginResponse> => {
  const params = JSON.parse(JSON.stringify(data))
  //パスワード暗号化
  params.PASS = encryptBySHA256(data.PASS, data.USER_ID)
  const methodname = 'Login'
  return login(servicename, methodname, params)
}

export const fetchGetUserInfo = (): Promise<Api.Auth.UserInfo> => {
  const methodname = 'GetUserInfo'
  return api(servicename, methodname, {})
}
