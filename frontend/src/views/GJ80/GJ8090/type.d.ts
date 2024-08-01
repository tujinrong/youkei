/** ----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitRequest extends DaRequestBase {
  /**期 */
  KI: number
}

/**検索処理(一覧画面) */
export interface SearchRequest extends CmSearchRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD?: number
  /**農場番号 */
  NOJO_CD?: number
  /**農場名 */
  NOJO_NAME?: string
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
}

/**検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**農場コード */
  NOJO_CD: number
}

/**保存処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者農場 */
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
  MEISAINO: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /**対象期 */
  KI: number
  /**契約者情報プルダウンリスト */
  KEIYAKUSYA_CD_NAME_LIST: DaSelectorModel[]
}

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者農場情報リスト */
  KEKKA_LIST: KeiyakuNojoSearchVM[]
}

/**初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**契約者名 */
  KEIYAKUSYA_NAME: string
  /**都道府県情報プルダウンリスト */
  KEN_CD_NAME_LIST: DaSelectorModel[]
}

/**検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  KEIYAKUSYA_NOJO: KeiyakuNojoSearchDetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface KeiyakuNojoSearchVM {
  /**農場コード */
  NOJO_CD: number
  /**農場名 */
  NOJO_NAME: string
  /**住所 */
  ADDR: string
}

export interface KeiyakuNojoSearchDetailVM {
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
  MEISAINO: number
}
