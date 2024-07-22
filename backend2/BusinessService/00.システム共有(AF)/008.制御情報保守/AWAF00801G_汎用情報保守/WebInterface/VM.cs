// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 汎用情報保守
//             ビューモデル定義
// 作成日　　: 2024.07.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00801G
{
    /// <summary>
    /// 汎用データ情報モデル
    /// </summary>
    public class HanyoVM : LockVM
    {
        public string nm { get; set; }              //名称
        public string kananm { get; set; }          //カナ名称
        public string shortnm { get; set; }         //略称
        public string biko { get; set; }            //備考
        public string hanyokbn1 { get; set; }       //汎用区分1
        public string hanyokbn2 { get; set; }       //汎用区分2
        public string hanyokbn3 { get; set; }       //汎用区分3
        public bool stopflg { get; set; }           //使用停止フラグ
        public int? orderseq { get; set; }          //並びシーケンス
        public bool hanyocdEditFlg { get; set; }    //汎用コード編集フラグ
        public bool pkgCdFlg { get; set; }          //PKGコードフラグ(true:PKG、false:独自)
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public string hanyocd { get; set; }     //汎用コード
        public DateTime? upddttm { get; set; }  //更新日時

        public LockVM()
        {
            
        }

        public LockVM(string hanyocd, DateTime? upddttm)
        {
            this.hanyocd = hanyocd;
            this.upddttm = upddttm;
        }
    }

    /// <summary>
    /// サブコード情報モデル
    /// </summary>
    public class SubCodeInfoVM
    {
        public string hanyomaincd { get; set; }     //汎用メインコード
        public int hanyosubcd { get; set; }         //汎用サブコード
        public string hanyosubcdnm { get; set; }    //汎用サブコード名称
        public int? userryoikikaisicd { get; set; } //ユーザ領域開始コード
        public int? keta { get; set; }              //桁数
    }
}