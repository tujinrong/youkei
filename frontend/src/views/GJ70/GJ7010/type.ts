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
  /** 入金日・振込日 */
  NYUKIN_DATE?: Date;
  /** 対象期 */
  KI?: number;
  /** 請求・返還回数 */
  SEIKYU_KAISU?: CmCodeFmToModel;
  /** 都道府県 */
  KEN_CD?: CmCodeFmToModel;
  /** 事務委託先 */
  JIMUITAKU_CD?: number;
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number;
  /** 契約者名（カナ） */
  KEIYAKUSYA_KANA?: string;
  /** 契約者名（漢字） */
  KEIYAKUSYA_NAME?: string;
  /** 請求・返還金額（入金金額） */
  SAGUKU_SEIKYU_KIN?: CmCodeFmToModel;
  /** 納付方法 */
  SEIKYU_HENKAN_KBN?: number;
  /** 処理状況 */
  SYORI_JOKYO_KBN?: number;
  /** 入金・返還日 */
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
  KEN_LIST?: CmCodeNameModel[];
  /** 事務委託先情報プルダウンリスト */
  JIMUITAKU_LIST?: CmCodeNameModel[];
}
/** 検索処理_一覧画面レスポンス */
export interface SearchResponse extends DaResponseBase {
  /** 一覧情報 */
  KEKKA_LIST?: SearchRowVM[];
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索結果行情報 */
export interface SearchRowVM {
  /** 対象期 */
  KI?: number;
  /** 請求(返還)回数 */
  SEIKYU_KAISU?: number;
  /** 積立金区分 */
  TUMITATE_KBN?: number;
  /** 契約者番号 */
  KEIYAKUSYA_CD?: number;
  /** 契約者名 */
  KEIYAKUSYA_NAME?: string;
  /** フリガナ */
  KEIYAKUSYA_KANA?: string;
  /** 処理状況コード */
  SYORI_JOKYO_KBN?: number;
  /** 処理状況名 */
  SYORI_JOKYO_NAME?: string;
  /** 請求・返還コード */
  SEIKYU_HENKAN_KBN?: number;
  /** 請求・返還名 */
  SEIKYU_HENKAN_KBN_NAME?: string;
  /** 請求・返還日 */
  SEIKYU_DATE?: Date;
  /** 入金・振込日 */
  NYUKIN_DATE?: Date;
  /** 請求金額/返還金額 */
  SEIKYU_KIN?: number;
}
