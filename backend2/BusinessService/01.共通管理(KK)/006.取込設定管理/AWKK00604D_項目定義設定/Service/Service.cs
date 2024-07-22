// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.画面項目情報ダイアログ画面
// 　　　　　　サービス処理
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.CheckImporter;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00604D
{
    [DisplayName("取込設定：画面項目情報ダイアログ画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00604D = "AWKK00604D";

        [DisplayName("初期化処理(取込設定：画面項目情報ダイアログ画面)")]
        public InitResponse InitDetail(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                var mainService = new AWKK00601G.Service();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //ドロップダウンリストの初期化データ
                //【入力区分】のドロップダウンリスト
                res.inputkbnList = mainService.GetNameSelectorList(db, EnumNmKbn.入力区分);

                //【フォーマット】のドロップダウンリスト
                res.formatList = mainService.GetNameSelectorList(db, EnumNmKbn.フォーマット_画面定義);
                //【必須】のドロップダウンリスト
                res.requiredflgList = mainService.GetNameSelectorList(db, EnumNmKbn.エラーレベル);
                //【年度チェック】のドロップダウンリスト
                res.yearchkflgList = mainService.GetNameSelectorList(db, EnumNmKbn.エラーレベル);
                //【表示入力設定】のドロップダウンリスト
                res.dispinputkbnList = mainService.GetNameSelectorList(db, EnumNmKbn.表示入力設定);

                //【マスタチェックテーブル】のドロップダウンリスト
                res.msttableList = GetTableListVM(db, nameof(tm_kktorinyuryoku_tableDto.sonzaicheckflg), true);

                //画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットするリストを取得する
                var pageitemList = GetPageItemList(req.pageitemseq, req.pageitemList);
                //【参照元項目】のドロップダウンリスト
                res.fromitemseqList = pageitemList;

                //変更の場合
                if (!string.IsNullOrEmpty(req.inputkbn))
                {
                    //【入力区分】が○○マスタ参照の場合
                    if (req.inputkbn == EnumToStr(Enum入力区分.マスタ参照))
                    {
                        //【入力方法】が○○マスタ参照にするのドロップダウンリスト
                        res.inputtypeList = GetTableListVM(db, nameof(tm_kktorinyuryoku_tableDto.sansyoflg), true);

                        //【入力方法】のテーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
                        var searchFieldIDList = GetFieldIDList(db, req.inputtype);
                        //【参照元フィールド】のドロップダウンリスト
                        res.fromfieldidList = searchFieldIDList;
                        //【取得先フィールド】のドロップダウンリスト
                        res.targetfieldidList = searchFieldIDList;
                    }
                    else
                    {
                        //入力方法
                        res.inputtypeList = GetInputTypeMethodList(db, req.inputkbn);
                    }
                }

                if (!string.IsNullOrEmpty(req.msttable))
                {
                    //【マスタチェックテーブル】のテーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
                    var checkFieldIDList = GetFieldIDList(db, req.msttable);
                    //【マスタチェック項目】のドロップダウンリスト
                    res.mstfieldList = checkFieldIDList;
                }

                //【条件必須エラーレベル区分】のドロップダウンリスト
                res.jherrlelkbnList = mainService.GetNameSelectorList(db, EnumNmKbn.エラーレベル);
                //【条件必須項目】のドロップダウンリスト
                res.jhitemseqList = pageitemList;
                //【条件必須演算子】のドロップダウンリスト
                res.jhenzanList = mainService.GetNameSelectorList(db, EnumNmKbn.演算子).OrderBy(o => CInt(o.value)).ToList();
                //【項目特定区分】のドロップダウンリスト
                res.itemkbnList = mainService.GetNameSelectorList(db, EnumNmKbn.項目特定区分).OrderBy(o => CInt(o.value)).ToList();
                //【事業コード】のドロップダウンリスト
                res.jigyocdList = GetaJigyocdList(db);
                //【引数区分】のドロップダウンリスト(todo)
                res.hikisukbnList = mainService.GetNameSelectorList(db, EnumNmKbn.引数区分_項目定義);

                //正常返し
                return res;
            });
        }

        [DisplayName("【入力方法】ドロップダウン初期化処理")]
        public InitInputTypeResponse InitInputType(InitInputTypeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitInputTypeResponse();
                //【入力区分】が○○マスタ参照の場合
                if (req.inputkbn == EnumToStr(Enum入力区分.マスタ参照))
                {
                    //【入力方法】が○○マスタ参照にするのドロップダウンリスト
                    res.inputtypeList = GetTableListVM(db, nameof(tm_kktorinyuryoku_tableDto.sansyoflg), true);
                }
                else
                {
                    //入力方法
                    res.inputtypeList = GetInputTypeMethodList(db, req.inputkbn);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("フィールドドロップダウン初期化処理")]
        public InitFieldidResponse InitFieldid(InitFieldidRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitFieldidResponse();
                //テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
                var fieldIDList = GetFieldIDList(db, req.tableid);
                //フィールドのドロップダウンリスト
                res.fieldidList = fieldIDList;

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetFieldIDList(DaDbContext db, string tableid)
        {
            //一括取込入力テーブル項目マスタ
            var tablefieldList = ImDBUtil.GetFieldList(db, tableid);

            var list = new List<DaSelectorModel>();
            foreach (var field in tablefieldList)
            {
                //テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットする
                var vm = new DaSelectorModel(field.FieldName, field.FieldComment);

                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// テーブルのドロップダウンリストを取得する(【入力方法】:【マスタチェックテーブル】)
        /// </summary>
        private List<DaSelectorKeyModel> GetTableListVM(DaDbContext db, string itemName, object value)
        {
            var vmList = new List<DaSelectorKeyModel>();
            //一括取込入力テーブルマスタ
            List<tm_kktorinyuryoku_tableDto> dtl = db.tm_kktorinyuryoku_table.SELECT.WHERE.ByItem(itemName, value).ORDER.By(nameof(tm_kktorinyuryoku_tableDto.orderseq)).GetDtoList();
            foreach (var tmdto in dtl)
            {
                //一括取込入力テーブルマスタ情報からドロップダウンモデルにセットする
                var vm = new DaSelectorKeyModel(tmdto.tablenm.ToString(), tmdto.tableronrinm, "");

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 【入力方法】のドロップダウンリストを取得する（入力区分が1、3、5、6の場合）
        /// </summary>
        private List<DaSelectorKeyModel> GetInputTypeMethodList(DaDbContext db, string inputkbn)
        {
            //入力区分より入力方法のドロップダウンリスト
            var list = DaNameService.GetNameList(db, EnumNmKbn.入力方法).Where(x => x.hanyokbn1 == inputkbn).Select(d => new DaSelectorKeyModel(d.nmcd, d.nm, d.hanyokbn2)).OrderBy(o => CInt(o.value)).ToList();
            return list;
        }

        /// <summary>
        /// 画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットするリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetPageItemList(int pageitemseq, List<string> pageItemList)
        {
            var list = new List<DaSelectorModel>();
            if (pageItemList != null)
            {
                foreach (string obj in pageItemList)
                {
                    var item = obj.Split(',');
                    if (item != null && item.Length == 2 && !pageitemseq.ToString().Equals(item[0].ToString()))
                    {
                        //画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットする
                        var model = new DaSelectorModel(item[0].ToString(), item[1].ToString());
                        list.Add(model);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 【実施事業】のドロップダウンリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetaJigyocdList(DaDbContext db)
        {
            //事業コードリスト
            var jigyocdList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード)).OrderBy(o => CInt(o.value)).ToList();

            return jigyocdList;
        }
    }
}