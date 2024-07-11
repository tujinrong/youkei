/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.14
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enumロール区分, Enum編集区分, Enumプログラム区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchListRequest extends CmSearchRequestBase {
  /** ユーザー */
  user?: string
  /** 所属グループ */
  syozoku?: string
  /** ロール区分 */
  rolekbn: Enumロール区分
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends SearchDetailRequest {
  /** ロールID */
  roleid: string
  /** ロール区分 */
  rolekbn: Enumロール区分
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 所属グループ */
  syozoku: string
}
/** 保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /** ロールID */
  roleid: string
  /** ロール区分 */
  rolekbn: Enumロール区分
  /** 編集区分 */
  editkbn: Enum編集区分
  /** ユーザー情報 */
  maininfo1: UserSaveVM | null
  /** 所属グループ情報 */
  maininfo2: SyozokuSaveVM | null
  /** 権限リスト(画面・共通バー) */
  authlist1: KinoSaveVM[]
  /** 帳票権限リスト */
  authlist2: ReportSaveVM[]
  /** 権限リスト(画面・共通バー)：排他用 */
  keylist1: KinoLockVM[]
  /** 帳票権限リスト：排他用 */
  keylist2: ReportLockVM[]
  /** ユーザーIDリスト(所属用：更新・排他) */
  keylist3: string[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(ユーザー) */
  selectorlist1: DaSelectorKeyModel[]
  /** ドロップダウンリスト(所属) */
  selectorlist2: DaSelectorModel[]
}
/** 検索処理 */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(ユーザー) */
  kekkalist1: UserRowVM[]
  /** 結果リスト(所属) */
  kekkalist2: SyozokuRowVM[]
}
/** 詳細画面ベース */
export interface SearchAuthResponse extends DaResponseBase {
  /** 画面機能権限リスト(所属) */
  kekkalist1: GamenVM[]
  /** 共通機能権限リスト(所属) */
  kekkalist2: CmBarVM[]
  /** 帳票権限リスト(所属) */
  kekkalist3: ReportVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends SearchAuthResponse {
  /** ユーザー情報 */
  maininfo1: UserInfoVM | null
  /** 所属グループ情報 */
  maininfo2: SyozokuInfoVM | null
  /** 画面機能権限リスト(ユーザー) */
  kekkalist4: GamenVM[] | null
  /** 共通機能権限リスト(ユーザー) */
  kekkalist5: CmBarVM[] | null
  /** 帳票権限リスト(ユーザー) */
  kekkalist6: ReportVM[] | null
  /** 支所一覧リスト(全て) */
  sisyolist: CmSisyoVM[]
  /** 個人番号操作権限付与フラグ(ログインユーザー) */
  pnoeditflg: boolean
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends SearchAuthResponse {
  /** 権限(所属) */
  authvm: RoleAuthBaseVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(ユーザー) */
export interface UserRowVM {
  /** ユーザーID */
  userid: string
  /** ユーザー名 */
  usernm: string
  /** 所属グループコード */
  syozokucd: string
  /** 所属グループ名 */
  syozokunm: string
  /** 有効年月日（開始） */
  yukoymdf: string
  /** 有効年月日（終了） */
  yukoymdt: string
  /** 状態 */
  status: string
}
/** 検索処理(所属) */
export interface SyozokuRowVM {
  /** 所属グループID */
  syozokucd: string
  /** 所属グループ名 */
  syozokunm: string
}
/** 機能権限キー(排他用) */
export interface KinoLockVM {
  /** 機能ID */
  kinoid: string
  /** 更新日時(排他用) */
  upddttm: string | null
}
/** 機能権限情報(保存用) */
export interface KinoSaveVM extends KinoLockVM {
  /** プログラム区分 */
  programkbn: Enumプログラム区分
  /** 追加権限フラグ */
  addflg: boolean | null
  /** 修正権限フラグ */
  updflg: boolean | null
  /** 削除権限フラグ */
  delflg: boolean | null
  /** 個人番号利用権限フラグ */
  personalnoflg: boolean | null
  /** 継承可能フラグ */
  keisyoflg: boolean | null
}
/** 機能権限情報(画面) */
export interface GamenVM extends KinoSaveVM {
  /** アクセス権限フラグ */
  viewflg: boolean
  /** 全て */
  allflg?: boolean | null
}
/** 機能権限情報(共通バー) */
export interface CmBarVM extends GamenVM {
  /** 機能名 */
  kinonm: string
}
/** 帳票権限キー(排他用) */
export interface ReportLockVM {
  /** 帳票グループID */
  repgroupid: string
  /** 更新日時(排他用) */
  upddttm: string | null
}
/** 帳票権限情報(保存用) */
export interface ReportSaveVM extends ReportLockVM {
  /** 通知書出力フラグ */
  tutisyooutflg: boolean | null
  /** PDF出力フラグ */
  pdfoutflg: boolean | null
  /** EXCEL出力フラグ */
  exceloutflg: boolean | null
  /** その他出力フラグ */
  othersflg: boolean | null
  /** 個人番号利用フラグ */
  personalnoflg: boolean | null
  /** 継承可能フラグ */
  keisyoflg: boolean | null
}
/** 帳票権限情報 */
export interface ReportVM extends ReportSaveVM {
  /** 帳票グループ名 */
  reportgroupnm: string
  /** アクセス権限 */
  viewflg: boolean
  /** 全て */
  allflg?: boolean | null
}
/** 権限情報ベース(ユーザー・所属　共通) */
export interface RoleAuthBaseVM {
  /** 管理者フラグ */
  kanrisyaflg: boolean
  /** 個人番号操作権限付与フラグ */
  pnoeditflg: boolean
  /** 警告参照フラグ */
  alertviewflg: boolean
  /** 更新可能支所一覧 */
  editsisyolist: CmSisyoVM[]
}
/** 権限情報ベース(ユーザー) */
export interface UserAuthBaseVM extends RoleAuthBaseVM {
  /** 管理者継承フラグ */
  kanrisyakeisyoflg: boolean
  /** 個人番号操作権限付与継承フラグ */
  pnoeditkeisyoflg: boolean
  /** 警告参照継承フラグ */
  alertviewkeisyoflg: boolean
  /** 部署（支所）別更新権限継承フラグ */
  authsisyokeisyoflg: boolean
}
/** ユーザー情報(表示用) */
export interface UserInfoVM extends UserAuthBaseVM {
  /** 所属グループ */
  syozoku: string
  /** 権限設定フラグ */
  authsetflg: boolean
  /** 使用停止フラグ */
  stopflg: boolean
  /** ユーザー名 */
  usernm: string
  /** 有効年月日（開始） */
  yukoymdf: string
  /** 有効年月日（終了） */
  yukoymdt: string
  /** ログインエラー回数 */
  errorkaisu: number
  /** 登録支所 */
  regsisyolist: CmSisyoVM[]
  /** 更新日時(排他用) */
  upddttm: string | null
}
/** ユーザー情報(保存用) */
export interface UserSaveVM extends UserInfoVM {
  /** 新パスワード */
  pword: string
}
/** 所属グループ情報(保存用) */
export interface SyozokuSaveVM extends RoleAuthBaseVM {
  /** 所属グループ名 */
  syozokunm: string
  /** 使用停止フラグ */
  stopflg: boolean
  /** ユーザーリスト(該当所属) */
  userlist1: UserRowVM[]
  /** 更新日時(排他用) */
  upddttm: string | null
}
/** 所属グループ情報(表示用) */
export interface SyozokuInfoVM extends SyozokuSaveVM {
  /** ユーザーリスト(全ユーザー) */
  userlist2: UserDetailVM[]
}
/** ユーザー一覧情報(選択用) */
export interface UserDetailVM extends UserRowVM {
  /** 編集フラグ */
  editflg: boolean
}
