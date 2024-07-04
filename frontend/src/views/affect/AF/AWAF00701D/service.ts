/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 宛名検索履歴
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.03.17
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SearchRequest, SaveRequest } from './type'
const servicename = 'AWAF00701D'

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
