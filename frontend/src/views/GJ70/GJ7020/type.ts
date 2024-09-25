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

  /** 対象期 */
  KI?: number;

  /** 都道府県 */
  KEN_CD: CmCodeFmToModel;

  /** 契約者番号 */
  KEIYAKUSYA_CD: CmCodeFmToModel;

  /** 契約区分 */
  KEIYAKU_KBN?: CmCodeFmToModel;

  /** 契約状況 */
  KEIYAKU_JYOKYO?: CmCodeFmToModel;

  /** 事務委託先 */
  JIMUITAKU_CD?: CmCodeFmToModel;

  /** 契約変更 */
  KEIYAKU_HENKO_KBN: KeiyakuHenkoKbn;

  /** 請求・返還区分 */
  SEIKYU_HENKAN_KBN: SeikyuHenkanKbn;

  /** 入金・振込状況 */
  SYORI_JOKYO_KBN: SyoriJokyoKbn;

  /** 請求・返還日 */
  SEIKYU_DATE: CmDateFmToModel;

  /** 入金・振込日 */
  NYUKIN_DATE: CmDateFmToModel;

  /** 出力項目選択 */
  SYUTURYOKU_KOMOKU_SENTAKU: number;

  /** 検索方法 */
  SEARCH_METHOD: EnumAndOr;
}
/** CSV出力処理_一覧画面リクエスト */
export interface CsvExportRequest {
  /** 契約日未入力者を除く */
  KEIYAKU_DATE_NOZOKU_FLG?: boolean;

  /** 対象期 */
  KI?: number;

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

  /** 契約変更 */
  KEIYAKU_HENKO_KBN?: KeiyakuHenkoKbn;

  /** 請求・返還区分 */
  SEIKYU_HENKAN_KBN?: SeikyuHenkanKbn;

  /** 入金・振込状況 */
  SYORI_JOKYO_KBN?: SyoriJokyoKbn;

  /** 請求・返還日 */
  SEIKYU_DATE?: CmDateFmToModel;

  /** 入金・振込日 */
  NYUKIN_DATE?: CmDateFmToModel;

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
}

/** 検索処理_一覧画面レスポンス */
export interface SearchResponse extends DaResponseBase {
  /** 対象期 */
  KI?: number;

  /** 明細件数 */
  MEISAI_TOTAL_ROW_COUNT?: number;

  /** 積立金情報リスト */
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
/** 契約変更情報 */
export interface KeiyakuHenkoKbn {
  SYOKI_KEIYAKU?: boolean;
  ZOHA?: boolean;
  KEIYAKU_KBN_HENKO?: boolean;
  JOTO?: boolean;
  IDO?: boolean;
}

/** 請求・返還区分情報 */
export interface SeikyuHenkanKbn {
  SEIKYU_SHINKI?: boolean;
  ICHIBU_SEIKYU?: boolean;
  ICHIBU_HENKAN?: boolean;
  ZENGAKU_HENKAN?: boolean;
}

/** 入金・振込状況情報 */
export interface SyoriJokyoKbn {
  NYUKIN_FURIKOMI_ZUMI?: boolean;
  MI_NYUKIN_FURIKOMI?: boolean;
  ICHIBU_NYUKIN?: boolean;
}
/** 検索結果行情報 */
export interface SearchRowVM {
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number;

  /** 契約者名 */
  KEIYAKUSYA_NAME?: string;

  /** 契約区分コード */
  KEIYAKU_KBN?: number;

  /** 契約区分名 */
  KEIYAKU_KBN_NAME?: string;

  /** 都道府県コード */
  KEN_CD?: number;

  /** 都道府県コード名 */
  KEN_CD_NAME?: string;

  /** 事務委託先コード */
  ITAKU_CD?: number;

  /** 事務委託先名 */
  ITAKU_NAME?: string;

  /** 回数 */
  SEIKYU_KAISU?: number;

  /** 請求・返還日 */
  SEIKYU_DATE?: Date;

  /** 契約変更コード */
  KEIYAKU_HENKO_KBN?: number;

  /** 契約変更名 */
  KEIYAKU_HENKO_KBN_NAME?: string;

  /** 請求・返還区分コード */
  SEIKYU_HENKAN_KBN?: number;

  /** 請求・返還区分名 */
  SEIKYU_HENKAN_KBN_NAME?: string;

  /** 請求・返還金額 */
  SEIKYU_KIN?: number;
}
