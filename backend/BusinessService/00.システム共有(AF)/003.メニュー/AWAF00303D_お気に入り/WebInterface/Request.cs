// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お気に入り
//             リクエストインターフェース
// 作成日　　: 2023.01.23
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00303D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string kinoid { get; set; }   //機能ID
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public class UpdateRequest : InitRequest
    {
        public Enum更新区分 updkbn { get; set; }    //更新区分
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public List<string> kinoids { get; set; }    //機能IDリスト
    }
}