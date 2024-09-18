/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 事業加入状況表(農場別リスト)
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  ExcelExportRequest,
  ExcelExportResponse,
  InitRequest,
  InitResponse,
} from './type'

const servicename = 'GJ1070'
/** 初期化処理_EXCEL出力画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init'
  return api(servicename, methodName, params, undefined, { loading: true })
}
/** EXCEL出力処理_EXCEL出力画面 */
export const ExcelExport = (
  params: ExcelExportRequest
): Promise<ExcelExportResponse> => {
  const methodName = 'ExcelExport'
  return api(servicename, methodName, params, undefined, { loading: true })
}
