/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: xxxxxxxxxxxxxxxxxxxxx
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.xx.xx
 * 作成者　　: xxxx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { CancelRequest, InitRequest, InitResponse, PreviewRequest } from './type'

const servicename = 'GJ3031'

/** 初期化処理_請求書発行画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodName = 'Init';
  return api(servicename, methodName, params, undefined, { loading: true });
};


/** プレビュー処理_通知書発行画面 */
/** プレビュー処理_請求書発行画面 Preview */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodName = 'Preview';
  return api(servicename, methodName, params, undefined, { loading: true });
};


/** 取消処理_請求書発行画面 Cancel */
export const Cancel = (params: CancelRequest): Promise<DaResponseBase> => {
  const methodName = 'Cancel';
  return api(servicename, methodName, params, undefined, { loading: true });
};

