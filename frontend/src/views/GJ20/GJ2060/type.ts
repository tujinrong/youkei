/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 家畜防疫互助基金積立金等請求書兼返還金通知書（全額返還）
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.06
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
  SYUTURYOKU_KBN: number
  /**対象期 */
  KI: number
  /**請求回数 */
  SEIKYU_KAISU: string
  /**返還年月日 */
  SEIKYU_DATE: string
  /**返還期限 */
  NOFUKIGEN_DATE: string
  /**発行日 */
  SEIKYU_HAKKO_DATE: string
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
