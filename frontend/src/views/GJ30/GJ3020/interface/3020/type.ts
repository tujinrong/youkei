/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
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

/** 初期化処理_詳細画面リクエスト */
export interface InitDetailRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 変更年月日（可选） */
  KEIYAKU_DATE_FROM?: Date
}
/** 保存処理_詳細画面リクエスト */
export interface SaveRequest extends DaRequestBase {
  /** 契約区分情報(入力) */
  KEIYAKU_KBN_JOHO: DetailVM
}


/** 削除処理_詳細画面リクエスト */
export interface DeleteRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date
  /** データ更新日 */
  UP_DATE: Date
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_詳細画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 初期化情報 - 期 */
  KI: number
  /** 契約者情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[]
}


/** 検索処理_詳細画面レスポンス */
export interface SearchResponse extends DaResponseBase {
  /** 一覧情報 */
  KI: number
  /** 契約者番号 */
  KEIYAKUSYA_CD: number
  /** 契約区分情報(表示)リスト */
  KEKKA_LIST: SearchRowVM[]
}


/** 初期化処理_詳細画面レスポンス */
export interface InitDetailResponse extends DaResponseBase {
  /** 契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[]
  /** 契約区分情報(入力) */
  KEIYAKU_KBN_JOHO: DetailVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 契約区分情報(表示) - 一覧情報行のモデル */
export interface SearchRowVM {
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date
  /** 契約区分(変更前) */
  KEIYAKU_KBN_MAE: string
  /** 契約区分(変更後) */
  KEIYAKU_KBN_ATO: string
  /** 処理状況 */
  SYORI_KBN: string
  /** 請求回数 */
  SEIKYU_KAISU: number
}

/** 契約区分情報(入力) - 詳細情報のモデル */
export interface DetailVM {
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date
  /** 契約区分(変更前) */
  KEIYAKU_KBN_MAE: string
  /** 契約区分(変更後) */
  KEIYAKU_KBN_ATO: string
  /** 入力確認有無 */
  SYORI_KBN: string
  /** データ更新日 (可选) */
  UP_DATE?: Date
}

