import { computed, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import { defineStore } from 'pinia'
import { useLoading } from '@sa/hooks'
import { SetupStoreId } from '@/enum'
import { useRouterPush } from '@/hooks/common/router'
import { fetchGetUserInfo, Login } from '@/service/api'
import { sessionStg } from '@/utils/storage'
import { $t } from '@/locales'
import { useRouteStore } from '../route'
import { useTabStore } from '../tab'
import { clearAuthStorage, getToken } from './shared'

export const useAuthStore = defineStore(SetupStoreId.Auth, () => {
  const route = useRoute()
  const routeStore = useRouteStore()
  const tabStore = useTabStore()
  const { toLogin, redirectFromLogin } = useRouterPush(false)
  const { loading: loginLoading, startLoading, endLoading } = useLoading()

  const token = ref(getToken())

  const userInfo: Api.Auth.UserInfo = reactive({
    // userid: '',
    USER_NAME: '',
    ROLES: [],
    // buttons: [],
  })

  /** is super role in static route */
  const isStaticSuper = computed(() => {
    const { VITE_AUTH_ROUTE_MODE, VITE_STATIC_SUPER_ROLE } = import.meta.env

    return (
      VITE_AUTH_ROUTE_MODE === 'static' &&
      userInfo.ROLES.includes(VITE_STATIC_SUPER_ROLE)
    )
  })

  /** Is login */
  const isLogin = computed(() => Boolean(token.value))

  /** Reset auth store */
  async function resetStore() {
    const authStore = useAuthStore()

    clearAuthStorage()

    authStore.$reset()

    if (!route.meta.constant) {
      await toLogin()
    }

    tabStore.cacheTabs()
    routeStore.resetStore()
  }

  /**
   * Login
   *
   * @param userName User name
   * @param password Password
   * @param [redirect=true] Whether to redirect after login. Default is `true`
   */
  async function login(userName: string, password: string, redirect = true) {
    startLoading()

    try {
      //get token
      const loginToken = await Login({
        USER_ID: userName,
        PASS: password,
      })

      if (loginToken) {
        const pass = await loginByToken(loginToken)

        if (pass) {
          //menu
          await routeStore.initAuthRoute()

          if (redirect) {
            await redirectFromLogin()
          }

          if (routeStore.isInitAuthRoute) {
            window.$notification?.success({
              message: $t('page.login.common.loginSuccess'),
              description: $t('page.login.common.welcomeBack', {
                userName: userInfo.USER_NAME,
              }),
            })
          }
        }
      } else {
        resetStore()
      }
    } catch (error) {}

    endLoading()
  }

  async function loginByToken(loginToken: Api.Auth.LoginToken) {
    // 1. stored in the sessionStorage, the later requests need it in headers
    sessionStg.set('token', loginToken.TOKEN)

    // 2. get user info
    const pass = await getUserInfo()

    if (pass) {
      token.value = loginToken.TOKEN

      return true
    }

    return false
  }

  async function getUserInfo() {
    try {
      const data = await fetchGetUserInfo()

      if (data) {
        // update store
        Object.assign(userInfo, data)

        return true
      }
    } catch (error) {}

    return false
  }

  async function initUserInfo() {
    const hasToken = getToken()

    if (hasToken) {
      const pass = await getUserInfo()
      if (!pass) {
        resetStore()
      }
    } else {
      resetStore()
    }
  }

  return {
    token,
    userInfo,
    isStaticSuper,
    isLogin,
    loginLoading,
    resetStore,
    login,
    initUserInfo,
  }
})
