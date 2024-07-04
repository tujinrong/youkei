import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest } from './type'
const servicename = 'AWKK00608D'

/** 初期化処理(取込設定：プロシージャ管理画面) */
export const InitDetail = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}
