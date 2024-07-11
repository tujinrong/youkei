/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: メモ情報（世帯）
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { AddVM, UpdVM, LockVM, SearchVM } from '../AWAF00601D/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 世帯番号 */
  setaino: string
  /** 新規メモリスト */
  addlist: AddVM[]
  /** 更新メモリスト */
  updlist: UpdVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 世帯主基本情報 */
  headerinfo: HeaderVM
  /** メモ（世帯）情報 */
  kekkalist: SearchVM[]
  /** 登録事業(登録範囲-CSV出力用) */
  jigyokbns: string[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 世帯主基本情報 */
export interface HeaderVM extends CommonBarHeaderBaseVM {
  /** 世帯番号 */
  setaino: string
}
