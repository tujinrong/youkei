/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人健（検）診事業詳細検索設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum詳細検索条件区分 } from '#/Enums'
import { KensinCommonHeaderVM } from '../AWKK00801G/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 成人健（検）診事業コード */
  jigyocd: string
}
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** 画面一覧 */
  kekkalist: SaveVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 検診画面ヘッダー情報 */
  headerinfo: KensinCommonHeaderVM
  /** 右部分(独自) */
  kekkalist1: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 並び順設定行モデル(表示用) */
export interface SearchVM extends SaveVM {
  /** 詳細条件表示名 */
  hyojinm: string
}
/** 並び順設定行モデル(保存用) */
export interface SaveVM {
  /** 条件区分 */
  jyokbn: Enum詳細検索条件区分
  /** 条件シーケンス */
  jyoseq: number
  /** 表示フラグ */
  hyojiflg: boolean
}
