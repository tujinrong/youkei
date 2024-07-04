// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ファイルモデル
//
// 作成日　　: 2023.02.14
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;

namespace BCC.Affect.DataAccess
{
    public class DaFileModel
    {
        public string filenm { get; set; } = string.Empty;             //ファイル名
        public string filetype { get; set; } = string.Empty;           //ファイルタイプ
        public int filesize { get; set; } = 0;                         //ファイルサイズ
        [JsonIgnore]
        public byte[] filedata { get; set; } = Array.Empty<byte>();    //ファイルデータ
        public DaFileModel(string filenm, string filetype, byte[] filedata)
        {
            this.filenm = filenm;
            this.filetype = filetype;
            this.filedata = filedata;
            this.filesize = filedata.Length;
        }
    }
}