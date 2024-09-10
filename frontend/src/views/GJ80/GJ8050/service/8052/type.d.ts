/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約者農場マスタメンテナンス
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.20
 * 作成者　　: 高 弘昆
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { EnumAndOr } from '@/enum'

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/**初期化処理(詳細画面) */
export interface InitSitenDetailRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
}

/**保存処理(詳細画面) */
export interface SaveSitenRequest extends DaRequestBase {
  /**金融機関情報 */
  SITEN: SitenDetailVM
}

/**削除処理(詳細画面) */
export interface DeleteSitenRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**支店コード */
  SITEN_CD?: string
  /**データ更新日 */
  UP_DATE?: Date
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/**初期化処理(詳細画面) */
export interface InitSitenDetailResponse extends DaResponseBase {
  /**金融機関情報 */
  SITEN: SitenDetailVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface SitenDetailVM {
  /**金融機関コード */
  BANK_CD: string
  /**支店コード */
  SITEN_CD: string
  /**支店名（ｶﾅ） */
  SITEN_KANA?: string
  /**支店名（漢字） */
  SITEN_NAME?: string
  /**データ更新日 */
  UP_DATE?: Date
}
