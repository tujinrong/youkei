/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助交付金計算処理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.19
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 処理 */
export interface SaveRequest extends DaRequestBase {
  /** */
  KEKKA: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 情報 */
export interface DetailVM {
  /** 処理区分 */
  SYORI_KBN: number | undefined
  /** 対象期 */
  KI: number | undefined
  /** 認定回数 */
  HASSEI_KAISU: number | undefined
  /** 計算回数 */
  KEISAN_KAISU: number | undefined
  /** 振込予定日 */
  FURIKOMI_YOTEI_DATE: Date | undefined
  /** 契約者番号 */
  KEIYAKUSYA_CD: number | undefined
}

/**検索処理(一覧画面) */
export interface SearchRequest {
  /** 対象期 */
  KI: number | undefined
  /** 認定回数 */
  HASSEI_KAISU: number | undefined
  /** 計算回数 */
  KEISAN_KAISU: number | undefined
  /** 処理日 */
  SYORI_DATE: Date | undefined
  /** 振込予定日 */
  FURI_YOTEI_DATE: Date | undefined
  /** 対象者数 */
  TAISYO_SYASU: number | undefined
  /** 経営支援金額 */
  KEIEI_KINGAKU: number | undefined
  /** 焼却・埋却金額 */
  SYOKYAKU_KINGAKU: number | undefined
  /** 合計交付金額 */
  KOFU_KINGAKU: number | undefined
}
