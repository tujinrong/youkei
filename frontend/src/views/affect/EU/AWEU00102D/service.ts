/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: データグループ新規作成
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.04.11
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, SearchResponse, SearchRequest, SaveRequest } from './type'
const servicename = 'AWEU00102D'

/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {}, { loading: true })
}

/** メインテーブル選択変更時検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
