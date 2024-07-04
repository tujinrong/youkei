/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: フォロー管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.01.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(内容画面) */
export interface SearchFollowNaiyoListRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
}
/** 初期化処理(結果画面) */
export interface InitFollowNaiyoRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(結果画面) */
export interface SearchFollowNaiyoRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
}
/** 保存処理(結果画面) */
export interface SaveFollowNaiyoRequest extends DaRequestBase {
  /** フォロー予定結果情報 */
  rowfollowkekka: RowFollowKekkaVM
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 削除処理(結果画面) */
export interface DeleteFollowNaiyoRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 更新日時 */
  upddttm: Date | string
}
/** 初期化処理(詳細画面) */
export interface InitFollowDetailRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** コピーフラグ */
  copyflg: boolean
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 検索処理(詳細画面) */
export interface SearchFollowDetailRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 枝番 */
  edano: number
}
/** 検索処理予定情報(詳細画面) */
export interface SearchFollowDetailPreKekkaRequest extends DaRequestBase {
  /** フォロー予定情報(詳細画面) */
  detailyoteiinfovm: FollowDetailYoteiInfoVM
}
/** 保存処理(詳細画面) */
export interface SaveFollowDetailRequest extends DaRequestBase {
  /** フォロー予定情報(詳細画面) */
  followdetailvm: FollowDetailVM
  /** フォロー予定入力フラグ */
  yoteiinputflg: boolean
  /** フォロー結果入力フラグ */
  kekkainputflg: boolean
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 削除処理(詳細画面) */
export interface DeleteFollowDetailRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 枝番 */
  edano: number
  /** 更新日時(排他用) */
  upddttmyotei?: Date | string
  /** 更新日時(排他用) */
  upddttmkekka?: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 管理一覧（初期表示） */
export interface SearchFollowListResponse extends CmSearchResponseBase {
  /** フォロー管理一覧 */
  kekkalist: RowFollowVM[]
}
/** 検索処理(内容画面) */
export interface SearchFollowNaiyoListResponse extends DaResponseBase {
  /** ドロップダウンリスト(把握経路) */
  haakukeiroList: DaSelectorModel[]
  /** ドロップダウンリスト(把握事業) */
  haakujigyoList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー状況) */
  followstatusList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー事業) */
  followjigyoList: DaSelectorModel[]
  /** 住民情報 */
  headerinfo: GamenHeaderBase2VM
  /** 結果リスト(フォロー内容一覧) */
  kekkalist: RowFollowContentVM[]
}
/** 新規処理(結果画面) */
export interface InitFollowNaiyoResponse extends DaResponseBase {
  /** ドロップダウンリスト(把握経路) */
  haakukeiroList: DaSelectorModel[]
  /** ドロップダウンリスト(把握事業) */
  haakujigyoList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー状況) */
  followstatusList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー事業) */
  followjigyoList: DaSelectorModel[]
  /** ドロップダウンリスト(担当) */
  followstaffidList: DaSelectorModel[]
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 表示フラグ(登録支所) */
  showflg: boolean
  /** 登録支所 */
  regsisyo: string
}
/** 検索処理(結果画面) */
export interface SearchFollowNaiyoResponse extends DaResponseBase {
  /** フォロー内容情報 */
  followkekkavm: RowFollowKekkaVM
  /** 結果リスト(フォロー予定結果情報一覧) */
  kekkalist: RowFollowKekkaVM[]
  /** 表示フラグ(登録支所) */
  showflg: boolean
  /** 登録支所 */
  regsisyo: string
}
/** 検索処理(詳細画面) */
export interface SearchFollowDetailResponse extends DaResponseBase {
  /** 前回結果情報セットフラグ */
  zenkaisetflg: boolean
  /** フォロー予定情報(詳細画面) */
  followdetailvm: FollowDetailVM
}
/** 初期化処理(詳細画面) */
export interface InitFollowDetailResponse extends DaResponseBase {
  /** ドロップダウンリスト(フォロー事業) */
  followjigyoList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー方法) */
  followhoho_yoteiList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー会場) */
  followkaijocd_yoteiList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー方法) */
  followhohoList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー会場) */
  followkaijocdList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー担当者 */
  followstaffid_yoteiList: DaSelectorModel[]
  /** ドロップダウンリスト(フォロー担当者 */
  followstaffidList: DaSelectorModel[]
  /** フォロー予定情報(詳細画面) */
  followdetailvm: FollowDetailVM
  /** 前回結果情報セットフラグ */
  zenkaisetflg: boolean
  /** 表示フラグ(登録支所) */
  showflg: boolean
  /** 登録支所 */
  regsisyo: string
}
/** 前回結果情報セット処理(詳細画面) */
export interface FollowDetailPreKekkaResponse extends DaResponseBase {
  /** フォロー予定入力フラグ */
  yoteiinputflg: boolean
  /** フォロー方法 */
  followhoho_yotei?: string
  /** 予定日 */
  followyoteiymd?: string
  /** フォロー時間 */
  followtm_yotei?: string
  /** フォロー会場 */
  followkaijocd_yotei?: string
  /** フォロー担当者 */
  followstaffid_yotei?: string
  /** フォロー担当者名称 */
  followstaffid_yoteinm?: string
  /** フォロー理由 */
  followriyu?: string
  /** 前回結果情報セットフラグ */
  zenkaisetflg: boolean
}
/** 予定情報セット処理(詳細画面) */
export interface FollowDetailKekkaResponse extends DaResponseBase {
  /** フォロー結果情報(詳細画面) */
  kekkadetailinfovm: FollowDetailKekkaInfoVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** フォロー管理一覧情報(管理画面) */
export interface RowFollowVM extends CmHeaderBaseVM {
  /** 宛名番号 */
  atenano: string
  /** 住所 */
  adrs: string
  /** フォロー予定日 */
  followyoteiymd: string
  /** フォロー実施日 */
  followjissiymd: string
  /** 警告内容 */
  keikoku: string
}

/** フォロー内容一覧情報(内容画面) */
export interface RowFollowContentVM extends CommonBarHeaderBaseVM {
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 把握経路 */
  haakukeiro: string
  /** 把握事業 */
  haakujigyocd: string
  /** フォロー内容 */
  follownaiyo: string
  /** フォロー状況 */
  followstatus: string
  /** フォロー事業 */
  followjigyocd: string
  /** 予定日 */
  followyoteiymd: string
  /** 時間 */
  followtm_yotei: string
  /** 会場 */
  followkaijocd_yotei: string
  /** 担当者 */
  followstaffid_yotei: string
  /** 実施日 */
  followjissiymd: string
  /** 時間 */
  followtm: string
  /** 会場 */
  followkaijocd: string
  /** 担当者 */
  followstaffid: string
}
/** フォロー内容情報(結果画面) */
export interface RowFollowKekkaVM extends RowFollowKekkaDetailVM {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 把握経路 */
  haakukeiro?: string
  /** 把握事業 */
  haakujigyocd?: string
  /** フォロー状況 */
  followstatus: string
  /** フォロー内容 */
  follownaiyo?: string
}
/** フォロー予定結果一覧情報(結果画面) */
export interface RowFollowKekkaDetailVM {
  /** 枝番 */
  edano: number
  /** フォロー事業 */
  followjigyocd: string
  /** 方法 */
  followhoho_yotei: string
  /** 予定日 */
  followyoteiymd: string
  /** 時間 */
  followtm_yotei: string
  /** 会場 */
  followkaijocd_yotei: string
  /** 担当者 */
  followstaffid_yotei: string
  /** フォロー理由 */
  followriyu: string
  /** 方法 */
  followhoho: string
  /** 実施日 */
  followjissiymd: string
  /** 時間 */
  followtm: string
  /** 会場 */
  followkaijocd: string
  /** 担当者 */
  followstaffid: string
  /** フォロー結果 */
  followkekka: string
  /** 更新日時(排他用) */
  upddttm?: Date | string
  /** 更新権限フラグ */
  updflg: boolean
}
/** フォロー予定情報(詳細画面) */
export interface FollowDetailVM extends FollowDetailYoteiInfoVM {
  /** 宛名番号 */
  atenano: string
  /** フォロー内容枝番 */
  follownaiyoedano: number
  /** 枝番 */
  edano: number
  /** 枝番新規用 */
  sinkiEdano: number
  /** 把握経路 */
  haakukeiro: string
  /** 把握事業 */
  haakujigyocd: string
  /** フォロー内容 */
  follownaiyo: string
  /** フォロー事業 */
  followjigyocd: string
}
/** フォロー予定情報(詳細画面) */
export interface FollowDetailYoteiInfoVM extends FollowDetailKekkaInfoVM {
  /** フォロー予定入力フラグ */
  yoteiinputflg: boolean
  /** フォロー方法 */
  followhoho_yotei?: string
  /** 予定日 */
  followyoteiymd?: string
  /** フォロー時間 */
  followtm_yotei?: string
  /** フォロー会場 */
  followkaijocd_yotei?: string
  /** フォロー担当者 */
  followstaffid_yotei?: string
  /** フォロー担当者名称 */
  followstaffid_yoteinm?: string
  /** フォロー理由 */
  followriyu?: string
}
/** フォロー結果情報(詳細画面) */
export interface FollowDetailKekkaInfoVM {
  /** フォロー結果入力フラグ */
  kekkainputflg: boolean
  /** フォロー方法 */
  followhoho?: string
  /** 実施日 */
  followjissiymd?: string
  /** フォロー時間 */
  followtm?: string
  /** フォロー会場 */
  followkaijocd?: string
  /** フォロー担当者 */
  followstaffid?: string
  /** フォロー担当者名称 */
  followstaffid_nm?: string
  /** フォロー結果 */
  followkekka?: string
  /** 更新日時(排他用) */
  upddttmyotei?: Date | string
  /** 更新日時(排他用) */
  upddttmkekka?: Date | string
  /** 更新権限フラグ */
  updflg: boolean
}
