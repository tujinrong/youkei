/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: EUC業務共通
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.03.15
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
type SearchVM_AF703 = import('@/views/affect/AF/AWAF00703D/type').SearchVM

/**詳細検索条件 */
interface DetailKensakuJyokenVM extends SearchVM_AF703 {
  /**項目物理名1 */
  komokunm1?: string
  /**コントローラータイプ */
  ctrltype?: import('#/Enums').Enumコントローラータイプ
}

/**プレビュー処理 */
interface CmPreviewResponseBase extends DaResponseBase {
  /**ファイル名 */
  filenm: string
  /**データ */
  data: any[]
  /**コンテンツタイプ */
  contenttype: string
}

/**ダウンロード処理 */
interface CmDownloadResponseBase extends CmPreviewResponseBase {
  /**ファイルタイプ */
  downloadtype: import('#/Enums').EnumDownloadType
  /**ファイル名(パス含む) */
  filefullnm: string
}

/** 検索条件 */
interface KensakuJyokenVM {
  /**条件シーケンス */
  jyokenseq: number
  /**検索条件区分 */
  jyokenkbn: import('#/Enums').Enum検索条件区分
  /**ラベル */
  jyokenlabel: string
  /**変数名 */
  variables?: string
  /**SQL */
  sql: string
  /**テーブル別名 */
  tablealias: string
  /**コントロール区分 */
  controlkbn?: import('#/Enums').Enumコントロール
  /**必須フラグ */
  hissuflg: boolean
  /**データ型 */
  datatype: import('#/Enums').EnumDataType
  /**選択リスト */
  selectorlist?: DaSelectorModel[]
  /**値 */
  value?: object
}

/** 抽出パネル情報*/
interface TyusyutuVM {
  /**抽出対象コード */
  tyusyututaisyocd: string
  /**年度 */
  nendo: string
  /**抽出内容 */
  tyusyutunaiyo: string
  /**帳票出力区分 */
  tyusyutukbn: string
  /**様式種別 */
  yosikisyubetu: string
}

/**  出力情報*/
interface OutPutInfoVM {
  /**発行日 */
  printdate: string
  /**枚目から */
  startdetailcount: number
}
