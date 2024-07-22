// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    レスポンスインターフェース　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00206D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public SonchoVM soncho { get; set; }                        //市区町村長
        public DairishaVM dairisha { get; set; }                    //職務代理者
        public byte[] sonchokoindata { get; set; }                  //市区町村長公印画像
        public byte[] dairishakoindata { get; set; }                //職務代理者公印画像
        public DateTime upddttm { get; set; }                       //更新日時
        public List<DaSelectorModel> kacdList { get; set; }         //課コード
        public List<DaSelectorModel> kakaricdList { get; set; }     //係コード
        public List<DaSelectorModel> toiawasesakicdList { get; set; } //問い合わせ先リスト
        public List<KoinReportVM> kekkalist1 { get; set; }          //印字設定結果リスト
        public List<ContactInfoReportVM> kekkalist2 { get; set; }   //問い合わせ先設定結果リスト
    }
}