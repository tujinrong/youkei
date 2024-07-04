/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  サービス処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 業務CD */
  gyoumucd?: number
}
/**  */
export interface ReportRequest extends CmUploadRequestBase {
  /** 帳票ID */
  ReportID?: number
  /** 帳票名 */
  ReportName: string
  /** 出力方式(PDF,EXCEL,プレビュー) */
  OutputType: number
  /** 白紙出力 */
  IsBlank?: boolean
  /** 条件シート出力 */
  OutputConditionSheet?: boolean
  /** 件数表 */
  OutputCountList?: boolean
  /** 検索条件(画面) */
  condition: Condition[]
  /** 様式 */
  style: string
  /** メモ */
  memo: string
}

/** 初期化処理 */
export interface DetailInitRequst extends DaRequestBase {
  rptid: number
  groupid: number
}

/** 検索処理 */
export interface DetailSearchRequst extends CmSearchRequestBase {
  ReportSearchRequestVM: ReportSearchRequestVM
}

/** 検索処理(取込設定一覧画面) */
export interface SearchKimpListRequest extends CmSearchRequestBase {
  /** 業務区分 */
  gyoumukbn: string
  /** 一括取込入力区分 */
  impkbn?: string
  /** 一括取込入力名 */
  impnm: string
}

/** 共通処理(取込（一括入力）編集画面) */
export interface DeleteKimpListRequest extends DaRequestBase {
  /** 排他キーリスト */
  lockList: LockVM[]
}

/** 初期化処理(取込（一括入力）編集画面) */
export interface InitDetailRequest extends CmSearchRequestBase {
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 取込実行ID */
  impexeid: number
  /** 一括取込入力No */
  impno: string
  /* 年度 */
  nendo: string
  rowNo: number
}

/** 初期化処理(取込（一括入力）編集画面) */
export interface DetailRequest extends ProcessTimerRequest {
  /** 画面項目一覧画面 */
  detailList: KimpDetailRowVM[]
  /** 取込実行ID */
  impexeid: number
  /** 一括取込入力No */
  impno: string
  /** 更新日時 */
  upddttm?: Date
  /** 編集区分 */
  editkbn: Enum編集区分
  /* 年度 */
  nendo: string
}

/** 初期化処理(取込（一括入力）編集画面) */
export interface DeleteDetailRequest extends DaRequestBase {
  /** データID */
  impexeid: number
  rownoList: number[]
  /** 更新日時 */
  upddttm: Date
}

/** 参照元項目入力後参照先項目の値を取得処理(取込（一括入力）編集画面) */
export interface GetTargetItemValueRequest extends DaRequestBase {
  /** 一括取込入力No */
  impno: string
  /** 項目値 */
  val: string
  /** 参照先項目ID(複数? ,) */
  pageitemseq: number
}

/** 項目特定処理(取込（一括入力）編集画面) */
export interface DoSpecialPageItemRequest extends DaRequestBase {
  /** 一括取込入力No */
  impno: string
  /** 参照先項目ID(複数? ,) */
  pageitemseq: number
  /* 明細行データ */
  detailRowVM: KimpDetailRowVM
}

/** 関数値を取得処理 (取込（一括入力）編集画面) */
export interface DoKansuRequest extends DaRequestBase {
  /** 一括取込入力No */
  impno: string
  /** 入力方法 */
  inputhoho: string
  /** 画面項目ID */
  pageitemseq: number
  /* 明細行データ */
  detailRowVM: KimpDetailRowVM
}

/** 初期化処理 */
export interface DetailInitResponse extends DaResponseBase {
  initSearch: ReportInitResponseVM
  /** 出力様式 */
  prttype: DaSelectorModel[]
  /** 実行モード */
  exec_model: DaSelectorModel[]
}

/** 検索処理 */
export interface DetailSearchResponse extends CmSearchResponseBase {
  searchVM: ReportDetailSearchResponseVM
}

/** 初期化処理 */
export interface HistoryInitRequest extends DaRequestBase {
  /** 帳票ID */
  rptid?: number
}
/** 取込履歴ファイルダウンロード処理(取込履歴一覧画面) */
export interface KimpHistoryFileDownRequest extends DaRequestBase {
  /** 履歴番号 */
  rirekiid: number
}

/** 取込実行のプログレスバー */
export interface ProcessTimerRequest extends DaRequestBase {
  /** 処理キー */
  processKey: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  gyoumucds: DaSelectorModel[]
  rptgroups: DaSelectorModel[]
}
/** confirm response */
export interface ReportResponse extends DaResponseBase {
  data: any
}
/** 再度検索処理 */
export interface ReSearchResponse extends CmSearchResponseBase {
  searchVM: ReportDetailSearchResponseVM[]
}

/** 初期化処理 */
export interface HistoryInitResponse extends CmSearchResponseBase {
  /** 帳票出力履歴 */
  reportrecords: ReportRecordVM[]
}

/** 初期化処理(取込設定一覧画面) */
export interface InitKimpListResponse extends DaResponseBase {
  /**業務区分 */
  gyoumukbn: string
  /**一括取込入力区分 */
  impkbn: string
}

/** 初期化処理(取込設定一覧画面) */
export interface SearchKimpListResponse extends CmSearchResponseBase {
  /**汎用取込設定情報リスト */
  kimpList: KimpRowVM[]
  /** 排他キーリスト */
  lockList: LockVM[]
}

/** 初期検索処理(未処理一覧画面) */
export interface SearchKimpDataListResponse extends CmSearchResponseBase {
  /**取込データ情報リスト */
  kimpDataList: KimpDataRowVM[]
}

/** 初期検索処理(取込履歴一覧画面) */
export interface SearchKimpHistoryListResponse extends CmSearchResponseBase {
  /**取込履歴情報リスト */
  kimpHistoryList: KimpHistoryRowVM[]
}

/** チェック処理(取込（一括入力）編集画面) */
export interface CheckInfoResponse extends SaveWorkResponse {
  /** 正常件数 */
  normalCnt: number
  /** 情報件数 */
  infoCnt: number
  /** 警告件数 */
  warnCnt: number
  /** エラー件数 */
  errCnt: number
}

/** 仮保存処理(取込（一括入力）編集画面) */
export interface SaveWorkResponse extends DaResponseBase {
  /** 取込実行ID */
  impexeid: number
  /** 更新日時 */
  upddttm: Date
}

/** 初期化処理(取込（一括入力）編集画面) */
export interface InitDetailResponse extends CmSearchResponseBase {
  /** 一括取込入力区分 */
  impkbn: string
  /** 一括取込入力名 */
  impnm: string
  /** 業務区分名称 */
  gyoumukbnnm: string
  /** 年度表示フラグ */
  yeardispflg: boolean
  /** 画面項目ヘッダーデータリスト */
  pageItemHeaderList: PageItemHeaderModel[]
  /** 画面項目明細データリスト */
  detailList: KimpDetailRowVM[]
  /** 画面項目の入力区分がコード変換時用システムコードデータ */
  cdchangeSelectorDic: any
  cdchangeOldSelectorDic: any
  selectorDic: any
  /** 取込実行ID */
  impexeid: number
  /** 正常件数 */
  normalCnt: number
  /** 情報件数 */
  infoCnt: number
  /** 警告件数 */
  warnCnt: number
  /** エラー件数 */
  errCnt: number
  /** 更新日時 */
  upddttm?: Date
  /** 最大行数 */
  rownoMax: number
  /** ページNo. */
  pagenum: number
  /** 初期表示年度 */
  nendo?: string
  /** 最大年度 */
  nendomax?: string
}

/** 参照元項目入力後参照先項目の値を取得処理(取込（一括入力）編集画面) */
export interface GetTargetItemValueResponse extends DaResponseBase {
  /** 参照先項目の値リスト */
  targetItemValueList: PageItemBodyModel[]
}

/** 項目特定処理(取込（一括入力）編集画面) */
export interface DoSpecialPageItemResponse extends DaResponseBase {
  /** 参照先項目の値リスト */
  targetItemValueList: PageItemBodyModel[]
}

/** 取込実行のプログレスバー */
export interface ProcessTimerResponse extends DaResponseBase {
  processnm: string
  value: number
}

/** 関数値を取得処理(取込（一括入力）編集画面) */
export interface DoKansuResponse extends DaResponseBase {
  kansuValueList: any[][]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface DetailSearchVM {
  /** 取込方法 */
  method?: string
  /** 開始行指定 */
  startLine?: string
  /** 終了行指定 */
  endLine?: string
  /** 年度 */
  year?: string
  /** 医療機関 */
  medichine?: string
  /** 会場 */
  place?: string
}

/** 一覧 */
export interface ReportVM {}

/** 帳票出力 init Response */
export interface ReportInitResponseVM {
  /** list of table fields */
  tableItems: tableItem[]
  /** list of table field contents */
  tableitemcontents: tableitemcontents[]
}

/** 帳票出力検索 Request */
export interface ReportSearchRequestVM {
  /** list of table fields */
  tableItems: DaSelectorModel[]
  /** 帳票ID */
  rptid?: number
  /** 出力様式 */
  prttype?: string
  /** 実行モード */
  exec_model?: string
  /** 検索条件メモ */
  searchcondmemo?: string
}

/** 帳票出力再度検索 Request */
export interface ReportReSearchRequestVM {
  /** list of table fields */
  tableItems: tableItem[]
  /** list of table field contents */
  tableitemcontents: tableitemcontents[]
}

/** 帳票出力再度検索 Response */
export interface ReportDetailSearchResponseVM {
  /** columns of table */
  columns: Column[]
  /** list data of table */
  tableitems: tableItems[]
}

/** table fields */
export interface tableItem {
  /** table name */
  table: DaSelectorModel
  /** table field name */
  tableitem: DaSelectorModel
  /** fieldtype */
  itemtype: DaSelectorModel
  /** fieldtype */
  sql: DaSelectorModel
  /** fieldtype */
  tableid: DaSelectorModel
  /** 入力値 */
  inputValue: string | number
}

/** table item contents */
export interface tableitemcontents {
  /** itemname */
  itemname: string
  /** table field contents */
  itemcontents: DaSelectorModel[]
}
/** 帳票出力履歴 */
export interface ReportRecordVM {
  /** 登錄日時 */
  registration_date: string
  /** 登錄者 */
  registrant: string
  /** 实行狀態 */
  exec_state: string
  /** 实行日時 */
  exec_date: string
  /** 出力方式 */
  output_mode: string
  /** 總件數 */
  total_number: string
  /** 检索条件 */
  search_condition: string
  /** 检索条件メモ */
  search_condition_memo: string
}

/** 帳票出力条件 */
export interface Condition {
  /** 項目タイプ */
  itemtype: string | number
  /** 項目ラベル */
  label: string
  /** 項目値 */
  value: string | number
  /** SQL */
  sql: string
  /** 項目所属テーブルID */
  tableid: string
}

export interface Column {
  /** タイトル */
  title: string
  /** キー */
  key: string
  /** タイプ */
  type: string
}

export interface tableItems {
  items: DaSelectorModel[]
}

/** 汎用取込設定情報モデル(取込設定一覧画面) */
export interface KimpRowVM {
  /** 一括取込入力No */
  impno: string
  /** 一括取込入力名 */
  impnm: string
  /** 一括取込入力区分 */
  impkbn: string
  /** 業務区分 */
  gyoumukbn: string
  /** 説明 */
  memo: string
}

/** 取込データ情報モデル(未処理一覧画面) */
export interface KimpDataRowVM {
  /** 取込実行ID */
  impexeid: number
  /** 一括取込入力No */
  impno: string
  /** 一括取込入力名 */
  impnm: string
  /** 業務区分 */
  gyoumukbn: string
  /**  */
  filename: string
  /** ファイル総行数 */
  filerowcnt: number
  /** 件数 */
  totalcnt: number
  /** エラー件数 */
  errcnt: number
  /** 更新ユーザーID(前回更新者) */
  upduserid: string
  /** 更新日時(前回更新時間) */
  upddttm: Date
  /** 更新日時(前回更新時間) */
  upddttmShow: string
}

/** 取込履歴情報モデル(取込履歴一覧画面) */
export interface KimpHistoryRowVM {
  /** 履歴番号 */
  rirekiid: number
  /** 登録日時(実行日時) */
  regdttm: string
  /** 登録ユーザーID(担当者) */
  reguserid: string
  /** 一括取込入力名 */
  impnm: string
  /** 一括取込入力区分 */
  impkbn: string
  /** 業務区分 */
  gyoumukbn: string
  /** ファイル名 */
  filename: string
  /** 登録件数(処理件数) */
  regcnt: number
  /** エラー件数 */
  errcnt: number
}

/** 画面項目一覧明細情報モデル(取込（一括入力）編集画面) */
export interface KimpDetailRowVM {
  /** 行番号 */
  rowno: number
  /** エラー内容 */
  errMsg: string
  /** 画面項目リスト */
  pageItemBodyList: PageItemBodyModel[]
}

/** 画面項目情報モデル(取込（一括入力）編集画面) */
export interface PageItemBodyModel {
  /** データID */
  dataseq: number
  /** 項目値 */
  val?: string
  /** 画面項目ID */
  pageitemseq: number | string
  errflg: boolean
  errkbn?: string
}

/** 画面項目定義情報モデル(取込（一括入力）編集画面) */
export interface PageItemHeaderModel {
  /** 画面項目ID */
  pageitemseq: number | string
  /** 項目名 */
  itemnm: string
  /** 入力区分 */
  inputkbn: string
  /** 入力方法 */
  inputtype?: string
  /** 引数 */
  hikisu?: string
  /** 桁数 */
  len: number
  /** 桁数（小数部） */
  len2?: number
  /** 幅 */
  width?: number
  /** フォーマット */
  format?: string
  /** 必須フラグ */
  requiredflg?: string
  /** 一意フラグ */
  uniqueflg?: boolean
  /** 表示入力設定区分 */
  dispinputkbn?: string
  /** 並び順 */
  sortno?: number
  /** 参照元項目ID */
  fromitemseq?: number
  /** 参照元フィールド */
  fromfieldid?: string
  /** 取得先フィールド */
  targetfieldid?: string
  /** 年度フラグ */
  nendoflg?: boolean
  /** 年度チェック */
  yearchkflg?: string
  /** 正規表現 */
  seiki?: string
  /** 最小値 */
  minval?: string
  /** 最大値 */
  maxval?: string
  /** 初期値 */
  defaultval?: string
  /** 固定値 */
  fixedval?: string
  /** マスタチェックテーブル */
  msttable?: string
  /** マスタチェック条件 */
  mstjyoken?: string
  /** マスタチェック項目 */
  mstfield?: string
  /** 条件必須エラーレベル区分 */
  jherrlelkbn?: string
  /** 条件必須項目ID */
  jhitemseq?: number
  /** 条件必須演算子 */
  jhenzan?: string
  /** 条件必須値 */
  jhval?: string
  /** 参照先項目ID(複数? ,) */
  targetitemseq?: string
  /** 項目特定区分 */
  itemkbn?: string
  /** 医療機関・事業従事者（担当者）事業コード(複数? ,) */
  jigyocd?: string
}
export interface Selector {
  code: string
  list: DaSelectorModel[]
}
export interface KeySelector {
  kbcd: number
  list: DaSelectorKeyModel[]
}

export interface CodeTrans {
  index: number
  pageitemseq: number | string
  val: string
  itemnm: string
  width?: number
  inputkbn: string
  inputtype?: string
  len: number
}

/** 排他チェック用モデル */
export interface LockVM {
  /** 取込実行ID */
  impexeid: string
  /** 更新日時 */
  upddttm: Date
}
