import { Enum抽出モード } from '#/Enums/CmBusinessEnums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 個別除外チェック */
export interface CheckRequest extends DaRequestBase {
  /**抽出対象コード */
  tyusyututaisyocd: string
  /**宛名番号 */
  atenano: string
  /**年度（年度管理されている場合） */
  nendo: number | null
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /**ドロップダウンリスト(抽出対象) */
  selectorlist: DaSelectorKeyModel[]
  /**年度表示フラグ */
  nendoflg: boolean
}

/** 個別除外チェック */
export interface CheckResponse extends DaResponseBase {
  /**抽出対象情報（帳票出力画面遷移用） */
  tyusyutuinfo: TyusyutuVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 抽出情報 */
export interface TyusyutuVM {
  /**年度 */
  nendo?: number
  /**抽出対象コード */
  tyusyututaisyocd?: string
  /**抽出対象名 */
  tyusyututaisyonm?: string
  /**帳票ID */
  rptid?: string
  /**抽出シーケンス */
  tyusyutuseq?: number
  /**抽出内容 */
  tyusyutunaiyo?: string
  /**抽出人数 */
  tyusyutunum?: string
  /**登録日時(個別) */
  regdttm?: string
}
