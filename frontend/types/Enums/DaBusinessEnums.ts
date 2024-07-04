/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 業務共通(DB)
 *             区分列挙型
 * 作成日　　: 2022.12.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumReportType, ArEnumFormat } from '#/Enums/BaseEnums'
export enum Enum特殊一覧検索機能 {
  /**成人検診 */
  AWSH001,
  /**住民・住登外 */
  AWKK00101G,
  /**フォロー管理 */
  AWKK00401G,
  /**帳票発行対象外者管理 */
  AWKK01001G,
  /**対象サイン */
  AWSH00302G,
  /**健（検）診予定管理 */
  AWSH00401G,
  /**健（検）診予約希望者管理(日程一覧画面) */
  AWSH00402G_1,
  /**健（検）診予約希望者管理(予約者一覧画面：予約情報) */
  AWSH00402G_2,
  /**健（検）診予約希望者管理(予約者一覧画面：予約者情報) */
  AWSH00402G_3,
  /**住登外 */
  AWKK00111G,
  /**保健指導 */
  AWKK00301G,
  /**母子保健 */
  Bosi
}
export enum Enum名称区分 {
  名称 = 1,
  カナ,
  略称
}
export enum Enumマスタ区分 {
  名称マスタ = 1,
  汎用マスタ,
  医療機関マスタ,
  ユーザーマスタ,
  所属グループマスタ,
  市区町村マスタ,
  地区情報マスタ,
  会場情報マスタ,
  事業従事者担当者情報マスタ,
  医療機関マスタ_保険
}
export enum Enumシステムマスタ区分 {
  名称メインマスタ,
  汎用メインマスタ,
  EUCテーブルマスタ,
  機能マスタ,
  タスクスケジュール情報マスタ,
  EUC帳票マスタ,
  EUC様式詳細マスタ,
  帳票発行抽出対象マスタ
}
/**1:整数;2:小数;3:文字;4:日付;5:時間;6:フラグ */
export enum EnumDataType {
  整数 = 1,
  小数,
  文字列,
  日付,
  時間,
  フラグ
}
export enum EnumMsgCtrlKbn {
  エラー = 1,
  アラート,
  非表示
}
export enum Enum詳細検索条件区分 {
  共通 = 1,
  独自
}
/**詳細条件 */
export enum Enumコントローラータイプ {
  通用項目 = 1,
  年齢生年月日,
  一覧選択,
  参照ダイアログ
}
/**参照ダイアログ項目区分 */
export enum Enum参照ダイアログ項目区分 {
  宛名番号 = 1,
  医療機関,
  事業従事者,
  検診実施機関
}
export enum Enum取得元区分 {
  テーブル固定項目 = 1,
  フリー項目
}
export enum EnumKensinKbn {
  一次 = 1,
  精密
}
export enum Enum計算区分 {
  Empty = -1,
  数式計算 = 1,
  内部関数,
  DB関数
}
/**入力項目コントローラータイプ */
export enum Enum入力タイプ {
  数値_整数 = 1,
  数値_小数点付き実数,
  数値_符号付き整数,
  半角文字_半角数字 = 11,
  半角文字_半角英数字,
  半角文字_年,
  半角文字_年_不詳あり,
  半角文字_年月,
  半角文字_年月_不詳あり,
  半角文字_時刻,
  半角文字_半角,
  全角文字_全角_改行不可 = 21,
  全角文字_全角_改行可,
  全角半角文字_全角半角_改行不可 = 26,
  全角半角文字_全角半角_改行可,
  日付_年月日 = 31,
  日付_年月日_不詳あり,
  日時_年月日時分秒,
  コード_名称マスタ = 41,
  コード_汎用マスタ,
  コード_ユーザーマスタ = 44,
  コード_所属グループマスタ,
  コード_地区情報マスタ,
  コード_会場情報マスタ = 48,
  宛名番号 = 61,
  医療機関 = 70,
  事業従事者 = 71,
  検診実施機関 = 72
}
export enum Enum住登区分 {
  住民 = 1,
  住登外
}
export enum Enum住民種別 {
  日本人住民 = 1,
  外国人住民
}
/**基準値用 */
export enum EnumSex {
  Empty = -1,
  男 = 1,
  女
}
export enum Enumロール区分 {
  ユーザー,
  所属
}
export enum Enumプログラム区分 {
  画面,
  共通バー機能
}
export enum Enum地区区分 {
  地区1 = 1,
  地区2,
  地区3,
  地区4,
  地区5,
  地区6,
  地区7,
  地区8,
  地区9,
  地区10
}
export enum Enum精密検査実施区分 {
  未実施,
  実施
}
export enum Enum画面表示区分 {
  非表示,
  表示
}
export enum Enum事業区分 {
  基本事業,
  市区町村拡張事業
}
export enum Enumフリー項目区分区分 {
  PKG標準項目拡張領域不使用 = 1,
  PKG標準項目拡張領域使用,
  市区町村独自項目
}
export enum Enum指導区分 {
  訪問指導 = 1,
  個別指導,
  集団指導
}
export enum Enum申込結果 {
  申込 = 1,
  結果
}
export enum Enum項目用途区分 {
  集団以外,
  事業用,
  参加者用
}
export enum Enum町字区分 {
  Empty = -1,
  大字町名 = 1,
  丁目,
  小字
}
export enum Enum年齢基準日区分 {
  受診日時点 = 0,
  指定日
}
export enum Enum引用符_CSV出力用 {
  なし = 0,
  ダブルコーテーション,
  シングルコーテーション,
  混在パターン
}
export enum Enum取込業務区分 {
  共通管理 = 1,
  成人保健 = 2,
  母子保健 = 3,
  予防接種 = 4
}
export enum Enum取込区分 {
  ファイル取込 = 1,
  一括入力 = 2
}
export enum Enum登録区分 {
  削除新規 = 1,
  新規 = 2,
  更新 = 3
}
export enum Enumファイル形式 {
  CSVファイル = 1,
  テキストファイル = 2,
  XMLファイル = 3
}
export enum Enumエンコード {
  SJIS = 1,
  UTF_8 = 2,
  UTF_16 = 3
}
export enum Enumデータ形式 {
  可変長 = 1,
  固定長 = 2
}
export enum Enum区切り記号 {
  カンマ = 1,
  タブ = 2
}
export enum Enum項目特定区分 {
  宛名番号 = 1,
  氏名 = 2,
  実施日_一次_申込 = 3,
  実施日_精密_結果 = 4,
  生年月日 = 5,
  実施年齢_一次_申込 = 6,
  実施年齢_精密_結果 = 7,
  年度_一次_申込,
  年度_精密_結果,
  性別,
  検診実施機関番号,
  医療機関コード,
  医療機関名,
  会場コード,
  会場名,
  フォロー内容枝番,
  フォロー内容,
  フォロー状況,
  把握経路,
  把握事業,
  把握日,
  医師
}
export enum Enumマッピング区分 {
  マッピングなし = 0,
  関数 = 1,
  単一項目移送 = 2
}
export enum Enumマッピング方法 {
  宛名番号取得 = 11,
  医療機関コード取得 = 12,
  年度取得,
  桁数指定 = 21
}
export enum Enum入力区分 {
  テキスト = 1,
  コード系 = 2,
  画面検索 = 3,
  マスタ参照 = 4,
  プルダウンリスト = 5,
  関数 = 6,
  プルダウン_画面検索 = 7
}
export enum Enum入力方法 {
  数値_整数 = 1,
  数値_小数点付き実数,
  数値_符号付き整数,
  半角文字_半角数字 = 11,
  半角文字_半角英数字,
  半角文字_年,
  半角文字_年_不詳あり,
  半角文字_年月,
  半角文字_年月_不詳あり,
  半角文字_時刻,
  半角文字_半角,
  全角文字_全角_改行不可 = 21,
  全角文字_全角_改行可,
  全角半角文字_全角半角_改行不可 = 26,
  全角半角文字_全角半角_改行可,
  日付_年月日 = 31,
  日付_年月日_不詳あり,
  日時_年月日時分秒 = 33,
  宛名番号 = 61,
  医療機関 = 70,
  事業従事者 = 71,
  検診実施機関 = 72,
  コード_ユーザーマスタ = 44,
  コード_所属グループマスタ = 45,
  コード_地区情報マスタ = 46,
  コード_会場情報マスタ = 48
}
export enum Enum年度範囲区分 {
  システム年度_システム年度 = 1,
  システム年度_システム年度Plus1 = 2,
  メニュー引き継ぐ_コントロールマスタ年度 = 3
}
export enum Enumフォーマット_画面定義 {
  左0埋め = 1,
  右0埋め = 2
}
export enum Enumエラーレベル {
  無視 = 0,
  情報 = 1,
  警告 = 2,
  エラー = 3
}
export enum Enum表示入力設定 {
  入力 = 1,
  表示 = 2,
  非表示 = 3
}
export enum Enum演算子 {
  等しい = 1,
  等しくない = 2,
  より大さい = 3,
  より小さい = 4,
  以上 = 5,
  以下 = 6,
  like = 7,
  not_like = 8,
  between = 9,
  not_between = 10,
  is_null = 11,
  is_not_null = 12
}
export enum Enum処理区分 {
  画面項目登録 = 1,
  固定値登録 = 2,
  自動 = 3,
  設定しない = 4,
  関連テーブルの項目から登録 = 5,
  手動採番 = 6,
  不祥フラグ登録 = 7,
  年齢登録_一次申込 = 8,
  年齢登録_精密結果 = 9,
  年度登録
}
export enum Enum処理種別 {
  チェック用 = 1,
  更新前処理 = 2,
  更新後処理 = 3
}
export enum Enum自動処理区分 {
  固定値 = 1,
  親テーブルの項目から = 2,
  自動採番 = 3,
  手動採番 = 4,
  自動登録 = 5
}
export enum Enum待機フラグ {
  希望しない = 1,
  希望する
}
export enum Enum減免区分種別 {
  特定健診 = 1,
  がん検診
}
export enum Enum生涯１回フラグ {
  生涯複数回 = 0,
  生涯1回
}
export enum Enum通知サイクル {
  毎年 = 1,
  生涯一回
}
export enum Enum業務区分 {
  健康管理共通 = 1,
  成人保健,
  母子保健,
  予防接種,
  統計_報告
}
export enum Enum検索条件区分 {
  通常条件 = 1,
  固定条件,
  前提条件
}
export enum Enum使用区分 {
  一覧項目 = 1,
  集計項目,
  併用
}
export enum Enum出力項目区分 {
  普通項目 = 1,
  宛名番号,
  個人番号
}
export enum Enum集計項目区分 {
  GroupBy = 1,
  Count,
  Sum
}
export enum Enum集計区分 {
  /**行ヘッダー */
  GroupBy縦 = 1,
  /**列ヘッダー */
  GroupBy横,
  集計
}
export enum Enum集計方法 {
  Count = 1,
  Sum,
  Max,
  Min
}
export enum Enum集計方法文字 {
  件数 = Enum集計方法.Count,
  合計 = Enum集計方法.Sum,
  最大値 = Enum集計方法.Max,
  最小値 = Enum集計方法.Min
}
export enum Enum小計区分 {
  内訳小計 = 1,
  小計
}
export enum Enumデータタイプ {
  文字 = ArEnumFormat.String,
  数値 = ArEnumFormat.Number,
  年 = ArEnumFormat.Year,
  年月日 = ArEnumFormat.Date,
  年月日時分秒 = ArEnumFormat.DateTime,
  時分秒 = ArEnumFormat.Time,
  論理型 = ArEnumFormat.Bool,
  バーコード = ArEnumFormat.BarCode,
  QRコード = ArEnumFormat.QRCode,
  図 = ArEnumFormat.Image
}
export enum EnumTableKbn {
  トランザクション = 1,
  マスタ,
  フリー,
  VIEW
}
export enum Enum帳票様式 {
  帳票 = 1,
  別様式,
  サブ様式
}
export enum Enum内外区分 {
  内部帳票 = 1,
  外部帳票
}
export enum Enum帳票種別区分 {
  台帳 = 1,
  一覧表,
  集計,
  特定様式,
  CSV
}
export enum Enum様式種別 {
  一覧表 = 1,
  台帳 = 2,
  経年表 = 3,
  集計表 = 4,
  カスタマイズ = 5
}
export enum Enum様式種別詳細 {
  一覧表 = 11,
  台帳 = 21,
  経年表 = 31,
  単純集計表 = 41,
  クロス集計 = 42,
  はがき = 51,
  アドレスシール = 52,
  バーコードシール = 53,
  宛名台帳 = 54
}
export enum Enum様式作成方法 {
  データソース = 1,
  SQL,
  プロシージャ
}
export enum Enum明細有無 {
  明細あり = 1,
  明細なし = 0
}
export enum Enum行列固定 {
  固定 = 1,
  可変
}
export enum Enum並び替え {
  無し = 0,
  降順,
  昇順
}
export enum Enumページサイズ {
  A3 = 3,
  A4 = 4,
  A5 = 5,
  A6 = 6,
  B5 = 7,
  B6Jis = 8
}
export enum Enumコントロール {
  数値入力 = 1,
  文字入力,
  日付入力,
  時間入力,
  数値範囲,
  文字範囲,
  日付範囲,
  時間範囲,
  選択,
  複数選択,
  論理値,
  宛名入力,
  年度
}
export enum Enum文字暦法区分 {
  かな漢字 = 1,
  半角カナ,
  全角カナ,
  英字,
  数値,
  西暦,
  和暦
}
export enum Enum文字区分 {
  かな漢字 = Enum文字暦法区分.かな漢字,
  半角カナ = Enum文字暦法区分.半角カナ,
  全角カナ = Enum文字暦法区分.全角カナ,
  英字 = Enum文字暦法区分.英字,
  数値 = Enum文字暦法区分.数値
}
export enum Enum暦法区分 {
  西暦 = Enum文字暦法区分.西暦,
  和暦 = Enum文字暦法区分.和暦
}
export enum Enum履歴出力状態区分 {
  予定中 = 1,
  処理中,
  処理完了,
  処理失敗
}
export enum Enum出力方式 {
  PDF = EnumReportType.PDF,
  EXCEL = EnumReportType.EXCEL,
  CSV = EnumReportType.CSV
}
export enum CodeTypeEnum {
  文字 = 1,
  数値,
  選択
}
export enum Enum検索区分 {
  完全検索 = 0,
  部分一致_中間一致,
  部分一致_前方一致
}
