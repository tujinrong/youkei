/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者検索
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.10.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, SearchRequest, SearchResponse } from './type'
const servicename = 'AWAF00704D'

/** 初期化処理(一覧画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
