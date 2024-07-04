/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 連絡先
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.08.31
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchRequest extends DaRequestBase {
  /** 宛名番号 */
  atenano: string
  /** パターンNo.(ドロップダウンリストコード)  */
  patternno?: string
}
/** 保存処理 */
export interface SaveRequest extends DaRequestBase {
  /** 連絡先情報 */
  detailinfo: SaveVM
}
/** 削除処理 */
export interface DeleteRequest extends DaRequestBase {
  /** 利用事業(コード：名称) */
  jigyo: string
  /** 宛名番号 */
  atenano: string
  /** 更新日時 */
  upddttm: Date | string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 検索処理 */
export interface SearchResponse extends DaResponseBase {
  /** 連絡先情報一覧 */
  kekkalist: SearchVM[]
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 連絡先情報(1件) */
export interface SearchVM {
  /** タブ名 */
  tabnm: string
  /** 個人基本情報 */
  headerinfo: CommonBarHeaderBaseVM
  /** 連絡先情報 */
  detailinfo?: SaveVM
  /** 更新権限フラグ */
  updflg: boolean
}
/** 連絡先情報(保存用) */
export interface SaveVM {
  /** 利用事業(コード：名称) */
  jigyo: string
  /** 宛名番号 */
  atenano: string
  /** 電話番号 */
  tel: string
  /** 携帯番号 */
  keitaitel: string
  /** E-mailアドレス */
  emailadrs: string
  /** E-mailアドレス2 */
  emailadrs2: string
  /** 連絡先詳細 */
  syosai: string
  /** 更新日時 */
  upddttm?: Date | string
  /** 登録支所名 */
  regsisyonm: string
}
