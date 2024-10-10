/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.10.10
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { SearchResponse } from './type'
const servicename = 'GJ2010'

/** 検索処理(一覧画面) */
export const Search = (
  params: CmSearchRequestBase
): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, undefined, { loading: true })
}
