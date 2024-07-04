/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 保健指導・集団指導項目並び順設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse, SaveRequest } from './type'
import { SidoCommonRequest } from '../AWKK00801G/type'
const servicename = 'AWKK00807D'

/** 検索処理 */
export const Search = (params: SidoCommonRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
