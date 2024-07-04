//-------------------------------------------------------------------
//リクエスト
//-------------------------------------------------------------------
/** 費用助成一覧画面検索処理 */
export interface SearchJyoseiListRequest extends CmSearchRequestBase {
  /** 母子詳細メニューコード */
  bosikbn: string
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 申請枝番 */
  sinseiedano: number
  /** 宛名番号 */
  atenano: string
  /** 登録番号 */
  torokuno: number
}
/** 費用助成一覧キー項目 */
export interface JyoseiKeyRequest extends CmSaveRequestBase {
  /** 母子詳細メニューコード */
  bosikbn: string
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 申請枝番 */
  sinseiedano: number
  /** 宛名番号 */
  atenano: string
  /** 登録番号 */
  torokuno: string
}
/** 保存処理（費用助成一覧） */
export interface SaveJyoseiRequest extends JyoseiKeyRequest {
  /** 費用助成一覧情報 */
  jyoseilistinfo: JyoseiListInfoVM[]
}
/** 削除処理（費用助成一覧） */
export interface DeleteJyoseiRequest extends JyoseiKeyRequest {
  /** 機能ID */
  kinoid: string
}
/** 初期化処理 */
export interface InitListRequest extends CmSearchRequestBase {
  /** 母子種類 */
  bosikbn: string
  /** 母子詳細メニューコード */
  bhsyosaimenyucd: string
  /** 母子詳細タブコード */
  bhsyosaitabcd: string
  /** 申請枝番 */
  sinseiedano: number
}
//-------------------------------------------------------------------
//レスポンス
//-------------------------------------------------------------------
/** 費用助成一覧画面検索処理 */
export interface SearchJyoseiListResponse extends CmSearchResponseBase {
  /** 費用助成情報（ヘッダー情報） */
  headerinfo: JyoseiHeaderInfoVM
  /** 費用助成一覧 */
  jyoseilist: JyoseiListInfoVM[]
  /** 費用助成情報（フッター情報） */
  footerinfo: JyoseiFooterInfoVM
}
/** 保存(費用助成一覧)/10.削除(費用助成一覧) */
export interface CommonResponse extends DaResponseBase {
  /** 機能ID */
  kinoid: string
}
/** 初期化処理 */
export interface InitListResponse extends DaResponseBase {
  /** ドロップダウンリスト(助成券種類リスト) */
  kensyuruilist: DaSelectorModel[]
  /** ドロップダウンリスト(助成上限額リスト) */
  kingakulimitlist: DaSelectorModel[]
}
//-------------------------------------------------------------------
//ビューモデル
//-------------------------------------------------------------------
/** 費用助成ヘッダー部分情報 */
export interface JyoseiHeaderInfoVM {
  /** 宛名番号 */
  atenano: string
  /** 氏名 */
  name: string
  /** 登録番号 */
  torokuno: string
  /** 申請日 */
  sinseiymd: string
}
/** 費用助成一覧（表示用） */
export interface JyoseiListInfoVM {
  /** No. */
  no: string
  /** 助成券種類 */
  joseikensyurui: string
  /** 受診年月日 */
  jusinymd: string
  /** 支払金額 */
  siharaikingaku: number
  /** 助成金額 */
  joseikingaku: number
  /** 助成金額（限度額）*/
  joseikingakulimit: number
}
/** 費用助成フッター情報 */
export interface JyoseiFooterInfoVM {
  /** 助成金額（総額） */
  joseikingakusogaku: number
}
