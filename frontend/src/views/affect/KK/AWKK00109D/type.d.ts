/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 介護被保険者情報履歴照会
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.10.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 結果リスト(履歴一覧) */
  kekkalist: RowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface RowVM {
  /** 履歴No. */
  rirekinum: number
  /** 資格履歴番号 */
  sikakurirekino: number
  /** 介護保険者番号 */
  kaigohokensyano: string
  /** 被保険者番号 */
  hihokensyano: string
  /** 資格取得日 */
  sikakusyutokuymd: string
  /** 資格喪失日 */
  sikakusosituymd: string
  /** 要介護認定日 */
  yokaigoninteiymd: string
  /** 要介護状態区分(名称) */
  yokaigojotaikbnnm: string
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
}
