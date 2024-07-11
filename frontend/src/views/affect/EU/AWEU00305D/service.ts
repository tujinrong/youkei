// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力履歴画面
//             サービス処理
// 作成日　　: 2023.09.05
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
import { api, download } from '@/utils/http/common-service'
import { SearchRequest, SearchResponse, DownloadRequest } from './type'
const servicename = 'AWEU00305D'

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/** ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<DaResponseBase> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}
