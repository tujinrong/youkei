import { api } from '@/utils/http/common-service'
import { InitResponse, CommonRequest, ReSearchResponse, SaveRequest } from './type'
const servicename = 'AWKK00607D'

/** 初期化処理(取込設定：プロシージャ管理画面) */
export const InitDetail = (params: DaRequestBase): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 【選択】【再読み込み】(取込設定：プロシージャ管理画面) */
export const ReSearch = (params: CommonRequest): Promise<ReSearchResponse> => {
  const methodname = 'ReSearch'
  return api(servicename, methodname, params)
}

/** 登録処理(取込設定：プロシージャ管理画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理(取込設定：プロシージャ管理画面) */
export const Delete = (params: CommonRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
