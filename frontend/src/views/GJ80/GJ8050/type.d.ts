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

/**初期化処理(詳細画面) */
export interface InitBankDetailRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
}

/**保存処理(詳細画面) */
export interface SaveBankRequest extends DaRequestBase {
  /**金融機関情報 */
  BANK: BankDetailVM
}

/**削除処理(詳細画面) */
export interface DeleteBankRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**データ更新日 */
  UP_DATE?: Date
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

/**初期化処理(詳細画面) */
export interface InitSitenDetailRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
}

/**保存処理(詳細画面) */
export interface SaveSitenRequest extends DaRequestBase {
  /**金融機関情報 */
  SITEN: SitenDetailVM
}

/**削除処理(詳細画面) */
export interface DeleteSitenRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
  /**データ更新日 */
  UP_DATE?: Date
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**検索処理(金融機関一覧画面) */
export interface SearchBankResponse extends CmSearchResponseBase {
  /**金融機関情報リスト */
  KEKKA_LIST: SearchBankRowVM[]
}

/**初期化処理(詳細画面) */
export interface InitBankDetailResponse extends DaResponseBase {
  /**金融機関情報 */
  BANK: BankDetailVM
}

/**検索処理(支店一覧画面) */
export interface SearchSitenResponse extends CmSearchResponseBase {
  /**金融機関情報リスト */
  KEKKA_LIST: SearchSitenRowVM[]
}
/**初期化処理(詳細画面) */
export interface InitSitenDetailResponse extends DaResponseBase {
  /**金融機関情報 */
  Siten: SitenDetailVM
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

export interface BankDetailVM {
  /**金融機関コード */
  BANK_CD: string
  /**金融機関名（ｶﾅ） */
  BANK_KANA?: string
  /**金融機関名（漢字） */
  BANK_NAME?: string
  /**データ更新日 */
  UP_DATE?: Date
}

export interface SitenDetailVM {
  /**金融機関コード */
  BANK_CD: string
  /**支店コード */
  SITEN_CD: string
  /**支店名（ｶﾅ） */
  SITEN_KANA?: string
  /**支店名（漢字） */
  SITEN_NAME?: string
  /**データ更新日 */
  UP_DATE?: Date
}
