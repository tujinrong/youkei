/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 生産者積立金返還金計算処理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.23
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
  /** 処理選択 */
  SYORI_SENTAKU: number | undefined
  /** 処理のタイプ */
  SYORI_TYPE: number | undefined
  /** 前期積立金取込処理日 */
  ZENKI_TUMITATE_DATE: Date | undefined
  /** 前期交付金取込日 */
  ZENKI_KOFU_DATE: Date | undefined
  /** 返還金計算日 */
  HENKAN_KEISAN_DATE: Date | undefined
  /** 前期積立金返還人数 */
  ZENKI_HENKAN_NINSU: number | undefined
  /** 前期積立金返還金合計 */
  ZENKI_HENKAN_GOKEI: number | undefined
  /** 前期積立金返還率 */
  ZENKI_HENKAN_RITU: number | undefined
}
