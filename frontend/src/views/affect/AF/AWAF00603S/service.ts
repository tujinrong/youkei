/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 共通バー情報
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.04.17
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest } from './type'
const servicename = 'AWAF00603S'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}
