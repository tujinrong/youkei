/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 送付先管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.11.21
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 利用目的 */
  riyomokuteki: string
}
/** 保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /** 会場情報メイン */
  maininfo: MainInfoVM
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 検索処理(詳細画面) */
export interface AutoSetRequest extends DaRequestBase {
  /** 郵便番号 */
  adrs_yubin: string
}
/** 削除処理(詳細画面) */
export interface DeleteRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 利用目的 */
  riyomokuteki: string
  /** 更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends CmSearchResponseBase {
  /** 住民情報 */
  headerinfo: PersonHeaderVM
  /** 結果リスト(送付先一覧) */
  kekkalist: RowVM[]
  /** 利用目的新規用フラグ */
  sinkiflg: boolean
  /** EXCEL出力フラグ */
  exceloutflg: boolean
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** ドロップダウンリスト(利用目的) */
  riyomokutekiList: DaSelectorModel[]
  /** ドロップダウンリスト(登録事由) */
  torokujiyuList: DaSelectorModel[]
  /** ドロップダウンリスト(市区町村) */
  sityosonList: DaSelectorModel[]
  /** ドロップダウンリスト(町字) */
  tyoazaList: DaSelectorKeyModel[]
  /** 表示フラグ(登録支所) */
  showflg: boolean
  /** 登録支所 */
  regsisyo: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 会場情報メイン */
  mainInfo: MainInfoVM
}
/** 自動入力処理(詳細画面) */
export interface AutoSetResponse extends SearchDetailResponse {
  /**  */
  autoset: AutoSetVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 初期化処理(一覧、詳細画面共用) */
export interface PersonHeaderVM extends CommonBarHeaderBaseVM {
  /** 住登区分 */
  jutokbnnm: string
  /** 住民種別 */
  juminsyubetunm: string
  /** 住民状態 */
  juminjotainm: string
  /** 郵便番号 */
  adrs_yubin: string
  /** 住所 */
  adrs: string
}
/** 初期化処理(一覧画面一覧) */
export interface RowVM {
  /** 利用目的コード */
  riyomokutekicd: string
  /** 利用目的名称 */
  riyomokutekinm: string
  /** 登録事由 */
  torokujiyu: string
  /** 送付先郵便番号 */
  sofusaki_yubin: string
  /** 送付先住所 */
  sofusaki_adrs: string
  /** 送付先氏名 */
  sofusaki_simei: string
}
/** 初期化処理(詳細画面) */
export interface MainInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 利用目的 */
  riyomokuteki: string
  /** 登録事由 */
  torokujiyu?: string
  /** 郵便番号 */
  adrs_yubin: string
  /** 市区町村リストコード */
  adrs_sikucd: string
  /** 町字リストコード */
  adrs_tyoazacd: string
  /** 町字リスト名称 */
  adrs_tyoaza: string
  /** 町字(手入力) */
  adrs_tyoaza_in?: string
  /** 番地号表記 */
  adrs_bantihyoki?: string
  /** 方書 */
  adrs_katagaki?: string
  /** 氏名 */
  sofusaki_simei: string
  /** 登録支所 */
  regsisyo: string
  /** 更新日時(排他用) */
  upddttm?: Date | string
  /** 更新権限フラグ */
  updflg: boolean
}
/** 自動入力処理(詳細画面) */
export interface AutoSetVM {
  /** 市区町村（コード） */
  adrs_sikucd: string
  /** 郵便番号 */
  adrs_yubin: string
  /** 町字（コード） */
  adrs_tyoazacd: string
}
