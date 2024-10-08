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
  /**農場コード */
  NOJO_CD: number | undefined
  /**自動採番 */
  SEQNO: number
  /**鳥の種類 */
  TORI_KBN: number | undefined
}
export interface InitNojoRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
}
export interface CopyRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約年月日 */
  KEIYAKU_DATE: CmDateFmToModel
  /**契約区分コード */
  KEIYAKU_KBN: number
}

export interface SaveRequest extends DaRequestBase {
  /**自動採番 */
  SEQNO: number | undefined
  /**期 */
  KI: number | undefined
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**農場コード */
  NOJO_CD: number | undefined
  /**鶏の種類コード */
  TORI_KBN: number | undefined
  /**契約羽数 */
  KEIYAKU_HASU: number | undefined
  /**契約年月日 */
  KEIYAKU_DATE: CmDateFmToModel | undefined
  /**備考 */
  BIKO: string
  /**契約区分コード */
  KEIYAKU_KBN: number
  /**データ更新日 */
  UP_DATE: Date | undefined
}

export interface DeleteRequest extends DaRequestBase {
  /**自動採番 */
  SEQNO: number | undefined
  /**データ更新日 */
  UP_DATE: Date
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
export interface SearchResponse extends CmSearchResponseBase {
  /**契約区分コード */
  KEIYAKU_KBN: number
  /**契約者名 */
  KEIYAKUSYA_NAME: string
  /**農場情報プルダウンリスト */
  NOJO_LIST: CmCodeNameModel[]
  /**鶏の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[]
  /**契約羽数合計 */
  HASU_GOKEI: CmKeiGokeiModel
  /**契約農場別明細情報(表示)リスト */
  KEKKA_LIST: SearchRowVM[]
}

export interface InitNojoResponse extends DaResponseBase {
  /**農場住所情報 */
  NOJO_ADDR: NojoAddrVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface SearchRowVM {
  /**自動採番 */
  SEQNO: number
  /**期 */
  KI: number | undefined
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**明細番号 */
  MEISAI_NO: number
  /**農場コード */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**農場住所 */
  NOJO_ADDR: string
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
  /**鳥の種類コード */
  TORI_KBN: number
  /**鳥の種類名 */
  TORI_KBN_NAME: string
  /**契約羽数 */
  KEIYAKU_HASU: number
  /**契約年月日 */
  KEIYAKU_DATE: CmDateFmToModel
  /**備考 */
  BIKO: string
}

export interface DetailRowVM {
  /**明細番号 */
  MEISAI_NO: number
  /**農場名 */
  NOJO_NAME: string
  /**農場住所 */
  NOJO_ADDR: string
  /**鳥の種類 */
  TORISYURUI: string
  /**契約羽数 */
  KEIYAKUHASU: string
  /**備考 */
  BIKO: string
}

export interface NoJoRowVM {
  /**農場コード */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**住所 */
  ADDR: string
}

export interface DetailVM {
  /**自動採番 */
  SEQNO: number | undefined
  /**期 */
  KI: number | undefined
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**農場コード */
  NOJO_CD: number | undefined
  /**鳥の種類 */
  TORI_KBN: number | undefined
  /**契約羽数 */
  KEIYAKU_HASU: number | undefined
  /**契約年月日 */
  KEIYAKU_DATE: CmDateFmToModel
  /**備考 */
  BIKO: string
  /**データ更新日 */
  UP_DATE: Date | undefined
}
export interface NojoAddrVM {
  /**明細番号 */
  MEISAI_NO: number
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
}
