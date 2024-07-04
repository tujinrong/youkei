/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 共通変換関数
 *
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
const toString = Object.prototype.toString

/**
 * @description: 値が特定の型ではないかどうかを判断する
 */
export function is(val: unknown, type: string) {
  return toString.call(val) === `[object ${type}]`
}

/**
 * @description:  関数かどうかを判断する
 */
export function isFunction<T>(val: unknown): val is T {
  return is(val, 'Function')
}

/**
 * @description: 定義かどうかを判断する
 */
export const isDef = <T = unknown>(val?: T): val is T => {
  return typeof val !== 'undefined'
}

export const isUnDef = <T = unknown>(val?: T): val is T => {
  return !isDef(val)
}
/**
 * @description: Objectかどうかを判断する
 */
export const isObject = (val: any): val is Record<any, any> => {
  return val !== null && is(val, 'Object')
}

/**
 * @description:  時間かどうかを判断する
 */
export function isDate(val: unknown): val is Date {
  return is(val, 'Date')
}

/**
 * @description:  数字かどうかを判断する
 */
export function isNumber(val: unknown): val is number {
  return is(val, 'Number')
}
/**
 * @description:  非同期かどうかを判断する
 */
export function isAsyncFunction<T = any>(val: unknown): val is Promise<T> {
  return is(val, 'AsyncFunction')
}
/**
 * @description:  Promiseかどうかを判断する
 */
export function isPromise<T = any>(val: unknown): val is Promise<T> {
  return is(val, 'Promise') && isObject(val) && isFunction(val.then) && isFunction(val.catch)
}

/**
 * @description:  文字かどうかを判断する
 */
export function isString(val: unknown): val is string {
  return is(val, 'String')
}

/**
 * @description:  Booleanかどうかを判断する
 */
export function isBoolean(val: unknown): val is boolean {
  return is(val, 'Boolean')
}

/**
 * @description:  Arrayかどうかを判断する
 */
export function isArray(val: any): val is Array<any> {
  return val && Array.isArray(val)
}

/**
 * @description: クライアントかどうかを判断する
 */
export const isClient = () => {
  return typeof window !== 'undefined'
}

/**
 * @description: ブラウザかどうかを判断する
 */
export const isWindow = (val: any): val is Window => {
  return typeof window !== 'undefined' && is(val, 'Window')
}

/**
 * @description: domかどうかを判断する
 */
export const isElement = (val: unknown): val is Element => {
  return isObject(val) && !!val.tagName
}

/**
 * @description: サーバーかどうかを判断する
 */
export const isServer = typeof window === 'undefined'

/**
 * @description: 画像ノードかどうかを判断する
 */
export function isImageDom(o: Element) {
  return o && ['IMAGE', 'IMG'].includes(o.tagName)
}
