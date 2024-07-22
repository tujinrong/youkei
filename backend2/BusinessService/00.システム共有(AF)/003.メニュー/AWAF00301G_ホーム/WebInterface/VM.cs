// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ホーム
//             ビューモデル定義
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00301G
{
    /// <summary>
    /// お知らせ
    /// </summary>
    public class InfoVM
    {
        public long infoseq { get; set; }       //お知らせシーケンス
        public string juyodo { get; set; }      //重要度
        public bool readflg { get; set; }       //既読未読フラグ
        public DateTime regdttm { get; set; }   //登録日時
        public string syosai { get; set; }      //詳細
    }

    /// <summary>
    /// 外部連携処理結果履歴
    /// </summary>
    public class GaibulogVM
    {
        public long gaibulogseq { get; set; }               //外部連携ログシーケンス
        public DateTime syoridttmf { get; set; }            //処理日時（開始）
        public DateTime syoridttmt { get; set; }            //処理日時（終了）
        public string syorikbn { get; set; }                //処理区分
        public string usernm { get; set; }                  //操作者名
        public string syorinm { get; set; }                 //処理内容
        public string status { get; set; }                  //処理結果
        public Enum表示色区分 colorkbn { get; set; }        //処理結果表示色区分
        public bool fileflg { get; set; }                   //ファイル存在フラグ
    }
}