import { api } from '@/service/request/common-service'
import { InitResponse } from './type'

const servicename = 'home'
/** 初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname)
}
