/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ストレージ
 *
 * 作成日　　: 2023.08.24
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { ss } from '@/utils/storage'
import {
  ACCESS_TOKEN,
  REGSISYO,
  USER_INFO,
  MENU_NAV,
  GLOBAL_YEAR
} from '@/constants/mutation-types'
import { UserInfoVM } from '@/views/affect/AF/AWAF00101G/type'
import { Enum共通バー番号 } from '#/Enums'
import { BarStore } from '@/store'

export function getUserToken(): string {
  return ss.get(ACCESS_TOKEN, '')
}

export function getUserInfo() {
  const userinfo: UserInfoVM = ss.get(USER_INFO, {})
  return userinfo
}

export function getUserMenu(): MenuModel[] {
  return ss.get(MENU_NAV)
}

export function clearUserInfo(): void {
  ss.remove(USER_INFO)
  ss.remove(ACCESS_TOKEN)
  ss.remove(MENU_NAV)
  ss.remove(GLOBAL_YEAR)
  ss.remove(REGSISYO)
}

// 共通バー権限
interface Kengen {
  updateflg: boolean
  addflg: boolean
  deleteflg: boolean
  personalnoflg: boolean
}
export function getBarKengen(barno: Enum共通バー番号): Kengen {
  const { barKengenList } = BarStore
  const kengen = barKengenList.find((el) => el.barno === barno) || {
    updateflg: false,
    addflg: false,
    deleteflg: false,
    personalnoflg: false
  }
  return kengen
}
