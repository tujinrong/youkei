/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.02
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import {
  Enum名称区分,
  Enum編集区分,
  Enum入力タイプ,
  Enum指導区分,
  Enum申込結果,
  Enum項目用途区分,
  Enum事業区分,
  Enum精密検査実施区分,
  Enum入力タイプ分類,
  Enumフリー項目区分区分
} from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理(選択画面) */
export interface InitChoiceRequest extends DaRequestBase {
  /** 名称区分(業務) */
  kbn1: Enum名称区分
  /** 名称区分(種類) */
  kbn2: Enum名称区分
}
/** 初期化処理(検診画面共通) */
export interface InitKensinCommonRequest extends DaRequestBase {
  /** 成人健（検）診事業コード */
  jigyocd?: string
}
/** 保存処理(検診事業詳細画面) */
export interface SaveKensinJigyoDetailRequest extends InitKensinCommonRequest {
  /** 更新日時(排他用) */
  upddttm?: Date | string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 事業名 */
  jigyonm: string
  /** 事業名略称 */
  jigyoshortnm: string
  /** 検診事業情報(事業内容) */
  jigyoinfo: KensinDetailJigyoVM
  /** 検診事業情報(検査方法) */
  hohoinfo: KensinDetailHohoSaveVM
  /** 検診事業情報(予約分類) */
  yoyakuinfo: KensinDetailYoyakuSaveVM
  /** 検診事業情報(フリー項目) */
  freeinfo: KensinDetailFreeSaveVM
  /** 検診事業情報(エラーチェック) */
  errorchkinfo: KensinDetailErrorchkSaveVM
}
/** 初期化処理(検診項目詳細画面) */
export interface InitKensinItemDetailRequest extends DaRequestBase {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 項目コード */
  itemcd?: string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コピーフラグ(コピーの場合、true) */
  copyflg: boolean
  /** 半角タイプ入力上限値フラグ（一次） */
  halfflg1: boolean
  /** 日付タイプ入力上限値フラグ（一次） */
  dayflg1: boolean
  /** 全角タイプ入力上限値フラグ（一次） */
  fullflg1: boolean
  /** コードタイプ入力上限値フラグ（一次） */
  cdflg1: boolean
  /** 半角タイプ入力上限値フラグ（精密） */
  halfflg2: boolean
  /** 日付タイプ入力上限値フラグ（精密） */
  dayflg2: boolean
  /** 全角タイプ入力上限値フラグ（精密） */
  fullflg2: boolean
  /** コードタイプ入力上限値フラグ（精密） */
  cdflg2: boolean
}
/** 条件コードリスト取得(検診項目詳細画面) */
export interface GetCodejokenListRequest extends DaRequestBase {
  /** 入力タイプ */
  inputtype: Enum入力タイプ
  /** コード条件1 */
  codejoken1?: string
  /** コード条件2 */
  codejoken2?: string
  /** コード条件3 */
  codejoken3?: string
  /** 成人健（検）診事業コード(検診の場合のみ) */
  jigyocd?: string
  /** グループID(コード：名称)(検診の場合のみ) */
  group?: string
}
/** 保存処理(検診項目詳細画面) */
export interface SaveKensinItemDetailRequest extends DaRequestBase {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 検診項目詳細 */
  detailinfo: KensinItemDetailSaveVM
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理(検診項目詳細画面) */
export interface DeteleKensinItemDetailRequest extends DaRequestBase {
  /** 成人健（検）診事業コード */
  jigyocd: string
  /** 項目コード */
  itemcd: string
  /** 更新日時(排他用) */
  upddttm: Date | string
}
/** 検索処理(指導項目一覧画面) */
export interface SidoCommonRequest extends DaRequestBase {
  /** 指導区分 */
  sidokbn: Enum指導区分
  /** 業務区分 */
  gyomukbn: string
  /** 申込結果区分 */
  mosikomikekkakbn: Enum申込結果
  /** 項目用途区分 */
  itemyotokbn: Enum項目用途区分
}
/** 初期化処理(指導項目詳細画面) */
export interface InitSidoItemDetailRequest extends SidoCommonRequest {
  /** 項目コード */
  itemcd?: string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** コピーフラグ(コピーの場合、true) */
  copyflg: boolean
  /** 半角タイプ入力上限値フラグ */
  halfflg: boolean
  /** 日付タイプ入力上限値フラグ */
  dayflg: boolean
  /** 全角タイプ入力上限値フラグ */
  fullflg: boolean
  /** コードタイプ入力上限値フラグ */
  cdflg: boolean
}
/** 保存処理(指導項目詳細画面) */
export interface SaveSidoItemDetailRequest extends SidoCommonRequest {
  /** 項目コード */
  itemcd: string
  /** 編集区分 */
  editkbn: Enum編集区分
  /** 指導項目詳細 */
  detailinfo: SidoItemDetailVM
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 削除処理(指導項目詳細画面) */
export interface DeteleSidoItemDetailRequest extends SidoCommonRequest {
  /** 項目コード */
  itemcd: string
  /** 更新日時(排他用) */
  upddttm: Date | string
}
/** 検索処理/引継ぎ処理(検診予約事業一覧画面) */
export interface KensinYoyakuJigyoListCommonRequest extends DaRequestBase {
  /** 年度 */
  nendo: number
}
/** 初期化処理(検診予約事業詳細画面) */
export interface InitKensinYoyakuJigyoDetailRequest extends KensinYoyakuJigyoListCommonRequest {
  /** 検診予約事業コード */
  jigyocd?: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 保存処理(検診予約事業詳細画面) */
export interface SaveKensinYoyakuJigyoDetailRequest extends InitKensinYoyakuJigyoDetailRequest {
  /** メイン情報 */
  maininfo: KensinYoyakuDetailMainSaveVM
  /** 検査方法一覧 */
  kekkalist: KensinYoyakuDetailRowSaveVM[]
  /** チェック用フラグ */
  chkflg: boolean
}
/** 削除処理(検診予約事業詳細画面) */
export interface DeleteKensinYoyakuJigyoDetailRequest extends KensinYoyakuJigyoListCommonRequest {
  /** 検診予約事業コード */
  jigyocd: string
  /** 更新日時(排他用) */
  upddttm: Date | string
}
/** 保存処理(その他予約事業一覧画面) */
export interface SaveYoyakuSidoJigyoListRequest extends DaRequestBase {
  /** その他予約事業一覧 */
  kekkalist: YoyakuSidoJigyoRowSaveVM[]
  /** 排他チェック用リスト */
  locklist: YoyakuSidoJigyoLockVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(選択画面) */
export interface InitChoiceResponse extends DaResponseBase {
  /** 業務区分一覧 */
  selectorlist1: DaSelectorModel[]
  /** 種類区分一覧 */
  selectorlist2: DaSelectorKeyModel2[]
}
/** 初期化処理(検診事業一覧画面) */
export interface InitKensinListResponse extends DaResponseBase {
  /** 検診事業一覧 */
  kekkalist: KensinListRowVM[]
  /** 新規フラグ */
  insertflg: boolean
  /** 拡張事業入力件数カウント */
  kensucnt: string
}
/** 初期化処理(検診事業詳細画面) */
export interface InitKensinDetailResponse extends DaResponseBase {
  /** 更新日時(排他用) */
  upddttm?: Date | string
  /** 検診共通画面ヘッダー情報 */
  headerinfo: KensinCommonHeaderVM
  /** 検診事業情報(事業内容) */
  jigyoinfo: KensinDetailJigyoVM
  /** 検診事業情報(検査方法) */
  hohoinfo: KensinDetailHohoVM
  /** 検診事業情報(予約分類) */
  yoyakuinfo: KensinDetailYoyakuVM
  /** 検診事業情報(フリー項目) */
  freeinfo: KensinDetailFreeVM
  /** 検診事業情報(エラーチェック) */
  errorchkinfo: KensinDetailErrorchkSaveVM
  /** 精密検査実施区分ドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** クーポン券表示区分ドロップダウンリスト */
  selectorlist2: DaSelectorModel[]
  /** 減免区分ドロップダウンリスト */
  selectorlist3: DaSelectorModel[]
  /** 生涯１回フラグドロップダウンリスト */
  selectorlist4: DaSelectorModel[]
  /** メッセージ区分一覧ドロップダウンリスト */
  selectorlist5: DaSelectorModel[]
}
/** 保存処理(検診事業詳細画面) */
export interface SaveKensinJigyoDetailResponse extends DaResponseBase {
  /** 機能ID(新規用) */
  kinoid: string
}
/** 初期化処理(検診項目一覧画面) */
export interface InitKensinItemListResponse extends DaResponseBase {
  /** 検診項目一覧画面ヘッダー情報 */
  headerinfo: KensinCommonHeaderVM
  /** 検診項目一覧 */
  kekkalist: KensinItemListRowVM[]
  /** 半角タイプ入力上限値フラグ（一次） */
  halfflg1: boolean
  /** 日付タイプ入力上限値フラグ（一次） */
  dayflg1: boolean
  /** 全角タイプ入力上限値フラグ（一次） */
  fullflg1: boolean
  /** コードタイプ入力上限値フラグ（一次） */
  cdflg1: boolean
  /** 半角タイプ入力上限値フラグ（精密） */
  halfflg2: boolean
  /** 日付タイプ入力上限値フラグ（精密） */
  dayflg2: boolean
  /** 全角タイプ入力上限値フラグ（精密） */
  fullflg2: boolean
  /** コードタイプ入力上限値フラグ（精密） */
  cdflg2: boolean
  /** ボタン制御フラグ(新規・コピー) */
  buttonflg: boolean
  /** 拡張事業入力件数カウント（一次） */
  kensuichijicnt: string
  /** 拡張事業入力件数カウント（精密） */
  kensuseimitsucnt: string
}
/** 初期化処理(検診項目詳細画面) */
export interface InitKensinItemDetailResponse extends GetCodejokenListResponse {
  /** 検診項目詳細画面ヘッダー情報 */
  headerinfo: KensinCommonHeaderVM
  /** 検診項目詳細 */
  detailinfo: KensinItemDetailInitVM
  /** 表示区分(グループID2) */
  showkbn1: boolean
  /** 表示区分(検査方法) */
  showkbn2: boolean
  /** グループIDドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** グループID2ドロップダウンリスト */
  selectorlist2: DaSelectorModel[]
  /** メッセージ区分ドロップダウンリスト */
  selectorlist3: DaSelectorModel[]
  /** 入力タイプドロップダウンリスト（一次） */
  selectorlist4_1: DaSelectorModel[]
  /** 入力タイプドロップダウンリスト（精密） */
  selectorlist4_2: DaSelectorModel[]
  /** 検査方法ドロップダウンリスト */
  selectorlist8: DaSelectorModel[]
  /** 計算区分ドロップダウンリスト */
  selectorlist9: DaSelectorModel[]
  /** 計算関数ID(内部)ドロップダウンリスト */
  selectorlist10: DaSelectorKeyModel[]
  /** 計算関数ID(内部)備考 */
  idNaibubiko?: string
  /** 計算関数ID(DB)ドロップダウンリスト */
  selectorlist11: DaSelectorKeyModel[]
  /** 計算関数ID(DB)備考 */
  idDbbiko?: string
  /** 項目一覧ドロップダウンリスト */
  selectorlist12: DaSelectorModel[]
  /** 項目特定区分ドロップダウンリスト */
  selectorlist13: DaSelectorModel[]
  /** 削除ボタン活性フラグ */
  deleteFlg: boolean
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 条件コードリスト取得(検診項目詳細画面) */
export interface GetCodejokenListResponse extends DaResponseBase {
  /** コード条件1ドロップダウンリスト */
  selectorlist5: DaSelectorModel[]
  /** コード条件2ドロップダウンリスト */
  selectorlist6: DaSelectorModel[]
  /** コード条件3ドロップダウンリスト */
  selectorlist7: DaSelectorModel[]
}
/** 初期化処理(指導項目一覧画面) */
export interface InitSidoItemListResponse extends DaResponseBase {
  /** 指導区分ドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** 業務区分ドロップダウンリスト */
  selectorlist2: DaSelectorModel[]
  /** 申込結果ドロップダウンリスト */
  selectorlist3: DaSelectorModel[]
  /** 項目用途区分ドロップダウンリスト */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(指導項目一覧画面) */
export interface SearchSidoItemListResponse extends DaResponseBase {
  /** 指導項目一覧 */
  kekkalist: ItemListRowBaseVM[]
  /** 半角タイプ入力上限値フラグ */
  halfflg: boolean
  /** 日付タイプ入力上限値フラグ */
  dayflg: boolean
  /** 全角タイプ入力上限値フラグ */
  fullflg: boolean
  /** コードタイプ入力上限値フラグ */
  cdflg: boolean
  /** ボタン制御フラグ(新規・コピー) */
  buttonflg: boolean
  /** 拡張事業入力件数カウント */
  kensucnt: string
}
/** 初期化処理(指導項目詳細画面) */
export interface InitSidoItemDetailResponse extends GetCodejokenListResponse {
  /** 指導項目詳細画面ヘッダー情報 */
  headerinfo: SidoCommonHeaderVM
  /** 指導項目詳細 */
  detailinfo: SidoItemDetailVM
  /** グループIDドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** グループID2ドロップダウンリスト */
  selectorlist2: DaSelectorModel[]
  /** メッセージ区分ドロップダウンリスト */
  selectorlist3: DaSelectorModel[]
  /** 入力タイプドロップダウンリスト */
  selectorlist4: DaSelectorModel[]
  /** 利用地域保健集計区分ドロップダウンリスト */
  selectorlist8: DaSelectorModel[]
  /** 項目特定区分ドロップダウンリスト */
  selectorlist9: DaSelectorModel[]
  /** 更新日時(排他用) */
  upddttm?: Date | string
}

/** 検索処理(検診予約事業一覧画面) */
export interface SearchKensinYoyakuJigyoListResponse extends DaResponseBase {
  /** 検診予約事業一覧 */
  kekkalist: KensinYoyakuListRowVM[]
}
/** 初期化処理(検診予約事業詳細画面) */
export interface InitKensinYoyakuJigyoDetailResponse extends DaResponseBase {
  /** メイン情報 */
  maininfo: KensinYoyakuDetailMainVM
  /** 検査方法一覧 */
  kekkalist: KensinYoyakuDetailRowVM[]
  /** 料金パターンドロップダウンリスト */
  selectorlist1: DaSelectorModel[]
  /** 検診予約事業ドロップダウンリスト(新規の場合のみ) */
  selectorlist2: DaSelectorModel[]
}
/** 初期化処理(その他予約事業一覧画面) */
export interface InitYoyakuSidoJigyoListResponse extends DaResponseBase {
  /** その他予約事業一覧 */
  kekkalist: YoyakuSidoJigyoRowVM[]
  /** 業務区分ドロップダウンリスト */
  selectorlist: DaSelectorKeyModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検診共通画面ヘッダーモデル */
export interface DaSelectorKeyModel2 extends DaSelectorModel {
  /** キー項目(連動フィルター用) */
  key: string
  /** 説明 */
  comment: string
}
/** 検診事業一覧画面行モデル */
export interface KensinListRowVM {
  /** 事業コード */
  jigyocd: string
  /** 事業名 */
  jigyonm: string
  /** 事業区分 */
  jigyokbn: Enum事業区分
  /** 事業区分名 */
  jigyokbnnm: string
  /** 精密検査実施区分 */
  seikenjissikbn: Enum精密検査実施区分
  /** 精密検査実施区分名 */
  seikenjissikbnnm: string
  /** 機能ID */
  kinoid: string
}
/** 検診共通画面ヘッダーモデル */
export interface KensinCommonHeaderVM {
  /** 事業名 */
  jigyonm: string
  /** 事業名略称 */
  jigyoshortnm: string
}
/** 検診事業詳細(事業内容) */
export interface KensinDetailJigyoVM {
  /** 機能ID */
  kinoid?: string
  /** 機能表示名称 */
  hyojinm: string
  /** 精密検査実施区分(コード：名称) */
  seikenjissikbn: string
  /** クーポン券表示区分(コード：名称) */
  cuponhyojikbn: string
  /** 減免区分(コード：名称) */
  genmenkbn: string
  /** 生涯１回フラグ */
  syogaiikaiflg: string
}
/** 検診事業詳細(検査方法) */
export interface KensinDetailHohoVM extends KensinDetailHohoSaveVM {
  /** 検査方法メインコード名 */
  kensahoho_maincdnm: string
}
/** 検診事業詳細(検査方法):保存処理 */
export interface KensinDetailHohoSaveVM {
  /** 検査方法設定フラグ */
  kensahoho_setflg: boolean
  /** 検査方法サブコード名 */
  kensahoho_subcdnm: string
  /** 検査方法一覧 */
  kekkalist: KensinDetailHohoRowVM[]
}
/** 検診事業詳細(予約分類) */
export interface KensinDetailYoyakuVM extends KensinDetailYoyakuSaveVM {
  /** 予約分類メインコード名 */
  yoyakubunrui_maincdnm: string
}
/** 検診事業詳細(予約分類):保存処理 */
export interface KensinDetailYoyakuSaveVM {
  /** 予約分類サブコード名 */
  yoyakubunrui_subcdnm: string
  /** 予約分類一覧 */
  kekkalist: KensinDetailYoyakuRowVM[]
}
/** 検診事業詳細(フリー項目) */
export interface KensinDetailFreeVM extends KensinDetailFreeSaveVM {
  /** グループ2メインコード名 */
  groupid2_maincdnm: string
}
/** 検診事業情報(エラーチェック) */
export interface KensinDetailErrorchkVM {
  /** 予約画面チェック区分 */
  yoyakuchk: string
  /** 健（検）診画面チェック区分 */
  kensinchk: string
}
/** 検診事業詳細(フリー項目):保存処理 */
export interface KensinDetailFreeSaveVM {
  /** グループ2サブコード名 */
  groupid2_subcdnm: string
  /** 検査分類名一覧 */
  kekkalist: DaSelectorModel[]
}
/** 検診事業情報(エラーチェック):保存処理 */
export interface KensinDetailErrorchkSaveVM {
  /** 予約画面チェック区分 */
  yoyakuchk: string
  /** 健（検）診画面チェック区分 */
  kensinchk: string
}
/** 検査方法行モデル */
export interface KensinDetailHohoRowVM {
  /** 検査方法コード */
  kensahohocd: string
  /** 検査方法名 */
  kensahohonm: string
  /** 検査方法略称 */
  kensahohoshortnm: string
}
/** 予約行モデル */
export interface KensinDetailYoyakuRowVM {
  /** 予約分類コード */
  yoyakubunrui: string
  /** 予約分類名 */
  yoyakubunruinm: string
  /** 予約分類表示名 */
  yoyakubunruishortnm: string
  /** 検査方法コード一覧 */
  yoyakubunruilist: string[]
}
/** 検診項目一覧画面行モデル */
export interface KensinItemListRowVM extends ItemListRowBaseVM {
  /** 利用検査方法名(複数) */
  riyokensahohonms: string
  /** 画面配置フラグ */
  haitiflg: boolean
}
/** 検診項目詳細画面初期化モデル */
export interface KensinItemDetailInitVM extends KensinItemDetailSaveVM {
  /** 計算パラメータ数 */
  keisanparamnum?: number
}
/** 検診項目詳細保存モデル */
export interface KensinItemDetailSaveVM extends FreeItemDetailBaseVM {
  /** 履歴管理フラグ */
  rirekiflg: boolean
  /** 表示年度（開始） */
  hyojinendof?: number
  /** 表示年度（終了） */
  hyojinendot?: number
  /** 計算区分(コード：名称) */
  keisankbn: string
  /** 計算数式 */
  keisansusiki: string
  /** 計算関数ID(コード：名称) */
  keisankansu?: string
  /** 計算パラメータ(複数) */
  keisanparams: string[]
  /** 利用検査方法コード(複数) */
  riyokensahohocds: string[]
}
/** 指導項目一覧画面行モデル */
export interface SidoItemListRowVM extends ItemListRowBaseVM {
  /** 項目用途区分 */
  itemyotokbn: Enum項目用途区分
}
/** 項目一覧画面行ベースモデル */
export interface ItemListRowBaseVM {
  /** 項目コード */
  itemcd: string
  /** 項目名 */
  itemnm: string
  /** 拡張領域使用 */
  kakutyokbn: string
  /** PKG標準・独自区分 */
  pkgdokujikbn: Enum事業区分
  /** PKG標準・独自区分 */
  pkgdokujikbnnm: string
  /** 入力タイプ分類 */
  inputtypekbn: Enum入力タイプ分類
  /** 項目タイプ */
  inputtypekbnnm: string
  /** グループID名 */
  groupnm: string
  /** グループID */
  groupid: string
  /** 項目区分(一覧内容リンク判断用) */
  itemkbn: Enumフリー項目区分区分
}
/** 指導共通画面ヘッダーモデル */
export interface SidoCommonHeaderVM {
  /** 指導区分名称 */
  sidokbnnm: string
  /** 業務区分名称 */
  gyomukbnnm: string
  /** 申込結果区分名称 */
  mosikomikekkakbnnm: string
  /** 項目用途区分名称 */
  itemyotokbnnm: string
}
/** 項目詳細モデルベース */
export interface FreeItemDetailBaseVM {
  /** 項目コード */
  itemcd?: string
  /** 項目名 */
  itemnm: string
  /** グループID(コード：名称) */
  group?: string
  /** グループID2(コード：名称) */
  group2?: string
  /** 入力タイプ(コード：名称) */
  inputtype: string | null
  /** コード条件1(コード：名称) */
  codejoken1?: string
  /** コード条件2(コード：名称) */
  codejoken2?: string
  /** コード条件3(コード：名称) */
  codejoken3?: string
  /** 入力桁 */
  keta?: string
  /** 必須フラグ */
  hissuflg: boolean
  /** 入力範囲（開始） */
  hanif: string
  /** 入力範囲（終了） */
  hanit: string
  /** 入力フラグ */
  inputflg: boolean
  /** メッセージ区分(コード：名称) */
  msgkbn: string
  /** 単位 */
  tani: string
  /** 初期値 */
  syokiti: string
  /** 項目特定区分 */
  komokutokuteikbn?: string
  /** 備考 */
  biko: string
}
/** 指導項目詳細保存モデル */
export interface SidoItemDetailVM extends FreeItemDetailBaseVM {
  /** 利用地域保健集計区分(複数) */
  syukeikbns: string[]
}
/** 検診予約事業一覧画面行モデル */
export interface KensinYoyakuListRowVM {
  /** 事業コード */
  jigyocd: string
  /** 事業名 */
  jigyonm: string
  /** 料金パターン名 */
  ryokinpatternnm: string
  /** 事業内容 */
  jigyonaiyo: string
}
/** 検診予約事業詳細画面行モデル */
export interface KensinYoyakuDetailRowVM extends KensinYoyakuDetailRowSaveVM {
  /** 検診事業名 */
  jigyonm: string
  /** 検査方法名 */
  kensahohonm: string
  /** 実施編集フラグ` */
  jissieditflg: boolean

  key: number
}
/** 検診予約事業詳細画面行モデル(保存用) */
export interface KensinYoyakuDetailRowSaveVM {
  /** 実施フラグ */
  jissiflg: boolean
  /** 検診事業コード */
  jigyocd: string
  /** 検査方法コード */
  kensahohocd: string
  /** オプションフラグ */
  optionflg: boolean
}
/** 検診予約事業詳細メイン情報 */
export interface KensinYoyakuDetailMainVM extends KensinYoyakuDetailMainBaseVM {
  /** 予約日程事業名(変更の場合のみ) */
  jigyonm: string
}
/** 検診予約事業詳細メイン情報(ベース) */
export interface KensinYoyakuDetailMainBaseVM {
  /** 料金パターン(コード：名称) */
  ryokinpatterncdnm: string
  /** 更新日時(排他用) */
  upddttm?: Date | string
}
/** 検診予約事業詳細メイン情報(保存用) */
export interface KensinYoyakuDetailMainSaveVM extends KensinYoyakuDetailMainBaseVM {
  /** 予約日程事業名(新規の場合のみ) */
  jigyocdnm: string
}
/** 予約指導事業行モデル */
export interface YoyakuSidoJigyoRowVM extends YoyakuSidoJigyoRowSaveVM {
  /** 更新日時 */
  upddttm?: Date | string
  /** 編集フラグ(業務区分) */
  editflg: boolean
}
/** 予約指導事業行モデル(保存用) */
export interface YoyakuSidoJigyoRowSaveVM {
  /** その他日程事業・保健指導事業コード */
  jigyocd: string
  /** その他日程事業・保健指導事業名 */
  jigyonm: string
  /** 使用停止フラグ */
  stopflg: boolean
  /** 業務区分(コード：名称) */
  gyomukbncdnm: string
  /** 予約利用フラグ */
  yoyakuriyoflg: boolean
  /** 訪問利用フラグ */
  homonriyoflg: boolean
  /** 相談利用フラグ */
  sodanriyoflg: boolean
  /** 集団利用フラグ */
  syudanriyoflg: boolean
}
/** 排他チェック用モデル(予約指導事業) */
export interface YoyakuSidoJigyoLockVM {
  /** その他日程事業・保健指導事業コード */
  jigyocd: string
  /** 更新日時 */
  upddttm: Date | string
}
