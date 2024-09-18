/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者情報変更
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.29
 * 作成者　　:wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  DeleteRequest,
  InitDetailRequest,
  InitDetailResponse,
  InitHasuRequest,
  InitHasuResponse,
  InitNojoRequest,
  InitNojoResponse,
  InitRequest,
  InitResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'GJ1020'

/** 初期化処理(一覧画面) */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** 検索処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** 初期化処理_詳細画面 */
export const InitDetail = (
  params: InitDetailRequest
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理_詳細画面 */
export const InitNojo = (
  params: InitNojoRequest
): Promise<InitNojoResponse> => {
  const methodname = 'InitNojo'
  return api(servicename, methodname, params)
}
/** 初期化処理_羽数 */
export const InitHasu = (
  params: InitHasuRequest
): Promise<InitHasuResponse> => {
  const methodname = 'InitHasu'
  return api(servicename, methodname, params)
}
/** 保存処理_詳細画面 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理_詳細画面 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
