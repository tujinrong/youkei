using AIplus.AIF.DBLib;
using BCC.Affect.DataAccess;
using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Transactions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;

namespace TestAILIB60.TestAILIB60
{

    [TestClass]
    public class Tests
    {
        private DaDbContext db = new DaDbContext();
        /// <summary>
        /// 追加、削除サンプル
        /// </summary>
        [TestMethod]
        public void TestNull()
        {
            var names = new string[] {nameof(tt_afatenaDto.sex), nameof(tt_afatenaDto.simei_kana_seion) };
            var list = new List<object?[]>() {
                new object?[]{"1", "イノウエマサミ" },
                new object?[]{"1", null }
            };
            var dtolist = db.Session.GetDtoListByItemList<tt_afatenaDto>(names, list);
            //var dtolist = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.simei_kana_seion), null).GetDtoList();
            //var list = new List<object?>() {
            //     "イノウエマサミ", null  };
            //var dtolist2 = db.tt_afatena.SELECT.WHERE.ByItemList(nameof(tt_afatenaDto.simei_kana_seion),
            //    list).GetDtoList();
        }

        [TestMethod]
        public void TestCache()
        {
            Stopwatch sw = Stopwatch.StartNew();
            {
                var list9 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.データ型)).ToString());
                var list10 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.部署_支所)).ToString());
                var list1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ);
                var list1B = DaSelectorService.GetSelectorList(db, Enum名称区分.カナ, Enumマスタ区分.医療機関マスタ);
                var list1C = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, false, "001");
                var list2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.ユーザーマスタ);
                var list3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.所属グループマスタ);
                var list4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.市区町村マスタ);
                var list4B = DaSelectorService.GetSelectorList(db, Enum名称区分.カナ, Enumマスタ区分.市区町村マスタ);
                var list5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ);
                var list5B = DaSelectorService.GetSelectorList(db, Enum名称区分.カナ, Enumマスタ区分.会場情報マスタ);


                var list6 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.名称メインマスタ, 名称マスタメインコード._1000);
                var list7 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.汎用メインマスタ, 汎用マスタメインコード._3010);
                var list8 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUCテーブルマスタ);
            }
            var m1 = sw.ElapsedMilliseconds;
            {
                var list1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ);
                var list2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.ユーザーマスタ);
                var list3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.所属グループマスタ);
                var list4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.市区町村マスタ);
                var list5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ);
                var list6 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.名称メインマスタ, 名称マスタメインコード._1000);
                var list7 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.汎用メインマスタ, 汎用マスタメインコード._3010);
                var list8 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUCテーブルマスタ);
                //var list9 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ);
                //var list10 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ);
            }
            //名称取得
            var name = DaSelectorService.GetName(db, "12211", Enum名称区分.名称, Enumマスタ区分.医療機関マスタ);
            var cdnm = DaSelectorService.GetCdNm(db, "0001", Enum名称区分.名称, Enumマスタ区分.医療機関マスタ);
            var namelist = DaNameService.GetSelectorList(db, EnumNmKbn.いいえ_はい, Enum名称区分.名称);
            var kanalist = DaNameService.GetSelectorList(db, EnumNmKbn.いいえ_はい, Enum名称区分.カナ);
            var m2 = sw.ElapsedMilliseconds;

            var name2 = DaNameService.GetName(db, EnumNmKbn.いいえ_はい, "1");
            var name3 = DaNameService.GetKanaName(db, EnumNmKbn.いいえ_はい, "1");
            var name4 = DaNameService.GetKbn3(db, EnumNmKbn.いいえ_はい, "1");
            var m3 = sw.ElapsedMilliseconds;

            var namelist2 = DaNameService.GetNameList(db, EnumNmKbn.いいえ_はい);
            var m4 = sw.ElapsedMilliseconds;
            var newlist = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.いいえ_はい)).ToString());
            var m5 = sw.ElapsedMilliseconds;
            sw.Stop();

        }


        [TestMethod]
        public void TestIN()
        {
            var session = db.Session;
            var sql = "SELECT * FROM tt_afatena WHERE sex = ANY(@性別) LIMIT 1";
            var paraNames = new string[] { "性別" };
            var paraValues = new object?[] { new string[] { "1", "2" } };
            var dt = session.GetDataTable(sql, paraNames, paraValues);
            Console.WriteLine("");
        }

        [TestMethod]
        public void TestSQL()
        {
            var session = db.Session;
            var sql = "SELECT * FROM tt_afatena WHERE sex=@性別 LIMIT 1";
            var paraNames = new string[] { "性別" };
            var paraValues = new object?[] { "1" };
            var dt = session.GetDataTable(sql, paraNames, paraValues);
            Console.WriteLine("");
        }

        [TestMethod]
        public void TestProcedure()
        {
            //複数関数のテスト
            var procList = new List<ProcModel>() {
                new ProcModel(){ProcName="", ParamList=new List<object?>(){1,2,3}},
                new ProcModel("euc_af_getage", "1984-10-01", DateTime.Today),
                };
            var valueList = DaDbUtil.GetProcedureValueList(db, procList);

            //関数
            var value = DaDbUtil.GetProcedureValue(db, "euc_af_getage", "1983-10-01", DateTime.Today);
        }


        [TestMethod]
        public void Test1()
        {
            db.tt_afinfo_user.DELETE.WHERE.ByKeyList(new List<long>() { 1 }).Execute();
            // db.tm_eureportitem.DELETE.WHERE.ByKey(1).Execute();
        }


        [TestMethod]
        public void TestService()
        {
            TransactionOptions options = new()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 3, 0)
            };
            using var scope = new TransactionScope(TransactionScopeOption.Required, options);
            var currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            try
            {
                // サービス名とメソッド名を取得する
                db.Session.UserID = "sytem";
                db.Session.Unit = "123";
                if (db.tt_shkensin.SELECT.WHERE.ByKey("010").Exists())
                {
                    var dto = db.tt_shkensin.SELECT.WHERE.ByKey("010").GetDto();
                    dto.jissiymd = DateTime.Now.ToString("hhmmss");
                    db.tt_shkensin.INSERT.Execute(dto);
                }
                scope?.Complete();
                return;
            }
            catch (Exception ex)
            {
                scope.Dispose();
                DaDbLogService.WriteDbException(db, ex);
                DaLogService.WriteException(currentMethod.Name, ex);
            }
            finally
            {
                db?.Dispose();
            }


        }
        [TestMethod]
        public void TestSession()
        {
            var session = db.Session;
            var meisyolist = session.Query<tm_afmeisyoDto>("SELECT * FROM tm_afmeisyo");
            Stopwatch sw = Stopwatch.StartNew();
            var freeList = session.Query<tt_shfreeDto>("SELECT * FROM tt_shfree");
            sw.Stop();
            sw.Restart();
            var freelist = db.tt_shfree.SELECT.GetDtoList();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
            sw.Restart();
            (var list1, var list2, var list3) = session.Query<tm_afmeisyoDto, tm_afctrlDto, tt_shfreeDto>(
                                    "SELECT * FROM tm_afmeisyo;" +
                                    "SELECT * FROM tm_afctrl;" +
                                    "SELECT * FROM tt_shfree");
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());

        }

        [TestMethod]
        public void TestEncrypt()
        {
            //システム・デフォルト・キーの暗号化と復号化
            var encrypt1 = DaEncryptUtil.RsaEncrypt("abc");
            var decrypt1 = DaEncryptUtil.RsaDecrypt(encrypt1);
            var test = DaEncryptUtil.RsaDecrypt("FjVnXrw+nkiZADCpcAL/HqQsAedBJN4Ieij6VnLSxJP4RvI6N0cj0at3u+UswRL8ltKmCq/By6k6rZMEUmCCWcqiQ0bqlvTbCMSz9lwlxOQKhpo5VNl/GGZ6KBHEVi6+QMLVNRYRWzZRJrkoj25rirSR644jB0e/nAdsyVxV0un7UU3+/79UI9wyUO/PwoWboSq7dYHQgQo9WiHgvSzqhQaXxx/LMVRdu5uGYDS8QDhReWMclObJhUDgIJqsWbdRmHjVeuEv7+v6MOdbujDk7MJbuHeZWxtbAAE8mmyb7ShKmXurHW66C8lj38wkrSoM7hEPSaTs3+k6guo5cdoPDQ==");

            //一度だけ暗号化する
            var encrypt2 = DaEncryptUtil.RsaEncrypt("abc", out var privateKeyPem2);
            var decrypt2 = DaEncryptUtil.RsaDecrypt(encrypt2, privateKeyPem2);

            //同じ公開鍵で複数回暗号化する
            var encrypt3A = DaEncryptUtil.RsaEncrypt("abc", out var publicKey, out var privateKeyPem3);
            var encrypt3B = DaEncryptUtil.RsaEncrypt("abcd", publicKey);
            var encrypt3C = DaEncryptUtil.RsaEncrypt("abcde", publicKey);
            var decrypt3A = DaEncryptUtil.RsaDecrypt(encrypt3A, privateKeyPem3);
            var decrypt3B = DaEncryptUtil.RsaDecrypt(encrypt3B, privateKeyPem3);
            var decrypt3C = DaEncryptUtil.RsaDecrypt(encrypt3C, privateKeyPem3);
        }

        /// <summary>
        /// 更新サンプル
        /// </summary>
        [TestMethod]
        public void TestUseModelItems()
        {
            db.Session.UserID = "sytem";
            db.Session.Unit = "123";
            if (db.tt_shkensin.SELECT.WHERE.ByKey("010").Exists())
            {
                var dto = db.tt_shkensin.SELECT.WHERE.ByKey("010").GetDto();
                dto.jissiymd = DateTime.Now.ToString("hhmmss");
                db.tt_shkensin.UPDATE.Execute(dto);

                dto.atenano = DateTime.Now.ToString("hhmmss");
                dto.jigyocd = "100";
                db.tt_shkensin.INSERT.SetUseModelCreateItems().Execute(dto);
            }
        }

        /// <summary>
        /// Selectサンプル、DTOデータ取得
        /// </summary>
        [TestMethod]
        public void SelectSample()
        {
            // DTOの取得
            var dto = db.tt_aflogdb.SELECT.WHERE.ByKey(681).GetDto();

            // Dto全件の取得
            var dtl = db.tt_aflogdb.SELECT.GetDtoList();
            // Key=1のデータを取得
            dtl = db.tt_aflogdb.SELECT.WHERE.ByKey(681).GetDtoList();

            // ソート、Top
            //dtl = db.tt_aflogdb.SELECT.ORDER.By(nameof(tt_aflogdbDto.syoridttmf)).GetDtoList();
            //dtl = db.tt_aflogdb.SELECT.ORDER.ByDescending(nameof(tt_aflogdbDto.syoridttmf)).SetTop(0).GetDtoList();
            dtl = db.tt_aflogdb.SELECT.ORDER.ByString(nameof(tt_aflogdbDto.regdttm)).SetTop(2).GetDtoList();

            // 項目条件を指定してデータ取得
            dtl = db.tt_aflogdb.SELECT.SetSelectItems(nameof(tt_aflogdbDto.regdttm)).GetDtoList();

            // Distinctの使い方
            //var lst = db.tt_aflogdb.SELECT.SetSelectItems(nameof(tm_afuserDto.username)).SetDistinct().ORDER.By(nameof(tm_afuserDto.username)).GetDtoList().Select(e => e.username).ToList();

        }
        /// <summary>
        /// Selectサンプル　件数、最大、最小、合計
        /// </summary>
        [TestMethod]
        public void SelectSample2()
        {
            // 件数の取得
            var 全件数 = db.tt_aflogdb.SELECT.GetCount();
            var 区分1件数 = db.tt_aflogdb.SELECT.WHERE.ByKey(681).GetCount();
            List<int>? keylist2 = new List<int>();
            keylist2.Add(682);
            keylist2.Add(681);
            var dd = db.tt_aflogdb.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();
            var 区分1件数3 = db.tt_aflogdb.SELECT.WHERE.ByKeyList(keylist2).GetCount();
            //var keyList = new List<object[]>();
            //keyList.Add(new object[] { 1 });
            //keyList.Add(new object[] { 2 });
            //var 区分1件数2 = tc_kkuserDao.SELECT.WHERE.ByKeyList(keyList).GetCount();

            var 件数 = db.tt_aflogdb.SELECT.WHERE.ByFilter($"{nameof(tt_aflogdbDto.sessionseq)}>@{nameof(tt_aflogdbDto.sessionseq)}", 5).GetCount();
            件数 = db.tt_aflogdb.SELECT.WHERE.ByItem(nameof(tt_aflogdbDto.sessionseq), 20).GetCount();
            Console.WriteLine(db.tt_aflogdb.SELECT.WHERE.ByItem(nameof(tt_aflogdbDto.sessionseq), 20).Exists());

            // 最大、最小、合計
            var 最大値 = db.tt_aflogdb.SELECT.GetMax<int>(nameof(tt_aflogdbDto.sessionseq));
            var 最小値 = db.tt_aflogdb.SELECT.GetMin<int>(nameof(tt_aflogdbDto.sessionseq));
            var 合計値 = db.tt_aflogdb.SELECT.GetSum(nameof(tt_aflogdbDto.sessionseq));
        }

        ///// <summary>
        ///// KeyListサンプル
        ///// </summary>
        //[Test]
        //public void SelectSample3()
        //{
        //    // 件数の取得
        //    var keyList = new List<object[]>();
        //    keyList.Add(new object[] { "01" });
        //    keyList.Add(new object[] { "02" });
        //    // Dim dtl = t_ken_hainyuDao.SELECT.WHERE.ByKeyList(keyList).GetDtoList
        //}

        [TestMethod]
        public void DeleteFlagSample()
        {
            var list1 = db.tt_shkensin.SELECT.WHERE.ByFilter($"{nameof(tt_shkensinDto.nendo)}>'2000'").GetDtoList();
            var list2 = db.tt_shkensin.SELECT.WHERE.ByFilter($"{nameof(tt_shkensinDto.nendo)}>'2000'").SetIncludeDeletedData().GetDtoList();
            var lst = new List<string>() { "1001", "1002" };

            var list3 = db.tm_afkikan.SELECT.WHERE.ByKeyList(lst).GetDtoList();
            var max1 = db.tt_shkensin.SELECT.WHERE.ByItem(nameof(tt_shkensinDto.nendo), "2022").GetMax<int>(nameof(tt_shkensinDto.kensinkaisu));
            var max2 = db.tt_shkensin.SELECT.WHERE.ByItem(nameof(tt_shkensinDto.nendo), "2022").SetIncludeDeletedData().GetMax<int>(nameof(tt_shkensinDto.kensinkaisu));
        }



        [TestMethod]
        public void FilterSample()
        {

            // パラメータがない場合
            var list1 = db.tm_afuser.SELECT.WHERE.ByFilter($"{nameof(tm_afuserDto.userid)}>'1' AND {nameof(tm_afuserDto.userid)}<='2'").GetDtoList();

            // パラメータがある場合
            var list2 = db.tm_afuser.SELECT.WHERE.ByFilter($"{nameof(tm_afuserDto.userid)}=@{nameof(tm_afuserDto.userid)}", "1").GetDtoList();

            // 範囲パラメータの場合
            //var list3 = db.tm_afuser.SELECT.WHERE.ByFilter($"{nameof(tm_afuserDto.userid)}>=@auth_cd_FROM AND {nameof(tm_afuserDto.userid)}<=@auth_cd_TO", '1', '2').GetDtoList();

        }

        /// <summary>
        /// 追加、削除サンプル
        /// </summary>
        [TestMethod]
        public void InsertDeleteSample1()
        {
            // データの作成
            var dto = db.tm_afuser.SELECT.WHERE.ByKey("1").GetDto();
            if (dto is null)
            {
                dto = new tm_afuserDto();
            }
            dto.userid = "99";

            if (db.tm_afuser.SELECT.WHERE.ByDto(dto).Exists() == false)
            {
                // データ追加
                db.tm_afuser.INSERT.Execute(dto);
            }

            // データ削除
            db.tm_afuser.DELETE.WHERE.ByDto(dto).Execute();

            // リスト作成
            var dtl = new List<tm_afuserDto>();
            dtl.Add(dto);
            var dto2 = dto.Copy<tm_afuserDto>();
            dto2.userid = "98";
            dto2.userid = "98";
            dtl.Add(dto2);

            if (db.tm_afuser.SELECT.WHERE.ByDto(dto2).Exists() == false)
            {
                // リスト追加
                db.tm_afuser.INSERT.Execute(dtl);
            }

            // リストの削除
            db.tm_afuser.DELETE.WHERE.ByDtoList(dtl).Execute();

            // BulkInsertの使い方
            db.tm_afuser.INSERT.SetBulkInsert().Execute(dtl);

            // キーを指定して削除
            db.tm_afuser.DELETE.WHERE.ByKey("98").Execute();
            // ByItem
            db.tm_afuser.DELETE.WHERE.ByItem("userid", "99").Execute();
            // ByFilter
            //tc_kkuserDao.DELETE.WHERE.ByFilter($"Imp_Date >= '{Strings.Format(DateTime.Now, "yyyy-MM-dd")}'").Execute();

            // キー配列を指定して削除
            var keyList = new List<object[]>();
            keyList.Add(new object[] { "98" });
            keyList.Add(new object[] { "99" });
            db.tm_afuser.DELETE.WHERE.ByKeyList(keyList).Execute();
        }

        /// <summary>
        /// Identityで自動採番の取り方
        /// </summary>
        [TestMethod]
        public void IdentitySample()
        {
            using var db = new DaDbContext();
            //db.Session.SessionID = 1;
            db.Session.UserID = "test";

            //var dto = new tc_kkkeijibanDto();
            //dto.userid = "100";
            //db.tc_kkkeijiban.INSERT.Execute(dto);

            //var dtl = new List<tc_kkkeijibanDto>();
            //dto.userid = "200";
            //dtl.Add(dto);
            //var dto2 = new tc_kkkeijibanDto();
            //dto2.userid = "300";
            //dto2.title = "test";
            //dto2.crdate = DateTime.Now;
            //dtl.Add(dto2);
            //db.tc_kkkeijiban.INSERT.Execute(dtl);

            //db.tc_kkkeijiban.INSERT.SetBulkInsert().Execute(dtl);

            //var d = db.tc_kkkeijiban.SELECT.WHERE.ByKey(23).GetDto();
        }
        /// <summary>
        /// 更新サンプル
        /// </summary>
        [TestMethod]
        public void UpdateSample()
        {
            //var dto2= tc_kkuserDao.SELECT.WHERE.ByKey("1").GetDto();

            if (db.tm_afuser.SELECT.WHERE.ByKey("test").Exists())
            {
                var dto = db.tm_afuser.SELECT.WHERE.ByKey("test2").GetDto();
                dto.userid = "test";
                //dto.username = "test";
                db.tm_afuser.UPDATE.Execute(dto);
            }
            else
            {
                var dto = db.tm_afuser.SELECT.WHERE.ByKey("1").GetDto();
                dto.userid = "test";
                dto.usernm = "test";
                dto.pword = "pword";
                db.tm_afuser.INSERT.Execute(dto);
                dto.pword = "pword2";
                db.tm_afuser.UPDATE.Execute(dto);
            }
            db.tm_afuser.DELETE.WHERE.ByItem(nameof(tm_afuserDto.usernm), "test2").Execute();
        }

        [TestMethod]
        public void InsertSample()
        {

            if (db.tm_afuser.SELECT.WHERE.ByKey("test2").Exists())
            {
                db.tm_afuser.DELETE.WHERE.ByKey("test2").Execute();
            }
            var dto = db.tm_afuser.SELECT.WHERE.ByKey("1").GetDto();
            dto.userid = "test2";
            dto.usernm = "test2";
            db.tm_afuser.INSERT.Execute(dto);
        }

        [TestMethod]
        public void 排他Sample()
        {
            if (db.tm_afuser.SELECT.WHERE.ByKey("test").Exists())
            {
                var dto = db.tm_afuser.SELECT.WHERE.ByKey("test").GetDto();
                dto.userid = "test";
                dto.usernm = "test" + DateTime.Now.ToString("HHmmss");
                db.tm_afuser.UPDATE.SetLock(dto.upddttm).Execute(dto);
                try
                {
                    db.tm_afuser.UPDATE.SetLock(DateTime.Now).Execute(dto);
                }
                catch (Exception)
                {
                    Console.WriteLine("OK");
                }
            }
        }

        [TestMethod]
        public void SetUserTest()
        {
            var maxKey = db.tt_aflog.SELECT.GetMax<long>(nameof(tt_aflogDto.sessionseq));
            var dto = db.tt_aflog.SELECT.WHERE.ByKey(maxKey).GetDto();
            if (dto == null)
            {
                dto = new tt_aflogDto();
                dto.syoridttmf = AiGlobal.DbApi.GetPseudoDateTime(db.Session);
                dto.syoridttmt = DateTime.Now;
                dto.milisec = 0;
                //dto.syorikbn = EnumSyoriKbn.Information;
                //dto.msg = "Test";
                //dto.browser = "edge";
            }
            //dto.msg = "カタカナ";
            db.tt_aflog.UPDATE.Execute(dto);
            db.tt_aflog.DELETE.WHERE.ByKey(maxKey).Execute();
            db.tt_aflog.INSERT.Execute(dto);
        }
        ///// <summary>
        ///// 差分更新サンプル
        ///// </summary>
        //[TestMethod]
        //public void DiffUpdateSample()
        //{
        //    var dto = new tc_kkkeijibanDto();
        //    dto.userid = "100";
        //    db.tc_kkkeijiban.INSERT.Execute(dto);
        //    var id = dto.id;
        //    dto.userid = "200";
        //    db.tc_kkkeijiban.INSERT.Execute(dto);

        //    // ----------------------------------------------------------------
        //    // テストデータの準備
        //    // ----------------------------------------------------------------
        //    var keyList = new List<object[]>();
        //    keyList.Add(new object[] { id });
        //    keyList.Add(new object[] { id + 1 });
        //    dto.id = id;
        //    dto.title = "差分Name";
        //    var dtl = new List<tc_kkkeijibanDto>();
        //    //dtl.Add(dto);
        //    // TODO
        //    db.tc_kkkeijiban.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl);
        //}

        //[TestMethod]
        //public void insertList_Test1()
        //{
        //    List<tc_kkkeijibanDto> dtl = new List<tc_kkkeijibanDto>();
        //    for (int i = 1; i <= 50; i++)
        //    {
        //        var dto = new tc_kkkeijibanDto()
        //        {
        //            delflg = false,
        //            userid = "batch_" + i
        //        };
        //        dtl.Add(dto);
        //    }
        //    db.tc_kkkeijiban.INSERT.Execute(dtl);
        //}

        [TestMethod]
        public void insertList_Test2()
        {
            // TODO
            var dtl = new List<tt_afinfoDto>();
            for (int i = 1; i <= 50; i++)
            {
                var dto = new tt_afinfoDto()
                {
                    //title = "TEST_" + i,
                    //juyo = "01",
                    //kigen = DateTime.Today.AddDays(i),
                    syosai = "SYOSAI_" + i,
                    reguserid = "jzy",
                    upduserid = "jzy"
                };
                dto.juyodo = "1";
                dto.kigenymd = "2023-01-01";
                dtl.Add(dto);
            }
            //  var id = GetCurrentAutoID();
            //db.tt_afinfo.INSERT.SetBulkInsert().Execute(dtl);

            db.tt_afinfo.INSERT.Execute(dtl);
        }
        private long GetCurrentAutoID()
        {
            string table = "tt_afinfo";
            string item = "infoseq";
            var sql = $"SELECT CURRVAL('{table}_{item}_seq')";
            var dt = new DataTable();
            NpgsqlConnection _conn = new NpgsqlConnection(DaGlobal.ConnectionString);
            NpgsqlCommand cmd = new()
            {
                CommandText = sql,
                CommandType = CommandType.Text
            };

            _conn.Open();
            cmd.Connection = _conn;
            using var adapter = new NpgsqlDataAdapter(cmd);
            adapter.Fill(dt);
            return AiDataUtil.NzLong(dt.Rows[0][0]);
            //var cmd = new NpgsqlCommand(sql, con);
            //using (var reader = cmd.ExecuteReader())
            //{
            //    reader.Read();
            //    return Conversions.ToLong(reader[0]);
            //}
        }
        [TestMethod]
        public void UpdateTest()
        {
            var keylist2 = new List<object[]>() { new object[] { "0", "10" } };


            //部署（支所）別更新権限テーブル
            var sisyoDtl = db.tt_afauthsisyo.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();

            var dtl = new List<tt_afinfo_userDto>();
            db.tt_afinfo_user.UPDATE.WHERE.ByKey(300).Execute(dtl);
            db.tt_afinfo_user.DELETE.WHERE.ByKey(301).Execute();

            for (int i = 300; i < 320; i++)
            {
                dtl.Add(new tt_afinfo_userDto()
                {
                    infoseq = i,
                    userid = "jzy"
                });
            }

            var keys = new List<object[]>();
            for (int i = 300; i < 350; i++)
            {
                keys.Add(new object[] { i, "jzy" });
            }
            var a = db.tt_afinfo_user.SELECT.WHERE.ByKeyList(keys).GetDtoList();

            //  db.tt_afinfo_user.UPDATE.WHERE.ByKey(300).Execute(dtl);

            db.tt_afinfo_user.UPDATE.WHERE.ByKeyList(keys).Execute(dtl);

            string[] itemNames = { nameof(tt_afinfo_userDto.infoseq), nameof(tt_afinfo_userDto.userid) };

            //db.tt_afinfo_user.UPDATE.WHERE.ByItemList(itemNames, keys).Execute(dtl);
        }

        ///// <summary>
        ///// 排他削除サンプル
        ///// </summary>
        //[TestMethod]
        //public void LockSample()
        //{
        //    var dto = m_userinfoDao.SELECT.WHERE.ByKey(1, 1).GetDto();
        //    dto.auth_cd = "1";
        //    // 排他ロック
        //    if (m_userinfoDao.SELECT.WHERE.ByDto(dto).Exists() == false)
        //    {
        //        // データ追加
        //        m_userinfoDao.INSERT.Execute(dto);
        //    }
        //    // 再読み込み
        //    dto = m_userinfoDao.SELECT.WHERE.ByKey(1, 100).GetDto();
        //    // Logのユーザ設定
        //    m_userinfoDao.DELETE.WHERE.ByDto(dto).SetLock(dto.upd_date).SetUser(1).Execute();
        //    try
        //    {
        //        m_userinfoDao.INSERT.Execute(dto);
        //        // upd_date不正時、排他エラー発生
        //        m_userinfoDao.DELETE.WHERE.ByDto(dto).SetLock(1234).SetUser(1).Execute();
        //    }
        //    catch (AiExclusiveException)
        //    {
        //        Console.WriteLine("OK");
        //    }
        //}

        //// ''' <summary>
        //// ''' JOIN の使い方
        //// ''' </summary>
        //// <Test> Public Sub JoinSample()
        //// 'テーブル間JOIN
        //// Dim dtl = M_USERINFODao.SELECT.JOIN(m_plantDto.TABLE_NAME).OnAutoLink().GetDtoList

        //// Dim sw As New Stopwatch
        //// sw.Start()
        //// 'テーブル間JOIN、条件ある場合
        //// Dim dtl1 = M_USERINFODao.SELECT.JOIN(m_plantDto.TABLE_NAME).OnAutoLink("todofuken_cd=1").GetDtoList
        //// sw.Stop()
        //// Console.WriteLine(sw.ElapsedMilliseconds)

        //// 'テーブル間JOIN、項目名が異なる場合の使い方
        //// Dim dtl3 = M_USERINFODao.SELECT.JOIN(m_plantDto.TABLE_NAME).On(NameOf(m_userinfoDto.plant_cd), NameOf(m_plantDto.plant_cd), "todofuken_cd=1").GetDtoList

        //// sw.Restart()
        //// 'KeyListを使用して、メモリー上でテーブル結合
        //// Dim shopList = m_plantDao.SELECT.WHERE.ByItem(NameOf(m_plantDto.todofuken_cd), 1).GetKeyList(Of String)()
        //// Dim dtl2 = M_USERINFODao.SELECT.WHERE.ByItemList(NameOf(m_userinfoDto.plant_cd), shopList).GetDtoList
        //// Assert.AreEqual(dtl1.Count, dtl2.Count)
        //// sw.Stop()
        //// Console.WriteLine(sw.ElapsedMilliseconds)
        //// End Sub

        ///// <summary>
        ///// グルーピング処理サンプル　
        ///// </summary>
        //[TestMethod]
        //public void GroupSample()
        //{
        //    // 基本的な使い方
        //    var dt1 = m_userinfoDao.GROUP.By(nameof(m_userinfoDto.auth_cd)).AddMin(nameof(m_userinfoDto.imp_date)).AddCount().GetDataTable;

        //    // 条件設定してグルーピングする
        //    var dt2 = m_userinfoDao.GROUP.By(nameof(m_userinfoDto.auth_cd)).WHERE.ByFilter("auth_cd<10").AddCount().GetDataTable;

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //[TestMethod]
        //public void DbInfoSample()
        //{
        //    bool hasDelete_flg;
        //    AiTableInfo tableInfo;
        //    using (var conn = new SqlConnection(DaGlobal.ConnectionString))
        //    {
        //        // テーブル情報を取得
        //        tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(conn, m_userinfoDto.TABLE_NAME);
        //        hasDelete_flg = tableInfo.FieldList.Exists(e => Operators.ConditionalCompareObjectEqual(e.FieldName, "Delete_Flg", false));
        //    }

        //    var key = m_userinfoDao.SELECT.GetMax<string>(nameof(m_userinfoDto.user_authority));
        //    var upd_date = m_userinfoDao.SELECT.WHERE.ByKey(key).GetDto().upd_date;

        //    var dto = new m_userinfoDao();
        //    if (hasDelete_flg)
        //    {
        //    }
        //    // M_USERINFODao.UPDATE.WHERE.ByKey(key).SetUpdateItems(NameOf(dto.Delete_Flg)).SetLock(upd_date).SetUser(1).Execute(dto)
        //    else
        //    {
        //        // Delete_flg存在しない場合、論理削除
        //        m_userinfoDao.DELETE.WHERE.ByKey(key).SetLock(upd_date).SetUser(1).Execute();
        //    }

        //}

        ///// <summary>
        ///// DAOメソッドのテスト
        ///// </summary>
        //[TestMethod]
        //public void DaoSample()
        //{
        //    // 論理削除
        //    // Dim key = T_BOUHANDao.SELECT.GetMax(Of String)(NameOf(T_BOUHANDto.Bno))
        //    // Dim upd_date = T_BOUHANDao.SELECT.WHERE.ByKey(key).GetDto.upd_date
        //    // T_BOUHANDao.DeleteByKey(key, upd_date, 0)
        //}

        ///// <summary>
        ///// トランザクション
        ///// </summary>
        //[TestMethod]
        //public void TransactionSample()
        //{
        //    using (var scope = new System.Transactions.TransactionScope())
        //    {
        //        // レコードロック
        //        // M_USERINFODao.SELECT.WaitRecord(0)
        //        //M_USERINFODao.SELECT.WaitTable();

        //        var dto = m_userinfoDao.SELECT.WHERE.ByKey(1).GetDto();
        //        dto.auth_cd = "1";

        //        if (m_userinfoDao.SELECT.WHERE.ByDto(dto).Exists() == false)
        //        {
        //            // データ追加
        //            m_userinfoDao.INSERT.Execute(dto);
        //        }

        //        dto.auth_cd = "1";
        //        if (m_userinfoDao.SELECT.WHERE.ByDto(dto).Exists() == false)
        //        {
        //            // データ追加
        //            m_userinfoDao.INSERT.Execute(dto);
        //        }

        //        // 更新
        //        dto.user_name = "TEST";
        //        m_userinfoDao.UPDATE.Execute(dto);

        //        // 削除
        //        m_userinfoDao.DELETE.WHERE.ByKey(1).Execute();
        //        m_userinfoDao.DELETE.WHERE.ByKey(2).Execute();

        //        scope.Complete();
        //    }

        //}
        //[TestMethod]
        //public void TestPararell()
        //{
        //    for (int i = 1; i <= 1000; i++)
        //        TransactionSample();
        //    Debugger.Break();
        //}
        //[TestMethod]
        //public void token()
        //{
        //    var dto = new t_tokenDto();
        //    // 同じユーザ同時ログイン不可
        //    t_tokenDao.DELETE.WHERE.ByItem(nameof(t_tokenDto.user_id), "1").Execute();
        //    dto.user_id = "1";
        //    dto.accesstime = DateTime.Now;
        //    t_tokenDao.INSERT.Execute(dto);
        //}

        //[TestMethod]
        //public void CopyDb()
        //{
        //    AiDbTool.CopyDatabase(EnumDatabaseType.SQLSERVER, "server=JZY-PC;database=AFCTV2_TEST;Trusted_Connection=SSPI",
        //        EnumDatabaseType.POSTGRE, "Host=localhost;Port=5432;Database=postgres;uid=postgres;pwd=Jae7758521...");
        //}

    }
}