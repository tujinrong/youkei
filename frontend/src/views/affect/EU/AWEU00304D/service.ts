// *******************************************************************
// 業務名称　: 養鶏-互助防疫システム
// 機能概要　: 警告内容・帳票発行対象外者設定
//             サービス処理
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
import { api } from '@/utils/http/common-service'
import {
  SearchWarningsRequest,
  SearchWarningsResponse,
  UpdateWarnCheckboxRequest,
  UpdateWarningDetailsRequest
} from './type'
const servicename = 'AWEU00304D'

/** 警告内容検索処理 */
export const SearchWarnings = (
  params: SearchWarningsRequest,
  onNextOk?: (data?) => void
): Promise<SearchWarningsResponse> => {
  const methodname = 'SearchWarnings'
  return api(servicename, methodname, params, { loading: true }, onNextOk)
}

/**警告チェックの処理 */
export const UpdateWarnCheckbox = (params: UpdateWarnCheckboxRequest): Promise<DaResponseBase> => {
  const methodname = 'UpdateWarnCheckbox'
  return api(servicename, methodname, params, { loading: true })
}

/**警告内容の選ぶの処理 */
export const UpdateWarningDetails = (
  params: UpdateWarningDetailsRequest
): Promise<DaResponseBase> => {
  const methodname = 'UpdateWarningDetails'
  return api(servicename, methodname, params)
}
