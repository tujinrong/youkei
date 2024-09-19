/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助金交付金通知書発行処理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.19
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(プレビュー画面) */
export interface InitRequest extends DaRequestBase {
  /**対象期 */
  KI: number
}

/**プレビュー処理(プレビュー画面) */
export interface PreviewRequest extends DaRequestBase {
  /**出力区分 */
  SYUTURYOKU_KBN: number | undefined
  /** 対象期・認定回数(対象期) */
  KI: number | undefined
  /** 対象期・認定回数(認定回数) */
  HASSEI_KAISU: number | undefined
  /** 計算回数 */
  KEISAN_KAISU: number | undefined
  /** 振込予定日 */
  FURIKOMI_YOTEI_DATE: Date | undefined
  /**発行日 */
  SEIKYU_HAKKO_DATE: Date | undefined
  /**発信番号（発信年） */
  SEIKYU_HAKKO_NO_NEN: number
  /**発信番号（発信連番） */
  SEIKYU_HAKKO_NO_RENBAN: number
  /**事務委託先番号コード */
  JIMUITAKU_CD: FmToModel
  /**契約者番号コード */
  KEIYAKUSYA_CD: FmToModel
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(プレビュー画面) */
export interface InitResponse extends DaResponseBase {
  /**対象期 */
  KI: number
  /**事務委託先情報プルダウンリスト */
  ITAKU_CD_NAME_LIST: CmCodeNameModel[]
  /**契約者番号情報プルダウンリスト */
  KEIYAKUSYA_CD_NAME_LIST: CmCodeNameModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface FmToModel {
  VALUE_FM: number | undefined
  VALUE_TO: number | undefined
}
