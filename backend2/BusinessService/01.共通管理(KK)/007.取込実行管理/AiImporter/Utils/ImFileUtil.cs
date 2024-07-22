// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　ファイルを読み込む共通関数
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using System.Text;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImFileUtil
    {
        /// <summary>
        /// TXT/CSVファイルを読み込む
        /// </summary>
        /// <param name="filedata">ファイルデータ</param>
        /// <param name="targetEncoding">エンコード</param>
        /// <param name="divideChar">区切り記号</param>
        /// <param name="isQuote">引用符存在か</param>
        /// <returns></returns>
        public static List<string[]> ReadFileData(byte[] filedata, Encoding targetEncoding, int divideChar, bool isQuote)
        {
            List<string[]> dataList = new List<string[]>();

            using MemoryStream stream = new MemoryStream(filedata);
            using (var reader = new StreamReader(stream, targetEncoding))
            {
                var fieldBuilder = new StringBuilder();
                var currentFields = new List<string>();
                bool insideQuotes = false;

                while (!reader.EndOfStream)
                {
                    int currentChar = reader.Read();
                    // 引用符内　引用符2つは引用符1つに変換
                    if (isQuote && currentChar == '"' && insideQuotes)
                    {
                        int nextChar = reader.Peek();
                        if (nextChar == '"')
                        {
                            reader.Read(); // 次の引用符をスキップ
                            fieldBuilder.Append('"');
                            continue;
                        }
                    }

                    // 引用符の処理
                    if (isQuote && (currentChar == '"' || currentChar == '\''))
                    {
                        insideQuotes = !insideQuotes;
                        continue;
                    }

                    // 区切り記号の処理
                    if (currentChar == divideChar && !insideQuotes)
                    {
                        currentFields.Add(fieldBuilder.ToString().Replace("\"\"", "\"").Trim());
                        fieldBuilder.Clear();
                        continue;
                    }

                    // 改行の処理
                    if (currentChar == '\n' && !insideQuotes)
                    {
                        // 最後のフィールドを追加
                        currentFields.Add(fieldBuilder.ToString().Replace("\"\"", "\"").Trim());
                        dataList.Add(currentFields.ToArray());
                        currentFields.Clear();
                        fieldBuilder.Clear();
                        continue;

                    }

                    // フィールドビルダーへの文字の追加
                    fieldBuilder.Append((char)currentChar);
                }

                // ファイルの最後の処理
                if (fieldBuilder.Length > 0)
                {
                    currentFields.Add(fieldBuilder.ToString().Replace("\"\"", "\"").Trim());
                    dataList.Add(currentFields.ToArray());
                }
            }

            return dataList;
        }
    }
}