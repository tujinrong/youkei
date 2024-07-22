// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             予防接種入力チェックマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysnyuryokucheckDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_ysnyuryokucheck";
		public string sessyucd { get; set; }                      //接種種類コード
		public string kaisu { get; set; }                         //回数
		public string vaccinesyu { get; set; }                    //ワクチン種類
		public string? sessyuchk1 { get; set; }                   //接種済みチェック1(エラー)
		public string? sessyuchk2 { get; set; }                   //接種済みチェック2(警告)
		public string? zensessyu { get; set; }                    //前回接種種類
		public string? rikanchk1 { get; set; }                    //罹患済みチェック1(エラー)
		public string? rikanchk2 { get; set; }                    //罹患済みチェック2(警告)
		public int? kanost { get; set; }                          //接種可能開始
		public string? kanosttani { get; set; }                   //接種可能開始単位
		public int? kanoed { get; set; }                          //接種可能終了
		public string? kanoedtani { get; set; }                   //接種可能終了単位
		public string? kanohanikbn { get; set; }                  //接種可能範囲区分
		public string? kanocomment { get; set; }                  //接種可能コメント
		public int? hyojunst { get; set; }                        //接種標準開始
		public string? hyojunsttani { get; set; }                 //接種標準開始単位
		public int? hyojuned { get; set; }                        //接種標準終了
		public string? hyojunedtani { get; set; }                 //接種標準終了単位
		public string? hyojunhanikbn { get; set; }                //接種標準範囲区分
		public string? hyojuncomment { get; set; }                //接種標準コメント
		public int? kankakumin { get; set; }                      //接種間隔下限
		public int? kankakumax { get; set; }                      //接種間隔上限
		public string? kankakutani { get; set; }                  //接種間隔単位
		public string? kankakucomment { get; set; }               //接種間隔コメント
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
