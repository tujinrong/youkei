/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 成人検診事業項目並び順設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
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
  /** 固定項目一覧(左) */
  kekkalist1: SaveVM[]
  /** フリー項目一覧(右) */
  kekkalist2: SaveVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 検診項目一覧画面ヘッダー情報 */
  headerinfo: KensinCommonHeaderVM
  /** 固定項目一覧(左) */
  kekkalist1: SearchVM[]
  /** フリー項目一覧(右) */
  kekkalist2: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 並び順設定行モデル(表示用) */
export interface SearchVM extends SaveVM {
  /** 項目名 */
  itemnm: string
}
/** 並び順設定行モデル(保存用) */
export interface SaveVM {
  /** 項目コード */
  itemcd: string
}
