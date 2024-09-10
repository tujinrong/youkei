/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約羽数增加入力&請求書作成(增羽)
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理_詳細画面リクエスト */
export interface InitRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
}
/** 検索処理_詳細画面リクエスト */
export interface SearchRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
}
/** リクエスト - 初期化処理_詳細画面 */
export interface InitDetailRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 増羽年月日 */
  KEIYAKU_DATE_FROM?: Date
  /** 契約年月日To  */
  KEIYAKU_DATE_TO?: Date
  /** 農場コード  */
  NOJO_CD?: number
  /** 契約区分  */
  KEIYAKU_KBN?: number
  /** 鳥の種類コード  */
  TORI_KBN?: number
}

/** リクエスト - 初期化処理_詳細画面InitNojo */
export interface InitNojoRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 農場コード */
  NOJO_CD: number
}

/** リクエスト - 初期化処理_詳細画面InitHasu */
export interface InitHasuRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 農場コード */
  NOJO_CD: number
  /** 鳥の種類コード */
  TORI_KBN: number
}
/** リクエスト - 保存処理_詳細画面Save */
export interface SaveRequest extends DaRequestBase {
  /** 契約者農場情報 */
  ZOHA_JOHO: DetailVM
}

/** リクエスト - 削除処理_詳細画面Delete */
export interface DeleteRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 増羽年月日 */
  KEIYAKU_DATE_FROM: Date
  /** 契約年月日To */
  KEIYAKU_DATE_TO: Date
  /** 農場コード */
  NOJO_CD: number
  /** 契約区分 */
  KEIYAKU_KBN: number
  /** 鳥の種類コード */
  TORI_KBN: number
}

/** リクエスト - 初期化処理_請求書発行画面Init */
export interface InitRequest_3011 extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
}

/** リクエスト - プレビュー処理_請求書発行画面Preview */
export interface PreviewRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 出力区分 */
  SYUTURYOKU_KBN: number
  /** 納付期限 */
  NOFUKIGEN_DATE?: Date
  /** 発行日 */
  SEIKYU_HAKKO_DATE?: Date
  /** 発信番号（発信年） */
  SEIKYU_HAKKO_NO_NEN?: number
  /** 発信番号（発信連番） */
  SEIKYU_HAKKO_NO_RENBAN?: number
}

/** リクエスト - 取消処理_請求書発行画面Cancel */
export interface CancelRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 請求返還回数 */
  SEIKYU_KAISU: number
  /** 積立金区分 */
  TUMITATE_KBN: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_詳細画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 初期化情報 */
  KI: number
  /** 契約者情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[]
}

/** 検索処理_詳細画面レスポンス */
export interface SearchResponse extends DaResponseBase {
  /** 契約農場別明細 増羽情報(表示) */
  KEKKA_LIST: SearchRowVM[]
}

/** リスポンス - 初期化処理_詳細画面 */
export interface InitDetailResponse extends DaResponseBase {
  /** 農場情報プルダウンリスト */
  NOJO_LIST: CmCodeNameModel[]
  /** 鳥の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[]
  /** 契約農場別明細 増羽情報(入力) */
  ZOHA_JOHO: DetailVM
}

/** リスポンス - 初期化処理_詳細画面InitNojo */
export interface InitNojoResponse extends DaResponseBase {
  /** 農場住所情報 */
  NOJO_ADDR: NojoAddrVM
}

/** リスポンス - 初期化処理_詳細画面InitHasu */
export interface InitHasuResponse extends DaResponseBase {
  /** 契約羽数(増羽前) */
  KEIYAKU_HASU: number
}

/** リスポンス - 初期化処理_請求書発行画面Init */
export interface InitResponse_3011 extends DaResponseBase {
  /** 請求返還回数 */
  SEIKYU_KAISU?: number
  /** 積立金区分 */
  KEIYAKUSYA_CD?: number
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** 納付期限 */
  NOFUKIGEN_DATE?: Date
  /** 発行日 */
  SEIKYU_HAKKO_DATE?: Date
  /** 発信番号（発信年） */
  SEIKYU_HAKKO_NO_NEN?: number
  /** 発信番号（発信連番） */
  SEIKYU_HAKKO_NO_RENBAN?: number
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索結果行モデル */
export interface SearchRowVM {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 契約年月日To */
  KEIYAKU_DATE_TO: Date
  /** 農場コード */
  NOJO_CD: number
  /** 契約区分 */
  KEIYAKU_KBN: number
  /** 鳥の種類コード */
  TORI_KBN: number
  /** 増羽年月日 */
  KEIYAKU_DATE_FROM: Date
  /** 農場名 */
  NOJO_NAME: string
  /** 鳥の種類名 */
  TORI_KBN_NAME: string
  /** 増羽数 */
  ZO_HASU: number
  /** 契約羽数(増羽前) */
  KEIYAKU_HASU_MAE?: number
  /** 契約羽数(増羽後) */
  KEIYAKU_HASU: number
  /** 処理区分 */
  SYORI_KBN: string
  /** 請求回数 */
  SEIKYU_KAISU?: number
}
/** 詳細情報クラス - 契約農場別明細 増羽情報(入力) */
export interface DetailVM {
  /** 農場コード */
  NOJO_CD: number
  /** 鳥の種類 */
  TORI_KBN: number
  /** 増羽数 */
  ZOGEN_HASU: number
  /** 増羽年月日 */
  KEIYAKU_DATE_FROM: Date
  /** 処理状況 */
  SYORI_KBN: number
}
/** 農場住所情報クラス */
export interface NojoAddrVM {
  /** 農場コード */
  NOJO_CD: number
  /** 農場住所（郵便番号） */
  ADDR_POST: string
  /** 農場住所（住所1） */
  ADDR_1: string
  /** 農場住所（住所2） */
  ADDR_2: string
  /** 農場住所（住所3） */
  ADDR_3: string
  /** 農場住所（住所4） */
  ADDR_4: string
}
