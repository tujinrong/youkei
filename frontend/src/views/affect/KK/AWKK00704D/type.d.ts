/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  ビューモデル定義
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/

/** アップロード処理 */
export interface InitListRequest extends CmSearchRequestBase {
  /** 取込実行ID */
  impexeid: number
}

/** エラー出力処理 */
export interface DownloadRequest extends CmUploadRequestBase {
  /** 取込データエラー情報リスト */
  kimpErrList: KimpErrRowVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期処理 */
export interface InitListResponse extends CmSearchResponseBase {
  /** 取込データエラー情報リスト */
  kimpErrList: KimpErrRowVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 取込データエラー情報モデル(エラー一覧画面) */
export interface KimpErrRowVM {
  /** No */
  No: number
  /** 行番号 */
  rowno: number
  /** 宛名番号 */
  atenano?: string
  /** 氏名 */
  shimei?: string
  /** 項目名 */
  itemnm?: string
  /** 項目値 */
  val?: string
  /** メッセージ(エラー内容) */
  msg?: string
}
