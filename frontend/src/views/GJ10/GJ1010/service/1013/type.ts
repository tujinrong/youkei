/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
export interface SearchRequest extends CmSearchRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
}

export interface InitDetailRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場番号 */
  NOJO_CD: number
}

export interface SaveRequest extends DaRequestBase {
  /**農場登録情報(入力) */
  NOJO_JOHO: DetailVM
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
export interface SearchResponse extends CmSearchResponseBase {
  /**農場情報(表示)リスト */
  NOJO_JOHO_LIST: NojoJohoVM[]
}

export interface InitDetailResponse extends DaResponseBase {
  /**都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]
  /**農場登録情報(入力) */
  NOJO_JOHO: DetailVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface SearchRowVM {
  /**自動採番 */
  SEQNO: number
  /**明細番号 */
  MEISAI_NO: number
  /**農場コード */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**農場住所 */
  NOJO_ADDR: string
  /**鳥の種類コード */
  TORI_KBN: number
  /**鳥の種類名 */
  TORI_KBN_NAME: string
  /**契約羽数 */
  KEIYAKU_HASU: number
  /**備考 */
  BIKO: string
}

export interface NojoJohoVM {
  /**農場番号 */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**農場住所 */
  ADDR: string
}

export interface DetailVM {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場番号 */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**都道府県コード */
  KEN_CD: number
  /**郵便番号 */
  ADDR_POST: string
  /**住所1 */
  ADDR_1: string
  /**住所2 */
  ADDR_2: string
  /**住所3 */
  ADDR_3: string
  /**住所4 */
  ADDR_4: string
  /**明細番号 */
  MEISAI_NO: number
  /**明細番号 */
  UP_DATE: Date | undefined
}
