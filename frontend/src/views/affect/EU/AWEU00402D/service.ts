/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 *
 * 作成日　　: 2024.4.11
 * 作成者　　: 魏
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest, SaveRequest, DeleteRequest } from './type'
const servicename = 'AWEU00402D'

/** 初期化処理(詳細画面) */
export const InitDetailInfo = (
  params: InitRequest,
  onNextOk?: (data?) => void
): Promise<InitResponse> => {
  const methodname = 'InitDetailInfo'
  return api(servicename, methodname, params, { loading: true }, onNextOk)
}
/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/**削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
