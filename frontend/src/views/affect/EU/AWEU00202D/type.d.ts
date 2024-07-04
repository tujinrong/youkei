/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票新規作成
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum帳票様式, Enum内外区分, Enum様式種別, Enum様式作成方法 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** チェック処理 */
export interface CheckRequest extends DaRequestBase {
  /** 帳票様式 */
  kbn: Enum帳票様式
  /** 帳票ID */
  rptid: string
  /** 帳票名 */
  rptnm: string
  /** 様式名 */
  yosikinm: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 帳票初期化処理 */
export interface InitReportResponse extends DaResponseBase {
  /** ドロップダウンリスト(業務) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(作成方法) */
  selectorlist2: DaSelectorModel[]
  /** プロシージャのドロップダウンリスト */
  functionlist: DaSelectorModel[]
  /** ドロップダウンリスト(様式種別) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(内外区分) */
  selectorlist4: DaSelectorModel[]
  /** ドロップダウンリスト(明細有無) */
  selectorlist5: DaSelectorModel[]
  /** ドロップダウンリスト(行列固定) */
  selectorlist6: DaSelectorModel[]
  /** 帳票グループリスト */
  rptgrouplist: ReportGroupVM[]
  /** データソースリスト */
  datasourcelist: DatasourceVM[]
  /** 様式種別詳細リスト */
  yoshikitypelist: YoshikiTypeVM[]
}
/** 別様式初期化処理 */
export interface InitOtherYosikiResponse extends DaResponseBase {
  /** 帳票リスト */
  reportlist: ReportVM[]
  /** ドロップダウンリスト(様式種別) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(内外区分) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(明細有無) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(行列固定) */
  selectorlist4: DaSelectorModel[]
  /** 様式種別詳細リスト */
  yoshikitypelist: YoshikiTypeVM[]
}
/** サブ帳票初期化処理 */
export interface InitSubReportResponse extends DaResponseBase {
  /** ドロップダウンリスト(作成方法) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(帳票種別) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(明細有無) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(行列固定) */
  selectorlist4: DaSelectorModel[]
  /** データソースリスト */
  datasourcelist: DatasourceVM[]
  /** ドロップダウンリスト(帳票様式) */
  reportwithyosikilist: ReportWithYosikiVM[]
  /** 様式種別詳細リスト */
  yoshikitypelist: YoshikiTypeVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 帳票初期化処理 */
export interface ReportGroupVM {
  /** 帳票グループID */
  rptgroupid: string
  /** 帳票グループ名 */
  rptgroupnm: string
  /** 業務コード */
  gyoumucd: string
}
/** 帳票初期化処理 */
export interface DatasourceVM {
  /** データソースID */
  datasourceid: string
  /** データソース名称 */
  datasourcenm: string
  /** 業務コード */
  gyoumucd: string
}
/** 帳票初期化処理 */
export interface YoshikiTypeVM {
  /** 様式種別 */
  yosikisyubetu: Enum様式種別
  /** 様式種別詳細リスト */
  yosikikbnlist: DaSelectorModel[]
}
/** 別様式初期化処理 */
export interface ReportVM {
  /** 帳票ID */
  rptid: string
  /** 帳票名 */
  rptnm: string
}
/** サブ帳票初期化処理 */
export interface ReportWithYosikiVM {
  /** 帳票ID */
  rptid: string
  /** 帳票名 */
  rptnm: string
  /** 業務 */
  gyoumu: string
  /** 帳票グループ */
  rptgroup: string
  /** 宛名フラグ */
  atenaflg: boolean
  /** アドレスシールフラグ */
  addresssealflg: boolean
  /** バーコードシール出力フラグ  */
  barcodesealflg: boolean
  /** はがき出力フラグ */
  hagakiflg: boolean
  /** 宛名台帳出力フラグ  */
  atenadaityoflg: boolean
  /** 件数表(年齢別)出力フラグ */
  kensuhyonenreiflg: boolean
  /** 件数表(行政区別)出力フラグ */
  kensuhyogyoseikuflg: boolean
  /** ドロップダウンリスト(様式) */
  selectorlist: DaSelectorModel[]
}
