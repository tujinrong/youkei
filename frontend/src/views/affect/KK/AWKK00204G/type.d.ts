/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 地区保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.25
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 地区区分(コード：名称) */
  tikukbn: string
  /** 地区(コード：名称) */
  tiku: string
  /** 地区担当者(コード：名称) */
  staff: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 地区区分(コード) */
  tikukbn: string
  /** 地区コード */
  tikucd: string
}
/** 検索処理(地区担当者情報) */
export interface SearchRowRequest extends DaRequestBase {
  /** 地区担当者ID */
  staffid: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 地区情報 */
  maininfo: SaveMainVM
  /** 地区担当者情報 */
  stafflist: string[]
  /** 編集区分 */
  editkbn: Enum編集区分
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(地区区分) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(地区コード) */
  selectorlist2: DaSelectorKeyModel[]
  /** ドロップダウンリスト(地区担当者) */
  selectorlist3: DaSelectorModel[]
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(地区一覧) */
  kekkalist: RowVM[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 地区情報 */
  maininfo: SaveMainVM
  /** 地区担当者情報 */
  stafflist: SubInfoVM[]
}
/** 検索処理(地区担当者情報) */
export interface SearchRowResponse extends DaResponseBase {
  /** 地区担当者情報 */
  staffinfo: SubInfoVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM extends MainInfoVM {
  /** 地区区分(コード) */
  tikukbn: string
  /** 地区担当者(「,」区切り) */
  staffnm: string
  /** 停止状態 */
  stopflg: string
  /** 地区区分(名称) */
  tikukbnnm: string
}
/** 地区情報(メイン：ベース) */
export interface MainInfoVM {
  /** 地区コード */
  tikucd: string
  /** 地区名 */
  tikunm: string
  /** 地区名(カナ) */
  kanatikunm: string
}
/** 地区情報(メイン：保存用) */
export interface SaveMainVM extends MainInfoVM {
  /** 地区区分(コード：名称) */
  tikukbn: string
  /** 使用停止フラグ */
  stopflg: boolean
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 地区担当者情報(サブ) */
export interface SubInfoVM {
  /** 事業従事者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
  /** 職種 */
  syokusyu: string
  /** 活動区分 */
  katudokbn: string
}
