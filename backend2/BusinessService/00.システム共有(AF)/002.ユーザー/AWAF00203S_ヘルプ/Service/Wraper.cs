// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ヘルプ
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.24
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00203S
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ファイルリスト取得
        /// </summary>
        public static List<DaFileModel> GetFileList(List<tm_afhelpdocDto> dtl)
        {
            return dtl.Select(d => new DaFileModel(d.filenm, $".{d.filetype}", d.filedata)).ToList();
        }
    }
}