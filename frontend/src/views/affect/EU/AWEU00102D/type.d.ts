// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: データグループ新規作成
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /**テーブル·別名 */
  tablealias: string
}

/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
  /**データソース名称 */
  datasourcenm: string
  /**業務コード */
  gyoumucd: string
  /**メインテーブル別名 */
  maintablealias: string
  /**その他テーブルリスト */
  jointablelist: any[] //front?
  /**メインテーブルSQLカラム集合 */
  sqlcolumns: string[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**メインテーブルリスト */
  tablelist: TableVM[]
  /**業務区分リスト */
  selectorlist: DaSelectorModel[]
}

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**その他テーブルリスト */
  jointablelist: TableVM[]
  /**テーブル項目リスト */
  tableitemlist: TableItemVM[]
  /**大分類リスト */
  daibunruilist: string[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 初期化処理 */
export interface TableVM {
  /**テーブル·別名 */
  tablealias: string
  /**テーブル物理名 */
  tablenm: string
  /**テーブル名称 */
  tablehyojinm: string
}

/** 検索処理 */
export interface TableItemVM {
  /**SQLカラム */
  sqlcolumn: string
  /**項目ID */
  itemid: string
  /**表示名称 */
  itemhyojinm: string
  /**大分類 */
  daibunrui: string
  /**中分類 */
  tyubunrui: string
  /**小分類 */
  syobunrui: string
  /**テーブル·別名 */
  tablealias: string
}
