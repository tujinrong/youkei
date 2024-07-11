// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 項目編集
//            インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { Enum使用区分, Enum出力項目区分, Enum集計項目区分, EnumDataType } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
  /**SQLカラム */
  sqlcolumn?: string
}

/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /**データソースID */
  datasourceid: string
  /**SQLカラム */
  sqlcolumn: string
}

/** 新規/更新処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /**データソースID */
  datasourceid: string
  /**SQLカラム */
  sqlcolumn: string
  /**旧SQLカラム */
  oldsqlcolumn: string
  /**更新日時  */
  upddttm: Date | string
  /**テーブル別名 */
  tablealias: string
  /**項目ID */
  itemid: string
  /**表示名称 */
  itemhyojinm: string
  /**大分類 */
  daibunrui: string
  /**中分類 */
  tyubunrui?: string
  /**小分類 */
  syobunrui?: string
  /**使用区分 */
  usekbn?: Enum使用区分
  /**todo 出力項目区分 */
  itemkbn?: Enum出力項目区分
  /**集計項目区分 */
  syukeikbn?: Enum集計項目区分
  /**データ型 */
  datatype?: EnumDataType
  /**名称マスタコード */
  mastercd?: string
  /**名称マスタパラメータ */
  masterpara?: string
}

/** 削除処理 */
export interface DeleteRequest extends SearchRequest {
  /**更新日時  */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**テーブルリスト */
  tablelist: TableVM[]
  /**ドロップダウンリスト(使用区分) */
  selectorlist1: DaSelectorModel[]
  /**ドロップダウンリスト(集計項目区分) */
  selectorlist2: DaSelectorModel[]
  /**ドロップダウンリスト(データ型) */
  selectorlist3: DaSelectorModel[]
  /**テーブル物理名リスト */
  tableNamelist: string[]
}

/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /**編集可能フラグ */
  editflg: boolean
  /**表示名称 */
  itemhyojinm: string
  /**SQLカラム */
  sqlcolumn: string
  /**関連テーブル別名 */
  kanrentablealias: string
  /**大分類 */
  daibunrui: string
  /**中分類 */
  tyubunrui?: string
  /**小分類 */
  syobunrui?: string
  /**使用区分 */
  usekbn: Enum使用区分
  /**todo 出力項目区分 */
  itemkbn: Enum出力項目区分
  /**集計項目区分 */
  syukeikbn?: Enum集計項目区分
  /**データ型 */
  datatype: EnumDataType
  /**名称マスタコード */
  mastercd?: string
  /**名称マスタパラメータ */
  masterpara?: string
  /**更新日時 */
  upddttm: Date | string
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
  /**関連テーブル別名 */
  kanrentablealias: string
}
