/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: コントロール情報保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { InitMainCodeRequest } from '../AWAF00801G/type'
import { EnumDataType } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化(サブコード) */
export interface InitSubCodeRequest extends InitMainCodeRequest {
  /** コントロールメインコード */
  ctrlmaincd: string
}
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** コントロールメインコード */
  ctrlmaincd: string
  /** コントロールサブコード */
  ctrlsubcd: string
}
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** コントロールデータリスト */
  savelist: SaveVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 説明 */
  biko: string
  /** コントロールデータリスト */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchVM extends SaveVM {
  /** 項目名称 */
  itemnm: string
  /** データ型 */
  datatype: EnumDataType
  /** 範囲フラグ */
  rangeflg: boolean
}
/** 保存処理 */
export interface SaveVM {
  /** コントロールコード */
  ctrlcd: string
  /** 値 */
  value: ValueVM | string | null
  /** 備考 */
  biko: string
  /** 更新日時 */
  upddttm: Date | string
}
/** 値モデル */
export interface ValueVM {
  /** 値１ */
  value1: string | null
  /** 値２ */
  value2: string | null
}
