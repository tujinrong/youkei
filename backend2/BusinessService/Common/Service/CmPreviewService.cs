// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: プレビュー
// 　　　　　　サービス処理
// 作成日　　: 2024.07.09
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public static class CmPreviewService
    {
        /// <summary>
        /// 単一ファイルプレビュー応答
        /// </summary>
        public static CmPreviewResponseBase GetPreviewResponseBase(DaFileModel file)
        {
            var res = new CmPreviewResponseBase();
            // ファイルがない場合
            if (file == null)
            {
                throw new FileNotFoundException();
            }
            res.filenm = $"{file.filenm}{file.filetype}";              //ファイル名
            res.data = file.filedata;                                  //ファイルデータ
            res.contenttype = CmFileUtil.GetMapping(file.filetype);    //コンテンツタイプ

            return res;
        }
    }
}