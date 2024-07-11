/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メモ情報
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.08.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest, SearchResponse, SearchRequest, SaveRequest } from './type'
const servicename = 'AWAF00601D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
