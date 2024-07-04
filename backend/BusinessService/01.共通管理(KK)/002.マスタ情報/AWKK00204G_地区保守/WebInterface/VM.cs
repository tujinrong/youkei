// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 地区保守
//             ビューモデル定義
// 作成日　　: 2023.09.22
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00204G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM : MainInfoVM
    {
        public string tikukbn { get; set; }     //地区区分(コード)
        public string staffnm { get; set; }     //地区担当者(「,」区切り)
        public string stopflg { get; set; }     //停止状態
        public string tikukbnnm { get; set; }   //地区区分(名称)
    }

    /// <summary>
    /// 地区情報(メイン：ベース)
    /// </summary>
    public class MainInfoVM
    {
        public string tikucd { get; set; }      //地区コード
        public string tikunm { get; set; }      //地区名
        public string kanatikunm { get; set; }  //地区名(カナ)
    }

    /// <summary>
    /// 地区情報(メイン：保存用)
    /// </summary>
    public class SaveMainVM : MainInfoVM
    {
        public string tikukbn { get; set; }     //地区区分(コード：名称)
        public bool stopflg { get; set; }       //使用停止フラグ
        public DateTime? upddttm { get; set; }  //更新日時(排他用)
    }

    /// <summary>
    /// 地区担当者情報(サブ)
    /// </summary>
    public class SubInfoVM
    {
        public string staffid { get; set; }         //事業従事者ID
        public string staffsimei { get; set; }      //事業従事者氏名
        public string kanastaffsimei { get; set; }  //事業従事者カナ氏名
        public string syokusyu { get; set; }        //職種
        public string katudokbn { get; set; }       //活動区分
    }
}