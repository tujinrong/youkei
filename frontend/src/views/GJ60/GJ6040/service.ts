/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 積立金返還金振込データ作成(全銀手順)
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.09.23
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import { PreviewRequest } from './type'

const servicename = 'GJ6040'

/** プレビュー処理(プレビュー画面) */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params)
}
