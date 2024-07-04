/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 詳細条件検索
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.08.30
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum詳細検索条件区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  // /** 機能ID */
  // kinoid: string
  /** パターンNo.(ドロップダウンリストコード) */
  patternno?: string
  /** 実施事業(複数「,」で連結) */
  jigyocds?: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 共通(左)リスト */
  leftlist: CommonFilterVM[]
  /** 独自(右)リスト */
  rightlist: CommonFilterVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 詳細条件(検索) */
export interface SearchVM {
  /** 条件区分 */
  jyokbn: Enum詳細検索条件区分
  /** 条件シーケンス */
  jyoseq: number
  /** 通用項目 */
  itemvm?: ItemVM
  /** 年齢範囲 */
  agevm?: AgeVM
  /** 生年月日範囲 */
  birthvm?: BirthVM
  /** 一覧選択 */
  cdlist?: string[]
}
/** 年齢範囲 */
export interface AgeVM {
  /** 年齢計算基準日 */
  basedate: Date | string
  /** 男性 */
  man: string
  /** 女性 */
  woman: string
  /** 両方 */
  both: string
  /** 不明 */
  unknown: string
}
/** 生年月日範囲 */
export interface BirthVM {
  /** 男性 */
  man: ItemVM
  /** 女性 */
  woman: ItemVM
  /** 両方 */
  both: ItemVM
  /** 不明 */
  unknown: ItemVM
}
/** 通用項目 */
export interface ItemVM {
  /** 値(開始) */
  value1: number | string | null
  /** 値(終了) */
  value2: number | string | null
  /** 年(不詳) */
  yearflg: boolean
  /** 月(不詳) */
  monthflg: boolean
  /** 日(不詳) */
  dayflg: boolean
}
