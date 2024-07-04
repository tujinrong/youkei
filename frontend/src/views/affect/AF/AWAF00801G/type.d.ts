/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 汎用情報保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.19
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分, Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化(メインコード) */
export interface InitMainCodeRequest extends DaRequestBase {
  /** 名称区分(メインコード) */
  kbn: Enum名称区分
}
/** 初期化(サブコード) */
export interface InitSubCodeRequest extends InitMainCodeRequest {
  /** 汎用メインコード */
  hanyomaincd: string
}
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 汎用メインコード */
  hanyomaincd: string
  /** 汎用サブコード */
  hanyosubcd: string
}
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** 排他キーリスト */
  locklist: LockVM[]
  /** 汎用データリスト */
  savelist: HanyoVM[]
}
/** サブコード情報登録(保存処理) */
export interface SaveSubCodeInfoRequest extends SearchRequest {
  /** サブコード情報 */
  subcdInfoVM: SubCodeInfoVM
  /** 編集区分 */
  editkbn: Enum編集区分
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** メインコード初期化処理 */
export interface InitMainCodeResponse extends InitSubCodeResponse {
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** サブコード初期化処理 */
export interface InitSubCodeResponse extends DaResponseBase {
  /** ドロップダウンリスト(メインコード/サブコード) */
  selectorlist: DaSelectorModel[]
}
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 備考 */
  biko: string
  /** ユーザ領域開始コード */
  userryoikikaisicd: number | null
  /** 最大汎用コード */
  maxHanyocd: number | null
  /** 桁数 */
  keta: number | null
  /** INSERT可能フラグ */
  iflg: boolean
  /** UPDATE可能フラグ */
  uflg: boolean
  /** DELETE可能フラグ */
  dflg: boolean
  /** 汎用データリスト */
  kekkalist: HanyoVM[]
  /** 汎用データリスト(ロック用) */
  locklist: LockVM[]
}
/** サブコード情報登録(初期処理) */
export interface InitSubCodeInfoResponse extends DaResponseBase {
  /** サブコード情報 */
  subcdInfoVM: SubCodeInfoVM | null
  /** 汎用メインコードリスト */
  maincdlist: DaSelectorModel[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 汎用データ情報モデル */
export interface HanyoVM extends LockVM {
  /** 名称 */
  nm: string
  /** カナ名称 */
  kananm: string
  /** 略称 */
  shortnm: string
  /** 備考 */
  biko: string
  /** 汎用区分1 */
  hanyokbn1: string
  /** 汎用区分2 */
  hanyokbn2: string
  /** 汎用区分3 */
  hanyokbn3: string
  /** 使用停止フラグ */
  stopflg: boolean
  /** 並びシーケンス */
  orderseq?: number
  /** 汎用コード編集フラグ */
  hanyocdEditFlg: boolean
  /** PKGコードフラグ(true:PKG、false:独自) */
  pkgCdFlg: boolean
}
/** 排他チェック用モデル */
export interface LockVM {
  /** 汎用コード */
  hanyocd: string
  /** 更新日時 */
  upddttm?: Date | string
}
/** サブコード情報モデル */
export interface SubCodeInfoVM {
  /** 汎用メインコード */
  hanyomaincd: string
  /** 汎用サブコード */
  hanyosubcd?: number
  /** 汎用サブコード名称 */
  hanyosubcdnm: string
  /** ユーザ領域開始コード */
  userryoikikaisicd?: number
  /** 桁数 */
  keta?: number
}
