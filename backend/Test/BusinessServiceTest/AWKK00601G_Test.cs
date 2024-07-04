using BCC.Affect.DataAccess;
using NPOI.SS.Formula.Functions;
using System.Data;

namespace BCC.Affect.Service.AWKK00601G
{
    [TestClass]
    public class AWKK00601G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        //public void InitListTest()
        //{
        //    var req = new DaRequestBase();
        //    var res = _service.InitList(req);
        //}

        //[TestMethod]
        //public void SearchListTest()
        //{
        //    var req = new SearchListRequest
        //    {
        //        gyoumukbn = "1", //業務区分
        //        impnm = "1" //一括取込入力名
        //    };
        //    var res = _service.Search(req);
        //}


        [TestMethod]
        public void DetailTest()
        {
            var req = new InitDetailRequest
            {
                impno = "1000",  //取込ID
                editkbn = Enum編集区分.変更   //新規フラグ
            };
            var res = _service.InitDetail(req);
        }

        //[TestMethod]
        //public void InitSysCodeListTest()
        //{
        //    var req = new InitSystemCodeRequest
        //    {
        //        cdchangeid = 3,  //
        //    };
        //    var res = _service.InitSysCodeList(req);
        //}

        //[TestMethod]
        //public void SaveTest()
        //{
        //    var req = new SaveDetailRequest
        //    {
        //        impid = 6,  //取込ID
        //        editkbn = Enum編集区分.新規,      //編集区分
        //        userid = "1"
        //    };

        //    GetSaveData(req);

        //    var res = _service.Save(req);
        //}

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    var req = new DetailCommonRequest
        //    {
        //        impid = 13,  //取込ID
        //        userid = "1"
        //    };

        //    var res = _service.Delete(req);
        //}

        //[TestMethod]
        //public void DownloadTest()
        //{
        //    //var req = new DetailCommonRequest
        //    //{
        //    //    impid = 15,  //取込ID
        //    //};
        //    //var res = _service.Download(req);
        //}

        //[TestMethod]
        //public void ExcelUploadTest()
        //{
        //    var req = new UploadRequest
        //    {
        //        impid = 3,  //取込ID
        //        gyoumukbn = "2",
        //        impno = 2,
        //        impkbn = "1",
        //    };
        //    var res = _service.ExcelUpload(req);
        //}

        //[TestMethod]
        //public void ReSearchProc()
        //{
        //    var req = new DaRequestBase
        //    {
        //    };
        //    var res = _service.ReSearchProc(req);
        //}

        private void GetSaveData(SaveDetailRequest req)
        {
            //req.hearderData = GetHeaderVM();      //ヘッダー情報を取得する
            //req.fileinfoData = GetFileInfoVM();   //取込ファイル基本情報を取得する
            //req.fileifList = GetFileIFVM();//ファイルI/F情報を取得する
            //req.codechangeList = GetCodeChangeVM();//取込コード変換情報を取得する
            //req.itemmappingList = GetItemMappingVM();//マッピング設定情報を取得する
            //req.pageitemList = GetPageItemVM();//画面項目情報を取得する
            //req.insertList= GetInsertVMList();//取込登録詳細情報を取得する

        }

        /// <summary>
        /// ヘッダー情報を取得する(詳細画面)
        /// </summary>
        private HeaderVM GetHeaderVM()
        {
            var vm = new HeaderVM();
            //vm.gyoumukbn = "2";       //業務区分
            //vm.impno = 1;               //***一括取込入力No
            //vm.impnm = "n"+ vm.impno.ToString();               //一括取込入力名
            //vm.impkbn = "1";             //一括取込入力区分
            //vm.yeardispflg = true;   //年度表示フラグ
            //vm.regupdkbn = "1";       //登録区分
            //vm.memo = "m" + vm.impno.ToString();                 //説明
            //vm.procchk = "";           //チェックプロシージャ名
            //vm.procbefore = "";     //更新前プロシージャ名
            //vm.procafter = "";       //更新後プロシージャ名

            //vm.tableidList = new List<string>() { "tt_kkimpdata","tt_kkimpdatadetail" };   //テーブル物理ID
            return vm;
        }

        /// <summary>
        /// 取込ファイル基本情報を取得する(詳細画面)
        /// </summary>
        private FileInfoVM GetFileInfoVM()
        {
            var vm = new FileInfoVM();
            vm.filetype = "1";     //ファイル形式
            vm.fileencode = "1"; //ファイルエンコード	
            vm.filenmrule = "1"; //ファイル名称
            vm.filenmruleflg = false; //ファイル名称
            vm.datakbn = "1";       //データ形式	
            vm.recordlen = 1;   //レコード長	
            vm.quoteskbn = "1";   //引用符存在区分
            vm.dividekbn = ",";   //区切り記号
            vm.headerrows = 1; //ヘッダー行数
            vm.footerrows = 5; //フッター行数
            return vm;
        }

        /// <summary>
        /// ファイルI/F情報を取得する(詳細画面)
        /// </summary>
        private List<FileIFVM> GetFileIFVM()
        {
            var vmList = new List<FileIFVM>();
            for (int i= 1;i <= 2;i++)
            {
                var vm = new FileIFVM();
                vm.fileitemseq = i;               //ファイル項目ID	
                vm.itemnm = "nm"+i.ToString();                         //項目名
                vm.keyflg = true;                         //キーフラグ
                vm.requiredflg = true;               //必須フラグ
                vm.datatype = "1";                     //データ型
                vm.len = 1;                               //桁数
                vm.len2 = 0;                             //桁数（小数部）
                vm.format = "1";                         //フォーマット
                vm.memo = "m" + i.ToString();                             //備考
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 取込コード変換情報を取得する(詳細画面)
        /// </summary>
        //private List<CodeChangeVM> GetCodeChangeVM()
        //{
        //    //取込コード変換情報リスト
        //    var vmList = new List<CodeChangeVM>();

        //    List<tm_kkimpcdchangeDto> tmdtl = new List<tm_kkimpcdchangeDto>();
        //    tmdtl.Add(new tm_kkimpcdchangeDto() { cdchangeid = 5, cdchangekbn = 1 });
        //    tmdtl.Add(new tm_kkimpcdchangeDto() { cdchangeid = 6, cdchangekbn = 2 });
        //    foreach (var tmdto in tmdtl)
        //    {
        //        //取込コード変換情報
        //        var vm = new CodeChangeVM();
        //        //コード変換区分
        //        vm.cdchangeid = tmdto.cdchangeid;
        //        //取込コード変換情報明細リスト
        //        var codechangedetailList = new List<CodeChangeDetailVM>();
        //        for (int i = 1; i <= 2; i++)
        //        {
        //            var detailVM = new CodeChangeDetailVM();
        //            detailVM.cdchangeid = tmdto.cdchangeid;   //コード変換ID
        //            detailVM.cdchangekbn = tmdto.cdchangekbn;   //コード変換区分
        //            detailVM.oldcode = "000" + i.ToString();           //元コード
        //            detailVM.oldcodememo = "A" + i.ToString();   //元コード説明
        //            detailVM.newcode = "100" + i.ToString();           //変換後コード
        //            detailVM.newcodememo = "AA" + i.ToString();   //変換後コード説明
        //            //取込コード変換情報明細リスト
        //            codechangedetailList.Add(detailVM);
        //        }
        //        //取込コード変換情報明細リスト
        //        vm.codechangedetailList = codechangedetailList;
        //        vmList.Add(vm);
        //    }
        //    return vmList;
        //}

        /// <summary>
        /// マッピング設定情報を取得する(詳細画面)
        /// </summary>
        private List<ItemMappingVM> GetItemMappingVM()
        {
            var vmList = new List<ItemMappingVM>();
            for (int i = 1; i <= 2; i++)
            {
                var vm = new ItemMappingVM();
                vm.pageitemseq = i;       //画面項目ID
                vm.fileitemseq = "1";       //ファイル項目(ファイル項目ID,カンマ区切り)
                vm.mappingkbn = "1";         //マッピング区分
                vm.mappingmethod = "1";   //マッピング方法
                vm.substrfrom = 1; //指定桁数（開始）
                vm.substrto = 1;     //指定桁数（終了）

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 画面項目情報を取得する(詳細画面)
        /// </summary>
        private List<PageItemVM> GetPageItemVM()
        {
            var vmList = new List<PageItemVM>();
            for (int i = 1; i <= 2; i++)
            {
                var vm = new PageItemVM();

                //※基本情報
                vm.pageitemseq = i;   //画面項目ID
                vm.itemnm = "項目"+i.ToString();             //項目名
                vm.inputkbn = "1";         //入力区分
                vm.inputtype = "1";       //入力方法
                vm.len = 10;                   //桁数
                vm.len2 = 0;                 //桁数（小数部）
                vm.width = 150;               //幅
                vm.format = "1";             //フォーマット
                vm.requiredflg = "1";           //必須フラグ	
                vm.uniqueflg = true;               //一意フラグ	
                vm.seiki = "1";                       //正規表現	"
                vm.dispinputkbn = "1";         //表示入力設定区分
                vm.sortno = 1;                     //並び順

                //※マスタ参照
                vm.fromitemseq = 1;           //参照元項目ID
                vm.fromfieldid = "1";           //参照元フィールド
                vm.targetfieldid = "1";     //取得先フィールド

                // vm.yearchkflg = true;                   //年度参照フラグ
                vm.minval = "1";                     //最小値
                vm.maxval = "1";                     //最大値
                vm.defaultval = "1";             //初期値

                //※マスタ存在
                vm.msttable = "1";                 //マスタチェックテーブル
                vm.mstjyoken = "1";   //マスタチェック条件
                vm.mstfield = "1";     //マスタチェック項目

                //※条件必須
                vm.jherrlelkbn = "1";   //条件必須エラーレベル区分
                vm.jhitemseq = 1;       //条件必須項目ID
                vm.jhenzan = "1";   //条件必須演算子
                vm.jhval = "1";       //条件必須値

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 取込登録詳細情報を取得する(詳細画面)
        /// </summary>
        private List<InsertVM> GetInsertVMList()
        {
            //登録項目情報リスト
            var vmList = new List<InsertVM>();

            List<string> tableidList = new List<string>() { "tt_kkimpdata", "tt_kkimpdatadetail" };
            List<string> fieldList = new List<string>() { "tt_kkimpdata", "tt_kkimpdatadetail" };

            if (tableidList != null && tableidList.Count > 0)
            {
                var insertDetailList = new List<InsertDetailVM>();
                //foreach (string tableid in tableidList)
                //{
                //    for (int i = 1; i <= 2; i++)
                //    {
                //        var detailVM = new InsertDetailVM();
                //        detailVM.tableid = tableid;    //テーブル物理名
                //        detailVM.recno = 1;        //レコードNo
                //        detailVM.fieldid = "fieldid" + i.ToString();    //フィールド物理名
                //        detailVM.syorikbn = "1";  //処理区分
                //        detailVM.pageitemseq = 1; //データ元画面項目ID
                //        detailVM.fixedval = "1"; //固定値

                //        insertDetailList.Add(detailVM);
                //    }
                //}
                var detailVM = new InsertDetailVM();
                detailVM.tableid = "tt_kkimpdata";    //テーブル物理名
                detailVM.recno = 1;        //レコードNo
                detailVM.fieldid = "errcnt";    //フィールド物理名
                detailVM.syorikbn = "1";  //処理区分
                detailVM.pageitemseq = 1; //データ元画面項目ID
                detailVM.fixedval = "1"; //固定値
                insertDetailList.Add(detailVM);

                detailVM = new InsertDetailVM();
                detailVM.tableid = "tt_kkimpdata";    //テーブル物理名
                detailVM.recno = 1;        //レコードNo
                detailVM.fieldid = "filename";    //フィールド物理名
                detailVM.syorikbn = "1";  //処理区分
                detailVM.pageitemseq = 1; //データ元画面項目ID
                detailVM.fixedval = "1"; //固定値
                insertDetailList.Add(detailVM);

                detailVM = new InsertDetailVM();
                detailVM.tableid = "tt_kkimpdatadetail";    //テーブル物理名
                detailVM.recno = 1;        //レコードNo
                detailVM.fieldid = "colno";    //フィールド物理名
                detailVM.syorikbn = "1";  //処理区分
                detailVM.pageitemseq = 1; //データ元画面項目ID
                detailVM.fixedval = "1"; //固定値
                insertDetailList.Add(detailVM);

                detailVM = new InsertDetailVM();
                detailVM.tableid = "tt_kkimpdatadetail";    //テーブル物理名
                detailVM.recno = 1;        //レコードNo
                detailVM.fieldid = "dataseq";    //フィールド物理名
                detailVM.syorikbn = "1";  //処理区分
                detailVM.pageitemseq = 1; //データ元画面項目ID
                detailVM.fixedval = "1"; //固定値
                insertDetailList.Add(detailVM);


                //テーブル物理名
                foreach (string tableid in tableidList)
                {
                    //登録項目情報
                    var vm = new InsertVM();
                    //テーブル物理名
                    vm.tableid = tableid;
                    //登録項目明細情報リスト
                    vm.insertdetailList = insertDetailList.Where(d => d.tableid == tableid).ToList();
                    vmList.Add(vm);
                }
            }
            return vmList;
        }
    }
}