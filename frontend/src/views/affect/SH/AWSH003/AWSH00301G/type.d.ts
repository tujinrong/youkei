/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診対象者設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.31
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
}
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** 情報一覧 */
  kekkalist: RowVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 事業一覧 */
  selectorlist1: DaSelectorModel[]
  /** 検査方法一覧 */
  selectorlist2: DaSelectorKeyModel[]
  /** 性別一覧 */
  selectorlist3: DaSelectorModel[]
  /** 基準日区分一覧 */
  selectorlist4: DaSelectorModel[]
  /** 保険区分一覧 */
  selectorlist5: DaSelectorModel[]
  /** 特殊処理一覧 */
  selectorlist6: DaSelectorModel[]
  /** 年度 */
  nendo: number
}
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 情報一覧 */
  kekkalist: RowVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 行モデル(事業単位) */
export interface RowVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 検査方法単位情報 */
  rows: HohoRowVM[]
}
/** 行モデル(検査方法単位) */
export interface HohoRowVM {
  /** 検査方法コード */
  kensahohocd?: string
  /** 性別コード */
  sex: string
  /** 年齢コード */
  age: string
  /** 年齢基準日区分コード */
  kijunkbn: string
  /** 年齢計算基準日 */
  kijunymd: string
  /** 保険区分コード */
  hokenkbn: string
  /** 特殊コード */
  tokusyu: string
  /** SQL文 */
  sql: string
}
/** 排他チェック用モデル */
export interface LockVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 検査方法コード */
  kensahohocd?: string
  /** 更新日時 */
  upddttm: Date | string
}

//for frontend
export interface ItemVM extends Omit<RowVM, 'rows'>, HohoRowVM {
  /** 背景色区分 by index */
  groupNo?: number
  /** 新しい */
  newflg?: boolean
  /** 線 */
  lastflag?: boolean
}

type OptionsVM = Omit<InitResponse, keyof DaResponseBase | 'nendo'>
