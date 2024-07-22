// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　編集データエラー定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImEditErrorRow
    {
        public int errseq { get; set; }                     //エラーID
        public int? dataseq { get; set; }                   //データID
        public int rowno { get; set; }                      //行番号
        public string? atenano { get; set; }                //宛名番号
        public string? shimei { get; set; }                 //氏名
        public string? itemnm { get; set; }                 //項目名
        public string? itemvalue { get; set; }              //項目値
        public string msg { get; set; }                     //メッセージ
        public string errkbn { get; set; } = string.Empty;  //エラー区分
        public ImEditErrorRow() { }

        public ImEditErrorRow(int? dataseq, int rowno, Enumエラーレベル errkbn, EnumMessage msgId, params object[] msgparam)
        {
            this.dataseq = dataseq;
            this.rowno = rowno;
            this.errkbn = EnumToStr(errkbn);
            this.msg = GetErrKbnName(this.errkbn) + DaMessageService.GetMsg(msgId, msgparam);
        }

        public ImEditErrorRow(int? dataseq, int rowno, Enumエラーレベル errkbn, string? itemnm, string? itemvalue, EnumMessage msgId, params object[] msgparam)
        {
            this.dataseq = dataseq;
            this.rowno = rowno;
            this.errkbn = EnumToStr(errkbn);
            this.itemnm = itemnm;
            this.itemvalue = itemvalue;
            this.msg = GetErrKbnName(this.errkbn) + DaMessageService.GetMsg(msgId, msgparam);
        }

        /// <summary>
        /// エラー区分名称を取得
        /// </summary>
        private string GetErrKbnName(string errkbn)
        {
            switch (ParseEnum<Enumエラーレベル>(errkbn))
            {
                case Enumエラーレベル.情報:
                    return "【情報】";
                case Enumエラーレベル.警告:
                    return "【警告】";
                case Enumエラーレベル.エラー:
                    return "【エラー】";
                default:
                    return "";
            }
        }
    }
}
