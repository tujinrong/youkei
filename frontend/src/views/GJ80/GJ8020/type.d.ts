/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 処理対象期・年度マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.19
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/

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

/** 処理対象期・年度マスタメンテナンス情報 */
export interface DetailVM {
  /** 期 */
  KI: number | undefined
  /** 事業対象開始年度 */
  JIGYO_NENDO: number | undefined
  /** 事業対象終了年度 */
  JIGYO_SYURYO_NENDO: number | undefined
  /** 前期積立金取込日 */
  ZENKI_TUMITATE_DATE: Date | undefined
  /** 前期交付金取込日 */
  ZENKI_KOFU_DATE: Date | undefined
  /** 返還金計算日 */
  HENKAN_KEISAN_DATE: Date | undefined
  /** 積立金返還人数 */
  HENKAN_NINZU: string
  /** 積立金返還額合計 */
  HENKAN_GOKEI: string
  /** 前期積立金返還率 */
  HENKAN_RITU: string
  /** 対象年度 */
  TAISYO_NENDO: number | undefined
  /** 当初対象積立金納付期限 */
  NOFU_KIGEN: string
  /** 現在の認定回数 */
  HASSEI_KAISU: number | undefined
  /** 備考 */
  BIKO: string | undefined
  /**データ更新日 */
  UP_DATE: Date | undefined
}
