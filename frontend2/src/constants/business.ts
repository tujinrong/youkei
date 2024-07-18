import { transformRecordToOption } from '@/utils/common'

export const enableStatusRecord: Record<
  Api.Common.EnableStatus,
  App.I18n.I18nKey
> = {
  '1': 'page.manage.common.status.enable',
  '2': 'page.manage.common.status.disable',
}

export const enableStatusOptions = transformRecordToOption(enableStatusRecord)

export const userGenderRecord: Record<
  Api.SystemManage.UserGender,
  App.I18n.I18nKey
> = {
  '1': 'page.manage.user.gender.male',
  '2': 'page.manage.user.gender.female',
}

export const userGenderOptions = transformRecordToOption(userGenderRecord)

export const menuTypeRecord: Record<
  Api.SystemManage.MenuType,
  App.I18n.I18nKey
> = {
  '1': 'page.manage.menu.type.directory',
  '2': 'page.manage.menu.type.menu',
}

export const menuTypeOptions = transformRecordToOption(menuTypeRecord)

export const menuIconTypeRecord: Record<
  Api.SystemManage.IconType,
  App.I18n.I18nKey
> = {
  '1': 'page.manage.menu.iconType.iconify',
  '2': 'page.manage.menu.iconType.local',
}

export const menuIconTypeOptions = transformRecordToOption(menuIconTypeRecord)

export const ERA_YEARS = {
  M: 1868,
  T: 1912,
  S: 1926,
  H: 1989,
  R: 2019,
  1: 1868,
  2: 1912,
  3: 1926,
  4: 1989,
  5: 2019,
  //拡張可能...
}
