/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import {
  PreviewBankRequest,
  PreviewSitenRequest,
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
/**検索処理(支店一覧画面) */
export const SearchSiten = (
  params: SearchSitenRequest
): Promise<SearchSitenResponse> => {
  const methodname = 'SearchSiten'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**プレビュー処理(金融機関プレビュー画面) */
export const PreviewBank = (
  params: PreviewBankRequest
): Promise<DaResponseBase> => {
  const methodname = 'PreviewBank'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**プレビュー処理(支店プレビュー画面) */
export const PreviewSiten = (
  params: PreviewSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'PreviewSiten'
  return api(servicename, methodname, params, undefined, { loading: true })
}
