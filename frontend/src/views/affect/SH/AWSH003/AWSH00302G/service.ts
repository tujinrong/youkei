/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 各種検診対象者保守
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.07
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import {
  SearchListResponse,
  SearchListRequest,
  InitResponse,
  InitRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SaveRequest
} from './type'
const servicename = 'AWSH00302G'

/** 検索処理(一覧画面) */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 初期化処理(詳細画面) */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
