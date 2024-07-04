/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.19
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 年度 */
  nendo: number
  /** 実施予定日(開始) */
  yoteiymdf?: string
  /** 実施予定日(終了) */
  yoteiymdt?: string
  /** 成人健（検）診予約日程事業コード */
  jigyocd?: string
  /** 会場コード */
  kaijocd?: string
  /** 医療機関コード */
  kikancd?: string
  /** 従事者（担当者） */
  staffid?: string
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 日程番号 */
  nitteino?: number
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コピーフラグ(コピーの場合、true) */
  copyflg: boolean
}
/** 編集可能予約一覧取得処理(詳細画面) */
export interface GetEditYoyakuRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 成人健（検）診予約日程事業コード */
  jigyocd: string
}
/** 保存処理 */
export interface SaveRequest extends InitDetailRequest {
  /** 予定メイン情報 */
  maininfo: DetailSaveVM
  /** 予定定員情報一覧 */
  kekkalist: RowSaveVM[]
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理 */
export interface DeleteRequest extends InitDetailRequest {
  /** 年度 */
  nendo: number
  /** 日程番号 */
  nitteino: number
  /** 更新日時(排他用) */
  upddttm: Date | string
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** 成人健（検）診予約日程事業一覧 */
  selectorlist1: DaSelectorModel[]
  /** 会場一覧 */
  selectorlist2: DaSelectorModel[]
  /** 医療機関一覧 */
  selectorlist3: DaSelectorModel[]
  /** 担当者一覧 */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 列情報 */
  columnInfos: ColumnInfoVM[]
  /** 結果一覧(予約情報) */
  kekkalist: DataInfoVM[][]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends GetEditYoyakuResponse {
  /** 成人健（検）診予約日程事業一覧 */
  selectorlist1: DaSelectorModel[]
  /** 会場一覧 */
  selectorlist2: DaSelectorModel[]
  /** 医療機関一覧 */
  selectorlist3: DaSelectorModel[]
  /** 担当者一覧 */
  selectorlist4: DaSelectorModel[]
  /** 予定メイン情報 */
  maininfo: DetailVM
  /** 予定定員情報一覧 */
  kekkalist: RowVM[]
  /** 支所編集可能フラグ */
  editflg: boolean
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 編集可能予約一覧取得処理(詳細画面) */
export interface GetEditYoyakuResponse extends DaResponseBase {
  /** 予定定員情報一覧(制御用) */
  editlist: RowKeyVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 予定メイン情報(表示用) */
export interface DetailVM extends DetailSaveVM {
  /** 登録支所名称 */
  regsisyonm: string
}
/** 予定メイン情報(保存用) */
export interface DetailSaveVM {
  /** 成人健（検）診予約日程事業(コード：名称) */
  jigyocdnm: string
  /** 実施予定日 */
  yoteiymd: string
  /** 開始時間 */
  timef: string
  /** 終了時間 */
  timet: string
  /** 会場(コード：名称) */
  kaijocdnm: string
  /** 医療機関(コード：名称) */
  kikancdnm: string
  /** 担当者一覧 */
  staffids: string[]
  /** 定員 */
  teiin?: number
}
/** 予定定員情報(表示用) */
export interface RowVM extends RowSaveVM {
  /** 予約分類名称 */
  yoyakubunruinm: string
  //front制御用
  editable: boolean
}
/** 予定定員情報(保存用) */
export interface RowSaveVM extends RowKeyVM {
  /** 定員(検診) */
  teiin_kensin: number | null
}
/** 予定定員情報(制御用) */
export interface RowKeyVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 予約分類コード */
  yoyakubunruicd: string
}
