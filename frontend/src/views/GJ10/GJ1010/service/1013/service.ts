/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  InitDetailRequest,
  InitDetailResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'GJ1013'

/** 検索処理_詳細画面 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, undefined, { loading: true })
}
export const InitDetail = (
  params: InitDetailRequest
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}
/** 保存処理_詳細画面 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
