/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { InitRequest, InitResponse, PreviewRequest } from './type';

const servicename = 'xxxx'
/** 初期化処理_プレビュー画面 Init */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init';
  return api(servicename, methodName, params, undefined, { loading: true });
};
/** プレビュー */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodName = 'Preview';
  return api(servicename, methodName, params, undefined, { loading: true });
};
