//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends PersonSearchRequest {
  /** 母子種類 */
  bosikbn: string
}
/** 検索処理(結果一覧のリンクをクリック) */
export interface SearchDetailRequest extends CmSearchRequestBase {
  /** 母子種類 */
  bosikbn: string
  /** 宛名番号 */
  atenano: string
}
/** 検索処理(結果一覧のリンクをクリック) */
export interface SearchSyosaiRequest extends SearchDetailRequest {
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 履歴回数（新規の場合は0を設定する） */
  kaisu: number
}
/** 父母親情報検索処理 */
export interface SearchAtenaInfoRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
}
/** キー項目 */
export interface KeyRequest extends CmSaveRequestBase {
  /** 母子種類 */
  bosikbn: string
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 宛名番号 */
  atenano: string
  /** 履歴回数 */
  kaisu: number
}
/** 保存処理 */
export interface SaveRequest extends KeyRequest {
  /** 画面情報（全て業務） */
  freeiteminfo: FreeItemInfoVM[]
  /** 固定項目情報 */
  fixiteminfo: FreeItemInfoVM[]
}
/** 保存処理 */
export interface SaveAllRequest extends CmSaveRequestBase {
  /** 画面情報（全て業務） */
  saveinfo: SaveRequest[]
}
/** 削除処理 */
export interface DeleteRequest extends KeyRequest {
  /** 削除フラグ　True：全ての詳細内容削除、False：選択中の履歷のみ削除 */
  delflg: boolean
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 乳幼児一覧画面検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 詳細項目タイトル */
  syosaititle: string
  /** 結果リスト(妊産婦一覧) */
  kekkalist: NinsanpuListVM[]
}
/** 乳幼児詳細画面検索処理(一覧画面) */
export interface SearchDetailResponse extends SearchSyosaiResponse {
  /** 乳幼児情報（固定部分 */
  headerinfo: HeaderInfoVM
  /** 乳幼児メニュー種類一覧 */
  menulist: MenuInfoVM[]
  /** 妊産婦メニュータブ一覧 */
  // menutab: MenuTabInfoVM[]
  /** フリー項目グループ１リスト */
  grouplist1: DaSelectorModel[]
  /** フリー項目グループ２リスト */
  grouplist2: DaSelectorModel[]
}
/** 乳幼児フリー検索処理(メニュー／タブ／回数をクリック) */
export interface SearchSyosaiResponse extends CmSearchResponseBase {
  /** 乳幼児タブ一覧 */
  tablist: TabInfoVM[]
  /** 最大回数（新規の場合は最大履歴回数＋１） */
  maxkaisu: number
  /** 回数タブ一覧（新規の場合は最大履歴回数＋１も含める） */
  kaisulist: KaisuInfoVM[]
  /** 乳幼児フリー項目情報（表示用） */
  freeitemlist: FreeItemDispInfoVM[]
  /** 固定項目情報 */
  fixitemlist: FreeItemDispInfoVM[]
}
/** 保存/7.削除処理(詳細画面) */
export interface SearchAtenaInfoResponse extends CmSearchResponseBase {
  /** 父母親情報 */
  AtenaInfo: string
}
/** 発育曲線表示処理 */
export interface ShowCurveResponse extends CmSearchResponseBase {
  /** 乳幼児情報（固定部分） */
  headerinfo: HeaderInfoVM
  /** 母子データリストコード */
  bhdatalistcd: string
  /** 単位 */
  tani: string
  /** 本人のグラフ */
  curveinfolist: KaisuInfoVM[]
  /** P3(全体3%)のグラフ */
  p3curveinfolist: FreeItemDispInfoVM[]
  /** P97(全体97%)のグラフ */
  p97curveinfolist: DokujiInfoVM[]
}
/** 保存/7.削除処理(詳細画面) */
export interface CommonResponse extends DaResponseBase {
  /** 名称 */
  KikanNM: string
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 基本情報(メイン：ベース) */
export interface BaseInfoVM {
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
}
/** 検索処理(乳幼児一覧画面) */
export interface NinsanpuListVM extends BaseInfoVM {
  /** 編集状態 */
  datasts: string
  /** 行政区 */
  gyoseiku: string
  /** 詳細（メニュー名称文字列） */
  syosai: string
}
/** 検索処理(妊産婦ヘッダー部分情報)*/
export interface HeaderInfoVM extends BaseInfoVM {
  /** 年齢 */
  age: string
  /** 年齢計算基準日 */
  kijunymd: string
}
/** メニュー種類名称表示用*/
export interface MenuInfoVM {
  /** メニューグループコード */
  menucd: string
  /** メニューグループ名称 */
  menuname: string
  /** 表示状態（文字色） */
  status: string
}
/** メニュー名称表示用*/
export interface MenuTabInfoVM {
  /** メニューグループコード */
  menugroupcd: string
  /** メニューコード */
  menucd: string
  /** メニュー名称*/
  menuname: string
  /** 表示状態（文字色） */
  status: string
}
/** タブ名称表示用*/
export interface TabInfoVM {
  /** タブコード */
  tabcd: string
  /** タブ名称 */
  tabname: string
  /** 表示状態（文字色） */
  status: string
}
/** 履歴回数表示用*/
export interface KaisuInfoVM {
  /** 履歴回数 */
  kaisu: number
}
/** 乳幼児詳細画面_フリー項目情報（表示用）*/
export interface FreeItemDispInfoVM extends FreeItemBaseVM {
  /** 履歴回数 */
  groupid?: string
  /** 並びシーケンス */
  orderseq: number
}
/** 乳幼児詳細画面_独自項目情報*/
export interface DokujiInfoVM {
  /** 枝番 */
  edano: string
  /** 値 */
  value: string
}
/** 乳幼児詳細画面_フリー項目情報（保存用）*/
export interface FreeItemInfoVM {
  /** 入力タイプ */
  inputtype: number
  /** 項目（名称） */
  item: string
  /** 値 */
  value?: string
}
/** 発育曲線表示用*/
export interface AtenaInfoVM {
  /** 氏名_優先 */
  simei_yusen: string
  /** 住登区分名称 */
  jutoknm: string
  /** 住民種別名称 */
  juminsyubetunm: string
  /** 住民状態名称 */
  juminjotainm: string
  /** 住民区分名称 */
  juminnm: string
}
/** 発育曲線表示用*/
export interface CurveInfoVM {
  /** 履歴回数（発育曲線のX軸） */
  kaisu: string
  /** 値（発育曲線のY軸） */
  value: string
}
/** 妊産婦詳細画面_助成一覧情報（表示用）*/
export interface JoseiInfoVM {
  /** 助成券種類 */
  joseikensyurui: string
  /** 受診年月日 */
  jusinymd: string
  /** 支払金額 */
  siharaikingaku: string
  /** 助成金額 */
  joseikingaku: string
}
/** 妊産婦詳細画面_助成合計情報（表示用）*/
export interface JoseiKekkaInfoVM {
  /** 助成金額（上限額） */
  joseikingakulimit: string
  /** 助成金額（総額） */
  joseikingakusum: string
}
/** 妊産婦詳細画面_フリー項目情報（保存用）*/
export interface FreeItemInfoVM {
  /** 入力タイプ */
  inputtype: number
  /** 項目（名称） */
  item: string
  /** 値 */
  value?: string
}
