//ls ss
import { AesEncryption, encryptKeys } from './encrypt/data'

const encryption = new AesEncryption({ key: encryptKeys.key, iv: encryptKeys.iv })

const sessionOptions = {
  namespace: 'ss_', // key prefix
  storage: 'sessionStorage',
  isEncrypt: false
}

const localOptions = {
  namespace: 'ls_', // key prefix
  storage: 'localStorage',
  default_cache_time: 60 * 60 * 24 * 7,
  isEncrypt: false
}

/**session */
export const ss = {
  getKey: (key: string) => {
    return sessionOptions.namespace + key
  },
  set: (key: string, value: any) => {
    const stringData = JSON.stringify({
      value
    })
    window[sessionOptions.storage].setItem(
      ss.getKey(key),
      sessionOptions.isEncrypt ? encryption.encryptByAES(stringData) : stringData
    )
  },
  setObj: (key: string, newVal: any) => {
    const oldVal = ss.get(key)
    if (!oldVal) {
      ss.set(key, newVal)
    } else {
      Object.assign(oldVal, newVal)
      ss.set(key, oldVal)
    }
  },
  /**
   * Read Cache
   * @param {string} key Cache key
   * @param {*=} def Default
   */
  get: (key: string, def: any = null) => {
    let item = window[sessionOptions.storage].getItem(ss.getKey(key))
    if (item) {
      try {
        if (sessionOptions.isEncrypt) {
          item = encryption.decryptByAES(item)
        }
        const data = JSON.parse(item)
        return data.value
      } catch (e) {
        console.error(e)
        return def
      }
    }
    return def
  },
  remove: (key: string) => {
    window[sessionOptions.storage].removeItem(ss.getKey(key))
  },
  clear: (): void => {
    window[sessionOptions.storage].clear()
  }
}

/**local */
export const ls = {
  getKey: (key: string) => {
    return localOptions.namespace + key
  },
  set: (key: string, value: any, expire: number | null = localOptions.default_cache_time) => {
    const stringData = JSON.stringify({
      value,
      expire: expire !== null ? new Date().getTime() + expire * 1000 : null
    })
    window[localOptions.storage].setItem(
      ls.getKey(key),
      localOptions.isEncrypt ? encryption.encryptByAES(stringData) : stringData
    )
  },
  setObj: (key: string, newVal: any, expire: number | null = localOptions.default_cache_time) => {
    const oldVal = ls.get(key)
    if (!oldVal) {
      ls.set(key, newVal, expire)
    } else {
      Object.assign(oldVal, newVal)
      ls.set(key, oldVal, expire)
    }
  },
  /**
   * Read Cache
   * @param {string} key Cache key
   * @param {*=} def Default
   */
  get: (key: string, def: any = null) => {
    let item = window[localOptions.storage].getItem(ls.getKey(key))
    if (item) {
      try {
        if (localOptions.isEncrypt) {
          item = encryption.decryptByAES(item)
        }
        const data = JSON.parse(item)
        const { value, expire } = data
        // Directly return within the validity period
        if (expire === null || expire >= Date.now()) {
          return value
        }
        ls.remove(ls.getKey(key))
      } catch (e) {
        console.error(e)
        return def
      }
    }
    return def
  },
  remove: (key: string) => {
    window[localOptions.storage].removeItem(ls.getKey(key))
  },
  clear: (): void => {
    window[localOptions.storage].clear()
  }
}

export default ls
