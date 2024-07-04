//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface SearchListRequest extends PersonSearchRequest {
  /** 母子種類 */
  bosikbn: string
  /** 母子手帳番号 */
  bhtetyono: string
}
/** 検索処理(結果一覧のリンクをクリック) */
export interface SearchDetailRequest extends CmSearchRequestBase {
  /** 母子種類 */
  bosikbn: string
  /** 宛名番号 */
  atenano: string
  /** 登録番号 */
  torokuno: number
}
/** 検索処理(結果一覧のリンクをクリック) */
export interface SearchSyosaiRequest extends SearchDetailRequest {
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 登録番号連番（多胎管理でない場合は0） */
  torokunorenban: number
  /** 枝番（新規の場合は1を設定する） def=1*/
  edano: number
  /** 回数（新規の場合は0を設定する）def=1*/
  kaisu: number
}
/** 医療機関検索処理 */
export interface SearchKikanNMRequest extends CmSearchRequestBase {
  /** 医療機関コード */
  kikancd: string
}
/** 医師検索処理 */
export interface SearchIshiNMRequest extends CmSearchRequestBase {
  /** 医師コード */
  staffid: string
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
  /** 登録番号 */
  torokuno: number
  /** 登録番号連番 */
  torokunorenban: number
  /** 枝番 */
  edano: number
  /** 回数 */
  kaisu: number
}
/** 保存処理 */
export interface SaveRequest extends KeyRequest {
  /** 費用助成一覧 */
  jyoseilistinfo: JyoseiListInfoVM[]
  /** 固定項目情報 */
  fixiteminfo: FreeItemInfoVM[]
  /** フリー項目情報 */
  freeiteminfo: FreeItemInfoVM[]
}
export interface SaveData {
  /** フリー項目情報 */
  savedata: SaveRequest[]
}
export interface SaveAllRequest extends CmSaveRequestBase {
  /** 画面情報（全て業務） */
  saveinfo: SaveRequest[]
}
/** 削除処理 */
export interface DeleteRequest extends KeyRequest {
  /** 削除フラグ  True：全ての詳細内容削除、False：選択中の履歷のみ削除*/
  delflg: boolean
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 妊産婦一覧画面検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 詳細項目タイトル */
  syosaititle: string
  /** 結果リスト(妊産婦一覧) */
  kekkalist: NinsanpuListVM[]
}
/** 妊産婦詳細画面検索処理(一覧画面) */
export interface SearchDetailResponse extends SearchSyosaiResponse {
  /** 妊産婦情報（ヘッダー情報） */
  headerinfo: HeaderInfoVM
  /** 妊産婦メニュー種類 */
  menulist: MenuInfoVM[]
  /** フリー項目グループ１リスト */
  grouplist1: DaSelectorModel[]
  /** フリー項目グループ２リスト */
  grouplist2: DaSelectorModel[]
}
/** 妊産婦詳細画面検索処理(一覧画面) */
export interface SearchSyosaiResponse extends CmSearchResponseBase {
  /** 登録番号 */
  torokuno: number
  /** 妊産婦タブ一覧 */
  tablist: TabInfoVM[]
  /** 最大回数（新規の場合は最大履歴回数＋１） */
  maxkaisu: number
  /** 上限回数 */
  limitkaisu: number
  /** 回数タブ一覧（新規の場合は最大履歴回数＋１も含める） */
  kaisulist: KaisuInfoVM[]
  /** 妊産婦フリー項目情報（表示用） */
  freeitemlist: FreeItemDispInfoVM[]
  /** 固定項目情報 */
  fixitemlist: FreeItemDispInfoVM[]
}
/** 医療機関検索 */
export interface SearchKikanNMResponse extends CmSearchResponseBase {
  /** 医療機関コード名称 */
  KikanNM: string
}
/** 医師検索処理 */
export interface SearchIshiNMResponse extends CmSearchResponseBase {
  /** 医師名称 */
  ishinm: string
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
/** 検索処理(妊産婦一覧画面) */
export interface NinsanpuListVM extends BaseInfoVM {
  /** 編集状態 */
  datasts?: string
  /** 行政区 */
  gyoseiku: string
  /** 詳細（メニュー名称文字列） */
  syosai: string
  /** 母子手帳番号 */
  bhtetyono: string
  /** 登録番号 */
  torokuno: number
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
  menugroupcd: string
  /** メニューグループ名称 */
  menugroupname: string
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
/** 妊産婦詳細画面_固定項目情報（表示用）*/
export interface FixItemDispInfoVM extends FreeItemDispInfoVM {}
/** 妊産婦詳細画面_フリー項目情報（表示用）*/
export interface FreeItemDispInfoVM extends FreeItemBaseVM {
  /** 履歴回数 */
  groupid?: string
  /** 並びシーケンス */
  orderseq: number
}
/** 妊産婦詳細画面_独自項目情報*/
export interface DokujiInfoVM {
  /** 枝番 */
  edano: string
  /** 値 */
  value: string
}
/** 妊産婦詳細画面_フリー項目情報（保存用）*/
export interface FreeItemInfoVM {
  /** 入力タイプ */
  inputtype: number
  /** 項目（名称） */
  item: string
  /** 値 */
  value?: object
}
/** 費用助成一覧（表示用） */
export interface JyoseiListInfoVM {
  /** No. */
  no: string
  /** 助成券種類 */
  joseikensyurui: string
  /** 受診年月日 */
  jusinymd: string
  /** 支払金額 */
  siharaikingaku: number
  /** 助成金額 */
  joseikingaku: number
  /** 助成金額（限度額）*/
  joseikingakugendogaku: number
}
