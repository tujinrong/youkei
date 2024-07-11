/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者（担当者）保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.12.11
 * 作成者　　: 高智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SaveDetailRequest
} from './type'
const servicename = 'AWKK00203G'

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
