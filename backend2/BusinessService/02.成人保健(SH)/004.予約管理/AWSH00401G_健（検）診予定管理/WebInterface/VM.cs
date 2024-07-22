// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予定管理
//             ViewModel定義
// 作成日　　: 2024.02.19
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00401G
{
    /// <summary>
    /// 予定メイン情報(表示用)
    /// </summary>
    public class DetailVM : DetailSaveVM
    {
        public string regsisyonm { get; set; }      //登録支所名称
    }

    /// <summary>
    /// 予定メイン情報(保存用)
    /// </summary>
    public class DetailSaveVM
    {
        public string jigyocdnm { get; set; }       //成人健（検）診予約日程事業(コード：名称)
        public string yoteiymd { get; set; }        //実施予定日
        public string timef { get; set; }           //開始時間
        public string timet { get; set; }           //終了時間
        public string kaijocdnm { get; set; }       //会場(コード：名称)
        public string kikancdnm { get; set; }       //医療機関(コード：名称)
        public List<string> staffids { get; set; }  //担当者一覧
        public int? teiin { get; set; }             //定員
    }

    /// <summary>
    /// 予定定員情報(表示用)
    /// </summary>
    public class RowVM : RowSaveVM
    {
        public string yoyakubunruinm { get; set; }  //予約分類名称
    }
    /// <summary>
    /// 予定定員情報(保存用)
    /// </summary>
    public class RowSaveVM : RowKeyVM
    {
        public int? teiin_kensin { get; set; }      //定員(検診)
    }
    /// <summary>
    /// 予定定員情報(制御用)
    /// </summary>
    public class RowKeyVM
    {
        public string jigyocd { get; set; }         //検診種別
        public string yoyakubunruicd { get; set; }  //予約分類コード
    }
}