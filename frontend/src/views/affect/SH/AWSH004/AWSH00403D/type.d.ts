/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 料金内訳
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.26
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 宛名番号 */
  atenano: string
  /** 予約情報一覧 */
  kekkalist: MoneyKeyBase2VM[]
}
/** 自己負担金キー */
export interface MoneyKeyBaseVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 日程番号 */
  nitteino: number
}
/** 自己負担金キー(インタフェース用) */
export interface MoneyKeyBase2VM extends MoneyKeyBaseVM {
  /** 検査方法(コード：名称) */
  kensahohocdnm: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 個人基本情報 */
  headerinfo: HeaderVM
  /** 自己負担金情報 */
  kekkalist: RowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** ヘッダー情報 */
export interface HeaderVM extends CommonBarHeaderBaseVM {
  /** 減免区分（特定健診）名称 */
  genmenkbn_tokutei: string
  /** 減免区分（がん検診）名称 */
  genmenkbn_gan: string
}
/** 自己負担金情報(1件) */
export interface RowVM {
  /** 検診名 */
  jigyonm: string
  /** 受診金額 */
  jusinkingaku: string
  /** （市区町村負担）金額 */
  kingaku_sityosonhutan: string
}
