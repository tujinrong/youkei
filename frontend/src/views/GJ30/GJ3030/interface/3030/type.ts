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
// 初期化処理_詳細画面Init Request
export interface InitRequest extends DaRequestBase {
  /** 期 */
  KI: number;
}
/** 検索処理_詳細画面 Search Request */
export interface SearchRequest {
  /** 対象期 */
  KI: number;
  /** 契約者番号(譲渡先) */
  KEIYAKUSYA_CD: number;
}

// 初期化処理_詳細画面InitDetail Request
export interface InitDetailRequest extends DaRequestBase {
  /** 期 */
  KI: number;
  /** 契約者番号(譲渡先) */
  KEIYAKUSYA_CD: number;
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date;
  /** 契約者番号(譲渡元) */
  MOTO_KEIYAKUSYA_CD: number;
}

// 保存処理_詳細画面Save Request
export interface SaveRequest extends DaRequestBase {
  /** 契約農場別明細 譲渡元情報(選択) */
  KEIYAKU_JOTO: DetailVM;
}
// 削除処理_詳細画面Delete Request
export interface DeleteRequest extends DaRequestBase {
  /** 期 */
  KI: number;
  /** 契約者番号(譲渡先) */
  KEIYAKUSYA_CD: number;
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date;
  /** 契約年月日To */
  KEIYAKU_DATE_TO: Date;
  /** 契約者番号(譲渡元) */
  MOTO_KEIYAKUSYA_CD: number;
  /** データ更新日 */
  UP_DATE: Date;
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
// 初期化処理_詳細画面Init Response
export interface InitResponse extends DaResponseBase {
  /** 期 */
  KI: number;
  /** 契約者情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[];
}

/** 検索処理_詳細画面 Search Response */
export interface SearchResponse {
  /** 一覧情報 */
  KI: number;
  /** 契約者番号(譲渡先) */
  KEIYAKUSYA_CD: number;
  /** 契約農場別明細　譲渡情報(表示)リスト */
  KEKKA_LIST: SearchRowVM[];
}
// 初期化処理_詳細画面InitDetail Response
export interface InitDetailResponse extends DaResponseBase {
  /** 契約農場別明細 譲渡元情報(選択) */
  KEIYAKU_JOTO: DetailVM;
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 契約農場別明細　譲渡情報(表示) (SearchRowVM) */
export interface SearchRowVM {
  /** 変更年月日 */
  KEIYAKU_DATE_FROM: Date;
  /** 契約者番号(譲渡元) */
  MOTO_KEIYAKUSYA_CD: number;
  /** 契約者名(譲渡元) */
  MOTO_KEIYAKUSYA_NAME: string;
  /** 処理状況コード */
  SYORI_KBN: number;
  /** 処理状況名 */
  SYORI_KBN_NAME: string;
  /** 請求回数 */
  SEIKYU_KAISU: number;
}


/** 契約区分情報 (入力) DetailVM */
export interface DetailVM {
  /** 期 */
  KI: number;
  /** 契約者番号(譲渡先) */
  KEIYAKUSYA_CD: number;
  /** 契約者番号(譲渡元) */
  MOTO_KEIYAKUSYA_CD: number;
  /** 契約者名(譲渡元) */
  MOTO_KEIYAKUSYA_NAME: string;
  /** 契約情報リスト */
  KEIYAKU_JOHO_LIST: KeiyakuJoho[];
  /** 譲渡年月日 */
  KEIYAKU_DATE_FROM: Date;
  /** 入力確認有無 */
  SYORI_KBN: string;
  /** データ更新日 */
  UP_DATE: Date | null;
}

/** 契約情報 (KeiyakuJoho) */
export interface KeiyakuJoho {
  /** 農場コード(譲渡元) */
  MOTO_NOJO_CD: number;
  /** 契約区分(譲渡先) */
  KEIYAKU_KBN: number | null;
  /** 農場名(譲渡元) */
  MOTO_NOJO_NAME: string;
  /** 農場住所(譲渡元) */
  ADDR: string;
  /** 鶏の種類コード */
  TORI_KBN: number;
  /** 鶏の種類名 */
  TORI_KBN_NAME: string;
  /** 契約羽数 */
  KEIYAKU_HASU: number;
}


