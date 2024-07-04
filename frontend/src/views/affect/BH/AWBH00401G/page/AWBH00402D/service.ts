import { api } from '@/utils/http/common-service'
import { ShowCurveRequest, ShowCurveResponse } from './type'

const servicename = 'AWBH00402D'

/** 費用助成一覧保存処理 */
export const ShowCurve = (params: ShowCurveRequest): Promise<ShowCurveResponse> => {
  const methodname = 'ShowCurve'
  return api(servicename, methodname, params)
}
