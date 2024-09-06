/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 年度マスタメンテナンス
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.19
 * 作成者　　: 高 智輝
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import { InitDetailResponse, SaveRequest } from './type'

const servicename = 'GJ8020'

/** 初期化処理(詳細画面) */
export const InitDetail = (
  params: DaRequestBase
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** 登録処理(詳細画面) */
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params, undefined, { loading: true })
}
