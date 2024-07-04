/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定.ファイルアップロード
 * 　　　　　  リクエストインターフェース
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/

/** エラーファイル出力用 */
export interface ErrorDownloadRequest extends DaRequestBase {
  /** エラー */
  errorbytebuffer: string
}

/** アップロード処理 */
export interface UploadRequest extends CmUploadRequestBase {
  /** 取込実行ID */
  impexeid?: number
  /** 一括取込入力No */
  impno: string
  /** 処理キー */
  processKey: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** アップロード処理 */
export interface ExcelUploadResponse extends DaResponseBase {
  /** 取込実行ID(ファイルエラーがない場合あり) */
  impexeid: number
  /** エラーファイル出力用 */
  errorbytebuffer: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 取込実行ファイルアップロードエラーモデル */
export interface UploadErrorVM {
  /** 行 */
  RowNo: number
  /** タイトル */
  Title: string
  /** 項目値 */
  ItemValue?: string
  /** エラー内容 */
  ErrMsg?: string
}
