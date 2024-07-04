/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 履歴照会
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.10.12
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SearchRequest } from './type'

/** 検索処理 */
export const Search = (servicename: string, params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
