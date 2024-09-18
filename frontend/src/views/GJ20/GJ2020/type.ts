/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者積立金計算処理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.03
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
  /** 請求・返還回数 */
  SEIKYU_KAISU: number | undefined
  /** 手数料率 */
  TESURYO_KAISU: number | undefined
  /** 徴収・返還区分 */
  CYOSYU_HENKAN_KBN: string
  /** 請求・返還年月日 */
  SEIKYU_DATE: Date | undefined
  /** 納付期限 */
  KIGEN_DATE: Date | undefined
  /** 請求(新規) */
  SHINKI: boolean
  /** 請求兼返還(徴収) */
  CYOSYU: boolean
  /** 請求兼返還(返還) */
  HENKAN: boolean
  /** 全額返還 */
  ZENGAKU: boolean
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
  /** 回数 */
  SEIKYU_KAISU: number | undefined
  /** 処理日 */
  SYORI_DATE: Date | undefined
  /** 計算区分 */
  KEIYAKU_HENKO_KBN: number | undefined
  /** 請求・返還日 */
  SEIKYU_DATE: Date | undefined
  /** 納付期限 */
  KIGEN_DATE: Date | undefined
  /** 振込予定日 */
  FURIKOMI_YOTEI_DATE: Date | undefined
  /** 対象者数 */
  SEIKYU_TAISYO_SYASU: number | undefined
  /** 積立金等総額 */
  TUMITATE_KINGAKU: number | undefined
  /** 徴収金額 */
  CYOSYU_KINGAKU: number | undefined
  /** 返還金額 */
  HENKAN_KINGAKU: number | undefined
}
