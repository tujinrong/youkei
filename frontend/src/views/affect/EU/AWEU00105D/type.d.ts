// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 検索条件編集(通常)
//            インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

import { Enumコントロール, CodeTypeEnum, Enum検索条件区分 } from '#/Enums'

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

/** 登録処理*/
export interface SaveRequest extends CmSaveRequestBase {
  /**データソースID */
  datasourceid: string
  /** SQLカラム */
  sqlcolumn: string
  /** ラベル */
  jyokenlabel: string
  /** コントロール区分 */
  controlkbn: Enumコントロール
  /** 名称マスタコード */
  mastercd?: string
  /** 名称マスタパラメータ */
  masterpara?: string
  /** 参照元SQL */
  sansyomotosql?: string
  /** 年度範囲区分 */
  nendohanikbn?: string
  /** 初期値 */
  syokiti?: string
  /** 曖昧検索区分 */
  aimaikbn?: string
  /**条件ID */
  jyokenid: number
  /**更新日時 */
  upddttm?: Date | string
}

/** 条件SQL取得*/
export interface SqlRequest extends DaRequestBase {
  /**SQLカラム */
  sqlcolumn: string
  /**コントロール区分 */
  controlkbn: Enumコントロール
}

/** 選択条件情報を取得する*/
export interface SearchJokenDetailRequest extends DaRequestBase {
  /**コントロール区分 */
  controlkbn?: number
  /**名称マスタコード */
  mastercd: string
  /**名称マスタパラメータ */
  masterpara: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理*/
export interface InitResponse extends DaResponseBase {
  /**項目大分類リスト */
  itemdaibunruilist: ItemDaiBunruiVM[]
  /**コントロールドロップダウンリスト */
  selectorlist: DaSelectorModel[]
  /**マスタリスト */
  masterlist: MasterVM[]
  /**年度マスタリスト */
  toshilist: { nmmaincd: string; nmsubcd: number; nmcd: string; nm: string }[]
  /**検索区分リスト */
  kensakukbnlist: DaSelectorModel[]
}

/** 検索処理*/
export interface SearchResponse extends DaResponseBase {
  /**ラベル */
  jyokenlabel: string
  /** 大分類 */
  daibunrui: string
  /**項目ID */
  itemid: string
  /**SQLカラム */
  sqlcolumn: string
  /**表示名称 */
  itemhyojinm: string
  /**データ型 */
  datatype: string
  /**値 */
  value?: string
  /**コントロール区分 */
  controlkbn: Enumコントロール
  /**名称マスタコード */
  mastercd?: string
  /**名称マスタパラメータ */
  masterpara?: string
  /** 参照元SQL */
  sansyomotosql?: string
  /**初期値*/
  syokiti?: string
  /**SQL */
  sql: string
  /** 曖昧検索区分 */
  aimaikbn?: string
  /**更新日時 */
  upddttm: Date | string
  /**使用済み */
  shiyoFlg: boolean
}

/** 条件SQL取得*/
export interface SqlResponse extends DaResponseBase {
  /**SQL */
  sql: string
}
/** 選択条件情報を取得する*/
export interface SearchJokenDetailResponse extends DaResponseBase {
  /**選択リスト */
  selectlist?: DaSelectorModel[]
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
  /**SQLカラム */
  sqlcolumn: string
  /**項目ID */
  itemid: string
  /**表示名称 */
  itemhyojinm: string
  /**データ型 */
  datatype: string
  /**名称マスタコード */
  mastercd?: string
  /**名称マスタパラメータ */
  masterpara?: string
}

/** 初期化処理 */
export interface CdVM {
  /**カラム */
  columnnm: string
  /**カラム名称 */
  columncomment: string
  /**コードタイプ */
  codetype: CodeTypeEnum
  /**選択リスト */
  selectorlist?: DaSelectorKeyModel[]
}

/** 初期化処理 */
export interface MasterVM {
  /**マスタコード */
  mastercd: string
  /**マスタ名称 */
  masterhyojinm: string
  /**コードリスト */
  cdlist: CdVM[]
}
