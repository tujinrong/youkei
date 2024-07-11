/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 登録部署設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.04
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { LockVM, SearchResponse as SearchResponseBase } from '@/views/affect/AF/AWAF00801G/type'
import { Enum名称区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 名称区分(メインコード) */
  kbn1: Enum名称区分
  /** 名称区分(サブコード) */
  kbn2: Enum名称区分
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaRequestBase {
  /** 汎用メインコード */
  hanyomaincd: string
  /** 汎用サブコード */
  hanyosubcd: string

  /** 備考 */
  biko: string
  /** 桁数 */
  keta: number | null
  /** INSERT可能フラグ */
  iflg: boolean
  /** UPDATE可能フラグ */
  uflg: boolean
  /** DELETE可能フラグ */
  dflg: boolean
  /** 汎用データリスト */
  kekkalist: HanyoVM[]
  /** 汎用データリスト(ロック用) */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 汎用データ情報モデル */
export interface HanyoVM {
  /** 汎用コード */
  hanyocd: string
  /** 更新日時 */
  upddttm?: Date | string
  /** 名称 */
  nm: string
  /** カナ名称 */
  kananm: string
  /** 略称 */
  shortnm: string
  /** 備考 */
  biko: string
  /** 汎用区分1 */
  hanyokbn1: string
  /** 汎用区分2 */
  hanyokbn2: string
  /** 汎用区分3 */
  hanyokbn3: string
  /** 使用停止フラグ */
  stopflg: boolean
}
