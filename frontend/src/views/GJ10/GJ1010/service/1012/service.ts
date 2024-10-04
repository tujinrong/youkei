/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { SearchRequest, SearchResponse } from './type'

const servicename = 'GJ1012'

/** 検索処理_詳細画面 */
export const Search = (
  params: CmSearchRequestBase
): Promise<CmSearchResponseBase> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}
