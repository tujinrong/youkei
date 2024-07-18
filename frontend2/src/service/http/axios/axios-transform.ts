/**
 * プロジェクトに応じて構成できるデータ処理クラス
 */
import type { AxiosRequestConfig, AxiosResponse } from 'axios'
import type { RequestOptions, Result } from './types'

export abstract class AxiosTransform {
  /**
   * @description: リクエスト前のプロセス構成
   * @description: Process configuration before request
   */
  beforeRequestHook?: (
    config: AxiosRequestConfig,
    options: RequestOptions
  ) => AxiosRequestConfig

  /**
   * @description: リクエストは正常に処理されました
   */
  transformRequestData?: (
    res: AxiosResponse<Result>,
    options: RequestOptions
  ) => any

  /**
   * @description: 失敗処理の要求
   */
  requestCatch?: (e: Error) => Promise<any>

  /**
   * @description: リクエスト前のインターセプター
   */
  requestInterceptors?: (config: AxiosRequestConfig) => AxiosRequestConfig

  /**
   * @description: リクエスト後のインターセプター
   */
  responseInterceptors?: (res: AxiosResponse<any>) => AxiosResponse<any>

  /**
   * @description: リクエスト前のインターセプターエラー処理
   */
  requestInterceptorsCatch?: (error: Error) => void

  /**
   * @description: リクエスト後のインターセプターエラー処理
   */
  responseInterceptorsCatch?: (error: Error) => void
}
