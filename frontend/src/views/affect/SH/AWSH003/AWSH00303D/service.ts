/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 受診拒否設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.02.07
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest, SaveRequest } from './type'
const servicename = 'AWSH00303D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
