/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitResponse,
  InitRequest,
  InitMappingMethodRequest,
  InitMappingMethodResponse
} from './type'
const servicename = 'AWKK00603D'

/** 初期化処理(取込設定：マッピング設定情報ダイアログ画面) */
export const InitDetail = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 【マッピング方法】初期化処理 */
export const InitMappingMethod = (
  params: InitMappingMethodRequest
): Promise<InitMappingMethodResponse> => {
  const methodname = 'InitMappingMethod'
  return api(servicename, methodname, params)
}
