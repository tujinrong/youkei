/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ログ情報管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.11.13
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  InitDetailResponse,
  InitDetailRequest,
  InitColumDetailResponse,
  SearchTusinDetailResponse,
  SearchCommonRequest,
  SearchBatchDetailResponse,
  SearchGaibuDetailResponse,
  SearchDBDetailResponse,
  SearchColumnDetailResponse,
  SearchColumnDetailRequest,
  SearchAtenaDetailResponse,
  OutputRequest
} from './type'
import { Save as SaveHistory } from '@/views/affect/AF/AWAF00202S/service'
const servicename = 'AWAF00803G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  SaveHistory({ kinoid: 'AWAF00803G' }) //使用履歴の保存処理
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理(詳細画面:項目値変更情報) */
export const InitColumDetail = (params: InitDetailRequest): Promise<InitColumDetailResponse> => {
  const methodname = 'InitColumDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:通信ログ情報) */
export const SearchTusinDetail = (
  params: SearchCommonRequest
): Promise<SearchTusinDetailResponse> => {
  const methodname = 'SearchTusinDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:バッチログ情報) */
export const SearchBatchDetail = (
  params: SearchCommonRequest
): Promise<SearchBatchDetailResponse> => {
  const methodname = 'SearchBatchDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:連携ログ情報) */
export const SearchGaibuDetail = (
  params: SearchCommonRequest
): Promise<SearchGaibuDetailResponse> => {
  const methodname = 'SearchGaibuDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:DB操作ログ情報) */
export const SearchDBDetail = (params: SearchCommonRequest): Promise<SearchDBDetailResponse> => {
  const methodname = 'SearchDBDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:項目値変更情報) */
export const SearchColumnDetail = (
  params: SearchColumnDetailRequest
): Promise<SearchColumnDetailResponse> => {
  const methodname = 'SearchColumnDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(詳細画面:宛名番号ログ情報) */
export const SearchAtenaDetail = (
  params: SearchCommonRequest
): Promise<SearchAtenaDetailResponse> => {
  const methodname = 'SearchAtenaDetail'
  return api(servicename, methodname, params)
}

/** CSV出力処理 */
export const Output = (params: OutputRequest): Promise<void> => {
  const methodname = 'Output'
  return download(servicename, methodname, params)
}
