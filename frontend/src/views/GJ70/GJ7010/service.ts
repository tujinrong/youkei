/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { CsvExportRequest, CsvExportResponse, InitRequest, InitResponse, SearchRequest, SearchResponse } from './type';

const servicename = 'GJ7010'
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init';
  return api(servicename, methodName, params, undefined, { loading: true });
};
export const Search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodName = 'Search';
  return api(servicename, methodName, params, undefined, { loading: true });
};
/** CSV出力処理_一覧画面サービス */
export const CsvExport = (params: CsvExportRequest): Promise<CsvExportResponse> => {
  const methodName = 'CsvExport';
  return api(servicename, methodName, params, undefined, { loading: true });
};


