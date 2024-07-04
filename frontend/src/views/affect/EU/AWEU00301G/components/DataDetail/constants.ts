import { Enum様式作成方法, Enum検索条件区分, Enumコントロール, Enum文字暦法区分 } from '#/Enums'

export const specialItems = [
  {
    label: '基準日',
    controlkbn: Enumコントロール.日付入力,
    selectlist: [],
    requiredflg: false,
    datatype: Enum文字暦法区分.和暦,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    jyokenid: -1
  },
  {
    label: '出力日',
    controlkbn: Enumコントロール.日付入力,
    selectlist: [],
    requiredflg: false,
    datatype: Enum文字暦法区分.和暦,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    jyokenid: -2
  },
  {
    label: '送付先出力',
    controlkbn: Enumコントロール.選択,
    selectlist: [],
    requiredflg: false,
    datatype: Enum文字暦法区分.半角カナ,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    jyokenid: -3
  },
  {
    label: '利用目的',
    controlkbn: Enumコントロール.複数選択,
    selectlist: [],
    requiredflg: false,
    datatype: Enum文字暦法区分.半角カナ,
    value: '',
    sql: '',
    tableid: '',
    itemnm: '',
    jyokenid: -4
  }
]

export const layout = {
  md: 12,
  xl: 12,
  xxl: 6
}
/** 固定様式 */
export const koteiyoshiki = {
  アドレスシール: '0Z01',
  バーコード: '0Z02',
  はがき: '0Z03',
  宛名台帳: '0Z04',
  '件数表(年齢別)': '0Z05',
  '件数表(行政区別)': '0Z06'
}
