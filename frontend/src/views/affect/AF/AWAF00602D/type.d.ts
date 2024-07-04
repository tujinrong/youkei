/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 電子ファイル情報
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.08.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分, Enum編集区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 名称区分(事業区分) */
  kbn: Enum名称区分
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
}
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 事業コード */
  jigyocd: string
  /** タイトル */
  title: string
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
}
/** プレビュー処理 */
export interface PreviewRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** ドキュメントシーケンス */
  docseq: number
}
/** 保存処理 */
export interface SaveRequest extends CmUploadRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 電子ファイル情報(保存用) */
  savevm: SaveVM
  /** 編集区分 */
  editkbn: Enum編集区分
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** キーリスト(排他用) */
  locklist: LockVM[]
}
/** ダウンロード処理 */
export interface DownloadRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** ドキュメントシーケンス */
  docseqs: number[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** ドロップダウンリスト(事業区分) */
  selectorlist: DaSelectorModel[]
}
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 個人基本情報 */
  headerinfo: CommonBarHeaderBaseVM
  /** ドキュメント情報 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** ドキュメント情報(保存用) */
export interface SaveVM extends LockVM {
  /** タイトル */
  title: string
  /** 重要フラグ */
  juyoflg: boolean
  /** ファイル名 */
  filenm: string
  /** 事業(コード：名称) */
  jigyo: string
}
/** ドキュメント情報(一覧) */
export interface SearchVM extends SaveVM {
  /** 画像フラグ */
  imgflg: boolean
  /** 登録日時(アップロード日時) */
  regdttm: Date | string
  /** 事業名 */
  jigyonm: string
  /** 登録支所名 */
  regsisyonm: boolean
  /** 更新権限フラグ */
  updflg: boolean
}
/** 排他チェック用モデル */
export interface LockVM {
  /** ドキュメントシーケンス */
  docseq: number
  /** 更新日時 */
  upddttm: null | string
}
