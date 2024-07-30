/** Default theme settings */
export const themeSettings: App.Theme.ThemeSetting = {
  themeScheme: 'light',
  grayscale: false,
  recommendColor: false,
  themeColor: '#3B82F6',
  otherColor: {
    info: '#3B82F6',
    success: '#52c41a',
    warning: '#faad14',
    error: '#f5222d',
  },
  isInfoFollowPrimary: true,
  layout: { mode: 'vertical', scrollMode: 'content' },
  page: { animate: true, animateMode: 'fade-slide' },
  header: { height: 48, breadcrumb: { visible: true, showIcon: true } },
  tab: { visible: true, cache: true, height: 40, mode: 'chrome' },
  fixedHeaderAndTab: true,
  sider: {
    inverted: true,
    width: 520,
    collapsedWidth: 64,
    mixWidth: 90,
    mixCollapsedWidth: 64,
    mixChildMenuWidth: 200,
  },
  footer: { visible: false, fixed: false, height: 48, right: true },
}

/**
 * Override theme settings
 *
 * If publish new version, use `overrideThemeSettings` to override certain theme settings
 */
export const overrideThemeSettings: Partial<App.Theme.ThemeSetting> = {}
