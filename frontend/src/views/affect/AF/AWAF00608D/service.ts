/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 送付先管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.11.17
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListRequest,
  InitDetailResponse,
  SearchDetailResponse,
  SearchDetailRequest,
  SaveRequest,
  DeleteRequest,
  AutoSetResponse,
  AutoSetRequest
} from './type'
const servicename = 'AWAF00608D'

/** 初期化処理(一覧画面) */
export const InitList = (params: SearchListRequest): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, {})
}

/** 検索処理(詳細画面) */
export const SearchDetail = (
  params: SearchDetailRequest,
  onNextOk?: (data?) => void
): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params, undefined, onNextOk)
}

/** 保存処理 */
export const Save = (params: SaveRequest, onNextOk?: (data?) => void): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, onNextOk)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** 自動入力 */
export const AutoSet = (params: AutoSetRequest): Promise<AutoSetResponse> => {
  const methodname = 'AutoSet'
  return api(servicename, methodname, params)
}
