/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.xx.xx
 * 作成者　　:xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import {
  DeleteRequest,
  InitDetailRequest,
  InitDetailResponse,
  InitRequest,
  InitResponse,
  SaveRequest,
  SearchRequest,
  SearchResponse,
} from './type'

const servicename = 'xxxx'
const servicename2 = 'xxxx'

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

/** 初期化処理(詳細画面) */
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
