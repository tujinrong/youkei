/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 料金内訳
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.26
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SearchRequest } from './type'
const servicename = 'AWSH00403D'

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
