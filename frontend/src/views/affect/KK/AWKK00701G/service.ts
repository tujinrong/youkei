/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込設定
 * 　　　　　  サービス処理
 * 作成日　　: 2023.10.10
 * 作成者　　: 韋
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download, upload } from '@/utils/http/common-service'
import {
  CheckInfoResponse,
  DeleteDetailRequest,
  DeleteKimpListRequest,
  DetailRequest,
  GetTargetItemValueRequest,
  GetTargetItemValueResponse,
  InitDetailRequest,
  InitDetailResponse,
  InitKimpListResponse,
  KimpHistoryFileDownRequest,
  SearchKimpDataListResponse,
  SearchKimpHistoryListResponse,
  SearchKimpListRequest,
  SearchKimpListResponse,
  DoSpecialPageItemRequest,
  DoSpecialPageItemResponse,
  ProcessTimerResponse,
  ProcessTimerRequest,
  SaveWorkResponse,
  DoKansuRequest,
  DoKansuResponse
} from './type'
const servicename = 'AWKK00701G'

/** 初期化処理(取込設定一覧画面） */
export const InitKimpList = (): Promise<InitKimpListResponse> => {
  const methodname = 'InitKimpList'
  return api(servicename, methodname, {})
}

/** 検索処理(取込設定一覧画面) */
export const SearchKimpList = (params: SearchKimpListRequest): Promise<SearchKimpListResponse> => {
  const methodname = 'SearchKimpList'
  return api(servicename, methodname, params, { loading: true })
}

/** "初期検索処理(未処理一覧画面) */
export const InitSearchKimpDataList = (
  params: SearchKimpListRequest
): Promise<SearchKimpDataListResponse> => {
  const methodname = 'InitSearchKimpDataList'
  return api(servicename, methodname, params)
}

/** 削除(未処理一覧画面) */
export const DeleteKimpList = (params: DeleteKimpListRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteKimpList'
  return api(servicename, methodname, params)
}

/** 初期検索処理(取込履歴一覧画面)*/
export const InitSearchKimpHistoryList = (
  params: SearchKimpListRequest
): Promise<SearchKimpHistoryListResponse> => {
  const methodname = 'InitSearchKimpHistoryList'
  return api(servicename, methodname, params)
}

/** 初期化処理(取込（一括入力）編集画面)*/
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 参照元項目入力後参照先項目の値を取得処理　(取込（一括入力）編集画面) */
export const GetTargetItemValue = (
  params: GetTargetItemValueRequest
): Promise<GetTargetItemValueResponse> => {
  const methodname = 'GetTargetItemValue'
  return api(servicename, methodname, params)
}

export const DoSpecialPageItem = (
  params: DoSpecialPageItemRequest
): Promise<DoSpecialPageItemResponse> => {
  const methodname = 'DoSpecialPageItem'
  return api(servicename, methodname, params)
}

/** チェック処理(取込（一括入力）編集画面)*/
export const CheckDetail = (params: DetailRequest): Promise<CheckInfoResponse> => {
  const methodname = 'CheckDetail'
  return api(servicename, methodname, params)
}

/** 登録実行処理(取込（一括入力）編集画面)*/
export const Save = (params: DetailRequest): Promise<DaResponseBase> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 仮保存処理(取込（一括入力）編集画面)*/
export const SaveWork = (params: DetailRequest): Promise<SaveWorkResponse> => {
  const methodname = 'SaveWork'
  return api(servicename, methodname, params)
}

/** 削除(取込（一括入力）編集画面)*/
export const DeleteEdit = (params: DeleteDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'DeleteEdit'
  return api(servicename, methodname, params)
}

/** 取込履歴ファイルダウンロード処理(取込履歴一覧画面)*/
export const KimpHistoryFileDown = (
  params: KimpHistoryFileDownRequest
): Promise<CmDownloadResponseBase> => {
  const methodname = 'KimpHistoryFileDown'
  return download(servicename, methodname, params)
}

/** 取込実行のプログレスバー*/
export const ProgressHandle = (params: ProcessTimerRequest): Promise<ProcessTimerResponse> => {
  const methodname = 'ProcessTimer'
  return api(servicename, methodname, params)
}

/** 関数値を取得処理 (取込（一括入力）編集画面)*/
export const DoKansu = (params: DoKansuRequest): Promise<DoKansuResponse> => {
  const methodname = 'DoKansu'
  return api(servicename, methodname, params)
}
