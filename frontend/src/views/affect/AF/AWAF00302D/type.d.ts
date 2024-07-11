/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: お知らせ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.21
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分, Enum表示区分, Enum未読区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 名称区分(重要度) */
  kbn: Enum名称区分
}
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 表示区分 */
  showkbn: Enum表示区分
  /** 未読区分 */
  readkbn: Enum未読区分
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 新規お知らせリスト */
  addlist: InfoVM[]
  /** 更新お知らせリスト */
  updlist: UpdVM[]
  /** 排他チェック用リスト(編集用) */
  locklist: LockVM[]
  /** 排他チェック用リスト(既読用) */
  locklist2: LockVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** ドロップダウンリスト(重要度) */
  selectorlist: DaSelectorModel[]
  /** ユーザー一覧リスト(全て、ログインユーザーを除く) */
  userlist: UserVM[]
}
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** お知らせ情報 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** お知らせ情報モデル */
export interface InfoVM {
  /** 重要度 */
  juyodo: string
  /** 詳細 */
  syosai: string
  /** 提示期限 */
  kigenymd: Date | string
  /** 宛先指定フラグ */
  atesakiflg: boolean
  /** 宛先一覧(ユーザーID) */
  userlist: string[] | null
  /**ユニーク値 */
  key?: symbol
}
/** お知らせ情報(更新)モデル */
export interface UpdVM extends InfoVM {
  /** シーケンス番号 */
  infoseq: number
  /** 未読既読フラグ */
  readflg: boolean
}
/** お知らせ情報(検索)モデル */
export interface SearchVM extends UpdVM {
  /** 登録操作者名 */
  regusernm: string
  /** 登録日時 */
  regdttm: Date | string
  /** 更新日時 */
  upddttm: Date | string
  /** 編集フラグ */
  editflg: boolean
}
/** 排他チェック用モデル */
export interface LockVM {
  /** シーケンス番号 */
  infoseq: number
  /** 更新日時 */
  upddttm: Date | string
}
/** ユーザーモデル */
export interface UserVM {
  /** ユーザーID */
  userid: string
  /** ユーザー名 */
  usernm: string
}
