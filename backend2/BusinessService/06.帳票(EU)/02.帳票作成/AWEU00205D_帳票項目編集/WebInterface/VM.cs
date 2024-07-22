// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目編集
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00205D
{
    /// <summary>
    /// マスタ初期化処理
    /// </summary>
    public class MasterVM : AWEU00105D.MasterVM
    {
        public bool manualflg { get; set; } //手入力フラグ
    }

    /// <summary>
    /// フォーマット初期化処理
    /// </summary>
    public class FormatVM
    {
        public string formatkbn { get; set; }                   //フォーマット区分
        public string formatnm { get; set; }                    //フォーマット名称
        public List<FormatSyosaiVM>? syosailist { get; set; }   //フォーマット詳細リスト
    }

    /// <summary>
    /// フォーマット初期化処理
    /// </summary>
    public class FormatSyosaiVM
    {
        public string formatkbn2 { get; set; }      //フォーマット区分2
        public string formattypenm { get; set; }    //フォーマット種別名
        public string? formatsyosai { get; set; }   //フォーマット詳細
        public bool userdefinedflg { get; set; }    //ユーザー定義フラグ
        public string? formatexample { get; set; }  //フォーマット例
    }
}