import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import { SearchResponse, InitRequest, InitResponse, SaveRequest } from './type'
const servicename = 'AWKK01001G'

/**検索処理(一覧画面) */
export const Search = (
  params: Partial<PersonSearchRequest>,
  onNextOk?: (data?) => void
): Promise<SearchResponse> => {
  const methodname = 'Search'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/**初期化処理(詳細画面) */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 保存処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
