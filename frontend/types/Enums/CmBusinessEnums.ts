/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 業務共通(処理)
 *             区分列挙型
 * 作成日　　: 2022.12.12
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumSex } from '#/Enums/DaBusinessEnums'

export enum Enum予約関係分類 {
  名称関係 = 1,
  検査方法コード関係
}
export enum Enum対象区分 {
  対象外 = 0,
  対象,
  不明 = 9
}
export enum Enumフリー項目グループNo {
  グループ = 1,
  グループ2
}
export enum Enumフリーマスタ分類 {
  成人 = 1,
  指導,
  母子
}
export enum Enum拡張予約指導業務区分 {
  成人保健 = 1,
  母子保健,
  予防接種
}
export enum Enum基準値業務区分 {
  成人保健 = 1,
  母子保健,
  予防接種
}
export enum Enumコントローラー分類 {
  数値 = 1,
  文字,
  日付,
  選択,
  検索,
  選択_検索
}
export enum Enum検診関連汎用マスタ区分 {
  検査方法 = 1,
  予約分類,
  グループ2
}
export enum Enumログ区分 {
  通信ログ = 1,
  バッチログ,
  連携ログ
}
export enum Enumログイン区分 {
  一回目 = 1,
  二回目
}
export enum Enum編集区分 {
  新規 = 1,
  変更
}
export enum Enum遷移区分 {
  初期化 = 1,
  タブ追加
}
export enum Enum表示区分 {
  期限内 = 1,
  すべて
}
export enum Enum未読区分 {
  未読 = 1,
  すべて
}
export enum Enum更新区分 {
  追加 = 1,
  削除
}
export enum Enumお気に入り区分 {
  なし = Enum更新区分.追加,
  あり = Enum更新区分.削除
}
export enum Enum処理結果区分 {
  正常終了,
  異常終了,
  要確認,
  処理停止,
  /**todo chen: ログと同じ名称マスタコードでいい？BCC様に要確認 */
  実行中
}
export enum Enum表示色区分 {
  黒,
  青,
  赤
}
export enum Enum共通バー番号 {
  メモ情報 = 1,
  電子ファイル情報,
  メモ情報_世帯,
  連絡先,
  個人照会,
  警告情報照会,
  送付先管理,
  フォロー管理,
  健診結果保健指導履歴照会,
  料金内訳,
  対象サイン
}
export enum Enum項目区分 {
  文字 = 1,
  数字,
  日付,
  日付不明,
  日時 = 5
}
export enum Enum性別 {
  不明 = 0,
  男 = EnumSex.男,
  女 = EnumSex.女,
  その他 = 9
}
export enum EnumBirthSearchKbn {
  年齢 = 1,
  生年月日
}
export enum Enum入力値保存型 {
  数値 = 1,
  文字
}
/**画面項目入力タイプ */
export enum Enum画面項目入力 {
  数値 = 1,
  文字,
  日付,
  選択,
  検索,
  選択_検索
}
export enum Enum基準値範囲 {
  正常値範囲 = 0,
  注意値範囲,
  異常値範囲
}
export enum Enumユーザー状態 {
  正常,
  停止,
  ロック,
  無効
}
export enum Enum表示 {
  非表示,
  表示
}
export enum Enum連絡先タブ区分 {
  妊娠届出情報 = 1,
  出生時状況,
  他市町村_医療機関等への接種依頼,
  健康被害救済制度情報,
  その他
}
export enum Enum連絡先タブ名称 {
  本人,
  父親,
  母親,
  保護者,
  該当者,
  請求者
}
export enum Enum事業コード区分 {
  メモ = 1,
  電子ファイル,
  医療機関,
  事業従事者,
  連絡先,
  フォロー事業
}
export enum Enum事業コードパターン {
  DB設定 = 1,
  画面選択
}
export enum Enum事業コード取得方法 {
  集約区分 = 1,
  事業コード
}
export enum Enum削除区分 {
  単一削除,
  全削除
}
export enum Enum入力タイプ分類 {
  半角 = 1,
  全角,
  日付,
  コード
}
export enum Enum入力タイプ型 {
  数値 = 1,
  文字
}
export enum Enum条件コード区分 {
  コード1 = 1,
  コード2,
  コード3
}
export enum Enum抽出モード {
  全体抽出 = 1,
  個別抽出
}
