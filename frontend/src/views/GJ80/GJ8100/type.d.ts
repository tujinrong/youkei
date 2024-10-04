/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 消費税率一覧
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.10.01
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {}
/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {
  /**適用開始日 */
  TAX_DATE_FROM: Date | undefined
  /**更新時間 */
  UP_DATE: Date
}

/**検索処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /**適用開始日 */
  TAX_DATE_FROM: Date | undefined
}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**消費税率情報 */
  TAX: DetailVM
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**検索処理(一覧画面) */
export interface SearchResponse extends DaResponseBase {
  /**消費税率情報リスト */
  KEKKA_LIST: SearchRowVM[]
}

/**検索処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**消費税率情報 */
  TAX: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 消費税率情報リスト */
export interface SearchRowVM {
  /**適用開始日  */
  TAX_DATE_FROM: Date | undefined
  /**適用終了日  */
  TAX_DATE_TO: Date | undefined
  /**消費税率(%)  */
  TAX_RITU: number | undefined
}

/**契約者農場情報 */
export interface DetailVM {
  /**適用開始日  */
  TAX_DATE_FROM: Date | undefined
  /**適用終了日  */
  TAX_DATE_TO: Date | undefined
  /**消費税率(%)  */
  TAX_RITU: number | undefined
  /**データ更新日 */
  UP_DATE: Date | undefined
}
