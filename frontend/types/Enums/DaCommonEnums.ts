/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: システム共通
 *             区分列挙型
 * 作成日　　: 2022.12.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumActionType } from '#/Enums/BaseEnums'
/**レスポンス状態区分 */
export enum EnumServiceResult {
  /**正常 */
  OK,
  /**エラー */
  ServiceError,
  /**アラート */
  ServiceAlert,
  /**非表示 */
  Hidden,
  /**例外 */
  Exception,
  /**利用不可 */
  Forbidden,
  /**権限認証失敗 */
  AuthError,
  /**アラート2(はいだけ) */
  ServiceAlert2,
  /**中断したエラー（前の画面に戻す） */
  InterruptionError
}
export enum EnumLogStatus {
  正常終了 = 0,
  異常終了 = 1,
  要確認 = 3,
  処理停止 = 4
}
/**操作区分 */
export enum EnumAtenaActionType {
  追加 = EnumActionType.Insert,
  更新 = EnumActionType.Update,
  削除 = EnumActionType.Delete,
  検索
}
/**連携区分 */
export enum EnumGaibuKbn {
  /**他システムから取得; */
  FromGaibu = 1,
  /**他システムへ出力 */
  ToGaibu
}
/**連携方式 */
export enum EnumGaibuDataType {
  CSV = 1,
  API
}
/**ファイル種類 */
export enum EnumFileTypeKbn {
  Empty = -1,
  csv = 1,
  doc,
  jpg,
  jpeg,
  png,
  pdf,
  tif,
  txt,
  xml,
  xls,
  xlsm,
  xlsx,
  zip
}
