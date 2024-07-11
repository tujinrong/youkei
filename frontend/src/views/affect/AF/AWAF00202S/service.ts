/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 使用履歴
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.02.22
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SaveRequest } from './type'
const servicename = 'AWAF00202S'

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
