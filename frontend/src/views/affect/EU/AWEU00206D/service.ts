import { api, upload } from '@/utils/http/common-service'
import { InitResponse, SaveRequest } from './type'

const servicename = 'AWEU00206D'

/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {}, { loading: true })
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return upload(servicename, methodname, params)
}
