// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象外者管理
//             ViewModel定義
// 作成日　　: 2023.12.20
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK01001G
{
    /// <summary>
    /// 一覧データモデル(行単位)
    /// </summary>
    public class RowVM
    {
        public string atenano { get; set; }         //宛名番号
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string sex { get; set; }             //性別
        public string bymd { get; set; }            //生年月日
        public string adrs { get; set; }            //住所
        public string gyoseiku { get; set; }        //行政区
        public string juminkbn { get; set; }        //住民区分
        public string taisyogaikbn { get; set; }    //対象外者区分
        public string keikoku { get; set; }         //警告内容
    }

    /// <summary>
    /// 排他モデル
    /// </summary>
    public class LockVM
    {
        public string rptgroupid { get; set; }  //帳票グループID
        public DateTime? upddttm { get; set; }  //更新日時
    }

    /// <summary>
    /// 保存処理モデル
    /// </summary>
    public class SaveVM : LockVM
    {
        public string uketukeymd { get; set; }      //受付日
        public string taisyogairiyu { get; set; }   //対象外理由
    }

    /// <summary>
    /// 画面表示内容モデル
    /// </summary>
    public class InitVM : SaveVM
    {
        public bool taisyogaikbn { get; set; }  //対象外者区分
        public string rptgroupnm { get; set; }  //帳票グループ名
        public string gyomukbn { get; set; }    //業務区分(フィルター用)
        public string gyomukbnnm { get; set; }  //業務区分名
    }
}