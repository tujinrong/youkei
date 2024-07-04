//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 乳幼児情報一覧画面検索処理 */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 乳幼児情報一覧画面検索処理 */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 乳幼児情報（ヘッダー情報） */
  headerinfo: HeaderInfoVM
  /** 乳幼児情報（一覧情報） */
  kekkalist: ListInfoVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 乳幼児情報一覧_(メイン：ベース) */
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
}
/** 乳幼児情報一覧_ヘッダー部 */
export interface HeaderInfoVM extends BaseInfoVM {
  /** 住民区分（内容） */
  juminkbnnm: string
  /** 年齢 */
  age: string
  /** 年齡計算基準日 */
  agekijunymd: string
}
/** 乳幼児情報一覧（表示用） */
export interface ListInfoVM extends BaseInfoVM {
  /** no */
  no: string
}
