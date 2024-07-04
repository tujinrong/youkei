/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票項目追加
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  SearchStatisticResponse,
  SearchStatisticRequest,
  SearchNormalTreeRequest,
  SearchNormalTreeResponse,
  SearchStatisticTreeRequest,
  SearchProcItemRequest,
  CheckRequest
} from './type'
const servicename = 'AWEU00204D'

/** 検索処理(一覧項目ツリー) */
export const SearchNormalTree = (
  params: SearchNormalTreeRequest
): Promise<SearchNormalTreeResponse> => {
  const methodname = 'SearchNormalTree'
  return api(servicename, methodname, params)
}

/** "検索処理(集計項目ツリー) */
export const SearchStatisticTree = (
  params: SearchStatisticTreeRequest
): Promise<SearchNormalTreeResponse> => {
  const methodname = 'SearchStatisticTree'
  return api(servicename, methodname, params)
}

/** 検索処理(集計項目) */
export const SearchStatistic = (
  params: SearchStatisticRequest
): Promise<SearchStatisticResponse> => {
  const methodname = 'SearchStatistic'
  return api(servicename, methodname, params)
}

/** 検索処理(プロシージ項目) */
export const SearchProcItem = (
  params: SearchProcItemRequest
): Promise<SearchNormalTreeResponse> => {
  const methodname = 'SearchProcItem'
  return api(servicename, methodname, params)
}

/** チェック処理(登録押下) */
export const Check = (params: CheckRequest): Promise<DaResponseBase> => {
  const methodname = 'Check'
  return api(servicename, methodname, params)
}
