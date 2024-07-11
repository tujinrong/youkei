// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 帳票出力(CSV)
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
import { ArEnumEncoding2 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** CSV出力設定初期化処理 */

export interface DetailInitRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**様式ID */
  yosikiid: string
}
/**  ダウンロード処理 */
export interface DownloadRequest extends DaRequestBase {
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
  /**文字セット */
  csvencoding: ArEnumEncoding2
  /**選択したデータ */
  selecteddatalist?: object[] | null
  /**bom */
  csvbom: boolean
  /**CSV出力ヘッダータグ */
  csvoutputheader: boolean
  /**CSV出力ダブルクォーテーション */
  csvquotation: boolean
  /**CSV出力パターン */
  csvpattern: string
  /**検索条件 */
  jyokenlist?: KensakuJyokenVM[]
  /**詳細検索条件 */
  detailjyokenlist?: DetailKensakuJyokenVM[]
  /**更新SQL */
  sqljikkoflg: boolean
  /**白纸 */
  hakusiflg: boolean
  /**条件シートを出力 */
  jyokensheetflg: boolean
  /**発送履歴テーブル更新 */
  rirekiupdflg: boolean
  /**抽出パネル情報 */
  tyusyutuinfo: TyusyutuVM
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**  CSV出力設定初期化処理 */
export interface DetailInitResponse extends DaResponseBase {
  /**出力パターン番号 */
  outputptnno?: number
  /**ドロップダウンリスト(csvdrop) */
  csvdroplist: DaSelectorModel[]
}
