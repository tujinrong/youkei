/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { PageItemVM } from '../AWKK00601G/type'
import { Enum編集区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理(取込設定：画面項目情報ダイアログ画面) */
export interface InitRequest extends DaRequestBase {
  /** 画面項目ID */
  pageitemseq: number
  /** 業務区分 */
  gyoumukbn: string
  /** 一括取込入力No */
  impno?: string
  /** 入力区分 */
  inputkbn?: string
  /** 入力方法 */
  inputtype?: string
  /** マスタチェックテーブル */
  msttable?: string
  /** 画面項目情報の(画面項目ID,項目名)のリスト */
  pageitemList: string[]
  /** 編集区分 */
  editkbn: Enum編集区分
}

/** ドロップダウン初期化(入力方法) */
export interface InitInputTypeRequest extends DaRequestBase {
  /** 業務区分 */
  gyoumukbn: string
  /** 一括取込入力No */
  impno?: string
  /** 入力区分 */
  inputkbn?: string
}

/** ドロップダウン初期化(フィールド) */
export interface InitFieldidRequest extends DaRequestBase {
  /** テーブルID */
  tableid: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(取込設定：画面項目情報ダイアログ画面) */
export interface InitResponse extends DaResponseBase {
  /** 画面項目明細情報 */
  detailData: PageItemVM
  /** 【入力区分】のドロップダウンリスト */
  inputkbnList: DaSelectorModel[]
  /** 【入力方法】のドロップダウンリスト */
  inputtypeList: DaSelectorKeyModel[]
  /** 【フォーマット】のドロップダウンリスト */
  formatList: DaSelectorModel[]
  /** 【必須】のドロップダウンリスト */
  requiredflgList: DaSelectorModel[]
  /** 【年度チェック】のドロップダウンリスト */
  yearchkflgList: DaSelectorModel[]
  /** 【表示入力設定】のドロップダウンリスト */
  dispinputkbnList: DaSelectorModel[]
  /** 【参照元項目】のドロップダウンリスト */
  fromitemseqList: DaSelectorModel[]
  /** 【参照元フィールド】のドロップダウンリスト */
  fromfieldidList: DaSelectorModel[]
  /** 【取得先フィールド】のドロップダウンリスト */
  targetfieldidList: DaSelectorModel[]
  /** 【マスタチェックテーブル】のドロップダウンリスト */
  msttableList: DaSelectorKeyModel[]
  /** 【マスタチェック項目】のドロップダウンリスト */
  mstfieldList: DaSelectorModel[]
  /** 【条件必須エラーレベル区分】のドロップダウンリスト */
  jherrlelkbnList: DaSelectorModel[]
  /** 【条件必須項目】のドロップダウンリスト */
  jhitemseqList: DaSelectorModel[]
  /** 【条件必須演算子】のドロップダウンリスト */
  jhenzanList: DaSelectorModel[]
  /** 【実施事業】のドロップダウンリスト */
  jigyocdList: DaSelectorModel[]
  /** 【項目特定区分】のドロップダウンリスト */
  itemkbnList: DaSelectorModel[]
  /** 【引数区分】のドロップダウンリスト */
  hikisukbnList: DaSelectorModel[]
}

/** 【入力方法】初期化処理 */
export interface InitInputTypeResponse extends DaResponseBase {
  /** 【入力方法】のドロップダウンリスト */
  inputtypeList: DaSelectorKeyModel[]
}

/** 【入力方法】初期化処理 */
export interface InitFieldidResponse extends DaResponseBase {
  /** 【入力方法】のドロップダウンリスト */
  fieldidList: DaSelectorModel[]
}
