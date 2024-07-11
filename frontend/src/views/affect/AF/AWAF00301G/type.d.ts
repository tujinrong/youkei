/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ホーム
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.21
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分, Enum未読区分, Enum表示色区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 名称区分(処理区分) */
  kbn: Enum名称区分
}
/** 検索処理(お知らせ) */
export interface SearchInfoRequest extends DaRequestBase {
  /** 未読区分 */
  readkbn: Enum未読区分
}
/** ダウンロード処理 */
export interface DownloadRequest extends DaRequestBase {
  /** 外部連携ログシーケンス */
  gaibulogseq: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** システム年度 */
  nendo: number
  /** 宛名番号長さ */
  atenanolen: number
  /** 医療機関コード長さ */
  kikancdlen: number
  /** 処理区分一覧 */
  selectorlist: DaSelectorModel[]
  /** お知らせリスト */
  kekkalist1: InfoVM[]
  /** 外部連携処理結果履歴リスト */
  kekkalist2: GaibulogVM[]
}
/** 検索処理(お知らせ) */
export interface SearchInfoResponse extends DaResponseBase {
  /** お知らせリスト */
  kekkalist: InfoVM[]
}
/** 検索処理(連携処理) */
export interface SearchLogResponse extends DaResponseBase {
  /** 外部連携処理結果履歴リスト */
  kekkalist: GaibulogVM[]
}
/** メニュー取得処理 */
export interface GetMenuResponse extends DaResponseBase {
  /** メニューリスト */
  menulist: MenuModel[]
  /** プログラムリスト */
  programlist: ProgramModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** お知らせ */
export interface InfoVM {
  /** お知らせシーケンス */
  infoseq: number
  /** 重要度 */
  juyodo: string
  /** 既読未読フラグ */
  readflg: boolean
  /** 登録日時 */
  regdttm: Date | string
  /** 詳細 */
  syosai: string
}
/** 外部連携処理結果履歴 */
export interface GaibulogVM {
  /** 外部連携ログシーケンス */
  gaibulogseq: number
  /** 処理日時（開始） */
  syoridttmf: Date | string
  /** 処理日時（終了） */
  syoridttmt: Date | string
  /** 処理区分 */
  syorikbn: string
  /** 操作者名 */
  usernm: string
  /** 処理内容 */
  syorinm: string
  /** 処理結果 */
  status: string
  /** 処理結果表示色区分 */
  colorkbn: Enum表示色区分
  /** ファイル存在フラグ */
  fileflg: boolean
}
