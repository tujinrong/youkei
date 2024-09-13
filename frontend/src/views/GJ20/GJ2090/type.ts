/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者積立金等入金
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.10
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

import {EnumAndOr} from "@/enum";

/** 処理 */
export interface SaveRequest extends DaRequestBase {
  /** */
  KEKKA: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 情報 */
export interface SearchVM {
  /** 対象期 */
  KI: number | undefined
  /** 請求・返還回数 */
  SEIKYU_KAISU: FmToModel
  /** 都道府県 */
  KEN_CD: FmToModel
  /** 事務委託先 */
  JIMUITAKU_CD: number | undefined
  /** 契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /** 契約者名（カナ） */
  KEIYAKUSYA_KANA: string
  /** 契約者名（漢字） */
  KEIYAKUSYA_NAME: string
  /** 請求・返還金額（入金金額） */
  SAGUKU_SEIKYU_KIN: FmToModel
  /** 納付方法 */
  SEIKYU_HENKAN_KBN: number | undefined
  /** 処理状況 */
  SYORI_JOKYO_KBN: number | undefined
  /** 入金・返還日 */
  NYUKIN_DATE: CmDateFmToModel
  /** 検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/**検索処理(一覧画面) */
export interface SearchRequest {
  /** 対象期 */
  KI: number | undefined
  /** 請求・返還回数 */
  SEIKYU_KAISU: number | undefined
  /** 積立金区分 */
  TUMITATE_KBN: number | undefined
  /** 契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** フリガナ */
  KEIYAKUSYA_KANA: string
  /** 処理状況コード 	*/
  SYORI_JOKYO_KBN: number | undefined
  /** 処理状況名 */
  SYORI_JOKYO_KBN_NAME: string
  /** 請求・返還コード */
  SEIKYU_HENKAN_KBN: number | undefined
  /** 請求・返還名 */
  SEIKYU_HENKAN_KBN_NAME: string
  /** 請求・返還日 */
  SEIKYU_DATE: Date | undefined
  /** 入金・振込日 */
  NYUKIN_DATE: Date | undefined
  /** 請求金額/返還金額 */
  SEIKYU_KIN: number | undefined
}

/**積立金情報 */
export interface DetailVM {
  /** 積立金区分 */
  TUMITATE_KBN: number | undefined
  /** 契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /** 都道府県コード */
  KEN_CD: number | undefined
  /** 都道府県名 */
  KEN_CD_NAME: string
  /** 処理状況コード */
  SYORI_JOKYO_KBN: number | undefined
  /** 処理状況名 */
  SYORI_JOKYO_KBN_NAME: string
  /** 契約者名(漢字) */
  KEIYAKUSYA_NAME : string
  /** 契約者名(カナ) */
  KEIYAKUSYA_KANA: string
  /** 住所（郵便番号） */
  ADDR_POST: string
  /** 住所 */
  ADDR: string
  /** 連絡先（電話1） */
  ADDR_TEL1: string
  /** 連絡先（電話2） */
  ADDR_TEL2: string
  /** 連絡先（FAX） */
  ADDR_FAX: string
  /** 振込先コード（金融機関） */
  FURI_BANK_CD: string
  /** 金融機関名 */
  BANK_NAME: string
  /** 振込先支店コード */
  FURI_BANK_SITEN_CD: string
  /** 支店名 */
  SITEN_NAME: string
  /** 口座種別コード */
  FURI_KOZA_SYUBETU: number | undefined
  /** 口座種別名 */
  FURI_KOZA_SYUBETU_NAME: string
  /** 口座番号 */
  FURI_KOZA_NO: string
  /** 口座名義人（カナ） */
  FURI_KOZA_MEIGI_KANA: string
  /** 事務委託先 */
  JIMUITAKU_CD: number | undefined
  /** 事務委託先名 */
  ITAKU_NAME: string
  /** 対象期 */
  KI: number | undefined
  /** 請求・返還日 */
  SEIKYU_DATE: Date | undefined
  /** 請求・返還回数 */
  SEIKYU_KAISU: number | undefined
  /** 徴収・返還区分コード */
  SEIKYU_HENKAN_KBN: number | undefined
  /** 徴収・返還区分名 */
  SEIKYU_HENKAN_KBN_NAME: string
  /** 入金・振込日 */
  NYUKIN_DATE: Date | undefined
  /** 請求・返還金額 */
  SAGUKU_SEIKYU_KIN: number | undefined
  /** 積立金額 */
  TUMITATE_KIN: number | undefined
  /** 手数料 */
  TESURYO: number | undefined
  /** 積立金等総計 */
  SEIKYU_KIN: number | undefined
  /** 備考 */
  BIKO: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface FmToModel {
  VALUE_FM: number | undefined
  VALUE_TO: number | undefined
}

export interface CmDateFmToModel {
  VALUE_FM: Date | undefined
  VALUE_TO: Date | undefined
}
