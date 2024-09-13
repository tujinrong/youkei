/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 生産者積立金等集計表作成処理（鶏の種類別）
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.12
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
  /**契約区分コード */
  KEIYAKU_KBN: FmToModel
  /**集計区分 */
  SYUKEI_KBN: number | undefined
  /**入力状況 */
  NYURYOKU_JYOKYO: {
    NYURYOKU_CYU: boolean
    NYURYOKU_KAKUNIN: boolean
  }
  /**都道府県 */
  KEN_CD: FmToModel
  /**事務委託先番号コード */
  JIMUITAKU_CD: FmToModel
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
  /**都道府県情報プルダウンリスト */
  KEN_CD_NAME_LIST: CmCodeNameModel[]
  /**事務委託先情報プルダウンリスト */
  ITAKU_CD_NAME_LIST: CmCodeNameModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface FmToModel {
  VALUE_FM: number | undefined
  VALUE_TO: number | undefined
}
