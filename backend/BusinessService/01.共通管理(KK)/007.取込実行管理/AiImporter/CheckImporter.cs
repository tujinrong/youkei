// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　ファイルデータからインポート
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using AIplus.AiImporter;
using BCC.Affect.Service.CheckImporter.Define.File;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter
{
    public static class CheckImporter
    {
        /// <summary>
        /// ファイルデータからインポート
        /// </summary>
        public static ImCheckResult ImportFromFile(DaDbContext db, DataTable data, ImDef def, ImCheckOption option, List<ImFileErrorRow>? errList)
        {
            var count = data.Rows.Count;
            List<DataTable> dataList = ImDBUtil.GetDataList(data, 1000);
            data = new DataTable();

            //ファイルデータのチェック
            var ret = CheckFileData(db, dataList, count, def, option);
            if (errList != null)
            {
                ret.FileErrorList.AddRange(errList);
            }
            if (!ret.Success || ret.FileErrorList.Count > 0) return ret;

            //編集データエラーリスト
            var rowErrorList = new List<ImEditErrorRow>();

            //ファイルから画面データに変換
            ret = Translate(db, dataList, count, def, option, ref rowErrorList);
            if (!ret.Success) return ret;
            dataList = new List<DataTable>();

            //ファイル取込自動チェックの場合
            option.IsAutoCheckFlg = true;

            //画面データのチェック
            ret = CheckEditData(db, ret.Data, def, option, rowErrorList, errList);

            return ret;
        }

        /// <summary>
        /// ファイルデータのチェック
        /// </summary>
        public static ImCheckResult CheckFileData(DaDbContext db, List<DataTable> dataList, int count, ImDef def, ImCheckOption option)
        {
            var result = new ImCheckResult(DaConst.MAX_ERRORS);
            try
            {
                var total = 0;
                foreach (var data in dataList)
                {
                    //ファイルチェック前フォーマット関数からデータを取得する
                    Dictionary<string, List<FileFormatDataModel>> itemsFormatResultDic = GetFileDataFormatResult(db, data, def);

                    int rowIndex = 0;
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (var item in def.FileColumns)
                        {
                            if (item.Check(db, row, rowIndex, option, itemsFormatResultDic, out ImFileErrorRow? error) == false)
                            {
                                result.AddFileError(error!);
                            }
                        }
                        rowIndex++;
                        total++;

                        //※プログレスバーをセットする
                        var process = 5 + (int)(CDec(total) / count * 90);
                        AiProgress.SetProgress(option.ProcessKey, ImportProcess.FileCheck, process);
                    }
                }

                //※プログレスバーをセットする
                AiProgress.SetProgress(option.ProcessKey, ImportProcess.FileCheck, 100);
            }
            catch (ImErrorOverExcetion ex)
            {
                result.ErrMsg = ex.Message;
                result.Success = false;
            }

            return result;
        }

        /// <summary>
        /// ファイルから画面データに変換
        /// </summary>
        public static ImCheckResult Translate(DaDbContext db, List<DataTable> dataList, int count, ImDef def, ImCheckOption option, ref List<ImEditErrorRow> rowErrorList)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(option.ProcessKey, ImportProcess.MappingCheck, 0);

            var result = new ImCheckResult(DaConst.MAX_ERRORS);
            try
            {
                //ColumnからDataTableを取得
                var dt = AITransferDef.GetDataTable(def.TransferColumns);
                //データID
                int dataseq = 0;
                var total = 0;
                foreach (var data in dataList)
                {
                    Dictionary<int, List<object?>> itemsResultDic = GetTranslateData(db, data, def);

                    for (int rowIndex = 0; rowIndex < data.Rows.Count; rowIndex++)
                    {
                        var dr = dt.NewRow();
                        DataRow row = data.Rows[rowIndex];
                        //行番号
                        int rowNo = CInt(row["RowNo"]);
                        dr["RowNo"] = rowNo;
                        foreach (var col in def.TransferColumns)
                        {
                            dataseq++;
                            //マッピング処理
                            var value = col.Translate(db, row, rowIndex, dataseq, itemsResultDic, out ImEditErrorRow? error);
                            if (error != null)
                            {
                                rowErrorList.Add(error);
                                result.AddEditError(error);
                            }
                            dr["Column" + col.pageitemseq] = value;
                        }
                        dt.Rows.Add(dr);
                        total++;

                        //※プログレスバーをセットする
                        var process = (int)(CDec(total) / count * 95);
                        AiProgress.SetProgress(option.ProcessKey, ImportProcess.MappingCheck, process);
                    }
                }
                result.Data = dt;

                //※プログレスバーをセットする
                AiProgress.SetProgress(option.ProcessKey, ImportProcess.MappingCheck, 100);
            }
            catch (ImErrorOverExcetion ex)
            {
                result.Success = false;
                result.ErrMsg = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// データのチェック
        /// </summary>
        public static ImCheckResult CheckEditData(DaDbContext db, DataTable data, ImDef def, ImCheckOption option, List<ImFileErrorRow>? errList)
        {
            //編集データエラーリスト
            var rowErrorList = new List<ImEditErrorRow>();
            //データのチェック
            return CheckEditData(db, data, def, option, rowErrorList, errList);
        }

        /// <summary>
        /// データのチェック
        /// </summary>
        public static ImCheckResult CheckEditData(DaDbContext db, DataTable dt, ImDef def, ImCheckOption option, List<ImEditErrorRow> rowTransferErrorList, List<ImFileErrorRow>? errList)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(option.ProcessKey, ImportProcess.PageItemCheck, 0);

            var result = new ImCheckResult(DaConst.MAX_ERRORS);

            try
            {
                //DB取込対象テーブルデータを取得する
                var aiImpTableInfoDic = GetDBImpTableInfoList(db, option.TableidList);

                //部署（支所）コードリスト
                var sisyocdList = GetSisyocdList(db, option.regupdkbn);

                List<DataTable> dataList = ImDBUtil.GetDataList(dt, 1000);


                //データID
                int dataseq = 0;
                //一意データ
                var uniqueDic = new Dictionary<int, HashSet<string>>();
                var total = 0;
                var count = dt.Rows.Count;
                foreach (var data in dataList)
                {
                    //チェック前参照テーブルデータ
                    var mstDic = new Dictionary<string, List<string>>();
                    //チェック前存在テーブルデータ
                    var sansoDic = new Dictionary<string, List<SearchDataModel>>();

                    //チェック前参照存在データを取得する
                    GetCheckBeforeData(db.Session, data, def, option, ref mstDic, ref sansoDic);

                    var unitCheckDataDic = new Dictionary<int, bool>();
                    if (option.regupdkbn.Equals(EnumToStr(Enum登録区分.更新)))
                    {
                        //更新登録支所権限チェックデータを取得する
                        unitCheckDataDic = GetCheckUnitData(db, data, def, aiImpTableInfoDic, sisyocdList);
                    }

                    for (var rowIndex = 0; rowIndex < data.Rows.Count; rowIndex++)
                    {
                        DataRow row = data.Rows[rowIndex];

                        //項目特定区分-宛名番号
                        string? atenano = null;
                        //項目特定区分-氏名
                        string? shimei = null;
                        var rowErrorList = new List<ImEditErrorRow>();

                        //行番号
                        int rowNo = CInt(row["RowNo"]);

                        //列インデックス
                        int colIndex = 0;
                        foreach (var item in def.EditorColumns)
                        {
                            dataseq++;
                            colIndex++;
                            if (item.Check(db.Session, row, rowNo, dataseq, option, aiImpTableInfoDic, mstDic, sansoDic, out List<ImEditErrorRow> errorList) == false && errorList != null && errorList.Count > 0)
                            {
                                rowErrorList.AddRange(errorList);
                            }
                            else if (item.uniqueflg)//一意
                            {
                                if (!uniqueDic.ContainsKey(item.pageitemseq))
                                {
                                    uniqueDic.Add(item.pageitemseq, new HashSet<string>());
                                }
                                var value = row[item.ColumnName].ToString()!;
                                if (uniqueDic[item.pageitemseq].Contains(value))
                                {
                                    //XXが重複しています。
                                    var error = new ImEditErrorRow(dataseq, rowNo, Enumエラーレベル.エラー, item.itemnm, value, EnumMessage.E001008, $"{item.itemnm}({value})");
                                    rowErrorList.Add(error);
                                }
                                else
                                {
                                    uniqueDic[item.pageitemseq].Add(value);
                                }
                            }

                            //画面項目編集データを取得する
                            result.EditDataList.Add(new ImEditDataRow(dataseq, rowNo, colIndex, item));

                            //項目特定区分
                            if (!string.IsNullOrEmpty(item.itemkbn))
                            {
                                //項目特定区分-宛名番号
                                if (string.IsNullOrEmpty(atenano) && item.itemkbn.Equals(EnumToStr(Enum項目特定区分.宛名番号)))
                                {
                                    atenano = item.Val;
                                }
                                //項目特定区分-氏名
                                if (string.IsNullOrEmpty(shimei) && item.itemkbn.Equals(EnumToStr(Enum項目特定区分.氏名)))
                                {
                                    shimei = item.Val;
                                }
                            }
                        }
                        if (option.IsAutoCheckFlg)
                        {
                            //検診実施機関番号、医療機関コード、医療機関名の特殊処理
                            SetIryokikan(def.EditorColumns, result.EditDataList, option, rowNo, ref rowErrorList, ref errList);
                            //会場コード、会場名の特殊処理
                            SetKaijo(def.EditorColumns, result.EditDataList, option, rowNo);
                        }
                        //登録区分が3（更新）の場合
                        if (rowErrorList.Count == 0 && option.regupdkbn.Equals(EnumToStr(Enum登録区分.更新)) && unitCheckDataDic.Count > 0)
                        {
                            //登録支所権限チェック
                            if (!unitCheckDataDic.ContainsKey(rowIndex) || !unitCheckDataDic[rowIndex])
                            {
                                var err = new ImEditErrorRow(null, rowNo, Enumエラーレベル.エラー, EnumMessage.E004008);
                                rowErrorList.Add(err);
                            }
                        }

                        if (rowTransferErrorList.Count > 0)
                        {
                            var subList = rowTransferErrorList.FindAll(x => x.rowno == rowNo);
                            if (subList.Count > 0)
                            {
                                rowErrorList.AddRange(subList);
                            }
                        }

                        //編集データエラー
                        if (rowErrorList.Count > 0)
                        {
                            foreach (var subError in rowErrorList)
                            {
                                subError.atenano = atenano; //宛名番号
                                subError.shimei = shimei;   //氏名
                                result.AddEditError(subError);
                            }
                        }
                        total++;

                        //※プログレスバーをセットする
                        var process = (int)(CDec(total) / count * 80);
                        AiProgress.SetProgress(option.ProcessKey, ImportProcess.PageItemCheck, process);
                    }
                }
            }
            catch (ImErrorOverExcetion ex)
            {
                result.Success = false;
                result.ErrMsg = ex.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrMsg = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// チェック前参照存在データを取得する
        /// </summary>
        private static void GetCheckBeforeData(AiSessionContext session, DataTable data, ImDef def, ImCheckOption option,
            ref Dictionary<string, List<string>> mstDic, ref Dictionary<string, List<SearchDataModel>> sansoDic)
        {
            foreach (var item in def.EditorColumns)
            {
                //列名(データ元画面項目)
                var columnName = item.ColumnName;

                //存在マスタチェックテーブル
                if (!string.IsNullOrEmpty(item.msttable))
                {
                    //選択フィールド(存在フィールド値)
                    var selfieldids = string.Join(",", new List<string>() { $"{item.mstfield!} {nameof(SearchDataModel.condictionvalue)}", $"{item.mstfield!} {nameof(SearchDataModel.targetvalue)}" });
                    //存在マスタチェックテーブルsqlを取得する
                    var sql = ImDBUtil.GetSql(session, data, columnName, item.msttable, selfieldids, item.mstfield!);
                    if (sql != "")
                    {
                        //存在マスタチェック条件
                        if (!string.IsNullOrEmpty(item.mstjyoken))
                        {
                            sql += $" and {item.mstjyoken} ";
                        }
                        //存在マスタチェックテーブルデータを取得する
                        List<SearchDataModel> dataList = session.Query<SearchDataModel>(sql);
                        List<string> mstFieldValueList = dataList.Select(e => e.targetvalue).ToList();
                        //存在マスタチェックデータを取得する(存在フィールド値)
                        mstDic.Add(columnName, mstFieldValueList);
                    }
                }
                if (item.inputkbn.Equals(EnumToStr(Enum入力区分.マスタ参照)) && option.IsAutoCheckFlg)
                {
                    //参照元フィールド値
                    var fromfieldid = item.fromfieldid!;
                    //選択フィールド（参照元フィールド値,取得先フィールド値）
                    var targetfieldid = item.itemkbn == EnumToStr(Enum項目特定区分.生年月日) ? $"fn_eugetbymd_wareki({fromfieldid})" : item.targetfieldid!;
                    var selfieldids = string.Join(",", new List<string>() { $"{fromfieldid} {nameof(SearchDataModel.condictionvalue)}", $"{targetfieldid} {nameof(SearchDataModel.targetvalue)}" });
                    //参照マスタチェックテーブルsqlを取得する
                    var sql = ImDBUtil.GetSql(session, data, "Column" + item.fromitemseq, item.inputtype, selfieldids, fromfieldid);

                    if (sql != "")
                    {
                        //参照マスタチェックテーブルデータを取得する
                        List<SearchDataModel> dataList = session.Query<SearchDataModel>(sql);
                        //参照マスタチェックデータを取得する（参照元フィールド値と取得先フィールド値）
                        sansoDic.Add(columnName, dataList);
                    }
                }
            }
        }



        /// <summary>
        /// DB取込対象テーブルデータを取得する
        /// </summary>
        private static Dictionary<string, AiTableInfo> GetDBImpTableInfoList(DaDbContext db, List<string> tableidList)
        {
            //DBテーブルデータ
            var aiTableInfoDic = new Dictionary<string, AiTableInfo>();
            foreach (string tableid in tableidList)
            {
                AiTableInfo aiTableInfo = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, tableid);
                aiTableInfoDic.Add(tableid, aiTableInfo);
            }
            return aiTableInfoDic;
        }

        /// <summary>
        /// ログインユーザーの更新権限支所情報を取得する
        /// </summary>
        private static List<string> GetSisyocdList(DaDbContext db, string regupdkbn)
        {
            var sisyocdList = new List<string>();
            if (regupdkbn.Equals(EnumToStr(Enum登録区分.更新)))
            {
                //ログインユーザーの更新権限支所情報
                var dtl = db.tt_afauthsisyo.SELECT.WHERE.ByItem(nameof(tt_afauthsisyoDto.roleid), db.Session.UserID!).GetDtoList();
                sisyocdList = dtl.Select(e => e.sisyocd).ToList();
            }
            return sisyocdList;
        }

        /// <summary>
        /// 更新登録支所権限チェックデータを取得
        /// </summary>
        private static Dictionary<int, bool> GetCheckUnitData(DaDbContext db, DataTable data, ImDef def,
                                                Dictionary<string, AiTableInfo> aiImpTableInfoDic, List<string> sisyocdList)
        {
            //登録支所フィールドあり？
            var tableidList = aiImpTableInfoDic.Where(kv => kv.Value.FieldList.Exists(e => e.FieldName == AiGlobal.CreateUnitName))
                              .Select(kvp => kvp.Key).ToList();
            if (tableidList.Count == 0)
            {
                return new Dictionary<int, bool>();
            }

            //検索用キーフィールド
            var keysSelDic = new Dictionary<string, List<object[]>>();
            //キーフィールド
            var keysDic = new Dictionary<string, List<string>>();
            foreach (DataRow row in data.Rows)
            {
                foreach (var tableid in tableidList)
                {
                    //登録支所取得キーフィールド
                    var keyFeilds = aiImpTableInfoDic[tableid].KeyList;
                    var paraValues = new List<object>();
                    foreach (var key in keyFeilds)
                    {
                        var detail = def.InsertDetails.Find(e => e.Tableid == tableid && e.FieldId == key.FieldName);
                        if (detail != null)
                        {
                            var value = GetUpdateKeyValue(detail, row);
                            paraValues.Add(value);
                        }
                    }
                    //検索用キーフィールド
                    if (!keysSelDic.ContainsKey(tableid))
                    {
                        keysSelDic.Add(tableid, new List<object[]>());
                    }
                    keysSelDic[tableid].Add(paraValues.ToArray());

                    //キーフィールド
                    if (!keysDic.ContainsKey(tableid))
                    {
                        keysDic.Add(tableid, new List<string>());
                    }
                    keysDic[tableid].Add(string.Join('-', paraValues));
                }
            }

            //該当テーブルの全て登録支所データ
            var tableUnitDic = new Dictionary<string, Dictionary<string, string>>();
            foreach (var tableid in tableidList)
            {
                var unitDic = new Dictionary<string, string>();
                //キーフィールド
                var keyFeilds = aiImpTableInfoDic[tableid].KeyList.Select(e => e.FieldName).ToArray();
                //検索用キーフィールドから該当テーブルの全て登録支所データを取得
                var dt = AiTempTableUtil.GetDataTable(db.Session, tableid, keyFeilds, keysSelDic[tableid], keyFeilds.Length);

                foreach (DataRow dr in dt.Rows)
                {
                    var keyValueList = new List<string>();
                    foreach (var key in keyFeilds)
                    {
                        keyValueList.Add(CStr(dr[key]));
                    }
                    //キー値
                    var keys = string.Join("-", keyValueList);
                    //登録支所値
                    var unit = CStr(dr[AiGlobal.CreateUnitName]);
                    if (!unitDic.ContainsKey(keys))
                    {
                        unitDic.Add(keys, unit);
                    }
                }
                //該当テーブルの全て登録支所データを追加
                tableUnitDic.Add(tableid, unitDic);
            }

            //登録支所権限チェック
            var resultDic = new Dictionary<int, bool>();
            for (int rowIndex = 0; rowIndex < data.Rows.Count; rowIndex++)
            {
                resultDic.Add(rowIndex, true);
                foreach (var tableid in tableidList)
                {
                    //該当テーブルの全て登録支所データ
                    var unitDic = tableUnitDic[tableid];
                    //キー値
                    var keys = keysDic[tableid][rowIndex];
                    if (unitDic.ContainsKey(keys))
                    {
                        //登録支所
                        var regsisyo = unitDic[keys];
                        //登録支所権限ありか
                        if (!sisyocdList.Contains(regsisyo!))
                        {
                            resultDic[rowIndex] = false;
                            break;
                        }
                    }
                    else
                    {
                        resultDic[rowIndex] = false;
                        break;
                    }
                }
            }
            return resultDic;
        }

        /// <summary>
        /// 更新キー値を取得
        /// </summary>
        private static object GetUpdateKeyValue(ImInsertDetailDef detail, DataRow row)
        {
            switch (ParseEnum<Enum処理区分>(detail.Syorikbn))
            {
                case Enum処理区分.画面項目登録:
                    //画面項目登録
                    return row[detail.ColumnName];
                case Enum処理区分.固定値登録:
                    //固定値登録
                    return detail.Koteiti!;
                case Enum処理区分.自動:
                    //自動DB固定値
                    if (detail.DBKoteiti == null)
                    {
                        throw new Exception("更新キー設定不正");
                    }
                    return detail.DBKoteiti!;
                default:
                    throw new Exception("更新キー設定不正");
            }
        }

        /// <summary>
        /// マッピングチェック前関数からデータを取得する
        /// </summary>
        private static Dictionary<int, List<object?>> GetTranslateData(DaDbContext db, DataTable fileDt, ImDef def)
        {
            //各項目マッピング結果
            var itemsResultDic = new Dictionary<int, List<object?>>();

            //宛名番号各項目マッピング情報
            Dictionary<int, object[]> atenanoItemsInfoDic = GetItemsInfo(db, def, EnumToStr(Enumマッピング方法.宛名番号取得));
            List<int> atenanoList = atenanoItemsInfoDic.Keys.ToList();
            //医療機関コード各項目マッピング情報
            Dictionary<int, object[]> kikanItemsInfoDic = GetItemsInfo(db, def, EnumToStr(Enumマッピング方法.医療機関コード取得));
            //年度各項目マッピング情報
            Dictionary<int, object[]> nendoItemsInfoDic = GetItemsInfo(db, def, EnumToStr(Enumマッピング方法.年度取得));

            //各項目マッピング情報
            Dictionary<int, object[]> itemsInfoDic = atenanoItemsInfoDic.Concat(kikanItemsInfoDic).Concat(nendoItemsInfoDic).ToDictionary(pair => pair.Key, pair => pair.Value);
            if (itemsInfoDic.Count == 0)
            {
                return itemsResultDic;
            }

            //各項目の毎行パラメータSql
            var itemsValueSqlDic = new Dictionary<int, List<string>>();
            for (int rowIndex = 0; rowIndex < fileDt.Rows.Count; rowIndex++)
            {
                DataRow row = fileDt.Rows[rowIndex];

                //各項目の毎行パラメータSql
                AddItemsValueSqlDic(row, itemsInfoDic, atenanoList, nendoItemsInfoDic, ref itemsValueSqlDic);
            }

            //各関数で各項目データを取得する
            foreach (var itemseq in itemsValueSqlDic.Keys)
            {
                //全て行のパラメータsql
                var sqlList = itemsValueSqlDic[itemseq];
                //全てsql
                var strSql = string.Join(";", sqlList);
                //結果リストに格納
                List<object?> resultList = db.Session.GetAllValueList(strSql);

                //各項目のデータを追加
                itemsResultDic.Add(itemseq, resultList);
            }

            return itemsResultDic;
        }

        /// <summary>
        /// 各項目の毎行パラメータsqlを追加
        /// </summary>
        private static void AddItemsValueSqlDic(DataRow row, Dictionary<int, object[]> itemsInfoDic, List<int> atenanoList, Dictionary<int, object[]> nendoItemsInfoDic, ref Dictionary<int, List<string>> itemsValueSqlDic)
        {
            //年度取得
            var nendoList = nendoItemsInfoDic.Keys.ToList();
            foreach (var itemseq in itemsInfoDic.Keys)
            {
                //毎行パラメータデータ
                var valueList = new List<string>();
                //関数名
                var procName = (string)itemsInfoDic[itemseq][0];
                //ファイル項目ID　or 固定値
                var fileitemseqList = (List<string>)itemsInfoDic[itemseq][1];
                foreach (string name in fileitemseqList)
                {
                    //固定値をセット
                    if (name.Contains('\''))
                    {
                        valueList.Add(name.Replace("'", ""));
                    }
                    //ファイル項目をセット
                    else
                    {
                        valueList.Add(CStr(row[name]));
                    }
                }

                //宛名番号取得の場合
                if (atenanoList.Contains(itemseq))
                {
                    //氏名カナ清音化なと処理
                    valueList[0] = CmConerterBase.ToKnameLikeStr(CStr(valueList[0]))!;
                }

                //毎行パラメータデータ
                valueList = valueList.Select(s => $"'{s}'").ToList();
                var strValue = string.Join(",", valueList);
                //パラメータsql
                var sql = $"SELECT {procName}({strValue})";

                if (!itemsValueSqlDic.ContainsKey(itemseq))
                {
                    itemsValueSqlDic.Add(itemseq, new List<string>());
                }
                //各項目の毎行パラメータsqlを追加
                itemsValueSqlDic[itemseq].Add(sql);
            }
        }

        /// <summary>
        /// 各項目マッピング情報を取得する
        /// </summary>
        private static Dictionary<int, object[]> GetItemsInfo(DaDbContext db, ImDef def, string mappingmethod)
        {
            //各項目マッピング情報
            var itemsInfoDic = new Dictionary<int, object[]>();

            var itemList = def.TransferColumns.Where(e => e.mappingkbn == EnumToStr(Enumマッピング区分.関数) && e.mappingmethod == mappingmethod).ToList();
            if (itemList != null && itemList.Count > 0)
            {
                foreach (var item in itemList)
                {
                    //関数名
                    var procName = DaNameService.GetKanaName(db, EnumNmKbn.マッピング方法, item.mappingmethod!);
                    //ファイル項目ID
                    var fileitemseqList = new List<string>(item.fileitemseq!.Split(","));

                    itemsInfoDic.Add(item.pageitemseq, new object[] { procName, fileitemseqList });
                }
            }
            return itemsInfoDic;
        }

        /// <summary>
        /// ファイルチェック前フォーマット関数からデータを取得する
        /// </summary>
        private static Dictionary<string, List<FileFormatDataModel>> GetFileDataFormatResult(DaDbContext db, DataTable fileDt, ImDef def)
        {
            var itemsFormatResultDic = new Dictionary<string, List<FileFormatDataModel>>();

            //フォーマット(９９:その他)項目
            var itemList = def.FileColumns.Where(e => e.format == フォーマット_日付._99).ToList();
            if (itemList.Count == 0)
            {
                return itemsFormatResultDic;
            }

            //各項目の毎行パラメータデータ
            var itemsValuesDic = new Dictionary<string, List<string>>();
            for (int rowIndex = 0; rowIndex < fileDt.Rows.Count; rowIndex++)
            {
                DataRow row = fileDt.Rows[rowIndex];
                foreach (var item in itemList)
                {
                    var itemseq = item.ColumnName;
                    //毎行パラメータデータ
                    var strValue = $"'{CStr(row[itemseq])}'";

                    if (!itemsValuesDic.ContainsKey(itemseq))
                    {
                        itemsValuesDic.Add(itemseq, new List<string>());
                    }
                    //各項目の毎行パラメータデータを追加
                    itemsValuesDic[itemseq].Add(strValue);
                }
            }

            //各関数で各項目データを取得する
            foreach (var item in itemList)
            {
                var itemseq = item.ColumnName;
                //各項目データ
                if (!itemsFormatResultDic.ContainsKey(itemseq))
                {
                    itemsFormatResultDic.Add(itemseq, new List<FileFormatDataModel>());
                }

                //フォーマットチェック関数名
                var procName = DaNameService.GetKanaName(db, EnumNmKbn.フォーマットチェック関数, item.fmtcheck!);
                //全て行のパラメータデータ
                var rowsValueList = itemsValuesDic[itemseq];
                //フォーマットチェック結果を取得する
                var checkResultList = GetAllValueList(db, procName, rowsValueList);

                //各項目のフォーマットチェックデータ
                List<FileFormatDataModel> fileFormatCheckResultList = checkResultList.Select((result, index) =>
                                        new FileFormatDataModel("1", index, CStr(result)))
                                        .ToList();

                //各項目のフォーマットチェックデータを追加
                itemsFormatResultDic[itemseq].AddRange(fileFormatCheckResultList);


                //フォーマットチェックOKの行インデックス
                var changeRowIndexList = GetCheckResultIndexList(checkResultList);


                //フォーマット変換関数名
                procName = DaNameService.GetKanaName(db, EnumNmKbn.フォーマット変換関数, item.fmtcheck!);
                //フォーマットチェックOKの行のパラメータデータ
                rowsValueList = rowsValueList.Where((result, index) => changeRowIndexList.Contains(index)).ToList();
                //フォーマット変換結果を取得する
                var changeResultList = GetAllValueList(db, procName, rowsValueList);

                //各項目のフォーマット変換データ
                List<FileFormatDataModel> fileFormatChangeResultList = changeResultList.Select((result, index) =>
                                        new FileFormatDataModel("2", changeRowIndexList[index], CStr(result)))
                                        .ToList();

                //各項目のフォーマット変換データを追加
                itemsFormatResultDic[itemseq].AddRange(fileFormatChangeResultList);
            }

            return itemsFormatResultDic;
        }

        /// <summary>
        /// フォーマットチェックOKの行インデックスを取得する
        /// </summary>
        private static List<int> GetCheckResultIndexList(List<object?> checkResultList)
        {
            //フォーマットチェックOKの行インデックス
            var changeRowIndexList = new List<int>();
            for (int rowIndex = 0; rowIndex < checkResultList.Count; rowIndex++)
            {
                if (checkResultList[rowIndex] != null)
                {
                    //成功時「00,」で返す、エラー時「10,MSG」で返す
                    var results = CStr(checkResultList[rowIndex]).Split(',');
                    //エラーがない時に設定した関数で変換をして後処理継続
                    if (results.Length > 1 && results[0].Equals("00"))
                    {
                        changeRowIndexList.Add(rowIndex);
                    }
                }
            }
            return changeRowIndexList;
        }

        /// <summary>
        /// 全て結果リストを取得する
        /// </summary>
        private static List<object?> GetAllValueList(DaDbContext db, string procName, List<string> rowsValueList)
        {
            //sqlリスト
            var sqlList = new List<string>();
            foreach (var value in rowsValueList)
            {
                var sql = $"SELECT {procName}({value})";
                sqlList.Add(sql);
            }

            //全てsql
            var sqls = string.Join(";", sqlList);
            //結果リストに格納
            List<object?> resultList = db.Session.GetAllValueList(sqls);
            return resultList;
        }

        /// <summary>
        /// 検診実施機関番号、医療機関コード、医療機関名の特殊処理
        /// </summary>
        /// <param name="editorColumns"></param>
        /// <param name="option"></param>
        private static void SetIryokikan(List<ImEditorColumnDef> editorColumns, List<ImEditDataRow> editDataList, ImCheckOption option, int rowNo, ref List<ImEditErrorRow> rowErrorList, ref List<ImFileErrorRow>? errList)
        {
            var bangoItem = editorColumns.Find(e => e.itemkbn == EnumToStr(Enum項目特定区分.検診実施機関番号));
            var cdItem = editorColumns.Find(e => e.itemkbn == EnumToStr(Enum項目特定区分.医療機関コード));
            var nmItem = editorColumns.Find(e => e.itemkbn == EnumToStr(Enum項目特定区分.医療機関名));

            if (bangoItem != null && cdItem != null && nmItem != null)
            {
                var bangoData = editDataList.Find(e => e.pageitemseq == bangoItem.pageitemseq && e.rowno == rowNo)!;
                var cdData = editDataList.Find(e => e.pageitemseq == cdItem.pageitemseq && e.rowno == rowNo)!;
                var nmData = editDataList.Find(e => e.pageitemseq == nmItem.pageitemseq && e.rowno == rowNo)!;
                if (!string.IsNullOrEmpty(bangoData.val))
                {
                    if (option.kikanDic.TryGetValue(bangoData.val, out var value))
                    {
                        cdData.val = value;
                    }
                    else
                    {
                        //TODO(まだ確認)
                        var err = new ImEditErrorRow(null, rowNo, Enumエラーレベル.エラー, bangoData.itemnm, bangoData.val, EnumMessage.ITEM_ILLEGAL_ALERT, $"{bangoData.itemnm}");
                        rowErrorList.Add(err);
                    }
                    nmData.val = string.Empty;
                }
                else if (!string.IsNullOrEmpty(nmData.val))
                {
                    //関数名
                    var nm = "fn_kkgetothersiryokikan";
                    var resList = option.kansuDic[nm];
                    cdData.val = CStr(resList[0]);
                }
                else
                {
                    errList ??= new List<ImFileErrorRow> { };
                    //検診実施機関番号と医療機関名が空白の場合、エラーチェック 
                    var err = new ImFileErrorRow(rowNo, "検診実施機関番号と医療機関名", "", EnumMessage.ITEM_REQUIRE_ERROR, $"「{bangoData.itemnm}」または「{nmData.itemnm}」");
                    errList.Add(err);
                }
            }
            //医療機関コードの必須チェック？（TODO高？）
        }

        /// <summary>
        /// 会場コード、会場名の特殊処理
        /// </summary>
        /// <param name="editorColumns"></param>
        private static void SetKaijo(List<ImEditorColumnDef> editorColumns, List<ImEditDataRow> editDataList, ImCheckOption option, int rowNo)
        {
            var cdItem = editorColumns.Find(e => e.itemkbn == EnumToStr(Enum項目特定区分.会場コード));
            var nmItem = editorColumns.Find(e => e.itemkbn == EnumToStr(Enum項目特定区分.会場名));
            if (cdItem != null && nmItem != null)
            {
                var cdData = editDataList.Find(e => e.pageitemseq == cdItem.pageitemseq && e.rowno == rowNo)!;
                var nmData = editDataList.Find(e => e.pageitemseq == nmItem.pageitemseq && e.rowno == rowNo)!;
                if (!string.IsNullOrEmpty(cdData.val))
                {
                    nmData.val = string.Empty;
                }
                else if (!string.IsNullOrEmpty(nmData.val))
                {
                    //関数名
                    var nm = "fn_kkgetotherskaijyo";
                    var resList = option.kansuDic[nm];
                    cdData.val = CStr(resList[0]);
                }
            }
        }
    }
}