// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: プレビュー処理
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Jbd.Gjs.Common;
using Newtonsoft.Json;

namespace WebService.Common.Base.Response
{
    public class CmPreviewResponseBase : DaResponseBase
    {
        public string filenm { get; set; }                                          //ファイル名
        [JsonIgnore]
        public byte[] data { get; set; }                                            //データ
        public string contenttype { get; set; }                                     //コンテンツタイプ
    }
}