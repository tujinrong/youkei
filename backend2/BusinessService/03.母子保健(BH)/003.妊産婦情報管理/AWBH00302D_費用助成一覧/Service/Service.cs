// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
// 　　　　　　サービス処理
// 作成日　　: 2024.05.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.Service.AWBH00301G.Service;

namespace BCC.Affect.Service.AWBH00302D
{
    [DisplayName("妊産婦情報管理-費用助成一覧")]
    public class Service : CmServiceBase
    {
        //助成金額（総額）項目名
        private const string JOSEIKINGAKUSOGAKUITEMNM = "助成金額（総額）";

        [DisplayName("費用助成一覧画面検索処理")]
        public SearchJyoseiListResponse SearchJyoseiList(SearchJyoseiListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchJyoseiList(db, req);
            });
        }

        [DisplayName("費用助成一覧保存処理")]
        public CommonResponse SaveJyosei(SaveJyoseiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveJyosei(db, req);
            });
        }

        [DisplayName("費用助成一覧削除処理")]
        public CommonResponse DeleteJyosei(DeleteJyoseiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return DeleteJyosei(db, req);
            });
        }

        [DisplayName("初期化処理")]
        public InitListResponse InitList(InitListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitList(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        ///初期化処理
        /// </summary>
        private InitListResponse InitList(DaDbContext db, InitListRequest req)
        {
            var res = new InitListResponse();

            //-------------------------------------------------------------
            //１.データ加工処理
            //-------------------------------------------------------------
            //A、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //B、各ドロップダウンリストを取得
            res = Wraper.GetVM(db, jigyocd);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑧費用助成一覧画面検索処理
        /// </summary>
        private SearchJyoseiListResponse SearchJyoseiList(DaDbContext db, SearchJyoseiListRequest req)
        {
            var res = new SearchJyoseiListResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、ヘッダー情報を設定（ヘッダー項目は、起動元から編集する。）
            var headerinfo = new JyoseiHeaderInfoVM()
            {
                atenano = req.atenano,                          //宛名番号
                name = GetAtenaName(db, req.atenano),           //氏名
                torokuno = req.torokuno,                        //登録番号
                sinseiymd = Getsinseiymd(db, req),              //申請日
            };
            res.headerinfo = headerinfo;

            //B、費用助成一覧情報を取得
            res.jyoseilist = GetJyoseiListInfo(db, req);

            //C、助成金額（総額）を取得
            var footerinfo = new JyoseiFooterInfoVM()
            {
                joseikingakusogaku = res.jyoseilist.Select(e => e.joseikingaku).Sum()
            };
            res.footerinfo = footerinfo;

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑨保存処理(費用助成一覧)
        /// </summary>
        private CommonResponse SaveJyosei(DaDbContext db, SaveJyoseiRequest req)
        {
            var res = new CommonResponse();

            //１、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //-------------------------------------------------------------
            //２.親画面のキー情報でサブテーブルを全件削除
            //-------------------------------------------------------------
            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診結果-妊婦健診結果と妊産婦歯科健診結果の場合
                //妊婦健診費用助成（固定）サブテーブル
                db.tt_bhnsninpukensinhiyojosei_sub.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.sinseiedano).Execute();
            }
            else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診結果-産婦健診結果の場合
                //産婦健診費用助成（固定）サブテーブル
                db.tt_bhnssanpukensinhiyojosei_sub.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.sinseiedano).Execute();
            }

            //-------------------------------------------------------------
            //３.妊産婦（フリー項目）テーブルへ登録
            //-------------------------------------------------------------
            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診結果-妊婦健診結果と妊産婦歯科健診結果の場合
                //妊婦健診費用助成（固定）サブテーブル
                var newdtl = new List<tt_bhnsninpukensinhiyojosei_subDto>();
                newdtl = Converter.GetDtl(newdtl, req, jigyocd);
                db.tt_bhnsninpukensinhiyojosei_sub.INSERT.Execute(newdtl);
            }
            else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診結果-産婦健診結果の場合
                //産婦健診費用助成（固定）サブテーブル
                var newdtl = new List<tt_bhnssanpukensinhiyojosei_subDto>();
                newdtl = Converter.GetDtl(newdtl, req);
                db.tt_bhnssanpukensinhiyojosei_sub.INSERT.Execute(newdtl);
            }

            //-------------------------------------------------------------
            //３.妊産婦（フリー項目）テーブルへ登録
            //-------------------------------------------------------------
            //助成金額（総額）フリー項目コードを取得
            var keyitemcd = GetKeyItemCd(db, AWBH00301G.母子種類._1, jigyocd, JOSEIKINGAKUSOGAKUITEMNM);

            //妊産婦（フリー）項目テーブル（フリーテーブル）
            var newfreedtl = Converter.GetDtl(req, jigyocd, keyitemcd);

            if (db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, 0, req.sinseiedano, 0, keyitemcd).Exists())
            {
                //存在する場合
                //妊産婦（フリー）項目テーブルの助成金額（総額）フリー項目を更新
                db.tt_bhnsfree.UPDATE.Execute(newfreedtl);
            } else
            {
                //存在しない場合
                //妊産婦（フリー）項目テーブルの助成金額（総額）フリー項目を追加
                db.tt_bhnsfree.INSERT.Execute(newfreedtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑩削除処理(費用助成一覧)
        /// </summary>
        private CommonResponse DeleteJyosei(DaDbContext db, DeleteJyoseiRequest req)
        {
            var res = new CommonResponse();

            //１、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //-------------------------------------------------------------
            //２.親画面のキー情報でサブテーブルを全件削除
            //-------------------------------------------------------------
            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診費用助成（固定）サブテーブル
                db.tt_bhnsninpukensinhiyojosei_sub.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.sinseiedano).Execute();
            }
            else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診費用助成（固定）サブテーブル
                db.tt_bhnssanpukensinhiyojosei_sub.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.sinseiedano).Execute();
            }

            //-------------------------------------------------------------
            //３.妊産婦（フリー項目）テーブルの助成金額（総額）項目を削除
            //-------------------------------------------------------------
            //助成金額（総額）フリー項目コードを取得
            var keyitemcd = GetKeyItemCd(db, AWBH00301G.母子種類._1, jigyocd, JOSEIKINGAKUSOGAKUITEMNM);

            //妊産婦（フリー）項目テーブルの助成金額（総額）フリー項目を削除
            db.tt_bhnsfree.DELETE.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                 $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                 $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                 $"{nameof(tt_bhnsfreeDto.edano)}=@edano and " +
                                                 $"{nameof(tt_bhnsfreeDto.itemcd)}=@itemcd"
                                                 , jigyocd, req.atenano, req.torokuno, req.sinseiedano, keyitemcd).Execute();

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
         /// <summary>
        ///費用助成一覧情報を取得
        /// </summary>
        private static List<JyoseiListInfoVM> GetJyoseiListInfo(DaDbContext db, SearchJyoseiListRequest req)
        {
            var jyoseilistinfovm = new List<JyoseiListInfoVM>();

            //１、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            switch (jigyocd)
            {
                case JIGYO_00006:            // 妊婦健診結果
                    var dtl1 = db.tt_bhnsninpukensinhiyojosei_sub.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.sinseiedano).GetDtoList().OrderBy(e => e.edano);
                    jyoseilistinfovm = Wraper.GetJyoseiListInfoVMList(db, jigyocd, dtl1!);
                    break;

                case JIGYO_00032:            // 妊産婦歯科健診結果
                    var dtl2 = db.tt_bhnsninpukensinhiyojosei_sub.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.sinseiedano).GetDtoList().OrderBy(e => e.edano);
                    jyoseilistinfovm = Wraper.GetJyoseiListInfoVMList(db, jigyocd, dtl2!);
                    break;

                case JIGYO_00011:            // 産婦健診結果
                    var dtl = db.tt_bhnssanpukensinhiyojosei_sub.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.sinseiedano).GetDtoList().OrderBy(e => e.edano);
                    jyoseilistinfovm = Wraper.GetJyoseiListInfoVMList(db, dtl!);
                    break;
            }

            return jyoseilistinfovm;
        }

        /// <summary>
        ///宛名番号から氏名を取得する
        /// </summary>
        public static string GetAtenaName(DaDbContext db, string atenano)
        {
            var dto = db.tt_afatena.GetDtoByKey(atenano);
            if (dto == null) { return string.Empty; }
            return dto.simei;
        }

        /// <summary>
        ///宛名番号、登録番号、申請枝番から申請日を取得する
        /// </summary>
        private static string Getsinseiymd(DaDbContext db, SearchJyoseiListRequest req)
        {
            //母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診費用助成（固定）テーブル
                var dto = db.tt_bhnsninpukensinhiyojosei.GetDtoByKey(jigyocd, req.atenano, req.torokuno, req.sinseiedano);
                if (dto == null) { return string.Empty; }
                return FormatWaKjYMD(dto.sinseiymd);
            } else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診費用助成（固定）テーブル
                var dto = db.tt_bhnssanpukensinhiyojosei.GetDtoByKey(req.atenano, req.torokuno, req.sinseiedano);
                if (dto == null) { return string.Empty; }
                return FormatWaKjYMD(dto.sinseiymd);
            }
            return string.Empty;
        }

        /// <summary>
        ///宛名番号、登録番号、申請枝番から申請日を取得する
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, Enumマスタ区分 kbn2, bool hasStopFlg = false, params string[] keys)
        {
            string maincd;
            string subcd;
            if (keys.Length == 1)
            {
                maincd = (CLng(keys[0]) / DaNameService.MAINCODE_DIGIT).ToString();
                subcd = (CLng(keys[0]) % DaNameService.MAINCODE_DIGIT).ToString();
            }
            else if (keys.Length == 2)
            {
                maincd = keys[0];
                subcd = keys[1];
            }
            else
            {
                throw new Exception("params count error");
            }
            string name = nameof(tm_afhanyoDto.hanyokbn2);

            var where = @$"{nameof(tm_afhanyoDto.hanyomaincd)}='{maincd}' and 
                           {nameof(tm_afhanyoDto.hanyosubcd)}='{subcd}'
                           {GetStopFlgWhereSql(hasStopFlg, nameof(tm_afhanyoDto.stopflg))}";

            var order = @$" {nameof(tm_afhanyoDto.orderseq)} , {nameof(tm_afhanyoDto.hanyocd)}";

            string sql = GetSelectSQL(tm_afhanyoDto.TABLE_NAME, nameof(tm_afhanyoDto.hanyocd), name, where, order);

            return db.Session.Query<DaSelectorModel>(sql);
        }

        private static string GetSelectSQL(string table, string cd, string name, string where = "", string orderby = "")
        {
            string order = string.IsNullOrEmpty(orderby) ? cd : orderby;
            if (string.IsNullOrEmpty(where))
            {
                return $"select {cd} {nameof(DaSelectorModel.value)}, {name} {nameof(DaSelectorModel.label)} from {table} order by {order}";
            }
            else
            {
                return $"select {cd} {nameof(DaSelectorModel.value)}, {name} {nameof(DaSelectorModel.label)} from {table} where {where} order by {order}";
            }
        }

        /// <summary>
        /// 使用停止sql
        /// </summary>
        private static string GetStopFlgWhereSql(bool hasStopFlg, string flgNm, string? tbId = null)
        {
            var where = string.Empty;
            if (!hasStopFlg)
            {
                var tbIdSql = string.IsNullOrEmpty(tbId) ? string.Empty : $"{tbId}.";
                where = $" and {tbIdSql}{flgNm} = false";
            }
            return where;
        }

        /// <summary>
        ///検索項目のフリー項目コードを取得（助成金額（総額））
        /// </summary>
        public static string GetKeyItemCd(DaDbContext db, string bosikbn, string jigyocd, string keyitemnm)
        {
            var itemcd = string.Empty;
            var itemnm = $"%{keyitemnm}";

            var notifidto = db.tm_bhkkfreeitem.SELECT.WHERE.ByFilter($"({nameof(tm_bhkkfreeitemDto.bosikbn)}=@bosikbn) and " +
                                                                     $"{nameof(tm_bhkkfreeitemDto.jigyocd)}=@jigyocd and " +
                                                                     $"{nameof(tm_bhkkfreeitemDto.itemnm)} LIKE @itemnm"
                                                                     , bosikbn, jigyocd, itemnm).GetDtoList()
                                                           .OrderBy(e => e.orderseq).FirstOrDefault();
            if (notifidto != null) { itemcd = notifidto.itemcd; }

            return itemcd;
        }
    }
}