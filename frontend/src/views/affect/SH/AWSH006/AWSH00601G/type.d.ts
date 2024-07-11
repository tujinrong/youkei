/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 自己負担金保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchListRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 成人健(検)診事業名 */
  kensin_jigyocd: string
  /** 料金パターン */
  ryokinpattern: string
}
/** 年度変更処理 */
export interface SearchNendoRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
}
export interface SearchHikitsudugiRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 事業コード */
  // jigyocd: number
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 成人健(検)診事業名 */
  kensin_jigyocd: string
  /** 料金パターン */
  ryokinpattern: string
  /** 排他キーリスト */
  locklist: LockVM[]
  /** 自己負担金データリスト */
  savelist: RowVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** 年度 */
  nendo: number
  /** 年度範囲 */
  nendolist: number[]
  /** 「前年度引続ぎ」活性フラグ */
  hikitsudugiflg: boolean
  /** ドロップダウンリスト(成人健(検)診事業名) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(料金パターン) */
  selectorlist2: DaSelectorModel[]
}
/** 年度変更処理(一覧画面) */
export interface SearchNendoResponse extends DaResponseBase {
  /** 「前年度引続ぎ」活性フラグ */
  hikitsudugiflg: boolean
  /** ドロップダウンリスト(成人健(検)診事業名) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(料金パターン) */
  selectorlist2: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends DaResponseBase {
  /** 減免区分 */
  genmenkbn: string
  /** ドロップダウンリスト(検査方法) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(減免区分＝1(特定健診)) */
  selectorlist4: DaSelectorModel[]
  /** ドロップダウンリスト(性別) */
  selectorlist5: DaSelectorModel[]
  /** 結果リスト(検索結果一覧) */
  kekkalist: RowVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(検索結果一覧) */
export interface RowVM extends LockVM {
  /** 受診金額 */
  jusinkingaku: number
  /** 金額（市区町村負担） */
  kingaku_sityosonhutan: number
}
/** 保存処理 */
export interface LockVM {
  /** 成人健（検）診事業コード */
  kensin_jigyocd: string
  /** 料金パターン */
  ryokinpattern: string
  /** 検査方法 */
  kensahohocd: string
  /** 減免区分 */
  genmenkbncd: string
  /** 性別 */
  sex: string
  /** 年齢範囲 */
  agehani: string
  /** 更新日時 */
  upddttm?: Date | string
}
