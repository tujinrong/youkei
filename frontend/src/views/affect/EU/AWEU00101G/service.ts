/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.04.11
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitResponse,
  SearchResponse,
  SearchRequest,
  DeleteRequest,
  SaveRequest,
  DeleteItemsRequest,
  InitDetailTabRequest,
  InitDetailTabResponse,
  SearchConditionTabRequest,
  SearchConditionTabResponse,
  SearchOtherConditionTabResponse,
  SaveResponse
} from './type'
const servicename = 'AWEU00101G'

/** 初期化処理(一覧画面) */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname)
}

/** 検索処理(一覧画面) */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/** 初期化処理(データソース詳細) */
export const InitDetailTab = (params: InitDetailTabRequest): Promise<InitDetailTabResponse> => {
  const methodname = 'InitDetailTab'
  return api(servicename, methodname, params, { loading: true })
}

/**項目削除処理(テーブルタブ) */
export const DeleteItems = (params: DeleteItemsRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteItems'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<SaveResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:検索条件タブ(通常)) */
export const SearchConditionTab = (
  params: SearchConditionTabRequest
): Promise<SearchConditionTabResponse> => {
  const methodname = 'SearchConditionTab'
  return api(servicename, methodname, params, { loading: true })
}

/**"検索処理(詳細画面:検索条件(その他条件)) */
export const SearchOtherConditionTab = (
  params: SearchConditionTabRequest
): Promise<SearchOtherConditionTabResponse> => {
  const methodname = 'SearchOtherConditionTab'
  return api(servicename, methodname, params, { loading: true })
}
