/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 予防接種情報管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.10.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**検索処理(世帯一覧)・初期化処理(詳細画面 */
export interface CommonRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 予防接種情報一覧画面検索処理(一覧画面) */
export type SearchListRequest = PersonSearchRequest

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 住民情報(ヘッダー) */
  headerinfo: CommonBarHeaderBase2VM
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 住民・住登外一覧 */
  kekkalist: JyuminListVM[]
  /** 遷移フラグ */
  transflg: boolean
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面ベース) */
export interface BaseInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sexhyoki: string
  /** 生年月日 */
  bymd: string
  /** 住民区分 */
  juminkbn: string
  /** 警告内容 */
  keikoku: string
}
/** 検索処理(予防接種情報一覧画面) */
export interface JyuminListVM extends BaseInfoVM {
  /** 住所(住所1、住所2) */
  adrs: string
  /** 行政区 */
  gyoseiku: string
}
