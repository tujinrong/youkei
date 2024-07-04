// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　ファイルエラー定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImFileErrorRow
    {
        public int RowNo { get; set; }//行
        public string Title { get; set; } = string.Empty;//タイトル
        public string ItemValue { get; set; } = string.Empty;//項目値
        public string Msg { get; set; }                //メッセージ

        public ImFileErrorRow() { }

        public ImFileErrorRow(int rowNo, string title, string itemValue, EnumMessage msgId, params object[] msgparam)
        {
            RowNo = rowNo;
            Title = title;
            ItemValue = itemValue;
            Msg = DaMessageService.GetMsg(msgId, msgparam);
        }

        public ImFileErrorRow(int rowNo, string title, string itemValue, string msg)
        {
            RowNo = rowNo;
            Title = title;
            ItemValue = itemValue;
            Msg = msg;
        }
    }
}
