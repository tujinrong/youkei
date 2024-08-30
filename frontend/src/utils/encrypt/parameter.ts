/** -----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: URL引数
 * 　　　　　  データ暗号化
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import {
  encryptByBase64 as encrypt,
  decodeByBase64 as decrypt,
} from '@/utils/encrypt/data'
const encodeReserveRE = /[!'()*]/g
const encodeReserveReplacer = (c: any) => '%' + c.charCodeAt(0).toString(16)
const commaRE = /%2C/g

const encode = (str: string) =>
  encodeURIComponent(str)
    .replace(encodeReserveRE, encodeReserveReplacer)
    .replace(commaRE, ',')

const decode = decodeURIComponent

export const stringifyQuery = (obj: any) => {
  const res = obj
    ? Object.keys(obj)
        .map((key) => {
          const val = obj[key]

          if (val === undefined) {
            return ''
          }

          if (val === null) {
            return encode(key)
          }

          if (Array.isArray(val)) {
            const result: string[] = []
            val.forEach((val2) => {
              if (val2 === undefined) {
                return
              }
              if (val2 === null) {
                result.push(encode(key))
              } else {
                result.push(encode(key) + '=' + encode(val2))
              }
            })
            return result.join('&')
          }

          return encode(key) + '=' + encode(val)
        })
        .filter((x) => x.length > 0)
        .join('&')
    : null
  // えんこーど
  return res ? `?${encrypt(res)}` : ''
}

export const parseQuery = (query: string) => {
  const res: any = {}

  query = query.trim().replace(/^(\?|#|&)/, '')

  if (!query) {
    return res
  }

  // あんごうかいどく
  query = decrypt(query)

  query.split('&').forEach((param) => {
    const parts = param.replace(/\+/g, ' ').split('=')
    const key = decode(parts.shift() ?? '')
    const val = parts.length > 0 ? decode(parts.join('=')) : null

    if (res[key] === undefined) {
      res[key] = val
    } else if (Array.isArray(res[key])) {
      res[key].push(val)
    } else {
      res[key] = [res[key], val]
    }
  })

  return res
}
