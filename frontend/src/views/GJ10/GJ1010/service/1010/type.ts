/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
export interface InitRequest extends DaRequestBase {
  /**期 */
  KI: number
}

export interface SearchRequest extends CmSearchRequestBase {
  /**期 */
  KI: number
  /**都道府県 */
  KEN_CD: CmCodeFmToModel
  /**未継続・未契約者を除く */
  NOZOKU_FLG: boolean
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**契約区分 */
  KEIYAKU_KBN: number | undefined
  /**契約状況 */
  KEIYAKU_JYOKYO: number | undefined
  /**契約者名 */
  KEIYAKUSYA_NAME?: string
  /**契約者名（ﾌﾘｶﾞﾅ） */
  KEIYAKUSYA_KANA?: string
  /**住所 */
  ADDR?: string
  /**電話番号 */
  ADDR_TEL1?: string
  /**事務委託先 */
  JIMUITAKU_CD: CmCodeFmToModel
  /**検索方法 */
  SEARCH_METHOD: EnumAndOr
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
export interface InitResponse extends DaResponseBase {
  /**期 */
  KI: number
  /**都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]
  /**契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[]
  /**契約状況情報プルダウンリスト */
  KEIYAKU_JYOKYO_LIST: CmCodeNameModel[]
  /**事務委託先情報プルダウンリスト */
  ITAKU_LIST: CmCodeNameModel[]
}

export interface SearchResponse extends CmSearchResponseBase {
  /**期 */
  KI: number
  /**契約者情報リスト */
  KEKKA_LIST: SearchRowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface SearchRowVM {
  /**契約者番号 */
  KEIYAKUSYA_CD: number
  /**契約者名 */
  KEIYAKUSYA_NAME: string
  /**フリガナ */
  KEIYAKUSYA_KANA: string
  /**契約区分コード */
  KEIYAKU_KBN: number
  /**契約区分名 */
  KEIYAKU_KBN_NAME: string
  /**契約状況コード */
  KEIYAKU_JYOKYO: number
  /**契約状況名 */
  KEIYAKU_JYOKYO_NAME: string
  /**電話番号 */
  ADDR_TEL1: string
  /**都道府県コード */
  KEN_CD: number
  /**都道府県コード名 */
  KEN_CD_NAME: string
  /**事務委託先番号 */
  JIMUITAKU_CD: number
  /**事務委託先名(略称) */
  ITAKU_RYAKU: string
}
