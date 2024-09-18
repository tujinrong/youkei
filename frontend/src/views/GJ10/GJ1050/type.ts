/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 事務委託先別·: 契約者別生產者積立金等一覧表
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.30
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理_プレビュー画面リクエスト */
export interface InitRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
}
/** プレビュー処理_プレビュー画面リクエスト */
export interface PreviewRequest extends DaRequestBase {
  /** 対象期 */
  KI: number
  /** 出力区分 */
  SYUTURYOKU_KBN: number
  /** 契約区分 */
  KEIYAKU_KBN: CmCodeFmToModel
  /** 契約状況 */
  KEIYAKU_JYOKYO: KeiyakuJyokyo
  /** 入力状況 */
  NYURYOKU_JYOKYO: NyuryokuJyokyo
  /** 都道府県 */
  KEN_CD: CmCodeFmToModel
  /** 事務委託先 */
  ITAKU_CD: CmCodeFmToModel
  /** 契約者番号 */
  KEIYAKUSYA_CD: CmCodeFmToModel
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理_プレビュー画面レスポンス */
export interface InitResponse extends DaResponseBase {
  /** 対象期 */
  KI: number

  /** 契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[]

  /** 都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]

  /** 事務委託先情報プルダウンリスト */
  JIMUITAKU_LIST: CmCodeNameModel[]

  /** 契約者番号情報プルダウンリスト */
  KEIYAKUSYA_LIST: CmCodeNameModel[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 契約状況クラス */
export interface KeiyakuJyokyo {
  /** 新規契約者 */
  SHINKI?: boolean
  /** 継続契約者 */
  KEIZOKU?: boolean
  /** 中止契約者 */
  CHUSHI?: boolean
}
/** 入力状況クラス */
export interface NyuryokuJyokyo {
  /** 入力中 */
  NYURYOKU_TYU?: boolean
  /** 入力確定 */
  NYURYOKU_KAKUTEI?: boolean
}
