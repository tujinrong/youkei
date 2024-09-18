/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
// リクエスト
//-------------------------------------------------------------------

/** 初期化処理_請求書発行画面リクエスト */
export interface InitRequest extends DaRequestBase {
  /** 期 */
  KI?: number
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number
  /** 請求返還回数 */
  SEIKYU_KAISU?: number
}

/** プレビュー処理_通知書発行画面リクエスト */
export interface PreviewRequest extends DaRequestBase {
  /** 期 */
  KI?: number
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number
  /** 請求返還回数 */
  SEIKYU_KAISU?: number
  /** 積立金区分 */
  TUMITATE_KBN?: number
  /** 出力区分 (1: 仮発行, 2: 初回発行, 3: 再発行, 4: 修正発行, 5: 通知書取消) */
  SYUTURYOKU_KBN?: number
  /** 納付期限 */
  NOFUKIGEN_DATE?: Date
  /** 発行日 */
  SEIKYU_HAKKO_DATE?: Date
  /** 発信番号（発信年） */
  SEIKYU_HAKKO_NO_NEN?: number
  /** 発信番号（発信連番） */
  SEIKYU_HAKKO_NO_RENBAN?: number
}

/** 取消処理_通知書発行画面リクエスト */
export interface CancelRequest extends DaRequestBase {
  /** 期 */
  KI?: number
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number
  /** 請求返還回数 */
  SEIKYU_KAISU?: number
  /** 積立金区分 */
  TUMITATE_KBN?: number
}

//-------------------------------------------------------------------
// レスポンス
//-------------------------------------------------------------------

/** 初期化処理_請求書発行画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 積立金区分 */
  TUMITATE_KBN?: number
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** 納付期限 */
  NOFUKIGEN_DATE?: Date
  /** 発行日 */
  SEIKYU_HAKKO_DATE?: Date
  /** 発信番号（文字） */
  HAKKO_NO_KANJ: string
  /** 発信番号（発信年） */
  SEIKYU_HAKKO_NO_NEN?: number
  /** 発信番号（発信連番） */
  SEIKYU_HAKKO_NO_RENBAN?: number
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------


