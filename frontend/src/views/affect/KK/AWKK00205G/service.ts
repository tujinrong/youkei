/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 基準値保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.1.16
 * 作成者　　: 張加恒
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  InitDetailResponse,
  InitDetailRequest,
  SearchRequest,
  GetFreeMstInfoRequest,
  GetFreeMstInfoResponse,
  SaveRequest,
  DeleteRequest
} from './type'
const servicename = 'AWKK00205G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 項目名称変更処理(詳細画面) */
export const GetFreeMstInfo = (params: GetFreeMstInfoRequest): Promise<GetFreeMstInfoResponse> => {
  const methodname = 'GetFreeMstInfo'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
