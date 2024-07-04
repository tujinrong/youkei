// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(CSV出力設定)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00302D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ダウンロード処理
        /// </summary>
        public static string GetFileNameNoSuffix(string fileName, string fileSuffix)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            }

            if (!fileName.EndsWith(fileSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return fileName;
            }
            var index = fileName.LastIndexOf(fileSuffix, StringComparison.OrdinalIgnoreCase);
            return fileName.Remove(index);
        }
    }
}