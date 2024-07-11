/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 住登外者管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.12.04
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum住登区分, Enum住民種別, EnumActionType } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends PersonSearchRequest {
  /** 不詳フラグ */
  fusyoflg: boolean
  /** 登録者(コード：名称) */
  reguser?: string
  /** 登録日時（開始） */
  regdatef?: Date | string
  /** 登録日時（終了） */
  regdatet?: Date | string
  /** 更新者(コード：名称) */
  upduser?: string
  /** 更新日時（開始） */
  upddatef?: Date | string
  /** 更新日時（終了） */
  upddatet?: Date | string
  /** 削除フラグ(コード：名称) */
  delflg?: string
  /** 業務ID(コード：名称) */
  gyomuid?: string
  /** 独自施策システム等ID(コード：名称) */
  dokujisystemid?: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 履歴番号 */
  rirekino: number
  /** 履歴No. */
  rirekinum: number
}
/** 世帯情報処理(詳細画面) */
export interface SearchSetaiRequest extends DaRequestBase {
  /** 世帯番号 */
  setaino: string
}
/** 検索処理(詳細画面--異動ボタン押下最新履歴情報取得処理) */
export interface SearchLasteRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 住登外者詳細_基本情報等タブメイン */
  maininfo: MainInfoVM
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 世帯情報更新処理 */
export interface SaveSeitaiRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 履歴番号 */
  rirekino: number
  /** 同一世帯員情報一覧（宛名番号） */
  seitaidictlist: SeitaiDictVM[]
}
/** 検索処理(詳細画面--郵便情報) */
export interface AutoSetRequest extends DaRequestBase {
  /** 郵便番号 */
  adrs_yubin: string
}
/** 最新個人番号取得処理 */
export interface SearchPersonalRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(詳細画面--異動処理「最新履歴」) */
export interface SearchSeisinDetailRequest extends SearchDetailRequest {
  /** 異動年月日 */
  idoymd: string
  /** 異動事由 */
  idojiyu: string
}
/** 自動付番処理（世帯番号及び宛名番号の自動採番） */
export interface AutoSaibanRequest extends DaRequestBase {
  /** 自動付番フラグ */
  seqflg: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(検索条件) */
export interface InitListResponse extends DaResponseBase {
  /** 生年月日不詳フラグフラグ */
  fusyoflg: boolean
  /** ドロップダウンリスト(登録者) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(更新者) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(削除フラグ) */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(業務ID) */
  selectorlist4: DaSelectorModel[]
  /** ドロップダウンリスト(独自施策システム等ID) */
  selectorlist5: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(住登外者一覧) */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 住登外者詳細_基本情報等タブリスト初期化 */
  initdetail: InitDetailVM
}
/** 世帯検索処理(詳細画面) */
export interface SearchSetaiResponse extends DaResponseBase {
  /** 世帯情報（詳細画面） */
  setaiInfo: SetaiInfoVM
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 総履歴数 */
  rirekitotal: number
  /** 履歴No. */
  rirekinum: number
  /** 住登外者詳細_ヘッダー部情報 */
  baseinfo: BaseInfoVM
  /** 住登外者詳細_基本情報等タブメイン */
  maininfo: MainInfoVM
}
/** 保存/削除処理(詳細画面) */
export interface CommonResponse extends DaResponseBase {
  /** 宛名番号 */
  atenano: string
  /** 履歴番号 */
  rirekino: number
  /** 同一世帯員情報一覧（宛名番号、氏名） */
  seitaidictlist: SeitaiDictVM[]
}
/** 自動入力処理(詳細画面--郵便情報) */
export interface AutoSetResponse extends DaResponseBase {
  /** 住登外者詳細_基本情報（郵便情報） */
  yubininfo: YubinInfoVM
}
/** 検索処理(個人番号) */
export interface SearchPersonalResponse extends DaResponseBase {
  /** 個人番号 */
  personalno?: string
}
/** 検索処理(自動付番) */
export interface SearchAutoSaibanResponse extends DaResponseBase {
  /** 世帯番号および宛名番号 */
  seqno?: string
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM {
  /** 宛名番号 */
  atenano: string
  /** 履歴番号 */
  rirekino: number
  /** 削除 */
  stopflg: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別（名称） */
  sexhyoki: string
  /** 住民区分（住民種別内容、住民状態内容） */
  juminkbn: string
  /** 生年月日 */
  bymd: string
  /** 住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書) */
  adrs: string
  /** 警告内容 */
  keikoku: string
}
/** 住登外者詳細_ヘッダー部(メイン：ベース) */
export interface BaseInfoVM {
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
  /** 住民区分（内容） */
  juminkbnnm: string
  /** 年齢 */
  age: string
  /** 年齡計算基準日 */
  agekijunymd: string
  /** 課税非課税区分（世帯） */
  kazeikbn_setai: string
  /** 保険区分（名称） */
  hokenkbn: string
  /** 削除 */
  stop: string
  /** 警告有無 */
  keikoku: string
}
/** 初期化処理(詳細画面) */
export interface InitDetailVM {
  // /** 生年月日不詳フラグフラグ */
  // fusyoflg: boolean
  /** ドロップダウンリスト(異動事由) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(行政区等) */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(市区町村)(市区町村コード、都道府県＋市区名、都道府県、市区名) */
  selectorlist3: DaSelectorModelExp[]
  /** ドロップダウンリスト(町字) */
  selectorlist4: DaSelectorKeyModel[]
  /** ドロップダウンリスト(住民種別) */
  selectorlist5: DaSelectorModel[]
  /** ドロップダウンリスト(住民状態) */
  selectorlist6: DaSelectorModel[]
  /** ドロップダウンリスト(性別) */
  selectorlist7: DaSelectorModel[]
  /** ドロップダウンリスト(国名等) */
  selectorlist8: DaSelectorModel[]
  /** ドロップダウンリスト(保険区分) */
  selectorlist9: DaSelectorModel[]
  /** ドロップダウンリスト(他業務参照不可) */
  selectorlist10: DaSelectorModel[]
  /** 参照独自施策システム等リスト */
  dokujisystemnmlist: DaSelectorModel[]
  /** 参照業務リスト */
  sansyogyomunmlist: DaSelectorModel[]
  /** ドロップダウンリスト(名寄せ元) */
  selectorlist11: DaSelectorModel[]
  /** ドロップダウンリスト(統合宛名フラグ) */
  selectorlist12: DaSelectorModel[]
  /** ドロップダウンリスト(登録部署) */
  selectorlist13: DaSelectorModel[]
}
/** 住登外者詳細_基本情報等タブ（メイン：保存用） */
export interface MainInfoVM {
  /** 履歴番号 */
  rirekino: number
  /** 更新日時(排他も利用) */
  upddttm: null | string
  /** 最新 */
  saisin: string
  /** 削除 */
  stop: string
  /** 異動年月日 */
  idoymd?: string
  /** 異動届出年月日 */
  idotodokeymd: string
  /** 異動事由 */
  idojiyu: string
  /** 世帯番号（I/O） */
  setaino: string
  /** 世帯主名 */
  senusinm: string
  /** 郵便番号（I/O） */
  adrs_yubin?: string
  /** 指定都市_行政区等コード（I/O） */
  tosi_gyoseikucd?: string
  /** 市区町村（I/O） */
  adrs_sikucd?: string
  /** 都道府県 */
  adrs_todofuken?: string
  /** 市区町村名 */
  adrs_sikunm?: string
  /** 町字コード（I/O） */
  adrs_tyoazacd: string
  /** 町字名（I/O） */
  adrs_tyoaza?: string
  /** 番地号表記（I/O） */
  adrs_bantihyoki?: string
  /** 方書(フリガナ)（I/O） */
  adrs_katagaki_kana?: string
  /** 方書(漢字)（I/O） */
  adrs_katagaki?: string
  /** 宛名番号（I/O） */
  atenano: string
  /** 個人番号（I/O） */
  personalno?: string
  /** 住登外者種別（I/O） */
  jutogaisyasyubetu: string
  /** 住登外者状態（I/O） */
  jutogaisyajotai: string
  /** 住民区分 */
  juminkbn: string
  /** 氏_日本人_フリガナ（I/O） */
  si_kana?: string
  /** 名_日本人_フリガナ（I/O） */
  mei_kana?: string
  /** 氏_日本人（I/O） */
  si?: string
  /** 名_日本人（I/O） */
  mei?: string
  /** 氏名_フリガナ（I/O） */
  simei_kana?: string
  /** 氏名_外国人漢字（I/O） */
  simei_gaikanji?: string
  /** 氏名_外国人ローマ字（I/O） */
  simei_gairoma?: string
  /** 通称_フリガナ（I/O） */
  tusyo_kana?: string
  /** 通称漢字（I/O） */
  tusyo?: string
  /** 通称_フリガナ確認状況（I/O） */
  tusyo_kanastatus?: string
  /** 性別（I/O） */
  sex: string
  /** 生年月日（I/O） */
  bymd?: string
  /** 生年月日_不詳フラグ（I/O） */
  bymd_fusyoflg: boolean
  /** 生年月日(不詳表記)（I/O） */
  bymd_fusyohyoki?: string
  /** 住所_国名コード（I/O） */
  adrs_kokunmcd?: string
  /** 住所_国名等 */
  adrs_kokunm: string
  /** 住所_国外住所（I/O） */
  adrs_gaiadrs?: string
  /** 保険区分（I/O） */
  hokenkbn?: string
  /** 他業務参照不可（I/O） */
  sansyofuka: string
  /** 参照独自施策システム等リスト(コード)（I/O） */
  dokujisystemcdlist: RefListVM[]
  /** 参照業務リスト(コード)（I/O） */
  sansyogyomucdlist: RefListVM[]
  /** 名寄せ元（I/O） */
  nayosemotoflg: string
  /** 名寄せ先宛名番号（I/O） */
  nayosesakiatenano?: string
  /** 統合宛名フラグ */
  togoatenaflg: string
  /** 登録部署（I/O） */
  regbusyocd: string
}
/** 宛名情報（保存用） */
export interface AtenaInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 世帯番号 */
  setaino: string
  /** 住登区分2 */
  jutokbn: Enum住登区分
  /** 住民種別 */
  juminsyubetu: Enum住民種別
  /** 住民状態 */
  juminjotai: string
  /** 住民区分 */
  juminkbn: string
  /** 氏名 */
  simei: string
  /** 氏名_フリガナ */
  simei_kana?: string
  /** 通称 */
  tusyo?: string
  /** 通称_フリガナ */
  tusyo_kana?: string
  /** 氏名_優先 */
  simei_yusen: string
  /** 氏名_フリガナ_優先 */
  simei_kana_yusen?: string
  /** 性別 */
  sex: string
  /** 性別表記 */
  sexhyoki?: string
  /** 生年月日 */
  bymd?: string
  /** 生年月日_不詳フラグ */
  bymd_fusyoflg?: boolean
  /** 生年月日_不詳表記 */
  bymd_fusyohyoki?: string
  /** 住登外：「未設定」 */
  zokuhyoki: string
  /** 住所_市区町村コード */
  adrs_sikucd: string
  /** 住所_町字コード */
  adrs_tyoazacd: string
  /** 指定都市_行政区等コード */
  tosi_gyoseikucd?: string
  /** 住所1 */
  adrs1: string
  /** 住所2 */
  adrs2?: string
  /** 住所_方書コード */
  adrs_katagakicd?: string
  /** 住所_郵便番号 */
  adrs_yubin: string
  /** 個人番号 */
  personalno?: string
}
/** 参照業務リストと参照独自施策システム等リスト用 */
export interface RefListVM {
  /** 汎用コード */
  hanyocd: string
  /** 名称 */
  nm: string
}
/**世帯情報モデル */
export interface SetaiInfoVM {
  /** 世帯番号 */
  setaino: string
  /** 世帯主氏名(氏名_優先) */
  simei_yusen: string
  /** 住所_郵便番号 */
  adrs_yubin: string
  /** 指定都市_行政区等コード */
  tosi_gyoseikucd?: string
  /** 住所_市区町村コード */
  adrs_sikucd: string
  /** 住所_都道府県 */
  adrs_todofuken: string
  /** 住所_市区郡町村名 */
  adrs_sikunm: string
  /** 住所_町字コード */
  adrs_tyoazacd: string
  /** 町字名 */
  adrs_tyoaza: string
  /** 番地号表記 */
  adrs_bantihyoki: string
  /** 方書(フリガナ)   */
  adrs_katagaki_kana: string
  /** 方書(漢字)    */
  adrs_katagaki: string
}
/** 編集状態モデル */
export interface StatusVM {
  /** 状態区分 */
  statuskbn: EnumActionType
}
/** 住登外者詳細_基本情報（世帯情報） */
export interface SeitaiInfoVM {
  /** 世帯番号（I/O） */
  setaino: string
  /** 郵便番号（I/O） */
  adrs_yubin?: string
  /** 指定都市_行政区等コード（I/O） */
  tosi_gyoseikucd?: string
  /** 市区町村（I/O） */
  adrs_sikucd?: string
  /** 町字コード（I/O） */
  adrs_tyoazacd: string
  /** 町字名（I/O） */
  adrs_tyoaza?: string
  /** 番地号表記（I/O） */
  adrs_bantihyoki?: string
  /** 方書(フリガナ)（I/O） */
  adrs_katagaki_kana?: string
  /** 方書(漢字)（I/O） */
  adrs_katagaki?: string
  /** 都道府県 */
  adrs_todofuken?: string
  /** 市区町村名 */
  adrs_sikunm?: string
}
/** 住登外者詳細_基本情報（郵便情報） */
export interface YubinInfoVM {
  /** 市区町村コード */
  adrs_sikucd?: string
  /** 町字コード */
  adrs_tyoazacd: string
  /** 町字名 */
  adrs_tyoaza?: string
  /** 都道府県 */
  adrs_todofuken?: string
  /** 市区町村名 */
  adrs_sikunm?: string
}
/** 住登外者詳細_基本情報（異動情報） */
export interface IdoInfoVM {
  /** 異動年月日 */
  idoymd: string
  /** 異動届出年月日 */
  idotodokeymd: string
  /** 異動事由 */
  idojiyu: string
}
/** 住登外者詳細_同一世帯員情報 */
export interface SeitaiDictVM {
  /** 宛名番号 */
  atenano: string
}

export interface DaSelectorModelExp extends DaSelectorModel {
  expname1: string
  expname2: string
}
