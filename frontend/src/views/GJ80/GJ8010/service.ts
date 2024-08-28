/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.20
 * 作成者　　: 魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import {
  DeleteRequest,
  InitResponse,
  SaveRequest,
  SearchDetailRequest,
  SearchDetailResponse,
  SearchRequest,
  SearchResponse,
} from './type'
import { DaResponseBase } from '@/typings/Base'

const servicename = 'GJ8010'
const servicename2 = 'GJ8011'

/** 初期化処理(一覧画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname)
}

/** 検索処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** 検索処理(詳細画面) */
export const SearchDetail = (
  params: SearchDetailRequest
): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
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
