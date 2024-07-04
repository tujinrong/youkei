/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票発行履歴管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.08
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  SearchDetailRequest,
  SaveDetailRequest,
  DeleteRequest
} from './type'
const servicename = 'AWAF01101G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/** 登録処理 */
export const Save = (params: SaveDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
