/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 業務区分 */
  gyoumukbn?: string
  /** 一括取込入力名 */
  impnm?: string
}
/** 共通処理(詳細画面) */
export interface DetailCommonRequest extends DaRequestBase {
  /** 一括取込入力No */
  impno?: string
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DetailCommonRequest {
  /** 編集区分 */
  editkbn: Enum編集区分
  /** アップロード処理フラグ */
  isUpload: boolean
  /** アップロードデータ */
  uploadData: UploadData
}
/** 削除処理(詳細画面) */
export interface DeleteDetailRequest extends DetailCommonRequest {
  /** 更新日時 */
  upddttm: Date
}
/** 変換コード情報：コード変換区分初期化処理(詳細画面) */
export interface InitCodeChangeRequest extends DetailCommonRequest {
  /** 業務区分 */
  gyoumukbn?: string
  /** 一括取込入力No */
  impno?: string
}

/**  変換コード情報：本システムコード初期化処理(詳細画面) */
export interface InitSystemCodeRequest extends InitCodeChangeRequest {
  /** 変換コードメイン情報 */
  changeCodeMainData: ChangeCodeMainVM
}

/** 登録処理(詳細画面) */
export interface SaveDetailRequest extends DaRequestBase {
  /** 詳細画面:ヘッダー情報 */
  hearderData: HeaderVM
  /** 詳細画面:基本情報 */
  fileinfoData?: FileInfoVM
  /** 詳細画面:ファイルI/F情報 */
  fileifList?: FileIFVM[]
  /** 詳細画面:取込コード変換情報 */
  codechangeList?: CodeChangeVM[]
  /** 詳細画面:マッピング設定情報 */
  itemmappingList?: ItemMappingVM[]
  /** 詳細画面:画面項目情報 */
  pageitemList?: PageItemVM[]
  /** 詳細画面:登録仕様情報 */
  insertList?: InsertVM[]
  /** 詳細画面:ストアドプロシージャ情報 */
  procedureList?: ProcedureDetailVM[]
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 更新日時 */
  upddttm: Date
  /** 詳細画面:変換コードメイン情報 */
  changeCodeMainList: ChangeCodeMainVM[]
}
/** アップロード処理 */
export interface UploadRequest extends CmUploadRequestBase {
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 一括取込入力No */
  impno?: string
}

/** 登録項目設定情報：明細一覧初期化処理(詳細画面) */
export interface InitTableFieldRequest extends DaRequestBase {
  /** テーブル物理ID */
  tableid: string
}

/** エラーファイル出力用 */
export interface ErrorDownloadRequest extends DaRequestBase {
  /** エラー */
  errorbytebuffer: string
}

/** 「並び順」重複エラーチェック処理(詳細画面) */
export interface CheckOrderSeqRequest extends DaRequestBase {
  /** 並び順 */
  orderseq?: number
  /** 業務区分 */
  gyoumukbn: string
  /** 一括取込入力区分 */
  impkbn?: string
  /** 一括取込入力No */
  impno?: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** 業務ドロップダウンリスト */
  gyoumuSelectorList: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 汎用取込設定情報リスト */
  kekkaList: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 詳細画面:ヘッダー情報 */
  hearderData: HeaderVM
  /** 詳細画面:基本情報 */
  fileinfoData: FileInfoVM
  /** 詳細画面:ファイルI/F情報 */
  fileifList: FileIFVM[]
  /** 詳細画面:取込コード変換情報 */
  codechangeList: CodeChangeVM[]
  /** 詳細画面:マッピング設定情報 */
  itemmappingList: ItemMappingVM[]
  /** 詳細画面:画面項目情報 */
  pageitemList: PageItemVM[]
  /** 詳細画面:登録仕様情報 */
  insertList: InsertVM[]
  /** 詳細画面:変換コードメイン情報 */
  changeCodeMainList: ChangeCodeMainVM[]
  /** 【一括取込入力区分】のドロップダウンリスト */
  impkbnList: DaSelectorModel[]
  /** 【年度表示フラグ】のドロップダウンリスト */
  yeardispflgList: DaSelectorModel[]
  /** 【登録区分】のドロップダウンリスト */
  regupdkbnList: DaSelectorModel[]
  /** 【年度範囲】のドロップダウンリスト */
  nendohanikbnList: DaSelectorModel[]
  /** 【テーブル】のドロップダウンリスト */
  headtableidList: DaSelectorKeyModel[]
  /** 【ファイル形式】のドロップダウンリスト */
  filetypeList: DaSelectorModel[]
  /** 【エンコード】のドロップダウンリスト */
  filenmruleList: DaSelectorModel[]
  /** 【データ形式】のドロップダウンリスト */
  datakbnList: DaSelectorModel[]
  /** 【引用符存在区分】のドロップダウンリスト */
  quoteskbnList: DaSelectorModel[]
  /** 【区切り記号】のドロップダウンリスト */
  dividekbnList: DaSelectorModel[]
  /** 【変換区分】のドロップダウンリスト */
  changekbnList: DaSelectorModel[]
  /** 【システムコード】のドロップダウンリスト */
  systemcodeList: DaSelectorModel[]
  /** 【チェック用】のドロップダウンリスト */
  procchkList: DaSelectorModel[]
  /** 【更新前処理】のドロップダウンリスト */
  procbeforeList: DaSelectorModel[]
  /** 【更新後処理】のドロップダウンリスト */
  procafterList: DaSelectorModel[]
  /** 【業務区分】のドロップダウンリスト */
  gyoumukbnList: DaSelectorModel[]
  /** エラーファイル出力用 */
  errorbytebuffer: string
  /** 更新日時 */
  upddttm: Date
}

/** 変換コード情報：本システムコード初期化処理(詳細画面) */
export interface InitSystemCodeResponse extends DaResponseBase {
  /** 【本システムコード】ドロップダウンリスト */
  systemcodeList: DaSelectorModel[]
}

/** 登録項目設定情報：明細一覧初期化処理(詳細画面) */
export interface InitTableFieldResponse extends DaResponseBase {
  /** テーブルの登録項目設定情報 */
  insertVM: InsertVM
}

/** ストアドプロシージャ情報：ドロップダウンリストの初期化データ(詳細画面) */
export interface ReSearchProcResponse extends DaResponseBase {
  /** 【チェック用】のドロップダウンリスト */
  procchkList: DaSelectorModel[]
  /** 【更新前処理】のドロップダウンリスト */
  procbeforeList: DaSelectorModel[]
  /** 【更新後処理】のドロップダウンリスト */
  procafterList: DaSelectorModel[]
}

/** 登録処理 */
export interface SaveDetailResponse extends DaResponseBase {
  /** 一括取込入力No */
  impno: string
  /** 更新日時 */
  upddttm?: Date
}

/** アップロード処理 */
export interface UploadResponse extends DaResponseBase {
  /** アップロードデータ */
  uploadData: UploadData
  /** エラーファイル出力用 */
  errorbytebuffer: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 汎用取込設定情報モデル(一覧画面) */
export interface RowVM {
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
/** ヘッダー情報モデル(詳細画面) */
export interface HeaderVM {
  /** 業務区分 */
  gyoumukbn: string
  /** 一括取込入力No */
  impno?: string
  /** 一括取込入力名 */
  impnm: string
  /** 一括取込入力区分 */
  impkbn: string
  /** 年度表示フラグ */
  yeardispflg: boolean
  /** 登録区分 */
  regupdkbn: string
  /** 年度範囲 */
  nendohanikbn?: string
  /** 説明 */
  memo?: string
  /** チェックプロシージャ名 */
  procchk: string
  /** 更新前プロシージャ名 */
  procbefore: string
  /** 更新後プロシージャ名 */
  procafter: string
  /** 並び順シーケンス */
  orderseq: number
  /** テーブル物理名 */
  tableidList: string[]
}
/** 取込ファイルの基本情報モデル(詳細画面) */
export interface FileInfoVM {
  /** ファイル形式 */
  filetype: string
  /** ファイルエンコード */
  fileencode: string
  /** ファイル名称 */
  filenmrule?: string
  /** 正規表現 */
  filenmruleflg?: boolean
  /** データ形式 */
  datakbn: string
  /** レコード長 */
  recordlen?: number
  /** 引用符存在区分 */
  quoteskbn?: string
  /** 区切り記号 */
  dividekbn?: string
  /** ヘッダー行数 */
  headerrows?: number
  /** フッター行数 */
  footerrows?: number
}
/** 取込ファイルIF情報モデル(詳細画面) */
export interface FileIFVM {
  /** ファイル項目ID */
  fileitemseq: number
  /** 項目名 */
  itemnm: string
  /** キーフラグ */
  keyflg?: boolean
  /** キーフラグ（名称） */
  keyflgName?: string
  /** 必須フラグ */
  requiredflg?: boolean
  /** 必須フラグ（名称） */
  requiredflgName?: string
  /** データ型 */
  datatype?: string
  /** データ型（名称） */
  datatypeName?: string
  /** 桁数 */
  len?: number
  /** 桁数（小数部） */
  len2?: number
  /** フォーマット */
  format?: string
  /** フォーマット（名称） */
  formatName?: string
  /** フォーマットチェック */
  fmtcheck?: string
  /** フォーマットチェック（名称） */
  fmtcheckName?: string
  /** フォーマット変換 */
  fmtchange?: string
  /** フォーマット変換（名称） */
  fmtchangeName?: string
  /** 備考 */
  memo?: string
}
/** 取込コード変換情報モデル(詳細画面) */
export interface ChangeCodeMainVM {
  /** コード変換区分 */
  codehenkankbn: number
  /** 変換区分名称 */
  henkankbnnm: string
  /** コード管理テーブル名 */
  codekanritablenm: string
  /** メインコード */
  maincd: string
  /** サブコード */
  subcd: string
  /** その他条件 */
  sonotajoken?: string
}
/** 取込コード変換情報モデル(詳細画面) */
export interface CodeChangeVM {
  /** コード変換区分 */
  cdchangekbn: number
  /** 取込コード変換情報明細リスト */
  codechangedetailList: CodeChangeDetailVM[]
}
/** 取込コード変換明細情報モデル(詳細画面) */
export interface CodeChangeDetailVM {
  /** コード変換区分 */
  cdchangekbn?: number
  /** 元コード */
  oldcode: string
  /** 元コード説明 */
  oldcodememo?: string
  /** 変換後コード */
  newcode: string
  /** 変換後コード説明 */
  newcodememo?: string
}
/** アップロードデータ */
export interface UploadData {
  /** 詳細画面:ヘッダー情報 */
  hearderData: HeaderVM
  /** 詳細画面:基本情報 */
  fileinfoData: FileInfoVM
  /** 詳細画面:ファイルI/F情報 */
  fileifList: FileIFVM[]
  /** 詳細画面:取込コード変換情報 */
  codechangeList: CodeChangeVM[]
  /** 詳細画面:マッピング設定情報 */
  itemmappingList: ItemMappingVM[]
  /** 詳細画面:画面項目情報 */
  pageitemList: PageItemVM[]
  /** 詳細画面:登録仕様情報 */
  insertList: InsertVM[]
  /** 詳細画面:変換コードメイン情報 */
  changeCodeMainList: ChangeCodeMainVM[]
}
/** マッピング設定情報モデル(詳細画面) */
export interface ItemMappingVM {
  /** 画面項目ID */
  pageitemseq: number
  /** 画面項目名 */
  pageitemnm: string
  /** ファイル項目(ファイル項目ID,カンマ区切り) */
  fileitemseq?: string
  /** ファイル項目(ファイル項目名,カンマ区切り)（名称） */
  fileitemseqName?: string
  /** マッピング区分 */
  mappingkbn?: string
  /** マッピング区分（名称） */
  mappingkbnName?: string
  /** マッピング方法 */
  mappingmethod?: string
  /** マッピング方法 */
  mappingmethodName?: string
  /** コード変換区分 */
  cdchangekbn?: number
  /** コード変換区分 */
  cdchangekbnName?: string
  /** 指定桁数（開始） */
  substrfrom?: number
  /** 指定桁数（終了） */
  substrto?: number
}
/** 画面項目情報モデル(詳細画面) */
export interface PageItemVM {
  /** 画面項目ID */
  pageitemseq: number
  /** 参照元フラグ */
  filecdflg?: boolean
  /** 項目名 */
  itemnm: string
  /**　ワークテープルカラム名 */
  wktablecolnm: string
  /** 入力区分 */
  inputkbn: string
  /** 入力区分（名称） */
  inputkbnName?: string
  /** 入力方法 */
  inputtype?: string
  /** 入力方法（名称） */
  inputtypeName?: string
  /** 引数 */
  hikisu?: string
  /** 引数（名称） */
  hikisuName?: string
  /** 桁数 */
  len?: number
  /** 桁数（小数部） */
  len2?: number
  /** 幅 */
  width?: number
  /** フォーマット */
  format?: string
  /** フォーマット（名称） */
  formatName?: string
  /** 必須フラグ */
  requiredflg?: string
  /** 必須フラグ */
  requiredflgName?: string
  /** 一意フラグ */
  uniqueflg?: boolean
  /** 一意フラグ */
  uniqueflgName?: string
  /** 正規表現 */
  seiki?: string
  /** 正規表現error */
  seikiError?: string
  /** 表示入力設定区分 */
  dispinputkbn?: string
  /** 表示入力設定区分（名称） */
  dispinputkbnName?: string
  /** 並び順 */
  sortno?: number
  /** 参照元項目ID */
  fromitemseq?: number | string
  /** 参照元項目ID（名称） */
  fromitemseqName?: string
  /** 参照元フィールド */
  fromfieldid?: string
  /** 参照元フィールド（名称） */
  fromfieldidName?: string
  /** 取得先フィールド */
  targetfieldid?: string
  /** 取得先フィールド（名称） */
  targetfieldidName?: string
  /** 年度チェック */
  yearchkflg?: string
  /** 年度チェック(名称） */
  yearchkflgName?: string
  /** 年度 */
  nendoflg?: boolean
  /** 年度(名称） */
  nendoflgName?: string
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
  /** マスタチェックテーブル（名称） */
  msttableName?: string
  /** マスタチェック条件 */
  mstjyoken?: string
  /** マスタチェック項目 */
  mstfield?: string
  /** マスタチェック項目（名称） */
  mstfieldName?: string
  /** 条件必須エラーレベル区分 */
  jherrlelkbn?: string
  /** 条件必須エラーレベル区分（名称） */
  jherrlelkbnName: string
  /** 条件必須項目ID */
  jhitemseq?: number | string
  /** 条件必須項目ID（名称） */
  jhitemseqName?: string
  /** 条件必須演算子 */
  jhenzan?: string
  /** 条件必須演算子（名称） */
  jhenzanName?: string
  /** 条件必須値 */
  jhval?: string
  /** 事業コード */
  jigyocd?: string
  /** 事業コード（名称） */
  jigyocdName?: string
  /** 項目特定区分 */
  itemkbn?: string
  /** 項目特定区分（名称） */
  itemkbnName?: string
  /** 項目特定区分status */
  itemkbnError?: string
  /** 項目特定区分help */
  itemkbnHelp?: string
}
/** 登録項目情報モデル(詳細画面) */
export interface InsertVM {
  /** テーブル物理名 */
  tableid: string
  /** 登録項目明細情報リスト */
  insertdetailList: InsertDetailVM[]
}
/** 登録項目明細情報モデル(詳細画面) */
export interface InsertDetailVM {
  /** テーブル物理名 */
  tableid: string
  /** レコードNo */
  recno: number
  /** フィールド物理名 */
  fieldid: string
  /** フィールド論理名 */
  fieldnm?: string
  /** 処理区分 */
  syorikbn: string
  /** 処理区分（名称） */
  syorikbnName?: string
  /** データ元画面項目ID */
  pageitemseq?: number
  /** データ元画面項目（名称） */
  itemnm?: string
  /** 固定値 */
  fixedval?: string
  /** データ元テーブル */
  datamototablenm?: string
  /** データ元テーブル(論理名) */
  datamototableronrinm?: string
  /** データ元フィールド */
  datamotofieldnm?: string
  /** データ元フィールド(論理名) */
  datamotofieldronrinm?: string
  /** 採番キー */
  saibankey?: string
  /** 採番キー(論理名) */
  saibankeyronrinm?: string
}
/** ストアドプロシージャ情報モデル(詳細画面) */
export interface ProcedureVM {
  /** 処理種別 */
  processingtype: string
  /** ストアドプロシージャ明細情報リスト */
  proceduredetail: ProcedureDetailVM
}
/** ストアドプロシージャ明細情報モデル(詳細画面) */
export interface ProcedureDetailVM {
  /** チェックプロシージャ名 */
  procchk: string
  /** 更新前プロシージャ名 */
  procbefore: string
  /** 更新後プロシージャ名 */
  procafter: string
}

/** 詳細画面 */
export interface AllData {
  /** 詳細画面:基本情報 */
  basicInfo?: FileInfoVM
  /** 詳細画面:ファイルI/F情報 */
  fileInterface?: FileIFVM[]
  /** 詳細画面:取込コード変換情報 */
  codeTransfer?: CodeChangeVM[]
  /** 詳細画面:マッピング設定情報 */
  mappingSetting?: ItemMappingVM[]
  /** 詳細画面:画面項目情報 */
  projectDefine?: PageItemVM[]
  /** 詳細画面:登録仕様情報 */
  projectTransfer?: InsertVM[]
  /** 詳細画面:ストアドプロシージャ情報 */
  procedure?: ProcedureDetailVM
  /** 詳細画面:変換コードメイン情報 */
  changeCodeMainList?: ChangeCodeMainVM[]
}

export interface AllDataChange {
  /** 詳細画面:基本情報 */
  basicInfo?: boolean
  /** 詳細画面:ファイルI/F情報 */
  fileInterface?: boolean
  /** 詳細画面:取込コード変換情報 */
  codeTransfer?: boolean
  /** 詳細画面:マッピング設定情報 */
  mappingSetting?: boolean
  /** 詳細画面:画面項目情報 */
  projectDefine?: boolean
  /** 詳細画面:登録仕様情報 */
  projectTransfer?: boolean
  /** 詳細画面:ストアドプロシージャ情報 */
  procedure?: boolean
}
