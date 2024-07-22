// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 電子ファイル情報
//             ビューモデル定義
// 作成日　　: 2024.07.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00602D
{
    /// <summary>
    /// ドキュメント情報(保存用)
    /// </summary>
    public class SaveVM : LockVM
    {
        public string title { get; set; }       //タイトル
        public bool juyoflg { get; set; }       //重要フラグ
        public string filenm { get; set; }      //ファイル名
        public string jigyo { get; set; }       //事業(コード：名称)
    }

    /// <summary>
    /// ドキュメント情報(一覧)
    /// </summary>
    public class SearchVM : SaveVM
    {
        public bool imgflg { get; set; }        //画像フラグ
        public DateTime regdttm { get; set; }   //登録日時(アップロード日時)
        public string jigyonm { get; set; }     //事業名
        public string regsisyonm { get; set; }  //登録支所名
        public bool updflg { get; set; }        //更新権限フラグ
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public int docseq { get; set; }         //ドキュメントシーケンス
        public DateTime? upddttm { get; set; }  //更新日時
    }
}