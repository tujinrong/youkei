// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力項目選択
//             インターフェース定義
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理 */
export interface InitRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**帳票ID */
  yosikiid: string
}

/**検索処理 */
export interface SearchRequest extends InitRequest {
  /**出力パターン番号 */
  outputptnno?: number
}

/**保存処理 */
export interface SaveRequest extends SearchRequest {
  /**出力パターン名 */
  outputptnnm: string
  /**帳票項目リスト(出力用、ソート済) */
  kekkalist: string[]
  /**更新日時 */
  upddttm?: Date | string
}

/**削除処理 */
export interface DeleteRequest extends SearchRequest {
  /**更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(出力パターン) */
  selectorlist: DaSelectorModel[]
}

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**出力パターン名 */
  outputptnnm: string
  /**帳票項目リスト(全て) */
  kekkalist1: RowVM[]
  /**帳票項目リスト(出力用、ソート済) */
  kekkalist2: string[]
  /**更新日時 */
  upddttm?: Date | string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 出力項目情報*/
export interface RowVM {
  /**様式項目ID */
  reportitemid: string
  /**帳票項目名称 */
  reportitemnm: string
}
