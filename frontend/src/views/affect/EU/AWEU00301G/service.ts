// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { api } from '@/utils/http/common-service'
import {
  InitResponse,
  SearchRequest,
  SearchResponse,
  DetailSearchRequest,
  YosikiInfoRequest,
  InitDetailRequest,
  InitDetailResponse,
  SearchDetailResponse,
  YosikiInfoResponse,
  ChangeTyusyutunaiyoRequest,
  ChangeTyusyutunaiyoResponse,
  GetTargetItemValueRequest,
  GetTargetItemValueResponse
} from './type'

const servicename = 'AWEU00301G'

/** 初期化処理(一覧画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/**検索処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/**初期化処理(出力画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, { loading: true })
}

/**抽出内容が変更時処理 */
export const ChangeTyusyutunaiyo = (
  params: ChangeTyusyutunaiyoRequest
): Promise<ChangeTyusyutunaiyoResponse> => {
  const methodname = 'ChangeTyusyutunaiyo'
  return api(servicename, methodname, params)
}

/**検索押下処理(出力画面) */
export const SearchDetail = (params: DetailSearchRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params, { loading: true })
}

/**様式情報の取得 */
export const GetYosikiInfo = (params: YosikiInfoRequest): Promise<YosikiInfoResponse> => {
  const methodname = 'GetYosikiInfo'
  return api(servicename, methodname, params, { loading: true })
}

/**参照元項目入力後参照先項目の選択リストを取得する処理 */
export const GetTargetItemValue = (
  params: GetTargetItemValueRequest
): Promise<GetTargetItemValueResponse> => {
  const methodname = 'GetTargetItemValue'
  return api(servicename, methodname, params)
}
