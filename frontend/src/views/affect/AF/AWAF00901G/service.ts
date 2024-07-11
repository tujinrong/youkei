/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.14
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  InitDetailResponse,
  InitDetailRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SaveRequest
} from './type'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'

const servicename = 'AWAF00901G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理 */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest, onNextOk?: (data?) => void): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, onNextOk)
}
