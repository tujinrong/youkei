import { api } from '@/utils/http/common-service'
import {
  InitRequest,
  InitResponse,
  SearchRequest,
  SearchResponse,
  SaveRequest,
  DeleteRequest
} from './type'
const servicename = 'AWEU00104D'

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
