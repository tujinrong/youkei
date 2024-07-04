/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 基幹系他システム情報照会
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
import {
  SearchSetaiListResponse,
  CommonRequest,
  InitDetailResponse,
  SearchJuminDetailResponse,
  SearchCommonRequest,
  SearchKaZeiDetailResponse,
  SearchNoZeiDetailResponse,
  SearchKojoDetailResponse,
  SearchKojoDetailRequest,
  SearchKojoDetailRowsResponse,
  SearchKojoDetailRowsRequest,
  SearchKokuhoDetailResponse,
  SearchKokiDetailResponse,
  SearchSeihoDetailResponse,
  SearchKaigoDetailResponse,
  SearchSyogaiDetailResponse,
  SearchPersonListResponse
} from './type'
const servicename = 'AWKK00101G'

/** 検索処理(一覧画面) */
export const SearchPersonList = (
  params: Partial<PersonSearchRequest>,
  onNextOk?: (data?) => void
): Promise<SearchPersonListResponse> => {
  const methodname = 'SearchPersonList'
  SaveHistory({ kinoid: servicename }) //使用履歴の保存処理
  return api(servicename, methodname, params, { personalno: params.personalno }, onNextOk)
}

/** 検索処理(世帯一覧) */
export const SearchSetaiList = (params: CommonRequest): Promise<SearchSetaiListResponse> => {
  const methodname = 'SearchSetaiList'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: CommonRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：住基タブ) */
export const SearchJuminDetail = (
  params: SearchCommonRequest
): Promise<SearchJuminDetailResponse> => {
  const methodname = 'SearchJuminDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：課税・納税義務者タブ_課税) */
export const SearchKaZeiDetail = (
  params: SearchCommonRequest
): Promise<SearchKaZeiDetailResponse> => {
  const methodname = 'SearchKaZeiDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：課税・納税義務者タブ_納税) */
export const SearchNoZeiDetail = (
  params: SearchCommonRequest
): Promise<SearchNoZeiDetailResponse> => {
  const methodname = 'SearchNoZeiDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：税額控除タブ) */
export const SearchKojoDetail = (
  params: SearchKojoDetailRequest
): Promise<SearchKojoDetailResponse> => {
  const methodname = 'SearchKojoDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：税額控除タブ_明細) */
export const SearchKojoDetailRows = (
  params: SearchKojoDetailRowsRequest
): Promise<SearchKojoDetailRowsResponse> => {
  const methodname = 'SearchKojoDetailRows'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：国保タブ) */
export const SearchKokuhoDetail = (
  params: SearchCommonRequest
): Promise<SearchKokuhoDetailResponse> => {
  const methodname = 'SearchKokuhoDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：後期タブ) */
export const SearchKokiDetail = (
  params: SearchCommonRequest
): Promise<SearchKokiDetailResponse> => {
  const methodname = 'SearchKokiDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：生保タブ) */
export const SearchSeihoDetail = (
  params: SearchCommonRequest
): Promise<SearchSeihoDetailResponse> => {
  const methodname = 'SearchSeihoDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：介護タブ) */
export const SearchKaigoDetail = (
  params: SearchCommonRequest
): Promise<SearchKaigoDetailResponse> => {
  const methodname = 'SearchKaigoDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面：福祉タブ) */
export const SearchSyogaiDetail = (
  params: SearchCommonRequest
): Promise<SearchSyogaiDetailResponse> => {
  const methodname = 'SearchSyogaiDetail'
  return api(servicename, methodname, params)
}
