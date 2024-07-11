/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票発行履歴管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.25
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分, Enum表示色区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 帳票名 */
  rptid: string
  /** 様式名 */
  yosikiid: string
  /** 年度 */
  nendo: string
  /** 抽出対象 */
  taisyocd: string
  /** 発行日時（開始） */
  hakkodttmf: string
  /** 発行日時（終了） */
  hakkodttmt: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** タスクコード */
  taskid: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 実行処理 */
export interface ExeBatchDetailRequest extends DaRequestBase {
  /** タスクコード */
  taskid: string
}
/** 保存処理 */
export interface SaveDetailRequest extends DaRequestBase {
  /** 更新日時 */
  upddttm: Date | string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** タスクID */
  taskid: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(処理区分) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(業務区分) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(タスク) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(前回処理結果) */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(バッチスケジュール一覧) */
  kekkalist: RowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM {
  /** 様式名 */
  yosikinm: string
  /** 帳票名 */
  rptnm: string
  /** 年度 */
  nendo: string
  /** 発行日時 */
  hakkodttm: string
  /** 発行人数 */
  hakkoninsu: string
  /** 抽出対象 */
  taisyocd: string
}
