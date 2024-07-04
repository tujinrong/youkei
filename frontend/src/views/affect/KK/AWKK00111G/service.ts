/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 住登外者管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.12.04
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  InitDetailResponse,
  SearchDetailResponse,
  SearchDetailRequest,
  SearchSeisinDetailRequest,
  CommonResponse,
  SaveRequest,
  SaveSeitaiRequest,
  DeleteRequest,
  AutoSetResponse,
  AutoSetRequest,
  SearchPersonalResponse,
  SearchPersonalRequest,
  SearchAutoSaibanResponse,
  AutoSaibanRequest,
  SearchSetaiRequest,
  SearchSetaiResponse
} from './type'
const servicename = 'AWKK00111G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  // SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}
/** 初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, {})
}

/** 検索処理(詳細画面) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 世帯検索処理(詳細画面) */
export const SearchSetai = (params: SearchSetaiRequest): Promise<SearchSetaiResponse> => {
  const methodname = 'SearchSetai'
  return api(servicename, methodname, params)
}

/** 検索処理(異動処理) */
export const SearchSeisinDetail = (
  params: SearchSeisinDetailRequest
): Promise<SearchDetailResponse> => {
  const methodname = 'SearchSeisinDetail'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest, onNextOk?: (data?) => void): Promise<CommonResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, onNextOk)
}

/** 世帯更新処理 */
export const SaveSeitai = (params: SaveSeitaiRequest): Promise<CommonResponse> => {
  const methodname = 'SaveSeitai'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<CommonResponse> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** 検索処理(郵便情報) */
export const SearchYubin = (params: AutoSetRequest): Promise<AutoSetResponse> => {
  const methodname = 'SearchYubin'
  return api(servicename, methodname, params)
}

/** 検索処理(個人番号) */
export const SearchPersonal = (params: SearchPersonalRequest): Promise<SearchPersonalResponse> => {
  const methodname = 'SearchPersonal'
  return api(servicename, methodname, params)
}

/** 検索処理(自動付番) */
export const AutoSaisin = (params: AutoSaibanRequest): Promise<SearchAutoSaibanResponse> => {
  const methodname = 'AutoSaisin'
  return api(servicename, methodname, params)
}
