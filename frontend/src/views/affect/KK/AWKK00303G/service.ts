/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 集団指導管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.29
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitDetailResponse,
  SearchListResponse,
  SearchListRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SearchSankasyaListResponse,
  SearchSankasyaListRequest,
  CommonResponse,
  SaveRequest,
  DeleteRequest,
  SearchSankasyaDetailResponse,
  SearchSankasyaDetailRequest,
  SaveSankasyaRequest,
  DeleteSankasyaRequest
} from './type'
const servicename = 'AWKK00303G'

/** 初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, {})
}

/** 集団一覧画面検索処理(検索画面) */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params, {}, onNextOk)
}

/** 指導情報検索処理 */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 参加者情報検索処理 */
export const SearchSankasyaList = (
  params: SearchSankasyaListRequest
): Promise<SearchSankasyaListResponse> => {
  const methodname = 'SearchSankasyaList'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<CommonResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<CommonResponse> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** 参加者詳細画面検索処理 */
export const SearchSankasyaDetail = (
  params: SearchSankasyaDetailRequest
): Promise<SearchSankasyaDetailResponse> => {
  const methodname = 'SearchSankasyaDetail'
  return api(servicename, methodname, params)
}

/** 参加者保存処理 */
export const SaveSankasya = (params: SaveSankasyaRequest): Promise<CommonResponse> => {
  const methodname = 'SaveSankasya'
  return api(servicename, methodname, params)
}

/** 参加者削除処理 */
export const DeleteSankasya = (params: DeleteSankasyaRequest): Promise<CommonResponse> => {
  const methodname = 'DeleteSankasya'
  return api(servicename, methodname, params)
}
