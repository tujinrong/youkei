// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DB共通処理
//             DataTableの便利機能。BulkInsert（Logに使用）
// 作成日　　: 2024.07.19
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using Npgsql;
using NpgsqlTypes;

namespace BCC.Affect.DataAccess
{
    public class ProcModel
    {
        public string ProcName { get; set; }
        public List<object?> ParamList = new List<object?>();
        public ProcModel() { }

        public ProcModel(string procName, List<object?> list)
        {
            ProcName = procName;
            ParamList = list;
        }

        public ProcModel(string procName, params object?[] param)
        {
            ProcName = procName;
            foreach (var p in param)
            {
                ParamList.Add(p);
            }
        }
    }

    public class DaDbUtil
    {
        /// <summary>
        /// SQLから、データテーブルを取得
        /// </summary>
        public static DataTable GetDataTable(DaDbContext db, string sql) => AiDbUtil.GetDataTable(db.Session, sql);

        /// <summary>
        /// SQL及びパラメータ設定によるデータテーブルの取得
        /// 注意：パラメータ名は項目名と一致する。
        /// </summary>
        public static DataTable GetDataTable(DaDbContext db, string sql, Dictionary<string, object?> paraDic) => AiDbUtil.GetDataTable(db.Session, sql, paraDic.Keys.ToArray(), paraDic.Values.ToArray());

        /// <summary>
        /// SQL、パラメータ一覧、値一覧からデータテーブルを取得
        /// </summary>
        public static DataTable GetDataTable(DaDbContext db, string sql, string[] paraNames, object[] paraValues) => AiDbUtil.GetDataTable(db.Session, sql, paraNames, paraValues);

        /// <summary>
        /// SQLの実行。
        /// </summary>
        public static int RunSql(DaDbContext db, string sql) => AiDbUtil.RunSql(db.Session, sql);

        /// <summary>
        /// パラメータ指定でSQLを実行する
        /// </summary>
        public static int RunSql(DaDbContext db, string sql, Dictionary<string, object> paraDic) => AiDbUtil.RunSql(db.Session, sql, paraDic.Keys.ToArray(), paraDic.Values.ToArray());

        /// <summary>
        /// パラメータ名、値を指定して、SQLを実行する
        /// </summary>
        public static int RunSql(DaDbContext db, string sql, string[] paraNames, object[] paraValues) => AiDbUtil.RunSql(db.Session, sql, paraNames, paraValues);


        /// <summary>
        /// 複数関数結果の取得
        /// </summary>
        public static List<object?> GetProcedureValueList(DaDbContext db, List<ProcModel> procList)
        {
            if (procList.Count() == 0) return new List<object?>();
            var sqls = new List<string>();
            foreach (ProcModel model in procList)
            {
                var helper = new AiProcedureHelper(db.Session, model.ProcName);
                foreach (var value in model.ParamList)
                {
                    helper.AddParameterWithValue(value);
                }

                var sql = helper.GetExecuteSQL();
                sqls.Add(sql);
            }
            var s = string.Join(";", sqls);
            return db.Session.GetValueList(s);
        }

        /// <summary>
        /// プロシージャ関数を実行する。Valueを返す
        /// </summary>
        public static object? GetProcedureValue(DaDbContext db, string procName, params object[] param)
        {
            var list = new List<object?>();
            foreach (var p in param)
            {
                list.Add(p);
            }
            return GetProcedureValue(db, procName, list);
        }

        /// <summary>
        /// プロシージャ関数を実行する。Valueを返す
        /// </summary>
        public static object? GetProcedureValue(DaDbContext db, string procName, List<AiKeyValue>? param = null)
        {
            var list = new List<object?>();
            if (param != null)
            {
                foreach (var de in param)
                {
                    list.Add(de.Value);
                }
            }
            return GetProcedureValue(db, procName, list);
        }

        /// <summary>
        /// プロシージャ関数を実行する。Valueを返す
        /// </summary>
        public static object? GetProcedureValue(DaDbContext db, string procName, List<object?> param)
        {
            var helper = new AiProcedureHelper(db.Session, procName);
            if (param != null)
            {
                foreach (var value in param)
                {
                    helper.AddParameterWithValue(value);
                }
            }
            helper.Execute();
            if (helper.DataTable.Rows.Count > 0)
            {
                return helper.DataTable.Rows[0][0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// プロシージャ関数を実行する。結果はDataTableで返す
        /// </summary>
        public static DataTable GetProcedureData(DaDbContext db, string procName, List<object?> param)
        {
            var helper = new AiProcedureHelper(db.Session, procName);
            if (param != null)
            {
                foreach (var value in param)
                {
                    helper.AddParameterWithValue(value);
                }
            }
            helper.Execute();
            return helper.DataTable;
        }

        /// <summary>
        /// プロシージャ関数を実行する。結果はDataTableで返す
        /// </summary>
        public static DataTable GetProcedureData(DaDbContext db, string procName, List<AiKeyValue>? param = null)
        {
            var helper = new AiProcedureHelper(db.Session, procName);
            if (param != null)
            {
                foreach (var de in param)
                {
                    helper.AddParameter(de.Key, de.Value);
                }
            }
            helper.Execute();
            return helper.DataTable;
        }

        /// <summary>
        /// ストアドプロシージャを実行する
        /// </summary>
        public static void RunProcedure(DaDbContext db, string procName, List<AiKeyValue> paraList)
        {
            var helper = new AiProcedureHelper(db.Session, procName);
            foreach (var de in paraList)
            {
                helper.AddParameter(de.Key, de.Value);
            }
            helper.Execute();
        }

        /// <summary>
        /// 検索画面の条件とページを指定して、データを取得
        /// </summary>
        public static DaPageListModel GetListData(DaDbContext db, string procName, List<AiKeyValue> param, int pageNum = 1, int pageSize = 10, int? orderby = null)
        {
            DaPageListModel data = new();

            var helperH = new AiProcedureHelper(db.Session, $"{procName}_head");
            foreach (var de in param)
            {
                helperH.AddParameter(de.Key, de.Value);
            }

            helperH.Execute();

            data.TotalCount = (int)helperH.DataTable.Rows[0][0];

            if (data.TotalCount > 0)
            {
                var helperB = new AiProcedureHelper(db.Session, $"{procName}_body");
                foreach (var de in param)
                {
                    helperB.AddParameter(de.Key, de.Value);
                }
                //並び順
                if (orderby != null)
                {
                    helperB.AddParameter(DaConst.PAGE_PARAM_ORDER_BY, orderby);
                }
                helperB.AddParameter(DaConst.PAGE_PARAM_LIMIT, pageSize);

                // 総ページ数を計算する
                int TotalPages = (data.TotalCount + pageSize - 1) / pageSize;

                // 総ページ数が現在のページ番号より少ない場合、現在のページ番号を1に設定する
                if (TotalPages < pageNum)
                {
                    pageNum = 1;
                }

                pageNum = pageNum > 0 ? pageNum : 1;
                helperB.AddParameter(DaConst.PAGE_PARAM_OFFSET, pageSize * (pageNum - 1));
                helperB.Execute();
                data.dataTable = helperB.DataTable;
            }
            return data;
        }

        /// <summary>
        /// バルクインサート（ログ処理に使用）
        /// </summary>
        internal static void BulkInsert(AiSessionContext session, DataTable dt, string tableName, bool hasIdentity)
        {
            if (dt.Rows.Count == 0) return;
            try
            {
                var _conn = (NpgsqlConnection)session.Connection!;
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }
                var fields = AiGlobal.DbInfoProvider.GetTableInfo(session, tableName).FieldList;

                var sql = $"COPY {tableName} FROM STDIN (FORMAT BINARY)";
                if (hasIdentity)
                {
                    var idname = tableName switch
                    {
                        tt_aflogDto.TABLE_NAME => nameof(tt_aflogDto.sessionseq),
                        tt_aflogdbDto.TABLE_NAME => nameof(tt_aflogdbDto.dblogseq),
                        tt_aflogcolumnDto.TABLE_NAME => nameof(tt_aflogcolumnDto.columnlogseq),
                        _ => fields.Find(x => x.isIdentity)!.FieldName
                    };

                    fields = fields.Where(f => !f.isIdentity).ToList();
                    dt.Columns.Remove(idname);
                    var columnNames = string.Join(',', dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName));
                    sql = $"COPY {tableName} ({columnNames}) FROM STDIN (FORMAT BINARY)";
                }

                //if (true)
                //{
                using var writer = _conn.BeginBinaryImport(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    writer.StartRow();

                    var i = 0;
                    foreach (var itemData in dr.ItemArray)
                    {
                        var itemInfo = fields[i++];
                        var itemType = (NpgsqlDbType)itemInfo.DbType;
                        writer.Write(itemData, itemType);
                    }
                }
                writer.Complete();

                //}
                //else
                //{
                //    var startTime = DaUtil.Now;
                //    var namelist = new List<string>();
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        namelist.Add(col.ColumnName);
                //    }
                //    sql = $"COPY {tableName} FROM STDIN WITH CSV";
                //    int n = dt.Columns.Count;
                //    using (var writer = _conn.BeginTextImport(sql))
                //    {
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //            var lst = new List<string>();
                //            for (int i = 0; i < n; i++)
                //            {
                //                var t = dt.Columns[i].DataType;
                //                string value = string.Empty;
                //                if (dr[i] is DBNull)
                //                {
                //                    lst.Add("");
                //                }
                //                else
                //                {
                //                    switch (t)
                //                    {
                //                        case var @case when @case == typeof(string):
                //                            {
                //                                lst.Add($"\"{dr[i]}\"");
                //                                break;
                //                            }

                //                        case var @case when @case == typeof(DateTime):
                //                            {
                //                                string s1 = ((DateTime)(dr[i])).ToString("yyyy-MM-dd HH:mm:ss.fff");
                //                                lst.Add(s1);
                //                                break;
                //                            }


                //                        default:
                //                            {
                //                                lst.Add($"{dr[i]}");
                //                                break;
                //                            }
                //                    }
                //                }
                //            }
                //            string s = string.Join(",", lst);
                //            writer.WriteLine(s);
                //        }
                //    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //public static int AdapterFill(IDbDataAdapter adapter, DataTable dt, string sql, AiSessionContext session)
        //{
        //    NpgsqlDataAdapter _adapter = (NpgsqlDataAdapter)adapter;
        //    try
        //    {
        //        var startTime = DaUtil.Now;

        //        int ret = _adapter.Fill(dt);

        //        return ret;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}