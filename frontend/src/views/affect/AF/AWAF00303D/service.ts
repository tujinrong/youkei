/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: お気に入り
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.03.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest, CommonResponse, UpdateRequest, SaveRequest } from './type'
const servicename = 'AWAF00303D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (): Promise<CommonResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, {})
}

/** 更新処理 */
export const Update = (params: UpdateRequest): Promise<CommonResponse> => {
  const methodname = 'Update'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<CommonResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
