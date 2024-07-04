// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目選択
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { api } from '@/utils/http/common-service'
import { SearchRequest, SearchResponse, SaveRequest } from './type'
const servicename = 'AWEU00103D'

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/**保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}
