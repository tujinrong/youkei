/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 生産者積立金等請求・返還一覧表
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.04
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
  /**請求回数 */
  SEIKYU_KAISU: string
  /**対象日(現在) */
  SEIKYU_DATE: string
  /**契約者区分コード */
  KEIYAKU_KBN: FmToModel
  /**請求・返還区分 */
  CYOSYU_HENKAN_KBN_LABELS: {
    CYOSYU_HENKAN_KBN1: boolean
    CYOSYU_HENKAN_KBN2: boolean
    CYOSYU_HENKAN_KBN3: boolean
    CYOSYU_HENKAN_KBN4: boolean
  }
  /**契約状況 */
  KEIYAKU_JYOKYO: {
    KEIZOKU: boolean
    SHINKI: boolean
    CHUSHI: boolean
  }
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
