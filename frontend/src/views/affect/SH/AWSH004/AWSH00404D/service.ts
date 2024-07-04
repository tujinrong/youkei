/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 対象サイン
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.27
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchRequest, SearchResponse } from './type'
const servicename = 'AWSH00404D'

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
