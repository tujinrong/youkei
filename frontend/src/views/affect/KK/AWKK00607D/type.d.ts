import { Enum編集区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 共通処理 */
export interface CommonRequest extends DaRequestBase {
  /** 編集区分 */
  procseq?: string
}

/** 登録処理 */
export interface SaveRequest extends DaRequestBase {
  /** プロシージャ情報 */
  procedureVM: ProcedureVM
  /** プロシージャシーケンス */
  editkbn: Enum編集区分
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** 【処理種別】のドロップダウンリスト(nmcd,nm,kananm) */
  processingtypeList: DaSelectorKeyModel[]
  /** プロシージャ情報 */
  procedureVM: ProcedureVM
}

/** 再読み込み処理 */
export interface ReSearchResponse extends DaResponseBase {
  /** プロシージャ情報 */
  procedureVM: ProcedureVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** プロシージャ情報モデル */
export interface ProcedureVM {
  /** プロシージャシーケンス */
  procseq?: string
  /** プロシージャ名 */
  procnm: string
  /** 種別区分 */
  prockbn: string
  /** 内容 */
  procsql: string
}
