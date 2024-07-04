/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  サービス処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitListResponse, InitListRequest } from './type'
const servicename = 'AWKK00703D'

/** 初期化処理(エラー一覧(行のエラー明細）) */
export const InitList = (params: InitListRequest): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, params)
}
