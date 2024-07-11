/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業実施報告書
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.12.11
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 実施日時（開始） */
  jissiymdf: string
  /** 実施日時（終了） */
  jissiymdt: string
  /** 会場(コード：名称) */
  kaijo: string
  /** 事業(コード：名称) */
  jigyo: string
  /** 地区担当者(コード：名称) */
  staff: string
}
/** 検索処理(詳細画面) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 事業報告書番号 */
  hokokusyono: number | null
}
/** 検索処理(事業従事者情報) */
export interface SearchRowRequest extends DaRequestBase {
  /** 事業従事者ID */
  staffid: string
}
/** 保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /** 事業報告書番号 */
  hokokusyono: number
  /** 更新日時 */
  upddttm: Date | string | null
  /** 事業実施報告書（日報）情報 */
  jissihokokusyo: JissihokokusyoVM
  /** 事業従事者ID集合 */
  staffids: string[]
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 事業報告書番号 */
  hokokusyono: number
  /** 更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends InitDetailResponse {
  /** ドロップダウンリスト(従事者) */
  selectorlist3: StaffJigyocdVM[]
  /** ドロップダウンリスト(会場) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(事業) */
  selectorlist2: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(日報一覧) */
  kekkalist: RowVM[]
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** ドロップダウンリスト(会場) */
  selectorlist4: DaSelectorModel[]
  /** ドロップダウンリスト(事業) */
  selectorlist5: DaSelectorModel[]
}
/** 検索処理(詳細画面) */
export interface SearchDetailResponse extends DaResponseBase {
  /** 事業報告書番号 */
  hokokusyono: number
  /** 更新日時 */
  upddttm?: Date | string
  /** 更新者 */
  updusernm?: string
  /** 登録支所 */
  regsisyo?: string
  /** 事業実施報告書（日報）情報 */
  jissihokokusyo?: JissihokokusyoVM
  /** 事業従事者リスト */
  stafflist: StaffVM[]
  /** EXCEL出力フラグ */
  exceloutflg: boolean
  /** ドロップダウンリスト(会場) */
  selectorlist4: DaSelectorModel[]
  /** ドロップダウンリスト(事業) */
  selectorlist5: DaSelectorModel[]
}
/** 保存処理 */
export interface SaveResponse extends DaResponseBase {
  /** 事業報告書番号 */
  hokokusyono: number
}
/** 検索処理(事業従事者情報) */
export interface SearchRowResponse extends DaResponseBase {
  /** 事業従事者情報 */
  staffinfo: StaffVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM {
  /** 事業報告書番号 */
  hokokusyono: number
  /** 実施日 */
  jissiymd: string
  /** 時間 */
  jissitime: string
  /** 会場名 */
  kaijonm: string
  /** 事業名 */
  jigyonm: string
  /** 従事者(「,」区切り) */
  staffnm: string
  /** 更新日時 */
  upddttm: string
  /** 更新者 */
  updusernm: string
  /** 登録支所 */
  regsisyo: string
}
/** 事業従事者（担当者）情報 */
export interface StaffVM {
  /** 事業従事者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
  /** 事業従事者カナ氏名 */
  kanastaffsimei: string
  /** 職種 */
  syokusyu: string
  /** 活動区分 */
  katudokbn: string
}
/** 実施報告書（日報）情報 */
export interface JissihokokusyoVM {
  /** 事業 */
  jigyo: string
  /** 会場 */
  kaijo: string
  /** 実施日 */
  jissiymd: string
  /** 開始時間 */
  timef: string
  /** 終了時間 */
  timet: string
  /** 男性延べ人数 */
  mantotalnum: number
  /** 女性延べ人数 */
  womantotalnum: number
  /** 性別不明延べ人数 */
  fumeitotalnum: number
  /** 男性実人数 */
  mannum: number
  /** 女性実人数 */
  womannum: number
  /** 性別不明実人数 */
  fumeinum: number
  /** 出席者数 */
  syussekisya: number
  /** 実施内容 */
  jissinaiyo?: string
  /** 媒体 */
  baitai?: string
  /** 配布資料 */
  haifusiryo?: string
  /** コメント */
  comment?: string
  /** 反省点 */
  hanseipoint?: string
  /** 事業目的 */
  jigyomokuteki?: string
}
/** 事業従事者情報 */
export interface StaffJigyocdVM extends DaSelectorModel {
  jigyocds: string[]
}
