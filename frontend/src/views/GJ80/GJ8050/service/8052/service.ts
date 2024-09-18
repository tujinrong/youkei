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
  DeleteSitenRequest,
  InitSitenDetailRequest,
  InitSitenDetailResponse,
  SaveSitenRequest,
} from './type'

const servicename = 'GJ8052'

/**初期化処理(詳細画面) */
export const InitSitenDetail = (
  params: InitSitenDetailRequest
): Promise<InitSitenDetailResponse> => {
  const methodname = 'InitSitenDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/**保存処理(詳細画面) */
export const SaveSiten = (
  params: SaveSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveSiten'
  return api(servicename, methodname, params, undefined)
}

/**削除処理(詳細画面) */
export const DeleteSiten = (
  params: DeleteSitenRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteSiten'
  return api(servicename, methodname, params, undefined)
}
