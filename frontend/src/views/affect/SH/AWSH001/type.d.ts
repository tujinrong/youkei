/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 共通ロジック(検診)
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.07.04
 * 作成者　　: 劉
 * 変更履歴　:
 * -----------------------------------------------------------------*/
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
}
/** 検索処理(一覧画面) */
export interface SearchRequest extends PersonSearchRequest {
  /** 年度 */
  nendo: number
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends InitListRequest {
  /** 宛名番号 */
  atenano: string
  /** 検診回数 */
  kensinkaisu?: number
  /** 遷移区分 */
  kbn: import('#/Enums').Enum遷移区分
}
/** 保存処理(詳細画面) */
export interface SaveRequest extends InitListRequest {
  /** 宛名番号 */
  atenano: string
  /** 検診回数 */
  kensinkaisu: number
  /** 編集区分(一次) */
  editflg1: boolean | null
  /** 編集区分(精密) */
  editflg2: boolean | null
  /** 該当回目の検診結果 */
  kekka: KsTimeUpdateVM
  /** データフラグ(一次：データ存在) */
  dataflg1: boolean
  /** データフラグ(精密：データ存在) */
  dataflg2: boolean
  /** チェックフラグ */
  checkflg: boolean
}
/** 削除処理(詳細画面) */
export interface DeleteRequest extends InitListRequest {
  /** 宛名番号 */
  atenano: string
  /** 検診回数(1件削除) */
  kensinkaisu?: number
  /** キーリスト(排他用) */
  locklist: KsLockVM[]
  /** 削除区分 */
  delkbn: import('#/Enums').Enum削除区分
}
/** 基準値取得処理 */
export interface GetKijunRequest extends InitListRequest {
  /** 宛名番号 */
  atenano: string
  /** 実施日(一次) */
  jissiymd1?: Date | string
  /** 実施日(精密) */
  jissiymd2?: Date | string
  /** 検査方法(一次固定)(コード：名称) */
  kensahoho1?: string
  /** フリー項目リスト */
  freeitemlist: KjFreeItemVM[]
}
/** 実施年齢取得処理 */
export interface GetAgeRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 実施日 */
  jissiymd?: Date | string
}
/** 精密検診チェック処理 */
export interface SeiKenEditCheckRequest extends DaRequestBase {
  /** 結果項目一覧(一次) */
  kekkalist: KsKekkaItemVM[]
  /** old結果項目一覧(一次) */
  oldlist?: KsKekkaItemVM[]
  /** データフラグ(一次：データ存在) */
  dataflg1: boolean
  /** データフラグ(精密：データ存在) */
  dataflg2: boolean
}
/** 新規追加権限チェック処理(詳細画面) */
export interface AuthCheckRequest extends InitListRequest {
  /** 宛名番号 */
  atenano: string
}
/** 計算処理 */
export interface CalculateRequest extends DaRequestBase {
  /** 結果項目一覧(全部) */
  kekkalist: KsKekkaItemVM[]
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** 表示フラグ(精密) */
  showflg1: boolean
}
/** 検索処理(一覧画面) */
export interface SearchResponse extends CmSearchResponseBase {
  /** 検診結果 */
  kekkalist: KsRowVM[]
  /** 遷移フラグ */
  transflg: boolean
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends InitListResponse {
  /** 表示フラグ(クーポン) */
  showflg2: boolean
  /** 表示フラグ(一次検査方法) */
  showflg3: boolean
  /** 個人基本情報 */
  headerinfo: KsHeaderVM
  /** 該当回目の検診結果 */
  kekka: KsTimeSearchVM
  /** キーリスト(全ての回目) */
  keylist: KsLockVM[]
  /** 成人保健フリー項目グループ１リスト */
  grouplist1: DaSelectorModel[]
  /** 成人保健フリー項目グループ２リスト */
  grouplist2: DaSelectorModel[]
  /** ドロップダウンリスト(検査方法) */
  selectorlist: DaSelectorModel[]
  /** クーポン番号 */
  coupon?: string
  /** 複数可能フラグ */
  addflg: boolean
  /** 編集フラグ(一次) */
  editflg1: boolean
  /** 編集フラグ(精密) */
  editflg2: boolean
  /** 削除フラグ(削除ボタン) */
  delflg: boolean
  /** エラーメッセージID */
  errormsgid: string
  /** アラートメッセージID */
  alertmsgid: string
}
/** 保存/削除処理(詳細画面) */
export interface CommonResponse extends DaResponseBase {
  /** 宛名番号 */
  atenano: string
  /** 状態一覧(編集後) */
  statuslist: KsStatusVM[]
}
/** 基準値取得処理 */
export interface GetKijunResponse extends DaResponseBase {
  /** 項目基準値リスト */
  kekkalist: KjItemVM[]
}
/** 実施年齢取得処理 */
export interface GetAgeResponse extends DaResponseBase {
  /** 実施年齢 */
  jissiage: number
}
/** 精密検診チェック処理 */
export interface SeiKenEditCheckResponse extends DaResponseBase {
  /** 編集フラグ(精密：一次結果) */
  editflg3: boolean
}
/** 新規追加権限チェック処理(詳細画面) */
export interface AuthCheckResponse extends DaResponseBase {
  /** 新規追加権限チェックフラグ */
  authflg: boolean
}
/** 計算処理 */
export interface CalculateResponse extends DaResponseBase {
  /** 結果項目一覧(計算されたデータのみ) */
  kekkalist: KsCalculateVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検診結果一覧データモデル(行単位) */
export interface KsRowVM {
  /** 編集状態 */
  status?: string
  /** 検診回数 */
  kensinkaisu?: number
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sex: string
  /** 生年月日 */
  bymd: string
  /** 住所 */
  adrs: string
  /** 行政区 */
  gyoseiku: string
  /** 住民区分 */
  juminkbn: string
  /** 実施日(一次) */
  jissiymd1?: Date | string
  /** 実施日(精密) */
  jissiymd2?: Date | string
  /** 警告内容 */
  keikoku: string
}
/** 検診詳細排他チェック用モデル */
export interface KsLockVM {
  /** 検診回数 */
  kensinkaisu?: number
  /** 更新日時(一次) */
  upddttm1?: Date | string
  /** 更新日時(精密) */
  upddttm2?: Date | string
}
/** 検診詳細情報モデル(回目単位)：ベース情報 */
export interface KsTimeVM extends KsLockVM {
  /** 実施日(一次) */
  jissiymd1?: Date | string
  /** 実施日(精密) */
  jissiymd2?: Date | string
  /** 登録支所(一次固定) */
  regsisyo1?: string
  /** 登録支所(精密固定) */
  regsisyo2?: string
  /** 登録支所名(一次固定) */
  regsisyonm1?: string
  /** 登録支所名(精密固定) */
  regsisyonm2?: string
  /** 実施年齢(一次固定) */
  jissiage1?: number | null
  /** 実施年齢(精密固定) */
  jissiage2?: number | null
  /** 検査方法(一次固定)(コード：名称) */
  kensahoho1?: string
  /** 検査方法(精密固定)(コード：名称) */
  kensahoho2?: string
}
/** 個人基本情報(詳細画面) */
export interface KsHeaderVM {
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別  */
  sexhyoki: string
  /** 生年月日 */
  bymd: string
  /** 住民区分 */
  juminkbn: string
  /** 年齢 */
  age: string
  /** 年齡計算基準日 */
  agekijunymd: string
  /** 個人番号 */
  personalno: string
  /** 警告内容 */
  keikoku: string
  /** 健（検）診予約希望者詳細フラグ */
  kensinkibosyasyosaiflg: boolean
}
/** 詳細情報モデル(回目単位)：検索 */
export interface KsTimeSearchVM extends KsTimeVM {
  /** 項目リスト(一次固定) */
  itemlist1: KsFixItemVM[]
  /** 項目リスト(精密固定) */
  itemlist2: KsFixItemVM[]
  /** 項目リスト(フリー) */
  itemlist3: KsFreeItemVM[]
}
/** 詳細情報モデル(回目単位)：更新 */
export interface KsTimeUpdateVM extends KsTimeVM {
  /** 項目リスト(一次) */
  itemlist1: KsItemUpdVM[]
  /** 項目リスト(精密) */
  itemlist2: KsItemUpdVM[]
  /** 結果項目一覧(一次) */
  kekkalist: KsKekkaItemVM[]
}
/** フリー項目モデル(更新) */
export interface KsItemUpdVM extends FreeItemUpdBaseVM {
  /** 検診回数 */
  kensinkaisu?: number
}
/** フリー項目モデル(初期化)：固定 */
export interface KsFixItemVM extends FixFreeItemBaseVM {
  /** 検診回数 */
  kensinkaisu?: number
  /** 利用検査方法コード一覧 */
  riyokensahohocds: string[]
  /** 項目特定区分 */
  komokutokuteikbn?: string
}
/** フリー項目モデル(初期化)：フリー */
export interface KsFreeItemVM extends KsFixItemVM {
  /** グループID */
  groupid: import('#/Enums').EnumKensinKbn
  /** グループID2 */
  groupid2: string
  /** 拡張(フロントエンド) */
  kijun?: KjItemVM
}
/** 編集状態モデル */
export interface KsStatusVM {
  /** 状態区分 */
  statuskbn: import('#/Enums').EnumActionType
  /** 検診回数(編集前) */
  kensinkaisubefore?: number
  /** 検診回数(編集後) */
  kensinkaisuafter?: number
}
/** 検診フリー項目(結果項目) */
export interface KsKekkaItemVM {
  /** 項目コード */
  itemcd: string
  /** 値(コード：名称) */
  value?: string
}
/** 検診フリー項目(計算用) */
export interface KsCalculateVM {
  /** 項目コード */
  itemcd: string
  /** 値*/
  value?: any
}

/** 検診フリー項目(キー) */
export interface KjFreeItemVM {
  /** 項目コード */
  itemcd: string
  /** グループID */
  groupid: import('#/Enums').EnumKensinKbn
}
