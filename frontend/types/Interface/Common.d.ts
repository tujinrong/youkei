/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 共通ロジック
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.07.26
 * 作成者　　: 劉
 * 変更履歴　:
 * -----------------------------------------------------------------*/
//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------

/** 検索処理(一覧画面：受診者を探す場合) */
interface PersonSearchRequest extends CmSearchRequestBase {
  /** 宛名番号 */
  atenano?: string
  /** 氏名 */
  name?: string
  /** カナ氏名 */
  kname?: string
  /** 生年月日 */
  bymd?: string
  /** 個人番号 */
  personalno?: string
  /** 詳細条件(検索) */
  syosailist?: import('@/views/affect/AF/AWAF00703D/type').SearchVM[]
}

//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 初期化処理(パスワードポリシー) */
interface CmPwdInitResponse extends DaResponseBase {
  /** パスワードポリシー設定フラグ */
  pwdflg: boolean
  /** 半角数字フラグ */
  numflg: boolean
  /** 半角英字フラグ */
  enflg: boolean
  /** 半角記号フラグ */
  symbolflg: boolean
  /** 使用可能記号 */
  symbolstr: string
  /** 最大文字数 */
  maxlen?: number
}

//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 支所モデル */
interface CmSisyoVM {
  /** 支所コード */
  sisyocd: string
  /** 支所名 */
  sisyonm: string
}
/** ヘッダー基本情報 */
interface CmHeaderBaseVM {
  /** 氏名 */
  name: string
  /** カナ氏名 */
  kname: string
  /** 性別 */
  sex: string
  /** 住民区分 */
  juminkbn: string
  /** 生年月日 */
  bymd: string
}
/** 共通バー共通基本情報 */
interface CommonBarHeaderBaseVM extends CmHeaderBaseVM {
  /** 年齢 */
  age: string
  /** 年齡計算基準日 */
  agekijunymd: Date | string
}
/** 共通バー共通基本情報 */
interface CommonBarHeaderBase2VM extends CommonBarHeaderBaseVM {
  /** 警告内容 */
  keikoku: string
}
/** 共通バー共通基本情報 */
interface CommonBarHeaderBase3VM extends CommonBarHeaderBase2VM {
  /** 住所 */
  adrs: string
}
/** 画面共通基本情報 */
interface GamenHeaderBaseVM extends CommonBarHeaderBaseVM {
  /** 個人番号 */
  personalno: string
}
/** 画面共通基本情報 */
interface GamenHeaderBase2VM extends GamenHeaderBaseVM {
  /** 住所 */
  adrs: string
  /** 警告内容 */
  keikoku: string
}
/** 基準値範囲 */
interface KjItemVM {
  /** 項目コード */
  itemcd: string
  /** 基準値表記 */
  kijunvaluehyoki: string
  /** 注意値表記 */
  alertvaluehyoki: string
  /** 異常値表記 */
  errvaluehyoki: string
  /** 基準値リスト */
  kijunlist: KijunVM[]
}
/** 基準値(チェック用) */
interface KijunVM {
  /** 異常値（数値）以下 */
  errvalue1t: number | null
  /** 注意値（数値）開始 */
  alertvalue1f: number | null
  /** 注意値（数値）終了 */
  alertvalue1t: number | null
  /** 基準値（数値）開始 */
  kijunvaluef: number | null
  /** 基準値（数値）終了 */
  kijunvaluet: number | null
  /** 注意値（数値）開始 */
  alertvalue2f: number | null
  /** 注意値（数値）終了 */
  alertvalue2t: number | null
  /** 異常値（数値）以上 */
  errvalue2f: number | null
  /** 基準値（コード） */
  hanteicd: string
  /** 注意値（コード） */
  alerthanteicd: string
  /** 異常値（コード） */
  errhanteicd: string
}
/** フリー項目モデル(初期化)：フリー */
interface FreeItemBaseVM extends FixFreeItemBaseVM {
  /** グループID2 */
  groupid2: string
  /** 拡張(フロントエンド) */
  kijun?: KjItemVM
}
/** フリー項目モデル(初期化)：固定 */
interface FixFreeItemBaseVM extends FreeItemUpdBaseVM {
  /** 項目名 */
  itemnm: string
  /** 画面項目入力区分 */
  inputkbn: import('#/Enums').Enum画面項目入力
  /** 一覧選択リスト */
  cdlist: DaSelectorModel[]
  /** 入力桁(整数部/文字) */
  keta1?: number
  /** 入力桁(小数部) */
  keta2?: number
  /** 必須フラグ */
  hissuflg: boolean
  /** 入力範囲（開始） */
  hanif: string
  /** 入力範囲（終了） */
  hanit: string
  /** 入力フラグ */
  inputflg: boolean
  /** メッセージ区分 */
  msgkbn: import('#/Enums').EnumMsgCtrlKbn
  /** 初期値 */
  syokiti: any
  /** 備考 */
  biko: string
  /** 警告表示フラグ(フロントエンド) */
  warntextflg?: boolean
}

/** フリー項目モデル(更新) */
interface FreeItemUpdBaseVM {
  /** 項目コード */
  itemcd: string
  /** 値 */
  value?: any
  /** 不詳フラグ */
  fusyoflg: boolean | null
  /** 入力タイプ区分 */
  inputtypekbn: import('#/Enums').Enum入力タイプ
}

/** 一覧列情報 */
interface ColumnInfoVM {
  /** 項目論理名 */
  title: string
  /** 項目物理名 */
  key: string
}

/** 一覧データ */
interface DataInfoVM {
  /** 項目物理名 */
  key: string
  /** 値 */
  value: string
}

/** 詳細条件(初期化) */
interface CommonFilterVM {
  /** ユニークキー */
  id: string //front
  /** 条件区分 */
  jyokbn: import('#/Enums').Enum詳細検索条件区分
  /** 条件シーケンス */
  jyoseq: number
  /** 詳細条件表示名 */
  hyojinm: string
  /** 入力説明 */
  placeholder: string
  /** コントローラータイプ */
  ctrltype: import('#/Enums').Enumコントローラータイプ
  /** 通用項目区分 */
  itemkbn: import('#/Enums').Enum項目区分
  /** 範囲フラグ */
  rangeflg: boolean
  /** 男性 */
  manflg: boolean
  /** 女性 */
  womanflg: boolean
  /** 両方 */
  bothflg: boolean
  /** 不明 */
  unknownflg: boolean
  /** 一覧選択リスト */
  cdlist: DaSelectorModel[]
  /** 参照ダイアログ項目区分 */
  searchitemkbn: import('#/Enums').Enum参照ダイアログ項目区分
}
