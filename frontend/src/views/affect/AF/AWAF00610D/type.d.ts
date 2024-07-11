/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診結果・保健指導履歴照会
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.14
 * 作成者　　: 張加恒
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 遷移処理 */
export interface SearchSeniRequest extends DaRequestBase {
  /** 事業コード */
  jigyocd: string
  /** 開いた機能ID */
  kinoids: string[]
  /** 機能ID（指導） */
  kinoid2?: string
}
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 個人基本情報 */
  headerinfo: PersonHeaderVM
  /** 結果リスト */
  kekkalist: RowVM[]
}
/** 遷移処理 */
export interface SearchSeniResponse extends DaResponseBase {
  /** 機能ID */
  kinoid: string
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 初期化処理 */
export interface PersonHeaderVM extends CommonBarHeaderBaseVM {
  /** 宛名番号 */
  atenano: string
}
export interface RowVM {
  /** 実施時年齢 */
  jissiage: string
  /** 健（検）診種別 */
  kstype: string
  /** 健（検）診年月日 */
  ksymd: string
  /** 一次 / 精密 */
  kskbn: string
  /** 検査方法 */
  kshoho: string
  /** 保健指導区分コード (訪問指導区分)*/
  hokensidokbn: string
  /** 保健指導区分 */
  hskbnnm: string
  /** 業務区分 */
  gyomukbn: string
  /** 事業コード */
  jigyocd: string
  /** 事業名 */
  jigyonm: string
  /** 実施日 */
  jissiymd: string
  /** 実施時間 */
  jissitm: string
  /** 実施者 */
  jissistaffnm: string
  /** 枝番（キー項目、非表示） */
  edano: number
  /** 年度（各健（検）診結果情報） */
  nendo: number
}
