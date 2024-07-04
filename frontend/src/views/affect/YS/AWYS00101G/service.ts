/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 予防接種情報管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import { CommonRequest, InitDetailResponse, SearchListRequest, SearchListResponse } from './type'
const servicename = 'AWYS00101G'

/** 初期化処理(詳細画面) */
export const InitDetail = (params: CommonRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, { loading: true })
}

/** 検索処理(一覧画面) */
export const SearchList = (params: Partial<SearchListRequest>): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno })
}
