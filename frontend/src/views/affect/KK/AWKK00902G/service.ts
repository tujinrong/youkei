/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitNitteiListResponse,
  SearchNitteiListResponse,
  SearchNitteiListRequest,
  InitCourseListResponse,
  CourseListRequest,
  InitPersonListResponse,
  InitPersonListRequest,
  DeletePersonListRequest,
  InitDetailResponse,
  InitDetailRequest,
  CheckResponse,
  CheckRequest,
  SaveRequest,
  DeleteDetailRequest
} from './type'
const servicename = 'AWKK00902G'

/** 初期化処理(日程一覧画面) */
export const InitNitteiList = (): Promise<InitNitteiListResponse> => {
  const methodname = 'InitNitteiList'
  return api(servicename, methodname, {})
}

/** 検索処理(日程一覧画面) */
export const SearchNitteiList = (
  params: Partial<SearchNitteiListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchNitteiListResponse> => {
  const methodname = 'SearchNitteiList'
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 初期化処理(コース一覧画面) */
export const InitDetailCourseList = (
  params: CourseListRequest
): Promise<InitCourseListResponse> => {
  const methodname = 'InitDetailCourseList'
  return api(servicename, methodname, params)
}

/** コピー処理 */
export const Copy = (params: CourseListRequest): Promise<DaResponseBase> => {
  const methodname = 'Copy'
  return api(servicename, methodname, params)
}

/** 初期化処理(予約者一覧画面) */
export const InitDetailPersonList = (
  params: InitPersonListRequest
): Promise<InitPersonListResponse> => {
  const methodname = 'InitDetailPersonList'
  return api(servicename, methodname, params)
}

/** 削除処理(予約者一覧画面) */
export const DeletePersonList = (params: DeletePersonListRequest): Promise<DaResponseBase> => {
  const methodname = 'DeletePersonList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 定員チェック処理(詳細画面) */
export const Check = (params: CheckRequest): Promise<CheckResponse> => {
  const methodname = 'Check'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理(詳細画面) */
export const DeleteDetail = (params: DeleteDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteDetail'
  return api(servicename, methodname, params)
}
