// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             インターフェース定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

import { Enumコントロール, Enum文字暦法区分, Enum様式種別, Enum検索条件区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 一覧画面検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /**業務区分 */
  gyomukbn?: string
  /**帳票グループID */
  rptgroupid?: string
  /**帳票名 */
  rptnm?: string
}

/** 出力画面初期化処理 */
export interface InitDetailRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
}

/** 様式情報の取得 */
export interface YosikiInfoRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**帳票ID */
  tyusyututaisyocd: string
  /**帳票出力区分(抽出パネルのとき設定) */
  tyusyutukbn?: string
  /**様式紐付け値(抽出パネルのとき未設定) */
  himozukevalue?: string
  /**様式紐付け条件ID(抽出パネルのとき未設定) */
  himozukejyokenid?: string
}

/** 出力画面検索処理 */
export interface DetailSearchRequest extends CmSearchRequestBase {
  /**帳票ID */
  rptid: string
  /**ワークシーケンス */
  workseq: number
}

/**  抽出内容が変更時処理 */
export interface ChangeTyusyutunaiyoRequest extends DaRequestBase {
  /**抽出内容 */
  tyusyutunaiyo: string
}

/**  参照元項目入力後参照先項目の選択リストを取得する処理 */
export interface GetTargetItemValueRequest extends DaRequestBase {
  /**帳票ID */
  rptid: string
  /**参照元項目ラベル */
  jyokenlabel: string
  /**参照元項目値 */
  val: string
  /**参照先項目ID(複数? ,) */
  targetitemseq: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** 初期化処理(一覧画面) */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(業務) */
  selectorlist1: DaSelectorModel[]
  /**ドロップダウンリスト(帳票グループ) */
  selectorlist2: DaSelectorKeyModel[]
}

/** 検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /**帳票リスト */
  kekkalist: ReportVM[]
}

/** 初期化処理(出力画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**帳票説明 */
  rptbiko?: string
  /**宛名フラグ */
  atenaflg: boolean
  /**様式紐付け名 */
  yosikihimonm?: string
  /**検索条件 */
  kensakujyokenlist1: KensakuJyokenInitVM[]
  /**検索条件以外 */
  kensakujyokenlist2: KensakuJyokenInitVM[]
  /**ドロップダウンリスト(出力様式) */
  selectorlist: YosikiInfo[]
  /**詳細検索条件 */
  detailjyokenlist: DetailJyokenInitVM[]
  /**抽出パネル表示フラグ */
  tyusyutupanelflg: boolean
  /**ドロップダウンリスト(抽出対象:抽出対象コード,抽出対象名,通知サイクル,抽出データ詳細区分) */
  tyusyututaisyolist: MyDaSelectorModel[]
  /**ドロップダウンリスト(抽出内容:抽出シーケンス,抽出内容,抽出対象コード_年度) */
  tyusyutunaiyolist: DaSelectorKeyModel[]
  /**ドロップダウンリスト(帳票出力区分:区分コード,区分名称,様式種別,抽出データ詳細区分) */
  tyusyutukbnlist: MyDaSelectorModel[]
}
/** 様式情報の取得処理 */
export interface YosikiInfoResponse extends DaResponseBase {
  /**ドロップダウンリスト(出力様式) */
  selectorlist: YosikiInfo[]
}

/** 抽出内容が変更時処理 */
export interface ChangeTyusyutunaiyoResponse extends DaResponseBase {
  /**抽出人数 */
  atenanocnt: string
  /**登録日時 */
  regdttm: string
}

/** 検索処理(出力画面) */
export interface SearchDetailResponse extends CmSearchResponseBase {
  /**宛名リスト */
  kekkalist: AtenaVM[]
}

/** 様式情報の取得 */
export interface YosikiInfo {
  /**様式ID*/
  yosikiid: string
  /**様式名 */
  yosikinm: string
  /**様式種別 */
  yosikisyubetu: Enum様式種別
  /**更新フラグ */
  updateflg: boolean
  /**PDF出力フラグ */
  pdfflg: boolean
  /**EXCEL出力フラグ */
  excelflg: boolean
  /**その他出力フラグ */
  otherflg: boolean
  /**帳票発行履歴管理フラグ */
  hakoflg: boolean
  /**通知書出力フラグ */
  tutisyooutflg: boolean
  /**発送履歴テーブル更新区分 */
  rirekiupdkbn?: string
}

/**  参照元項目入力後参照先項目の選択リストを取得する処理 */
export interface GetTargetItemValueResponse extends DaResponseBase {
  /**取得先項目の値リスト */
  targetItemValueList: TargetItemValueVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 一覧画面検索処理 */
export interface ReportVM {
  /**帳票ID */
  rptid: string
  /**帳票名 */
  rptnm: string
  /**帳票グループ */
  rptgroupnm: string
  /**帳票説明 */
  rptbiko?: string
  /**作成者 */
  regusernm: string
  /**作成日時 */
  regdttm: Date | string
  /**帳票グループID */
  rptgroupid: string
}

/** 出力画面初期化処理 */
export interface KensakuJyokenInitVM {
  /**条件シーケンス */
  jyokenseq: number
  /**条件ID */
  jyokenid?: number
  /**検索条件区分 */
  jyokenkbn: Enum検索条件区分
  /**ラベル */
  jyokenlabel: string
  /**変数名 */
  variables?: string
  /**SQL */
  sql: string
  /**テーブル別名 */
  tablealias: string
  /**コントロール区分 */
  controlkbn?: Enumコントロール
  /**必須フラグ */
  hissuflg: boolean
  /**データ型 */
  datatype: Enum文字暦法区分
  /** 年度範囲区分 */
  nendohanikbn: string
  /** 初期表示年度 */
  nendo: string
  /** 最大年度 */
  nendomax?: string
  /** 初期値 */
  syokiti?: string
  /**選択リスト */
  selectorlist?: DaSelectorModel[]
  /**値 */
  value: any
  /** 参照先項目ID(複数? ,) */
  targetitemseq?: string

  /**front use 外部検索条件入力不可 */
  disabled?: boolean
}

/** 出力画面初期化処理 */
export interface DetailJyokenInitVM extends CommonFilterVM {
  /**項目物理名1 */
  komokunm1: string
}

/** 出力画面検索処理*/
export interface AtenaVM {
  /**出力フラグ */
  formflg: boolean
  /**宛名番号 */
  atenano: string
  /**氏名_優先 */
  simei_yusen: string
  /**性別表記 */
  sex: string
  /**生年月日表記 */
  bymdhyoki: string
  /**行政区 */
  gyoseikunm: string
  /**住民区分 */
  juminkbn: string
  /**発行対象外者対象外理由 */
  taisyogairiyu: string
  /**警告内容 */
  warningtext: string
}

/** 抽出パネル用*/
export interface MyDaSelectorModel {
  /** 名称 */
  label: string
  /** コード */
  value: string
  /** キー項目1 */
  key: string
  /** キー項目2 */
  key2: string
}

/** 抽出パネル用*/
export interface TargetItemValueVM {
  /** 条件ID */
  jyokenid: number
  /** 選択リスト */
  selectorlist: DaSelectorModel[]
}
