/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 生産者積立金等請求・返還一覧表(処理確定・未処理)
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
  /**対象期 */
  KI: number
  /**請求回数 */
  SEIKYU_KAISU: FmToModel
  /**請求・返還日 */
  SEIKYU_DATE: CmDateFmToModel
  /**入金・振込日 */
  NYUKIN_DATE: CmDateFmToModel
  /**契約区分コード */
  KEIYAKU_KBN: FmToModel
  /**請求・返還区分 */
  SEIKYU_HENKAN_KBN: {
    SEIKYU_SHINKI: boolean
    ICHIBU_SEIKYU: boolean
    ICHIBU_HENKAN: boolean
    ZENGAKU_HENKAN: boolean
  }
  /**入金・振込状況 */
  SYORI_JYOKYO_KBN: {
    NYUKIN_FURIKOMI_ZUMI: boolean
    MI_NYUKIN_FURIKOMI: boolean
    ICHIBU_NYUKIN: boolean
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

export interface CmDateFmToModel {
  VALUE_FM: Date | undefined
  VALUE_TO: Date | undefined
}
