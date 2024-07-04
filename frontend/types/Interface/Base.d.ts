/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ベースロジック
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.03.03
 * 作成者　　: 劉
 * 変更履歴　:
 * -----------------------------------------------------------------*/
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 共通ベース：参照用、実質データ格納しない、httpのヘッダーに格納する */
interface DaRequestBase {
  /** ユーザーID */
  userid?: string
  /** 支所 */
  regsisyo?: string
}
/** 排他処理 */
interface CmLockRequestBase extends DaRequestBase {
  /** タイムスタンプ */
  timestamp: Date | null
}
/** 登録処理 */
interface CmSaveRequestBase extends DaRequestBase {
  /** チェックフラグ */
  checkflg: boolean
}
/** 検索処理 */
interface CmSearchRequestBase extends DaRequestBase {
  /** ページサイズ */
  pagesize: number
  /** ページNo. */
  pagenum: number
  /** 並び順 */
  orderby?: number
  // //
  // queryflg?: boolean
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
  returncode: import('#/Enums').EnumServiceResult
  /** メッセージ */
  message: string
  /** 秘密キー(復号化用) */
  rsaprivatekey?: string
}
/** 排他処理 */
interface CmLockResponseBase extends DaResponseBase {
  /** タイムスタンプ */
  timestamp: Date | null
}
/** 検索処理 */
interface CmSearchResponseBase extends DaResponseBase {
  /** ページ数 */
  totalpagecount: number
  /** 総件数 */
  totalrowcount: number
}
/** ドロップダウンリスト */
interface DaSelectorModel {
  /** 名称 */
  label: string
  /** コード */
  value: string
  /** 無効属性 */
  disabled?: boolean
}
/** ドロップダウンリスト */
interface DaSelectorDisabledModel extends DaSelectorModel {
  /** 無効属性 */
  disabled: boolean
}
/** ドロップダウンリスト(連動用) */
interface DaSelectorKeyModel extends DaSelectorModel {
  /** キー項目(連動フィルター用) */
  key: string
}
/** ドロップダウンリスト(ツリー) */
interface DaSelectorTreeModel<T extends DaSelectorModel> extends DaSelectorModel {
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
