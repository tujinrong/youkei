// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定
//          　 インターフェース定義
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
import { KensakuJyokenInitVM } from '../AWEU00301G/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchWarningsRequest extends CmSearchRequestBase {
  /**帳票ID */
  rptid: string
  /**ワークシーケンス */
  workseq?: number
  /**様式ID */
  yosikiid: string
  /**検索条件 */
  jyokenlist?: KensakuJyokenInitVM[]
  /**詳細検索条件 */
  detailjyokenlist?: DetailKensakuJyokenVM[]
  /**抽出パネル情報 */
  tyusyutuinfo: TyusyutuVM
}

/**警告チェックの処理 */
export interface UpdateWarnCheckboxRequest extends CmSearchRequestBase {
  /**ワークシーケンス */
  workseq: number
  /**ステータス */
  status: string
  /**世帯番号 */
  atenano: string
  /**出力フラグ */
  formflg: boolean
  /**出力フラグ(旧) */
  formflgold: boolean
}

/**警告内容の選ぶの処理 */
export interface UpdateWarningDetailsRequest extends CmSearchRequestBase {
  /**ワークシーケンス */
  workseq: number
  /**ステータス */
  status: string
  /**世帯番号 */
  warningContents: WarningContentVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 警告内容検索処理 */
export interface SearchWarningsResponse extends CmSearchResponseBase {
  /**ワークシーケンス */
  workseq: number
  /**警告内容リスト */
  kekkalist: WarningContentVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 検索処理 */
export interface WarningContentVM {
  /**宛名番号 */
  atenano: string
  /**氏名 */
  simei: string
  /**警告内容 */
  keikoku: string
  /**対象外者/対象外理由 */
  taisyogairiyu?: string
  /**出力フラグ */
  formflg: boolean
  /**出力フラグ(旧) */
  formflgold: boolean
}
