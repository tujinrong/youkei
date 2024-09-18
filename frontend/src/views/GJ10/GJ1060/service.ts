/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 家畜防疫互助基金事業加入状况表
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { ExcelExportRequest, InitRequest, InitResponse } from './type'

const servicename = 'GJ1060'
/** 初期化処理_EXCEL出力画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init'
  return api(servicename, methodName, params, undefined, { loading: true })
}

/** EXCEL出力処理_EXCEL出力画面 */
export const ExcelExport = (
  params: ExcelExportRequest
): Promise<DaResponseBase> => {
  const methodName = 'ExcelExport'
  return api(servicename, methodName, params)
}
