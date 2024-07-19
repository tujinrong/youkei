import { login } from '../request/common-service'
import { request } from '../request'
import { encryptBySHA256 } from '@/utils/encrypt/data'
/**
 * Login
 *
 * @param userName User name
 * @param password Password
 */
export function fetchLogin(userName: string, password: string) {
  return request<Api.Auth.LoginToken>({
    url: '/auth/login',
    method: 'post',
    data: {
      userName,
      password,
    },
  })
}
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

/**
 * Refresh token
 *
 * @param refreshToken Refresh token
 */
export function fetchRefreshToken(refreshToken: string) {
  return request<Api.Auth.LoginToken>({
    url: '/auth/refreshToken',
    method: 'post',
    data: {
      refreshToken,
    },
  })
}

/**
 * return custom backend error
 *
 * @param code error code
 * @param msg error message
 */
export function fetchCustomBackendError(code: string, msg: string) {
  return request({ url: '/auth/error', params: { code, msg } })
}
