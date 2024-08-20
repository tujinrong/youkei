export enum SetupStoreId {
  App = 'app-store',
  Theme = 'theme-store',
  Auth = 'auth-store',
  Route = 'route-store',
  Tab = 'tab-store',
}

/** リクエスト方法 */
export enum RequestEnum {
  GET = 'GET',
  POST = 'POST',
  PATCH = 'PATCH',
  PUT = 'PUT',
  DELETE = 'DELETE',
}

/** 一般的なコンテンツタイプ */
export enum ContentTypeEnum {
  /**json */
  JSON = 'application/json;charset=UTF-8',
  /**text */
  TEXT = 'text/plain;charset=UTF-8',
  /**form-data アップロード */
  FORM_DATA = 'multipart/form-data;charset=UTF-8',
}

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
  InterruptionError,
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
  下旬 = 'A3',
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
}

/** EnumAndOr(検索方法) */
export enum EnumAndOr {
  /**すべてを含む(AND) */
  AndCODE,
  /**いずれかを含む(OR) */
  OrCODE,
}
/** 編集区分 */
export enum EnumEditKbn {
  Add = 1,
  Edit,
}
