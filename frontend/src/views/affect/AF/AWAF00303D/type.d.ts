/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: お気に入り
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.03.28
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum更新区分, Enumお気に入り区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 機能ID */
  kinoid: string
}
/** 更新処理 */
export interface UpdateRequest extends InitRequest {
  /** 更新区分 */
  updkbn: Enum更新区分
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 機能IDリスト */
  kinoids: string[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** お気に入り状態 */
  statuskbn: Enumお気に入り区分
}
/** 検索処理/更新処理/保存処理 */
export interface CommonResponse extends DaResponseBase {
  /** 機能IDリスト */
  kekkalist: string[]
}
