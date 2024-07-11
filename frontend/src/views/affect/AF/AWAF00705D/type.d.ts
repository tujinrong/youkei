/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 宛名番号
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.04.01
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 性別 */
  sexlist: DaSelectorModel[]
  /** 住民区分 */
  juminkbnlist: DaSelectorModel[]
  /** 保険区分 */
  hokenkbnlist: DaSelectorModel[]
  /** ドロップダウンリスト(住民区分)初期値 */
  juminkbns: string[]
}

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 生年月日 */
  bymd: string
  /** 性別 */
  sex: string[]
  /** 住民区分 */
  juminkbn: string[]
  /** 保険区分 */
  hokenkbn: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 個人情報 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sex: string
  /** 生年月日 */
  bymd: string
  /** 住所 */
  adrs: string
  /** 行政区分 */
  gyoseiku: string
  /** 住民区分 */
  juminkbn: string
  /** 保険区分 */
  hokenkbn: string
  /** 警告内容 */
  keikoku: string
}
