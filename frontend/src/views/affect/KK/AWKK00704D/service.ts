/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込設定
 * 　　　　　  サービス処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download } from '@/utils/http/common-service'
import { InitListResponse, InitListRequest, DownloadRequest } from './type'
const servicename = 'AWKK00704D'

/** 初期化処理(エラー一覧(行のエラー明細）) */
export const InitList = (params: InitListRequest): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, params)
}

/** エラー出力処理 */
export const Download = (params: DownloadRequest): Promise<CmDownloadResponseBase> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}
