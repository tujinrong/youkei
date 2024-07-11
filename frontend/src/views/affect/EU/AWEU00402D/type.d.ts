import { Enum編集区分 } from '#/Enums'
/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票データグループ一覧
 *
 * 作成日　　: 2024.4.11
 * 作成者　　: 魏
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 編集区分 */
  editkbn: Enum編集区分
  /**帳票グループID */
  rptgroupid?: string
}

/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 更新日時 */
  upddttm?: Date
  /** 帳票グループID */
  rptgroupid?: string
  /** 帳票グループ名 */
  rptgroupnm: string
  /** 個人連絡先 */
  kojinrenrakusakicd: string
  /** メモ情報（複数） */
  memocd: string
  /** 電子ファイル（複数） */
  electronfilecd: string
  /** フォロー管理（複数） */
  followmanage: string
  /** 業務区分 */
  gyomukbn: string
  /**並び順 */
  orderseq?: number
}

/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /**更新日時 */
  upddttm?: Date
  /**帳票グループID */
  rptgroupid?: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**帳票グループ名 */
  rptgroupnm: string
  /**業務区分 */
  gyomukbn: string
  /**個人連絡先 */
  kojinrenrakusakicd: string
  /**メモ情報（複数） */
  memocd: string
  /**電子ファイル（複数） */
  electronfilecd: string
  /**フォロー管理（複数） */
  followmanage: string
  /**並び順 */
  orderseq: number
  /**更新日時 */
  upddttm: Date
  /**業務区分のドロップダウンリスト */
  gyomukbnList: DaSelectorModel[]
  /**個人連絡先のドロップダウンリスト */
  renrakusakicds: DaSelectorModel[]
  /**メモ情報のドロップダウンリスト */
  memocds: DaSelectorModel[]
  /**電子ファイル情報のドロップダウンリスト */
  electronfilecds: DaSelectorModel[]
  /**フォロー管理のドロップダウンリスト */
  followmanages: DaSelectorModel[]
}
