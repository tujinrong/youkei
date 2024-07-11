/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ヘルプ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { download } from '@/utils/http/common-service'
import { DownloadRequest } from './type'
const servicename = 'AWAF00203S'

/** ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<DaResponseBase> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}
