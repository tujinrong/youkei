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
export interface InitBankDetailRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
}

/**保存処理(詳細画面) */
export interface SaveBankRequest extends DaRequestBase {
  /**金融機関情報 */
  BANK: BankDetailVM
}

/**削除処理(詳細画面) */
export interface DeleteBankRequest extends DaRequestBase {
  /**金融機関コード */
  BANK_CD?: string
  /**データ更新日 */
  UP_DATE?: Date
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/**初期化処理(詳細画面) */
export interface InitBankDetailResponse extends DaResponseBase {
  /**金融機関情報 */
  BANK: BankDetailVM
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface BankDetailVM {
  /**金融機関コード */
  BANK_CD: string
  /**金融機関名（ｶﾅ） */
  BANK_KANA?: string
  /**金融機関名（漢字） */
  BANK_NAME?: string
  /**データ更新日 */
  UP_DATE?: Date
}
