/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 基準値保守
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.1.16
 * 作成者　　: 張加恒
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理(一覧) */
export interface SearchRequest extends DaRequestBase {
  /** 業務 */
  gyomukbn: string
  /** 事業（基準値事業コード） */
  kijunjigyo: string
}
/** 初期化処理(詳細画面) */
export interface InitDetailRequest extends DaRequestBase {
  /** 業務 */
  gyomukbn: string
  /** 事業（基準値事業コード） */
  kijunjigyocd: string
  /** 項目コード */
  itemcd: string
  /** 枝番 */
  edano: string
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** フリー項目マスタ情報取得処理(詳細画面) */
export interface GetFreeMstInfoRequest extends DaRequestBase {
  /** 業務 */
  gyomukbncd: string
  /** 事業（基準値事業コード） */
  kijunjigyocd: string
  /** 項目コード */
  itemcd: string
  /** 枝番 */
  edano: string
}
/** 保存処理(詳細画面) */
export interface SaveRequest extends InitDetailRequest {
  /** 保存情報 */
  saveinfo: SaveMainVM
}
/** 削除処理(詳細画面) */
export interface DeleteRequest extends DaRequestBase {
  /** 業務 */
  gyomukbn: string
  /** 事業（基準値事業コード） */
  kijunjigyocd: string
  /** 項目名称 */
  itemcd: string
  /** 枝番 */
  edano: string
  /** 更新日時 */
  upddttm: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(業務) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(事業)：成人 */
  selectorlist2: DaSelectorModel[]
  /** ドロップダウンリスト(事業)：母子 */
  selectorlist3: DaSelectorModel[]
  /** ドロップダウンリスト(事業)：予防 */
  selectorlist4: DaSelectorModel[]
}
/** 検索処理(一覧画面) */
export interface SearchListResponse extends CmSearchResponseBase {
  /** 結果リスト(基準値保守一覧) */
  kekkalist: RowVM[]
}
/** 項目名称変更処理（詳細画面）*/
export interface GetFreeMstInfoResponse extends DaResponseBase {
  /** 項目名称変更情報 */
  freemstinfo: FreeMstInfoVM
}
/** 初期化処理(詳細画面) */
export interface InitDetailResponse extends GetFreeMstInfoResponse {
  /** ドロップダウンリスト(項目名称)　新規の場合のみ */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(性別) */
  selectorlist2: DaSelectorModel[]
  /** 項目名称 編集の場合のみ */
  itemnm: string
  /** 業務（名称） */
  gyomukbnnm: string
  /** 事業（名称） */
  kijunjigyonm: string
  /** 基準値保守情報(詳細画面) */
  saveinfo: SaveMainVM
}
export interface InitData {
  /** 項目名称 編集の場合のみ */
  itemnm: string
  /** 業務（名称） */
  gyomukbnnm: string
  /** 事業（名称） */
  kijunjigyonm: string
  /** 基準値保守情報(詳細画面) */
  saveinfo: SaveMainVM
  /** 項目名称変更情報 */
  freemstinfo: FreeMstInfoVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 検索処理(一覧画面) */
export interface RowVM {
  /** 項目名称 */
  itemnm: string
  /** 項目コード */
  itemcd: string
  /** 性別 */
  sex: string
  /** 年齢範囲 */
  age: string
  /** 単位 */
  tani: string
  /** 基準範囲 */
  kijunvaluehyoki: string
  /** 要注意 */
  alertvaluehyoki: string
  /** 異常値 */
  errvaluehyoki: string
  /** 有効年月日開始 */
  yukoymdf: string
  /** 有効年月日終了 */
  yukoymdt: string
  /** 有効年月日範囲 */
  yukoymd: string
  /** 有効フラグ */
  yukoflg: boolean
  /** 枝番 */
  edano: string
}
/** 項目名称変更情報(詳細画面) */
export interface FreeMstInfoVM {
  /** 単位 */
  tani: string
  /** 入力フラグ */
  inputflgstr: string
  /** 表示年度（開始）フロント */
  hyojinendof: string
  /** 表示年度（終了）フロント */
  hyojinendot: string
  /** 入力タイプフラグ */
  numcdflg: boolean
  /** ドロップダウンリスト(基準値（コード）) */
  selectorlist3: DaSelectorModel[]
}
/** 基準値保守保存情報(詳細画面) */
export interface MainNumsetInfoVM {
  /** 異常値1 */
  errvalue1t: string
  /** 注意値1（開始） */
  alertvalue1f: string
  /** 注意値1（終了） */
  alertvalue1t: string
  /** 基準値1（開始） */
  kijunvaluef: string
  /** 基準値1（終了） */
  kijunvaluet: string
  /** 注意値2（開始） */
  alertvalue2f: string
  /** 注意値2（終了） */
  alertvalue2t: string
  /** 異常値2 */
  errvalue2f: string
}
/** 基準値保守コード設定情報(詳細画面) */
export interface MainCodesetInfoSaveVM {
  /** 基準値（コード） */
  hanteicdlist: string[]
  /** 注意値（コード） */
  alerthanteicdlist: string[]
  /** 異常値（コード） */
  errhanteicdlist: string[]
}
/** 基準値保守情報(メイン：保存用) */
export interface SaveMainVM {
  /** 年齢指定 */
  ageflg: boolean
  /** 年齢（開始） */
  agef: string
  /** 年齢（終了） */
  aget: string
  /** 性別指定 */
  sexflg: boolean
  /** 性別 */
  sex: string
  /** 有効年月日（開始） */
  yukoymdf: string
  /** 有効年月日（終了） */
  yukoymdt: string
  /** 基準値表記 */
  kijunvaluehyoki: string
  /** 注意値表記 */
  alertvaluehyoki: string
  /** 異常値表記 */
  errvaluehyoki: string
  /** 基準値保守コード設定情報 */
  maincodesetinfo: MainCodesetInfoSaveVM
  /** 基準値保守数値設定情報 */
  mainnumsetinfo: MainNumsetInfoVM
  /** 項目名称変更情報 */
  freemstinfo: FreeMstInfoVM
  /** 更新日時 */
  upddttm: string
}
/** 基準値保守情報 */
export interface ItemVM {
  /** 項目名称 */
  itemnm: string
  /** 単位 */
  tani: string
}
