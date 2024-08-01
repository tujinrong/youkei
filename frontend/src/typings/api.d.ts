/**
 * Namespace Api
 *
 * All backend api type
 */
declare namespace Api {
  namespace Common {
    /**
     * enable status
     *
     * - "1": enabled
     * - "2": disabled
     */
    type EnableStatus = '1' | '2'
  }

  /**
   * Namespace Auth
   *
   * Backend api module: "auth"
   */
  namespace Auth {
    interface LoginToken {
      TOKEN: string
    }

    interface UserInfo {
      /** ユーザID */
      // userid: string
      /** ユーザー名 */
      USER_NAME: string
      ROLES: string[]
      // buttons: string[]
    }

    /** ログイン処理 */
    interface LoginRequest extends DaRequestBase {
      /** パスワード */
      PWORD: string
    }
    /** ログイン処理(成功) */
    export interface LoginResponse extends DaResponseBase {
      /** トークン(ベースロジック) */
      TOKEN: string
    }
  }

  /**
   * Namespace Route
   *
   * Backend api module: "route"
   */
  namespace Route {
    type ElegantConstRoute = import('@elegant-router/types').ElegantConstRoute

    interface MenuRoute extends ElegantConstRoute {
      id: string
    }

    interface UserRoute {
      routes: MenuRoute[]
      home: import('@elegant-router/types').LastLevelRouteKey
    }
  }
}

declare namespace AntDesign {
  type TableColumnCheck = import('@sa/hooks').TableColumnCheck
}
