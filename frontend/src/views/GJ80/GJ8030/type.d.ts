/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 日本養鶏協会マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.19
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumEditKbn } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD: string
}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**契約者農場情報 */
  KYOKAI: DetailVM
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**金融機関情報プルダウンリスト */
  BANK_LIST: CmCodeNameModel[]
  /**本支店情報プルダウンリスト */
  SITEN_LIST: CmCodeNameModel[]
  /**口座種別情報プルダウンリスト */
  KOZA_SYUBETU_LIST: CmCodeNameModel[]
}

/**検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /**協会情報 */
  KYOKAI: DetailVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 日本養鶏協会マスタメンテナンス情報 */
export interface DetailVM {
  /** 協会区分 */
  KYOKAI_KBN: number | undefined
  /** 協会名称 */
  KYOKAI_NAME: string
  /** 支援事業名 */
  JIGYO_NAME: string
  /** 役職名 */
  YAKUMEI: string
  /** 会長名 */
  KAICHO_NAME: string
  /** 予備 */
  YOBI1: string
  /** 郵便番号 */
  POST: string
  /** 住所1 */
  ADDR1: string
  /** 住所2 */
  ADDR2: string
  /** 発行番号・漢字 */
  HAKKO_NO_KANJI: string
  /** 電話1 */
  TEL1: string
  /** FAX1 */
  FAX1: string
  /** E-Mail1 */
  E_MAIL1: string
  /** 電話2 */
  TEL2: string
  /** FAX2 */
  FAX2: string
  /** E-Mail2 */
  E_MAIL2: string
  /** ホームページURL */
  HP_URL: string
  /** 登録番号 */
  TOUROKU_NO: string
  /** 振込　金融機関 */
  FURI_BANK_CD: string
  /** 振込　本支店 */
  FURI_BANK_SITEN_CD: string
  /** 振込　口座種別 */
  FURI_KOZA_SYUBETU?: number
  /** 振込　口座番号 */
  FURI_KOZA_NO: string
  /** 振込　種別コード */
  FURI_SYUBETU: number | undefined
  /** 振込　口座名義人（カナ） */
  FURI_KOZA_MEIGI_KANA: string
  /** 振込　口座名義人（漢字） */
  FURI_KOZA_MEIGI: string
  /** 支払　金融機関 */
  KOFU_BANK_CD: string
  /** 支払　本支店 */
  KOFU_BANK_SITEN_CD: string
  /** 支払　口座種別 */
  KOFU_KOZA_SYUBETU?: number
  /** 支払　口座番号 */
  KOFU_KOZA_NO: string
  /** 支払　種別コード */
  KOFU_SYUBETU?: number
  /** 支払　コード区分 */
  KOFU_CD_KBN?: number
  /** 支払　依頼人コード */
  KOFU_KAISYA_CD?: number
  /** 支払　振込依頼人名（ﾌﾘｶﾞﾅ） */
  KOFU_KAISYA_NAME: string
  /** データ更新日 */
  UP_DATE?: Date
}
