/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助金交付一覧（互助金種類・鶏の種類・農場）
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
  /**対象期 */
  KI: number
  /**認定回数 */
  HASSEI_KAISU: FmToModel
  /**計算回数 */
  KEISAN_KAISU: FmToModel
  /**契約区分コード */
  KEIYAKU_KBN: FmToModel
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
  /**契約区分情報プルダウンリスト */
  KEIYAKU_KBN_CD_NAME_LIST: CmCodeNameModel[]
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
