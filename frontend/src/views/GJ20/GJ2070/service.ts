/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 家畜防疫互助金積立金等請求通知書（新規加入者）
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.09.06
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'

import { InitRequest, InitResponse, PreviewRequest } from './type'

const servicename = 'GJ2070'

/** 初期化処理(プレビュー画面) */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** プレビュー処理(プレビュー画面) */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params)
}
