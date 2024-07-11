/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票項目編集
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.30
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitMasterResponse, InitFormatResponse } from './type'
const servicename = 'AWEU00205D'

/** 一覧項目ツリー検索処理 */
export const Init = (): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, {})
}

/**マスタ初期化処理 */
export const InitMaster = (): Promise<InitMasterResponse> => {
  const methodname = 'InitMaster'
  return api(servicename, methodname, {})
}

/**フォーマット初期化処理 */
export const InitFormat = (): Promise<InitFormatResponse> => {
  const methodname = 'InitFormat'
  return api(servicename, methodname, {})
}
