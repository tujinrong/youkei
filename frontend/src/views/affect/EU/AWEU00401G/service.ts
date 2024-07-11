/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 *
 * 作成日　　: 2023.10.31
 * 作成者　　: 王
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, SearchResponse, SearchRequest } from './type'
const servicename = 'AWEU00401G'

/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}
