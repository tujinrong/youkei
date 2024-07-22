// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予約希望者管理
//             リクエストインターフェース
// 作成日　　: 2024.02.19
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00402G
{
    /// <summary>
    /// 検索処理(日程一覧画面)
    /// </summary>
    public class SearchListRequest : AWSH00401G.SearchListRequest
    {
        public string? atenano { get; set; }                //宛名番号
        public override string? personalno { get; set; }    //個人番号
    }
    /// <summary>
    /// 初期化処理(予約者一覧画面)
    /// </summary>
    public class InitPersonListRequest : DaRequestBase
    {
        public int nendo { get; set; }      //年度
        public int nitteino { get; set; }   //日程番号
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public int nendo { get; set; }              //年度
        public int nitteino { get; set; }           //日程番号
        public string atenano { get; set; }         //宛名番号
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// 計算処理
    /// </summary>
    public class CalculateRequest : DaRequestBase
    {
        public int nendo { get; set; }                          //年度
        public string atenano { get; set; }                     //宛名番号
        public List<AWSH00403D.MoneyKeyBase2VM> kekkalist { get; set; }    //予約情報一覧
    }

    /// <summary>
    /// 定員チェック処理(詳細画面)
    /// </summary>
    public class CheckTeiinRequest : InitDetailRequest
    {
        public List<DetailRowKeyVM> kekkalist { get; set; } //予約情報一覧(日程番号が画面のデータのみ)
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : InitDetailRequest
    {
        public string biko { get; set; }                        //備考
        public List<DetailRowSaveVM> kekkalist { get; set; }    //予約情報一覧(日程番号があるデータのみ)
        public DateTime? upddttm { get; set; }                  //更新日時(排他用)
    }
    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public int nendo { get; set; }          //年度
        public int nitteino { get; set; }       //日程番号
        public string atenano { get; set; }     //宛名番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
}