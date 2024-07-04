/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: DBデータ項目
 * 　　　　　  データ暗号化
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { encrypt, decrypt } from 'crypto-js/aes'
import { parse } from 'crypto-js/enc-utf8'
import pkcs7 from 'crypto-js/pad-pkcs7'
import ECB from 'crypto-js/mode-ecb'
import md5 from 'crypto-js/md5'
import UTF8 from 'crypto-js/enc-utf8'
import Base64 from 'crypto-js/enc-base64'
import SHA256 from 'crypto-js/sha256'
import JSEncrypt from 'jsencrypt'

interface EncryptionParams {
  key: string
  iv: string
}
export const encryptKeys = {
  key: 'aeskeyxxx',
  iv: 'aesivxxx'
}

const RsaPublicKeyPem = `-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhl81icNTbjrhWHs+OiPw
fBmIqo4AccHz0gMWiIwH7nL34LKRFYD0UUOalUOtC3hWaEjaFdMrPbCjAluZuIMC
qi0ulKUub0mPAvWP0QFFu+a3Uv1ITwSKcWKcO7y5rMcjEXo7T8l03TQhlKY38QMh
W2FxGhZzplFixhdIgR46IlgarN0wdqJCv9zbx8VaM7QVDW5aVdbse+8WuqCLuSUo
BgBclO4+YA3dAO2VkEp+5zxjwjxmkXhX6merwCPn4K83a1vLVM3LO5wZXtCRQlE7
GxMVemtxZV/+3Nlup3TTIYClBNXYgt0tQeR9u4fKFXnwvfUd73zCRwnoETab7wQr
twIDAQAB
-----END PUBLIC KEY-----`

export class AesEncryption {
  private key
  private iv

  constructor(opt: Partial<EncryptionParams> = {}) {
    const { key, iv } = opt
    if (key) {
      this.key = parse(key)
    }
    if (iv) {
      this.iv = parse(iv)
    }
  }

  get getOptions() {
    return {
      mode: ECB,
      padding: pkcs7,
      iv: this.iv
    }
  }

  encryptByAES(cipherText: string): string {
    return encrypt(cipherText, this.key, this.getOptions).toString()
  }

  decryptByAES(cipherText: string): string {
    return decrypt(cipherText, this.key, this.getOptions).toString(UTF8)
  }
}

export function encryptByBase64(cipherText: string): string {
  return UTF8.parse(cipherText).toString(Base64)
}

export function decodeByBase64(cipherText: string): string {
  return Base64.parse(cipherText).toString(UTF8)
}

export function encryptByMd5(password: string): string {
  return md5(password).toString()
}

export function encryptBySHA256(password: string, salt?: string): string {
  return SHA256(salt ? salt + password : password).toString()
}

export const encryptByRSA = (data?: string) => {
  if (!data) return
  const encrypt = new JSEncrypt()
  encrypt.setPublicKey(RsaPublicKeyPem)
  return encrypt.encrypt(data) || undefined
}

export const decryptByRSA = (data = '', privkey = '') => {
  const decrypt = new JSEncrypt()
  decrypt.setPrivateKey(privkey)
  return decrypt.decrypt(data)
}
