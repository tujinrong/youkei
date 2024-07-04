/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: バッチスケジュール管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
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
  SaveDetailRequest,
  DeleteRequest,
  ExeBatchDetailRequest
} from './type'
const servicename = 'AWAF01001G'

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

/** 登録処理 */
export const Save = (params: SaveDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
/** バッチ実行処理 */
export const Execute = (params: ExeBatchDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'Execute'
  return api(servicename, methodname, params)
}
