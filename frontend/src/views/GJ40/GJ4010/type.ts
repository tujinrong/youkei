/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 互助金申請情報一覧
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.09.10
 * 作成者　　: 阎格
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

import {EnumAndOr} from "@/enum";

/** 処理 */
export interface SaveRequest extends DaRequestBase {
  /** */
  KEKKA: GJ4011DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------

/** 情報 */
export interface SearchVM {
  /** 互助金単価マスタ　参照日 */
  TANKA_MST_DATE: number | undefined
  /** 対象期 */
  KI: number | undefined
  /** 認定回数 */
  HASSEI_KAISU: FmToModel
  /** 計算回数 */
  KEISAN_KAISU: FmToModel
  /** 都道府県 */
  KEN_CD: FmToModel
  /** 契約者番号 */
  KEIYASYA_CD: number | undefined
  /** 契約区分 */
  KEIYAKU_KBN: number | undefined
  /** 契約状況 */
  KEIYAKU_JYOKYO: number | undefined
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** 契約者名（ﾌﾘｶﾞﾅ） */
  KEIYAKUSYA_KANA: string
  /** 住所 */
  ADDR: string
  /** 電話番号 */
  ADDR_TEL: string
  /** 事務委託先 */
  JIMUITAKU_CD: FmToModel
  /** 検索方法 */
  SEARCH_METHOD: EnumAndOr
}

/**検索処理(一覧画面) */
export interface SearchRequest {
  /** 契約者番号 */
  KEIYASYA_CD: number | undefined
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** 住所 */
  ADDR: string
  /** 契約区分コード */
  KEIYAKU_KBN: number | undefined
  /** 契約区分名 */
  KEIYAKU_KBN_NAME: string
  /** 電話番号 */
  ADDR_TEL1: string
  /** 都道府県コード */
  KEN_CD: number | undefined
  /** 都道府県コード名 */
  KEN_CD_NAME: string
  /** 事務委託先番号 */
  JIMUITAKU_CD: number | undefined
  /** 事務委託先名（略称） */
  ITAKU_RYAKU: string
}

/** GJ4011初期化情報 */
export interface GJ4011SearchVM {
  /** 契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /** 契約者名 */
  KEIYAKUSYA_NAME: string
  /** 認定回数 */
  HASSEI_KAISU: number | undefined
  /** 申請日 */
  SINSEI_DATE: Date | undefined

}

/**契約農場別明細情報（交付情報）（表示） */
export interface SearchRowVM {
  /** 農場コード */
  NOJO_CD: number | undefined
  /** 明細番号 */
  MEISAI_NO: number | undefined
  /** 農場名 */
  NOJO_NAME: string
  /** 農場住所 */
  ADDR: string
  /** 契約区分コード */
  KEIYAKU_KBN: number | undefined
  /** 鳥の種類コード */
  TORI_KBN: string
  /** 鳥の種類名 */
  TORI_KBN_NAME: string
  /** 計算回数 */
  KEISAN_KAISU: number | undefined
  /** 処理状況コード */
  SYORI_JOKYO_KBN: number | undefined
  /** 処理状況名 */
  SYORI_JOKYO_KBN_NAME: string
  /** 互助金対象羽数 */
  KOFU_HASU: number | undefined
  /** 減額率（%） */
  GENGAKU_RITU: number | undefined
  /** 経営支援互助金額 */
  KOFU_KIN: number | undefined
}

/**契約農場別明細情報（交付情報）（表示） */
export interface GJ4011DetailVM {
  /** 契約区分コード */
  KEIYAKU_KBN: number | undefined
  /** 農場コード */
  NOJO_CD: number | undefined
  /** 郵便番号 */
  ADDR_POST: string
  /** 住所1 */
  ADDR_1: string
  /** 住所2 */
  ADDR_2: string
  /** 住所3 */
  ADDR_3: string
  /** 住所4 */
  ADDR_4: string
  /** 鶏の種類コード */
  TORI_KBN: string
  /** 契約羽数 */
  KEIYAKU_HASU: number | undefined
  /** 互助金交付対象羽数 */
  KOFU_HASU: number | undefined
  /** 互助金交付率 */
  KOFU_RITU: number | undefined
  /** 家伝法違反減額率 */
  GENGAKU_RITU: number | undefined
  /** 経営支援互助金交付額 */
  KOFU_KIN: number | undefined
  /** 積立金交付額 */
  SEI_TUMITATE_KIN: number | undefined
  /** 国庫交付額 */
  KUNI_KOFU_KIN: number | undefined
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface FmToModel {
  VALUE_FM: number | undefined
  VALUE_TO: number | undefined
}

export interface CmDateFmToModel {
  VALUE_FM: Date | undefined
  VALUE_TO: Date | undefined
}
