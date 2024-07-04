// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログ情報管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.09.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;
using AIplus.AiReport.Utils;
using AIplus.AiReport.Enums;
using System.Text;

namespace BCC.Affect.Service.AWAF00803G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ログ情報一覧(一覧画面)
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool pnoAuthFlg)
        {
            var vmList = new List<RowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetVM(db, row, pnoAuthFlg));
            }

            return vmList;
        }

        /// <summary>
        /// ヘッダー情報(詳細画面)
        /// </summary>
        public static HeaderVM GetVM(DaDbContext db, tt_aflogDto logDto, tm_afuserDto userDto, bool pnoflg, bool pnoAuthFlg)
        {
            var vm = new HeaderVM();
            vm.status = DaNameService.GetName(db, EnumNmKbn.処理結果コード, logDto.statuscd);                                   //処理結果(名称)
            vm.syoridttm = $"{FormatWaKjDttm(logDto.syoridttmf)}{DaStrPool.C_TILDE_FULL}{FormatWaKjDttm(logDto.syoridttmt)}";   //処理日時（開始～終了）

            TimeSpan timeSpan = TimeSpan.FromMilliseconds(CDbl(logDto.milisec));
            vm.syoritime = FormatTime(timeSpan);                                                                                //処理時間
            vm.servicenm = CStr(logDto.service);                                                                                //機能(名称)
            vm.methodnm = CStr(logDto.methodnm);                                                                                //処理(名称)
            if (logDto.reguserid != DaConst.SYSTEM)
            {
                vm.user = userDto.usernm;                                                                                       //操作者(名称)
            }
            else
            {
                vm.user = DaConst.SYSTEM;
            }
            if (pnoAuthFlg)
            {
                vm.pnoflg = FormatFlgStr(pnoflg);                                                                               //個人番号操作状況
            }

            return vm;
        }

        /// <summary>
        /// ドロップダウンリスト(変更テーブル)
        /// </summary>
        public static List<DaSelectorModel> GetTableList(List<AiTableInfo> infoList, List<string> dataList)
        {
            var list = new List<DaSelectorModel>();

            foreach (var tbl in dataList)
            {
                var info = infoList.Find(e => e.TableName == tbl)!;
                list.Add(new DaSelectorModel(tbl, info.TableDesc));
            }

            return list;
        }

        /// <summary>
        /// ドロップダウンリスト(変更項目)
        /// </summary>
        public static List<DaSelectorKeyModel> GetItemList(DaDbContext db, List<DaSelectorKeyModel> dataList)
        {
            foreach (var item in dataList)
            {
                //テーブル情報
                var tblInfo = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, item.key);
                //項目情報
                var itemInfo = tblInfo.FieldList.Find(e => e.FieldName == item.value)!;
                item.label = itemInfo.FieldDesc;
            }

            return dataList;
        }

        /// <summary>
        /// 通信ログ情報一覧(詳細画面)
        /// </summary>
        public static List<TusinRowVM> GetTusinVMList(DataRowCollection rows)
        {
            var vmList = new List<TusinRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetTusinVM(row));
            }

            return vmList;
        }

        /// <summary>
        /// バッチログ情報一覧(詳細画面)
        /// </summary>
        public static List<BatchRowVM> GetBatchVMList(DataRowCollection rows)
        {
            var vmList = new List<BatchRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetBatchVM(row));
            }

            return vmList;
        }

        /// <summary>
        /// 連携ログ情報一覧(詳細画面)
        /// </summary>
        public static List<GaibuRowVM> GetGaibuVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<GaibuRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetGaibuVM(db, row));
            }

            return vmList;
        }

        /// <summary>
        /// 項目値変更情報(詳細画面)
        /// </summary>
        public static List<ColumnRowVM> GetColumnVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<ColumnRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetColumnVM(db, row));
            }

            return vmList;
        }

        /// <summary>
        /// 宛名番号ログ情報一覧(詳細画面)
        /// </summary>
        public static List<AtenaRowVM> GetAtenaVMList(DaDbContext db, DataRowCollection rows, bool pnoAuthFlg, bool adrsFlg)
        {
            var vmList = new List<AtenaRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetAtenaVM(db, row, pnoAuthFlg, adrsFlg));
            }

            return vmList;
        }

        /// <summary>
        /// DB操作ログ情報一覧(詳細画面)
        /// </summary>
        public static List<DBRowVM> GetDBVMList(DataRowCollection rows)
        {
            var vmList = new List<DBRowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetDBVM(row));
            }

            return vmList;
        }

        /// <summary>
        /// ファイルリスト取得
        /// </summary>
        public static List<DaFileModel> GetFileList(DataTable? dt0, DataTable? dt1, DataTable? dt2, DataTable? dt3, DataTable? dt4, DataTable? dt5, DataTable? dt6,
                                                    bool mainflg, bool tusinflg, bool batchflg, bool gaibuflg, bool dbflg, bool columnflg, bool atenaflg)
        {
            var list = new List<DaFileModel>();

            var quotation = ArEnumQuotation.Mix;
            if (mainflg && dt0 != null) list.Add(new DaFileModel($"ログメイン_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt0!, true, quotation))));
            if (tusinflg && dt1 != null) list.Add(new DaFileModel($"ログ通信_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt1!, true, quotation))));
            if (batchflg && dt2 != null) list.Add(new DaFileModel($"ログバッチ_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt2!, true, quotation))));
            if (gaibuflg && dt3 != null) list.Add(new DaFileModel($"ログ連携_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt3!, true, quotation))));
            if (dbflg && dt4 != null) list.Add(new DaFileModel($"ログDB_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt4!, true, quotation))));
            if (columnflg && dt5 != null) list.Add(new DaFileModel($"ログ項目値_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt5!, true, quotation))));
            if (atenaflg && dt6 != null) list.Add(new DaFileModel($"ログ宛名_{FormatTime2(DaUtil.Now)}", $".{EnumFileTypeKbn.csv}", GetCsvData(ArCsvUtil.ToCsv(dt6!, true, quotation))));
            return list;
        }

        /// <summary>
        /// CSVファイル生成
        /// </summary>
        private static byte[] GetCsvData(string csvStr)
        {
            return Encoding.UTF8.GetBytes(csvStr);
        }

        /// <summary>
        /// ログ情報(一覧画面)1行
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row, bool pnoAuthFlg)
        {
            var vm = new RowVM();

            vm.sessionseq = row.CLng("seq");                                            //ログシーケンス
            vm.existflg1 = FormatFlgStr(row.CBool(nameof(RowVM.existflg1)));            //通信ログ操作状況
            vm.existflg2 = FormatFlgStr(row.CBool(nameof(RowVM.existflg2)));            //バッチログ操作状況
            vm.existflg3 = FormatFlgStr(row.CBool(nameof(RowVM.existflg3)));            //外部連携ログ操作状況
            vm.existflg4 = FormatFlgStr(row.CBool(nameof(RowVM.existflg4)));            //DB操作ログ操作状況
            vm.existflg5 = FormatFlgStr(row.CBool(nameof(RowVM.existflg5)));            //項目値変更ログ操作状況
            vm.existflg6 = FormatFlgStr(row.CBool(nameof(RowVM.existflg6)));            //宛名番号ログ操作状況
            vm.syoridttmf = FormatWaKjDttm(row.CDate(nameof(RowVM.syoridttmf)));        //処理日時（開始）
            vm.syoridttmt = FormatWaKjDttm(row.CDate(nameof(RowVM.syoridttmt)));        //処理日時（終了）
            var syoritime = row.CInt(nameof(RowVM.syoritime));
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(syoritime);
            vm.syoritime = FormatTime(timeSpan);                                        //処理時間
            vm.kinoid = row.Wrap(nameof(RowVM.kinoid));                                 //機能ID
            vm.servicenm = row.Wrap(nameof(RowVM.servicenm));                           //機能名
            vm.methodnm = row.Wrap(nameof(RowVM.methodnm));                             //処理名
            vm.usernm = row.Wrap(nameof(RowVM.usernm));                                 //操作者
            if (pnoAuthFlg)
            {
                vm.pnoflg = FormatFlgStr(row.CBool(nameof(RowVM.pnoflg)));              //個人番号操作状況
            }
            vm.msgflg = FormatFlgStr(row.CBool(nameof(RowVM.msgflg)));                  //メッセージ操作状況
            var statuscd = row.Wrap(nameof(tt_aflogDto.statuscd));                      //処理結果コード
            vm.status = DaNameService.GetName(db, EnumNmKbn.処理結果コード, statuscd);  //処理結果(名称)

            return vm;
        }

        /// <summary>
        /// 通信ログ情報(詳細画面)1行
        /// </summary>
        private static TusinRowVM GetTusinVM(DataRow row)
        {
            var vm = new TusinRowVM();

            vm.tusinlogseq = row.CLng(nameof(TusinRowVM.tusinlogseq));          //通信ログシーケンス
            var syoridttmf = row.CDate(nameof(tt_aftusinlogDto.syoridttmf));    //処理日時（開始）
            var syoridttmt = row.CDate(nameof(tt_aftusinlogDto.syoridttmt));    //処理日時（終了）
            vm.syoridttm = GetSyoridttm(syoridttmf, syoridttmt);                //処理日時（開始～終了）
            vm.ipadrs = row.Wrap(nameof(TusinRowVM.ipadrs));                    //操作者IP
            vm.os = row.Wrap(nameof(TusinRowVM.os));                            //操作者OS
            vm.browser = row.Wrap(nameof(TusinRowVM.browser));                  //操作者ブラウザー
            vm.request = row.Wrap(nameof(TusinRowVM.request));                  //リクエスト
            vm.response = row.Wrap(nameof(TusinRowVM.response));                //レスポンス
            vm.msg = row.Wrap(nameof(TusinRowVM.msg));                          //メッセージ

            return vm;
        }

        /// <summary>
        /// バッチログ情報(詳細画面)1行
        /// </summary>
        private static BatchRowVM GetBatchVM(DataRow row)
        {
            var vm = new BatchRowVM();

            vm.batchlogseq = row.CLng(nameof(BatchRowVM.batchlogseq));          //バッチログシーケンス
            var syoridttmf = row.CDate(nameof(tt_afbatchlogDto.syoridttmf));    //処理日時（開始）
            var syoridttmt = row.CDate(nameof(tt_afbatchlogDto.syoridttmt));    //処理日時（終了）
            vm.syoridttm = GetSyoridttm(syoridttmf, syoridttmt);                //処理日時（開始～終了）
            vm.pram = row.Wrap(nameof(BatchRowVM.pram));                        //パラメータ
            vm.msg = row.Wrap(nameof(BatchRowVM.msg));                          //メッセージ

            return vm;
        }

        /// <summary>
        /// 連携ログ情報(詳細画面)1行
        /// </summary>
        private static GaibuRowVM GetGaibuVM(DaDbContext db, DataRow row)
        {
            var vm = new GaibuRowVM();

            vm.gaibulogseq = row.CLng(nameof(GaibuRowVM.gaibulogseq));                          //外部連携ログシーケンス
            var syoridttmf = row.CDate(nameof(tt_afgaibulogDto.syoridttmf));                    //処理日時（開始）
            var syoridttmt = row.CDate(nameof(tt_afgaibulogDto.syoridttmt));                    //処理日時（終了）
            vm.syoridttm = GetSyoridttm(syoridttmf, syoridttmt);                                //処理日時（開始～終了）
            vm.ipadrs = row.Wrap(nameof(GaibuRowVM.ipadrs));                                    //操作者IP
            var kbn = row.Wrap(nameof(GaibuRowVM.kbn));
            vm.kbn = DaNameService.GetName(db, EnumNmKbn.連携方向区分, kbn);                    //連携区分
            var kbn2 = row.Wrap(nameof(GaibuRowVM.kbn2));
            vm.kbn2 = DaNameService.GetName(db, EnumNmKbn.連携方式, kbn2);                      //連携方式
            var kbn3 = row.Wrap(nameof(GaibuRowVM.kbn3));
            vm.kbn3 = DaNameService.GetName(db, EnumNmKbn.連携処理区分, kbn3);                  //処理区分
            vm.apidata = row.Wrap(nameof(GaibuRowVM.apidata));                                  //API連携データ
            var filenm = row.Wrap(nameof(GaibuRowVM.filenm));                                   //ファイル名
            if (!string.IsNullOrEmpty(filenm))
            {
                var filetype = (EnumFileTypeKbn)row.CInt(nameof(tt_afgaibulogDto.filetype));    //ファイルタイプ
                vm.filenm = $"{filenm}{DaStrPool.C_DOT}{filetype}";                             //ファイル名
            }
            vm.msg = row.Wrap(nameof(GaibuRowVM.msg));                                          //メッセージ

            return vm;
        }

        /// <summary>
        /// DB操作ログ情報(詳細画面)1行
        /// </summary>
        private static DBRowVM GetDBVM(DataRow row)
        {
            var vm = new DBRowVM();

            vm.dblogseq = row.CLng(nameof(DBRowVM.dblogseq));   //DB操作ログシーケンス
            vm.sql = row.Wrap(nameof(DBRowVM.sql));             //SQL

            return vm;
        }

        /// <summary>
        /// 項目値変更情報(詳細画面)1行
        /// </summary>
        private static ColumnRowVM GetColumnVM(DaDbContext db, DataRow row)
        {
            var vm = new ColumnRowVM();

            vm.columnlogseq = row.CLng(nameof(ColumnRowVM.columnlogseq));               //項目値変更ログシーケンス
            vm.tablenm = row.Wrap(nameof(ColumnRowVM.tablenm));                         //変更テーブル
            var henkokbn = row.Wrap(nameof(ColumnRowVM.henkokbn));
            vm.henkokbn = DaNameService.GetName(db, EnumNmKbn.DB変更区分, henkokbn);    //変更区分
            vm.keys = row.Wrap(nameof(ColumnRowVM.keys));                               //主キー
            vm.itemnm = row.Wrap(nameof(ColumnRowVM.itemnm));                           //変更項目
            vm.valuebefore = row.Wrap(nameof(ColumnRowVM.valuebefore));                 //変更前内容
            vm.valueafter = row.Wrap(nameof(ColumnRowVM.valueafter));                   //更新後内容

            return vm;
        }

        /// <summary>
        /// 宛名番号ログ情報(詳細画面)1行
        /// </summary>
        private static AtenaRowVM GetAtenaVM(DaDbContext db, DataRow row, bool pnoAuthFlg, bool adrsFlg)
        {
            var vm = new AtenaRowVM();

            vm.atenalogseq = row.CLng(nameof(AtenaRowVM.atenalogseq));              //宛名番号ログシーケンス
            vm.atenano = row.Wrap(nameof(AtenaRowVM.atenano));                      //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                              //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                       //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                         //住民区分
            if (pnoAuthFlg)
            {
                vm.pnoflg = FormatFlgStr(row.CBool(nameof(AtenaRowVM.pnoflg)));     //個人番号操作状況
            }
            var usekbn = row.Wrap(nameof(AtenaRowVM.usekbn));
            vm.usekbn = DaNameService.GetName(db, EnumNmKbn.操作処理区分, usekbn);  //操作区分

            return vm;
        }

        /// <summary>
        /// 処理日時取得（開始～終了）
        /// </summary>
        private static string GetSyoridttm(DateTime dttmf, DateTime dttmt)
        {
            var syoridttmf = FormatWaKjDttm(dttmf);                         //処理日時（開始）
            var syoridttmt = FormatWaKjDttm(dttmt);                         //処理日時（終了）
            return $"{syoridttmf}{DaStrPool.C_TILDE_FULL}{syoridttmt}";     //処理日時（開始～終了）
        }
    }
}