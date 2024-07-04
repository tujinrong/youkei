// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 拡張事業・拡張運用情報保守
//             リクエストインターフェース
// 作成日　　: 2023.12.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00801G
{
    /// <summary>
    /// 初期化処理(選択画面)
    /// </summary>
    public class InitChoiceRequest : DaRequestBase
    {
        public Enum名称区分 kbn1 { get; set; }   //名称区分(業務)
        public Enum名称区分 kbn2 { get; set; }   //名称区分(種類)
    }

    /// <summary>
    /// 初期化処理(検診画面共通)
    /// </summary>
    public class InitKensinCommonRequest : DaRequestBase
    {
        public string? jigyocd { get; set; } //成人健（検）診事業コード
    }

    /// <summary>
    /// 保存処理(検診事業詳細画面)
    /// </summary>
    public class SaveKensinJigyoDetailRequest : DaRequestBase
    {
        public string? jigyocd { get; set; } //成人健（検）診事業コード

        public DateTime? upddttm { get; set; }                      //更新日時(排他用)
        public Enum編集区分 editkbn { get; set; }                   //編集区分
        public string jigyonm { get; set; }                         //事業名
        public string jigyoshortnm { get; set; }                    //事業名略称
        public KensinDetailJigyoVM jigyoinfo { get; set; }          //検診事業情報(事業内容)
        public KensinDetailHohoSaveVM hohoinfo { get; set; }        //検診事業情報(検査方法)
        public KensinDetailYoyakuSaveVM yoyakuinfo { get; set; }    //検診事業情報(予約分類)
        public KensinDetailFreeSaveVM freeinfo { get; set; }        //検診事業情報(フリー項目)
        public KensinDetailErrorchkSaveVM errorchkinfo { get; set; }  //検診事業情報(エラーチェック)
    }
    /// <summary>
    /// 初期化処理(検診項目詳細画面)
    /// </summary>
    public class InitKensinItemDetailRequest : DaRequestBase
    {
        public string jigyocd { get; set; }         //成人健（検）診事業コード
        public string? itemcd { get; set; }         //項目コード
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool copyflg { get; set; }           //コピーフラグ(コピーの場合、true)
        public bool halfflg1 { get; set; }           //半角タイプ入力上限値フラグ（一次）
        public bool dayflg1 { get; set; }            //日付タイプ入力上限値フラグ（一次）
        public bool fullflg1 { get; set; }           //全角タイプ入力上限値フラグ（一次）
        public bool cdflg1 { get; set; }             //コードタイプ入力上限値フラグ（一次）
        public bool halfflg2 { get; set; }           //半角タイプ入力上限値フラグ（精密）
        public bool dayflg2 { get; set; }            //日付タイプ入力上限値フラグ（精密）
        public bool fullflg2 { get; set; }           //全角タイプ入力上限値フラグ（精密）
        public bool cdflg2 { get; set; }             //コードタイプ入力上限値フラグ（精密）
    }
    /// <summary>
    /// 条件コードリスト取得(検診項目詳細画面)
    /// </summary>
    public class GetCodejokenListRequest : DaRequestBase
    {
        public Enum入力タイプ inputtype { get; set; }   //入力タイプ
        public string? codejoken1 { get; set; }         //コード条件1
        public string? codejoken2 { get; set; }         //コード条件2
        public string? codejoken3 { get; set; }         //コード条件3
        public string? jigyocd { get; set; }            //成人健（検）診事業コード(検診の場合のみ)
        public string? group { get; set; }              //グループID(コード：名称)(検診の場合のみ)
    }
    /// <summary>
    /// 保存処理(検診項目詳細画面)
    /// </summary>
    public class SaveKensinItemDetailRequest : DaRequestBase
    {
        public string jigyocd { get; set; }                     //成人健（検）診事業コード
        public Enum編集区分 editkbn { get; set; }               //編集区分
        public KensinItemDetailSaveVM detailinfo { get; set; }  //検診項目詳細
        public DateTime? upddttm { get; set; }                  //更新日時(排他用)
    }
    /// <summary>
    /// 削除処理(検診項目詳細画面)
    /// </summary>
    public class DeteleKensinItemDetailRequest : DaRequestBase
    {
        public string jigyocd { get; set; }     //成人健（検）診事業コード
        public string itemcd { get; set; }      //項目コード
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
    /// <summary>
    /// 検索処理(指導項目一覧画面)
    /// </summary>
    public class SidoCommonRequest : DaRequestBase
    {
        public Enum指導区分 sidokbn { get; set; }           //指導区分
        public string gyomukbn { get; set; }                //業務区分
        public Enum申込結果 mosikomikekkakbn { get; set; }  //申込結果区分
        public Enum項目用途区分 itemyotokbn { get; set; }   //項目用途区分
    }
    /// <summary>
    /// 初期化処理(指導項目詳細画面)
    /// </summary>
    public class InitSidoItemDetailRequest : SidoCommonRequest
    {
        public string? itemcd { get; set; }         //項目コード
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool copyflg { get; set; }           //コピーフラグ(コピーの場合、true)
        public bool halfflg { get; set; }           //半角タイプ入力上限値フラグ
        public bool dayflg { get; set; }            //日付タイプ入力上限値フラグ
        public bool fullflg { get; set; }           //全角タイプ入力上限値フラグ
        public bool cdflg { get; set; }             //コードタイプ入力上限値フラグ
    }
    /// <summary>
    /// 保存処理(指導項目詳細画面)
    /// </summary>
    public class SaveSidoItemDetailRequest : SidoCommonRequest
    {
        public string itemcd { get; set; }                  //項目コード
        public Enum編集区分 editkbn { get; set; }           //編集区分
        public SidoItemDetailVM detailinfo { get; set; }    //指導項目詳細
        public DateTime? upddttm { get; set; }              //更新日時(排他用)

    }
    /// <summary>
    /// 削除処理(指導項目詳細画面)
    /// </summary>
    public class DeteleSidoItemDetailRequest : SidoCommonRequest
    {
        public string itemcd { get; set; }      //項目コード
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
    /// <summary>
    /// 検索処理/引継ぎ処理(検診予約事業一覧画面)
    /// </summary>
    public class KensinYoyakuJigyoListCommonRequest : DaRequestBase
    {
        public int nendo { get; set; }  //年度
    }
    /// <summary>
    /// 初期化処理(検診予約事業詳細画面)
    /// </summary>
    public class InitKensinYoyakuJigyoDetailRequest : KensinYoyakuJigyoListCommonRequest
    {
        public string? jigyocd { get; set; }        //検診予約事業コード
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }
    /// <summary>
    /// 保存処理(検診予約事業詳細画面)
    /// </summary>
    public class SaveKensinYoyakuJigyoDetailRequest : InitKensinYoyakuJigyoDetailRequest
    {
        public KensinYoyakuDetailMainSaveVM maininfo { get; set; }          //メイン情報
        public List<KensinYoyakuDetailRowSaveVM> kekkalist { get; set; }    //検査方法一覧
        public bool chkflg { get; set; }                                    //チェック用フラグ
    }
    /// <summary>
    /// 削除処理(検診予約事業詳細画面)
    /// </summary>
    public class DeleteKensinYoyakuJigyoDetailRequest : KensinYoyakuJigyoListCommonRequest
    {
        public string jigyocd { get; set; }     //検診予約事業コード
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
    /// <summary>
    /// 保存処理(その他予約事業一覧画面)
    /// </summary>
    public class SaveYoyakuSidoJigyoListRequest : DaRequestBase
    {
        public List<YoyakuSidoJigyoRowSaveVM> kekkalist { get; set; }   //その他予約事業一覧
        public List<YoyakuSidoJigyoLockVM> locklist { get; set; }       //排他チェック用リスト
    }
}