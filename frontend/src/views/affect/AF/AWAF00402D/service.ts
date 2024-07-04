/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: CSV出力項目選択
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.11.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitResponse,
  InitRequest,
  SearchResponse,
  SearchRequest,
  SaveRequest,
  DeleteRequest
} from './type'
const servicename = 'AWAF00402D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
