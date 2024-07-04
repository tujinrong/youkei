/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.27
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import {
  InitPersonListResponse,
  InitPersonListRequest,
  InitDetailResponse,
  InitDetailRequest,
  CalculateResponse,
  CalculateRequest,
  SaveRequest,
  DeleteRequest,
  SearchListRequest,
  CheckTeiinRequest,
  CheckTeiinResponse
} from './type'
import { InitListResponse, SearchListResponse } from '../AWSH00401G/type'
const servicename = 'AWSH00402G'

/** 初期化処理(日程一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(日程一覧画面) */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 初期化処理(予約者一覧画面) */
export const InitDetailPersonList = (
  params: InitPersonListRequest
): Promise<InitPersonListResponse> => {
  const methodname = 'InitDetailPersonList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 計算処理(詳細画面) */
export const Calculate = (params: CalculateRequest): Promise<CalculateResponse> => {
  const methodname = 'Calculate'
  return api(servicename, methodname, params)
}

/** 定員チェック処理(詳細画面) */
export const CheckTeiin = (params: CheckTeiinRequest): Promise<CheckTeiinResponse> => {
  const methodname = 'CheckTeiin'
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
