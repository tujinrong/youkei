// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票項目編集
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

import { CodeTypeEnum } from '#/Enums'

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(集計区分) */
  selectorlist1: DaSelectorModel[]
  /**ドロップダウンリスト(出力項目区分) */
  selectorlist2: DaSelectorModel[]
  /**ドロップダウンリスト(並び替え) */
  selectorlist3: DaSelectorModel[]
  /**ドロップダウンリスト(コード区分) */
  selectorlist4: DaSelectorModel[]
  /**ドロップダウンリスト(小計区分) */
  selectorlist5: DaSelectorModel[]
}

/** マスタ初期化処理 */
export interface InitMasterResponse extends DaResponseBase {
  /**マスタリスト */
  masterlist: MasterVM[]
}

/** フォーマット初期化処理 */
export interface InitFormatResponse extends DaResponseBase {
  /**フォーマットリスト */
  formatlist: FormatVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** マスタ初期化処理 */
export interface MasterVM {
  /**マスタコード */
  mastercd: string
  /**マスタ名称 */
  masterhyojinm: string
  /**コードリスト */
  cdlist: CdVM[]
  /**手入力フラグ */
  manualflg: boolean
}

/** マスタ初期化処理 */
export interface CdVM {
  /**カラム */
  columnnm: string
  /**カラム名称 */
  columncomment: string
  /**数値フラグ */
  numflg: boolean
  /**コードタイプ */
  codetype: CodeTypeEnum
  /**選択リスト */
  selectorlist?: DaSelectorKeyModel[]
}

/** マスタ初期化処理 */
export interface FormatVM {
  /**フォーマット区分 */
  formatkbn: string
  /**フォーマット名称 */
  formatnm: string
  /**フォーマット詳細リスト */
  syosailist: FormatSyosaiVM[]
}

/** マスタ初期化処理 */
export interface FormatSyosaiVM {
  /**フォーマット区分2 */
  formatkbn2: string
  /**フォーマット種別名 */
  formattypenm: string
  /**フォーマット詳細 */
  formatsyosai: string
  /**ユーザー定義フラグ */
  userdefinedflg: boolean
  /**フォーマット例 */
  formatexample?: string
}
