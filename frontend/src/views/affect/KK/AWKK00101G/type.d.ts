/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 基幹系他システム情報照会
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.10.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum住登区分, Enum住民種別 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(世帯一覧)・初期化処理(詳細画面) */
export interface CommonRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(詳細画面：共通) */
export interface SearchCommonRequest extends CommonRequest {
  /** 履歴No. */
  rirekinum: number
}
/** 検索処理(詳細画面：税額控除タブ全体) */
export interface SearchKojoDetailRequest extends CmSearchRequestBase {
  /** 履歴No. */
  rirekinum: number
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(詳細画面：税額控除タブ明細) */
export interface SearchKojoDetailRowsRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 課税年度 */
  kazeinendo: number
  /** 税額控除情報履歴番号 */
  kojorirekino: number
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchPersonListResponse extends CmSearchResponseBase {
  /** 住民・住登外一覧 */
  kekkalist: PersonRowVM[]
}
/** 検索処理(世帯一覧) */
export interface SearchSetaiListResponse extends DaResponseBase {
  /** 世帯主情報 */
  headerinfo: SetaiHeaderVM
  /** 世帯成員一覧 */
  kekkalist: SetaiRowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 住民情報(ヘッダー) */
  headerinfo: PersonHeaderVM
}
/** 検索処理(詳細画面：ベース) */
export interface SearchDetailResponseBase extends DaResponseBase {
  /** 総履歴数 */
  rirekitotal: number
  /** 履歴No. */
  rirekinum: number
}
/** 検索処理(詳細画面：住基タブ) */
export interface SearchJuminDetailResponse extends SearchDetailResponseBase {
  /** 住民情報 */
  detailinfo: JuminVM
}
/** 検索処理(詳細画面：課税・納税義務者タブ_課税) */
export interface SearchKaZeiDetailResponse extends SearchDetailResponseBase {
  /** 課税情報 */
  detailinfo: KazeiVM
}
/** 検索処理(詳細画面：課税・納税義務者タブ_納税) */
export interface SearchNoZeiDetailResponse extends SearchDetailResponseBase {
  /** 納税義務者情報 */
  detailinfo: NozeiVM
}
/** 検索処理(詳細画面：税額控除タブ全体) */
export interface SearchKojoDetailResponse extends SearchKojoDetailRowsResponse {
  /** 総履歴数 */
  rirekitotal: number
  /** 履歴No. */
  rirekinum: number
  /** 控除情報(ヘッダー) */
  detailheaderinfo: KojoHeaderVM
}
/** 検索処理(詳細画面：税額控除タブ明細) */
export interface SearchKojoDetailRowsResponse extends CmSearchResponseBase {
  /** 控除情報(明細) */
  kekkalist: KojoRowVM[]
}
/** 検索処理(詳細画面：国保タブ) */
export interface SearchKokuhoDetailResponse extends SearchDetailResponseBase {
  /** 国保情報 */
  detailinfo: KokuhoVM
}
/** 検索処理(詳細画面：後期タブ) */
export interface SearchKokiDetailResponse extends SearchDetailResponseBase {
  /** 後期情報 */
  detailinfo: KokiVM
}
/** 検索処理(詳細画面：生保タブ) */
export interface SearchSeihoDetailResponse extends SearchDetailResponseBase {
  /** 生保情報 */
  detailinfo: SeihoVM
}
/** 検索処理(詳細画面：介護タブ) */
export interface SearchKaigoDetailResponse extends SearchDetailResponseBase {
  /** 介護情報 */
  detailinfo: KaigoVM
}
/** 検索処理(詳細画面：福祉タブ) */
export interface SearchSyogaiDetailResponse extends SearchDetailResponseBase {
  /** 障害情報 */
  detailinfo: SyogaiVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面ベース) */
export interface RowBaseVM {
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
  /** 住民区分 */
  juminkbn: string
  /** 警告内容 */
  keikoku: string
  /** 住登区分 */
  jutokbn: Enum住登区分
}
/** 検索処理(一覧画面) */
export interface PersonRowVM extends RowBaseVM {
  /** 住所 */
  adrs: string
  /** 行政区 */
  gyoseiku: string
}
/** 検索処理(世帯一覧：ヘッダー) */
export interface SetaiHeaderVM {
  /** 世帯番号 */
  setaino: string
  /** カナ氏名 */
  kname: string
  /** 氏名 */
  name: string
  /** 課税非課税区分（世帯） */
  kazeikbn_setai: string
  /** 指定都市_行政区等(コード：名称) */
  tosi_gyoseiku: string
  /** 郵便番号 */
  adrs_yubin: string
  /** 住所 */
  adrs: string
  /** 地区一覧(ラベル、値) */
  tikulist: TikuVM[]
}
/** 検索処理(世帯一覧) */
export interface SetaiRowVM extends RowBaseVM {
  /** 年齢 */
  age: string
  /** 続柄 */
  zokuhyoki: string
  /** 保険区分 */
  hokenkbn: string
  /** 課税区分 */
  kazeikbn: string
}
/** 初期化処理(詳細画面) */
export interface PersonHeaderVM extends CommonBarHeaderBase2VM {
  /** 課税非課税区分（世帯） */
  kazeikbn_setai: string
  /** 保険区分 */
  hokenkbn: string
}
/** 住民情報(住基タブ) */
export interface JuminVM {
  /** 個人履歴番号 */
  kojinrirekino: number
  /** 個人履歴番号_枝番号 */
  kojinrireki_edano: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 世帯番号 */
  setaino: string
  /** 世帯主名(最新) */
  senusinm: string
  /** 個人番号 */
  personalno: string
  /** 宛名番号 */
  atenano: string
  /** 住民種別 */
  juminsyubetu: Enum住民種別
  /** 住民種別(名称) */
  juminsyubetunm: string
  /** 住民状態 */
  juminjotai: string
  /** 氏名優先区分(外国人のみ) */
  simeiyusenkbn: string
  /** 国籍名等(外国人のみ) */
  kokunm: string
  /** 氏名_フリガナ */
  simei_kana: string
  /** 氏名 */
  simei: string
  /** 氏名_外国人漢字(外国人のみ) */
  simei_gaikanji: string
  /** 氏名_外国人ローマ字(外国人のみ) */
  simei_gairoma: string
  /** 通称_フリガナ(外国人のみ) */
  tusyo_kana: string
  /** 通称(外国人のみ) */
  tusyo: string
  /** 生年月日(不詳自動変換) */
  bymd: string
  /** 生年月日_不詳表記 */
  bymd_fusyohyoki: string
  /** 続柄表記 */
  zokuhyoki: string
  /** 旧氏_フリガナ(日本人のみ) */
  kyusi_kana: string
  /** 旧氏(日本人のみ) */
  kyusi: string
  /** 住所_郵便番号 */
  adrs_yubin: string
  /** 指定都市_行政区等(名称) */
  tosi_gyoseikunm: string
  /** 住所_方書_フリガナ */
  adrs_katagaki_kana: string
  /** 住所(住所_町字、住所_番地号表記、住所_方書) */
  adrs: string
  /** 地区一覧(ラベル、値) */
  tikulist: TikuVM[]
  /** 第30条45規定区分(外国人のみ) */
  kiteikbn: string
  /** 在留資格等(名称)(外国人のみ) */
  zairyu: string
  /** 在留期間（年）(外国人のみ) */
  zairyu_year: string
  /** 在留期間（月）(外国人のみ) */
  zairyu_month: string
  /** 在留期間（日）(外国人のみ) */
  zairyu_day: string
  /** 在留期間の満了の日(外国人のみ) */
  zairyumanryoymd: string
  /** 住民となった年月日(不詳自動変換)(日本人のみ) */
  juymd: string
  /** 住民となった年月日_不詳表記(日本人のみ) */
  juymd_fusyohyoki: string
  /** 外国人住民となった年月日(不詳自動変換)(外国人のみ) */
  gaijuymd: string
  /** 外国人住民となった年月日_不詳表記(外国人のみ) */
  gaijuymd_fusyohyoki: string
  /** 転入通知年月日 */
  tennyututiymd: string
  /** 消除の異動年月日(不詳自動変換) */
  delidoymd: string
  /** 消除の異動年月日_不詳表記 */
  delidoymd_fusyohyoki: string
  /** 消除の届出年月日 */
  todokeymd: string
  /** 異動年月日(不詳自動変換) */
  idoymd: string
  /** 異動年月日_不詳表記 */
  idoymd_fusyohyoki: string
  /** 異動届出年月日 */
  idotodokeymd: string
  /** 異動事由 */
  idojiyu: string
  /** 転入前住所_郵便番号 */
  tennyumaeadrs_yubin: string
  /** 転入前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書) */
  tennyumaeadrs: string
  /** 転入前住所_国名等 */
  tennyumaeadrs_kokunm: string
  /** 転入前住所_国外住所 */
  tennyumaeadrs_gaiadrs: string
  /** 転入前住所_世帯主氏名 */
  tennyumaeadrs_senusisimei: string
  /** 転出先住所（予定）_郵便番号 */
  tensyutuyoteiadrs_yubin: string
  /** 転出先住所（予定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書) */
  tensyutuyoteiadrs: string
  /** 転出先住所（予定）_国名等 */
  tensyutuyoteiadrs_kokunm: string
  /** 転出先住所（予定）_国外住所 */
  tensyutuyoteiadrs_gaiadrs: string
  /** 転出先住所（確定）_郵便番号 */
  tensyutukakuteiadrs_yubin: string
  /** 転出先住所（確定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書) */
  tensyutukakuteiadrs: string
  /** 転居前住所_郵便番号 */
  tenkyomaeadrs_yubin: string
  /** 転居前住所_方書_フリガナ */
  tenkyomaeadrs_katagaki_kana: string
  /** 転居前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書) */
  tenkyomaeadrs: string
}
/** 課税情報(課税・納税義務者タブ) */
export interface KazeiVM {
  /** 課税年度 */
  kazeinendo: number
  /** 課税情報履歴番号 */
  kazeirirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 課税非課税区分 */
  kazeikbn: string
  /** 指定都市_行政区等(コード：名称) */
  tosi_gyoseiku: string
}
/** 納税義務者情報(課税・納税義務者タブ) */
export interface NozeiVM {
  /** 課税年度 */
  kazeinendo: number
  /** 個人履歴番号 */
  kojinrirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 未申告区分 */
  misinkokukbn: string
  /** 他団体課税対象者区分 */
  takazeikbn: string
  /** 他団体課税対象者の課税先市区町村(コード：名称) */
  takazeisiku: string
  /** 指定都市_行政区等(コード：名称) */
  tosi_gyoseiku: string
}
/** 控除情報(税額控除タブ：ヘッダー) */
export interface KojoHeaderVM {
  /** 課税年度 */
  kazeinendo: number
  /** 税額控除情報履歴番号 */
  kojorirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
}
/** 控除情報(税額控除タブ：明細) */
export interface KojoRowVM {
  /** 税額・税額控除コード */
  kojocd: string
  /** 税額・税額控除名 */
  kojonm: string
  /** 指定都市_行政区等(名称) */
  tosi_gyoseikunm: string
  /** 税額控除金額 */
  kojokingaku: number
}
/** 国保情報(国保タブ) */
export interface KokuhoVM {
  /** 被保険者履歴番号 */
  hihokensyarirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 市区町村保険者番号 */
  sikutyosonhokenjano: string
  /** 保険者名称 */
  hokenjanm: string
  /** 国保記号番号 */
  kokuho_kigono: string
  /** 枝番 */
  kokuho_edano: string
  /** 国保資格区分 */
  kokuho_sikakukbn: string
  /** 国保資格取得年月日 */
  kokuho_sikakusyutokuymd: string
  /** 国保資格取得事由 */
  kokuho_sikakusyutokujiyu: string
  /** 国保資格喪失年月日 */
  kokuho_sikakusosituymd: string
  /** 国保資格喪失事由 */
  kokuho_sikakusositujiyu: string
  /** 国保適用開始年月日 */
  kokuho_tekiyoymdf: string
  /** 国保適用終了年月日 */
  kokuho_tekiyoymdt: string
  /** 証区分 */
  syokbn: string
  /** 有効期限 */
  yukokigenymd: string
  /** マル学マル遠区分 */
  marugakumaruenkbn: string
}
/** 後期情報(後期タブ) */
export interface KokiVM {
  /** 履歴番号 */
  rirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 被保険者番号 */
  hihokensyano: string
  /** 個人区分(名称) */
  kojinkbnnm: string
  /** 被保険者資格取得事由(名称) */
  hiho_sikakusyutokujiyunm: string
  /** 被保険者資格取得年月日 */
  hiho_sikakusyutokuymd: string
  /** 被保険者資格喪失事由(名称) */
  hiho_sikakusositujiyunm: string
  /** 被保険者資格喪失年月日 */
  hiho_sikakusosituymd: string
  /** 保険者番号適用開始年月日 */
  hoken_tekiyoymdf: string
  /** 保険者番号適用終了年月日 */
  hoken_tekiyoymdt: string
}
/** 生保情報(生保タブ) */
export interface SeihoVM {
  /** 福祉事務所コード */
  fukusijimusyocd: string
  /** ケース番号 */
  caseno: string
  /** 員番号 */
  inno: number
  /** 決定履歴番号 */
  ketteirirekino: number
  /** 申請履歴番号 */
  sinseirirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 生活保護開始年月日 */
  seihoymdf: string
  /** 停止年月日 */
  teisiymd: string
  /** 停止解除年月日 */
  teisikaijoymd: string
  /** 単併給区分(コード：名称) */
  tanheikyukbn: string
  /** 生活扶助フラグ */
  seikatufujoflg: boolean
  /** 住宅扶助フラグ */
  jutakufujoflg: boolean
  /** 教育扶助フラグ */
  kyoikufujoflg: boolean
  /** 医療扶助フラグ */
  iryofujoflg: boolean
  /** 出産扶助フラグ */
  syussanfujoflg: boolean
  /** 生業扶助フラグ */
  seigyofujoflg: boolean
  /** 葬祭扶助フラグ */
  sosaifujoflg: boolean
  /** 廃止年月日 */
  haisiymd: string
}
/** 介護情報(介護タブ) */
export interface KaigoVM {
  /** 資格履歴番号 */
  sikakurirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 介護保険者番号 */
  kaigohokensyano: string
  /** 被保険者番号 */
  hihokensyano: string
  /** 被保険者区分(コード：名称) */
  hihokensyakbn: string
  /** 資格取得日 */
  sikakusyutokuymd: string
  /** 資格喪失日 */
  sikakusosituymd: string
  /** 要介護認定状況(コード：名称) */
  yokaigoninteijokyo: string
  /** 要介護状態区分(コード：名称) */
  yokaigojotaikbn: string
  /** 要介護認定日 */
  yokaigoninteiymd: string
  /** 要介護認定有効期間開始日 */
  yokaigoyukoymdf: string
  /** 要介護認定有効期間終了日 */
  yokaigoyukoymdt: string
  /** 公費受給者番号 */
  kohijukyusyano: string
}
/** 障害情報(福祉タブ) */
export interface SyogaiVM {
  /** 履歴番号 */
  rirekino: number
  /** 更新日時 */
  upddttm: string
  /** 最新フラグ */
  saisinflg: string
  /** 資格状態(コード：名称) */
  sikakujotai: string
  /** 手帳番号 */
  tetyono: string
  /** 初回交付日 */
  syokaikofuymd: string
  /** 返還日 */
  henkanymd: string
  /** 統計部位(コード：名称) */
  tokeibui: string
  /** 障害種別(コード：名称) */
  syogaisyubetu: string
  /** 総合等級(コード：名称) */
  sogotokyu: string
  /** 障害名 */
  syogainm: string
}
/** 地区モデル */
export interface TikuVM {
  /** 地区区分(名称) */
  tikukbn: string
  /** 地区(コード：名称) */
  tiku: string
}

/** 詳細画面：<a-row> */
export interface DetailRow<T extends DataOrVM> {
  cols: {
    span: number
    md?: number
    xl?: number
    label: string
    field: keyof T | ''
    /**複数field */
    list?: { label: string; field: keyof T }[]
  }[]
  title?: string
  th_width?: number
  /** 地区一覧あり */
  tikulist?: boolean
}

export type DataAndVM = JuminVM &
  KazeiVM &
  NozeiVM &
  KojoHeaderVM &
  KokuhoVM &
  KokiVM &
  SeihoVM &
  KaigoVM &
  SyogaiVM

export type DataOrVM =
  | JuminVM
  | KazeiVM
  | NozeiVM
  | KojoHeaderVM
  | KokuhoVM
  | KokiVM
  | SeihoVM
  | KaigoVM
  | SyogaiVM
