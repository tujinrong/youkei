/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 家畜防疫互助基金事業加入状况表
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理_EXCEL出力画面リクエスト */
export interface InitRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
}
/** EXCEL出力処理_EXCEL出力画面リクエスト */
export interface ExcelExportRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
  /** 出力区分 */
  SYUTURYOKU_KBN: number
  /** 指定日 */
  KEIYAKU_DATE_FROM: Date
  /** 契約区分 */
  KEIYAKU_KBN: KeiyakuKbn
  /** 都道府県 */
  KEN_CD: CmCodeFmToModel
  /** 契約者番号 */
  KEIYAKUSYA_CD: CmCodeFmToModel
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_EXCEL出力画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 初期化情報 対象期 */
  KI: number
  /** 都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]
  /** 契約者番号情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[]
}
/** EXCEL出力処理_EXCEL出力画面レスポンス */
export interface ExcelExportResponse extends DaResponseBase {
  /**ファイル名 */
  filenm: string
  /**データ */
  data: any[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 契約区分クラス */
export interface KeiyakuKbn {
  /** 家族 */
  KAZOKU?: boolean
  /** 企業 */
  KIGYO?: boolean
  /** 鶏以外 */
  KEIIGAI?: boolean
}
