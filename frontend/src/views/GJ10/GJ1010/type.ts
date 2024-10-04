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

//1011

//1012

export interface InitDetailRequest_1012 extends DaRequestBase {
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
export interface CopyRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約年月日 */
  KEIYAKU_DATE_FROM: Date
}

export interface SaveRequest_1012 extends DaRequestBase {
  /**契約農場別登録明細情報 */
  KEIYAKUSYA_NOJO: DetailVM_1012
}

export interface DeleteRequest_1012 extends DaRequestBase {
  /**データ更新日 */
  UP_DATE: Date
  /**自動採番 */
  SEQNO: number
}
export interface InitNojoRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
}
//1013
export interface InitDetailRequest_1013 extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
}

export interface SaveRequest_1013 extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
  /**農場名称 */
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
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

export interface InitDetailResponse_1012 extends DaResponseBase {
  /**農場情報プルダウンリスト */
  NOJO_LIST: CmCodeNameModel[]
  /**鶏の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[]
  /**契約農場別登録明細情報(入力) */
  KEIYAKUSYA_NOJO: DetailVM_1012
}

export interface InitNojoResponse extends DaResponseBase {
  /**農場住所情報 */
  NOJO_ADDR: NojoAddrVM
}
//1013
export interface InitDetailResponse_1013 extends DaResponseBase {
  /**都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者番名 */
  KEIYAKUSYA_NAME: string
  /**農場情報リスト */
  KEKKA_LIST: NoJoRowVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

//1011

//1012
//1012table
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

export interface DetailVM_1012 {
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
  /**農場コード */
  NOJO_CD: number
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
