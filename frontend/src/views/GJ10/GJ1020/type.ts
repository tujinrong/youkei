/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者情報変更
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.29
 * 作成者　　:wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**初期化処理 */
export interface InitRequest extends DaRequestBase {
  /**期 */
  KI: number
}
/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
}
/**初期化処理_詳細画面 */
export interface InitDetailRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 移動開始日 */
  KEIYAKU_DATE_FROM?: Date
  /** 鶏の種類 */
  TORI_KBN?: number
  /** 農場コード(移動元) */
  NOJO_CD_MOTO?: number
  /** 農場コード(移動先) */
  NOJO_CD_SAKI?: number
}
/**初期化処理_詳細画面 */
export interface InitNojoRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /** 農場コード */
  NOJO_CD: number
}
export interface InitHasuRequest extends DaRequestBase {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 鶏の種類 */
  TORI_KBN: number
  /** 農場コード */
  NOJO_CD: number
}
export interface SaveRequest extends DaRequestBase {
  /** 契約農場別明細移動情報(入力) */
  KEIYAKUSYA_NOJO: DetailVM
}
export interface DeleteRequest {
  /** 期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 移動開始日 */
  KEIYAKU_DATE_FROM: Date
  /** 鳥の種類 */
  TORI_KBN: number
  /** 農場コード(移動元) */
  NOJO_CD_MOTO: number
  /** 農場コード(移動先) */
  NOJO_CD_SAKI: number
  /** データ更新日 */
  UP_DATE: Date
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/**初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**期 */
  KI: number
  /**契約者情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[]
}
/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約農場別明細移動情報(表示) */
  KEKKA_LIST: SearchRowVM[]
}
/**初期化処理_詳細画面 */
export interface InitDetailResponse extends DaResponseBase {
  /** 鶏の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[]
  /** 農場(移動元及び移動先)情報プルダウンリスト */
  NOJO_LIST: CmCodeNameModel[]
  /** 契約農場別明細移動情報(入力) */
  KEIYAKUSYA_NOJO: DetailVM
}

/**初期化処理_詳細画面 */
export interface InitNojoResponse extends DaResponseBase {
  /** 詳細情報 農場住所情報 */
  NOJO_ADDR: NojoAddrVM
}
export interface InitHasuResponse extends DaResponseBase {
  /** 契約羽数(移動前) */
  KEIYAKU_HASU: number
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface SearchRowVM {
  /** 移動開始日 */
  KEIYAKU_DATE_FROM: Date
  /** 鳥の種類コード */
  TORI_KBN: number
  /** 鳥の種類名 */
  TORI_KBN_NAME: string
  /** 移動羽数 */
  IDO_HASU: number
  /** 農場コード(移動元) */
  NOJO_CD_MOTO: number
  /** 農場名(移動元) */
  NOJO_NAME_MOTO: string
  /** 契約羽数(移動元) */
  KEIYAKU_HASU_MOTO_ATO: number
  /** 農場コード(移動先) */
  NOJO_CD_SAKI: number
  /** 農場名(移動先) */
  NOJO_NAME_SAKI: string
  /** 契約羽数(移動先) */
  KEIYAKU_HASU_SAKI_ATO: number
  /** 処理区分名 */
  SYORI_KBN_NAME: string
}
export interface DetailVM {
  /** 期 */
  KI?: number
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number
  /** 鶏の種類コード */
  TORI_KBN?: number
  /** 移動羽数 */
  IDO_HASU?: number
  /** 農場コード(移動元) */
  NOJO_CD_MOTO?: number
  /** 農場(移動元)　契約羽数(移動前) */
  KEIYAKU_HASU_MOTO_MAE?: number
  /** 農場(移動元)　契約羽数(移動後) */
  KEIYAKU_HASU_MOTO_ATO?: number
  /** 農場コード(移動先) */
  NOJO_CD_SAKI?: number
  /** 農場(移動先)　契約羽数(移動前) */
  KEIYAKU_HASU_SAKI_MAE?: number
  /** 農場(移動先)　契約羽数(移動後) */
  KEIYAKU_HASU_SAKI_ATO?: number
  /** 移動年月日 */
  KEIYAKU_DATE_FROM?: Date
  /** 入力確認有無 */
  SYORI_KBN: number
  /** データ更新日 */
  UP_DATE?: Date
}

export interface NojoAddrVM {
  /** 農場コード */
  NOJO_CD: number
  /** 農場名 */
  NOJO_NAME: string
  /** 農場住所（郵便番号） */
  ADDR_POST: string
  /** 農場住所（住所１） */
  ADDR_1: string
  /** 農場住所（住所2） */
  ADDR_2: string
  /** 農場住所（住所3） */
  ADDR_3: string
  /** 農場住所（住所4） */
  ADDR_4: string
}
