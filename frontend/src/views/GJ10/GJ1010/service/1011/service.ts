/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  DeleteRequest,
  InitDetailRequest,
  InitDetailResponse,
  SaveRequest,
  SearchDetailRequest,
  SearchDetailResponse,
} from './type'

const servicename = 'GJ1011'

/** 初期化処理_詳細画面 */
export const InitDetail = (
  params: InitDetailRequest
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 検索処理_詳細画面 */
export const SearchDetail = (
  params: SearchDetailRequest
): Promise<SearchDetailResponse> => {
  const methodname = 'SearchDetail'
  return api(servicename, methodname, params)
}

/** 保存処理_詳細画面 */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理_詳細画面 */
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
