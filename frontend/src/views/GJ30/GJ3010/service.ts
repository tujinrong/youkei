/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要servicename　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  CancelRequest,
  DeleteRequest,
  InitDetailRequest,
  InitDetailResponse,
  InitHasuRequest,
  InitHasuResponse,
  InitNojoRequest,
  InitNojoResponse,
  InitRequest,
  InitRequest_3011,
  InitResponse,
  InitResponse_3011,
  PreviewRequest,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename1 = 'GJ3010'
const servicename2 = 'GJ3011'

/** 初期化処理_詳細画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init'
  return api(servicename1, methodName, params, undefined, { loading: true })
}
/** 検索処理_詳細画面 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodName = 'Search'
  return api(servicename1, methodName, params, undefined, { loading: true })
}

/** 初期化処理_詳細画面 */
export const InitDetail = (
  params: InitDetailRequest
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename1, methodname, params, undefined, { loading: true })
}

/** 初期化処理_詳細画面InitNojo */
export const InitNojo = (
  params: InitNojoRequest
): Promise<InitNojoResponse> => {
  const methodname = 'InitNojo'
  return api(servicename1, methodname, params, undefined, { loading: true })
}

/** 初期化処理_詳細画面InitHasu */
export const InitHasu = (
  params: InitHasuRequest
): Promise<InitHasuResponse> => {
  const methodname = 'InitHasu'
  return api(servicename1, methodname, params, undefined, { loading: true })
}

/** 保存処理_詳細画面Save */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename1, methodname, params, undefined, { loading: true })
}

/** 削除処理_詳細画面Delete */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename1, methodname, params, undefined, { loading: true })
}

/** 初期化処理_請求書発行画面Init */
export const Init_3011 = (
  params: InitRequest_3011
): Promise<InitResponse_3011> => {
  const methodname = 'Init'
  return api(servicename2, methodname, params, undefined, { loading: true })
}

/** プレビュー処理_請求書発行画面Preview */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename2, methodname, params, undefined, { loading: true })
}

/** 取消処理_請求書発行画面Cancel */
export const Cancel = (params: CancelRequest): Promise<void> => {
  return api(servicename2, 'Cancel', params, undefined, { loading: true })
}
