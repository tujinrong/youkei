/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 地区保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分, Enum表示色区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 処理区分 */
  kbn: string
  /** 業務区分 */
  gyomukbn: string
  /** タスク名 */
  tasknm: string
  /** 前回処理結果 */
  statuscd: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** タスクID */
  taskid: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 実行処理 */
export interface ExeBatchDetailRequest extends DaRequestBase {
  /** タスクID */
  taskid: string
}
/** 保存処理 */
export interface SaveDetailRequest extends DaRequestBase {
  /** 更新日時 */
  upddttm: Date | string
  /** スケジュール管理情報 */
  maininfo: MainInfoVM
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
  /** ドロップダウンリスト(タスク名) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(前回処理結果) */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(バッチスケジュール一覧) */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 業務区分 */
  gyomukbnnmList: DaSelectorModel[]
  /** 処理区分*/
  syorikbnnmList: DaSelectorModel[]
  /** モジュール */
  modulenmList: DaSelectorModel[]
  /** 毎月の月 */
  tukinmList: DaSelectorModel[]
  /** 毎月の日(コード：名称) */
  nichinmList: DaSelectorModel[]
  /** 毎月の週(コード：名称) */
  syunmList: DaSelectorModel[]
  /** 曜日(コード：名称) */
  yobinmList: DaSelectorModel[]
  /** 間隔 */
  kurikaeshikannmList: DaSelectorModel[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** バッチスケジュール管理情報 */
  mainInfo: MainInfoVM
  /** 更新日時 */
  upddttm?: Date | string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM {
  /** タスクID */
  taskid: string
  /** タスク名 */
  tasknm: string
  /** 処理区分 */
  syorikbn: string
  /** 業務区分 */
  gyomukbn: string
  /** 頻度 */
  jikkohindo: string
  /** 頻度詳細 */
  hindosyosai: string
  /** 次回処理日時 */
  syoridttmf: string
  /** 処理日時（開始） */
  syoridttmt: string
  /** 処理結果コード */
  statuscd: string
  /** 処理結果表示色区分 */
  colorkbn: Enum表示色区分
  /** 状態 */
  jotai: string
}

/** バッチスケジュール管理情報 */
export interface MainInfoVM {
  /** タスクID */
  taskid: string
  /** タスク名 */
  tasknm: string
  /** 説明 */
  biko: string
  /** 前回の実行日時（開始） */
  zenjikkodttmf: string
  /** 前回の実行日時（終了） */
  zenjikkodttmt: string
  /** 次回処理日時 */
  syoridttmf: string
  /** 処理区分 */
  syorikbn: string
  /** 業務区分 */
  gyomukbn: string
  /** モジュール名 */
  modulecd: string
  /** 有効年月日（開始） */
  yukoymdf: string
  /** 有効時間（開始） */
  yukotmf: string
  /** 頻度区分 */
  hindokbn: string
  /** 祝日停止フラグ */
  syukustopflg: boolean
  /** 曜日 */
  yobi: string[]
  /** 毎月の日・曜日区分 */
  maitukihiyobikbn: string
  /** 毎月の月 */
  maitukituki: string[]
  /** 毎月の日 */
  maitukihi: string[]
  /** 毎月の週 */
  maitukisyu: string[]
  /** 引数 */
  hikisu: string
  /** 状態*/
  jotai: string
  /** 処理結果コード */
  statuscd: string
  /** 繰り返し間隔フラグ */
  kurikaesikanflg: boolean
  /** 繰り返し間隔区分 */
  kurikaesikankbn: string
  /** 継続時間区分 */
  keizokujikankbn: string
  /** 時間帯開始_時 */
  jikantaif: string
  /** 時間帯終了_時 */
  jikantait: string
  /** 時間内開始_分 */
  jikannaif: string
  /** 時間内終了_分 */
  jikannait: string
  /** 曜日(日) */
  sunday: boolean
  /** 曜日(月) */
  monday: boolean
  /** 曜日(火) */
  tuesday: boolean
  /** 曜日(水) */
  wednesday: boolean
  /** 曜日(木) */
  thursday: boolean
  /** 曜日(金) */
  friday: boolean
  /** 曜日(土) */
  saturday: boolean
  /** 更新日時 */
  upddttm: Date | string
  syuyobi: string
}
