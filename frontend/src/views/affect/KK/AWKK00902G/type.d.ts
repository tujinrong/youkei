/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.03.11
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import {
  InitListResponse,
  SearchNitteiListRequest as SearchNitteiListRequest_901
} from '../AWKK00901G/type'
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(日程一覧画面) */
export interface SearchNitteiListRequest extends SearchNitteiListRequest_901 {
  /** コース名 */
  coursenm?: string
  /** 回数 */
  kaisu?: number
  /** 宛名番号 */
  atenano?: string
  /** 個人番号 */
  personalno?: string
}
/** コース日程一覧画面(初期化処理/コピー処理) */
export interface CourseListRequest extends DaRequestBase {
  /** コース番号 */
  courseno: number
}
/** 初期化処理(予約者一覧画面) */
export interface InitPersonListRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino: number
}
/** 削除処理(予約者一覧画面) */
export interface DeletePersonListRequest extends DaRequestBase {
  /** 宛名番号(チェック対象) */
  locklist: LockVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino: number
  /** 宛名番号 */
  atenano: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** チェック処理(詳細画面) */
export interface CheckRequest extends InitDetailRequest {
  /** 待機フラグ */
  taikiflg: boolean
}
/** 保存処理(詳細画面) */
export interface SaveRequest extends InitDetailRequest {
  /** 予約情報 */
  detailinfo: DetailVM
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理(詳細画面) */
export interface DeleteDetailRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino: number
  /** 宛名番号 */
  atenano: string
  /** 更新日時(排他用) */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitNitteiListResponse extends InitListResponse {
  /** コース一覧 */
  selectorlist6: DaSelectorModel[]
}
/** 検索処理(日程一覧画面) */
export interface SearchNitteiListResponse extends CmSearchResponseBase {
  /** 日程情報 */
  kekkalist: NitteiRowVM[]
}
/** 初期化処理(コース一覧画面) */
export interface InitCourseListResponse extends DaResponseBase {
  /** コース情報(ヘッダー) */
  headerinfo: CourseHeaderVM
  /** コース情報(明細) */
  kekkalist: CourseRowVM[]
  /** 編集フラグ(コピーボタン) */
  editflg: boolean
}
/** 初期化処理(予約者一覧画面) */
export interface InitPersonListResponse extends DaResponseBase {
  /** 日程基本情報(ヘッダー) */
  headerinfo: PersonHeaderVM
  /** 日程基本情報(明細) */
  detailinfo: PersonDetailVM
  /** 結果一覧 */
  kekkalist: PersonRowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 日程基本情報 */
  headerinfo: PersonHeaderVM
  /** 希望者情報 */
  personinfo: CommonBarHeaderBase3VM
  /** 予約情報 */
  detailinfo: DetailVM
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** チェック処理(詳細画面) */
export interface CheckResponse extends DaResponseBase {
  /** 定員オーバーフラグ */
  overflg: boolean
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 日程情報(1件) */
export interface NitteiRowVM extends RowBaseVM {
  /** 業務区分名 */
  gyomukbnnm: string
  /** コース番号 */
  courseno?: number
  /** コース名 */
  coursenm: string
  /** 開始時間～終了時間 */
  time: string
}
/** コース情報(1件) */
export interface CourseRowVM extends RowBaseVM {
  /** 開始時間 */
  tmf: string
  /** 終了時間 */
  tmt: string
}
/** 共通情報(1件) */
export interface RowBaseVM {
  /** 日程番号 */
  nitteino: number
  /** 回数 */
  kaisu?: number
  /** その他日程事業・保健指導事業名 */
  jigyonm: string
  /** 実施内容 */
  jissinaiyo: string
  /** 実施予定日 */
  jissiyoteiymd: string
  /** 会場名 */
  kaijonm: string
  /** 医療機関名 */
  kikannm: string
  /** 担当者名(複数) */
  staffidnms: string
  /** 状態 */
  status: string
  /** 申/定員 */
  ninzu: string
  /** 待機数 */
  taikinum?: number
}
/** コース情報(ヘッダー) */
export interface CourseHeaderVM {
  /** 業務区分名 */
  gyomukbnnm: string
  /** コース名 */
  coursenm: string
}
/** 日程基本情報(ヘッダー) */
export interface PersonHeaderVM extends CourseHeaderVM {
  /** コース番号 */
  courseno?: number
  /** 回数 */
  kaisu?: number
  /** その他日程事業・保健指導事業名 */
  jigyonm: string
  /** 実施内容 */
  jissinaiyo: string
  /** 実施予定日 */
  jissiyoteiymd: string
  /** 開始時間 */
  tmf: string
  /** 終了時間 */
  tmt: string
  /** 会場名 */
  kaijonm: string
  /** 医療機関名 */
  kikannm: string
  /** 担当者一覧 */
  staffnms: string
}
/** 日程基本情報(予約状態) */
export interface PersonDetailVM {
  /** 状態 */
  status: string
  /** 定員 */
  teiin: number
  /** 申込人数 */
  moushikominum?: number
  /** 待機人数 */
  taikinum?: number
}
/** 希望者情報(検索用) */
export interface PersonRowVM extends LockVM {
  /** 予約番号 */
  yoyakuno: number
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sex: string
  /** 生年月日 */
  bymd: string
  /** 年齢 */
  age: string
  /** 住民区分 */
  juminkbn: string
  /** 警告内容 */
  keikoku: string
  /** 予約状態 */
  status: string
}
/** 希望者情報(排他用) */
export interface LockVM {
  /** 日程番号 */
  nitteino: number
  /** 宛名番号 */
  atenano: string
  /** 更新日時(排他用) */
  upddttm: Date | string
}
/** 予約情報(詳細画面) */
export interface DetailVM {
  /** 予約番号 */
  yoyakuno?: number
  /** 待機フラグ */
  taikiflg: boolean
  /** 受診金額 */
  jusinkingaku?: number
  /** 金額（市区町村負担） */
  kingaku_sityosonhutan?: number
  /** 初回受付日 */
  syokaiuketukeymd: string
  /** 備考 */
  biko: string
}
