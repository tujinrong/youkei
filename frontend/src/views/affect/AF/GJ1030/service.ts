/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 電子ファイル情報
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.08.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, preview, upload, download } from '@/utils/http/common-service'
import {
  InitResponse,
  InitRequest,
  SearchResponse,
  SearchRequest,
  PreviewRequest,
  SaveRequest,
  DeleteRequest,
  DownloadRequest
} from './type'
const servicename = 'AWAF00602D'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理 */
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params)
}

/** プレビュー処理 */
export const Preview = (params: PreviewRequest): Promise<Blob> => {
  const methodname = 'Preview'
  return preview(servicename, methodname, params)
}

/** 保存処理 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return upload(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<void> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}
