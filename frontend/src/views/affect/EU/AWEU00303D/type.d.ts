// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力(帳票出力設定)
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

import { EnumReportType } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**プレビュー処理 */
export interface PreviewRequest extends CommonRequest {
  /**出力方式 */
  outputtype: EnumReportType
}

/**ダウンロード処理 */
export interface DownloadRequest extends CommonRequest {
  /**出力方式(PDF,EXCEL) */
  outputtype: EnumReportType
}

/**共通 */
export interface CommonRequest extends DaRequestBase {
  /**ワークシーケンス */
  workseq: number
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
  /**出力名 */
  outputfilenm: string
  /**検索条件メモ */
  memo?: string
  /**選択した宛名番号リスト */
  selectedatenanolist?: string[]
  /**検索条件 */
  jyokenlist?: KensakuJyokenVM[]
  /**詳細検索条件 */
  detailjyokenlist?: DetailKensakuJyokenVM[]
  /**出力方式 */
  outputtype: EnumReportType
  /**更新SQL */
  sqljikkoflg: boolean
  /**白纸 */
  hakusiflg: boolean
  /**条件シートを出力 */
  jyokensheetflg?: boolean
  /**発送履歴テーブル更新 */
  rirekiupdflg?: boolean
  /**抽出パネル情報 */
  tyusyutuinfo: TyusyutuVM
  /**出力情報 */
  outPutInfo?: OutPutInfoVM
}

/** バッチ処理 */
export interface BatchRequest extends DownloadRequest {
  /**実行日時 */
  executiontime: Date | string
  /** チェックフラグ */
  checkflg: boolean
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** プレビュー処理 */
export interface ReportPreviewResponse extends CmPreviewResponseBase {
  totalpagecount: number
}
