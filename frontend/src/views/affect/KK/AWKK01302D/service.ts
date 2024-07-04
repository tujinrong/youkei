import { api } from '@/utils/http/common-service'
import { CheckRequest, CheckResponse, InitResponse } from './type'
const servicename = 'AWKK01302D'

/**初期化処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}
/**個別除外チェック */
export const Check = (
  params: CheckRequest,
  onNextOk?: (data?) => void,
  onNextCancel?: (data?) => void
): Promise<CheckResponse> => {
  const methodname = 'Check'
  return api(servicename, methodname, params, undefined, onNextOk, onNextCancel)
}
