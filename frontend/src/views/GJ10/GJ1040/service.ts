/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:契約者別契約情報入力確認チェックリスト（Ｂ４サイズ）
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.08.29
 * 作成者　　: wx
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/service/request/common-service'
import { InitRequest, InitResponse, PreviewRequest } from './type'

const servicename = 'GJ1040'

/** 初期化処理_プレビュー画面 */
export const Init = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'Init'
  return api(servicename, methodname, params, undefined, { loading: true })
}

/** プレビュー処理_プレビュー画面 */
export const Preview = (params: PreviewRequest): Promise<DaResponseBase> => {
  const methodname = 'Preview'
  return api(servicename, methodname, params)
}
