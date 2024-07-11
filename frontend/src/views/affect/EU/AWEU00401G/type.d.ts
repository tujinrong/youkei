import { Enum編集区分 } from '#/Enums'
/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 *
 * 作成日　　: 2023.10.31
 * 作成者　　: 王
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /**帳票グループID */
  rptgroupid?: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**帳票グループのドロップダウンリスト */
  groupList: DaSelectorModel[]
}

/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /**検索結果 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 検索処理 */
export interface SearchVM {
  /**帳票ID */
  rptgroupid: string
  /** 帳票グループ */
  rptgroupnm: string
  /**個人連絡先 */
  kojinrenrakusakicd: string
  /** メモ情報 */
  memocd: string
  /** 電子ファイル情報 */
  electronfilecd: string
  /**フォロー管理 */
  followmanage: string
}
