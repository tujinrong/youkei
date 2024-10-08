/** ----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　:互助基金契約者マスタ
 * 　　　　　  インターフェース定義
 * 作成日　　: 2024.08.27
 * 作成者　　:魏星
 * 変更履歴　:
 * -----------------------------------------------------------------*/

//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
export interface InitDetailRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**金融機関コード */
  FURI_BANK_CD: string
}

export interface SearchDetailRequest extends DaRequestBase {
  /**期 */
  KI: number
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
}
export interface SaveRequest extends DaRequestBase {
  /**契約者情報 */
  KEIYAKUSYA: DetailVM
}

export interface DeleteRequest extends DaRequestBase {
  /**期 */
  KI: number | undefined
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**事務委託先番号(変更前) */
  OLD_JIMUITAKU_CD: number | undefined
  /**データ更新日 */
  UP_DATE: Date | undefined
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
export interface InitDetailResponse extends DaResponseBase {
  /**都道府県情報プルダウンリスト */
  KEN_LIST: CmCodeNameModel[]
  /**契約区分情報プルダウンリスト */
  KEIYAKU_KBN_LIST: CmCodeNameModel[]
  /**契約状況情報プルダウンリスト */
  KEIYAKU_JYOKYO_LIST: CmCodeNameModel[]
  /**事務委託先情報プルダウンリスト */
  JIMUITAKU_LIST: CmCodeNameModel[]
  /**金融機関情報プルダウンリスト */
  BANK_LIST: CmCodeNameModel[]
  /**本支店情報プルダウンリスト */
  SITEN_LIST: CmCodeNameModel[]
  /**口座種別情報プルダウンリスト */
  KOZA_SYUBETU_LIST: CmCodeNameModel[]
}

export interface SearchDetailResponse extends DaResponseBase {
  /**契約者情報 */
  KEIYAKUSYA: DetailVM
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
export interface DetailVM {
  /**期 */
  KI: number | undefined
  /**契約者番号 */
  KEIYAKUSYA_CD: number | undefined
  /**経営安定対策事業生産者番号 */
  SEISANSYA_CD: number | undefined
  /**都道府県 */
  KEN_CD: number | undefined
  /**日鶏協番号 */
  NIKKEIKYO_CD: number | undefined
  /**契約区分 */
  KEIYAKU_KBN: number | undefined
  /**契約日 */
  KEIYAKU_DATE: Date | undefined
  /**契約状況 */
  KEIYAKU_JYOKYO: number | undefined
  /**入金日、返還日 */
  NYU_HEN_DATE: Date | undefined
  /**申込者名(ﾌﾘｶﾞﾅ) */
  KEIYAKUSYA_KANA: string
  /**申込者名(個人・団体) */
  KEIYAKUSYA_NAME: string
  /**代表者名(団体) */
  DAIHYO_NAME: string
  /**住所（郵便番号） */
  ADDR_POST: string
  /**住所（住所1） */
  ADDR_1: string
  /**住所2 */
  ADDR_2: string
  /**住所（住所3） */
  ADDR_3: string
  /**住所（住所4） */
  ADDR_4: string
  /**連絡先（電話） */
  ADDR_TEL1: string
  /**連絡先（電話2） */
  ADDR_TEL2: string
  /**連絡先（FAX） */
  ADDR_FAX: string
  /**メールアドレス */
  ADDR_E_MAIL: string
  /**事務委託先番号(変更前) */
  OLD_JIMUITAKU_CD: number | undefined
  /**事務委託先番号 */
  JIMUITAKU_CD: number | undefined
  /**金融機関コード */
  FURI_BANK_CD: string
  /**本支店コード */
  FURI_BANK_SITEN_CD: string
  /**口座種別コード */
  FURI_KOZA_SYUBETU: number | undefined
  /**口座番号 */
  FURI_KOZA_NO: string
  /**口座名義人（カナ） */
  FURI_KOZA_MEIGI_KANA: string
  /**口座名義人（漢字） */
  FURI_KOZA_MEIGI: string
  /**入力確認有無(入力状況) */
  NYURYOKU_JYOKYO: number | undefined
  /**備考 */
  BIKO: string
  /**廃業日 */
  HAIGYO_DATE: Date | undefined
  /**データ更新日 */
  UP_DATE: Date | undefined
}
