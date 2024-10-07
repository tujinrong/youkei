/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 共通関数
 *
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { ERA_YEARS } from '@/constants/business'
import { Enum日付不明区分 } from '@/enum'
import { Ref } from 'vue'
import { encryptByBase64 as encrypt } from '@/utils/encrypt/data'

/**  /4/1 or -4-1 => 0401 */
export function DatePadZero(dateString) {
  return dateString.replace(
    /([/-])(\d{1,2})([/-])(\d{1,2})/g,
    function (_, p1, p2, p3, p4) {
      return (
        (p2.length === 1 ? '0' + p2 : p2) + (p4.length === 1 ? '0' + p4 : p4)
      )
    }
  )
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
      try {
        eraYear = new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
          era: 'long',
          year: '2-digit',
        })
          .format(new Date(+year, +month ? +month - 1 : 1, +day || 1))
          .replace(/\//, '年')
          .replace(/\b(\d)\b/g, '0$1') //0埋め
      } catch (error) {
        return value
      }
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
export const getDateJpText = (value: Date | string | undefined): string => {
  if (value) {
    try {
      const date = new Date(value)
      return (
        new Intl.DateTimeFormat('ja-JP-u-ca-japanese', {
          era: 'long',
          year: '2-digit',
          month: '2-digit',
          day: '2-digit',
        })
          .format(date)
          .replace(/\//, '年')
          .replace(/\//, '月') + '日'
      )
    } catch (error) {
      console.error(error)
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
      second: '2-digit',
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
      day: '2-digit',
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
      second: '2-digit',
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

//--------------------------------------------------------------------------
/**ソート処理 */
export function changeTableSort(e: any, orderby: Ref): void {
  orderby.value = 0
  if (e.order === 'asc') {
    orderby.value = e.column.params.order
  } else if (e.order === 'desc') {
    orderby.value = e.column.params.order * -1
  } else {
    orderby.value = 0
  }
}
//--------------------------------------------------------------------------

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
export function filterOption(input: string, option: CmCodeNameModel) {
  return (
    option.NAME.toLowerCase().includes(input.toLowerCase()) ||
    String(option.CODE).toLowerCase().includes(input.toLowerCase())
  )
}

/**コードで名称を取得  (ドロップダウンリスト)*/
export function getLabelByValue(
  value = '',
  options: (CmCodeNameModel & { key?: string })[] = [],
  /** キー項目(連動フィルター用) */
  key?: string
) {
  return (
    options.find((item) => {
      if (key) {
        return item.CODE === value && item.key === key
      }
      return item.CODE === value
    })?.NAME ?? value
  )
}

/**コードで名称を取得  (複数選択ドロップダウンリスト)*/
export function getMultipleLabel(
  list: string[] = [],
  options: (CmCodeNameModel | DaSelectorKeyModel)[] = []
) {
  if (list.length > 0) {
    const arr = list.map((el) => getLabelByValue(el, options))
    return arr.filter(Boolean).join(',')
  }
  return ''
}

/**半角のアルファペット、数字、スペース及び記号を全角に変換*/
export function convertToFullWidth(input: string): string {
  return input
    .replace(/[!-~]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) + 0xfee0))
    .replace(/ /g, '　')
}

/**全角のアルファペット、数字、スペース及び記号を半角に変換（漢字と仮名を制限されていない）*/
export function convertToHalfWidth(input: string): string {
  return input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/「」/g, '｢｣')
}

/**全角のアルファペット、数字、スペース及び記号を半角に変換*/
export function convertToAllowedCharacters(input: string): string {
  const fullWidthToHalfWidth = input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/「」/g, '｢｣')

  return fullWidthToHalfWidth.replace(
    /[^0-9A-Za-z\-@./!"#$%&'()=~|｢｣[\]{}^;:,.\\`+*<>?_ ]/g,
    ''
  )
}

/**全角のアルファペット、数字及びスペースを半角に変換*/
export function convertToHalfWidthProhibitSymbol(input: string): string {
  return input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/[^A-Za-z0-9\s]/g, '')
}

/**全角の数字、記号及びスペースを半角に変換*/
export function convertToHalfWidthProhibitLetter(input: string): string {
  return input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/[^0-9\-@./!"#$%&'()=~|｢｣[\]{}^;:,.\\`+*<>?_ ]/g, '')
}

/**全角のアルファペット、数字及びスペースを半角に変換、及び英字は小文字を大文字に変換*/
export function convertToHalfWidthAndUpperCase(input: string): string {
  return input
    .toUpperCase()
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/[^A-Z0-9\s]/g, '')
}

/**全角の数字及びスペースを半角に変換*/
export function convertToHalfNumber(input: string): string {
  return input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/[^0-9\s]/g, '')
}

/**電話番号に変換*/
export function convertToTel(input: string): string {
  return input
    .replace(/[！-～]/g, (ch) => String.fromCharCode(ch.charCodeAt(0) - 0xfee0))
    .replace(/　/g, ' ')
    .replace(/[^0-9-]/g, '')
}

//すべての文字を半角に変換
export function convertALLToHalfWidth(input: string): string {
  return input.replace(/[^\u0020-\u007E\uFF61-\uFF9F]/g, '')
}

/**平仮名に変換*/
export function convertToKaNa(input: string): string {
  return input.replace(/[^\u3040-\u309F\u30A0-\u30FF\uFF00-\uFFEF\s()]/g, '')
}

/**フリガナに変換*/
export function convertToFuRiGaNa(input: string): string {
  return input
    .replace(/[ぁ-ん]/g, (char) =>
      String.fromCharCode(char.charCodeAt(0) + 0x60)
    )
    .replace(/[^\u30A0-\u30FF\s]/g, '')
}

/**金融数字*/
export const mathNumber = {
  formatter: (value) => value.replace(/\B(?=(\d{3})+(?!\d))/g, ','),
  parser: (value) => value.replace(/(,*)/g, ''),
}

/**カタカナは全角を半角に変換し、平仮名を半角カタカナに変換し、制限された文字のみ許可*/
export function convertKanaToHalfWidth(input: string): string {
  const hiragana =
    'あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんぁぃぅぇぉっゃゅょ'
  const fullWidthKana =
    'アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンァィゥェォッャュョ'
  const halfWidthKana =
    'ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｯｬｭｮ'
  const voicedHiraganaMap: Record<string, string> = {
    が: 'か',
    ぎ: 'き',
    ぐ: 'く',
    げ: 'け',
    ご: 'こ',
    ざ: 'さ',
    じ: 'し',
    ず: 'す',
    ぜ: 'せ',
    ぞ: 'そ',
    だ: 'た',
    ぢ: 'ち',
    づ: 'つ',
    で: 'て',
    ど: 'と',
    ば: 'は',
    び: 'ひ',
    ぶ: 'ふ',
    べ: 'へ',
    ぼ: 'ほ',
  }
  const semiVoicedHiraganaMap: Record<string, string> = {
    ぱ: 'は',
    ぴ: 'ひ',
    ぷ: 'ふ',
    ぺ: 'へ',
    ぽ: 'ほ',
  }
  const voicedKatakanaMap: Record<string, string> = {
    ガ: 'カ',
    ギ: 'キ',
    グ: 'ク',
    ゲ: 'ケ',
    ゴ: 'コ',
    ザ: 'サ',
    ジ: 'シ',
    ズ: 'ス',
    ゼ: 'セ',
    ゾ: 'ソ',
    ダ: 'タ',
    ヂ: 'チ',
    ヅ: 'ツ',
    デ: 'テ',
    ド: 'ト',
    バ: 'ハ',
    ビ: 'ヒ',
    ブ: 'フ',
    ベ: 'ヘ',
    ボ: 'ホ',
  }
  const semiVoicedKatakanaMap: Record<string, string> = {
    パ: 'ハ',
    ピ: 'ヒ',
    プ: 'フ',
    ペ: 'ヘ',
    ポ: 'ホ',
  }

  const convertChar = (char: string) => {
    // 濁音の平仮名を処理（分解）
    if (voicedHiraganaMap[char]) {
      return voicedHiraganaMap[char] + 'ﾞ'
    }
    // 半濁音の平仮名を処理（分解）
    if (semiVoicedHiraganaMap[char]) {
      return semiVoicedHiraganaMap[char] + 'ﾟ'
    }
    // 濁音のカタカナを処理（分解）
    if (voicedKatakanaMap[char]) {
      return voicedKatakanaMap[char] + 'ﾞ'
    }
    // 半濁音のカタカナを処理（分解）
    if (semiVoicedKatakanaMap[char]) {
      return semiVoicedKatakanaMap[char] + 'ﾟ'
    }
    // 平仮名を処理
    const hiraganaIndex = hiragana.indexOf(char)
    if (hiraganaIndex > -1) return halfWidthKana[hiraganaIndex]
    // カタカナを処理
    const fullWidthIndex = fullWidthKana.indexOf(char)
    // 全角'ー' -> 半角
    if (fullWidthIndex > -1) return halfWidthKana[fullWidthIndex]
    if (char === 'ー') return 'ｰ'
    // 全角数字、アルファベット -> 半角
    if (char.match(/[！-～]/)) {
      return String.fromCharCode(char.charCodeAt(0) - 0xfee0)
    }
    // 全角スペース -> 半角スペース
    if (char === '　') return ' '
    return char
  }
  const allowedCharacters =
    /[\u3040-\u309F\u30A0-\u30FF\uFF00-\uFFEF\u0020-\u007Eー]/g

  return (input.match(allowedCharacters) || []).map(convertChar).join('')
}

/**入力文字列を確認し、全バイト長(フルウィット:2バイト、ハーフウィット:1バイト)が指定された制限を超えないことを確認 */
export function validateLength(input: string, length: number): string {
  let byteCount = 0
  let result = ''

  for (let i = 0; i < input.length; i++) {
    const char = input[i]
    byteCount += char.match(/[^\x00-\x7F]/) ? 2 : 1
    if (byteCount > length) {
      break
    }
    result += char
  }
  return result
}

/**
 * プレビュー画面を開く
 * @param searchParams パラメータ
 * @param name プレビューID
 */
export function openNew(searchParams, name) {
  const baseURL = `${window.location.origin}/preview`
  const params = {
    param: JSON.stringify(searchParams),
    name,
  }
  const paramString = Object.keys(params)
    .map((key) => `${key}=${encodeURIComponent(params[key])}`)
    .join('&')
  const encryptedParams = encrypt(paramString)
  const url = `${baseURL}?${encryptedParams}`
  window.open(url, '_blank')
}
