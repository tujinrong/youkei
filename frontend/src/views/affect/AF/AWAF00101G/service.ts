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
  return new Promise((resolve) => {
    resolve({
      token: null,
      userinfo: null,
      sisyolist: [
        {
          sisyocd: "0",
          sisyonm: "支所000"
        },
        {
          sisyocd: "1",
          sisyonm: "支所001"
        }
      ],
      pwdmsgflg: false,
      returncode: 0,
      message: null,
      rsaprivatekey: null
    });
  });
}

export const Login2 = (data: LoginRequest): Promise<LoginResponse> => {
  return new Promise((resolve) => {
    resolve({
      token: "26rXIyqePDMo9ujJ4CY2aw==",
      userinfo: { 
        userid: "1",
        usernm: "スーパー管理",
        syozokunm: "",
        kanrisyaflg: true
      },
      sisyolist: null,
      pwdmsgflg: false,
      returncode: 0,
      message: null,
      rsaprivatekey: null
    });
  });
}
