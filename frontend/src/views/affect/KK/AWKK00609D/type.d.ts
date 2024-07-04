//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

import { ChangeCodeMainVM } from '../AWKK00601G/type'

/** 初期化処理*/
export interface InitRequest extends DaRequestBase {
  /** 変換コードメイン情報 */
  changeCodeMainList: ChangeCodeMainVM[]
}

/** 初期化処理(【メインコード】のドロップダウンリスト) */
export interface InitMaincdRequest extends DaRequestBase {
  /** コード管理テーブル名 */
  tablename: string
}

/** 初期化処理(【サブコード】のドロップダウンリスト) */
export interface InitSubcdRequest extends DaRequestBase {
  /** コード管理テーブル名 */
  tablename: string
  /** メインコード */
  maincd: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 【コ-ド管理テ-プル】のドロップダウンリスト */
  codeManagerTableList: DaSelectorModel[]
  /** 変換コードメイン補充情報 */
  changeCodeMainExList: ChangeCodeMainExVM[]
}

/** 初期化処理(【メインコード】のドロップダウンリスト) */
export interface InitMaincdResponse extends DaResponseBase {
  /** 【メインコード】のドロップダウンリスト */
  maincdList: DaSelectorModel[]
}

/** 初期化処理(【サブコード】のドロップダウンリスト) */
export interface InitSubcdResponse extends DaResponseBase {
  /** 【サブコード】のドロップダウンリスト */
  subcdList: DaSelectorModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 変換コードメイン補充情報モデル */
export interface ChangeCodeMainExVM extends ChangeCodeMainVM {
  /** 行【メインコード】のドロップダウンリスト */
  rowMaincdList?: DaSelectorModel[]
  /** 【サブコード】のドロップダウンリスト */
  rowSubcdList: DaSelectorModel[]
}
