/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: CSV出力項目選択
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.11.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 帳票ID */
  reportid: number
}
/** 検索処理 */
export interface SearchRequest extends InitRequest {
  /** 出力パターン番号 */
  outputptnno?: number
}
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** 出力パターン名 */
  outputptnnm: string
  /** 帳票項目リスト(出力用、ソート済) */
  kekkalist: number[]
  /** 更新日時 */
  upddttm?: Date | string
}
/** 削除処理 */
export interface DeleteRequest extends SearchRequest {
  /** 更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** ドロップダウンリスト(出力パターン) */
  selectorlist: DaSelectorModel[]
}
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 出力パターン名 */
  outputptnnm: string
  /** 帳票項目リスト(全て) */
  kekkalist1: RowVM[]
  /** 帳票項目リスト(出力用、ソート済) */
  kekkalist2: number[]
  /** 更新日時 */
  upddttm: string | null
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 出力項目情報 */
export interface RowVM {
  /** 帳票項目ID */
  reportitemid: number
  /** 項目名称 */
  reportitemnm: string
}
