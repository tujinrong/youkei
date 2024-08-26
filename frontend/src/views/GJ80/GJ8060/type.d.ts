/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 事務委託先一覧
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr, EnumEditKbn } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitRequest extends DaRequestBase {
  /**期 */
  KI: number
}

/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {
  /**期 */
  KI: number
  /**都道府県コード */
  KEN_CD?: number
  /**農場番号 */
  ITAKU_NAME?: number
  /**農場名 */
  ITAKU_CD?: number
  /**まとめ先 */
  MATOMESAKI?: number
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/**初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**契約者農場情報 */
  KEIYAKUSYA_NOJO: DetailVM
  /**編集区分 */
  EDIT_KBN: EnumEditKbn
}

/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
  /**更新時間 */
  UP_DATE: Date
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /**対象期 */
  KI: number
  /**契約者情報プルダウンリスト */
  KEIYAKUSYA_CD_NAME_LIST: CodeNameModel[]
}

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者農場情報リスト */
  KEKKA_LIST: SearchRowVM[]
}

/**初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**契約者名 */
  KEIYAKUSYA_NAME: string
  /**都道府県情報プルダウンリスト */
  KEN_CD_NAME_LIST: CodeNameModel[]
  /**契約者農場情報 */
  KEIYAKUSYA_NOJO: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface SearchRowVM {
  /**農場コード */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**住所 */
  ADDR: string
}

/**契約者農場情報 */
export interface DetailVM {
  /**期 */
  KI: number
  /**事務委託先 */
  ITAKU_CD: number
  /**都道府県コード */
  KEN_CD?: number
  /**事務委託先名称（正式） */
  ITAKU_NAME: string
  /**事務委託先名称（略称） */
  ITAKU_RYAKU: string
  /**代表者氏名 */
  DAIHYO_NAME: string
  /**担当者氏名 */
  TANTO_NAME: string
  /**住所（郵便番号） */
  ADDR_POST: string
  /**住所1 */
  ADDR_1: string
  /**住所2 */
  ADDR_2: string
  /**住所3 */
  ADDR_3: string
  /**住所4 */
  ADDR_4: string
  /**連絡先（電話） */
  ADDR_TEL: string
  /**連絡先（FAX） */
  ADDR_FAX: string
  /**メールアドレス */
  ADDR_E_MAIL: string
  /**金融機関情報印字有無 */
  BANK_INJI_KBN?: number
  /**まとめ先 */
  MATOMESAKI?: number
  /**申込書類 */
  MOSIKOMISYORUI: string
  /**請求書・契約書 */
  SEIKYUSYO: string
  /**入金方法 */
  NYUKINHOHO: string
  /**ラベル発行 */
  LABELHAKKO?: number
  /**除外フラグ */
  JYOGAI_FLG?: number
  /**備考 */
  BIKO: string

  /**農場コード */
  NOJO_CD: number
  /**農場名称 */
  NOJO_NAME: string

  /**明細番号 */
  MEISAI_NO: number
  /**更新時間 */
  UP_DATE: Date
}
