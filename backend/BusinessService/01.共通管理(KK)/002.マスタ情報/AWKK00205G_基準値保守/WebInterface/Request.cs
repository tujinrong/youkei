// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基準値保守
//             リクエストインターフェース
// 作成日　　: 2023.01.16
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00205G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string gyomukbn { get; set; }     　 //業務
        public string kijunjigyo { get; set; }      //事業（基準値事業コード）
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public string gyomukbn { get; set; }     　 //業務（コード）
        public string kijunjigyocd { get; set; }    //事業（基準値事業コード）コード
        public string? itemcd { get; set; }         //項目（コード）
        public int? edano { get; set; }             //枝番
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// フリー項目マスタ情報取得処理(詳細画面)
    /// </summary>
    public class GetFreeMstInfoRequest : DaRequestBase
    {
        public string gyomukbncd { get; set; }      //業務（コード）
        public string kijunjigyocd { get; set; }    //事業（基準値事業コード）コード
        public string itemcd { get; set; }          //項目コード
        public int edano { get; set; }              //枝番
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : InitDetailRequest
    {
        public SaveMainVM saveinfo { get; set; }   //保存情報
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string gyomukbn { get; set; }           //業務
        public string kijunjigyocd { get; set; }       //事業
        public string itemcd { get; set; }             //項目コード
        public int edano { get; set; }                 //枝番
        public DateTime upddttm { get; set; } 　　　　 //更新日時
    }
}