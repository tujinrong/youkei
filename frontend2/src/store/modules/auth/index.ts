import { computed, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import { defineStore } from 'pinia'
import { useLoading } from '@sa/hooks'
import { SetupStoreId } from '@/enum'
import { useRouterPush } from '@/hooks/common/router'
import { fetchGetUserInfo, fetchLogin, Login } from '@/service/api'
import { localStg } from '@/utils/storage'
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
    userid: '',
    userName: '',
    roles: [],
    buttons: [],
  })

  /** is super role in static route */
  const isStaticSuper = computed(() => {
    const { VITE_AUTH_ROUTE_MODE, VITE_STATIC_SUPER_ROLE } = import.meta.env

    return (
      VITE_AUTH_ROUTE_MODE === 'static' &&
      userInfo.roles.includes(VITE_STATIC_SUPER_ROLE)
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
      const res2 = await Login({
        userid: userName,
        pword: password,
      })
      token.value = res2.token as string
      localStg.set('token', res2.token as string)
      Object.assign(userInfo, res2.userinfo)
      Object.assign(userInfo, {
        userName: res2.userinfo?.usernm,
        roles: ['R_SUPER'],
        buttons: ['B_CODE1', 'B_CODE2', 'B_CODE3'],
      })

      await routeStore.initAuthRoute()

      if (redirect) {
        await redirectFromLogin()
      }

      if (routeStore.isInitAuthRoute) {
        window.$notification?.success({
          message: $t('page.login.common.loginSuccess'),
          description: $t('page.login.common.welcomeBack', {
            userName: userInfo.userid,
          }),
        })
      }
    } catch (error) {
      resetStore()
    }

    endLoading()
  }

  async function loginByToken(loginToken: Api.Auth.LoginToken) {
    // 1. stored in the localStorage, the later requests need it in headers
    localStg.set('token', loginToken.token)
    localStg.set('refreshToken', loginToken.refreshToken)

    // 2. get user info
    const pass = await getUserInfo()

    if (pass) {
      token.value = loginToken.token

      return true
    }

    return false
  }

  async function getUserInfo() {
    const { data: info, error } = await fetchGetUserInfo()

    if (!error) {
      // update store
      Object.assign(userInfo, info)

      return true
    }

    return false
  }

  async function initUserInfo() {
    const hasToken = getToken()

    if (hasToken) {
      const pass = await getUserInfo()

      if (!pass) {
        resetStore()
      }
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
