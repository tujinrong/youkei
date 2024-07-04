// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目出力順編集
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理 */
export interface InitRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
}

/**検索処理 */
export interface SearchRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**出力順パターン番号 */
  sortptnno: string
}

/**項目検索処理 */
export interface SearchItemsRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**帳票項目ID */
  selecteditemids: string[]
}

/**新規処理 */
export interface AddRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**出力順パターン名 */
  sortptnnm: string
  /**出力順の項目詳細リスト */
  sortsublist: SortSubVM[]
  /**様式更新日時 */
  yosikiupddttm?: Date | string
}

/** 更新処理 */
export interface UpdateRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**出力順パターン番号 */
  sortptnno: string
  /**出力順パターン名 */
  sortptnnm: string
  /**出力順の項目詳細リスト */
  sortsublist: SortSubVM[]
  /**出力順更新日時 */
  sortupddttm: Date | string
  /**様式更新日時 */
  yosikiupddttm?: Date | string
}

/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**出力順パターン番号 */
  sortptnno: string
  /**出力順更新日時 */
  sortupddttm: Date | string
  /**様式更新日時 */
  yosikiupddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(出力順) */
  selectorlist1: DaSelectorModel[]
  /**ドロップダウンリスト(項目) */
  selectorlist2: DaSelectorModel[]
  /**出力順パターン番号 */
  sortptnno?: string
  /**出力順の項目詳細リスト */
  sortsublist: SortSubVM[]
  /**出力順更新日時 */
  sortupddttm?: Date | string
  /**様式更新日時 */
  yosikiupddttm: string
}

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**出力順の項目詳細リスト */
  sortsublist: SortSubVM[]
  /**出力順更新日時 */
  sortupddttm: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 初期化処理 */
export interface SortSubVM {
  /**帳票項目ID */
  reportitemid: string
  /**降順フラグ */
  descflg: boolean
  /**改ページフラグ */
  pageflg: boolean
}
