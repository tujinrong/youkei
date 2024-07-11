/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 各種検診対象者保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.07
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { RowBaseVM as AWKK00101G_RowBaseVM } from '@/views/affect/KK/AWKK00101G/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends PersonSearchRequest {
  /** 年度 */
  nendo: number
}
/** 初期化処理(詳細画面) */
export interface InitRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
  /** 宛名番号 */
  atenano: string
  /** 検診状況一覧(基準日変更可能検診のみ) */
  kekkalist: Row3VM[]
}
/** 保存処理(詳細画面) */
export interface SaveRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 減免区分（特定健診）(コード：名称) */
  genmenkbn_tokuteicdnm: string
  /** 減免区分（がん検診）(コード：名称) */
  genmenkbn_gancdnm: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 対象者一覧 */
  kekkalist: PersonRowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitResponse extends DaResponseBase {
  /** 個人基本情報 */
  headerinfo: GamenHeaderBase2VM
  /** 減免区分（特定健診）(コード：名称) */
  genmenkbn_tokuteicdnm: string
  /** 減免区分（がん検診）(コード：名称) */
  genmenkbn_gancdnm: string
  /** 減免区分（特定健診）一覧 */
  selectorlist1: DaSelectorModel[]
  /** 減免区分（がん検診）一覧 */
  selectorlist2: DaSelectorModel[]
  /** 検診状況一覧 */
  kekkalist: Row2VM[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 検診状況一覧(基準日変更可能検診のみ) */
  kekkalist: RowVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 対象者情報(1行) */
export interface PersonRowVM extends AWKK00101G_RowBaseVM {
  /** 住所 */
  adrs: string
}
/** 検診状況情報(1行)：ベース */
export interface RowBaseVM {
  /** 検診事業コード */
  jigyocd: string
  /** 検査方法コード */
  kensahohocd: string
}
/** 検診状況情報(1行)：レスポンス再表示用 */
export interface RowVM extends RowBaseVM {
  /** 年齢 */
  age: string
  /** 対象サイン */
  sign2: string
}
/** 検診状況情報(1行)：レスポンス表示用 */
export interface Row2VM extends RowVM {
  /** 成人健（検）診事業・検査方法 */
  kensahoho: string
  /** 一時対象サイン */
  sign1: string
  /** 年齢基準日フラグ(false:指定日;true:受診日時点) */
  kijunflg: boolean
  /** 年齢計算基準日 */
  kijunymd: string
}
/** 検診状況情報(1行)：リクエスト用 */
export interface Row3VM extends RowBaseVM {
  /** 年齢計算基準日 */
  kijunymd: string
}
