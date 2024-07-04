/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: フォロー管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  SearchFollowListResponse,
  SearchFollowNaiyoListResponse,
  SearchFollowNaiyoListRequest,
  InitFollowNaiyoResponse,
  InitFollowNaiyoRequest,
  SearchFollowNaiyoResponse,
  SearchFollowNaiyoRequest,
  InitFollowDetailResponse,
  InitFollowDetailRequest,
  SearchFollowDetailResponse,
  SearchFollowDetailRequest,
  FollowDetailPreKekkaResponse,
  FollowDetailKekkaResponse,
  SearchFollowDetailPreKekkaRequest,
  SaveFollowNaiyoRequest,
  SaveFollowDetailRequest,
  DeleteFollowNaiyoRequest,
  DeleteFollowDetailRequest
} from './type'
const servicename = 'AWKK00401G'

/** 検索処理(管理画面) */
export const SearchFollowList = (
  params: Partial<PersonSearchRequest>,
  onNextOk?: (data?) => void
): Promise<SearchFollowListResponse> => {
  const methodname = 'SearchFollowList'
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 検索処理(内容画面) */
export const SearchFollowNaiyoList = (
  params: SearchFollowNaiyoListRequest
): Promise<SearchFollowNaiyoListResponse> => {
  const methodname = 'SearchFollowNaiyoList'
  return api(servicename, methodname, params)
}

/** 新規処理(結果画面) */
export const InitFollowNaiyo = (
  params: InitFollowNaiyoRequest
): Promise<InitFollowNaiyoResponse> => {
  const methodname = 'InitFollowNaiyo'
  return api(servicename, methodname, params)
}

/** 検索処理(結果画面) */
export const SearchFollowNaiyo = (
  params: SearchFollowNaiyoRequest
): Promise<SearchFollowNaiyoResponse> => {
  const methodname = 'SearchFollowNaiyo'
  return api(servicename, methodname, params)
}

/** 新規処理(詳細画面) */
export const InitFollowDetail = (
  params: InitFollowDetailRequest
): Promise<InitFollowDetailResponse> => {
  const methodname = 'InitFollowDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面) */
export const SearchFollowDetail = (
  params: SearchFollowDetailRequest
): Promise<SearchFollowDetailResponse> => {
  const methodname = 'SearchFollowDetail'
  return api(servicename, methodname, params)
}

/** 前回結果情報セット処理(詳細画面) */
export const SearchFollowDetailPreKekka = (
  params: SearchFollowDetailRequest
): Promise<FollowDetailPreKekkaResponse> => {
  const methodname = 'SearchFollowDetailPreKekka'
  return api(servicename, methodname, params)
}

/** 予定情報セット処理(詳細画面) */
export const SearchFollowDetailKekka = (
  params: SearchFollowDetailPreKekkaRequest
): Promise<FollowDetailKekkaResponse> => {
  const methodname = 'SearchFollowDetailKekka'
  return api(servicename, methodname, params)
}

/** 保存処理(結果画面) */
export const SaveFollowNaiyo = (params: SaveFollowNaiyoRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveFollowNaiyo'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面) */
export const SaveFollowDetail = (params: SaveFollowDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveFollowDetail'
  return api(servicename, methodname, params)
}

/** 削除処理(結果画面) */
export const DeleteFollowNaiyo = (params: DeleteFollowNaiyoRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteFollowNaiyo'
  return api(servicename, methodname, params)
}

/** 削除処理(詳細画面) */
export const DeleteFollowDetail = (params: DeleteFollowDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteFollowDetail'
  return api(servicename, methodname, params)
}
