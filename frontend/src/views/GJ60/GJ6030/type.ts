/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 各種マスタの次期対応コピー処理
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
  /** マスタ選択 */
  MASUTA_SENTAKU: number | undefined
  /** 事務委託先マスタ処理件数(XX期) */
  JIMUITAKU_KENSU: number | undefined
  /** 契約者マスタ処理件数(XX期) */
  KEIYAKUSYA_KENSU: number | undefined
  /** 農場マスタ処理件数(XX期) */
  NOJO_KENSU: number | undefined
}
