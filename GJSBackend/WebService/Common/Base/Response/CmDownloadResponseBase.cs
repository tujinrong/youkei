// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ダウンロード処理
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using WebService.Common.Enums;

namespace WebService.Common.Base.Response
{
    public class CmDownloadResponseBase : CmPreviewResponseBase
    {
        public EnumDownloadType downloadtype { get; set; } = EnumDownloadType.Data; //ファイルタイプ
        public string filefullnm { get; set; }                                      //ファイル名(パス含む)
    }
}