// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(固定)
//            インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { Enum検索条件区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
}

/** 検索処理 */
export interface SearchRequest extends InitRequest {
  /**条件ID */
  jyokenid: number
}

/** 削除処理 */
export interface DeleteRequest extends SearchRequest {
  /**更新日時 */
  upddttm: Date | string
  /**検索条件区分 */
  jyokenkbn: string
}

/** 登録処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /**データソースID */
  datasourceid: string
  /**検索条件区分 */
  jyokenkbn: Enum検索条件区分
  /**項目SEQ */
  sqlcolumn: string
  /**ラベル */
  jyokenlabel: string
  /**初期値 */
  syokiti: string
  /**条件ID */
  jyokenid: number
  /**更新日時 */
  upddttm?: Date | string
}

/** 条件SQL取得 */
export interface SqlRequest extends DaRequestBase {
  /**SQLカラム */
  sqlcolumn: string
  /**初期値 */
  value: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**項目大分類リスト */
  itemdaibunruilist: ItemDaiBunruiVM[]
  /**ドロップダウンリスト(固定検索条件区分) */
  selectorlist: DaSelectorModel[]
}

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**検索条件区分 */
  jyokenkbn: Enum検索条件区分
  /**ラベル */
  jyokenlabel: string
  /**大分類 */
  daibunrui: string
  /**項目ID */
  itemid: string
  /**SQLカラム */
  sqlcolumn: string
  /**表示名称 */
  itemhyojinm: string
  /**データ型 */
  datatype: string
  /**初期値 */
  syokiti?: string
  /**SQL */
  sql: string
  /**更新日時 */
  upddttm: Date | string
}

/** 条件SQL取得 */
export interface SqlResponse extends DaResponseBase {
  /**SQL */
  sql: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 初期化処理 */
export interface ItemDaiBunruiVM {
  /**大分類 */
  daibunrui: string
  /**項目リスト */
  itemlist: DatasourceItemVM[]
}

/** 初期化処理 */
export interface DatasourceItemVM {
  /**項目ID */
  itemid: string
  /**SQLカラム */
  sqlcolumn: string
  /**表示名称 */
  itemhyojinm: string
  /**データ型 */
  datatype: string
}
