import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import { ProgramStore } from '@/store'
import {
  SearchListRequest,
  SearchListResponse,
  SearchDetailRequest,
  SearchDetailResponse,
  SearchSyosaiResponse,
  SearchSyosaiRequest,
  SearchAtenaInfoRequest,
  SearchAtenaInfoResponse,
  CommonResponse,
  SaveAllRequest,
  DeleteRequest
} from './type'

const servicename = 'AWBH00401G'

/** 乳幼児画面検索処理(検索画面) */
export const SearchList = (
  params: Partial<SearchListRequest>,
  onNextOk?: (data?) => void
): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: ProgramStore.id }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 乳幼児詳細画面検索処理(妊産婦一覧) */
export const SearchDetail = (params: SearchDetailRequest): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 乳幼児フリー項目検索処理 */
export const SearchSyosai = (params: SearchSyosaiRequest): Promise<SearchSyosaiResponse> => {
  const methodname = 'SearchSyosai'
  return api(servicename, methodname, params)
}

/** 父母親情報検索処理 */
export const SearchAtenaInfo = (
  params: SearchAtenaInfoRequest
): Promise<SearchAtenaInfoResponse> => {
  const methodname = 'SearchAtenaInfo'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveAllRequest): Promise<CommonResponse> => {
  const methodname = 'SaveAll'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<CommonResponse> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
