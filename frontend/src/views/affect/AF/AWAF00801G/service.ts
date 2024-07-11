/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 汎用情報保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitMainCodeResponse,
  InitMainCodeRequest,
  InitSubCodeResponse,
  InitSubCodeRequest,
  SearchResponse,
  SearchRequest,
  SaveRequest,
  InitSubCodeInfoResponse,
  SaveSubCodeInfoRequest
} from './type'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
const servicename = 'AWAF00801G'

/** メインコード初期化処理 */
export const InitMainCode = (params: InitMainCodeRequest): Promise<InitMainCodeResponse> => {
  const methodname = 'InitMainCode'
  return api(servicename, methodname, params)
}

/** サブコード初期化処理 */
export const InitSubCode = (params: InitSubCodeRequest): Promise<InitSubCodeResponse> => {
  const methodname = 'InitSubCode'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params)
}

/** サブコード情報登録(初期処理) */
export const InitSubCodeInfo = (params: SearchRequest): Promise<InitSubCodeInfoResponse> => {
  const methodname = 'InitSubCodeInfo'
  return api(servicename, methodname, params)
}

/** サブコード情報登録(保存処理) */
export const SaveSubCodeInfo = (params: SaveSubCodeInfoRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveSubCodeInfo'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
