/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, api2 } from '@/service/request/common-service'

import {
  DeleteBankRequest,
  DeleteSitenRequest,
  InitBankDetailRequest,
  InitBankDetailResponse,
  InitSitenDetailRequest,
  InitSitenDetailResponse,
  PreviewBankRequest,
  PreviewSitenRequest,
  SaveBankRequest,
  SaveSitenRequest,
  SearchBankRequest,
  SearchBankResponse,
  SearchSitenRequest,
  SearchSitenResponse,
} from './type'

const servicename = 'GJ8050'

/**検索処理(金融機関一覧画面) */
export const SearchBank = (
  params: SearchBankRequest
): Promise<SearchBankResponse> => {
  const methodname = 'SearchBank'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**プレビュー処理(金融機関プレビュー画面) */
export const PreviewBank = (
  params: PreviewBankRequest
): Promise<DaResponseBase> => {
  const methodname = 'PreviewBank'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**初期化処理(詳細画面) */
export const InitBankDetail = (
  params: InitBankDetailRequest
): Promise<InitBankDetailResponse> => {
  const methodname = 'InitBankDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**保存処理(詳細画面) */
export const SaveBank = (params: SaveBankRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveBank'
  return api(servicename, methodname, params, undefined)
}

/**削除処理(詳細画面) */
export const DeleteBank = (
  params: DeleteBankRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteBank'
  return api(servicename, methodname, params, undefined)
}

/**検索処理(支店一覧画面) */
export const SearchSiten = (
  params: SearchSitenRequest
): Promise<SearchSitenResponse> => {
  const methodname = 'SearchSiten'
  return api(servicename, methodname, params, undefined, { loading: true })
}
/**プレビュー処理(支店プレビュー画面) */
export const PreviewSiten = (
  params: PreviewSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'PreviewSiten'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**初期化処理(詳細画面) */
export const InitSitenDetail = (
  params: InitSitenDetailRequest
): Promise<InitSitenDetailResponse> => {
  const methodname = 'InitSitenDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**保存処理(詳細画面) */
export const SaveSiten = (
  params: SaveSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveSiten'
  return api(servicename, methodname, params, undefined)
}

/**削除処理(詳細画面) */
export const DeleteSiten = (
  params: DeleteSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteSiten'
  return api(servicename, methodname, params, undefined)
}
