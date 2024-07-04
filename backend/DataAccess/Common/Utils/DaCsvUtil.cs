// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力、CSV読込
//
// 作成日　　: 2023.01.19
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class DaCsvUtil
    {
        public const string ERR_PARAMTER_DT = "パラメータエラー";
        public const string ERR_PARAMTER_QUOT = "ダブルクォーテーション内データエラー";
        public const string ERR_PARAMTER_LEN = "パラメータ件数エラー";
        public const string ERR_COLUMN_COUNT = "カラム件数エラー";
        public const string ERR_LINE_LINGTH = "データ行数エラー";
        /// <summary>
        /// CSV出力(文字列表示)
        /// </summary>
        public static string ToCsv(List<object> list)
        {
            if (list.Count == 0) return string.Empty;

            var model = list[0];
            var ps = model.GetType().GetProperties();
            var colCount = ps.Length;
            StringBuilder sb = new StringBuilder();
            int lastColIndex = colCount - 1;

            foreach (var row in list)
            {
                for (int i = 0; i < colCount; i++)
                {
                    var p = ps[i];
                    //フィールドの取得
                    string field = p.GetValue(row)!.ToString() ?? "";
                    //"で囲む
                    field = EncloseDoubleQuotesIfNeed(field);
                    //フィールドを書き込む
                    sb.Append(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sb.Append(',');
                    }
                }

                //改行する
                sb.Append("\r\n");
            }

            return sb.ToString();
        }
        /// <summary>
        /// CSV出力(文字列表示)
        /// </summary>
        /// <param name="dt">対象のDataTable</param>
        public static string ToCsv(DataTable dt, bool writeHeader)
        {
            StringBuilder sb = new StringBuilder();

            int colCount = dt.Columns.Count;
            int lastColIndex = colCount - 1;

            //ヘッダを書き込む
            if (writeHeader)
            {
                for (int i = 0; i < colCount; i++)
                {
                    //ヘッダの取得
                    string field = dt.Columns[i].Caption;
                    //"で囲む
                    field = EncloseDoubleQuotesIfNeed(field);
                    //フィールドを書き込む
                    sb.Append(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sb.Append(',');
                    }
                }
                //改行する
                sb.Append("\r\n");
            }

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    //フィールドの取得
                    string field = GetString(row[i]);
                    //"で囲む
                    field = EncloseDoubleQuotesIfNeed(field);
                    //フィールドを書き込む
                    sb.Append(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sb.Append(',');
                    }
                }

                //改行する
                sb.Append("\r\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// CSVからDataTableを作成
        /// </summary>
        /// <param name="content"></param>
        /// <param name="dt"></param>
        /// <param name="hasHead"></param>
        public static void ReadCsv(string content, ref DataTable dt, bool hasHead = true)
        {
            //char splitChar = ',';
            if (content == null) return;
            if (dt == null) throw new System.Exception(ERR_PARAMTER_DT);

            string[] lines = content.Split('\r');
            int rowIndex = 0;
            foreach (string line in lines)
            {

                string s = line;
                if (line.StartsWith("\n"))
                {
                    s = line.Substring(1);
                }
                if (hasHead && rowIndex++ == 0) continue;
                if (s.Trim() == string.Empty) break;

                DataRow dr = dt.NewRow();

                FillDataRow_Excel(rowIndex, s, dt.Columns, ref dr);
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
        }

        #region Private function
        private static string GetString(object obj)
        {
            if (obj == System.Convert.DBNull)
            {
                return "";
            }
            else if (obj is string[])
            {
                var ss = (string[])obj;
                return $"{{{string.Join(",", ss)}}}";
            }
            else if (obj is byte[])
            {
                var data = (byte[])obj;
                return Convert.ToBase64String(data);
            }
            else
            {
                return obj.ToString()!;
            }
        }


        /// <summary>
        /// Excel形式CSVの読込
        /// </summary>
        /// <param name="s"></param>
        /// <param name="cols"></param>
        /// <param name="dr"></param>
        private static void FillDataRow_Excel(int rowIndex, string s, DataColumnCollection cols, ref DataRow dr)
        {
            string[] ss = FromExcelRow(s);
            if (ss.Length != cols.Count)
            {
                throw new System.Exception(ERR_COLUMN_COUNT);
            }
            for (int i = 0; i < ss.Length; i++)
            {
                string item = ss[i];
                FillDataRowItem(rowIndex, item, cols[i], i, ref dr);
            }
        }

        private static void FillDataRowItem(int rowIndex, string s, DataColumn col, int index, ref DataRow dr)
        {
            if (s == string.Empty)
            {
                if (col.AllowDBNull == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.NullError };
                }
                dr[index] = System.DBNull.Value;
                return;
            }
            if (col.DataType == typeof(string))
            {
                if (s.Length > col.MaxLength && col.MaxLength > 0)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.LengthOver };
                }
                dr[index] = s;
            }
            else if (col.DataType == typeof(int))
            {
                if (int.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(decimal))
            {
                if (decimal.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(DateTime))
            {
                if (DateTime.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(Double))
            {
                if (double.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(Single))
            {
                if (Single.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(bool))
            {
                if (bool.TryParse(s, out var result) == false)
                {
                    throw new CSVExcetion() { RowIndex = rowIndex, ColIndex = index + 1, Caption = col.ColumnName, ErrorType = CSVExcetion.EnumCSVError.TypeError };
                }
                dr[index] = result;
            }
            else if (col.DataType == typeof(string[]))
            {
                if (s != string.Empty)
                {
                    string[] result = s.Trim().Replace("{", "").Replace("}", "").Replace("\"", "").Split(',');
                    dr[index] = result;
                }
            }
            else if (col.DataType == typeof(byte[]))
            {
                if (s != string.Empty)
                {
                    dr[index] = Convert.FromBase64String(s);
                }
            }
            else
            {
                throw new Exception("Type Error");
            }
        }
        private static string[] FromExcelRow(string row)
        {
            Dictionary<int, int> commaDic = GetCommaDic(row);
            List<int> commaList = GetCommaList(row, commaDic);
            List<string> list = new List<string>();
            int lastIndex = 0;
            foreach (int i in commaList)
            {
                string item = GetItem(row, lastIndex, i);
                list.Add(item);
                lastIndex = i + 1;
            }
            list.Add(GetItem(row, lastIndex, row.Length));

            return list.ToArray();
        }

        private static List<int> GetCommaList(string s, Dictionary<int, int> commaDic)
        {
            List<int> commaList = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == ',')
                {
                    commaList.Add(i);

                }
                if (commaDic.ContainsKey(i))
                {
                    i = commaDic[i];
                }

            }

            return commaList;
        }
        private static string GetItem(string row, int strat, int end)
        {
            string item = row.Substring(strat, end - strat).Trim();
            if (item.StartsWith("\""))
            {
                item = item.Substring(1);
            }
            if (item.EndsWith("\""))
            {
                item = item.Substring(0, item.Length - 1);
            }
            return item.Replace("\"\"", "\"").Replace("\n", "\r");
        }
        private enum EnumFlag { OutRange, RangeStart, RangeEnd, InRange };
        private static Dictionary<int, int> GetCommaDic(string s)
        {
            EnumFlag flag = EnumFlag.OutRange;
            Dictionary<int, int> commaDic = new Dictionary<int, int>();
            int startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //char c = s[i];


                if (s[i] == '"')
                {
                    switch (flag)
                    {
                        case EnumFlag.OutRange:
                            startIndex = i;
                            flag = EnumFlag.RangeStart;
                            break;
                        case EnumFlag.InRange:
                            char c2 = (i < s.Length) ? s[i + 1] : ' ';
                            if (c2 == '"')
                            {
                                i++;
                                flag = EnumFlag.InRange;
                            }
                            else
                            {
                                commaDic.Add(startIndex, i);
                                flag = EnumFlag.RangeEnd;
                            }
                            break;
                    }
                }

                switch (flag)
                {
                    case EnumFlag.RangeStart:
                        flag = EnumFlag.InRange;
                        break;
                    case EnumFlag.RangeEnd:
                        flag = EnumFlag.OutRange;
                        break;
                }

            }
            return commaDic;
        }

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }
        private static bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }
        #endregion
    }

    /// <summary>
    /// CSVエラークラス
    /// </summary>
    public class CSVExcetion : Exception
    {
        public enum EnumCSVError
        {
            NullError, LengthOver, TypeError, KeyDuplicate
        }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public string Caption { get; set; }
        public EnumCSVError ErrorType { get; set; }

        public CSVExcetion() : base("項目エラー、詳細はパラメータを参照。")
        {

        }
    }
}
