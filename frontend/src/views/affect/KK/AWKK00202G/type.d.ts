/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 会場保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.11.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分, Enum地区区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 会場コード */
  kaijocd: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 会場コード */
  kaijocd: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 会場情報メイン */
  maininfo: MainInfoVM
  /** 地区リスト */
  tikulist: TikuOneSaveVM[]
  /** 編集区分 */
  editkbn: Enum編集区分
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(会場コード) */
  selectorlist1: DaSelectorModel[]
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(会場一覧) */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 地区リスト */
  tikuList: TikuOneInitVM[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends InitDetailResponse {
  /** 会場情報メイン */
  mainInfo: MainInfoVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM extends BaseInfoVM {
  /** 会場連絡先 */
  kaijorenrakusaki: string
  /** 住所方書 */
  adrskatagaki: string
  /** 行政区 */
  gyoseiku: string
  /** 利用状態 */
  stopflg: string
}
/** 会場情報(メイン：ベース) */
export interface BaseInfoVM {
  /** 会場コード */
  kaijocd: string
  /** 会場名 */
  kaijonm: string
  /** 会場名(カナ) */
  kanakaijonm: string
}
/** 会場情報 */
export interface MainInfoVM extends BaseInfoVM {
  /** 使用停止フラグ */
  stopflg: boolean
  /** 住所 */
  adrs: string
  /** 方書 */
  katagaki: string
  /** 会場連絡先 */
  kaijorenrakusaki: string
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 単一地区情報初期化モデル */
export interface TikuOneInitVM extends TikuOneSaveVM {
  /** 地区区分名称 */
  tikukbnnm: string
  /** 地区一覧(コード：名称) */
  tikucdnmList: DaSelectorModel[]
}
/** 単一地区情報保存モデル */
export interface TikuOneSaveVM {
  /** 地区区分 */
  tikukbn: Enum地区区分
  /** 地区一覧(コード) */
  tikucdList: string[]
}
