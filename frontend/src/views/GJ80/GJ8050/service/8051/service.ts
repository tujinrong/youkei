/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.07.24
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import {
  DeleteBankRequest,
  InitBankDetailRequest,
  InitBankDetailResponse,
  SaveBankRequest,
} from './type'

const servicename = 'GJ8051'
/**初期化処理(詳細画面) */
export const InitBankDetail = (
  params: InitBankDetailRequest
): Promise<InitBankDetailResponse> => {
  const methodname = 'InitBankDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**保存処理(詳細画面) */
export const SaveBank = (params: SaveBankRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveBank'
  return api(servicename, methodname, params, undefined)
}

/**削除処理(詳細画面) */
export const DeleteBank = (
  params: DeleteBankRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteBank'
  return api(servicename, methodname, params, undefined)
}
