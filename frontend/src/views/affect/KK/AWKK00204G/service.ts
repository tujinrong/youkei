/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 地区保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.25
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SearchRowResponse,
  SearchRowRequest,
  SaveRequest
} from './type'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
const servicename = 'AWKK00204G'

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
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面) */
export const SearchRow = (params: SearchRowRequest): Promise<SearchRowResponse> => {
  const methodname = 'SearchRow'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
