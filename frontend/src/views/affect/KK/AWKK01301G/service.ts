import { api } from '@/utils/http/common-service'
import {
  ExtractRequest,
  ExtractResponse,
  InitDetailRequest,
  InitDetailResponse,
  InitListResponse,
  SearchListRequest,
  SearchListResponse
} from './type'
const servicename = 'AWKK01301G'

/**検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params)
}

/**初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/**初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/**抽出処理 */
export const Extract = (
  params: ExtractRequest,
  onNextOk?: (data?) => void
): Promise<ExtractResponse> => {
  const methodname = 'Extract'
  return api(servicename, methodname, params, undefined, onNextOk)
}
