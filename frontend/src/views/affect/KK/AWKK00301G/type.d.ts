// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 保健指導管理
//             ビューモデル定義
// 作成日　　: 2023.12.13
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************

/**基本情報(メイン：ベース) */
export interface BaseInfoVM {
  /**宛名番号 */
  atenano: string
  /**氏名 */
  name: string
  /**カナ氏名 */
  kname: string
  /**性別（名称） */
  sex: string
  /**生年月日 */
  bymd: string
  /**住民区分 */
  juminkbn: string
  /**警告内容 */
  keikoku: string
}

/**検索処理(住民一覧画面) */

export interface JyuminListVM extends BaseInfoVM {
  /**住所(住所1、住所2) */
  adrs: string
  /**行政区 */
  gyoseiku: string
}

/**検索処理(世帯固定部分情報) */

export interface SetaiBaseInfoVM {
  /**宛名番号 */
  atenano: string
  /**氏名 */
  name: string
  /**カナ氏名 */
  kname: string
  /**郵便番号 */
  adrs_yubin: string
  /**指定都市_行政区等 */
  tosi_gyoseiku: string
  /**住所(住所1、住所2) */
  adrs: string
}

/**検索処理(世帯地区情報) */

export interface SetaiTikuListVM {
  /**地区区分 */
  tikukbn: string
  /**地区 */
  tiku: string
}

/**検索処理(世帯構成員一覧画面) */
export interface SetaiListVM extends BaseInfoVM {
  /**続柄 */
  zokuhyoki: string
  /**訪問予定日 */
  homonyoteiymd: string
  /**訪問実施日 */
  homonjissiymd: string
  /**個別指導予定日 */
  kobetuyoteiymd: string
  /**個別指導実施日 */
  kobetujissiymd: string
}

/**検索処理(個人一覧ヘッダー情報) */
export interface PersonalHeaderInfoVM extends BaseInfoVM {
  /**年齢	 */
  age: string
  /**年齢計算基準日 */
  kijunymd: string
}

/**検索処理(指導情報一覧画面) */
export interface ShidouInfoListVM {
  /**業務 */
  gyomunm: string
  /**事業コード */
  jigyocd: string
  /**事業名称 */
  jigyonm: string
  /**実施予定日 */
  yoteiymd: string
  /**予定開始時間 */
  yoteitm: string
  /**実施場所（申込） */
  yoteikaijo: string
  /**予定者 */
  yoteisya: string
  /**実施日 */
  jissiymd: string
  /**実施時間 */
  jissitm: string
  /**実施場所（結果） */
  jissikaijo: string
  /**実施日時点年齢 */
  nenrei: string
  /**実施者 */
  jissisya: string
  /**枝番（キー項目、非表示） */
  edano: number
}

/** 個人詳細画面_フリー項目情報（表示用） */
export interface FreeItemDispInfoVM extends FreeItemBaseVM {
  /**分類 */
  itemkbn: string
  /**グループID */
  groupid?: string
  /**利用地域保健集計区分 */
  syukeikbn: string
}

/** 個人詳細画面_指導情報（表示用） */
export interface FixDispInfoVM extends PersonalBaseInfoVM {
  /**実施予定日（申込タブ用） */
  yoteiymd: string
  /**予定開始時間（申込タブ用） */
  yoteitm: string
  /**実施日（結果タブ用） */
  jissiymd: string
  /**開始時間（結果タブ用） */
  tmf: string
  /**終了時間（結果タブ用） */
  tmt: string
  /**地域保健集計区分（結果タブ用） */
  syukeikbn: string
  /**ドロップダウンリスト(地域保健集計区分リスト) */
  syukeikbnlist: DaSelectorModel[]
}

/**事業リスト（仕様未確定の為、未使用） */
export interface JigyoListVM {
  /**事業コード */
  jigyocd: string
  /**事業名 */
  jigyonm: string
}

/**実施場所リスト */
export interface KaijoListVM {
  /**会場コード */
  kaijocd: string
  /**会場名 */
  kaijonm: string
}

/**事業従事者リスト（予定者／実施者用） */
export interface StaffListVM {
  /**事業従事者ID */
  staffid: string
  /**事業従事者氏名 */
  staffsimei: string
}

/**個人詳細画面_固定情報（保存用） */
export interface PersonalBaseInfoVM {
  /**申込情報入力 */
  inputflg: boolean
  /**ドロップダウンリスト(事業リスト) */
  jigyolist: DaSelectorModel[]
  /**事業（コード : 名称） */
  jigyo: string
  /**実施場所 */
  kaijo: string
  /**事業従事者ID（予定者／実施者） */
  stafflist: StaffListVM[]
  /**登録支所コード */
  regsisyocd: string
  /**登録支所名称 */
  regsisyonm: string
  //
  syukeikbnlist: undefined
}

/**個人詳細画面_フリー項目情報（保存用） */
export interface FreeItemInfoVM {
  /**入力タイプ */
  inputtype: number
  /**項目（名称） */
  item: string
  /**値 */
  value?: any
}

/**個人詳細画面_申込情報（保存用） */
export interface MosikomiInfoVM extends PersonalBaseInfoVM {
  /**実施予定日 */
  yoteiymd: string
  /**予定開始時間 */
  yoteitm: string
  /**フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}

/** 個人詳細画面_結果情報（保存用） */
export interface KekkaInfoVM extends PersonalBaseInfoVM {
  /**実施日 */
  jissiymd: string
  /**開始時間 */
  tmf: string
  /**終了時間 */
  tmt: string
  /**地域保健集計区分 */
  syukeikbn: string
  /**フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}

/** 個人詳細画面_申込情報／結果情報タブ（保存用） */
export interface MainInfoVM {
  /**宛名番号 */
  atenano: string
  /**保健指導区分 */
  hokensidokbn: string
  /**業務区分 */
  gyomukbn: string
  /**枝番 */
  edano: number
  /**申込情報 */
  mosikomiinfo: MosikomiInfoVM
  /**結果情報 */
  kekkainfo: KekkaInfoVM
}

/** スタッフリストVM（検索用） */
export interface StaffSearchVM {
  /**保健指導区分 */
  hokensidokbn: string
  /**業務区分 */
  gyomukbn: string
  /**宛名番号 */
  atenano: string
  /**枝番 */
  edano: number
  /**申込結果区分 */
  mosikomikekkakbn: string
}

/** 初期化処理(個人詳細画面) */
export interface InitDetailVM {
  /**結果情報入力 */
  inputflg: boolean
  /**ドロップダウンリスト(業務リスト) */
  gyomulist: DaSelectorModel[]
  /**ドロップダウンリスト(実施場所リスト) */
  kaijolist: DaSelectorModel[]
  /**ドロップダウンリスト(実施者リスト) */
  stafflist: DaSelectorModel[]
  /**ドロップダウンリスト(地域保健集計区分リスト) */
  syukeikbnlist: DaSelectorModel[]
  /**ドロップダウンリスト(グループ１リスト) */
  group1list: DaSelectorModel[]
  /**ドロップダウンリスト(グループ２リスト) */
  group2list: DaSelectorModel[]
}

/**1.住民一覧画面検索処理(一覧画面) */
export type SearchListRequest = PersonSearchRequest

/** 2.3.住民詳細画面検索処理(結果一覧のリンクをクリック) */
export interface SearchDetailRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
}

/** 4.世帯詳細画面検索処理(世帯一覧のリンクをクリック) */
export interface SearchSetaiDetailRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
  /**保健指導区分 */
  hokensidokbn: string
}

/**5.世帯詳細画面検索処理（個人一覧のタブを選択） */
export interface SearchShidouDetailRequest extends CmSearchRequestBase {
  /**宛名番号 */
  atenano: string
  /**保健指導区分 */
  hokensidokbn: string
  /**業務区分 */
  gyomukbn: string
  /**事業コード */
  jigyocd: string
}

/**
 * 6.個人詳細画面検索処理（個人一覧のリンクをクリック）
 * 7.個人詳細画面検索処理（個人詳細のタブを選択）
 **/

export interface SearchPersonDetailRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
  /**保健指導区分 */
  hokensidokbn: string
  /**業務区分 */
  gyomukbn: string
  /**枝番 */
  edano: number
  /**申込結果区分 */
  mosikomikekkakbn: string
}

/**8.保存処理 */
export interface SaveRequest extends CmSaveRequestBase {
  /**個人詳細画面_申込情報／結果情報タブメイン */
  maininfo: MainInfoVM
}

/**9.削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
  /**保健指導区分 */
  hokensidokbn: string
  /**業務区分 */
  gyomukbn: string
  /**枝番 */
  edano: number
}

/**10.フリー項目絞込処理（「地域保健集計区分」ドロップダウンリストを選択） */
export interface SearchFreeItemRequest extends SearchPersonDetailRequest {
  /**グループ1	 */
  groupid: string
  /**グループ2	 */
  groupid2: string
  /**必須フラグ	 */
  hissuflg: boolean
  /**地域保健集計区分	 */
  syukeikbn: string
}

/**1.住民一覧画面検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /**結果リスト(住民一覧) */
  kekkalist: JyuminListVM[]
  /**遷移フラグ */
  transflg: boolean
}

/** 2.3.住民詳細画面検索処理(一覧画面) */
export interface SearchDetailResponse extends CmSearchResponseBase {
  /**世帯情報（固定部分） */
  setaibaseinfo: SetaiBaseInfoVM
  /**世帯地区情報一覧 */
  setaitikulist: SetaiTikuListVM[]
  /**世帯構成員一覧 */
  setailist: SetaiListVM[]
}

/**4.世帯詳細画面検索処理(一覧画面) */
export interface SearchSetaiDetailResponse extends CmSearchResponseBase {
  /**個人一覧ヘッダー情報 */
  personalheaderinfo: PersonalHeaderInfoVM
  /**ドロップダウンリスト(業務リスト) */
  gyomulist: DaSelectorModel[]
  /**ドロップダウンリスト(事業リスト)(申込タブ用) */
  h_jigyolist: DaSelectorModel[]
  /**ドロップダウンリスト(事業リスト)(結果タブ用) */
  k_jigyolist: DaSelectorModel[]
  /**個人一覧指導情報 */
  shidouinfolist: ShidouInfoListVM[]
}

/**5.世帯詳細画面検索処理（個人一覧のタブを選択） */
export interface SearchShidouDetailResponse extends DaResponseBase {
  /**ドロップダウンリスト(業務リスト) */
  gyomulist: DaSelectorModel[]
  /**ドロップダウンリスト(事業リスト)(申込タブ用) */
  h_jigyolist: DaSelectorModel[]
  /**ドロップダウンリスト(事業リスト)(結果タブ用) */
  k_jigyolist: DaSelectorModel[]
  /**個人一覧指導情報 */
  shidouinfolist: ShidouInfoListVM[]
}

/**6.個人詳細画面検索処理（個人詳細画面） */
export interface SearchPersonDetailResponse extends SearchPersonShidouResponse {
  /**個人詳細ヘッダー情報 */
  personalheaderinfo: PersonalHeaderInfoVM
}

/**7.個人詳細画面検索処理（個人詳細のタブを選択） */
export interface SearchPersonShidouResponse extends SearchFreeItemResponse {
  /**編集フラグ */
  editflg: boolean
  /**個人詳細固定情報（表示用） */
  personalfixinfo: FixDispInfoVM
}

/**7.8.保存/削除処理(詳細画面) */
export type CommonResponse = DaResponseBase

/** 9.フリー項目絞込処理 */
export interface SearchFreeItemResponse extends DaResponseBase {
  /**フリー項目グループ１リスト */
  grouplist1: DaSelectorModel[]
  /**フリー項目グループ２リスト */
  grouplist2: DaSelectorModel[]
  /**フリー項目情報（表示用） */
  freeitemlist: FreeItemDispInfoVM[]
}

/**10.初期化処理(個人詳細画面) */
export interface InitDetailResponse extends DaResponseBase {
  /**個人詳細画面_基本情報等タブリスト初期化 */
  initdetail: InitDetailVM
}

/** 11.実施日時点年齢を取得 */
export interface GetAgeRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 実施日 */
  yoteiymd: string
}

/** 11.実施日時点年齢取得処理 */
export interface GetAgeResponse extends DaRequestBase {
  /** 実施日時点年齢 */
  nenrei: string
}
