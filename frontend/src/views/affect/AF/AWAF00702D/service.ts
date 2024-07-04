/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 医療機関検索
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.03.17
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SearchRequest } from './type'
const servicename = 'AWAF00702D'

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
