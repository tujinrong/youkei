// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票管理画面
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 保存処理 */
export interface SaveRequest extends CmUploadRequestBase {
  /**印字設定リスト */
  koinreportlist: BaseKoinReportVM[]
  /**問い合わせ先設定リスト */
  contactinforeportlist: BaseContactInfoReportVM[]
  /**市区町村長 */
  soncho: SonchoVM
  /**職務代理者 */
  dairisha: DairishaVM
  /**更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理 */
export interface InitResponse extends DaRequestBase {
  /**市区町村長 */
  soncho: SonchoVM
  /**職務代理者 */
  dairisha: DairishaVM
  dairiymdt: string
  /**市区町村長公印画像 */
  sonchokoindata: string
  /**職務代理者公印画像 */
  dairishakoindata: string
  /**更新日時 */
  upddttm: Date | string
  /**課コード */
  kacdList: DaSelectorModel[]
  /**係コード */
  kakaricdList: DaSelectorModel[]
  /**問い合わせ先リスト */
  toiawasesakicdList: DaSelectorModel[]
  /**印字設定結果リスト */
  kekkalist1: KoinReportVM[]
  /**問い合わせ先設定結果リスト */
  kekkalist2: ContactInfoReportVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface BaseReportVM {
  /** 帳票ID */
  rptid: number
  /** 更新日時 */
  upddttm: Date
}

/** 保存処理 */
export interface BaseKoinReportVM extends BaseReportVM {
  /** 市区町村長名の印字フラグ */
  koinnmflg: boolean
  /** 電子公印の印字フラグ */
  koinpicflg: boolean
  /** 電子公印の職務代理者適用フラグ */
  dairisyaflg: boolean
}

/** 保存処理 */
export interface BaseContactInfoReportVM extends BaseReportVM {
  /**問い合わせ先コード */
  toiawasesakicd: string
}

/** 印字設定検索処理 */
export interface KoinReportVM extends BaseKoinReportVM {
  /**帳票名 */
  rptnm: string
  /**様式名 */
  yosikinm: string
}

/** 問い合わせ先設定検索処理 */
export interface ContactInfoReportVM extends BaseContactInfoReportVM {
  /**帳票名 */
  rptnm: string
  /**名称 */
  nm: string
  /**詳細 */
  detail: string
}

/** 市区町村長 */
export interface SonchoVM {
  /**市区町村長名 */
  sonchomei: string //
  /** 更新日時 */
  upddttm?: Date | string
}

/** 職務代理者 */
export interface DairishaVM {
  /**職務代理名 */
  dairimei: string
  /**職務代理者 */
  dairisha: string
  /**代理適用年月日（開始） */
  dairiymdf?: Date | string
  /**代理適用年月日（終了） */
  dairiymdt?: Date | string
  /**更新日時 */
  upddttm?: Date
}
