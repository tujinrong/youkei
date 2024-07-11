/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 拡張事業
 * 　　　　　  インターフェース処理
 * 作成日　　: 2024.03.05
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { api } from '@/utils/http/common-service'
import {
  InitChoiceResponse,
  InitChoiceRequest,
  InitKensinListResponse,
  InitKensinDetailResponse,
  InitKensinCommonRequest,
  SaveKensinJigyoDetailRequest,
  InitKensinItemListResponse,
  InitKensinItemDetailResponse,
  InitKensinItemDetailRequest,
  SaveKensinItemDetailRequest,
  DeteleKensinItemDetailRequest,
  GetCodejokenListResponse,
  GetCodejokenListRequest,
  InitSidoItemListResponse,
  SearchSidoItemListResponse,
  SidoCommonRequest,
  InitSidoItemDetailResponse,
  InitSidoItemDetailRequest,
  SaveSidoItemDetailRequest,
  DeteleSidoItemDetailRequest,
  SearchKensinYoyakuJigyoListResponse,
  KensinYoyakuJigyoListCommonRequest,
  InitKensinYoyakuJigyoDetailResponse,
  InitKensinYoyakuJigyoDetailRequest,
  SaveKensinYoyakuJigyoDetailRequest,
  DeleteKensinYoyakuJigyoDetailRequest,
  InitYoyakuSidoJigyoListResponse,
  SaveYoyakuSidoJigyoListRequest,
  SaveKensinJigyoDetailResponse
} from './type'
const servicename = 'AWKK00801G'

/** 初期化処理(選択画面) */
export const InitChoice = (params: InitChoiceRequest): Promise<InitChoiceResponse> => {
  const methodname = 'InitChoice'
  return api(servicename, methodname, params)
}

/** 初期化処理(検診事業一覧画面) */
export const InitKensinJigyoList = (): Promise<InitKensinListResponse> => {
  const methodname = 'InitKensinJigyoList'
  return api(servicename, methodname, {})
}

/** 初期化処理(検診事業詳細画面) */
export const InitKensinJigyoDetail = (
  params: InitKensinCommonRequest
): Promise<InitKensinDetailResponse> => {
  const methodname = 'InitKensinJigyoDetail'
  return api(servicename, methodname, params)
}

/** 保存処理(検診事業詳細画面) */
export const SaveKensinJigyoDetail = (
  params: SaveKensinJigyoDetailRequest
): Promise<SaveKensinJigyoDetailResponse> => {
  const methodname = 'SaveKensinJigyoDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理(検診項目一覧画面) */
export const InitKensinItemList = (
  params: InitKensinCommonRequest
): Promise<InitKensinItemListResponse> => {
  const methodname = 'InitKensinItemList'
  return api(servicename, methodname, params)
}

/** 初期化処理(検診項目詳細画面) */
export const InitKensinItemDetail = (
  params: InitKensinItemDetailRequest
): Promise<InitKensinItemDetailResponse> => {
  const methodname = 'InitKensinItemDetail'
  return api(servicename, methodname, params)
}

/** 保存処理(検診項目詳細画面) */
export const SaveKensinItemDetail = (
  params: SaveKensinItemDetailRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveKensinItemDetail'
  return api(servicename, methodname, params)
}

/** 削除処理(検診項目詳細画面) */
export const DeleteKensinItemDetail = (
  params: DeteleKensinItemDetailRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteKensinItemDetail'
  return api(servicename, methodname, params)
}

/** 条件コードリスト取得(項目詳細画面) */
export const GetCodejokenList = (
  params: GetCodejokenListRequest
): Promise<GetCodejokenListResponse> => {
  const methodname = 'GetCodejokenList'
  return api(servicename, methodname, params)
}

/** 初期化処理(指導項目一覧画面) */
export const InitSidoItemList = (): Promise<InitSidoItemListResponse> => {
  const methodname = 'InitSidoItemList'
  return api(servicename, methodname, {})
}

/** 検索処理(指導項目一覧画面) */
export const SearchSidoItemList = (
  params: SidoCommonRequest
): Promise<SearchSidoItemListResponse> => {
  const methodname = 'SearchSidoItemList'
  return api(servicename, methodname, params)
}

/** 初期化処理(指導項目詳細画面) */
export const InitSidoItemDetail = (
  params: InitSidoItemDetailRequest
): Promise<InitSidoItemDetailResponse> => {
  const methodname = 'InitSidoItemDetail'
  return api(servicename, methodname, params)
}

/** 保存処理(指導項目詳細画面) */
export const SaveSidoItemDetail = (params: SaveSidoItemDetailRequest): Promise<DaResponseBase> => {
  const methodname = 'SaveSidoItemDetail'
  return api(servicename, methodname, params)
}

/** 削除処理(指導項目詳細画面) */
export const DeleteSidoItemDetail = (
  params: DeteleSidoItemDetailRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteSidoItemDetail'
  return api(servicename, methodname, params)
}

/** 検索処理(検診予約事業一覧画面) */
export const SearchKensinYoyakuJigyoList = (
  params: KensinYoyakuJigyoListCommonRequest
): Promise<SearchKensinYoyakuJigyoListResponse> => {
  const methodname = 'SearchKensinYoyakuJigyoList'
  return api(servicename, methodname, params)
}

/** 引継ぎ処理(検診予約事業一覧画面) */
export const SaveKensinYoyakuJigyoList = (
  params: KensinYoyakuJigyoListCommonRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveKensinYoyakuJigyoList'
  return api(servicename, methodname, params)
}

/** 初期化処理(検診予約事業詳細画面) */
export const InitKensinYoyakuJigyoDetail = (
  params: InitKensinYoyakuJigyoDetailRequest
): Promise<InitKensinYoyakuJigyoDetailResponse> => {
  const methodname = 'InitKensinYoyakuJigyoDetail'
  return api(servicename, methodname, params)
}

/** 保存処理(検診予約事業詳細画面) */
export const SaveKensinYoyakuJigyoDetail = (
  params: SaveKensinYoyakuJigyoDetailRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveKensinYoyakuJigyoDetail'
  return api(servicename, methodname, params)
}

/** 削除処理(検診予約事業詳細画面) */
export const DeleteKensinYoyakuJigyoDetail = (
  params: DeleteKensinYoyakuJigyoDetailRequest
): Promise<DaResponseBase> => {
  const methodname = 'DeleteKensinYoyakuJigyoDetail'
  return api(servicename, methodname, params)
}

/** 初期化処理(その他予約事業一覧画面) */
export const InitYoyakuSidoJigyoList = (): Promise<InitYoyakuSidoJigyoListResponse> => {
  const methodname = 'InitYoyakuSidoJigyoList'
  return api(servicename, methodname, {})
}

/** 保存処理(その他予約事業一覧画面) */
export const SaveYoyakuSidoJigyoList = (
  params: SaveYoyakuSidoJigyoListRequest
): Promise<DaResponseBase> => {
  const methodname = 'SaveYoyakuSidoJigyoList'
  return api(servicename, methodname, params)
}
