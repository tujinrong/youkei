/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 帳票管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import {
  Enum様式種別,
  Enum様式作成方法,
  Enum帳票様式,
  Enum様式種別詳細,
  Enumコントロール,
  Enum内外区分,
  Enumページサイズ,
  Enum並び替え,
  Enum出力項目区分,
  Enum集計区分,
  Enum集計方法,
  Enum小計区分,
  Enum編集区分
} from '#/Enums'
import { MasterVM } from '../AWEU00205D/type'
import { SortSubVM } from '../AWEU00306D/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 業務コード */
  gyoumucd?: string
  /** 帳票グループID */
  rptgroupid?: string
  /** 帳票名 */
  rptnm?: string
  /** 様式名 */
  yosikinm?: string
  /** 様式分類 */
  yoshikibunrui?: string
  /** 様式種別 */
  yosikisyubetu?: string
}
/** 初期化処理(詳細画面：共通部分) */
export interface InitDetailRequest extends DaRequestBase {
  /** 帳票ID */
  rptid: string
  /** 様式ID */
  yosikiid?: string
  /** 様式作成方法 */
  yosikihouhou?: Enum様式作成方法
  /** データソースID */
  datasourceid?: string
  /** プロシージャ名称 */
  procnm?: string
  /** 帳票様式 */
  kbn: Enum帳票様式
  /** 編集区分 */
  editkbn: Enum編集区分
}

/** 帳票キー共有リクエスト */
export interface YosikiRequestTabBase extends DaRequestBase {
  /** 帳票ID */
  rptid: string
  /** 様式ID */
  yosikiid: string
  /** 様式枝番 */
  yosikieda?: number
  /** データソースID */
  datasourceid?: string
}
/** 帳票様式共通 */
export interface YosikiCommonRequest extends YosikiRequestTabBase {
  /** プロシージャ名称 */
  procnm?: string
  /** SQL */
  sql?: string
  /** 帳票様式 */
  kbn: Enum帳票様式
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 様式作成方法 */
  yosikihouhou?: Enum様式作成方法
}

/** SQL解析(様式設定タブ) */
export interface ParseAndFormatSqlRequest extends DaRequestBase {
  /** SQL */
  sql: string
  /**様式項目リスト */
  itemlist: ReportItemDetailVM[]
  /**検索条件リスト */
  conditionlist: SearchConditionVM[]
}

/** 検索条件 */
export interface CheckDataTypeRequestBase extends DaRequestBase {
  /** データタイプ */
  datatype?: number
  /** 種類 */
  controlkbn?: Enumコントロール
  /** 初期値 */
  syokiti?: string
  /** SQLカラム */
  sqlcolumn?: string
}
/** 検索条件以外 */
export interface InitSpecialConditionsRequest extends DaRequestBase {
  /** データソース */
  isDataSource: boolean
}
/** 検索処理(条件追加) */
export interface SearchConditionDetailRequest extends DaRequestBase {
  /** 条件シーケンス */
  jyokenseq: number
}
/** 検索処理(条件追加) */
export interface SearchJokenDetailRequest extends DaRequestBase {
  /** コントロール区分*/
  controlkbn?: number
  /** 名称マスタコード */
  mastercd?: string
  /** 名称マスタパラメータ */
  masterpara?: string
  /** 年度範囲区分 */
  nendohanikbn?: string
}

/**  プロシージャの解析(様式設定タブ) */
export interface ParseAndFormatProcedureRequest extends DaRequestBase {
  /** SQL */
  sql: string
  /**様式項目リスト */
  itemlist: ReportItemDetailVM[]
  /**検索条件リスト */
  conditionlist: SearchConditionVM[]
  /**帳票プロシージャ名 */
  mainprocedurenm?: string
  /** 帳票様式 */
  kbn: Enum帳票様式
  /**様式プロシージャ名 */
  procedurenm?: string
  /** 帳票ID */
  rptid: string
}

/** 初期化処理(項目定義タブ) */
export interface InitItemsTabRequest extends DaRequestBase {
  /** 様式種別 */
  yosikisyubetu: Enum様式種別
  /** 様式作成方法 */
  yosikihouhou: Enum様式作成方法
  /** データソースID */
  datasourceid?: string
}

/** 検索処理(Excelマッピング) */
export interface SearchExcelMappingTabRequest extends DaRequestBase {
  /** 帳票ID */
  rptid: string
  /** 様式ID */
  yosikiid: string
  /** 様式枝番 */
  yosikieda?: number
  /** 様式種別詳細 */
  yosikikbn: Enum様式種別詳細
  /** 明細有無 */
  meisaiflg: boolean
  /** 行（列）固定区分 */
  meisaikoteikbn?: string
  /** excelStatus */
  excelStatus: boolean
}
/** 初期化処理(特殊項目)(Excelマッピングタブ) */
export interface InitSpecialItemsRequest extends DaRequestBase {
  /** 台帳 */
  isPageReport: boolean
  /** クロス集計 */
  IsCross: boolean
  /** データソース */
  isDataSource: boolean
  /** 内外区分 */
  naigaikbn: Enum内外区分
}
/** エクセルテンプレートファイルのダウンロード処理 */
export interface DownloadExcelTemplateRequest extends CmUploadRequestBase {
  /**全シートのセル */
  celldatas: CellVM[][]
}

/** 保存処理(画面全件情報) */
export interface SaveProjectRequest extends CmUploadRequestBase {
  /** 帳票ID */
  rptid: string
  /** 帳票名 */
  rptnm: string
  /** 様式ID */
  yosikiid: string
  /** 様式枝番 */
  yosikieda: number
  /** 様式名 */
  yosikinm: string
  /** 帳票様式 */
  kbn: Enum帳票様式
  /** 更新識別 */
  updflag: boolean
  /** 更新日時 */
  upddttm?: Date | string
  /** 様式作成方法 */
  yosikihouhou: Enum様式作成方法
  /** 帳票データソースID */
  datasourceid?: string
  /** SQL */
  sql?: string
  /** プロシージャ名 */
  procnm?: string
  /** 帳票情報 */
  rptDetailParam: ReportTabInfoVM
  /** 様式情報索 */
  styleDetailParam: YosikiTabInfoVM
  /** 項目定義リスト */
  definitionValue: ReportItemDetailVM[]
  /** 検索条件ー画面 */
  rptConditionList: SearchConditionVM[]
  /** Excelマッピング */
  excelData: ExcelMappingVM[]
  /** チェックフラグ */
  checkflg: boolean
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(業務) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(帳票グループ) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(帳票様式) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(様式種別) */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 検索結果リスト */
  kekkalist: SearchVM[]
}
/** 様式枝番取得(詳細画面：新規・共通部分) */
export interface InitDetailResponse extends DaResponseBase {
  /** 様式ID */
  yosikiid?: string
  /** 様式枝番 */
  yosikieda?: number
  /** 様式作成方法 */
  yosikihouhou: Enum様式作成方法
  /** 帳票データソースID */
  datasourceid?: string
  /** 帳票データソース名称 */
  datasourcenm?: string
  /** プロシージャ名 */
  procnm?: string
  /** プロシージャ文 */
  sql: string
  /** ドロップダウンリスト(内外区分) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(利用目的) */
  selectorlist4: DaSelectorModel[]
  /** 問い合わせ先設定リスト */
  settinglist: DaSelectorModel[]
  /** 課コード */
  kacdList: DaSelectorModel[]
  /** 係コード */
  kakaricdList: DaSelectorModel[]
  /** 様式紐付名のドロップダウンリスト */
  selectorlist: DaSelectorModel[]
  /** 様式紐付け値のドロップダウンリスト */
  himozukevalueList: SearchConditionVM[]
  /** パラメータリスト */
  parameterList: string[]
}
/** 検索処理(帳票設定タブ) */
export interface SearchReportTabResponse extends DaResponseBase {
  /** 帳票設定タブ情報 */
  rptDetailParam: ReportTabInfoVM
  /** 固定条件 */
  jyokenLabellist: DaSelectorModel[]
  /** 更新日時 */
  upddttm?: Date | string
}
/** 検索処理(様式設定タブ) */
export interface SearchYosikiTabResponse extends DaResponseBase {
  /** 帳票設定タブ情報 */
  styleDetailParam: YosikiTabInfoVM
}

/** SELECT文の解析 */
export interface ParseAndFormatSqlResponse extends DaResponseBase {
  /** SQL */
  sql: string
  /** 様式項目リスト */
  itemlist: ReportItemDetailVM[]
  /** 検索条件リスト */
  conditionlist: SearchConditionVM[]
}
/** プロシージャの解析 */
export interface ParseAndFormatProcedureResponse extends DaResponseBase {
  /** SQL */
  sql: string
  /** 様式項目リスト */
  itemlist: ReportItemDetailVM[]
  /** 検索条件リスト */
  conditionlist: SearchConditionVM[]
  /** プロシージャ名 */
  procedurenm: string
}

/** 初期化処理/検索処理(項目定義タブ) */
export interface InitItemsTabResponse extends DaResponseBase {
  /** 帳票項目リスト */
  reportitemlist: ReportItemDetailVM[]
}

/** 初期化処理（検索条件タブ） */
export interface InitConditionTabResponse extends DaResponseBase {
  /** DataTypeドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** コントロールドロップダウンリスト */
  selectorlist2: DaSelectorModel[]
  /** マスタリスト */
  masterlist: MasterVM[]
}
/** 初期化処理(検索条件以外タブ) */
export interface InitSpecialConditionsResponse extends DaResponseBase {
  /** 普通全て検索条件リスト */
  labels: string[]
  /** 検索条件以外リスト */
  specialConditions: SearchConditionVM[]
}

/** 検索処理（検索条件タブ） */
export interface SearchConditionTabResponse extends DaResponseBase {
  /** 普通全て検索条件リスト */
  itemlist: SearchConditionVM[]
  /** 普通条件の選択したリスト */
  selectedjokenlist: SelectedSearchConditionVM[]
  /** プロシージャの検索条件の選択したリスト(含む条件追加) */
  selectedProcedjoklist: SearchConditionVM[]
  /** 検索条件以外の選択したリスト */
  selectedjokenOtherlist: SearchConditionVM[]
  /** データソースの検索条件-条件追加リスト */
  conditionAddlist: SearchConditionVM[]
}

/**  検索処理(条件追加)（検索条件タブ） */
export interface SearchConditionDetailResponse extends DaResponseBase {
  /**検索条件情報 */
  eurptkensaku: SearchConditionVM
}

/**  初期化処理(特殊項目)(Excelマッピングタブ) */
export interface InitSpecialItemsResponse extends DaResponseBase {
  /** 特殊項目リスト */
  specialitemlist: string[]
}

/**   検索処理(Excelマッピングタブ) */
export interface SearchExcelMappingTabResponse extends DaResponseBase {
  /** Excelマッピング情報 */
  excelmappingdata: ExcelMappingVM
}

/** 条件追加のドロップダウンリストを取得 */
export interface SearchJokenResponse extends DaResponseBase {
  /** 選択リスト */
  selectlist: DaSelectorModel[]
  /** 初期表示年度 */
  nendo: string
  /** リストCount  */
  masterCount: number
  /** 最大年度 */
  nendomax: string
}

// /** 帳票項目検索 */
// export interface SearchItemsResponse extends DaResponseBase {
//   /** 帳票項目リスト */
//   reportitemlist: ReportItemVM[]
// }

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 一覧検索明細情報 */
export interface SearchVM {
  /** 業務 */
  gyoumu: string
  /** 帳票グループ名 */
  rptgroupnm: string
  /** 帳票ID */
  rptid: string
  /** 帳票名 */
  rptnm: string
  /** 様式id-枝番 */
  yosikiideda: string
  /** 様式名-サブ様式名 */
  yosikidenm: string
  /** 様式ID */
  yosikiid: string
  /** 様式枝番 */
  yosikieda: number
  /** 様式名 */
  yosikinm: string
  /** 様式分類 */
  kbn: string
  /** 様式種別 */
  yosikisyubetu: string
  /** 様式種別詳細 */
  yosikikbn: string
  /** データソース名称 */
  datasourcenm: string
}
/** 帳票設定タブ情報 */
export interface ReportTabInfoVM {
  /** 帳票グループ名 */
  rptgroupnm: string
  /** 帳票グループID */
  rptgroupid: string
  /** 業務 */
  gyoumu: string
  /** 帳票説明 */
  rptbiko: string
  /** 宛名フラグ */
  atenaflg: boolean
  /** 妊産婦フラグ */
  ninsanpuflg: boolean
  /** アドレスシールフラグ固定様式 */
  addresssealflg: boolean
  /** バーコードシール固定様式 */
  barcodesealflg: boolean
  /** はがき固定様式 */
  hagakiflg: boolean
  /** 宛名台帳  */
  atenadaityoflg: boolean
  /** 件数表(年齢別)固定様式 */
  kensuhyonenreiflg: boolean
  /** 件数表(行政区別)固定様式 */
  kensuhyogyoseikuflg: boolean
  /** 様式紐付け名 */
  yosikihimonm?: string
  /** 選択固定条件 */
  jyokenLabels: SearchConditionVM[]
  /** 抽出パネル表示フラグ */
  tyusyutupanelflg: boolean
  /** 並びシーケンス */
  orderseq?: number
}
/** 様式設定タブ情報 */
export interface YosikiTabInfoVM {
  /** 様式種別 */
  yosikisyubetu: Enum様式種別
  /** 行（列）固定区分 */
  meisaikoteikbn: string
  /** 明細有無 */
  meisaiflg: boolean
  /** 様式種別詳細 */
  yosikikbn: Enum様式種別詳細
  /** 様式作成方法 */
  yosikihouhou: Enum様式作成方法
  /** 帳票発行履歴管理区分 */
  hakokbn: string
  /** 帳票発行履歴管理フラグ */
  hakoflg?: boolean
  /** 重複データ排除フラグ */
  distinctflg: boolean
  /** 空白値ゼロ出力フラグ */
  nulltozeroflg?: boolean
  /** PDF */
  pdfflg?: boolean
  /** EXCEL */
  excelflg?: boolean
  /** other */
  otherflg?: boolean
  /** 出力順パターン */
  sortptnno?: number
  /** 更新フラグ */
  updateflg?: boolean
  /** 更新SQL */
  updatesql: string
  /** 内外区分 */
  naigaikbn: Enum内外区分
  /** 市区町村印字 */
  koinnmflg: boolean
  /** 電子更新印字公印 */
  koinpicflg: boolean
  /** 職務代理者適用 */
  dairisyaflg: boolean
  /** 問い合わせ */
  toiawasesakicd: string
  /** 問い合わせ内容 */
  hanyocd: string
  /** 様式紐付け条件ID */
  himozukejyokenid?: number
  /** 様式紐付け値 */
  himozukevalue?: string
  /** 課コード */
  kacd?: string
  /** 係コード */
  kakaricd?: string
  /** 業務画面使用フラグ */
  gyomuflg?: boolean
  /** 通知書出力フラグ */
  tutisyoflg?: boolean
  /** 様式更新日時 */
  yosikiUpddttm?: Date | string
  /** 様式詳細更新日時 */
  yosikisyosaiUpddttm?: Date | string
  /** 並びシーケンス */
  orderseq?: number
}
/** 項目定義明細情報 */
export interface ReportItemDetailVM {
  /** 様式項目ID */
  yosikiitemid: string
  /** 帳票項目名称 */
  reportitemnm: string
  /** CSV項目名称 */
  csvitemnm: string
  /** SQLカラム */
  sqlcolumn: string
  /** テーブル別名 */
  tablealias: string
  /** 並び替え */
  orderkbn: Enum並び替え
  /** 並び替えシーケンス */
  orderkbnseq?: number
  /** 並びシーケンス */
  orderseq?: number
  /** 帳票出力フラグ */
  reportoutputflg: boolean
  /** CSV出力フラグ */
  csvoutputflg: boolean
  /** ヘッダーフラグ */
  headerflg: boolean
  /** 改ページフラグ */
  kaipageflg: boolean
  /** 項目区分 */
  itemkbn: Enum出力項目区分
  /** フォーマット区分 */
  formatkbn?: string
  /** フォーマット区分2 */
  formatkbn2?: string
  /** フォーマット詳細 */
  formatsyosai?: string
  /** 高 */
  height?: number
  /** 幅 */
  width?: number
  /** X軸オフセット */
  offsetx?: number
  /** Y軸オフセット */
  offsety?: number
  /** 白紙表示 */
  blankvalue?: string
  /** 名称マスタコード */
  mastercd?: string
  /** 名称マスタパラメータ */
  masterpara?: string
  /** 複数のキー・値・ペアjson */
  keyvaluepairsjson?: string
  /** 集計区分 */
  crosskbn?: Enum集計区分
  /** 集計方法 */
  syukeihoho?: Enum集計方法
  /** 小計区分 */
  kbn1?: Enum小計区分
  /** 集計レベル */
  level?: number
  /** 大分類 */
  daibunrui?: string
}
/** 並び替え設定(項目定義タブ) */
export interface SortLineParam extends DaRequestBase {
  /** 出力順パターン */
  sortptnno: number
  /** 出力順の項目詳細リスト */
  sortsublist: SortSubVM[]
}
/** 選択検索条件情報 */
export interface SelectedSearchConditionVM {
  /** 条件ID */
  jyokenid: number
  /** データソースID */
  datasourceid: string
  /** 必須フラグ */
  hissuflg: boolean
  /** ラベル */
  jyokenlabel: string
  /** 並び順シーケンス */
  orderseq: number
}
/** 検索条件情報 */
export interface SearchConditionVM extends SelectedSearchConditionVM {
  /** 検索条件区分 */
  jyokenkbn: string
  /** ラベル */
  jyokenlabel: string
  /** テーブルID */
  tableid: string
  /** 変数名 */
  variables?: string
  /** 大分類 */
  daibunrui: string
  /** 項目ID */
  itemid: string
  /** 項目物理名 */
  itemnm: string
  /** 項目名 */
  label: string
  /** 種類 */
  controlkbn: Enumコントロール
  /** 入力値 */
  value?: string
  /** SQL */
  sql?: string
  /** テーブル名 */
  tablealias: string
  /** 名称マスタコード */
  mastercd?: string
  /** 名称マスタパラメータ */
  masterpara?: string
  /** 参照元SQL */
  sansyomotosql?: string
  /** データ型 */
  datatype?: number
  /** 年度範囲区分 */
  nendohanikbn: string
  /** 初期値 */
  syokiti?: string
  /** 初期表示年度 */
  nendo: string
  /** 最大年度 */
  nendomax?: string
  /** 条件シーケンス */
  jyokenseq: number
  /** SQLカラム */
  sqlcolumn: string
  /** 並び順シーケンス */
  orderseq: number
  /** 選択リスト */
  selectlist?: DaSelectorModel[]
  /** 曖昧検索区分 */
  aimaikbn?: string
}
/** Excelマッピング情報 */
export interface ExcelMappingVM extends DaResponseBase {
  /** テンプレートファイル名 */
  templatefilenm: string
  /** テンプレートファイル */
  templatefiledata: string
  /** テンプレート終了行 */
  endrow: number
  /** テンプレート終了列 */
  endcol: number
  /** ページサイズ */
  pagesize: Enumページサイズ
  /** 出力方向 */
  landscape: boolean
  /** 行明細フラグ */
  rowdetailflg: boolean
  /** テンプレート明細開始行 */
  startrow?: number
  /** １ページあたりの最大行数 */
  loopmaxrow?: number
  /** 1明細あたりの行数 */
  looprow?: number
  /** 列明細フラグ */
  coldetailflg: boolean
  /** 明細開始列数 */
  startcol?: number
  /** １ページあたりの最大列数 */
  loopmaxcol?: number
  /** 1明細あたりの列数 */
  loopcol?: number
  /** 全シートのセル */
  celldatas: CellVM[][]
}
/** 検索条件 */
export interface CellVM {
  /** 行インデックス */
  rowindex: number
  /** 列インデックス */
  columnindex: number
  /** 値 */
  value?: object
}
/** 初期化関数リスト */
export interface ProcedureVM {
  /** 関数名 */
  name: string
  /** 関数のソース */
  src: string
  /** 関数説明 */
  description: string
}

/** 初期化関数リスト */
export interface SubYosikiDataVM {
  /** 様式紐付け値 */
  himozukevalue?: string
  /** 帳票発行履歴更新フラグ */
  hakoflg: boolean
  /** PDF 出力形式 */
  pdfflg: boolean
  /** EXCEL 出力形式 */
  excelflg: boolean
  /** other 出力形式 */
  otherflg: boolean
  /** 更新フラグ */
  updateflg?: boolean
  /** 更新SQL */
  updatesql: string
  /** 内外区分 */
  naigaikbn: Enum内外区分
}
