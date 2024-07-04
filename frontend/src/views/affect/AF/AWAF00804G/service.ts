/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 各種事業コード設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.01.26
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { SearchResponse } from './type'
const servicename = 'AWAF00804G'

/** 検索処理 */
export const Search = (): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, {})
}
