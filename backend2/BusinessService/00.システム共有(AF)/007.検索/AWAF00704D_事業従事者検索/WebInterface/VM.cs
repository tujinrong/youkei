// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者検索
// 　　　　　　ビューモデル定義
// 作成日　　: 2023.10.20
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00704D
{
    /// <summary>
    /// 事業従事者（担当者）情報モデル
    /// </summary>
    public class SearchVM
    {
        public string staffid { get; set; }           //事業従事者ID
        public string staffsimei { get; set; }        //事業従事者氏名
        public string kanastaffsimei { get; set; }    //事業従事者カナ氏名
        public string syokusyunm { get; set; }        //職種
        public string katudokbnnm { get; set; }       //活動区分
    }
}
