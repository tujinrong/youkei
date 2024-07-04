import { api } from '@/utils/http/common-service'
import {
  SearchJyoseiListRequest,
  SearchJyoseiListResponse,
  SaveJyoseiRequest,
  DeleteJyoseiRequest,
  CommonResponse,
  InitListRequest,
  InitListResponse
} from './type'
const servicename = 'AWBH00302D'

/** 費用助成一覧画面検索処理 */
export const SearchJyoseiList = (
  params: SearchJyoseiListRequest
): Promise<SearchJyoseiListResponse> => {
  const methodname = 'SearchJyoseiList'
  return api(servicename, methodname, params)
}

/** 費用助成一覧保存処理 */
export const SaveJyosei = (params: SaveJyoseiRequest): Promise<CommonResponse> => {
  const methodname = 'SaveJyosei'
  return api(servicename, methodname, params)
}

/** 費用助成一覧削除処理 */
export const DeleteJyosei = (params: DeleteJyoseiRequest): Promise<CommonResponse> => {
  const methodname = 'DeleteJyosei'
  return api(servicename, methodname, params)
}

/** 費用助成一覧削除処理 */
export const InitList = (params: InitListRequest): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, params)
}
