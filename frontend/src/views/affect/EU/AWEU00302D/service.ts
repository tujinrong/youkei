// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力(CSV)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { api, download } from '@/utils/http/common-service'

import { DownloadRequest, DetailInitRequest, DetailInitResponse } from './type'

const servicename = 'AWEU00302D'

/** ダウンロード処理 */
export const Download = (params: DownloadRequest) => {
  const methodname = 'Download'
  return download(servicename, methodname, params, { loading: true })
}

/**CSV出力設定初期化処理 */
export const DetailInit = (params: DetailInitRequest): Promise<DetailInitResponse> => {
  const methodname = 'DetailInit'
  return api(servicename, methodname, params)
}
