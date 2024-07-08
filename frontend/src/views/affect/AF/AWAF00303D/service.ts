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
  return new Promise((resolve) => {
    resolve({
      kekkalist: [
        "AWSH00301G",
        "AWSH00302G",
        "AWEU00101G",
        "AWEU00201G",
        "AWEU00301G",
        "AWEU00401G",
        "AWSH00107G",
        "AWKK00301G",
        "AWKK00303G"
      ],
      returncode: 0,
      message: null,
      rsaprivatekey: null
    });
  });
  // const methodname = 'Search'
  // return api(servicename, methodname, {})
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
