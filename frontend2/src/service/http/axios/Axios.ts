import type { AxiosRequestConfig, AxiosInstance, AxiosResponse } from 'axios'
import axios from 'axios'
import { AxiosCanceler } from './axios-cancel'
import { isFunction } from '@/utils/is'
import { clone } from 'xe-utils'
import type { RequestOptions, CreateAxiosOptions, Result } from './types'
import { ContentTypeEnum, EnumServiceResult } from '@/enum'
import { showInfoModal } from '@/utils/modal'

let controller = new AbortController()

export * from './axios-transform'

/**
 * @description:  axiosモジュール
 */
export class VAxios {
  private axiosInstance: AxiosInstance
  private options: CreateAxiosOptions

  constructor(options: CreateAxiosOptions) {
    this.options = options
    this.axiosInstance = axios.create(options)
    this.setupInterceptors()
  }

  private getTransform() {
    const { transform } = this.options
    return transform
  }

  /**
   * @description: インターセプター構成
   */
  private setupInterceptors() {
    const transform = this.getTransform()
    if (!transform) {
      return
    }
    const {
      requestInterceptors,
      requestInterceptorsCatch,
      responseInterceptors,
      responseInterceptorsCatch,
    } = transform

    const axiosCanceler = new AxiosCanceler()

    // インターセプター構成処理を要求する
    this.axiosInstance.interceptors.request.use(
      (config: AxiosRequestConfig) => {
        const {
          headers: { ignoreCancelToken } = { ignoreCancelToken: false },
        } = config
        !ignoreCancelToken && axiosCanceler.addPending(config)
        if (requestInterceptors && isFunction(requestInterceptors)) {
          config = requestInterceptors(config)
        }
        return config
      },
      undefined
    )

    // インターセプターエラーキャプチャを要求する
    requestInterceptorsCatch &&
      isFunction(requestInterceptorsCatch) &&
      this.axiosInstance.interceptors.request.use(
        undefined,
        requestInterceptorsCatch
      )

    // 応答結果インターセプター処理
    this.axiosInstance.interceptors.response.use((res: AxiosResponse<any>) => {
      res && axiosCanceler.removePending(res.config)
      if (responseInterceptors && isFunction(responseInterceptors)) {
        res = responseInterceptors(res)
      }
      return res
    }, undefined)

    // 応答結果インターセプターエラーキャプチャ
    responseInterceptorsCatch &&
      isFunction(responseInterceptorsCatch) &&
      this.axiosInstance.interceptors.response.use(
        undefined,
        responseInterceptorsCatch
      )
  }

  /**
   * @description:   リクエスト
   */
  request(
    config: AxiosRequestConfig,
    options?: RequestOptions
  ): Promise<Result> {
    let conf: AxiosRequestConfig = clone(config, true)
    const transform = this.getTransform()
    const { requestOptions } = this.options
    const opt: RequestOptions = Object.assign({}, requestOptions, options)
    const { beforeRequestHook, requestCatch, transformRequestData } =
      transform || {}
    if (beforeRequestHook && isFunction(beforeRequestHook)) {
      conf = beforeRequestHook(conf, opt)
    }
    conf.signal = controller.signal
    conf.headers = {
      'Content-Type': ContentTypeEnum.JSON,
      ...conf.headers,
    }

    return new Promise((resolve, reject) => {
      this.axiosInstance
        .request<unknown, AxiosResponse<Result>>(conf)
        .then((res: AxiosResponse<Result>) => {
          // リクエストがキャンセルされたかどうか
          const isCancel = axios.isCancel(res)
          if (isCancel) {
            return resolve
          }
          if (
            transformRequestData &&
            isFunction(transformRequestData) &&
            !isCancel
          ) {
            const ret = transformRequestData(res, opt)
            if (ret && ret.returncode === EnumServiceResult.OK) {
              return resolve(ret)
            }
          }
          return reject(res)
        })
        .catch((e: Error) => {
          if (requestCatch && isFunction(requestCatch)) {
            reject(requestCatch(e))
            return
          }
          reject(e)
        })
    })
  }

  /**
   * @description:  ファイルをアップロードしてプレビューに戻ります
   */
  uploadPriview(
    config: AxiosRequestConfig,
    options?: RequestOptions
  ): Promise<Result> {
    const transform = this.getTransform()
    const { requestOptions } = this.options
    const opt: RequestOptions = Object.assign({}, requestOptions, options)
    const { requestCatch, transformRequestData } = transform || {}

    const url = `${requestOptions?.apiUrl || ''}${config.url}`
    const formData: FormData = config.params

    return new Promise((resolve, reject) => {
      this.axiosInstance
        .post<unknown, AxiosResponse<Result>>(url, formData, {
          responseType: 'json',
          headers: {
            'Content-Type': ContentTypeEnum.FORM_DATA,
          },
        })
        .then((res: AxiosResponse<Result>) => {
          // リクエストがキャンセルされたかどうか
          const isCancel = axios.isCancel(res)
          if (isCancel) {
            return resolve
          }
          if (
            transformRequestData &&
            isFunction(transformRequestData) &&
            !isCancel
          ) {
            const ret = transformRequestData(res, opt)
            if (ret && ret.returncode === EnumServiceResult.OK) {
              return resolve(ret)
            }
          }
          return reject(res)
        })
        .catch((e: Error) => {
          if (requestCatch && isFunction(requestCatch)) {
            reject(requestCatch(e))
            return
          }
          reject(e)
        })
    })
  }

  /**
   * @description:  preview
   */
  preview<T = any>(
    config: AxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    let conf: AxiosRequestConfig = clone(config, true)
    const transform = this.getTransform()

    const { requestOptions } = this.options

    const opt: RequestOptions = Object.assign({}, requestOptions, options)

    const { beforeRequestHook, requestCatch } = transform || {}
    if (beforeRequestHook && isFunction(beforeRequestHook)) {
      conf = beforeRequestHook(conf, opt)
    }
    return new Promise((resolve, reject) => {
      this.axiosInstance
        .post<any, AxiosResponse<Result>>(conf.url as string, conf.data, {
          responseType: 'blob',
        })
        .then((res: any) => {
          if (res) {
            if (res.headers?.returncode == EnumServiceResult.OK) {
              resolve(res.data)
            } else {
              if (res.headers?.returncode == EnumServiceResult.ServiceError) {
                showInfoModal({
                  type: 'error',
                  content: res.headers?.message,
                })
                reject(res.headers?.message)
              }
              if (res.headers?.returncode == EnumServiceResult.ServiceAlert) {
                showInfoModal({
                  type: 'warning',
                  content: res.headers?.message,
                })
                reject(res.headers?.message)
              }
              if (res.headers?.returncode == EnumServiceResult.Hidden) {
                reject()
              }
              reject(window.decodeURI(res.headers?.message))
            }
          }
          reject()
        })
        .catch((e: Error) => {
          if (requestCatch && isFunction(requestCatch)) {
            reject(requestCatch(e))
          }
          reject(e)
        })
    })
  }

  cancelRequest() {
    controller.abort()
    controller = new AbortController()
  }

  /** ダウンロード */
  download<T = any>(
    config: AxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    let conf: AxiosRequestConfig = clone(config, true)
    const transform = this.getTransform()

    const { requestOptions } = this.options

    const opt: RequestOptions = Object.assign({}, requestOptions, options)

    const { beforeRequestHook, requestCatch } = transform || {}
    if (beforeRequestHook && isFunction(beforeRequestHook)) {
      conf = beforeRequestHook(conf, opt)
    }
    return new Promise((resolve, reject) => {
      this.axiosInstance
        .post<any, AxiosResponse<Result>>(conf.url as string, conf.data, {
          responseType: 'blob',
          signal: controller.signal,
          headers: conf.headers,
        })
        .then((res: any) => {
          if (res) {
            if (res.headers?.returncode == EnumServiceResult.OK) {
              const blob = res.data
              let fileName = ''
              const contentDisposition = res.headers['content-disposition']
              if (contentDisposition) {
                fileName = decodeURIComponent(
                  res.headers['content-disposition']
                    .split('=')[2]
                    .replace("UTF-8''", '')
                )
              }
              document.createElement('a')
              // 非IEダウンロード
              const elink = document.createElement('a')
              elink.download = fileName
              elink.target = '_blank'
              elink.style.display = 'none'
              elink.href = URL.createObjectURL(blob)
              document.body.appendChild(elink)
              elink.click()
              URL.revokeObjectURL(elink.href)
              document.body.removeChild(elink)
              resolve(res)
            } else {
              if (res.headers?.returncode == EnumServiceResult.ServiceError) {
                showInfoModal({
                  type: 'error',
                  content: window.decodeURI(res.headers?.message),
                })
                reject(res.headers?.message)
              }
              if (res.headers?.returncode == EnumServiceResult.ServiceAlert2) {
                showInfoModal({
                  type: 'warning',
                  content: window.decodeURI(res.headers?.message),
                })
                reject(res.headers?.message)
              }
              if (res.headers?.returncode == EnumServiceResult.Hidden) {
                reject()
              }
              reject(window.decodeURI(res.headers?.message))
            }
          }
          reject()
        })
        .catch((e: Error) => {
          if (requestCatch && isFunction(requestCatch)) {
            reject(requestCatch(e))
          }
          reject(e)
        })
    })
  }
}
