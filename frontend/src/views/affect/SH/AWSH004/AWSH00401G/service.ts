/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.19
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
  GetEditYoyakuResponse,
  GetEditYoyakuRequest,
  SaveRequest,
  DeleteRequest
} from './type'
const servicename = 'AWSH00401G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 編集可能予約一覧取得処理(詳細画面) */
export const GetEditYoyaku = (params: GetEditYoyakuRequest): Promise<GetEditYoyakuResponse> => {
  const methodname = 'GetEditYoyaku'
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
