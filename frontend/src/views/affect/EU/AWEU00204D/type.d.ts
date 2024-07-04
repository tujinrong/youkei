/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票項目追加
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum集計区分, Enum並び替え, Enum出力項目区分, Enum集計方法, Enum小計区分 } from '#/Enums'
import { ItemTreeNode, SimpleItemVM } from '../AWEU00107D/type'
import { ReportItemDetailVM } from '../AWEU00201G/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 一覧項目ツリー検索処理 */
export interface SearchNormalTreeRequest extends DaRequestBase {
  /** データソースID */
  datasourceid?: string
  /** 一覧項目ID */
  itemids: string[]
  /** プロシージャ名称 */
  procnm?: string
  /** プロシージャ */
  sql?: string
}
/** 集計項目ツリー検索処理 */
export interface SearchStatisticTreeRequest extends SearchNormalTreeRequest {
  /** 集計区分 */
  crosskbn?: Enum集計区分
}
/** 集計項目検索処理 */
export interface SearchStatisticRequest extends DaRequestBase {
  /** データソースID */
  datasourceid?: string
  /** 項目ID */
  itemids: string[]
  /** 集計区分 */
  crosskbn?: Enum集計区分
  /** 項目ID */
  itemid?: string
  /** プロシージャ名称 */
  procnm?: string
  /** プロシージャ文 */
  sql?: string
}
/** プロシージャ一覧項目検索処理 */
export interface SearchProcItemRequest extends DaRequestBase {
  /** プロシージャ名称 */
  procnm: string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchNormalTreeResponse extends DaResponseBase {
  /**項目ツリー */
  itemtree: Array<ItemTreeNode<ItemVM>>
}
/** 集計項目検索処理 */
export interface SearchStatisticResponse extends DaResponseBase {
  /** 分類リスト */
  bunruilist: BunruiItemVM[]
  /** ドロップダウンリスト(集計項目区分) */
  syukeikbnlist: DaSelectorModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface ItemVM extends SimpleItemVM {
  /** 様式項目ID */
  yosikiitemid: string
  /** 帳票項目名称 */
  reportitemnm: string
  /** CSV項目名称 */
  csvitemnm: string
  /** テーブル別名 */
  tablealias: string
  /** 並び替え */
  orderkbn: Enum並び替え
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
  formatkbn2?: number
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
}
/** 集計項目検索処理 */
export interface BunruiItemVM {
  /** 大分類 */
  daibunrui: string
  /** 項目リスト */
  itemlist: StatisticItemVM[]
}
/** 集計項目検索処理 */
export interface StatisticItemVM {
  /** SQLカラム */
  sqlcolumn: string
  /** 様式項目ID */
  yosikiitemid: string
  /** 帳票項目名称 */
  reportitemnm: string
  /** CSV項目名称 */
  csvitemnm: string
  /** テーブル別名 */
  tablealias: string
  /** 並び替え */
  orderkbn: Enum並び替え
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
  formatkbn2?: number
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
}

/** チェック処理 */
export interface CheckRequest extends DaRequestBase {
  /** SQLカラム */
  sqlcolumn: string
  /** フォーマット区分 */
  formatkbn?: string
  /** フォーマット区分2 */
  formatkbn2?: string
}
