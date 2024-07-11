/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 宛名番号
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.04.01
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, SearchResponse, SearchRequest } from './type'
const servicename = 'AWAF00705D'

/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
