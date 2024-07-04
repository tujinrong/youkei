// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ダウンロード
// 　　　　　　サービス処理
// 作成日　　: 2023.02.14
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using ICSharpCode.SharpZipLib.Zip;

namespace BCC.Affect.Service
{
    public static class CmDownloadService
    {
        /// <summary>
        /// 単一ファイルのダウンロード応答を取得
        /// </summary>
        public static CmDownloadResponseBase GetDownloadResponse(List<DaFileModel> files, string? zipFileName = null)
        {
            var res = new CmDownloadResponseBase();
            // ファイルがない場合
            if (files == null || !files.Any())
            {
                throw new FileNotFoundException();
            }

            DaFileModel singleFile;
            // 単一ファイルの場合
            if (files.Count == 1)
            {
                singleFile = files[0];
            }
            else
            {
                // 同じ名前のファイルの名前を変更
                RenameSameNameFiles(files);

                // 複数のファイルを圧縮
                singleFile = ZipFiles(files, zipFileName);
            }
            res.filenm = $"{singleFile.filenm}{singleFile.filetype}";      //ファイル名
            res.data = singleFile.filedata;                                //ファイルデータ
            res.contenttype = CmFileUtil.GetMapping(singleFile.filetype);  //コンテンツタイプ

            return res;
        }

        /// <summary>
        /// 単一ファイルのダウンロード応答を取得
        /// </summary>
        public static CmDownloadResponseBase GetDownloadResponse(DaFileModel file)
        {
            var res = new CmDownloadResponseBase();
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

        /// <summary>
        /// 同じ名前のファイルの名前を変更
        /// </summary>
        private static void RenameSameNameFiles(IEnumerable<DaFileModel> files)
        {
            var group = files.GroupBy(f => $"{f.filenm}{f.filetype}").ToDictionary(f => f.Key, f => f.ToList());
            foreach (var g in group)
            {
                if (g.Value.Count > 1)
                {
                    for (int i = 1; i < g.Value.Count; i++)
                    {
                        var file = g.Value[i];
                        file.filenm = $"{file.filenm}({i})";
                    }
                }
            }
        }

        /// <summary>
        /// 複数のファイルを1つのzipファイルに圧縮
        /// </summary>
        private static DaFileModel ZipFiles(IEnumerable<DaFileModel> files, string? zipFileName)
        {
            using var memoryStream = new MemoryStream();
            using var zos = new ZipOutputStream(memoryStream);
            zos.SetLevel(9);
            zipFileName = string.IsNullOrEmpty(zipFileName) ? DaConst.DEFAULT_ZIP_FILE_NAME : zipFileName;
            var now = DaUtil.Now;
            foreach (var file in files)
            {
                var entry = new ZipEntry($"{zipFileName}{DaStrPool.C_SLASH}{file.filenm}{file.filetype}")
                {
                    DateTime = now
                };
                zos.PutNextEntry(entry);
                zos.Write(file.filedata);
                zos.Flush();
            }
            zos.Finish();
            return new DaFileModel(zipFileName, DaStrPool.FILE_ZIP_SUFFIX, memoryStream.ToArray());
        }
    }
}