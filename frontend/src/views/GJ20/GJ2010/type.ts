/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者積立金・互助金単価マスタ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.02
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /** */
  KEKKA: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 情報 */
export interface DetailVM {
  START_DATE: string
  END_DATE: string
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
