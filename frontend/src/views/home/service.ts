/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: ホーム
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.07.26
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { InitResponse } from './type'

const servicename = 'GJ0000'

/** 取得処理(ホーム画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Home'
  const params = undefined
  return api(servicename, methodname, params, undefined, { loading: true })
}
