// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(帳票出力設定)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { api, download, preview } from '@/utils/http/common-service'
import { PreviewRequest, ReportPreviewResponse, DownloadRequest, BatchRequest } from './type'
const servicename = 'AWEU00303D'

/**プレビュー処理 */
export const Preview = (params: PreviewRequest): Promise<ReportPreviewResponse> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params, { loading: true })
}

/**ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<CmDownloadResponseBase> => {
  const methodname = 'Download'
  return download(servicename, methodname, params, { loading: true })
}

/**バッチ処理 */
export const AddBatchJob = (params: BatchRequest): Promise<DaResponseBase> => {
  const methodname = 'AddBatchJob'
  return api(servicename, methodname, params)
}
