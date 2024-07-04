/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 保健指導詳細検索設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.06
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SaveRequest } from './type'
const servicename = 'AWKK00806D'

/** 検索処理 */
export const Search = (): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, {})
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
