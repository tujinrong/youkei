//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 発育曲線表示処理 */
export interface ShowCurveRequest extends CmSearchRequestBase {
  /** 母子種類  def=2*/
  bosikbn: string
  /** 宛名番号 */
  atenano: string
}
//レスポンス
//-------------------------------------------------------------------
/** 発育曲線表示処理 */
export interface ShowCurveResponse extends CmSearchResponseBase {
  /** 乳幼児情報（固定部分） */
  headerinfo: HeaderInfoVM
  /** 発育曲線リスト */
  graphlist: GraphListVM[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 発育曲線ヘッダー情報 */
export interface HeaderInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
}
/** 発育曲線表示用 */
export interface CurveInfoVM {
  /** 回数（発育曲線のX軸） */
  kaisu: number
  /** 値（発育曲線のY軸） */
  value?: object
}
/** 発育曲線表示用 */
export interface GraphListVM {
  /** 発育曲線番号 */
  no: number
  /** 部位名称 */
  itemnm: string
  /** 単位 */
  tani: string
  /** 本人のグラフ */
  curveinfolist: CurveInfoVM[]
  /** P3(全体3%)のグラフ */
  p3curveinfolist: CurveInfoVM[]
  /** P97(全体97%)のグラフ*/
  p97curveinfolist: CurveInfoVM[]
}
