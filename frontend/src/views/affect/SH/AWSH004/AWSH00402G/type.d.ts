/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 健
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.27
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { SearchListRequest as SearchListRequest_401 } from '../AWSH00401G/type'
import { Enum編集区分, Enum対象区分, EnumMsgCtrlKbn } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(日程一覧画面) */
export interface SearchListRequest extends SearchListRequest_401 {
  /** 宛名番号 */
  atenano?: string
  /** 個人番号 */
  personalno?: string
}
/** 初期化処理(予約者一覧画面) */
export interface InitPersonListRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 日程番号 */
  nitteino: number
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 日程番号 */
  nitteino: number
  /** 宛名番号 */
  atenano: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 定員チェック処理(詳細画面) */
export interface CheckTeiinRequest extends InitDetailRequest {
  /** 予約情報一覧(日程番号が画面のデータのみ) */
  kekkalist: DetailRowKeyVM[]
}
/** 計算処理 */
export interface CalculateRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 宛名番号 */
  atenano: string
  /** 予約情報一覧 */
  kekkalist: MoneyKeyBase2VM[]
}
/** 保存処理 */
export interface SaveRequest extends InitDetailRequest {
  /** 備考 */
  biko: string
  /** 予約情報一覧(日程番号があるデータのみ) */
  kekkalist: DetailRowSaveVM[]
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
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
/** 初期化処理(予約者一覧画面) */
export interface InitPersonListResponse extends DaResponseBase {
  /** 日程基本情報 */
  headerinfo: HeaderVM
  /** 結果一覧(予約情報) */
  kekkalist1: RowVM[]
  /** 列情報 */
  columnInfos: ColumnInfoVM[]
  /** 結果一覧(予約者情報) */
  kekkalist2: DataInfoVM[][]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends CalculateResponse {
  /** 日程基本情報 */
  headerinfo: HeaderVM
  /** 希望者情報 */
  personinfo: PersonVM
  /** 備考 */
  biko: string
  /** 更新日時(排他用) */
  upddttm?: Date | string
  /** 予約一覧 */
  kekkalist: DetailRowVM[]
}
/** 定員チェック処理 */
export interface CheckTeiinResponse extends DaResponseBase {
  /** 待機変更必要検診事業一覧 */
  kekkalist: string[]
  /** 全体定員オーバーフラグ */
  overflg: boolean
}
/** 計算処理 */
export interface CalculateResponse extends DaResponseBase {
  /** 自己負担金情報 */
  moneyinfo: MoneyVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 日程基本情報 */
export interface HeaderVM {
  /** 成人健（検）診予約日程事業名 */
  jigyonm: string
  /** 実施予定日 */
  yoteiymd: string
  /** 開始時間 */
  timef: string
  /** 終了時間 */
  timet: string
  /** 会場名 */
  kaijonm: string
  /** 医療機関名 */
  kikannm: string
  /** 担当者一覧 */
  staffnms: string
}
/** 予約情報 */
export interface RowVM {
  /** タイトル */
  title: string
  /** 状態 */
  status: string
  /** 定員 */
  teiin: string
  /** 申込人数 */
  moshikominum: string
  /** 待機数 */
  taikinum: string
}
/** 希望者情報 */
export interface PersonVM extends CommonBarHeaderBase3VM {
  /** 課税非課税区分（世帯） */
  kazeikbn_setai: string
  /** 保険区分 */
  hokenkbn: string
  /** 減免区分（特定健診） */
  genmenkbn_tokutei: string
  /** 減免区分（がん検診） */
  genmenkbn_gan: string
}
/** 予約情報(保存用) */
export interface DetailRowSaveVM extends DetailRowKeyVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 検査方法(コード：名称) */
  kensahohocdnm: string
  /** 日程番号 */
  nitteino?: number
  /** 待機フラグ */
  taikiflg: boolean
  /** 初回受付日 */
  syokaiuketukeymd: string
  /** 受付変更日 */
  henkouketukeymd: string
}
/** 予約情報(表示用) */
export interface DetailRowVM extends DetailRowSaveVM {
  /** 検診名 */
  jigyonm: string
  /** 実施予定日 */
  yoteiymd: string
  /** 時間範囲 */
  time: string
  /** 状態 */
  status: string
  /** クーポン */
  cupon: string
  /** 予約画面チェック区分 */
  yoyakuchk: EnumMsgCtrlKbn
  /** 検査方法一覧 */
  selectorlist: DaSelectorDisabledModelSign[]
  /** 編集フラグ(false:①該当日程事業含まない検診②検査方法全て対象外③受診済) */
  editflg: boolean
}
interface DaSelectorDisabledModelSign extends DaSelectorDisabledModel {
  /** 対象サイン */
  sign: string
  /** 昨年フラグ(false:受診済) */
  flg1: boolean
  /** 今年フラグ(false:受診済) */
  flg2: boolean
}
/** 予約情報(チェック用) */
export interface DetailRowKeyVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 検査方法コード(コード：名称) */
  kensahohocdnm: string
}
/** 対象検査方法 */
export interface Row2VM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 検査方法コード */
  kensahohocd: string
  /** 昨年フラグ(false:受診済) */
  flg1: boolean
  /** 今年フラグ(false:受診済) */
  flg2: boolean
  /** 対象フラグ(true:対象) */
  flg3: boolean
}
/** 自己負担金 */
export interface MoneyVM {
  /** 受診金額 */
  jusinkingaku: string
  /** （市区町村負担）金額 */
  kingaku_sityosonhutan: string
}
/** 自己負担金キー */
export interface MoneyKeyVM extends MoneyKeyBase3VM {
  /** 料金パターン */
  ryokinpattern: string
  /** 減免区分 */
  genmenkbn: string
  /** 年齢計算基準日 */
  kijunymd: string
}
/** 自己負担金キー */
export interface MoneyKeyBaseVM {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 日程番号 */
  nitteino: number
}
/** 自己負担金キー(インタフェース用) */
export interface MoneyKeyBase2VM extends MoneyKeyBaseVM {
  /** 検査方法(コード：名称) */
  kensahohocdnm: string
}
/** 自己負担金キー(ロジック用) */
export interface MoneyKeyBase3VM extends MoneyKeyBaseVM {
  /** 検査方法コード */
  kensahohocd: string
}
