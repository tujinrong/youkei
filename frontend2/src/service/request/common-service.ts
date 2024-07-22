/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ベースロジック
 * 　　　　　  API定義
 * 作成日　　: 2023.03.03
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { AxiosRequestHeaders } from 'axios'
import { request } from './index'

/** ログイン処理 */
export async function login(
  servicename: string,
  methodname: string,
  data: any
): Promise<any> {
  const body = {
    servicename,
    methodname,
    bizrequest: {
      data: JSON.stringify(data),
    },
  }
  return request({
    url: '/AFCT/Login',
    method: 'post',
    data: body,
  })
}

/** Web共通 */
export function api(
  servicename: string,
  methodname: string,
  data: any,
  headers?: AxiosRequestHeaders & { loading?: boolean },
  onNextOk?: (data?: DaResponseBase) => void,
  onNextCancel?: (data?: DaResponseBase) => void
): Promise<any> {
  const body = {
    servicename,
    methodname,
    bizrequest: {
      data: JSON.stringify(data) || '',
    },
  }
  return request({
    url: '/AFCT/WebRequest',
    method: 'post',
    data: body,
    headers,
    extra: {
      onNextOk,
      onNextCancel,
    },
  })
}

// /** プレビュー処理 */
// export function preview(
//   servicename: string,
//   methodname: string,
//   data?: unknown,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const params = {
//     signal: controller.signal,
//     servicename,
//     methodname,
//     bizrequest: {
//       data: JSON.stringify(data) || '',
//     },
//   }

//   return http.preview({
//     url: '/AFCT/Preview',
//     method: RequestEnum.POST,
//     params,
//     headers,
//   })
// }

// /** ダウンロード処理 */
// export function download(
//   servicename: string,
//   methodname: string,
//   data: unknown,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const params = {
//     servicename,
//     methodname,
//     bizrequest: {
//       data: JSON.stringify(data),
//     },
//   }
//   return http.download({
//     url: '/AFCT/Download/WebRequestDownload',
//     method: RequestEnum.POST,
//     params,
//     headers,
//   })
// }

// /** アップロード処理 */
// export function upload(
//   servicename: string,
//   methodname: string,
//   data: any,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const formData = new FormData()
//   const { files, ...obj } = data

//   formData.append('servicename', servicename)
//   formData.append('methodname', methodname)
//   if (obj.filerequired !== undefined)
//     formData.append('filerequired', obj.filerequired)
//   formData.append(
//     'bizrequest.data',
//     JSON.stringify(files.length === 0 ? data : obj)
//   )
//   for (const file of files) {
//     formData.append('files', file)
//   }

//   return http.request({
//     url: '/AFCT/Upload',
//     method: RequestEnum.POST,
//     params: formData,
//     headers: { ...headers, 'Content-Type': ContentTypeEnum.FORM_DATA },
//   })
// }

// /** アップロード ダウンロード処理 */
// export function uploadDownload(
//   servicename: string,
//   methodname: string,
//   data: any,
//   headers?: RawAxiosRequestHeaders & { loading?: boolean }
// ): Promise<any> {
//   const formData = new FormData()
//   const { files, ...obj } = data

//   formData.append('servicename', servicename)
//   formData.append('methodname', methodname)
//   if (obj.filerequired !== undefined)
//     formData.append('filerequired', obj.filerequired)
//   formData.append(
//     'bizrequest.data',
//     JSON.stringify(files.length === 0 ? data : obj)
//   )
//   for (const file of files) {
//     formData.append('files', file)
//   }

//   return http.download({
//     url: '/AFCT/Download/UploadDownload',
//     method: RequestEnum.POST,
//     params: formData,
//     headers: { ...headers, 'Content-Type': ContentTypeEnum.FORM_DATA },
//   })
// }
