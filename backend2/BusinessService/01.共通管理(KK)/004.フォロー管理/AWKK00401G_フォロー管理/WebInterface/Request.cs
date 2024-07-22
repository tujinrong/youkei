// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理
//             リクエストインターフェース
// 作成日　　: 2023.11.24
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00401G
{
    /// <summary>
    /// 検索処理(内容画面)
    /// </summary>
    public class SearchFollowNaiyoListRequest : DaRequestBase
    {
        public string atenano { get; set; }        //宛名番号
    }

    /// <summary>
    /// 初期化処理(結果画面)
    /// </summary>
    public class InitFollowNaiyoRequest : DaRequestBase
    {
        public string atenano { get; set; }                     //宛名番号
    }

    /// <summary>
    /// 検索処理(結果画面)
    /// </summary>
    public class SearchFollowNaiyoRequest : DaRequestBase
    {
        public string atenano { get; set; }                     //宛名番号
        public int follownaiyoedano { get; set; }               //フォロー内容枝番
    }

    /// <summary>
    /// 保存処理(結果画面)
    /// </summary>
    public class SaveFollowNaiyoRequest : DaRequestBase
    {
        public RowFollowKekkaVM rowfollowkekka { get; set; }            //フォロー予定結果情報
        public Enum編集区分 editkbn { get; set; }                       //編集区分
    }

    /// <summary>
    /// 削除処理(結果画面)
    /// </summary>
    public class DeleteFollowNaiyoRequest : DaRequestBase
    {
        public string atenano { get; set; }             //宛名番号
        public int follownaiyoedano { get; set; }       //フォロー内容枝番
        public DateTime upddttm { get; set; }           //更新日時
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitFollowDetailRequest : DaRequestBase
    {
        public string atenano { get; set; }                  //宛名番号
        public int follownaiyoedano { get; set; }            //フォロー内容枝番
        public bool copyflg { get; set; }                    //コピーフラグ
        public Enum編集区分 editkbn { get; set; }            //編集区分
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchFollowDetailRequest : DaRequestBase
    {
        public string atenano { get; set; }                  //宛名番号
        public int follownaiyoedano { get; set; }            //フォロー内容枝番
        public int edano { get; set; }                       //枝番
    }

    /// <summary>
    /// 検索処理予定情報(詳細画面)
    /// </summary>
    public class SearchFollowDetailPreKekkaRequest : DaRequestBase
    {
        public FollowDetailYoteiInfoVM detailyoteiinfovm { get; set; }   //フォロー予定情報(詳細画面)
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveFollowDetailRequest : DaRequestBase
    {
        public FollowDetailVM followdetailvm { get; set; }  //フォロー予定情報(詳細画面)
        public bool yoteiinputflg { get; set; }             //フォロー予定入力フラグ
        public bool kekkainputflg { get; set; }             //フォロー結果入力フラグ
        public Enum編集区分 editkbn { get; set; }           //編集区分
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteFollowDetailRequest : DaRequestBase
    {
        public string atenano { get; set; }             //宛名番号
        public int follownaiyoedano { get; set; }       //フォロー内容枝番
        public int edano { get; set; }                  //枝番
        public DateTime? upddttmyotei { get; set; }     //更新日時(排他用)  予定情報テーブル利用
        public DateTime? upddttmkekka { get; set; }     //更新日時(排他用)  結果情報テーブル利用
    }
}
