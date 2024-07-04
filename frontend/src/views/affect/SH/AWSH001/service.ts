/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ロジック共通仕様処理(検診)
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.07.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import { ProgramStore } from '@/store'
import {
  AuthCheckRequest,
  AuthCheckResponse,
  CalculateRequest,
  CalculateResponse,
  CommonResponse,
  DeleteRequest,
  GetAgeRequest,
  GetAgeResponse,
  GetKijunRequest,
  GetKijunResponse,
  InitDetailRequest,
  InitDetailResponse,
  InitListRequest,
  InitListResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
  SeiKenEditCheckRequest,
  SeiKenEditCheckResponse
} from './type'
export const servicename = 'AWSH001'

/** 初期化処理 */
export const InitList = (params: InitListRequest): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (
  params: Partial<SearchRequest>,
  onNextOk?: (data?) => void
): Promise<SearchResponse> => {
  const methodname = 'Search'
  SaveHistory({ kinoid: ProgramStore.id }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 初期化処理 */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  SaveHistory({ kinoid: ProgramStore.id }) //使用履歴の保存処理
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest, onNextOk?: (data?) => void): Promise<CommonResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, onNextOk)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<CommonResponse> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** 基準値取得処理 */
export const GetKijun = (params: GetKijunRequest): Promise<GetKijunResponse> => {
  const methodname = 'GetKijun'
  return api(servicename, methodname, params)
}

/** 実施年齢取得処理 */
export const GetAge = (params: GetAgeRequest): Promise<GetAgeResponse> => {
  const methodname = 'GetAge'
  return api(servicename, methodname, params)
}

/** 精密検診チェック処理 */
export const SeiKenEditCheck = (
  params: SeiKenEditCheckRequest,
  onNextOk?: (data?) => void,
  onNextCancel?: (data?) => void
): Promise<SeiKenEditCheckResponse> => {
  const methodname = 'SeiKenEditCheck'
  return api(servicename, methodname, params, undefined, onNextOk, onNextCancel)
}

/** 計算処理 */
export const Calculate = (params: CalculateRequest): Promise<CalculateResponse> => {
  const methodname = 'Calculate'
  return api(servicename, methodname, params)
}

/** 新規追加権限チェック処理 */
export const KensinAuthCheck = (params: AuthCheckRequest): Promise<AuthCheckResponse> => {
  const methodname = 'KensinAuthCheck'
  return api(servicename, methodname, params)
}
