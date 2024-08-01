import { request } from '../request'
import { api } from '../request/common-service'

const servicename = 'GJ0010'

/** get user routes */
export const fetchGetUserRoutes = (): Promise<Api.Route.UserRoute> => {
  const methodname = 'GetUserRoutes'
  return api(servicename, methodname, {})
}

/**
 * whether the route is exist
 *
 * @param routeName route name
 */
export function fetchIsRouteExist(routeName: string) {
  return request<boolean>({ url: '/route/isRouteExist', params: { routeName } })
}
