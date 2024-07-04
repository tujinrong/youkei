/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票新規作成
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitReportResponse,
  InitOtherYosikiResponse,
  InitSubReportResponse,
  CheckRequest
} from './type'
const servicename = 'AWEU00202D'

/** 初期化処理(帳票) */
export const InitReport = (): Promise<InitReportResponse> => {
  const methodname = 'InitReport'
  return api(servicename, methodname, {})
}

/** 初期化処理(別様式) */
export const InitOtherYosiki = (): Promise<InitOtherYosikiResponse> => {
  const methodname = 'InitOtherYosiki'
  return api(servicename, methodname, {})
}

/** 初期化処理(サブ帳票) */
export const InitSubReport = (): Promise<InitSubReportResponse> => {
  const methodname = 'InitSubReport'
  return api(servicename, methodname, {})
}

/** チェック処理(次へ押下) */
export const Check = (params: CheckRequest): Promise<DaResponseBase> => {
  const methodname = 'Check'
  return api(servicename, methodname, params)
}
