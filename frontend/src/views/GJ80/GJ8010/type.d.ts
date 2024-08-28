/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.20
 * 作成者　　: 魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr, EnumEditKbn } from '@/enum'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**検索処理(一覧画面) */
export interface SearchRequest {
  /**種類区分 */
  SYURUI_KBN: number | undefined
}

/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {
  /**種類区分 */
  SYURUI_KBN: string
  /**名称コード */
  MEISYO_CD: number
  /**更新時間 */
  UP_DATE?: Date
}

/**検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /**種類区分 */
  SYURUI_KBN: string
  /**名称コード */
  MEISYO_CD: number
}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**コード情報 */
  CODE_VM: DetailVM
  /**編集区分 */
  EDIT_KBN: EnumEditKbn
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /**種類区分プルダウンリスト */
  SYURUI_KBN_LIST: CmCodeNameModel[]
}

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者農場情報リスト */
  KEKKA_LIST: SearchRowVM[]
}

/**検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /**コード情報 */
  CODE_VM: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface SearchRowVM {
  /**名称コード */
  MEISYO_CD: number
  /**名称 */
  MEISYO: string
  /**略称 */
  RYAKUSYO: string
}

/**契約者農場情報 */
export interface DetailVM {
  /**種類区分 */
  SYURUI_KBN: string
  /**名称コード */
  MEISYO_CD: number
  /**名称 */
  MEISYO: string
  /**略称 */
  RYAKUSYO: string
  /**更新時間 */
  UP_DATE?: Date
}
