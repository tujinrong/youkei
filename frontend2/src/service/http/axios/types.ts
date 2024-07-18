import type { AxiosRequestConfig } from 'axios'
import type { AxiosTransform } from './axios-transform'

export interface CreateAxiosOptions extends AxiosRequestConfig {
  transform?: AxiosTransform
  requestOptions?: RequestOptions
}

export interface RequestOptions {
  // インターフェース アドレスが入力されていない場合は、デフォルトの apiUrl を使用します
  apiUrl?: string
  // click Error AlertModal's ok
  onNextOk?: (data?: DaResponseBase) => void
  // click Error AlertModal's cancel
  onNextCancel?: (data?: DaResponseBase) => void
}

export type Result<T = any> = {
  returncode: number
  message: string
} & T
