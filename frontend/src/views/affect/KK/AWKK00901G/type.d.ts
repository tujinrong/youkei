/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業予定管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.03.06
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面：日程) */
export interface SearchNitteiListRequest extends CmSearchRequestBase {
  /** 業務区分 */
  gyomukbn?: string
  /** 実施予定日(開始) */
  jissiyoteiymdf?: string
  /** 実施予定日(終了) */
  jissiyoteiymdt?: string
  /** その他日程事業・保健指導事業コード */
  jigyocd?: string
  /** 会場コード */
  kaijocd?: string
  /** 医療機関コード */
  kikancd?: string
  /** 担当者 */
  staffid?: string
}
/** 検索処理(一覧画面：コース) */
export interface SearchCourseListRequest extends SearchNitteiListRequest {
  /** コース名 */
  coursenm?: string
  /** 回数 */
  kaisu?: number
}
/** 初期化処理(詳細画面：日程) */
export interface InitNitteiDetailRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino?: number
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コピーフラグ(コピーの場合、true) */
  copyflg: boolean
}
/** 初期化処理(詳細画面：コース) */
export interface InitCourseDetailRequest extends DaRequestBase {
  /** コース番号 */
  courseno?: number
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コピーフラグ(コピーの場合、true) */
  copyflg: boolean
}
/** 保存処理(詳細画面：日程) */
export interface SaveNitteiRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino?: number
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 日程情報(明細) */
  detailinfo: NitteiDetailVM
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 保存処理(詳細画面：コース) */
export interface SaveCourseRequest extends DaRequestBase {
  /** コース番号 */
  courseno?: number
  /** コース名 */
  coursenm: string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コース情報(明細) */
  detailinfo: CourseDetailVM[]
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理(詳細画面：日程) */
export interface DeleteNitteiRequest extends DaRequestBase {
  /** 日程番号 */
  nitteino: number
  /** 更新日時(排他用) */
  upddttm: Date | string
}
/** 削除処理(詳細画面：コース) */
export interface DeleteCourseRequest extends DaRequestBase {
  /** コース番号 */
  courseno: number
  /** 更新日時(排他用) */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitListResponse extends DaResponseBase {
  /** 業務区分一覧 */
  selectorlist1: DaSelectorModel[]
  /** 予約事業一覧 */
  selectorlist2: DaSelectorKeyModel[]
  /** 会場一覧 */
  selectorlist3: DaSelectorModel[]
  /** 医療機関一覧 */
  selectorlist4: DaSelectorModel[]
  /** 担当者一覧 */
  selectorlist5: DaSelectorModel[]
}
/** 検索処理(一覧画面：日程) */
export interface SearchNitteiListResponse extends CmSearchResponseBase {
  /** 日程情報 */
  kekkalist: NitteiRowVM[]
}
/** 検索処理(一覧画面：コース) */
export interface SearchCourseListResponse extends CmSearchResponseBase {
  /** コース情報 */
  kekkalist: CourseRowVM[]
}
/** 初期化処理(詳細画面：日程) */
export interface InitNitteiDetailResponse extends InitListResponse {
  /** 日程情報(ヘッダー) */
  headerinfo: NitteiHeaderVM
  /** 日程情報(明細) */
  detailinfo: NitteiDetailVM
  /** 編集フラグ */
  editflg: boolean
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 初期化処理(詳細画面：コース) */
export interface InitCourseDetailResponse extends InitListResponse {
  /** コース情報(ヘッダー) */
  headerinfo: CourseHeaderVM
  /** コース情報(明細) */
  detailinfo: CourseDetailVM[]
  /** 編集フラグ */
  editflg: boolean
  /** 更新日時(排他用) */
  upddttm?: Date | string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 日程情報(1件) */
export interface NitteiRowVM {
  /** 日程番号 */
  nitteino: number
  /** 業務区分名 */
  gyomukbnnm: string
  /** その他日程事業・保健指導事業名 */
  jigyonm: string
  /** 実施内容 */
  jissinaiyo: string
  /** 実施予定日 */
  jissiyoteiymd: string
  /** 開始時間～終了時間 */
  time: string
  /** 会場名 */
  kaijonm: string
  /** 医療機関名 */
  kikannm: string
  /** 担当者名(複数) */
  staffidnms: string
  /** 定員 */
  teiin: number
}
/** コース情報(1件) */
export interface CourseRowVM {
  /** コース番号 */
  courseno: number
  /** 業務区分名 */
  gyomukbnnm: string
  /** コース名 */
  coursenm: string
  /** 回数 */
  kaisu: number
  /** 実施期間 */
  jissikikan: string
}
/** 日程情報(ヘッダー) */
export interface NitteiHeaderVM {
  /** 業務区分 */
  gyomukbn: string
  /** 登録支所名 */
  regsisyonm: string
}
/** 日程情報(明細) */
export interface NitteiDetailVM {
  /** その他日程事業・保健指導事業(コード：名称) */
  jigyocdnm: string
  /** 実施内容 */
  jissinaiyo: string
  /** 実施予定日 */
  jissiyoteiymd: string
  /** 開始時間 */
  tmf: string
  /** 終了時間 */
  tmt: string
  /** 会場(コード：名称) */
  kaijocdnm: string
  /** 医療機関(コード：名称) */
  kikancdnm: string
  /** 担当者(複数) */
  staffids: string[]
  /** 定員 */
  teiin?: number
  /** 編集フラグ(事業) */
  editflg: boolean
}
/** コース情報(ヘッダー) */
export interface CourseHeaderVM extends NitteiHeaderVM {
  /** コース名 */
  coursenm: string
}
/** コース情報(明細) */
export interface CourseDetailVM extends NitteiDetailVM {
  /** 日程番号 */
  nitteino?: number
  /** 回数 */
  kaisu: number
}
