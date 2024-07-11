/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 項目ツリー参照
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.04.19
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchRequest, SearchResponse } from './type'
const servicename = 'AWEU00107D'

/** 一覧項目ツリー検索処理 */
export const SearchNormalTree = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'SearchNormalTree'
  return api(servicename, methodname, params, { loading: true })
}

/**集計項目ツリー検索処理 */
export const SearchStatisticTree = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'SearchStatisticTree'
  return api(servicename, methodname, params, { loading: true })
}
