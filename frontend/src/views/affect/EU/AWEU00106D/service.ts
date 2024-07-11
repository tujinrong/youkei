// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 検索条件編集(固定)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { api } from '@/utils/http/common-service'
import {
  InitRequest,
  InitResponse,
  SearchRequest,
  SearchResponse,
  SaveRequest,
  DeleteRequest,
  SqlRequest,
  SqlResponse
} from './type'
const servicename = 'AWEU00106D'

/**初期化処理 */
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
