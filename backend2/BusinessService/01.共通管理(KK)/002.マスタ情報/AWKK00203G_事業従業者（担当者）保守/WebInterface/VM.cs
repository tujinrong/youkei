// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者（担当者）保守
//             ビューモデル定義
// 作成日　　: 2023.12.4
// 作成者　　: 誠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00203G
{
    /// <summary>
    /// 事業従業者（担当者）情報モデル(一覧画面)
    /// </summary>
    public class StaffRowVM
    {
        public string staffid { get; set; }             //事業従業者ID
        public string staffsimei { get; set; }          //事業従事者氏名
        public string kanastaffsimei { get; set; }      //事業従事者カナ氏名
        public string syokusyunm { get; set; }          //職種
        public string katudokbnnm { get; set; }         //活動区分
        public string stopflg { get; set; }               //停止状態

    }
    /// <summary>
    /// 事業従業者（担当者）情報モデル(メイン)
    /// </summary>
    public class MainInfoVM
    {
        public string staffid { get; set; }             //事業従業者ID
        public string staffsimei { get; set; }          //事業従事者名
        public string kanastaffsimei { get; set; }      //事業従事者カナ氏名
        public bool stopflg { get; set; }               //使用（利用）停止フラグ
        public string syokusyu { get; set; }            //職種
        public string katudokbn { get; set; }           //活動区分
    }

    /// <summary>
    /// 実施事業モデル
    /// </summary>
    public class JissijigyoModel
    {
        public string jissijigyo { get; set; }          //実施事業コード
        public string jissijigyonm { get; set; }        //実施事業名称       
        public bool checkflg { get; set; }              //チェックフラグ
        public string hanyokbn1 { get; set; }           //汎用区分1
        public JissijigyoModel()
        {
        }
        public JissijigyoModel(string? jissijigyo, string? jissijigyonm, bool checkflg, string? hanyokbn1)
        {
            this.jissijigyo = jissijigyo ?? string.Empty;
            this.jissijigyonm = jissijigyonm ?? string.Empty;
            this.checkflg = checkflg;
            this.hanyokbn1 = hanyokbn1 ?? string.Empty;
        }
    }

}