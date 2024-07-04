/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, download, upload } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListResponse,
  SearchListRequest,
  InitDetailResponse,
  InitDetailRequest,
  SaveDetailRequest,
  DetailCommonRequest,
  UploadRequest,
  InitSystemCodeRequest,
  InitSystemCodeResponse,
  InitTableFieldRequest,
  InitTableFieldResponse,
  ErrorDownloadRequest,
  ReSearchProcResponse,
  DeleteDetailRequest,
  CheckOrderSeqRequest,
  SaveDetailResponse,
  UploadResponse
} from './type'
const servicename = 'AWKK00601G'

/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const Search = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'Search'
  return api(servicename, methodname, params, { loading: true })
}

/** 初期化処理(詳細画面) */
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, { loading: true })
}

/** 登録項目設定情報：明細一覧初期化処理（ヘッダーテーブル変更時）(詳細画面) */
export const IniTableFieldList = (
  params: InitTableFieldRequest
): Promise<InitTableFieldResponse> => {
  const methodname = 'IniTableFieldList'
  return api(servicename, methodname, params)
}

/** 変換コード情報：【本システムコード】ドロップダウン初期化処理(【変換区分】変更時）(詳細画面) */
export const InitSysCodeList = (params: InitSystemCodeRequest): Promise<InitSystemCodeResponse> => {
  const methodname = 'InitSysCodeList'
  return api(servicename, methodname, params)
}

/** ヘッダー情報：「並び順」重複エラーチェック(詳細画面) */
export const CheckOrderSeq = (params: CheckOrderSeqRequest): Promise<DaResponseBase> => {
  const methodname = 'CheckOrderSeq'
  return api(servicename, methodname, params, { loading: true })
}

/** 登録処理 */
export const Save = (params: SaveDetailRequest): Promise<SaveDetailResponse> => {
  const methodname = 'Save'
  return api(servicename, methodname, params)
}

/** 削除処理 */
export const Delete = (params: DeleteDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}

/** ダウンロード処理 */
export const Download = (params: DetailCommonRequest): Promise<DaResponseBase> => {
  const methodname = 'Download'
  return download(servicename, methodname, params, { loading: true })
}

/** ダウンロード処理 */
export const ErrorDownload = (params: ErrorDownloadRequest): Promise<CmDownloadResponseBase> => {
  const methodname = 'ErrorDownload'
  return download(servicename, methodname, params)
}

/** アップロード処理 */
export const ExcelUpload = (params: UploadRequest): Promise<UploadResponse> => {
  const methodname = 'ExcelUpload'
  return upload(servicename, methodname, params)
}

/** 詳細画面：【ヘッダ】のドロップダウンリストの初期化データをセットする */
export const SetInitDetailHeadSelectorData = (params: InitDetailResponse): Promise<void> => {
  const methodname = 'SetInitDetailHeadSelectorData'
  return api(servicename, methodname, params)
}

/** ストアドプロシージャ情報のドロップダウンリスト再検索処理 */
export const ReSearchProc = (params: DaRequestBase): Promise<ReSearchProcResponse> => {
  const methodname = 'ReSearchProc'
  return api(servicename, methodname, params)
}
