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
  InitFieldidRequest,
  InitFieldidResponse,
  InitInputTypeRequest,
  InitInputTypeResponse
} from './type'
const servicename = 'AWKK00604D'

/** 初期化処理(取込設定：画面項目情報ダイアログ画面) */
export const InitDetail = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 【入力方法】ドロップダウン初期化処理 */
export const InitInputType = (params: InitInputTypeRequest): Promise<InitInputTypeResponse> => {
  const methodname = 'InitInputType'
  return api(servicename, methodname, params)
}

/** フィールドドロップダウン初期化処理 */
export const InitFieldid = (params: InitFieldidRequest): Promise<InitFieldidResponse> => {
  const methodname = 'InitFieldid'
  return api(servicename, methodname, params)
}
