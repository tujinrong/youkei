// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             外部連携処理結果履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afgaibulogDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_afgaibulog";
        public long gaibulogseq { get; set; }                     //外部連携ログシーケンス
        public long sessionseq { get; set; }                      //セッションシーケンス
        public DateTime syoridttmf { get; set; }                  //処理日時（開始）
        public DateTime syoridttmt { get; set; }                  //処理日時（終了）
        public string msg { get; set; }                           //メッセージ
        public string ipadrs { get; set; }                        //IPアドレス（実行）
        public string kbn { get; set; }                           //連携区分
        public string kbn2 { get; set; }                          //連携方式
        public string kbn3 { get; set; }                          //処理区分
        public string apidata { get; set; }                       //API連携データ
        public string filenm { get; set; }                        //ファイル名
        public EnumFileTypeKbn filetype { get; set; }             //ファイルタイプ
        public int? filesize { get; set; }                        //ファイルサイズ
        public byte[] filedata { get; set; }                      //ファイルデータ
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
    }
}
