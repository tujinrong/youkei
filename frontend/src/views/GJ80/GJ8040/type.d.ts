/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.20
 * 作成者　　: 魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/**削除処理(一覧画面) */
export interface DeleteRequest extends DaRequestBase {
  /**ユーザID */
  USERID: string
  /**更新時間 */
  UP_DATE: Date
}

/**検索処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /**ユーザID */
  USERID: string
}

/**登録処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /**使用者情報 */
  USER: DetailVM
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/**検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**ユーザー情報リスト */
  KEKKA_LIST: SearchRowVM[]
}

/**検索処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**使用者情報 */
  USER: DetailVM
  /**使用区分 */
  SIYO_KBN_LIST: CmCodeNameModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

export interface SearchRowVM {
  /**ユーザID */
  USER_ID: string
  /**ユーザ名 */
  USER_NAME: string
  /**使用区分  */
  SIYO_KBN: number | string
  /**停止日  */
  TEISI_DATE: Date | undefined
  /**停止理由  */
  TEISI_RIYU: string
}

/**契約者農場情報 */
export interface DetailVM {
  /**ユーザID */
  USERID: string
  /**ユーザ名 */
  USER_NAME: string
  /**パスワード */
  PASS: string
  /**パスワード有効期限 */
  PASS_KIGEN_DATE: Date
  /**パスワード変更日 */
  PASS_UP_DATE: Date
  /**使用区分  */
  SIYO_KBN: number
  /**停止日  */
  TEISI_DATE: Date
  /**停止理由  */
  TEISI_RIYU: string
  /**更新時間 */
  UP_DATE?: Date
}
