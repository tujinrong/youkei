// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: EUC帳票ロジック処理
//　　　　　　　Private関数
// 作成日　　: 2024.07.07
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************

using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Interface;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDef;
using AIplus.AiReport.ReportDef.SheetDefs;
using AIplus.AiReport.ReportDef.SheetDefs.Base;
using NPOI.Util;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{

    public static partial class DaEucService
    {
        /// <summary>
        /// 対象外者一覧
        /// </summary>
        public static List<DaTaishogaiModel> GetTasyogaiList(DaDbContext db, string tokenID,
                    string rptID, string yosikiID,
                    Dictionary<string, object> searchDic, Dictionary<string, object> detailSearchDic)
        {
            //①発行履歴管理帳票の場合、帳票抽出対象テーブルに存在する宛名番号は前提条件とする。										
            //②警告内容
            //宛名テーブルに「支援措置区分」が空白以外のものは対象とする。								
            //③帳票発行対象外
            //「帳票発行対象外者テーブル」に「帳票グループID」＝該当帳票の帳票グループID のデータは対象とする。（受付日条件は必要？）								

            return new List<DaTaishogaiModel>();
        }



        /// <summary>
        /// 固定帳票サブ情報設定
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="subSheet"></param>
        /// <param name="engine"></param>
        /// <param name="excel"></param>
        private static void SetSubSheetInfo(ref ArSheetDef sheet, ref IArSubSheetDef subSheet, IArEngine engine, string excel)
        {
            // Sheet定義
            sheet.IsLandscape = true;
            sheet.TemplateFullPath = excel;
            sheet.ReportName = Path.GetFileNameWithoutExtension(excel);
            sheet.SheetName = AiReport.GetSheetName(sheet.TemplateFullPath);
            subSheet.Name = sheet.SheetName;
            var subSheetBase = (ArSheetDefBase)subSheet;
            subSheetBase.IsMain = true;
            sheet.SubSheetDefs.Add(subSheet);
            subSheet.Engine = engine;

            // Select項目
            engine.ItemDefs = new List<ArItemDef>();

            // テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
        }

        /// <summary>
        /// 帳票出力履歴テーブルに情報登録
        /// </summary>
        /// <param name="db"></param>
        /// <param name="rptID"></param>
        /// <param name="yosikiID"></param>
        /// <param name="reportType"></param>
        /// <param name="searchDic"></param>
        /// <param name="memo"></param>
        /// <param name="sessionseq"></param>
        /// <param name="reguserid"></param>
        /// <param name="result"></param>
        /// <param name="syoridttmf"></param>
        /// <param name="syoridttmt"></param>
        private static void OutPutHistoryInfo(DaDbContext db, string rptID, string yosikiID, EnumReportType reportType, Dictionary<string, object> searchDic,
            string memo, string sessionseq, string reguserid, AIplus.AiReport.Common.ArResult result, DateTime syoridttmf, DateTime syoridttmt, Dictionary<string, object> outputInfoDic)
        {

            // 帳票出力履歴テーブルに登録
            if (reportType.Equals(EnumReportType.PDF) || reportType.Equals(EnumReportType.EXCEL) || reportType.Equals(EnumReportType.CSV))
            {
                // EUC帳票出力履歴テーブルに出力
                var rirekidto = new tt_eurirekiDto();
                // 帳票ID
                rirekidto.rptid = rptID;
                rirekidto.yosikiid = yosikiID;
                rirekidto.outputkbn = (Enum出力方式)reportType;
                rirekidto.memo = memo;
                if (outputInfoDic.Count > 0 && outputInfoDic.TryGetValue(DaEucService.CONDITION_FILE_NM, out object fileNmValue))
                {
                    string fileNm = fileNmValue.ToString();
                    if (!string.IsNullOrEmpty(fileNm))
                    {
                        rirekidto.filenm = fileNm;
                    }
                }
                rirekidto.jyotaikbn = Enum履歴出力状態区分.処理完了;
                rirekidto.num = result.DataCount;
                rirekidto.syoridttmf = syoridttmf;
                rirekidto.syoridttmt = syoridttmt;
                rirekidto.milisec = (int)(syoridttmt - syoridttmf).TotalMilliseconds;
                rirekidto.filedata = result.FileData;
                rirekidto.reguserid = reguserid;
                rirekidto.regdttm = syoridttmt;
                rirekidto.upduserid = reguserid;
                rirekidto.upddttm = syoridttmt;
                db.tt_eurireki.INSERT.Execute(rirekidto);

                // EUC帳票出力履歴条件に出力
                var rirekiseq = rirekidto.rirekiseq;
                var index = 0;
                var strValue = new StringBuilder();
                foreach (var r in searchDic)
                {
                    index++;
                    strValue.Length = 0;
                    var jyokendto = new tt_eurirekijyokenDto();
                    jyokendto.rirekiseq = rirekiseq;
                    jyokendto.jyokenseq = index;
                    jyokendto.jyokenlabel = r.Key;
                    if (r.Value.GetType() == typeof(ArPair))
                    {
                        strValue.Append(((ArPair)r.Value).First);
                        strValue.Append(",");
                        strValue.Append(((ArPair)r.Value).Second);
                    }
                    else if (r.Value is List<object>)
                    {
                        for (int mindex = 0; mindex < ((List<Object>)r.Value).Count; mindex++)
                        {
                            strValue.Append(((List<Object>)r.Value)[mindex]);
                            if (mindex < ((List<Object>)r.Value).Count - 1)
                            {
                                strValue.Append(",");
                            }
                        }
                    }
                    else if (r.Value.GetType().IsArray)
                    {
                        for (int mindex = 0; mindex < ((object[])r.Value).Length; mindex++)
                        {
                            strValue.Append(((object[])r.Value)[mindex]);
                            if (mindex < ((object[])r.Value).Length - 1)
                            {
                                strValue.Append(",");
                            }
                        }
                    }
                    else
                    {
                        strValue.Append(r.Value);
                    }
                    jyokendto.value = strValue.ToString()!;
                    db.tt_eurirekijyoken.INSERT.Execute(jyokendto);
                }
            }
        }

        /// <summary>
        /// 宛名番号操作ログテーブルに情報登録
        /// </summary>
        private static void OutPutAtenaOperatedInfo(DaDbContext db, string rptID, string yosikiID, Dictionary<string, object> searchDic, Dictionary<string, object> detailSearchDic, List<string> orderByList,
            string workSeq, string sessionseq, string reguserid, bool pnouseflg, DateTime syoridttmt)
        {
            //シート定義情報
            var sheet = new ArSheetDef();

            //条件情報
            var condition = new ArConditionModel();
            TransData paramData = new TransData(EnumMakeWorkKbn.宛名番号ログ, pnouseflg, long.Parse(sessionseq), reguserid, syoridttmt);

            BundleSheetInfo(db, ref sheet, ref condition, workSeq, rptID, yosikiID, EnumReportType.その他, searchDic, detailSearchDic, orderByList, "", "", "", "", "", false, false, false, paramData);

            // 宛名番号操作ログテーブルに登録
            condition.isDistinct = true;
            condition.PreSql = @"INSERT INTO tt_aflogatena( sessionseq, atenano, pnouseflg, usekbn, msg, reguserid, regdttm) ";
            AiReport.MakeWorkTable(db.Session, sheet, condition);
        }



        /// <summary>
        /// プロシージャのselect項目をセット
        /// </summary>
        private static void SetProcItems(ref List<ArItemDef> itemDefs, string maintablealias)
        {
            foreach (var item in itemDefs)
            {
                if(DaSystemParameterManager.IsSystemParameter(item.ItemName))
                {
                    continue;
                }
                if (!item.IsTotaling)
                {
                    if (!item.SqlColumn.Contains("."))
                    {
                        item.SqlColumn = $"{maintablealias}.{item.SqlColumn}";
                    }
                }
                else
                {
                    if (!item.SqlColumn.Contains("."))
                    {
                        item.SqlColumn = item.SqlColumn.Replace("(", $"({maintablealias}.");
                    }
                }


            }
        }

        /// <summary>
        /// プロシージャのパラメータ値を取得
        /// </summary>
        private static List<object> GetProcParValue(DaDbContext db, Dictionary<string, object> searchDic, DaSystemParameterManager sysManager, List<tm_eurptkensakuDto> rptWheres, string procnm)
        {
            var parValues = new List<object>();

            var paramInfoList = AiGlobal.DbInfoProvider.GetProcParameterList(db.Session, procnm);

            paramInfoList = paramInfoList.Distinct().Where(e => e.IsOutput == false).ToList();

            if (paramInfoList != null && paramInfoList.Count > 0)
            {
                foreach (var paramInfo in paramInfoList)
                {
                    var pname = paramInfo.ParameterName;

                    var rptWhere = rptWheres.Find(e => e.variables! == $"{DaStrPool.C_AT}{pname}");
                    //検索条件の場合、画面の検索値を追加
                    if (rptWhere != null && searchDic.ContainsKey(rptWhere.jyokenlabel!))
                    {
                        var value = searchDic[rptWhere.jyokenlabel!];

                        //帳票画面条件からパラメータ値をセット
                        SetParValue(rptWhere, value, ref parValues);
                    }
                    //システム固定項目の場合、固定SQLを追加
                    else if (DaSystemParameterManager.IsSystemParameter(pname))
                    {
                        var sysItem = sysManager.GetItem(pname);
                        parValues.Add(sysItem.GetSQL());
                    }
                    else
                    {
                        parValues.Add("null");
                    }
                }
            }
            return parValues;
        }

        /// <summary>
        /// 帳票画面条件からパラメータ値をセット
        /// </summary>
        private static void SetParValue(tm_eurptkensakuDto rptWhere, object value, ref List<object> parValues)
        {
            //範囲
            if (value.GetType() == typeof(ArPair))
            {
                var param = new ArParameterModel();
                var valArPair = (ArPair)value;

                parValues.Add(valArPair.First == null ? "null" : $"'{valArPair.First}'");
                parValues.Add(valArPair.Second == null ? "null" : $"'{valArPair.Second}'");
                return;
            }
            //複数選択
            else if (value.GetType().IsArray)
            {
                parValues.Add($"'{string.Join(",", (object[])value)}'");
                return;
            }

            if (string.IsNullOrEmpty(value?.ToString()))
            {
                parValues.Add("null");
            }
            else if (rptWhere.datatype == (int)EnumDataType.整数
                || rptWhere.datatype == (int)EnumDataType.小数)
            {
                parValues.Add(value);
            }
            else if (rptWhere.datatype == (int)EnumDataType.フラグ)
            {
                parValues.Add(CBool(value));
            }
            else
            {
                parValues.Add($"'{value}'");
            }
        }

        /// <summary>
        /// Join文組み立て(プロシージャ)
        /// </summary>
        private static List<ArTableRelationDef> GetProcJoinInfo(string workSeq, string maintablealias, bool isMakeWorkFLg)
        {
            var relations = new List<ArTableRelationDef>();
            if (!isMakeWorkFLg)
            {
                var relation = new ArTableRelationDef();
                relation.IsLeftJoin = false;
                relation.TableID = wk_euatena_subDto.TABLE_NAME;
                relation.TableName = wk_euatena_subDto.TABLE_NAME;
                relation.RefTableID = maintablealias;
                relation.JoinString = $@"{wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.workseq)}={workSeq} AND {maintablealias}.{nameof(wk_euatena_subDto.atenano)} = {wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.atenano)} AND {wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.formflg)}=true";
                relations.Add(relation);
            }

            return relations;
        }

        /// <summary>
        /// Join文組み立て
        /// </summary>
        private static void SetJoinInfo(DaDbContext db, ref ArRelationDef rlt, tm_eudatasourceDto eudatasource, ref ArSmartEngineBase dataEngine,
             ref ArSheetDefBase subSheetBase, string datasourceId, string workSeq, bool isAtenaflg, bool isMakeWorkFLg, bool isDetailSearch)
        {
            var tablejoin = DaEucCacheService.GetEutablejoinDtoList(db);

            //テーブル一覧
            var tableList = new HashSet<string>();
            foreach (var table in subSheetBase.SelectTables)
            {
                if (tableList.Contains(table) == false)
                {
                    tableList.Add(table);
                }
            }
            //条件中のテーブル
            foreach (var table in subSheetBase.WhereTables)
            {
                if (tableList.Contains(table) == false)
                {
                    tableList.Add(table);
                }
            }
            //詳細検索
            if (isDetailSearch)
            {
                if (tableList.Contains(tt_afatenaDto.TABLE_NAME) == false)
                {
                    tableList.Add(tt_afatenaDto.TABLE_NAME);
                }
            }
            //Join文構成
            //MainTableID
            var MainTableID = eudatasource.maintablealias;
            var relations = dataEngine.RelationDef.TableRelations;
            dataEngine.RelationDef.MainTableName = eudatasource.maintablealias;

            dataEngine.RelationDef.TableRelations = GetRelation(db, MainTableID, tableList, subSheetBase.WhereTables);

            //宛名帳票の場合、ワークテーブルと結合する
            //relations.Sort(new JionComparer());
            if (isAtenaflg && !isMakeWorkFLg)
            {
                var relation = new ArTableRelationDef();
                relation.IsLeftJoin = false; //subSheetBase.WhereTables.Count < 1;
                relation.TableID = wk_euatena_subDto.TABLE_NAME;
                relation.TableName = wk_euatena_subDto.TABLE_NAME;
                relation.RefTableID = eudatasource.maintablealias;
                relation.JoinString = $@"{wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.workseq)}={workSeq} AND {eudatasource.maintablealias}.{nameof(wk_euatena_subDto.atenano)} = {wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.atenano)} AND {wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.formflg)}=true";
                dataEngine.RelationDef.TableRelations.Add(relation);
            }
        }

        private static List<ArTableRelationDef> GetRelation(DaDbContext db, string mainTableAlias, HashSet<string> tableSet1, HashSet<string> WhereTables)
        {
            var join = DaEucCacheService.GetEutablejoinDtoList(db);
            var joinSet = join.Select(e => $"{e.tablealias}.{e.kanrentablealias}").ToHashSet();
            var tableList1 = GetAllJoinTables(db, mainTableAlias);
            var parentdic = new Dictionary<string, string>();

            HashSet<string> tableSet2 = tableSet1.Copy();
            //抜けテーブルの補正
            foreach (var table in tableSet1)
            {
                var parent = GetParent(tableList1, table, joinSet);
                if (parent != "")
                {
                    if (tableSet2.Contains(parent) == false)
                    {
                        tableSet2.Add(parent);
                    }
                }
            }

#if FALSE
            //抜けテーブルの補正
            var tableSet3 = tableSet2.Copy();
            foreach (var table in tableSet2)
            {
                var parent = GetParent(tableList1, table, joinSet);
                if (parent != "")
                {
                    if (tableSet3.Contains(parent) == false)
                    {
                        tableSet3.Add(parent);
                    }
                }
            }

            //抜けテーブルの補正
            var tableSet4 = tableSet3.Copy();
            foreach (var table in tableSet3)
            {
                var parent = GetParent(tableList1, table, joinSet);
                if (parent != "")
                {
                    if (tableSet4.Contains(parent) == false)
                    {
                        tableSet4.Add(parent);
                    }
                }
            }

            //抜けテーブルの補正
            var tableSet5 = tableSet4.Copy();
            foreach (var table in tableSet4)
            {
                var parent = GetParent(tableList1, table, joinSet);
                if (parent != "")
                {
                    if (tableSet5.Contains(parent) == false)
                    {
                        tableSet5.Add(parent);
                    }
                }
            }
#endif

            //上位辞書の作成
            foreach (var table in tableSet2)
            {
                var parent = GetParent(tableList1, table, joinSet);
                if (parent != "")
                {
                    parentdic.Add(table, parent);
                }
            }

            //並び替え
            var tableList3 = new List<string>();
            foreach (var table in tableList1)
            {
                if (tableSet2.Contains(table))
                {
                    tableList3.Add(table);
                }
            }

            //エラーチェック
            foreach (var table in tableSet2)
            {
                if (tableList3.Contains(table) == false && table != "SYSTEM")
                {
                    throw new Exception($"テーブル結合エラーです。「tm_eutablejoin」テーブルにメインテーブルが「{mainTableAlias}」で、「tablealias」＝「{table}」のデータが存在しません。");
                }
            }

            List<ArTableRelationDef> relations = new List<ArTableRelationDef>();
            var tableInfo = DaEucCacheService.GetEutableDtoList(db);

            foreach (var table in tableList3)
            {
                if (table != mainTableAlias)
                {
                    var relation = new ArTableRelationDef();
                    relation.MainTableID = mainTableAlias;
                    relation.TableID = table;
                    relation.TableName = tableInfo.Find(e => e.tablealias == table)!.tablenm;
                    relation.RefTableID = parentdic[table];
                    var joinDtl = join.Find(e => e.tablealias == table && e.kanrentablealias == relation.RefTableID);
                    relation.JoinString = joinDtl!.ketugosql;
#if DEBUG
                    //エラーチェック
                    //テーブル存在性
                    var tables = AiGlobal.DbInfoProvider.GetTableList(db.Session);
                    if (relation.TableName.StartsWith("t"))
                    {
                        if (tables.Exists(e => e.TableName == relation.TableName) == false)
                        {
                            throw new Exception($"tm_eutableテーブルにtablenm項目「{relation.TableName}」が間違っています。");
                        }
                    }
                    //JOIN Sringのテーブル名チェック
                    var list = GetJoinTables(relation.JoinString);
                    var err = list.Find(e => e != relation.TableID && e != relation.RefTableID);
                    if (err != null)
                    {
                        throw new Exception($"tm_eutablejoinテーブルにketugousql項目「{relation.JoinString}」に別名「{err}」が間違っています。");
                    }
#endif
                    //InnerJion／LeftJion判定
                    relation.IsLeftJoin = !WhereTables.Contains(relation.TableName);
                    if (relation.TableName == tt_afatenaDto.TABLE_NAME)
                    {
                        relation.IsLeftJoin = false;
                    }

                    relations.Add(relation);
                }
            }

            return relations;
        }


        private static List<string> GetTableAndItem(string itemSql)
        {
            Regex regex = new Regex("([a-z_0-9]+\\.[a-z_0-9]+)");
            var list = new List<string>();
            foreach (Match ms in regex.Matches(itemSql))
            {
                foreach (Group g in ms.Groups)
                {
                    var item = g.Value;
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }
        private static List<string> GetJoinTables(string join)
        {
            Regex regex = new Regex("([a-z_0-9]+\\.)");
            var list = new List<string>();
            foreach (Match ms in regex.Matches(join))
            {
                foreach (Group g in ms.Groups)
                {
                    var item=g.Value.Substring(0, g.Value.Length - 1);
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }
        private static string GetParent(List<string> tableList, string table, HashSet<string> joinSet)
        {
            int index = tableList.IndexOf(table);
            for (int i = 0; i< index ; i++)
            {
                var key = $"{table}.{tableList[i]}";
                if (joinSet.Contains(key))
                {
                    return tableList[i];
                }
            }
            //throw new Exception("ERROR");
            return "";
        }


        private static void GetSubTables(List<tm_eutablejoinDto> joinTable, string table, List<string> allTables)
        {
            var subTables = joinTable.Where(e => e.kanrentablealias == table);
            foreach (var item in subTables)
            {
                var thisTable = item.tablealias;
                if (!allTables.Contains(thisTable))
                {
                    allTables.Add(thisTable);
                    GetSubTables(joinTable, thisTable, allTables);
                }
            }
        }

        /// <summary>
        /// Select文組み立て
        /// </summary>
        private static bool SetSelectInfo(DaDbContext db, ref ArSmartEngineBase dataEngine, TransData? paramData, tm_euyosikisyosaiDto rptSubSheet, List<tm_eurptitemDto> rptItems, ref ArSheetDefBase subSheetBase,
            tm_eurptDto rpt, string yosikiID, EnumReportType reportType, string csvPattern, tm_eudatasourceDto eudatasource, string workSeq, bool isMakeWorkFLg, Dictionary<string, object> searchDic, tm_euyosikiDto rptSheet, string reguserid, DaSystemParameterManager sysParaManger)
        {
            //個人番号操作フラグ
            bool pnouseflg = false;

            // Select文構成
            if (isMakeWorkFLg)
            {
                pnouseflg = SetSelectMakeWorkInfo(db, ref dataEngine, rptSubSheet, rptItems, ref subSheetBase, eudatasource, workSeq, rpt);
            }
            else if (paramData != null && EnumMakeWorkKbn.宛名番号ログ.Equals(paramData.workKbn))
            {
                pnouseflg = SetSelectAtenaLogInfo(db, ref dataEngine, rptSubSheet, rptItems, ref subSheetBase, eudatasource, paramData);
            }
            else
            {
                pnouseflg = SetSelectSubInfo(db, ref dataEngine, rptSubSheet, rptItems, ref subSheetBase, rpt.rptid, yosikiID, reportType, csvPattern, searchDic, rptSheet, reguserid, sysParaManger);
            }

            //Select項目チェック
            if (dataEngine.ItemDefs.Count == 0)
            {
                throw new Exception("SELECT項目が存在しません");
            }

            //改ページItemID
            //if (rptSubSheet.meisaiflg == false) dataEngine.ItemDefs[0].IsPageBreakItem = true;

            return pnouseflg;
        }

        /// <summary>
        /// Selectサブ文組み立て
        /// </summary>
        private static bool SetSelectSubInfo(DaDbContext db, ref ArSmartEngineBase dataEngine, tm_euyosikisyosaiDto rptSubSheet, List<tm_eurptitemDto> rptItems,
            ref ArSheetDefBase subSheetBase, string rptID, string yosikiID, EnumReportType reportType, string csvPattern, Dictionary<string, object> searchDic, tm_euyosikiDto rptSheet, string reguserid, DaSystemParameterManager sysParaManger)
        {
            //個人番号操作フラグ
            bool pnouseflg = false;

            //項目一覧
            var itemDefs = new List<ArItemDef>();
            //ソース順項目一覧
            var sortItemDefs = new List<ArItemDef>();
            pnouseflg = SetSelectSubInfo(db, ref itemDefs, ref sortItemDefs, rptSubSheet, rptItems, ref subSheetBase, rptID, yosikiID, reportType, csvPattern, searchDic, rptSheet, reguserid, sysParaManger);
            //項目一覧
            dataEngine.ItemDefs = itemDefs.OrderBy(e => e.Seq).ToList();
            //ソース順項目一覧
            dataEngine.SortItemDefs = sortItemDefs;

            return pnouseflg;
        }


        /// <summary>
        /// Selectサブ文組み立て
        /// </summary>
        private static bool SetSelectSubInfo(DaDbContext db, ref List<ArItemDef> itemDefs, ref List<ArItemDef> sortItemDefs, tm_euyosikisyosaiDto rptSubSheet, List<tm_eurptitemDto> rptItems,
            ref ArSheetDefBase subSheetBase, string rptID, string yosikiID, EnumReportType reportType, string csvPattern, Dictionary<string, object> searchDic, tm_euyosikiDto rptSheet, string reguserid, DaSystemParameterManager sysParaManger)
        {
            var itemDic = DaEucCacheService.GetEutableitemDtoDic(db);

            //個人番号操作フラグ
            bool pnouseflg = false;

            // Select文構成
            //パターンを使用する場合、パターンの項目一覧を取得
            List<tt_eucsv_subDto> ptnList = new List<tt_eucsv_subDto>();
            if (!string.IsNullOrEmpty(csvPattern))
            {
                ptnList = db.tt_eucsv_sub.SELECT.WHERE.ByKey(rptID, rptSubSheet.yosikiid, int.Parse(csvPattern)).GetDtoList();
                if (ptnList.Count == 0)
                {
                    throw new Exception("CSVパタン項目が存在しません");
                }
            }

            //出力順パターンサブテーブル
            var sortItems = db.tt_eusort_sub.SELECT.WHERE.ByKey(rptID, yosikiID, rptSheet.sortptnno.HasValue ? rptSheet.sortptnno : 1).GetDtoList().OrderBy(e => e.orderseq).ToList();

            var items = rptItems.Where(e => e.yosikieda == rptSubSheet.yosikieda);
            foreach (var item in items)
            {
                var tableList = new List<string>();
                if (itemDic.ContainsKey(item.sqlcolumn!))
                {
                    var tableItem = itemDic[item.sqlcolumn!];
                    if (!string.IsNullOrEmpty(tableItem.tablealias)) tableList.Add(tableItem.tablealias);
                    if (!string.IsNullOrEmpty(tableItem.tablealias2)) tableList.AddRange(tableItem.tablealias2.Split(','));
                }
                else
                {
                    tableList = item.tablealias.Split(',').ToList();
                }
                var itemdef = new ArItemDef();
                if (item.headerflg)
                {
                    itemdef.GroupType = EnumGroupItemType.ColumnGroup;
                }
                //パターンが存在する場合、パターンSUBの登録項目のみ有効
                if (string.IsNullOrEmpty(csvPattern) || ptnList!.Exists(e => e.reportitemid == item.yosikiitemid))
                {

                    //Sqlcolumn
                    var ptnDto = ptnList.Where(e => e.reportitemid == item.yosikiitemid).FirstOrDefault();
                    itemdef.SqlColumn = GetSqlcolumn(string.IsNullOrWhiteSpace(item.sqlcolumn) ? "" : item.sqlcolumn, searchDic, sysParaManger);
                    //var tableItem = db.tm_eutableitem.SELECT.WHERE.ByKey(item.sqlcolumn!).GetDto();
                    itemdef.ItemID = item.yosikiitemid.Substring(4);
                    if (EnumReportType.PDF.Equals(reportType) || EnumReportType.PREVIEW.Equals(reportType) || EnumReportType.EXCEL.Equals(reportType))
                    {
                        itemdef.ItemName = item.reportitemnm;
                        itemdef.Visiable = item.reportoutputflg;
                        if (item.reportoutputflg)
                        {
                            itemDefs.Add(itemdef);
                        }
                    }
                    else if (reportType.Equals(EnumReportType.CSV))
                    {
                        itemdef.ItemName = item.csvitemnm;
                        itemdef.Visiable = item.csvoutputflg;
                        if (item.csvoutputflg)
                        {
                            itemDefs.Add(itemdef);
                        }
                    }
                    itemdef.SortType = (ArEnumSort)item.orderkbn;
                    itemdef.Seq = (ptnDto !=null && ptnDto!.orderseq != 0) ? ptnDto.orderseq : item.orderseq!.Value;
                    // Cross情報
                    SetCrossItemInfo(db, rptSubSheet, ref itemdef, item);
                    //高
                    if (item.height.HasValue && item.height.Value > 0) itemdef.Height = item.height.Value;
                    //幅
                    if (item.width.HasValue && item.width.Value > 0) itemdef.Width = item.width.Value;

                    //X軸オフセット
                    if (item.offsetx.HasValue && item.offsetx.Value > 0) itemdef.Left = item.offsetx.Value;
                    //Y軸オフセット
                    if (item.offsety.HasValue && item.offsety.Value > 0) itemdef.Top = item.offsety.Value;
                    //項目区分
                    if (!pnouseflg && Enum出力項目区分.個人番号.Equals(item.itemkbn))
                    {
                        pnouseflg = true;
                    }
                    tm_afuserDto user = db.tm_afuser.GetDtoByKey(reguserid);
                    if (user.pnoeditflg == false && Enum出力項目区分.個人番号.Equals(item.itemkbn))
                    {
                        itemdef.ItemName = "*";
                    }
                    //白紙ディフォルト値設定
                    itemdef.BlankValue = item.blankvalue;

                    //フォーマット区分
                    int formatKbn = string.IsNullOrWhiteSpace(item.formatkbn) ? 0 : int.Parse(item.formatkbn);
                    int formatKbn2 = string.IsNullOrWhiteSpace(item.formatkbn2) ? 0 : int.Parse(item.formatkbn2);
                    itemdef.FormatKbn = (ArEnumFormat)formatKbn;
                    if (formatKbn == (int)ArEnumFormat.BarCode) itemdef.BarCodeType = (ArEnumBarCode)formatKbn2;

                    //フォーマット詳細
                    switch (formatKbn)
                    {
                        case (int)ArEnumFormat.String:
                        case (int)ArEnumFormat.Number:
                        case (int)ArEnumFormat.Year:
                        case (int)ArEnumFormat.Date:
                        case (int)ArEnumFormat.DateTime:
                        case (int)ArEnumFormat.Time:
                        case (int)ArEnumFormat.Bool:
                            itemdef.FormatString = string.IsNullOrWhiteSpace(item.formatsyosai) ? "" : item.formatsyosai;
                            break;

                        case (int)ArEnumFormat.QRCode:
                            itemdef.Height=itemdef.Width;
                            break;

                        case (int)ArEnumFormat.BarCode:
                        case (int)ArEnumFormat.Image:
                            //20240624
                            //string[] formatsyosai = (string.IsNullOrWhiteSpace(item.formatsyosai) ? "10" : item.formatsyosai).Split(',');
                            //if (formatsyosai.Length < 4) formatsyosai = formatsyosai.Concat(Enumerable.Repeat("1", 4 - formatsyosai.Length)).ToArray();
                            //int[] numSpec = formatsyosai.Select(p => int.Parse(p)).ToArray();
                            //itemdef.Width = numSpec[0];
                            //itemdef.Height = numSpec[0];
                            //itemdef.Left = numSpec[2];
                            //itemdef.Top = numSpec[3];
                            break;

                        default:
                            itemdef.FormatString = string.IsNullOrWhiteSpace(item.formatsyosai) ? string.Empty : item.formatsyosai;
                            break;
                    }

                    if (sortItems != null && sortItems.Count > 0)
                    {
                        var dto = sortItems.Find(e => e.reportitemid == item.yosikiitemid);
                        if (dto != null)
                        {
                            itemdef.IsPageBreakItem = dto.pageflg;
                        }
                    }
                    //改ページフラグ
                    if (item.kaipageflg)
                    {
                        itemdef.IsPageBreakItem = item.kaipageflg;
                    }

                    //テーブル一覧を作成
                    //var tables = item.tablealias.Split(',');
                    foreach (var table in tableList)
                    {
                        if (CONST_FUNCTION.Equals(item.tablealias))
                        {
                            //TODO
                            List<string> retLst = GetTables(item.sqlcolumn!);
                            foreach (string strTable in retLst)
                            {
                                if (subSheetBase.SelectTables.Contains(strTable) == false)
                                {
                                    subSheetBase.SelectTables.Add(strTable);
                                }
                            }
                        }
                        else
                        {
                            if (subSheetBase.SelectTables.Contains(table) == false)
                            {
                                subSheetBase.SelectTables.Add(table);
                            }
                        }
                    }
                }
            }

            //ソース順
            sortItemDefs = new List<ArItemDef>();
            if (sortItems != null && sortItems.Count > 0)
            {
                foreach (var item in sortItems)
                {
                    var itemdef = new ArItemDef();
                    sortItemDefs.Add(itemdef);

                    var itemInfo = itemDefs.FirstOrDefault(e => e.ItemID == item.reportitemid.Substring(4));
                    //出力対象項目の場合
                    if (itemInfo != null)
                    {
                        itemdef.ItemID = itemInfo.ItemID;
                    }
                    else
                    {
                        var itemDto = items.FirstOrDefault(e => e.yosikiitemid == item.reportitemid);
                        if (itemDto != null)
                        {
                            itemdef.ItemID = itemDto!.sqlcolumn!;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    itemdef.SortType = item.descflg ? ArEnumSort.Descending : ArEnumSort.Ascending;
                    itemdef.Seq = item.orderseq;
                }
            }

            return pnouseflg;
        }

        /// <summary>
        /// Selectワークテーブル文組み立て
        /// </summary>
        private static bool SetSelectMakeWorkInfo(DaDbContext db, ref ArSmartEngineBase dataEngine, tm_euyosikisyosaiDto rptSubSheet, List<tm_eurptitemDto> rptItems,
            ref ArSheetDefBase subSheetBase, tm_eudatasourceDto eudatasource, string workSeq, tm_eurptDto rpt)
        {
            //個人番号操作フラグ
            bool pnouseflg = false;

            // Select文構成
            dataEngine.ItemDefs = GetSelectItemMakeWorkInfo(workSeq, eudatasource.maintablealias, rpt);
            //TODOi
            //var items = rptItems.Where(e => e.yosikieda == rptSubSheet.yosikieda);

            if (subSheetBase.SelectTables.Contains(eudatasource.maintablealias) == false)
            {
                subSheetBase.SelectTables.Add(eudatasource.maintablealias);
            }
            return pnouseflg;
        }

        /// <summary>
        /// Selectワークテーブル文組み立て
        /// </summary>
        private static List<ArItemDef> GetSelectItemMakeWorkInfo(string workSeq, string maintablealias, tm_eurptDto rpt)
        {
            // Select文構成
            var itemDefs = new List<ArItemDef>();

            // ワークシーケンス
            var itemWorkseq = new ArItemDef();
            itemDefs.Add(itemWorkseq);
            itemWorkseq.SqlColumn = $@"{workSeq}";
            itemWorkseq.ItemID = $@"{nameof(wk_euatena_subDto.workseq)}";
            itemWorkseq.ItemName = $@"{nameof(wk_euatena_subDto.workseq)}";
            itemWorkseq.Seq = 1;

            // 宛名№
            var itemAtena = new ArItemDef();
            itemDefs.Add(itemAtena);
            itemAtena.SqlColumn = $@"{maintablealias}.{nameof(wk_euatena_subDto.atenano)}";
            itemAtena.ItemID = $@"{nameof(wk_euatena_subDto.atenano)}";
            itemAtena.ItemName = $@"{nameof(wk_euatena_subDto.atenano)}";
            itemAtena.SortType = ArEnumSort.Ascending;
            itemAtena.Seq = 2;

            //妊産婦フラグチェックしない場合
            if (!rpt.ninsanpuflg)
            {
                // 出力フラグ
                var itemFormflg = new ArItemDef();
                itemDefs.Add(itemFormflg);
                itemFormflg.SqlColumn = "true";
                itemFormflg.ItemID = $@"{nameof(wk_euatena_subDto.formflg)}";
                itemFormflg.ItemName = $@"{nameof(wk_euatena_subDto.formflg)}";
                itemFormflg.Seq = 3;

                // 対象フラグ
                var itemTaisyoflg = new ArItemDef();
                itemDefs.Add(itemTaisyoflg);
                itemTaisyoflg.SqlColumn = "false";
                itemTaisyoflg.ItemID = $@"{nameof(wk_euatena_subDto.taisyoflg)}";
                itemTaisyoflg.ItemName = $@"{nameof(wk_euatena_subDto.taisyoflg)}";
                itemTaisyoflg.Seq = 4;

                // 対象外フラグ
                var itemTaisyooutflg = new ArItemDef();
                itemDefs.Add(itemTaisyooutflg);
                itemTaisyooutflg.SqlColumn = "false";
                itemTaisyooutflg.ItemID = $@"{nameof(wk_euatena_subDto.taisyooutflg)}";
                itemTaisyooutflg.ItemName = $@"{nameof(wk_euatena_subDto.taisyooutflg)}";
                itemTaisyooutflg.Seq = 5;
            }
            else
            {
                // 妊産婦登録番号
                var itemTorokuno = new ArItemDef();
                itemDefs.Add(itemTorokuno);
                itemTorokuno.SqlColumn = $@"{maintablealias}.{nameof(wk_euninsanpu_subDto.torokuno)}";
                itemTorokuno.ItemID = $@"{nameof(wk_euninsanpu_subDto.torokuno)}";
                itemTorokuno.ItemName = $@"{nameof(wk_euninsanpu_subDto.torokuno)}";
                itemTorokuno.Seq = 3;
            }

            return itemDefs;
        }

        /// <summary>
        /// Select宛名番号ログ文組み立て
        /// </summary>
        private static bool SetSelectAtenaLogInfo(DaDbContext db, ref ArSmartEngineBase dataEngine, tm_euyosikisyosaiDto rptSubSheet, List<tm_eurptitemDto> rptItems,
            ref ArSheetDefBase subSheetBase, tm_eudatasourceDto eudatasource, TransData paramData)
        {
            // Select文構成
            dataEngine.ItemDefs = GetSelectAtenaLogInfo(eudatasource.maintablealias, paramData);
            //TODOi
            //var items = rptItems.Where(e => e.yosikieda == rptSubSheet.yosikieda);

            if (subSheetBase.SelectTables.Contains(eudatasource.maintablealias) == false)
            {
                subSheetBase.SelectTables.Add(eudatasource.maintablealias);
            }
            return false;
        }

        /// <summary>
        /// Select宛名番号ログ文組み立て
        /// </summary>
        private static List<ArItemDef> GetSelectAtenaLogInfo(string maintablealias, TransData paramData)
        {
            // Select文構成
            var itemDefs = new List<ArItemDef>();

            // セッションシーケンス
            var itemSessionseq = new ArItemDef();
            itemDefs.Add(itemSessionseq);
            itemSessionseq.SqlColumn = $@"{paramData.sessionseq}";
            itemSessionseq.ItemID = $@"{nameof(tt_aflogatenaDto.sessionseq)}";
            itemSessionseq.ItemName = $@"{nameof(tt_aflogatenaDto.sessionseq)}";
            itemSessionseq.Seq = 1;

            // 宛名番号
            var itemAtenaNo = new ArItemDef();
            itemDefs.Add(itemAtenaNo);
            itemAtenaNo.SqlColumn = $@"{maintablealias}.{nameof(tt_aflogatenaDto.atenano)}";
            itemAtenaNo.ItemID = $@"{nameof(tt_aflogatenaDto.atenano)}";
            itemAtenaNo.ItemName = $@"{nameof(tt_aflogatenaDto.atenano)}";
            itemAtenaNo.SortType = ArEnumSort.Ascending;
            itemAtenaNo.Seq = 2;

            // 個人番号操作フラグ
            var itemPnouseflg = new ArItemDef();
            itemDefs.Add(itemPnouseflg);
            itemPnouseflg.SqlColumn = $@"{paramData.pnouseflg}";
            itemPnouseflg.ItemID = $@"{nameof(tt_aflogatenaDto.pnouseflg)}";
            itemPnouseflg.ItemName = $@"{nameof(tt_aflogatenaDto.pnouseflg)}";
            itemPnouseflg.Seq = 3;

            // 操作区分
            var itemUsekbn = new ArItemDef();
            itemDefs.Add(itemUsekbn);
            itemUsekbn.SqlColumn = ((int)EnumUseKbn.検索).ToString();
            itemUsekbn.ItemID = $@"{nameof(tt_aflogatenaDto.usekbn)}";
            itemUsekbn.ItemName = $@"{nameof(tt_aflogatenaDto.usekbn)}";
            itemUsekbn.Seq = 4;

            // メッセージ
            var itemMsg = new ArItemDef();
            itemDefs.Add(itemMsg);
            itemMsg.SqlColumn = "null";
            itemMsg.ItemID = $@"{nameof(tt_aflogatenaDto.msg)}";
            itemMsg.ItemName = $@"{nameof(tt_aflogatenaDto.msg)}";
            itemMsg.Seq = 5;

            // 登録ユーザーID
            var itemReguserid = new ArItemDef();
            itemDefs.Add(itemReguserid);
            itemReguserid.SqlColumn = $@"'{paramData.reguserid}'";
            itemReguserid.ItemID = $@"{nameof(tt_aflogatenaDto.reguserid)}";
            itemReguserid.ItemName = $@"{nameof(tt_aflogatenaDto.reguserid)}";
            itemReguserid.Seq = 6;

            // 登録日時
            var itemRegdttm = new ArItemDef();
            itemDefs.Add(itemRegdttm);
            itemRegdttm.SqlColumn = $@"now()";
            itemRegdttm.ItemID = $@"{nameof(tt_aflogatenaDto.regdttm)}";
            itemRegdttm.ItemName = $@"{nameof(tt_aflogatenaDto.regdttm)}";
            itemRegdttm.Seq = 7;

            return itemDefs;
        }

        /// <summary>
        /// Where文組み立て
        /// </summary>
        private static void SetWhereInfo(DaDbContext db, ref ArSmartEngineBase dataEngine, ref ArConditionModel condition, List<tm_eurptkensakuDto> rptWheres,
            Dictionary<string, object> searchDic, ref ArSheetDefBase subSheetBase, string datasourceId)
        {
            //条件マッチフラグ
            bool isMatch = false;

            // Where文構成
            dataEngine.ConditionDic = new Dictionary<string, ArConditionDef>();
            if (rptWheres != null && rptWheres.Count > 0)
            {
                foreach (var rptWhere in rptWheres)
                {
                    var dataSourceWhere = new tm_eudatasourcekensakuDto();
                    string[] arrSql = { };
                    string[] arrPara = { };
                    if (rptWhere.datasourceid == datasourceId)
                    {
                        //検索条件のデータ
                        dataSourceWhere = DaEucCacheService.GetTm_eudatasourcekensakuByDoubleID(db, datasourceId, rptWhere.jyokenid!);
                        if (dataSourceWhere != null)
                        {
                            if (dataEngine.ConditionDic.ContainsKey(dataSourceWhere.jyokenlabel!))
                            {
                                continue;
                            }
                            isMatch = false;
                            arrSql = dataSourceWhere.sql!.Split(@";");
                            arrPara = dataSourceWhere.variables!.Split(@",");
                        }
                    }
                    else
                    {
                        //条件追加のデータ
                        isMatch = false;
                        arrSql = rptWhere.sql!.Split(@";");
                        arrPara = rptWhere.variables!.Split(@",");
                        dataSourceWhere.jyokenlabel = CStr(rptWhere.jyokenlabel);
                        dataSourceWhere.tablealias = CStr(rptWhere.tablealias);
                        dataSourceWhere.sql = CStr(rptWhere.sql);
                    }
                    if (arrSql.Length != arrPara.Length || arrPara.Length > 2) throw new Exception("検索条件の変数の数とSQL文の設定値が一致しない。");
                    for (int index = 0; index < arrSql.Length; index++)
                    {
                        isMatch = false;
                        var cond = new ArConditionDef();
                        //検索条件が範囲の場合、入力範囲（開始）より入力範囲（終了）が設定しない場合にチェックを行う
                        if (arrSql.Length == 2 && arrPara.Length == 2)
                        {
                            var _valArPair = (ArPair)searchDic.First(e => e.Value.GetType() == typeof(ArPair) && e.Key == dataSourceWhere!.jyokenlabel!).Value;
                            if (!CheckValArPair(_valArPair, index))
                            {
                                continue;
                            }
                        }
                        cond.Sql = arrSql[index];
                        cond.Name = dataSourceWhere!.jyokenlabel! + index;

                        //Whereのパラメータ
                        cond.ParameterList.Add(arrPara[index]);

                        //検索条件用テーブルを設定
                        var tables = dataSourceWhere.tablealias!.Split(',');

                        //条件データ紐づけ
                        foreach (var searchItem in searchDic)
                        {
                            if (dataSourceWhere.jyokenlabel!.Equals(searchItem.Key))
                            {

                                var condItem = new ArConditionItem();
                                condItem.Name = searchItem.Key + index;
                                if (arrPara.Length == 2 && searchItem.Value.GetType() == typeof(ArPair))
                                {
                                    ArParameterModel param = new ArParameterModel();
                                    param.Name = arrPara[index];
                                    var valArPair = (ArPair)searchItem.Value;
                                    if (index == 0)
                                    {
                                        param.Value = valArPair.First!;
                                    }
                                    else
                                    {
                                        param.Value = valArPair.Second!;
                                    }
                                    if (!string.IsNullOrEmpty(CStr(param.Value)))
                                    {
                                        condItem.ParaList.Add(param);
                                        isMatch = true;
                                    }
                                }
                                else if (searchItem.Value is List<object>)
                                {
                                    ArParameterModel param = new ArParameterModel();
                                    param.Name = arrPara[0];
                                    param.Value = searchItem.Value;
                                    condItem.ParaList.Add(param);
                                    isMatch = true;
                                }
                                else
                                {
                                    ArParameterModel param = new ArParameterModel();
                                    param.Name = arrPara[0];
                                    if (dataSourceWhere.aimaikbn == EnumToStr(Enum検索区分.部分一致_中間一致))
                                    {
                                        param.Value = $"%{searchItem.Value}%";


                                    }
                                    else if (dataSourceWhere.aimaikbn == EnumToStr(Enum検索区分.部分一致_前方一致))
                                    {
                                        param.Value = $"{searchItem.Value}%";
                                    }
                                    else
                                    {
                                        param.Value = searchItem.Value;
                                    }
                                    condItem.ParaList.Add(param);
                                    isMatch = true;
                                }
                                if (isMatch)
                                {
                                    if (condition.ConditionList.Contains(condItem) == false)
                                    {
                                        condition.ConditionList.Add(condItem);
                                    }
                                }
                                break;
                            }
                        }

                        //固定条件
                        if (!dataSourceWhere.sql!.Contains(@"@"))
                        {
                            var condItem = new ArConditionItem();
                            condItem.Name = dataSourceWhere.jyokenlabel! + index;
                            condItem.IsFix = true;

                            if (condition.ConditionList.Contains(condItem) == false)
                            {
                                condition.ConditionList.Add(condItem);
                            }
                        }

                        if (!dataSourceWhere.sql!.Contains(@"@") || (dataSourceWhere.sql!.Contains(@"@") && isMatch))
                        {
                            foreach (var table in tables)
                            {
                                if (subSheetBase.WhereTables.Contains(table) == false)
                                {
                                    subSheetBase.WhereTables.Add(table);
                                }
                                //Whereの関連テーブルをセット
                                if (cond.TableIDList.Contains(table) == false)
                                {
                                    cond.TableIDList.Add(table);
                                }
                            }
                            dataEngine.ConditionDic.Add(dataSourceWhere.jyokenlabel! + index, cond);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 入力範囲（開始）より入力範囲（終了）が設定しない場合にチェック
        /// </summary>
        /// <param name="_valArPair"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static bool CheckValArPair(ArPair _valArPair, int index)
        {
            if ((index == 0 && string.IsNullOrEmpty(CStr(_valArPair.First))) || (index == 1 && string.IsNullOrEmpty(CStr(_valArPair.Second))))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cross情報を組み立て
        /// </summary>
        private static void SetCrossItemInfo(DaDbContext db, tm_euyosikisyosaiDto rptSubSheet, ref ArItemDef itemdef, tm_eurptitemDto item)
        {
            //集計区分
            var crosskbn = item.crosskbn;
            if (!string.IsNullOrWhiteSpace(crosskbn))
            {
                //集計レベル
                var level = (int)(item.level.HasValue ? item.level : 1);

                //Values
                List<string> Values = new List<string>();
                //Captions
                List<string> Captions = new List<string>();
                //コード名称ラインアップ
                if (!string.IsNullOrWhiteSpace(item.keyvaluepairsjson))
                {
                    string[] pairs = item.keyvaluepairsjson.Split(';');
                    for (int i = 0; i < pairs.Length; i++)
                    {
                        string[] pair = pairs[i].Split(':');
                        Values.Add(pair[0].Trim());
                        Captions.Add(pair[1].Trim());
                    }
                }
                else if (!string.IsNullOrWhiteSpace(item.mastercd))
                {
                    var tblItemName = DaEucCacheService.GetEutableitemnameDto(db, item.mastercd);
                    if (tblItemName == null) throw new ArgumentException("EUCテーブル項目名称にはデータが無し。");
                    List<ValueCaptionModel> LstVC = DaEucCacheService.LstValueCaptionModel(db, tblItemName, item);
                    if (LstVC != null && LstVC.Count > 0)
                    {
                        for (int i = 0; i < LstVC.Count; i++)
                        {
                            Values.Add(LstVC[i].value);
                            Captions.Add(LstVC[i].caption);
                        }
                    }
                }
                if (rptSubSheet.yosikikbn == Enum様式種別詳細.クロス集計 && !C集計.Equals(crosskbn) && (Values.Count == 0 || Captions.Count == 0)) throw new ArgumentException("コード名称情報が設定不正");

                //小計区分
                var kbn1 = item.kbn1;
                if (!string.IsNullOrWhiteSpace(kbn1))
                {
                    var sumvalue = (level == 1) ? ArConst.TOTAL : ArConst.SUM;
                    var sumcaption = (level == 1) ? CONST_TOTAL : CONST_SUM;
                    switch (kbn1)
                    {
                        case C前:
                            Values.Insert(0, sumvalue);
                            Captions.Insert(0, sumcaption);
                            break;

                        case C後:
                            Values.Add(sumvalue);
                            Captions.Add(sumcaption);
                            break;

                        default:
                            break;
                    }
                }

                switch (crosskbn)
                {
                    case CGroupby縦:
                        itemdef.GroupType = EnumGroupItemType.RowGroup;
                        itemdef.ItemGroupDef = new ArFixItemGroupDef()
                        {
                            Level = level,
                            Values = Values,
                            Captions = Captions
                        };
                        break;

                    case CGroupby横:

                        itemdef.GroupType = EnumGroupItemType.ColumnGroup;
                        itemdef.ItemGroupDef = new ArFixItemGroupDef()
                        {
                            Level = level,
                            Values = Values,
                            Captions = Captions
                        };
                        break;

                    case C集計:
                        itemdef.FormatKbn = ArEnumFormat.Number;
                        itemdef.GroupType = EnumGroupItemType.Totaling;

                        break;

                    default:
                        throw new ArgumentException("集計区分が設定不正");
                }
            }
            //}
        }

        /// <summary>
        /// UpdateSQLを行う
        /// </summary>
        private static string UpdateSQL(DaDbContext db, string rptID, string yosikiID, string workSeq, EnumReportType reportType, Dictionary<string, object> searchDic,
            string reguserid, string? regsisyo, ArConditionModel condition, bool hasUpdHassoRireki = false)
        {
            var rptSheet = db.tm_euyosiki.SELECT.WHERE.ByKey(rptID, yosikiID).GetDto();
            var rptWheres = db.tm_eurptkensaku.SELECT.WHERE.ByItem(nameof(tm_eurptkensakuDto.rptid), rptID).GetDtoList().OrderBy(e => e.jyokenseq).ToList();

            DaSystemParameterManager sysParaManger = new DaSystemParameterManager(db, workSeq, rptSheet.rptid, rptSheet.yosikiid, reportType, reguserid, regsisyo, false, hasUpdHassoRireki, condition);
            //プロシージャのパラメータ値を取得
            var updatesql = GetupdateSqlValue(db, rptSheet, rptWheres, searchDic, sysParaManger);
            var retStr = string.Empty;
            try
            {
                var ret = DaDbUtil.RunSql(db, updatesql);
                if (ret == -1)
                {
                    retStr = "UpdateSQL処理が成功した，しかし、渡されたパラメータには対応するデータがありません！";
                }
                else
                {
                    retStr = "UpdateSQL処理が成功した";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return retStr;
        }


        /// <summary>
        /// プロシージャのパラメータ値を取得
        /// </summary>
        private static string GetupdateSqlValue(DaDbContext db, tm_euyosikiDto rptSheet, List<tm_eurptkensakuDto> rptWheres, Dictionary<string, object> searchDic,
                                                DaSystemParameterManager sysParaManger)
        {
            string retsql = string.Empty;

            if (!string.IsNullOrEmpty(rptSheet.updatesql))
            {
                var valueList = new List<object>();

                var updateSql = rptSheet.updatesql;
                int startIndex = updateSql.IndexOf('(');
                int endIndex = updateSql.LastIndexOf(')');
                var procnm = updateSql.Substring(0, startIndex).Trim();
                var joken = updateSql.Substring(startIndex + 1, endIndex - startIndex - 1);

                List<string> paramList = new List<string>(joken.Split(','));

                var paramInfoList = AiGlobal.DbInfoProvider.GetProcParameterList(db.Session, procnm);
                paramInfoList = paramInfoList.Distinct().Where(e => e.IsOutput == false).ToList();

                if (paramInfoList != null && paramInfoList.Count > 0 && paramInfoList.Count == paramList.Count)
                {
                    for (var i = 0; i < paramList.Count; i++)
                    {
                        var param = paramList[i].Trim();
                        if (!param.StartsWith(@"@"))
                        {
                            //TODO
                            valueList.Add(param);
                        }
                        else
                        {
                            var paramnm = param.Replace("@", "").Trim();

                            var rptWhere = rptWheres.Find(e => e.jyokenlabel! == paramnm);
                            //検索条件の場合、画面の検索値を追加
                            if (rptWhere != null && searchDic.ContainsKey(rptWhere.jyokenlabel!))
                            {
                                var value = searchDic[rptWhere.jyokenlabel!];

                                //帳票画面条件からパラメータ値をセット
                                SetParValue(rptWhere, value, ref valueList);
                            }
                            //システム固定項目の場合、固定SQLを追加
                            else if (DaSystemParameterManager.IsSystemParameter(paramnm))
                            {
                                var sysItem = sysParaManger.GetItem(paramnm);
                                valueList.Add(sysItem.GetSQL().ToString());
                            }
                            else
                            {
                                valueList.Add("null");
                            }
                        }
                    }
                }

                retsql = $"CALL {procnm}({string.Join(",", valueList)})";

            }
            return retsql;
        }

        /// <summary>
        /// Sqlcolumn取得を行う
        /// </summary>
        private static string GetSqlcolumn(string strSqlcolumn, Dictionary<string, object> searchDic, DaSystemParameterManager sysParaManger)
        {
            if (!strSqlcolumn.Contains("@")) return strSqlcolumn;

            string strPtn = @"@(.*?)(?=[),]|(?:\|\|)|$)";
            MatchCollection matches = Regex.Matches(strSqlcolumn, strPtn);
            var retStr = strSqlcolumn;
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                if (match.Success)
                {
                    if (searchDic != null && searchDic.ContainsKey(match.Groups[1].Value))
                    {
                        retStr = retStr.Replace($"@{match.Groups[1].Value}", $"'{searchDic[match.Groups[1].Value].ToString()}'");
                    }
                    else if (DaSystemParameterManager.IsSystemParameter(match.Groups[1].Value))
                    {
                        var sysItem = sysParaManger.GetItem(match.Groups[1].Value);
                        var sysPararValue = sysItem.GetSQL();
                        retStr = retStr.Replace($"@{match.Groups[1].Value}", sysPararValue);
                    }
                    else
                    {
                        retStr = retStr.Replace($"@{match.Groups[1].Value}", "NULL");
                    }
                }
            }
            return retStr;
        }

        /// <summary>
        /// テンプレート区分取得
        /// </summary>
        private static string GetSiyoKbn(string yosikiID)
        {
            var siyoKbn = string.Empty;
            switch (yosikiID)
            {
                case Cアドレスシール:
                    siyoKbn = "1";
                    break;

                case Cはがき:
                    siyoKbn = "2";
                    break;

                case C宛名台帳:
                    siyoKbn = "3";
                    break;

                case Cバーコード:
                    siyoKbn = "4";
                    break;

                case C件数表年齢:
                    siyoKbn = "5";
                    break;

                case C件数表行政区:
                    siyoKbn = "6";
                    break;

                default:
                    throw new ArgumentException();
            }
            return siyoKbn;
        }



        private static byte[] GetSQLReport(DaDbContext db, string sql, string excel, EnumReportType reportType)
        {
            var rptDef = new ArSheetDef();

            //★Sheet定義
            var sheet = new ArColumnSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = AiReport.GetSheetName(rptDef.TemplateFullPath);
            sheet.IsLandscape = false;
            var engine = new ArSQLEngine();
            sheet.Engine = engine;
            engine.SQL = sql;

            //検索条件

            //出力方法
            var condition = new ArConditionModel();
            condition.OutputType = reportType switch
            {
                EnumReportType.PREVIEW => ArEnumOutputType.Svgz,
                EnumReportType.PDF => ArEnumOutputType.Pdf,
                EnumReportType.EXCEL => ArEnumOutputType.Excel,
                _ => throw new ArgumentException()
            };

            var result = AiReport.MakeReport(db.Session, rptDef, condition);
            return result.FileData!;
        }


        private static IArEngine GetSmartEngine(tm_eurptDto rpt, tm_euyosikisyosaiDto subSheet)
        {
            if (subSheet.yosikihouhou == Enum様式作成方法.データソース)
            {
                switch (subSheet.yosikisyubetu)
                {
                    case Enum様式種別.集計表:
                        return new ArSmartGroupEngine();

                    default:
                        return new ArSmartListEngine();
                }
            }
            else if (subSheet.yosikihouhou == Enum様式作成方法.プロシージャ)
            {
                switch (subSheet.yosikisyubetu)
                {
                    case Enum様式種別.集計表:
                        return new ArSPEngine(ArEnumEngineType.Summary);

                    default:
                        return new ArSPEngine();

                }

            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private static IArSubSheetDef GetSubSheetDef(ref ArConditionModel condition, tm_euyosikiDto sheet, tm_euyosikisyosaiDto subSheet)
        {
            switch (subSheet.yosikisyubetu)
            {
                case Enum様式種別.一覧表:
                    return (subSheet.meisaikoteikbn == EnumToStr(Enum行列固定.可変)) ? new ArListSheetDef() : new ArPageListSheetDef();

                case Enum様式種別.台帳:
                    if (subSheet.meisaiflg)
                    {
                        return (subSheet.meisaikoteikbn == EnumToStr(Enum行列固定.可変)) ? new ArListSheetDef() : new ArPageListSheetDef();
                    }
                    else
                    {
                        return new ArPageSheetDef();
                    }
                //return (subSheet.meisaiflg) ? new ArPageListSheetDef() : new ArPageSheetDef();

                case Enum様式種別.経年表:
                    return new ArColumnSheetDef();

                case Enum様式種別.集計表:
                    switch (subSheet.yosikikbn)
                    {
                        case Enum様式種別詳細.単純集計表:
                            return (subSheet.meisaikoteikbn == EnumToStr(Enum行列固定.固定)) ? new ArPageListSheetDef() : new ArListSheetDef();

                        case Enum様式種別詳細.クロス集計:
                            var lstSheet = new ArPageListSheetDef();
                            lstSheet.IsNullToZero = subSheet.nulltozeroflg;
                            lstSheet.IsMain = true;
                            condition.CrossOption.AutoCross = subSheet.meisaikoteikbn != EnumToStr(Enum行列固定.固定);
                            return lstSheet;

                        default:
                            throw new ArgumentException();
                    }
                case Enum様式種別.カスタマイズ:
                    switch (subSheet.yosikikbn)
                    {
                        case Enum様式種別詳細.はがき:
                            return new ArGridSheetDef();

                        case Enum様式種別詳細.アドレスシール:
                            return new ArGridSheetDef();

                        case Enum様式種別詳細.バーコードシール:
                            return new ArGridSheetDef();

                        case Enum様式種別詳細.宛名台帳:
                            return new ArPageSheetDef();

                        default:
                            throw new ArgumentException();
                    }

                default:
                    // 上記以外の場合
                    return new ArPageSheetDef();
                   // throw new ArgumentException();
            }
        }

        /// <summary>
        /// 詳細検索のSQL作成
        /// </summary>
        private static string GetDetailSql(Dictionary<string, object>? detailSearchDic)
        {
            if (detailSearchDic == null || !detailSearchDic.Any()) return string.Empty;

            var list = new List<string>();
            foreach (var de in detailSearchDic)
            {
                switch (de.Key)
                {
                    case nameof(tt_afatenaDto.juminjotai):
                        {
                            //住民状態    "juminjotai"  string[]
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.juminjotai)}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.jutokbn):
                        {
                            //住登区分       "jutokbn"   string[]
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.jutokbn)}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.juminsyubetu):
                        {
                            //住民種別   "juminsyubetu"  string[]
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.juminsyubetu)}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.sex):
                        {
                            //性別    "sex" string[]
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.sex)}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        break;

                    case "age":
                        {
                            //年齢   "age" DaAgeFilter()
                            var value = (DaAgeFilter)de.Value;
                            list.Add(value.ToString());
                        }
                        break;

                    case nameof(tt_afatenaDto.bymd):
                        {
                            //生年月日  "bymd" DaBirthdayFilter()
                            var value = (DaBirthdayFilter)de.Value;
                            list.Add(value.ToString());
                        }
                        break;

                    case nameof(tt_afatenaDto.simei):
                        {
                            //氏名   "simei"  string
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.simei_yusen)}";
                            var value = (string)de.Value;
                            var s = GetSql_Like(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.adrs_sikucd):
                        {
                            //住所（都道府県)		"adrs_sikucd" string
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs_sikucd)}";
                            var value = (string)(de.Value);
                            var s = GetSql_Like(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.adrs_tyoazacd):
                        {
                            //住所（町字）  "adrs_tyoazacd"   string
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.adrs_tyoazacd)}";
                            var value = (string)de.Value;
                            var s = GetSql_Like(field, value);
                            list.Add(s);
                        }
                        break;

                    case nameof(tt_afatenaDto.gyoseikucd):
                        {
                            //行政区  "gyoseikucd"  string[]
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.gyoseikucd)}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        break;
                    default:
                        //地区管理コード1～10   "tikukanricd1～10"    string[]
                        string name = nameof(tt_afatenaDto.tikukanricd1);
                        var len = name.Length - 1;
                        var key = de.Key;
                        if (key.Length < len) throw new Exception("Wrong key!");
                        if (key[..len] == name[..len])
                        {
                            var field = $"{tt_afatenaDto.TABLE_NAME}.{key}";
                            var value = (string[])de.Value;
                            var s = GetSql_In(field, value);
                            list.Add(s);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                        break;
                }
            }
            return string.Join(" AND ", list);
        }

        /// <summary>
        /// Joinサブ文組み立て
        /// </summary>
        private static void SetJoinSubInfo(DaDbContext db, ref ArSheetDefBase subSheetBase, List<tm_eudatasourcejoinDto> joins, ref List<ArTableRelationDef> relations,
            List<string> joinTables, List<string> joinRefTables, string strMainTableID)
        {
            var tablejoin = DaEucCacheService.GetEutablejoinDtoList(db);
            foreach (var join in joins)
            {
                var relation = new ArTableRelationDef();
                var table = DaEucCacheService.GetTm_eutableByTablealias(db, join.tablealias!);
                if (table != null)
                {
                    relation.TableName = table.tablenm;
                }
                else
                {
                    relation.TableName = join.tablealias;
                }
                //InnerJion／LeftJion判定
                if (subSheetBase.WhereTables.Contains(relation.TableName))
                {
                    relation.IsLeftJoin = false;
                }
                else
                {
                    relation.IsLeftJoin = true;
                }
                relation.MainTableID = strMainTableID;
                relation.TableID = join.tablealias;
                relation.RefTableID = join.kanrentablealias;
                var joinDtl = tablejoin.Find(e => e.tablealias == join.tablealias && e.kanrentablealias == join.kanrentablealias);
                if (joinDtl != null)
                {
                    relation.JoinString = joinDtl!.ketugosql;
                }
                else
                {
                    relation.JoinString = join.ketugosql;
                }
                if (!joinTables.Contains(relation.JoinString) || joinRefTables.Contains(relation.TableID))
                {
                    relations.Add(relation);
                }
            }
        }

        /// <summary>
        /// 追加パラメタ
        /// </summary>
        private class TransData
        {
            public EnumMakeWorkKbn workKbn = EnumMakeWorkKbn.宛名番号ログ;
            public bool pnouseflg;
            public long sessionseq = 0;
            public string reguserid;
            public DateTime syoridttmt = DaUtil.Now;

            // コンストラクタ
            public TransData()
            { }

            // コンストラクタ
            public TransData(EnumMakeWorkKbn workKbn, bool pnouseflg, long sessionseq, string reguserid, DateTime syoridttmt)
            {
                this.workKbn = workKbn;
                this.pnouseflg = pnouseflg;
                this.sessionseq = sessionseq;
                this.reguserid = reguserid;
                this.syoridttmt = syoridttmt;
            }
        }

        /// <summary>
        /// Join文ソート
        /// </summary>
        private class JionComparer : IComparer<ArTableRelationDef?>
        {
            public int Compare(ArTableRelationDef? x, ArTableRelationDef? y)
            {
                int mcountx, mcounty;
                if (x == null || y == null) return 0;
                if (x.TableID.Equals(y.RefTableID)) return -1;
                if (isSort(x, out mcountx) && !isSort(y, out mcounty)) return -1;
                if (isSort(x, out mcountx) && isSort(y, out mcounty) && mcountx < mcounty) return -1;
                //if (x.RefTableID.Equals(y.RefTableID)) return 0;
                //if (x.JoinString.Contains(y.TableID + ".")) return 1;

                return 0;
            }
        }

        /// <summary>
        /// メインテーブルソート
        /// </summary>
        private static bool isSort(ArTableRelationDef? objJoin, out int mcount)
        {
            var arrJoins = objJoin!.JoinString.Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries);
            mcount = arrJoins.Length;
            bool isContain = false;
            foreach (var joinsSub in arrJoins)
            {
                if (isContain) break;
                var arrJoinsSub = joinsSub.Split('=');
                foreach (var joins in arrJoinsSub)
                {
                    if (isContain) break;
                    isContain = joins.Contains(objJoin!.MainTableID + ".");
                }
            }

            return isContain;
        }


        private static string GetSql_In(string field, string[] ins)
        {
            var items = ins.Select(e => $"'{e}'").ToList();
            return $"{field} IN ({string.Join(",", items)})";
        }

        private static string GetSql_Like(string field, string s)
        {
            return $"{field} LIKE '%{s}%'";
        }

        /// <summary>
        /// 参照テーブルID取得
        /// </summary>
        private static List<String> GetTables(string mStr)
        {
            MatchCollection matches = Regex.Matches(mStr, @"\(([^)]*)\)");
            List<string> retLst = new List<string>();
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                string content = match.Groups[1].Value;
                string[] parts = content.Split(',');
                foreach (string part in parts)
                {
                    string[] subParts = part.Trim().Split('.');
                    if (subParts.Length > 1)
                    {
                        retLst.Add(subParts[0]);
                    }
                }
            }
            return retLst;
        }

        /// <summary>
        /// 件数表年齢リスト
        /// </summary>
        private static List<string> GetAgeList()
        {
            var list = new List<string>();
            for (int i = -1; i < 100; i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }

        /// <summary>
        /// 件数表年齢ヘッダー情報
        /// </summary>
        private static List<string> GetAgeCaptionList()
        {
            var list = new List<string>();
            list.Add("不明");
            for (int i = 0; i < 100; i++)
            {
                list.Add(i.ToString() + "才");
            }
            return list;
        }

        private static ArRelationDef GetRelation()
        {
            var relationDef = new ArRelationDef();
            relationDef.MainTableName = tt_afatenaDto.TABLE_NAME;
            relationDef.MainTableID = "T";
            return relationDef;
        }

        private static Dictionary<string, ArConditionDef> GetConditionDef()
        {
            var dic = new Dictionary<string, ArConditionDef>();
            //検索条件
            var conditionDef1 = new ArConditionDef();
            conditionDef1.Name = "氏名";
            conditionDef1.Sql = $"T.{nameof(tt_afatenaDto.simei)} LIKE @{nameof(tt_afatenaDto.simei)}";
            conditionDef1.ParameterList.Add($"{nameof(tt_afatenaDto.simei)}");
            conditionDef1.TableIDList.Add($"T");
            dic.Add(conditionDef1.Name, conditionDef1);

            return dic;
        }
    }
}

