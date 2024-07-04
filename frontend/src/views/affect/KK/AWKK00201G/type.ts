/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 医療機関保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.11.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 医療機関コード */
  kikancd: string
  /** 保険医療機関コード */
  hokenkikancd: string
  /** 医療機関名 */
  kikannm: string
  /** 医療機関名カナ */
  kanakikannm: string
  /** 住所 */
  adrs: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 医療機関コード */
  kikancd: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 医療機関情報メイン */
  maininfo: MainInfoVM
  // /** 実施事業リスト */
  jissijigyoSelectorList: JissijigyoOneInitVM[]
  /** 編集区分 */
  editkbn: Enum編集区分
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(医療機関コード) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(保険医療機関コード) */
  selectorlist2: DaSelectorModel[]
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(医療機関一覧) */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 実施事業リスト */
  jissijigyoSelectorList: JissijigyoOneInitVM[]
  jissijigyoList: JissijigyoOneInitVM[]
  syozokuisikaiList: DaSelectorModel[]
  /** 業務ドロップダウンリスト */
  gyoSelectorList: DaSelectorModel[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends InitDetailResponse {
  /** 医療機関情報メイン */
  mainInfo: MainInfoVM
  // /** 編集区分 */
  // editkbn: Enum編集区分
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM extends BaseInfoVM {
  /** 電話番号 */
  tel: string
  /** 郵便番号 */
  yubin: string
  /** 住所 */
  adrs: string
  /** 利用状態 */
  stopflg: string
}
/** 医療機関(メイン：ベース) */
export interface BaseInfoVM {
  /** 医療機関コード */
  kikancd: string
  /** 保険医療機関コード */
  hokenkikancd: string
  /** 医療機関名 */
  kikannm: string
  /** 医療機関名(カナ) */
  kanakikannm: string
}
/** 医療機関情報 */
export interface MainInfoVM extends BaseInfoVM {
  /** 電話番号 */
  tel: string
  /** 郵便番号 */
  yubin: string
  /** FAX番号 */
  fax: string
  /** 使用停止フラグ */
  stopflg: boolean
  /** 住所 */
  adrs: string
  /** 方書 */
  katagaki: string
  /** 所属医師会 */
  syozokuisikai: string
}
/** 初期化モデル */
export interface JissijigyoOneInitVM {
  /** 実施事業名称 */
  jissijigyonm: string
  /** 汎用コード（実施事業コード） */
  jissijigyo: string
  /** 選択フラグ */
  checkflg: boolean
  /** 汎用区分1 */
  hanyokbn1: string
}
