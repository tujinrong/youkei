/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者検索
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.10.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**  */
export interface SearchRequest extends CmSearchRequestBase {
  /** 事業従事者氏名 */
  staffsimei?: string
  /** 職種 */
  syokusyu?: string
  /** 活動区分 */
  katudokbn?: string
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
  /** 実施事業(複数「,」で連結)  */
  jigyocds?: string
  /** 使用停止sql  */
  hasStopFlg: boolean
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /** ドロップダウンリスト(職種) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(活動区分) */
  selectorlist2: DaSelectorModel[]
}
/** 初期化処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /** 事業従事者（担当者）情報 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 事業従事者（担当者）情報モデル */
export interface SearchVM {
  /** 事業従事者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
  /** 職種 */
  syokusyunm: string
  /** 活動区分 */
  katudokbnnm: string
}
