import { login, api } from '../request/common-service'
import { encryptBySHA256 } from '@/utils/encrypt/data'

const servicename = 'AWAF00101G'

/** ログイン処理 */
export const Login = (
  data: Api.Auth.LoginRequest
): Promise<Api.Auth.LoginResponse> => {
  const params = JSON.parse(JSON.stringify(data))
  //パスワード暗号化
  params.pword = encryptBySHA256(data.pword, data.userid)
  const methodname = 'Login'
  return login(servicename, methodname, params)
}

export const fetchGetUserInfo = (): Promise<Api.Auth.UserInfo> => {
  const methodname = 'GetUserInfo'
  return api(servicename, methodname, {})
}
