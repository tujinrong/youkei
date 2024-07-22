// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　DB処理共通関数
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImDBUtil
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;
        /// <summary>
        /// キャシュークリア
        /// </summary>
        public static void ClearCache()
        {
            _cache?.Clear();
        }

        /// <summary>
        /// パラメータセット
        /// </summary>
        public static void SetParam(AiSessionContext session, string tableName, List<string> paraNames, ref List<object> paraValues)
        {
            var fieldlist = AiGlobal.DbInfoProvider.GetTableInfo(session, tableName).FieldList;

            for (int i = 0; i < paraNames.Count; i++)
            {
                var fieldName = paraNames[i];
                var field = fieldlist.Find(e => e.FieldName.Equals(fieldName));
                if (field != null)
                {
                    paraValues[i] = GetParaValue(paraValues[i], field.DbType);
                }
            }
        }

        /// <summary>
        /// パラメータ値を取得
        /// </summary>
        private static object GetParaValue(object value, int dbType)
        {
            try
            {
                Type fieldType = AiGlobal.DbInfoProvider.GetFieldType(dbType);
                return Convert.ChangeType(value, fieldType);
            }
            catch
            {
                throw new Exception("Parameter Error:" + value);
            }
        }

        /// <summary>
        /// マスタチェックテーブルsqlを取得する
        /// </summary>
        public static string GetSql(AiSessionContext session, DataTable data, string columnName,
                                string tableid, string selfieldid, string confieldid)
        {
            string sql = "";
            //条件値
            var valueList = data.AsEnumerable().Where(row => !string.IsNullOrEmpty(row.Field<string>(columnName)))
                                            .Select(row => row.Field<string>(columnName)).ToList();
            if (valueList.Count == 0)
            {
                return "";
            }
            //条件値を取得する
            var values = GetConditionValues(session, tableid, confieldid, valueList!);

            if (!string.IsNullOrEmpty(values))
            {
                sql = $"SELECT {selfieldid} FROM {tableid} WHERE {confieldid} in ({values})";
            }
            return sql;
        }

        /// <summary>
        /// 条件値を取得する
        /// </summary>
        public static string GetConditionValues(AiSessionContext session, string tableid, string fieldid, List<string> valueList)
        {
            var tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(session, tableid);
            //条件フィールド情報
            var fieldInfo = tableInfo.FieldList.Find(e => e.FieldName.Equals(fieldid));
            if (fieldInfo != null)
            {
                //フィールドTYPE
                if (JudfieldType(fieldInfo.DbType))
                {
                    return string.Join(", ", valueList.Select(s => $"'{s}'"));
                }
                else
                {
                    return string.Join(", ", valueList.Select(s => $"{s}"));
                }
            }
            return "";
        }

        /// <summary>
        /// フィールドTYPE
        /// </summary>
        private static bool JudfieldType(int dbType)
        {
            //フィールドTYPE
            Type fieldType = AiGlobal.DbInfoProvider.GetFieldType(dbType);
            if (fieldType.Name == "String" || fieldType.Name == "DateTime" || fieldType.Name == "TimeSpan")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// DataTable を指定された数の行ごとに分割する
        /// </summary>
        public static List<DataTable> GetDataList(DataTable dt, int count)
        {
            var dataList = new List<DataTable>();
            //DataTable の各行を指定された数ごとにグループ分けする
            IEnumerable<IEnumerable<DataRow>> rowGroups = dt.AsEnumerable()
            .Select((row, index) => new { Row = row, Index = index }).GroupBy(x => x.Index / count).Select(g => g.Select(x => x.Row));

            //分けたグループごとに新しい DataTable を作成し、リストに追加する
            foreach (var rowGroup in rowGroups)
            {
                DataTable newTable = dt.Clone();
                foreach (DataRow row in rowGroup)
                {
                    //新しい DataTable に行を追加
                    newTable.ImportRow(row);
                }
                dataList.Add(newTable);
            }

            return dataList;
        }

        /// <summary>
        /// 該当テーブルのフィールドリストを取得する
        /// </summary>
        public static List<AiFieldInfo> GetFieldList(DaDbContext db, string tableid)
        {
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            List<AiFieldInfo> fieldList;
            if (!_cache.TryGetValue(tableid, out fieldList!))
            {
                AiTableInfo aiTableInfo = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, tableid);
                if (aiTableInfo != null)
                {
                    fieldList = aiTableInfo.FieldList;

                    //共通フィールド
                    var commonFieldList = new List<string>()
                    {
                        AiGlobal.CreateUnitName,
                        AiGlobal.CreateUserFieldName,
                        AiGlobal.CreateTimeFieldName,
                        AiGlobal.UpdateUserFieldName,
                        AiGlobal.UpdateTimeFieldName

                    };
                    //共通フィールドは画面に設定に表示しない
                    fieldList = fieldList.Where(e => !commonFieldList.Contains(e.FieldName)).ToList();

                    _cache.Set(tableid, fieldList, TimeSpan.FromMinutes(CACHE_MINIUTE));
                }
            }

            return fieldList;
        }

        /// <summary>
        /// 一時テーブルを作成
        /// </summary>
        public static void CreateTempTab(AiSessionContext session, string tmpTableName, List<string> columnNameList)
        {
            AiGlobal.DbApi.RunSql(session, $"DROP TABLE IF EXISTS {tmpTableName}");

            var sb = new StringBuilder();
            sb.AppendLine($"CREATE TEMP TABLE {tmpTableName}");
            sb.AppendLine($"(");
            for (int i = 0; i < columnNameList.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }
                sb.AppendLine($"\"{columnNameList[i]}\" TEXT ");
            }
            sb.AppendLine(")");
            AiGlobal.DbApi.RunSql(session, sb.ToString());
        }

        /// <summary>
        /// 一時テーブルを登録
        /// </summary>
        public static void SaveWorkData(AiSessionContext session, string tmpTableName, DataTable dt)
        {
            var lst3 = new List<string>();
            string f3;
            string sql = $"INSERT INTO {tmpTableName} VALUES ";
            foreach (DataRow row in dt.Rows)
            {
                var lst2 = new List<string>();
                string f2;
                foreach (DataColumn col in dt.Columns)
                {
                    if (CStr(row[col.ColumnName]) == string.Empty)
                    {
                        lst2.Add("null");
                        continue;
                    }

                    switch (col.DataType)
                    {
                        case var case2 when case2 == typeof(string):
                        case var case4 when case4 == typeof(DateTime):
                        case var case5 when case5 == typeof(TimeSpan):
                            {
                                f2 = $"'{row[col.ColumnName]}'";
                                break;
                            }
                        case var case3 when case3 == typeof(int):
                            {
                                f2 = $"{row[col.ColumnName]}";
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException();
                            }
                    }
                    lst2.Add(f2);
                }
                f3 = $"({string.Join(",", lst2)})";
                lst3.Add(f3);
            }
            sql += string.Join(",", lst3);
            AiGlobal.DbApi.RunSql(session, sql);
        }
    }
}