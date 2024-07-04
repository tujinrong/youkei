import { Enum抽出モード } from '#/Enums/CmBusinessEnums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /**ページサイズ（二番目の一覧） */
  pagesize2: number
  /**ページNo.（二番目の一覧） */
  pagenum2: number
  /**並び順（二番目の一覧） */
  orderby2: number
  /**年度 */
  nendo?: number
  /**抽出対象(コード：名称) */
  tyusyututaisyo?: string
  /**抽出内容 */
  tyusyutunaiyo?: string
  /**抽出日（開始） */
  regdttmf?: string
  /**抽出日（終了） */
  regdttmt?: string
}

export interface DetailBaseRequest extends DaRequestBase {
  zentaikobetukbn: string
}

/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DetailBaseRequest {
  /**抽出対象コード */
  tyusyututaisyocd: string
  /**抽出シーケンス（全体抽出参照モード、抽出後） */
  tyusyutuseq: number | null
  /**宛名番号(個別抽出) */
  atenano: string | null
  /**年度（個別抽出かつ年度管理されている場合） */
  nendo: number | null
  /**抽出内容（全体抽出の場合、フロントエンドの入力値；個別抽出の場合、個別抽出の固定テキスト） */
  tyusyutunaiyo?: string
}

/** 抽出処理 */
export interface ExtractRequest extends DetailBaseRequest {
  /**抽出対象コード */
  tyusyututaisyocd: string
  /**宛名番号（個別抽出） */
  atenano: string | null
  /**抽出内容 */
  tyusyutunaiyo: string
  /**継続希望フラグ */
  continueflg: boolean
  /**年度（個別抽出かつ年度管理されている場合） */
  nendo: number | null
  /**抽出パラメータ */
  parameters: ParameterVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------

/** ベース初期化処理（入り口によって異なる項目の初期化） */
export interface InitBaseResponse extends DaResponseBase {
  /**年度表示フラグ */
  nendoflg: boolean
}

/** 初期化処理(一覧画面) */
export interface InitListResponse extends InitBaseResponse {
  /**ドロップダウンリスト(抽出対象) */
  selectorlist: DaSelectorModel[]
}

/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /**ページ数（二番目の一覧） */
  totalpagecount2: number
  /**総件数（二番目の一覧） */
  totalrowcount2: number
  /**抽出情報一覧（全体抽出） */
  kekkalist1: RowVM[]
  /**抽出情報一覧（個別抽出） */
  kekkalist2: RowVM[]
}

/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends InitBaseResponse {
  /**フリー項目情報(検索条件) */
  jokenlist1: FreeItemTyusyutuVM[]
  /**フリー項目情報(検索条件以外) */
  jokenlist2: FreeItemTyusyutuVM[]
  /**抽出情報*/
  tyusyutuinfo: TyusyutuMainVM
  /**宛名情報（個別抽出の場合）*/
  atenainfo?: AtenaVM
  /**発券情報表示フラグ（個別抽出の場合）*/
  hakkenhyojiflg: boolean
  /**発券情報（個別抽出かつ発券情報表示の場合）*/
  hakkeninfo: HakkenVM[]
}

/** 抽出処理 */
export interface ExtractResponse extends DaResponseBase {
  /**抽出シーケンス  */
  tyusyutuseq?: number
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM extends TyusyutuMainVM {
  /**抽出対象コード */
  tyusyututaisyocd: string
  /**抽出シーケンス */
  tyusyutuseq: number
}

/** 抽出メイン情報 */
export interface TyusyutuMainVM {
  /**年度 */
  nendo: number | null
  /**抽出対象名 */
  tyusyututaisyonm: string
  /**帳票ID */
  rptid: string
  /**抽出内容 */
  tyusyutunaiyo: string
  /**抽出人数 */
  tyusyutunum: string
  /**登録日時 */
  regdttm: string
}

/** フリー項目情報 */
export interface FreeItemTyusyutuVM extends FreeItemBaseVM {
  /**年齢項目かどうか */
  isageflg?: boolean
}

/** 抽出パラメータ */
export interface ParameterVM {
  /**アイテムコード */
  itemcd: string
  /**画面の入力値 */
  value: any
}

/** 抽出結果 */
export interface ExtractVM {
  /**実行結果区分(0:実行完了 1:エラー 2:アラート) */
  actresultkbn: number
  /**画面に表示するメッセージID */
  messageid?: string
  /**チェックが失敗した場合、エラー・アラートメッセージの内容 */
  messagetext?: string
  /**抽出した場合、tt_kktaisyosya_tyusyutuの最大抽出シーケンス＋１ */
  tyusyutuseq?: number
}

/** 宛名情報 */
export interface AtenaVM {
  /**氏名 */
  name: string
  /**カナ氏名 */
  kname: string
  /**性別 */
  sex: string
  /**生年月日 */
  bymd: string
  /**住民区分 */
  juminkbn: string
  /**年齢(本日時点) */
  age: string
}

/** 発券情報 */
export interface HakkenVM {
  /**ラベル */
  label: string
  /**発券番号 */
  hakkenno: string
}
