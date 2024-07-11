/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.04.12
 * 作成者　　:
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumDataType, Enumコントロール } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {
  /**業務コード */
  gyoumucd: string
  /**データソース */
  datasourcenm?: string
}

/** 初期化処理(詳細画面) */
export interface InitDetailTabRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
}

/** 削除処理(詳細画面) */
export interface DeleteRequest extends InitDetailTabRequest {
  /**更新日時 */
  upddttm?: Date | string
}

/**保存処理(詳細画面) */
export interface SaveRequest extends DeleteRequest {
  /**データソース名称 */
  datasourcenm: string
  /**業務 */
  gyoumu: string
}

/**項目削除処理(詳細画面) */
export interface DeleteItemsRequest extends CmSaveRequestBase {
  /**データソースID */
  datasourceid: string
  deleteitemlist: DeleteTableItemVM[]
}

/**検索処理(詳細画面:検索条件) */
export interface SearchConditionTabRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
  /**ステータス */
  status: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(業務) */
  selectorlist: DaSelectorModel[]
}

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**データグループ情報 */
  kekkalist: SearchVM[]
}

/**初期化処理(詳細画面) */
export interface InitDetailTabResponse extends DaResponseBase {
  /**データソースID */
  datasourceid: string
  /**メインテーブル別名 */
  maintablealias: string
  /**データソース名称 */
  datasourcenm: string
  /**業務 */
  gyoumu: string
  /**更新日時 */
  upddttm: Date | string
  /**メインテーブル */
  maindata: DatasourceTableVM
  /**結合テーブルリスト */
  joindata: DatasourceTableVM[]
  /**マスタテーブルリスト */
  masterdata: DatasourceTableVM[]
  /**フリーテーブルリスト */
  freedata: DatasourceTableVM[]
  /**Viewリスト */
  viewdata: DatasourceTableVM[]
}

/**検索処理(詳細画面:検索条件タブ(通常)) */
export interface SearchConditionTabResponse extends DaResponseBase {
  /**検索条件(通常)リスト */
  conditionlist: ConditionVM[]
}

/**検索処理(詳細画面:その他条件タブ) */
export interface SearchOtherConditionTabResponse extends DaResponseBase {
  /**検索条件(その他条件)リスト */
  fixedconditionlist: FixedConditionVM[]
}

/** 戻る更新時刻 */
export interface SaveResponse extends DaResponseBase {
  /**更新日時 */
  upddttm: Date
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchVM {
  /**データソースID */
  datasourceid: string
  /**データソース名称 */
  datasourcenm: string
  /**業務 */
  gyoumu: string
  /**メインテーブル名称 */
  maintablehyojinm: string
  /**メインテーブル物理名 */
  maintablenm: string
}

/** データソーステーブル */
export interface DatasourceTableVM {
  /**テーブル·別名 */
  tablealias: string
  /**テーブル物理名 */
  tablenm: string
  /**テーブル名称 */
  tablehyojinm: string
  /**データソース項目リスト */
  itemlist: DatasourceTableItemVM[]
  /**更新日時 */
  upddttm: Date | string
}

/** データソース項目 */
export interface DatasourceTableItemVM extends DeleteTableItemVM {
  /**データソース項目ID */
  itemid: string
  /**表示名称 */
  itemhyojinm: string
  /**大分類 */
  daibunrui: string
  /**中分類 */
  tyubunrui?: string
  /**小分類 */
  syobunrui?: string
}

/** 項目削除処理 */
export interface DeleteTableItemVM {
  /**SQLカラム */
  sqlcolumn: string
  /**更新日時 */
  upddttm: Date | string
}

/** 検索条件(通常) */
export interface ConditionVM {
  /**条件ID */
  jyokenid: string
  /**ラベル */
  jyokenlabel: string
  /**SQL */
  sql: string
  /**コントロール */
  control: string
  /** 曖昧検索区分 */
  aimaikbn?: string
}
/** 検索条件(固定) */
export interface FixedConditionVM {
  /**条件ID */
  jyokenid: number
  /**ラベル */
  jyokenlabel: string
  /**SQL */
  sql: string
  /**検索条件区分 */
  jyokenkbn: string
  /**変数名 */
  variables?: string
  /**テーブル名 */
  tablealias: string
  /**コントロール区分 */
  controlkbn: Enumコントロール
  /**名称マスタコード */
  mastercd?: string
  /**名称マスタパラメータ */
  masterpara?: string
  /** 参照元SQL */
  sansyomotosql?: string
  /**データ型 */
  datatype: EnumDataType
  /** 曖昧検索区分 */
  aimaikbn?: string
}

/** ----------------------------customizeType------------------------------------ */

export type totalTableLlistType = {
  maindata: DatasourceTableVM[]
  masterTable: DatasourceTableVM[]
  transactionTable: DatasourceTableVM[]
  views: DatasourceTableVM[]
}
