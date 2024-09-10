/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.20
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**検索処理(金融機関一覧画面) */
export interface SearchBankRequest extends CmSearchRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**金融機関名（ｶﾅ） */
  BANK_KANA?: string
  /**金融機関名（漢字） */
  BANK_NAME?: string
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/**検索処理(支店一覧画面) */
export interface SearchSitenRequest extends CmSearchRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
  /**支店名（ｶﾅ） */
  SITEN_KANA?: string
  /**支店名（漢字） */
  SITEN_NAME?: string
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}
/**プレビュー処理(金融機関プレビュー画面) */
export interface PreviewBankRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**金融機関名（ｶﾅ） */
  BANK_KANA?: string
  /**金融機関名（漢字） */
  BANK_NAME?: string
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/************************************************************** */

/**プレビュー処理(支店プレビュー画面) */
export interface PreviewSitenRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
  /**支店名（ｶﾅ） */
  SITEN_KANA?: string
  /**支店名（漢字） */
  SITEN_NAME?: string
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**検索処理(金融機関一覧画面) */
export interface SearchBankResponse extends CmSearchResponseBase {
  /**金融機関情報リスト */
  KEKKA_LIST: SearchBankRowVM[]
}
/**検索処理(支店一覧画面) */
export interface SearchSitenResponse extends CmSearchResponseBase {
  /**金融機関情報リスト */
  KEKKA_LIST: SearchSitenRowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface SearchBankRowVM {
  /**金融機関コード */
  BANK_CD: string
  /**金融機関名（ｶﾅ） */
  BANK_KANA: string
  /**金融機関名（漢字） */
  BANK_NAME: string
}

export interface SearchSitenRowVM {
  /**金融機関コード */
  BANK_CD: string
  /**支店コード */
  SITEN_CD: string
  /**支店名（ｶﾅ） */
  SITEN_KANA: string
  /**支店名（漢字） */
  SITEN_NAME: string
}
