// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 連絡先
//             ビューモデル定義
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00605D
{
    /// <summary>
    /// 連絡先情報(1件)
    /// </summary>
    public class SearchVM
    {
        public string tabnm { get; set; }                       //タブ名
        public CommonBarHeaderBaseVM headerinfo { get; set; }   //個人基本情報
        public SaveVM? detailinfo { get; set; }                 //連絡先情報
        public bool updflg { get; set; }                        //更新権限フラグ
    }

    /// <summary>
    /// 連絡先情報(保存用)
    /// </summary>
    public class SaveVM
    {
        public string jigyo { get; set; }           //利用事業(コード：名称)
        public string atenano { get; set; }         //宛名番号
        public string tel { get; set; }             //電話番号
        public string keitaitel { get; set; }       //携帯番号
        public string emailadrs { get; set; }       //E-mailアドレス
        public string emailadrs2 { get; set; }      //E-mailアドレス2
        public string syosai { get; set; }          //連絡先詳細
        public DateTime? upddttm { get; set; }      //更新日時
        public string regsisyonm { get; set; }      //登録支所名
    }

    /// <summary>
    /// キー項目モデル
    /// </summary>
    public class KeyVM
    {
        public string atenano { get; set; }             //宛名番号
        public Enum連絡先タブ名称 kbn { get; set; }     //タブ区分
        public KeyVM(string atenano, Enum連絡先タブ名称 kbn)
        {
            this.atenano = atenano;
            this.kbn = kbn;
        }
    }
}