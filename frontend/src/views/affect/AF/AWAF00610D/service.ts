/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健（検）診結果・保健指導履歴照会
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.14
 * 作成者　　: 張加恒
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchSeniRequest, SearchRequest, SearchResponse, SearchSeniResponse } from './type'
const servicename = 'AWAF00610D'

/** 遷移処理 */
export const SearchSeni = (params: SearchSeniRequest): Promise<SearchSeniResponse> => {
  const methodname = 'SearchSeni'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
