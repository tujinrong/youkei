/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 取込設定
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.09.15
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { ItemMappingVM } from '../AWKK00601G/type'
import { Enum編集区分 } from '#/Enums'
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 初期化処理(取込設定：マッピング設定情報ダイアログ画面) */
export interface InitRequest extends DaRequestBase {
  /** マッピング区分（【マッピング方法ド】ロップダウン初期化時用） */
  mappingkbn: string
  /** 取込ファイルIF情報のファイル項目ID+項目名のリスト */
  fileitemList: any[]
  /** 編集区分 */
  editkbn: Enum編集区分
}

/** 【マッピング方法】初期化処理 */
export interface InitMappingMethodRequest extends DaRequestBase {
  /** マッピング区分） */
  mappingkbn: string
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(取込設定：マッピング設定情報ダイアログ画面) */
export interface InitResponse extends DaResponseBase {
  /** マッピング設定明細情報 */
  detailData: ItemMappingVM
  /** 【マッピング区分】のドロップダウンリスト */
  mappingkbnList: DaSelectorModel[]
  /** 【マッピング方法】のドロップダウンリスト */
  mappingmethodList: DaSelectorKeyModel[]
  /** 【ファイル項目】のドロップダウンリスト */
  fileitemseqList: DaSelectorModel[]
  /** 【引数区分】のドロップダウンリスト */
  hikisukbnList: DaSelectorModel[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 【マッピング方法】初期化処理 */
export interface InitMappingMethodResponse extends DaResponseBase {
  /** 【マッピング区分】のドロップダウンリスト */
  mappingmethodList: DaSelectorKeyModel[]
}
