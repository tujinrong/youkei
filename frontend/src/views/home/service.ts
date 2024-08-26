import { api } from '@/service/request/common-service'
import { InitResponse } from './type'

const servicename = 'GJ0000'
/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Home'
  const params = undefined
  return api(servicename, methodname, params, undefined, { loading: true })
}
