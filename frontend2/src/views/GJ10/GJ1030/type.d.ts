/** ----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.29
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**プレビュー処理(プレビュー画面) */
export interface PreviewRequest extends CmSearchRequestBase {
  /**対象期 */
  KI: number
  /**対象日(現在) */
  TAISYOBI_YMD: string
  /**契約者区分コードFROM */
  KEIYAKU_KBN_CD_FM?: number
  /**契約者区分コードTO */
  KEIYAKU_KBN_CD_TO?: number
  /**契約状況[新規契約者] */
  KEIYAKU_JYOKYO_SHINKI: boolean
  /**契約状況[継続契約者] */
  KEIYAKU_JYOKYO_KEIZOKU: boolean
  /**契約状況[中止契約者] */
  KEIYAKU_JYOKYO_CHUSHI: boolean
  /**契約状況[廃業者] */
  KEIYAKU_JYOKYO_HAIGYO: boolean
  /**事務委託先番号コードFROM */
  ITAKU_CD_FM?: number
  /**事務委託先番号コードTO */
  ITAKU_CD_TO?: number
  /**契約者番号コードFROM */
  KEIYAKUSYA_CD_FM?: number
  /**契約者番号コードTO */
  KEIYAKUSYA_CD_TO?: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(プレビュー画面) */
export interface InitResponse extends DaResponseBase {
  /**対象期 */
  KI: number
  /**契約区分情報プルダウンリスト */
  KEIYAKU_KBN_CD_NAME_LIST: DaSelectorModel
  /**事務委託先情報プルダウンリスト */
  ITAKU_CD_NAME_LIST: DaSelectorModel
  /**契約者番号情報プルダウンリスト */
  KEIYAKUSYA_CD_NAME_LIST: DaSelectorModel
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
