/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業従事者（担当者）保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.12.11
 * 作成者　　: 高智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 事業従業者ID */
  staffid: string
  /** 医療機関(コード) */
  kikancd: string
  /** 職種 */
  syokusyu: string
  /** 活動区分 */
  katudokbn: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 事業従業者ID */
  staffid: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 登録処理(詳細画面) */
export interface SaveDetailRequest extends DaRequestBase {
  /** 事業従業者（担当者）メイン情報 */
  mainInfo: MainInfoVM
  // /** 医療機関リスト */
  kikanlist: string[]
  // /** 実施事業ドロップダウンリスト */
  jissijigyoSelectorList: JissijigyoModel[]
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 更新日時 */
  upddttm?: Date
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** 事業従業者IDドロップダウンリスト */
  staffidSelectorList: DaSelectorModel[]
  /** 医療機関ドロップダウンリスト */
  kikanSelectorList: DaSelectorModel[]
  /** 職種ドロップダウンリスト */
  syokusyunmSelectorList: DaSelectorModel[]
  /** 活動区分ドロップダウンリスト */
  katudokbnnmSelectorList: DaSelectorModel[]
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 事業従業者（担当者）情報リスト */
  kekkaList: StaffRowVM[]
}

/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 事業従業者（担当者）メイン情報 */
  mainInfo: MainInfoVM
  /** 医療機関リスト */
  kikanlist: string[]
  /** 医療機関ドロップダウンリスト */
  kikanSelectorList: DaSelectorKeyModel[]
  /** 実施事業ドロップダウンリスト */
  jissijigyoSelectorList: JissijigyoModel[]
  /** 業務ドロップダウンリスト */
  gyoSelectorList: DaSelectorModel[]
  /** 更新日時 */
  upddttm?: Date
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 事業従業者（担当者）情報モデル(一覧画面) */
export interface StaffRowVM {
  /** 事業従業者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
  /** 職種 */
  syokusyunm: string
  /** 活動区分 */
  katudokbnnm: string
  /** 停止状態 */
  stopflg: string
}
/** 事業従業者（担当者）情報モデル(メイン) */
export interface MainInfoVM {
  /** 事業従業者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
  /** 使用（利用）停止フラグ */
  stopflg: boolean
  /** 職種 */
  syokusyu: string
  /** 活動区分 */
  katudokbn: string
}
/** 実施事業モデル */
export interface JissijigyoModel {
  /** 実施事業コード */
  jissijigyo: string
  /** 実施事業名称 */
  jissijigyonm: string
  /** チェックフラグ */
  checkflg: boolean
  /** 汎用区分1 */
  hanyokbn1: string
}
