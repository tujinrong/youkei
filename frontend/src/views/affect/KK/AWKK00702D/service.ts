/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込実行.ファイルアップロード
 * 　　　　　  サービス処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { download, upload } from '@/utils/http/common-service'
import { UploadRequest, ExcelUploadResponse, ErrorDownloadRequest } from './type'
const servicename = 'AWKK00702D'

/** アップロードチェック処理(実行) */
export const ExcelUploadCheck = (params: UploadRequest): Promise<ExcelUploadResponse> => {
  const methodname = 'ExcelUploadCheck'
  return upload(servicename, methodname, params)
}

/** エラー出力処理*/
export const ErrorDownload = (params: ErrorDownloadRequest): Promise<CmDownloadResponseBase> => {
  const methodname = 'ErrorDownload'
  return download(servicename, methodname, params)
}
