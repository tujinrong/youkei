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
  TAISYO_DATE_FROM: string
  TAISYO_DATE_TO: string
  KEIYAKU_KBN: number | undefined
  TORI_KBN: number | undefined
  TUMITATE_TANKA: number | undefined
  KEIEISIEN_TANKA: number | undefined
  SYOKYAKU_TANKA: number | undefined
  TESURYO_RITU: number | undefined
  KOFU_RITU: number | undefined
}
