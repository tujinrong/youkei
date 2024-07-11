/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 詳細条件検索
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.08.30
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest } from './type'
const servicename = 'AWAF00703D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}
