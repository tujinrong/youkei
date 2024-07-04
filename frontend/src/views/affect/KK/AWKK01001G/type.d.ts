/// <summary>
/// 一覧データモデル(行単位)

import { Enum名称区分 } from '#/Enums'

/// </summary>
export interface RowVM {
  /**宛名番号 */
  atenano: string
  /**氏名 */
  name: string
  /**カナ氏名 */
  kname: string
  /**性別 */
  sex: string
  /**生年月日 */
  bymd: string
  /**住所 */
  adrs: string
  /**行政区 */
  gyoseiku: string
  /**住民区分 */
  juminkbn: string
  /**対象外者区分 */
  taisyogaikbn: string
  /**警告内容 */
  keikoku: string
}

/// <summary>
/// 排他モデル
/// </summary>
export interface LockVM {
  /**帳票グループID */
  rptgroupid: string
  /**更新日時 */
  upddttm?: Date | string
}

/// <summary>
/// 保存処理モデル
/// </summary>
export interface SaveVM extends LockVM {
  /**受付日 */
  uketukeymd: string
  /**対象外理由 */
  taisyogairiyu: string
}

/// <summary>
/// 画面表示内容モデル
/// </summary>
export interface InitVM extends SaveVM {
  /**対象外者区分 */
  taisyogaikbn: boolean
  /**帳票グループ名 */
  rptgroupnm: string
  /**業務区分(フィルター用) */
  gyomukbn: string
  /**業務区分名 */
  gyomukbnnm: string
}

/// <summary>
/// 初期化処理(詳細画面)
/// </summary>
export interface InitRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
  /**名称区分(処理区分) */
  kbn: Enum名称区分
}

/// <summary>
/// 保存処理(詳細画面)
/// </summary>
export interface SaveRequest extends DaRequestBase {
  /**宛名番号 */
  atenano: string
  /**保存リスト */
  savelist: SaveVM[]
  /**排他チェック用リスト */
  locklist: LockVM[]
}

/// <summary>
/// 検索処理(一覧画面)
/// </summary>
export interface SearchResponse extends CmSearchResponseBase {
  /**一覧情報 */
  kekkalist: RowVM[]
}

/// <summary>
/// 初期化処理(詳細画面)
/// </summary>
export interface InitResponse extends DaResponseBase {
  /**個人基本情報 */
  headerinfo: GamenHeaderBaseVM
  /**業務区分一覧 */
  selectorlist: DaSelectorModel[]
  /**結果リスト(対象外者情報) */
  kekkalist: InitVM[]
}
