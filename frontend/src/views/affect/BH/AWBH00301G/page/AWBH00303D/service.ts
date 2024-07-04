import { api } from '@/utils/http/common-service'
import { SearchListRequest, SearchListResponse } from './type'
const servicename = 'AWBH00303D'

/** 妊産婦情報管理-乳幼児情報一覧画面検索処理 */
export const SearchJyoseiList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchJyoseiList'
  return api(servicename, methodname, params)
}
