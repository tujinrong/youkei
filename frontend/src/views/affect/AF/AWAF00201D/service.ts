/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: パスワード変更
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.02.22
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SaveRequest } from './type'
const servicename = 'AWAF00201D'

/** 初期化処理(パスワードポリシー) */
export const Init = (): Promise<CmPwdInitResponse> => {
  const methodname = 'CmPwdInit'
  return api('Common.Service', methodname, {})
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
