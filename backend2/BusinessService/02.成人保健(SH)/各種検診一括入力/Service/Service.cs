/*using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml;

namespace AFFECTv2
{
    public class KK_kosin_ikkatu_import
    {
        // ' 定数定義：PGごとで変更
        private const string mPGNAME = "KK_kosin_ikkatu_import";

        private const string mSHORIMEI = "一括入力・取込兼用処理";
        private AdvanceSoftware.VBReport8.Web.WebCellReport _xlsRep;

        private AdvanceSoftware.VBReport8.Web.WebCellReport xlsRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _xlsRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _xlsRep = value;
            }
        }

        private System.ComponentModel.IContainer components;

        public const string DISPTYPEKBN_NUM = "001";
        public const string DISPTYPEKBN_DATE = "002";
        public const string DISPTYPEKBN_CD = "003";
        private const int COMMAND_TIMEOUT = 600;

        private CM_dbaccess db = new CM_dbaccess();

        /// <summary>
        /// 取込処理画面で使用する種別コードを抽出する。
        /// </summary>
        /// <param name="pgid">プログラムＩＤ</param>
        /// <param name="jikkokbn">実行区分(1:取込処理,2:一括入力)</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_FormInitImp(string pgid, string jikkokbn)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string systemcd;

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更
                    {
                        ref var withBlock = ref newXML;

                        rootElemRESULTXML = withBlock.CreateElement("RESULTXML");

                        // 処理コード取得処理
                        var argconn = conn;
                        systemcd = CM_kyotu_proc.pubf_createSystemCd(pgid, ref argconn, ref newXML, ref rootElemRESULTXML);

                        // アップロードURL取得
                        var argconn1 = conn;
                        pubf_GetUpURL(ref argconn1, ref newXML, ref rootElemRESULTXML);

                        // 種類取得
                        SQL = "SELECT                                                  " + Constants.vbCr;
                        SQL += "     CF.CD       AS  DATA                              " + Constants.vbCr;
                        SQL += "    ,CF.NAIYO    AS  LABEL                             " + Constants.vbCr;
                        SQL += "    ,CF.BIKO     AS  BIKO                              " + Constants.vbCr;
                        SQL += "    ,CF.KBN1     AS  KBN1                              " + Constants.vbCr;
                        SQL += "    ,CF.KBN2     AS  KBN2                              " + Constants.vbCr;
                        SQL += "    ,CF.KBN3     AS  KBN3                              " + Constants.vbCr;
                        SQL += "    ,CM.KETA     AS  KETA                              " + Constants.vbCr;
                        SQL += "FROM dbo.TC_KKCF CF                                    " + Constants.vbCr;
                        SQL += "     LEFT    JOIN    dbo.TC_KKCFMAIN CM                " + Constants.vbCr;
                        SQL += "         ON  CF.MAINCD =   CM.MAINCD                   " + Constants.vbCr;
                        SQL += "         AND CF.SUBCD  =   CM.SUBCD                    " + Constants.vbCr;
                        SQL += "WHERE    CF.MAINCD = '01'                              " + Constants.vbCr;
                        SQL += "     AND CF.SUBCD  = '306'                             " + Constants.vbCr;
                        SQL += "     AND LEFT(CF.CD, 2) = LEFT('" + systemcd + "', 2)  " + Constants.vbCr;
                        SQL += "ORDER    BY  CONVERT(INT, CF.KBN1), CF.CD              " + Constants.vbCr;

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MSYURUI", rootElemRESULTXML);
                        }

                        // 登録処理後画面制御実行フラグ取得
                        SQL = " SELECT                                                               " + Constants.vbCr;
                        SQL += "     CASE WHEN COUNT(*) > 0 THEN '1' ELSE '0' END AS DISPCTRLFLG     " + Constants.vbCr;
                        SQL += "FROM dbo.TC_KKCF CF                                                  " + Constants.vbCr;
                        SQL += "WHERE    CF.MAINCD = '98'                                            " + Constants.vbCr;
                        SQL += "     AND CF.SUBCD  = '033'                                           " + Constants.vbCr;
                        SQL += "     AND CF.CD     = '001'                                           " + Constants.vbCr;
                        SQL += "     AND CF.NAIYO  LIKE '''" + pgid.ToString() + "'''                " + Constants.vbCr;

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MDISPCTRLFLG", rootElemRESULTXML);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            return newXML;
        }

        /// <summary>
        /// 取込エラーリストの出力を行う
        /// </summary>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="syoricd">処理コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_repCreate(string systemcd, string userid, string nendo, string syoricd, string edano, string yosikicd, string jikkokbn, string taisyo, string outputtype)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL;
            string itemNm = "";
            string xlsPass = "";
            string crtPass = "";
            string urlPass = "";
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");

            string repName;
            SqlDataAdapter da;
            DataTable dt;
            int y;
            string[] splItem;
            int pageCnt;
            var field = new string[6];
            bool bFind;
            string wkTableName = "WK_" + syoricd + "_" + edano;
            string errTableName = "WK_ERR_" + syoricd + "_" + edano;
            string syoriNm;

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    repName = "一括入力取込エラーリスト";

                    if (outputtype == "1")
                    {
                        // デザインファイルのパスを取得する。
                        bFind = CM_kyotu_proc.pubf_GetDesignFile(repName, ref xlsPass);

                        // デザインファイルが見つからなかったらErrorを返却する。
                        if (!bFind)
                        {
                            CM_kyotu_proc.pub_Status(1, 53, "(" + repName + ".xlsx)", newXML, "STATUS", rootElemRESULTXML);
                            return newXML;
                        }
                    }

                    // '出力先
                    switch (outputtype ?? "")
                    {
                        case "1": // '(EXCEL)
                            {
                                crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsKakuno"].ToString() + userid + "_" + repName + strNow + ".xlsx";
                                urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsUrl"].ToString() + userid + "_" + repName + strNow + ".xlsx";
                                break;
                            }
                        case "2": // '(CSV)
                            {
                                crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["csvKakuno"].ToString() + userid + "_" + repName + strNow + ".csv";
                                urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["csvUrl"].ToString() + userid + "_" + repName + strNow + ".csv";
                                break;
                            }
                    }

                    // 処理名取得
                    syoriNm = GetSyoriNm(conn, syoricd, edano);

                    // 抽出項目取得
                    SQL = createSQL_SelectErrorList(yosikicd, conn, wkTableName, errTableName, ref itemNm);
                    itemNm += "行番号|!エラー内容|!";

                    switch (outputtype ?? "")
                    {
                        case "1": // '(EXCEL)
                            {
                                da = new SqlDataAdapter(SQL, conn);
                                dt = new DataTable();
                                da.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    CM_kyotu_proc.pub_Status(0, 2, "", newXML, "STATUS", rootElemRESULTXML);
                                    return newXML;
                                }

                                components = new System.ComponentModel.Container();
                                xlsRep = new AdvanceSoftware.VBReport8.Web.WebCellReport(components);
                                xlsRep.FileName = xlsPass;

                                xlsRep.Report.Start();
                                xlsRep.Report.File();

                                pageCnt = 1;

                                // 取込エラーリスト
                                xlsRep.Page.Start(repName, "1");
                                splItem = Strings.Split(itemNm, "|!");

                                y = 0;
                                for (int rowIndex = 0, loopTo = dt.Rows.Count - 1; rowIndex <= loopTo; rowIndex++)
                                {
                                    if (xlsRep.Page.TotalCount % CM_kyotu_proc.MAX_PAGE_CNT == 0)
                                    {
                                        xlsRep.Page.End();
                                        pageCnt += 1;
                                        xlsRep.Page.Start(repName, pageCnt.ToString());
                                    }
                                    if (y == 0)
                                    {
                                        xlsRep.Cell("A1").Value = repName + "(" + syoriNm + ")";

                                        for (int itemIndx = 0, loopTo1 = splItem.Length - 2; itemIndx <= loopTo1; itemIndx++)
                                            xlsRep.Cell("**フィールド" + (itemIndx + 1)).Value = splItem[itemIndx];
                                    }

                                    xlsRep.Page.Repeat(1, 75);
                                    for (int itemIndx = 0, loopTo2 = splItem.Length - 2; itemIndx <= loopTo2; itemIndx++)
                                    {
                                        string item = splItem[itemIndx];
                                        xlsRep.Cell("**データ" + (itemIndx + 1), 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[rowIndex][item].ToString());
                                    }
                                    xlsRep.Cell("**行番号", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[rowIndex]["行番号"].ToString());
                                    xlsRep.Cell("**エラー内容", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[rowIndex]["エラー内容"].ToString());

                                    if (y == 68)
                                    {
                                        xlsRep.Page.Next(true);
                                        y = 0;
                                    }
                                    else
                                    {
                                        y += 2;
                                    }
                                }

                                xlsRep.Page.End();

                                xlsRep.Report.End();
                                xlsRep.Report.SaveAs(crtPass);
                                break;
                            }

                        case "2": // '(CSV)
                            {
                                if (CM_kyotu_proc.pubf_CreateCSV(SQL, crtPass) == false)
                                {
                                    CM_kyotu_proc.pub_Status(0, 3, "", newXML, "STATUS", rootElemRESULTXML);
                                    return newXML;
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
                finally
                {
                    // エラーチェック時はエラーテーブル削除
                    executeDropTable(conn, errTableName);
                }
            }

            CM_kyotu_proc.pub_URLPath(newXML, rootElemRESULTXML, urlPass);
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 個人情報を取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_KojinKensaku(string systemcd, string userid, string kojinno, string gyono, string yosikicd)
        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            SqlCommand cmd;
            string SQL;

            Param = "func_KojinKensaku(" + systemcd + "," + userid + "," + kojinno + "," + yosikicd + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更
                    {
                        ref var withBlock = ref newXML;
                        rootElemRESULTXML = withBlock.CreateElement("RESULTXML");

                        // 検索情報
                        SQL = "SELECT                                       " + Constants.vbCr;
                        SQL += "         '" + gyono + "' AS  GYONO          " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.CommandText = SQL;

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MINFO", rootElemRESULTXML);
                        }

                        // '個人情報取得
                        executeSelectKojinInfo(conn, kojinno, yosikicd, ref newXML, ref rootElemRESULTXML);
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), kojinno, "");

            return newXML;
        }

        /// <summary>
        /// 取込情報の履歴情報を取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="syoricd">処理CD</param>
        /// <param name="edano">処理CD枝番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Rireki(string systemcd, string userid, string syoricd, string edano)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            // ログ採取用
            Param = "func_Rireki(" + systemcd + "," + userid + "," + syoricd + "," + edano + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    SQL = " SELECT                                              " + Constants.vbCr;
                    SQL += "        LO.TAISYO                    AS TAISYO      " + Constants.vbCr;
                    SQL += "       ,LO.PATHNAME                  AS PATHNAME    " + Constants.vbCr;
                    SQL += "       ,LO.SYORIYMD                  AS SYORIYMD    " + Constants.vbCr;
                    SQL += "       ,US.USERNAME                  AS USERID      " + Constants.vbCr;
                    SQL += "       ,LO.INPUTKENSU                AS INPUTKENSU  " + Constants.vbCr;
                    SQL += "       ,LO.OUTPUTKENSU               AS OUTPUTKENSU " + Constants.vbCr;
                    SQL += " FROM TC_KKTORIIKKATULOG LO                         " + Constants.vbCr;
                    SQL += " INNER JOIN TC_KKUSER US                            " + Constants.vbCr;
                    SQL += " 		ON  US.USER_ID = LO.USERID                  " + Constants.vbCr;
                    SQL += " WHERE LO.SYORICD = '" + syoricd + "'               " + Constants.vbCr;
                    SQL += "   AND LO.EDANO = '" + edano + "'                   " + Constants.vbCr;
                    SQL += " ORDER BY LO.SYORIYMD DESC                          " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "RIREKI", rootElemRESULTXML);
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 取込情報画面で使用するデータを抽出する。
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="nendo">対象年度</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Kensaku(string systemcd, string userid, string syoricd, string edano, string nendo)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;

            // ログ採取用
            Param = "func_Kensaku(" + systemcd + "," + userid + "," + syoricd + "," + edano + "," + nendo + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    SQL = " SELECT KT.SYORICD                  AS SYORICD             " + Constants.vbCr;
                    SQL += "      ,KT.EDANO                    AS EDANO               " + Constants.vbCr;
                    SQL += "      ,KT.SYORINM                  AS SYORINM             " + Constants.vbCr;
                    SQL += "      ,KT.YOSIKICD                 AS YOSIKICD            " + Constants.vbCr;
                    SQL += "      ,KT.INSUPDKBN                AS INSUPDKBN           " + Constants.vbCr;
                    SQL += "      ,KT.JIKKOKBN                 AS JIKKOKBN            " + Constants.vbCr;
                    SQL += "      ,KT.NENDOSIYOFLG             AS NENDOSIYOFLG        " + Constants.vbCr;
                    SQL += "      ,KT.FILEPATH                 AS FILEPATH            " + Constants.vbCr;
                    SQL += "      ,KT.FILENM                   AS FILENM              " + Constants.vbCr;
                    SQL += "      ,KT.HFILENM                  AS HFILENM             " + Constants.vbCr;
                    SQL += "      ,KT.ORDERID                  AS ORDERID             " + Constants.vbCr;
                    SQL += "      ,KT.DISPCHKFLG               AS DISPCHKFLG          " + Constants.vbCr;
                    SQL += "      ,KT.DISPROWFLG               AS DISPROWFLG          " + Constants.vbCr;
                    SQL += "      ,KT.DISPADDFLG               AS DISPADDFLG          " + Constants.vbCr;
                    SQL += "      ,KT.DISPDELFLG               AS DISPDELFLG          " + Constants.vbCr;
                    SQL += "      ,TL.SYORIYMD                 AS SYORIYMD            " + Constants.vbCr;
                    SQL += "      ,US.USERNAME                 AS USERNAME            " + Constants.vbCr;
                    SQL += "      ,''                          AS UPLFLG              " + Constants.vbCr;
                    SQL += "FROM TC_KKTORIIKKATU KT                                   " + Constants.vbCr;
                    SQL += "    LEFT JOIN                                             " + Constants.vbCr;
                    SQL += "    (                                                     " + Constants.vbCr;
                    SQL += "    SELECT SYORICD, EDANO, MAX(SYORIYMD) AS SYORIYMD      " + Constants.vbCr;
                    SQL += "    FROM TC_KKTORIIKKATULOG                               " + Constants.vbCr;
                    SQL += "    WHERE SYORICD = '" + syoricd + "'                     " + Constants.vbCr;
                    // ' 対象年度に値が設定されている場合
                    if (!string.IsNullOrEmpty(nendo))
                    {
                        SQL += "  AND   CONVERT(NVARCHAR, SYORIYMD, 111) BETWEEN      " + Constants.vbCr;
                        SQL += "        '" + CM_kyotu_proc.pubf_CnvSeireki(nendo) + "/04/01' AND    " + Constants.vbCr;
                        SQL += "        '" + (CM_kyotu_proc.pubf_CnvSeireki(nendo) + 1) + "/03/31'  " + Constants.vbCr;
                    }
                    SQL += "    GROUP BY SYORICD, EDANO                               " + Constants.vbCr;
                    SQL += "    ) LT                                                  " + Constants.vbCr;
                    SQL += "    ON  LT.SYORICD = KT.SYORICD                           " + Constants.vbCr;
                    SQL += "    AND LT.EDANO = KT.EDANO                               " + Constants.vbCr;
                    SQL += "    LEFT JOIN TC_KKTORIIKKATULOG TL                       " + Constants.vbCr;
                    SQL += "    ON  LT.SYORICD = TL.SYORICD                           " + Constants.vbCr;
                    SQL += "    AND LT.EDANO = TL.EDANO                               " + Constants.vbCr;
                    SQL += "    AND LT.SYORIYMD = TL.SYORIYMD                         " + Constants.vbCr;
                    SQL += "    LEFT JOIN TC_KKUSER US                                " + Constants.vbCr;
                    SQL += "    ON  US.USER_ID = TL.USERID                            " + Constants.vbCr;
                    SQL += "WHERE KT.SYORICD = '" + syoricd + "'                      " + Constants.vbCr;
                    SQL += "ORDER BY CONVERT(INT, KT.ORDERID)                         " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);
                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MEISAI", rootElemRESULTXML);
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 取込情報画面で使用するデータグリッド用のレイアウトデータを抽出する。
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Layout(string systemcd, string userid, string yosikicd, string jikkokbn)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;

            // ログ採取用
            Param = "func_Layout(" + systemcd + "," + userid + "," + yosikicd + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    SQL = createSQL_TC_KKTORIIKKATUITEM(yosikicd, jikkokbn);
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "DLAYOUT", rootElemRESULTXML);
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message + ex.StackTrace, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 取込情報画面で使用するデータグリッドのデータを取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="filename">ファイル名</param>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_GetFileData(string systemcd, string userid, string filename, string yosikicd, string syoricd, string edano)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string strCsvData = "";
            string csvPath = System.Configuration.ConfigurationManager.ConnectionStrings["importKakuno"].ToString();
            var entity = new TC_KKTORI_YOSIKI_Entity();
            SqlTransaction wkTrn = null;
            var htParam = new Hashtable();
            string wkTableName = "";
            var dt = new DataTable();
            SqlDataAdapter da;
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");

            // ログ採取用
            Param = "func_GetFileData(" + systemcd + "," + userid + "," + filename + "," + yosikicd + "," + syoricd + "," + edano + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    if (!System.IO.File.Exists(csvPath + filename))
                    {
                        CM_kyotu_proc.pub_Status(1, 38, "", newXML, "STATUS", rootElemRESULTXML);
                        return newXML;
                    }

                    entity = GetTcKkToriYosiki(conn, yosikicd, wkTrn);

                    // 取込ファイル様式取得
                    SQL = "SELECT                                             " + Constants.vbCr;
                    SQL += "    N'" + entity.KEISIKIKBN + "'  AS  KEISIKIKBN  " + Constants.vbCr;
                    SQL += "   ,N'" + entity.MOJICDKBN + "'   AS  MOJICDKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.KUGIRIKBN + "'   AS  KUGIRIKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.INYOFUKBN + "'   AS  INYOFUKBN   " + Constants.vbCr;
                    SQL += "   ," + entity.HEADERROW + "      AS  HEADERROW   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MYOSIKI", rootElemRESULTXML);
                    }

                    wkTrn = conn.BeginTransaction();

                    // 固定長
                    ArrayList importDataList;
                    int rowCount;
                    string[] splCsvData;
                    string row;
                    string encode = getYosikiEncode(entity.MOJICDKBN);

                    using (var sr = new System.IO.StreamReader(csvPath + filename, System.Text.Encoding.GetEncoding(encode)))
                    {
                        strCsvData = sr.ReadToEnd();
                        strCsvData = strCsvData.Replace(Constants.vbCrLf, Constants.vbLf);
                        strCsvData = strCsvData.Replace(Constants.vbCr, Constants.vbLf);

                        splCsvData = Strings.Split(strCsvData, Constants.vbLf);
                        importDataList = new ArrayList();

                        // 最終行(EOF)は取込まない
                        var loopTo = splCsvData.Length - 2;
                        for (rowCount = 0; rowCount <= loopTo; rowCount++)
                        {
                            if (rowCount >= entity.HEADERROW)
                            {
                                row = splCsvData[rowCount];
                                importDataList.Add(row);
                            }
                        }
                    }

                    wkTableName = "WK_" + syoricd + "_" + edano;

                    htParam.Add("yosikicd", yosikicd);

                    executeDropTable(conn, wkTableName, wkTrn);
                    executeCreateWkTable(conn, wkTableName, "", htParam, wkTrn);

                    // 取込項目取得
                    SQL = "SELECT                                            " + Constants.vbCr;
                    SQL += "     KOMOKUCD   AS  KOMOKUCD                     " + Constants.vbCr;
                    SQL += "    ,INPKETASU  AS  INPKETASU                    " + Constants.vbCr;
                    SQL += "FROM  dbo.TC_KKTORIIKKATUITEM                    " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("WHERE YOSIKICD = '", htParam["yosikicd"]), "'   "), Constants.vbCr));
                    SQL += "  AND INPORDERID IS NOT NULL                     " + Constants.vbCr;
                    SQL += "ORDER BY CONVERT(INT, INPORDERID)                " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (entity.KEISIKIKBN == "2")
                    {
                        executeDropTable(conn, "##TORI_PRE" + strNow, wkTrn);
                        SQL = " CREATE TABLE ##TORI_PRE" + strNow + "(     " + Constants.vbCr;
                        SQL += "      [GYONO] [NVARCHAR](4000) NULL        " + Constants.vbCr;
                        SQL += "     ,[NAIYO] [NVARCHAR](4000) NULL        " + Constants.vbCr;
                        SQL += " )                                         " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        int gyono = 1;
                        foreach (string importData in importDataList)
                        {
                            SQL = "    INSERT INTO ##TORI_PRE" + strNow + " ( " + Constants.vbCr;
                            SQL += "         GYONO                            " + Constants.vbCr;
                            SQL += "        ,NAIYO                            " + Constants.vbCr;
                            SQL += "     )VALUES(                             " + Constants.vbCr;
                            SQL += "          '" + gyono + "'                 " + Constants.vbCr;
                            SQL += "        ,N'" + importData + "'            " + Constants.vbCr;
                            SQL += "     )                                    " + Constants.vbCr;

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.CommandTimeout = COMMAND_TIMEOUT;
                            cmd.ExecuteNonQuery();

                            gyono = gyono + 1;
                        }

                        // データを分割
                        int kei = 1;
                        int keta = 0;
                        string SQL_Insert = "";
                        string SQL_Select = "";

                        for (int rowIndx = 0, loopTo1 = dt.Rows.Count - 1; rowIndx <= loopTo1; rowIndx++)
                        {
                            SQL_Insert += ",";
                            SQL_Insert = Conversions.ToString(SQL_Insert + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" [", dt.Rows[rowIndx]["KOMOKUCD"]), "] "), Constants.vbCr));
                            keta = Conversions.ToInteger(dt.Rows[rowIndx]["INPKETASU"]);
                            SQL_Select += ",dbo.ZTRIM(SUBSTRING(CONVERT(TEXT, NAIYO)," + kei + "," + keta + "))" + Constants.vbCr;

                            kei = kei + keta;
                        }
                        SQL = "INSERT INTO " + wkTableName + " (  " + Constants.vbCr;
                        SQL += " GYONO                            " + Constants.vbCr;
                        SQL += SQL_Insert;
                        SQL += ")                                 " + Constants.vbCr;
                        SQL += "SELECT  GYONO                     " + Constants.vbCr;
                        SQL += SQL_Select;
                        SQL += "FROM                              " + Constants.vbCr;
                        SQL += "   ##TORI_PRE" + strNow + "       " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.CommandTimeout = COMMAND_TIMEOUT;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // 可変長
                        // データを分割
                        string[] importStr;
                        int gyono = 1;
                        string SQL_Insert = "";
                        string inyofu = "";

                        for (int rowIndx = 0, loopTo2 = dt.Rows.Count - 1; rowIndx <= loopTo2; rowIndx++)
                        {
                            SQL_Insert += ",";

                            SQL_Insert = Conversions.ToString(SQL_Insert + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" [", dt.Rows[rowIndx]["KOMOKUCD"]), "] "), Constants.vbCr));
                        }

                        if (entity.INYOFUKBN == "3")
                        {
                            // 引用符、ダブルクォーテーション混在の場合

                            // データ内カンマ、改行の置き換え文字を取得
                            string strConvComma = "、";
                            string strConvCRLF = "、";

                            SqlDataAdapter daConv;
                            DataTable dtConv;

                            SQL = "SELECT COALESCE(NAIYO, '') AS NAIYO FROM TC_KKCF WHERE MAINCD='98' AND SUBCD='CSV' AND CD='COMMA' ";
                            daConv = new SqlDataAdapter(SQL, conn);
                            daConv.SelectCommand.Transaction = wkTrn;
                            dtConv = new DataTable();
                            daConv.Fill(dtConv);
                            if (dtConv.Rows.Count > 0)
                            {
                                strConvComma = dtConv.Rows[0]["NAIYO"].ToString();
                            }

                            SQL = "SELECT COALESCE(NAIYO, '') AS NAIYO FROM TC_KKCF WHERE MAINCD='98' AND SUBCD='CSV' AND CD='CRLF' ";
                            daConv = new SqlDataAdapter(SQL, conn);
                            daConv.SelectCommand.Transaction = wkTrn;
                            dtConv = new DataTable();
                            daConv.Fill(dtConv);
                            if (dtConv.Rows.Count > 0)
                            {
                                strConvCRLF = dtConv.Rows[0]["NAIYO"].ToString();
                            }

                            // CSVをTextFieldParserで読む(データ内の改行、カンマに自動対応)
                            using (var tfp = new TextFieldParser(csvPath + filename, System.Text.Encoding.GetEncoding(encode)))
                            {
                                tfp.TextFieldType = FieldType.Delimited;
                                tfp.SetDelimiters(",");

                                // ヘッダ行を読み飛ばす
                                for (int i = 1, loopTo3 = entity.HEADERROW; i <= loopTo3; i++)
                                {
                                    if (!tfp.EndOfData)
                                    {
                                        importStr = tfp.ReadFields();
                                    }
                                }

                                // 1件毎に取込する
                                while (!tfp.EndOfData)
                                {
                                    importStr = tfp.ReadFields();

                                    SQL = "INSERT INTO " + wkTableName + " ( " + Constants.vbCr;
                                    SQL += " GYONO                           " + Constants.vbCr;
                                    SQL += SQL_Insert;
                                    SQL += ")                                " + Constants.vbCr;
                                    SQL += "SELECT                           " + Constants.vbCr;
                                    SQL += "    " + gyono + "                " + Constants.vbCr;

                                    foreach (string importItem in importStr)
                                    {
                                        string importItemTemp = importItem;
                                        // データ内の半角カンマを置き換え
                                        importItemTemp = Strings.Replace(importItem, ",", strConvComma);

                                        // データ内の改行コードを置き換え
                                        importItemTemp = Strings.Replace(importItem, Constants.vbCrLf, strConvCRLF);
                                        importItemTemp = Strings.Replace(importItem, Constants.vbCr, strConvCRLF);
                                        importItemTemp = Strings.Replace(importItem, Constants.vbLf, strConvCRLF);

                                        SQL += ",dbo.ZTRIM(" + CM_kyotu_proc.pubf_CnvNull(importItemTemp, 1) + ")" + Constants.vbCr;
                                    }

                                    cmd = conn.CreateCommand();
                                    cmd.Transaction = wkTrn;
                                    cmd.CommandText = SQL;
                                    cmd.CommandTimeout = COMMAND_TIMEOUT;
                                    cmd.ExecuteNonQuery();

                                    gyono = gyono + 1;
                                }
                            }
                        }
                        else
                        {
                            foreach (string importData in importDataList)
                            {
                                string tempStr = importData;
                                if (entity.INYOFUKBN == "1")
                                {
                                    // ダブルクォテーション
                                    inyofu = "\"";
                                }
                                else if (entity.INYOFUKBN == "2")
                                {
                                    // シングルクォテーション
                                    inyofu = "'";
                                }

                                if (entity.INYOFUKBN == "1" | entity.INYOFUKBN == "2")
                                {
                                    tempStr = Strings.Mid(tempStr, 2, tempStr.Length - 2);
                                }

                                importStr = Strings.Split(tempStr, inyofu + "," + inyofu);

                                SQL = "INSERT INTO " + wkTableName + " ( " + Constants.vbCr;
                                SQL += " GYONO                           " + Constants.vbCr;
                                SQL += SQL_Insert;
                                SQL += ")                                " + Constants.vbCr;
                                SQL += "SELECT                           " + Constants.vbCr;
                                SQL += "    " + gyono + "                " + Constants.vbCr;

                                foreach (string importItem in importStr)

                                    SQL += ",dbo.ZTRIM(" + CM_kyotu_proc.pubf_CnvNull(importItem, 1) + ")" + Constants.vbCr;

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.CommandTimeout = COMMAND_TIMEOUT;
                                cmd.ExecuteNonQuery();

                                gyono = gyono + 1;
                            }
                        }
                    }

                    // 取込書式変換
                    executeConvertForm(conn, wkTableName, entity, htParam, wkTrn);

                    // データ取得
                    if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_OMTK & syoricd.Substring(0, 2) == "03")
                    {
                        SQL = createSQL_WkTableDataFromYobouFileOMTK(syoricd, wkTableName);
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 2) == "03")
                    {
                        SQL = createSQL_WkTableDataFromYobouFileTOSK(syoricd, wkTableName);
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 4) == "0401")
                    {
                        // 健診回数取得
                        string kenkaisu = "";
                        switch (yosikicd ?? "")
                        {
                            case "04001":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[020], 2)";
                                    break;
                                }
                            case "04002":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[012], 2)";
                                    break;
                                }
                            case "04003":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[011], 2)";
                                    break;
                                }

                            default:
                                {
                                    kenkaisu = "RIGHT('00' + WK.[013], 2)";
                                    break;
                                }
                        }

                        SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, kenkaisu, syoricd.Substring(8, 2));
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 4) == "0402")
                    {
                        SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", syoricd.Substring(4, 2));
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_KARK & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "01")
                    {
                        // 受付データ
                        switch (yosikicd ?? "")
                        {
                            case "02010":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE WK.[001] IN('020','120','140')";
                                    break;
                                }
                            case "02020":
                                {
                                    // 肝炎検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "021");
                                    break;
                                }
                            case "02040":
                                {
                                    // 大腸がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "060");
                                    break;
                                }
                            case "02050":
                                {
                                    // 肺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "010");
                                    break;
                                }
                            case "02070":
                                {
                                    // 前立腺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "090");
                                    break;
                                }
                            case "02160":
                                {
                                    // 結核検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "011");
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_GEKK & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "01")
                    {
                        // 受付データ
                        switch (yosikicd ?? "")
                        {
                            case "02010":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE WK.[001] IN('020','120','140','150')";
                                    break;
                                }
                            case "02020":
                                {
                                    // 肝炎検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "021");
                                    break;
                                }
                            case "02040":
                                {
                                    // 大腸がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "060");
                                    break;
                                }
                            case "02050":
                                {
                                    // 肺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "010");
                                    break;
                                }
                            case "02070":
                                {
                                    // 前立腺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "090");
                                    break;
                                }
                            case "02160":
                                {
                                    // 結核検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "011");
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if (((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_KARK | (CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_GEKK) & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "02")
                    {
                        // 結果データ
                        switch (yosikicd ?? "")
                        {
                            case "02011":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[097], '') <> '' OR ISNULL(WK.[098], '') <> '' OR ISNULL(WK.[099], '') <> '' OR ISNULL(WK.[113], '') <> ''";
                                    break;
                                }
                            case "02021":
                                {
                                    // 肝炎検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[033], '') <> '' OR ISNULL(WK.[060], '') <> ''";
                                    break;
                                }
                            case "02041":
                                {
                                    // 大腸がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[107], '') <> '' OR ISNULL(WK.[109], '') <> '' OR ISNULL(WK.[110], '') <> ''";
                                    break;
                                }
                            case "02051":
                                {
                                    // 肺がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[100], '') <> '' OR ISNULL(WK.[103], '') <> ''";
                                    break;
                                }
                            case "02071":
                                {
                                    // 前立腺がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[112], '') <> ''";
                                    break;
                                }
                            case "02161":
                                {
                                    // 結核検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK  WHERE ISNULL(WK.[105], '') <> ''";
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TKMK)
                    {
                        // 結果データ
                        switch (syoricd ?? "")
                        {
                            case "0202000001":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[021], '') <> '' OR ISNULL(WK.[022], '') <> '' OR ISNULL(WK.[023], '') <> ''";
                                    break;
                                }
                            case "0201000001":
                                {
                                    // 肝炎検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[060], '') <> '' OR ISNULL(WK.[066], '') <> ''";
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_FUKK & (Strings.Left(syoricd, 5) == "02910" | Strings.Left(syoricd, 5) == "02920"))
                    {
                        SQL = "SELECT * FROM " + wkTableName;
                    }
                    // 複数検診のファイル取込に対応
                    else if (syoricd.Substring(0, 2) == "02" & syoricd.Substring(4, 1) == "1")
                    {
                        // 各検診の必須項目のKOMOKUCDを取得
                        SQL = " SELECT                                          " + Constants.vbCr;
                        SQL += "     B.FLDNM                                    " + Constants.vbCr;
                        SQL += "    ,B.KOMOKUCD                                 " + Constants.vbCr;
                        SQL += "FROM    TC_KKTORIIKKATU A                       " + Constants.vbCr;
                        SQL += "INNER JOIN TC_KKTORIIKKATUITEM B                " + Constants.vbCr;
                        SQL += "    ON A.YOSIKICD = B.YOSIKICD                  " + Constants.vbCr;
                        SQL += "WHERE A.SYORICD = '" + syoricd + "'             " + Constants.vbCr;

                        switch (Strings.Left(syoricd, 5) ?? "")
                        {
                            case "02011":    // 特定健診（メタボ判定、指導レベル、総合判定）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSTOKUKEN'                  " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('METABO','SIDO','SOGOH')      " + Constants.vbCr;
                                    break;
                                }
                            case "02021":    // 肝炎検診（Ｂ型結果、Ｃ型結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSKANKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAB','KEKKAC')            " + Constants.vbCr;
                                    break;
                                }
                            case "02031":    // 胃がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSIKEN'                     " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02041":    // 大腸がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSDAIKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02051":    // 肺がん検診（X線一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSHAIKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAXI')                    " + Constants.vbCr;
                                    break;
                                }
                            case "02061":    // 腹部超音波検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSFUKUBUKEN'                " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02071":    // 前立腺がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSZENRITUKEN'               " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02081":    // 子宮がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSSIKYUKEN'                 " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02091":    // 乳がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSNYUKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02101":    // 骨粗鬆症検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSKOTUKEN'                  " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02111":    // 歯周疾患検診（判定区分）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSSISYUKEN'                 " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKA')                      " + Constants.vbCr;
                                    break;
                                }
                            case "02161":    // 結核検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSRENKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                        }

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        dt = new DataTable();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        SQL = "SELECT * FROM " + wkTableName + " WK ";

                        for (int i = 0, loopTo4 = dt.Rows.Count - 1; i <= loopTo4; i++)
                        {
                            if (i == 0)
                            {
                                SQL += "WHERE ISNULL(WK.[" + dt.Rows[i]["KomokuCD"].ToString() + "], '') <> '' ";
                            }
                            else
                            {
                                SQL += "   OR ISNULL(WK.[" + dt.Rows[i]["KomokuCD"].ToString() + "], '') <> '' ";
                            }
                        }
                    }
                    else
                    {
                        SQL = "SELECT * FROM " + wkTableName;
                    }

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = COMMAND_TIMEOUT;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFILEDATA", rootElemRESULTXML);
                    }

                    // 個人情報取得
                    SQL = createSQL_SelectKojinInfo(conn, "", yosikicd, wkTableName, wkTrn);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = COMMAND_TIMEOUT;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKOJIN", rootElemRESULTXML);
                    }

                    executeDropTable(conn, wkTableName, wkTrn);

                    wkTrn.Commit();
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();

                        if (!string.IsNullOrEmpty(wkTableName))
                        {
                            executeDropTable(conn, wkTableName);
                        }
                    }

                    CM_kyotu_proc.pub_Status(99, 1, ex.Message + ex.StackTrace, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 一括入力で使用するデータグリッドのデータを取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="filename">ファイル名</param>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Jikko(string systemcd, string userid, string filename, string yosikicd, string syoricd, string edano)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string strCsvData = "";
            string csvPath = System.Configuration.ConfigurationManager.ConnectionStrings["importKakuno"].ToString();
            var entity = new TC_KKTORI_YOSIKI_Entity();
            SqlTransaction wkTrn = null;
            var htParam = new Hashtable();
            string wkTableName = "";
            var dt = new DataTable();
            SqlDataAdapter da;
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");

            // ログ採取用
            Param = "func_Jikko(" + systemcd + "," + userid + "," + filename + "," + yosikicd + "," + syoricd + "," + edano + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    if (!System.IO.File.Exists(csvPath + filename))
                    {
                        CM_kyotu_proc.pub_Status(1, 38, "", newXML, "STATUS", rootElemRESULTXML);
                        return newXML;
                    }

                    entity = GetTcKkToriYosiki(conn, yosikicd, wkTrn);

                    // 取込ファイル様式取得
                    SQL = "SELECT                                             " + Constants.vbCr;
                    SQL += "    N'" + entity.KEISIKIKBN + "'  AS  KEISIKIKBN  " + Constants.vbCr;
                    SQL += "   ,N'" + entity.MOJICDKBN + "'   AS  MOJICDKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.KUGIRIKBN + "'   AS  KUGIRIKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.INYOFUKBN + "'   AS  INYOFUKBN   " + Constants.vbCr;
                    SQL += "   ," + entity.HEADERROW + "      AS  HEADERROW   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MYOSIKI", rootElemRESULTXML);
                    }

                    wkTrn = conn.BeginTransaction();

                    // 固定長
                    ArrayList importDataList;
                    int rowCount;
                    string[] splCsvData;
                    string row;
                    string encode = getYosikiEncode(entity.MOJICDKBN);

                    using (var sr = new System.IO.StreamReader(csvPath + filename, System.Text.Encoding.GetEncoding(encode)))
                    {
                        strCsvData = sr.ReadToEnd();
                        strCsvData = strCsvData.Replace(Constants.vbCrLf, Constants.vbLf);
                        strCsvData = strCsvData.Replace(Constants.vbCr, Constants.vbLf);

                        splCsvData = Strings.Split(strCsvData, Constants.vbLf);
                        importDataList = new ArrayList();

                        // 最終行(EOF)は取込まない
                        var loopTo = splCsvData.Length - 2;
                        for (rowCount = 0; rowCount <= loopTo; rowCount++)
                        {
                            if (rowCount >= entity.HEADERROW)
                            {
                                row = splCsvData[rowCount];
                                importDataList.Add(row);
                            }
                        }
                    }

                    wkTableName = "WK_" + syoricd + "_" + edano;

                    htParam.Add("yosikicd", yosikicd);

                    executeDropTable(conn, wkTableName, wkTrn);
                    executeCreateWkTable(conn, wkTableName, "", htParam, wkTrn);

                    // 取込項目取得
                    SQL = "SELECT                                            " + Constants.vbCr;
                    SQL += "     KOMOKUCD   AS  KOMOKUCD                     " + Constants.vbCr;
                    SQL += "    ,INPKETASU  AS  INPKETASU                    " + Constants.vbCr;
                    SQL += "FROM  dbo.TC_KKTORIIKKATUITEM                    " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("WHERE YOSIKICD = '", htParam["yosikicd"]), "'   "), Constants.vbCr));
                    SQL += "  AND INPORDERID IS NOT NULL                     " + Constants.vbCr;
                    SQL += "ORDER BY CONVERT(INT, INPORDERID)                " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (entity.KEISIKIKBN == "2")
                    {
                        executeDropTable(conn, "##TORI_PRE" + strNow, wkTrn);
                        SQL = " CREATE TABLE ##TORI_PRE" + strNow + "(     " + Constants.vbCr;
                        SQL += "      [GYONO] [NVARCHAR](4000) NULL        " + Constants.vbCr;
                        SQL += "     ,[NAIYO] [NVARCHAR](4000) NULL        " + Constants.vbCr;
                        SQL += " )                                         " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        int gyono = 1;
                        foreach (string importData in importDataList)
                        {
                            SQL = "    INSERT INTO ##TORI_PRE" + strNow + "( " + Constants.vbCr;
                            SQL += "         GYONO                           " + Constants.vbCr;
                            SQL += "        ,NAIYO                           " + Constants.vbCr;
                            SQL += "     )VALUES(                            " + Constants.vbCr;
                            SQL += "          '" + gyono + "'                " + Constants.vbCr;
                            SQL += "        ,N'" + importData + "'           " + Constants.vbCr;
                            SQL += "     )                                   " + Constants.vbCr;

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.CommandTimeout = COMMAND_TIMEOUT;
                            cmd.ExecuteNonQuery();

                            gyono = gyono + 1;
                        }

                        // データを分割
                        int kei = 1;
                        int keta = 0;
                        string SQL_Insert = "";
                        string SQL_Select = "";

                        for (int rowIndx = 0, loopTo1 = dt.Rows.Count - 1; rowIndx <= loopTo1; rowIndx++)
                        {
                            SQL_Insert += ",";
                            SQL_Insert = Conversions.ToString(SQL_Insert + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" [", dt.Rows[rowIndx]["KOMOKUCD"]), "] "), Constants.vbCr));
                            keta = Conversions.ToInteger(dt.Rows[rowIndx]["INPKETASU"]);
                            SQL_Select += ",dbo.ZTRIM(SUBSTRING(CONVERT(TEXT, NAIYO)," + kei + "," + keta + "))" + Constants.vbCr;

                            kei = kei + keta;
                        }
                        SQL = "INSERT INTO " + wkTableName + " (  " + Constants.vbCr;
                        SQL += " GYONO                            " + Constants.vbCr;
                        SQL += SQL_Insert;
                        SQL += ")                                 " + Constants.vbCr;
                        SQL += "SELECT  GYONO                     " + Constants.vbCr;
                        SQL += SQL_Select;
                        SQL += "FROM                              " + Constants.vbCr;
                        SQL += "   ##TORI_PRE" + strNow + "       " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.CommandTimeout = COMMAND_TIMEOUT;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // 可変長
                        // データを分割
                        string[] importStr;
                        int gyono = 1;
                        string SQL_Insert = "";
                        string inyofu = "";

                        for (int rowIndx = 0, loopTo2 = dt.Rows.Count - 1; rowIndx <= loopTo2; rowIndx++)
                        {
                            SQL_Insert += ",";

                            SQL_Insert = Conversions.ToString(SQL_Insert + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" [", dt.Rows[rowIndx]["KOMOKUCD"]), "] "), Constants.vbCr));
                        }

                        if (entity.INYOFUKBN == "3")
                        {
                            // 引用符、ダブルクォーテーション混在の場合

                            // データ内カンマ、改行の置き換え文字を取得
                            string strConvComma = "、";
                            string strConvCRLF = "、";

                            SqlDataAdapter daConv;
                            DataTable dtConv;

                            SQL = "SELECT COALESCE(NAIYO, '') AS NAIYO FROM TC_KKCF WHERE MAINCD='98' AND SUBCD='CSV' AND CD='COMMA' ";
                            daConv = new SqlDataAdapter(SQL, conn);
                            daConv.SelectCommand.Transaction = wkTrn;
                            dtConv = new DataTable();
                            daConv.Fill(dtConv);
                            if (dtConv.Rows.Count > 0)
                            {
                                strConvComma = dtConv.Rows[0]["NAIYO"].ToString();
                            }

                            SQL = "SELECT COALESCE(NAIYO, '') AS NAIYO FROM TC_KKCF WHERE MAINCD='98' AND SUBCD='CSV' AND CD='CRLF' ";
                            daConv = new SqlDataAdapter(SQL, conn);
                            daConv.SelectCommand.Transaction = wkTrn;
                            dtConv = new DataTable();
                            daConv.Fill(dtConv);
                            if (dtConv.Rows.Count > 0)
                            {
                                strConvCRLF = dtConv.Rows[0]["NAIYO"].ToString();
                            }

                            // CSVをTextFieldParserで読む(データ内の改行、カンマに自動対応)
                            using (var tfp = new TextFieldParser(csvPath + filename, System.Text.Encoding.GetEncoding(encode)))
                            {
                                tfp.TextFieldType = FieldType.Delimited;
                                tfp.SetDelimiters(",");

                                // ヘッダ行を読み飛ばす
                                for (int i = 1, loopTo3 = entity.HEADERROW; i <= loopTo3; i++)
                                {
                                    if (!tfp.EndOfData)
                                    {
                                        importStr = tfp.ReadFields();
                                    }
                                }

                                // 1件毎に取込する
                                while (!tfp.EndOfData)
                                {
                                    importStr = tfp.ReadFields();

                                    SQL = "INSERT INTO " + wkTableName + " ( " + Constants.vbCr;
                                    SQL += " GYONO                           " + Constants.vbCr;
                                    SQL += SQL_Insert;
                                    SQL += ")                                " + Constants.vbCr;
                                    SQL += "SELECT                           " + Constants.vbCr;
                                    SQL += "    " + gyono + "                " + Constants.vbCr;

                                    foreach (string importItem in importStr)
                                    {
                                        string tempStr = importItem;
                                        // データ内の半角カンマを置き換え
                                        tempStr = Strings.Replace(tempStr, ",", strConvComma);

                                        // データ内の改行コードを置き換え
                                        tempStr = Strings.Replace(tempStr, Constants.vbCrLf, strConvCRLF);
                                        tempStr = Strings.Replace(tempStr, Constants.vbCr, strConvCRLF);
                                        tempStr = Strings.Replace(tempStr, Constants.vbLf, strConvCRLF);

                                        SQL += ",dbo.ZTRIM(" + CM_kyotu_proc.pubf_CnvNull(tempStr, 1) + ")" + Constants.vbCr;
                                    }

                                    cmd = conn.CreateCommand();
                                    cmd.Transaction = wkTrn;
                                    cmd.CommandText = SQL;
                                    cmd.CommandTimeout = COMMAND_TIMEOUT;
                                    cmd.ExecuteNonQuery();

                                    gyono = gyono + 1;
                                }
                            }
                        }
                        else
                        {
                            foreach (string importData in importDataList)
                            {
                                string tempStr = importData;
                                if (entity.INYOFUKBN == "1")
                                {
                                    // ダブルクォテーション
                                    inyofu = "\"";
                                }
                                else if (entity.INYOFUKBN == "2")
                                {
                                    // シングルクォテーション
                                    inyofu = "'";
                                }

                                if (entity.INYOFUKBN == "1" | entity.INYOFUKBN == "2")
                                {
                                    tempStr = Strings.Mid(tempStr, 2, tempStr.Length - 2);
                                }

                                importStr = Strings.Split(tempStr, inyofu + "," + inyofu);

                                SQL = "INSERT INTO " + wkTableName + " ( " + Constants.vbCr;
                                SQL += " GYONO                           " + Constants.vbCr;
                                SQL += SQL_Insert;
                                SQL += ")                                " + Constants.vbCr;
                                SQL += "SELECT                           " + Constants.vbCr;
                                SQL += "    " + gyono + "                " + Constants.vbCr;

                                foreach (string importItem in importStr)

                                    SQL += ",dbo.ZTRIM(" + CM_kyotu_proc.pubf_CnvNull(importItem, 1) + ")" + Constants.vbCr;

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.CommandTimeout = COMMAND_TIMEOUT;
                                cmd.ExecuteNonQuery();

                                gyono = gyono + 1;
                            }
                        }
                    }
                    // 取込書式変換
                    executeConvertForm(conn, wkTableName, entity, htParam, wkTrn);

                    // データ取得
                    if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_OMTK & syoricd.Substring(0, 2) == "03")
                    {
                        SQL = createSQL_WkTableDataFromYobouFileOMTK(syoricd, wkTableName);
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 2) == "03")
                    {
                        SQL = createSQL_WkTableDataFromYobouFileTOSK(syoricd, wkTableName);
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 4) == "0401")
                    {
                        // 健診回数取得
                        string kenkaisu = "";
                        switch (yosikicd ?? "")
                        {
                            case "04001":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[020], 2)";
                                    break;
                                }
                            case "04002":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[012], 2)";
                                    break;
                                }
                            case "04003":
                                {
                                    kenkaisu = "RIGHT('00' + WK.[011], 2)";
                                    break;
                                }

                            default:
                                {
                                    kenkaisu = "RIGHT('00' + WK.[013], 2)";
                                    break;
                                }
                        }

                        SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, kenkaisu, syoricd.Substring(8, 2));
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TOSK & syoricd.Substring(0, 4) == "0402")
                    {
                        SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", syoricd.Substring(4, 2));
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_ARIK)
                    {
                        // 結果データ
                        switch (yosikicd ?? "")
                        {
                            case "02020":
                                {
                                    // 肝炎検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[090], '') <> '' OR ISNULL(WK.[091], '') <> '' OR ISNULL(WK.[092], '') <> '' OR ISNULL(WK.[093], '') <> ''";
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_KARK & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "01")
                    {
                        // 受付データ
                        switch (yosikicd ?? "")
                        {
                            case "02010":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE WK.[001] IN('020','120','140')";
                                    break;
                                }
                            case "02020":
                                {
                                    // 肝炎検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "021");
                                    break;
                                }
                            case "02040":
                                {
                                    // 大腸がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "060");
                                    break;
                                }
                            case "02050":
                                {
                                    // 肺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "010");
                                    break;
                                }
                            case "02070":
                                {
                                    // 前立腺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "090");
                                    break;
                                }
                            case "02160":
                                {
                                    // 結核検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "011");
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_GEKK & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "01")
                    {
                        // 受付データ
                        switch (yosikicd ?? "")
                        {
                            case "02010":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE WK.[001] IN('020','120','140','150')";
                                    break;
                                }
                            case "02020":
                                {
                                    // 肝炎検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "021");
                                    break;
                                }
                            case "02040":
                                {
                                    // 大腸がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "060");
                                    break;
                                }
                            case "02050":
                                {
                                    // 肺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "010");
                                    break;
                                }
                            case "02070":
                                {
                                    // 前立腺がん検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "090");
                                    break;
                                }
                            case "02160":
                                {
                                    // 結核検診
                                    SQL = createSQL_WkTableDataOnCondition(syoricd, wkTableName, "WK.[001]", "011");
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if (((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_KARK | (CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_GEKK) & syoricd.Substring(0, 2) == "02" & syoricd.Substring(syoricd.Length - 2, 2) == "02")
                    {
                        // 結果データ
                        switch (yosikicd ?? "")
                        {
                            case "02011":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[097], '') <> '' OR ISNULL(WK.[098], '') <> '' OR ISNULL(WK.[099], '') <> '' OR ISNULL(WK.[113], '') <> ''";
                                    break;
                                }
                            case "02021":
                                {
                                    // 肝炎検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[033], '') <> '' OR ISNULL(WK.[060], '') <> ''";
                                    break;
                                }
                            case "02041":
                                {
                                    // 大腸がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[107], '') <> '' OR ISNULL(WK.[109], '') <> '' OR ISNULL(WK.[110], '') <> ''";
                                    break;
                                }
                            case "02051":
                                {
                                    // 肺がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[100], '') <> '' OR ISNULL(WK.[103], '') <> ''";
                                    break;
                                }
                            case "02071":
                                {
                                    // 前立腺がん検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[112], '') <> ''";
                                    break;
                                }
                            case "02161":
                                {
                                    // 結核検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK  WHERE ISNULL(WK.[105], '') <> ''";
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_TKMK)
                    {
                        // 結果データ
                        switch (syoricd ?? "")
                        {
                            case "0201000001":
                                {
                                    // 特定健診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[021], '') <> '' OR ISNULL(WK.[022], '') <> '' OR ISNULL(WK.[023], '') <> ''";
                                    break;
                                }
                            case "0202000001":
                                {
                                    // 肝炎検診
                                    SQL = "SELECT * FROM " + wkTableName + " WK WHERE ISNULL(WK.[060], '') <> '' OR ISNULL(WK.[066], '') <> ''";
                                    break;
                                }

                            default:
                                {
                                    // その他
                                    SQL = "SELECT * FROM " + wkTableName;
                                    break;
                                }
                        }
                    }
                    else if ((CM_kyotu_proc.pubf_Towncd() ?? "") == CM_kyotu_proc.TOWNCD_FUKK & (Strings.Left(syoricd, 5) == "02910" | Strings.Left(syoricd, 5) == "02920"))
                    {
                        SQL = "SELECT * FROM " + wkTableName;
                    }

                    // 複数検診のファイル取込に対応
                    else if (syoricd.Substring(0, 2) == "02" & syoricd.Substring(4, 1) == "1")
                    {
                        // 各検診の必須項目のKOMOKUCDを取得
                        SQL = " SELECT                                          " + Constants.vbCr;
                        SQL += "     B.FLDNM                                    " + Constants.vbCr;
                        SQL += "    ,B.KOMOKUCD                                 " + Constants.vbCr;
                        SQL += "FROM    TC_KKTORIIKKATU A                       " + Constants.vbCr;
                        SQL += "INNER JOIN TC_KKTORIIKKATUITEM B                " + Constants.vbCr;
                        SQL += "    ON A.YOSIKICD = B.YOSIKICD                  " + Constants.vbCr;
                        SQL += "WHERE A.SYORICD = '" + syoricd + "'             " + Constants.vbCr;

                        switch (Strings.Left(syoricd, 5) ?? "")
                        {
                            case "02011":    // 特定健診（メタボ判定、指導レベル、総合判定）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSTOKUKEN'                  " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('METABO','SIDO','SOGOH')      " + Constants.vbCr;
                                    break;
                                }
                            case "02021":    // 肝炎検診（Ｂ型結果、Ｃ型結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSKANKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAB','KEKKAC')            " + Constants.vbCr;
                                    break;
                                }
                            case "02031":    // 胃がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSIKEN'                     " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02041":    // 大腸がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSDAIKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02051":    // 肺がん検診（X線一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSHAIKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAXI')                    " + Constants.vbCr;
                                    break;
                                }
                            case "02061":    // 腹部超音波検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSFUKUBUKEN'                " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02071":    // 前立腺がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSZENRITUKEN'               " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02081":    // 子宮がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSSIKYUKEN'                 " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02091":    // 乳がん検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSNYUKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02101":    // 骨粗鬆症検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSKOTUKEN'                  " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                            case "02111":    // 歯周疾患検診（判定区分）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSSISYUKEN'                 " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKA')                      " + Constants.vbCr;
                                    break;
                                }
                            case "02161":    // 結核検診（一次検診結果）
                                {
                                    SQL += "  AND B.TBLNM = 'TM_KSRENKEN'                   " + Constants.vbCr;
                                    SQL += "  AND B.FLDNM IN ('KEKKAI')                     " + Constants.vbCr;
                                    break;
                                }
                        }

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        dt = new DataTable();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        SQL = "SELECT * FROM " + wkTableName + " WK ";

                        for (int i = 0, loopTo4 = dt.Rows.Count - 1; i <= loopTo4; i++)
                        {
                            if (i == 0)
                            {
                                SQL += "WHERE ISNULL(WK.[" + dt.Rows[i]["KomokuCD"].ToString() + "], '') <> '' ";
                            }
                            else
                            {
                                SQL += "   OR ISNULL(WK.[" + dt.Rows[i]["KomokuCD"].ToString() + "], '') <> '' ";
                            }
                        }
                    }
                    else
                    {
                        SQL = "SELECT * FROM " + wkTableName;
                    }

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = COMMAND_TIMEOUT;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFILEDATA", rootElemRESULTXML);
                    }

                    // 個人情報取得
                    SQL = createSQL_SelectKojinInfo(conn, "", yosikicd, wkTableName, wkTrn);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = COMMAND_TIMEOUT;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKOJIN", rootElemRESULTXML);
                    }

                    executeDropTable(conn, wkTableName, wkTrn);

                    wkTrn.Commit();
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();

                        if (!string.IsNullOrEmpty(wkTableName))
                        {
                            executeDropTable(conn, wkTableName);
                        }
                    }

                    CM_kyotu_proc.pub_Status(99, 1, ex.Message + ex.StackTrace, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 一括入力画面で使用する種別コードを抽出する。
        /// </summary>
        /// <param name="pgid">プログラムＩＤ</param>
        /// <param name="jikkokbn">実行区分(1:取込処理,2:一括入力)</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_FormInitIkkatu(string pgid, string jikkokbn, string yosikicd)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string systemcd;

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更
                    {
                        ref var withBlock = ref newXML;

                        rootElemRESULTXML = withBlock.CreateElement("RESULTXML");

                        // 処理コード取得処理
                        var argconn = conn;
                        systemcd = CM_kyotu_proc.pubf_createSystemCd(pgid, ref argconn, ref newXML, ref rootElemRESULTXML);

                        // アップロードURL取得
                        var argconn1 = conn;
                        pubf_GetUpURL(ref argconn1, ref newXML, ref rootElemRESULTXML);

                        // 処理選択取得
                        SQL = createSQL_TC_KKTORIIKKATU(systemcd, "", "", jikkokbn);
                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MSYORI", rootElemRESULTXML);
                        }

                        // 項目フィルタ1
                        SQL = createSQL_TC_KKTORIIKKATUITEM("", jikkokbn);
                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MITEMF1", rootElemRESULTXML);
                        }

                        // 項目フィルタ2
                        SQL = CM_kyotu_proc.pubf_SQLCf("01", "307");

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MITEMF2", rootElemRESULTXML);
                        }

                        // 登録処理後画面制御実行フラグ取得
                        SQL = " SELECT                                                               " + Constants.vbCr;
                        SQL += "     CASE WHEN COUNT(*) > 0 THEN '1' ELSE '0' END AS DISPCTRLFLG     " + Constants.vbCr;
                        SQL += "FROM dbo.TC_KKCF CF                                                  " + Constants.vbCr;
                        SQL += "WHERE    CF.MAINCD = '98'                                            " + Constants.vbCr;
                        SQL += "     AND CF.SUBCD  = '033'                                           " + Constants.vbCr;
                        SQL += "     AND CF.CD     = '001'                                           " + Constants.vbCr;
                        SQL += "     AND CF.NAIYO  LIKE '%''" + pgid.ToString() + "''%'                " + Constants.vbCr;

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MDISPCTRLFLG", rootElemRESULTXML);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            return newXML;
        }

        /// <summary>
        /// 一括入力画面で使用するデータグリッドの情報を取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="filename">ファイル名</param>
        /// <param name="jikkokbn">実行区分(1:取込処理,2:一括入力)</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Sentaku(string systemcd, string userid, string yosikicd, string jikkokbn, string filename)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string strCsvData = "";
            string csvPath = System.Configuration.ConfigurationManager.ConnectionStrings["importKakuno"].ToString();
            var entity = new TC_KKTORI_YOSIKI_Entity();

            // ログ採取用
            Param = "func_Sentaku(" + systemcd + "," + userid + "," + yosikicd + "," + jikkokbn + "," + filename + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    entity = GetTcKkToriYosiki(conn, yosikicd);

                    // 取込ファイル様式取得
                    SQL = "SELECT                                             " + Constants.vbCr;
                    SQL += "    N'" + entity.KEISIKIKBN + "'  AS  KEISIKIKBN  " + Constants.vbCr;
                    SQL += "   ,N'" + entity.MOJICDKBN + "'   AS  MOJICDKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.KUGIRIKBN + "'   AS  KUGIRIKBN   " + Constants.vbCr;
                    SQL += "   ,N'" + entity.INYOFUKBN + "'   AS  INYOFUKBN   " + Constants.vbCr;
                    SQL += "   ," + entity.HEADERROW + "      AS  HEADERROW   " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MYOSIKI", rootElemRESULTXML);
                    }

                    if (!string.IsNullOrEmpty(filename))
                    {
                        if (!System.IO.File.Exists(csvPath + filename))
                        {
                            CM_kyotu_proc.pub_Status(1, 38, "", newXML, "STATUS", rootElemRESULTXML);
                            return newXML;
                        }

                        using (var sr = new System.IO.StreamReader(csvPath + filename, System.Text.Encoding.GetEncoding("shift_jis")))
                        {
                            strCsvData = sr.ReadToEnd();
                        }
                    }

                    // 'CSVデータ取得
                    SQL = "SELECT                                                       " + Constants.vbCr;
                    SQL += "    N'" + Strings.Replace(strCsvData, "'", "''") + "'  AS  CSVDATA  " + Constants.vbCr;
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MCSVDATA", rootElemRESULTXML);
                    }

                    // '一括入力画面コード内容(TC_KKCF用)
                    SQL = pubf_KsGetIlist1(yosikicd);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MCFLIST", rootElemRESULTXML);
                    }

                    // '一括入力画面施設内容(TC_KKKIKAN用)
                    SQL = pubf_KsGetIlist3(yosikicd);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKIKANLIST", rootElemRESULTXML);
                    }

                    // '一括入力画面スタッフ内容(TC_KKSTAFF用)
                    SQL = pubf_KsGetIlist4(yosikicd);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MSTAFFLIST", rootElemRESULTXML);
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message + ex.StackTrace, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 初期値を取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="gyono">行番号</param>
        /// <param name="taisyo">対象者リスト</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Syoki(string systemcd, string userid, string nendo, string syoricd, string edano, string gyono, string taisyo, string yosikicd)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            var htParam = new Hashtable();
            TC_KKTORIIKKATU_Entity entity = null;
            string towncd;
            string snendo = "";
            SqlTransaction wkTrn = null;
            string wkTableName = "";

            Param = "func_Syoki(" + systemcd + "," + userid + "," + nendo + "," + syoricd + "," + edano + "," + gyono + "," + taisyo + "," + yosikicd + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    // ' XMLデータを作成：PGごとで変更
                    {
                        ref var withBlock = ref newXML;
                        rootElemRESULTXML = withBlock.CreateElement("RESULTXML");

                        // 市町村コード取得
                        towncd = CM_kyotu_proc.pubf_Towncd();
                        if (!string.IsNullOrEmpty(nendo))
                        {
                            snendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
                        }
                        wkTableName = "WK_" + syoricd + "_" + edano;

                        // パラメータ設定
                        htParam.Add("snendo", snendo);
                        htParam.Add("userid", userid);
                        htParam.Add("towncd", towncd);
                        htParam.Add("taisyo", taisyo);
                        htParam.Add("yosikicd", yosikicd);
                        htParam.Add("wkTableName", wkTableName);

                        // 取込・一括入力処理マスタの情報を取得
                        entity = GetTcKKToriIkkatu(conn, syoricd, edano, wkTrn);

                        // ワークテーブル削除
                        executeDropTable(conn, wkTableName, wkTrn);

                        // ワークテーブル作成
                        executeCreateWkTable(conn, wkTableName, "", htParam, wkTrn);

                        // ワークテーブルにデータを挿入
                        executeInsertWkTable(conn, wkTableName, entity, htParam, wkTrn);

                        // '初期値取得
                        executeSelectSyokiInfo(conn, htParam, ref newXML, ref rootElemRESULTXML, wkTrn);

                        wkTrn.Commit();
                    }
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();
                    }

                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");

            return newXML;
        }

        /// <summary>
        /// 個人情報を取得する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="gyono">行番号</param>
        /// <param name="taisyo">対象者リスト</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Saikeisan(string systemcd, string userid, string nendo, string syoricd, string edano, string gyono, string taisyo, string yosikicd)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            var htParam = new Hashtable();
            TC_KKTORIIKKATU_Entity entity = null;
            string towncd;
            string snendo = "";
            SqlTransaction wkTrn = null;
            string wkTableName = "";

            Param = "func_Saikeisan(" + systemcd + "," + userid + "," + nendo + "," + syoricd + "," + edano + "," + gyono + "," + taisyo + "," + yosikicd + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    // ' XMLデータを作成：PGごとで変更
                    {
                        ref var withBlock = ref newXML;
                        rootElemRESULTXML = withBlock.CreateElement("RESULTXML");

                        // 市町村コード取得
                        towncd = CM_kyotu_proc.pubf_Towncd();
                        if (!string.IsNullOrEmpty(nendo))
                        {
                            snendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
                        }
                        wkTableName = "WK_" + syoricd + "_" + edano;

                        // パラメータ設定
                        htParam.Add("snendo", snendo);
                        htParam.Add("userid", userid);
                        htParam.Add("towncd", towncd);
                        htParam.Add("taisyo", taisyo);
                        htParam.Add("yosikicd", yosikicd);
                        htParam.Add("wkTableName", wkTableName);

                        // 取込・一括入力処理マスタの情報を取得
                        entity = GetTcKKToriIkkatu(conn, syoricd, edano, wkTrn);

                        // ワークテーブル削除
                        executeDropTable(conn, wkTableName, wkTrn);

                        // ワークテーブル作成
                        executeCreateWkTable(conn, wkTableName, "", htParam, wkTrn);

                        // ワークテーブルにデータを挿入
                        executeInsertWkTable(conn, wkTableName, entity, htParam, wkTrn);

                        // '再計算結果取得
                        executeSelectSaikeisanInfo(conn, htParam, ref newXML, ref rootElemRESULTXML, wkTrn);

                        wkTrn.Commit();
                    }
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();
                    }

                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");

            return newXML;
        }

        /// <summary>
        /// 一括入力画面のデータグリッドの情報をチェックする。
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="jikkokbn">実行区分(1:取込処理,2:一括入力)</param>
        /// <param name="syorikbn">処理区分(1:ｴﾗｰﾁｪｯｸ,2:登録,3ｴﾗｰﾘｽﾄ,4:csv)</param>
        /// <param name="taisyo">対象者リスト</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_importIkkatuCheck(string systemcd, string userid, string nendo, string syoricd, string edano, string yosikicd, string jikkokbn, string syorikbn, string taisyo)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string SQL = "";
            SqlCommand cmd;
            TC_KKTORIIKKATU_Entity entity = null;
            string towncd;
            string snendo = "";
            SqlTransaction wkTrn = null;
            var htParam = new Hashtable();
            string wkTableName = "";
            string errTableName = "";

            // ログ採取用
            Param = "func_importIkkatuCheck(" + systemcd + "," + userid + "," + nendo + "," + syoricd + "," + edano + "," + yosikicd + "," + jikkokbn + "," + "," + syorikbn + "," + taisyo + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    // 市町村コード取得
                    towncd = CM_kyotu_proc.pubf_Towncd();
                    if (!string.IsNullOrEmpty(nendo))
                    {
                        snendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
                    }
                    wkTableName = "WK_" + syoricd + "_" + edano;
                    errTableName = "WK_ERR_" + syoricd + "_" + edano;

                    // パラメータ設定
                    htParam.Add("snendo", snendo);
                    htParam.Add("userid", userid);
                    htParam.Add("towncd", towncd);
                    htParam.Add("taisyo", taisyo);
                    htParam.Add("yosikicd", yosikicd);
                    htParam.Add("wkTableName", wkTableName);
                    htParam.Add("errTableName", errTableName);

                    // 他の端末でエラーチェック/更新中は以降の処理を行わない。
                    if (IsExistTable(conn, errTableName, wkTrn))
                    {
                        CM_kyotu_proc.pub_Status(1, 65, "", newXML, "STATUS", rootElemRESULTXML);
                        CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 65), "", "");
                        return newXML;
                    }

                    // 取込・一括入力処理マスタの情報を取得
                    entity = GetTcKKToriIkkatu(conn, syoricd, edano, wkTrn);

                    // 'ワークテーブル・エラーテーブル作成
                    // エラーテーブル削除
                    executeDropTable(conn, errTableName, wkTrn);
                    // ワークテーブル削除
                    executeDropTable(conn, wkTableName, wkTrn);

                    // エラーテーブル作成
                    executeCreateErrTable(conn, errTableName, htParam, wkTrn);

                    // ワークテーブル作成
                    executeCreateWkTable(conn, wkTableName, "", htParam, wkTrn);

                    // ワークテーブルにデータを挿入
                    executeInsertWkTable(conn, wkTableName, entity, htParam, wkTrn);

                    // '入力チェック
                    // 必須チェック
                    CheckRequired(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 数値型チェック
                    CheckDataTypeNum(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 数値有効範囲チェック
                    CheckNumRange(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // コードチェック
                    CheckDataTypeCode(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 日付チェック
                    CheckDataTypeDate(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 機関コードチェック
                    CheckDataTypeKikan(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 入力桁数チェック
                    CheckLength(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // スタッフコードチェック
                    if (Strings.Left(entity.SYORICD, 2) == "03")
                    {
                        CheckDataTypeStaffYS(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }
                    else
                    {
                        CheckDataTypeStaff(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }

                    // '入力チェックストアド実行
                    if (string.IsNullOrEmpty(entity.CHKSTORED) == false)
                    {
                        executeStoredProcedure(conn, htParam, entity.CHKSTORED, wkTrn);
                    }

                    // 重複チェック
                    CheckDuplication(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    // 存在チェック
                    // 宛名存在チェック(存在しない場合エラー)
                    CheckNotExistKojinno(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                    if (entity.INSUPDKBN == "1")
                    {
                        // 登録マスタデータ存在チェック(存在する場合エラー)
                        CheckExistRecord(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }
                    else if (entity.INSUPDKBN == "2")
                    {
                        // 登録マスタデータ存在チェック(存在しない場合エラー)
                        CheckNotExistRecord(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }

                    if (systemcd.Substring(0, 2) == "03")
                    {
                        // 予防接種入力チェック

                        // 生年月日と接種年月日の大小チェック
                        CheckBymdAndTargetymd(conn, wkTableName, errTableName, entity, htParam, "SESSYUYMD", wkTrn);

                        // 予防接種共通入力チェック
                        var ys_kyotu_check = new YSCO_kyotu_check();
                        ys_kyotu_check.func_CheckIkkatuImport(syoricd, userid, wkTableName, errTableName, htParam, conn, wkTrn);

                        // Hib＆小児用肺炎球菌接種回数チェック
                        if (((towncd ?? "") == CM_kyotu_proc.TOWNCD_TOSK | (towncd ?? "") == CM_kyotu_proc.TOWNCD_OMTK) & (syoricd.Substring(0, 4) == "0320" | syoricd.Substring(0, 4) == "0321"))
                        {
                            CheckSessyuKaisu(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                        }
                    }
                    else if (syoricd.Substring(0, 5) == "04010")
                    {
                        // 交付番号と新規交付区分のチェックを行う
                        CheckBkofunoAndKofukbn(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }
                    else if (syoricd.Substring(0, 5) == "04011")
                    {
                        // 妊婦健診チェック＆産婦健診チェック
                        CheckNotExistBkofuno(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                        // 妊婦健診入力チェック
                        // 受診日が既に入力されているかでチェックを行う。
                        CheckFinishInputNinken(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }
                    else if (syoricd.Substring(0, 5) == "04012")
                    {
                        // 妊婦健診チェック＆産婦健診チェック
                        CheckNotExistBkofuno(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }
                    else if (syoricd.Substring(0, 4) == "0402")
                    {
                        // 乳幼児互助防疫入力チェック

                        // 生年月日と健診年月日の大小チェック
                        CheckBymdAndTargetymd(conn, wkTableName, errTableName, entity, htParam, "KENYMD", wkTrn);

                        // 生後月数チェック
                        CheckSeigoTukisu(conn, wkTableName, errTableName, entity, htParam, wkTrn);

                        // 月齢範囲チェック
                        CheckGetukbnRange(conn, wkTableName, errTableName, entity, htParam, wkTrn);
                    }

                    // エラーチェック結果を取得(件数)
                    SQL = " SELECT                                                                  " + Constants.vbCr;
                    SQL += "         SUM(CASE WHEN ERRORKBN = '3' THEN 1 ELSE 0 END) AS ERRORCNT   " + Constants.vbCr;
                    SQL += "        ,SUM(CASE WHEN ERRORKBN = '2' THEN 1 ELSE 0 END) AS WARNINGCNT " + Constants.vbCr;
                    SQL += "        ,SUM(CASE WHEN ERRORKBN = '1' THEN 1 ELSE 0 END) AS INFOCNT    " + Constants.vbCr;
                    SQL += " FROM " + errTableName + " ER           " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MERRCNT", rootElemRESULTXML);
                    }

                    // エラーチェック結果を取得(行数)
                    SQL = " SELECT                                                                      " + Constants.vbCr;
                    SQL += "         (SELECT COUNT(*) FROM " + wkTableName + ")          AS TOTAL       " + Constants.vbCr;
                    SQL += "        ,(SELECT COUNT(*) FROM (SELECT  GYONO FROM " + errTableName + "     " + Constants.vbCr;
                    SQL += "          WHERE ERRORKBN IN ('2', '3') GROUP BY GYONO) CNT ) AS ERRWARNGYO  " + Constants.vbCr;
                    SQL += "        ,SUM(CASE WHEN MERRORKBN = '3' THEN 1 ELSE 0 END)    AS ERRORGYO    " + Constants.vbCr;
                    SQL += "        ,SUM(CASE WHEN MERRORKBN = '2' THEN 1 ELSE 0 END)    AS WARNINGGYO  " + Constants.vbCr;
                    SQL += "        ,SUM(CASE WHEN MERRORKBN = '1' THEN 1 ELSE 0 END)    AS INFOGYO     " + Constants.vbCr;
                    SQL += " FROM (                                                                     " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                                                       " + Constants.vbCr;
                    SQL += "               ,MAX(ERRORKBN)  AS MERRORKBN                                 " + Constants.vbCr;
                    SQL += "        FROM " + errTableName + "                                           " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                                                      " + Constants.vbCr;
                    SQL += "      ) ER                                                                  " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MERRGYO", rootElemRESULTXML);
                    }

                    // エラーチェック結果を取得
                    SQL = " SELECT                                                       " + Constants.vbCr;
                    SQL += "        ER.GYONO         AS GYONO                            " + Constants.vbCr;
                    SQL += "       ,ER.KOMOKUCD      AS KOMOKUCD                         " + Constants.vbCr;
                    SQL += "       ,ER.ERRORKBN      AS ERRORKBN                         " + Constants.vbCr;
                    SQL += "       ,ER.ERRORCD       AS ERRORCD                          " + Constants.vbCr;
                    SQL += "       ,ER.ERROR         AS ERROR                            " + Constants.vbCr;
                    SQL += " FROM " + errTableName + " ER                                " + Constants.vbCr;
                    SQL += " ORDER BY CONVERT(INT, ER.GYONO), ER.ERRORKBN DESC, ER.ERROR " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MERROR", rootElemRESULTXML);
                    }

                    // パラメータを返却
                    SQL = " SELECT                                   " + Constants.vbCr;
                    SQL += "        '" + syorikbn + "'  AS SYORIKBN  " + Constants.vbCr; // 処理区分

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPARAM", rootElemRESULTXML);
                    }

                    if (syorikbn == "1")
                    {
                        // エラーチェック時はエラーテーブル削除
                        executeDropTable(conn, errTableName, wkTrn);
                    }

                    wkTrn.Commit();
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();
                    }
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + SQL + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");

            return newXML;
        }

        /// <summary>
        /// 一括入力画面グリッドをCSV出力する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="item">項目名リスト</param>
        /// <param name="taisyo">対象者リスト</param>
        /// <param name="sfileName">保存ファイル名</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_preToroku(string systemcd, string userid, string nendo, string syoricd, string edano, string item, string taisyo, string sfileName, string yosikicd)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string strCsvData = "";
            var dt = new DataTable();
            DataRow datadr;
            string crtPass;
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");
            string urlPass;
            string csvPath = System.Configuration.ConfigurationManager.ConnectionStrings["csvKakuno"].ToString();
            var entity = new TC_KKTORI_YOSIKI_Entity();
            // ログ採取用
            Param = "func_preToroku(" + systemcd + "," + userid + "," + nendo + "," + syoricd + "," + edano + "," + taisyo + "," + sfileName + "," + yosikicd + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    // ' CSV作成用のデータテーブルを作成する
                    dt = new DataTable();
                    var itemListColumn = Strings.Split(item, CM_kyotu_proc.MAIN_DELIMITER);
                    entity = GetTcKkToriYosiki(conn, yosikicd);
                    string encode = getYosikiEncode(entity.MOJICDKBN);

                    foreach (string colNm in itemListColumn)
                        dt.Columns.Add(colNm);

                    urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["csvUrl"].ToString() + userid + "_" + sfileName + "_" + strNow + ".csv";
                    crtPass = csvPath + userid + "_" + sfileName + "_" + strNow + ".csv";

                    foreach (string listRow in Strings.Split(taisyo, CM_kyotu_proc.MAIN_DELIMITER))
                    {
                        // パラメータの分割(カラム単位)
                        var colData = Strings.Split(listRow, CM_kyotu_proc.SUB1_DELIMITER);

                        datadr = dt.NewRow();

                        string colNm = "";
                        for (int colIndx = 0, loopTo = colData.Length - 2; colIndx <= loopTo; colIndx++)
                            datadr[itemListColumn[colIndx]] = colData[colIndx];

                        dt.Rows.Add(datadr);
                    }

                    if (createCSVForDataTable(dt, crtPass, encode) == false)
                    {
                        CM_kyotu_proc.pub_Status(0, 3, "", newXML, "STATUS", rootElemRESULTXML);
                        CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 3), "", "");
                        return newXML;
                    }

                    CM_kyotu_proc.pub_URLPath(newXML, rootElemRESULTXML, urlPass);
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message + ex.StackTrace, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            return newXML;
        }

        /// <summary>
        /// 一括入力画面グリッドを登録する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="jikkokbn">実行区分(1:取込処理,2:一括入力)</param>
        /// <param name="keizokukbn">処理継続区分(0:ﾜｰｸﾃｰﾌﾞﾙ削除のみ実行、1:登録実行)</param>
        /// <param name="taisyo">対象者リスト</param>
        /// <param name="fileNm">取込ファイル名、修正再開ファイル名</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Toroku(string systemcd, string userid, string nendo, string syoricd, string edano, string yosikicd, string jikkokbn, string keizokukbn, string taisyo, string fileNm)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string Param;
            string SQL = "";
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            TC_KKTORIIKKATU_Entity entity = null;
            string towncd;
            string snendo = "";
            SqlTransaction wkTrn = null;
            var htParam = new Hashtable();
            string wkTableName = "";
            string errTableName = "";
            string total = "";
            string errorGyo = "";
            // ログ採取用
            Param = "func_Toroku(" + systemcd + "," + userid + "," + nendo + "," + syoricd + "," + edano + "," + yosikicd + "," + jikkokbn + "," + keizokukbn + "," + taisyo + "," + fileNm + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    // ' XMLデータを作成：PGごとで変更

                    rootElemRESULTXML = newXML.CreateElement("RESULTXML");

                    // 市町村コード取得
                    towncd = CM_kyotu_proc.pubf_Towncd();
                    if (!string.IsNullOrEmpty(nendo))
                    {
                        snendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
                    }
                    wkTableName = "WK_" + syoricd + "_" + edano;
                    errTableName = "WK_ERR_" + syoricd + "_" + edano;

                    // パラメータ設定
                    htParam.Add("snendo", snendo);
                    htParam.Add("userid", userid);
                    htParam.Add("towncd", towncd);
                    htParam.Add("taisyo", taisyo);
                    htParam.Add("yosikicd", yosikicd);
                    htParam.Add("wkTableName", wkTableName);
                    htParam.Add("errTableName", errTableName);

                    // 処理継続区分が1の場合は
                    // エラーテーブル、ワークテーブルの削除のみ行う。
                    if (keizokukbn == "1")
                    {
                        // 取込・一括入力処理マスタの情報を取得
                        entity = GetTcKKToriIkkatu(conn, syoricd, edano, wkTrn);

                        // '更新前ストアド実行
                        if (string.IsNullOrEmpty(entity.BEFSTORED) == false)
                        {
                            executeStoredProcedure(conn, htParam, entity.BEFSTORED, wkTrn);
                        }

                        // コード変換処理（取込処理の場合のみ）
                        if (entity.JIKKOKBN == "1")
                        {
                            executeConvertCode(conn, wkTableName, entity, htParam, wkTrn);
                        }

                        // データの更新
                        executeToroku(conn, wkTableName, entity, htParam, wkTrn);

                        // '更新後ストアド実行
                        if (string.IsNullOrEmpty(entity.AFTSTORED) == false)
                        {
                            executeStoredProcedure(conn, htParam, entity.AFTSTORED, wkTrn);
                        }

                        // エラーチェック結果を取得(行数)
                        SQL = " SELECT                                                                              " + Constants.vbCr;
                        SQL += "         (SELECT COUNT(*) FROM " + wkTableName + ")       AS TOTAL                  " + Constants.vbCr;
                        SQL += "        ,ISNULL(SUM(CASE WHEN MERRORKBN = '3' THEN 1 ELSE 0 END), 0) AS ERRORGYO    " + Constants.vbCr;
                        SQL += "        ,ISNULL(SUM(CASE WHEN MERRORKBN = '2' THEN 1 ELSE 0 END), 0) AS WARNINGGYO  " + Constants.vbCr;
                        SQL += "        ,ISNULL(SUM(CASE WHEN MERRORKBN = '1' THEN 1 ELSE 0 END), 0) AS INFOGYO     " + Constants.vbCr;
                        SQL += " FROM (                                                                             " + Constants.vbCr;
                        SQL += "        SELECT  GYONO                                                               " + Constants.vbCr;
                        SQL += "               ,MAX(ERRORKBN)  AS MERRORKBN                                         " + Constants.vbCr;
                        SQL += "        FROM " + errTableName + "                                                   " + Constants.vbCr;
                        SQL += "        GROUP BY GYONO                                                              " + Constants.vbCr;
                        SQL += "      ) ER                                                                          " + Constants.vbCr;

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        dt = new DataTable();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        total = dt.Rows[0]["TOTAL"].ToString();
                        errorGyo = dt.Rows[0]["ERRORGYO"].ToString();

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MERRGYO", rootElemRESULTXML);
                        }
                    }

                    // パラメータを返却
                    SQL = " SELECT                                    " + Constants.vbCr;
                    SQL += "        '" + keizokukbn + "'  AS KEIZOKU  " + Constants.vbCr; // 処理継続

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPARAM", rootElemRESULTXML);
                    }

                    // エラーテーブル削除
                    executeDropTable(conn, errTableName, wkTrn);

                    // ワークテーブルデータ削除
                    executeDropTable(conn, wkTableName, wkTrn);

                    if (jikkokbn == "1" & keizokukbn == "1")
                    {
                        // ' 取込処理ログ出力
                        pub_IkkatuImportLog(entity.SYORICD, edano, userid, entity.SYORINM, fileNm, total, total, errorGyo, (Conversions.ToLong(total) - Conversions.ToLong(errorGyo)).ToString(), snendo, conn, wkTrn);
                    }

                    wkTrn.Commit();
                }
                catch (Exception ex)
                {
                    if (wkTrn is not null)
                    {
                        wkTrn.Rollback();

                        // エラーテーブル削除
                        executeDropTable(conn, errTableName);
                        // ワークテーブルデータ削除
                        executeDropTable(conn, wkTableName);
                    }
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + SQL + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");

            return newXML;
        }

        /// <summary>
        /// テーブル存在チェック処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">ワークテーブル名称</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private bool IsExistTable(SqlConnection conn, string tableName, SqlTransaction wkTrn = null)
        {
            bool IsExistTableRet = default;
            SqlCommand cmd;
            string SQL;
            string existKbn;

            SQL = "SELECT CASE WHEN OBJECT_ID('" + tableName + "') IS NOT NULL THEN '1' ELSE '0' END" + Constants.vbCr;
            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            existKbn = Conversions.ToString(cmd.ExecuteScalar());

            if (existKbn == "1")
            {
                IsExistTableRet = true;
            }
            else
            {
                IsExistTableRet = false;
            }

            return IsExistTableRet;
        }

        /// <summary>
        /// 処理年月日＆ユーザＩＤ包含チェック処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">ワークテーブル名称</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private bool IsConteinSyoriymdAndUserid(SqlConnection conn, string tableName, SqlTransaction wkTrn = null)
        {
            bool IsConteinSyoriymdAndUseridRet = default;
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;

            SQL = "SELECT 1                                             " + Constants.vbCr;
            SQL += "FROM dbo.sysobjects A                               " + Constants.vbCr;
            SQL += "    INNER JOIN dbo.syscolumns B                     " + Constants.vbCr;
            SQL += "            ON A.id=B.id                            " + Constants.vbCr;
            SQL += "WHERE A.xtype = 'U'                                 " + Constants.vbCr;
            SQL += "  AND (B.name = 'USERID' OR B.name = 'SYORIYMD')    " + Constants.vbCr;
            SQL += "  AND A.name = '" + tableName + "'                  " + Constants.vbCr;
            SQL += "GROUP BY A.name                                     " + Constants.vbCr;
            SQL += "ORDER BY A.name                                     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                IsConteinSyoriymdAndUseridRet = true;
            }
            else
            {
                IsConteinSyoriymdAndUseridRet = false;
            }

            return IsConteinSyoriymdAndUseridRet;
        }

        /// <summary>
        /// テーブル削除処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeDropTable(SqlConnection conn, string wkTableName, SqlTransaction wkTrn = null)
        {
            SqlCommand cmd;
            string SQL;

            if (IsExistTable(conn, wkTableName, wkTrn))
            {
                SQL = "EXECUTE ('DROP TABLE dbo." + wkTableName + "')  " + Constants.vbCr;

                cmd = conn.CreateCommand();
                if (wkTrn is not null)
                {
                    cmd.Transaction = wkTrn;
                }
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ワークテーブル作成処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="kbn">ファイル取込フラグ(1:ファイル取込時)</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeCreateWkTable(SqlConnection conn, string wkTableName, string kbn, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;

            SQL = "SELECT                                            " + Constants.vbCr;
            SQL += "    KOMOKUCD  AS  KOMOKUCD                       " + Constants.vbCr;
            SQL += "FROM  dbo.TC_KKTORIIKKATUITEM                    " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("WHERE YOSIKICD = '", htParam["yosikicd"]), "'   "), Constants.vbCr));
            if (kbn == "1")
            {
                SQL += "  AND INPORDERID IS NOT NULL                 " + Constants.vbCr;
            }

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            SQL = "EXECUTE ('CREATE TABLE dbo." + wkTableName + "(                                " + Constants.vbCr;
            SQL += "  [GYONO] [real] NOT NULL,                                                " + Constants.vbCr;
            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
                SQL += "[" + dt.Rows[rowIndx]["KOMOKUCD"].ToString() + "] [nvarchar](4000) NULL,    " + Constants.vbCr;
            SQL += ")')                                                                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// エラーテーブル作成処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeCreateErrTable(SqlConnection conn, string wkTableName, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;

            SQL = "EXECUTE ('CREATE TABLE dbo." + wkTableName + "(                                " + Constants.vbCr;
            SQL += "  [GYONO] [real] NOT NULL,                                                    " + Constants.vbCr;
            SQL += "  [KOMOKUCD] [nvarchar](2000) NULL,                                           " + Constants.vbCr;
            SQL += "  [ERRORKBN] [nvarchar](2000) NULL,                                           " + Constants.vbCr;
            SQL += "  [ERRORCD] [nvarchar](2000) NULL,                                            " + Constants.vbCr;
            SQL += "  [ERROR] [nvarchar](2000) NULL,                                              " + Constants.vbCr;
            SQL += ")')                                                                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// ワークテーブルデータ挿入処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeInsertWkTable(SqlConnection conn, string wkTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string dispTypeKbn;
            var SQLParam = new string[6];

            string SQL_Insert = "";

            SQL = "SELECT                                             " + Constants.vbCr;
            SQL += "       IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.DISPVISFLG = '1'                         " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            SQL_Insert += " [GYONO]  " + Constants.vbCr;
            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)

                SQL_Insert += " ,[" + dt.Rows[rowIndx]["KOMOKUCD"].ToString() + "]  " + Constants.vbCr;

            var dataList = new ArrayList();
            foreach (string inputRowData in Strings.Split(Conversions.ToString(htParam["taisyo"]), CM_kyotu_proc.MAIN_DELIMITER))
            {
                var inputColData = Strings.Split(inputRowData, CM_kyotu_proc.SUB1_DELIMITER);

                SQL = "INSERT   INTO dbo." + wkTableName + "(                               " + Constants.vbCr;
                SQL += SQL_Insert;
                SQL += ")VALUES(                                                            " + Constants.vbCr;
                SQL += "  " + inputColData[0] + "                                           " + Constants.vbCr;
                for (int colCnt = 0, loopTo1 = inputColData.Length - 3; colCnt <= loopTo1; colCnt++)
                {
                    dispTypeKbn = dt.Rows[colCnt]["DISPTYPEKBN"].ToString();
                    if ((dispTypeKbn ?? "") == DISPTYPEKBN_NUM)
                    {
                        SQL += " ," + CM_kyotu_proc.pubf_CnvNull(Strings.Trim(inputColData[colCnt + 1]), 1) + "                    " + Constants.vbCr;
                    }
                    else if ((dispTypeKbn ?? "") == DISPTYPEKBN_DATE)
                    {
                        if (string.IsNullOrEmpty(CM_kyotu_proc.pubf_CnvSeirekiYMD(inputColData[colCnt + 1])))
                        {
                            SQL += " ," + CM_kyotu_proc.pubf_CnvNull(inputColData[colCnt + 1], 1) + "                      " + Constants.vbCr;
                        }
                        else
                        {
                            SQL += " ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(inputColData[colCnt + 1]), 1) + "  " + Constants.vbCr;
                        }
                    }
                    else
                    {
                        SQL += " ," + CM_kyotu_proc.pubf_CnvNull(Strings.Trim(inputColData[colCnt + 1]), 1) + "                " + Constants.vbCr;
                    }
                }
                SQL += "    )                                                                        " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeToroku(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            ArrayList tableList;

            tableList = getTargetTable(conn, wktableName, entity, htParam, wkTrn);

            foreach (string tableName in tableList)
            {
                if (tableName == "TM_KSFREE")
                {
                    // 各種検診フリー項目登録処理
                    executeTorokuTM_KSFREE(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_KSTOKUSIKKAN")
                {
                    // 疾患別区分登録処理
                    executeTorokuTM_KSTOKUSIKKAN(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_KKKAZOKUREKI")
                {
                    // 家族歴登録処理
                    executeTorokuTM_KKKAZOKUREKI(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_KKKIOREKI")
                {
                    // 既往歴登録処理
                    executeTorokuTM_KKKIOREKI(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_ITITAKU")
                {
                    // 委託料管理マスタ登録処理
                    executeTorokuTM_ITITAKU(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNSITEM")
                {
                    // 妊産婦動的項目管理マスタ
                    executeTorokuTM_BHNSITEM(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNSMONSIN")
                {
                    // 妊産婦問診管理マスタ
                    executeTorokuTM_BHNSMONSIN(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNSFREE")
                {
                    // 妊産婦フリー項目
                    executeTorokuTM_BHNSFREE(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNYITEM")
                {
                    // 乳幼児動的項目管理マスタ
                    executeTorokuTM_BHNYITEM(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNYSYOKEN")
                {
                    // 乳幼児診察所見管理マスタ
                    executeTorokuTM_BHNYSYOKEN(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_BHNYMONSIN")
                {
                    // 乳幼児問診管理マスタ
                    executeTorokuTM_BHNYMONSIN(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }
                else if (tableName == "TM_YSFREE")
                {
                    // 予防接種フリー項目登録処理
                    executeTorokuTM_YSFREE(conn, wktableName, entity, htParam, wkTrn);
                    continue;
                }

                // 上記のマスタ以外の項目を取込
                switch (entity.INSUPDKBN ?? "")
                {
                    case "1":
                        {
                            // 追加
                            executeInsert(conn, tableName, wktableName, entity, htParam, wkTrn);
                            break;
                        }

                    case "2":
                        {
                            // 上書き
                            executeUpdate(conn, tableName, wktableName, entity, htParam, wkTrn);
                            break;
                        }

                    case "3":
                        {
                            // 追加更新
                            executDelete(conn, tableName, wktableName, entity, htParam, wkTrn);
                            executeInsert(conn, tableName, wktableName, entity, htParam, wkTrn);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 取込処理・登録処理の対象テーブルを取得する
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private ArrayList getTargetTable(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            var tableList = new ArrayList();

            SQL = "SELECT  IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM IS NOT NULL                        " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;
            SQL += "GROUP BY IT.TBLNM                                 " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int tableCnt = 0, loopTo = dt.Rows.Count - 1; tableCnt <= loopTo; tableCnt++)

                tableList.Add(dt.Rows[tableCnt]["TBLNM"].ToString());

            return tableList;
        }

        /// <summary>
        /// データ追加処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">データ追加テーブル名称</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeInsert(SqlConnection conn, string tableName, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string dispTypeKbn;
            string setData;
            string ItemKojinno = "";
            DataRow[] dro;

            string SQL_Insert = "";
            string SQL_Select = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            // 項目「個人番号」取得
            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            // 接種区分を取得（取込処理（予防接種）以外の場合は空）
            string sessyukbn = getSessyukbn(entity.SYORICD, dt);
            bool syoriymdFlg = IsConteinSyoriymdAndUserid(conn, tableName, wkTrn);

            // Insert項目作成
            if (syoriymdFlg)
            {
                SQL_Insert = ",USERID                           " + Constants.vbCr;
                SQL_Insert += ",SYORIYMD                        " + Constants.vbCr;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
            {
                SQL_Insert += " ,NENDO                          " + Constants.vbCr;
            }
            if (!string.IsNullOrEmpty(sessyukbn))
            {
                SQL_Insert += " ,SESSYUKBN                      " + Constants.vbCr;
            }

            // Select項目作成
            if (syoriymdFlg)
            {
                SQL_Select = Conversions.ToString(SQL_Select + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(",'", htParam["userid"]), "'     "), Constants.vbCr));
                SQL_Select += ",GETDATE()                       " + Constants.vbCr;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
            {
                SQL_Select = Conversions.ToString(SQL_Select + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" ,", htParam["snendo"]), "      "), Constants.vbCr));
            }

            if (!string.IsNullOrEmpty(sessyukbn))
            {
                SQL_Select += " ,'" + sessyukbn + "'            " + Constants.vbCr;
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                SQL_Insert += ",[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "] " + Constants.vbCr;

                dispTypeKbn = dt.Rows[rowIndx]["DISPTYPEKBN"].ToString();
                setData = dt.Rows[rowIndx]["SETDATA"].ToString();
                SQL_Select += "," + getSQLItemConvert(dispTypeKbn, setData);
            }

            // Insert文作成
            SQL = "INSERT INTO " + tableName + "(               " + Constants.vbCr;
            // 先頭のカンマを除去
            SQL += Strings.Mid(SQL_Insert, 2);
            SQL += ")                                           " + Constants.vbCr;
            SQL += "SELECT                                      " + Constants.vbCr;
            // 先頭のカンマを除去
            SQL += Strings.Mid(SQL_Select, 2);

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 個人番号あり
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + wktableName + " WK                     " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN KO                       " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO    " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                   " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO             " + Constants.vbCr;
            }
            else
            {
                // 個人番号なし
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + wktableName + " WK                     " + Constants.vbCr;
            }

            SQL += "WHERE  WK.GYONO NOT IN (                    " + Constants.vbCr;
            SQL += "        SELECT  GYONO                       " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), ""), Constants.vbCr));
            SQL += "        WHERE ERRORKBN = '3'                " + Constants.vbCr;
            SQL += "        GROUP BY GYONO                      " + Constants.vbCr;
            SQL += "      )                                     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// データ更新処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">データ追加テーブル名称</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeUpdate(SqlConnection conn, string tableName, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string ItemKojinno = "";
            DataRow[] dro;

            string SQL_Set = "";
            string SQL_Join = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            // 項目「個人番号」取得
            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            bool syoriymdFlg = IsConteinSyoriymdAndUserid(conn, tableName, wkTrn);

            if (syoriymdFlg)
            {
                SQL_Set = Conversions.ToString(SQL_Set + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(" K.USERID   = '", htParam["userid"]), "'  "), Constants.vbCr));
                SQL_Set += ",K.SYORIYMD = GETDATE()                    " + Constants.vbCr;
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                if (dt.Rows[rowIndx]["FLDKEYFLG"].ToString() == "1")
                {
                    if (string.IsNullOrEmpty(SQL_Join))
                    {
                        SQL_Join += "  ON ";
                    }
                    else
                    {
                        SQL_Join += " AND ";
                    }

                    SQL_Join += "  K.[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "] = ";
                    SQL_Join += "  " + dt.Rows[rowIndx]["SETDATA"].ToString() + " " + Constants.vbCr;
                }
                else
                {
                    if (string.IsNullOrEmpty(SQL_Set))
                    {
                        SQL_Set = "";
                    }
                    else
                    {
                        SQL_Set += ",";
                    }

                    SQL_Set += "    K.[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "]  = ";
                    SQL_Set += "  " + dt.Rows[rowIndx]["SETDATA"].ToString() + " " + Constants.vbCr;
                }
            }

            SQL = "UPDATE                                " + Constants.vbCr;
            SQL += "    K                                " + Constants.vbCr;
            SQL += "SET                                  " + Constants.vbCr;
            SQL += SQL_Set;

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 個人番号あり
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + tableName + " K                        " + Constants.vbCr;
                SQL += "INNER JOIN " + wktableName + " WK             " + Constants.vbCr;
                SQL += SQL_Join;
                SQL += "LEFT  JOIN TM_KKKOJIN KO                      " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO    " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                   " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO             " + Constants.vbCr;
            }
            else
            {
                // 個人番号なし
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + tableName + " K                        " + Constants.vbCr;
                SQL += "   INNER JOIN " + wktableName + " WK          " + Constants.vbCr;
                SQL += SQL_Join;
            }

            SQL += "WHERE 1 = 1                          " + Constants.vbCr;

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
            {
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(" AND K.NENDO = ", htParam["snendo"]), Constants.vbCr));
            }

            // 接種区分を取得（取込処理（予防接種）以外の場合は空）
            string sessyukbn = getSessyukbn(entity.SYORICD, dt);
            if (!string.IsNullOrEmpty(sessyukbn))
            {
                SQL += " AND K.SESSYUKBN = '" + sessyukbn + "'" + Constants.vbCr;
            }
            SQL += "  AND WK.GYONO NOT IN (                    " + Constants.vbCr;
            SQL += "        SELECT  GYONO                       " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), ""), Constants.vbCr));
            SQL += "        WHERE ERRORKBN = '3'                " + Constants.vbCr;
            SQL += "        GROUP BY GYONO                      " + Constants.vbCr;
            SQL += "      )                                     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 各種検診フリー項目登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_KSFREE(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL = "";

            string fldNm;
            string[] splFldNm;
            string kojinno = "";
            string edano = "";
            string syubetu = "";
            string itemcd = "";
            string nendo = "";
            string datatype = "";
            string itemValue = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_KSFREE'                   " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            dro = dt.Select("FLDNM = 'NENDO'");
            if (dro.Length > 0)
            {
                nendo = dro[0]["SETDATA"].ToString();
            }
            else
            {
                nendo = Conversions.ToString(htParam["snendo"]);
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                syubetu = splFldNm[0];
                itemcd = splFldNm[1];
                datatype = splFldNm[2];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_KSFREE K                                   " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO = " + kojinno + "          " + Constants.vbCr;
                SQL += "          AND K.EDANO   = " + edano + "            " + Constants.vbCr;
                SQL += "WHERE                                              " + Constants.vbCr;
                SQL += "       K.NENDO   = " + nendo + "                   " + Constants.vbCr;
                SQL += "   AND K.SYUBETU = '" + syubetu + "'               " + Constants.vbCr;
                SQL += "   AND K.ITEMCD  = '" + itemcd + "'                " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_KSFREE (                                    " + Constants.vbCr;
                SQL += "    NENDO                                                 " + Constants.vbCr;
                SQL += "   ,KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,SYUBETU                                               " + Constants.vbCr;
                SQL += "   ,ITEMCD                                                " + Constants.vbCr;

                switch (datatype ?? "")
                {
                    case "DATATYPE1":
                        {
                            // 数値
                            SQL += "   ,DATATYPE1                                     " + Constants.vbCr;
                            SQL += "   ,DATATYPE2                                     " + Constants.vbCr;
                            break;
                        }

                    default:
                        {
                            // 数値以外
                            SQL += "   ," + datatype + "                              " + Constants.vbCr;
                            break;
                        }
                }

                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + nendo + "                                         " + Constants.vbCr;
                SQL += "   ," + kojinno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + syubetu + "'                                     " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                                      " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                         " + Constants.vbCr;
                            break;
                        }
                    case "4": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                // SQL += "  AND " & itemValue & " IS NOT NULL                       " & vbCr
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 予防接種フリー項目登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_YSFREE(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL = "";

            string fldNm;
            string[] splFldNm;
            string kojinno = "";
            string edano = "";
            string syubetu = "";
            string itemcd = "";
            string nendo = "";
            string datatype = "";
            string itemValue = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_YSFREE'                   " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            dro = dt.Select("FLDNM = 'NENDO'");
            if (dro.Length > 0)
            {
                nendo = dro[0]["SETDATA"].ToString();
            }
            else
            {
                nendo = Conversions.ToString(htParam["snendo"]);
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                syubetu = splFldNm[0];
                itemcd = splFldNm[1];
                datatype = splFldNm[2];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_YSFREE K                                   " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO = " + kojinno + "          " + Constants.vbCr;
                SQL += "          AND K.EDANO   = " + edano + "            " + Constants.vbCr;
                SQL += "WHERE                                              " + Constants.vbCr;
                SQL += "       K.NENDO   = " + nendo + "                   " + Constants.vbCr;
                SQL += "   AND K.SYUBETU = '" + syubetu + "'               " + Constants.vbCr;
                SQL += "   AND K.ITEMCD  = '" + itemcd + "'                " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_YSFREE (                                    " + Constants.vbCr;
                SQL += "    NENDO                                                 " + Constants.vbCr;
                SQL += "   ,KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,SYUBETU                                               " + Constants.vbCr;
                SQL += "   ,ITEMCD                                                " + Constants.vbCr;

                switch (datatype ?? "")
                {
                    case "DATATYPE1":
                        {
                            // 数値
                            SQL += "   ,DATATYPE1                                     " + Constants.vbCr;
                            SQL += "   ,DATATYPE2                                     " + Constants.vbCr;
                            break;
                        }

                    default:
                        {
                            // 数値以外
                            SQL += "   ," + datatype + "                              " + Constants.vbCr;
                            break;
                        }
                }

                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + nendo + "                                         " + Constants.vbCr;
                SQL += "   ," + kojinno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + syubetu + "'                                     " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                                      " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                         " + Constants.vbCr;
                            break;
                        }
                    case "4": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                // SQL += "  AND " & itemValue & " IS NOT NULL                       " & vbCr
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 疾患別区分登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_KSTOKUSIKKAN(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL = "";

            string fldNm;
            string[] splFldNm;
            string kojinno = "";
            string edano = "";
            string cd = "";
            string sakiFldNm = "";
            string nendo = "";
            string itemValue = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_KSTOKUSIKKAN'             " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            dro = dt.Select("FLDNM = 'NENDO'");
            if (dro.Length > 0)
            {
                nendo = dro[0]["SETDATA"].ToString();
            }
            else
            {
                nendo = Conversions.ToString(htParam["snendo"]);
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("HANTEI") & !fldNm.Contains("SONOTA"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                cd = splFldNm[0];
                sakiFldNm = splFldNm[1];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_KSTOKUSIKKAN K                             " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO = " + kojinno + "          " + Constants.vbCr;
                SQL += "          AND K.EDANO   = " + edano + "            " + Constants.vbCr;
                SQL += "WHERE                                              " + Constants.vbCr;
                SQL += "       K.NENDO   = " + nendo + "                   " + Constants.vbCr;
                SQL += "   AND K.CD      = " + cd + "                      " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_KSTOKUSIKKAN (                              " + Constants.vbCr;
                SQL += "    NENDO                                                 " + Constants.vbCr;
                SQL += "   ,KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,CD                                                    " + Constants.vbCr;
                SQL += "   ," + sakiFldNm + "                                     " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + nendo + "                                         " + Constants.vbCr;
                SQL += "   ," + kojinno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + cd + "'                                          " + Constants.vbCr;
                SQL += "   ," + itemValue + "                                     " + Constants.vbCr;
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 家族歴登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_KKKAZOKUREKI(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string kojinno = "";
            string byomeikbn = "";
            string zoku = "";
            string otherbyomei = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_KKKAZOKUREKI'             " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("BYOMEIKBN") & !fldNm.Contains("ZOKU") & !fldNm.Contains("OTHERBYOMEI"))
                {
                    continue;
                }

                if (fldNm == "BYOMEIKBN")
                {
                    byomeikbn = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                if (fldNm == "ZOKU")
                {
                    zoku = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                if (fldNm == "OTHERBYOMEI")
                {
                    otherbyomei = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                if (!string.IsNullOrEmpty(byomeikbn) & !string.IsNullOrEmpty(zoku))
                {
                    SQL = " DELETE FROM K                                      " + Constants.vbCr;
                    SQL += "FROM TM_KKKAZOKUREKI K                             " + Constants.vbCr;
                    SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                    SQL += "           ON K.KOJINNO = " + kojinno + "          " + Constants.vbCr;
                    SQL += "          AND K.BYOMEIKBN   = " + byomeikbn + "    " + Constants.vbCr;
                    SQL += "          AND K.ZOKU   = " + zoku + "              " + Constants.vbCr;
                    SQL += "WHERE                                              " + Constants.vbCr;
                    SQL += "       WK.GYONO NOT IN (                           " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                    SQL += "       )                                           " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    SQL = "INSERT INTO TM_KKKAZOKUREKI (                              " + Constants.vbCr;
                    SQL += "    KOJINNO                                               " + Constants.vbCr;
                    SQL += "   ,USERID                                                " + Constants.vbCr;
                    SQL += "   ,SYORIYMD                                              " + Constants.vbCr;
                    SQL += "   ,BYOMEIKBN                                             " + Constants.vbCr;
                    SQL += "   ,ZOKU                                                  " + Constants.vbCr;
                    SQL += "   ,OTHERBYOMEI                                           " + Constants.vbCr;
                    SQL += ")                                                         " + Constants.vbCr;
                    SQL += "SELECT                                                    " + Constants.vbCr;
                    SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("   ,'", htParam["userid"]), "'                           "), Constants.vbCr));
                    SQL += "   ,GETDATE()                                             " + Constants.vbCr;
                    SQL += "   ," + byomeikbn + "                                     " + Constants.vbCr;
                    SQL += "   ," + zoku + "                                          " + Constants.vbCr;
                    SQL += "   ,NULL                                                  " + Constants.vbCr;
                    SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                    SQL += "WHERE                                                     " + Constants.vbCr;
                    SQL += "  LTRIM(" + byomeikbn + ") <> ''                          " + Constants.vbCr;
                    SQL += "  AND LTRIM(" + zoku + ") <> ''                           " + Constants.vbCr;
                    SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                    SQL += "      )                                                   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    byomeikbn = "";
                    zoku = "";
                }
                else if (!string.IsNullOrEmpty(otherbyomei))
                {
                    SQL = "INSERT INTO TM_KKKAZOKUREKI (                              " + Constants.vbCr;
                    SQL += "    KOJINNO                                               " + Constants.vbCr;
                    SQL += "   ,USERID                                                " + Constants.vbCr;
                    SQL += "   ,SYORIYMD                                              " + Constants.vbCr;
                    SQL += "   ,BYOMEIKBN                                             " + Constants.vbCr;
                    SQL += "   ,ZOKU                                                  " + Constants.vbCr;
                    SQL += "   ,OTHERBYOMEI                                           " + Constants.vbCr;
                    SQL += ")                                                         " + Constants.vbCr;
                    SQL += "SELECT                                                    " + Constants.vbCr;
                    SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("   ,'", htParam["userid"]), "'                           "), Constants.vbCr));
                    SQL += "   ,GETDATE()                                             " + Constants.vbCr;
                    SQL += "   ,'99'                                                  " + Constants.vbCr;
                    SQL += "   ,'99'                                                  " + Constants.vbCr;
                    SQL += "   ," + otherbyomei + "                                   " + Constants.vbCr;
                    SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                    SQL += "WHERE                                                     " + Constants.vbCr;
                    SQL += "  LTRIM(" + otherbyomei + ") <> ''                        " + Constants.vbCr;
                    SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                    SQL += "      )                                                   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    otherbyomei = "";
                }
            }
        }

        /// <summary>
        /// 既往歴登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_KKKIOREKI(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string kojinno = "";
            string byomeikbn = "";
            string tiryokbn = "";
            string hassyonenrei = "";
            string otherbyomei = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_KKKIOREKI'             " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("BYOMEIKBN") & !fldNm.Contains("TIRYOKBN") & !fldNm.Contains("HASSYONENREI") & !fldNm.Contains("OTHERBYOMEI"))
                {
                    continue;
                }

                if (fldNm == "BYOMEIKBN")
                {
                    byomeikbn = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                if (fldNm == "TIRYOKBN")
                {
                    tiryokbn = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                if (fldNm == "HASSYONENREI")
                {
                    hassyonenrei = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                if (fldNm == "OTHERBYOMEI")
                {
                    otherbyomei = dt.Rows[rowIndx]["SETDATA"].ToString();
                }
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                if (!string.IsNullOrEmpty(byomeikbn) & !string.IsNullOrEmpty(tiryokbn) & !string.IsNullOrEmpty(hassyonenrei))
                {
                    SQL = " DELETE FROM K                                      " + Constants.vbCr;
                    SQL += "FROM TM_KKKIOREKI K                                " + Constants.vbCr;
                    SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                    SQL += "           ON K.KOJINNO = " + kojinno + "          " + Constants.vbCr;
                    SQL += "          AND K.BYOMEIKBN   = " + byomeikbn + "    " + Constants.vbCr;
                    SQL += "WHERE                                              " + Constants.vbCr;
                    SQL += "       WK.GYONO NOT IN (                           " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                    SQL += "       )                                           " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    SQL = "INSERT INTO TM_KKKIOREKI (                                 " + Constants.vbCr;
                    SQL += "    KOJINNO                                               " + Constants.vbCr;
                    SQL += "   ,USERID                                                " + Constants.vbCr;
                    SQL += "   ,SYORIYMD                                              " + Constants.vbCr;
                    SQL += "   ,BYOMEIKBN                                             " + Constants.vbCr;
                    SQL += "   ,OTHERBYOMEI                                           " + Constants.vbCr;
                    SQL += "   ,TIRYOKBN                                              " + Constants.vbCr;
                    SQL += "   ,HASSYONENREI                                          " + Constants.vbCr;
                    SQL += "   ,NYUINFLG                                              " + Constants.vbCr;
                    SQL += "   ,SYUJUTUFLG                                            " + Constants.vbCr;
                    SQL += "   ,YUKETUFLG                                             " + Constants.vbCr;
                    SQL += ")                                                         " + Constants.vbCr;
                    SQL += "SELECT                                                    " + Constants.vbCr;
                    SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("   ,'", htParam["userid"]), "'                           "), Constants.vbCr));
                    SQL += "   ,GETDATE()                                             " + Constants.vbCr;
                    SQL += "   ," + byomeikbn + "                                     " + Constants.vbCr;
                    SQL += "   ,NULL                                                  " + Constants.vbCr;
                    SQL += "   ," + CM_kyotu_proc.pubf_CnvNull(tiryokbn, 0) + "                     " + Constants.vbCr;
                    SQL += "   ," + CM_kyotu_proc.pubf_CnvNull(hassyonenrei, 0) + "                 " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                    SQL += "WHERE                                                     " + Constants.vbCr;
                    SQL += "  LTRIM(" + byomeikbn + ") <> ''                          " + Constants.vbCr;
                    SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                    SQL += "      )                                                   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    byomeikbn = "";
                    tiryokbn = "";
                    hassyonenrei = "";
                }
                else if (!string.IsNullOrEmpty(otherbyomei))
                {
                    SQL = "INSERT INTO TM_KKKIOREKI (                                 " + Constants.vbCr;
                    SQL += "    KOJINNO                                               " + Constants.vbCr;
                    SQL += "   ,USERID                                                " + Constants.vbCr;
                    SQL += "   ,SYORIYMD                                              " + Constants.vbCr;
                    SQL += "   ,BYOMEIKBN                                             " + Constants.vbCr;
                    SQL += "   ,OTHERBYOMEI                                           " + Constants.vbCr;
                    SQL += "   ,TIRYOKBN                                              " + Constants.vbCr;
                    SQL += "   ,HASSYONENREI                                          " + Constants.vbCr;
                    SQL += "   ,NYUINFLG                                              " + Constants.vbCr;
                    SQL += "   ,SYUJUTUFLG                                            " + Constants.vbCr;
                    SQL += "   ,YUKETUFLG                                             " + Constants.vbCr;
                    SQL += ")                                                         " + Constants.vbCr;
                    SQL += "SELECT                                                    " + Constants.vbCr;
                    SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("   ,'", htParam["userid"]), "'                           "), Constants.vbCr));
                    SQL += "   ,GETDATE()                                             " + Constants.vbCr;
                    SQL += "   ,'49'                                                  " + Constants.vbCr;
                    SQL += "   ," + otherbyomei + "                                   " + Constants.vbCr;
                    SQL += "   ,NULL                                                  " + Constants.vbCr;
                    SQL += "   ,NULL                                                  " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "   ,0                                                     " + Constants.vbCr;
                    SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                    SQL += "WHERE                                                     " + Constants.vbCr;
                    SQL += "  LTRIM(" + otherbyomei + ") <> ''                        " + Constants.vbCr;
                    SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                    SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                    SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                    SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                    SQL += "      )                                                   " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();

                    otherbyomei = "";
                }
            }
        }

        /// <summary>
        /// 委託料管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_ITITAKU(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string maincd = "";
            string subcd = "";
            string tNengetu = "";
            string kikancd = "";
            string itemcd = "";
            string item = "";
            string itemValue = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_ITITAKU'                  " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            maincd = Conversions.ToString(dt.Select("FLDNM='MAINCD'")[0]["SETDATA"]);
            subcd = Conversions.ToString(dt.Select("FLDNM='SUBCD'")[0]["SETDATA"]);
            tNengetu = Conversions.ToString(dt.Select("FLDNM='TNENGETU'")[0]["SETDATA"]);
            kikancd = Conversions.ToString(dt.Select("FLDNM='KIKANCD'")[0]["SETDATA"]);

            SQL = " DELETE FROM K                                     " + Constants.vbCr;
            SQL += "FROM TM_ITITAKU K                                 " + Constants.vbCr;
            SQL += "    INNER JOIN " + wktableName + " WK             " + Constants.vbCr;
            SQL += "           ON K.MAINCD   = " + maincd + "         " + Constants.vbCr;
            SQL += "          AND K.SUBCD    = " + subcd + "          " + Constants.vbCr;
            SQL += "          AND K.KIKANCD  = " + kikancd + "        " + Constants.vbCr;
            SQL += "          AND K.TNENGETU = " + tNengetu + "       " + Constants.vbCr;
            SQL += " WHERE WK.GYONO NOT IN (                          " + Constants.vbCr;
            SQL += "        SELECT  GYONO                             " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "      "), Constants.vbCr));
            SQL += "        WHERE ERRORKBN = '3'                      " + Constants.vbCr;
            SQL += "        GROUP BY GYONO                            " + Constants.vbCr;
            SQL += "      )                                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();

            // 件数登録
            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("KENSU"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                itemcd = splFldNm[0];
                item = splFldNm[1];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();

                SQL = "INSERT INTO TM_ITITAKU(                            " + Constants.vbCr;
                SQL += "    MAINCD                                        " + Constants.vbCr;
                SQL += "   ,SUBCD                                         " + Constants.vbCr;
                SQL += "   ,KIKANCD                                       " + Constants.vbCr;
                SQL += "   ,TNENGETU                                      " + Constants.vbCr;
                SQL += "   ,ITEMCD                                        " + Constants.vbCr;
                SQL += "   ,KENSU                                         " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "    " + maincd + "                                " + Constants.vbCr;
                SQL += "   ," + subcd + "                                 " + Constants.vbCr;
                SQL += "   ," + kikancd + "                               " + Constants.vbCr;
                SQL += "   ," + tNengetu + "                              " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                              " + Constants.vbCr;
                SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                SQL += "FROM  " + wktableName + " WK                      " + Constants.vbCr;
                SQL += "WHERE  WK.GYONO NOT IN (                          " + Constants.vbCr;
                SQL += "        SELECT  GYONO                             " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "      "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                      " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                            " + Constants.vbCr;
                SQL += "      )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }

            // 金額更新
            for (int rowIndx = 0, loopTo1 = dt.Rows.Count - 1; rowIndx <= loopTo1; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("GAKU"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                itemcd = splFldNm[0];
                item = splFldNm[1];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();

                SQL = " UPDATE K                                          " + Constants.vbCr;
                SQL += "    SET GAKU = " + itemValue + "                  " + Constants.vbCr;
                SQL += "FROM TM_ITITAKU K                                 " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK             " + Constants.vbCr;
                SQL += "           ON K.MAINCD   = " + maincd + "         " + Constants.vbCr;
                SQL += "          AND K.SUBCD    = " + subcd + "          " + Constants.vbCr;
                SQL += "          AND K.KIKANCD  = " + kikancd + "        " + Constants.vbCr;
                SQL += "          AND K.TNENGETU = " + tNengetu + "       " + Constants.vbCr;
                SQL += "          AND K.ITEMCD   = '" + itemcd + "'       " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 妊産婦動的項目管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNSITEM(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string bnendo;
            string bkofuno;
            string edano;
            string kenkaisu;

            string itemcd;
            string itemeda;
            string datatype;
            string maincd;
            string subcd;
            string itemValue;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNSITEM'                 " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            bnendo = Conversions.ToString(dt.Select("FLDNM='BNENDO'")[0]["SETDATA"]);
            bkofuno = Conversions.ToString(dt.Select("FLDNM='BKOFUNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);
            kenkaisu = Conversions.ToString(dt.Select("FLDNM='KENKAISU'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                itemcd = splFldNm[0];
                itemeda = splFldNm[1];
                datatype = splFldNm[2];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNSITEM K                                 " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.BNENDO    = " + bnendo + "         " + Constants.vbCr;
                SQL += "          AND K.BKOFUNO   = " + bkofuno + "        " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "          AND K.KENKAISU  = " + kenkaisu + "       " + Constants.vbCr;
                SQL += "WHERE  K.ITEMCD  = '" + itemcd + "'                " + Constants.vbCr;
                SQL += "   AND K.ITEMEDA = '" + itemeda + "'               " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNSITEM (                                  " + Constants.vbCr;
                SQL += "    BNENDO                                                " + Constants.vbCr;
                SQL += "   ,BKOFUNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,KENKAISU                                              " + Constants.vbCr;
                SQL += "   ,ITEMCD                                                " + Constants.vbCr;
                SQL += "   ,ITEMEDA                                               " + Constants.vbCr;
                SQL += "   ," + datatype + "                                      " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + bnendo + "                                        " + Constants.vbCr;
                SQL += "   ," + bkofuno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + kenkaisu + "'                                    " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                                      " + Constants.vbCr;
                SQL += "   ,'" + itemeda + "'                                     " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            break;
                        }
                    case "4": // ﾒﾓ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "5": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 妊産婦問診管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNSMONSIN(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string bnendo;
            string bkofuno;
            string edano;

            string kensinkbn;
            string monsincd;
            string monsineda;
            string datatype;

            string maincd;
            string subcd;
            string itemValue;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNSMONSIN'               " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            bnendo = Conversions.ToString(dt.Select("FLDNM='BNENDO'")[0]["SETDATA"]);
            bkofuno = Conversions.ToString(dt.Select("FLDNM='BKOFUNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                kensinkbn = splFldNm[0];
                monsincd = splFldNm[1];
                monsineda = splFldNm[2];
                datatype = splFldNm[3];

                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNSMONSIN K                               " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.BNENDO   = " + bnendo + "          " + Constants.vbCr;
                SQL += "          AND K.BKOFUNO   = " + bkofuno + "        " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "WHERE  K.KENSINKBN  = '" + kensinkbn + "'          " + Constants.vbCr;
                SQL += "   AND K.MONSINCD   = '" + monsincd + "'           " + Constants.vbCr;
                SQL += "   AND K.MONSINEDA  = '" + monsineda + "'          " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNSMONSIN (                                " + Constants.vbCr;
                SQL += "    BNENDO                                                " + Constants.vbCr;
                SQL += "   ,BKOFUNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,KENSINKBN                                             " + Constants.vbCr;
                SQL += "   ,MONSINCD                                              " + Constants.vbCr;
                SQL += "   ,MONSINEDA                                             " + Constants.vbCr;
                SQL += "   ," + datatype + "                                      " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + bnendo + "                                        " + Constants.vbCr;
                SQL += "   ," + bkofuno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + kensinkbn + "'                                   " + Constants.vbCr;
                SQL += "   ,'" + monsincd + "'                                    " + Constants.vbCr;
                SQL += "   ,'" + monsineda + "'                                   " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            break;
                        }
                    case "4": // ﾒﾓ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "5": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 妊産婦フリー項目マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNSFREE(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string bnendo = "";
            string bkofuno = "";
            string edano = "";

            string kenkaisu = "";
            string itemcd = "";
            string datatype = "";

            string itemValue = "";
            string maincd = "";
            string subcd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNSFREE'                 " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            bnendo = Conversions.ToString(dt.Select("FLDNM='BNENDO'")[0]["SETDATA"]);
            bkofuno = Conversions.ToString(dt.Select("FLDNM='BKOFUNO'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                kenkaisu = splFldNm[0];
                itemcd = splFldNm[1];
                datatype = splFldNm[2];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNSFREE K                                 " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.BNENDO   = " + bnendo + "          " + Constants.vbCr;
                SQL += "          AND K.BKOFUNO   = " + bkofuno + "        " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "WHERE                                              " + Constants.vbCr;
                SQL += "       K.KENKAISU   = " + kenkaisu + "             " + Constants.vbCr;
                SQL += "   AND K.ITEMCD  = '" + itemcd + "'                " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNSFREE (                                  " + Constants.vbCr;
                SQL += "    BNENDO                                                " + Constants.vbCr;
                SQL += "   ,BKOFUNO                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,KENKAISU                                              " + Constants.vbCr;
                SQL += "   ,ITEMCD                                                " + Constants.vbCr;

                switch (datatype ?? "")
                {
                    case "DATATYPE1":
                        {
                            // 数値
                            SQL += "   ,DATATYPE1                                     " + Constants.vbCr;
                            SQL += "   ,DATATYPE2                                     " + Constants.vbCr;
                            break;
                        }

                    default:
                        {
                            // 数値以外
                            SQL += "   ," + datatype + "                              " + Constants.vbCr;
                            break;
                        }
                }

                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + bnendo + "                                        " + Constants.vbCr;
                SQL += "   ," + bkofuno + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + kenkaisu + "'                                    " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                                      " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "4": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 乳幼児動的項目管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNYITEM(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string kojinno;
            string getukbn;
            string kensinkbn;
            string edano;

            string itemcd;
            string itemeda;
            string datatype;

            string maincd;
            string subcd;
            string itemValue;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNYITEM'                 " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            getukbn = Conversions.ToString(dt.Select("FLDNM='GETUKBN'")[0]["SETDATA"]);
            kensinkbn = Conversions.ToString(dt.Select("FLDNM='KENSINKBN'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                itemcd = splFldNm[0];
                itemeda = splFldNm[1];
                datatype = splFldNm[2];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNYITEM K                                 " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO   = " + kojinno + "        " + Constants.vbCr;
                SQL += "          AND K.GETUKBN   = " + getukbn + "        " + Constants.vbCr;
                SQL += "          AND K.KENSINKBN = " + kensinkbn + "      " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "WHERE  K.ITEMCD  = '" + itemcd + "'                " + Constants.vbCr;
                SQL += "   AND K.ITEMEDA = '" + itemeda + "'               " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNYITEM (                                  " + Constants.vbCr;
                SQL += "    KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,GETUKBN                                               " + Constants.vbCr;
                SQL += "   ,KENSINKBN                                             " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,ITEMCD                                                " + Constants.vbCr;
                SQL += "   ,ITEMEDA                                               " + Constants.vbCr;
                SQL += "   ," + datatype + "                                      " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                SQL += "   ," + getukbn + "                                       " + Constants.vbCr;
                SQL += "   ," + kensinkbn + "                                     " + Constants.vbCr;
                SQL += "   ,'" + edano + "'                                       " + Constants.vbCr;
                SQL += "   ,'" + itemcd + "'                                      " + Constants.vbCr;
                SQL += "   ,'" + itemeda + "'                                     " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            break;
                        }
                    case "4": // ﾒﾓ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "5": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 乳幼児診察所見管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNYSYOKEN(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string kojinno;
            string getukbn;
            string edano;

            string syokencd;
            string syoken;
            string itemValue;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNYSYOKEN'               " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            getukbn = Conversions.ToString(dt.Select("FLDNM='GETUKBN'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("SYOKEN"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                syokencd = splFldNm[0];
                syoken = splFldNm[1];
                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNYSYOKEN K                               " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO   = " + kojinno + "        " + Constants.vbCr;
                SQL += "          AND K.GETUKBN   = " + getukbn + "        " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "WHERE  K.SYOKENCD  = '" + syokencd + "'            " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNYSYOKEN (                                " + Constants.vbCr;
                SQL += "    KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,GETUKBN                                               " + Constants.vbCr;
                SQL += "   ,SYOKENCD                                              " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,SYOKEN                                                " + Constants.vbCr;
                SQL += "   ,SEIMITU                                               " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + kojinno + "                                       " + Constants.vbCr;
                SQL += "   ," + getukbn + "                                       " + Constants.vbCr;
                SQL += "   ,'" + syokencd + "'                                    " + Constants.vbCr;
                SQL += "   ,'" + edano + "'                                       " + Constants.vbCr;
                SQL += "   ," + itemValue + "                                     " + Constants.vbCr;
                SQL += "   ,NULL                                                  " + Constants.vbCr;
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 乳幼児問診管理マスタ登録処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTorokuTM_BHNYMONSIN(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            var dt = new DataTable();
            SqlDataAdapter da;
            string SQL = "";

            string fldNm;
            string[] splFldNm;

            string kojinno;
            string getukbn;
            string edano;

            string kensinkbn;
            string monsincd;
            string monsineda;
            string datatype;

            string maincd;
            string subcd;
            string itemValue;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = 'TM_BHNYMONSIN'               " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            kojinno = Conversions.ToString(dt.Select("FLDNM='KOJINNO'")[0]["SETDATA"]);
            getukbn = Conversions.ToString(dt.Select("FLDNM='GETUKBN'")[0]["SETDATA"]);
            edano = Conversions.ToString(dt.Select("FLDNM='EDANO'")[0]["SETDATA"]);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                fldNm = dt.Rows[rowIndx]["FLDNM"].ToString();

                if (!fldNm.Contains("DATATYPE"))
                {
                    continue;
                }

                splFldNm = Strings.Split(fldNm, ";");

                kensinkbn = splFldNm[0];
                monsincd = splFldNm[1];
                monsineda = splFldNm[2];
                datatype = splFldNm[3];

                itemValue = dt.Rows[rowIndx]["SETDATA"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = " DELETE FROM K                                      " + Constants.vbCr;
                SQL += "FROM TM_BHNYMONSIN K                               " + Constants.vbCr;
                SQL += "    INNER JOIN " + wktableName + " WK              " + Constants.vbCr;
                SQL += "           ON K.KOJINNO   = " + kojinno + "        " + Constants.vbCr;
                SQL += "          AND K.GETUKBN   = " + getukbn + "        " + Constants.vbCr;
                SQL += "          AND K.EDANO     = " + edano + "          " + Constants.vbCr;
                SQL += "WHERE  K.KENSINKBN  = '" + kensinkbn + "'          " + Constants.vbCr;
                SQL += "   AND K.MONSINCD   = '" + monsincd + "'           " + Constants.vbCr;
                SQL += "   AND K.MONSINEDA  = '" + monsineda + "'          " + Constants.vbCr;
                SQL += "   AND WK.GYONO NOT IN (                           " + Constants.vbCr;
                SQL += "        SELECT  GYONO                              " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "       "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                       " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                             " + Constants.vbCr;
                SQL += "       )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();

                SQL = "INSERT INTO TM_BHNYMONSIN (                                " + Constants.vbCr;
                SQL += "    KOJINNO                                               " + Constants.vbCr;
                SQL += "   ,GETUKBN                                               " + Constants.vbCr;
                SQL += "   ,EDANO                                                 " + Constants.vbCr;
                SQL += "   ,KENSINKBN                                             " + Constants.vbCr;
                SQL += "   ,MONSINCD                                              " + Constants.vbCr;
                SQL += "   ,MONSINEDA                                             " + Constants.vbCr;
                SQL += "   ," + datatype + "                                      " + Constants.vbCr;
                SQL += ")                                                         " + Constants.vbCr;
                SQL += "SELECT                                                    " + Constants.vbCr;
                SQL += "    " + kojinno + "                                        " + Constants.vbCr;
                SQL += "   ," + getukbn + "                                       " + Constants.vbCr;
                SQL += "   ," + edano + "                                         " + Constants.vbCr;
                SQL += "   ,'" + kensinkbn + "'                                   " + Constants.vbCr;
                SQL += "   ,'" + monsincd + "'                                    " + Constants.vbCr;
                SQL += "   ,'" + monsineda + "'                                   " + Constants.vbCr;
                switch (Strings.Right(datatype, 1) ?? "")
                {
                    case "1": // ｺｰﾄﾞ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "2": // ﾃｷｽﾄ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "3": // 数値
                        {
                            SQL += "   ,CONVERT(REAL," + itemValue + ")               " + Constants.vbCr;
                            break;
                        }
                    case "4": // ﾒﾓ
                        {
                            SQL += "   ," + itemValue + "                             " + Constants.vbCr;
                            break;
                        }
                    case "5": // 日付
                        {
                            SQL += "   ,CONVERT(DATETIME, " + itemValue + ")          " + Constants.vbCr;
                            break;
                        }
                }
                SQL += "FROM  " + wktableName + " WK                              " + Constants.vbCr;
                SQL += "WHERE                                                     " + Constants.vbCr;
                SQL += "  LTRIM(" + itemValue + ") <> ''                          " + Constants.vbCr;
                SQL += "  AND WK.GYONO NOT IN (                                   " + Constants.vbCr;
                SQL += "        SELECT  GYONO                                     " + Constants.vbCr;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), "              "), Constants.vbCr));
                SQL += "        WHERE ERRORKBN = '3'                              " + Constants.vbCr;
                SQL += "        GROUP BY GYONO                                    " + Constants.vbCr;
                SQL += "      )                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeConvertCode(SqlConnection conn, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string komokucd = "";
            string maincd = "";
            string subcd = "";

            string SQL_Set = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.DISPTYPEKBN = '003'                      " + Constants.vbCr;
            SQL += "  AND IT.CFMAINCD IS NOT NULL                     " + Constants.vbCr;
            SQL += "  AND IT.CFSUBCD  IS NOT NULL                     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                komokucd = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                if (rowIndx > 0)
                {
                    SQL_Set += ",";
                }

                SQL_Set += "WK.[" + komokucd + "]  = ";
                SQL_Set += " (SELECT KBN1 ";
                SQL_Set += "  FROM   TC_KKCF ";
                SQL_Set += "  WHERE  MAINCD = '" + maincd + "'  ";
                SQL_Set += "    AND SUBCD = '" + subcd + "'     ";
                SQL_Set += "    AND CD = WK.[" + komokucd + "]) " + Constants.vbCr;
            }

            SQL = "UPDATE                                " + Constants.vbCr;
            SQL += "    WK                               " + Constants.vbCr;
            SQL += "SET                                  " + Constants.vbCr;
            SQL += SQL_Set;
            SQL += "FROM                                 " + Constants.vbCr;
            SQL += "   " + wktableName + " WK            " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">データ追加テーブル名称</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executDelete(SqlConnection conn, string tableName, string wktableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;

            string SQL_Join = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;
            SQL += "  AND IT.SETDATA IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                if (dt.Rows[rowIndx]["FLDKEYFLG"].ToString() == "1")
                {
                    if (string.IsNullOrEmpty(SQL_Join))
                    {
                        SQL_Join += "  ON ";
                    }
                    else
                    {
                        SQL_Join += " AND ";
                    }
                    SQL_Join += "  K.[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "] = ";
                    SQL_Join += "  " + dt.Rows[rowIndx]["SETDATA"].ToString() + "" + Constants.vbCr;
                }
            }

            SQL = "DELETE FROM K                              " + Constants.vbCr;
            SQL += "FROM " + tableName + " K                  " + Constants.vbCr;
            SQL += "    INNER JOIN " + wktableName + " WK     " + Constants.vbCr;
            SQL += SQL_Join;

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
            {
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(" AND K.NENDO = ", htParam["snendo"]), Constants.vbCr));
            }

            // 接種区分を取得（取込処理（予防接種）以外の場合は空）
            string sessyukbn = getSessyukbn(entity.SYORICD, dt);
            if (!string.IsNullOrEmpty(sessyukbn))
            {
                SQL += " AND K.SESSYUKBN = '" + sessyukbn + "'" + Constants.vbCr;
            }
            SQL += "WHERE  WK.GYONO NOT IN (                    " + Constants.vbCr;
            SQL += "        SELECT  GYONO                       " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("        FROM ", htParam["errTableName"]), ""), Constants.vbCr));
            SQL += "        WHERE ERRORKBN = '3'                " + Constants.vbCr;
            SQL += "        GROUP BY GYONO                      " + Constants.vbCr;
            SQL += "      )                                     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// ストアドプロシージャ実行処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="htParam"></param>
        /// <param name="storedProc">実行ストアドプロシージャ</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeStoredProcedure(SqlConnection conn, Hashtable htParam, string storedProc, SqlTransaction wkTrn = null)
        {
            SqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = wkTrn;
            cmd.CommandText = storedProc;
            cmd.CommandTimeout = 300;

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(htParam["snendo"], "", false)))
            {
                cmd.Parameters.Add("@SNENDO", SqlDbType.Int).Value = 0;
            }
            else
            {
                cmd.Parameters.Add("@SNENDO", SqlDbType.Int).Value = htParam["snendo"];
            }

            cmd.Parameters.Add("@USERID", SqlDbType.VarChar).Value = htParam["userid"];
            cmd.Parameters.Add("@WKTABLE", SqlDbType.VarChar).Value = htParam["wkTableName"];
            cmd.Parameters.Add("@ERRTABLE", SqlDbType.VarChar).Value = htParam["errTableName"];

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// CSVファイルを出力する。(Serverへファイル保存)
        /// </summary>
        /// <param name="outdt">データテーブル</param>
        /// <param name="insFileName">フルパス付のファイル名</param>
        /// <param name="encode">文字コード</param>
        /// <returns>TRUE: 抽出結果が存在し、CSV出力に成功 FALSE: 抽出結果が存在しない</returns>
        /// <remarks></remarks>
        public bool createCSVForDataTable(DataTable outdt, string insFileName, string encode)
        {
            var db = new CM_dbaccess();
            bool append = false;
            System.Text.Encoding enc;
            var format = new System.Text.StringBuilder();
            var head = new System.Text.StringBuilder();
            string strData;

            // 文字コード設定
            if (string.IsNullOrEmpty(encode))
            {
                encode = "Shift-JIS";
            }
            enc = System.Text.Encoding.GetEncoding(encode);

            // ' 結果が1行も存在しなかった場合
            if (outdt.Rows.Count == 0)
            {
                return false;
            }
            CM_kyotu_proc.pubCSVCount = outdt.Rows.Count.ToString();

            for (int i = 0, loopTo = outdt.Columns.Count - 1; i <= loopTo; i++)
            {
                if (!(i == 0))
                {
                    format.Append(',');
                }
                format.AppendFormat("\"{0}{1:d}{2}\"", "{", i, "}");
                if (!(i == 0))
                {
                    head.Append(',');
                }
                strData = outdt.Columns[i].Caption;
                strData = CM_kyotu_proc.pubf_CnvStr(strData, 1);
                head.AppendFormat("\"{0}\"", strData);
            }

            var writer = My.OpenTextFileWriter(insFileName, append, enc);
            // 見出しを出力
            writer.WriteLine(head.ToString());
            for (long nRowCnt = 0L, loopTo1 = outdt.Rows.Count - 1; nRowCnt <= loopTo1; nRowCnt++)
                writer.WriteLine(format.ToString(), outdt.Rows[(int)nRowCnt].ItemArray);
            writer.Close();

            return true;
        }

        /// <summary>
        /// テーブルデータ一括削除処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="tableName">テーブル名称</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeTruncateTable(SqlConnection conn, string tableName, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;

            SQL = "TRUNCATE TABLE dbo." + tableName + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// アップロードURL取得処理
        /// </summary>
        /// <param name="conn">DBコネクション</param>
        /// <param name="xmlDoc">データリーダの内容を追加するXMLドキュメント</param>
        /// <param name="root">ルートタグ</param>
        /// <remarks></remarks>
        public void pubf_GetUpURL(ref SqlConnection conn, ref XmlDocument xmlDoc, ref XmlElement root)
        {
            SqlCommand cmd;
            string SQL;
            string uplUrl = System.Configuration.ConfigurationManager.ConnectionStrings["importUrl"].ToString();

            SQL = "SELECT                                           " + Constants.vbCr;
            SQL += "    '" + uplUrl + "UPIMPORT.PHP'  AS  UPLURL    " + Constants.vbCr;
            SQL += "    ,'" + uplUrl + "'             AS  UPLFOL    " + Constants.vbCr;

            cmd = new SqlCommand(SQL, conn);

            using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
            {
                CM_kyotu_proc.pub_CreateXML(dr, xmlDoc, "MUPLURL", root);
            }
        }

        /// <summary>
        /// 項目値変換用SQL取得処理(登録用)
        /// </summary>
        /// <param name="dispTypeKbn">DBコネクション</param>
        /// <param name="setData">データリーダの内容を追加するXMLドキュメント</param>
        /// <remarks></remarks>
        private string getSQLItemConvert(string dispTypeKbn, string setData)
        {
            string SQL = "";

            if ((dispTypeKbn ?? "") == DISPTYPEKBN_NUM)
            {
                SQL += " CONVERT(REAL, " + setData + ")       " + Constants.vbCr;
            }
            else if ((dispTypeKbn ?? "") == DISPTYPEKBN_DATE)
            {
                SQL += " CONVERT(DATETIME, " + setData + ")   " + Constants.vbCr;
            }
            else
            {
                SQL += " " + setData + "                      " + Constants.vbCr;
            }

            return SQL;
        }

        /// <summary>
        /// 項目値変換用SQL取得処理(表示用)
        /// </summary>
        /// <param name="dispTypeKbn">DBコネクション</param>
        /// <param name="setData">データリーダの内容を追加するXMLドキュメント</param>
        /// <remarks></remarks>
        private string getSQLItemConvertDisp(string dispTypeKbn, string setData)
        {
            string SQL = "";

            if ((dispTypeKbn ?? "") == DISPTYPEKBN_NUM)
            {
                SQL += " CONVERT(REAL, " + setData + ")       ";
            }
            else if ((dispTypeKbn ?? "") == DISPTYPEKBN_DATE)
            {
                SQL += " CONVERT(NVARCHAR, " + setData + ", 111)   ";
            }
            else
            {
                SQL += " " + setData + "                      ";
            }

            return SQL;
        }

        /// <summary>
        /// 取込・一括入力処理マスタ取得用のSQLを作成する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="jikkokbn">実行区分</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string createSQL_TC_KKTORIIKKATU(string systemcd, string syoricd, string edano, string jikkokbn)
        {
            string createSQL_TC_KKTORIIKKATURet = default;
            string SQL;

            SQL = " SELECT SYORICD                  AS SYORICD     " + Constants.vbCr;
            SQL += "      ,EDANO                    AS EDANO       " + Constants.vbCr;
            SQL += "      ,SYORINM                  AS SYORINM     " + Constants.vbCr;
            SQL += "      ,YOSIKICD                 AS YOSIKICD    " + Constants.vbCr;
            SQL += "      ,INSUPDKBN                AS INSUPDKBN   " + Constants.vbCr;
            SQL += "      ,JIKKOKBN                 AS JIKKOKBN    " + Constants.vbCr;
            SQL += "      ,NENDOSIYOFLG             AS NENDOSIYOFLG" + Constants.vbCr;
            SQL += "      ,FILEPATH                 AS FILEPATH    " + Constants.vbCr;
            SQL += "      ,FILENM                   AS FILENM      " + Constants.vbCr;
            SQL += "      ,HFILENM                  AS HFILENM     " + Constants.vbCr;
            SQL += "      ,ORDERID                  AS ORDERID     " + Constants.vbCr;
            SQL += "      ,DISPCHKFLG               AS DISPCHKFLG  " + Constants.vbCr;
            SQL += "      ,DISPROWFLG               AS DISPROWFLG  " + Constants.vbCr;
            SQL += "      ,DISPADDFLG               AS DISPADDFLG  " + Constants.vbCr;
            SQL += "      ,DISPDELFLG               AS DISPDELFLG  " + Constants.vbCr;
            SQL += "      ,CHKSTORED                AS CHKSTORED   " + Constants.vbCr;
            SQL += "      ,BEFSTORED                AS BEFSTORED   " + Constants.vbCr;
            SQL += "      ,AFTSTORED                AS AFTSTORED   " + Constants.vbCr;
            SQL += "  FROM TC_KKTORIIKKATU                         " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                    " + Constants.vbCr;
            if (!string.IsNullOrEmpty(systemcd))
            {
                SQL += "  AND LEFT(SYORICD,2) = LEFT('" + systemcd + "', 2) " + Constants.vbCr;
            }
            if (!string.IsNullOrEmpty(syoricd))
            {
                SQL += "  AND SYORICD = '" + syoricd + "'          " + Constants.vbCr;
            }

            if (!string.IsNullOrEmpty(edano))
            {
                SQL += "  AND EDANO = " + edano + "                " + Constants.vbCr;
            }

            if (!string.IsNullOrEmpty(jikkokbn))
            {
                SQL += "  AND JIKKOKBN = '" + jikkokbn + "'        " + Constants.vbCr;
            }

            SQL += "ORDER BY CONVERT(INT, ORDERID)                 " + Constants.vbCr;

            createSQL_TC_KKTORIIKKATURet = SQL;
            return createSQL_TC_KKTORIIKKATURet;
        }

        /// <summary>
        /// 取込・一括入力処理項目マスタ取得用のSQLを作成する
        /// </summary>
        /// <param name="yosikicd">様式コード</param>
        /// <param name="jikkokbn">実行区分</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string createSQL_TC_KKTORIIKKATUITEM(string yosikicd, string jikkokbn)
        {
            string createSQL_TC_KKTORIIKKATUITEMRet = default;
            string SQL;

            // 複数の処理コードで同じ様式コードを使用している
            // 場合、複数レコード取得するので重複レコードを削除する。
            SQL = "SELECT DISTINCT                                    " + Constants.vbCr;
            SQL += "       IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.HIMODUKECD            AS  HIMODUKECD    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.DISPFORMAT            AS  DISPFORMAT    " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "      ,CONVERT(INT,IT.DISPORDERID) AS ORDERID     " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;

            if (!string.IsNullOrEmpty(yosikicd))
            {
                SQL += "  AND IT.YOSIKICD = '" + yosikicd + "'        " + Constants.vbCr;
            }

            SQL += "  AND IT.DISPVISFLG = '1'                         " + Constants.vbCr;
            SQL += "ORDER BY CONVERT(INT,IT.DISPORDERID)              " + Constants.vbCr;

            createSQL_TC_KKTORIIKKATUITEMRet = SQL;
            return createSQL_TC_KKTORIIKKATUITEMRet;
        }

        /// <summary>
        /// 取込・一括入力処理マスタを取得する
        /// </summary>
        /// <param name="conn">DBコネクション情報</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private TC_KKTORIIKKATU_Entity GetTcKKToriIkkatu(SqlConnection conn, string syoricd, string edano, SqlTransaction wkTrn = null)
        {
            var resultEntity = new TC_KKTORIIKKATU_Entity();
            string SQL;
            SqlDataAdapter da;
            DataTable dt;

            SQL = createSQL_TC_KKTORIIKKATU("", syoricd, edano, "");

            da = new SqlDataAdapter(SQL, conn);
            if (wkTrn is not null)
            {
                da.SelectCommand.Transaction = wkTrn;
            }
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var drReadData = dt.Rows[0];

                resultEntity.SYORICD = Conversions.ToString(drReadData["SYORICD"]);

                resultEntity.EDANO = Conversions.ToString(drReadData["EDANO"]);

                if (drReadData["SYORINM"] is DBNull == false)
                {
                    resultEntity.SYORINM = Conversions.ToString(drReadData["SYORINM"]);
                }

                if (drReadData["YOSIKICD"] is DBNull == false)
                {
                    resultEntity.YOSIKICD = Conversions.ToString(drReadData["YOSIKICD"]);
                }

                if (drReadData["INSUPDKBN"] is DBNull == false)
                {
                    resultEntity.INSUPDKBN = Conversions.ToString(drReadData["INSUPDKBN"]);
                }

                if (drReadData["JIKKOKBN"] is DBNull == false)
                {
                    resultEntity.JIKKOKBN = Conversions.ToString(drReadData["JIKKOKBN"]);
                }

                if (drReadData["NENDOSIYOFLG"] is DBNull == false)
                {
                    resultEntity.NENDOSIYOFLG = Conversions.ToString(drReadData["NENDOSIYOFLG"]);
                }

                if (drReadData["FILEPATH"] is DBNull == false)
                {
                    resultEntity.FILEPATH = Conversions.ToString(drReadData["FILEPATH"]);
                }

                if (drReadData["FILENM"] is DBNull == false)
                {
                    resultEntity.FILENM = Conversions.ToString(drReadData["FILENM"]);
                }

                if (drReadData["HFILENM"] is DBNull == false)
                {
                    resultEntity.HFILENM = Conversions.ToString(drReadData["HFILENM"]);
                }

                if (drReadData["ORDERID"] is DBNull == false)
                {
                    resultEntity.ORDERID = Conversions.ToString(drReadData["ORDERID"]);
                }

                if (drReadData["DISPCHKFLG"] is DBNull == false)
                {
                    resultEntity.DISPCHKFLG = Conversions.ToString(drReadData["DISPCHKFLG"]);
                }

                if (drReadData["DISPROWFLG"] is DBNull == false)
                {
                    resultEntity.DISPROWFLG = Conversions.ToString(drReadData["DISPROWFLG"]);
                }

                if (drReadData["DISPADDFLG"] is DBNull == false)
                {
                    resultEntity.DISPADDFLG = Conversions.ToString(drReadData["DISPADDFLG"]);
                }

                if (drReadData["DISPDELFLG"] is DBNull == false)
                {
                    resultEntity.DISPDELFLG = Conversions.ToString(drReadData["DISPDELFLG"]);
                }

                if (drReadData["CHKSTORED"] is DBNull == false)
                {
                    resultEntity.CHKSTORED = Conversions.ToString(drReadData["CHKSTORED"]);
                }

                if (drReadData["BEFSTORED"] is DBNull == false)
                {
                    resultEntity.BEFSTORED = Conversions.ToString(drReadData["BEFSTORED"]);
                }

                if (drReadData["AFTSTORED"] is DBNull == false)
                {
                    resultEntity.AFTSTORED = Conversions.ToString(drReadData["AFTSTORED"]);
                }
            }

            return resultEntity;
        }

        /// <summary>
        /// 取込ファイル様式マスタを取得する
        /// </summary>
        /// <param name="conn">DBコネクション情報</param>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private TC_KKTORI_YOSIKI_Entity GetTcKkToriYosiki(SqlConnection conn, string yosikicd, SqlTransaction wkTrn = null)
        {
            var resultEntity = new TC_KKTORI_YOSIKI_Entity();
            string SQL;
            SqlDataAdapter da;
            DataTable dt;

            SQL = " SELECT YOSIKICD               AS YOSIKICD     " + Constants.vbCr;
            SQL += "      ,KEISIKIKBN             AS KEISIKIKBN   " + Constants.vbCr;
            SQL += "      ,MOJICDKBN              AS MOJICDKBN    " + Constants.vbCr;
            SQL += "      ,KUGIRIKBN              AS KUGIRIKBN    " + Constants.vbCr;
            SQL += "      ,INYOFUKBN              AS INYOFUKBN    " + Constants.vbCr;
            SQL += "      ,HEADERROW              AS HEADERROW    " + Constants.vbCr;
            SQL += "FROM TC_KKTORI_YOSIKI                         " + Constants.vbCr;
            SQL += "WHERE YOSIKICD = '" + yosikicd + "'           " + Constants.vbCr;

            da = new SqlDataAdapter(SQL, conn);
            if (wkTrn is not null)
            {
                da.SelectCommand.Transaction = wkTrn;
            }
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var drReadData = dt.Rows[0];
                resultEntity.YOSIKICD = Conversions.ToString(drReadData["YOSIKICD"]);

                if (drReadData["KEISIKIKBN"] is DBNull == false)
                {
                    resultEntity.KEISIKIKBN = Conversions.ToString(drReadData["KEISIKIKBN"]);
                }
                if (drReadData["MOJICDKBN"] is DBNull == false)
                {
                    resultEntity.MOJICDKBN = Conversions.ToString(drReadData["MOJICDKBN"]);
                }
                if (drReadData["KUGIRIKBN"] is DBNull == false)
                {
                    resultEntity.KUGIRIKBN = Conversions.ToString(drReadData["KUGIRIKBN"]);
                }
                if (drReadData["INYOFUKBN"] is DBNull == false)
                {
                    resultEntity.INYOFUKBN = Conversions.ToString(drReadData["INYOFUKBN"]);
                }
                if (drReadData["HEADERROW"] is DBNull == false)
                {
                    resultEntity.HEADERROW = Conversions.ToInteger(drReadData["HEADERROW"]);
                }
            }

            return resultEntity;
        }

        /// <summary>
        /// 必須項目のチェックを行い、値が未入力の場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckRequired(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string hissuchkkbn;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND ISNULL(IT.HISSUCHKKBN, '0') <> '0'          " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                hissuchkkbn = dt.Rows[rowIndx]["HISSUCHKKBN"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + hissuchkkbn + "'                           " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                if (hissuchkkbn == "1" | hissuchkkbn == "2")
                {
                    SQL += "      AND CF.CD    ='00014'                   " + Constants.vbCr;
                }
                else
                {
                    SQL += "      AND CF.CD    ='00001'                   " + Constants.vbCr;
                }

                SQL += "WHERE LEN(LTRIM(WK.[" + item + "])) IS NULL       " + Constants.vbCr;
                SQL += "   OR LEN(LTRIM(WK.[" + item + "])) = 0           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 項目のデータ型チェックを行い、数値型でない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeNum(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND IT.DISPTYPEKBN = '001'                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00002'                       " + Constants.vbCr;
                SQL += "WHERE ISNUMERIC(WK.[" + item + "]) = 0            " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 数値の範囲チェックを行い、範囲外の場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckNumRange(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string minValue;
            string maxValue;

            SQL = "SELECT  IT.YOSIKICD                  AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD                  AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM                  AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN                AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,ISNULL(IT.MIMVALUE, 0)       AS  MIMVALUE      " + Constants.vbCr;
            SQL += "      ,ISNULL(IT.MAXVALUE, 9999999) AS  MAXVALUE      " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                           " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                           " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'      " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                            " & vbCr
            SQL += "  AND IT.DISPTYPEKBN = '001'                          " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();

                minValue = dt.Rows[rowIndx]["MIMVALUE"].ToString();
                maxValue = dt.Rows[rowIndx]["MAXVALUE"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                           " + Constants.vbCr;
                SQL += "  GYONO                                                    " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                                 " + Constants.vbCr;
                SQL += " ,ERRORKBN                                                 " + Constants.vbCr;
                SQL += " ,ERRORCD                                                  " + Constants.vbCr;
                SQL += " ,ERROR                                                    " + Constants.vbCr;
                SQL += ")                                                          " + Constants.vbCr;
                SQL += "SELECT                                                     " + Constants.vbCr;
                SQL += "  WK.GYONO                                                 " + Constants.vbCr;
                SQL += " ,'" + item + "'                                           " + Constants.vbCr;
                SQL += " ,'3'                                                      " + Constants.vbCr;
                SQL += " ,CF.CD                                                    " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')             " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                                " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                                       " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                                   " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                                  " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00011'                                " + Constants.vbCr;
                SQL += "WHERE ISNUMERIC(WK.[" + item + "]) = 1                     " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL                        " + Constants.vbCr;
                SQL += "  AND (" + minValue + " > CONVERT(REAL, WK.[" + item + "]) " + Constants.vbCr;
                SQL += "   OR " + maxValue + " < CONVERT(REAL, WK.[" + item + "])) " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 月齢の範囲チェックを行い、範囲外の場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckGetukbnRange(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string itemBymd = "";
            string itemYmd = "";
            string getukbn = entity.SYORICD.Substring(4, 2);
            string kbn1;
            string kbn2;
            string kbn3;
            string dateIntervalType = "";
            string kbn2Str = "";
            string kbn3Str = "";

            SQL = "SELECT  IT.YOSIKICD                  AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD                  AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM                  AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                     AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.SETDATA                   AS  SETDATA       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                           " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                           " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'BYMD'");
            if (dro.Length > 0)
            {
                itemBymd = dro[0]["KOMOKUCD"].ToString();
            }

            dro = dt.Select("FLDNM = 'KENYMD' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                itemYmd = dro[0]["KOMOKUCD"].ToString();
            }

            if (string.IsNullOrEmpty(itemBymd) | string.IsNullOrEmpty(itemYmd))
            {
                return;
            }

            SQL = "SELECT                                        " + Constants.vbCr;
            SQL += "     CF.CD       AS  DATA                    " + Constants.vbCr;
            SQL += "    ,CF.NAIYO    AS  LABEL                   " + Constants.vbCr;
            SQL += "    ,CF.BIKO     AS  BIKO                    " + Constants.vbCr;
            SQL += "    ,CF.KBN1     AS  KBN1                    " + Constants.vbCr;
            SQL += "    ,CF.KBN2     AS  KBN2                    " + Constants.vbCr;
            SQL += "    ,CF.KBN3     AS  KBN3                    " + Constants.vbCr;
            SQL += "FROM dbo.TC_KKCF CF                          " + Constants.vbCr;
            SQL += "     LEFT    JOIN    dbo.TC_KKCFMAIN CM      " + Constants.vbCr;
            SQL += "         ON  CF.MAINCD   =   CM.MAINCD       " + Constants.vbCr;
            SQL += "         AND CF.SUBCD    =   CM.SUBCD        " + Constants.vbCr;
            SQL += "WHERE    CF.MAINCD   =   '04'                " + Constants.vbCr;
            SQL += "     AND CF.SUBCD    =   '558'               " + Constants.vbCr;
            SQL += "     AND CF.NAIYO    =   '" + getukbn + "'   " + Constants.vbCr;
            SQL += "ORDER    BY  CF.CD                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                kbn1 = dt.Rows[rowIndx]["KBN1"].ToString();
                kbn2 = dt.Rows[rowIndx]["KBN2"].ToString();
                kbn3 = dt.Rows[rowIndx]["KBN3"].ToString();

                switch (kbn1 ?? "")
                {
                    case "1":
                        {
                            kbn2Str = kbn2 + "日";
                            kbn3Str = kbn3 + "日";

                            dateIntervalType = "DAY";
                            break;
                        }
                    case "2":
                        {
                            kbn2Str = kbn2 + "週";
                            kbn3Str = kbn3 + "週";

                            dateIntervalType = "WEEK";
                            break;
                        }
                    case "3":
                        {
                            kbn2Str = kbn2 + "か月";
                            kbn3Str = kbn3 + "か月";

                            dateIntervalType = "MONTH";
                            break;
                        }
                    case "4":
                        {
                            kbn2Str = kbn2 + "年";
                            kbn3Str = kbn3 + "年";

                            dateIntervalType = "YEAR";
                            break;
                        }
                }

                SQL = "INSERT INTO " + errTableName + "(                                                 " + Constants.vbCr;
                SQL += "  GYONO                                                                          " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                                                       " + Constants.vbCr;
                SQL += " ,ERRORKBN                                                                       " + Constants.vbCr;
                SQL += " ,ERRORCD                                                                        " + Constants.vbCr;
                SQL += " ,ERROR                                                                          " + Constants.vbCr;
                SQL += ")                                                                                " + Constants.vbCr;
                SQL += "SELECT                                                                           " + Constants.vbCr;
                SQL += "  WK.GYONO                                                                       " + Constants.vbCr;
                SQL += " ,'" + itemYmd + "'                                                              " + Constants.vbCr;
                SQL += " ,'2'                                                                            " + Constants.vbCr;
                SQL += " ,CF.CD                                                                          " + Constants.vbCr;
                SQL += " ,Replace(Replace(CF.NAIYO,'@@@7@@@','" + kbn2Str + "'),'@@@8@@@','" + kbn3Str + "')   " + Constants.vbCr;
                SQL += "FROM (                                                                                 " + Constants.vbCr;
                SQL += "     SELECT  *                                                                         " + Constants.vbCr;
                SQL += "            ,DATEDIFF(" + dateIntervalType + "                                         " + Constants.vbCr;
                SQL += "                         ,(CASE WHEN ISDATE([" + itemBymd + "]) = 1 THEN [" + itemBymd + "] ELSE NULL END)" + Constants.vbCr;
                SQL += "                         ,DATEADD( DAY                                                                                                   " + Constants.vbCr;
                SQL += "                                   ,-DATEPART(DAY,  (CASE WHEN ISDATE([" + itemBymd + "]) = 1 THEN [" + itemBymd + "] ELSE NULL END)) + 1" + Constants.vbCr;
                SQL += "                                   ,(CASE WHEN ISDATE([" + itemYmd + "]) = 1 THEN [" + itemYmd + "] ELSE NULL END))                      " + Constants.vbCr;
                SQL += "                      ) AS DIFF                                                  " + Constants.vbCr;
                SQL += "     FROM " + wktableName + " WK                                                 " + Constants.vbCr;
                SQL += ") WK                                                                             " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                                                             " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                                                         " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                                                        " + Constants.vbCr;
                SQL += "      AND CF.CD    ='04003'                                                      " + Constants.vbCr;
                SQL += "WHERE (" + kbn2 + " > WK.DIFF)                                                   " + Constants.vbCr;
                SQL += "   OR (" + kbn3 + " < WK.DIFF)                                                   " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 入力桁数チェックを行い、範囲外の場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckLength(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string ketasu;

            SQL = "SELECT  IT.YOSIKICD                  AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD                  AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM                  AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN                AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU                AS  DISPKETASU    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                           " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                           " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'      " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                            " & vbCr
            SQL += "  AND IT.DISPKETASU  IS NOT NULL                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();

                ketasu = dt.Rows[rowIndx]["DISPKETASU"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                                                    " + Constants.vbCr;
                SQL += "  GYONO                                                                             " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                                                          " + Constants.vbCr;
                SQL += " ,ERRORKBN                                                                          " + Constants.vbCr;
                SQL += " ,ERRORCD                                                                           " + Constants.vbCr;
                SQL += " ,ERROR                                                                             " + Constants.vbCr;
                SQL += ")                                                                                   " + Constants.vbCr;
                SQL += "SELECT                                                                              " + Constants.vbCr;
                SQL += "  WK.GYONO                                                                          " + Constants.vbCr;
                SQL += " ,'" + item + "'                                                                    " + Constants.vbCr;
                SQL += " ,'3'                                                                               " + Constants.vbCr;
                SQL += " ,CF.CD                                                                             " + Constants.vbCr;
                SQL += " ,Replace(Replace(CF.NAIYO,'@@@6@@@','" + ketasu + "'), '@@@1@@@','" + itemNm + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                                                         " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                                                                " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                                                            " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                                                           " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00013'                                                         " + Constants.vbCr;
                SQL += "WHERE LEN(WK.[" + item + "]) > " + ketasu + "                                       " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// コード項目の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeCode(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;
            string maincd;
            string subcd;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND IT.DISPTYPEKBN = '003'                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00003'                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF C                               " + Constants.vbCr;
                SQL += "       ON C.MAINCD = '" + maincd + "'             " + Constants.vbCr;
                SQL += "      AND C.SUBCD  = '" + subcd + "'              " + Constants.vbCr;
                SQL += "      AND C.CD     = WK.[" + item + "]            " + Constants.vbCr;
                SQL += "WHERE C.CD IS NULL                                " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 項目のデータ型チェックを行い、日付型でない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeDate(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND IT.DISPTYPEKBN = '002'                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00004'                       " + Constants.vbCr;
                SQL += "WHERE ISDATE(WK.[" + item + "]) = 0               " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 機関コード項目の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeKikan(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;
            string disptypekbn;
            string sessyukbn = entity.SYORICD.Substring(2, 3);
            string filtercd = getYSStaffKikanFiltercd(sessyukbn);
            string subcd = "";
            string cd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND LEFT(IT.DISPTYPEKBN, 1)  = '1'              " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();
                disptypekbn = dt.Rows[rowIndx]["DISPTYPEKBN"].ToString();
                subcd = dt.Rows[rowIndx]["CFMAINCD"].ToString();

                if (Strings.Left(entity.SYORICD, 2) == "03")
                {
                    cd = filtercd;
                }
                else
                {
                    cd = dt.Rows[rowIndx]["CFSUBCD"].ToString();
                }

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(Replace(CF.NAIYO,                       " + Constants.vbCr;
                SQL += "  '@@@2@@@',WK.[" + item + "]), '@@@1@@@','" + itemNm + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00005'                       " + Constants.vbCr;

                if (disptypekbn == "101")
                {
                    // 標準機関コード
                    SQL += "LEFT JOIN TC_KKKIKAN KI                       " + Constants.vbCr;
                    SQL += "      ON KI.KHKIKANCD = WK.[" + item + "]     " + Constants.vbCr;
                }
                else
                {
                    SQL += "LEFT JOIN TC_KKKIKAN KI                       " + Constants.vbCr;
                    SQL += "      ON KI.KIKANCD = WK.[" + item + "]       " + Constants.vbCr;
                }

                SQL += "LEFT   JOIN    TC_KKKIKAN_SUB  KS                 " + Constants.vbCr;
                SQL += "        ON  KI.KIKANCD  =   KS.KIKANCD            " + Constants.vbCr;
                if (!string.IsNullOrEmpty(subcd))
                {
                    SQL += "  AND KS.SUBCD   =   '" + subcd + "'          " + Constants.vbCr;
                }
                if (!string.IsNullOrEmpty(cd))
                {
                    SQL += "  AND KS.CD      =   '" + cd + "'             " + Constants.vbCr;
                }
                SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
                SQL += "  AND KS.KIKANCD IS NULL                          " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// (予防接種用)スタッフコード項目の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeStaffYS(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;
            string sessyukbn = entity.SYORICD.Substring(2, 3);
            string filtercd = getYSStaffKikanFiltercd(sessyukbn);
            string itemKikancd = "";
            DataRow[] dro;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,LEFT(IT.DISPTYPEKBN, 1)  AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'KIKANCD' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                itemKikancd = dro[0]["SETDATA"].ToString();
            }

            // dro = dt.Select("DISPUPDFLG  = '1' AND DISPTYPEKBN  = '2'")
            dro = dt.Select("DISPTYPEKBN  = '2'");

            if (dro.Length == 0)
            {
                return;
            }

            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dro[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dro[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dro[rowIndx]["TYPECHKKBN"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                        " + Constants.vbCr;
                SQL += "  GYONO                                                 " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                              " + Constants.vbCr;
                SQL += " ,ERRORKBN                                              " + Constants.vbCr;
                SQL += " ,ERRORCD                                               " + Constants.vbCr;
                SQL += " ,ERROR                                                 " + Constants.vbCr;
                SQL += ")                                                       " + Constants.vbCr;
                SQL += "SELECT                                                  " + Constants.vbCr;
                SQL += "  WK.GYONO                                              " + Constants.vbCr;
                SQL += " ,'" + item + "'                                        " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                                  " + Constants.vbCr;
                SQL += " ,CF.CD                                                 " + Constants.vbCr;
                SQL += " ,Replace(Replace(CF.NAIYO,                             " + Constants.vbCr;
                SQL += "  '@@@2@@@',WK.[" + item + "]), '@@@1@@@','" + itemNm + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                             " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                                    " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                                " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                               " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00006'                             " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKSTAFF ST                                 " + Constants.vbCr;
                SQL += "      ON ST.STAFFCD = WK.[" + item + "]                 " + Constants.vbCr;
                SQL += "WHERE WK.[" + item + "] IS NOT NULL                     " + Constants.vbCr;
                SQL += "AND NOT EXISTS(                                         " + Constants.vbCr;
                SQL += "			SELECT *                                    " + Constants.vbCr;
                SQL += "			FROM TC_KKSTAFF CK                          " + Constants.vbCr;
                SQL += "			INNER JOIN dbo.TC_KKSTAFF_SUB  SK           " + Constants.vbCr;
                SQL += "					ON CK.STAFFCD = SK.STAFFCD          " + Constants.vbCr;
                SQL += "			INNER JOIN dbo.TC_KKCF C1                   " + Constants.vbCr;
                SQL += "					ON C1.MAINCD = '03'                 " + Constants.vbCr;
                SQL += "				   AND C1.SUBCD  = '002'                " + Constants.vbCr;
                SQL += "				   AND SK.CD     =  C1.CD               " + Constants.vbCr;
                SQL += "			WHERE CK.SYOKUSYU1 =  '01'                  " + Constants.vbCr;
                SQL += "			  AND SK.SUBCD     =  '02'                  " + Constants.vbCr;
                SQL += "			  AND SK.CD        = '" + filtercd + "'     " + Constants.vbCr;
                if (!string.IsNullOrEmpty(itemKikancd))
                {
                    SQL += "			  AND ((CK.KIKANCD  = " + itemKikancd + "" + Constants.vbCr;
                    SQL += "			   OR  CK.KIKANCD  IS NULL)             " + Constants.vbCr;
                    SQL += "			   OR  " + itemKikancd + " IS NULL)      " + Constants.vbCr;
                }
                SQL += "			  AND CK.STAFFCD   = WK.[" + item + "]      " + Constants.vbCr;
                SQL += "		    )                                           " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// スタッフコード項目の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDataTypeStaff(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            // SQL += "  AND IT.DISPUPDFLG  = '1'                        " & vbCr
            SQL += "  AND LEFT(IT.DISPTYPEKBN, 1)  = '2'              " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(Replace(CF.NAIYO,                             " + Constants.vbCr;
                SQL += "  '@@@2@@@',WK.[" + item + "]), '@@@1@@@','" + itemNm + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00006'                       " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKSTAFF ST                           " + Constants.vbCr;
                SQL += "      ON ST.STAFFCD = WK.[" + item + "]           " + Constants.vbCr;
                SQL += "WHERE ST.STAFFCD IS NULL                          " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 個人番号の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckNotExistKojinno(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            string typechkkbn;
            string maincd;
            string subcd;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            SQL += "  AND IT.DISPTYPEKBN = '051'                      " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                item = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                itemNm = dt.Rows[rowIndx]["KOMOKUNM"].ToString();
                typechkkbn = dt.Rows[rowIndx]["TYPECHKKBN"].ToString();
                maincd = dt.Rows[rowIndx]["CFMAINCD"].ToString();
                subcd = dt.Rows[rowIndx]["CFSUBCD"].ToString();

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT                                            " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + item + "'                                  " + Constants.vbCr;
                SQL += " ,'" + typechkkbn + "'                            " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN KO                           " + Constants.vbCr;
                SQL += "       ON KO.KOJINNO = WK.[" + item + "]          " + Constants.vbCr;
                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00007'                       " + Constants.vbCr;
                SQL += "WHERE KO.KOJINNO IS NULL                          " + Constants.vbCr;
                SQL += "  AND WK.[" + item + "] IS NOT NULL               " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 交付番号と新規交付区分のチェックを行う。
        /// 新規交付区分の番号範囲に交付番号が含まれない場合はエラーとする。
        ///
        /// 例）1:新規交付 10001～20000
        /// 　　新規交付区分が1で交付番号が20001の場合はエラー
        ///
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckBkofunoAndKofukbn(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;

            DataRow[] dro;
            string itemBkofuno = "";
            string itemSinki = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'BKOFUNO'");
            if (dro.Length > 0)
            {
                itemBkofuno = dro[0]["KOMOKUCD"].ToString();
            }

            dro = dt.Select("FLDNM = 'HESINKI'");
            if (dro.Length > 0)
            {
                itemSinki = dro[0]["KOMOKUCD"].ToString();
            }

            if (string.IsNullOrEmpty(itemBkofuno) | string.IsNullOrEmpty(itemSinki))
            {
                return;
            }

            SQL = "INSERT INTO " + errTableName + "(                    " + Constants.vbCr;
            SQL += "  GYONO                                             " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                          " + Constants.vbCr;
            SQL += " ,ERRORKBN                                          " + Constants.vbCr;
            SQL += " ,ERRORCD                                           " + Constants.vbCr;
            SQL += " ,ERROR                                             " + Constants.vbCr;
            SQL += ")                                                   " + Constants.vbCr;
            SQL += "SELECT DISTINCT                                     " + Constants.vbCr;
            SQL += "  WK.GYONO                                          " + Constants.vbCr;
            SQL += " ,'" + itemBkofuno + "'                             " + Constants.vbCr;
            SQL += " ,'3'                                               " + Constants.vbCr;
            SQL += " ,CF.CD                                             " + Constants.vbCr;
            SQL += " ,CF.NAIYO                                          " + Constants.vbCr;
            SQL += "FROM " + wktableName + " WK                         " + Constants.vbCr;
            SQL += "LEFT JOIN TC_KKCF CF                                " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                            " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                           " + Constants.vbCr;
            SQL += "      AND CF.CD    ='04005'                         " + Constants.vbCr;
            SQL += "WHERE (                                             " + Constants.vbCr;
            SQL += "        SELECT ISNULL(CONVERT(INT,MAX(KBN1)), 99999) AS KBN      " + Constants.vbCr;
            SQL += "        FROM  TC_KKCF CF                            " + Constants.vbCr;
            SQL += "        WHERE CF.MAINCD='04'                        " + Constants.vbCr;
            SQL += "          AND CF.SUBCD ='039'                       " + Constants.vbCr;
            SQL += "          AND CF.CD    =WK.[" + itemSinki + "]      " + Constants.vbCr;
            SQL += "      ) > ISNULL(CONVERT(INT,WK.[" + itemBkofuno + "]),0)        " + Constants.vbCr;
            SQL += "   OR                                               " + Constants.vbCr;
            SQL += "      (                                             " + Constants.vbCr;
            SQL += "        SELECT ISNULL(CONVERT(INT,MAX(KBN1)), 99999) AS KBN      " + Constants.vbCr;
            SQL += "        FROM  TC_KKCF CF                            " + Constants.vbCr;
            SQL += "        WHERE CF.MAINCD='04'                        " + Constants.vbCr;
            SQL += "          AND CF.SUBCD ='039'                       " + Constants.vbCr;
            SQL += "          AND CF.CD    =WK.[" + itemSinki + "] +1   " + Constants.vbCr;
            SQL += "    ) <= ISNULL(CONVERT(INT,WK.[" + itemBkofuno + "]),0)         " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 母子手帳交付番号の存在チェックを行い、存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckNotExistBkofuno(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;

            DataRow[] dro;
            string itemBnendo = "";
            string itemBkofuno = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'BNENDO'");
            if (dro.Length > 0)
            {
                itemBnendo = dro[0]["KOMOKUCD"].ToString();
            }

            dro = dt.Select("FLDNM = 'BKOFUNO'");
            if (dro.Length > 0)
            {
                itemBkofuno = dro[0]["KOMOKUCD"].ToString();
            }

            if (string.IsNullOrEmpty(itemBnendo) | string.IsNullOrEmpty(itemBkofuno))
            {
                return;
            }

            SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
            SQL += "  GYONO                                           " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
            SQL += " ,ERRORKBN                                        " + Constants.vbCr;
            SQL += " ,ERRORCD                                         " + Constants.vbCr;
            SQL += " ,ERROR                                           " + Constants.vbCr;
            SQL += ")                                                 " + Constants.vbCr;
            SQL += "SELECT DISTINCT                                   " + Constants.vbCr;
            SQL += "  WK.GYONO                                        " + Constants.vbCr;
            SQL += " ,'" + itemBnendo + "'                            " + Constants.vbCr;
            SQL += " ,'3'                                             " + Constants.vbCr;
            SQL += " ,CF.CD                                           " + Constants.vbCr;
            SQL += " ,CF.NAIYO                                        " + Constants.vbCr;
            SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
            SQL += "LEFT JOIN TM_BHNSHAKKO HK                         " + Constants.vbCr;
            SQL += "       ON HK.BNENDO  = WK.[" + itemBnendo + "]    " + Constants.vbCr;
            SQL += "      AND HK.BKOFUNO = WK.[" + itemBkofuno + "]   " + Constants.vbCr;
            SQL += "      AND HK.EDANO   = 1                          " + Constants.vbCr;
            SQL += "      AND HK.DELFLG  = 0                          " + Constants.vbCr;
            SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
            SQL += "      AND CF.CD    ='04006'                       " + Constants.vbCr;
            SQL += "WHERE HK.BNENDO IS NULL                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 妊産婦健診の入力済チェックを行い、入力済の場合は警告を返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckFinishInputNinken(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item = "";
            string itemNm = "";
            string typechkkbn = "";
            string SQL_Join = "";
            string SQL_Set = "";
            string[] itemLs;
            DataRow[] dro;
            string itemYmd = "";
            string itemYmdFld = "";

            string tableName = "TM_BHNSNINKEN";

            itemLs = null;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
            SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                // チェック処理を行わない
                return;
            }

            dro = dt.Select("FLDNM = 'JUSINYMD'");
            if (dro.Length > 0)
            {
                itemYmd = dro[0]["KOMOKUCD"].ToString();
                itemYmdFld = dro[0]["FLDNM"].ToString();
            }

            if (string.IsNullOrEmpty(itemYmd))
            {
                return;
            }

            dro = dt.Select("FLDKEYFLG = '1'");

            itemLs = new string[dro.Length + 1];

            SQL_Join = "";
            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                itemLs[rowIndx] = dro[rowIndx]["KOMOKUCD"].ToString();

                if (string.IsNullOrEmpty(SQL_Join))
                {
                    SQL_Join += "  ON ";
                }
                else
                {
                    SQL_Join += " AND ";
                }

                SQL_Join += "  K.[" + dro[rowIndx]["FLDNM"].ToString() + "] = ";
                SQL_Join += "  " + dro[rowIndx]["SETDATA"].ToString() + " " + Constants.vbCr;
            }

            itemLs[itemLs.Length - 1] = itemYmd;

            SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
            SQL += "  GYONO                                           " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
            SQL += " ,ERRORKBN                                        " + Constants.vbCr;
            SQL += " ,ERRORCD                                         " + Constants.vbCr;
            SQL += " ,ERROR                                           " + Constants.vbCr;
            SQL += ")                                                 " + Constants.vbCr;
            SQL += "SELECT DISTINCT                                   " + Constants.vbCr;
            SQL += "  WK.GYONO                                        " + Constants.vbCr;
            SQL += " ,'" + Strings.Join(itemLs, ",") + "'                     " + Constants.vbCr;
            SQL += " ,'2'                                             " + Constants.vbCr;
            SQL += " ,CF.CD                                           " + Constants.vbCr;
            SQL += " ,Replace(CF.NAIYO,'@@@3@@@','" + tableName + "') " + Constants.vbCr;
            SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
            SQL += "LEFT JOIN " + tableName + " K                     " + Constants.vbCr;
            SQL += SQL_Join;
            SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
            SQL += "      AND CF.CD    ='04002'                       " + Constants.vbCr;
            SQL += "WHERE K.BNENDO IS NOT NULL                        " + Constants.vbCr;
            SQL += "AND   K.[" + itemYmdFld + "] IS NOT NULL          " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// レコードの存在チェックを行い、既に存在しない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckNotExistRecord(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item = "";
            string itemNm = "";
            string typechkkbn = "";
            ArrayList tableList;
            string SQL_Join = "";
            string SQL_Set = "";
            string[] itemLs;

            itemLs = null;

            tableList = getTargetTable(conn, wktableName, entity, htParam, wkTrn);

            foreach (string tableName in tableList)
            {
                SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
                SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
                SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
                SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
                SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
                SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
                SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
                SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
                SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
                SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
                SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
                SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
                SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
                SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
                SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
                SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
                SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
                SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
                SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
                SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
                SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
                SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
                SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
                SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
                SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
                SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;
                SQL += "  AND IT.FLDKEYFLG   = '1'                        " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    // チェック処理を行わない
                    continue;
                }

                itemLs = new string[dt.Rows.Count];

                SQL_Join = "";
                for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
                {
                    itemLs[rowIndx] = dt.Rows[rowIndx]["KOMOKUCD"].ToString();

                    if (string.IsNullOrEmpty(SQL_Join))
                    {
                        SQL_Join += "  ON ";
                    }
                    else
                    {
                        SQL_Join += " AND ";
                    }

                    SQL_Join += "  K.[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "] = " + Constants.vbCr;
                    SQL_Join += "  " + dt.Rows[rowIndx]["SETDATA"].ToString() + " " + Constants.vbCr;
                }

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT DISTINCT                                   " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + Strings.Join(itemLs, ",") + "'                     " + Constants.vbCr;
                SQL += " ,'3'                                             " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@3@@@','" + tableName + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN " + tableName + " K                     " + Constants.vbCr;
                SQL += SQL_Join;

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
                {
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(" AND K.NENDO = ", htParam["snendo"]), Constants.vbCr));
                }

                // 接種区分を取得（取込処理（予防接種）以外の場合は空）
                string sessyukbn = getSessyukbn(entity.SYORICD, dt);
                if (!string.IsNullOrEmpty(sessyukbn))
                {
                    SQL += " AND K.SESSYUKBN = '" + sessyukbn + "'" + Constants.vbCr;
                }

                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00009'                       " + Constants.vbCr;

                if (Strings.Left(entity.SYORICD, 4) == "0401")
                {
                    // 妊産婦情報
                    SQL += "WHERE K.BNENDO IS NULL                        " + Constants.vbCr;
                }
                else
                {
                    // その他
                    SQL += "WHERE K.KOJINNO IS NULL                       " + Constants.vbCr;
                }

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 生年月日と対象年月日の大小チェックを行い、生年月日より大きい場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckBymdAndTargetymd(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, string TargetYmd, SqlTransaction wkTrn)

        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            DataRow[] dro;
            string itemBymd = "";
            string itemYmd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'BYMD'");
            if (dro.Length > 0)
            {
                itemBymd = dro[0]["KOMOKUCD"].ToString();
            }

            dro = dt.Select("FLDNM = '" + TargetYmd + "' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                itemYmd = dro[0]["KOMOKUCD"].ToString();
            }

            if (string.IsNullOrEmpty(itemBymd) | string.IsNullOrEmpty(itemYmd))
            {
                return;
            }

            item = dro[0]["KOMOKUCD"].ToString();
            itemNm = dro[0]["KOMOKUNM"].ToString();

            SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
            SQL += "  GYONO                                           " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
            SQL += " ,ERRORKBN                                        " + Constants.vbCr;
            SQL += " ,ERRORCD                                         " + Constants.vbCr;
            SQL += " ,ERROR                                           " + Constants.vbCr;
            SQL += ")                                                 " + Constants.vbCr;
            SQL += "SELECT                                            " + Constants.vbCr;
            SQL += "  WK.GYONO                                        " + Constants.vbCr;
            SQL += " ,'" + item + "'                                  " + Constants.vbCr;
            SQL += " ,'3'                                             " + Constants.vbCr;
            SQL += " ,CF.CD                                           " + Constants.vbCr;
            SQL += " ,Replace(Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "'),'@@@2@@@', dbo.CHG_WAREKI(0,WK.[" + itemYmd + "CN]))" + Constants.vbCr;
            SQL += "FROM (                                            " + Constants.vbCr;
            SQL += "      SELECT  *                                   " + Constants.vbCr;
            SQL += "             ,(CASE WHEN ISDATE([" + itemBymd + "]) = 1 THEN [" + itemBymd + "] ELSE NULL END) AS [" + itemBymd + "CN] " + Constants.vbCr;
            SQL += "             ,(CASE WHEN ISDATE([" + itemYmd + "]) = 1 THEN [" + itemYmd + "] ELSE NULL END) AS [" + itemYmd + "CN] " + Constants.vbCr;
            SQL += "      FROM " + wktableName + "                    " + Constants.vbCr;
            SQL += "      )WK                                         " + Constants.vbCr;
            SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
            SQL += "      AND CF.CD    ='00012'                       " + Constants.vbCr;
            SQL += "WHERE (CONVERT(DATETIME, WK.[" + itemBymd + "CN]) " + Constants.vbCr;
            SQL += "  >= CONVERT(DATETIME, WK.[" + itemYmd + "CN]))   " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 生後月数チェックを行い、100ヶ月以上の場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckSeigoTukisu(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item;
            string itemNm;
            DataRow[] dro;
            string itemBymd = "";
            string itemYmd = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM = 'BYMD'");
            if (dro.Length > 0)
            {
                itemBymd = dro[0]["KOMOKUCD"].ToString();
            }

            dro = dt.Select("FLDNM = 'KENYMD' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                itemYmd = dro[0]["KOMOKUCD"].ToString();
            }

            if (string.IsNullOrEmpty(itemBymd) | string.IsNullOrEmpty(itemYmd))
            {
                return;
            }

            item = dro[0]["KOMOKUCD"].ToString();
            itemNm = dro[0]["KOMOKUNM"].ToString();

            SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
            SQL += "  GYONO                                           " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
            SQL += " ,ERRORKBN                                        " + Constants.vbCr;
            SQL += " ,ERRORCD                                         " + Constants.vbCr;
            SQL += " ,ERROR                                           " + Constants.vbCr;
            SQL += ")                                                 " + Constants.vbCr;
            SQL += "SELECT                                            " + Constants.vbCr;
            SQL += "  WK.GYONO                                        " + Constants.vbCr;
            SQL += " ,'" + item + "'                                  " + Constants.vbCr;
            SQL += " ,'3'                                             " + Constants.vbCr;
            SQL += " ,CF.CD                                           " + Constants.vbCr;
            SQL += " ,Replace(CF.NAIYO,'@@@1@@@','" + itemNm + "')    " + Constants.vbCr;
            SQL += "FROM (                                            " + Constants.vbCr;
            SQL += "      SELECT  *                                   " + Constants.vbCr;
            SQL += "             ,(CASE WHEN ISDATE([" + itemBymd + "]) = 1 THEN [" + itemBymd + "] ELSE NULL END) AS [" + itemBymd + "CN] " + Constants.vbCr;
            SQL += "             ,(CASE WHEN ISDATE([" + itemYmd + "]) = 1 THEN [" + itemYmd + "] ELSE NULL END) AS [" + itemYmd + "CN] " + Constants.vbCr;
            SQL += "      FROM " + wktableName + "                    " + Constants.vbCr;
            SQL += "      )WK                                         " + Constants.vbCr;
            SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
            SQL += "      AND CF.CD    ='04001'                       " + Constants.vbCr;
            SQL += "WHERE DATEDIFF(MONTH,  WK.[" + itemBymd + "CN]   " + Constants.vbCr;
            SQL += "              ,DATEADD(DAY,-DATEPART(DAY,  WK.[" + itemBymd + "CN])+1, WK.[" + itemYmd + "CN])) >= 100     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Hib＆小児用肺炎球菌接種回数チェックを行い、適切な接種回でない場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckSessyuKaisu(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item = "";
            string itemNm = "";
            string typechkkbn = "";
            string SQL_Join = "";
            string SQL_Set = "";
            string[] itemLs;
            string houhou = "";
            string kaisu = "";
            string errkbn = "3";
            string syubetu = Strings.Left(entity.SYORICD, 4);
            string SQL_MSG = "";
            string SQL_WHERE = "";
            string SQL_MSGCD = "";

            itemLs = null;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                // チェック処理を行わない
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(CM_kyotu_proc.TOWNCD_TOSK, htParam["towncd"], false)))
            {
                houhou = "WK.[013]";
                kaisu = "WK.[020]";
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(CM_kyotu_proc.TOWNCD_OMTK, htParam["towncd"], false)))
            {
                houhou = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("WK.[", dt.Select("KOMOKUNM='開始年齢区分'")[0]["KOMOKUCD"]), "]"));
                kaisu = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("WK.[", dt.Select("KOMOKUNM='接種数'")[0]["KOMOKUCD"]), "]"));

                errkbn = "2";
            }

            if (syubetu == "0320")
            {
                // Hibの場合
                // 出力メッセージ
                SQL_MSG += "CASE WHEN " + houhou + " = '2' AND " + kaisu + " = '3' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '３'), '@@@5@@@','3') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '3' AND " + kaisu + " = '1' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','1') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '3' AND " + kaisu + " = '2' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','2') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '3' AND " + kaisu + " = '3' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','3') " + Constants.vbCr;
                SQL_MSG += "END" + Constants.vbCr;

                // 抽出条件
                SQL_WHERE += " AND(                                                     " + Constants.vbCr;
                SQL_WHERE += "        (" + houhou + " = '2' AND " + kaisu + " = '3')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '3' AND " + kaisu + " = '1')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '3' AND " + kaisu + " = '2')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '3' AND " + kaisu + " = '3')    " + Constants.vbCr;
                SQL_WHERE += "    )     " + Constants.vbCr;

                // メッセージコード
                SQL_MSGCD = "03001";
            }
            else if (syubetu == "0321")
            {
                // 小児用肺炎球菌の場合
                // 出力メッセージ
                SQL_MSG += "CASE WHEN " + houhou + " = '2' AND " + kaisu + " = '3' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '３'), '@@@5@@@','3') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '3' AND " + kaisu + " = '2' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '２'), '@@@5@@@','2') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '3' AND " + kaisu + " = '3' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '２'), '@@@5@@@','3') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '4' AND " + kaisu + " = '1' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','1') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '4' AND " + kaisu + " = '2' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','2') " + Constants.vbCr;
                SQL_MSG += "     WHEN " + houhou + " = '4' AND " + kaisu + " = '3' THEN         " + Constants.vbCr;
                SQL_MSG += "         REPLACE(REPLACE(CF.NAIYO, '@@@4@@@', '１'), '@@@5@@@','3') " + Constants.vbCr;
                SQL_MSG += "END" + Constants.vbCr;

                // 抽出条件
                SQL_WHERE += " AND(                                                     " + Constants.vbCr;
                SQL_WHERE += "        (" + houhou + " = '2' AND " + kaisu + " = '3')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '3' AND " + kaisu + " = '2')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '3' AND " + kaisu + " = '3')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '4' AND " + kaisu + " = '1')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '4' AND " + kaisu + " = '2')    " + Constants.vbCr;
                SQL_WHERE += "      OR(" + houhou + " = '4' AND " + kaisu + " = '3')    " + Constants.vbCr;
                SQL_WHERE += "    )     " + Constants.vbCr;

                // メッセージコード
                SQL_MSGCD = "03002";
            }

            SQL = "INSERT INTO " + errTableName + "(                              " + Constants.vbCr;
            SQL += "  GYONO                                                       " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                                    " + Constants.vbCr;
            SQL += " ,ERRORKBN                                                    " + Constants.vbCr;
            SQL += " ,ERRORCD                                                     " + Constants.vbCr;
            SQL += " ,ERROR                                                       " + Constants.vbCr;
            SQL += ")                                                             " + Constants.vbCr;
            SQL += "SELECT DISTINCT                                               " + Constants.vbCr;
            SQL += "  WK.GYONO                                                    " + Constants.vbCr;
            SQL += " ,'" + Strings.Join(itemLs, ",") + "'                                 " + Constants.vbCr;
            SQL += " ,'" + errkbn + "'                                            " + Constants.vbCr;
            SQL += " ,CF.CD                                                       " + Constants.vbCr;
            SQL += " ," + SQL_MSG + "                                             " + Constants.vbCr;
            SQL += "FROM " + wktableName + " WK                                   " + Constants.vbCr;
            SQL += "LEFT JOIN TC_KKCF CF                                          " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                                      " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                                     " + Constants.vbCr;
            SQL += "      AND CF.CD    ='" + SQL_MSGCD + "'                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                                   " + Constants.vbCr;
            SQL += SQL_WHERE;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// レコードの存在チェックを行い、既に存在する場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckExistRecord(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string item = "";
            string itemNm = "";
            string typechkkbn = "";
            ArrayList tableList;
            string SQL_Join = "";
            string SQL_Set = "";
            string[] itemLs;

            itemLs = null;

            tableList = getTargetTable(conn, wktableName, entity, htParam, wkTrn);

            foreach (string tableName in tableList)
            {
                SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
                SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
                SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
                SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
                SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
                SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
                SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
                SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
                SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
                SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
                SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
                SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
                SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
                SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
                SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
                SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
                SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
                SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
                SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
                SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
                SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
                SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
                SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
                SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
                SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
                SQL += "  AND IT.YOSIKICD = '" + entity.YOSIKICD + "'     " + Constants.vbCr;
                SQL += "  AND IT.TBLNM    = '" + tableName + "'           " + Constants.vbCr;
                SQL += "  AND IT.FLDKEYFLG   = '1'                        " + Constants.vbCr;

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    // チェック処理を行わない
                    continue;
                }

                itemLs = new string[dt.Rows.Count];

                SQL_Join = "";
                for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
                {
                    itemLs[rowIndx] = dt.Rows[rowIndx]["KOMOKUCD"].ToString();

                    if (string.IsNullOrEmpty(SQL_Join))
                    {
                        SQL_Join += "  ON ";
                    }
                    else
                    {
                        SQL_Join += " AND ";
                    }

                    SQL_Join += "  K.[" + dt.Rows[rowIndx]["FLDNM"].ToString() + "] = ";
                    SQL_Join += "  " + dt.Rows[rowIndx]["SETDATA"].ToString() + " " + Constants.vbCr;
                }

                SQL = "INSERT INTO " + errTableName + "(                  " + Constants.vbCr;
                SQL += "  GYONO                                           " + Constants.vbCr;
                SQL += " ,KOMOKUCD                                        " + Constants.vbCr;
                SQL += " ,ERRORKBN                                        " + Constants.vbCr;
                SQL += " ,ERRORCD                                         " + Constants.vbCr;
                SQL += " ,ERROR                                           " + Constants.vbCr;
                SQL += ")                                                 " + Constants.vbCr;
                SQL += "SELECT DISTINCT                                   " + Constants.vbCr;
                SQL += "  WK.GYONO                                        " + Constants.vbCr;
                SQL += " ,'" + Strings.Join(itemLs, ",") + "'                     " + Constants.vbCr;
                SQL += " ,'3'                                             " + Constants.vbCr;
                SQL += " ,CF.CD                                           " + Constants.vbCr;
                SQL += " ,Replace(CF.NAIYO,'@@@3@@@','" + tableName + "') " + Constants.vbCr;
                SQL += "FROM " + wktableName + " WK                       " + Constants.vbCr;
                SQL += "LEFT JOIN " + tableName + " K                     " + Constants.vbCr;
                SQL += SQL_Join;

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(htParam["snendo"], "", false)))
                {
                    SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(" AND K.NENDO = ", htParam["snendo"]), Constants.vbCr));
                }

                // 接種区分を取得（取込処理（予防接種）以外の場合は空）
                string sessyukbn = getSessyukbn(entity.SYORICD, dt);
                if (!string.IsNullOrEmpty(sessyukbn))
                {
                    SQL += " AND K.SESSYUKBN = '" + sessyukbn + "'" + Constants.vbCr;
                }

                SQL += "LEFT JOIN TC_KKCF CF                              " + Constants.vbCr;
                SQL += "       ON CF.MAINCD='01'                          " + Constants.vbCr;
                SQL += "      AND CF.SUBCD ='308'                         " + Constants.vbCr;
                SQL += "      AND CF.CD    ='00010'                       " + Constants.vbCr;

                if (Strings.Left(entity.SYORICD, 4) == "0401")
                {
                    // 妊産婦情報
                    SQL += "WHERE K.BNENDO IS NOT NULL                    " + Constants.vbCr;
                }
                else
                {
                    // その他
                    SQL += "WHERE K.KOJINNO IS NOT NULL                   " + Constants.vbCr;
                }

                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 重複したキー項目が存在する場合はエラーを返す。
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wktableName">ワークテーブル名称</param>
        /// <param name="errTableName">エラーテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void CheckDuplication(SqlConnection conn, string wktableName, string errTableName, TC_KKTORIIKKATU_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            string[] itemLs;
            string item = "";
            string SQL_Join = "";
            itemLs = null;

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + entity.YOSIKICD + "'  " + Constants.vbCr;
            SQL += "  AND IT.FLDKEYFLG   = '1'                        " + Constants.vbCr;
            SQL += "  AND IT.DISPVISFLG  = '1'                        " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            itemLs = new string[dt.Rows.Count];
            for (int rowIndx = 0, loopTo = dt.Rows.Count - 1; rowIndx <= loopTo; rowIndx++)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    item += ",";
                }

                itemLs[rowIndx] = dt.Rows[rowIndx]["KOMOKUCD"].ToString();
                item += "WK.[" + dt.Rows[rowIndx]["KOMOKUCD"].ToString() + "]";
            }

            SQL = "INSERT INTO " + errTableName + "(                " + Constants.vbCr;
            SQL += "  GYONO                                         " + Constants.vbCr;
            SQL += " ,KOMOKUCD                                      " + Constants.vbCr;
            SQL += " ,ERRORKBN                                      " + Constants.vbCr;
            SQL += " ,ERRORCD                                       " + Constants.vbCr;
            SQL += " ,ERROR                                         " + Constants.vbCr;
            SQL += ")                                               " + Constants.vbCr;
            SQL += "SELECT                                          " + Constants.vbCr;
            SQL += "  WK.GYONO                                      " + Constants.vbCr;
            SQL += " ,'" + Strings.Join(itemLs, ",") + "'                   " + Constants.vbCr;
            SQL += " ,'3'                                           " + Constants.vbCr;
            SQL += " ,CF.CD                                         " + Constants.vbCr;
            SQL += " ,CF.NAIYO                                      " + Constants.vbCr;
            SQL += "FROM " + wktableName + " WK                     " + Constants.vbCr;
            SQL += "INNER  JOIN(                                    " + Constants.vbCr;
            SQL += "           SELECT " + item + " ,COUNT(*) AS CNT " + Constants.vbCr;
            SQL += "           FROM  " + wktableName + " WK         " + Constants.vbCr;
            SQL += "           GROUP BY " + item + "                " + Constants.vbCr;
            SQL += "           HAVING COUNT(*) > 1                  " + Constants.vbCr;
            SQL += "       ) DP                                     " + Constants.vbCr;
            foreach (string itemstr in itemLs)
            {
                if (string.IsNullOrEmpty(SQL_Join))
                {
                    SQL_Join += "  ON ";
                }
                else
                {
                    SQL_Join += "  AND ";
                }
                SQL_Join += " ISNULL(WK.[" + itemstr + "], '') = ISNULL(DP.[" + itemstr + "],'') " + Constants.vbCr;
            }
            SQL += SQL_Join;
            SQL += "LEFT JOIN TC_KKCF CF                           " + Constants.vbCr;
            SQL += "       ON CF.MAINCD='01'                       " + Constants.vbCr;
            SQL += "      AND CF.SUBCD ='308'                      " + Constants.vbCr;
            SQL += "      AND CF.CD    ='00008'                    " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 一括入力画面コード内容(TC_KKCF用)取得用SQL作成。
        /// </summary>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_KsGetIlist1(string yosikicd)
        {
            string SQL;

            SQL = "SELECT   DISTINCT                            " + Constants.vbCr;
            SQL += "        IT.CFMAINCD AS  MAINCD              " + Constants.vbCr;
            SQL += "       ,IT.CFSUBCD  AS  SUBCD               " + Constants.vbCr;
            SQL += "       ,CF.CD       AS  CD                  " + Constants.vbCr;
            SQL += "       ,CF.NAIYO    AS  NAIYO               " + Constants.vbCr;
            SQL += "FROM    dbo.TC_KKTORIIKKATUITEM   IT        " + Constants.vbCr;
            SQL += "    INNER   JOIN    dbo.TC_KKCF CF          " + Constants.vbCr;
            SQL += "        ON  IT.CFMAINCD   =   CF.MAINCD     " + Constants.vbCr;
            SQL += "        AND IT.CFSUBCD    =   CF.SUBCD      " + Constants.vbCr;
            SQL += "WHERE   IT.YOSIKICD  =   '" + yosikicd + "' " + Constants.vbCr;
            SQL += "    AND IT.DISPTYPEKBN    = '003'           " + Constants.vbCr;
            SQL += "ORDER   BY  IT.CFMAINCD                     " + Constants.vbCr;
            SQL += "           ,IT.CFSUBCD                      " + Constants.vbCr;
            SQL += "           ,CF.CD                           " + Constants.vbCr;

            return SQL;
        }

        /// <summary>
        /// 一括入力画面地区情報内容(TC_KKTIKU用)取得用SQL作成。
        /// </summary>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_KsGetIlist2(string yosikicd)
        {
            string SQL;

            SQL = "SELECT   DISTINCT                             " + Constants.vbCr;
            SQL += "        IT.CFMAINCD AS  MAINCD               " + Constants.vbCr;
            SQL += "       ,CF.CD       AS  CD                   " + Constants.vbCr;
            SQL += "       ,CF.MEISYO   AS  NAIYO                " + Constants.vbCr;
            SQL += "FROM    dbo.TC_KKTORIIKKATUITEM   IT         " + Constants.vbCr;
            SQL += "    INNER   JOIN    dbo.TC_KKTIKU   CF       " + Constants.vbCr;
            SQL += "        ON  IT.CFMAINCD = CF.MAINCD          " + Constants.vbCr;
            SQL += "WHERE   IT.YOSIKICD     = '" + yosikicd + "' " + Constants.vbCr;
            SQL += "  AND   IT.DISPTYPEKBN  = '60'               " + Constants.vbCr;
            SQL += "ORDER   BY  IT.CFMAINCD                      " + Constants.vbCr;
            SQL += "           ,CF.CD                            " + Constants.vbCr;

            return SQL;
        }

        /// <summary>
        /// 一括入力画面施設内容(TC_KKKIKAN用)取得用SQL作成。
        /// </summary>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_KsGetIlist3(string yosikicd)
        {
            string SQL;

            SQL = "SELECT DISTINCT                              " + Constants.vbCr;
            SQL += "        CF.KIKANCD   AS  CD                 " + Constants.vbCr;
            SQL += "       ,CF.KIKANMEI  AS  NAIYO              " + Constants.vbCr;
            SQL += "       ,CF.KHKIKANCD AS  HCD                " + Constants.vbCr;
            SQL += "FROM    dbo.TC_KKKIKAN  CF                  " + Constants.vbCr;
            SQL += "    INNER  JOIN    TC_KKKIKAN_SUB  KS       " + Constants.vbCr;
            SQL += "       ON  CF.KIKANCD  =   KS.KIKANCD       " + Constants.vbCr;
            // SQL += "    INNER  JOIN    TC_KKTORIIKKATUITEM  IT  " & vbCr
            // SQL += "       ON  IT.CFMAINCD =   KS.SUBCD         " & vbCr
            // SQL += "      AND  IT.CFSUBCD  =   KS.CD            " & vbCr
            // SQL += "      AND  LEFT(IT.DISPTYPEKBN, 1) =  '1'   " & vbCr
            SQL += "ORDER   BY  CF.KIKANCD                      " + Constants.vbCr;

            return SQL;
        }

        /// <summary>
        /// 一括入力画面スタッフ内容(TC_KKSTAFF用)取得用SQL作成。
        /// </summary>
        /// <param name="yosikicd">様式コード</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_KsGetIlist4(string yosikicd)
        {
            string SQL;

            SQL = "SELECT  DISTINCT                             " + Constants.vbCr;
            SQL += "        CF.STAFFCD  AS  CD                  " + Constants.vbCr;
            SQL += "       ,CF.NAME     AS  NAIYO               " + Constants.vbCr;
            SQL += "FROM    dbo.TC_KKSTAFF  CF                  " + Constants.vbCr;
            SQL += "    INNER JOIN TC_KKSTAFF_SUB  KS           " + Constants.vbCr;
            SQL += "        ON  CF.STAFFCD  =   KS.STAFFCD      " + Constants.vbCr;
            // SQL += "    INNER  JOIN    TC_KKTORIIKKATUITEM  IT  " & vbCr
            // SQL += "       ON  IT.CFMAINCD =   KS.SUBCD         " & vbCr
            // SQL += "      AND  IT.CFSUBCD  =   KS.CD            " & vbCr
            // SQL += "      AND  LEFT(IT.DISPTYPEKBN, 1) =  '2'   " & vbCr
            SQL += "ORDER   BY  CF.STAFFCD          " + Constants.vbCr;

            return SQL;
        }

        private string createSQL_WkTableDataOnCondition(string syoricd, string wkTableName, string ConditionItem, string ConditionValue)
        {
            string SQL;

            SQL = "  SELECT *                                                " + Constants.vbCr;
            SQL += " FROM " + wkTableName + " WK                             " + Constants.vbCr;
            SQL += " WHERE 1 = 1                                             " + Constants.vbCr;
            SQL += "   AND " + ConditionItem + " = '" + ConditionValue + "'  " + Constants.vbCr;

            return SQL;
        }

        /// <summary>
        /// 取込処理　(TOSK)予防接種取込ファイルから取込対象のデータを抽出
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private string createSQL_WkTableDataFromYobouFileTOSK(string syoricd, string wkTableName)
        {
            string SQL;
            string sessyukbn = syoricd.Substring(2, 2);
            string sessyukai = syoricd.Substring(4, 1);

            // 接種回数変換
            if (sessyukbn == "02")
            {
                // 二種混合(2期)
                sessyukai = "";
            }
            else if (sessyukbn == "04")
            {
                // ＭＲ(1期)
                sessyukbn = "04";
                sessyukai = "1";
            }
            else if (sessyukbn == "05")
            {
                // ＭＲ(2期)
                sessyukbn = "04";
                sessyukai = "2";
            }
            else if (sessyukbn == "08")
            {
                // 麻しん(1期)
                sessyukbn = "08";
                sessyukai = "1";
            }
            else if (sessyukbn == "09")
            {
                // 麻しん(2期)
                sessyukbn = "08";
                sessyukai = "2";
            }
            else if (sessyukbn == "12")
            {
                // 風しん(1期)
                sessyukbn = "12";
                sessyukai = "1";
            }
            else if (sessyukbn == "13")
            {
                // 風しん(2期)
                sessyukbn = "12";
                sessyukai = "2";
            }
            else if (sessyukbn == "16" & sessyukai == "6")
            {
                // 日本脳炎(1期初回追加):6⇒3
                sessyukai = "3";
            }
            else if (sessyukbn == "17")
            {
                // 日本脳炎(2期)
                sessyukbn = "16";
                sessyukai = "4";
            }
            else if (sessyukbn == "19")
            {
                // ＢＣＧ
                sessyukai = "";
            }
            else if (sessyukai == "6")
            {
                // 追加:6⇒4
                sessyukai = "4";
            }

            SQL = "  SELECT *                                         " + Constants.vbCr;
            SQL += " FROM " + wkTableName + " WK                      " + Constants.vbCr;
            SQL += " WHERE 1 = 1                                      " + Constants.vbCr;
            SQL += "   AND LEFT(WK.[002],2)    = '" + sessyukbn + "'  " + Constants.vbCr; // 予防接種コード
            SQL += "   AND ISNULL(WK.[020],'') = '" + sessyukai + "'  " + Constants.vbCr; // 変換後回数

            return SQL;
        }

        /// <summary>
        /// 取込処理　(OMTK)予防接種取込ファイルから取込対象のデータを抽出
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private string createSQL_WkTableDataFromYobouFileOMTK(string syoricd, string wkTableName)
        {
            string SQL;
            string sessyukbn = syoricd.Substring(2, 2);
            string sessyukai = syoricd.Substring(4, 1);
            string yobouCd = "";

            switch (sessyukbn ?? "")
            {
                case "01":
                    {
                        // 1:三種混合
                        yobouCd = "1";
                        break;
                    }
                case "04":
                    {
                        // 2:ＭＲ
                        yobouCd = "2";
                        sessyukai = "1";
                        break;
                    }
                case "05":
                    {
                        // 2:ＭＲ
                        yobouCd = "2";
                        sessyukai = "2";
                        break;
                    }
                case "06":
                    {
                        // 2:ＭＲ
                        yobouCd = "2";
                        sessyukai = "3";
                        break;
                    }
                case "07":
                    {
                        // 2:ＭＲ
                        yobouCd = "2";
                        sessyukai = "4";
                        break;
                    }
                case "08":
                    {
                        // 3:麻しん
                        yobouCd = "3";
                        sessyukai = "1";
                        break;
                    }
                case "09":
                    {
                        // 3:麻しん
                        yobouCd = "3";
                        sessyukai = "2";
                        break;
                    }
                case "10":
                    {
                        // 3:麻しん
                        yobouCd = "3";
                        sessyukai = "3";
                        break;
                    }
                case "11":
                    {
                        // 3:麻しん
                        yobouCd = "3";
                        sessyukai = "4";
                        break;
                    }
                case "16":
                    {
                        // 4:日本脳炎
                        yobouCd = "4";
                        break;
                    }
                case "17":
                    {
                        // 4:日本脳炎
                        yobouCd = "4";
                        sessyukai = "4";
                        break;
                    }
                case "18":
                    {
                        // 4:日本脳炎
                        yobouCd = "4";
                        sessyukai = "5";
                        break;
                    }
                case "50":
                    {
                        // 5:ｲﾝﾌﾙｴﾝｻﾞ
                        yobouCd = "5";
                        break;
                    }
                case "12":
                    {
                        // 6:風しん
                        yobouCd = "6";
                        sessyukai = "1";
                        break;
                    }
                case "13":
                    {
                        // 6:風しん
                        yobouCd = "6";
                        sessyukai = "2";
                        break;
                    }
                case "14":
                    {
                        // 6:風しん
                        yobouCd = "6";
                        sessyukai = "3";
                        break;
                    }
                case "15":
                    {
                        // 6:風しん
                        yobouCd = "6";
                        sessyukai = "4";
                        break;
                    }
                case "02":
                    {
                        // 7:二種混合
                        yobouCd = "7";
                        sessyukai = "";
                        break;
                    }
                case "03":
                    {
                        // 8:生ポリオ
                        yobouCd = "8";
                        break;
                    }
                case "19":
                    {
                        // 9:BCG
                        yobouCd = "9";
                        sessyukai = "";
                        break;
                    }
                case "22":
                    {
                        // A:HPV
                        yobouCd = "A";
                        break;
                    }
                case "20":
                    {
                        // B:ﾋﾌﾞﾜｸﾁﾝ
                        yobouCd = "B";
                        break;
                    }
                case "21":
                    {
                        // C:肺炎球菌
                        yobouCd = "C";
                        break;
                    }
                case "23":
                    {
                        // D:不活化ポリオ
                        yobouCd = "D";
                        break;
                    }
                case "24":
                    {
                        // E:四種混合
                        yobouCd = "E";
                        break;
                    }
                case "26":
                    {
                        // F:水痘
                        yobouCd = "F";
                        break;
                    }
                case "51":
                    {
                        // G:成人用肺炎球菌
                        yobouCd = "G";
                        break;
                    }
                case "27":
                    {
                        // H:B型肝炎
                        yobouCd = "H";
                        break;
                    }
                case "32":
                    {
                        // J:ロタテック
                        yobouCd = "J";
                        break;
                    }
                case "33":
                    {
                        // I:ロタリックス
                        yobouCd = "I";
                        break;
                    }
            }

            // 接種回数変換
            if (yobouCd == "4" & sessyukai == "6")
            {
                // 日本脳炎(1期初回追加):6⇒3
                sessyukai = "3";
            }
            else if (yobouCd != "5" & sessyukai == "6")
            {
                // 追加:6⇒4
                sessyukai = "4";
            }

            SQL = "  SELECT *                            " + Constants.vbCr;
            SQL += " FROM " + wkTableName + " WK         " + Constants.vbCr;
            SQL += " WHERE 1 = 1                         " + Constants.vbCr;
            SQL += "   AND WK.[001] = '" + yobouCd + "'  " + Constants.vbCr; // 予防接種コード
            SQL += "   AND WK.[005] <> '2'               " + Constants.vbCr; // 接種可否
            if (yobouCd != "5" & yobouCd != "G")
            {
                // インフルエンザと成人用肺炎球菌の場合は条件に含めない
                SQL += "   AND WK.[007] = '" + sessyukai + "'" + Constants.vbCr; // 接種回数
            }

            return SQL;
        }

        /// <summary>
        /// 接種区分を取得する。予防接種以外の場合は空文字を返却
        /// </summary>
        /// <param name="syoricd">処理コード</param>
        /// <param name="dt">データテーブル</param>
        /// <remarks></remarks>
        private string getSessyukbn(string syoricd, DataTable dt)
        {
            string sessyukbn = "";
            DataRow[] dro;

            if (syoricd.Substring(0, 2) == "03")
            {
                dro = dt.Select("FLDNM='SESSYUKBN'");
                if (dro.Length > 0)
                {
                    sessyukbn = dro[0]["SETDATA"].ToString();
                }
                else
                {
                    sessyukbn = syoricd.Substring(2, 3);
                }
            }

            return sessyukbn;
        }

        /// <summary>
        /// 文字コードを取得する
        /// </summary>
        /// <param name="moziCdKbn">文字コード区分</param>
        /// <remarks></remarks>
        private string getYosikiEncode(string moziCdKbn)
        {
            string encode = "";

            switch (moziCdKbn ?? "")
            {
                case "1":
                    {
                        encode = "Shift-JIS";
                        break;
                    }
                case "5":
                    {
                        encode = "UTF-8";
                        break;
                    }
                case "6":
                    {
                        encode = "UTF-16";
                        break;
                    }
            }

            return encode;
        }

        /// <summary>
        /// Select項目取得処理
        /// </summary>
        private string createSQL_SelectErrorList(string yosikicd, SqlConnection conn, string wkTableName, string errTableName, ref string itemNm)
        {
            SqlCommand cmd;
            string SQL;
            string value;
            string SQLERR = "";
            SqlDataAdapter da;
            DataTable dt;
            DataRow[] dro;
            DataRow drReadData;
            string ItemKojinno = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDKEYFLG             AS  FLDKEYFLG     " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.HISSUCHKKBN           AS  HISSUCHKKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.DISPVISFLG            AS  DISPVISFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPUPDFLG            AS  DISPUPDFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPTABFLG            AS  DISPTABFLG    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH1            AS  DISPWIDTH1    " + Constants.vbCr;
            SQL += "      ,IT.DISPWIDTH2            AS  DISPWIDTH2    " + Constants.vbCr;
            SQL += "      ,IT.DISPKETASU            AS  DISPKETASU    " + Constants.vbCr;
            SQL += "      ,IT.DISPORDERID           AS  DISPORDERID   " + Constants.vbCr;
            SQL += "      ,IT.REPORDERID            AS  REPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI     " + Constants.vbCr;
            SQL += "      ,IT.INPKETASU             AS  INPKETASU     " + Constants.vbCr;
            SQL += "      ,IT.INPORDERID            AS  INPORDERID    " + Constants.vbCr;
            SQL += "      ,IT.INPFORMAT             AS  INPFORMAT     " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD = '" + yosikicd + "'            " + Constants.vbCr;
            SQL += "  AND IT.REPORDERID IS NOT NULL                   " + Constants.vbCr;
            SQL += "ORDER BY CONVERT(INT, IT.REPORDERID)              " + Constants.vbCr;

            cmd = new SqlCommand(SQL, conn);

            da = new SqlDataAdapter(SQL, conn);
            dt = new DataTable();
            da.Fill(dt);

            // 項目「個人番号」取得
            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            for (int rowIndex = 0, loopTo = dt.Rows.Count - 1; rowIndex <= loopTo; rowIndex++)
            {
                drReadData = dt.Rows[rowIndex];

                if (drReadData["SETDATA"] is DBNull == false)
                {
                    value = drReadData["SETDATA"].ToString();
                }
                else
                {
                    value = "''";
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(drReadData["DISPTYPEKBN"], DISPTYPEKBN_CD, false)))
                {
                    SQLERR = Conversions.ToString(SQLERR + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,ISNULL(WK.[", drReadData["KOMOKUCD"]), "], "), value), ") + ':' "));
                    SQLERR = Conversions.ToString(SQLERR + Operators.ConcatenateObject(Operators.ConcatenateObject("     + (SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '", drReadData["CFMAINCD"]), "' "));
                    SQLERR = Conversions.ToString(SQLERR + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("                      AND SUBCD = '", drReadData["CFSUBCD"]), "' AND CD=ISNULL(WK.["), drReadData["KOMOKUCD"]), "], "), value), ")) AS  ["), drReadData["KOMOKUNM"]), "]"), Constants.vbCr));
                }
                else
                {
                    SQLERR = Conversions.ToString(SQLERR + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,ISNULL(WK.[", drReadData["KOMOKUCD"]), "], "), value), ") AS  ["), drReadData["KOMOKUNM"]), "]"), Constants.vbCr));
                }

                itemNm = Conversions.ToString(itemNm + Operators.ConcatenateObject(dt.Rows[rowIndex]["KOMOKUNM"], "|!"));
            }

            SQL = "SELECT                                             " + Constants.vbCr;
            SQL += "     ER.GYONO    AS 行番号                        " + Constants.vbCr;
            SQL += "    ,CASE WHEN ER.ERRORKBN = '3' THEN '【エラー】'" + Constants.vbCr;
            SQL += "          WHEN ER.ERRORKBN = '2' THEN '【警告】'  " + Constants.vbCr;
            SQL += "          WHEN ER.ERRORKBN = '1' THEN '【情報】'  " + Constants.vbCr;
            SQL += "     END  + ER.ERROR    AS エラー内容             " + Constants.vbCr;
            SQL += SQLERR;

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 個人番号あり
                SQL += "FROM  " + errTableName + " ER                 " + Constants.vbCr;
                SQL += "LEFT JOIN " + wkTableName + " WK              " + Constants.vbCr;
                SQL += "       ON ER.GYONO = WK.GYONO                 " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN KO                       " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO    " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                   " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO             " + Constants.vbCr;
            }
            else
            {
                // 個人番号なし
                SQL += "FROM  " + errTableName + " ER                 " + Constants.vbCr;
                SQL += "LEFT JOIN " + wkTableName + " WK              " + Constants.vbCr;
                SQL += "       ON ER.GYONO = WK.GYONO                 " + Constants.vbCr;
            }

            SQL += "ORDER BY CONVERT(INT, ER.GYONO), ER.ERRORKBN DESC, ER.ERROR  " + Constants.vbCr;

            return SQL;
        }

        /// <summary>
        /// 取込処理ログ管理用のデータを取込履歴ログ管理マスタへINSERTする。
        /// </summary>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <param name="userid">操作者ID</param>
        /// <param name="taisyo">取込対象</param>
        /// <param name="pathname">ファイルパス(ファイル名)</param>
        /// <param name="inputkensu">インプット件数</param>
        /// <param name="inputrecord">帳票名</param>
        /// <param name="inputerror"></param>
        /// <param name="outputkensu"></param>
        /// <remarks></remarks>
        public void pub_IkkatuImportLog(string syoricd, string edano, string userid, string taisyo, string pathname, string inputkensu, string inputrecord, string inputerror, string outputkensu, string nendo, SqlConnection conn, SqlTransaction wkTrn)

        {
            string SQL;
            SqlCommand cmd;

            SQL = "INSERT   INTO    dbo.TC_KKTORIIKKATULOG          " + Constants.vbCr;
            SQL += "    (                                           " + Constants.vbCr;
            SQL += "        SYORICD                                 " + Constants.vbCr;
            SQL += "       ,EDANO                                   " + Constants.vbCr;
            SQL += "       ,SYORIYMD                                " + Constants.vbCr;
            SQL += "       ,USERID                                  " + Constants.vbCr;
            SQL += "       ,TAISYO                                  " + Constants.vbCr;
            SQL += "       ,PATHNAME                                " + Constants.vbCr;
            SQL += "       ,INPUTKENSU                              " + Constants.vbCr;
            SQL += "       ,INPUTRECORD                             " + Constants.vbCr;
            SQL += "       ,INPUTERROR                              " + Constants.vbCr;
            SQL += "       ,OUTPUTKENSU                             " + Constants.vbCr;
            if (!string.IsNullOrEmpty(nendo))
            {
                SQL += "   ,NENDO                                   " + Constants.vbCr;
            }
            SQL += "    )                                           " + Constants.vbCr;
            SQL += "VALUES                                          " + Constants.vbCr;
            SQL += "    (                                           " + Constants.vbCr;
            SQL += "        " + CM_kyotu_proc.pubf_CnvNull(syoricd, 1) + "        " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(edano, 1) + "          " + Constants.vbCr;
            SQL += "       ,GETDATE()                               " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(userid, 1) + "         " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(taisyo, 1) + "         " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(pathname, 1) + "       " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(inputkensu, 0) + "     " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(inputrecord, 0) + "    " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(inputerror, 0) + "     " + Constants.vbCr;
            SQL += "       ," + CM_kyotu_proc.pubf_CnvNull(outputkensu, 0) + "    " + Constants.vbCr;
            if (!string.IsNullOrEmpty(nendo))
            {
                SQL += "   ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString(), 0) + "    " + Constants.vbCr;
            }
            SQL += "    )                                           " + Constants.vbCr;

            cmd = conn.CreateCommand();
            cmd.Transaction = wkTrn;
            cmd.CommandText = SQL;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 個人情報を取得する
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeSelectKojinInfo(SqlConnection conn, string kojinno, string yosikicd, ref XmlDocument xmlDoc, ref XmlElement root, SqlTransaction wkTrn = null)

        {
            SqlCommand cmd;
            string SQL;

            SQL = createSQL_SelectKojinInfo(conn, kojinno, yosikicd, "");

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;

            using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
            {
                CM_kyotu_proc.pub_CreateXML(dr, xmlDoc, "MKOJIN", root);
            }
        }

        /// <summary>
        /// 個人情報を取得するSQLを作成する
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private string createSQL_SelectKojinInfo(SqlConnection conn, string kojinno, string yosikicd, string wkTableName, SqlTransaction wkTrn = null)
        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL_Select = "";
            string fldNm = "";
            string komokucd = "";
            string dispTypeKbn = "";
            string ItemKojinno = "";
            string ItemBnendo = "";
            string ItemBKofuno = "";
            string ItemEdano = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD      " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM      " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM         " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM         " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA       " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN   " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN    " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD      " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD       " + Constants.vbCr;
            SQL += "      ,IT.GETDATAFLG            AS  GETDATAFLG    " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                       " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                       " + Constants.vbCr;
            SQL += "  AND IT.YOSIKICD    = '" + yosikicd + "'         " + Constants.vbCr;

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("GETDATAFLG  = '1'");

            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                // 項目取得
                fldNm = dro[rowIndx]["FLDNM"].ToString();
                komokucd = dro[rowIndx]["KOMOKUCD"].ToString();
                dispTypeKbn = dro[rowIndx]["DISPTYPEKBN"].ToString();

                fldNm = "," + getSQLItemConvertDisp(dispTypeKbn, fldNm);

                // SQL作成
                SQL_Select += "" + fldNm + " AS [" + komokucd + "]" + Constants.vbCr;
            }

            if (string.IsNullOrEmpty(wkTableName))
            {
                // 個人検索時
                SQL = "SELECT                                                 " + Constants.vbCr;
                SQL += "         KO.KOJINNO    AS  KOJINNO                    " + Constants.vbCr;
                SQL += SQL_Select;
                SQL += "FROM    TM_KKKOJIN KO                                 " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                           " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO                     " + Constants.vbCr;
                SQL += "WHERE   KO.KOJINNO  =   '" + kojinno + "'             " + Constants.vbCr;
            }
            else
            {
                dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");
                if (dro.Length > 0)
                {
                    ItemKojinno = dro[0]["SETDATA"].ToString();
                }

                dro = dt.Select("FLDNM='BNENDO' AND SETDATA IS NOT NULL");
                if (dro.Length > 0)
                {
                    ItemBnendo = dro[0]["SETDATA"].ToString();
                }

                dro = dt.Select("FLDNM='BKOFUNO' AND SETDATA IS NOT NULL");
                if (dro.Length > 0)
                {
                    ItemBKofuno = dro[0]["SETDATA"].ToString();
                }

                dro = dt.Select("FLDNM='EDANO' AND SETDATA IS NOT NULL");
                if (dro.Length > 0)
                {
                    ItemEdano = dro[0]["SETDATA"].ToString();
                }

                SQL = "SELECT                                             " + Constants.vbCr;
                SQL += "         WK.GYONO    AS  GYONO                    " + Constants.vbCr;
                SQL += SQL_Select;
                // その他検索時
                SQL += "FROM    " + wkTableName + " WK                    " + Constants.vbCr;

                if (!string.IsNullOrEmpty(ItemKojinno))
                {
                    // 修正画面表示時(宛名マスタ)
                    SQL += "LEFT JOIN TM_KKKOJIN KO                           " + Constants.vbCr;
                    SQL += "       ON " + ItemKojinno + " = KO.KOJINNO        " + Constants.vbCr;
                    SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                       " + Constants.vbCr;
                    SQL += "       ON KS.KOJINNO = KO.KOJINNO                 " + Constants.vbCr;
                }

                if (!string.IsNullOrEmpty(ItemBnendo))
                {
                    // 修正画面表示時(妊婦基本情報)
                    SQL += "LEFT JOIN VW_BHNSKOJIN NS                         " + Constants.vbCr;
                    SQL += "       ON " + ItemBnendo + "  = NS.BNENDO         " + Constants.vbCr;
                    SQL += "      AND " + ItemBKofuno + " = NS.BKOFUNO        " + Constants.vbCr;
                    SQL += "      AND " + ItemEdano + "   = NS.EDANO          " + Constants.vbCr;
                }
            }

            return SQL;
        }

        /// <summary>
        /// 初期値を取得する
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeSelectSyokiInfo(SqlConnection conn, Hashtable htParam, ref XmlDocument xmlDoc, ref XmlElement root, SqlTransaction wkTrn = null)

        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL_Select = "";
            string komokucd = "";
            string syoki = "";
            string ItemKojinno = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD       " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD       " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM       " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM          " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM          " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA        " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN    " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN     " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD       " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD        " + Constants.vbCr;
            SQL += "      ,IT.DISPSYOKI             AS  DISPSYOKI      " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                        " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                        " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  AND IT.YOSIKICD   = '", htParam["yosikicd"]), "'"), Constants.vbCr));

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");

            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            dro = dt.Select("DISPSYOKI IS NOT NULL");

            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                // 項目取得
                komokucd = dro[rowIndx]["KOMOKUCD"].ToString();
                syoki = dro[rowIndx]["DISPSYOKI"].ToString();

                // SQL作成
                SQL_Select += ", '" + syoki + "' AS [" + komokucd + "]" + Constants.vbCr;
            }

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 個人番号あり
                SQL = "SELECT                                             " + Constants.vbCr;
                SQL += "         WK.GYONO    AS  GYONO                    " + Constants.vbCr;
                SQL += SQL_Select;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FROM    ", htParam["wkTableName"]), " WK         "), Constants.vbCr));
                SQL += "LEFT JOIN TM_KKKOJIN KO                           " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO        " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                       " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO                 " + Constants.vbCr;
            }
            else
            {
                // 個人番号なし
                SQL = "SELECT                                             " + Constants.vbCr;
                SQL += "         WK.GYONO    AS  GYONO                    " + Constants.vbCr;
                SQL += SQL_Select;
                SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FROM    ", htParam["wkTableName"]), " WK         "), Constants.vbCr));
            }

            // 実行するSQL中の変数を設定する
            SQL = getSQL_SetVariable(SQL, htParam);

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;

            using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
            {
                CM_kyotu_proc.pub_CreateXML(dr, xmlDoc, "MKOJIN", root);
            }
        }

        /// <summary>
        /// 再計算結果を取得する
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeSelectSaikeisanInfo(SqlConnection conn, Hashtable htParam, ref XmlDocument xmlDoc, ref XmlElement root, SqlTransaction wkTrn = null)

        {
            SqlCommand cmd;
            string SQL;
            var dt = new DataTable();
            SqlDataAdapter da;
            DataRow[] dro;
            string SQL_Select = "";
            string komokucd = "";
            string dispformat = "";
            string ItemKojinno = "";
            string ItemBnendo = "";
            string ItemBKofuno = "";
            string ItemEdano = "";

            SQL = "SELECT  IT.YOSIKICD              AS  YOSIKICD       " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUCD              AS  KOMOKUCD       " + Constants.vbCr;
            SQL += "      ,IT.KOMOKUNM              AS  KOMOKUNM       " + Constants.vbCr;
            SQL += "      ,IT.TBLNM                 AS  TBLNM          " + Constants.vbCr;
            SQL += "      ,IT.FLDNM                 AS  FLDNM          " + Constants.vbCr;
            SQL += "      ,IT.SETDATA               AS  SETDATA        " + Constants.vbCr;
            SQL += "      ,IT.DISPTYPEKBN           AS  DISPTYPEKBN    " + Constants.vbCr;
            SQL += "      ,IT.TYPECHKKBN            AS  TYPECHKKBN     " + Constants.vbCr;
            SQL += "      ,IT.CFMAINCD              AS  CFMAINCD       " + Constants.vbCr;
            SQL += "      ,IT.CFSUBCD               AS  CFSUBCD        " + Constants.vbCr;
            SQL += "      ,IT.DISPFORMAT            AS  DISPFORMAT     " + Constants.vbCr;
            SQL += "FROM TC_KKTORIIKKATUITEM IT                        " + Constants.vbCr;
            SQL += "WHERE 1 = 1                                        " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("  AND IT.YOSIKICD   = '", htParam["yosikicd"]), "'"), Constants.vbCr));

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");

            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            dro = dt.Select("FLDNM='BNENDO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemBnendo = dro[0]["SETDATA"].ToString();
            }

            dro = dt.Select("FLDNM='BKOFUNO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemBKofuno = dro[0]["SETDATA"].ToString();
            }

            dro = dt.Select("FLDNM='EDANO' AND SETDATA IS NOT NULL");
            if (dro.Length > 0)
            {
                ItemEdano = dro[0]["SETDATA"].ToString();
            }

            dro = dt.Select("DISPFORMAT IS NOT NULL");

            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                // 項目取得
                komokucd = dro[rowIndx]["KOMOKUCD"].ToString();
                dispformat = dro[rowIndx]["DISPFORMAT"].ToString();

                // SQL作成
                SQL_Select += ", " + dispformat + " AS [" + komokucd + "]" + Constants.vbCr;
            }

            SQL = "SELECT                                             " + Constants.vbCr;
            SQL += "         WK.GYONO    AS  GYONO                    " + Constants.vbCr;
            SQL += SQL_Select;
            // その他検索時
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FROM    ", htParam["wkTableName"]), " WK         "), Constants.vbCr));

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 修正画面表示時(宛名マスタ)
                SQL += "LEFT JOIN TM_KKKOJIN KO                           " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO        " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                       " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO                 " + Constants.vbCr;
            }

            if (!string.IsNullOrEmpty(ItemBnendo))
            {
                // 修正画面表示時(妊婦基本情報)
                SQL += "LEFT JOIN VW_BHNSKOJIN NS                         " + Constants.vbCr;
                SQL += "       ON " + ItemBnendo + "  = NS.BNENDO         " + Constants.vbCr;
                SQL += "      AND " + ItemBKofuno + " = NS.BKOFUNO        " + Constants.vbCr;
                SQL += "      AND " + ItemEdano + "   = NS.EDANO          " + Constants.vbCr;
            }

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;

            using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
            {
                CM_kyotu_proc.pub_CreateXML(dr, xmlDoc, "MKOJIN", root);
            }
        }

        /// <summary>
        /// 処理名称を取得する
        /// </summary>
        /// <param name="conn">DBコネクション情報</param>
        /// <param name="syoricd">処理コード</param>
        /// <param name="edano">枝番号</param>
        /// <remarks>処理名称</remarks>
        private string GetSyoriNm(SqlConnection conn, string syoricd, string edano, SqlTransaction wkTrn = null)
        {
            string SQL;
            SqlDataAdapter da;
            DataTable dt;

            SQL = "SELECT SYORINM       AS SYORINM      " + Constants.vbCr;
            SQL += "FROM   TC_KKTORIIKKATU              " + Constants.vbCr;
            SQL += "WHERE  SYORICD = '" + syoricd + "'  " + Constants.vbCr;
            SQL += "  AND  EDANO   = " + edano + "      " + Constants.vbCr;

            da = new SqlDataAdapter(SQL, conn);
            if (wkTrn is not null)
            {
                da.SelectCommand.Transaction = wkTrn;
            }
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SYORINM"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 取込書式変換処理
        /// </summary>
        /// <param name="conn">DB接続情報</param>
        /// <param name="wkTableName">ワークテーブル名称</param>
        /// <param name="entity">取込・一括入力処理マスタエンティティ</param>
        /// <param name="htParam"></param>
        /// <param name="wkTrn">トランザクション</param>
        /// <remarks></remarks>
        private void executeConvertForm(SqlConnection conn, string wktableName, TC_KKTORI_YOSIKI_Entity entity, Hashtable htParam, SqlTransaction wkTrn)
        {
            SqlCommand cmd;
            string SQL;
            SqlDataAdapter da;
            DataTable dt;
            DataRow[] dro;
            string ItemKojinno = "";

            SQL = "SELECT                                            " + Constants.vbCr;
            SQL += "     KOMOKUCD   AS  KOMOKUCD                     " + Constants.vbCr;
            SQL += "    ,FLDNM      AS  FLDNM                        " + Constants.vbCr;
            SQL += "    ,SETDATA    AS  SETDATA                      " + Constants.vbCr;
            SQL += "    ,INPFORMAT  AS  INPFORMAT                    " + Constants.vbCr;
            SQL += "FROM  dbo.TC_KKTORIIKKATUITEM                    " + Constants.vbCr;
            SQL = Conversions.ToString(SQL + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("WHERE YOSIKICD = '", htParam["yosikicd"]), "'   "), Constants.vbCr));

            cmd = conn.CreateCommand();
            if (wkTrn is not null)
            {
                cmd.Transaction = wkTrn;
            }
            cmd.CommandText = SQL;
            cmd.CommandTimeout = COMMAND_TIMEOUT;
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            // 個人番号取得
            dro = dt.Select("FLDNM='KOJINNO' AND SETDATA IS NOT NULL");

            if (dro.Length > 0)
            {
                ItemKojinno = Conversions.ToString(dro[0]["SETDATA"]);
            }

            dro = dt.Select("INPFORMAT IS NOT NULL");

            SQL = "UPDATE                                         " + Constants.vbCr;
            SQL += "    WK                                        " + Constants.vbCr;
            SQL += "SET                                           " + Constants.vbCr;
            string komokucd;
            string format;
            for (int rowIndx = 0, loopTo = dro.Length - 1; rowIndx <= loopTo; rowIndx++)
            {
                komokucd = Conversions.ToString(dro[rowIndx]["KOMOKUCD"]);
                format = Conversions.ToString(dro[rowIndx]["INPFORMAT"]);

                if (rowIndx > 0)
                {
                    SQL += " ,";
                }

                SQL += " WK.[" + komokucd + "] = " + format + "   " + Constants.vbCr;
            }

            if (!string.IsNullOrEmpty(ItemKojinno))
            {
                // 個人番号あり
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + wktableName + " WK                     " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN KO                       " + Constants.vbCr;
                SQL += "       ON " + ItemKojinno + " = KO.KOJINNO    " + Constants.vbCr;
                SQL += "LEFT JOIN TM_KKKOJIN_SUB KS                   " + Constants.vbCr;
                SQL += "       ON KS.KOJINNO = KO.KOJINNO             " + Constants.vbCr;
            }
            else
            {
                // 個人番号なし
                SQL += "FROM                                          " + Constants.vbCr;
                SQL += "   " + wktableName + " WK                     " + Constants.vbCr;
            }

            if (dro.Length > 0)
            {
                cmd = conn.CreateCommand();
                cmd.Transaction = wkTrn;
                cmd.CommandText = SQL;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// (予防接種用)スタッフ、機関フィルター用のCDを取得する
        /// </summary>
        /// <param name="sessyukbn">接種区分</param>
        /// <remarks></remarks>
        private string getYSStaffKikanFiltercd(string sessyukbn)
        {
            string filtercd = "";

            switch (Strings.Left(sessyukbn, 2) ?? "")
            {
                case "04":
                case "05":
                case "06":
                case "07":
                    {
                        filtercd = "04";
                        break;
                    }
                case "08":
                case "09":
                case "10":
                case "11":
                    {
                        filtercd = "08";
                        break;
                    }
                case "12":
                case "13":
                case "14":
                case "15":
                    {
                        filtercd = "12";
                        break;
                    }
                case "16":
                case "17":
                case "18":
                    {
                        filtercd = "16";
                        break;
                    }

                default:
                    {
                        filtercd = Strings.Left(sessyukbn, 2);
                        break;
                    }
            }

            return filtercd;
        }

        /// <summary>
        /// 実行するSQL中の変数を設定する
        /// </summary>
        private string getSQL_SetVariable(string paramSQL, Hashtable htParam)
        {
            string SQL = paramSQL;
            string getukbn = Conversions.ToString(htParam["wkTableName"].ToString().Substring(7, 2));
            string nskaisu = Conversions.ToString(htParam["wkTableName"].ToString().Substring(11, 2));
            string sessyukbn = Conversions.ToString(htParam["wkTableName"].ToString().Substring(5, 3));

            SQL = Strings.Replace(SQL, "@@@sessyukbn@@@", sessyukbn); // 接種区分
            SQL = Strings.Replace(SQL, "@@@getukbn@@@", getukbn);     // 月齢区分
            SQL = Strings.Replace(SQL, "@@@nskaisu@@@", nskaisu);     // 妊産婦健診回数

            return SQL;
        }
    }

    /// <summary>
    /// 取込・一括入力処理マスタエンティティ
    /// </summary>
    /// <remarks></remarks>
    public class TC_KKTORIIKKATU_Entity
    {
        /// <summary>
        /// 処理コード
        /// </summary>
        /// <remarks></remarks>
        public string SYORICD;

        /// <summary>
        /// 枝番
        /// </summary>
        /// <remarks></remarks>
        public string EDANO;

        /// <summary>
        /// 処理名称
        /// </summary>
        /// <remarks></remarks>
        public string SYORINM;

        /// <summary>
        /// 様式コード
        /// </summary>
        /// <remarks></remarks>
        public string YOSIKICD;

        /// <summary>
        /// 登録更新区分
        /// </summary>
        /// <remarks></remarks>
        public string INSUPDKBN;

        /// <summary>
        /// 実行区分
        /// </summary>
        /// <remarks></remarks>
        public string JIKKOKBN;

        /// <summary>
        /// 年度使用フラグ
        /// </summary>
        /// <remarks></remarks>
        public string NENDOSIYOFLG;

        /// <summary>
        /// ファイルパス
        /// </summary>
        /// <remarks></remarks>
        public string FILEPATH;

        /// <summary>
        /// ファイル名称
        /// </summary>
        /// <remarks></remarks>
        public string FILENM;

        /// <summary>
        /// 編集ファイル名称
        /// </summary>
        /// <remarks></remarks>
        public string HFILENM;

        /// <summary>
        /// 並び順
        /// </summary>
        /// <remarks></remarks>
        public string ORDERID;

        /// <summary>
        /// 画面入力時チェックフラグ
        /// </summary>
        /// <remarks></remarks>
        public string DISPCHKFLG;

        /// <summary>
        /// 画面行自動作成フラグ
        /// </summary>
        /// <remarks></remarks>
        public string DISPROWFLG;

        /// <summary>
        /// 画面追加可能フラグ
        /// </summary>
        /// <remarks></remarks>
        public string DISPADDFLG;

        /// <summary>
        /// 画面削除可能フラグ
        /// </summary>
        /// <remarks></remarks>
        public string DISPDELFLG;

        /// <summary>
        /// 入力チェック用ストアドプロシージャ
        /// </summary>
        /// <remarks></remarks>
        public string CHKSTORED;

        /// <summary>
        /// 前処理用ストアドプロシージャ
        /// </summary>
        /// <remarks></remarks>
        public string BEFSTORED;

        /// <summary>
        /// 後処理用ストアドプロシージャ
        /// </summary>
        /// <remarks></remarks>
        public string AFTSTORED;
    }

    /// <summary>
    /// 取込ファイル様式マスタエンティティ
    /// </summary>
    /// <remarks></remarks>
    public class TC_KKTORI_YOSIKI_Entity
    {
        /// <summary>
        /// 様式コード
        /// </summary>
        /// <remarks></remarks>
        public string YOSIKICD;

        /// <summary>
        /// データ形式区分
        /// </summary>
        /// <remarks></remarks>
        public string KEISIKIKBN;

        /// <summary>
        /// 文字コード区分
        /// </summary>
        /// <remarks></remarks>
        public string MOJICDKBN;

        /// <summary>
        /// 区切り記号区分
        /// </summary>
        /// <remarks></remarks>
        public string KUGIRIKBN;

        /// <summary>
        /// 引用符区分
        /// </summary>
        /// <remarks></remarks>
        public string INYOFUKBN;

        /// <summary>
        /// ヘッダー部行数
        /// </summary>
        /// <remarks></remarks>
        public int HEADERROW;
    }
}*/