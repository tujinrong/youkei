// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目ツリー参照
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
  /**データソースID */
  datasourceid: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**項目ツリー */
  itemtree: ItemTreeNode<SimpleItemVM>
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** ツリーノード */
export interface ItemTreeNode<T> extends SimpleItemVM {
  /**ツリーノード */
  value: T
  /**次のレベル */
  children: ItemTreeNode<T>[]
}

/** 簡単項目 */
export interface SimpleItemVM {
  /**SQLカラム */
  readonly sqlcolumn: string
  /**項目ID */
  readonly itemid: string
  /**表示名称 */
  readonly itemhyojinm: string
  /**リーフノードフラグ */
  readonly isleaf: boolean
}

/** 分類キー */
export interface BuruiKey {
  /**大分類 */
  readonly daibunrui: string
  /**中分類 */
  readonly tyubunrui: string
  /**小分類 */
  readonly syobunrui: string
}
