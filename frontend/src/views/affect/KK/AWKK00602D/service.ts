/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース処理
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import { InitResponse, InitRequest, InitFormatListRequest, InitFormatListResponse } from './type'
const servicename = 'AWKK00602D'

/** 初期化処理(取込設定：取込ファイルIF情報ダイアログ画面) */
export const InitDetail = (params: InitRequest): Promise<InitResponse> => {
  const methodname = 'InitDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理(フォーマット) */
export const InitFormatList = (params: InitFormatListRequest): Promise<InitFormatListResponse> => {
  const methodname = 'InitFormatList'
  return api(servicename, methodname, params)
}
