/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ホーム
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.21
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download } from '@/utils/http/common-service'
import {
  InitResponse,
  InitRequest,
  SearchInfoResponse,
  SearchInfoRequest,
  SearchLogResponse,
  DownloadRequest,
  GetMenuResponse
} from './type'
const servicename = 'AWAF00301G'

/** 初期化処理 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params)
}

/** 検索処理(お知らせ) */
export const SearchInfo = (params: SearchInfoRequest): Promise<SearchInfoResponse> => {
  const methodname = 'SearchInfo'
  return api(servicename, methodname, params)
}

/** 検索処理(連携処理) */
export const SearchLog = (): Promise<SearchLogResponse> => {
  const methodname = 'SearchLog'
  return api(servicename, methodname, {})
}

/** ダウンロード処理 */
export const Download = (params: DownloadRequest): Promise<void> => {
  const methodname = 'Download'
  return download(servicename, methodname, params)
}

/** メニュー取得処理 */
export const GetMenu = (): Promise<GetMenuResponse> => {
  const methodname = 'GetMenu'
  return api(servicename, methodname)
}
