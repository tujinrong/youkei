/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.xx.xx
 * 作成者　　:xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr, EnumEditKbn } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitRequest extends DaRequestBase {
  /** */
}

/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {}

/**初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {}

/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {}

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {}

/**初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface SearchRowVM {}

/**契約者農場情報 */
export interface DetailVM {}
