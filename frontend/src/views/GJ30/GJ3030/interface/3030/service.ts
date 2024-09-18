/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { DeleteRequest, InitDetailRequest, InitDetailResponse, InitRequest, InitResponse, SaveRequest, SearchRequest, SearchResponse } from './type';

const servicename = 'GJ3030'
/** 初期化処理_詳細画面 Init */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init';
  return api(servicename, methodName, params, undefined, { loading: true });
};

export const search = (params: SearchRequest): Promise<SearchResponse> => {
  const methodName = 'Search';
  return api(servicename, methodName, params, undefined, { loading: true });
};
// 初期化処理_詳細画面InitDetail Service
export const InitDetail = (params: InitDetailRequest): Promise<InitDetailResponse> => {
  const methodName = 'InitDetail';
  return api(servicename, methodName, params, undefined, { loading: true });
};
// 保存処理_詳細画面Save Service
export const Save = (params: SaveRequest): Promise<DaResponseBase> => {
  const methodName = 'Save';
  return api(servicename, methodName, params, undefined, { loading: true });
};
// 削除処理_詳細画面Delete Service
export const Delete = (params: DeleteRequest): Promise<DaResponseBase> => {
  const methodName = 'Delete';
  return api(servicename, methodName, params, undefined, { loading: true });
};
