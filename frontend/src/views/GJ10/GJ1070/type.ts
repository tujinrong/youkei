/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 事業加入状況表(農場別リスト)
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
  /** 契約区分 */
  KEIYAKU_KBN: CmCodeFmToModel
  /** 鳥の種類 */
  TORI_KBN: CmCodeFmToModel
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
  /** 対象期 */
  KI: number
  /** 契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[]
  /** 鳥の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[]
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
