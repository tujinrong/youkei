/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 自己負担金保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListRequest,
  SearchListResponse,
  SaveRequest,
  SearchNendoRequest,
  SearchNendoResponse,
  SearchHikitsudugiRequest
} from './type'
const servicename = 'AWSH00601G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname)
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 年度変更処理(一覧画面) */
export const SearchNendo = (params: SearchNendoRequest): Promise<SearchNendoResponse> => {
  const methodname = 'SearchNendo'
  return api(servicename, methodname, params)
}

/** 前年度引継ぎ */
export const SearchHikitsudugi = (
  params: SearchHikitsudugiRequest
): Promise<SearchNendoResponse> => {
  const methodname = 'SearchHikitsudugi'
  return api(servicename, methodname, params)
}
