/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 国保資格情報履歴照会
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
  /** 被保険者履歴番号 */
  hihokensyarirekino: number
  /** 国保記号番号 */
  kokuho_kigono: string
  /** 枝番 */
  kokuho_edano: string
  /** 国保資格取得年月日 */
  kokuho_sikakusyutokuymd: string
  /** 国保資格喪失年月日 */
  kokuho_sikakusosituymd: string
  /** 国保資格取得事由 */
  kokuho_sikakusyutokujiyu: string
  /** 国保資格喪失事由 */
  kokuho_sikakusositujiyu: string
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
}
