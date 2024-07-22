// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: パーセンタイル値保守
// 　　　　　　サービス処理
// 作成日　　: 2024.06.01
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00501G
{
    [DisplayName("パーセンタイル値保守")]
    public class Service : CmServiceBase
    {
        //定数定義
        private const string PROC_NAME_01 = "sp_awbh00501g_01"; //パーセンタイル値保守画面検索処理(一覧画面)用

        //パーセンタイル値パターン
        private const string PAS_PATTERN1 = "1";        //パーセンタイル標準
        private const string PAS_PATTERN2 = "2";        //パーセンタイル3P
        private const string PAS_PATTERN3 = "3";        //パーセンタイル10P
        private const string PAS_PATTERN4 = "4";        //パーセンタイル25P
        private const string PAS_PATTERN5 = "5";        //パーセンタイル50P
        private const string PAS_PATTERN6 = "6";        //パーセンタイル75P
        private const string PAS_PATTERN7 = "7";        //パーセンタイル90P
        private const string PAS_PATTERN8 = "8";        //パーセンタイル97P

        public enum Enum処理区分
        {
            削除新規 = 1,
            新規 = 2,
            更新 = 3,
            対象外 = 4
        }

        [DisplayName("初期化処理")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitList(db);
            });
        }

        [DisplayName("検索処理")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var result = new CommonResponse();
                foreach (PasentairuListVM req in req.kekkalist)
                {
                    result = Save(db, req);
                    if (result.returncode != EnumServiceResult.OK) { return result; }   //異常返し
                }
                //正常返し
                return result;
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        ///初期化処理
        /// </summary>
        private InitListResponse InitList(DaDbContext db)
        {
            var res = new InitListResponse();

            //-------------------------------------------------------------
            //１.データ加工処理
            //-------------------------------------------------------------
            res = Wraper.GetVM(db);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索画面
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //パラメータ取得
            var param = Converter.GetParameters(req);

            //パーセンタイル値情報一覧取得
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_01, param, req.pagenum, req.pagesize, req.orderby);

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.kekkalist = Wraper.GetPasentairuVMList(db, pageList.dataTable.Rows);   //パーセンタイル値一覧

            //ページャー設定
            res.SetPageInfo(pageList.TotalCount, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        private CommonResponse Save(DaDbContext db, PasentairuListVM req)
        {
            var res = new CommonResponse();

            if (req.prockbn.Equals((int)(Enum登録区分.削除新規))) 
            {
                res = ProcDelete(db, req);
                if (res.returncode != EnumServiceResult.OK) { return res; }
            } else if (req.prockbn.Equals((int)Enum登録区分.新規))
            {
                res = ProcInsert(db, req);
                if (res.returncode != EnumServiceResult.OK) { return res; }
            } else if (req.prockbn.Equals((int)Enum登録区分.更新))
            {
                res = ProcUpdate(db, req);
                if (res.returncode != EnumServiceResult.OK) { return res; }
            }

            //正常返し
            return res;
        }

        //************************************************************** 処理ロジェック（サブ） **************************************************************
        /// <summary>
        /// 削除処理（月・日単位）
        /// </summary>
        private CommonResponse ProcDelete(DaDbContext db, PasentairuListVM req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //DB削除処理
            //-------------------------------------------------------------
            //乳幼児パーセンタイル値マスタ
            db.tm_bhnyhpasentairu.DELETE.WHERE.ByKey(req.buicd, req.sex, req.month, req.date).Execute();

            //正常返し
            return res;
        }

        /// <summary>
        /// 追加処理（月・日単位）
        /// </summary>
        private CommonResponse ProcInsert(DaDbContext db, PasentairuListVM req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //追加する前にDB削除処理（重複エラーを避ける為）
            //-------------------------------------------------------------
            //乳幼児パーセンタイル値マスタ
            db.tm_bhnyhpasentairu.DELETE.WHERE.ByKey(req.buicd, req.sex, req.month, req.date).Execute();

            //-------------------------------------------------------------
            //追加処理
            //-------------------------------------------------------------
            var newdtl = new List<tm_bhnyhpasentairuDto>();

            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN1, req.pasentairustd);        //パーセンタイル標準 
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN2, req.pasentairu3p);         //パーセンタイル3P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN3, req.pasentairu10p);        //パーセンタイル10P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN4, req.pasentairu25p);        //パーセンタイル25P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN5, req.pasentairu50p);        //パーセンタイル50P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN6, req.pasentairu75p);        //パーセンタイル75P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN7, req.pasentairu90p);        //パーセンタイル90P
            newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN8, req.pasentairu97p);        //パーセンタイル97P

            //母子保健パーセンタイル値マスタ
            db.tm_bhnyhpasentairu.INSERT.Execute(newdtl); 

            //正常返し
            return res;
        }

        /// <summary>
        /// 更新処理（月・日・パターン単位）
        /// </summary>
        private CommonResponse ProcUpdate(DaDbContext db, PasentairuListVM req)
        {
            var res = new CommonResponse();

            //乳幼児パーセンタイル値マスタ
            var newdtl = new List<tm_bhnyhpasentairuDto>();    //新規追加の場合利用
            var upddtl = new List<tm_bhnyhpasentairuDto>();    //更新の場合利用

            //パーセンタイル標準 
            if (checkdataexist(db, req, PAS_PATTERN1, req.pasentairustd).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN1, req.pasentairustd); }
            else if (checkdataexist(db, req, PAS_PATTERN1, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN1, req.pasentairustd); }

            //パーセンタイル3P
            if (checkdataexist(db, req, PAS_PATTERN2, req.pasentairu3p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN2, req.pasentairu3p); }
            else if (checkdataexist(db, req, PAS_PATTERN2, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN2, req.pasentairu3p); }

            //パーセンタイル10P
            if (checkdataexist(db, req, PAS_PATTERN3, req.pasentairu10p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN3, req.pasentairu10p); }
            else if (checkdataexist(db, req, PAS_PATTERN3, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN3, req.pasentairu10p); }

            //パーセンタイル25P
            if (checkdataexist(db, req, PAS_PATTERN4, req.pasentairu25p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN4, req.pasentairu25p); }
            else if (checkdataexist(db, req, PAS_PATTERN4, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN4, req.pasentairu25p); }

            //パーセンタイル50P
            if (checkdataexist(db, req, PAS_PATTERN5, req.pasentairu50p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN5, req.pasentairu50p); }
            else if (checkdataexist(db, req, PAS_PATTERN5, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN5, req.pasentairu50p); }

            //パーセンタイル75P
            if (checkdataexist(db, req, PAS_PATTERN6, req.pasentairu75p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN6, req.pasentairu75p); }
            else if (checkdataexist(db, req, PAS_PATTERN6, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN6, req.pasentairu75p); }

            //パーセンタイル90P
            if (checkdataexist(db, req, PAS_PATTERN7, req.pasentairu90p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN7, req.pasentairu90p); }
            else if (checkdataexist(db, req, PAS_PATTERN7, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN7, req.pasentairu90p); }

            //パーセンタイル97P
            if (checkdataexist(db, req, PAS_PATTERN8, req.pasentairu97p).Equals(Enum処理区分.更新)) { upddtl = Converter.GetDto(upddtl, req, PAS_PATTERN8, req.pasentairu97p); }
            else if (checkdataexist(db, req, PAS_PATTERN8, req.pasentairustd).Equals(Enum処理区分.新規)) { newdtl = Converter.GetDto(newdtl, req, PAS_PATTERN8, req.pasentairu97p); }

            if (newdtl.Count > 0)
            {
                //新規の場合
                db.tm_bhnyhpasentairu.INSERT.Execute(newdtl);
            }

            if (upddtl.Count > 0)
            {
                //更新の場合
                db.tm_bhnyhpasentairu.UPDATE.Execute(upddtl);
            }

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// データの処理区分を取得       2：新規、3：更新、4：対象外（処理しない）
        /// </summary>
        private Enum処理区分 checkdataexist(DaDbContext db, PasentairuListVM req, string? pasentairucd, int pasentairuti)
        {
            //乳幼児パーセンタイル値マスタ
            var dto = db.tm_bhnyhpasentairu.GetDtoByKey(req.buicd, req.sex, req.month, req.date, pasentairucd!);
            if (dto != null)
            {
                //存在する場合
                if (dto.pasentairuti != pasentairuti)
                {
                    //パーセンタイル値は変更されていない場合、更新する必要ない
                    return Enum処理区分.対象外;
                }
                else
                {
                    //パーセンタイル値は変更された場合
                    return Enum処理区分.更新;
                }
            }

            //存在しない場合
            return Enum処理区分.新規;
        }
    }
}