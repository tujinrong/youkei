/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ベース
 * 　　　　　  区分列挙型
 * 作成日　　: 2023.03.28
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
/** リクエスト方法 */
export enum RequestEnum {
  GET = 'GET',
  POST = 'POST',
  PATCH = 'PATCH',
  PUT = 'PUT',
  DELETE = 'DELETE'
}

/** 一般的なコンテンツタイプ */
export enum ContentTypeEnum {
  /**json */
  JSON = 'application/json;charset=UTF-8',
  /**text */
  TEXT = 'text/plain;charset=UTF-8',
  /**form-data アップロード */
  FORM_DATA = 'multipart/form-data;charset=UTF-8'
}

/**入力制限用の正則(replaceText)*/
export enum EnumRegex {
  全角 = 1,
  全角_改行可,
  全角半角,
  全角半角_改行可,
  カナ,
  カナ氏名,
  半角,
  半角英数,
  半角数字,
  電話
}

/** 確認 */
export enum Enum確認 {
  FALSE = '0',
  TRUE = '1'
}

/** 画面モード */
export enum PageSatatus {
  /**一覧画面 */
  List,
  /**詳細画面 */
  Detail,
  /**編集画面 */
  Edit,
  /**新規画面 */
  New,
  /**削除画面 */
  Delete,
  /**プレビュー画面 */
  Preview
}

/** ダイアログボックスモード */
export enum EditSatatus {
  /**編集モード */
  Update = '1',
  /**新規モード */
  Add = '2'
}

/** メニュータイプ */
export enum MenuType {
  /**トップメニュー */
  Top = 'topmenu',
  /**サイドメニュー */
  Side = 'sidemenu'
}

/** 項目選択対象 */
export enum TargetType {
  /**左部分 */
  Left = 'left',
  /**右部分 */
  Right = 'right'
}

export enum Enum日付不明区分 {
  不明年 = '0000',
  不明月 = '00',
  不明日 = '00',
  春 = 'A1',
  夏 = 'A2',
  秋 = 'A3',
  冬 = 'A4',
  上旬 = 'A1',
  中旬 = 'A2',
  下旬 = 'A3'
}

export enum ArEnumFormat {
  String = 1,
  Number,
  Year,
  Date,
  DateTime,
  Time,
  Bool,
  BarCode,
  QRCode,
  Image
}

export enum EnumActionType {
  Insert = 1,
  Update,
  Delete
}

export enum ArEnumOutputType {
  Excel,
  Pdf,
  Csv,
  Svgz
}

export enum EnumKensinStsType {
  新規 = EnumActionType.Insert,
  変更 = EnumActionType.Update,
  削除 = EnumActionType.Delete
}

export enum ArEnumEncoding {
  UTF8,
  Shift_jis,
  Unicode
}

//この列挙型はバックエンドに対応するため、定義した
export enum ArEnumEncoding2 {
  SHIFT_JIS,
  UTF8,
  UTF16_LE,
  UTF16_BE
}

export enum EnumReportType {
  PDF,
  EXCEL,
  PREVIEW,
  CSV,
  その他
}
