/*using Microsoft.Data.SqlClient;

// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// 修正履歴
// 2012/11/01 yokota 更新時の区切り文字を変更
// 2013/01/28 yokota 妊産婦バーコードシール出力対応
// 2013/01/28 yokota 住所、妊婦世帯電話番号を検索条件部に追加
// 2013/01/28 yokota 排他制御追加
// 2013/01/28 yokota 要管理内容・個人照会にフォロー方法、フォロー予定年月日、
// フォロー完了年月日を追加
// 2013/01/28 yokota 妊娠既往歴に妊娠高血圧症候群を追加
// 2013/01/28 yokota メモ情報にて注意フラグ設定時にボタンの色を変更
// 2013/10/30 yokota DV対象者、メモ情報有無のメッセージ表示処理を追加
// フリー項目に医療機関・スタッフを選択できる機能を追加する
// 2014/05/12 yamasaki 助成通知出力処理を追加
// 2014/05/26 yamasaki 連絡先に保護者タブ追加
// 2014/07/15 yamasaki 交付番号以外で検索した場合複数子供が紐づくとエラーが出るため修正
// 2014/08/07 yokota 子の個人番号が数値で検索されている為、修正
// 2014/10/06 yokota 母子保健用フリー項目の追加
// 2015/03/31 minori-sol 妊産婦情報管理の改修
// 2015/08/29 takahashi ARIK 受診票ボタンを追加。「受診票ボタン」クリック及び
// 新規登録時に「妊婦健診受診票（補助券）」の出力処理を追加
// 2015/09/30 Minori-sol 番号法対応
// 2015/02/12 ikuno 妊婦検索の戻値に住民となった日、住民でなくなった日を追加
// 2016/03/18 hasuo  個人番号検索後の一覧から個人を選択したときのログが正しく登録されないため修正
// 2016/04/04 takahashi  妊婦健診受診票（補助券）の出力項目に「出生予定順位」を追加
// 2016/10/28 nakamura 問診項目が日付タイプ(DATATYPE5)の場合、登録の際にエラーになるため修正
// 2016/11/09 yamaguchi カナ氏名または生年月日で検索し複数件（住登外者を１人以上含む）ヒットした場合、住登外者が一覧に表示されないため修正
// 2016/02/14 hauso     帳票の出力項目を追加
// 2017/07/25 gotou 個人照会時にKATAがNULLの場合、住所が空白となる不具合を修正
// 2017/07/28 matsuo 父親の情報を入力して検索するとデータを取得するため、データを取得しないよう修正
// 2017/11/17 gotou  フリー項目マスタのカラムの追加削除に対応
// 2017/12/14 hauso  CF(98-411-001)に1が立っているとき、除票者のメッセージを表示する処理を追加
// 2017/12/20 hasuo 子育てワンストップ対応(プッシュ通知希望追加・オンライン申請情報追加)
// 2017/12/20 hasuo 個人照会時にKATAがNULLの場合、住所が空白となる不具合を修正
// 2017/12/20 hasuo 父親の情報を入力して検索するとデータを取得するため、データを取得しないよう修正
// 2018/09/07 hasuo    訪問指導、健康相談ボタンのスタイルをデータの有無により変更する処理を追加
// 2018/09/11 yokota ジェノグラム、家族構成ボタン追加
// 2018/09/11 yokota 支援計画タブ追加
// 2018/09/11 yokota 関係機関ボタン追加
// 2018/09/11 yokota 支援計画帳票出力項目追加
// 2018/10/31 hasuo  【元号対応】VBのクラスではなく新規作成関数で和暦変換するように変更
// 2019/03/25 yamasaki 支援計画タブで帳票出力時に訪問指導の備考がNULLの場合オブジェクトエラーとなるため修正
// 2019/04/23 mure   【元号対応】妊婦健診受診票（補助券）「発行年月日」を和暦変換するSQLに修正
// 2020/01/10 mure    受診票：父親かな・氏名を出力
// 2020/05/01 mure    個人台帳ボタン押下時の処理を追加
// 2020/11/11 mure  「産後２週間」「産後１か月」のパネル名称をTC_KKCFで管理する様に変更
// 2022/03/04 yamasaki.m 母子保健関連画面のサブシステム権限制御が一部未適用だったため追加
// 2022.06.21 ikuno 妊婦支援計画帳票に父生年月日を追加
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace AFFECTv2
{
    public class BH_kosin_ninsanpu
    {
        // ' 定数定義：PGごとで変更
        private const string mPGNAME = "BH_kosin_ninsanpu";

        private const string mSHORIMEI = "妊産婦情報管理";
        private const string KBN_TITI = "1";
        private const string KBN_HAHA = "2";
        private const string KBN_KO = "3";
        private const string KBN_HOGO = "4";
        private const string CONST_FILETYPE_PDF = "PDF";
        private const string CONST_FILETYPE_EXCEL = "EXCEL";
        private const string CONST_FILETYPE_CSV = "CSV";
        private const string PGID_NYUYOJI = "122";
        private const string PGID_SOGOSIEN = "228";
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

        private CM_dbaccess db = new CM_dbaccess();

        /// <summary>
        /// 初期表示処理
        /// </summary>
        /// <param name="pgid"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_FormInit(string pgid, string userid)
        {
            SqlCommand cmd;
            string SQL;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            SqlDataAdapter da;
            DataTable dt;
            int i;
            string systemcd;

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();
                try
                {
                    // 'システムコード取得
                    SQL = pubf_SQLGetSystemCode(pgid);

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    systemcd = dt.Rows[0]["SYSTEMCD"].ToString();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MSYORICD", rootElemRESULTXML);
                    }

                    // affect.htmlのURL取得
                    SQL = "SELECT                       " + Constants.vbCr;
                    SQL += "        '" + System.Configuration.ConfigurationManager.ConnectionStrings["urlKino"].ToString() + "'   " + Constants.vbCr;
                    SQL += "                AS  URL     " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MURL", rootElemRESULTXML);
                    }

                    // 分娩場所/実施機関
                    SQL = pubf_SQLGetKikan("03", "01");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KIKAN", rootElemRESULTXML);
                    }

                    // 医師(医師名)
                    SQL = pubf_SQLGetStaff("03", "01", "1");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "ISI", rootElemRESULTXML);
                    }

                    // スタッフ(担当保健師/母子推進委員/担当者)
                    SQL = pubf_SQLGetStaff("03", "01", "3");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "STAFF", rootElemRESULTXML);
                    }

                    // 手帳（県）/手帳（市）/訪問希望/育児休業/妊娠分娩異常/
                    // ペット/中毒有無/産褥期の異常/治療/入院/育児への協力及び相談者の有無
                    // 貧血/偏食/産婦訪問/妊娠高血圧症候群
                    SQL = CM_kyotu_proc.pubf_SQLCf("01", "011");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "UMU", rootElemRESULTXML);
                    }

                    // 保険区分
                    SQL = CM_kyotu_proc.pubf_SQLCf("01", "020");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HOKEN", rootElemRESULTXML);
                    }

                    // 新規交付
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "039");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SINKIKOFU", rootElemRESULTXML);
                    }

                    // 発行区分
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "002");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HAKKOKUBUN", rootElemRESULTXML);
                    }

                    // 発行場所
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "003");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HAKKOBASYO", rootElemRESULTXML);
                    }

                    // 勤務区分
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "004");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KINMUKUBN", rootElemRESULTXML);
                    }

                    // 通勤方法
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "005");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "THOHO", rootElemRESULTXML);
                    }

                    // 子供の健康状態
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "006");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KENKO", rootElemRESULTXML);
                    }

                    // 妊娠歴区分
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "007");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "NINSINREKIKUBUN", rootElemRESULTXML);
                    }

                    // 自然・人工
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "008");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIZENJINKOKUBUN", rootElemRESULTXML);
                    }

                    // 住居情報
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "009");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "JYUKYO", rootElemRESULTXML);
                    }

                    // 騒音
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "010");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SOON", rootElemRESULTXML);
                    }

                    // 日当り
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "011");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HIATARI", rootElemRESULTXML);
                    }

                    // 疾患有無
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "012");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIKKAN", rootElemRESULTXML);
                    }

                    // 尿（糖）/尿（蛋白）/尿（潜血）/浮腫
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "013");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "NYOKEN", rootElemRESULTXML);
                    }

                    // 主訴　内容
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "014");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SNAIYO", rootElemRESULTXML);
                    }

                    // 症状
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "015");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SYOJYO", rootElemRESULTXML);
                    }

                    // 疾病名
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "016");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIPPEI", rootElemRESULTXML);
                    }

                    // 保健指導 要管理内容
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "017");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HNAIYO", rootElemRESULTXML);
                    }

                    // 保健指導 フォロー方法
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "042");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HFHOUHOU", rootElemRESULTXML);
                    }

                    // 飲酒種類
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "018");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "INSYU", rootElemRESULTXML);
                    }

                    // 栄養強化対象
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "019");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "EIYO", rootElemRESULTXML);
                    }

                    // 牛乳
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "020");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "GYUNYU", rootElemRESULTXML);
                    }

                    // 指導内容
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "021");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIDONAIYO", rootElemRESULTXML);
                    }

                    // 妊婦健診回数
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "022");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KENKAISU", rootElemRESULTXML);
                    }

                    // 予算区分
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "023");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "YOSAN", rootElemRESULTXML);
                    }

                    // 検診方式
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "024");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KHOSIKI", rootElemRESULTXML);
                    }

                    // 検査結果
                    // 間接クームス/HBs抗原/HCV抗原/HCV抗体/梅毒血清検査/HIV/風疹
                    // トキソプラズマ/HTLV-1/ATL/子宮頚がん細胞診/子宮頚管細菌検査
                    // B型溶血性連鎖球菌/HBs抗原(妊娠既往歴)/ATL(妊娠既往歴)
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "025");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KKEKKA", rootElemRESULTXML);
                    }

                    // 子宮がん結果
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "026");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIKYUKEKKA", rootElemRESULTXML);
                    }

                    // 疾患名
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "027");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIKSIKKAN", rootElemRESULTXML);
                    }

                    // 超音波検査
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "028");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TKEN", rootElemRESULTXML);
                    }

                    // 超音波結果
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "029");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TKEKKA", rootElemRESULTXML);
                    }

                    // 胎児発育評価検査
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "030");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HATUIKU", rootElemRESULTXML);
                    }

                    // 総合判定/判定
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "031");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "HANTEI", rootElemRESULTXML);
                    }

                    // 入院
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "032");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "NYUIN", rootElemRESULTXML);
                    }

                    // 病名１
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "033");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "BYOMEI1", rootElemRESULTXML);
                    }

                    // 病名２
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "033");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "BYOMEI2", rootElemRESULTXML);
                    }

                    // 病名３
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "033");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "BYOMEI3", rootElemRESULTXML);
                    }

                    // 病名４
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "033");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "BYOMEI4", rootElemRESULTXML);
                    }

                    // 市町村連絡事項
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "034");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "RENRAKU", rootElemRESULTXML);
                    }

                    // 身体の状況
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "035");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SINJOKYO", rootElemRESULTXML);
                    }

                    // 気分の異常
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "036");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KIBUN", rootElemRESULTXML);
                    }

                    // 月経開始時期
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "037");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "GEKKEI", rootElemRESULTXML);
                    }

                    // 検査結果（浮腫）
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "040");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "FUSYU", rootElemRESULTXML);
                    }

                    // 詳細検索（妊婦）
                    // 行政区取得
                    SQL = CM_kyotu_proc.pubf_SQLGyo();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MJGYO", rootElemRESULTXML);
                    }

                    // 詳細検索（妊婦）
                    // 住民区分指定
                    SQL = CM_kyotu_proc.pubf_SQLCf("01", "008");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "JKBN", rootElemRESULTXML);
                    }

                    // 詳細検索（妊婦）妊婦健診判定指定
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "031");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "SYOHANTEI", rootElemRESULTXML);
                    }

                    // 特定妊婦チェック該当/非該当 取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "048");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNCHECK", rootElemRESULTXML);
                    }

                    // 特定妊婦チェックリスト項目名一覧取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "049");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNCHECKLABELS", rootElemRESULTXML);
                    }

                    // 特定妊婦チェックリスト情報取得
                    for (i = 1; i <= 12; i++)
                    {
                        SQL = pubf_SQLCf2("04", "050", i.ToString("00"));
                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNCHECK" + i.ToString("00"), rootElemRESULTXML);
                        }
                    }

                    // 特定妊婦支援計画　方法取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "051");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNHOHO", rootElemRESULTXML);
                    }

                    // 特定妊婦支援計画　雛型取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "052");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNHINAGATA", rootElemRESULTXML);
                    }

                    // 特定妊婦支援計画　評価結果取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "053");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNKEKKA", rootElemRESULTXML);
                    }

                    // 特定妊婦支援計画　主なフォロー方法取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "054");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "TNHOHOMAIN", rootElemRESULTXML);
                    }

                    // 2015/02/12 ikuno 妊婦検索の戻値に住民となった日、住民でなくなった日を追加 >>
                    // 健診日、住民日付チェック
                    SQL = CM_kyotu_proc.pubf_SQLCfNAIYO("98", "406", "001");
                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "JUJNCHECK", rootElemRESULTXML);
                    }
                    // 2015/02/12 ikuno 妊婦検索の戻値に住民となった日、住民でなくなった日を追加 <<

                    // 妊産婦動的項目管理マスタより抽出
                    SQL = pubf_SQLGetTC_BHKKITEM("", "");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "NSITEM", rootElemRESULTXML);
                    }

                    // 動的項目　コンボボックスの値を取得
                    SQL = pubf_SQLGetKKITEM_CFCD();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    int count = dt.Rows.Count;

                    if (count > 0)
                    {
                        var loopTo = count - 1;
                        for (i = 0; i <= loopTo; i++)
                        {
                            string cfid = dt.Rows[i]["CFID"].ToString();
                            string maincd = dt.Rows[i]["CFMAINCD"].ToString();
                            string subcd = dt.Rows[i]["CFSUBCD"].ToString();

                            if (cfid != "1")
                            {
                                continue;
                            }

                            // CFからコンボボックスの選択項目を取得する
                            SQL = CM_kyotu_proc.pubf_SQLCf(maincd, subcd);

                            BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, maincd, subcd, cfid, i, rootElemRESULTXML);
                        }

                        int cfnum = i;

                        // 'フリー項目リスト内容(TC_KKTIKU用大字)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "01");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "01", "", "2", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKTIKU用行政区)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "02");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "02", "", "2", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKTIKU用納組)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "03");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "03", "", "2", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKTIKU用小学校区)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "04");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "04", "", "2", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKTIKU用中学校区)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "05");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "05", "", "2", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKKIKAN用)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList3("01");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "", "", "3", cfnum, rootElemRESULTXML);

                        // 'フリー項目リスト内容(TC_KKSTAFF用)
                        cfnum += 1;
                        SQL = BHCO_kyotu_proc.pubf_BHGetFreeList4("01");
                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "", "", "4", cfnum, rootElemRESULTXML);
                    }

                    // 'フリー項目グループ取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "044");

                    cmd = new SqlCommand(SQL, conn);

                    // '（コンボボックス用）
                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEG", rootElemRESULTXML);
                    }

                    // 'フリー項目グループ２取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "045");

                    cmd = new SqlCommand(SQL, conn);

                    // '（コンボボックス用）
                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEG2", rootElemRESULTXML);
                    }

                    // 'フリー項目取得
                    SQL = BHCO_kyotu_proc.pubf_BhGetFitem("044", "1", "00", "1");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREE", rootElemRESULTXML);
                    }

                    // 'フリー項目リスト内容(TC_KKCF用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist1("1", "00");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREECF1", rootElemRESULTXML);
                    }

                    // 'フリー項目リスト内容(TC_KKTIKU用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist2("1", "00");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREECF2", rootElemRESULTXML);
                    }

                    // 'フリー項目リスト内容(TC_KKKIKAN用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist3("01");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREECF3", rootElemRESULTXML);
                    }

                    // 'フリー項目リスト内容(TC_KKSTAFF用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist4("01");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREECF4", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報グループ取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "046");

                    cmd = new SqlCommand(SQL, conn);

                    // '（コンボボックス用）
                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINEG", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報グループ２取得
                    SQL = CM_kyotu_proc.pubf_SQLCf("04", "047");

                    cmd = new SqlCommand(SQL, conn);

                    // '（コンボボックス用）
                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINEG2", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報フリー項目取得
                    SQL = BHCO_kyotu_proc.pubf_BhGetFitem("046", "1", "10", "1");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINE", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報フリー項目リスト内容(TC_KKCF用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist1("1", "10");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINECF1", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報フリー項目リスト内容(TC_KKTIKU用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist2("1", "10");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINECF2", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報フリー項目リスト内容(TC_KKKIKAN用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist3("01");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINECF3", rootElemRESULTXML);
                    }

                    // 'オンライン申請情報フリー項目リスト内容(TC_KKSTAFF用)
                    SQL = BHCO_kyotu_proc.pubf_BhGetFlist4("01");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINECF4", rootElemRESULTXML);
                    }

                    // 排他制御マスタ：ロック解除
                    if (CM_kyotu_proc.pubf_Haitaseigyo() == "1")
                    {
                        CM_kyotu_proc.pubf_DeleteHaitaseigyo(userid, systemcd);
                    }

                    // 各種権限取得
                    var argconn = conn;
                    CM_kyotu_proc.pubf_GetPAuthority(pgid, userid, ref argconn, ref newXML, ref rootElemRESULTXML);

                    // 乳幼児情報管理（個人）権限取得
                    var argconn1 = conn;
                    CM_kyotu_proc.pubf_GetSubsystemAuthority(PGID_NYUYOJI, userid, ref argconn1, ref newXML, ref rootElemRESULTXML, "MNYUYOJIAUTH");
                    // 総合支援情報管理権限取得
                    var argconn2 = conn;
                    CM_kyotu_proc.pubf_GetSubsystemAuthority(PGID_SOGOSIEN, userid, ref argconn2, ref newXML, ref rootElemRESULTXML, "MSOGOSIENAUTH");

                    // メモ・ドキュメント機能の権限取得
                    var argconn3 = conn;
                    CM_kyotu_proc.pubf_GetMADAuthority(userid, ref argconn3, ref newXML, ref rootElemRESULTXML);

                    // '除票者メッセージフラグの取得
                    SQL = "SELECT                                        " + Constants.vbCr;
                    SQL += "    CF.NAIYO    AS  MSGFLG                   " + Constants.vbCr;
                    SQL += "FROM dbo.TC_KKCF CF                          " + Constants.vbCr;
                    SQL += "WHERE    CF.MAINCD   =   '98'                " + Constants.vbCr;
                    SQL += "     AND CF.SUBCD    =   '411'               " + Constants.vbCr;
                    SQL += "     AND CF.CD       =   '001'               " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MMSGFLG", rootElemRESULTXML);
                    }

                    // 'プッシュ通知希望情報使用/未使用制御取得
                    SQL = CM_kyotu_proc.pubf_SQLOnPushUse();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MONPUSHUSE", rootElemRESULTXML);
                    }

                    // ジェノグラム使用権限取得
                    var argconn4 = conn;
                    CM_kyotu_proc.pubf_GetGenogramAuthority(userid, ref argconn4, ref newXML, ref rootElemRESULTXML);

                    // 家族構成使用権限取得
                    var argconn5 = conn;
                    CM_kyotu_proc.pubf_GetKazokukouseiAuthority(userid, ref argconn5, ref newXML, ref rootElemRESULTXML);

                    // '子育て世代包括支援機能使用/未使用制御取得
                    SQL = CM_kyotu_proc.pubf_SQLBhHokatuUse();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MBHHOKATU", rootElemRESULTXML);
                    }

                    SQL = CM_kyotu_proc.pubf_SQLBhKojinDaichouUse();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MBHKOJINDAICHOU", rootElemRESULTXML);
                    }

                    // 産婦健康診査情報(上段)名称設定
                    SQL = CM_kyotu_proc.pubf_SQLBhSanpuKenSin1_Use();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MBHSANPUTITLE1", rootElemRESULTXML);
                    }

                    // 産婦健康診査情報(下段)名称設定
                    SQL = CM_kyotu_proc.pubf_SQLBhSanpuKenSin2_Use();

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MBHSANPUTITLE2", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
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
        /// 妊産婦情報入力で使用するデータを抽出する。
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <param name="edano">枝番号</param>
        /// <param name="kokojinno">整理番号(子供)</param>
        /// <param name="sinkiflg">新規フラグ</param>
        /// <param name="seirino">整理番号</param>
        /// <param name="bymd">生年月日</param>
        /// <param name="kname">カナ氏名</param>
        /// <param name="jokengyo">行政区（条件あり/なし）</param>
        /// <param name="gyoseiku">行政区</param>
        /// <param name="jokenjumin">住民区分（条件あり/なし）</param>
        /// <param name="juminkubun">住民区分</param>
        /// <param name="jokennenrei">年齢範囲（条件あり/なし）</param>
        /// <param name="kijunbi">年齢基準日</param>
        /// <param name="nenrei">年齢</param>
        /// <param name="jokentodokedesyusu">届出週数（条件あり/なし）</param>
        /// <param name="todokedesyusuFrom">届出週数（From）</param>
        /// <param name="todokedesyusuTo">届出週数（To）</param>
        /// <param name="jokentodokedebi">届出日（条件あり/なし）</param>
        /// <param name="todokedebiFrom">届出日（From）</param>
        /// <param name="todokedebiTo">届出日（To）</param>
        /// <param name="jokenbunben">分娩予定日範囲（条件あり/なし）</param>
        /// <param name="bunbenyoteibiFrom">分娩予定日範囲（From）</param>
        /// <param name="bunbenyoteibiTo">分娩予定日範囲（To）</param>
        /// <param name="jokenninpukenshinbi">妊婦健診受診日範囲（条件あり/なし）</param>
        /// <param name="ninpukenshinbiFrom">妊婦健診受診日（From）</param>
        /// <param name="ninpukenshinbiTo">妊婦健診受診日（To）</param>
        /// <param name="jokennninpukenshinhantei">妊婦健診判定（条件あり/なし）</param>
        /// <param name="ninpukenshinhantei">妊婦健診判定</param>
        /// <param name="pno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Kensaku(string systemcd, string userid, string nendo, string kofuno, string edano, string kokojinno, bool sinkiflg, string seirino, string bymd, string kname, string jokengyo, string[] gyoseiku, string jokenjumin, string[] juminkubun, string jokennenrei, string kijunbi, string nenrei, string jokentodokedesyusu, string todokedesyusuFrom, string todokedesyusuTo, string jokentodokedebi, string todokedebiFrom, string todokedebiTo, string jokenbunben, string bunbenyoteibiFrom, string bunbenyoteibiTo, string jokenninpukenshinbi, string ninpukenshinbiFrom, string ninpukenshinbiTo, string jokennninpukenshinhantei, string[] ninpukenshinhantei, string pno)

        {
            SqlCommand cmd;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            SqlDataAdapter da;
            DataTable dt;
            long cnt;
            string kojinno = "";
            string bnendo = "";
            string bkofuno = "";
            string bedano = "";
            string nenreisql = "";
            string Param;
            string SQL;
            string CNT_SQL;
            int i;
            string[] pnoList = null;

            string msg = "";

            if (Strings.Len(pno) > 0)
            {
                pnoList = new string[] { pno };
            }

            // ログパラメータ設定（個人番号はマスクする）
            Param = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("func_Kensaku(" + systemcd + "," + userid + "," + nendo + "," + kofuno + "," + edano + "," + sinkiflg + "," + seirino + ",", Interaction.IIf(Strings.Len(pno) > 0, "************", "")), ")"));

            nendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // 対称キーオープン
                    var argconn = conn;
                    SqlTransaction argwkTrn = null;
                    CM_kyotu_proc.pubf_OpenSymKey(1, ref argconn, wkTrn: ref argwkTrn);

                    if (!string.IsNullOrEmpty(nendo) & !string.IsNullOrEmpty(kofuno) & !string.IsNullOrEmpty(edano))
                    {
                        // 母子手帳番号で検索
                        // 複数件ヒットした場合は1レコード目を取り出し取得件数1件とする
                        SQL = pubf_SQLGetNyuryokuKensaku(nendo, kofuno, edano, kokojinno);

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        cnt = dt.Rows.Count;
                        if (cnt == 1L)
                        {
                            kojinno = dt.Rows[0]["HEMKOJINNO"].ToString();
                        }

                        bnendo = nendo;
                        bkofuno = kofuno;
                        bedano = edano;

                        pnoList = null;

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPARAM", rootElemRESULTXML);
                        }
                    }
                    else
                    {
                        // 年齢範囲
                        if (jokennenrei == "1")
                        {
                            if (CM_kyotu_proc.pubf_ChkAge(nenrei) == false)
                            {
                                CM_kyotu_proc.pub_Status(1, 6, "（年齢範囲/女性）", newXML, "STATUS", rootElemRESULTXML);
                                CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 6) + "（年齢範囲/女性）", "", "");
                                return newXML;
                            }
                            nenreisql = CM_kyotu_proc.pubNenrei;
                        }

                        // 整理番号、カナ氏名、生年月日、詳細検索条件で検索を行う場合
                        SQL = pubf_SQLGetKensaku(seirino, bymd, kname, jokengyo, gyoseiku, jokenjumin, juminkubun, jokennenrei, kijunbi, nenreisql, jokentodokedesyusu, todokedesyusuFrom, todokedesyusuTo, jokentodokedebi, todokedebiFrom, todokedebiTo, jokenbunben, bunbenyoteibiFrom, bunbenyoteibiTo, jokenninpukenshinbi, ninpukenshinbiFrom, ninpukenshinbiTo, jokennninpukenshinhantei, ninpukenshinhantei, pno);

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);
                        cnt = Conversions.ToLong(dt.Rows[0]["SUM"].ToString());

                        if (cnt == 1L)
                        {
                            bnendo = dt.Rows[0]["BNENDO"].ToString();
                            bkofuno = dt.Rows[0]["BKOFUNO"].ToString();
                            bedano = dt.Rows[0]["BEDANO"].ToString();

                            SQL = pubf_SQLGetNyuryokuKensaku(bnendo, bkofuno, bedano, kokojinno);
                            da = new SqlDataAdapter(SQL, conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            cnt = dt.Rows.Count;
                            if (cnt == 1L)
                            {
                                kojinno = dt.Rows[0]["HEMKOJINNO"].ToString();
                            }

                            cmd = new SqlCommand(SQL, conn);

                            using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                            {
                                CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPARAM", rootElemRESULTXML);
                            }
                        }
                    }

                    // 検索ヒット件数をXMLに設定する
                    CNT_SQL = "SELECT                       " + Constants.vbCr;
                    CNT_SQL += "        " + cnt + " AS  CNT " + Constants.vbCr;

                    cmd = new SqlCommand(CNT_SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "CMEISAI", rootElemRESULTXML);
                    }

                    switch (cnt)
                    {
                        case 0L:
                            {
                                // 検索結果が0件の場合
                                CM_kyotu_proc.pub_Status(0, 9, "", newXML, "STATUS", rootElemRESULTXML);
                                CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 9), "", "", "", pnoList);

                                return newXML;
                            }
                        case 1L:
                            {
                                // 検索結果が1件の場合
                                string seigyoflg = "0";
                                if (!string.IsNullOrEmpty(kojinno) & CM_kyotu_proc.pubf_Haitaseigyo() == "1")
                                {
                                    msg = CM_kyotu_proc.pubf_InsertHaitaseigyo(userid, systemcd, kojinno);

                                    if (!string.IsNullOrEmpty(msg))
                                    {
                                        seigyoflg = "1";
                                    }
                                }

                                SQL = "SELECT  '" + seigyoflg + "' AS  SEIGYOFLG";
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "HAITA", rootElemRESULTXML);
                                }

                                // 出生歴取得
                                SQL = pubf_SQLGetSyussyo(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SYUSEIREKI", rootElemRESULTXML);
                                }

                                // 妊娠歴取得
                                SQL = pubf_SQLGetNinsinreki(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "NINSINREKI", rootElemRESULTXML);
                                }

                                // 家族環境・同居の家族取得
                                SQL = pubf_SQLGetDokyo(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "DOKYO", rootElemRESULTXML);
                                }

                                // 主訴取得
                                SQL = pubf_SQLGetSyuso(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SYUSO", rootElemRESULTXML);
                                }

                                // 母親学級取得
                                SQL = pubf_SQLGetGakkyu(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "GAKKYU", rootElemRESULTXML);
                                }

                                // 現在の疾病治療状況取得
                                SQL = pubf_SQLGetSippei(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIPPEI", rootElemRESULTXML);
                                }

                                // 保健指導取得
                                SQL = pubf_SQLGetSido(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "HOKENSIDO", rootElemRESULTXML);
                                }

                                // 要管理内容取得
                                SQL = pubf_SQLGetYokanri(bnendo, bkofuno);
                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "YOKANRI", rootElemRESULTXML);
                                }

                                // 問診の入力内容を取得する
                                SQL = pubf_SQLGetMonsin(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MONSIN", rootElemRESULTXML);
                                }

                                // 妊婦健診マスタより抽出
                                SQL = pubf_SQLGetNinpukensin(bnendo, bkofuno, bedano);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "NINKEN", rootElemRESULTXML);
                                }

                                // 妊産婦動的項目管理マスタより抽出
                                SQL = pubf_SQLGetTC_BHKKITEM(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "NSITEM", rootElemRESULTXML);
                                }

                                // 動的項目　コンボボックスの値を取得
                                SQL = pubf_SQLGetKKITEM_CFCD();

                                da = new SqlDataAdapter(SQL, conn);
                                dt = new DataTable();
                                da.Fill(dt);
                                int count = dt.Rows.Count;

                                if (count > 0)
                                {
                                    var loopTo = count - 1;
                                    for (i = 0; i <= loopTo; i++)
                                    {
                                        string cfid = dt.Rows[i]["CFID"].ToString();
                                        string maincd = dt.Rows[i]["CFMAINCD"].ToString();
                                        string subcd = dt.Rows[i]["CFSUBCD"].ToString();

                                        if (cfid != "1")
                                        {
                                            continue;
                                        }

                                        // CFからコンボボックスの選択項目を取得する
                                        SQL = CM_kyotu_proc.pubf_SQLCf(maincd, subcd);

                                        BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, maincd, subcd, cfid, i, rootElemRESULTXML);
                                    }

                                    int cfnum = i;

                                    // 'フリー項目リスト内容(TC_KKTIKU用大字)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "01");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "01", "", "2", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKTIKU用行政区)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "02");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "02", "", "2", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKTIKU用納組)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "03");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "03", "", "2", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKTIKU用小学校区)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "04");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "04", "", "2", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKTIKU用中学校区)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList2("1", "05");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "05", "", "2", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKKIKAN用)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList3("01");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "", "", "3", cfnum, rootElemRESULTXML);

                                    // 'フリー項目リスト内容(TC_KKSTAFF用)
                                    cfnum += 1;
                                    SQL = BHCO_kyotu_proc.pubf_BHGetFreeList4("01");
                                    BHCO_kyotu_proc.pubf_setCFMAP(conn, newXML, SQL, "", "", "4", cfnum, rootElemRESULTXML);
                                }

                                // 産婦健診マスタより抽出
                                SQL = pubf_SQLGetSanpu(bnendo, bkofuno, bedano);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SANPU", rootElemRESULTXML);
                                }

                                if (!string.IsNullOrEmpty(kojinno))
                                {
                                    // 'メモ情報有無メッセージフラグ取得
                                    SQL = CM_kyotu_proc.pubf_SQLMemoMsgFlg();

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MMEMOMSG", rootElemRESULTXML);
                                    }

                                    // メモの入力内容があるか確認する
                                    SQL = CM_kyotu_proc.pubf_SQLMemo(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MMEMOF", rootElemRESULTXML);
                                    }

                                    // 'ドキュメント管理情報有無取得
                                    SQL = CM_kyotu_proc.pubf_SQLDoc(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MDOCF", rootElemRESULTXML);
                                    }

                                    // '世帯DV対象者取得処理
                                    var argconn1 = conn;
                                    CM_kyotu_proc.pubf_SQLGetDv(kojinno, "", ref argconn1, ref newXML, ref rootElemRESULTXML);

                                    // 個人照会

                                    SQL = pubf_SQLGetKojin(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKOJIN", rootElemRESULTXML);
                                    }

                                    da = new SqlDataAdapter(SQL, conn);
                                    dt = new DataTable();
                                    da.Fill(dt);

                                    int num = dt.Rows.Count;
                                    if (num == 1)
                                    {
                                        string dsetaino = dt.Rows[0]["SETAINO"].ToString();
                                        // 世帯構成員情報取得
                                        SQL = pubf_SQLSetaiKosei(dsetaino);

                                        cmd = new SqlCommand(SQL, conn);

                                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                        {
                                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "MSETAI", rootElemRESULTXML);
                                        }
                                    }

                                    // 母子手帳番号一覧取得
                                    SQL = pubf_SQLGetTetyobango(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MTETYO", rootElemRESULTXML);
                                    }

                                    // 'プッシュ通知希望情報有無取得
                                    SQL = CM_kyotu_proc.pubf_SQLPush(kojinno, "1");

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPUSHF", rootElemRESULTXML);
                                    }

                                    // ジェノグラム情報有無取得
                                    SQL = CM_kyotu_proc.pubf_SQLGeno(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MGENOF", rootElemRESULTXML);
                                    }

                                    // 家族構成情報取得
                                    SQL = BHCO_kyotu_proc.pubf_SQLBhKazoku(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKAZOKUF", rootElemRESULTXML);
                                    }

                                    // 訪問指導情報の有無を取得する
                                    var argconn2 = conn;
                                    CM_kyotu_proc.pubf_GetHomonUmu(kojinno, ref argconn2, ref newXML, ref rootElemRESULTXML);

                                    // 健康相談情報の有無を取得する
                                    var argconn3 = conn;
                                    CM_kyotu_proc.pubf_GetSodanUmu(kojinno, ref argconn3, ref newXML, ref rootElemRESULTXML);

                                    // 関係機関情報取得
                                    SQL = BHCO_kyotu_proc.pubf_SQLBhKKikan(kojinno);

                                    cmd = new SqlCommand(SQL, conn);

                                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                    {
                                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MKKIKANF", rootElemRESULTXML);
                                    }
                                }

                                // 妊婦健診情報
                                SQL = pubf_SQLGetKojinNinpukensin(bnendo, bkofuno, bedano);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MNINKEN", rootElemRESULTXML);
                                }

                                // 要管理内容
                                SQL = pubf_SQLGetKojinYokanri(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MYOKANRI", rootElemRESULTXML);
                                }

                                // 要管理内容有メッセージ表示フラグ
                                SQL = pubf_SQLGetYokanriMsgFlg();

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MYKMSG", rootElemRESULTXML);
                                }

                                // 'フリー項目取得
                                SQL = BHCO_kyotu_proc.pubf_BhNsGetKojinFree(bnendo, bkofuno, "00", "044");

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREE", rootElemRESULTXML);
                                }

                                // 'オンライン申請情報取得
                                SQL = BHCO_kyotu_proc.pubf_BhNsGetKojinFree(bnendo, bkofuno, "10", "041");

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "MFREEONLINE", rootElemRESULTXML);
                                }

                                // 支援計画内容
                                SQL = pubf_SQLGetKojinSien(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIEN", rootElemRESULTXML);
                                }

                                // 支援計画プラン内容
                                SQL = pubf_SQLGetKojinSienPlan(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIENPLAN", rootElemRESULTXML);
                                }

                                // 支援計画内容(LISTへのチェック部分)
                                SQL = pubf_SQLGetKojinSienSub(bnendo, bkofuno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "SIENSUB", rootElemRESULTXML);
                                }

                                break;
                            }

                        default:
                            {
                                // 検索結果が複数ある場合
                                // 妊産婦検索　一覧情報を取得する
                                SQL = pubf_SQLGetNinpuKensaku(bnendo, bkofuno, bedano, seirino, bymd, kname, jokengyo, gyoseiku, jokenjumin, juminkubun, jokennenrei, kijunbi, nenreisql, jokentodokedesyusu, todokedesyusuFrom, todokedesyusuTo, jokentodokedebi, todokedebiFrom, todokedebiTo, jokenbunben, bunbenyoteibiFrom, bunbenyoteibiTo, jokenninpukenshinbi, ninpukenshinbiFrom, ninpukenshinbiTo, jokennninpukenshinhantei, ninpukenshinhantei, pno);

                                cmd = new SqlCommand(SQL, conn);

                                using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                                {
                                    CM_kyotu_proc.pub_CreateXML(dr, newXML, "KENSAKU", rootElemRESULTXML);
                                }

                                break;
                            }
                    }

                    // 対称キークローズ
                    var argconn4 = conn;
                    SqlTransaction argwkTrn1 = null;
                    CM_kyotu_proc.pubf_OpenSymKey(2, ref argconn4, wkTrn: ref argwkTrn1);
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            if (!string.IsNullOrEmpty(msg))
            {
                CM_kyotu_proc.pub_Status(0, 99, msg, newXML, "STATUS", rootElemRESULTXML);
                CM_kyotu_proc.pub_Log(userid, systemcd, Param, msg, "", "", "", pnoList);
            }
            else
            {
                CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
                CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), kojinno, "", "", pnoList);
            }

            return newXML;
        }

        /// <summary>
        /// 妊産婦検索一覧再取得
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <param name="edano">枝番号</param>
        /// <param name="sinkiflg">新規フラグ</param>
        /// <param name="seirino">整理番号</param>
        /// <param name="bymd">生年月日</param>
        /// <param name="kname">カナ氏名</param>
        /// <param name="jokengyo">行政区（条件あり/なし）</param>
        /// <param name="gyoseiku">行政区</param>
        /// <param name="jokenjumin">住民区分（条件あり/なし）</param>
        /// <param name="juminkubun">住民区分</param>
        /// <param name="jokennenrei">年齢範囲（条件あり/なし）</param>
        /// <param name="kijunbi">年齢基準日</param>
        /// <param name="nenrei">年齢</param>
        /// <param name="jokentodokedesyusu">届出週数（条件あり/なし）</param>
        /// <param name="todokedesyusuFrom">届出週数（From）</param>
        /// <param name="todokedesyusuTo">届出週数（To）</param>
        /// <param name="jokentodokedebi">届出日（条件あり/なし）</param>
        /// <param name="todokedebiFrom">届出日（From）</param>
        /// <param name="todokedebiTo">届出日（To）</param>
        /// <param name="jokenbunben">分娩予定日範囲（条件あり/なし）</param>
        /// <param name="bunbenyoteibiFrom">分娩予定日範囲（From）</param>
        /// <param name="bunbenyoteibiTo">分娩予定日範囲（To）</param>
        /// <param name="jokenninpukenshinbi">妊婦健診受診日範囲（条件あり/なし）</param>
        /// <param name="ninpukenshinbiFrom">妊婦健診受診日（From）</param>
        /// <param name="ninpukenshinbiTo">妊婦健診受診日（To）</param>
        /// <param name="jokennninpukenshinhantei">妊婦健診判定（条件あり/なし）</param>
        /// <param name="ninpukenshinhantei">妊婦健診判定</param>
        /// <param name="pno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_KensakuIchiran(string systemcd, string userid, string nendo, string kofuno, string edano, bool sinkiflg, string seirino, string bymd, string kname, string jokengyo, string[] gyoseiku, string jokenjumin, string[] juminkubun, string jokennenrei, string kijunbi, string nenrei, string jokentodokedesyusu, string todokedesyusuFrom, string todokedesyusuTo, string jokentodokedebi, string todokedebiFrom, string todokedebiTo, string jokenbunben, string bunbenyoteibiFrom, string bunbenyoteibiTo, string jokenninpukenshinbi, string ninpukenshinbiFrom, string ninpukenshinbiTo, string jokennninpukenshinhantei, string[] ninpukenshinhantei, string pno)

        {
            SqlCommand cmd;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string kojinno = "";
            string bnendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
            string bkofuno = kofuno;
            string bedano = edano;
            string Param;
            string SQL;
            string[] pnoList = null;

            if (Strings.Len(pno) > 0)
            {
                pnoList = new string[] { pno };
            }

            // ログパラメータ設定（個人番号はマスクする）
            Param = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("func_KensakuIchiran(" + systemcd + "," + userid + "," + nendo + "," + kofuno + "," + edano + "," + sinkiflg + "," + seirino + ",", Interaction.IIf(Strings.Len(pno) > 0, "************", "")), ")"));

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // 検索結果が複数ある場合
                    // 妊産婦検索　一覧情報を取得する
                    SQL = pubf_SQLGetNinpuKensaku(bnendo, bkofuno, bedano, seirino, bymd, kname, jokengyo, gyoseiku, jokenjumin, juminkubun, jokennenrei, kijunbi, nenrei, jokentodokedesyusu, todokedesyusuFrom, todokedesyusuTo, jokentodokedebi, todokedebiFrom, todokedebiTo, jokenbunben, bunbenyoteibiFrom, bunbenyoteibiTo, jokenninpukenshinbi, ninpukenshinbiFrom, ninpukenshinbiTo, jokennninpukenshinhantei, ninpukenshinhantei, pno);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "KENSAKU", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), kojinno, "", "", pnoList);
            return newXML;
        }

        /// <summary>
        /// 妊婦情報入力で編集した内容を各テーブルに更新する
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="sinkiflg">新規フラグ</param>
        /// <param name="kensakuList">検索条件項目</param>
        /// <param name="headerItemList">ヘッダー入力項目</param>
        /// <param name="ninputitioyaList">妊婦・父親情報</param>
        /// <param name="syuroujyokyoList">就労状況</param>
        /// <param name="syusseirekiList">出生歴</param>
        /// <param name="ninsinrekiList">妊娠歴</param>
        /// <param name="kazokudokyoList">家族環境・同居の家族</param>
        /// <param name="ninsinkiouList">妊娠既往歴</param>
        /// <param name="syusoList">主訴</param>
        /// <param name="sintyotaijuList">身長・体重</param>
        /// <param name="gakkyuList">母親学級</param>
        /// <param name="sippeijyokyoList">現在の疾病治療状況</param>
        /// <param name="hokensidoList">保健指導</param>
        /// <param name="ninpukensinList">妊婦健康診査情報</param>
        /// <param name="nsItemList">妊産婦動的入力</param>
        /// <param name="sanpukensin1List">産婦健康診査情報(１ヶ月)</param>
        /// <param name="sanpukensin3List">産婦健康診査情報(３ヶ月)	</param>
        /// <param name="monsinList">問診</param>
        /// <param name="sougoukoment">総合コメント</param>
        /// <param name="freeitemcd">フリー項目ＩＤ</param>
        /// <param name="inputdata">フリー項目入力値</param>
        /// <param name="datatype">フリー項目データタイプ</param>
        /// <param name="freeitemcdOnline">オンライン申請情報ＩＤ</param>
        /// <param name="inputOnlinedata">オンライン申請情報入力値</param>
        /// <param name="datatypeOnline">オンライン申請情報データタイプ</param>
        /// <param name="sienList">支援計画</param>
        /// <param name="sienCheckList">支援計画(チェック項目)</param>
        /// <param name="sienPlanList">支援計画(プラン)</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Toroku(string systemcd, string userid, string sinkiflg, string[] kensakuList, string[] headerItemList, string[] ninputitioyaList, string[] syuroujyokyoList, string[] syusseirekiList, string[] ninsinrekiList, string[] kazokudokyoList, string[] ninsinkiouList, string[] syusoList, string[] sintyoTaijuList, string[] gakkyuList, string[] sippeijyokyoList, string[] hokensidoList, string[] ninpukensinList, string nsItemList, string[] sanpukensin1List, string[] sanpukensin3List, string[] monsinList, string sougoukoment, string freeitemcd, string inputdata, string datatype, string freeitemcdOnline, string inputOnlinedata, string datatypeOnline, string[] sienList, string[] sienCheckList, string[] sienPlanList)

        {
            SqlCommand cmd;
            SqlTransaction wkTrn;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL = "";
            string Param;
            SqlDataAdapter da;
            DataTable dt;
            int i = 0;

            string bnendo = CM_kyotu_proc.pubf_CnvSeireki(kensakuList[0]).ToString();
            string bkofuno = kensakuList[1];
            string bedano = kensakuList[2];
            string kojinno = kensakuList[3];
            string kofukbn = kensakuList[4];

            // ログパラメータの設定
            Param = "func_Toroku(" + ninsinrekiList[0] + ")";

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    // 妊婦発行情報マスタ(TM_BHNSHAKKO)の更新(Delete-Insert)
                    // 妊婦発行情報マスタ(TM_BHNSHAKKO)の削除
                    SQL = pubf_SQLDeleteBhbhakko(bnendo, bkofuno, bedano);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊婦発行情報マスタ(TM_BHNSHAKKO)へ追加
                    var hakkoInsertParam = new string[] { bnendo, bkofuno, bedano, userid, headerItemList[19] };
                    SQL = pubf_SQLInsertBhbhakko(hakkoInsertParam);

                    // '処理実行
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 血族結婚フラグ
                    string ketuzoku = ninputitioyaList[0];
                    // 妊婦
                    var ninpuData = Strings.Split(ninputitioyaList[1], CM_kyotu_proc.MAIN_DELIMITER);
                    // 父親
                    var titioyaData = Strings.Split(ninputitioyaList[2], CM_kyotu_proc.MAIN_DELIMITER);
                    // 子
                    var koData = Strings.Split(ninputitioyaList[3], CM_kyotu_proc.MAIN_DELIMITER);
                    // 保護者
                    var hogoData = Strings.Split(ninputitioyaList[4], CM_kyotu_proc.MAIN_DELIMITER);

                    // 妊産婦基本情報管理マスタ(TM_BHNSKIHON)の更新
                    SQL = pubf_SQLDeleteKihon(bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    var InsertParam_BHNSKIHON = new string[73];
                    InsertParam_BHNSKIHON[0] = bnendo;                 // 母子手帳年度
                    InsertParam_BHNSKIHON[1] = bkofuno;                // 母子手帳交付番号
                    InsertParam_BHNSKIHON[2] = 1.ToString();                      // 枝番号
                    InsertParam_BHNSKIHON[3] = kofukbn;                // 新規交付
                    InsertParam_BHNSKIHON[4] = ketuzoku;               // 血族結婚フラグ
                    InsertParam_BHNSKIHON[5] = ninpuData[0];           // 母個人番号
                    InsertParam_BHNSKIHON[6] = titioyaData[0];         // 父個人番号
                    InsertParam_BHNSKIHON[7] = ninpuData[13];          // 里帰り
                    InsertParam_BHNSKIHON[8] = ninpuData[15];          // 里帰り住所
                    InsertParam_BHNSKIHON[9] = ninpuData[14];          // 里帰り世帯主
                    InsertParam_BHNSKIHON[10] = ninpuData[16];         // 里帰り電話番号
                    InsertParam_BHNSKIHON[11] = headerItemList[0];     // 訪問希望
                    InsertParam_BHNSKIHON[12] = headerItemList[1];     // 担当保健師
                    InsertParam_BHNSKIHON[13] = headerItemList[2];     // 母子推進委員
                    InsertParam_BHNSKIHON[14] = headerItemList[3];     // 通知希望フラグ
                    InsertParam_BHNSKIHON[15] = headerItemList[4];     // 無効フラグ
                    InsertParam_BHNSKIHON[16] = headerItemList[5];     // 無効理由
                    InsertParam_BHNSKIHON[17] = headerItemList[6];     // 届出年月日
                    InsertParam_BHNSKIHON[18] = headerItemList[7];     // 妊娠週数
                    InsertParam_BHNSKIHON[19] = headerItemList[8];     // 分娩後フラグ
                    InsertParam_BHNSKIHON[20] = headerItemList[9];     // 保険区分
                    InsertParam_BHNSKIHON[21] = headerItemList[10];    // 本人フラグ
                    InsertParam_BHNSKIHON[22] = headerItemList[11];    // 最終月経年月日
                    InsertParam_BHNSKIHON[23] = headerItemList[12];    // 市手帳
                    InsertParam_BHNSKIHON[24] = headerItemList[13];    // 県手帳
                    InsertParam_BHNSKIHON[25] = headerItemList[14];    // 分娩予定年月日
                    InsertParam_BHNSKIHON[26] = headerItemList[15];    // 分娩予定場所
                    InsertParam_BHNSKIHON[27] = headerItemList[16];    // 分娩予定場所その他
                    InsertParam_BHNSKIHON[28] = headerItemList[17];    // 発行区分
                    InsertParam_BHNSKIHON[29] = headerItemList[18];    // 発行場所
                    InsertParam_BHNSKIHON[30] = syuroujyokyoList[0];   // 勤務先
                    InsertParam_BHNSKIHON[31] = syuroujyokyoList[4];   // 勤務区分
                    InsertParam_BHNSKIHON[32] = syuroujyokyoList[5];   // 勤務先電話番号
                    InsertParam_BHNSKIHON[33] = syuroujyokyoList[1];   // 出産前休暇週数
                    InsertParam_BHNSKIHON[34] = syuroujyokyoList[2];   // 出産後休暇週数
                    InsertParam_BHNSKIHON[35] = syuroujyokyoList[6];   // 退職予定年月日
                    InsertParam_BHNSKIHON[36] = syuroujyokyoList[7];   // 育児休業
                    InsertParam_BHNSKIHON[37] = syuroujyokyoList[3];   // 仕事内容
                    InsertParam_BHNSKIHON[38] = syuroujyokyoList[8];   // 通勤方法
                    InsertParam_BHNSKIHON[39] = syuroujyokyoList[9];   // 通勤時間
                    InsertParam_BHNSKIHON[40] = kazokudokyoList[1];    // ペット
                    InsertParam_BHNSKIHON[41] = kazokudokyoList[2];    // ペットコメント
                    InsertParam_BHNSKIHON[42] = kazokudokyoList[3];    // 園名
                    InsertParam_BHNSKIHON[43] = kazokudokyoList[4];    // 住居
                    InsertParam_BHNSKIHON[44] = kazokudokyoList[5];    // 階建
                    InsertParam_BHNSKIHON[45] = kazokudokyoList[6];    // 階数
                    InsertParam_BHNSKIHON[46] = kazokudokyoList[7];    // 騒音
                    InsertParam_BHNSKIHON[47] = kazokudokyoList[8];    // 日当り
                    InsertParam_BHNSKIHON[48] = ninsinkiouList[0];     // 既往疾患
                    InsertParam_BHNSKIHON[49] = ninsinkiouList[1];     // 既往疾患その他
                    InsertParam_BHNSKIHON[72] = ninsinkiouList[7];     // 妊娠高血圧症候群
                    InsertParam_BHNSKIHON[50] = ninsinkiouList[2];     // 妊娠中毒
                    InsertParam_BHNSKIHON[51] = ninsinkiouList[3];     // 妊娠ＨＢＳ抗原
                    InsertParam_BHNSKIHON[52] = ninsinkiouList[4];     // 妊娠産褥期
                    InsertParam_BHNSKIHON[53] = ninsinkiouList[5];     // ＡＴＬ
                    InsertParam_BHNSKIHON[54] = ninsinkiouList[6];     // 既往その他
                    InsertParam_BHNSKIHON[55] = sintyoTaijuList[0];    // 身長
                    InsertParam_BHNSKIHON[56] = sintyoTaijuList[1];    // 体重妊娠前
                    InsertParam_BHNSKIHON[57] = sintyoTaijuList[2];    // 体重分娩時
                    InsertParam_BHNSKIHON[58] = sintyoTaijuList[3];    // ＢＭＩ
                    InsertParam_BHNSKIHON[59] = hokensidoList[0];      // 育児協力
                    InsertParam_BHNSKIHON[60] = hokensidoList[1];      // 協力者
                    InsertParam_BHNSKIHON[61] = hokensidoList[2];      // 保健指導担当者１
                    InsertParam_BHNSKIHON[62] = hokensidoList[3];      // 保健指導担当者２
                    InsertParam_BHNSKIHON[63] = hokensidoList[4];      // 飲酒種類
                    InsertParam_BHNSKIHON[64] = hokensidoList[5];      // 飲酒量
                    InsertParam_BHNSKIHON[65] = hokensidoList[6];      // 喫煙数
                    InsertParam_BHNSKIHON[66] = hokensidoList[7];      // 栄養強化対象
                    InsertParam_BHNSKIHON[67] = hokensidoList[8];      // 偏食
                    InsertParam_BHNSKIHON[68] = hokensidoList[9];      // 牛乳
                    InsertParam_BHNSKIHON[69] = hokensidoList[10];     // 牛乳量
                    InsertParam_BHNSKIHON[70] = hokensidoList[11];     // 保健指導コメント
                    InsertParam_BHNSKIHON[71] = sougoukoment;          // 総合コメント

                    // 妊産婦基本情報管理マスタの作成
                    SQL = pubf_SQLBhnskihon(InsertParam_BHNSKIHON);

                    // 処理実行
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦出生歴管理マスタの削除
                    SQL = pubf_SQLDeleteSyussyo(bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦出生歴管理マスタ(TM_BHNSSYUSSYO)の更新
                    if (!string.IsNullOrEmpty(syusseirekiList[0]))
                    {
                        string syusseirekiRowData = syusseirekiList[0];
                        var syusseirekiStr = Strings.Split(syusseirekiRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦出生歴管理マスタの作成
                        var loopTo = syusseirekiStr.Length - 1;
                        for (i = 0; i <= loopTo; i++)
                        {
                            var syussyoreki = Strings.Split(syusseirekiStr[i], CM_kyotu_proc.SUB1_DELIMITER);
                            var syussyorekiInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), syussyoreki[0], kojinno, syussyoreki[1], syussyoreki[2], syussyoreki[3], syussyoreki[4], syussyoreki[5], syussyoreki[6] };

                            SQL = pubf_SQLInsertSyussyo(syussyorekiInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦妊娠歴管理マスタの削除
                    SQL = pubf_SQLDeleteNinreki(bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦妊娠歴管理マスタ(TM_BHNSNINREKI)の更新
                    if (!string.IsNullOrEmpty(ninsinrekiList[0]))
                    {
                        string ninsinrekiRowData = ninsinrekiList[0];
                        var ninsinrekiStr = Strings.Split(ninsinrekiRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦妊娠歴管理マスタの作成
                        var loopTo1 = ninsinrekiStr.Length - 1;
                        for (i = 0; i <= loopTo1; i++)
                        {
                            var ninsinreki = Strings.Split(ninsinrekiStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var ninsinrekiInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), (i + 1).ToString(), kojinno, ninsinreki[0], ninsinreki[1], ninsinreki[2], ninsinreki[3], ninsinreki[4] };

                            SQL = pubf_SQLInsertNinreki(ninsinrekiInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦同居管理マスタの削除
                    SQL = pubf_SQLDeleteDokyo(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦同居管理マスタ(TM_BHNSDOKYO)の更新
                    if (!string.IsNullOrEmpty(kazokudokyoList[0]))
                    {
                        string kazokudokyoListRowData = kazokudokyoList[0];
                        var kazokudokyoStr = Strings.Split(kazokudokyoListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦同居管理マスタの作成
                        var loopTo2 = kazokudokyoStr.Length - 1;
                        for (i = 0; i <= loopTo2; i++)
                        {
                            var kazokudokyo = Strings.Split(kazokudokyoStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var kazokudokyoInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), (i + 1).ToString(), kazokudokyo[0], kazokudokyo[1], kazokudokyo[2], kazokudokyo[3], kazokudokyo[4], kazokudokyo[5], kazokudokyo[6] };

                            SQL = pubf_SQLInsertDokyo(kazokudokyoInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦主訴管理マスタの削除
                    SQL = pubf_SQLDeleteSyuso(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // '妊産婦主訴管理マスタ(TM_BHNSSYUSO)の更新
                    if (!string.IsNullOrEmpty(syusoList[0]))
                    {
                        string syusoListRowData = syusoList[0];
                        var syusoStr = Strings.Split(syusoListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦主訴管理マスタの作成
                        var loopTo3 = syusoStr.Length - 1;
                        for (i = 0; i <= loopTo3; i++)
                        {
                            var syuso = Strings.Split(syusoStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var syusoInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), syuso[0], syuso[1] };

                            SQL = pubf_SQLInsertSyuso(syusoInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦母親学級管理マスタの削除
                    SQL = pubf_SQLDeleteGakkyu(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦母親学級管理マスタ(TM_BHNSGAKKYU)の更新
                    if (!string.IsNullOrEmpty(gakkyuList[0]))
                    {
                        string gakkyuListRowData = gakkyuList[0];
                        var gakkyuStr = Strings.Split(gakkyuListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦母親学級管理マスタの作成
                        var loopTo4 = gakkyuStr.Length - 1;
                        for (i = 0; i <= loopTo4; i++)
                        {
                            var gakkyu = Strings.Split(gakkyuStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var gakkyuInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), gakkyu[0], gakkyu[1], gakkyu[2], gakkyu[3], gakkyu[4], gakkyu[5], gakkyu[6], gakkyu[7] };

                            SQL = pubf_SQLInsertGakkyu(gakkyuInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦疾病状況管理マスタの削除
                    SQL = pubf_SQLDeleteSippei(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦疾病状況管理マスタ(TM_BHNSSIPPEI)の更新
                    if (!string.IsNullOrEmpty(sippeijyokyoList[0]))
                    {
                        string sippeijyokyoListRowData = sippeijyokyoList[0];
                        var sippeijyokyoStr = Strings.Split(sippeijyokyoListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦疾病状況管理マスタの作成
                        var loopTo5 = sippeijyokyoStr.Length - 1;
                        for (i = 0; i <= loopTo5; i++)
                        {
                            var sippeijyokyo = Strings.Split(sippeijyokyoStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var sippeijyokyoInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), sippeijyokyo[0], sippeijyokyo[1], sippeijyokyo[2], sippeijyokyo[3] };

                            SQL = pubf_SQLInsertSippei(sippeijyokyoInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦要管理内容管理マスタの削除
                    SQL = pubf_SQLDeleteYokanri(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦要管理内容管理マスタ(TM_BHNSYOKANRI)の更新
                    if (!string.IsNullOrEmpty(hokensidoList[12]))
                    {
                        string yokanriListRowData = hokensidoList[12];
                        var yokanriStr = Strings.Split(yokanriListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦疾病状況管理マスタの作成
                        var loopTo6 = yokanriStr.Length - 1;
                        for (i = 0; i <= loopTo6; i++)
                        {
                            var yokanri = Strings.Split(yokanriStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var yokanriInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), yokanri[0], yokanri[1], yokanri[2], yokanri[3], yokanri[4] };

                            SQL = pubf_SQLInsertYokanri(yokanriInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊産婦保健指導管理マスタの削除
                    SQL = pubf_SQLDeleteSido(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊産婦保健指導管理マスタ(TM_BHNSSIDO)の更新
                    if (!string.IsNullOrEmpty(hokensidoList[13]))
                    {
                        string sidoListRowData = hokensidoList[13];
                        var sidoStr = Strings.Split(sidoListRowData, CM_kyotu_proc.MAIN_DELIMITER);

                        // 妊産婦保健指導管理マスタの作成
                        var loopTo7 = sidoStr.Length - 1;
                        for (i = 0; i <= loopTo7; i++)
                        {
                            var sido = Strings.Split(sidoStr[i], CM_kyotu_proc.SUB1_DELIMITER);

                            var sidoInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), sido[0], sido[1], sido[2], sido[3], sido[4], sido[5] };

                            SQL = pubf_SQLInsertSido(sidoInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊婦健診管理マスタの削除
                    SQL = pubf_SQLDeleteNinken(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊婦健診管理マスタ(TM_BHNSNINKEN)の更新
                    if (!string.IsNullOrEmpty(ninpukensinList[0]))
                    {
                        // 妊婦健診管理マスタの作成
                        var loopTo8 = ninpukensinList.Length - 1;
                        for (i = 0; i <= loopTo8; i++)
                        {
                            string ninpukensinData = ninpukensinList[i];
                            var ninpukensin = Strings.Split(ninpukensinData, CM_kyotu_proc.MAIN_DELIMITER);

                            var ninpukensinInsertParam = new string[] { bnendo, bkofuno, 1.ToString(), ninpukensin[0], ninpukensin[1], ninpukensin[2], ninpukensin[3], ninpukensin[4], ninpukensin[5], ninpukensin[6], ninpukensin[7], ninpukensin[8], ninpukensin[9], ninpukensin[10], ninpukensin[11], ninpukensin[12], ninpukensin[13], ninpukensin[14], ninpukensin[15], ninpukensin[16], ninpukensin[17], ninpukensin[18], ninpukensin[19], ninpukensin[20], ninpukensin[21], ninpukensin[22], ninpukensin[23], ninpukensin[24], ninpukensin[25], ninpukensin[26], ninpukensin[27], ninpukensin[28], ninpukensin[29], ninpukensin[30], ninpukensin[31], ninpukensin[32], ninpukensin[33], ninpukensin[34], ninpukensin[35], ninpukensin[36], ninpukensin[37], ninpukensin[38], ninpukensin[39], ninpukensin[40], ninpukensin[41], ninpukensin[42], ninpukensin[43], ninpukensin[44], ninpukensin[45], ninpukensin[46], ninpukensin[47], ninpukensin[48], ninpukensin[49], ninpukensin[50], ninpukensin[51], ninpukensin[52] };

                            SQL = pubf_SQLInsertNinken(ninpukensinInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // ****************************
                    // * 妊産婦動的項目管理マスタ登録処理
                    // ****************************
                    foreach (string nsItemRow in Strings.Split(nsItemList, CM_kyotu_proc.MAIN_DELIMITER))
                    {
                        if (!string.IsNullOrEmpty(nsItemRow))
                        {
                            // パラメータの分割(カラム単位)
                            var nsItem = Strings.Split(nsItemRow, CM_kyotu_proc.SUB1_DELIMITER);

                            string kenkaisu = nsItem[0];
                            string itemcd = nsItem[1];
                            string itemeda = nsItem[2];

                            // 乳幼児動的項目管理マスタの存在チェック
                            SQL = pubf_SQLGetCountTM_BHNSITEM(bnendo, bkofuno, kenkaisu, itemcd, itemeda);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;

                            da = new SqlDataAdapter(cmd);
                            dt = new DataTable();
                            da.Fill(dt);

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dt.Rows[0]["CNT"], 0, false)))
                            {
                                // 妊産婦動的項目管理マスタの登録処理
                                var InsertParam_TM_BHNSITEM = new string[12];
                                InsertParam_TM_BHNSITEM[0] = bnendo;      // 母子手帳年度
                                InsertParam_TM_BHNSITEM[1] = bkofuno;     // 母子手帳交付番号
                                InsertParam_TM_BHNSITEM[2] = "1";         // 枝番号
                                InsertParam_TM_BHNSITEM[3] = kenkaisu;    // 健診回数
                                InsertParam_TM_BHNSITEM[4] = itemcd;      // 項目ＣＤ
                                InsertParam_TM_BHNSITEM[5] = itemeda;     // 項目枝番
                                InsertParam_TM_BHNSITEM[6] = nsItem[3];   // データタイプ１
                                InsertParam_TM_BHNSITEM[7] = nsItem[4];   // データタイプ２
                                InsertParam_TM_BHNSITEM[8] = nsItem[5];   // データタイプ３
                                InsertParam_TM_BHNSITEM[9] = nsItem[6];   // データタイプ４
                                InsertParam_TM_BHNSITEM[10] = CM_kyotu_proc.pubf_CnvSeirekiYMD(nsItem[7]);  // データタイプ５

                                SQL = pubf_SQLInsertTM_BHNSITEM(InsertParam_TM_BHNSITEM);

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // 妊産婦動的項目管理マスタの登録処理
                                var UpdateParam_TM_BHNYITEM = new string[12];
                                UpdateParam_TM_BHNYITEM[0] = bnendo;      // 母子手帳年度
                                UpdateParam_TM_BHNYITEM[1] = bkofuno;     // 母子手帳交付番号
                                UpdateParam_TM_BHNYITEM[2] = "1";         // 枝番号
                                UpdateParam_TM_BHNYITEM[3] = kenkaisu;    // 健診回数
                                UpdateParam_TM_BHNYITEM[4] = itemcd;      // 項目ＣＤ
                                UpdateParam_TM_BHNYITEM[5] = itemeda;     // 項目枝番
                                UpdateParam_TM_BHNYITEM[6] = nsItem[3];   // データタイプ１
                                UpdateParam_TM_BHNYITEM[7] = nsItem[4];   // データタイプ２
                                UpdateParam_TM_BHNYITEM[8] = nsItem[5];   // データタイプ３
                                UpdateParam_TM_BHNYITEM[9] = nsItem[6];   // データタイプ４
                                UpdateParam_TM_BHNYITEM[10] = CM_kyotu_proc.pubf_CnvSeirekiYMD(nsItem[7]);  // データタイプ５

                                SQL = pubf_SQLUpdateTM_BHNSITEM(UpdateParam_TM_BHNYITEM);

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 産婦健診管理マスタの削除
                    SQL = pubf_SQLDeleteSanpu(bnendo, bkofuno);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 産婦健診管理マスタ(TM_BHNSSANPU)の更新
                    if (!string.IsNullOrEmpty(sanpukensin1List[0]) | !string.IsNullOrEmpty(sanpukensin3List[0]))
                    {
                        var sanpukensin1InsertParam = new string[] { bnendo, bkofuno, 1.ToString(), sanpukensin1List[0], sanpukensin1List[1], sanpukensin1List[2], sanpukensin1List[3], sanpukensin1List[4], sanpukensin1List[5], sanpukensin1List[6], sanpukensin1List[7], sanpukensin1List[8], sanpukensin1List[9], sanpukensin1List[10], sanpukensin1List[11], sanpukensin1List[12], sanpukensin1List[13], sanpukensin1List[14], sanpukensin1List[15], sanpukensin1List[16], sanpukensin1List[17], sanpukensin1List[18], sanpukensin1List[19], sanpukensin1List[20], sanpukensin1List[21], sanpukensin1List[22] };

                        // 産婦健診管理マスタの作成 (産婦健康診査情報(１ヶ月))
                        SQL = pubf_SQLInsertSanpu(sanpukensin1InsertParam);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        var sanpukensin3InsertParam = new string[] { bnendo, bkofuno, 1.ToString(), sanpukensin3List[0], sanpukensin3List[1], sanpukensin3List[2], sanpukensin3List[3], sanpukensin3List[4], sanpukensin3List[5], sanpukensin3List[6], sanpukensin3List[7], sanpukensin3List[8], sanpukensin3List[9], sanpukensin3List[10], sanpukensin3List[11], sanpukensin3List[12], sanpukensin3List[13], sanpukensin3List[14], sanpukensin3List[15], sanpukensin3List[16], sanpukensin3List[17], sanpukensin3List[18], sanpukensin3List[19], sanpukensin3List[20], sanpukensin3List[21], sanpukensin3List[22] };

                        // 産婦健診管理マスタの作成 (産婦健康診査情報(３ヶ月))
                        SQL = pubf_SQLInsertSanpu(sanpukensin3InsertParam);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }

                    // 妊婦父親情報の更新
                    // 妊婦父親区分（1:父親, 2:妊婦, 3:子, 4:保護者）
                    string ninpuTitiKkbn = KBN_HAHA;
                    // 住民 or 住登外（整理番号が空の場合、住登外とする）
                    if (!string.IsNullOrEmpty(ninpuData[0]))
                    {
                        // 妊産婦住登外父母情報管理マスタの母親情報削除
                        // (妊産婦を変更された場合を考慮し、住登外情報を削除する)
                        SQL = pubf_SQLDeleteJyutogai(bnendo, bkofuno, ninpuTitiKkbn);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 宛名サブマスタ（個人）
                        var updateParam_TM_KKKOJIN_SUB = new string[9];
                        updateParam_TM_KKKOJIN_SUB[0] = userid;            // 操作者ＩＤ
                        updateParam_TM_KKKOJIN_SUB[1] = ninpuData[9];      // 電話番号１
                        updateParam_TM_KKKOJIN_SUB[2] = ninpuData[10];     // 電話番号２
                        updateParam_TM_KKKOJIN_SUB[3] = ninpuData[11];     // メールアドレス１
                        updateParam_TM_KKKOJIN_SUB[4] = ninpuData[12];     // メールアドレス２
                        updateParam_TM_KKKOJIN_SUB[5] = ninpuData[4];      // 血液型
                        updateParam_TM_KKKOJIN_SUB[6] = "";                // 職業
                        updateParam_TM_KKKOJIN_SUB[7] = "";                // 勤務先

                        SQL = pubf_SQLUpdateKojinSub(ninpuTitiKkbn, ninpuData[0], updateParam_TM_KKKOJIN_SUB);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 宛名サブマスタ（世帯）
                        var setaiSubUpdateParamNinpu = new string[] { ninpuData[6], ninpuData[7] };
                        SQL = pubf_SQLUpdateSetaiSub(userid, ninpuData[0], setaiSubUpdateParamNinpu);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // 'カナ氏名が未入力の場合は登録しない
                        // If ninpuData(1) <> "" Then
                        // 妊産婦住登外父母情報管理マスタの母親情報削除
                        SQL = pubf_SQLDeleteJyutogai(bnendo, bkofuno, ninpuTitiKkbn);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        var jyutogaiParamNinpu = new string[19];
                        jyutogaiParamNinpu[0] = bnendo;
                        jyutogaiParamNinpu[1] = bkofuno;
                        jyutogaiParamNinpu[2] = 1.ToString();
                        jyutogaiParamNinpu[3] = ninpuTitiKkbn;
                        jyutogaiParamNinpu[4] = ninpuData[1];                    // カナ氏名
                        jyutogaiParamNinpu[5] = CM_kyotu_proc.pubf_CnvKana(1, ninpuData[1]);   // 検索用カナ氏名
                        jyutogaiParamNinpu[6] = ninpuData[2];
                        jyutogaiParamNinpu[7] = CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpuData[3]);
                        jyutogaiParamNinpu[8] = ninpuData[5];
                        jyutogaiParamNinpu[9] = ninpuData[8];
                        jyutogaiParamNinpu[10] = ninpuData[6];
                        jyutogaiParamNinpu[11] = ninpuData[7];
                        jyutogaiParamNinpu[12] = ninpuData[9];
                        jyutogaiParamNinpu[13] = ninpuData[10];
                        jyutogaiParamNinpu[14] = ninpuData[11];
                        jyutogaiParamNinpu[15] = ninpuData[12];
                        jyutogaiParamNinpu[16] = ninpuData[4];
                        jyutogaiParamNinpu[17] = "";
                        jyutogaiParamNinpu[18] = "";

                        // 妊産婦住登外父母情報管理マスタ
                        SQL = pubf_SQLInsertJyutogai(jyutogaiParamNinpu);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                        // End If
                    }

                    // 父親
                    // 妊婦父親区分（1:父親, 2:妊婦, 3:子, 4:保護者）
                    ninpuTitiKkbn = KBN_TITI;
                    if (!string.IsNullOrEmpty(titioyaData[0]))
                    {
                        // 妊産婦住登外父母情報管理マスタの父親情報削除
                        // (父親を変更された場合を考慮し、住登外情報を削除する)
                        SQL = pubf_SQLDeleteJyutogai(bnendo, bkofuno, ninpuTitiKkbn);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 宛名サブマスタ（個人）
                        var updateParam_TM_KKKOJIN_SUB = new string[9];
                        updateParam_TM_KKKOJIN_SUB[0] = userid;            // 操作者ＩＤ
                        updateParam_TM_KKKOJIN_SUB[1] = titioyaData[9];    // 電話番号１
                        updateParam_TM_KKKOJIN_SUB[2] = titioyaData[10];   // 電話番号２
                        updateParam_TM_KKKOJIN_SUB[3] = titioyaData[11];   // メールアドレス１
                        updateParam_TM_KKKOJIN_SUB[4] = titioyaData[12];   // メールアドレス２
                        updateParam_TM_KKKOJIN_SUB[5] = titioyaData[4];    // 血液型
                        updateParam_TM_KKKOJIN_SUB[6] = titioyaData[13];   // 職業
                        updateParam_TM_KKKOJIN_SUB[7] = titioyaData[14];   // 勤務先

                        SQL = pubf_SQLUpdateKojinSub(ninpuTitiKkbn, titioyaData[0], updateParam_TM_KKKOJIN_SUB);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 宛名サブマスタ（世帯）
                        var setaiSubUpdateParamTiti = new string[] { titioyaData[6], titioyaData[7] };
                        SQL = pubf_SQLUpdateSetaiSub(userid, titioyaData[0], setaiSubUpdateParamTiti);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // カナ氏名が未入力の場合は登録しない
                        // If titioyaData(1) <> "" Then
                        // 妊産婦住登外父母情報管理マスタの父親情報削除
                        SQL = pubf_SQLDeleteJyutogai(bnendo, bkofuno, ninpuTitiKkbn);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        var jyutogaiParamTiti = new string[19];
                        jyutogaiParamTiti[0] = bnendo;
                        jyutogaiParamTiti[1] = bkofuno;
                        jyutogaiParamTiti[2] = 1.ToString();
                        jyutogaiParamTiti[3] = ninpuTitiKkbn;
                        jyutogaiParamTiti[4] = titioyaData[1];                       // カナ氏名
                        jyutogaiParamTiti[5] = CM_kyotu_proc.pubf_CnvKana(1, titioyaData[1]);      // 検索用カナ氏名
                        jyutogaiParamTiti[6] = titioyaData[2];
                        jyutogaiParamTiti[7] = CM_kyotu_proc.pubf_CnvSeirekiYMD(titioyaData[3]);
                        jyutogaiParamTiti[8] = titioyaData[5];
                        jyutogaiParamTiti[9] = titioyaData[8];
                        jyutogaiParamTiti[10] = titioyaData[6];
                        jyutogaiParamTiti[11] = titioyaData[7];
                        jyutogaiParamTiti[12] = titioyaData[9];
                        jyutogaiParamTiti[13] = titioyaData[10];
                        jyutogaiParamTiti[14] = titioyaData[11];
                        jyutogaiParamTiti[15] = titioyaData[12];
                        jyutogaiParamTiti[16] = titioyaData[4];
                        jyutogaiParamTiti[17] = titioyaData[13];
                        jyutogaiParamTiti[18] = titioyaData[14];

                        // 妊産婦住登外父母情報管理マスタの作成
                        SQL = pubf_SQLInsertJyutogai(jyutogaiParamTiti);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }

                    // 子
                    ninpuTitiKkbn = KBN_KO;
                    if (!string.IsNullOrEmpty(koData[0]))
                    {
                        // 宛名サブマスタ（個人）
                        var kojinSubUpdateParamKo = new string[] { koData[2], koData[3], koData[4], koData[5], "" };
                        var updateParam_TM_KKKOJIN_SUB = new string[9];
                        updateParam_TM_KKKOJIN_SUB[0] = userid;            // 操作者ＩＤ
                        updateParam_TM_KKKOJIN_SUB[1] = koData[2];         // 電話番号１
                        updateParam_TM_KKKOJIN_SUB[2] = koData[3];         // 電話番号２
                        updateParam_TM_KKKOJIN_SUB[3] = koData[4];         // メールアドレス１
                        updateParam_TM_KKKOJIN_SUB[4] = koData[5];         // メールアドレス２
                        updateParam_TM_KKKOJIN_SUB[5] = "";                // 血液型
                        updateParam_TM_KKKOJIN_SUB[6] = "";                // 職業
                        updateParam_TM_KKKOJIN_SUB[7] = "";                // 勤務先

                        SQL = pubf_SQLUpdateKojinSub(ninpuTitiKkbn, koData[0], updateParam_TM_KKKOJIN_SUB);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 宛名サブマスタ（世帯）
                        var setaiSubUpdateParamKo = new string[] { koData[1], koData[6] };
                        SQL = pubf_SQLUpdateSetaiSub(userid, koData[0], setaiSubUpdateParamKo);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }

                    // 保護者
                    ninpuTitiKkbn = KBN_HOGO;
                    if (!string.IsNullOrEmpty(koData[0]))
                    {
                        // 子が登録されていない場合更新しない
                        // 宛名サブマスタ（個人）
                        var updateParam_TM_KKKOJIN_SUB_HOGO = new string[9];
                        updateParam_TM_KKKOJIN_SUB_HOGO[0] = userid;            // 操作者ＩＤ
                        updateParam_TM_KKKOJIN_SUB_HOGO[1] = hogoData[0];       // 整理番号
                        updateParam_TM_KKKOJIN_SUB_HOGO[2] = hogoData[1];       // カナ氏名
                        updateParam_TM_KKKOJIN_SUB_HOGO[3] = hogoData[2];       // 氏名
                        updateParam_TM_KKKOJIN_SUB_HOGO[4] = hogoData[3];       // 生年月日
                        updateParam_TM_KKKOJIN_SUB_HOGO[5] = hogoData[4];       // 住所
                        updateParam_TM_KKKOJIN_SUB_HOGO[6] = hogoData[5];       // 電話番号
                        updateParam_TM_KKKOJIN_SUB_HOGO[7] = hogoData[6];       // 続柄

                        SQL = pubf_SQLUpdateKojinSub(ninpuTitiKkbn, koData[0], updateParam_TM_KKKOJIN_SUB_HOGO);
                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }

                    // 妊産婦問診管理マスタ（TM_BHNSMONSIN）の新規作成・修正(delete_insert)
                    if (!string.IsNullOrEmpty(monsinList[0]))
                    {
                        // 妊産婦問診管理マスタの削除
                        SQL = pubf_SQLDeleteMonsin(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // 妊産婦問診管理マスタの作成
                        var loopTo9 = monsinList.Length - 1;
                        for (i = 0; i <= loopTo9; i++)
                        {
                            var monsin = Strings.Split(monsinList[i], CM_kyotu_proc.MAIN_DELIMITER);

                            var monsinInsertParam = new string[] { bnendo, bkofuno, bedano, monsin[1], monsin[2], monsin[3], monsin[4], monsin[5], monsin[6], monsin[7], monsin[8] };

                            SQL = pubf_SQLInsertMonsin(monsinInsertParam);

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    var splItemcd = Strings.Split(freeitemcd, CM_kyotu_proc.MAIN_DELIMITER);
                    var splData = Strings.Split(inputdata, CM_kyotu_proc.MAIN_DELIMITER);
                    var splDatatype = Strings.Split(datatype, CM_kyotu_proc.MAIN_DELIMITER);

                    if (Strings.Len(splItemcd[0]) > 0)
                    {
                        // 'TM_BHNSFREE(DELETE→INSERT)

                        SQL = BHCO_kyotu_proc.pubf_BhNsInsFreed(bnendo, bkofuno, "00");

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        for (long itemIndex = 0L, loopTo10 = splItemcd.Length - 1; itemIndex <= loopTo10; itemIndex++)
                        {
                            if (Strings.Len(Strings.Trim(splData[(int)itemIndex])) > 0)
                            {
                                SQL = BHCO_kyotu_proc.pubf_BhNsInsFreei(bnendo, bkofuno, "00", splItemcd[(int)itemIndex], splData[(int)itemIndex], splDatatype[(int)itemIndex]);

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // オンライン申請情報登録処理
                    var splItemcdOnline = Strings.Split(freeitemcdOnline, CM_kyotu_proc.MAIN_DELIMITER);
                    var splDataOnline = Strings.Split(inputOnlinedata, CM_kyotu_proc.MAIN_DELIMITER);
                    var splDatatypeOnline = Strings.Split(datatypeOnline, CM_kyotu_proc.MAIN_DELIMITER);

                    if (Strings.Len(splItemcdOnline[0]) > 0)
                    {
                        // 'TM_BHNSFREE(DELETE→INSERT)

                        SQL = BHCO_kyotu_proc.pubf_BhNsInsFreed(bnendo, bkofuno, "10");

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        for (long itemIndex = 0L, loopTo11 = splItemcdOnline.Length - 1; itemIndex <= loopTo11; itemIndex++)
                        {
                            if (Strings.Len(Strings.Trim(splDataOnline[(int)itemIndex])) > 0)
                            {
                                SQL = BHCO_kyotu_proc.pubf_BhNsInsFreei(bnendo, bkofuno, "10", splItemcdOnline[(int)itemIndex], splDataOnline[(int)itemIndex], splDatatypeOnline[(int)itemIndex]);

                                cmd = conn.CreateCommand();
                                cmd.Transaction = wkTrn;
                                cmd.CommandText = SQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // ****************************
                    // * 支援計画登録処理
                    // ****************************
                    // 妊婦支援マスタ(TM_BHNSIEN)のDELETE/INSERT
                    SQL = pubf_SQLDeleteSien(bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    SQL = pubf_SQLInsertSien(bnendo, bkofuno, sienList);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 妊婦支援マスタサブ(TM_BHNSIEN_SUB)のDELETE/INSERT
                    SQL = pubf_SQLDeleteSienSub(bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    var loopTo12 = sienCheckList.Length - 1;
                    for (i = 0; i <= loopTo12; i++)
                    {
                        if (!string.IsNullOrEmpty(sienCheckList[i])) // 空文字列はダミー項目(要素0のArrayは送れないため)
                        {
                            SQL = pubf_SQLInsertSienSub(bnendo, bkofuno, sienCheckList[i]);
                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 妊婦支援マスタプラン(TM_BHSIEN・TM_BHSIEN_NSHYOJI)のDELETE/INSERT/UPDATE
                    SQL = pubf_SQLDeleteSienPlan(userid, bnendo, bkofuno);
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    var loopTo13 = sienPlanList.Length - 1;
                    for (i = 0; i <= loopTo13; i++)
                    {
                        if (!string.IsNullOrEmpty(sienPlanList[i])) // 空文字列はダミー項目(要素0のArrayは送れないため)
                        {
                            var insertParam_TM_BHSIEN_HYOJI = new string[5];
                            var insParam_TM_BHSIEN = new string[37];
                            var splSienPlan = Strings.Split(sienPlanList[i], CM_kyotu_proc.MAIN_DELIMITER);
                            string planno = splSienPlan[0];
                            string sienno = splSienPlan[15];
                            string delcanf = splSienPlan[36];

                            if (sienno.Length == 0)
                            {
                                // 新規登録

                                // SIENNOの取得
                                SQL = "SELECT                                               " + Constants.vbCr;
                                SQL += "        ISNULL(MAX(SIENNO),0) +   1   AS  SIENNO    " + Constants.vbCr;
                                SQL += "FROM    dbo.TM_BHSIEN                               " + Constants.vbCr;

                                da = new SqlDataAdapter(SQL, conn);
                                da.SelectCommand.Transaction = wkTrn;
                                dt = new DataTable();
                                da.Fill(dt);

                                sienno = dt.Rows[0]["SIENNO"].ToString();

                                // TM_BHSIEN_NSHYOJIの設定
                                insertParam_TM_BHSIEN_HYOJI[0] = planno;                           // プラン番号
                                insertParam_TM_BHSIEN_HYOJI[1] = sienno;                           // 支援番号
                                insertParam_TM_BHSIEN_HYOJI[2] = delcanf;                          // 削除可能フラグ
                            }
                            else
                            {
                                // '更新

                                // TM_BHSIEN_NSHYOJIの設定
                                insertParam_TM_BHSIEN_HYOJI[0] = planno;                           // プラン番号
                                insertParam_TM_BHSIEN_HYOJI[1] = sienno;                           // 支援番号
                                insertParam_TM_BHSIEN_HYOJI[2] = delcanf;
                            }                          // 削除可能フラグ

                            // TM_BHSIEN_NSHYOJIの追加
                            SQL = pubf_SQLInsertSienPlanHyoji(bnendo, bkofuno, insertParam_TM_BHSIEN_HYOJI);
                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();

                            // TM_BHSIENの更新
                            insParam_TM_BHSIEN[0] = splSienPlan[1];        // 計画年月日
                            insParam_TM_BHSIEN[1] = splSienPlan[2];        // 計画時間
                            insParam_TM_BHSIEN[2] = splSienPlan[3];        // 計画方法
                            insParam_TM_BHSIEN[3] = splSienPlan[4];        // 計画スタッフ
                            insParam_TM_BHSIEN[4] = splSienPlan[5];        // 計画内容
                            insParam_TM_BHSIEN[5] = splSienPlan[6];        // 実績年月日
                            insParam_TM_BHSIEN[6] = splSienPlan[7];        // 実績時間
                            insParam_TM_BHSIEN[7] = splSienPlan[8];        // 実績方法
                            insParam_TM_BHSIEN[8] = splSienPlan[9];        // 実績スタッフ
                            insParam_TM_BHSIEN[9] = splSienPlan[10];      // 実績内容
                            insParam_TM_BHSIEN[10] = splSienPlan[11];      // 評価年月日
                            insParam_TM_BHSIEN[11] = splSienPlan[12];      // 評価スタッフ
                            insParam_TM_BHSIEN[12] = splSienPlan[13];      // 評価内容
                            insParam_TM_BHSIEN[13] = splSienPlan[14];      // 評価結果
                                                                           // 画面非表示
                            insParam_TM_BHSIEN[14] = sienno;               // 支援番号
                            insParam_TM_BHSIEN[15] = splSienPlan[16];      // 支援所属
                            insParam_TM_BHSIEN[16] = splSienPlan[17];      // 支援区分
                            insParam_TM_BHSIEN[17] = splSienPlan[18];      // 支援終了時間
                            insParam_TM_BHSIEN[18] = splSienPlan[19];      // 支援年
                            insParam_TM_BHSIEN[19] = splSienPlan[20];      // 支援月
                            insParam_TM_BHSIEN[20] = splSienPlan[21];      // 支援結果
                            insParam_TM_BHSIEN[21] = splSienPlan[22];      // 次回予定
                            insParam_TM_BHSIEN[22] = splSienPlan[23];      // 次回予定年月日
                            insParam_TM_BHSIEN[23] = splSienPlan[24];      // 次回予定開始時間
                            insParam_TM_BHSIEN[24] = splSienPlan[25];      // 次回予定終了時間
                            insParam_TM_BHSIEN[25] = splSienPlan[26];      // 次回確認フラグ
                            insParam_TM_BHSIEN[26] = splSienPlan[27];      // 相談者関係
                            insParam_TM_BHSIEN[27] = splSienPlan[28];      // 相談者整理番号
                            insParam_TM_BHSIEN[28] = splSienPlan[29];      // 相談者氏名
                            insParam_TM_BHSIEN[29] = splSienPlan[30];      // 相談者連絡先
                            insParam_TM_BHSIEN[30] = splSienPlan[31];      // 備忘
                            insParam_TM_BHSIEN[31] = splSienPlan[32];      // 備忘確認フラグ
                            insParam_TM_BHSIEN[32] = splSienPlan[33];      // 注意フラグ
                            insParam_TM_BHSIEN[33] = splSienPlan[34];      // 登録年月日
                            insParam_TM_BHSIEN[34] = splSienPlan[35];      // 登録者
                            insParam_TM_BHSIEN[35] = userid;

                            if (delcanf == "1")
                            {
                                SQL = pubf_SQLInsertSienPlan(insParam_TM_BHSIEN);
                            }
                            else
                            {
                                SQL = pubf_SQLUpdateSienPlan(insParam_TM_BHSIEN);
                            }

                            cmd = conn.CreateCommand();
                            cmd.Transaction = wkTrn;
                            cmd.CommandText = SQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    wkTrn.Commit();

                    // 排他制御マスタ：ロック解除
                    if (CM_kyotu_proc.pubf_Haitaseigyo() == "1")
                    {
                        CM_kyotu_proc.pubf_DeleteHaitaseigyo(userid, systemcd);
                    }
                }
                catch (SqlException ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");

            return newXML;
        }

        /// <summary>
        /// 妊産婦情報を削除する。
        /// 該当レコードに削除フラグを立てる。
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <param name="edano">枝番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Sakujo(string systemcd, string userid, string nendo, string kofuno, string edano)
        {
            SqlCommand cmd;
            SqlTransaction wkTrn;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL = "";
            string Param;
            int cnt = 0;

            string bnendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
            string bkofuno = kofuno;
            string bedano = edano;

            // ' ログパラメータの設定
            Param = "func_Sakujo(" + systemcd + "," + userid + "," + bnendo + "," + bkofuno + "," + bedano + ")";

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    SQL = "SELECT                                 " + Constants.vbCr;
                    SQL += "        COUNT(*) AS CNT               " + Constants.vbCr;
                    SQL += "FROM    dbo.TM_BHNSHAKKO              " + Constants.vbCr;
                    SQL += "WHERE   BNENDO    =   " + bnendo + "  " + Constants.vbCr;
                    SQL += "    AND BKOFUNO   =   " + bkofuno + " " + Constants.vbCr;
                    SQL += "    AND EDANO     =   1               " + Constants.vbCr;

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    cnt = Conversions.ToInteger(cmd.ExecuteScalar());

                    // ****************************
                    // * 妊婦発行情報マスタ(TM_BHNSHAKKO)削除処理
                    // ****************************
                    SQL = pubf_SQLUpdateHakkoEda(userid, bnendo, bkofuno, bedano);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    // 母子手帳番号(母子手帳枝番違いの番号)が2件以上存在する場合
                    if (cnt < 2)
                    {
                        // 削除-該当レコードの枝番号を+1する
                        // ****************************
                        // * 妊産婦基本情報マスタ(TM_BHNSKIHON)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateKihonEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦住登外父母情報管理マスタ(TM_BHNSJUTOGAI)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateJyutogaiEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 出生歴マスタ(TM_BHNSSYUSSYO)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSyussyoEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊娠歴マスタ(TM_BHNSNINREKI)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateNinrekiEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦同居管理マスタ(TM_BHNSDOKYO)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateDokyoEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 主訴マスタ(TM_BHNSSYUSO)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSyusoEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 母親学級マスタ(TM_BHBGAKKYU)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateGakkyuEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦疾病状況管理マスタ(TM_BHNSSIPPEI)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSippeiEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦要管理内容管理マスタ(TM_BHNSYOKANRI)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateYokanriEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦保健指導管理マスタ(TM_BHNSSIDO)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSidoEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊婦健診管理マスタ(TM_BHNSNINKEN)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateNinkenEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦動的項目管理マスタ（TM_BHNSITEM）削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateTM_BHNSITEMEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 産婦健診管理マスタ(TM_BHNSSANPU)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSanpuEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦問診管理マスタ(TM_BHNSMONSIN)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateMonsinEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産婦フリー項目マスタ(TM_BHNSFREE)削除処理
                        // ****************************
                        SQL = BHCO_kyotu_proc.pubf_BhNsDelFreeEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        // ****************************
                        // * 妊産支援管理マスタ(TM_BHNSIEN, TM_BHNSIEN_SUB)削除処理
                        // ****************************
                        SQL = pubf_SQLUpdateSienEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        SQL = pubf_SQLUpdateSienSEda(bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();

                        SQL = pubf_SQLUpdateSienPEda(userid, bnendo, bkofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;
                        cmd.ExecuteNonQuery();
                    }

                    wkTrn.Commit();

                    // 排他制御マスタ：ロック解除
                    if (CM_kyotu_proc.pubf_Haitaseigyo() == "1")
                    {
                        CM_kyotu_proc.pubf_DeleteHaitaseigyo(userid, systemcd);
                    }
                }
                catch (SqlException ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");
            return newXML;
        }

        /// <summary>
        /// 妊産婦情報入力で表示されている情報をコピー登録する
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <param name="edano">枝番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_CopyToroku(string systemcd, string userid, string nendo, string kofuno, string edano)
        {
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            SqlTransaction wkTrn;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL = "";
            string Param;

            string bnendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();

            // ログパラメータの設定
            Param = "func_CopyToroku(" + systemcd + "," + userid + "," + bnendo + "," + kofuno + "," + edano + ")";

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                wkTrn = conn.BeginTransaction();

                try
                {
                    var kensakuList = new string[3];
                    kensakuList[0] = bnendo;     // 母子手帳年度
                    kensakuList[1] = kofuno;     // 母子手帳交付番号
                    kensakuList[2] = (Conversions.ToDouble(edano) + 1d).ToString();  // 母子手帳枝番

                    SQL = pubf_SQLGetCountTM_BHNSHAKKO(kensakuList);

                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;

                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(dt.Rows[0]["CNT"], 0, false)))
                    {
                        // 現在登録されている最大の母子手帳枝番を取得する
                        SQL = pubf_SQLGetBEDANO(bnendo, kofuno);

                        cmd = conn.CreateCommand();
                        cmd.Transaction = wkTrn;
                        cmd.CommandText = SQL;

                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);

                        // 最大の枝番号+1を登録する
                        kensakuList[2] = Conversions.ToString(Operators.AddObject(dt.Rows[0]["BEDANO"], 1));
                    }

                    // 妊産婦発行管理マスタに登録する
                    SQL = pubf_SQLCopyToroku(userid, kensakuList);

                    // '処理実行
                    cmd = conn.CreateCommand();
                    cmd.Transaction = wkTrn;
                    cmd.CommandText = SQL;
                    cmd.ExecuteNonQuery();

                    wkTrn.Commit();

                    // 排他制御マスタ：ロック解除
                    if (CM_kyotu_proc.pubf_Haitaseigyo() == "1")
                    {
                        CM_kyotu_proc.pubf_DeleteHaitaseigyo(userid, systemcd);
                    }
                }
                catch (SqlException ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    wkTrn.Rollback();
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");
            return newXML;
        }

        /// <summary>
        /// 住民情報取得で使用する情報を取得する
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_Jyumin(string systemcd, string userid, string kojinno)
        {
            SqlCommand cmd;
            var newXML = new XmlDocument();
            string Param;
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL;

            // 'ログパラメータの設定
            Param = "func_Jyumin(" + systemcd + "," + userid + "," + kojinno + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();
                try
                {
                    // 個人情報取得
                    SQL = pubf_SQLGetJyumin(kojinno);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "JUMIN", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");
            return newXML;
        }

        /// <summary>
        /// 住民となった日、住民でなくなった日、プッシュ通知希望情報有無を取得する
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_JuJnYmd(string systemcd, string userid, string kojinno)
        {
            SqlCommand cmd;
            var newXML = new XmlDocument();
            string Param;
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL;

            // 'ログパラメータの設定
            Param = "func_JuJnYmd(" + systemcd + "," + userid + "," + kojinno + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();
                try
                {
                    // 個人情報取得
                    SQL = pubf_SQLGetJuJnYmd(kojinno);

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "JUJNYMD", rootElemRESULTXML);
                    }

                    // 'プッシュ通知希望情報有無取得
                    SQL = CM_kyotu_proc.pubf_SQLPush(kojinno, "1");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPUSHF", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");
            return newXML;
        }

        /// <summary>
        /// 手帳番号取得
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_GetTetyoBango(string systemcd, string userid, string nendo, string kofuno, string edano, string kofukbn, string nextkofukbn)

        {
            SqlCommand cmd;
            string cnt;
            var newXML = new XmlDocument();
            SqlDataAdapter da;
            DataTable dt;
            string Param;
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string SQL = "";

            string bnendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();
            // 'ログパラメータの設定
            Param = "func_GetTetyoBango(" + systemcd + "," + userid + ")";

            // DB接続
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();
                try
                {
                    if (!string.IsNullOrEmpty(kofuno))
                    {
                        var kensakuList = new string[3];
                        kensakuList[0] = bnendo;     // 母子手帳年度
                        kensakuList[1] = kofuno;     // 母子手帳交付番号
                        kensakuList[2] = edano;      // 母子手帳枝番

                        SQL = pubf_SQLGetCountTM_BHNSHAKKO(kensakuList);

                        cmd = conn.CreateCommand();
                        cmd.CommandText = SQL;

                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);

                        cnt = dt.Rows[0]["CNT"].ToString();
                    }
                    else
                    {
                        // 現在登録されている最大の手帳番号+1を取得する
                        SQL = pubf_SQLGetHakko(bnendo, kofukbn, nextkofukbn);

                        cmd = new SqlCommand(SQL, conn);

                        using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                        {
                            CM_kyotu_proc.pub_CreateXML(dr, newXML, "TETYONO", rootElemRESULTXML);
                        }

                        cnt = "0";
                    }

                    // 検索ヒット件数をXMLに設定する
                    SQL = "SELECT                       " + Constants.vbCr;
                    SQL += "        " + cnt + " AS  CNT " + Constants.vbCr;

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MPARAM", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            // '処理ステータスの設定
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            // 'ログ書込み
            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", "");
            return newXML;
        }

        /// <summary>
        /// 帳票出力処理
        /// </summary>
        /// <param name="systemcd">システムコード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="type">出力形式</param>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">母子手帳交付番号</param>
        /// <param name="edano">母子手帳枝番</param>
        /// <param name="todokymd">届出年月日</param>
        /// <param name="hahaname">母氏名</param>
        /// <param name="kijunymd">基準年月日</param>
        /// <param name="ninpukensinJoseiList">妊婦健康診査情報</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_repCreate(string systemcd, string userid, string type, string nendo, string kofuno, string edano, string todokymd, string hahaname, string kijunymd, string[] ninpukensinJoseiList)

        {
            var newXML = new XmlDocument();
            string Param;
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string repName = "";
            string repTitle = "";
            string xlsPass = "";
            string crtPass = "";
            string urlPass = "";
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");
            string strNowymd = Strings.Format(DateTime.Now, "yyyy/MM/dd");
            var xlsCreator = new AdvanceSoftware.ExcelCreator.Xlsx.XlsxCreator();
            string SQL = "";
            SqlCommand cmd;
            string sikkomei = "";
            string sikkosya = "";
            string sityosonmei = "";
            int i;
            int joseigakukei = 0;       // '助成金交付決定額
            int joseicount = 0;         // '助成金交付対象受診回数
            SqlDataAdapter da;
            DataTable dt;
            var SQLParam = new string[2];

            string extention = ".xlsx";
            string towncd = CM_kyotu_proc.pubf_Towncd();

            string yubin = "";
            string adrs = "";
            string kata = "";

            // 'ログパラメータの設定
            Param = "func_repCreate(" + systemcd + CM_kyotu_proc.LOG_DELIMITER + userid + CM_kyotu_proc.LOG_DELIMITER + type + CM_kyotu_proc.LOG_DELIMITER + nendo + CM_kyotu_proc.LOG_DELIMITER + kofuno + CM_kyotu_proc.LOG_DELIMITER + edano + CM_kyotu_proc.LOG_DELIMITER + todokymd + CM_kyotu_proc.LOG_DELIMITER + hahaname + CM_kyotu_proc.LOG_DELIMITER + kijunymd + CM_kyotu_proc.LOG_DELIMITER + ninpukensinJoseiList[0] + ")";

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // '##########################################################################################################
                    // '#
                    // '# 帳票作成処理
                    // '# ・type 妊産婦バーコードシール     1:EXCEL
                    // '# ・type 助成金額交付決定通知書     2:EXCEL
                    // '#
                    // '##########################################################################################################

                    // '和暦→西暦
                    string bnendo = CM_kyotu_proc.pubf_CnvSeireki(nendo).ToString();

                    // 年齢計算基準日を和暦→西暦
                    SQLParam[1] = CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunymd);

                    // 職務執行名取得
                    SQL = "SELECT                       " + Constants.vbCr;
                    SQL += "        NAIYO   AS  NAIYO   " + Constants.vbCr;
                    SQL += "FROM    dbo.TC_KKCF         " + Constants.vbCr;
                    SQL += "WHERE   MAINCD  =   '01'    " + Constants.vbCr;
                    SQL += "    AND SUBCD   =   '001'   " + Constants.vbCr;
                    SQL += "    AND CD      =   '04'    " + Constants.vbCr;
                    cmd = new SqlCommand(SQL, conn);
                    sikkomei = Conversions.ToString(cmd.ExecuteScalar());
                    cmd = null;

                    // 職務執行者取得
                    SQL = "SELECT                       " + Constants.vbCr;
                    SQL += "        NAIYO   AS  NAIYO   " + Constants.vbCr;
                    SQL += "FROM    dbo.TC_KKCF         " + Constants.vbCr;
                    SQL += "WHERE   MAINCD  =   '01'    " + Constants.vbCr;
                    SQL += "    AND SUBCD   =   '001'   " + Constants.vbCr;
                    SQL += "    AND CD      =   '05'    " + Constants.vbCr;
                    cmd = new SqlCommand(SQL, conn);
                    sikkosya = Conversions.ToString(cmd.ExecuteScalar());
                    cmd = null;

                    // 市町村名取得
                    SQL = "SELECT                       " + Constants.vbCr;
                    SQL += "        NAIYO   AS  NAIYO   " + Constants.vbCr;
                    SQL += "FROM    dbo.TC_KKCF         " + Constants.vbCr;
                    SQL += "WHERE   MAINCD  =   '01'    " + Constants.vbCr;
                    SQL += "    AND SUBCD   =   '001'   " + Constants.vbCr;
                    SQL += "    AND CD      =   '02'    " + Constants.vbCr;
                    cmd = new SqlCommand(SQL, conn);
                    sityosonmei = Conversions.ToString(cmd.ExecuteScalar());
                    cmd = null;

                    // '帳票名
                    switch (type ?? "")
                    {
                        case "1":
                            {
                                repName = "妊産婦バーコードシール";
                                break;
                            }
                        case "2":
                            {
                                repName = "妊婦健康診査助成金交付決定通知書";
                                repTitle = sityosonmei + repName;
                                break;
                            }
                        case "3":
                            {
                                repName = "妊婦健診受診票（補助券）";
                                break;
                            }
                    }
                    // エクセルクリエーターの場合はxlsmを設定する
                    switch (type ?? "")
                    {
                        case "1":
                        case "3":
                            {
                                extention = ".xlsm";
                                break;
                            }
                    }

                    bool bFind;
                    // CSV出力以外の場合、デザインファイルのパスを取得する。
                    bFind = CM_kyotu_proc.pubf_GetDesignFile(repName, ref xlsPass, extention);

                    // デザインファイルが見つからなかったらErrorを返却する。
                    if (!bFind)
                    {
                        CM_kyotu_proc.pub_Status(1, 53, "(" + repName + extention + ")", newXML, "STATUS", rootElemRESULTXML);
                        CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(1, 53) + "(" + repName + extention + ")", "", "");
                        return newXML;
                    }

                    crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsKakuno"].ToString() + userid + "_" + repName + strNow + extention;
                    urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsUrl"].ToString() + userid + "_" + repName + strNow + extention;

                    switch (type ?? "")
                    {
                        case "1":
                            {
                                // '（XLSCreator使用）
                                FileSystem.FileCopy(xlsPass, crtPass);

                                xlsCreator.OpenBook(crtPass, "");
                                xlsCreator.SheetNo = xlsCreator.SheetNo2("一覧表");     // シート名：一覧表

                                xlsCreator.Cell("**行番号").Long = 1;
                                xlsCreator.Cell("**母子手帳年度").Str = bnendo + "/04/01";
                                xlsCreator.Cell("**母子手帳交付番号").Str = kofuno;
                                xlsCreator.Cell("**母子手帳枝番").Str = edano;
                                xlsCreator.Cell("**届出年月日").Str = todokymd;

                                xlsCreator.Cell("A2").Long = 1;

                                xlsCreator.CloseBook(true);
                                break;
                            }

                        case "2":
                            {
                                // 助成金額、受診回数出力
                                if (!string.IsNullOrEmpty(ninpukensinJoseiList[0]))
                                {
                                    var loopTo = ninpukensinJoseiList.Length - 1;
                                    for (i = 0; i <= loopTo; i++)
                                    {
                                        string ninpukensinJoseiData = ninpukensinJoseiList[i];
                                        var ninpukensinJosei = Strings.Split(ninpukensinJoseiData, CM_kyotu_proc.MAIN_DELIMITER);

                                        string kenkaisu = ninpukensinJosei[0];
                                        string syokanflg = ninpukensinJosei[1];
                                        string joseigaku = ninpukensinJosei[2];

                                        if (syokanflg == "1")
                                        {
                                            joseicount += 1;
                                            if (Operators.CompareString(joseigaku, "", false) > 0)
                                            {
                                                joseigakukei += Conversions.ToInteger(joseigaku);
                                            }
                                        }
                                    }
                                }

                                // '（VBReport使用）
                                components = new System.ComponentModel.Container();
                                xlsRep = new AdvanceSoftware.VBReport8.Web.WebCellReport(components);
                                xlsRep.FileName = xlsPass;

                                // '助成金交付対象受診回数が0の場合メッセージ（情報）を表示
                                if (joseicount == 0)
                                {
                                    CM_kyotu_proc.pub_Status(0, 2, "", newXML, "STATUS", rootElemRESULTXML);
                                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 2), "", "");
                                    return newXML;
                                }

                                // '郵便番号（通知書用）、住所（通知書用）、方書（通知書用）取得
                                SQL = "SELECT                                                                                                         " + Constants.vbCr;
                                SQL += "    ISNULL(dbo.CHG_YUBIN(VW.YUBIN),'')                          AS [郵便番号（通知書用）]                     " + Constants.vbCr;
                                SQL += "    ,dbo.GET_JITI_ADRS(VW.ADRS, KO.SFADRS)                      AS [住所（通知書用）]                         " + Constants.vbCr;
                                SQL += "    ,ISNULL(VW.KATA,'')                                         AS [方書（通知書用）]                         " + Constants.vbCr;
                                SQL += "FROM                                                                                                          " + Constants.vbCr;
                                SQL += "    TM_BHNSKIHON KH                                                                                           " + Constants.vbCr;
                                SQL += "LEFT JOIN FT_ATENA('" + Strings.Format(DateTime.Now, "yyyy/MM/dd") + "') VW                                                    " + Constants.vbCr;
                                SQL += "    ON KH.HEMKOJINNO = VW.KOJINNO                                                                             " + Constants.vbCr;
                                SQL += "LEFT JOIN TM_KKKOJIN KO                                                                                       " + Constants.vbCr;
                                SQL += "    ON KH.HEMKOJINNO = KO.KOJINNO                                                                             " + Constants.vbCr;
                                SQL += "WHERE                                                                                                         " + Constants.vbCr;
                                SQL += "    KH.BNENDO = '" + bnendo + "'                                                                              " + Constants.vbCr;
                                SQL += "AND KH.BKOFUNO = '" + kofuno + "'                                                                             " + Constants.vbCr;
                                SQL += "AND KH.EDANO = '" + edano + "'                                                                                " + Constants.vbCr;

                                da = new SqlDataAdapter(SQL, conn);
                                dt = new DataTable();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    yubin = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["郵便番号（通知書用）"].ToString());
                                    adrs = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["住所（通知書用）"].ToString());
                                    kata = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["方書（通知書用）"].ToString());
                                }

                                // '帳票出力開始
                                xlsRep.Report.Start();
                                xlsRep.Report.File();
                                xlsRep.Page.Start(repName, "1");

                                xlsRep.Cell("**発行年月日").Value = CM_kyotu_proc.pubf_GetTodayWareki();

                                xlsRep.Cell("**タイトル").Value = repTitle;
                                xlsRep.Cell("**氏名（通知書用）").Value = hahaname + " 様";
                                xlsRep.Cell("**職務執行名").Value = sikkomei;
                                xlsRep.Cell("**職務執行者").Value = sikkosya;
                                xlsRep.Cell("**助成金交付決定額").Value = joseigakukei;
                                xlsRep.Cell("**助成金交付対象受診回数").Value = joseicount;
                                xlsRep.Cell("**郵便番号（通知書用）").Value = yubin;
                                xlsRep.Cell("**住所（通知書用）").Value = adrs;
                                xlsRep.Cell("**方書（通知書用）").Value = kata;

                                xlsRep.Page.End();
                                xlsRep.Report.End();
                                xlsRep.Report.SaveAs(crtPass);
                                break;
                            }

                        case "3":
                            {
                                // （XLSCreator使用） 妊婦健診受診票（補助券）
                                FileSystem.FileCopy(xlsPass, crtPass);

                                SQL = "SELECT                                                                                                               " + Constants.vbCr;
                                SQL += "    KO.KOJINNO AS '整理番号'                                                                                        " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.KNAME ELSE KO.KNAME END AS '母カナ氏名'                              " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.NAME ELSE KO.NAME END AS '母氏名'                                    " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.BYMD ELSE KO.BYMD END AS '母生年月日'                                " + Constants.vbCr;
                                SQL += "    ,dbo.AGE_COMP(CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.BYMD                                                    " + Constants.vbCr;
                                SQL += "        ELSE KO.BYMD END,'" + strNowymd + "') AS 母年齢                                                             " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.ADRS ELSE dbo.GET_JITI_ADRS(SE.ADRS, KO.SFADRS) END AS '母住所'      " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN '' ELSE SE.KATA END AS '母方書'                                          " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.TEL1 ELSE KS.TEL1 END AS '母電話番号１'                              " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN '' ELSE SE.SNAME END AS '世帯主名'                                       " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEMKOJINNO IS NULL THEN BJT.SETAITEL ELSE SS.TEL END AS '世帯電話番号'                           " + Constants.vbCr;
                                SQL += "    ,CF1.NAIYO AS '市町村名'                                                                                        " + Constants.vbCr;
                                SQL += "    ,CF2.NAIYO AS '市町村長名'                                                                                      " + Constants.vbCr;
                                SQL += "    ,BHA.JUNI  AS '出生予定順位'                                                                                    " + Constants.vbCr;
                                if ((towncd ?? "") == CM_kyotu_proc.TOWNCD_ARIK)
                                {
                                    SQL += "    ,FR1.DATATYPE3 AS '初産経産'                                                                                " + Constants.vbCr;
                                }
                                SQL += "    ,dbo.WAREKI_NENGO(0,'" + strNowymd + "') AS '元号'                                                              " + Constants.vbCr;
                                SQL += "    ,dbo.WAREKI_NENGO(1,'" + strNowymd + "') AS '元号_A'                                                            " + Constants.vbCr;
                                SQL += "    ,dbo.WAREKI_NENGO(2,'" + strNowymd + "') AS '元号_1'                                                            " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEFKOJINNO IS NULL THEN BJT_F.KNAME ELSE KO_F.KNAME END AS '父カナ氏名'                          " + Constants.vbCr;
                                SQL += "    ,CASE WHEN BNK.HEFKOJINNO IS NULL THEN BJT_F.NAME ELSE KO_F.NAME END AS '父氏名'                                " + Constants.vbCr;
                                SQL += "FROM                                                                                                                " + Constants.vbCr;
                                SQL += "    (select * from TM_BHNSKIHON                                                                                     " + Constants.vbCr;
                                SQL += "        WHERE BNENDO = '" + bnendo + "'                                                                             " + Constants.vbCr;
                                SQL += "        AND   BKOFUNO = '" + kofuno + "'                                                                            " + Constants.vbCr;
                                SQL += "        AND   EDANO = 1 ) BNK                                                                                       " + Constants.vbCr;
                                SQL += "    left join TM_KKKOJIN KO                                                                                         " + Constants.vbCr;
                                SQL += "        ON	KO.KOJINNO = BNK.HEMKOJINNO                                                                             " + Constants.vbCr;
                                SQL += "    left join TM_KKKOJIN_SUB KS                                                                                     " + Constants.vbCr;
                                SQL += "        ON	KS.KOJINNO = BNK.HEMKOJINNO                                                                             " + Constants.vbCr;
                                SQL += "    left join TM_KKKOJIN  KO_F                                                                                      " + Constants.vbCr;
                                SQL += "        ON	KO_F.KOJINNO = BNK.HEFKOJINNO                                                                           " + Constants.vbCr;
                                SQL += "    left join TM_KKKOJIN_SUB KS_F                                                                                   " + Constants.vbCr;
                                SQL += "        ON	KS_F.KOJINNO = BNK.HEFKOJINNO                                                                           " + Constants.vbCr;
                                SQL += "    left join TM_KKSETAI SE                                                                                         " + Constants.vbCr;
                                SQL += "        ON	SE.SETAINO = KO.SETAINO                                                                                 " + Constants.vbCr;
                                SQL += "    left join TM_KKSETAI_SUB SS                                                                                     " + Constants.vbCr;
                                SQL += "        ON	SS.SETAINO = SE.SETAINO                                                                                 " + Constants.vbCr;
                                SQL += "    left join TM_BHNSJUTOGAI BJT                                                                                    " + Constants.vbCr;
                                SQL += "        ON	BJT.BNENDO = BNK.BNENDO                                                                                 " + Constants.vbCr;
                                SQL += "        AND	BJT.BKOFUNO = BNK.BKOFUNO                                                                               " + Constants.vbCr;
                                SQL += "        AND	BJT.EDANO = BNK.EDANO                                                                                   " + Constants.vbCr;
                                SQL += "        AND	BJT.NTKBN = '2'                                                                                         " + Constants.vbCr;
                                SQL += "    left join TM_BHNSJUTOGAI BJT_F                                                                                  " + Constants.vbCr;
                                SQL += "        ON	BJT_F.BNENDO = BNK.BNENDO                                                                               " + Constants.vbCr;
                                SQL += "        AND	BJT_F.BKOFUNO = BNK.BKOFUNO                                                                             " + Constants.vbCr;
                                SQL += "        AND	BJT_F.EDANO = BNK.EDANO                                                                                 " + Constants.vbCr;
                                SQL += "        AND	BJT_F.NTKBN = '1'                                                                                       " + Constants.vbCr;
                                SQL += "    left join TM_BHNSHAKKO BHA                                                                                      " + Constants.vbCr;
                                SQL += "        ON	BHA.BNENDO = BNK.BNENDO                                                                                 " + Constants.vbCr;
                                SQL += "        AND	BHA.BKOFUNO = BNK.BKOFUNO                                                                               " + Constants.vbCr;
                                SQL += "        AND	BHA.EDANO = BNK.EDANO                                                                                   " + Constants.vbCr;
                                SQL += "        AND	BHA.BEDANO = 1                                                                                          " + Constants.vbCr;
                                SQL += "    left join TC_KKCF CF1                                                                                           " + Constants.vbCr;
                                SQL += "        ON	CF1.MAINCD = '01'                                                                                       " + Constants.vbCr;
                                SQL += "        AND	CF1.SUBCD = '001'                                                                                       " + Constants.vbCr;
                                SQL += "        AND	CF1.CD = '04'                                                                                           " + Constants.vbCr;
                                SQL += "    left join TC_KKCF CF2                                                                                           " + Constants.vbCr;
                                SQL += "        ON	CF2.MAINCD = '01'                                                                                       " + Constants.vbCr;
                                SQL += "        AND	CF2.SUBCD = '001'                                                                                       " + Constants.vbCr;
                                SQL += "        AND	CF2.CD = '05'                                                                                           " + Constants.vbCr;
                                if ((towncd ?? "") == CM_kyotu_proc.TOWNCD_ARIK)
                                {
                                    SQL += "    left join TM_BHNSFREE FR1                                                                                   " + Constants.vbCr;
                                    SQL += "        ON	FR1.KENKAISU = '00'                                                                                 " + Constants.vbCr;
                                    SQL += "        AND	FR1.ITEMCD = '00001'                                                                                " + Constants.vbCr;
                                    SQL += "        AND	FR1.BNENDO = BNK.BNENDO                                                                             " + Constants.vbCr;
                                    SQL += "        AND	FR1.BKOFUNO = BNK.BKOFUNO                                                                           " + Constants.vbCr;
                                    SQL += "        AND	FR1.EDANO = BNK.EDANO                                                                               " + Constants.vbCr;
                                }

                                da = new SqlDataAdapter(SQL, conn);
                                dt = new DataTable();
                                da.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    CM_kyotu_proc.pub_Status(0, 2, "", newXML, "STATUS", rootElemRESULTXML);
                                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 2), "", "");
                                    return newXML;
                                }

                                xlsCreator.OpenBook(crtPass, "");
                                xlsCreator.SheetNo = xlsCreator.SheetNo2("一覧表");     // シート名：一覧表

                                xlsCreator.Cell("**年齢計算基準日").Str = SQLParam[1];
                                xlsCreator.Cell("**発行年月日").Str = CM_kyotu_proc.pubf_CnvWareki(Conversions.ToDate(strNowymd));
                                xlsCreator.Cell("**市町村名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["市町村名"].ToString());
                                xlsCreator.Cell("**市町村長名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["市町村長名"].ToString());

                                xlsCreator.Cell("**行番号").Long = 1;
                                xlsCreator.Cell("**母子手帳年度").Str = bnendo;
                                xlsCreator.Cell("**母子手帳交付番号").Str = kofuno;
                                xlsCreator.Cell("**母子手帳枝番").Str = edano;
                                xlsCreator.Cell("**整理番号").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["整理番号"].ToString());
                                xlsCreator.Cell("**母カナ氏名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母カナ氏名"].ToString());
                                xlsCreator.Cell("**母氏名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母氏名"].ToString());
                                xlsCreator.Cell("**母生年月日").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母生年月日"].ToString());
                                xlsCreator.Cell("**母年齢").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母年齢"].ToString());
                                xlsCreator.Cell("**母住所").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母住所"].ToString());
                                xlsCreator.Cell("**母方書").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母方書"].ToString());
                                xlsCreator.Cell("**母電話番号１").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["母電話番号１"].ToString());
                                xlsCreator.Cell("**世帯主名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["世帯主名"].ToString());
                                xlsCreator.Cell("**世帯電話番号").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["世帯電話番号"].ToString());
                                xlsCreator.Cell("**出生予定順位").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["出生予定順位"].ToString());
                                if ((towncd ?? "") == CM_kyotu_proc.TOWNCD_ARIK)
                                {
                                    xlsCreator.Cell("**初産経産").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["初産経産"].ToString());
                                }
                                xlsCreator.Cell("**元号").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["元号"].ToString());
                                xlsCreator.Cell("**元号_A").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["元号_A"].ToString());
                                xlsCreator.Cell("**元号_1").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["元号_1"].ToString());
                                xlsCreator.Cell("**父カナ氏名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["父カナ氏名"].ToString());
                                xlsCreator.Cell("**父氏名").Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["父氏名"].ToString());

                                xlsCreator.Cell("A2").Long = 1;

                                xlsCreator.CloseBook(true);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_URLPath(newXML, rootElemRESULTXML, urlPass);
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            // '##########################################################################################################
            // '#
            // '# ログ出力処理
            // '#
            // '##########################################################################################################
            switch (type ?? "")
            {
                case "1":
                    {
                        repName = repName + "(EXCEL)";
                        break;
                    }
                case "2":
                    {
                        repName = repName + "(EXCEL)";
                        break;
                    }
            }

            CM_kyotu_proc.pub_Log(userid, systemcd, Param, CM_kyotu_proc.pubf_Msg(0, 0), "", repName, crtPass);

            return newXML;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <param name="edano"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateHakkoEda(string userid, string nendo, string kofuno, string edano)
        {
            string pubf_SQLUpdateHakkoEdaRet = default;
            pubf_SQLUpdateHakkoEdaRet = "UPDATE   dbo.TM_BHNSHAKKO                    " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "   ,DELFLG      =   1                       " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "   ,USERID      =   '" + userid + "'        " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "   ,SYORIYMD    =   GETDATE()               " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "WHERE   BNENDO    =   " + nendo + "       " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "  AND   BKOFUNO   =   " + kofuno + "      " + Constants.vbCr;
            pubf_SQLUpdateHakkoEdaRet += "  AND   BEDANO    =   " + edano + "      " + Constants.vbCr;
            return pubf_SQLUpdateHakkoEdaRet;
        }

        /// <summary>
        /// 妊産婦基本情報管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateKihonEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateKihonEdaRet = default;
            pubf_SQLUpdateKihonEdaRet = "UPDATE   dbo.TM_BHNSKIHON                    " + Constants.vbCr;
            pubf_SQLUpdateKihonEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateKihonEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateKihonEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateKihonEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateKihonEdaRet;
        }

        /// <summary>
        /// 妊産婦住登外父母情報管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateJyutogaiEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateJyutogaiEdaRet = default;
            pubf_SQLUpdateJyutogaiEdaRet = "UPDATE   dbo.TM_BHNSJUTOGAI                 " + Constants.vbCr;
            pubf_SQLUpdateJyutogaiEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateJyutogaiEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateJyutogaiEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateJyutogaiEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateJyutogaiEdaRet;
        }

        /// <summary>
        /// 妊産婦出生歴管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSyussyoEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateSyussyoEdaRet = default;
            pubf_SQLUpdateSyussyoEdaRet = "UPDATE   dbo.TM_BHNSSYUSSYO                  " + Constants.vbCr;
            pubf_SQLUpdateSyussyoEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateSyussyoEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateSyussyoEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateSyussyoEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateSyussyoEdaRet;
        }

        /// <summary>
        /// 妊産婦妊娠歴管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateNinrekiEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateNinrekiEdaRet = default;
            pubf_SQLUpdateNinrekiEdaRet = "UPDATE   dbo.TM_BHNSNINREKI                  " + Constants.vbCr;
            pubf_SQLUpdateNinrekiEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateNinrekiEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateNinrekiEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateNinrekiEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateNinrekiEdaRet;
        }

        /// <summary>
        /// 妊産婦同居管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateDokyoEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateDokyoEdaRet = default;
            pubf_SQLUpdateDokyoEdaRet = "UPDATE   dbo.TM_BHNSDOKYO                    " + Constants.vbCr;
            pubf_SQLUpdateDokyoEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateDokyoEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateDokyoEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateDokyoEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateDokyoEdaRet;
        }

        /// <summary>
        /// 妊産婦主訴管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSyusoEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateSyusoEdaRet = default;
            pubf_SQLUpdateSyusoEdaRet = "UPDATE   dbo.TM_BHNSSYUSO                  " + Constants.vbCr;
            pubf_SQLUpdateSyusoEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateSyusoEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateSyusoEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateSyusoEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateSyusoEdaRet;
        }

        /// <summary>
        /// 妊産婦母親学級管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateGakkyuEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateGakkyuEdaRet = default;
            pubf_SQLUpdateGakkyuEdaRet = "UPDATE   dbo.TM_BHNSGAKKYU                   " + Constants.vbCr;
            pubf_SQLUpdateGakkyuEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateGakkyuEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateGakkyuEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateGakkyuEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateGakkyuEdaRet;
        }

        /// <summary>
        /// 妊産婦疾病状況管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSippeiEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateSippeiEdaRet = default;
            pubf_SQLUpdateSippeiEdaRet = "UPDATE   dbo.TM_BHNSSIPPEI                   " + Constants.vbCr;
            pubf_SQLUpdateSippeiEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateSippeiEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateSippeiEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateSippeiEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateSippeiEdaRet;
        }

        /// <summary>
        /// 妊産婦要管理内容管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateYokanriEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateYokanriEdaRet = default;
            pubf_SQLUpdateYokanriEdaRet = "UPDATE   dbo.TM_BHNSYOKANRI                  " + Constants.vbCr;
            pubf_SQLUpdateYokanriEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateYokanriEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateYokanriEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateYokanriEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateYokanriEdaRet;
        }

        /// <summary>
        /// 妊産婦保健指導管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSidoEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateSidoEdaRet = default;
            pubf_SQLUpdateSidoEdaRet = "UPDATE   dbo.TM_BHNSSIDO                     " + Constants.vbCr;
            pubf_SQLUpdateSidoEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateSidoEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateSidoEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateSidoEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateSidoEdaRet;
        }

        /// <summary>
        /// 妊婦健診管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateNinkenEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateNinkenEdaRet = default;
            pubf_SQLUpdateNinkenEdaRet = "UPDATE   dbo.TM_BHNSNINKEN                   " + Constants.vbCr;
            pubf_SQLUpdateNinkenEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateNinkenEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateNinkenEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateNinkenEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateNinkenEdaRet;
        }

        /// <summary>
        /// 産婦健診管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSanpuEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateSanpuEdaRet = default;
            pubf_SQLUpdateSanpuEdaRet = "UPDATE   dbo.TM_BHNSSANPU                    " + Constants.vbCr;
            pubf_SQLUpdateSanpuEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateSanpuEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateSanpuEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateSanpuEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateSanpuEdaRet;
        }

        /// <summary>
        /// 妊産婦問診管理マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateMonsinEda(string nendo, string kofuno)
        {
            string pubf_SQLUpdateMonsinEdaRet = default;
            pubf_SQLUpdateMonsinEdaRet = "UPDATE   dbo.TM_BHNSMONSIN                   " + Constants.vbCr;
            pubf_SQLUpdateMonsinEdaRet += "SET                                         " + Constants.vbCr;
            pubf_SQLUpdateMonsinEdaRet += "    EDANO       =   EDANO + 1               " + Constants.vbCr;
            pubf_SQLUpdateMonsinEdaRet += "WHERE   BNENDO    =   " + nendo + "         " + Constants.vbCr;
            pubf_SQLUpdateMonsinEdaRet += "  AND   BKOFUNO   =   " + kofuno + "        " + Constants.vbCr;
            return pubf_SQLUpdateMonsinEdaRet;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="bedano"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteBhbhakko(string bnendo, string bkofuno, string bedano)
        {
            string pubf_SQLDeleteBhbhakkoRet = default;
            pubf_SQLDeleteBhbhakkoRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteBhbhakkoRet += "    FROM    dbo.TM_BHNSHAKKO    " + Constants.vbCr;
            pubf_SQLDeleteBhbhakkoRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteBhbhakkoRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteBhbhakkoRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            pubf_SQLDeleteBhbhakkoRet += "  AND BEDANO  = " + bedano + "  " + Constants.vbCr;
            return pubf_SQLDeleteBhbhakkoRet;
        }

        /// <summary>
        /// 妊産婦基本情報管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteKihon(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteKihonRet = default;
            pubf_SQLDeleteKihonRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteKihonRet += "    FROM    dbo.TM_BHNSKIHON    " + Constants.vbCr;
            pubf_SQLDeleteKihonRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteKihonRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteKihonRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteKihonRet;
        }

        /// <summary>
        /// 妊産婦出生歴管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSyussyo(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteSyussyoRet = default;
            pubf_SQLDeleteSyussyoRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteSyussyoRet += "    FROM    dbo.TM_BHNSSYUSSYO  " + Constants.vbCr;
            pubf_SQLDeleteSyussyoRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteSyussyoRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteSyussyoRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteSyussyoRet;
        }

        /// <summary>
        /// 妊産婦妊娠歴管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteNinreki(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteNinrekiRet = default;
            pubf_SQLDeleteNinrekiRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteNinrekiRet += "    FROM    dbo.TM_BHNSNINREKI  " + Constants.vbCr;
            pubf_SQLDeleteNinrekiRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteNinrekiRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteNinrekiRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteNinrekiRet;
        }

        /// <summary>
        /// 妊産婦同居管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteDokyo(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteDokyoRet = default;
            pubf_SQLDeleteDokyoRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteDokyoRet += "    FROM    dbo.TM_BHNSDOKYO    " + Constants.vbCr;
            pubf_SQLDeleteDokyoRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteDokyoRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteDokyoRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteDokyoRet;
        }

        /// <summary>
        /// 妊産婦主訴管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSyuso(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteSyusoRet = default;
            pubf_SQLDeleteSyusoRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteSyusoRet += "    FROM    dbo.TM_BHNSSYUSO    " + Constants.vbCr;
            pubf_SQLDeleteSyusoRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteSyusoRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteSyusoRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteSyusoRet;
        }

        /// <summary>
        /// 妊産婦母親学級管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteGakkyu(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteGakkyuRet = default;
            pubf_SQLDeleteGakkyuRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteGakkyuRet += "    FROM    dbo.TM_BHNSGAKKYU   " + Constants.vbCr;
            pubf_SQLDeleteGakkyuRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteGakkyuRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteGakkyuRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteGakkyuRet;
        }

        /// <summary>
        /// 妊産婦要管理内容管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSippei(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteSippeiRet = default;
            pubf_SQLDeleteSippeiRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteSippeiRet += "    FROM    dbo.TM_BHNSSIPPEI   " + Constants.vbCr;
            pubf_SQLDeleteSippeiRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteSippeiRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteSippeiRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteSippeiRet;
        }

        /// <summary>
        /// 妊産婦要管理内容管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteYokanri(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteYokanriRet = default;
            pubf_SQLDeleteYokanriRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteYokanriRet += "    FROM    dbo.TM_BHNSYOKANRI  " + Constants.vbCr;
            pubf_SQLDeleteYokanriRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteYokanriRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteYokanriRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteYokanriRet;
        }

        /// <summary>
        /// 妊産婦保健指導管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSido(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteSidoRet = default;
            pubf_SQLDeleteSidoRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteSidoRet += "    FROM    dbo.TM_BHNSSIDO     " + Constants.vbCr;
            pubf_SQLDeleteSidoRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteSidoRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteSidoRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteSidoRet;
        }

        /// <summary>
        /// 妊婦健診管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteNinken(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteNinkenRet = default;
            pubf_SQLDeleteNinkenRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteNinkenRet += "    FROM    dbo.TM_BHNSNINKEN   " + Constants.vbCr;
            pubf_SQLDeleteNinkenRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteNinkenRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteNinkenRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteNinkenRet;
        }

        /// <summary>
        /// 産婦健診管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSanpu(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteSanpuRet = default;
            pubf_SQLDeleteSanpuRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteSanpuRet += "    FROM    dbo.TM_BHNSSANPU    " + Constants.vbCr;
            pubf_SQLDeleteSanpuRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteSanpuRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteSanpuRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteSanpuRet;
        }

        /// <summary>
        /// 妊産婦問診管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteMonsin(string bnendo, string bkofuno)
        {
            string pubf_SQLDeleteMonsinRet = default;
            pubf_SQLDeleteMonsinRet = "DELETE                           " + Constants.vbCr;
            pubf_SQLDeleteMonsinRet += "    FROM    dbo.TM_BHNSMONSIN   " + Constants.vbCr;
            pubf_SQLDeleteMonsinRet += "WHERE EDANO   =   1             " + Constants.vbCr;
            pubf_SQLDeleteMonsinRet += "  AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            pubf_SQLDeleteMonsinRet += "  AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            return pubf_SQLDeleteMonsinRet;
        }

        /// <summary>
        /// 妊産婦出生歴管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSyussyo(string[] insertItem)
        {
            string pubf_SQLInsertSyussyoRet = default;
            pubf_SQLInsertSyussyoRet = "INSERT   INTO    dbo.TM_BHNSSYUSSYO              " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,JUNI                                    " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,KOJINNO                                 " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,NENREI                                  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,TAIJU                                   " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,NSYUSU                                  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,IJO                                     " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,KENKO                                   " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ,BIKO                                    " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + " " + Constants.vbCr;
            pubf_SQLInsertSyussyoRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertSyussyoRet;
        }

        /// <summary>
        /// 妊産婦妊娠歴管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertNinreki(string[] insertItem)
        {
            string pubf_SQLInsertNinrekiRet = default;
            pubf_SQLInsertNinrekiRet = "INSERT   INTO    dbo.TM_BHNSNINREKI                                  " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,ROWNO                                                       " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,KOJINNO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,NINSINYMD                                                   " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,NREKICD                                                     " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,JINKOSIZEN                                                  " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,NSYUSU                                                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ,BIKO                                                        " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[5]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinrekiRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertNinrekiRet;
        }

        /// <summary>
        /// 妊産婦同居管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertDokyo(string[] insertItem)
        {
            string pubf_SQLInsertDokyoRet = default;
            pubf_SQLInsertDokyoRet = "INSERT   INTO    dbo.TM_BHNSDOKYO                " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,ROWNO                                   " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,SIMEI                                   " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,NENREI                                  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,TUZUKI                                  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,HOIKUFLG                                " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,SOUDANFLG                               " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,KYORYOKFLG                              " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ,BIKO                                    " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + " " + Constants.vbCr;
            pubf_SQLInsertDokyoRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertDokyoRet;
        }

        /// <summary>
        /// 妊産婦主訴管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSyuso(string[] insertItem)
        {
            string pubf_SQLInsertSyusoRet = default;
            pubf_SQLInsertSyusoRet = "INSERT   INTO    dbo.TM_BHNSSYUSO                " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ,NAIYOCD                                 " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ,SIDO                                    " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSyusoRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertSyusoRet;
        }

        /// <summary>
        /// 妊産婦母親学級管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertGakkyu(string[] insertItem)
        {
            string pubf_SQLInsertGakkyuRet = default;
            pubf_SQLInsertGakkyuRet = "INSERT   INTO    dbo.TM_BHNSGAKKYU                                   " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,SANKAYMD                                                    " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,MAXKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,MINKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,[TO]                                                        " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,TANPAKU                                                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,SENKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,HSYOJO                                                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ,CMNT                                                        " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[3]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertGakkyuRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertGakkyuRet;
        }

        /// <summary>
        /// 妊産婦疾病状況管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSippei(string[] insertItem)
        {
            string pubf_SQLInsertSippeiRet = default;
            pubf_SQLInsertSippeiRet = "INSERT   INTO    dbo.TM_BHNSSIPPEI               " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,SIPPEICD                                " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,TIRYO                                   " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,NYUIN                                   " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ,BIKO                                    " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSippeiRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertSippeiRet;
        }

        /// <summary>
        /// 妊産婦要管理内容管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertYokanri(string[] insertItem)
        {
            string pubf_SQLInsertYokanriRet = default;
            pubf_SQLInsertYokanriRet = "INSERT   INTO    dbo.TM_BHNSYOKANRI                                  " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,KANRICD                                                     " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,FHOUHOU                                                     " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,FYOTEIYMD                                                   " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,FKANYMD                                                     " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ,BIKO                                                        " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[6]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[7]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertYokanriRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertYokanriRet;
        }

        /// <summary>
        /// 妊産婦保健指導管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSido(string[] insertItem)
        {
            string pubf_SQLInsertSidoRet = default;
            pubf_SQLInsertSidoRet = "INSERT   INTO    dbo.TM_BHNSSIDO                                     " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,SIDOCD                                                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,SIDOYMD                                                     " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,TANTO1                                                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,TANTO2                                                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,CMNT                                                        " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ,SONOTA                                                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[4]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSidoRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertSidoRet;
        }

        /// <summary>
        /// 妊婦健診管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertNinken(string[] insertItem)
        {
            string pubf_SQLInsertNinkenRet = default;
            pubf_SQLInsertNinkenRet = "INSERT   INTO    dbo.TM_BHNSNINKEN                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KENKAISU                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KOFUNO                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HAKKOFLG                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SYOKANFLG                                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,JURIYMD                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,JUSINYMD                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SYUSU                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KIKANCD                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,YOSANCD                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,ISICD                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KHOSIKI                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KETTO                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SYOKUGO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,GURUKOSU                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KANSETUK                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HINKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SYOKUSO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HBSKOGEN                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HCVKOGEN                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HCVKOTAI                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BAIDOKU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HIV                                                         " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,FUSIN                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TPURAZUMA                                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HTLV                                                        " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,ATL                                                         " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SSAIBO                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SSAIKIN                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BRENSA                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SIKYUKEKKA                                                  " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,SIKSIKKAN                                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TKEN                                                        " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,THAKKOFLG                                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TKEKKA                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,MAXKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,MINKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,FUSYU                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TAIJU                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HATUIKU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,[TO]                                                        " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,TANPAKU                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,KETON                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,HANTEI                                                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,NYUIN                                                       " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BYOMEI1                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BYOMEI2                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BYOMEI3                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BYOMEI4                                                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,RENRAKU1                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,RENRAKU2                                                    " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,RENRAKUTA                                                   " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ,BIKO                                                        " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[7]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[8]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[11], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[12], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[13], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[14], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[15], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[16], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[17], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[18], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[19], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[20], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[21], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[22], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[23], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[24], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[25], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[26], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[27], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[28], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[29], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[30], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[31], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[32], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[33], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[34], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[35], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[36], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[37], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[38], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[39], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[40], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[41], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[42], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[43], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[44], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[45], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[46], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[47], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[48], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[49], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[50], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[51], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[52], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[53], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[54], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[55], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertNinkenRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertNinkenRet;
        }

        /// <summary>
        /// 産婦健診管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSanpu(string[] insertItem)
        {
            string pubf_SQLInsertSanpuRet = default;
            pubf_SQLInsertSanpuRet = "INSERT   INTO    dbo.TM_BHNSSANPU                                    " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,GETUKBN                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,JUSINYMD                                                   " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,TASIFLG                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,KIKANCD                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,MAXKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,MINKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,SYOKUSO                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,[TO]                                                        " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,TANPAKU                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,SENKETU                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,SINJOKYO                                                   " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,KIBUN                                                       " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,GEKKEI                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,HOMON                                                       " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,HANTEI                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,KETUFLG                                                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,TANFLG                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,FUSYUFLG                                                    " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,HINFLG                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,TOFLG                                                       " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,SENFLG                                                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,TAFLG                                                       " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ,BIKO                                                        " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[4]), 1) + "  " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[11], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[12], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[13], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[14], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[15], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[16], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[17], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[18], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[19], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[20], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[21], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[22], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[23], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[24], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[25], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertSanpuRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertSanpuRet;
        }

        /// <summary>
        /// 妊産婦問診管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertMonsin(string[] insertItem)
        {
            string pubf_SQLInsertMonsinRet = default;
            pubf_SQLInsertMonsinRet = "INSERT   INTO    dbo.TM_BHNSMONSIN               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,KENSINKBN                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,MONSINCD                                " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,MONSINEDA                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,DATATYPE1                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,DATATYPE2                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,DATATYPE3                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,DATATYPE4                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "       ,DATATYPE5                               " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertMonsinRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "  " + Constants.vbCr; // 母子手帳年度
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "  " + Constants.vbCr; // 母子手帳交付番号
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "  " + Constants.vbCr; // 枝番号
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "  " + Constants.vbCr; // 健診区分
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr; // 問診ＣＤ
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "  " + Constants.vbCr; // 問診枝番
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "  " + Constants.vbCr; // データタイプ１
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "  " + Constants.vbCr; // データタイプ２
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 0) + "  " + Constants.vbCr; // データタイプ３
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "  " + Constants.vbCr; // データタイプ４
            pubf_SQLInsertMonsinRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(Strings.Trim(insertItem[10])), 1) + " " + Constants.vbCr; // データタイプ５
            pubf_SQLInsertMonsinRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertMonsinRet;
        }

        /// <summary>
        /// 検索件数取得SQL
        /// </summary>
        /// <param name="seirino"></param>
        /// <param name="bymd"></param>
        /// <param name="kname"></param>
        /// <param name="jokengyo"></param>
        /// <param name="gyoseiku"></param>
        /// <param name="jokenjumin"></param>
        /// <param name="juminkubun"></param>
        /// <param name="jokennenrei"></param>
        /// <param name="kijunbi"></param>
        /// <param name="nenreisql"></param>
        /// <param name="jokentodokedesyusu"></param>
        /// <param name="todokedesyusuFrom"></param>
        /// <param name="todokedesyusuTo"></param>
        /// <param name="jokentodokedebi"></param>
        /// <param name="todokedebiFrom"></param>
        /// <param name="todokedebiTo"></param>
        /// <param name="jokenbunben"></param>
        /// <param name="bunbenyoteibiFrom"></param>
        /// <param name="bunbenyoteibiTo"></param>
        /// <param name="jokenninpukenshinbi"></param>
        /// <param name="ninpukenshinbiFrom"></param>
        /// <param name="ninpukenshinbiTo"></param>
        /// <param name="jokennninpukenshinhantei"></param>
        /// <param name="ninpukenshinhantei"></param>
        /// <param name="pno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKensaku(string seirino, string bymd, string kname, string jokengyo, string[] gyoseiku, string jokenjumin, string[] juminkubun, string jokennenrei, string kijunbi, string nenreisql, string jokentodokedesyusu, string todokedesyusuFrom, string todokedesyusuTo, string jokentodokedebi, string todokedebiFrom, string todokedebiTo, string jokenbunben, string bunbenyoteibiFrom, string bunbenyoteibiTo, string jokenninpukenshinbi, string ninpukenshinbiFrom, string ninpukenshinbiTo, string jokennninpukenshinhantei, string[] ninpukenshinhantei, string pno)

        {
            string pubf_SQLGetKensakuRet = default;
            int i = 0;

            pubf_SQLGetKensakuRet = "SELECT                                                                                                      " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     D.SUM + K.SUM                                                                       AS SUM            " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "    ,(CASE WHEN H.BNENDO IS NOT NULL AND O.BNENDO IS NULL THEN H.BNENDO                                    " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           WHEN H.BNENDO IS NULL AND O.BNENDO IS NOT NULL THEN O.BNENDO                                    " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           ELSE NULL END)                                                                AS BNENDO         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "    ,(CASE WHEN H.BKOFUNO IS NOT NULL AND O.BKOFUNO IS NULL THEN H.BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           WHEN H.BKOFUNO IS NULL AND O.BKOFUNO IS NOT NULL THEN O.BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           ELSE NULL END)                                                                AS BKOFUNO        " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "    ,(CASE WHEN H.BEDANO IS NOT NULL AND O.BEDANO IS NULL THEN H.BEDANO                                    " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           WHEN H.BEDANO IS NULL AND O.BEDANO IS NOT NULL THEN O.BEDANO                                    " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "           ELSE NULL END)                                                                AS BEDANO         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "FROM                                                                                                         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     (SELECT COUNT(*) AS SUM                                                                                 " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     FROM TM_BHNSHAKKO A                                                                                     " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "         INNER JOIN TM_BHNSKIHON B ON A.BNENDO = B.BNENDO AND A.BKOFUNO = B.BKOFUNO AND A.EDANO = B.EDANO    " + Constants.vbCr;

            // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
            if (string.IsNullOrEmpty(seirino) & (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1"))
            {
                pubf_SQLGetKensakuRet += "         LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                  " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "                    WHERE 1 = 1                                                                                    " + Constants.vbCr;
                if (jokenninpukenshinbi == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "'            " + Constants.vbCr;
                }

                if (jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo = ninpukenshinhantei.Length - 1;
                    for (i = 0; i <= loopTo; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                 " + Constants.vbCr;
                }
                pubf_SQLGetKensakuRet += "         ) T ON A.BNENDO = T.BNENDO AND A.BKOFUNO = T.BKOFUNO AND A.EDANO = T.EDANO                          " + Constants.vbCr;
            }

            pubf_SQLGetKensakuRet += "         LEFT JOIN VW_KKITIRAN C ON B.HEMKOJINNO = C.KOJINNO                                                  " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "         LEFT JOIN TM_KKKOJIN_SUB C_sub ON C.KOJINNO = C_sub.KOJINNO                                         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "         LEFT JOIN TM_KKSETAI P On C.SETAINO = P.SETAINO                                                     " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     WHERE                                                                                                   " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "         A.EDANO = 1                                                                                         " + Constants.vbCr;

            // 画面の整理番号
            if (!string.IsNullOrEmpty(seirino))
            {
                pubf_SQLGetKensakuRet += "         AND C.KOJINNO = '" + seirino + "'                                                                    " + Constants.vbCr;
            }
            else if (!string.IsNullOrEmpty(pno))
            {
                // 画面の個人番号
                pubf_SQLGetKensakuRet += "         AND cast(DecryptByKey(C.PERSONALNO)as varchar) =   '" + pno + "'    " + Constants.vbCr;
            }
            else
            {
                // 画面のカナ氏名
                if (!string.IsNullOrEmpty(kname))
                {
                    pubf_SQLGetKensakuRet += "         AND C_sub.KKNAME LIKE '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                                                             " + Constants.vbCr;
                }

                // 画面の生年月日
                if (!string.IsNullOrEmpty(bymd))
                {
                    pubf_SQLGetKensakuRet += "         AND C.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                    " + Constants.vbCr;
                }

                // 詳細画面の行政区指定
                if (jokengyo == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND P.GYOCD IN ('DUMMY'                                            " + Constants.vbCr;
                    var loopTo1 = gyoseiku.Length - 1;
                    for (i = 0; i <= loopTo1; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の住民区分
                if (jokenjumin == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND C.JKBN IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo2 = juminkubun.Length - 1;
                    for (i = 0; i <= loopTo2; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + juminkubun[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の年齢指定範囲
                if (jokennenrei == "1")
                {
                    pubf_SQLGetKensakuRet += "   AND " + CM_kyotu_proc.pubf_SQLAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "C");
                }

                // 詳細画面の届出週数指定範囲
                if (jokentodokedesyusu == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND B.HESYUSU BETWEEN  " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                }

                // 詳細画面の届出年月日指定範囲
                if (jokentodokedebi == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND B.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面の分娩予定年月日指定範囲
                if (jokenbunben == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND B.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND T.BNENDO IS NOT NULL                                                                            " + Constants.vbCr;
                }
            }

            pubf_SQLGetKensakuRet += " ) D                                                                                                         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += " LEFT JOIN (SELECT E.BNENDO,E.BKOFUNO,E.BEDANO                                                               " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "    FROM TM_BHNSHAKKO E                                                                                      " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     INNER JOIN TM_BHNSKIHON F ON E.BNENDO = F.BNENDO AND E.BKOFUNO = F.BKOFUNO AND E.EDANO = F.EDANO        " + Constants.vbCr;

            // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
            if (string.IsNullOrEmpty(seirino) & (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1"))
            {
                pubf_SQLGetKensakuRet += "     LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                      " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "     WHERE  1= 1                                                                                            " + Constants.vbCr;
                if (jokenninpukenshinbi == "1")
                {
                    pubf_SQLGetKensakuRet += "             AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "'            " + Constants.vbCr;
                }

                if (jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo3 = ninpukenshinhantei.Length - 1;
                    for (i = 0; i <= loopTo3; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                 " + Constants.vbCr;
                }

                pubf_SQLGetKensakuRet += "     ) U ON E.BNENDO = U.BNENDO AND E.BKOFUNO = U.BKOFUNO AND E.EDANO = U.EDANO                              " + Constants.vbCr;
            }

            pubf_SQLGetKensakuRet += "     LEFT JOIN VW_KKITIRAN G ON F.HEMKOJINNO = G.KOJINNO                                                      " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     LEFT JOIN TM_KKKOJIN_SUB G_sub ON G.KOJINNO = G_sub.KOJINNO                                                 " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     LEFT JOIN TM_KKSETAI Q On G.SETAINO = Q.SETAINO                                                         " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "    WHERE                                                                                                    " + Constants.vbCr;
            pubf_SQLGetKensakuRet += "     E.EDANO = 1                                                                                             " + Constants.vbCr;

            // 画面の整理番号
            if (!string.IsNullOrEmpty(seirino))
            {
                pubf_SQLGetKensakuRet += "     AND G.KOJINNO = '" + seirino + "'                                                                        " + Constants.vbCr;
            }
            else if (!string.IsNullOrEmpty(pno))
            {
                // 画面の個人番号
                pubf_SQLGetKensakuRet += "     AND cast(DecryptByKey(G.PERSONALNO)as varchar) =   '" + pno + "'    " + Constants.vbCr;
            }
            else
            {
                // 画面のカナ氏名
                if (!string.IsNullOrEmpty(kname))
                {
                    pubf_SQLGetKensakuRet += "     AND G_sub.KKNAME LIKE '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                                                                 " + Constants.vbCr;
                }

                // 画面の生年月日
                if (!string.IsNullOrEmpty(bymd))
                {
                    pubf_SQLGetKensakuRet += "     AND G.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                                           " + Constants.vbCr;
                }

                // 詳細画面の行政区指定
                if (jokengyo == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND Q.GYOCD IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo4 = gyoseiku.Length - 1;
                    for (i = 0; i <= loopTo4; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の住民区分
                if (jokenjumin == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND G.JKBN IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo5 = juminkubun.Length - 1;
                    for (i = 0; i <= loopTo5; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + juminkubun[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の年齢指定範囲
                if (jokennenrei == "1")
                {
                    pubf_SQLGetKensakuRet += "   AND " + CM_kyotu_proc.pubf_SQLAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "G");
                }

                // 詳細画面の届出週数指定範囲
                if (jokentodokedesyusu == "1")
                {
                    pubf_SQLGetKensakuRet += "     AND F.HESYUSU BETWEEN  " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                }

                // 詳細画面の届出年月日指定範囲
                if (jokentodokedebi == "1")
                {
                    pubf_SQLGetKensakuRet += "     AND F.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "'  " + Constants.vbCr;
                }

                // 詳細画面の分娩予定年月日指定範囲
                if (jokenbunben == "1")
                {
                    pubf_SQLGetKensakuRet += "     AND F.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "     AND U.BNENDO IS NOT NULL                                                                                " + Constants.vbCr;
                }
            }

            pubf_SQLGetKensakuRet += " ) H ON D.SUM = 1                                                                                            " + Constants.vbCr;

            // 画面で整理番号を指定した場合もしくは詳細検索画面にて住民区分を選択した場合
            if (!string.IsNullOrEmpty(seirino) | jokenjumin == "1" | !string.IsNullOrEmpty(pno))
            {
                pubf_SQLGetKensakuRet += " ,(SELECT SUM = 0) K                                                                                         " + Constants.vbCr;
                pubf_SQLGetKensakuRet += " LEFT JOIN (SELECT BNENDO = NULL,BKOFUNO = NULL,BEDANO = NULL) O ON K.SUM = 1                                " + Constants.vbCr;
            }
            else if (!string.IsNullOrEmpty(kname) | !string.IsNullOrEmpty(bymd) | jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1" | jokengyo == "1" | jokennenrei == "1" | jokentodokedesyusu == "1" | jokentodokedebi == "1" | jokenbunben == "1")
            {
                // カナ氏名もしくは生年月日指定をした場合
                // 詳細検索のみでの検索
                pubf_SQLGetKensakuRet += " ,(SELECT COUNT(*) AS SUM                                                                                    " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "     FROM TM_BHNSHAKKO I                                                                                     " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         INNER JOIN TM_BHNSKIHON R ON I.BNENDO = R.BNENDO AND I.BKOFUNO = R.BKOFUNO AND I.EDANO = R.EDANO    " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         INNER JOIN TM_BHNSJUTOGAI J ON I.BNENDO = J.BNENDO AND I.BKOFUNO = J.BKOFUNO AND I.EDANO = J.EDANO " + Constants.vbCr;

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "         LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                  " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "              WHERE  1 = 1                                                                                        " + Constants.vbCr;

                    if (jokenninpukenshinbi == "1")
                    {
                        pubf_SQLGetKensakuRet += "    AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "'            " + Constants.vbCr;
                    }

                    if (jokennninpukenshinhantei == "1")
                    {
                        pubf_SQLGetKensakuRet += "    AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                        var loopTo6 = ninpukenshinhantei.Length - 1;
                        for (i = 0; i <= loopTo6; i++)
                            pubf_SQLGetKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                        pubf_SQLGetKensakuRet += "        )                                                                 " + Constants.vbCr;
                    }

                    pubf_SQLGetKensakuRet += "         ) V ON R.BNENDO = V.BNENDO AND R.BKOFUNO = V.BKOFUNO AND R.EDANO = V.EDANO                          " + Constants.vbCr;
                }

                pubf_SQLGetKensakuRet += "     WHERE                                                                                                   " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         I.EDANO = 1                                                                                         " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         AND J.NTKBN = '2'                                                                                   " + Constants.vbCr;

                // 画面のカナ氏名
                if (!string.IsNullOrEmpty(kname))
                {
                    pubf_SQLGetKensakuRet += "         AND J.KKNAME Like '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                                                             " + Constants.vbCr;
                }

                // 画面の生年月日
                if (!string.IsNullOrEmpty(bymd))
                {
                    pubf_SQLGetKensakuRet += "         AND J.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                                       " + Constants.vbCr;
                }

                // 詳細画面の行政区指定()
                if (jokengyo == "1")
                {
                    pubf_SQLGetKensakuRet += "    AND J.GYOCD IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo7 = gyoseiku.Length - 1;
                    for (i = 0; i <= loopTo7; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の年齢指定範囲
                if (jokennenrei == "1")
                {
                    pubf_SQLGetKensakuRet += "   AND " + pubf_SQLJutogaiAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "J");
                }

                // 詳細画面の届出週数指定範囲
                if (jokentodokedesyusu == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND R.HESYUSU BETWEEN " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                }

                // 詳細画面の届出年月日指定範囲
                if (jokentodokedebi == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND R.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面の分娩予定年月日指定範囲
                if (jokenbunben == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND R.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "'                                         " + Constants.vbCr;
                }

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND V.BNENDO IS NOT NULL                                                                            " + Constants.vbCr;
                }

                pubf_SQLGetKensakuRet += " ) K                                                                                                         " + Constants.vbCr;
                pubf_SQLGetKensakuRet += " LEFT JOIN (SELECT L.BNENDO,L.BKOFUNO,L.BEDANO                                                               " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "      FROM TM_BHNSHAKKO L                                                                                    " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         INNER JOIN TM_BHNSKIHON S ON L.BNENDO = S.BNENDO AND L.BKOFUNO = S.BKOFUNO AND L.EDANO = S.EDANO    " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         INNER JOIN TM_BHNSJUTOGAI M ON L.BNENDO = M.BNENDO AND L.BKOFUNO = M.BKOFUNO AND L.EDANO = M.EDANO " + Constants.vbCr;

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "         LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                  " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "                WHERE 1 = 1                                                                                       " + Constants.vbCr;
                    if (jokenninpukenshinbi == "1")
                    {
                        pubf_SQLGetKensakuRet += "              AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "'            " + Constants.vbCr;
                    }

                    if (jokennninpukenshinhantei == "1")
                    {
                        pubf_SQLGetKensakuRet += "              AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                        var loopTo8 = ninpukenshinhantei.Length - 1;
                        for (i = 0; i <= loopTo8; i++)
                            pubf_SQLGetKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                        pubf_SQLGetKensakuRet += "        )                                                                 " + Constants.vbCr;
                    }

                    pubf_SQLGetKensakuRet += "         ) W ON L.BNENDO = W.BNENDO AND L.BKOFUNO = W.BKOFUNO AND L.EDANO = W.EDANO                          " + Constants.vbCr;
                }

                pubf_SQLGetKensakuRet += "     WHERE                                                                                                   " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         L.EDANO = 1                                                                                         " + Constants.vbCr;
                pubf_SQLGetKensakuRet += "         AND M.NTKBN = '2'                                                                                   " + Constants.vbCr;

                // 画面のカナ氏名
                if (!string.IsNullOrEmpty(kname))
                {
                    pubf_SQLGetKensakuRet += "         AND M.KKNAME Like '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                                                 " + Constants.vbCr;
                }

                // 画面の生年月日
                if (!string.IsNullOrEmpty(bymd))
                {
                    pubf_SQLGetKensakuRet += "         AND M.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                                       " + Constants.vbCr;
                }

                // 詳細画面の行政区指定
                if (jokengyo == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND M.GYOCD IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo9 = gyoseiku.Length - 1;
                    for (i = 0; i <= loopTo9; i++)
                        pubf_SQLGetKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の年齢指定範囲
                if (jokennenrei == "1")
                {
                    pubf_SQLGetKensakuRet += "   AND " + pubf_SQLJutogaiAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "M");
                }

                // 詳細画面の届出週数指定範囲
                if (jokentodokedesyusu == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND S.HESYUSU BETWEEN " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                }

                // 詳細画面の届出年月日指定範囲
                if (jokentodokedebi == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND S.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面の分娩予定年月日指定範囲
                if (jokenbunben == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND S.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "' " + Constants.vbCr;
                }

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetKensakuRet += "         AND W.BNENDO IS NOT NULL                                                                            " + Constants.vbCr;
                }

                pubf_SQLGetKensakuRet += " ) O ON K.SUM = 1                                                                                            " + Constants.vbCr;
            }

            return pubf_SQLGetKensakuRet;
        }

        /// <summary>
        /// 年齢条件のSQL文をを返す。(住登外父母)
        /// </summary>
        /// <param name="strMan">男性条件</param>
        /// <param name="strWoman">女性条件</param>
        /// <param name="kijunymd">基準年月日</param>
        /// <param name="betumei">宛名マスタ別名</param>
        /// <returns>年齢指定SQL文</returns>
        /// <remarks></remarks>
        public string pubf_SQLJutogaiAge(string strMan, string strWoman, string kijunymd, string betumei)
        {
            string SQL = "";
            string SQLman = "";
            string SQLwoman = "";
            string SQLnenrei = "";
            string[] splmage;
            string[] splwage;
            int i;

            splmage = Strings.Split(strMan, "|!");
            splwage = Strings.Split(strWoman, "|!");

            SQLnenrei = "dbo.AGE_COMP(" + betumei + ".BYMD,'" + kijunymd + "') ";
            // '男性条件
            if (!string.IsNullOrEmpty(strMan))
            {
                SQLman = "      (" + betumei + ".NTKBN = '1' AND (        " + Constants.vbCr;
                var loopTo = splmage.Length - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (i != 0)
                    {
                        SQLman += "      OR                             " + Constants.vbCr;
                    }
                    SQLman += "      " + SQLnenrei + splmage[i] + "     " + Constants.vbCr;
                }
                SQLman += "      ))                                     " + Constants.vbCr;
            }
            // '女性条件
            if (!string.IsNullOrEmpty(strWoman))
            {
                SQLwoman = "      (" + betumei + ".NTKBN = '2' AND (      " + Constants.vbCr;
                var loopTo1 = splwage.Length - 1;
                for (i = 0; i <= loopTo1; i++)
                {
                    if (i != 0)
                    {
                        SQLwoman += "      OR                           " + Constants.vbCr;
                    }
                    SQLwoman += "      " + SQLnenrei + splwage[i] + "   " + Constants.vbCr;
                }
                SQLwoman += "      ))                                   " + Constants.vbCr;
            }
            // 'SQL文作成
            if (!string.IsNullOrEmpty(strMan) & string.IsNullOrEmpty(strWoman))
            {
                SQL += SQLman;
            }
            else if (string.IsNullOrEmpty(strMan) & !string.IsNullOrEmpty(strWoman))
            {
                SQL += SQLwoman;
            }
            else
            {
                SQL += "      (                                         " + Constants.vbCr;
                SQL += SQLman;
                SQL += "      OR                                        " + Constants.vbCr;
                SQL += SQLwoman;
                SQL += "      )                                         " + Constants.vbCr;
            }

            return SQL;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタ,妊産婦基本情報管理マスタ,妊産婦住登外父母情報管理マスタ取得SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="bedano"></param>
        /// <param name="kokojinno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetNyuryokuKensaku(string bnendo, string bkofuno, string bedano, string kokojinno)
        {
            string pubf_SQLGetNyuryokuKensakuRet = default;
            // If getCount = "1" Then
            // pubf_SQLGetNyuryokuKensaku = " SELECT TOP 1                                                                                                        " & vbCr
            // Else
            pubf_SQLGetNyuryokuKensakuRet = " SELECT                                                                                                              " + Constants.vbCr;
            // End If
            pubf_SQLGetNyuryokuKensakuRet += "      A.BNENDO                                                                                          AS BNENDO       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,A.BKOFUNO                                                                                         AS BKOFUNO      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,A.BEDANO                                                                                          AS BEDANO       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,A.JUNI                                                                                            AS JUNI       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HESINKI                                                                                         AS HESINKI      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEKETUFLG                                                                                       AS HEKETUFLG    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEMKOJINNO                                                                                      AS HEMKOJINNO   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEFKOJINNO                                                                                      AS HEFKOJINNO   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSSATO                                                                                          AS HSSATO       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSADRS                                                                                          AS HSADRS       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSSNNAME                                                                                        AS HSSNNAME     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSTEL                                                                                           AS HSTEL        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHOMON                                                                                        AS HEHOMON     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHOKENSI                                                                                       AS HEHOKENSI    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HESUISIN                                                                                        AS HESUISIN     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HETUTIFLG                                                                                       AS HETUTIFLG    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEMUKOFLG                                                                                       AS HEMUKOFLG    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEMUKORIYU                                                                                      AS HEMUKORIYU   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.HETODOKYMD)                                                                    AS HETODOKYMD   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HESYUSU                                                                                         AS HESYUSU      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEBUNFLG                                                                                        AS HEBUNFLG     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHOKEN                                                                                         AS HEHOKEN      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHONFLG                                                                                        AS HEHONFLG     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.HEGEKKEYMD)                                                                    AS HEGEKKEYMD   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HETETYOS                                                                                        AS HETETYOS     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HETETYOK                                                                                        AS HETETYOK     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.HEYOTEIYMD)                                                                    AS HEYOTEIYMD   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEYOTEI                                                                                         AS HEYOTEI      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEYOTEITA                                                                                       AS HEYOTEITA    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHAKKOKBN                                                                                      AS HEHAKKOKBN   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HEHAKKO                                                                                         AS HEHAKKO      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMKSAKI                                                                                         AS KMKSAKI      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMKINMU                                                                                         AS KMKINMU      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMKTEL                                                                                          AS KMKTEL       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMBKYUKA                                                                                        AS KMBKYUKA     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMAKYUKA                                                                                        AS KMAKYUKA     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.KMTAIYMD)                                                                      AS KMTAIYMD     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMIKUJI                                                                                         AS KMIKUJI      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMSIGOTO                                                                                        AS KMSIGOTO     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMTHOHO                                                                                         AS KMTHOHO      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KMTJIKAN                                                                                        AS KMTJIKAN     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZPET                                                                                           AS KZPET        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZPCMNT                                                                                         AS KZPCMNT      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZENMEI                                                                                         AS KZENMEI      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZJUKYO                                                                                        AS KZJUKYO     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZKTATE                                                                                         AS KZKTATE      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZKSU                                                                                           AS KZKSU        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZSOON                                                                                         AS KZSOON      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.KZHIATARI                                                                                       AS KZHIATARI    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKSIKKAN                                                                                        AS NKSIKKAN     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKSIKKANTA                                                                                      AS NKSIKKANTA   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKKOUKETUATU                                                                                    AS NKKOUKETUATU " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKTYUDOKU                                                                                       AS NKTYUDOKU    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKHBS                                                                                           AS NKHBS        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKSANJOKU                                                                                      AS NKSANJOKU   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKATL                                                                                           AS NKATL        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.NKKIOTA                                                                                        AS NKKIOTA     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.STSINTYO                                                                                        AS STSINTYO     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.STTAIJUN                                                                                       AS STTAIJUN    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.STTAIJUB                                                                                       AS STTAIJUB    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.STBMI                                                                                           AS STBMI        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSKYORYOKU                                                                                      AS HSKYORYOKU   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSKYOSYA                                                                                        AS HSKYOSYA     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSTANTO1                                                                                        AS HSTANTO1     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSTANTO2                                                                                        AS HSTANTO2     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSSAKESYU                                                                                       AS HSSAKESYU    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSSAKERYO                                                                                       AS HSSAKERYO    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSHONSU                                                                                         AS HSHONSU      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSEIYO                                                                                          AS HSEIYO       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSHENSYOKU                                                                                      AS HSHENSYOKU   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSGYU                                                                                           AS HSGYU        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSGYURYO                                                                                        AS HSGYURYO     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.HSCMNT                                                                                          AS HSCMNT       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,B.SOGOCMNT                                                                                        AS SOGOCMNT     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,C.KOJINNO                                                                                         AS HAHAKOJINNO  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,C.SETAINO                                                                                         AS HAHASETAINO  " + Constants.vbCr; //
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When C.KOJINNO Is Not Null Then (Select NAIYO From TC_KKCF Where MAINCD = '01'                              " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "       And SUBCD = '008' And CD = C.JKBN) Else '住登外' End)                                            AS JKBN         " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When C.KOJINNO Is Not Null Then C.KNAME Else G.KNAME End)                                   AS HAHAKNAME    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When C.KOJINNO Is Not Null Then C.NAME Else G.NAME End)                                     AS HAHANAME     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When C.KOJINNO Is Not Null Then dbo.CHG_WAREKI(0,C.BYMD) Else dbo.CHG_WAREKI(0,G.BYMD) End) AS HAHABYMD     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(CASE WHEN C.KOJINNO IS NOT NULL THEN dbo.AGE_COMP(C.BYMD,GETDATE())                                              " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "       ELSE dbo.AGE_COMP(G.BYMD,GETDATE()) END)                                                         AS HAHAAGE      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(CASE WHEN C.KOJINNO IS NOT NULL THEN dbo.AGE_COMP(C.BYMD,B.HEYOTEIYMD)                                           " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "       ELSE dbo.AGE_COMP(G.BYMD,B.HEYOTEIYMD) END )                                                     AS BUNBENAGE    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.KETUEKI Else G.KETUEKI End)                               AS HAHAKETUEKI  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When E.SETAINO Is Not Null Then ISNULL(E.ADRS, '') + ISNULL(E.KATA, '') Else G.ADRS End)    AS HAHAADRS     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When F.SETAINO Is Not Null Then F.TEL Else G.SETAITEL End)                                  AS HAHATEL      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When F.SETAINO Is Not Null Then F.FAX Else G.FAX End)                                       AS HAHAFAX      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When E.SETAINO Is Not Null Then E.GYOCD Else G.GYOCD End)                                   AS HAHAGYO      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.TEL1 Else G.TEL1 End)                                     AS HAHATEL1     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.MADRS1 Else G.MADRS1 End)                                 AS HAHAMADRS1   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.TEL2 Else G.TEL2 End)                                     AS HAHATEL2     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.MADRS2 Else G.MADRS2 End)                                 AS HAHAMADRS2   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When D.KOJINNO Is Not Null Then D.DVFLG ELSE 0 END)                                         AS DVFLG        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,H.KOJINNO                                                                                         AS TITIKOJINNO  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,H.SETAINO                                                                                         AS TITISETAINO  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When H.KOJINNO Is Not Null Then H.KNAME Else L.KNAME End)                                   AS TITIKNAME    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When H.KOJINNO Is Not Null Then H.NAME Else L.NAME End)                                     AS TITINAME     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When H.KOJINNO Is Not Null Then dbo.CHG_WAREKI(0,H.BYMD) Else dbo.CHG_WAREKI(0,L.BYMD) End) AS TITIBYMD     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(CASE WHEN H.KOJINNO IS NOT NULL THEN dbo.AGE_COMP(H.BYMD,GETDATE())                                              " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "       ELSE dbo.AGE_COMP(L.BYMD,GETDATE()) END)                                                         AS TITIAGE      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.KETUEKI Else  L.KETUEKI End)                              AS TITIKETUEKI  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When J.SETAINO Is Not Null Then ISNULL(J.ADRS, '') + ISNULL(J.KATA, '') Else L.ADRS End)    AS TITIADRS     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When K.SETAINO Is Not Null Then K.TEL Else L.SETAITEL End)                                  AS TITITEL      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When K.SETAINO Is Not Null Then K.FAX Else L.FAX End)                                       AS TITIFAX      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When J.SETAINO Is Not Null Then J.GYOCD Else L.GYOCD End)                                   AS TITIGYO      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.TEL1 Else L.TEL1 End)                                     AS TITITEL1     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.MADRS1 Else L.MADRS1 End)                                 AS TITIMADRS1   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.TEL2 Else L.TEL2 End)                                     AS TITITEL2     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.MADRS2 Else L.MADRS2 End)                                 AS TITIMADRS2   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.SYOKUGYO Else L.SYOKUGYO End)                             AS TITISYOKU    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,(Case When I.KOJINNO Is Not Null Then I.KAISYA Else L.KINMU End)                                  AS TITIKAISYA   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,M.COUNT                                                                                           AS TATAI        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,P.KOJINNO                                                                                         AS KOKOJINNO    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,P.SETAINO                                                                                         AS KOSETAINO    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,P.NAME                                                                                            AS KONAME       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,ISNULL(R.ADRS, '') + ISNULL(R.KATA, '')                                                           AS KOADRS       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.TEL1                                                                                            AS KOTEL1       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.MADRS1                                                                                          AS KOMADRS1     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.TEL2                                                                                            AS KOTEL2       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.MADRS2                                                                                          AS KOMADRS2     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,S.TEL                                                                                             AS KOTEL        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,S.FAX                                                                                             AS KOFAX        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGOKOJINNO                                                                                     AS HOGOKOJINNO  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGOKNAME                                                                                       AS HOGOKNAME    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGONAME                                                                                        AS HOGONAME     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.CHG_WAREKI(0,Q.HOGOBYMD)                                                                      AS HOGOBYMD     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,dbo.AGE_COMP(Q.HOGOBYMD,GETDATE())                                                                AS HOGOAGE      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGOADRS                                                                                        AS HOGOADRS     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGOTEL                                                                                         AS HOGOTEL      " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     ,Q.HOGOZOKUNM                                                                                      AS HOGOZOKUNM   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += " FROM                                                                                                                   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += " TM_BHNSHAKKO A                                                                                                         " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     INNER JOIN TM_BHNSKIHON B On A.BNENDO = B.BNENDO And A.BKOFUNO = B.BKOFUNO And A.EDANO = B.EDANO                   " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN C On B.HEMKOJINNO = C.KOJINNO                                                                 " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN_SUB D On C.KOJINNO = D.KOJINNO                                                                " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI E On C.SETAINO = E.SETAINO                                                                    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI_SUB F On E.SETAINO = F.SETAINO                                                                " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_BHNSJUTOGAI G On B.BNENDO = G.BNENDO                                                                 " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "          AND B.BKOFUNO = G.BKOFUNO And B.EDANO = G.EDANO And G.NTKBN = '2'                                             " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN H On B.HEFKOJINNO = H.KOJINNO                                                                 " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN_SUB I On H.KOJINNO = I.KOJINNO                                                               " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI J On H.SETAINO = J.SETAINO                                                                    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI_SUB K On J.SETAINO = K.SETAINO                                                                " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_BHNSJUTOGAI L On B.BNENDO = L.BNENDO                                                                 " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "         AND B.BKOFUNO = L.BKOFUNO And B.EDANO = L.EDANO And L.NTKBN = '1'                                              " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN (SELECT BNENDO,BKOFUNO,EDANO,COUNT(*) AS COUNT FROM TM_BHNSHAKKO GROUP BY BNENDO,BKOFUNO,EDANO) M        " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "         ON A.BNENDO = M.BNENDO AND A.BKOFUNO = M.BKOFUNO AND A.EDANO = M.EDANO                                         " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_BHNYJO O ON A.BNENDO = O.BNENDO AND A.BKOFUNO = O.BKOFUNO AND A.BEDANO = O.BEDANO AND O.EDANO = 1    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN P ON O.KOJINNO = P.KOJINNO                                                                    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKKOJIN_SUB Q On P.KOJINNO = Q.KOJINNO                                                                " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI R On P.SETAINO = R.SETAINO                                                                    " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "     LEFT JOIN TM_KKSETAI_SUB S On R.SETAINO = S.SETAINO                                                                " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += " WHERE                                                                                                                  " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "    A.EDANO = 1                                                                                                         " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "    AND A.BNENDO = " + bnendo + "                                                                                       " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "    AND A.BKOFUNO = " + bkofuno + "                                                                                     " + Constants.vbCr;
            pubf_SQLGetNyuryokuKensakuRet += "    AND A.BEDANO = " + bedano + "                                                                                       " + Constants.vbCr;
            if (!string.IsNullOrEmpty(kokojinno))
            {
                pubf_SQLGetNyuryokuKensakuRet += "    AND P.KOJINNO  = '" + kokojinno + "'                                                                            " + Constants.vbCr;
            }

            return pubf_SQLGetNyuryokuKensakuRet;
        }

        /// <summary>
        /// 妊婦検索一覧取得
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="bedano"></param>
        /// <param name="seirino"></param>
        /// <param name="bymd"></param>
        /// <param name="kname"></param>
        /// <param name="jokengyo"></param>
        /// <param name="gyoseiku"></param>
        /// <param name="jokenjumin"></param>
        /// <param name="juminkubun"></param>
        /// <param name="jokennenrei"></param>
        /// <param name="kijunbi"></param>
        /// <param name="nenreisql"></param>
        /// <param name="jokentodokedesyusu"></param>
        /// <param name="todokedesyusuFrom"></param>
        /// <param name="todokedesyusuTo"></param>
        /// <param name="jokentodokedebi"></param>
        /// <param name="todokedebiFrom"></param>
        /// <param name="todokedebiTo"></param>
        /// <param name="jokenbunben"></param>
        /// <param name="bunbenyoteibiFrom"></param>
        /// <param name="bunbenyoteibiTo"></param>
        /// <param name="jokenninpukenshinbi"></param>
        /// <param name="ninpukenshinbiFrom"></param>
        /// <param name="ninpukenshinbiTo"></param>
        /// <param name="jokennninpukenshinhantei"></param>
        /// <param name="ninpukenshinhantei"></param>
        /// <param name="pno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetNinpuKensaku(string bnendo, string bkofuno, string bedano, string seirino, string bymd, string kname, string jokengyo, string[] gyoseiku, string jokenjumin, string[] juminkubun, string jokennenrei, string kijunbi, string nenreisql, string jokentodokedesyusu, string todokedesyusuFrom, string todokedesyusuTo, string jokentodokedebi, string todokedebiFrom, string todokedebiTo, string jokenbunben, string bunbenyoteibiFrom, string bunbenyoteibiTo, string jokenninpukenshinbi, string ninpukenshinbiFrom, string ninpukenshinbiTo, string jokennninpukenshinhantei, string[] ninpukenshinhantei, string pno)

        {
            string pubf_SQLGetNinpuKensakuRet = default;

            int i = 0;

            pubf_SQLGetNinpuKensakuRet = " SELECT                                                                                                               " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "      A.BNENDO                                                                                     AS BNENDO         " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,A.BKOFUNO                                                                                    AS BKOFUNO        " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,A.BEDANO                                                                                     AS BEDANO         " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,C.NAME                                                                                       AS HAHANAME       " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,dbo.CHG_WAREKI(0,C.BYMD)                                                                     AS HAHABYMD       " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.HETODOKYMD)                                                               AS HETODOKYMD     " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,B.HESYUSU                                                                                    AS HESYUSU        " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,dbo.CHG_WAREKI(0,B.HEYOTEIYMD)                                                               AS HEBUNYMD       " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,ISNULL(D.ADRS, '') + ISNULL(D.KATA,'')                                                       AS ADRS           " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,C.JKBN                                                                                       AS JKBN           " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,(SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '008' AND CD = C.JKBN)            AS JUMINKBN       " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,E.JUNI                                                                                       AS JUNI           " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,F.KOJINNO                                                                                    AS KOKOJINNO      " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,F.NAME                                                                                       AS KONAME         " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,F.SEX                                                                                        AS SEXKBN         " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,(SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '004' AND CD = F.SEX)             AS KOSEX          " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     ,dbo.CHG_WAREKI(0,F.BYMD)                                                                     AS KOBYMD         " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += " FROM                                                                                                                " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     TM_BHNSHAKKO A                                                                                                  " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     Inner Join TM_BHNSKIHON B On A.BNENDO = B.BNENDO AND A.BKOFUNO = B.BKOFUNO AND A.EDANO = B.EDANO                " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     INNER Join TM_KKKOJIN C On B.HEMKOJINNO = C.KOJINNO                                                             " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     INNER Join TM_KKKOJIN_SUB C_sub On C.KOJINNO = C_sub.KOJINNO                                                    " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     INNER Join VW_KKITIRAN I On C.KOJINNO = I.KOJINNO                                                               " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     Left Join TM_KKSETAI D On C.SETAINO = D.SETAINO                                                                 " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     LEFT JOIN TM_BHNYJO E ON A.BNENDO = E.BNENDO AND A.BKOFUNO = E.BKOFUNO AND A.BEDANO = E.BEDANO AND E.EDANO = 1 " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     LEFT JOIN TM_KKKOJIN F ON E.KOJINNO = F.KOJINNO                                                                 " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "     Left Join TM_KKSETAI G On C.SETAINO = G.SETAINO                                                                 " + Constants.vbCr;

            if (string.IsNullOrEmpty(seirino) & (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1"))
            {
                pubf_SQLGetNinpuKensakuRet += "     LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                              " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "                WHERE  1 = 1                                                                                              " + Constants.vbCr;

                if (jokenninpukenshinbi == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "             AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "'            " + Constants.vbCr;
                }

                if (jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "             AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo = ninpukenshinhantei.Length - 1;
                    for (i = 0; i <= loopTo; i++)
                        pubf_SQLGetNinpuKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "        )                                                                 " + Constants.vbCr;
                }
                pubf_SQLGetNinpuKensakuRet += "                ) H ON A.BNENDO = H.BNENDO AND A.BKOFUNO = H.BKOFUNO AND A.EDANO = H.EDANO                           " + Constants.vbCr;
            }

            pubf_SQLGetNinpuKensakuRet += " WHERE                                                                                                               " + Constants.vbCr;
            pubf_SQLGetNinpuKensakuRet += "    A.EDANO = 1                                                                                                      " + Constants.vbCr;

            if (!string.IsNullOrEmpty(bnendo) & !string.IsNullOrEmpty(bkofuno) & !string.IsNullOrEmpty(bedano))
            {
                // 手帳番号
                pubf_SQLGetNinpuKensakuRet += "    AND A.BNENDO = " + bnendo + "                                                     " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    AND A.BKOFUNO = " + bkofuno + "                                                   " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    AND A.BEDANO = " + bedano + "                                                     " + Constants.vbCr;
            }
            else if (!string.IsNullOrEmpty(seirino))
            {
                // 整理番号
                pubf_SQLGetNinpuKensakuRet += "    AND B.HEMKOJINNO = '" + seirino + "'                                              " + Constants.vbCr;
            }
            else if (!string.IsNullOrEmpty(pno))
            {
                // 個人番号
                pubf_SQLGetNinpuKensakuRet += "    AND cast(DecryptByKey(I.PERSONALNO)as varchar) =   '" + pno + "'    " + Constants.vbCr;
            }
            else
            {
                // カナ氏名
                if (!string.IsNullOrEmpty(kname))
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND C_sub.KKNAME Like '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                       " + Constants.vbCr;
                }

                // 生年月日
                if (!string.IsNullOrEmpty(bymd))
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND C.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                        " + Constants.vbCr;
                }

                // 行政区区分
                if (jokengyo == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND G.GYOCD IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo1 = gyoseiku.Length - 1;
                    for (i = 0; i <= loopTo1; i++)
                        pubf_SQLGetNinpuKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 住民区分
                if (jokenjumin == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND C.JKBN IN ('DUMMY'                                                " + Constants.vbCr;
                    var loopTo2 = juminkubun.Length - 1;
                    for (i = 0; i <= loopTo2; i++)
                        pubf_SQLGetNinpuKensakuRet += "        ,'" + juminkubun[i] + "'                                         " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "        )                                                                  " + Constants.vbCr;
                }

                // 詳細画面の年齢指定範囲
                if (jokennenrei == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "   AND " + CM_kyotu_proc.pubf_SQLAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "C");
                }

                // 届出週数
                if (jokentodokedesyusu == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "         AND B.HESYUSU BETWEEN  " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                }

                // 届出年月日
                if (jokentodokedebi == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND B.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "'                  " + Constants.vbCr;
                }

                // 分娩予定年月日
                if (jokenbunben == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND B.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "'          " + Constants.vbCr;
                }

                // 詳細画面で妊婦健診受診年月日指定か妊婦健診判定指定が条件ありの場合
                if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND H.BNENDO IS NOT NULL                                                                  " + Constants.vbCr;
                }
            }

            // 詳細検索にて住民区分が設定されていない場合に住登外を範囲に含める
            if (jokenjumin != "1")
            {
                pubf_SQLGetNinpuKensakuRet += " UNION                                                                                                               " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += " SELECT                                                                                                              " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "     A.BNENDO                                                                                      AS BNENDO         " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,A.BKOFUNO                                                                                     AS BKOFUNO        " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,A.BEDANO                                                                                      AS BEDANO         " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,C.NAME                                                                                        AS HAHANAME       " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,dbo.CHG_WAREKI(0,C.BYMD)                                                                      AS HAHABYMD       " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,dbo.CHG_WAREKI(0,B.HETODOKYMD)                                                                AS HETODOKYMD     " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,B.HESYUSU                                                                                     AS HESYUSU        " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,dbo.CHG_WAREKI(0,B.HEYOTEIYMD)                                                                AS HEBUNYMD       " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,C.ADRS                                                                                        AS ADRS           " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,''                                                                                            AS JKBN           " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,''                                                                                            AS JUMINKBN       " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,D.JUNI                                                                                        AS JUNI           " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,E.KOJINNO                                                                                     AS KOKOJINNO      " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,E.NAME                                                                                        AS KONAME         " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,E.SEX                                                                                         AS SEXKBN         " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,(SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '004' AND CD = E.SEX)              AS KOSEX          " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    ,dbo.CHG_WAREKI(0,E.BYMD)                                                                      AS KOBYMD         " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += " FROM                                                                                                                " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    TM_BHNSHAKKO A                                                                                                   " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    INNER JOIN TM_BHNSKIHON B On A.BNENDO = B.BNENDO AND A.BKOFUNO = B.BKOFUNO AND A.EDANO = B.EDANO                 " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    INNER JOIN TM_BHNSJUTOGAI C On A.BNENDO = C.BNENDO AND A.BKOFUNO = C.BKOFUNO AND A.EDANO = C.EDANO              " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    LEFT JOIN TM_BHNYJO D ON A.BNENDO = D.BNENDO AND A.BKOFUNO = D.BKOFUNO AND A.BEDANO = D.BEDANO AND D.EDANO = 1  " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    LEFT JOIN TM_KKKOJIN E ON D.KOJINNO = E.KOJINNO                                                                  " + Constants.vbCr;

                if (string.IsNullOrEmpty(seirino) & (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1"))
                {
                    pubf_SQLGetNinpuKensakuRet += "    LEFT JOIN (SELECT DISTINCT BNENDO,BKOFUNO,EDANO FROM TM_BHNSNINKEN                                               " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "                WHERE 1 = 1                                                                                                           " + Constants.vbCr;

                    if (jokenninpukenshinbi == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "             AND JUSINYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(ninpukenshinbiTo) + "' " + Constants.vbCr;
                    }

                    if (jokennninpukenshinhantei == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND HANTEI IN ('DUMMY'                                                " + Constants.vbCr;
                        var loopTo3 = ninpukenshinhantei.Length - 1;
                        for (i = 0; i <= loopTo3; i++)
                            pubf_SQLGetNinpuKensakuRet += "        ,'" + ninpukenshinhantei[i] + "'                              " + Constants.vbCr;
                        pubf_SQLGetNinpuKensakuRet += "        )                                                                 " + Constants.vbCr;
                    }

                    pubf_SQLGetNinpuKensakuRet += "               ) F ON A.BNENDO = F.BNENDO AND A.BKOFUNO = F.BKOFUNO AND A.EDANO = F.EDANO                        " + Constants.vbCr;
                }

                pubf_SQLGetNinpuKensakuRet += " WHERE                                                                                                               " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "        A.EDANO = 1                                                                                                      " + Constants.vbCr;
                pubf_SQLGetNinpuKensakuRet += "    AND C.NTKBN= '2'                                                                                                      " + Constants.vbCr;

                // 整理番号
                if (!string.IsNullOrEmpty(bnendo) & !string.IsNullOrEmpty(bkofuno) & !string.IsNullOrEmpty(bedano))
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND A.BNENDO = " + bnendo + "                                                     " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "    AND A.BKOFUNO = " + bkofuno + "                                                   " + Constants.vbCr;
                    pubf_SQLGetNinpuKensakuRet += "    AND A.BEDANO = " + bedano + "                                                     " + Constants.vbCr;
                }
                else if (!string.IsNullOrEmpty(seirino))
                {
                    pubf_SQLGetNinpuKensakuRet += "    AND B.HEMKOJINNO = '" + seirino + "'                                              " + Constants.vbCr;
                }
                else
                {
                    // カナ氏名
                    if (!string.IsNullOrEmpty(kname))
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND C.KKNAME Like '" + CM_kyotu_proc.pubf_CnvKana(1, kname) + "%'                                                            " + Constants.vbCr;
                    }

                    if (!string.IsNullOrEmpty(bymd))
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND C.BYMD = '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bymd) + "'                                                                                    " + Constants.vbCr;
                    }

                    // 行政区区分
                    if (jokengyo == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND C.GYOCD IN ('DUMMY'                                                " + Constants.vbCr;
                        var loopTo4 = gyoseiku.Length - 1;
                        for (i = 0; i <= loopTo4; i++)
                            pubf_SQLGetNinpuKensakuRet += "        ,'" + gyoseiku[i] + "'                                         " + Constants.vbCr;
                        pubf_SQLGetNinpuKensakuRet += "        )                                                                  " + Constants.vbCr;
                    }

                    if (jokennenrei == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "   AND " + pubf_SQLJutogaiAge("", nenreisql, CM_kyotu_proc.pubf_CnvSeirekiYMD(kijunbi), "C");
                    }

                    if (jokentodokedesyusu == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND B.HESYUSU BETWEEN " + todokedesyusuFrom + "  AND " + todokedesyusuTo + " " + Constants.vbCr;
                    }

                    if (jokentodokedebi == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND B.HETODOKYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(todokedebiTo) + "' " + Constants.vbCr;
                    }

                    if (jokenbunben == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND B.HEYOTEIYMD BETWEEN '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiFrom) + "'  AND '" + CM_kyotu_proc.pubf_CnvSeirekiYMD(bunbenyoteibiTo) + "' " + Constants.vbCr;
                    }

                    if (jokenninpukenshinbi == "1" | jokennninpukenshinhantei == "1")
                    {
                        pubf_SQLGetNinpuKensakuRet += "    AND F.BNENDO IS NOT NULL                                                                                         " + Constants.vbCr;
                    }
                }
            }

            return pubf_SQLGetNinpuKensakuRet;
        }

        /// <summary>
        /// システムコード取得SQL
        /// </summary>
        /// <param name="pgid"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetSystemCode(string pgid)
        {
            string pubf_SQLGetSystemCodeRet = default;
            pubf_SQLGetSystemCodeRet = "SELECT                                                               " + Constants.vbCr;
            pubf_SQLGetSystemCodeRet += "        MAINCD  +   SUBCD1  +   SUBCD2  +   SUBCD3  AS  SYSTEMCD    " + Constants.vbCr;
            pubf_SQLGetSystemCodeRet += "FROM    dbo.TC_KKSYORI                                              " + Constants.vbCr;
            pubf_SQLGetSystemCodeRet += "WHERE   PGID    =   " + pgid + "                                    " + Constants.vbCr;
            return pubf_SQLGetSystemCodeRet;
        }

        /// <summary>
        /// 妊婦健診管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <param name="eda"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetNinpukensin(string nendo, string kofuno, string eda)
        {
            string pubf_SQLGetNinpukensinRet = default;
            pubf_SQLGetNinpukensinRet = "SELECT                                                " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "        B.BNENDO                       AS BNENDO     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BKOFUNO                      AS BKOFUNO    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.EDANO                        AS EDANO      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KENKAISU                     AS KENKAISU   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KOFUNO                       AS KOFUNO     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HAKKOFLG                     AS HAKKOFLG   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SYOKANFLG                    AS SYOKANFLG  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,dbo.CHG_WAREKI(0,B.JURIYMD)    AS JURIYMD    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,dbo.CHG_WAREKI(0,B.JUSINYMD)   AS JUSINYMD   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SYUSU                        AS SYUSU      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KIKANCD                      AS KIKANCD    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.YOSANCD                      AS YOSANCD    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.ISICD                        AS ISICD      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KHOSIKI                      AS KHOSIKI    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KETTO                        AS KETTO      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SYOKUGO                      AS SYOKUGO    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.GURUKOSU                     AS GURUKOSU   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KANSETUK                     AS KANSETUK   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HINKETU                      AS HINKETU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SYOKUSO                      AS SYOKUSO    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HBSKOGEN                     AS HBSKOGEN   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HCVKOGEN                     AS HCVKOGEN   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HCVKOTAI                     AS HCVKOTAI   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BAIDOKU                      AS BAIDOKU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HIV                          AS HIV        " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.FUSIN                        AS FUSIN      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TPURAZUMA                    AS TPURAZUMA  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HTLV                         AS HTLV       " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.ATL                          AS ATL        " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SSAIBO                       AS SSAIBO     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SSAIKIN                      AS SSAIKIN    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BRENSA                       AS BRENSA     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SIKYUKEKKA                   AS SIKYUKEKKA " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.SIKSIKKAN                    AS SIKSIKKAN  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TKEN                         AS TKEN       " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TKOFUNO                      AS TKOFUNO    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.THAKKOFLG                    AS THAKKOFLG  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TKEKKA                       AS TKEKKA     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.MAXKETU                      AS MAXKETU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.MINKETU                      AS MINKETU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.FUSYU                        AS FUSYU      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TAIJU                        AS TAIJU      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HATUIKU                      AS HATUIKU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.[TO]                         AS [TO]       " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.TANPAKU                      AS TANPAKU    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.KETON                        AS KETON      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.HANTEI                       AS HANTEI     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.NYUIN                        AS NYUIN      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BYOMEI1                      AS BYOMEI1    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BYOMEI2                      AS BYOMEI2    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BYOMEI3                      AS BYOMEI3    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BYOMEI4                      AS BYOMEI4    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.RENRAKU1                     AS RENRAKU1   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.RENRAKU2                     AS RENRAKU2   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.RENRAKUTA                    AS RENRAKUTA  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       ,B.BIKO                         AS BIKO       " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "FROM    dbo.TM_BHNSHAKKO  A                          " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "    INNER   JOIN    TM_BHNSNINKEN  B                 " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "        ON  A.BNENDO = B.BNENDO                      " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       AND  A.BKOFUNO = B.BKOFUNO                    " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "       AND  A.EDANO = B.EDANO                        " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "WHERE   A.EDANO = 1                                  " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "    AND A.BNENDO = " + nendo + "                     " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "    AND A.BKOFUNO = " + kofuno + "                   " + Constants.vbCr;
            pubf_SQLGetNinpukensinRet += "    AND A.BEDANO = " + eda + "                       " + Constants.vbCr;
            return pubf_SQLGetNinpukensinRet;
        }

        /// <summary>
        /// 産婦健診管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <param name="eda"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetSanpu(string nendo, string kofuno, string eda)
        {
            string pubf_SQLGetSanpuRet = default;
            pubf_SQLGetSanpuRet = "SELECT                                                " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "        B.BNENDO                        AS BNENDO    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.BKOFUNO                       AS BKOFUNO   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.EDANO                         AS EDANO     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.GETUKBN                       AS GETUKBN   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,dbo.CHG_WAREKI(0,B.JUSINYMD)    AS JUSINYMD  " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.TASIFLG                       AS TASIFLG   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.KIKANCD                       AS KIKANCD   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.MAXKETU                       AS MAXKETU   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.MINKETU                       AS MINKETU   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.SYOKUSO                       AS SYOKUSO   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.[TO]                          AS [TO]      " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.TANPAKU                       AS TANPAKU   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.SENKETU                       AS SENKETU   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.SINJOKYO                      AS SINJOKYO  " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.KIBUN                         AS KIBUN     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.GEKKEI                        AS GEKKEI    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.HOMON                         AS HOMON     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.HANTEI                        AS HANTEI    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.KETUFLG                       AS KETUFLG   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.TANFLG                        AS TANFLG    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.FUSYUFLG                      AS FUSYUFLG  " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.HINFLG                        AS HINFLG    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.TOFLG                         AS TOFLG     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.SENFLG                        AS SENFLG    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.TAFLG                         AS TAFLG     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       ,B.BIKO                          AS BIKO      " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "FROM    dbo.TM_BHNSHAKKO  A                          " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "    INNER   JOIN    TM_BHNSSANPU  B                  " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "        ON  A.BNENDO = B.BNENDO                      " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       AND  A.BKOFUNO = B.BKOFUNO                    " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "       AND  A.EDANO = B.EDANO                        " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "WHERE   A.EDANO = 1                                  " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "    AND A.BNENDO = " + nendo + "                     " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "    AND A.BKOFUNO = " + kofuno + "                   " + Constants.vbCr;
            pubf_SQLGetSanpuRet += "    AND A.BEDANO = " + eda + "                       " + Constants.vbCr;
            return pubf_SQLGetSanpuRet;
        }

        /// <summary>
        /// 機関マスタ取得SQL
        /// </summary>
        /// <param name="subcd"></param>
        /// <param name="cd"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKikan(string subcd, string cd)
        {
            string pubf_SQLGetKikanRet = default;
            pubf_SQLGetKikanRet = "SELECT                                   " + Constants.vbCr;
            pubf_SQLGetKikanRet += "        KI.KIKANCD  AS  DATA            " + Constants.vbCr;
            pubf_SQLGetKikanRet += "       ,KI.KIKANMEI AS  LABEL           " + Constants.vbCr;
            pubf_SQLGetKikanRet += "FROM    dbo.TC_KKKIKAN  KI              " + Constants.vbCr;
            pubf_SQLGetKikanRet += "    INNER   JOIN    TC_KKKIKAN_SUB  KS  " + Constants.vbCr;
            pubf_SQLGetKikanRet += "        ON  KI.KIKANCD  =   KS.KIKANCD  " + Constants.vbCr;
            pubf_SQLGetKikanRet += "WHERE   KS.SUBCD   =   '" + subcd + "'  " + Constants.vbCr;
            pubf_SQLGetKikanRet += "    AND KS.CD      =   '" + cd + "'     " + Constants.vbCr;
            pubf_SQLGetKikanRet += "ORDER   BY  KS.KIKANCD                  " + Constants.vbCr;
            return pubf_SQLGetKikanRet;
        }

        /// <summary>
        /// スタッフマスタ取得SQL
        /// </summary>
        /// <param name="subcd"></param>
        /// <param name="cd"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetStaff(string subcd, string cd, string kbn = "")
        {
            string pubf_SQLGetStaffRet = default;
            pubf_SQLGetStaffRet = "SELECT                                   " + Constants.vbCr;
            pubf_SQLGetStaffRet += "        ST.STAFFCD  AS  DATA            " + Constants.vbCr;
            pubf_SQLGetStaffRet += "       ,ST.NAME     AS  LABEL           " + Constants.vbCr;
            pubf_SQLGetStaffRet += "FROM    dbo.TC_KKSTAFF  ST              " + Constants.vbCr;
            pubf_SQLGetStaffRet += "    INNER   JOIN    TC_KKSTAFF_SUB  SS  " + Constants.vbCr;
            pubf_SQLGetStaffRet += "        ON  ST.STAFFCD  =   SS.STAFFCD  " + Constants.vbCr;
            pubf_SQLGetStaffRet += "    LEFT JOIN   dbo.TC_KKCF  CF         " + Constants.vbCr;
            pubf_SQLGetStaffRet += "        ON  CF.MAINCD  = '01'           " + Constants.vbCr;
            pubf_SQLGetStaffRet += "       AND  CF.SUBCD   = '026'          " + Constants.vbCr;
            pubf_SQLGetStaffRet += "       AND  CF.CD      = ST.SYOKUSYU1   " + Constants.vbCr;
            pubf_SQLGetStaffRet += "WHERE   SS.SUBCD   =   '" + subcd + "'  " + Constants.vbCr;
            pubf_SQLGetStaffRet += "    AND SS.CD      =   '" + cd + "'     " + Constants.vbCr;
            if (!string.IsNullOrEmpty(kbn))
            {
                pubf_SQLGetStaffRet += "    AND (CF.KBN2 IS NULL            " + Constants.vbCr;
                pubf_SQLGetStaffRet += "     OR  CF.KBN2 = '" + kbn + "')   " + Constants.vbCr;
            }
            pubf_SQLGetStaffRet += "ORDER   BY  ST.STAFFCD                  " + Constants.vbCr;
            return pubf_SQLGetStaffRet;
        }

        /// <summary>
        /// 妊産婦出生歴管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetSyussyo(string nendo, string kofuno)
        {
            string pubf_SQLGetSyussyoRet = default;
            pubf_SQLGetSyussyoRet = "SELECT                            " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "     BNENDO        AS BNENDO     " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,BKOFUNO       AS BKOFUNO    " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,EDANO         AS EDANO      " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,JUNI          AS JUNI       " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,KOJINNO       AS KOJINNO    " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,NENREI        AS NENREI     " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,TAIJU         AS TAIJU      " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,NSYUSU        AS NSYUSU     " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,IJO           AS IJO        " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,KENKO         AS KENKO      " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    ,BIKO          AS BIKO       " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "FROM    dbo.TM_BHNSSYUSSYO       " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "WHERE    EDANO = 1               " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    AND BNENDO = " + nendo + "   " + Constants.vbCr;
            pubf_SQLGetSyussyoRet += "    AND BKOFUNO = " + kofuno + " " + Constants.vbCr;
            return pubf_SQLGetSyussyoRet;
        }

        /// <summary>
        /// 妊産婦妊娠歴管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetNinsinreki(string nendo, string kofuno)
        {
            string pubf_SQLGetNinsinrekiRet = default;
            pubf_SQLGetNinsinrekiRet = "SELECT                                                  " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "     BNENDO                           AS BNENDO        " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,BKOFUNO                          AS BKOFUNO       " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,EDANO                            AS EDANO         " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,ROWNO                            AS ROWNO         " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,KOJINNO                          AS KOJINNO       " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,dbo.CHG_WAREKI(0, NINSINYMD)     AS NINSINYMD     " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,NREKICD                          AS NREKICD       " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,JINKOSIZEN                       AS JINKOSIZEN    " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,NSYUSU                           AS NSYUSU        " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    ,BIKO                             AS BIKO          " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "FROM     dbo.TM_BHNSNINREKI                            " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "WHERE    EDANO = 1                                     " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    AND BNENDO = " + nendo + "                         " + Constants.vbCr;
            pubf_SQLGetNinsinrekiRet += "    AND BKOFUNO = " + kofuno + "                       " + Constants.vbCr;
            return pubf_SQLGetNinsinrekiRet;
        }

        /// <summary>
        /// 妊産婦同居管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetDokyo(string nendo, string kofuno)
        {
            string pubf_SQLGetDokyoRet = default;
            pubf_SQLGetDokyoRet = "SELECT                                                  " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "     BNENDO                               AS BNENDO     " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,BKOFUNO                              AS BKOFUNO    " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,EDANO                                AS EDANO      " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,ROWNO                                AS ROWNO      " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,SIMEI                                AS SIMEI      " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,NENREI                               AS NENREI     " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,TUZUKI                               AS TUZUKI     " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,HOIKUFLG                             AS HOIKUFLG   " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,SOUDANFLG                            AS SOUDANFLG  " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,KYORYOKFLG                           AS KYORYOKFLG " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    ,BIKO                                 AS BIKO       " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "FROM     dbo.TM_BHNSDOKYO                               " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "WHERE    EDANO = 1                                      " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    AND BNENDO = " + nendo + "                          " + Constants.vbCr;
            pubf_SQLGetDokyoRet += "    AND BKOFUNO = " + kofuno + "                        " + Constants.vbCr;
            return pubf_SQLGetDokyoRet;
        }

        /// <summary>
        /// 妊産婦主訴管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetSyuso(string nendo, string kofuno)
        {
            string pubf_SQLGetSyusoRet = default;
            pubf_SQLGetSyusoRet = "SELECT                                                  " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "     BNENDO                                AS BNENDO   " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    ,BKOFUNO                               AS BKOFUNO  " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    ,EDANO                                 AS EDANO    " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    ,NAIYOCD                               AS NAIYOCD  " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    ,SIDO                                  AS SIDO     " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "FROM     dbo.TM_BHNSSYUSO                              " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "WHERE    EDANO = 1                                     " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    AND BNENDO = " + nendo + "                         " + Constants.vbCr;
            pubf_SQLGetSyusoRet += "    AND BKOFUNO = " + kofuno + "                       " + Constants.vbCr;
            return pubf_SQLGetSyusoRet;
        }

        /// <summary>
        /// 妊産婦母親学級管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetGakkyu(string nendo, string kofuno)
        {
            string pubf_SQLGetGakkyuRet = default;
            pubf_SQLGetGakkyuRet = "SELECT                                                    " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "     BNENDO                                  AS BNENDO   " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,BKOFUNO                                 AS BKOFUNO  " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,EDANO                                   AS EDANO    " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,dbo.CHG_WAREKI(0, SANKAYMD)             AS SANKAYMD " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,MAXKETU                                 AS MAXKETU  " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,MINKETU                                 AS MINKETU  " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,[TO]                                    AS [TO]     " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,TANPAKU                                 AS TANPAKU  " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,SENKETU                                 AS SENKETU  " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,HSYOJO                                  AS HSYOJO   " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    ,CMNT                                    AS CMNT     " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "FROM     dbo.TM_BHNSGAKKYU                               " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "WHERE    EDANO = 1                                       " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    AND BNENDO = " + nendo + "                           " + Constants.vbCr;
            pubf_SQLGetGakkyuRet += "    AND BKOFUNO = " + kofuno + "                         " + Constants.vbCr;
            return pubf_SQLGetGakkyuRet;
        }

        /// <summary>
        /// 妊産婦疾病状況管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetSippei(string nendo, string kofuno)
        {
            string pubf_SQLGetSippeiRet = default;
            pubf_SQLGetSippeiRet = "SELECT                                                   " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "     BNENDO                                 AS BNENDO   " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,BKOFUNO                                AS BKOFUNO  " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,EDANO                                  AS EDANO    " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,SIPPEICD                               AS SIPPEICD " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,TIRYO                                  AS TIRYO    " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,NYUIN                                  AS NYUIN    " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    ,BIKO                                   AS BIKO     " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "FROM     dbo.TM_BHNSSIPPEI                              " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "WHERE    EDANO = 1                                      " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    AND BNENDO = " + nendo + "                          " + Constants.vbCr;
            pubf_SQLGetSippeiRet += "    AND BKOFUNO = " + kofuno + "                        " + Constants.vbCr;
            return pubf_SQLGetSippeiRet;
        }

        /// <summary>
        /// 妊産婦保健指導管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetSido(string nendo, string kofuno)
        {
            string pubf_SQLGetSidoRet = default;
            pubf_SQLGetSidoRet = "SELECT                                                   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "     BNENDO                                 AS BNENDO   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,BKOFUNO                                AS BKOFUNO  " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,EDANO                                  AS EDANO    " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,SIDOCD                                 AS SIDOCD   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,dbo.CHG_WAREKI(0, SIDOYMD)             AS SIDOYMD  " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,TANTO1                                 AS TANTO1   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,TANTO2                                 AS TANTO2   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,CMNT                                   AS CMNT     " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    ,SONOTA                                 AS SONOTA   " + Constants.vbCr;
            pubf_SQLGetSidoRet += "FROM     dbo.TM_BHNSSIDO                                " + Constants.vbCr;
            pubf_SQLGetSidoRet += "WHERE    EDANO = 1                                      " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    AND BNENDO = " + nendo + "                          " + Constants.vbCr;
            pubf_SQLGetSidoRet += "    AND BKOFUNO = " + kofuno + "                        " + Constants.vbCr;
            return pubf_SQLGetSidoRet;
        }

        /// <summary>
        /// 妊産婦要管理内容管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetYokanri(string nendo, string kofuno)
        {
            string pubf_SQLGetYokanriRet = default;
            pubf_SQLGetYokanriRet = "SELECT                                                      " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "     BNENDO                                   AS BNENDO    " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,BKOFUNO                                  AS BKOFUNO   " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,EDANO                                    AS EDANO     " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,KANRICD                                  AS KANRICD   " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,FHOUHOU                                  AS FHOUHOU   " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,dbo.CHG_WAREKI(0, FYOTEIYMD)             AS FYOTEIYMD " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,dbo.CHG_WAREKI(0, FKANYMD)               AS FKANYMD   " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    ,BIKO                                     AS BIKO      " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "FROM     dbo.TM_BHNSYOKANRI                                " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "WHERE    EDANO = 1                                         " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    AND BNENDO = " + nendo + "                             " + Constants.vbCr;
            pubf_SQLGetYokanriRet += "    AND BKOFUNO = " + kofuno + "                           " + Constants.vbCr;
            return pubf_SQLGetYokanriRet;
        }

        /// <summary>
        /// 手帳番号取得SQL
        /// </summary>
        /// <param name="kojinno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetTetyobango(string kojinno)
        {
            string pubf_SQLGetTetyobangoRet = default;
            pubf_SQLGetTetyobangoRet = " SELECT                                                                 " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "         B.BNENDO                                       AS BNENDO      " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        ,B.BKOFUNO                                      AS BKOFUNO     " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        ,B.BEDANO                                       AS BEDANO      " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        ,A.HESINKI                                      AS HESINKIKBN  " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        ,(Select NAIYO From TC_KKCF Where MAINCD = '04'                " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "          And SUBCD = '039' And CD = A.HESINKI)         AS HESINKI     " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        ,dbo.CHG_WAREKI(0,A.HETODOKYMD)                 AS HAKKOYMD    " + Constants.vbCr; // 届出年月日が発行年月日
            pubf_SQLGetTetyobangoRet += " FROM dbo.TM_BHNSKIHON A                                               " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "        INNER JOIN TM_BHNSHAKKO B                                      " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "           ON A.BNENDO = B.BNENDO                                      " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "           AND A.BKOFUNO = B.BKOFUNO                                   " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "           AND A.EDANO = B.EDANO                                       " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += " WHERE  A.EDANO = 1                                                    " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += "    AND A.HEMKOJINNO = '" + kojinno + "'                               " + Constants.vbCr;
            pubf_SQLGetTetyobangoRet += " ORDER BY BNENDO DESC, BKOFUNO DESC, BEDANO DESC                       " + Constants.vbCr;
            return pubf_SQLGetTetyobangoRet;
        }

        /// <summary>
        /// 世帯構成取得SQL
        /// </summary>
        /// <param name="dsetaino"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLSetaiKosei(string dsetaino)
        {
            string pubf_SQLSetaiKoseiRet = default;
            pubf_SQLSetaiKoseiRet = "SELECT   " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "        KO.KOJINNO  AS  KOJINNO             " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "       ,KO.NAME     AS  NAME                " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "       ,KO.ZOKUNM   AS  ZOKUNM              " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "       ,C1.NAIYO    AS  JKBN                " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "FROM    dbo.TM_KKKOJIN  KO                  " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "    LEFT    JOIN    dbo.TC_KKCF C1          " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "        ON  C1.MAINCD   =   '01'            " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "        AND C1.SUBCD    =   '008'           " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "        AND KO.JKBN     =   C1.CD           " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "WHERE   KO.SETAINO  =   '" + dsetaino + "'  " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "ORDER   BY  KO.JKBN                         " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "           ,KO.ZOKU                         " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "           ,KO.BYMD                         " + Constants.vbCr;
            pubf_SQLSetaiKoseiRet += "           ,KO.KNAME                        " + Constants.vbCr;
            return pubf_SQLSetaiKoseiRet;
        }

        /// <summary>
        /// 個人照会 個人情報取得SQL
        /// </summary>
        /// <param name="kojinno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKojin(string kojinno)
        {
            string pubf_SQLGetKojinRet = default;
            pubf_SQLGetKojinRet = "SELECT                                                                           " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        NAME                                                        AS  NAME    " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,dbo.AGE_COMP(KO.BYMD,GETDATE())                             AS  AGE     " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,'(' +   dbo.CHG_WAREKI(0,GETDATE()) +   '現在)'             AS  KIJUN   " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,C1.NAIYO                                                    AS  HOKEN   " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,C2.NAIYO                                                    AS  KAZEI   " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,GY.MEISYO                                                   AS  GYONM   " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,SE.ADRS + ISNULL(SE.KATA,'')                                AS  ADRS    " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,KS.TEL1                                                     AS  TEL     " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,KO.SETAINO                                                  AS  SETAINO " + Constants.vbCr;
            // 2015/02/12 ikuno 妊婦検索の戻値に住民となった日、住民でなくなった日を追加 >>
            pubf_SQLGetKojinRet += "       ,KO.JUYMD                                                    AS  JUYMD   " + Constants.vbCr;
            pubf_SQLGetKojinRet += "       ,KO.JNYMD                                                    AS  JNYMD   " + Constants.vbCr;
            // 2015/02/12 ikuno 妊婦検索の戻値に住民となった日、住民でなくなった日を追加 <<
            pubf_SQLGetKojinRet += "FROM    dbo.TM_KKKOJIN  KO                                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    INNER   JOIN    dbo.TM_KKKOJIN_SUB  KS                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  KO.KOJINNO  =   KS.KOJINNO                                          " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    INNER   JOIN    dbo.TM_KKSETAI      SE                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  KO.SETAINO  =   SE.SETAINO                                          " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    INNER   JOIN    dbo.TM_KKSETAI_SUB  SS                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  KO.SETAINO  =   SS.SETAINO                                          " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    LEFT    JOIN    dbo.TC_KKTIKU       GY                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  GY.MAINCD   =   '02'                                                " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        AND SE.GYOCD    =   GY.CD                                               " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    LEFT    JOIN    dbo.TC_KKCF         C1                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  C1.MAINCD   =   '01'                                                " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        AND C1.SUBCD    =   '020'                                               " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        AND KS.HOKEN    =   C1.CD                                               " + Constants.vbCr;
            pubf_SQLGetKojinRet += "    LEFT    JOIN    dbo.TC_KKCF         C2                                      " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        ON  C2.MAINCD   =   '01'                                                " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        AND C2.SUBCD    =   '025'                                               " + Constants.vbCr;
            pubf_SQLGetKojinRet += "        AND SS.SZEIFLG  =   C2.CD                                               " + Constants.vbCr;
            pubf_SQLGetKojinRet += "WHERE   KO.KOJINNO  =   '" + kojinno + "'                                       " + Constants.vbCr;
            return pubf_SQLGetKojinRet;
        }

        /// <summary>
        /// 個人照会　妊産婦要管理内容管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo">年度</param>
        /// <param name="kofuno">交付番号</param>
        /// <remarks></remarks>
        public string pubf_SQLGetKojinYokanri(string nendo, string kofuno)
        {
            string pubf_SQLGetKojinYokanriRet = default;
            pubf_SQLGetKojinYokanriRet = "SELECT                                               " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "     C.NAIYO                           AS NAIYO     " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    ,C2.NAIYO                          AS FHOUHOU   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    ,dbo.CHG_WAREKI(0,YO.FYOTEIYMD)    AS FYOTEIYMD " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    ,dbo.CHG_WAREKI(0,YO.FKANYMD)      AS FKANYMD   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    ,YO.BIKO                           AS BIKO      " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "FROM     dbo.TM_BHNSYOKANRI YO                      " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    LEFT    JOIN    dbo.TC_KKCF C                   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        ON  C.MAINCD    =   '04'                    " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        AND C.SUBCD     =   '017'                   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        AND YO.KANRICD  =   C.CD                    " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    LEFT    JOIN    dbo.TC_KKCF C2                  " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        ON  C2.MAINCD   =   '04'                    " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        AND C2.SUBCD    =   '042'                   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "        AND YO.FHOUHOU  =   C2.CD                   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "WHERE   YO.EDANO = 1                                " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    AND YO.BNENDO = " + nendo + "                   " + Constants.vbCr;
            pubf_SQLGetKojinYokanriRet += "    AND YO.BKOFUNO = " + kofuno + "                 " + Constants.vbCr;
            return pubf_SQLGetKojinYokanriRet;
        }

        /// <summary>
        /// 個人照会　　妊婦健診管理マスタ取得SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <param name="eda"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKojinNinpukensin(string nendo, string kofuno, string eda)
        {
            string pubf_SQLGetKojinNinpukensinRet = default;
            pubf_SQLGetKojinNinpukensinRet = "SELECT                                                " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "        B.KENKAISU                     AS KENKAISU   " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "       ,dbo.CHG_WAREKI(0,B.JUSINYMD)   AS JUSINYMD   " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "       ,C1.NAIYO                       AS HANTEI     " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "       ,B.BIKO                         AS BIKO       " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "FROM    dbo.TM_BHNSHAKKO  A                          " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "    INNER   JOIN    TM_BHNSNINKEN  B                 " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "        ON  A.BNENDO = B.BNENDO                      " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "       AND  A.BKOFUNO = B.BKOFUNO                    " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "       AND  A.EDANO = B.EDANO                        " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "    LEFT    JOIN    dbo.TC_KKCF C1                   " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "        ON  C1.MAINCD   =   '04'                     " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "        AND C1.SUBCD    =   '031'                    " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "        AND B.HANTEI    =   C1.CD                    " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "WHERE   A.EDANO = 1                                  " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "    AND A.BNENDO = " + nendo + "                     " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "    AND A.BKOFUNO = " + kofuno + "                   " + Constants.vbCr;
            pubf_SQLGetKojinNinpukensinRet += "    AND A.BEDANO = " + eda + "                       " + Constants.vbCr;
            return pubf_SQLGetKojinNinpukensinRet;
        }

        /// <summary>
        /// 妊産婦問診管理マスタ取得SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetMonsin(string bnendo, string bkofuno)
        {
            string pubf_SQLGetMonsinRet = default;
            pubf_SQLGetMonsinRet = " SELECT                                    " + Constants.vbCr;
            pubf_SQLGetMonsinRet += "        BNENDO              AS BNENDO     " + Constants.vbCr; // 母子手帳年度
            pubf_SQLGetMonsinRet += "       ,BKOFUNO             AS BKOFUNO    " + Constants.vbCr; // 母子手帳交付番号
            pubf_SQLGetMonsinRet += "       ,EDANO               AS EDANO      " + Constants.vbCr; // 枝番号
            pubf_SQLGetMonsinRet += "       ,KENSINKBN           AS KENSINKBN  " + Constants.vbCr; // 健診区分
            pubf_SQLGetMonsinRet += "       ,MONSINCD            AS MONSINCD   " + Constants.vbCr; // 問診ＣＤ
            pubf_SQLGetMonsinRet += "       ,MONSINEDA           AS MONSINEDA  " + Constants.vbCr; // 問診枝番
            pubf_SQLGetMonsinRet += "       ,DATATYPE1           AS DATATYPE1  " + Constants.vbCr; // データタイプ１
            pubf_SQLGetMonsinRet += "       ,DATATYPE2           AS DATATYPE2  " + Constants.vbCr; // データタイプ２
            pubf_SQLGetMonsinRet += "       ,DATATYPE3           AS DATATYPE3  " + Constants.vbCr; // データタイプ３
            pubf_SQLGetMonsinRet += "       ,DATATYPE4           AS DATATYPE4  " + Constants.vbCr; // データタイプ４
            pubf_SQLGetMonsinRet += "       ,dbo.CHG_WAREKI(0,DATATYPE5) AS DATATYPE5  " + Constants.vbCr; // データタイプ５
            pubf_SQLGetMonsinRet += " FROM dbo.TM_BHNSMONSIN                   " + Constants.vbCr;
            pubf_SQLGetMonsinRet += " WHERE                                    " + Constants.vbCr;
            pubf_SQLGetMonsinRet += "        EDANO = 1                         " + Constants.vbCr;

            if (Strings.Len(bnendo) > 0)
            {
                pubf_SQLGetMonsinRet += "AND BNENDO    =   " + bnendo + "   " + Constants.vbCr;
            }
            if (Strings.Len(bkofuno) > 0)
            {
                pubf_SQLGetMonsinRet += "AND BKOFUNO    =   " + bkofuno + "   " + Constants.vbCr;
            }

            return pubf_SQLGetMonsinRet;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタカウント取得SQL
        /// </summary>
        /// <param name="kensakuList"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetCountTM_BHNSHAKKO(string[] kensakuList)
        {
            string pubf_SQLGetCountTM_BHNSHAKKORet = default;
            pubf_SQLGetCountTM_BHNSHAKKORet = "SELECT                        " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "        COUNT(*) AS CNT      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "FROM    dbo.TM_BHNSHAKKO      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "WHERE   BNENDO    =   " + kensakuList[0] + "      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "    AND BKOFUNO   =   " + kensakuList[1] + "      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "    AND BEDANO    =   " + kensakuList[2] + "      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSHAKKORet += "    AND EDANO     =   1                           " + Constants.vbCr;
            return pubf_SQLGetCountTM_BHNSHAKKORet;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタコピー登録SQL
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="kensakuList"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLCopyToroku(string userid, string[] kensakuList)
        {
            string pubf_SQLCopyTorokuRet = default;
            pubf_SQLCopyTorokuRet = "INSERT   INTO    dbo.TM_BHNSHAKKO                  " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "    (                                             " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "        BNENDO                                    " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,BKOFUNO                                   " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,BEDANO                                    " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,EDANO                                     " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,DELFLG                                    " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,USERID                                    " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,SYORIYMD                                  " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,JUNI                                      " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "    )                                             " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "VALUES                                            " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "    (                                             " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "        " + CM_kyotu_proc.pubf_CnvNull(kensakuList[0], 1) + "   " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(kensakuList[1], 1) + "   " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(kensakuList[2], 1) + "   " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,'1'                                       " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,0                                         " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ," + CM_kyotu_proc.pubf_CnvNull(userid, 1) + "           " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ,GETDATE()                                 " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "       ," + CM_kyotu_proc.pubf_CnvNull("1", 1) + "              " + Constants.vbCr;
            pubf_SQLCopyTorokuRet += "    )                                             " + Constants.vbCr;
            return pubf_SQLCopyTorokuRet;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertBhbhakko(string[] insertItem)
        {
            string pubf_SQLInsertBhbhakkoRet = default;
            pubf_SQLInsertBhbhakkoRet = "INSERT   INTO    dbo.TM_BHNSHAKKO                " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "        BNENDO                                  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,BKOFUNO                                 " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,BEDANO                                  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,EDANO                                   " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,DELFLG                                  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,USERID                                  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,SYORIYMD                                " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,JUNI                                    " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "    )                                           " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "VALUES                                          " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "    (                                           " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,'1'                                     " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,0                                       " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ,GETDATE()                               " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "  " + Constants.vbCr;
            pubf_SQLInsertBhbhakkoRet += "    )                                           " + Constants.vbCr;
            return pubf_SQLInsertBhbhakkoRet;
        }

        /// <summary>
        /// 妊産婦発行情報管理マスタ更新SQL
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="kensakuList"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateBhbhakko(string userid, string[] kensakuList)
        {
            string pubf_SQLUpdateBhbhakkoRet = default;
            pubf_SQLUpdateBhbhakkoRet = "UPDATE   dbo.TM_BHNSHAKKO                          " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "SET USERID      = " + CM_kyotu_proc.pubf_CnvNull(userid, 1) + " " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "   ,SYORIYMD    =   GETDATE()                     " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "WHERE   BNENDO    =   " + kensakuList[0] + "      " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "    AND BKOFUNO   =   " + kensakuList[1] + "      " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "    AND BEDANO    =   " + kensakuList[2] + "      " + Constants.vbCr;
            pubf_SQLUpdateBhbhakkoRet += "    AND EDANO     =   1                           " + Constants.vbCr;
            return pubf_SQLUpdateBhbhakkoRet;
        }

        /// <summary>
        /// 妊産婦基本情報管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLBhnskihon(string[] insertItem)
        {
            string pubf_SQLBhnskihonRet = default;
            pubf_SQLBhnskihonRet = "INSERT   INTO    dbo.TM_BHNSKIHON                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "    (                                                                    " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "        BNENDO                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,BKOFUNO                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,EDANO                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HESINKI                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEKETUFLG                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEMKOJINNO                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEFKOJINNO                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSSATO                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSADRS                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSSNNAME                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSTEL                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHOMON                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHOKENSI                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HESUISIN                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HETUTIFLG                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEMUKOFLG                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEMUKORIYU                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HETODOKYMD                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HESYUSU                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEBUNFLG                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHOKEN                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHONFLG                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEGEKKEYMD                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HETETYOS                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HETETYOK                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEYOTEIYMD                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEYOTEI                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEYOTEITA                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHAKKOKBN                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HEHAKKO                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMKSAKI                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMKINMU                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMKTEL                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMBKYUKA                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMAKYUKA                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMTAIYMD                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMIKUJI                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMSIGOTO                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMTHOHO                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KMTJIKAN                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZPET                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZPCMNT                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZENMEI                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZJUKYO                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZKTATE                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZKSU                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZSOON                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,KZHIATARI                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKSIKKAN                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKSIKKANTA                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKKOUKETUATU                                                     " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKTYUDOKU                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKHBS                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKSANJOKU                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKATL                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,NKKIOTA                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,STSINTYO                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,STTAIJUN                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,STTAIJUB                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,STBMI                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSKYORYOKU                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSKYOSYA                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSTANTO1                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSTANTO2                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSSAKESYU                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSSAKERYO                                                        " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSHONSU                                                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSEIYO                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSHENSYOKU                                                       " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSGYU                                                            " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSGYURYO                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,HSCMNT                                                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ,SOGOCMNT                                                         " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "    )                                                                    " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "VALUES                                                                   " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "    (                                                                    " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 0) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "                           " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[11], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[12], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[13], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[14], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[15], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[16], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[17]), 1) + "      " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[18], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[19], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[20], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[21], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[22]), 1) + "      " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[23], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[24], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[25]), 1) + "      " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[26], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[27], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[28], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[29], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[30], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[31], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[32], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[33], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[34], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(insertItem[35]), 1) + "      " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[36], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[37], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[38], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[39], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[40], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[41], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[42], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[43], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[44], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[45], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[46], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[47], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[48], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[49], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[72], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[50], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[51], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[52], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[53], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[54], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[55], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[56], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[57], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[58], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[59], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[60], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[61], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[62], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[63], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[64], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[65], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[66], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[67], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[68], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[69], 0) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[70], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[71], 1) + "                          " + Constants.vbCr;
            pubf_SQLBhnskihonRet += "    )   ";
            return pubf_SQLBhnskihonRet;
        }

        /// <summary>
        /// 住民情報取得SQL
        /// </summary>
        /// <param name="kojinno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetJyumin(string kojinno)
        {
            string pubf_SQLGetJyuminRet = default;
            pubf_SQLGetJyuminRet = "SELECT                                                      " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "        A.NAME                         AS  SIMEI           " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "       ,dbo.AGE_COMP(A.BYMD,GETDATE()) AS  NENREI          " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "       ,A.ZOKUNM                       AS  TUZUKI          " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "FROM    dbo.TM_KKKOJIN  A                                  " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "    INNER    JOIN  (                                       " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "        SELECT                                             " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "                  SETAINO                                  " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "        FROM      dbo.TM_KKKOJIN                           " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "        WHERE     KOJINNO  =  '" + kojinno + "'            " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "    ) B ON A.SETAINO = B.SETAINO                           " + Constants.vbCr;
            pubf_SQLGetJyuminRet += "WHERE   A.JKBN BETWEEN '0' AND '4'                         " + Constants.vbCr;
            return pubf_SQLGetJyuminRet;
        }

        /// <summary>
        /// 住民情報取得SQL
        /// </summary>
        /// <param name="kojinno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetJuJnYmd(string kojinno)
        {
            string pubf_SQLGetJuJnYmdRet = default;
            pubf_SQLGetJuJnYmdRet = "SELECT                                                      " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "        A.NAME                         AS  SIMEI           " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "       ,dbo.AGE_COMP(A.BYMD,GETDATE()) AS  NENREI          " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "       ,A.ZOKUNM                       AS  TUZUKI          " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "       ,A.JUYMD                        AS  JUYMD           " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "       ,A.JNYMD                        AS  JNYMD           " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "FROM    dbo.TM_KKKOJIN  A                                  " + Constants.vbCr;
            pubf_SQLGetJuJnYmdRet += "WHERE A.KOJINNO  = " + CM_kyotu_proc.pubf_CnvNull(kojinno, 1) + "        " + Constants.vbCr;
            return pubf_SQLGetJuJnYmdRet;
        }

        /// <summary>
        /// 宛名マスタ（個人）の項目更新のSQLを返す
        /// </summary>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateKojin(string userid, string kojinno, string[] updateItemList)
        {
            string pubf_SQLUpdateKojinRet = default;
            pubf_SQLUpdateKojinRet = "UPDATE   dbo.TM_KKKOJIN                                                            " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "    SET USERID   = " + CM_kyotu_proc.pubf_CnvNull(userid, 1) + "                                " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "       ,SYORIYMD = GETDATE()                                                      " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "       ,KNAME    = " + CM_kyotu_proc.pubf_CnvNull(updateItemList[0], 1) + "                     " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "       ,NAME     = " + CM_kyotu_proc.pubf_CnvNull(updateItemList[1], 1) + "                     " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "       ,BYMD     = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(updateItemList[2]), 1) + " " + Constants.vbCr;
            pubf_SQLUpdateKojinRet += "WHERE   KOJINNO  = '" + kojinno + "'                                              " + Constants.vbCr;
            return pubf_SQLUpdateKojinRet;
        }

        /// <summary>
        /// 宛名サブマスタ（個人）の項目更新のSQLを返す
        /// </summary>
        /// <param name="ninpuTitiKkbn">妊婦父親区分</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateKojinSub(string ninpuTitiKkbn, string kojinno, string[] updateItemList)
        {
            string pubf_SQLUpdateKojinSubRet = default;
            pubf_SQLUpdateKojinSubRet = "UPDATE   TM_KKKOJIN_SUB                                                          " + Constants.vbCr;
            pubf_SQLUpdateKojinSubRet += "    SET USERID      =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[0], 1) + "              " + Constants.vbCr;
            pubf_SQLUpdateKojinSubRet += "       ,SYORIYMD    =   GETDATE()                                               " + Constants.vbCr;
            switch (ninpuTitiKkbn ?? "")
            {
                case KBN_HOGO:
                    {
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOKOJINNO =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[1], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOKNAME   =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[2], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGONAME    =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[3], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOBYMD    =   " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(updateItemList[4]), 1) + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOADRS    =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[5], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOTEL     =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[6], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,HOGOZOKUNM  =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[7], 1) + "              " + Constants.vbCr;
                        break;
                    }

                default:
                    {
                        pubf_SQLUpdateKojinSubRet += "       ,TEL1        =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[1], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,TEL2        =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[2], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,MADRS1      =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[3], 1) + "              " + Constants.vbCr;
                        pubf_SQLUpdateKojinSubRet += "       ,MADRS2      =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[4], 1) + "              " + Constants.vbCr;

                        if (!string.IsNullOrEmpty(updateItemList[5]))
                        {
                            pubf_SQLUpdateKojinSubRet += "       ,KETUEKI     =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[5], 1) + "          " + Constants.vbCr;
                        }

                        if (ninpuTitiKkbn == "1")
                        {
                            // 職業
                            pubf_SQLUpdateKojinSubRet += "       ,SYOKUGYO     =  " + CM_kyotu_proc.pubf_CnvNull(updateItemList[6], 1) + "          " + Constants.vbCr;
                            // 会社名
                            pubf_SQLUpdateKojinSubRet += "       ,KAISYA       =  " + CM_kyotu_proc.pubf_CnvNull(updateItemList[7], 1) + "          " + Constants.vbCr;
                        }

                        break;
                    }
            }

            pubf_SQLUpdateKojinSubRet += "WHERE   KOJINNO =   '" + kojinno + "'                                           " + Constants.vbCr;
            return pubf_SQLUpdateKojinSubRet;
        }

        /// <summary>
        /// 宛名マスタ（世帯）の項目更新のSQLを返す
        /// </summary>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSetai(string kojinno, string[] updateItemList)
        {
            string pubf_SQLUpdateSetaiRet = default;
            pubf_SQLUpdateSetaiRet = "UPDATE   KS                                                            " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "    SET KS.USERID      =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[0], 1) + " " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "       ,KS.SYORIYMD    =   GETDATE()                                  " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "       ,KS.GYOCD       =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[1], 1) + " " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "       ,KS.ADRS       =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[2], 1) + "  " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "FROM    dbo.TM_KKKOJIN KO                                             " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "        INNER    JOIN dbo.TM_KKSETAI KS                               " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "              ON KO.SETAINO = KS.SETAINO                              " + Constants.vbCr;
            pubf_SQLUpdateSetaiRet += "WHERE   KO.KOJINNO =   '" + kojinno + "'                              " + Constants.vbCr;
            return pubf_SQLUpdateSetaiRet;
        }

        /// <summary>
        /// 宛名サブマスタ（世帯）の項目更新のSQLを返す
        /// </summary>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="kojinno">個人番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSetaiSub(string userid, string kojinno, string[] updateItemList)
        {
            string pubf_SQLUpdateSetaiSubRet = default;
            pubf_SQLUpdateSetaiSubRet = "UPDATE KS                                                              " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "    SET  KS.USERID      =   " + CM_kyotu_proc.pubf_CnvNull(userid, 1) + "           " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "        ,KS.SYORIYMD   =   GETDATE()                                  " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "        ,KS.TEL        =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[0], 1) + " " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "        ,KS.FAX        =   " + CM_kyotu_proc.pubf_CnvNull(updateItemList[1], 1) + " " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "FROM    dbo.TM_KKKOJIN KO                                             " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "        INNER    JOIN dbo.TM_KKSETAI_SUB KS                           " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "              ON KO.SETAINO = KS.SETAINO                              " + Constants.vbCr;
            pubf_SQLUpdateSetaiSubRet += "WHERE   KO.KOJINNO =   '" + kojinno + "'                              " + Constants.vbCr;
            return pubf_SQLUpdateSetaiSubRet;
        }

        /// <summary>
        /// 妊産婦住登外父母情報管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="ninpuTitiKkbn"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteJyutogai(string bnendo, string bkofuno, string ninpuTitiKkbn)
        {
            string pubf_SQLDeleteJyutogaiRet = default;
            pubf_SQLDeleteJyutogaiRet = "DELETE                                 " + Constants.vbCr;
            pubf_SQLDeleteJyutogaiRet += "    FROM    dbo.TM_BHNSJUTOGAI        " + Constants.vbCr;
            pubf_SQLDeleteJyutogaiRet += "WHERE EDANO   =   1                   " + Constants.vbCr;
            pubf_SQLDeleteJyutogaiRet += "  AND BNENDO  = " + bnendo + "        " + Constants.vbCr;
            pubf_SQLDeleteJyutogaiRet += "  AND BKOFUNO = " + bkofuno + "       " + Constants.vbCr;
            pubf_SQLDeleteJyutogaiRet += "  AND NTKBN = '" + ninpuTitiKkbn + "' " + Constants.vbCr;
            return pubf_SQLDeleteJyutogaiRet;
        }

        /// <summary>
        /// 妊産婦住登外父母情報管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertJyutogai(string[] insertItem)
        {
            string pubf_SQLInsertJyutogaiRet = default;
            pubf_SQLInsertJyutogaiRet = "INSERT   INTO    dbo.TM_BHNSJUTOGAI                                 " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "    (                                                              " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "        BNENDO                                                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,BKOFUNO                                                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,EDANO                                                      " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,NTKBN                                                      " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,KNAME                                                      " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,KKNAME                                                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,NAME                                                       " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,BYMD                                                       " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,ADRS                                                       " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,GYOCD                                                      " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,SETAITEL                                                   " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,FAX                                                        " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,TEL1                                                       " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,TEL2                                                       " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,MADRS1                                                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,MADRS2                                                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,KETUEKI                                                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,SYOKUGYO                                                   " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ,KINMU                                                      " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "    )                                                              " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "VALUES                                                             " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "    (                                                              " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[11], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[12], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[13], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[14], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[15], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[16], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[17], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[18], 1) + "                    " + Constants.vbCr;
            pubf_SQLInsertJyutogaiRet += "    )                                                              " + Constants.vbCr;
            return pubf_SQLInsertJyutogaiRet;
        }

        /// <summary>
        /// 母子手帳交付番号取得SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofukbn"></param>
        /// <param name="nextKofukbn"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetHakko(string nendo, string kofukbn, string nextKofukbn)
        {
            string pubf_SQLGetHakkoRet = default;
            pubf_SQLGetHakkoRet = "SELECT                                                           " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "     ISNULL(MAX(BKOFUNO), " + (Conversions.ToDouble(kofukbn) - 1d) + ") + 1   AS BKOFUNO " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "    ,1                                               AS EDANO   " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "FROM     dbo.TM_BHNSHAKKO                                       " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "WHERE    EDANO = 1                                              " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "    AND BNENDO = " + nendo + "                                  " + Constants.vbCr;
            pubf_SQLGetHakkoRet += "    AND BKOFUNO BETWEEN  " + kofukbn + " AND (" + nextKofukbn + " - 1 )    " + Constants.vbCr;
            return pubf_SQLGetHakkoRet;
        }

        /// <summary>
        /// 最大母子手帳枝番号取得SQL
        /// </summary>
        /// <param name="nendo">母子手帳年度</param>
        /// <param name="kofuno">母子手帳交付番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetBEDANO(string nendo, string kofuno)
        {
            string pubf_SQLGetBEDANORet = default;
            pubf_SQLGetBEDANORet = "SELECT                                                    " + Constants.vbCr;
            pubf_SQLGetBEDANORet += "     ISNULL(MAX(BEDANO), 0)                  AS BEDANO   " + Constants.vbCr;
            pubf_SQLGetBEDANORet += "FROM     dbo.TM_BHNSHAKKO                                " + Constants.vbCr;
            pubf_SQLGetBEDANORet += "WHERE    EDANO = 1                                       " + Constants.vbCr;
            pubf_SQLGetBEDANORet += "    AND BNENDO = " + nendo + "                           " + Constants.vbCr;
            pubf_SQLGetBEDANORet += "    AND BKOFUNO =  " + kofuno + "                        " + Constants.vbCr;
            return pubf_SQLGetBEDANORet;
        }

        /// <summary>
        /// 動的項目情報取得SQL
        /// </summary>
        /// <param name="bnendo">母子手帳年度</param>
        /// <param name="bkofuno">母子手帳交付番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetTC_BHKKITEM(string bnendo, string bkofuno)
        {
            string pubf_SQLGetTC_BHKKITEMRet = default;
            pubf_SQLGetTC_BHKKITEMRet = "SELECT                                                         " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "           IT.BOSIKBN                           AS BOSIKBN    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.GETUKAIKBN                        AS GETUKAIKBN " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.KENSINKBN                         AS KENSINKBN  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.ITEMCD                            AS ITEMCD     " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.ITEMEDA                           AS ITEMEDA    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.ITEMNM                            AS ITEMNM     " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.DATATYPE                          AS DATATYPE   " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.TANI                              AS TANI       " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.CFID                              AS CFID       " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.CFMAINCD                          AS CFMAINCD   " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.CFSUBCD                           AS CFSUBCD    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.SYOKITI                           AS SYOKITI    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.NARABI                            AS NARABI     " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,IT.SIYOFLG                           AS SIYOFLG    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.BNENDO                           AS BNENDO     " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.BKOFUNO                          AS BKOFUNO    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.EDANO                            AS EDANO      " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.KENKAISU                         AS KENKAISU   " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.DATATYPE1                        AS DATATYPE1  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.DATATYPE2                        AS DATATYPE2  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.DATATYPE3                        AS DATATYPE3  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,NSI.DATATYPE4                        AS DATATYPE4  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "          ,dbo.CHG_WAREKI(0, NSI.DATATYPE5)     AS DATATYPE5  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "FROM    dbo.TC_BHKKITEM IT                                    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "        LEFT JOIN TM_BHNSITEM NSI                             " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "               ON NSI.BNENDO  = '" + bnendo + "'              " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND NSI.BKOFUNO = '" + bkofuno + "'             " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND NSI.EDANO   = 1                             " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND NSI.EDANO   = 1                             " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND IT.GETUKAIKBN = NSI.KENKAISU                " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND IT.ITEMCD = NSI.ITEMCD                      " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "              AND IT.ITEMEDA = NSI.ITEMEDA                    " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "WHERE   IT.BOSIKBN = '1'                                      " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "       AND IT.SIYOFLG = 1                                     " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "       AND IT.KENSINKBN  = 1                                  " + Constants.vbCr;
            pubf_SQLGetTC_BHKKITEMRet += "ORDER BY IT.NARABI                                            " + Constants.vbCr;
            return pubf_SQLGetTC_BHKKITEMRet;
        }

        /// <summary>
        /// 動的項目で使用するコンボボックスのMAINCDとSUBCDを取得するSQL
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKKITEM_CFCD()
        {
            string pubf_SQLGetKKITEM_CFCDRet = default;
            pubf_SQLGetKKITEM_CFCDRet = "SELECT DISTINCT                                   " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "        IT.CFID                    AS CFID       " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "       ,IT.CFMAINCD                AS CFMAINCD   " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "       ,IT.CFSUBCD                 AS CFSUBCD    " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "FROM    dbo.TC_BHKKITEM IT                       " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "WHERE  IT.BOSIKBN = '1'                          " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "       AND IT.SIYOFLG = 1                        " + Constants.vbCr;
            pubf_SQLGetKKITEM_CFCDRet += "       AND IT.CFID    IS NOT NULL                " + Constants.vbCr;
            return pubf_SQLGetKKITEM_CFCDRet;
        }

        /// <summary>
        /// 妊産婦動的項目管理マスタ削除SQL
        /// </summary>
        /// <param name="bnendo">母子手帳年度</param>
        /// <param name="bkofuno">母子手帳交付番号</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateTM_BHNSITEMEda(string bnendo, string bkofuno)
        {
            string pubf_SQLUpdateTM_BHNSITEMEdaRet = default;
            pubf_SQLUpdateTM_BHNSITEMEdaRet = "UPDATE dbo.TM_BHNSITEM                      " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMEdaRet += " SET  EDANO       =   EDANO + 1            " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMEdaRet += "WHERE   BNENDO  = " + bnendo + "           " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMEdaRet += "AND   BKOFUNO  = " + bkofuno + "           " + Constants.vbCr;
            return pubf_SQLUpdateTM_BHNSITEMEdaRet;
        }

        /// <summary>
        /// 妊産婦動的項目管理マスタ登録SQL
        /// </summary>
        /// <param name="insertItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertTM_BHNSITEM(string[] insertItem)
        {
            string pubf_SQLInsertTM_BHNSITEMRet = default;
            pubf_SQLInsertTM_BHNSITEMRet = "INSERT   INTO    dbo.TM_BHNSITEM                                     " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "        BNENDO                                                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,BKOFUNO                                                     " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,EDANO                                                       " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,KENKAISU                                                    " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,ITEMCD                                                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,ITEMEDA                                                     " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,DATATYPE1                                                   " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,DATATYPE2                                                   " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,DATATYPE3                                                   " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,DATATYPE4                                                   " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ,DATATYPE5                                                   " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "    )                                                               " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "VALUES                                                              " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "    (                                                               " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "        " + CM_kyotu_proc.pubf_CnvNull(insertItem[0], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[1], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[2], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[3], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[4], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[5], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[6], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[7], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[8], 0) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[9], 1) + "                      " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "       ," + CM_kyotu_proc.pubf_CnvNull(insertItem[10], 1) + "                     " + Constants.vbCr;
            pubf_SQLInsertTM_BHNSITEMRet += "    )                                                               " + Constants.vbCr;
            return pubf_SQLInsertTM_BHNSITEMRet;
        }

        /// <summary>
        /// 妊産婦動的項目管理マスタカウント取得SQL
        /// </summary>
        /// <param name="bnendo">母子手帳年度</param>
        /// <param name="bkofuno">母子手帳交付番号</param>
        /// <param name="kenkaisu">健診回数</param>
        /// <param name="itemcd">項目CD</param>
        /// <param name="itemeda">項目枝番</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetCountTM_BHNSITEM(string bnendo, string bkofuno, string kenkaisu, string itemcd, string itemeda)
        {
            string pubf_SQLGetCountTM_BHNSITEMRet = default;
            pubf_SQLGetCountTM_BHNSITEMRet = "SELECT                                   " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "        COUNT(*)          AS CNT        " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "FROM    dbo.TM_BHNSITEM                 " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "WHERE   BNENDO = " + bnendo + "         " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "    AND BKOFUNO = " + bkofuno + "       " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "    AND EDANO  = 1                      " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "    AND KENKAISU = '" + kenkaisu + "'   " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "    AND ITEMCD = '" + itemcd + "'       " + Constants.vbCr;
            pubf_SQLGetCountTM_BHNSITEMRet += "    AND ITEMEDA = " + itemeda + "       " + Constants.vbCr;
            return pubf_SQLGetCountTM_BHNSITEMRet;
        }

        /// <summary>
        /// 妊産婦動的項目管理マスタ更新SQL
        /// </summary>
        /// <param name="updateItem"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateTM_BHNSITEM(string[] updateItem)
        {
            string pubf_SQLUpdateTM_BHNSITEMRet = default;
            pubf_SQLUpdateTM_BHNSITEMRet = "UPDATE dbo.TM_BHNSITEM                                         " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += " SET    DATATYPE1 = " + CM_kyotu_proc.pubf_CnvNull(updateItem[6], 1) + "    " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += "       ,DATATYPE2 = " + CM_kyotu_proc.pubf_CnvNull(updateItem[7], 1) + "    " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += "       ,DATATYPE3 = " + CM_kyotu_proc.pubf_CnvNull(updateItem[8], 1) + "    " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += "       ,DATATYPE4 = " + CM_kyotu_proc.pubf_CnvNull(updateItem[9], 1) + "    " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += "       ,DATATYPE5 = " + CM_kyotu_proc.pubf_CnvNull(updateItem[10], 1) + "   " + Constants.vbCr;
            pubf_SQLUpdateTM_BHNSITEMRet += " WHERE BNENDO   = " + CM_kyotu_proc.pubf_CnvNull(updateItem[0], 1) + "      " + Constants.vbCr; // 母子手帳年度
            pubf_SQLUpdateTM_BHNSITEMRet += " AND   BKOFUNO  = " + CM_kyotu_proc.pubf_CnvNull(updateItem[1], 1) + "      " + Constants.vbCr; // 母子手帳交付番号
            pubf_SQLUpdateTM_BHNSITEMRet += " AND   EDANO    = " + CM_kyotu_proc.pubf_CnvNull(updateItem[2], 1) + "      " + Constants.vbCr; // 枝番号
            pubf_SQLUpdateTM_BHNSITEMRet += " AND   KENKAISU = " + CM_kyotu_proc.pubf_CnvNull(updateItem[3], 1) + "      " + Constants.vbCr; // 健診回数
            pubf_SQLUpdateTM_BHNSITEMRet += " AND   ITEMCD   = " + CM_kyotu_proc.pubf_CnvNull(updateItem[4], 1) + "      " + Constants.vbCr; // 項目ＣＤ
            pubf_SQLUpdateTM_BHNSITEMRet += " AND   ITEMEDA  = " + CM_kyotu_proc.pubf_CnvNull(updateItem[5], 1) + "      " + Constants.vbCr; // 項目枝番
            return pubf_SQLUpdateTM_BHNSITEMRet;
        }

        /// <summary>
        /// 要管理内容有メッセージ表示フラグ取得SQL
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetYokanriMsgFlg()
        {
            string pubf_SQLGetYokanriMsgFlgRet = default;
            pubf_SQLGetYokanriMsgFlgRet = "SELECT                                                           " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "    CASE WHEN CF.NAIYO = '1' THEN '1'                           " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "         ELSE '0' END     AS MSGFLG                             " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "FROM                                                            " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "    dbo.TC_KKCF CF                                              " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "WHERE                                                           " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "    CF.MAINCD = '98'                                            " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "AND CF.SUBCD  = '405'                                           " + Constants.vbCr;
            pubf_SQLGetYokanriMsgFlgRet += "AND CF.CD     = '001'                                           " + Constants.vbCr;
            return pubf_SQLGetYokanriMsgFlgRet;
        }

        /// <summary>
        /// CFを抽出するためのSQL文を返す。(※KBN2ソート版）
        /// </summary>
        /// <param name="maincd">MEINCD</param>
        /// <param name="subcd">SUBCD</param>
        /// <param name="kbn1">KBN1</param>
        /// <remarks></remarks>
        public string pubf_SQLCf2(string maincd, string subcd, string kbn1)
        {
            string ret = "";

            ret = "SELECT                                        " + Constants.vbCr;
            ret += "     CF.CD       AS  DATA                    " + Constants.vbCr;
            ret += "    ,CF.NAIYO    AS  LABEL                   " + Constants.vbCr;
            ret += "    ,CF.BIKO     AS  BIKO                    " + Constants.vbCr;
            ret += "    ,CF.KBN1     AS  KBN1                    " + Constants.vbCr;
            ret += "    ,CF.KBN2     AS  KBN2                    " + Constants.vbCr;
            ret += "    ,CF.KBN3     AS  KBN3                    " + Constants.vbCr;
            ret += "    ,CM.KETA     AS  KETA                    " + Constants.vbCr;
            ret += "FROM dbo.TC_KKCF CF                          " + Constants.vbCr;
            ret += "     LEFT    JOIN    dbo.TC_KKCFMAIN CM      " + Constants.vbCr;
            ret += "         ON  CF.MAINCD   =   CM.MAINCD       " + Constants.vbCr;
            ret += "         AND CF.SUBCD    =   CM.SUBCD        " + Constants.vbCr;
            ret += "WHERE    CF.MAINCD   =   '" + maincd + "'    " + Constants.vbCr;
            ret += "     AND CF.SUBCD    =   '" + subcd + "'     " + Constants.vbCr;
            ret += "     AND CF.KBN1     =   '" + kbn1 + "'      " + Constants.vbCr;
            ret += "ORDER    BY  CF.KBN2, CF.CD                  " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画情報取得SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKojinSien(string bnendo, string bkofuno)
        {
            string ret = "";

            ret = " SELECT             " + Constants.vbCr;
            ret += "    GAITO          " + Constants.vbCr;
            ret += "   ,BIKO01         " + Constants.vbCr;
            ret += "   ,BIKO02         " + Constants.vbCr;
            ret += "   ,BIKO03         " + Constants.vbCr;
            ret += "   ,BIKO04         " + Constants.vbCr;
            ret += "   ,BIKO05         " + Constants.vbCr;
            ret += "   ,BIKO06         " + Constants.vbCr;
            ret += "   ,BIKO07         " + Constants.vbCr;
            ret += "   ,BIKO08         " + Constants.vbCr;
            ret += "   ,BIKO09         " + Constants.vbCr;
            ret += "   ,BIKO10         " + Constants.vbCr;
            ret += "   ,BIKO11         " + Constants.vbCr;
            ret += "   ,BIKO12         " + Constants.vbCr;
            ret += "   ,BIKO           " + Constants.vbCr;
            ret += "   ,dbo.CHG_WAREKI(0, KEIKAKUYMD) AS KEIKAKUYMD " + Constants.vbCr;
            ret += "   ,KEIKAKUSTAFF   " + Constants.vbCr;
            ret += "   ,SOGOKADAI      " + Constants.vbCr;
            ret += "   ,MOKUHYO        " + Constants.vbCr;
            ret += "   ,KEIKAKUHOHOMAIN" + Constants.vbCr;
            ret += "   ,RANK           " + Constants.vbCr;
            ret += "   ,dbo.CHG_WAREKI(0, SOGOHYOKAYMD) AS SOGOHYOKAYMD " + Constants.vbCr;
            ret += "   ,SOGOHYOKASTAFF  " + Constants.vbCr;
            ret += "   ,SOGOHYOKANAIYO  " + Constants.vbCr;
            ret += "   ,SOGOHYOKAKEKKA  " + Constants.vbCr;
            ret += "FROM               " + Constants.vbCr;
            ret += "    TM_BHNSIEN     " + Constants.vbCr;
            ret += "WHERE (0 = 0)      " + Constants.vbCr;
            ret += "    AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            ret += "    AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            ret += "    AND EDANO   = 1 ";

            return ret;
        }

        /// <summary>
        /// 支援計画(サブ)情報取得SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKojinSienSub(string bnendo, string bkofuno)
        {
            string ret = "";

            ret = " SELECT     " + Constants.vbCr;
            ret += "    GAITO  " + Constants.vbCr;
            ret += "FROM               " + Constants.vbCr;
            ret += "    TM_BHNSIEN_SUB " + Constants.vbCr;
            ret += "WHERE (0 = 0)      " + Constants.vbCr;
            ret += "    AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            ret += "    AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            ret += "    AND EDANO   = 1 ";

            return ret;
        }

        /// <summary>
        /// 支援計画(プラン)情報取得SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLGetKojinSienPlan(string bnendo, string bkofuno)
        {
            string ret = "";

            ret = " SELECT          										" + Constants.vbCr;
            ret += "       HY.PLANNO										" + Constants.vbCr;
            ret += "      ,dbo.CHG_WAREKI(0, SI.KEIKAKUYMD)	AS KEIKAKUYMD	" + Constants.vbCr;
            ret += "      ,SI.KEIKAKUTIME									" + Constants.vbCr;
            ret += "      ,SI.KEIKAKUHOHO									" + Constants.vbCr;
            ret += "      ,SI.KEIKAKUSTAFF									" + Constants.vbCr;
            ret += "      ,SI.KEIKAKUNAIYO									" + Constants.vbCr;
            ret += "      ,dbo.CHG_WAREKI(0, SI.SIENYMD)	AS SIENYMD	    " + Constants.vbCr;
            ret += "      ,SI.SIENSTIME						AS SIENSTIME	" + Constants.vbCr;
            ret += "      ,SI.SIENHOHO						AS SIENHOHO	    " + Constants.vbCr;
            ret += "      ,SI.SIENSTAFF						AS SIENSTAFF	" + Constants.vbCr;
            ret += "      ,SI.SIENNAIYO						AS SIENNAIYO	" + Constants.vbCr;
            ret += "      ,dbo.CHG_WAREKI(0, SI.HYOKAYMD)	AS HYOKAYMD		" + Constants.vbCr;
            ret += "      ,SI.HYOKASTAFF									" + Constants.vbCr;
            ret += "      ,SI.HYOKAKEKKA									" + Constants.vbCr;
            ret += "      ,SI.HYOKANAIYO									" + Constants.vbCr;
            // 画面非表示データ
            ret += "      ,SI.SIENNO    									" + Constants.vbCr;
            ret += "      ,SI.SIENSYOZOKU									" + Constants.vbCr;
            ret += "      ,SI.SIENKBN										" + Constants.vbCr;
            ret += "      ,SI.SIENETIME										" + Constants.vbCr;
            ret += "      ,SI.SIENAGE										" + Constants.vbCr;
            ret += "      ,SI.SIENAGEM										" + Constants.vbCr;
            ret += "      ,SI.SIENKEKKA										" + Constants.vbCr;
            ret += "      ,SI.JIKAI											" + Constants.vbCr;
            ret += "      ,SI.JIKAIYMD                              		" + Constants.vbCr;
            ret += "      ,SI.JIKAIYOSTIME									" + Constants.vbCr;
            ret += "      ,SI.JIKAIYOETIME									" + Constants.vbCr;
            ret += "      ,CASE WHEN SI.JIKAIKAKUNINFLG = 0 THEN 0          " + Constants.vbCr;
            ret += "             ELSE 1 END              AS JIKAIKAKUNINFLG " + Constants.vbCr;
            ret += "      ,SI.SODANKANKEI									" + Constants.vbCr;
            ret += "      ,SI.SODANKOJINNO									" + Constants.vbCr;
            ret += "      ,SI.SODANNAME										" + Constants.vbCr;
            ret += "      ,SI.SODANRENRAKU									" + Constants.vbCr;
            ret += "      ,SI.BIBO											" + Constants.vbCr;
            ret += "      ,CASE WHEN SI.BIBOKAKUNINFLG = 0 THEN 0           " + Constants.vbCr;
            ret += "             ELSE 1 END              AS BIBOKAKUNINFLG  " + Constants.vbCr;
            ret += "      ,CASE WHEN SI.TYUIFLG = 0 THEN 0                  " + Constants.vbCr;
            ret += "             ELSE 1 END              AS TYUIFLG         " + Constants.vbCr;
            ret += "      ,SI.ADDDATE										" + Constants.vbCr;
            ret += "      ,SI.TUSERID										" + Constants.vbCr;
            ret += "      ,CASE WHEN HY.DELCANF = 0 THEN 0                  " + Constants.vbCr;
            ret += "             ELSE 1 END              AS DELCANF         " + Constants.vbCr;
            ret += "  FROM dbo.TM_BHSIEN SI									" + Constants.vbCr;
            ret += "  INNER JOIN dbo.TM_BHSIEN_NSHYOJI HY					" + Constants.vbCr;
            ret += "	ON SI.SIENNO = HY.SIENNO							" + Constants.vbCr;
            ret += "  WHERE  (0 = 0)										" + Constants.vbCr;
            ret += "	AND SI.DELFLG   = 0									" + Constants.vbCr;
            ret += "	AND HY.EDANO    = 1									" + Constants.vbCr;
            ret += "	AND HY.BNENDO   = " + bnendo + "					" + Constants.vbCr;
            ret += "	AND HY.BKOFUNO  = " + bkofuno + "					" + Constants.vbCr;
            ret += "  ORDER BY HY.PLANNO DESC         						" + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画情報削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSien(string bnendo, string bkofuno)
        {
            string ret = "";

            ret = " DELETE FROM TM_BHNSIEN " + Constants.vbCr;
            ret += "WHERE (0 = 0)      " + Constants.vbCr;
            ret += "    AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            ret += "    AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            ret += "    AND EDANO   = 1 " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(サブ)情報削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSienSub(string bnendo, string bkofuno)
        {
            string ret = "";

            ret = " DELETE FROM TM_BHNSIEN_SUB " + Constants.vbCr;
            ret += "WHERE (0 = 0)      " + Constants.vbCr;
            ret += "    AND BNENDO  = " + bnendo + "  " + Constants.vbCr;
            ret += "    AND BKOFUNO = " + bkofuno + " " + Constants.vbCr;
            ret += "    AND EDANO   = 1 " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(プラン)情報削除SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLDeleteSienPlan(string userid, string bnendo, string bkofuno)
        {
            string ret = "";

            // TM_BHSIENの削除（削除権限がある場合）
            ret = "DELETE SI                            " + Constants.vbCr;
            ret += "FROM TM_BHSIEN SI                   " + Constants.vbCr;
            ret += "INNER JOIN TM_BHSIEN_NSHYOJI HY     " + Constants.vbCr;
            ret += "	ON SI.SIENNO = HY.SIENNO        " + Constants.vbCr;
            ret += "WHERE HY.BNENDO = " + bnendo + "    " + Constants.vbCr;
            ret += "	AND HY.BKOFUNO = " + bkofuno + "" + Constants.vbCr;
            ret += "	AND HY.EDANO = 1                " + Constants.vbCr;
            ret += "	AND HY.DELCANF = 1              " + Constants.vbCr;

            // TM_BHSIENの更新（削除権限がない場合、総合支援情報管理画面に存在しない項目はクリア）
            // ※総合支援情報管理画面で入力項目を増やす場合は注意すること。
            ret += "UPDATE SI                           " + Constants.vbCr;
            ret += "SET                                 " + Constants.vbCr;
            ret += "     [KEIKAKUYMD] = NULL	        " + Constants.vbCr;
            ret += "    ,[KEIKAKUTIME] = NULL	        " + Constants.vbCr;
            ret += "    ,[KEIKAKUHOHO] = NULL	        " + Constants.vbCr;
            ret += "    ,[KEIKAKUSTAFF] = NULL	        " + Constants.vbCr;
            ret += "    ,[KEIKAKUNAIYO] = NULL	        " + Constants.vbCr;
            // ret &= "    ,[SIENYMD] = NULL	            " & vbCr
            // ret &= "    ,[SIENSTIME] = NULL	        " & vbCr
            // ret &= "    ,[SIENHOHO] = NULL	            " & vbCr
            // ret &= "    ,[SIENSTAFF] = NULL	        " & vbCr
            // ret &= "    ,[SIENNAIYO] = NULL	        " & vbCr
            ret += "    ,[HYOKAYMD] = NULL	            " + Constants.vbCr;
            ret += "    ,[HYOKASTAFF] = NULL	        " + Constants.vbCr;
            ret += "    ,[HYOKANAIYO] = NULL	        " + Constants.vbCr;
            ret += "    ,[HYOKAKEKKA] = NULL	        " + Constants.vbCr;
            ret += "FROM TM_BHSIEN SI                   " + Constants.vbCr;
            ret += "INNER JOIN TM_BHSIEN_NSHYOJI HY     " + Constants.vbCr;
            ret += "	ON SI.SIENNO = HY.SIENNO        " + Constants.vbCr;
            ret += "WHERE HY.BNENDO = " + bnendo + "    " + Constants.vbCr;
            ret += "	AND HY.BKOFUNO = " + bkofuno + "" + Constants.vbCr;
            ret += "	AND HY.EDANO = 1                " + Constants.vbCr;
            ret += "	AND HY.DELCANF = 0              " + Constants.vbCr;

            // TM_BHSIEN_NSHYOJIの削除
            ret += "DELETE TM_BHSIEN_NSHYOJI            " + Constants.vbCr;
            ret += "WHERE BNENDO = " + bnendo + "       " + Constants.vbCr;
            ret += "	AND BKOFUNO = " + bkofuno + "   " + Constants.vbCr;
            ret += "	AND EDANO = 1                   " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画情報追加SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSien(string bnendo, string bkofuno, string[] items)
        {
            string ret = "";

            ret = " INSERT INTO TM_BHNSIEN (" + Constants.vbCr;
            ret += "    BNENDO         " + Constants.vbCr;
            ret += "   ,BKOFUNO        " + Constants.vbCr;
            ret += "   ,EDANO          " + Constants.vbCr;
            ret += "   ,GAITO          " + Constants.vbCr;
            ret += "   ,BIKO01         " + Constants.vbCr;
            ret += "   ,BIKO02         " + Constants.vbCr;
            ret += "   ,BIKO03         " + Constants.vbCr;
            ret += "   ,BIKO04         " + Constants.vbCr;
            ret += "   ,BIKO05         " + Constants.vbCr;
            ret += "   ,BIKO06         " + Constants.vbCr;
            ret += "   ,BIKO07         " + Constants.vbCr;
            ret += "   ,BIKO08         " + Constants.vbCr;
            ret += "   ,BIKO09         " + Constants.vbCr;
            ret += "   ,BIKO10         " + Constants.vbCr;
            ret += "   ,BIKO11         " + Constants.vbCr;
            ret += "   ,BIKO12         " + Constants.vbCr;
            ret += "   ,BIKO           " + Constants.vbCr;
            ret += "   ,KEIKAKUYMD     " + Constants.vbCr;
            ret += "   ,KEIKAKUSTAFF   " + Constants.vbCr;
            ret += "   ,SOGOKADAI      " + Constants.vbCr;
            ret += "   ,MOKUHYO        " + Constants.vbCr;
            ret += "   ,KEIKAKUHOHOMAIN " + Constants.vbCr;
            ret += "   ,RANK            " + Constants.vbCr;
            ret += "   ,SOGOHYOKAYMD    " + Constants.vbCr;
            ret += "   ,SOGOHYOKASTAFF  " + Constants.vbCr;
            ret += "   ,SOGOHYOKANAIYO  " + Constants.vbCr;
            ret += "   ,SOGOHYOKAKEKKA  " + Constants.vbCr;
            ret += ") VALUES (";
            ret += "    " + CM_kyotu_proc.pubf_CnvNull(bnendo, 0) + "                        " + Constants.vbCr; // BNENDO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(bkofuno, 0) + "                       " + Constants.vbCr; // BKOFUNO
            ret += "   ,1                                                      " + Constants.vbCr; // EDANO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[0], 1) + "                      " + Constants.vbCr; // 00:GAITO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[1], 1) + "                      " + Constants.vbCr; // 01:BIKO01
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[2], 1) + "                      " + Constants.vbCr; // 02:BIKO02
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[3], 1) + "                      " + Constants.vbCr; // 03:BIKO03
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[4], 1) + "                      " + Constants.vbCr; // 04:BIKO04
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[5], 1) + "                      " + Constants.vbCr; // 05:BIKO05
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[6], 1) + "                      " + Constants.vbCr; // 06:BIKO06
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[7], 1) + "                      " + Constants.vbCr; // 07:BIKO07
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[8], 1) + "                      " + Constants.vbCr; // 08:BIKO08
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[9], 1) + "                      " + Constants.vbCr; // 09:BIKO09
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[10], 1) + "                     " + Constants.vbCr; // 10:BIKO10
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[11], 1) + "                     " + Constants.vbCr; // 11:BIKO11
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[12], 1) + "                     " + Constants.vbCr; // 12:BIKO12
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[13], 1) + "                     " + Constants.vbCr; // 13:BIKO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[14]), 1) + " " + Constants.vbCr; // 14:KEIKAKUYMD
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[15], 1) + "                     " + Constants.vbCr; // 15:KEIKAKUSTAFF
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[16], 1) + "                     " + Constants.vbCr; // 16:SOGOKADAI
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[17], 1) + "                     " + Constants.vbCr; // 17:MOKUHYO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[18], 1) + "                     " + Constants.vbCr; // 18:KEIKAKUHOHOMAIN
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[19], 1) + "                     " + Constants.vbCr; // 19:RANK
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[20]), 1) + " " + Constants.vbCr; // 20:SOGOHYOKAYMD
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[21], 1) + "                     " + Constants.vbCr; // 21:SOGOHYOKASTAFF
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[22], 1) + "                     " + Constants.vbCr; // 22:SOGOHYOKANAIYO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[23], 1) + "                     " + Constants.vbCr; // 23:SOGOHYOKAKEKKA
            ret += ")                                                          " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(サブ)情報追加SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="gaito"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSienSub(string bnendo, string bkofuno, string gaito)
        {
            string ret = "";

            ret = " INSERT INTO TM_BHNSIEN_SUB (" + Constants.vbCr;
            ret += "    BNENDO         " + Constants.vbCr;
            ret += "   ,BKOFUNO        " + Constants.vbCr;
            ret += "   ,EDANO          " + Constants.vbCr;
            ret += "   ,GAITO          " + Constants.vbCr;
            ret += ") VALUES (         " + Constants.vbCr;
            ret += "    " + CM_kyotu_proc.pubf_CnvNull(bnendo, 0) + "  " + Constants.vbCr; // BNENDO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(bkofuno, 0) + " " + Constants.vbCr; // BKOFUNO
            ret += "   ,1                                " + Constants.vbCr; // EDANO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(gaito, 1) + "   " + Constants.vbCr; // GAITO
            ret += ")                                    " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(プラン表示)情報追加SQL
        /// </summary>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSienPlanHyoji(string bnendo, string bkofuno, string[] items)
        {
            string ret = "";
            // Dim sienno As String = items(0)

            ret = " INSERT INTO TM_BHSIEN_NSHYOJI (         " + Constants.vbCr;
            ret += "    BNENDO                              " + Constants.vbCr;
            ret += "   ,BKOFUNO                             " + Constants.vbCr;
            ret += "   ,EDANO                               " + Constants.vbCr;
            ret += "   ,PLANNO                              " + Constants.vbCr;
            ret += "   ,SIENNO                              " + Constants.vbCr;
            ret += "   ,DELCANF                             " + Constants.vbCr;
            ret += ") VALUES (                              " + Constants.vbCr;
            ret += "    " + CM_kyotu_proc.pubf_CnvNull(bnendo, 0) + "     " + Constants.vbCr; // BNENDO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(bkofuno, 0) + "    " + Constants.vbCr; // BKOFUNO
            ret += "   ,1                                   " + Constants.vbCr; // EDANO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[0], 0) + "   " + Constants.vbCr; // 0:PLANNO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[1], 0) + "   " + Constants.vbCr; // 1:SIENNO
            ret += "   ," + CM_kyotu_proc.pubf_CnvNull(items[2], 0) + "   " + Constants.vbCr; // 2:DELCANF
            ret += ")                                       " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(プラン)情報更新SQL
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLInsertSienPlan(string[] items)
        {
            string ret = "";

            ret = "INSERT INTO [dbo].[TM_BHSIEN]	                                                  " + Constants.vbCr;
            ret += "(                                                                                 " + Constants.vbCr;
            ret += "     [KEIKAKUYMD]	                                                              " + Constants.vbCr;
            ret += "    ,[KEIKAKUTIME]	                                                              " + Constants.vbCr;
            ret += "    ,[KEIKAKUHOHO]	                                                              " + Constants.vbCr;
            ret += "    ,[KEIKAKUSTAFF]	                                                              " + Constants.vbCr;
            ret += "    ,[KEIKAKUNAIYO]	                                                              " + Constants.vbCr;
            ret += "    ,[SIENYMD]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENSTIME]	                                                              " + Constants.vbCr;
            ret += "    ,[SIENHOHO]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENSTAFF]	                                                              " + Constants.vbCr;
            ret += "    ,[SIENNAIYO]	                                                              " + Constants.vbCr;
            ret += "    ,[HYOKAYMD]	                                                                  " + Constants.vbCr;
            ret += "    ,[HYOKASTAFF]	                                                              " + Constants.vbCr;
            ret += "    ,[HYOKANAIYO]	                                                              " + Constants.vbCr;
            ret += "    ,[HYOKAKEKKA]	                                                              " + Constants.vbCr;
            // 画面非表示
            ret += "    ,[SIENNO]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENSYOZOKU]	                                                              " + Constants.vbCr;
            ret += "    ,[SIENKBN]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENETIME]	                                                              " + Constants.vbCr;
            ret += "    ,[SIENAGE]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENAGEM]	                                                                  " + Constants.vbCr;
            ret += "    ,[SIENKEKKA]	                                                              " + Constants.vbCr;
            ret += "    ,[JIKAI]	                                                                  " + Constants.vbCr;
            ret += "    ,[JIKAIYMD]	                                                                  " + Constants.vbCr;
            ret += "    ,[JIKAIYOSTIME]	                                                              " + Constants.vbCr;
            ret += "    ,[JIKAIYOETIME]	                                                              " + Constants.vbCr;
            ret += "    ,[JIKAIKAKUNINFLG]                                                            " + Constants.vbCr;
            ret += "    ,[SODANKANKEI]	                                                              " + Constants.vbCr;
            ret += "    ,[SODANKOJINNO]	                                                              " + Constants.vbCr;
            ret += "    ,[SODANNAME]	                                                              " + Constants.vbCr;
            ret += "    ,[SODANRENRAKU]	                                                              " + Constants.vbCr;
            ret += "    ,[BIBO]	                                                                      " + Constants.vbCr;
            ret += "    ,[BIBOKAKUNINFLG]	                                                          " + Constants.vbCr;
            ret += "    ,[TYUIFLG]	                                                                  " + Constants.vbCr;
            ret += "    ,[ADDDATE]	                                                                  " + Constants.vbCr;
            ret += "    ,[TUSERID]	                                                                  " + Constants.vbCr;
            ret += "    ,[USERID]	                                                                  " + Constants.vbCr;
            ret += "    ,[DELFLG]	                                                                  " + Constants.vbCr;
            ret += "    ,[SYORIYMD]	                                                                  " + Constants.vbCr;
            ret += ")                                                                                 " + Constants.vbCr;
            ret += "SELECT                                                                            " + Constants.vbCr;
            ret += "     [KEIKAKUYMD]	    = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[0]), 1) + "   " + Constants.vbCr;
            ret += "    ,[KEIKAKUTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[1], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUHOHO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[2], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUSTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[3], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUNAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[4], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[5]), 1) + "   " + Constants.vbCr;
            ret += "    ,[SIENSTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[6], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENHOHO]	        = " + CM_kyotu_proc.pubf_CnvNull(items[7], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENSTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[8], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENNAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[9], 1) + "                       " + Constants.vbCr;
            ret += "    ,[HYOKAYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[10]), 1) + "  " + Constants.vbCr;
            ret += "    ,[HYOKASTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[11], 1) + "                      " + Constants.vbCr;
            ret += "    ,[HYOKANAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[12], 1) + "                      " + Constants.vbCr;
            ret += "    ,[HYOKAKEKKA]	    = " + CM_kyotu_proc.pubf_CnvNull(items[13], 1) + "                      " + Constants.vbCr;
            // 画面非表示
            ret += "    ,[SIENNO]	        = " + CM_kyotu_proc.pubf_CnvNull(items[14], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENSYOZOKU]	    = " + CM_kyotu_proc.pubf_CnvNull(items[15], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENKBN]	        = " + CM_kyotu_proc.pubf_CnvNull(items[16], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENETIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[17], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENAGE]	        = " + CM_kyotu_proc.pubf_CnvNull(items[18], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENAGEM]	        = " + CM_kyotu_proc.pubf_CnvNull(items[19], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENKEKKA]	    = " + CM_kyotu_proc.pubf_CnvNull(items[20], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAI]	        = " + CM_kyotu_proc.pubf_CnvNull(items[21], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(items[22], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYOSTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[23], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYOETIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[24], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIKAKUNINFLG]	= " + CM_kyotu_proc.pubf_CnvNull(items[25], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANKANKEI]	    = " + CM_kyotu_proc.pubf_CnvNull(items[26], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANKOJINNO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[27], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANNAME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[28], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANRENRAKU]	    = " + CM_kyotu_proc.pubf_CnvNull(items[29], 1) + "                      " + Constants.vbCr;
            ret += "    ,[BIBO]	            = " + CM_kyotu_proc.pubf_CnvNull(items[30], 1) + "                      " + Constants.vbCr;
            ret += "    ,[BIBOKAKUNINFLG]	= " + CM_kyotu_proc.pubf_CnvNull(items[31], 1) + "                      " + Constants.vbCr;
            ret += "    ,[TYUIFLG]	        = " + CM_kyotu_proc.pubf_CnvNull(items[32], 1) + " " + Constants.vbCr;
            ret = Conversions.ToString(ret + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,[ADDDATE]	        = ", Interaction.IIf(string.IsNullOrEmpty(items[33]), "GETDATE()", CM_kyotu_proc.pubf_CnvNull(items[33], 1))), "                      "), Constants.vbCr));
            ret = Conversions.ToString(ret + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,[TUSERID]	        = ", Interaction.IIf(string.IsNullOrEmpty(items[34]), CM_kyotu_proc.pubf_CnvNull(items[35], 1), CM_kyotu_proc.pubf_CnvNull(items[34], 1))), "                      "), Constants.vbCr));
            ret += "    ,[USERID]	        = " + CM_kyotu_proc.pubf_CnvNull(items[35], 1) + "                      " + Constants.vbCr;
            ret += "    ,[DELFLG]	        = 0                                                       " + Constants.vbCr;
            ret += "    ,[SYORIYMD]	        = GETDATE()                                               " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 支援計画(プラン)情報更新SQL
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSienPlan(string[] items)
        {
            string ret = "";

            ret = "UPDATE [dbo].[TM_BHSIEN]	                                                          " + Constants.vbCr;
            ret += "SET                                                                            " + Constants.vbCr;
            ret += "     [KEIKAKUYMD]	    = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[0]), 1) + "   " + Constants.vbCr;
            ret += "    ,[KEIKAKUTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[1], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUHOHO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[2], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUSTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[3], 1) + "                       " + Constants.vbCr;
            ret += "    ,[KEIKAKUNAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[4], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[5]), 1) + "   " + Constants.vbCr;
            ret += "    ,[SIENSTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[6], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENHOHO]	        = " + CM_kyotu_proc.pubf_CnvNull(items[7], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENSTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[8], 1) + "                       " + Constants.vbCr;
            ret += "    ,[SIENNAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[9], 1) + "                       " + Constants.vbCr;
            ret += "    ,[HYOKAYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(CM_kyotu_proc.pubf_CnvSeirekiYMD(items[10]), 1) + "  " + Constants.vbCr;
            ret += "    ,[HYOKASTAFF]	    = " + CM_kyotu_proc.pubf_CnvNull(items[11], 1) + "                      " + Constants.vbCr;
            ret += "    ,[HYOKANAIYO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[12], 1) + "                      " + Constants.vbCr;
            ret += "    ,[HYOKAKEKKA]	    = " + CM_kyotu_proc.pubf_CnvNull(items[13], 1) + "                      " + Constants.vbCr;
            // 画面非表示
            // ret &= "    ,[SIENNO]	        = " & pubf_CnvNull(items(14), 1) & "                      " & vbCr
            ret += "    ,[SIENSYOZOKU]	    = " + CM_kyotu_proc.pubf_CnvNull(items[15], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENKBN]	        = " + CM_kyotu_proc.pubf_CnvNull(items[16], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENETIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[17], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENAGE]	        = " + CM_kyotu_proc.pubf_CnvNull(items[18], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENAGEM]	        = " + CM_kyotu_proc.pubf_CnvNull(items[19], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SIENKEKKA]	    = " + CM_kyotu_proc.pubf_CnvNull(items[20], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAI]	        = " + CM_kyotu_proc.pubf_CnvNull(items[21], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYMD]	        = " + CM_kyotu_proc.pubf_CnvNull(items[22], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYOSTIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[23], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIYOETIME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[24], 1) + "                      " + Constants.vbCr;
            ret += "    ,[JIKAIKAKUNINFLG]	= " + CM_kyotu_proc.pubf_CnvNull(items[25], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANKANKEI]	    = " + CM_kyotu_proc.pubf_CnvNull(items[26], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANKOJINNO]	    = " + CM_kyotu_proc.pubf_CnvNull(items[27], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANNAME]	    = " + CM_kyotu_proc.pubf_CnvNull(items[28], 1) + "                      " + Constants.vbCr;
            ret += "    ,[SODANRENRAKU]	    = " + CM_kyotu_proc.pubf_CnvNull(items[29], 1) + "                      " + Constants.vbCr;
            ret += "    ,[BIBO]	            = " + CM_kyotu_proc.pubf_CnvNull(items[30], 1) + "                      " + Constants.vbCr;
            ret += "    ,[BIBOKAKUNINFLG]	= " + CM_kyotu_proc.pubf_CnvNull(items[31], 1) + "                      " + Constants.vbCr;
            ret += "    ,[TYUIFLG]	        = " + CM_kyotu_proc.pubf_CnvNull(items[32], 1) + "                      " + Constants.vbCr;
            ret = Conversions.ToString(ret + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,[ADDDATE]	        = ", Interaction.IIf(string.IsNullOrEmpty(CM_kyotu_proc.pubf_CnvNull(items[33], 1)), "GETDATE()", CM_kyotu_proc.pubf_CnvNull(items[33], 1))), "                      "), Constants.vbCr));
            ret = Conversions.ToString(ret + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,[TUSERID]	        = ", Interaction.IIf(CM_kyotu_proc.pubf_CnvNull(items[34], 1) == "Null", CM_kyotu_proc.pubf_CnvNull(items[35], 1), CM_kyotu_proc.pubf_CnvNull(items[34], 1))), "                      "), Constants.vbCr));
            ret += "    ,[USERID]	        = " + CM_kyotu_proc.pubf_CnvNull(items[35], 1) + "                      " + Constants.vbCr;
            ret += "    ,[DELFLG]	        = 0                                                       " + Constants.vbCr;
            ret += "    ,[SYORIYMD]	        = GETDATE()                                               " + Constants.vbCr;
            ret += "WHERE                                                                             " + Constants.vbCr;
            ret += "    [SIENNO]	        = " + CM_kyotu_proc.pubf_CnvNull(items[14], 1) + "                      " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 妊婦支援計画マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSienEda(string nendo, string kofuno)
        {
            string ret = "";

            ret = "UPDATE   TM_BHNSIEN                     " + Constants.vbCr;
            ret += "SET                                    " + Constants.vbCr;
            ret += "    EDANO       =   EDANO + 1          " + Constants.vbCr;
            ret += "WHERE   BNENDO    =   " + nendo + "    " + Constants.vbCr;
            ret += "  AND   BKOFUNO   =   " + kofuno + "   " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 妊婦支援計画マスタ枝番号更新SQL
        /// </summary>
        /// <param name="nendo"></param>
        /// <param name="kofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSienSEda(string nendo, string kofuno)
        {
            string ret = "";

            ret = "UPDATE   TM_BHNSIEN_SUB                 " + Constants.vbCr;
            ret += "SET                                    " + Constants.vbCr;
            ret += "    EDANO       =   EDANO + 1          " + Constants.vbCr;
            ret += "WHERE   BNENDO    =   " + nendo + "    " + Constants.vbCr;
            ret += "  AND   BKOFUNO   =   " + kofuno + "   " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 妊婦支援計画マスタ枝番号更新SQL
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="bnendo"></param>
        /// <param name="bkofuno"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string pubf_SQLUpdateSienPEda(string userid, string bnendo, string bkofuno)
        {
            string ret = "";

            ret = "UPDATE   TM_BHSIEN_NSHYOJI                       " + Constants.vbCr;
            ret += "SET                                             " + Constants.vbCr;
            ret += "    EDANO       =   EDANO + 1                   " + Constants.vbCr;
            ret += "WHERE   BNENDO    =   " + bnendo + "            " + Constants.vbCr;
            ret += "  AND   BKOFUNO   =   " + bkofuno + "           " + Constants.vbCr;
            ret += ";                                               " + Constants.vbCr;
            ret += "UPDATE   SI                                     " + Constants.vbCr;
            ret += "    SET USERID          =   '" + userid + "'    " + Constants.vbCr;
            ret += "       ,SYORIYMD        =   GETDATE()           " + Constants.vbCr;
            ret += "       ,DELFLG          =   1                   " + Constants.vbCr;
            ret += "FROM    dbo.TM_BHSIEN  SI                       " + Constants.vbCr;
            ret += "LEFT JOIN dbo.TM_BHSIEN_NSHYOJI SN              " + Constants.vbCr;
            ret += "    ON SI.SIENNO = SN.SIENNO                    " + Constants.vbCr;
            ret += "WHERE   (0=0)                                   " + Constants.vbCr;
            ret += "    AND SN.BNENDO = " + bnendo + "              " + Constants.vbCr;
            ret += "    AND SN.BKOFUNO = " + bkofuno + "            " + Constants.vbCr;
            ret += "    AND SN.EDANO > 1                            " + Constants.vbCr;
            ret += "    AND SN.DELCANF = 1                          " + Constants.vbCr;
            ret += "    AND SI.DELFLG = 0                           " + Constants.vbCr;

            return ret;
        }

        /// <summary>
        /// 帳票出力を行う。
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="type">帳票種別</param>
        /// <param name="bnendo">対象者(年度)</param>
        /// <param name="bkofuno">対象者(番号)</param>
        /// <param name="edano">対象者(枝番)</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_RepCreateSien(string systemcd, string userid, string type, string bnendo, string bkofuno, string edano)

        {
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;
            DataTable dtMain;
            DataTable dtSonota;
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string xlsPass = "";
            string crtPass = "";
            string urlPass = "";
            string repName = "";
            string filetype = "";
            string templateName = "";
            string param = "";
            var xlsCreator = new AdvanceSoftware.ExcelCreator.Xlsx.XlsxCreator();

            string SQL = "";
            StringBuilder sb;

            int i = 0;
            string buf = "";
            int ik = 0;
            string komoku_kbn = "";
            string komoku = "";
            string sonotakomoku_kbn = "";
            string sonotakomoku = "";
            string youyaku = "";

            string temp = "";
            string itemnm = "";

            long rep_i = 0L;

            string hahakojinno;
            // ジェノグラム
            string genoFlg;
            string genoOutPutFlg;
            string genoCellName;
            string genoWidth;
            string genoHeight;
            string genoOffset_X;
            string genoOffset_Y;

            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                // 'ログ採取用
                param = "func_repCreate(" + Strings.Join(new string[] { systemcd, userid, type, bnendo, bkofuno, edano }, ",") + ")";

                bnendo = CM_kyotu_proc.pubf_CnvSeireki(bnendo).ToString();

                try
                {
                    // ファイルタイプ
                    switch (type ?? "")
                    {
                        case "1":
                            {
                                repName = "妊婦支援計画";
                                templateName = repName;
                                filetype = CONST_FILETYPE_EXCEL;
                                break;
                            }

                        default:
                            {
                                throw new ArgumentException("指定されたTYPE=" + type + "が不正です。");
                                return default;
                            }
                    }

                    // '出力先
                    if (!pubf_SetSyuturyokusakiSien(filetype, userid, templateName, repName, ref xlsPass, ref crtPass, ref urlPass))
                    {
                        CM_kyotu_proc.pub_Status(1, 53, "(" + repName + ".xlsm)", newXML, "STATUS", rootElemRESULTXML);
                        CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(1, 53) + "(" + repName + ".xlsm)", "", "");
                        return newXML;
                    }

                    // '帳票出力開始
                    FileSystem.FileCopy(xlsPass, crtPass);

                    xlsCreator.OpenBook(crtPass, "");
                    xlsCreator.SheetNo = xlsCreator.SheetNo2("一覧表");

                    rep_i = 0L; // 1件のみ出力するため常に0

                    xlsCreator.Cell("**行番号", 0, (int)rep_i).Long = (int)(rep_i + 1L);
                    xlsCreator.Cell("**処理日", 0, (int)rep_i).Str = CM_kyotu_proc.pubf_GetTodayWareki();

                    // 妊婦基本情報
                    SQL = pubf_SQLGetNyuryokuKensaku(bnendo, bkofuno, edano, "");
                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    hahakojinno = dt.Rows[0]["HAHAKOJINNO"].ToString();

                    xlsCreator.Cell("**氏名カナ", 0, (int)rep_i).Str = dt.Rows[0]["HAHAKNAME"].ToString();
                    xlsCreator.Cell("**氏名", 0, (int)rep_i).Str = dt.Rows[0]["HAHANAME"].ToString();
                    xlsCreator.Cell("**整理番号", 0, (int)rep_i).Str = hahakojinno;
                    xlsCreator.Cell("**生年月日", 0, (int)rep_i).Str = dt.Rows[0]["HAHABYMD"].ToString();
                    xlsCreator.Cell("**出産予定日", 0, (int)rep_i).Str = dt.Rows[0]["HEYOTEIYMD"].ToString();
                    xlsCreator.Cell("**住所", 0, (int)rep_i).Str = dt.Rows[0]["HAHAADRS"].ToString();
                    xlsCreator.Cell("**連絡先", 0, (int)rep_i).Str = getFirstValue(dt.Rows[0]["HAHATEL1"].ToString(), dt.Rows[0]["HAHATEL2"].ToString(), dt.Rows[0]["HAHATEL"].ToString());

                    xlsCreator.Cell("**妊娠回数", 0, (int)rep_i).Str = dt.Rows[0]["JUNI"].ToString() + "回目";
                    xlsCreator.Cell("**年齢", 0, (int)rep_i).Str = dt.Rows[0]["HAHAAGE"].ToString();
                    xlsCreator.Cell("**母子手帳年度").Str = bnendo;
                    xlsCreator.Cell("**母子手帳交付番号").Str = bkofuno;
                    xlsCreator.Cell("**母子手帳枝番").Str = edano;
                    xlsCreator.Cell("**届出年月日", 0, (int)rep_i).Str = dt.Rows[0]["HETODOKYMD"].ToString();
                    xlsCreator.Cell("**妊娠週数", 0, (int)rep_i).Str = dt.Rows[0]["HESYUSU"].ToString();
                    xlsCreator.Cell("**父氏名", 0, (int)rep_i).Str = dt.Rows[0]["TITINAME"].ToString();
                    // 2022.06.21 ikuno 妊婦支援計画帳票に父生年月日を追加 >>>
                    xlsCreator.Cell("**父生年月日", 0, (int)rep_i).Str = dt.Rows[0]["TITIBYMD"].ToString();
                    // 2022.06.21 ikuno 妊婦支援計画帳票に父生年月日を追加 <<<
                    xlsCreator.Cell("**父年齢", 0, (int)rep_i).Str = dt.Rows[0]["TITIAGE"].ToString();
                    xlsCreator.Cell("**父住所", 0, (int)rep_i).Str = dt.Rows[0]["TITIADRS"].ToString();
                    xlsCreator.Cell("**父連絡先", 0, (int)rep_i).Str = dt.Rows[0]["TITITEL1"].ToString();

                    // '関係機関
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT     TOP 1   ");
                    sb.AppendLine("   CF.NAIYO    AS [NAIYO]  ");
                    sb.AppendLine("  ,BK.RENRAKU  AS [RENRAKU]       ");
                    sb.AppendLine("  ,BK.TANTOSYANM AS [TANTOSYANM]  ");
                    sb.AppendLine("FROM                  ");
                    sb.AppendLine("   TM_BHKKIKAN BK     ");
                    sb.AppendLine("   LEFT JOIN          ");
                    sb.AppendLine("      TC_KKCF CF      ");
                    sb.AppendLine("   ON                 ");
                    sb.AppendLine("      BK.KKIKANCD = CF.CD  ");
                    sb.AppendLine("WHERE          ");
                    sb.AppendLine("    BK.KOJINNO = '" + hahakojinno + "' ");
                    sb.AppendLine("   AND          ");
                    sb.AppendLine("      CF.MAINCD = '04'    ");
                    sb.AppendLine("   AND          ");
                    sb.AppendLine("       CF.SUBCD = 'A08'    ");
                    sb.AppendLine("ORDER BY          ");
                    sb.AppendLine("       BK.ROWNO ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        xlsCreator.Cell("**関係機関名", 0, (int)rep_i).Str = dt.Rows[0]["NAIYO"].ToString();
                        xlsCreator.Cell("**関係機関担当者名", 0, (int)rep_i).Str = dt.Rows[0]["TANTOSYANM"].ToString();
                        xlsCreator.Cell("**関係機関連絡先", 0, (int)rep_i).Str = dt.Rows[0]["RENRAKU"].ToString();
                    }

                    // 家族構成
                    sb = new StringBuilder();

                    sb.AppendLine("SELECT                                         ");
                    sb.AppendLine("     K.NAME AS SHIMEI                          ");
                    sb.AppendLine("    ,dbo.AGE_COMP(K.BYMD, GETDATE()) AS NENREI ");
                    sb.AppendLine("    ,K.ZOKUNM                                  ");
                    sb.AppendLine("    ,KS.SYOKUGYO                               ");
                    sb.AppendLine("    ,(                                         ");
                    sb.AppendLine("        SELECT                                 ");
                    sb.AppendLine("            NAIYO                              ");
                    sb.AppendLine("        FROM                                   ");
                    sb.AppendLine("            TC_KKCF                            ");
                    sb.AppendLine("        WHERE                                  ");
                    sb.AppendLine("            MAINCD = '01'                      ");
                    sb.AppendLine("          AND                                  ");
                    sb.AppendLine("            SUBCD = '008'                      ");
                    sb.AppendLine("          AND                                  ");
                    sb.AppendLine("            CD = K.JKBN                        ");
                    sb.AppendLine("     ) AS KJKBN                                ");
                    sb.AppendLine("FROM                                           ");
                    sb.AppendLine("    TM_KKKOJIN K                               ");
                    sb.AppendLine("                                               ");
                    sb.AppendLine("    INNER JOIN (                               ");
                    sb.AppendLine("        SELECT                                 ");
                    sb.AppendLine("            SETAINO                            ");
                    sb.AppendLine("        FROM                                   ");
                    sb.AppendLine("            TM_KKKOJIN                         ");
                    sb.AppendLine("        WHERE                                  ");
                    sb.AppendLine("            KOJINNO = '" + hahakojinno + "' ");
                    sb.AppendLine("    ) B                                        ");
                    sb.AppendLine("    ON                                         ");
                    sb.AppendLine("        K.SETAINO = B.SETAINO                  ");
                    sb.AppendLine("                                               ");
                    sb.AppendLine("    LEFT JOIN TM_KKKOJIN_SUB KS                ");
                    sb.AppendLine("    ON K.KOJINNO = KS.KOJINNO                  ");
                    sb.AppendLine("ORDER BY                                       ");
                    sb.AppendLine("    K.JKBN,K.ZOKU,K.BYMD,K.KNAME               ");

                    SQL = sb.ToString();
                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    for (i = 0; i <= 6; i++)
                    {
                        if (i <= dt.Rows.Count - 1)
                        {
                            xlsCreator.Cell("**家族氏名" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["SHIMEI"].ToString();
                            xlsCreator.Cell("**家族年齢" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["NENREI"].ToString();
                            xlsCreator.Cell("**家族続柄" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["ZOKUNM"].ToString();
                            xlsCreator.Cell("**家族職業" + (i + 1), 0, (int)rep_i).Str = "";
                            xlsCreator.Cell("**家族住民区分" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["KJKBN"].ToString();
                        }
                    }

                    // '保健指導（直近の母子対象：妊婦の指導データ）
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT TOP 1										                                    ");
                    sb.AppendLine("	dbo.CHG_WAREKI(0,HS.SIDOYMD)                                    AS [SIDOYMD]        ");
                    // sb.AppendLine("	,(DATEDIFF(DAY, KI.HETODOKYMD, HS.SIDOYMD) / 7) + KI.HESYUSU    AS [HOMONJISYUSU]   ")
                    // sb.AppendLine("	,(DATEDIFF(DAY, KI.HETODOKYMD, HS.SIDOYMD) % 7)                 AS [HOMONJISYUSUD]  ")
                    // sb.AppendLine("	,HS.SIDOBIKO                                                    AS [BIKO]           ")
                    sb.AppendLine("FROM												                                    ");
                    sb.AppendLine("	TM_BHNSKIHON KI									                                    ");
                    sb.AppendLine("	INNER JOIN TM_HSHOKENSIDO HS					                                    ");
                    sb.AppendLine("		ON HS.KOJINNO = KI.HEMKOJINNO				                                    ");
                    sb.AppendLine("WHERE											                                    ");
                    sb.AppendLine(" KI.EDANO = 1									                                    ");
                    sb.AppendLine(" AND KI.BNENDO = " + bnendo + "					                                    ");
                    sb.AppendLine("	AND KI.BKOFUNO = " + bkofuno + "				                                    ");
                    sb.AppendLine("	AND HS.DELFLG = 0								                                    ");
                    sb.AppendLine("	AND HS.BOSITAISYO = '1'							                                    ");
                    sb.AppendLine("	AND HS.SIDOYMD >= KI.HETODOKYMD					                                    ");
                    sb.AppendLine("ORDER BY											                                    ");
                    sb.AppendLine("	 HS.SIDOYMD DESC								                                    ");
                    sb.AppendLine("	,HS.STIME DESC									                                    ");
                    sb.AppendLine("	,HS.ETIME DESC									                                    ");

                    SQL = sb.ToString();
                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        xlsCreator.Cell("**直近妊婦指導年月日", 0, (int)rep_i).Str = dt.Rows[0]["SIDOYMD"].ToString();
                        // .Cell("**訪問時週数", 0, rep_i).Str = dt.Rows(0)("HOMONJISYUSU").ToString
                        // .Cell("**訪問時週数_日", 0, rep_i).Str = dt.Rows(0)("HOMONJISYUSUD").ToString
                        // .Cell("**把握状況", 0, rep_i).Str = Replace(dt.Rows(0)("BIKO").ToString, vbCr, vbCrLf)
                    }

                    // '保健指導（直近の訪問指導データ）
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT TOP 1										                                    ");
                    sb.AppendLine("	dbo.CHG_WAREKI(0,HS.SIDOYMD)                                    AS [SIDOYMD]        ");
                    sb.AppendLine("	,(DATEDIFF(DAY, KI.HETODOKYMD, HS.SIDOYMD) / 7) + KI.HESYUSU    AS [HOMONJISYUSU]   ");
                    sb.AppendLine("	,(DATEDIFF(DAY, KI.HETODOKYMD, HS.SIDOYMD) % 7)                 AS [HOMONJISYUSUD]  ");
                    sb.AppendLine("	,HS.SIDOBIKO                                                    AS [BIKO]           ");
                    sb.AppendLine("FROM												                                    ");
                    sb.AppendLine("	TM_BHNSKIHON KI									                                    ");
                    sb.AppendLine("	INNER JOIN TM_HSHOKENSIDO HS					                                    ");
                    sb.AppendLine("		ON HS.KOJINNO = KI.HEMKOJINNO				                                    ");
                    sb.AppendLine("WHERE											                                    ");
                    sb.AppendLine(" KI.EDANO = 1									                                    ");
                    sb.AppendLine(" AND KI.BNENDO = " + bnendo + "					                                    ");
                    sb.AppendLine("	AND KI.BKOFUNO = " + bkofuno + "				                                    ");
                    sb.AppendLine("	AND HS.DELFLG = 0								                                    ");
                    sb.AppendLine("	AND HS.TAIOKBN = '1'							                                    ");
                    // sb.AppendLine("	AND HS.SIDOYMD >= KI.HETODOKYMD					                                    ")
                    sb.AppendLine("ORDER BY											                                    ");
                    sb.AppendLine("	 HS.SIDOYMD DESC								                                    ");
                    sb.AppendLine("	,HS.STIME DESC									                                    ");
                    sb.AppendLine("	,HS.ETIME DESC									                                    ");

                    SQL = sb.ToString();
                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        xlsCreator.Cell("**直近訪問指導年月日", 0, (int)rep_i).Str = dt.Rows[0]["SIDOYMD"].ToString();
                        xlsCreator.Cell("**訪問時週数", 0, (int)rep_i).Str = dt.Rows[0]["HOMONJISYUSU"].ToString();
                        xlsCreator.Cell("**訪問時週数_日", 0, (int)rep_i).Str = dt.Rows[0]["HOMONJISYUSUD"].ToString();
                        xlsCreator.Cell("**把握状況", 0, (int)rep_i).Str = CM_kyotu_proc.pubf_CnvEmptyValue(dt.Rows[0]["BIKO"].ToString().Replace(Constants.vbCr, Constants.vbCrLf));
                    }

                    // 支援計画のメインテーブル
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT         ");
                    sb.AppendLine("   *           ");
                    sb.AppendLine("FROM           ");
                    sb.AppendLine("   TM_BHNSIEN  ");
                    sb.AppendLine("               ");
                    sb.AppendLine("WHERE          ");
                    sb.AppendLine("        BNENDO  = " + bnendo);
                    sb.AppendLine("    AND BKOFUNO = " + bkofuno);
                    sb.AppendLine("    AND EDANO   = 1 ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dtMain = new DataTable();
                    da.Fill(dtMain);

                    // <<項目支援項目>>
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT                                    ");
                    sb.AppendLine("     A.BNENDO                             ");
                    sb.AppendLine("    ,A.BKOFUNO                            ");
                    sb.AppendLine("    ,A.EDANO                              ");
                    sb.AppendLine("    ,A.GAITO                              ");
                    sb.AppendLine("    ,C.NAIYO AS KOUMOKU                   ");
                    sb.AppendLine("    ,B.NAIYO AS YOUYAKU                   ");
                    sb.AppendLine("    ,CASE WHEN B.KBN3 = '1' THEN          ");
                    sb.AppendLine("        CASE B.KBN1                       ");
                    sb.AppendLine("            WHEN '01' THEN D.BIKO01       ");
                    sb.AppendLine("            WHEN '02' THEN D.BIKO02       ");
                    sb.AppendLine("            WHEN '03' THEN D.BIKO03       ");
                    sb.AppendLine("            WHEN '04' THEN D.BIKO04       ");
                    sb.AppendLine("            WHEN '05' THEN D.BIKO05       ");
                    sb.AppendLine("            WHEN '06' THEN D.BIKO06       ");
                    sb.AppendLine("            WHEN '07' THEN D.BIKO07       ");
                    sb.AppendLine("            WHEN '08' THEN D.BIKO08       ");
                    sb.AppendLine("            WHEN '09' THEN D.BIKO09       ");
                    sb.AppendLine("            WHEN '10' THEN D.BIKO10       ");
                    sb.AppendLine("            WHEN '11' THEN D.BIKO11       ");
                    sb.AppendLine("            WHEN '12' THEN D.BIKO12       ");
                    sb.AppendLine("        END                               ");
                    sb.AppendLine("     END AS BIKO                          ");
                    sb.AppendLine("    ,B.KBN1                               ");
                    sb.AppendLine("    ,B.KBN2                               ");
                    sb.AppendLine("    ,B.KBN3                               ");
                    sb.AppendLine("    ,C.KBN1 AS KOUMOKUNO                  ");
                    sb.AppendLine("FROM                                      ");
                    sb.AppendLine("    TM_BHNSIEN_SUB AS A                   ");
                    sb.AppendLine("                                          ");
                    sb.AppendLine("    LEFT JOIN (SELECT * FROM TC_KKCF WHERE MAINCD='04' AND SUBCD='050') AS B ");
                    sb.AppendLine("    ON A.GAITO = B.CD                                                            ");
                    sb.AppendLine("                                                                             ");
                    sb.AppendLine("    LEFT JOIN (SELECT * FROM TC_KKCF WHERE MAINCD='04' AND SUBCD='049') AS C ");
                    sb.AppendLine("    ON B.KBN1 = C.CD                                                         ");
                    sb.AppendLine("                                                                             ");
                    sb.AppendLine("    LEFT JOIN TM_BHNSIEN D                                                   ");
                    sb.AppendLine("    ON     A.BNENDO  = D.BNENDO                                              ");
                    sb.AppendLine("       AND A.BKOFUNO = D.BKOFUNO                                             ");
                    sb.AppendLine("       AND A.EDANO   = D.EDANO                                               ");
                    sb.AppendLine("                                                                             ");
                    sb.AppendLine("    -- CHECKされている項目数が多いもの判断用 >>                              ");
                    sb.AppendLine("    LEFT JOIN (                                                              ");
                    sb.AppendLine("        SELECT                                                               ");
                    sb.AppendLine("             A.BNENDO                                                        ");
                    sb.AppendLine("            ,A.BKOFUNO                                                       ");
                    sb.AppendLine("            ,A.EDANO                                                         ");
                    sb.AppendLine("            ,B.KBN1                                                          ");
                    sb.AppendLine("            ,COUNT(A.BNENDO) AS CNT                                          ");
                    sb.AppendLine("        FROM                                                                 ");
                    sb.AppendLine("            TM_BHNSIEN_SUB AS A                                              ");
                    sb.AppendLine("                                                                             ");
                    sb.AppendLine("            LEFT JOIN (SELECT * FROM TC_KKCF WHERE MAINCD='04' AND SUBCD='050') AS B  ");
                    sb.AppendLine("            ON A.GAITO = B.CD                                                         ");
                    sb.AppendLine("        GROUP BY                                                                      ");
                    sb.AppendLine("             A.BNENDO                                                                 ");
                    sb.AppendLine("            ,A.BKOFUNO                                                                ");
                    sb.AppendLine("            ,A.EDANO                                                                  ");
                    sb.AppendLine("            ,B.KBN1                                                                   ");
                    sb.AppendLine("    ) CC                                                                              ");
                    sb.AppendLine("    ON     A.BNENDO  = CC.BNENDO                                                      ");
                    sb.AppendLine("       AND A.BKOFUNO = CC.BKOFUNO                                                     ");
                    sb.AppendLine("       AND A.EDANO   = CC.EDANO                                                       ");
                    sb.AppendLine("       AND b.KBN1    = CC.KBN1                                                        ");
                    sb.AppendLine("    -- CHECKされている項目数が多いもの判断用 <<                                       ");
                    sb.AppendLine("                                                                                      ");
                    sb.AppendLine("WHERE                                                                                 ");
                    sb.AppendLine("        A.BNENDO  = " + bnendo);
                    sb.AppendLine("    AND A.BKOFUNO = " + bkofuno);
                    sb.AppendLine("    AND A.EDANO   = 1 ");
                    sb.AppendLine("                          ");
                    sb.AppendLine("ORDER BY                  ");
                    sb.AppendLine("     A.BNENDO             ");
                    sb.AppendLine("    ,A.BKOFUNO            ");
                    sb.AppendLine("    ,A.EDANO              ");
                    sb.AppendLine("    ,CC.CNT DESC          ");
                    sb.AppendLine("    ,B.KBN1               ");
                    sb.AppendLine("    ,B.KBN2               ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    dt.Rows.Add(dt.NewRow()); // 末尾を判断しやすいように空行を差し込む

                    // その他項目番号・項目名取得
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT                   ");
                    sb.AppendLine("     NAIYO AS KOUMOKU    ");
                    sb.AppendLine("    ,KBN1  AS KOUMOKUNO  ");
                    sb.AppendLine("FROM                     ");
                    sb.AppendLine("   TC_KKCF               ");
                    sb.AppendLine("                         ");
                    sb.AppendLine("WHERE                    ");
                    sb.AppendLine("        MAINCD = '04'    ");
                    sb.AppendLine("    AND SUBCD  = '049'   ");
                    sb.AppendLine("    AND CD     = '13'    ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dtSonota = new DataTable();
                    da.Fill(dtSonota);

                    sonotakomoku_kbn = dtSonota.Rows[0]["KOUMOKUNO"].ToString();
                    sonotakomoku = dtSonota.Rows[0]["KOUMOKU"].ToString();

                    ik = 0;
                    komoku_kbn = "";
                    youyaku = "";
                    var loopTo = dt.Rows.Count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        // 前の行と項目が変わったら書く
                        if ((komoku_kbn ?? "") != (dt.Rows[i]["KOUMOKUNO"].ToString() ?? ""))
                        {
                            if (ik < 7 & !string.IsNullOrEmpty(komoku_kbn))
                            {
                                ik = ik + 1;

                                xlsCreator.Cell("**項目番号" + ik, 0, (int)rep_i).Str = komoku_kbn;
                                xlsCreator.Cell("**項目" + ik, 0, (int)rep_i).Str = komoku;
                                xlsCreator.Cell("**項目要約" + ik, 0, (int)rep_i).Str = youyaku;

                                youyaku = "";
                            }
                        }

                        komoku_kbn = dt.Rows[i]["KOUMOKUNO"].ToString();
                        komoku = dt.Rows[i]["KOUMOKU"].ToString();
                        if (!string.IsNullOrEmpty(youyaku))
                        {
                            youyaku += "、";
                        }
                        if (dt.Rows[i]["KBN3"].ToString() == "1")
                        {
                            youyaku += dt.Rows[i]["YOUYAKU"].ToString() + ":" + dt.Rows[i]["BIKO"].ToString();
                        }
                        else
                        {
                            youyaku += dt.Rows[i]["YOUYAKU"].ToString();
                        }
                    }

                    // 13:その他
                    if (!string.IsNullOrEmpty(dtMain.Rows[0]["BIKO"].ToString()))
                    {
                        if (ik < 7)
                        {
                            ik = ik + 1;
                        }
                        xlsCreator.Cell("**項目番号" + ik, 0, (int)rep_i).Str = sonotakomoku_kbn;
                        xlsCreator.Cell("**項目" + ik, 0, (int)rep_i).Str = sonotakomoku;
                        xlsCreator.Cell("**項目要約" + ik, 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO"].ToString();
                    }

                    if (dt.Rows.Count > 0)
                    {
                        var loopTo1 = dt.Rows.Count - 1;
                        for (i = 0; i <= loopTo1; i++)
                            xlsCreator.Cell("**チェックリスト" + dt.Rows[i]["GAITO"].ToString(), 0, (int)rep_i).Str = 1.ToString();
                        xlsCreator.Cell("**アセスメント指標", 0, (int)rep_i).Str = (dt.Rows.Count - 1).ToString();
                    }

                    xlsCreator.Cell("**総合的な課題", 0, (int)rep_i).Str = dtMain.Rows[0]["SOGOKADAI"].ToString();
                    xlsCreator.Cell("**目標と具体策の提案", 0, (int)rep_i).Str = dtMain.Rows[0]["MOKUHYO"].ToString();
                    xlsCreator.Cell("**ランク", 0, (int)rep_i).Str = dtMain.Rows[0]["RANK"].ToString();
                    xlsCreator.Cell("**その他01", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO01"].ToString();
                    xlsCreator.Cell("**その他02", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO02"].ToString();
                    xlsCreator.Cell("**その他03", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO03"].ToString();
                    xlsCreator.Cell("**その他04", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO04"].ToString();
                    xlsCreator.Cell("**その他05", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO05"].ToString();
                    xlsCreator.Cell("**その他06", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO06"].ToString();
                    xlsCreator.Cell("**その他07", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO07"].ToString();
                    xlsCreator.Cell("**その他08", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO08"].ToString();
                    xlsCreator.Cell("**その他09", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO09"].ToString();
                    xlsCreator.Cell("**その他10", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO10"].ToString();
                    xlsCreator.Cell("**その他11", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO11"].ToString();
                    xlsCreator.Cell("**その他12", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO12"].ToString();
                    xlsCreator.Cell("**その他", 0, (int)rep_i).Str = dtMain.Rows[0]["BIKO"].ToString();

                    // <<支援プラン>>
                    sb = new StringBuilder();

                    sb.AppendLine("SELECT                                                  ");
                    sb.AppendLine("    TM_BHSIEN_NSHYOJI.PLANNO AS COL                     ");
                    sb.AppendLine("   ,TM_BHSIEN.KEIKAKUYMD     AS KEIKAKUYMD              ");
                    sb.AppendLine("   ,TM_BHSIEN.KEIKAKUTIME    AS KEIKAKUTIME             ");
                    sb.AppendLine("   ,TM_BHSIEN.KEIKAKUSTAFF   AS KEIKAKUSTAFF            ");
                    sb.AppendLine("   ,TC_KKSTAFF.NAME          AS KEIKAKUSTAFF_NM         ");
                    sb.AppendLine("   ,TM_BHSIEN.KEIKAKUHOHO    AS KEIKAKUHOHO             ");
                    sb.AppendLine("   ,HOHO.NAIYO               AS KEIKAKUHOHO_NM          ");
                    sb.AppendLine("   ,TM_BHSIEN.KEIKAKUNAIYO   AS KEIKAKUNAIYO            ");
                    sb.AppendLine("FROM                                                    ");
                    sb.AppendLine("    TM_BHSIEN_NSHYOJI                                   ");
                    sb.AppendLine("                                                        ");
                    sb.AppendLine("    LEFT JOIN TM_BHSIEN                                 ");
                    sb.AppendLine("    ON TM_BHSIEN_NSHYOJI.SIENNO = TM_BHSIEN.SIENNO      ");
                    sb.AppendLine("                                                        ");
                    sb.AppendLine("    LEFT JOIN TC_KKSTAFF                                ");
                    sb.AppendLine("    ON KEIKAKUSTAFF = TC_KKSTAFF.STAFFCD                ");
                    sb.AppendLine("                                                        ");
                    sb.AppendLine("    LEFT JOIN (SELECT * FROM TC_KKCF WHERE MAINCD='04' AND SUBCD='051') HOHO ");
                    sb.AppendLine("    ON TM_BHSIEN.KEIKAKUHOHO = HOHO.CD                  ");
                    sb.AppendLine("                                                        ");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("        BNENDO  = " + bnendo);
                    sb.AppendLine("    AND BKOFUNO = " + bkofuno);
                    sb.AppendLine("    AND EDANO   = 1                                     ");
                    sb.AppendLine("    AND DELFLG  = 0                                     ");
                    sb.AppendLine("                                                        ");
                    sb.AppendLine("ORDER BY KEIKAKUYMD DESC, COL                           ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        int maxplancnt;

                        // 日付の降順に上位3件まで取得
                        if (dt.Rows.Count > 3)
                        {
                            maxplancnt = 3;
                        }
                        else
                        {
                            maxplancnt = dt.Rows.Count;
                        }

                        var loopTo2 = maxplancnt - 1;
                        for (i = 0; i <= loopTo2; i++)
                        {
                            temp = "";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["KEIKAKUYMD"].ToString()))
                            {
                                temp += CM_kyotu_proc.pubf_CnvWareki(Conversions.ToDate(dt.Rows[i]["KEIKAKUYMD"]));
                            }
                            if (!string.IsNullOrEmpty(temp))
                            {
                                temp += " ";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["KEIKAKUTIME"].ToString()))
                            {
                                temp += Strings.Left(dt.Rows[i]["KEIKAKUTIME"].ToString(), 2) + ":" + Strings.Right(dt.Rows[i]["KEIKAKUTIME"].ToString(), 2);
                            }
                            xlsCreator.Cell("**支援予定日" + (i + 1), 0, (int)rep_i).Str = temp;
                            xlsCreator.Cell("**支援担当者" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["KEIKAKUSTAFF_NM"].ToString();
                            xlsCreator.Cell("**支援方法" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["KEIKAKUHOHO_NM"].ToString();
                            xlsCreator.Cell("**支援内容" + (i + 1), 0, (int)rep_i).Str = dt.Rows[i]["KEIKAKUNAIYO"].ToString();
                        }
                    }

                    // '<<その他情報>>
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("    SUBSTRING(IT.ITEMCD,1,10)   AS  ITEMCD");
                    sb.AppendLine("   ,IT.ITEMNM                   AS  ITEMNM");
                    sb.AppendLine("   ,CASE");
                    sb.AppendLine("         WHEN IT.DATATYPE IN(1,2) THEN BF.DATATYPE2");
                    sb.AppendLine("		 WHEN IT.DATATYPE = 3     THEN ");
                    sb.AppendLine("			CASE ");
                    sb.AppendLine("				WHEN IT.CFID = 1 THEN CF.NAIYO");
                    sb.AppendLine("				WHEN IT.CFID = 2 THEN TI.MEISYO");
                    sb.AppendLine("				WHEN IT.CFID = 3 THEN KI.KIKANMEI");
                    sb.AppendLine("				WHEN IT.CFID = 4 THEN ST.NAME");
                    sb.AppendLine("			END");
                    sb.AppendLine("		 WHEN IT.DATATYPE = 4     THEN dbo.CHG_WAREKI(0,BF.DATATYPE4) ");
                    sb.AppendLine("	END AS KEKKA");
                    sb.AppendLine("FROM ");
                    sb.AppendLine("    TC_BHFREEITEM IT");

                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("	TM_BHNSFREE BF");
                    sb.AppendLine("		ON	BF.BNENDO = '" + bnendo + "'");
                    sb.AppendLine("		AND BF.BKOFUNO = '" + bkofuno + "'    ");
                    sb.AppendLine("		AND BF.EDANO = 1");
                    sb.AppendLine("		AND BF.KENKAISU = '00'");
                    sb.AppendLine("		AND BF.ITEMCD= IT.ITEMCD");
                    sb.AppendLine("LEFT JOIN");
                    sb.AppendLine("	TC_KKCF CF");
                    sb.AppendLine("ON  IT.CFID		= 1");
                    sb.AppendLine("AND	IT.MAINCD	= CF.MAINCD");
                    sb.AppendLine("AND	IT.SUBCD	= CF.SUBCD");
                    sb.AppendLine("AND BF.DATATYPE3 = CF.CD");

                    sb.AppendLine("LEFT JOIN dbo.TC_KKTIKU TI");
                    sb.AppendLine("ON IT.CFID = '2'");
                    sb.AppendLine("AND IT.MAINCD = TI.MAINCD");
                    sb.AppendLine("AND BF.DATATYPE3 =  TI.CD");

                    sb.AppendLine("LEFT JOIN dbo.TC_KKKIKAN KI");
                    sb.AppendLine("ON IT.CFID = '3'");
                    sb.AppendLine("AND BF.DATATYPE3 =  KI.KIKANCD");

                    sb.AppendLine("LEFT JOIN dbo.TC_KKSTAFF  ST");
                    sb.AppendLine("ON IT.CFID = '4'");
                    sb.AppendLine("AND BF.DATATYPE3 =  ST.STAFFCD");

                    sb.AppendLine("WHERE IT.BOSIKBN = '1'");
                    sb.AppendLine("AND	 IT.GETUKAIKBN = '00'");
                    sb.AppendLine("AND   IT.KENSINKBN = '1'");

                    sb.AppendLine("ORDER BY IT.ORDERID ");
                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        var loopTo3 = dt.Rows.Count - 1;
                        for (i = 0; i <= loopTo3; i++)
                            xlsCreator.Cell("**CD_" + dt.Rows[i]["ITEMCD"].ToString(), 0, (int)rep_i).Str = dt.Rows[i]["KEKKA"].ToString();
                    }

                    // '<<職務執行名・職務執行者・課名>>
                    sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("    (SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '001' AND CD = '04') AS [職務執行名]");
                    sb.AppendLine("   ,(SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '001' AND CD = '05') AS [職務執行者]");
                    sb.AppendLine("   ,(SELECT NAIYO FROM TC_KKCF WHERE MAINCD = '01' AND SUBCD = '001' AND CD = '11') AS [課名]");

                    SQL = sb.ToString();

                    da = new SqlDataAdapter(SQL, conn);
                    dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        xlsCreator.Cell("**職務執行名").Str = dt.Rows[0]["職務執行名"].ToString();
                        xlsCreator.Cell("**職務執行者").Str = dt.Rows[0]["職務執行者"].ToString();
                        xlsCreator.Cell("**課名").Str = dt.Rows[0]["課名"].ToString();
                    }

                    xlsCreator.Cell("A2").Long = 1;

                    // 'ジェノグラムの出力
                    if (xlsCreator.SheetNo2("妊産婦アセスメント調査票") >= 0)
                    {
                        xlsCreator.SheetNo = xlsCreator.SheetNo2("妊産婦アセスメント調査票");

                        // ジェノグラム使用権限取得
                        SQL = "SELECT                                                   " + Constants.vbCr;
                        SQL += "        DRAWINGFLG                 AS  DRAWINGFLG       " + Constants.vbCr;
                        SQL += "FROM    dbo.TC_KKUSER                                   " + Constants.vbCr;
                        SQL += "WHERE   USER_ID =   '" + userid + "'                    " + Constants.vbCr;

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        genoFlg = dt.Rows[0]["DRAWINGFLG"].ToString();

                        // ジェノグラム出力区分取得
                        SQL = "SELECT                                                         " + Constants.vbCr;
                        SQL += "        CASE WHEN NAIYO = '1' THEN 'True'                     " + Constants.vbCr;
                        SQL += "                              ELSE 'False' END AS  OUTPUTFLG  " + Constants.vbCr;
                        SQL += "FROM    dbo.TC_KKCF                                           " + Constants.vbCr;
                        SQL += "WHERE   MAINCD = '98'                                         " + Constants.vbCr;
                        SQL += "  AND    SUBCD = '412'                                        " + Constants.vbCr;
                        SQL += "  AND       CD = '11'                                         " + Constants.vbCr;

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        genoOutPutFlg = dt.Rows[0]["OUTPUTFLG"].ToString();

                        // ジェノグラム出力セル位置取得
                        SQL = "SELECT                                    " + Constants.vbCr;
                        SQL += "      NAIYO             AS  CELLNAME     " + Constants.vbCr;
                        SQL += "FROM  dbo.TC_KKCF                        " + Constants.vbCr;
                        SQL += "WHERE MAINCD = '98'                      " + Constants.vbCr;
                        SQL += "  AND SUBCD  = '412'                     " + Constants.vbCr;
                        SQL += "  AND CD     = '12'                      " + Constants.vbCr;

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        genoCellName = dt.Rows[0]["CELLNAME"].ToString();

                        // ジェノグラムの幅、高さを取得
                        SQL = "SELECT                                    " + Constants.vbCr;
                        SQL += "      KBN1              AS  WIDTH        " + Constants.vbCr;
                        SQL += "     ,KBN2              AS  HEIGHT       " + Constants.vbCr;
                        SQL += "FROM  dbo.TC_KKCF                        " + Constants.vbCr;
                        SQL += "WHERE MAINCD = '98'                      " + Constants.vbCr;
                        SQL += "  AND SUBCD  = '412'                     " + Constants.vbCr;
                        SQL += "  AND CD     = '13'                      " + Constants.vbCr;

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        genoWidth = dt.Rows[0]["WIDTH"].ToString();
                        genoHeight = dt.Rows[0]["HEIGHT"].ToString();

                        // ジェノグラムの出力セル位置から空ける間隔(オフセット値)を取得
                        SQL = "SELECT                                    " + Constants.vbCr;
                        SQL += "      KBN1              AS  OFFSETX      " + Constants.vbCr;
                        SQL += "     ,KBN2              AS  OFFSETY      " + Constants.vbCr;
                        SQL += "FROM  dbo.TC_KKCF                        " + Constants.vbCr;
                        SQL += "WHERE MAINCD = '98'                      " + Constants.vbCr;
                        SQL += "  AND SUBCD  = '412'                     " + Constants.vbCr;
                        SQL += "  AND CD     = '14'                      " + Constants.vbCr;

                        da = new SqlDataAdapter(SQL, conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        genoOffset_X = dt.Rows[0]["OFFSETX"].ToString();
                        genoOffset_Y = dt.Rows[0]["OFFSETX"].ToString();

                        // ジェノグラム出力：引数(xlsCreator or VBReport,整理番号,セル位置,幅,高さ,オフセット値X,,オフセット値Y)
                        if (genoFlg == "True" & genoOutPutFlg == "True")
                        {
                            CM_kyotu_proc.pub_RepCreateGenogramImage(xlsCreator, hahakojinno, genoCellName, genoWidth, genoHeight, genoOffset_X, genoOffset_Y);
                        }
                    }

                    xlsCreator.CloseBook(true);
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            CM_kyotu_proc.pub_URLPath(newXML, rootElemRESULTXML, urlPass);
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);

            // '##########################################################################################################
            // '#
            // '# ログ出力処理
            // '#
            // '##########################################################################################################
            CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(0, 0), "", repName + "(" + filetype + ")", crtPass);

            // '##########################################################################################################
            // '#
            // '# 実行履歴取得処理
            // '#
            // '##########################################################################################################
            using (var conn = new SqlConnection(db.getConn_SQL()))
            {
                conn.Open();

                try
                {
                    // 'XMLデータを作成：PGごとで変更

                    // '実行履歴取得
                    SQL = CM_kyotu_proc.pubf_SQLRepRireki(systemcd, "func_repCreate");

                    cmd = new SqlCommand(SQL, conn);

                    using (System.Data.Common.DbDataReader dr = cmd.ExecuteReader())
                    {
                        CM_kyotu_proc.pub_CreateXML(dr, newXML, "MJRIREKI", rootElemRESULTXML);
                    }
                }
                catch (SqlException ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
                catch (Exception ex)
                {
                    CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                    return newXML;
                }
            }

            return newXML;
        }

        /// <summary>
        /// 帳票出力を行う。(個人台帳)
        /// </summary>
        /// <param name="systemcd">処理コード</param>
        /// <param name="userid">操作者ＩＤ</param>
        /// <param name="type">帳票種別</param>
        /// <param name="bnendo">対象者(年度)</param>
        /// <param name="bkofuno">対象者(番号)</param>
        /// <param name="edano">対象者(枝番)</param>
        /// <returns></returns>
        /// <remarks></remarks>

        public XmlDocument func_RepCreateKojinDaichou(string systemcd, string userid, string type, string bnendo, string bkofuno, string edano)

        {
            var newXML = new XmlDocument();
            var rootElemRESULTXML = newXML.CreateElement("RESULTXML");
            string xlsPass = "";
            string crtPass = "";
            string urlPass = "";
            string param = "";
            int i = 0;
            string filename = "";
            string extention = ".xlsx";
            string downloadFileName = "";
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");
            int pageRow;
            string SQL = "";
            string SQLCSV = "";
            string SQLGraph = "";
            string SQLFROM = "";
            string SQLWHERE = "";
            string strOrder = "";
            var CSVParam = new Hashtable();
            string str;
            int y;
            string syusu;
            // --妊娠経過表-上段
            string itemnm = "";
            SqlDataAdapter daKojinDaichou;
            DataTable daKojinDaichouTbl;
            // --妊娠経過表-歯科健診
            string itemnmShika = "";
            SqlDataAdapter daKojinDaichouShika;
            DataTable daKojinDaichouShikaTbl;
            DataRow ShikaData;

            // --妊娠経過表-グラフ
            string itemnmGraph = "";
            SqlDataAdapter daKojinDaichouGraph;
            DataTable daKojinDaichouGraphTbl;

            // 'ログ採取用
            param = "func_repCreate(" + Strings.Join(new string[] { systemcd, userid, type, bnendo, bkofuno, edano }, ",") + ")";

            bnendo = CM_kyotu_proc.pubf_CnvSeireki(bnendo).ToString();

            try
            {
                // 帳票名の設定
                filename = "妊娠経過表";
                bool bFind;

                // デザインファイルのパスを取得する。
                bFind = CM_kyotu_proc.pubf_GetDesignFile(filename, ref xlsPass, extention);

                // デザインファイルが見つからなかったらErrorを返却する。
                if (!bFind)
                {
                    CM_kyotu_proc.pub_Status(1, 53, "(" + filename + extention + ")", newXML, "STATUS", rootElemRESULTXML);
                    CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(1, 53) + Constants.vbCrLf + "(" + filename + extention + ")", "", "");
                    return newXML;
                }

                // ' XMLデータを作成：PGごとで変更
                // 出力ファイル名の設定
                downloadFileName = userid + "_" + filename + strNow + extention;
                // 出力フルパスの設定
                crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsKakuno"].ToString() + downloadFileName;
                // URL出力パスの設定
                urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsUrl"].ToString() + downloadFileName;

                // テンプレートファイル更新
                // DB接続
                using (var conn = new SqlConnection(db.getConn_SQL()))
                {
                    conn.Open();

                    // '帳票出力開始
                    components = new System.ComponentModel.Container();
                    xlsRep = new AdvanceSoftware.VBReport8.Web.WebCellReport(components);
                    xlsRep.FileName = xlsPass;

                    // ----------------------------------------------------------
                    // 妊娠経過表-上段
                    // ----------------------------------------------------------
                    SQLCSV = pubf_SQLGetKojinDaichouCSVITEM(conn, systemcd, 0);
                    SQLFROM = pubf_SQLGetKojinDaichou(bnendo, bkofuno, edano);

                    // SQL文
                    SQL = "SELECT   " + Constants.vbCr;
                    SQL += SQLCSV + Constants.vbCr;
                    SQL += SQLFROM + Constants.vbCr;

                    daKojinDaichou = new SqlDataAdapter(SQL, conn);
                    daKojinDaichouTbl = new DataTable();
                    daKojinDaichou.Fill(daKojinDaichouTbl);

                    if (daKojinDaichouTbl.Rows.Count == 0)
                    {
                        // 該当データ無し
                        CM_kyotu_proc.pub_Status(0, 2, "", newXML, "STATUS", rootElemRESULTXML);
                        CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(0, 2), "", "");
                        return newXML;
                    }

                    // ----------------------------------------------------------
                    // 妊娠経過表-歯科健診
                    // ----------------------------------------------------------
                    SQLCSV = pubf_SQLGetKojinDaichouCSVITEM(conn, systemcd, 1);
                    SQLFROM = pubf_SQLGetKojinDaichouShika(bnendo, bkofuno, edano);

                    // SQL文
                    SQL = "SELECT   " + Constants.vbCr;
                    SQL += SQLCSV + Constants.vbCr;
                    SQL += SQLFROM + Constants.vbCr;

                    daKojinDaichouShika = new SqlDataAdapter(SQL, conn);
                    daKojinDaichouShikaTbl = new DataTable();
                    daKojinDaichouShika.Fill(daKojinDaichouShikaTbl);

                    // 歯科健診はデータが無くても処理を続行する。

                    // ----------------------------------------------------------
                    // 妊娠経過表-グラフ
                    // ----------------------------------------------------------
                    SQLCSV = pubf_SQLGetKojinDaichouCSVITEM(conn, systemcd, 2);
                    SQLFROM = pubf_SQLGetKojinDaichouGraph(bnendo, bkofuno, edano);

                    // SQL文
                    SQL = "";
                    SQL = "SELECT   " + Constants.vbCr;
                    SQL += SQLCSV + Constants.vbCr;
                    SQL += SQLFROM + Constants.vbCr;

                    daKojinDaichouGraph = new SqlDataAdapter(SQL, conn);
                    daKojinDaichouGraphTbl = new DataTable();
                    daKojinDaichouGraph.Fill(daKojinDaichouGraphTbl);

                    components = new System.ComponentModel.Container();
                    xlsRep = new AdvanceSoftware.VBReport8.Web.WebCellReport(components);
                    xlsRep.FileName = xlsPass;

                    xlsRep.Report.Start();
                    xlsRep.Report.File();
                    y = 0;

                    // 個人台帳
                    pageRow = 1;
                    i = 0;
                    xlsRep.Page.Start("妊娠経過表 ", pageRow.ToString());

                    // 妊娠前の体重
                    double taiju;
                    taiju = 0d;
                    // 'ヘッダ部
                    xlsRep.Cell("**手帳番号", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["手帳番号"].ToString());
                    xlsRep.Cell("**氏名", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["氏名"].ToString());
                    xlsRep.Cell("**妊娠時の年齢", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["妊娠時の年齢"].ToString());
                    xlsRep.Cell("**妊娠歴", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["妊娠歴"].ToString());
                    xlsRep.Cell("**分娩予定年月日", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["分娩予定年月日"].ToString());

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["身長"].ToString())))))
                    {
                        xlsRep.Cell("**身長", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["身長"].ToString());
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["妊娠前_体重"].ToString())))))
                    {
                        taiju = Conversions.ToDouble(CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["妊娠前_体重"].ToString()));
                        xlsRep.Cell("**妊娠前_体重", 0, y).Value = taiju;
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["BMI"].ToString())))))
                    {
                        xlsRep.Cell("**BMI", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["BMI"].ToString());
                    }

                    // 帳票右側
                    xlsRep.Cell("**在胎週数", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["在胎週数"].ToString());
                    xlsRep.Cell("**出生順位", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["出生順位"].ToString());
                    xlsRep.Cell("**出生日", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["出生日"].ToString());
                    xlsRep.Cell("**性別", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["性別"].ToString());
                    xlsRep.Cell("**単胎_多胎", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["単胎_多胎"].ToString());

                    // 歯科健診
                    if (daKojinDaichouShikaTbl.Rows.Count != 0)
                    {
                        ShikaData = daKojinDaichouShikaTbl.Rows[i];
                        foreach (DataColumn ShikaDataCol in ShikaData.Table.Columns)
                            xlsRep.Cell("**" + ShikaDataCol.ColumnName, 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(ShikaData[ShikaDataCol.ColumnName].ToString());
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["児体重"].ToString())))))
                    {
                        xlsRep.Cell("**児体重", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["児体重"].ToString());
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["児身長"].ToString())))))
                    {
                        xlsRep.Cell("**児身長", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["児身長"].ToString());
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["児頭囲"].ToString())))))
                    {
                        xlsRep.Cell("**児頭囲", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["児頭囲"].ToString());
                    }

                    if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouTbl.Rows[i]["児胸囲"].ToString())))))
                    {
                        xlsRep.Cell("**児胸囲", 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouTbl.Rows[i]["児胸囲"].ToString());
                    }

                    xlsRep.Cell("**分娩方法", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["分娩方法"].ToString());
                    xlsRep.Cell("**分娩場所", 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouTbl.Rows[i]["分娩場所"].ToString());

                    var loopTo = daKojinDaichouGraphTbl.Rows.Count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        syusu = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouGraphTbl.Rows[i]["妊娠週数"].ToString());

                        if (!string.IsNullOrEmpty(Strings.Trim(syusu)))
                        {
                            // グラフ
                            xlsRep.Cell("**data1_" + syusu, 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouGraphTbl.Rows[i]["data1"].ToString()); // 重複

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data2"].ToString())))))
                            {
                                xlsRep.Cell("**data2_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data2"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data3"].ToString())))))
                            {
                                xlsRep.Cell("**data3_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data3"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data4"].ToString())))))
                            {
                                xlsRep.Cell("**data4_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data4"].ToString());
                            }

                            // 体重増加量
                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data4"].ToString())))))
                            {
                                xlsRep.Cell("**data5_" + syusu, 0, y).Value = Operators.SubtractObject(pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data4"].ToString()), taiju);
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data6"].ToString())))))
                            {
                                xlsRep.Cell("**data6_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data6"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data7"].ToString())))))
                            {
                                xlsRep.Cell("**data7_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data7"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data8"].ToString())))))
                            {
                                xlsRep.Cell("**data8_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data8"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data9"].ToString())))))
                            {
                                xlsRep.Cell("**data9_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data9"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data10"].ToString())))))
                            {
                                xlsRep.Cell("**data10_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data10"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data11"].ToString())))))
                            {
                                xlsRep.Cell("**data11_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data11"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data12"].ToString())))))
                            {
                                xlsRep.Cell("**data12_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data12"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data13"].ToString())))))
                            {
                                xlsRep.Cell("**data13_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data13"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data14"].ToString())))))
                            {
                                xlsRep.Cell("**data14_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data14"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data15"].ToString())))))
                            {
                                xlsRep.Cell("**data15_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data15"].ToString());
                            }

                            if (Conversions.ToBoolean(Strings.Trim(Conversions.ToString(!string.IsNullOrEmpty(daKojinDaichouGraphTbl.Rows[i]["data16"].ToString())))))
                            {
                                xlsRep.Cell("**data16_" + syusu, 0, y).Value = pubf_KojinDaichou_TypeChgResult(daKojinDaichouGraphTbl.Rows[i]["data16"].ToString());
                            }

                            // 医療機関
                            xlsRep.Cell("**data17_" + syusu, 0, y).Value = CM_kyotu_proc.pubf_CnvEmptyValue(daKojinDaichouGraphTbl.Rows[i]["data17"].ToString());
                        }
                    }

                    // '週数をループする
                    xlsRep.Page.End();
                    xlsRep.Report.End();
                    xlsRep.Report.SaveAs(crtPass);
                }
            }
            catch (Exception ex)
            {
                CM_kyotu_proc.pub_Status(99, 1, ex.Message, newXML, "STATUS", rootElemRESULTXML);
                CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(99, 1) + Constants.vbNewLine + ex.Message + ex.StackTrace, "", "");
                return newXML;
            }

            CM_kyotu_proc.pub_URLPath(newXML, rootElemRESULTXML, urlPass);
            CM_kyotu_proc.pub_Status(0, 0, "", newXML, "STATUS", rootElemRESULTXML);
            CM_kyotu_proc.pub_Log(userid, systemcd, param, CM_kyotu_proc.pubf_Msg(0, 0), "", downloadFileName, crtPass);

            return newXML;
        }

        /// <summary>
        /// 数字文字の判断
        /// </summary>
        /// <param name="data">値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private object pubf_KojinDaichou_TypeChgResult(string data)
        {
            object ret;

            if (data is null)
            {
                ret = " ";
            }
            else if (string.IsNullOrEmpty(Strings.Trim(data)))
            {
                ret = " ";
            }
            else if (Information.IsNumeric(data) == true & Strings.Len(data) == Encoding.GetEncoding("Shift_JIS").GetByteCount(data))
            {
                ret = Conversions.ToDouble(data);
            }
            else if (Information.IsDate(data) == true)
            {
                ret = Conversions.ToDate(data);
            }
            else
            {
                ret = data;
            }

            return ret;
        }

        /// <summary>
        /// 妊娠経過表CSVITEM取得処理
        /// </summary>
        /// <param name="conn">値</param>
        /// <param name="systemcd">値</param>
        /// <param name="kbn">値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string pubf_SQLGetKojinDaichouCSVITEM(SqlConnection conn, string systemcd, int kbn)
        {
            string SQLCSV;
            SqlCommand cmd;
            string itemnm = "";
            var CSVParam = new Hashtable();

            SQLCSV = "";
            SQLCSV = "SELECT                                       " + Constants.vbCr;
            SQLCSV += "        ITEM    AS  ITEM                    " + Constants.vbCr;
            SQLCSV += "       ,ITEMNM  AS  ITEMNM                  " + Constants.vbCr;
            SQLCSV += "FROM    dbo.TC_KKCSVITEM                    " + Constants.vbCr;
            SQLCSV += "WHERE   SYSTEMCD    =   '" + systemcd + "'  " + Constants.vbCr;
            SQLCSV += "    AND SELECTITEM  >   0                   " + Constants.vbCr;
            SQLCSV += "    AND KUBUN  =   " + kbn + "             " + Constants.vbCr;
            SQLCSV += "ORDER   BY  SELECTITEM                      " + Constants.vbCr;

            cmd = new SqlCommand(SQLCSV, conn);

            SQLCSV = "SENTOU";
            using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
            {
                // '次の行が存在する間繰り返す
                while (reader.Read())
                {
                    SQLCSV = Conversions.ToString(SQLCSV + Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("    ,", reader["ITEM"]), "  AS  ["), reader["ITEMNM"]), "]  "), Constants.vbCr));
                    itemnm = Conversions.ToString(itemnm + Operators.ConcatenateObject(reader["ITEMNM"], "|!"));
                }
            }
            foreach (string str in CSVParam.Keys)
                SQLCSV = Strings.Replace(SQLCSV, "@@" + str, "'" + CSVParam[str].ToString() + "'");
            SQLCSV = Strings.Replace(SQLCSV, "SENTOU    ,", "     ");

            return SQLCSV;
        }

        /// <summary>
        /// 妊娠経過表(上段)SQL文作成
        /// </summary>
        /// <param name="bnendo">対象者(年度)</param>
        /// <param name="bkofuno">対象者(番号)</param>
        /// <param name="edano">対象者(枝番)</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string pubf_SQLGetKojinDaichou(string bnendo, string bkofuno, string edano)
        {
            string SQLFROM;
            SQLFROM = "";
            SQLFROM = "  FROM                                       " + Constants.vbCr;
            SQLFROM += "(									        " + Constants.vbCr;
            SQLFROM += "	SELECT							        " + Constants.vbCr;
            SQLFROM += "	*								        " + Constants.vbCr;
            SQLFROM += "	FROM							        " + Constants.vbCr;
            SQLFROM += "	    TM_BHNSHAKKO					    " + Constants.vbCr; // 妊産婦発行情報管理マスタ(TM_BHNSHAKKO) NSH
            SQLFROM += "	WHERE							        " + Constants.vbCr;
            SQLFROM += "	    BNENDO = '" + bnendo + "'           " + Constants.vbCr;
            SQLFROM += "	    AND BKOFUNO = '" + bkofuno + "'	    " + Constants.vbCr;
            SQLFROM += "	    AND BEDANO	 = '" + edano + "'      " + Constants.vbCr;
            SQLFROM += "	    AND EDANO = '1'                     " + Constants.vbCr;
            SQLFROM += "	    AND DELFLG = '0'                    " + Constants.vbCr;
            SQLFROM += "	)NSH INNER JOIN TM_BHNSKIHON NSK ON     " + Constants.vbCr; // 妊産婦基本情報管理マスタ(TM_BHNSKIHON) NSK
            SQLFROM += "	NSH.BNENDO = NSK.BNENDO                 " + Constants.vbCr;
            SQLFROM += "	AND NSH.BKOFUNO = NSK.BKOFUNO           " + Constants.vbCr;
            SQLFROM += "	LEFT JOIN                               " + Constants.vbCr; // 宛名マスタ（個人）(TM_KKKOJIN)
            SQLFROM += "	    TM_KKKOJIN KO On                    " + Constants.vbCr;
            SQLFROM += "	    KO.KOJINNO = NSK.HEMKOJINNO         " + Constants.vbCr;
            SQLFROM += "	LEFT JOIN TM_BHNSJUTOGAI NSJ On         " + Constants.vbCr; // 妊産婦住登外父母情報管理マスタ(TM_BHNSJUTOGAI) NSJ
            SQLFROM += "	    NSK.BKOFUNO = NSJ.BKOFUNO           " + Constants.vbCr;
            SQLFROM += "	    AND NSK.BNENDO = NSJ.BNENDO         " + Constants.vbCr;
            SQLFROM += "	    AND NSK.EDANO = NSJ.EDANO           " + Constants.vbCr;
            SQLFROM += "	    AND NSJ.NTKBN = '2'                 " + Constants.vbCr;
            SQLFROM += "	LEFT JOIN TM_BHNYJO NYJ On              " + Constants.vbCr; // 乳幼児出生時情報管理マスタ (TM_BHNYJO) NYJ
            SQLFROM += "	    NYJ.BNENDO = NSH.BNENDO             " + Constants.vbCr;
            SQLFROM += "	    AND NYJ.BKOFUNO = NSH.BKOFUNO       " + Constants.vbCr;
            SQLFROM += "	    AND NYJ.BEDANO = NSH.BEDANO         " + Constants.vbCr;
            SQLFROM += "	    AND NYJ.EDANO = '1'                 " + Constants.vbCr;
            SQLFROM += "	    AND NYJ.DELFLG = '0'                " + Constants.vbCr;
            SQLFROM += "	LEFT JOIN TM_KKKOJIN KO_N On            " + Constants.vbCr;
            SQLFROM += "	        NYJ.KOJINNO = KO_N.KOJINNO      " + Constants.vbCr;

            return SQLFROM;
        }

        /// <summary>
        /// 妊娠経過表(歯周病)SQL文作成
        /// </summary>
        /// <param name="bnendo">対象者(年度)</param>
        /// <param name="bkofuno">対象者(番号)</param>
        /// <param name="edano">対象者(枝番)</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string pubf_SQLGetKojinDaichouShika(string bnendo, string bkofuno, string edano)
        {
            string SQLFROM;
            SQLFROM = "";
            SQLFROM = "  FROM                                                   " + Constants.vbCr;
            SQLFROM += "TM_KSSISYUKEN SISY                                      " + Constants.vbCr;
            SQLFROM += "INNER JOIN                                              " + Constants.vbCr;
            SQLFROM += "(                                                       " + Constants.vbCr;
            SQLFROM += "	SELECT                                              " + Constants.vbCr;
            SQLFROM += "		ROW_NUMBER() OVER(PARTITION BY                  " + Constants.vbCr;
            SQLFROM += "			NENDO                                       " + Constants.vbCr;
            SQLFROM += "			,KOJINNO                                    " + Constants.vbCr;
            SQLFROM += "			ORDER BY NENDO DESC,JYMD DESC               " + Constants.vbCr;
            SQLFROM += "			,EDANO DESC) As NUM                         " + Constants.vbCr;
            SQLFROM += "		,NENDO                                          " + Constants.vbCr;
            SQLFROM += "		,KOJINNO                                        " + Constants.vbCr;
            SQLFROM += "		,EDANO                                          " + Constants.vbCr;
            SQLFROM += "		,JYMD                                           " + Constants.vbCr;
            SQLFROM += "	FROM                                                " + Constants.vbCr;
            SQLFROM += "		TM_KSSISYUKEN                                   " + Constants.vbCr;
            SQLFROM += "	WHERE                                               " + Constants.vbCr;
            SQLFROM += "		KOJINNO IN                                      " + Constants.vbCr;
            SQLFROM += "			(                                           " + Constants.vbCr;
            SQLFROM += "				SELECT HEMKOJINNO                       " + Constants.vbCr;
            SQLFROM += "				FROM TM_BHNSKIHON                       " + Constants.vbCr;
            SQLFROM += "				WHERE BNENDO = '" + bnendo + "'         " + Constants.vbCr;
            SQLFROM += "				AND BKOFUNO = '" + bkofuno + "'         " + Constants.vbCr;
            SQLFROM += "				AND EDANO = '1'                         " + Constants.vbCr;
            SQLFROM += "			)                                           " + Constants.vbCr;
            SQLFROM += "		AND DELFLG = '0'                                " + Constants.vbCr;
            SQLFROM += "		AND JYMD IS NOT NULL                            " + Constants.vbCr;
            SQLFROM += "		AND                                             " + Constants.vbCr;
            SQLFROM += "		KSYUBETU IN (SELECT CD FROM TC_KKCF WHERE       " + Constants.vbCr;
            SQLFROM += "		MAINCD = '02' AND SUBCD = '653' AND KBN2  ='1') " + Constants.vbCr;
            SQLFROM += ")A ON                                                   " + Constants.vbCr;
            SQLFROM += "SISY.NENDO = A.NENDO                                    " + Constants.vbCr;
            SQLFROM += "AND SISY.KOJINNO = A.KOJINNO                            " + Constants.vbCr;
            SQLFROM += "AND SISY.EDANO = A.EDANO                                " + Constants.vbCr;
            SQLFROM += "AND A.NUM = '1'                                         " + Constants.vbCr;
            SQLFROM += "";

            return SQLFROM;
        }

        /// <summary>
        /// 妊娠経過表(グラフ)SQL文作成
        /// </summary>
        /// <param name="bnendo">対象者(年度)</param>
        /// <param name="bkofuno">対象者(番号)</param>
        /// <param name="edano">対象者(枝番)</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string pubf_SQLGetKojinDaichouGraph(string bnendo, string bkofuno, string edano)
        {
            string SQLFROM;

            SQLFROM = " FROM                                                    " + Constants.vbCr;
            SQLFROM += "(                                                       " + Constants.vbCr;
            SQLFROM += "	SELECT * FROM                                       " + Constants.vbCr;
            SQLFROM += "	TM_BHNSNINKEN                                       " + Constants.vbCr;
            SQLFROM += "	WHERE                                               " + Constants.vbCr;
            SQLFROM += "	BNENDO = '" + bnendo + "'                           " + Constants.vbCr;
            SQLFROM += "	AND BKOFUNO = '" + bkofuno + "'                     " + Constants.vbCr;
            SQLFROM += "	AND EDANO = '1'                                     " + Constants.vbCr;
            SQLFROM += ")NSN                                                    " + Constants.vbCr;
            SQLFROM += "LEFT JOIN                                               " + Constants.vbCr;
            SQLFROM += "(                                                       " + Constants.vbCr;
            SQLFROM += "		SELECT                                          " + Constants.vbCr;
            SQLFROM += "		 ROW_NUMBER() OVER(PARTITION BY                 " + Constants.vbCr;
            SQLFROM += "		 A.BNENDO,A.BKOFUNO,A.EDANO,A.SYUSU             " + Constants.vbCr;
            SQLFROM += "		 ORDER BY B.JUSINYMD DESC                       " + Constants.vbCr;
            SQLFROM += "		 ,B.KENKAISU DESC) As NUM                       " + Constants.vbCr;
            SQLFROM += "		,A.BNENDO                                       " + Constants.vbCr;
            SQLFROM += "		,A.BKOFUNO                                      " + Constants.vbCr;
            SQLFROM += "		,A.EDANO                                        " + Constants.vbCr;
            SQLFROM += "		,A.SYUSU                                        " + Constants.vbCr;
            SQLFROM += "		,B.JUSINYMD                                     " + Constants.vbCr;
            SQLFROM += "		,B.KENKAISU                                     " + Constants.vbCr;
            SQLFROM += "		,'*' As '重複'                                  " + Constants.vbCr;
            SQLFROM += "		FROM                                            " + Constants.vbCr;
            SQLFROM += "		(                                               " + Constants.vbCr;
            SQLFROM += "			SELECT                                      " + Constants.vbCr;
            SQLFROM += "				BNENDO,BKOFUNO,EDANO,SYUSU              " + Constants.vbCr;
            SQLFROM += "			FROM                                        " + Constants.vbCr;
            SQLFROM += "				TM_BHNSNINKEN                           " + Constants.vbCr;
            SQLFROM += "			WHERE                                       " + Constants.vbCr;
            SQLFROM += "				BNENDO = '" + bnendo + "'               " + Constants.vbCr;
            SQLFROM += "				AND BKOFUNO = '" + bkofuno + "'         " + Constants.vbCr;
            SQLFROM += "				AND EDANO = '1'                         " + Constants.vbCr;
            SQLFROM += "				AND JUSINYMD IS NOT NULL                " + Constants.vbCr;
            SQLFROM += "				AND SYUSU IS NOT NULL                   " + Constants.vbCr;
            SQLFROM += "			GROUP BY                                    " + Constants.vbCr;
            SQLFROM += "				BNENDO,BKOFUNO,EDANO,SYUSU              " + Constants.vbCr;
            SQLFROM += "			HAVING COUNT(*) > 1                         " + Constants.vbCr;
            SQLFROM += "		)A LEFT JOIN                                    " + Constants.vbCr;
            SQLFROM += "		TM_BHNSNINKEN B ON                              " + Constants.vbCr;
            SQLFROM += "		A.BNENDO = B.BNENDO                             " + Constants.vbCr;
            SQLFROM += "		AND A.BKOFUNO = B.BKOFUNO                       " + Constants.vbCr;
            SQLFROM += "		AND A.EDANO = B.EDANO                           " + Constants.vbCr;
            SQLFROM += "		AND A.SYUSU = B.SYUSU                           " + Constants.vbCr;
            SQLFROM += ")NSN2 ON                                                " + Constants.vbCr;
            SQLFROM += "	NSN.BNENDO = NSN2.BNENDO                            " + Constants.vbCr;
            SQLFROM += "	AND NSN.BKOFUNO = NSN2.BKOFUNO                      " + Constants.vbCr;
            SQLFROM += "	AND NSN.EDANO = NSN2.EDANO                          " + Constants.vbCr;
            SQLFROM += "	AND NSN.KENKAISU = NSN2.KENKAISU                    " + Constants.vbCr;
            SQLFROM += "	AND NSN.SYUSU = NSN2.SYUSU                          " + Constants.vbCr;
            SQLFROM += "WHERE                                                   " + Constants.vbCr;
            SQLFROM += "	NSN.JUSINYMD IS NOT NULL                            " + Constants.vbCr;
            SQLFROM += "	AND                                                 " + Constants.vbCr;
            SQLFROM += "	( NSN2.num = '1' OR NSN2.num IS NULL )              " + Constants.vbCr;

            return SQLFROM;
        }

        /// <summary>
        /// 出力先設定
        /// </summary>
        /// <param name="filetype">ファイルタイプ（PDF、EXCEL、CSV）</param>
        /// <param name="userid">ユーザID</param>
        /// <param name="templateName">テンプレートファイル名</param>
        /// <param name="repName">帳票ファイル名</param>
        /// <param name="xlsPass">xlsパス</param>
        /// <param name="crtPass">crtパス</param>
        /// <param name="urlPass">urlパス</param>
        /// <remarks></remarks>
        public bool pubf_SetSyuturyokusakiSien(string filetype, string userid, string templateName, string repName, ref string xlsPass, ref string crtPass, ref string urlPass)

        {
            string strNow = Strings.Format(DateTime.Now, "yyyyMMddHHmmss");
            bool @bool = true;

            switch (filetype ?? "")
            {
                case CONST_FILETYPE_PDF:	// '(PDF)
                    {
                        @bool = CM_kyotu_proc.pubf_GetDesignFile(templateName, ref xlsPass);
                        crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["pdfKakuno"].ToString() + userid + "_" + repName + strNow + ".pdf";
                        urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["pdfUrl"].ToString() + userid + "_" + repName + strNow + ".pdf";
                        break;
                    }
                case CONST_FILETYPE_EXCEL: // '(Excel)
                    {
                        @bool = CM_kyotu_proc.pubf_GetDesignFile(templateName, ref xlsPass, ".xlsm");
                        crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsKakuno"].ToString() + userid + "_" + repName + strNow + ".xlsm";
                        urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["xlsUrl"].ToString() + userid + "_" + repName + strNow + ".xlsm";
                        break;
                    }
                case CONST_FILETYPE_CSV:	// '(CSV)
                    {
                        crtPass = System.Configuration.ConfigurationManager.ConnectionStrings["csvKakuno"].ToString() + userid + "_" + repName + strNow + ".csv";
                        urlPass = System.Configuration.ConfigurationManager.ConnectionStrings["csvUrl"].ToString() + userid + "_" + repName + strNow + ".csv";
                        break;
                    }
            }

            return @bool;
        }

        /// <summary>
        /// 値のある先頭の値を返す
        /// </summary>
        /// <param name="args">値の配列</param>
        /// <remarks></remarks>
        private string getFirstValue(params string[] args)
        {
            string ret = "";

            foreach (string arg in args)
            {
                if (!string.IsNullOrEmpty(Strings.Trim(arg)))
                {
                    ret = arg;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// TC_KKCSVITEM を読み取り、DataTableで返す
        /// </summary>
        /// <param name="systemcd">SYSTEMCD</param>
        /// <param name="kubun">KUBUN</param>
        /// <param name="conn">接続先DB</param>
        /// <remarks></remarks>
        private DataTable getCsvItem(string systemcd, int kubun, SqlConnection conn)
        {
            SqlDataAdapter da;
            var sb = new StringBuilder();
            var tb = new DataTable();

            sb.AppendLine("SELECT                             ");
            sb.AppendLine("    *                              ");
            sb.AppendLine("FROM                               ");
            sb.AppendLine("    TC_KKCSVITEM                   ");
            sb.AppendLine("WHERE                              ");
            sb.AppendLine("     SYSTEMCD = '" + systemcd + "' ");
            sb.AppendLine(" AND KUBUN    = '" + kubun + "'    ");
            sb.AppendLine("ORDER BY                           ");
            sb.AppendLine("    EDA                            ");

            da = new SqlDataAdapter(sb.ToString(), conn);
            da.Fill(tb);

            return tb;
        }
    }
}*/