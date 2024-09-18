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
export interface InitRequest {
  /** 対象期 */
  KI?: number;
}
/** 検索処理_一覧画面リクエスト */
export interface SearchRequest {
  /** 対象期 */
  KI?: number;

  /** 対象年月 */
  KEISAN_DATE?: Date;

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

  /** 認定回数 */
  HASSEI_KAISU: CmCodeFmToModel;

  /** 交付通知書処理状況 */
  SYORI_JOKYO: SyoriJokyo;

  /** 通知書発行日 */
  KOFUTUTI_HAKKO_DATE: CmDateFmToModel;

  /** 出力項目選択 */
  SYUTURYOKU_KOMOKU_SENTAKU?: number;

  /** 検索方法 */
  SEARCH_METHOD: EnumAndOr;
}

/** CSV出力処理_一覧画面リクエスト */
export interface CsvExportRequest {
  /** 対象期 */
  KI?: number;

  /** 対象年月 */
  KEISAN_DATE?: Date;

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

  /** 認定回数 */
  HASSEI_KAISU: CmCodeFmToModel;

  /** 交付通知書処理状況 */
  SYORI_JOKYO: SyoriJokyo;

  /** 通知書発行日 */
  KOFUTUTI_HAKKO_DATE: CmDateFmToModel;

  /** 出力項目選択 */
  SYUTURYOKU_KOMOKU_SENTAKU?: number;

  /** 検索方法 */
  SEARCH_METHOD: EnumAndOr;
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_一覧画面レスポンス */
export interface InitResponse {
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
}
/** 検索処理_一覧画面レスポンス */
export interface SearchResponse {
  /** 対象期 */
  KI?: number;

  /** 明細件数 */
  MEISAI_TOTAL_ROW_COUNT: number;

  /** 互助金交付情報リスト */
  KEKKA_LIST: SearchRowVM[];
}
/** CSV出力処理_一覧画面レスポンス */
export interface CsvExportResponse extends DaResponseBase {
  /** ドキュメント情報 */
  DATA: Blob;
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 処理状況 */
export interface SyoriJokyo {
  /** 発行済 */
  HAKKO_ZUMI :boolean
  /** 未発行 */
  MI_HAKKO :boolean
}
/** 検索結果行 */
export interface SearchRowVM {
  /** 認定回数 */
  HASSEI_KAISU: number;

  /** 契約者番号 */
  KEIYAKUSYA_CD: number;

  /** 契約者名 */
  KEIYAKUSYA_NAME: string;

  /** フリガナ */
  KEIYAKUSYA_KANA: string;

  /** 契約区分コード */
  KEIYAKU_KBN: number;

  /** 契約区分名 */
  KEIYAKU_KBN_NAME: string;

  /** 都道府県コード */
  KEN_CD: number;

  /** 都道府県コード名 */
  KEN_CD_NAME: string;

  /** 事務委託先コード */
  ITAKU_CD: number;

  /** 事務委託先名 */
  ITAKU_NAME: string;

  /** 振込予定日 */
  FURIKOMI_YOTEI_DATE: Date;

  /** 互助交付金 */
  KOFU_KIN_KEI: number;
}
