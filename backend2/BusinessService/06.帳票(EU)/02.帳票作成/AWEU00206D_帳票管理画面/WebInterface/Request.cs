// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    リクエストインターフェース　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00206D
{
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmUploadRequestBase
    {
        public List<BaseKoinReportVM> koinreportlist { get; set; } = new();                 //印字設定リスト
        public List<BaseContactInfoReportVM> contactinforeportlist { get; set; } = new();   //問い合わせ先設定リスト
        public SonchoVM soncho { get; set; }                                                //市区町村長
        public DairishaVM dairisha { get; set; }                                            //職務代理者
        public DateTime upddttm { get; set; }                                               //更新日時
    }
}