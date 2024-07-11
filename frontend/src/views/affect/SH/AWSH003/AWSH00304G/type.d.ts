/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 年度切替
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.02.09
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import {
  LockVM,
  RowVM,
  SearchRequest,
  InitResponse as SH301InitResponse
} from '@/views/affect/SH/AWSH003/AWSH00301G/type'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 保存処理 */
export interface SaveRequest extends SearchRequest {
  /** 情報一覧 */
  kekkalist: RowVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
  /** 引継ぎ区分コード */
  hikitugikbn: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理 */
export interface InitResponse extends SH301InitResponse {
  /** 引継ぎ区分一覧 */
  selectorlist8: DaSelectorModel[]
}
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 情報一覧 */
  kekkalist: RowVM[]
  /** 排他チェック用リスト */
  locklist: LockVM[]
}
