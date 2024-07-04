/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 集団指導管理
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.29
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 2.集団指導一覧画面検索処理(一覧画面) */
export interface SearchListRequest extends CmSearchRequestBase {
  /** 業務 */
  gyomu: string
  /** 事業 */
  jigyo: string
  /** 予定者/実施者 */
  tantosya: string
  /** 実施場所 */
  jissibasyo: string
  /** 予定日(From) */
  yoteiymdf: string
  /** 予定日(To) */
  yoteiymdt: string
  /** コース */
  course: string
  /** 実施日(From) */
  jissiymdf: string
  /** 実施日(To) */
  jissiymdt: string
  /** コース名 */
  coursenm: string
  /** 宛名番号 */
  atenano: string
}
/** 3.個別入力画面検索処理(集団指導管理の検索結果一覧の行をクリックした場合) */
export interface SearchDetailRequest extends DaRequestBase {
  /** 業務区分 */
  gyomukbn: string
  /** 枝番 */
  edano: number
  /** 申込結果区分 */
  mosikomikekkakbn: string
}
/** 5.参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ）） */
export interface SearchSankasyaListRequest extends SearchDetailRequest {
  /** 事業コード */
  jigyocd: string
}
/** 6.保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /** 個別入力画面_申込情報／結果情報タブメイン */
  maininfo: MainInfoVM
}
/** 7.削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 業務区分 */
  gyomukbn: string
  /** 枝番 */
  edano: number
}
/** 8参加者詳細画面検索処理（参加者情報一覧のリンクをクリック） */
export interface SearchSankasyaDetailRequest extends SearchDetailRequest {
  /** 宛名番号 */
  atenano: string
}
/** 10.参加者保存処理 */
export interface SaveSankasyaRequest extends CmSaveRequestBase {
  /** 参加者詳細画面_申込情報／結果情報タブメイン */
  maininfo: SankasyaMainInfoVM
}
/** 11.参加者削除処理 */
export interface DeleteSankasyaRequest extends DeleteRequest {
  /** 宛名番号 */
  atenano: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 1.初期化処理(個人詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /** 個人詳細画面_基本情報等タブリスト初期化 */
  initdetail: InitDetailVM
}
/** 2.集団指導一覧画面検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(結果一覧) */
  kekkalist: SyudanListVM[]
}
/** 3,4フリー項目検索 */
export interface SearchFreeItemResponse extends DaResponseBase {
  /** フリー項目グループ１リスト */
  grouplist1: DaSelectorModel[]
  /** フリー項目グループ２リスト */
  grouplist2: DaSelectorModel[]
  /** フリー項目情報（表示用） */
  freeitemlist: FreeItemDispInfoVM[]
}
/** 3.個別入力画面検索処理(集団指導管理の検索結果一覧の行をクリックした場合) */
export interface SearchDetailResponse extends SearchFreeItemResponse {
  /**編集フラグ */
  editflg: boolean
  /** 親画面引き続き情報（表示用） */
  paraminfo: ParamInfoVM
  /** 個別入力画面固定情報（表示用） */
  fixinfo: JigyoFixInfoVM
}
/** 5.参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ）） */
export interface SearchSankasyaListResponse extends DaResponseBase {
  /** 参加者情報入力 */
  inputflg: boolean
  /** 事業（コード */
  jigyo: string
  /** 参加者基本情報（表示用） */
  sankasyalist: SankasyaInfoVM[]
}
/** 6.7.保存/削除処理(個別入力画面)
 * 10.11.参加者保存/参加者削除処理(参加者詳細画面)
 */
export interface CommonResponse extends DaResponseBase {
  /** 参加者詳細画面ヘッダー情報（表示用） */
  headerinfo: HeaderInfoVM
  /** 参加者詳細画面固定情報（表示用） */
  fixinfo: SankasyaFixInfoVM
}

/** 8,9.参加者詳細画面検索処理 */
export interface SearchSankasyaDetailResponse extends SearchFreeItemResponse {
  /**編集フラグ */
  editflg: boolean
  /** 参加者詳細画面ヘッダー情報（表示用） */
  headerinfo: HeaderInfoVM
  /** 参加者詳細画面固定情報（表示用） */
  fixinfo: SankasyaFixInfoVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitDetailVM {
  /** ドロップダウンリスト(業務リスト) */
  gyomulist: DaSelectorModel[]
  /** ドロップダウンリスト(事業リスト) */
  jigyolist: DaSelectorModel[]
  /** ドロップダウンリスト(実施場所リスト) */
  kaijolist: DaSelectorModel[]
  /** ドロップダウンリスト(予定者／実施者リスト) */
  stafflist: StaffListVM[]
  /** ドロップダウンリスト(コースリスト) */
  courselist: DaSelectorModel[]
  /** ドロップダウンリスト(地域保健集計区分リスト) */
  syukeikbnlist: DaSelectorModel[]
  /** ドロップダウンリスト(グループ１リスト) */
  group1list: DaSelectorModel[]
  /** ドロップダウンリスト(グループ２リスト) */
  group2list: DaSelectorModel[]
  /** ドロップダウンリスト(参加者グループ１リスト) */
  sankasyagroup1list: DaSelectorModel[]
  /** ドロップダウンリスト(参加者グループ２リスト) */
  sankasyagroup2list: DaSelectorModel[]
  /** スイッチ(出欠区分スイッチ) */
  syukketuswitch: DaSelectorModel[]
}
/** 検索処理(結果一覧画面) */
export interface SyudanListVM {
  /** 業務区分 */
  gyomukbn: string
  /** 業務 */
  gyomu: string
  /** 事業コード */
  jigyocd: string
  /** 事業名称 */
  jigyo: string
  /** 実施予定日 */
  yoteiymd?: string
  /** 予定開始時間 */
  yotetmf?: string
  /** 実施予定場所 */
  yotebasyo?: string
  /** 予定者 */
  yoteisya: string
  /** 日程番号 */
  nitteno?: number
  /** 日程詳細番号 */
  nittesyosaino?: number
  /** コース名 */
  coursenm?: string
  /** 実施日 */
  jissiymd: string
  /** 実施時間 */
  jissitm: string
  /** 実施場所 */
  jissibasyo?: string
  /** 実施者 */
  jissisya: string
  /** 枝番（キー項目、非表示） */
  edano: number
}
/** 事業従事者リスト（予定者／実施者用） */
export interface StaffListVM {
  /** 事業従事者ID */
  staffid: string
  /** 事業従事者氏名 */
  staffsimei: string
}
/** 親画面引き続き情報（表示用） */
export interface ParamInfoVM {
  /** 業務 */
  gyomu: string
  /** 枝番 */
  edano: number
}
/** 事業詳細画面_固定情報（表示用） */
export interface JigyoBaseInfoVM {
  /** 申込情報入力 */
  inputflg: boolean
  /** ドロップダウンリスト(事業リスト) */
  jigyolist: DaSelectorModel[]
  /** 事業コード */
  jigyo: string
  /** 実施場所 */
  kaijo: string
  /** 事業従事者ID（予定者／実施者） */
  stafflist: StaffListVM[]
  /** 登録支所コード */
  regsisyocd: string
  /** 登録支所名称 */
  regsisyonm: string
}
/** 事業詳細画面_指導情報（表示用） */
export interface JigyoFixInfoVM extends JigyoBaseInfoVM {
  /** 実施予定日（申込タブ用） */
  yoteiymd: string
  /** 予定開始時間（申込タブ用） */
  yoteitm: string
  /** 地域保健集計区分（結果タブ用） */
  syukeikbn: string
  /** 実施日（結果タブ用） */
  jissiymd: string
  /** 開始時間（結果タブ用） */
  tmf: string
  /** 終了時間（結果タブ用） */
  tmt: string
}
/** 個人詳細画面_フリー項目情報（表示用） */
export interface FreeItemDispInfoVM extends FreeItemBaseVM {
  /** 分類 */
  itemkbn: string
  /** グループID */
  groupid?: string
  /** 利用地域保健集計区分 */
  syukeikbn: string
}
/** 参加者基本情報 */
export interface SankasyaBaseInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別（名称） */
  sex: string
  /** 生年月日（和暦表示） */
  bymd: string
  /** 住民区分（名称） */
  juminkbn: string
  /** 警告内容 */
  keikoku: string
}
/** 参加者一覧情報 */
export interface SankasyaInfoVM extends SankasyaBaseInfoVM {
  /** 出欠区分 */
  syukketukbn: string
}
/** 参加者詳細画面_ヘッダー情報（表示用） */
export interface HeaderInfoVM extends SankasyaInfoVM {
  /** 年齢 */
  age: string
  /** 年齢計算基準日 */
  kijunymd: string
}
/** 参加者詳細画面_固定情報（表示用） */
export interface SankasyaFixInfoVM {
  /** 申込／結果情報入力 */
  inputflg: boolean
  /** 事業コード */
  jigyo: string
  /** 地域保健集計区分（結果タブ用） */
  syukeikbn: string
  /** 登録支所コード */
  regsisyocd: string
  /** 登録支所名称 */
  regsisyonm: string
}
/** 個人詳細画面_フリー項目情報（保存用） */
export interface FreeItemInfoVM {
  /** 入力タイプ */
  inputtype: number
  /** 項目（コード：名称） */
  item: string
  /** 値 */
  value?: object
}
/** 個人詳細画面_固定情報（保存用） */
export interface PersonalBaseInfoVM {
  /** 申込／結果情報入力 */
  inputflg: boolean
  /** 事業（コード */
  jigyo: string
  /** 実施場所 */
  kaijo: string
  /** 事業従事者ID（予定者／実施者） */
  stafflist: StaffListVM[]
  /** 登録支所コード */
  regsisyocd: string
  /** 登録支所名称 */
  regsisyonm: string
  //
  jigyolist: undefined
}
/** 個人詳細画面_申込情報（保存用） */
export interface MosikomiSaveVM extends PersonalBaseInfoVM {
  /** 実施予定日 */
  yoteiymd: string
  /** 予定開始時間 */
  yoteitm: string
  /** フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}
/** 個人詳細画面_結果情報（保存用） */
export interface KekkaSaveVM extends PersonalBaseInfoVM {
  /** 実施日 */
  jissiymd: string
  /** 開始時間 */
  tmf: string
  /** 終了時間 */
  tmt: string
  /** 地域保健集計区分 */
  syukeikbn: string
  /** フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}
/** 個人詳細画面_結果情報（保存用） */
export interface SankasyaListVM extends SankasyaBaseInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 出欠区分 */
  syukketukbn: string
}
/** 参加者情報情報（保存用） */
export interface SankasyaSaveVM {
  /** 参加者情報入力 */
  inputflg: boolean
  /** 事業（コード */
  jigyo: string
  /** 参加者一覧 */
  sankasyalist: SankasyaListVM[]
}
/** 個人詳細画面_申込情報／結果情報タブ（保存用） */
export interface MainInfoVM {
  /** 業務区分 */
  gyomukbn: string
  /** 枝番 */
  edano: number
  /** 申込情報 */
  mosikomiinfo: MosikomiSaveVM
  /** 結果情報 */
  kekkainfo: KekkaSaveVM
  /** 参加者情報 */
  sankasyainfo: SankasyaSaveVM
}
/** 参加者詳細_申込情報／結果情報タブ（保存用） */
export interface SankasyaMainInfoVM {
  /** 業務区分 */
  gyomukbn: string
  /** 枝番 */
  edano: number
  /** 宛名番号 */
  atenano?: string
  /** 申込情報 */
  mosikomiinfo: SankasyaMosikomiInfoVM
  /** 結果情報 */
  kekkainfo: SankasyaKekkaInfoVM
}
/** 参加者詳細画面_申込情報（保存用） */
export interface SankasyaMosikomiInfoVM {
  /** 申込／結果情報入力 */
  inputflg: boolean
  /** 登録支所コード */
  regsisyocd: string
  /** フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}
/** 参加者詳細画面_結果情報（保存用） */
export interface SankasyaKekkaInfoVM extends SankasyaMosikomiInfoVM {
  /** 地域保健集計区分 */
  syukeikbn: string
}
