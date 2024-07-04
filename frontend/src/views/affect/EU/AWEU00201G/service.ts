/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 帳票管理
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.04.01
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api, upload, uploadDownload } from '@/utils/http/common-service'
import {
  InitListResponse,
  SearchListRequest,
  SearchListResponse,
  InitSpecialItemsResponse,
  DownloadExcelTemplateRequest,
  SaveProjectRequest,
  ParseAndFormatSqlResponse,
  ParseAndFormatSqlRequest,
  ParseAndFormatProcedureResponse,
  ParseAndFormatProcedureRequest,
  YosikiCommonRequest,
  InitConditionTabResponse,
  InitDetailRequest,
  InitDetailResponse,
  InitItemsTabRequest,
  InitItemsTabResponse,
  SearchConditionDetailRequest,
  SearchConditionDetailResponse,
  SearchConditionTabResponse,
  SearchExcelMappingTabRequest,
  SearchExcelMappingTabResponse,
  SearchReportTabResponse,
  SearchYosikiTabResponse,
  YosikiRequestTabBase,
  InitSpecialItemsRequest,
  InitSpecialConditionsResponse,
  InitSpecialConditionsRequest,
  CheckDataTypeRequestBase,
  SearchJokenDetailRequest,
  SearchJokenResponse
} from './type'
const servicename = 'AWEU00201G'

//一覧画面-------------------------------------------------------------------------------------------
/** 初期化処理(一覧画面) */
export const InitList = (): Promise<InitListResponse> => {
  const methodname = 'InitList'
  return api(servicename, methodname, {})
}

/** 検索処理(一覧画面) */
export const SearchList = (params: SearchListRequest): Promise<SearchListResponse> => {
  const methodname = 'SearchList'
  return api(servicename, methodname, params, { loading: true })
}

//詳細画面(共通部分)------------------------------------------------------------------------------------
/** 初期化処理(詳細画面：共通部分) */
export const InitDetail = (
  params: InitDetailRequest,
  onNextOk?: (data?) => void
): Promise<InitDetailResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params, { loading: true }, onNextOk)
}

//帳票設定タブ------------------------------------------------------------------------------------
/** 検索処理(帳票設定タブ) */
export const SearchReportTab = (params: YosikiRequestTabBase): Promise<SearchReportTabResponse> => {
  const methodname = 'SearchReportTab'
  return api(servicename, methodname, params)
}

//様式設定タブ------------------------------------------------------------------------------------
/** 検索処理(様式設定タブ) */
export const SearchYosikiTab = (params: YosikiCommonRequest): Promise<SearchYosikiTabResponse> => {
  const methodname = 'SearchYosikiTab'
  return api(servicename, methodname, params)
}

//SQL項目------------------------------------------------------------------------------------
/** SELECT文の解析(様式設定タブ) */
export const ParseAndFormatSql = (
  params: ParseAndFormatSqlRequest
): Promise<ParseAndFormatSqlResponse> => {
  const methodname = 'ParseAndFormatSql'
  return api(servicename, methodname, params)
}

/** プロシージャの解析(様式設定タブ) */
export const ParseAndFormatProcedure = (
  params: ParseAndFormatProcedureRequest
): Promise<ParseAndFormatProcedureResponse> => {
  const methodname = 'ParseAndFormatProcedure'
  return api(servicename, methodname, params)
}

//項目定義タブ------------------------------------------------------------------------------------
/** 初期化処理(項目定義タブ) */
export const InitItemsTab = (params: InitItemsTabRequest): Promise<InitItemsTabResponse> => {
  const methodname = 'InitItemsTab'
  return api(servicename, methodname, params)
}

/** 検索処理(項目定義タブ) */
export const SearchItemsTab = (params: YosikiCommonRequest): Promise<InitItemsTabResponse> => {
  const methodname = 'SearchItemsTab'
  return api(servicename, methodname, params)
}

//検索条件タブ------------------------------------------------------------------------------------

/** 初期化処理(検索条件タブ)(作成方法がSQLの場合) */
export const InitConditionTab = (): Promise<InitConditionTabResponse> => {
  const methodname = 'InitConditionTab'
  return api(servicename, methodname, {})
}

/** データタイプのチェック */
export const CheckDataType = (params: CheckDataTypeRequestBase): Promise<DaResponseBase> => {
  const methodname = 'CheckDataType'
  return api(servicename, methodname, params)
}

/** 検索処理(検索条件タブ) */
export const SearchConditionTab = (
  params: YosikiCommonRequest
): Promise<SearchConditionTabResponse> => {
  const methodname = 'SearchConditionTab'
  return api(servicename, methodname, params)
}

//条件追加------------------------------------------------------------------------------------
/** 検索処理(検索条件タブ) */
export const InitSpecialConditions = (
  params: InitSpecialConditionsRequest
): Promise<InitSpecialConditionsResponse> => {
  const methodname = 'InitSpecialConditions'
  return api(servicename, methodname, params)
}

/** 検索処理(条件追加) */
export const SearchConditionDetail = (
  params: SearchConditionDetailRequest
): Promise<SearchConditionDetailResponse> => {
  const methodname = 'SearchConditionDetail'
  return api(servicename, methodname, params, { loading: true })
}
/** 検索処理(条件追加) */
export const SearchJokenDetail = (
  params: SearchJokenDetailRequest
): Promise<SearchJokenResponse> => {
  const methodname = 'SearchJokenDetail'
  return api(servicename, methodname, params)
}

//Excelマッピングタブ------------------------------------------------------------------------------------
/** 初期化処理(特殊項目)(Excelマッピングタブ) */
export const InitSpecialItems = (
  params: InitSpecialItemsRequest
): Promise<InitSpecialItemsResponse> => {
  const methodname = 'InitSpecialItems'
  return api(servicename, methodname, params)
}

/** 検索処理(Excelマッピングタブ) */
export const SearchExcelMappingTab = (
  params: SearchExcelMappingTabRequest
): Promise<SearchExcelMappingTabResponse> => {
  const methodname = 'SearchExcelMappingTab'
  return api(servicename, methodname, params)
}

/** エクセルテンプレートファイルのダウンロード処理 */
export const DownloadExcelTemplate = (
  params: DownloadExcelTemplateRequest
): Promise<CmDownloadResponseBase> => {
  const methodname = 'DownloadExcelTemplate'
  return uploadDownload(servicename, methodname, params, { loading: true })
}

//登録・保存更新処理------------------------------------------------------------------------------------
/** 保存処理(画面全件情報) */
export const SaveProject = (params: SaveProjectRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveProject'
  return upload(servicename, methodname, params)
}

//削除処理------------------------------------------------------------------------------------
/** 削除処理 */
export const Delete = (params: YosikiRequestTabBase): Promise<DaResponseBase> => {
  const methodname = 'Delete'
  return api(servicename, methodname, params)
}
