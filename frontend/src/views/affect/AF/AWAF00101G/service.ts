/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログイン
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.02.22
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { login } from '@/utils/http/common-service'
import { LoginRequest, LoginResponse } from './type'
import { encryptBySHA256 } from '@/utils/encrypt/data'
const servicename = 'AWAF00101G'

/** ログイン処理 */
export const Login = (data: LoginRequest): Promise<LoginResponse> => {
  const params = JSON.parse(JSON.stringify(data))
  //パスワード暗号化
  params.pword = encryptBySHA256(data.pword, data.userid)
  const methodname = 'Login'
  return login(servicename, methodname, params)
}
