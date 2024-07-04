// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目選択
//            インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
  /**大分類 */
  daibunrui?: string
  /**中分類 */
  tyubunrui?: string
  /**小分類 */
  syobunrui?: string
}

/** 保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /**データソースID */
  datasourceid: string
  /**SQLカラム集合 */
  sqlcolumns: any
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**テーブル項目リスト */
  tableitemlist: TableItemVM[]
  /**次の分類リスト */
  nextbunruilist: TableVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 検索処理 */
export interface TableItemVM {
  /**項目ID */
  itemid: string
  /**表示名称 */
  itemhyojinm: string
  /**SQLカラム */
  sqlcolumn: string
  /**大分類 */
  daibunrui: string
  /**中分類 */
  tyubunrui: string
  /**小分類 */
  syobunrui: string
}
/** 検索処理 */
export interface TableVM {
  /**テーブル·別名 */
  tablealias: string
  /**テーブル物理名 */
  tablenm: string
}
