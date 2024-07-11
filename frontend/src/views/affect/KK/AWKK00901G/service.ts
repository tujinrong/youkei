/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業予定管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.03.06
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchNitteiListResponse,
  SearchNitteiListRequest,
  SearchCourseListResponse,
  SearchCourseListRequest,
  InitNitteiDetailResponse,
  InitNitteiDetailRequest,
  InitCourseDetailResponse,
  InitCourseDetailRequest,
  SaveNitteiRequest,
  SaveCourseRequest,
  DeleteNitteiRequest,
  DeleteCourseRequest
} from './type'
const servicename = 'AWKK00901G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面：日程) */
export const SearchNitteiList = (
  params: SearchNitteiListRequest
): Promise<SearchNitteiListResponse> => {
  const methodname = 'SearchNitteiList'
  return api(servicename, methodname, params)
}

/** 検索処理(一覧画面：コース) */
export const SearchCourseList = (
  params: SearchCourseListRequest
): Promise<SearchCourseListResponse> => {
  const methodname = 'SearchCourseList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面：日程) */
export const InitDetailNittei = (
  params: InitNitteiDetailRequest
): Promise<InitNitteiDetailResponse> => {
  const methodname = 'InitDetailNittei'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面：コース) */
export const InitDetailCourse = (
  params: InitCourseDetailRequest
): Promise<InitCourseDetailResponse> => {
  const methodname = 'InitDetailCourse'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面：日程) */
export const SaveNittei = (params: SaveNitteiRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveNittei'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面：コース) */
export const SaveCourse = (params: SaveCourseRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveCourse'
  return api(servicename, methodname, params)
}

/** 削除処理(詳細画面：日程) */
export const DeleteNittei = (params: DeleteNitteiRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteNittei'
  return api(servicename, methodname, params)
}

/** 削除処理(詳細画面：コース) */
export const DeleteCourse = (params: DeleteCourseRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteCourse'
  return api(servicename, methodname, params)
}
