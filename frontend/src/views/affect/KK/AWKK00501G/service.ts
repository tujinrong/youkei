/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業実施報告書
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.12.11
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
  SaveResponse,
  SearchRowResponse,
  SearchRowRequest,
  SaveRequest,
  DeleteRequest
} from './type'
const servicename = 'AWKK00501G'

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
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, {})
}

/** 検索処理(詳細画面) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面) */
export const SearchRow = (params: SearchRowRequest): Promise<SearchRowResponse> => {
  const methodname = 'SearchRow'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest, onNextOk?: (data?) => void): Promise<SaveResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, onNextOk)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
