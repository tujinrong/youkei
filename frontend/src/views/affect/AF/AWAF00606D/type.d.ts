/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 個人照会
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.10.03
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 個人基本情報 */
  headerinfo: HeaderVM
  /** 住民情報その他情報 */
  detailinfo1: Tab1DetailVM
  /** 課税・保険・介護情報 */
  detailinfo2: Tab2DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 個人基本情報 */
export interface HeaderVM extends CommonBarHeaderBase2VM {
  /** 行政区(コード：名称) */
  gyoseiku: string
}
/** 住民情報その他情報 */
export interface Tab1DetailVM {
  /** 年齢(年度末) */
  age_nendo: string
  /** 年齢計算基準日(年度末) */
  agekijunymd_nendo: string
  /** 世帯番号 */
  setaino: string
  /** 世帯情報一覧 */
  kekkalist: RowVM[]
}
/** 課税・保険・介護情報 */
export interface Tab2DetailVM {
  /** 課税非課税区分（世帯） */
  kazeikbn_setai: string
  /** 保険区分 */
  hokenkbn: string
  /** 課税非課税区分 */
  kazeikbn: string
  /** 国保記号番号 */
  kokuho_kigono: string
  /** 枝番 */
  kokuho_edano: string
  /** 国保資格取得年月日 */
  kokuho_sikakusyutokuymd: string
  /** 国保資格喪失年月日 */
  kokuho_sikakusosituymd: string
  /** 被保険者番号(後期高齢者医療) */
  hihokensyano1: string
  /** 被保険者資格取得年月日 */
  hiho_sikakusyutokuymd: string
  /** 被保険者資格喪失年月日 */
  hiho_sikakusosituymd: string
  /** 生活保護開始年月日 */
  seihoymdf: string
  /** 停止年月日 */
  teisiymd: string
  /** 停止解除年月日 */
  teisikaijoymd: string
  /** 廃止年月日 */
  haisiymd: string
  /** 要介護状態区分(名称) */
  yokaigojotaikbnnm: string
  /** 被保険者番号(介護保険) */
  hihokensyano2: string
  /** 要介護認定日 */
  yokaigoninteiymd: string
  /** 要介護認定有効期間開始日 */
  yokaigoyukoymdf: string
  /** 要介護認定有効期間終了日 */
  yokaigoyukoymdt: string
}
/** 世帯情報(1件) */
export interface RowVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 続柄 */
  zokuhyoki: string
  /** 性別 */
  sex: string
  /** 生年月日 */
  bymd: string
  /** 住民区分 */
  juminkbn: string
  /** 警告内容 */
  keikoku: string
  /** 除票者フラグ */
  stopflg: boolean
}
