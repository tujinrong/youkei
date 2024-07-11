// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力履歴画面
//          　 インターフェース定義
// 作成日　　: 2023.09.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { Enum帳票様式 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**帳票様式 */
  kbn: Enum帳票様式
}

/** ダウンロード処理 */
export interface DownloadRequest extends DaRequestBase {
  /** 履歴シーケンス */
  rirekiseq: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/**検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  kekkalist: RirekiVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface RirekiVM {
  /**履歴シーケンス */
  rirekiseq: number
  /**登録日時 */
  regdttm: Date | string
  /**登録ユーザー名 */
  regusernm: string
  /**状態区分 */
  jyotai: string
  /**実行日時 */
  syoridttmf: Date | string
  /**出力方式 */
  outputkbn: string
  /**結果件数 */
  num?: number
  /**検索条件 */
  jyoken: string
  /**検索条件メモ */
  memo?: string
  /**ファイルフラグ */
  fileflg: boolean
  /**検索条件リスト */
  jyokenlist: JyokenVM[]
}

/**検索処理 */
export interface JyokenVM {
  /**条件シーケンス */
  jyokenseq: number
  /**ラベル */
  jyokenlabel: string
  /**検索条件値 */
  value: string
}
