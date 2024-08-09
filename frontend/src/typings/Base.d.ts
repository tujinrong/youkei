/** ----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: ベースロジック
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.07.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 共通ベース：参照用、実質データ格納しない、httpのヘッダーに格納する */
interface DaRequestBase {
  /** ユーザーID */
  USER_ID?: string
}

/** 登録処理 */
interface CmSaveRequestBase extends DaRequestBase {
  /** チェックフラグ */
  CHECK_FLG: boolean
}

/** 検索処理 */
interface CmSearchRequestBase extends DaRequestBase {
  /** ページサイズ */
  PAGE_SIZE: number
  /** ページNo. */
  PAGE_NUM: number
  /** 並び順 */
  ORDER_BY?: number
}

/** upload file */
interface CmUploadRequestBase extends DaRequestBase {
  files: File[] | null
  filerequired?: boolean
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 共通ベース */
interface DaResponseBase {
  /** レスポンス状態区別 */
  RETURN_CODE: import('@/enum').EnumServiceResult
  /** メッセージ */
  MESSAGE: string
  // /** 秘密キー(復号化用) */
  // rsaprivatekey?: string
}

/** 検索処理 */
interface CmSearchResponseBase extends DaResponseBase {
  /** ページ数 */
  TOTAL_PAGE_COUNT: number
  /** 総件数 */
  TOTAL_ROW_COUNT: number
}

/** ドロップダウンリスト */
interface CodeNameModel {
  /** 名称 */
  CODE: string
  /** コード */
  NAME: string
  /** 無効属性 */
  disabled?: boolean
}
/** ドロップダウンリスト */
interface DaSelectorDisabledModel extends CodeNameModel {
  /** 無効属性 */
  disabled: boolean
}
/** ドロップダウンリスト(連動用) */
interface DaSelectorKeyModel extends CodeNameModel {
  /** キー項目(連動フィルター用) */
  key: string
}
/** ドロップダウンリスト(ツリー) */
interface DaSelectorTreeModel<T extends CodeNameModel> extends CodeNameModel {
  /** 子ドロップダウンリスト(連動用) */
  children: T[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** メニュー */
interface MenuModel {
  /**パス(URL用) */
  path: string
  /**親メニューID */
  parentid: string
  /**フォルダの場合：True　メニューの場合:false */
  isfolder: boolean
  /**フォルダ内シーケンス */
  menuseq: number
  /**メニュー表示名称/画面名称共有 */
  menuname: string
  /**検索パラメーター継承フラグ */
  paramkeisyoflg: boolean
  /**利用権限がない場合、falseと設定 */
  enabled: boolean
  /**メニューID */
  menuid: string
  /**追加権限フラグ */
  addflg: boolean
  /**修正権限フラグ */
  deleteflg: boolean
  /**削除権限フラグ */
  updateflg: boolean
  /**個人番号利用権限フラグ */
  personalnoflg: boolean
}

interface ProgramModel {
  /**機能ID */
  kinoid: string
  /**メニューIDリスト */
  menuids: string[]
}

interface StrObj {
  [x: string]: string
}
