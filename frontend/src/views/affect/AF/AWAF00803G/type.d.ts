/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.11.13
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enumログ区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** ログ区分 */
  logkbn?: Enumログ区分
  /** 処理結果(コード：名称) */
  status?: string
  /** 処理日時（開始） */
  syoridttmf?: string
  /** 処理日時（終了） */
  syoridttmt?: string
  /** 機能(コード：名称) */
  service?: string
  /** 処理(コード：名称) */
  method?: string
  /** 操作者(コード：名称) */
  user?: string
  /** 宛名番号 */
  atenano?: string
  /** 個人番号 */
  personalno?: string
  /** 個人番号操作区分 */
  pnokbn: boolean
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /** ログシーケンス */
  sessionseq: number
}
/** 検索処理(詳細画面：共通) */
export interface SearchCommonRequest extends CmSearchRequestBase {
  /** ログシーケンス */
  sessionseq: number
}
/** 検索処理(詳細画面：項目値変更情報) */
export interface SearchColumnDetailRequest extends SearchCommonRequest {
  /** 変更テーブル */
  table?: string
  /** 変更項目 */
  item?: string
  /** 変更区分 */
  henkokbn?: string
}
/** CSV出力処理 */
export interface OutputRequest extends DaRequestBase {
  /** ログ区分 */
  logkbn?: Enumログ区分
  /** 処理結果(コード：名称) */
  status?: string
  /** 処理日時（開始） */
  syoridttmf?: string
  /** 処理日時（終了） */
  syoridttmt?: string
  /** 機能(コード：名称) */
  service?: string
  /** 処理(コード：名称) */
  method?: string
  /** 操作者(コード：名称) */
  user?: string
  /** 宛名番号 */
  atenano?: string
  /** 個人番号 */
  personalno?: string
  /** 個人番号操作区分 */
  pnokbn: boolean
  /** メインログフラグ */
  mainflg: boolean
  /** 通信ログフラグ */
  tusinflg: boolean
  /** バッチログフラグ */
  batchflg: boolean
  /** 連携ログフラグ */
  gaibuflg: boolean
  /** DB操作ログフラグ */
  dbflg: boolean
  /** 項目値変更フラグ */
  columnflg: boolean
  /** 宛名番号ログフラグ */
  atenaflg: boolean
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(ログ区分) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(処理結果) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(機能) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(処理) */
  selectorlist4: DaSelectorKeyModel[]
  /** ドロップダウンリスト(操作者) */
  selectorlist5: DaSelectorModel[]
  /** CSV出力フラグ */
  csvoutflg: boolean
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** ログ情報一覧 */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends CmSearchResponseBase {
  /** ログ基本情報 */
  headerinfo: HeaderVM
  /** 通信ログ操作状況 */
  existflg1: boolean
  /** バッチログ操作状況 */
  existflg2: boolean
  /** 外部連携ログ操作状況 */
  existflg3: boolean
  /** DB操作ログ操作状況 */
  existflg4: boolean
  /** 項目値変更ログ操作状況 */
  existflg5: boolean
  /** 宛名番号ログ操作状況 */
  existflg6: boolean
}
/** 初期化処理(項目値変更情報) */
export interface InitColumDetailResponse extends DaResponseBase {
  /** ドロップダウンリスト(変更テーブル) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(変更項目) */
  selectorlist2: DaSelectorKeyModel[]
  /** ドロップダウンリスト(変更区分) */
  selectorlist3: DaSelectorModel[]
}
/** 検索処理(通信ログ情報) */
export interface SearchTusinDetailResponse extends CmSearchResponseBase {
  /** 通信ログ情報一覧 */
  kekkalist: TusinRowVM[]
}
/** 検索処理(バッチログ情報) */
export interface SearchBatchDetailResponse extends CmSearchResponseBase {
  /** バッチログ情報一覧 */
  kekkalist: BatchRowVM[]
}
/** 検索処理(連携ログ情報) */
export interface SearchGaibuDetailResponse extends CmSearchResponseBase {
  /** 連携ログ情報一覧 */
  kekkalist: GaibuRowVM[]
}
/** 検索処理(DB操作ログ情報) */
export interface SearchDBDetailResponse extends CmSearchResponseBase {
  /** DB操作ログ情報一覧 */
  kekkalist: DBRowVM[]
}
/** 検索処理(項目値変更情報) */
export interface SearchColumnDetailResponse extends CmSearchResponseBase {
  /** 項目値変更情報一覧 */
  kekkalist: ColumnRowVM[]
}
/** 検索処理(宛名番号ログ情報) */
export interface SearchAtenaDetailResponse extends CmSearchResponseBase {
  /** 宛名番号ログ情報一覧 */
  kekkalist: AtenaRowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** メインログ情報(一覧画面) */
export interface RowVM {
  /** ログシーケンス */
  sessionseq: number
  /** 通信ログ操作状況 */
  existflg1: string
  /** バッチログ操作状況 */
  existflg2: string
  /** 外部連携ログ操作状況 */
  existflg3: string
  /** DB操作ログ操作状況 */
  existflg4: string
  /** 項目値変更ログ操作状況 */
  existflg5: string
  /** 宛名番号ログ操作状況 */
  existflg6: string
  /** 処理日時（開始） */
  syoridttmf: string
  /** 処理日時（終了） */
  syoridttmt: string
  /** 処理時間 */
  syoritime: string
  /** 機能ID */
  kinoid: string
  /** 機能名 */
  servicenm: string
  /** 処理名 */
  methodnm: string
  /** 操作者 */
  usernm: string
  /** 個人番号操作状況 */
  pnoflg: string
  /** メッセージ操作状況 */
  msgflg: string
  /** 処理結果(名称) */
  status: string
}
/** ヘッダー情報(詳細画面) */
export interface HeaderVM {
  /** 処理結果(名称) */
  status: string
  /** 処理日時（開始～終了） */
  syoridttm: string
  /** 処理時間 */
  syoritime: string
  /** 機能(名称) */
  servicenm: string
  /** 処理(名称) */
  methodnm: string
  /** 操作者(名称) */
  user: string
  /** 個人番号操作状況 */
  pnoflg: string
}
/** 通信ログ情報(詳細画面) */
export interface TusinRowVM {
  /** 通信ログシーケンス */
  tusinlogseq: number
  /** 操作者IP */
  ipadrs: string
  /** 操作者OS */
  os: string
  /** 操作者ブラウザー */
  browser: string
  /** 処理日時（開始～終了） */
  syoridttm: string
  /** リクエスト */
  request: string
  /** レスポンス */
  response: string
  /** メッセージ */
  msg: string
}
/** バッチログ情報(詳細画面) */
export interface BatchRowVM {
  /** バッチログシーケンス */
  batchlogseq: number
  /** 処理日時（開始～終了） */
  syoridttm: string
  /** パラメータ */
  pram: string
  /** メッセージ */
  msg: string
}
/** 連携ログ情報(詳細画面) */
export interface GaibuRowVM {
  /** 外部連携ログシーケンス */
  gaibulogseq: number
  /** 処理日時（開始～終了） */
  syoridttm: string
  /** 操作者IP */
  ipadrs: string
  /** 連携区分 */
  kbn: string
  /** 連携方式 */
  kbn2: string
  /** 処理区分 */
  kbn3: string
  /** API連携データ */
  apidata: string
  /** ファイル名 */
  filenm: string
  /** メッセージ */
  msg: string
}
/** DB操作ログ情報(詳細画面) */
export interface DBRowVM {
  /** DB操作ログシーケンス */
  dblogseq: number
  /** SQL */
  sql: string
}
/** 項目値変更情報(詳細画面) */
export interface ColumnRowVM {
  /** 項目値変更ログシーケンス */
  columnlogseq: number
  /** 変更テーブル */
  tablenm: string
  /** 変更区分 */
  henkokbn: string
  /** 主キー */
  keys: string
  /** 変更項目 */
  itemnm: string
  /** 変更前内容 */
  valuebefore: string
  /** 更新後内容 */
  valueafter: string
}
/** 宛名番号ログ情報(詳細画面) */
export interface AtenaRowVM {
  /** 宛名番号ログシーケンス */
  atenalogseq: number
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sex: string
  /** 生年月日 */
  bymd: string
  /** 住所 */
  adrs: string
  /** 行政区 */
  gyoseiku: string
  /** 住民区分 */
  juminkbn: string
  /** 個人番号操作状況 */
  pnoflg: string
  /** 操作区分 */
  usekbn: string
}
/** 宛名番号ログ情報(詳細画面) */
export interface CSVRowVM {
  /** ログシーケンス */
  sessionseq: number
  /** 通信ログフラグ */
  existflg1: boolean
  /** バッチログフラグ */
  existflg2: boolean
  /** 外部連携ログフラグ */
  existflg3: boolean
  /** DB操作ログフラグ */
  existflg4: boolean
  /** 項目値変更ログフラグ */
  existflg5: boolean
  /** 宛名番号ログフラグ */
  existflg6: boolean
}
