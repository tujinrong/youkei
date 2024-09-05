/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.19
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumEditKbn } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**処理対象期・年度情報 */
  SYORI_KI: DetailVM
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**検索処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**契約者農場情報 */
  SYORI_KI: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 情報 */
export interface DetailVM {
  KI: number | undefined
  JIGYO_NENDO: number | undefined
  JIGYO_SYURYO_NENDO: number | undefined
  ZENKI_TUMITATE_DATE: string
  ZENKI_KOFU_DATE: string
  HENKAN_KEISAN_DATE: number | undefined
  HENKAN_NINZU: string
  HENKAN_GOKEI: string
  HENKAN_RITU: string
  TAISYO_NENDO: number | undefined
  NOFU_KIGEN: string
  HASSEI_KAISU: number | undefined
  BIKO: number | undefined
}
