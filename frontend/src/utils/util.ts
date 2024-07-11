/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 共通関数
 *
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { FormInstance } from 'ant-design-vue'
import { EditSatatus, EnumRegex, Enum日付不明区分 } from '#/Enums'
import { Ref } from 'vue'
import { getUserMenu } from './user'
import { showConfirmModal } from './modal'
import { C003003 } from '@/constants/msg'
import { ERA_YEARS } from '@/constants/constant'

export const collapseModelChange = (collapseModel, key) => {
  if (key) {
    collapseModel.activeKeyBackup = key
  } else {
    collapseModel.activeKey = collapseModel.activeKeyBackup
  }
}

/**  /4/1 or -4-1 => 0401 */
export function DatePadZero(dateString) {
  return dateString.replace(/([/-])(\d{1,2})([/-])(\d{1,2})/g, function (_, p1, p2, p3, p4) {
    return (p2.length === 1 ? '0' + p2 : p2) + (p4.length === 1 ? '0' + p4 : p4)
  })
}
/**和暦取得(入力文字から変換、不明を含む) */
export function getUnKnownDateJpText(value: string): string {
  let dateStr = DatePadZero(value)
    .replace(/\//g, '')
    .replace(/-/g, '')
    .replace(/[^\x00-\xff]/g, '')
  if (dateStr.length === 7) {
    if (ERA_YEARS.hasOwnProperty(dateStr[0])) {
      const startYear = ERA_YEARS[dateStr[0]]
      const year = startYear + parseInt(dateStr.slice(1, 3)) - 1
      dateStr = dateStr.replace(dateStr.slice(0, 3), String(year))
    }
  }

  if (dateStr.length === 8) {
    const year = dateStr.slice(0, 4)
    let month = dateStr.slice(4, 6)
    let day = dateStr.slice(6)

    let eraYear
    if (year === Enum日付不明区分.不明年) {
      eraYear = '不明年'
    } else {
      eraYear = new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
        era: 'long',
        year: '2-digit'
      })
        .format(new Date(+year, +month ? +month - 1 : 1, +day || 1))
        .replace(/\//, '年')
        .replace(/\b(\d)\b/g, '0$1') //0埋め
    }

    if (month === Enum日付不明区分.不明月) {
      month = '不明月'
    } else if (month === Enum日付不明区分.春) {
      month = '春'
    } else if (month === Enum日付不明区分.夏) {
      month = '夏'
    } else if (month === Enum日付不明区分.秋) {
      month = '秋'
    } else if (month === Enum日付不明区分.冬) {
      month = '冬'
    } else {
      month += '月'
    }

    if (day === Enum日付不明区分.不明日) {
      day = '不明日'
    } else if (day === Enum日付不明区分.上旬) {
      day = '上旬'
    } else if (day === Enum日付不明区分.中旬) {
      day = '中旬'
    } else if (day === Enum日付不明区分.下旬) {
      day = '下旬'
    } else {
      day += '日'
    }

    return `${eraYear}${month}${day}`
  } else {
    return value
  }
}
/**和暦取得(日付) */
export const getDateJpText = (value: Date): string => {
  if (value) {
    try {
      return (
        new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
          era: 'long',
          year: '2-digit',
          month: '2-digit',
          day: '2-digit'
        })
          .format(value)
          .replace(/\//, '年')
          .replace(/\//, '月') + '日'
      )
    } catch (error) {
      return '無効日付'
    }
  } else {
    return ''
  }
}
/**和暦取得(日時) */
export const getDateHmsJpText = (value: Date): string => {
  if (value) {
    return new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
      era: 'long',
      year: '2-digit',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit'
    })
      .format(value)
      .replace(/\//, '年')
      .replace(/\//, '月')
      .replace(/\ /, '日')
  } else {
    return ''
  }
}
/**和暦取得(簡易表記：日付) */
export const getSimpleDateJpText = (date: Date): string => {
  if (date) {
    return new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
      year: '2-digit',
      month: '2-digit',
      day: '2-digit'
    })
      .format(date)
      .replace(/\//, '.')
      .replace(/\//, '.')
  } else {
    return ''
  }
}
/**和暦取得(簡易表記：日時) */
export const getSimpleDateHmsJpText = (date: Date): string => {
  if (date) {
    return new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
      year: '2-digit',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit'
    })
      .format(date)
      .replace(/\//, '.')
      .replace(/\//, '.')
  } else {
    return ''
  }
}
/**和暦取得(年) */
export const yearFormatter = (value: number): string => {
  let yearName = ''
  let yearNum = 1
  if (value < 1868) return String(value)
  if (value <= 1912) {
    yearName = '明治'
    yearNum = value - 1868 + 1
  } else if (value <= 1926) {
    yearName = '大正'
    yearNum = value - 1912 + 1
  } else if (value <= 1989) {
    yearName = '昭和'
    yearNum = value - 1926 + 1
  } else if (value < 2019) {
    yearName = '平成'
    yearNum = value - 1989 + 1
  } else {
    yearName = '令和'
    yearNum = value - 2019 + 1
  }

  if (yearNum < 10) {
    yearName = yearName + '0'
  }

  return yearName + yearNum + '年度'
}
/**和暦取得(年 不詳あり) */
export const yearFormatter_unknown = (value: any): string => {
  if (!value) return ''
  if (value === Enum日付不明区分.不明年) {
    return '不明年'
  } else if (value === 9999) {
    return '生涯一回'
  } else {
    return yearFormatter(+value)
  }
}
/**和暦取得(年月) */
export const yearMonthFormatter = (value: string): string => {
  let year, month
  //年と月取得
  if (value.includes('-')) {
    ;[year, month] = value.split('-')
  } else if (value.length === 6) {
    year = value.substring(0, 4)
    month = value.substring(4)
  }
  //年処理
  year = yearFormatter(+year)
  //月処理
  month += '月'
  return year + month
}
/**和暦取得(年月 不詳あり) */
export const yearMonthFormatter_unknown = (value: string): string => {
  let year, month
  //年と月取得
  if (value.includes('-')) {
    ;[year, month] = value.split('-')
  } else if (value.length === 6) {
    year = value.substring(0, 4)
    month = value.substring(4)
  }
  //年処理
  if (year === Enum日付不明区分.不明年) {
    year = '不明年'
  } else {
    year = yearFormatter(+year)
  }
  //月処理
  if (month === Enum日付不明区分.不明月) {
    month = '不明月'
  } else if (month === Enum日付不明区分.春) {
    month = '春'
  } else if (month === Enum日付不明区分.夏) {
    month = '夏'
  } else if (month === Enum日付不明区分.秋) {
    month = '秋'
  } else if (month === Enum日付不明区分.冬) {
    month = '冬'
  } else {
    month += '月'
  }
  return year + month
}

/**チェック処理 */
export const judgeValidate = async (
  editFormRef: FormInstance[],
  addFormRef: FormInstance[]
): Promise<EditSatatus | null> => {
  return Promise.all(editFormRef.map((item) => item.validate())).then(
    async () => {
      try {
        await Promise.all(addFormRef.map((item) => item.validate()))
        return Promise.resolve(null)
      } catch (err) {
        return Promise.reject(EditSatatus.Add)
      }
    },
    (err) => {
      return Promise.reject(EditSatatus.Update)
    }
  )
}
//--------------------------------------------------------------------------
/**ソート処理 */
export function changeTableSort(e: any, orderby: Ref): void {
  orderby.value = 0
  if (e.order === 'asc') {
    orderby.value = e.column.params.order
  } else if (e.order === 'desc') {
    orderby.value = e.column.params.order * -1
  }
}
//--------------------------------------------------------------------------

/**遷移処理 */
export function transferToPage(menuid: string, onOk: () => void): void {
  const menus = getUserMenu()
  const menu = menus.find((el) => el.menuid === menuid)
  if (menu && menu.enabled) {
    showConfirmModal({
      content: C003003.Msg.replace('{0}', menu.menuname),
      onOk
    })
  }
}

/**表の第1列合併*/
export function mergeFirstColumn({ columnIndex, rowIndex }) {
  if (columnIndex === 0 && rowIndex === 0) {
    return { rowspan: 999, colspan: 1 }
  } else if (columnIndex === 0) {
    return { rowspan: 0, colspan: 0 }
  }
  return
}

/**正則置換 */
export function replaceText(text = '', type: EnumRegex) {
  switch (type) {
    case EnumRegex.全角:
      return text.replace(
        /[^\u3000-\u303F\u3040-\u309F\u30A0-\u30FF\uFF01-\uFF5E\u4E00-\u9FFF]/g,
        ''
      )
    case EnumRegex.全角_改行可:
      return text.replace(
        /[^\u3000-\u303F\u3040-\u309F\u30A0-\u30FF\uFF01-\uFF5E\u4E00-\u9FFF\n\r]/g,
        ''
      )
    case EnumRegex.全角半角:
      return text.replace(
        /[^\u0020-\u007E\u3000-\u303F\u3040-\u309F\u30A0-\u30FF\u4E00-\u9FFF\uFF00-\uFFEF]/g,
        ''
      )
    case EnumRegex.全角半角_改行可:
      return text.replace(
        /[^\u0020-\u007E\u3000-\u303F\u3040-\u309F\u30A0-\u30FF\u4E00-\u9FFF\uFF00-\uFFEF\n\r]/g,
        ''
      )
    case EnumRegex.カナ:
      return text.replace(/[^\u3040-\u309F\u30A0-\u30FF\uFF00-\uFFEF\s]/g, '')
    case EnumRegex.カナ氏名:
      let str = text.replace(/[^\u3040-\u309F\u30A0-\u30FF\uFF00-\uFFEF%％\s]/g, '')
      //%入力制限
      if (str !== '' && ['%', '％'].includes(str[0])) {
        str = '%' + str.replace(/%|％/g, '')
      } else {
        str = str.replace(/%|％/g, '')
      }
      return str
    case EnumRegex.半角:
      return text.replace(/[^\u0020-\u007E\uFF61-\uFF9F]/g, '')
    case EnumRegex.半角英数:
      return text.replace(/[^a-zA-Z0-9]/g, '')
    case EnumRegex.半角数字:
      return text.replace(/[^0-9]/g, '')
    case EnumRegex.電話:
      return text.replace(/[^-0-9]/g, '')
    default:
      return text
  }
}

/**
 * @description 全角のチェック \
 * @param str
 */
export const changeFullAngle = (str: string): string => {
  return str
    .replace(/[^\x00-\xff]/g, '')
    .replace(/[^ -~]/g, '')
    .replace(/\\/g, '')
    .replace(/\s/g, '')
}

/**全角数字⇒半角数字 「、」⇒　「,」  「－」、「～」⇒　「-」*/
export function formatRangeNumFull2Half(value = '') {
  return value
    .replace(/[０-９]/g, function (m) {
      return String.fromCharCode(m.charCodeAt(0) - 65248)
    })
    .replace(/、/g, ',')
    .replace(/[－～]/g, '-')
    .replace(/[^0-9,-]/g, '')
    .replace(/,{2,}/g, ',')
    .replace(/-{2,}/g, '-')
}

/**郵便番号 0000000 => 000-0000 */
export function formatYubin(string = '', reverse = false) {
  if (!string) return ''
  if (reverse) {
    return string.replaceAll('-', '')
  }
  if (string.length === 7) {
    return string.replace(/(\d{3})(\d{4})/, '$1-$2')
  }
  return string
}
/**時間 0000 => 00:00 */
export function formatTime(time = '') {
  if (!time) return ''
  return time.slice(0, 2) + ':' + time.slice(2)
}

/**Base64 to Blob */
export function Base64toBlob(base64: string) {
  const binaryData = atob(base64)
  const uint8Array = new Uint8Array(binaryData.length)
  for (let i = 0; i < binaryData.length; i++) {
    uint8Array[i] = binaryData.charCodeAt(i)
  }
  const blob = new Blob([uint8Array], { type: 'application/octet-stream' })
  return blob
}

/**tabledata to select's options */
export function table2Opts(list: any[], field: string) {
  const strings = [...new Set(list.map((el) => el[field]).filter((el) => !!el))]
  const options = [{ label: 'すべて', value: '' }]
  return [...options, ...strings.map((el) => ({ label: el, value: el }))]
}

/**ドロップダウンリスト検索 */
export function filterOption(input: string, option: DaSelectorModel) {
  return (
    option.label.toLowerCase().includes(input.toLowerCase()) ||
    option.value.toLowerCase().includes(input.toLowerCase())
  )
}

/**コードで名称を取得  (ドロップダウンリスト)*/
export function getLabelByValue(
  value = '',
  options: (DaSelectorModel & { key?: string })[] = [],
  /** キー項目(連動フィルター用) */
  key?: string
) {
  return (
    options.find((item) => {
      if (key) {
        return item.value === value && item.key === key
      }
      return item.value === value
    })?.label ?? value
  )
}
/**コードで名称を取得  (複数選択ドロップダウンリスト)*/
export function getMultipleLabel(
  list: string[] = [],
  options: (DaSelectorModel | DaSelectorKeyModel)[] = []
) {
  if (list.length > 0) {
    const arr = list.map((el) => getLabelByValue(el, options))
    return arr.filter(Boolean).join(',')
  }
  return ''
}

/**「超過」を赤字表示 */
export function formatExceedText({ cellValue }) {
  if (!cellValue) return ''
  return cellValue.replace('超過', '<span style="color:red">超過</span>') as string
}

/**EUC */
export function getSearchQuery(searchParams, fieldMapping) {
  const obj = {}
  for (const key in fieldMapping) {
    if (searchParams[key]) {
      obj[fieldMapping[key]] = searchParams[key]
    }
  }
  return obj
}
