/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: メモ情報
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.08.24
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Enum名称区分 } from '#/Enums'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitRequest extends DaRequestBase {
  /** 名称区分(重要度) */
  kbn1: Enum名称区分
  /** 名称区分(登録事業) */
  kbn2: Enum名称区分
  /** 名称区分(登録支所) */
  kbn3: Enum名称区分
  /** パターンナンバー */
  patternno?: string
}
/** 検索処理 */
export interface SearchRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano: string
  /** パターンナンバー */
  patternno?: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** 新規メモリスト */
  addlist: AddVM[]
  /** 更新メモリスト */
  updlist: UpdVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends DaResponseBase {
  /** ドロップダウンリスト(重要度) */
  selectorlist1: DaSelectorModel[]
  /** ドロップダウンリスト(登録事業) */
  selectorlist2: DaSelectorModel[]
  /** 表示フラグ(登録支所) */
  showflg: boolean
  /** 登録支所 */
  regsisyo: string
  /** csv出力フラグ */
  csvoutflg: boolean
}
/** 検索処理 */
export interface SearchResponse extends CmSearchResponseBase {
  /** 個人基本情報 */
  headerinfo: CommonBarHeaderBaseVM
  /** メモ情報 */
  kekkalist: SearchVM[]
  /** 登録事業(登録範囲-CSV出力用) */
  jigyokbns: string[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** メモ情報(新規) */
export interface AddVM {
  /** 登録事業（共通・各事業） */
  jigyokbn: string
  /** 重要度 */
  juyodo: string
  /** 件名（タイトル） */
  title: string
  /** メモ（フリーテキスト） */
  memo: string
  /** 期限日 */
  kigenymd: string
  /**ユニーク値 */
  key: symbol
}
/** メモ情報(更新) */
export interface UpdVM extends AddVM {
  /** メモシーケンス */
  memoseq: number
}
/** メモ情報(検索) */
export interface SearchVM extends UpdVM {
  /** 登録支所 */
  regsisyo: string
  /** 登録者 */
  regusernm: string
  /** 登録日時 */
  regdttm: Date | string
  /** 登録者 */
  updusernm: string
  /** 更新日時 */
  upddttm: Date | string
  /** 更新権限フラグ */
  updflg: boolean
}
/** 排他チェック用モデル */
export interface LockVM {
  /** メモシーケンス */
  memoseq: number
  /** 更新日時 */
  upddttm: Date | string
}
