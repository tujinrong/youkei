// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健事業マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkkjigyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhkkjigyo";
		public string bosikbn { get; set; }                       //母子区分
		public string jigyocd { get; set; }                       //母子保健事業コード
		public string kihonkakutyokbn { get; set; }               //基本／拡張事業区分
		public string bhkanripatterncd { get; set; }              //母子保健管理パターンコード
		public bool rirekiflg { get; set; }                       //履歴管理フラグ
		public bool tataiflg { get; set; }                        //多胎管理フラグ
		public bool kaisuflg { get; set; }                        //回数管理フラグ
		public int kaisu { get; set; }                            //最大回数
		public string nykensincd { get; set; }                    //乳幼児健診コード
		public string? groupid_maincd { get; set; }               //フリー項目グループ左設定メインコード
		public int? groupid_subcd { get; set; }                   //フリー項目グループ左設定サブコード
		public string? groupid2_maincd { get; set; }              //フリー項目グループ右設定メインコード
		public int? groupid2_subcd { get; set; }                  //フリー項目グループ右設定サブコード
    }
}
