/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 保健指導管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.23
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  SearchListResponse,
  SearchListRequest,
  SearchDetailResponse,
  SearchDetailRequest,
  SearchSetaiDetailResponse,
  SearchSetaiDetailRequest,
  SearchShidouDetailResponse,
  SearchShidouDetailRequest,
  SearchPersonDetailResponse,
  SearchPersonDetailRequest,
  SearchPersonShidouResponse,
  CommonResponse,
  SaveRequest,
  DeleteRequest,
  InitDetailResponse,
  GetAgeRequest,
  GetAgeResponse
} from './type'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'

const servicename = 'AWKK00301G'

/** 住民一覧画面検索処理(検索画面) */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/**住民詳細画面検索処理(住民一覧) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/**世帯詳細画面検索処理(世帯一覧) */
export const SearchSetaiDetail = (
  params: SearchSetaiDetailRequest
): Promise<SearchSetaiDetailResponse> => {
  const methodname = 'SearchSetaiDetail'
  return api(servicename, methodname, params)
}

/**世帯詳細画面検索処理(タブ選択) */
export const SearchShidouDetail = (
  params: SearchShidouDetailRequest
): Promise<SearchShidouDetailResponse> => {
  const methodname = 'SearchShidouDetail'
  return api(servicename, methodname, params)
}

/**個人詳細画面検索処理(個人一覧) */
export const SearchPersonDetail = (
  params: SearchPersonDetailRequest
): Promise<SearchPersonDetailResponse> => {
  const methodname = 'SearchPersonDetail'
  return api(servicename, methodname, params)
}

/**個人詳細画面検索処理(タブ選択) */
export const SearchPersonShidou = (
  params: SearchPersonDetailRequest
): Promise<SearchPersonShidouResponse> => {
  const methodname = 'SearchPersonShidou'
  return api(servicename, methodname, params)
}

/**保存処理 */
export const Save = (params: SaveRequest): Promise<CommonResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<CommonResponse> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/**初期化処理(詳細画面) */
export const InitDetail = (): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname)
}

/** 実施年齢取得処理 */
export const GetAge = (params: GetAgeRequest): Promise<GetAgeResponse> => {
  const methodname = 'GetAge'
  return api(servicename, methodname, params)
}
