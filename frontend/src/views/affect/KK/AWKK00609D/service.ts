import { api } from '@/utils/http/common-service'
import {
  InitMaincdRequest,
  InitMaincdResponse,
  InitRequest,
  InitResponse,
  InitSubcdRequest,
  InitSubcdResponse
} from './type'
const servicename = 'AWKK00609D'

/** 初期化処理(変換区分管理画面) */
export const InitDetail = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理(【メインコード】のドロップダウンリスト) */
export const InitMaincdList = (params: InitMaincdRequest): Promise<InitMaincdResponse> => {
  const methodname = 'InitMaincdList'
  return api(servicename, methodname, params)
}

/** 初期化処理(【サブコード】のドロップダウンリスト) */
export const InitSubcdList = (params: InitSubcdRequest): Promise<InitSubcdResponse> => {
  const methodname = 'InitSubcdList'
  return api(servicename, methodname, params)
}
