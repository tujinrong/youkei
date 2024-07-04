/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 関連テーブル追加
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.04.14
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitResponse,
  SearchResponse,
  InitRequest,
  SearchRequest,
  SaveRequest,
  DeleteRequest,
  SqlRequest,
  SqlResponse,
  SearchJokenDetailResponse,
  SearchJokenDetailRequest
} from './type'
const servicename = 'AWEU00105D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/**検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/**新規処理 */
export const Add = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Add'
  return api(servicename, methodname, params)
}

/**更新処理 */
export const Update = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Update'
  return api(servicename, methodname, params)
}

/**削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/**条件SQL取得 */
export const GetSql = (params: SqlRequest): Promise<SqlResponse> => {
  const methodname = 'GetSql'
  return api(servicename, methodname, params)
}
/**選択条件 */
export const SearchJokenDetail = (
  params: SearchJokenDetailRequest
): Promise<SearchJokenDetailResponse> => {
  const methodname = 'SearchJokenDetail'
  return api(servicename, methodname, params)
}
