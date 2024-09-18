/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr } from "@/enum";

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理_一覧画面リクエスト */
export interface InitRequest extends DaRequestBase {
  /** 対象期 */
  KI?: number;
}
/** 検索処理_一覧画面リクエスト */
export interface SearchRequest extends DaRequestBase {
  /** 契約日未入力者を除く */
  KEIYAKU_DATE_NOZOKU_FLG?: boolean;
  /** 入金・返還日未入力者を除く */
  NYUHEN_DATE_NOZOKU_FLG?: boolean;
  /** 対象期 */
  KI?: number;
  /** 対象年月 */
  KEIYAKU_DATE_TO?: Date;
  /** 都道府県 */
  KEN_CD: CmCodeFmToModel;
  /** 契約者番号 */
  KEIYAKUSYA_CD: CmCodeFmToModel;
  /** 契約区分 */
  KEIYAKU_KBN: CmCodeFmToModel;
  /** 契約状況 */
  KEIYAKU_JYOKYO: CmCodeFmToModel;
  /** 事務委託先 */
  JIMUITAKU_CD: CmCodeFmToModel;
  /** 鶏の種類 */
  TORI_KBN: CmCodeFmToModel;
  /** 契約年月日 */
  KEIYAKU_DATE: CmDateFmToModel;
  /** 出力項目選択 */
  SYUTURYOKU_KOMOKU_SENTAKU?: number;
  /** 検索方法 */
  SEARCH_METHOD?: EnumAndOr;
}
/** CSV出力処理_一覧画面リクエスト */
export interface CsvExportRequest extends DaRequestBase {
  /** 契約日未入力者を除く */
  KEIYAKU_DATE_NOZOKU_FLG?: boolean;
  /** 入金・返還日未入力者を除く */
  NYUHEN_DATE_NOZOKU_FLG?: boolean;
  /** 対象期 */
  KI?: number;
  /** 対象年月 */
  KEIYAKU_DATE_TO?: Date;
  /** 都道府県 */
  KEN_CD?: CmCodeFmToModel;
  /** 契約者番号 */
  KEIYAKUSYA_CD?: CmCodeFmToModel;
  /** 契約区分 */
  KEIYAKU_KBN?: CmCodeFmToModel;
  /** 契約状況 */
  KEIYAKU_JYOKYO?: CmCodeFmToModel;
  /** 事務委託先 */
  JIMUITAKU_CD?: CmCodeFmToModel;
  /** 鶏の種類 */
  TORI_KBN?: CmCodeFmToModel;
  /** 契約年月日 */
  KEIYAKU_DATE?: CmDateFmToModel;
  /** 出力項目選択 */
  SYUTURYOKU_KOMOKU_SENTAKU?: number;
  /** 検索方法 */
  SEARCH_METHOD?: EnumAndOr;
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_一覧画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 対象期 */
  KI?: number;
  /** 都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[];
  /** 契約者情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[];
  /** 契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[];
  /** 契約状況情報プルダウンリスト */
  KEIYAKU_JYOKYO_LIST: CmCodeNameModel[];
  /** 事務委託先情報プルダウンリスト */
  JIMUITAKU_LIST: CmCodeNameModel[];
  /** 鶏の種類情報プルダウンリスト */
  TORI_KBN_LIST: CmCodeNameModel[];
}

/** 検索処理_一覧画面レスポンス */
export interface SearchResponse extends DaResponseBase {
  /** 対象期 */
  KI?: number;
  /** 農場件数 */
  MEISAI_TOTAL_ROW_COUNT?: number;
  /** 契約者情報リスト */
  KEKKA_LIST?: SearchRowVM[];
}
/** CSV出力処理_一覧画面レスポンス */
export interface CsvExportResponse extends DaResponseBase {
  /** ドキュメント情報 */
  DATA: Blob;
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 契約者信息 */
export interface SearchRowVM {
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number;
  /** 契約者名 */
  KEIYAKUSYA_NAME?: string;
  /** フリガナ */
  KEIYAKUSYA_KANA?: string;
  /** 契約区分コード */
  KEIYAKU_KBN?: number;
  /** 契約区分名 */
  KEIYAKU_KBN_NAME?: string;
  /** 契約状況コード */
  KEIYAKU_JYOKYO?: number;
  /** 契約状況名 */
  KEIYAKU_JYOKYO_NAME?: string;
  /** 電話番号 */
  ADD_TEL1?: string;
  /** 都道府県コード */
  KEN_CD?: number;
  /** 都道府県コード名 */
  KEN_CD_NAME?: string;
  /** 事務委託先コード */
  ITAKU_CD?: number;
  /** 事務委託先名 */
  ITAKU_NAME?: string;
}
