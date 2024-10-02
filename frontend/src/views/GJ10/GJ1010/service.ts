/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  CopyRequest,
  DeleteRequest,
  DeleteRequest_1012,
  InitDetailRequest_1012,
  InitDetailRequest_1013,
  InitDetailResponse,
  InitDetailResponse_1012,
  InitDetailResponse_1013,
  InitNojoRequest,
  InitNojoResponse,
  SaveRequest,
  SaveRequest_1012,
  SaveRequest_1013,
  SearchDetailRequest,
  SearchDetailRequest_1012,
  SearchDetailResponse,
  SearchDetailResponse_1012,
} from './type'

const servicename2 = 'GJ1011'
const servicename3 = 'GJ1012'
const servicename4 = 'GJ1013'

//--------------------------------------------------------------------------
//GJ1010
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//GJ1011
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//GJ1012
//--------------------------------------------------------------------------
/** 検索処理_詳細画面 */
export const SearchDetail_1012 = (
  params: SearchDetailRequest_1012
): Promise<SearchDetailResponse_1012> => {
  const methodname = 'Search'
  return api(servicename3, methodname, params)
}

/** 初期化処理_詳細画面*/
export const InitDetail_1012 = (
  params: InitDetailRequest_1012
): Promise<InitDetailResponse_1012> => {
  const methodname = 'InitDetail'
  return api(servicename3, methodname, params)
}

/** 初期化処理_詳細画面*/
export const InitNojo = (
  params: InitNojoRequest
): Promise<InitNojoResponse> => {
  const methodname = 'InitNojo'
  return api(servicename3, methodname, params)
}

/** 前期データコピー処理_詳細画面Copy*/
export const Copy = (params: CopyRequest): Promise<DaResponseBase> => {
  const methodname = 'Copy'
  return api(servicename3, methodname, params)
}

/** 保存処理_詳細画面 */
export const Save_1012 = (
  params: SaveRequest_1012
): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename3, methodname, params)
}

/** 削除処理_詳細画面 */
export const Delete_1012 = (
  params: DeleteRequest_1012
): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename3, methodname, params)
}
//--------------------------------------------------------------------------
//GJ1013
//--------------------------------------------------------------------------
/** 初期化処理_詳細画面*/
export const InitDetail_1013 = (
  params: InitDetailRequest_1013
): Promise<InitDetailResponse_1013> => {
  const methodname = 'InitDetail'
  return api(servicename4, methodname, params)
}
/** 保存処理_詳細画面 */
export const Save_1013 = (
  params: SaveRequest_1013
): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename4, methodname, params)
}
