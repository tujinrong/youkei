/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 消費税率一覧
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.10.01
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, api2 } from '@/service/request/common-service'

import {
  DeleteRequest,
  InitDetailRequest,
  InitDetailResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'GJ8100'
const servicename2 = 'GJ8101'

/** 初期化処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, {})
}

/** 検索処理(詳細画面) */
export const InitDetail = (
  params: InitDetailRequest
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename2, methodname, params, undefined, { loading: true })
}

/** 登録処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename2, methodname, params)
}

/** 削除処理(詳細画面) */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename2, methodname, params)
}
