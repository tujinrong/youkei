// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票管理(一覧)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWAF00802G;
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00201G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索処理(一覧画面)
        /// </summary>
        public static List<SearchVM> GetSearchVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(x => GetSearchVM(db, x)).ToList();
        }

        /// <summary>
        /// 検索処理(一覧画面)
        /// </summary>
        private static SearchVM GetSearchVM(DaDbContext db, DataRow row)
        {
            var vm = new SearchVM();

            var gyomukbn = row.Wrap(nameof(tm_eurptgroupDto.gyomukbn));
            vm.gyoumu = DaNameService.GetName(db, EnumNmKbn.EUC業務区分, gyomukbn); //業務
            vm.rptgroupnm = row.Wrap(nameof(SearchVM.rptgroupnm));                  //帳票グループ名
            vm.rptid = row.Wrap(nameof(SearchVM.rptid));                            //帳票ID
            vm.rptnm = row.Wrap(nameof(SearchVM.rptnm));                            //帳票名
            vm.yosikiideda = row.Wrap(nameof(SearchVM.yosikiideda));                //様式id-枝番
            vm.yosikidenm = row.Wrap(nameof(SearchVM.yosikidenm));                  //様式名-サブ様式名
            vm.yosikiid = row.Wrap(nameof(SearchVM.yosikiid));                      //様式ID
            vm.yosikieda = row.CInt(nameof(SearchVM.yosikieda));                    //様式枝番
            vm.yosikinm = row.Wrap(nameof(SearchVM.yosikinm));                      //様式名
            vm.kbn = row.Wrap(nameof(SearchVM.kbn));                                //様式分類
            vm.yosikisyubetu = row.Wrap(nameof(SearchVM.yosikisyubetu));            //様式種別
            vm.yosikikbn = row.Wrap(nameof(SearchVM.yosikikbn));                    //様式種別詳細
            vm.datasourcenm = row.Wrap(nameof(SearchVM.datasourcenm));              //データソース名称

            return vm;
        }

        /// <summary>
        /// 帳票設定情報を取得
        /// </summary>
        public static ReportTabInfoVM GetReportItemInfo(DaDbContext db,tm_eurptDto kekka, tm_eurptgroupDto? rptgroup)
        {
            var vm = new ReportTabInfoVM();

            vm.rptbiko = CStr(kekka.rptbiko);                   //帳票説明
            vm.atenaflg = kekka.atenaflg;                       //宛名フラグ
            vm.ninsanpuflg = kekka.ninsanputorokunoflg;                 //妊産婦フラグ
            vm.addresssealflg = kekka.addresssealflg;           //アドレスシール固定様式
            vm.barcodesealflg = kekka.barcodesealflg;           //バーコードシール固定様式
            vm.hagakiflg = kekka.hagakiflg;                     //はがき固定様式
            vm.yosikihimonm = CNStr(kekka.yosikihimonm);        //様式紐付け名
            vm.tyusyutupanelflg = kekka.tyusyutupanelflg;       //抽出パネル表示フラグ
            vm.atenadaityoflg = kekka.atenadaityoflg;           //宛名台帳　固定様式
            vm.kensuhyonenreiflg = kekka.kensuhyonenreiflg;     //件数表(年齢別)固定様式
            vm.kensuhyogyoseikuflg = kekka.kensuhyogyoseikuflg; //件数表(行政区別)固定様式
            vm.orderseq = kekka.orderseq;                       //並びシーケンス
            if (rptgroup != null)
            {
                vm.gyoumu = DaNameService.GetName(db, EnumNmKbn.EUC業務区分, rptgroup.gyomukbn); //業務  
                vm.rptgroupnm = rptgroup.rptgroupnm; // 帳票グループ名
                vm.rptgroupid = rptgroup.rptgroupid; // 帳票グループID
            }
            return vm;
        }

        /// <summary>
        /// 帳票項目リストを取得(新規用)
        /// </summary>
        public static List<ReportItemDetailVM> GetReportItemVMList(IEnumerable<tm_eutableitemDto> datasourceItemDtl)
        {
            return datasourceItemDtl.Select(GetReportItemDetailVM).ToList();
        }

        /// <summary>
        /// 帳票項目を取得(新規用)
        /// </summary>
        private static ReportItemDetailVM GetReportItemDetailVM(tm_eutableitemDto dto)
        {
            var vm = new ReportItemDetailVM();
            vm.yosikiitemid = dto.itemid;       //様式項目ID
            vm.reportitemnm = dto.itemhyojinm;  //帳票項目名称
            vm.csvitemnm = dto.itemhyojinm;     //CSV項目名称
            vm.sqlcolumn = dto.sqlcolumn;       //SQLカラム
            vm.tablealias = dto.tablealias;     //テーブル別名
            vm.orderkbn = Enum並び替え.無し;    //並び替え
            vm.orderseq = null;                 //並びシーケンス
            vm.reportoutputflg = true;          //帳票出力フラグ
            vm.csvoutputflg = true;             //CSV出力フラグ
            vm.headerflg = false;               //ヘッダーフラグ
            vm.kaipageflg = false;              //改ページフラグ
            vm.itemkbn = dto.itemkbn;           //項目区分
            vm.formatkbn = null;                //フォーマット区分
            vm.formatkbn2 = null;               //フォーマット区分2
            vm.formatsyosai = null;             //フォーマット詳細
            vm.height = null;                   //高
            vm.width = null;                    //幅
            vm.offsetx = null;                  //X軸オフセット
            vm.offsety = null;                  //Y軸オフセット
            vm.blankvalue = null;               //白紙表示
            vm.mastercd = dto.mastercd;         //名称マスタコード
            vm.masterpara = dto.masterpara;     //名称マスタパラメータ
            vm.keyvaluepairsjson = null;        //複数のキー・値・ペアjson
            vm.crosskbn = null;                 //todo 集計区分
            vm.syukeihoho = null;               //todo 集計方法
            vm.kbn1 = null;                     //todo 小計区分
            vm.level = null;                    //todo 集計レベル
            vm.daibunrui = dto.daibunrui;       //大分類
            return vm;
        }

        /// <summary>
        /// 帳票項目リストを取得(更新用)
        /// </summary>
        public static List<ReportItemDetailVM> GetReportItemVMList(IEnumerable<tm_eurptitemDto> rptitemDtl, Dictionary<string, string>? itemId2DaiBunruiDict)
        {
            return rptitemDtl.Select(x => GetReportItemDetailVM(x, itemId2DaiBunruiDict)).ToList();
        }

        /// <summary>
        /// 帳票項目情報を取得(更新用)
        /// </summary>
        private static ReportItemDetailVM GetReportItemDetailVM(tm_eurptitemDto dto, Dictionary<string, string>? itemId2DaiBunruiDict)
        {
            //集計区分
            Enum集計区分? crosskbn = TryParseEnum<Enum集計区分>(dto.crosskbn);

            var vm = new ReportItemDetailVM();
            vm.yosikiitemid = dto.yosikiitemid;                             //様式項目ID
            vm.reportitemnm = dto.reportitemnm;                             //帳票項目名称
            vm.csvitemnm = dto.csvitemnm;                                   //CSV項目名称
            vm.sqlcolumn = dto.sqlcolumn ?? string.Empty;                   //SQLカラム
            vm.tablealias = dto.tablealias;                                 //テーブル別名
            vm.orderkbn = dto.orderkbn;                                     //並び替え
            vm.orderkbnseq = dto.orderkbnseq;                               //並び替えシーケンス
            vm.orderseq = dto.orderseq;                                     //並びシーケンス
            vm.reportoutputflg = CBool(dto.reportoutputflg);                //帳票出力フラグ
            vm.csvoutputflg = CBool(dto.csvoutputflg);                      //CSV出力フラグ
            vm.headerflg = CBool(dto.headerflg);                            //ヘッダーフラグ
            vm.kaipageflg = CBool(dto.kaipageflg);                          //改ページフラグ
            vm.itemkbn = dto.itemkbn;                                       //項目区分
            vm.formatkbn = dto.formatkbn;                                   //フォーマット区分
            vm.formatkbn2 = dto.formatkbn2;                                 //フォーマット区分2
            vm.formatsyosai = dto.formatsyosai;                             //フォーマット詳細
            vm.height = dto.height;                                         //高
            vm.width = dto.width;                                           //幅
            vm.offsetx = dto.offsetx;                                       //X軸オフセット
            vm.offsety = dto.offsety;                                       //Y軸オフセット
            vm.blankvalue = dto.blankvalue;                                 //白紙表示
            vm.mastercd = dto.mastercd;                                     //名称マスタコード
            vm.masterpara = dto.masterpara;                                 //名称マスタパラメータ
            vm.keyvaluepairsjson = dto.keyvaluepairsjson;                   //複数のキー・値・ペアjson
            vm.crosskbn = crosskbn;                                         //集計区分
            //vm.syukeihoho = CNStr(dto.syukeihoho);                        //集計方法
            vm.kbn1 = CNStr(dto.kbn1);                                      //小計区分
            vm.level = CNInt(dto.level);                                    //集計レベル
            vm.daibunrui = GetName(itemId2DaiBunruiDict, dto.yosikiitemid); //大分類
            return vm;
        }

        /// <summary>
        /// EUC様式詳細情報をセット
        /// </summary>
        public static void SetYosikiSyosaiInfo(SearchYosikiTabResponse res, tm_euyosikisyosaiDto yosikisyosaiDto)
        {
            res.styleDetailParam.yosikisyubetu = yosikisyosaiDto.yosikisyubetu;           //様式種別 
            res.styleDetailParam.yosikikbn = yosikisyosaiDto.yosikikbn;                   //様式種別詳細
            res.styleDetailParam.yosikihouhou = yosikisyosaiDto.yosikihouhou;             //様式作成方法
            res.styleDetailParam.meisaiflg = yosikisyosaiDto.meisaiflg;                   //明細有無
            res.styleDetailParam.meisaikoteikbn = CStr(yosikisyosaiDto.meisaikoteikbn);   //行（列）固定区分
            res.styleDetailParam.distinctflg = yosikisyosaiDto.distinctflg;               //重複データ排除フラグ
            res.styleDetailParam.nulltozeroflg = yosikisyosaiDto.nulltozeroflg;           //空白値ゼロ出力フラグ
            res.styleDetailParam.yosikisyosaiUpddttm = yosikisyosaiDto.upddttm;           //更新日時
        }

        /// <summary>
        /// EUC様式情報をセット
        /// </summary>
        public static void GetYosikiInfo(SearchYosikiTabResponse res, tm_euyosikiDto yosikiDto, List<tm_afhanyoDto> hanyoDtl)
        {
            res.styleDetailParam.pdfflg = CBool(yosikiDto.pdfflg);                                    //pdf出力形式
            res.styleDetailParam.excelflg = CBool(yosikiDto.excelflg);                                //excel出力形式
            res.styleDetailParam.otherflg = CBool(yosikiDto.otherflg);                                //other出力形式
            res.styleDetailParam.koinnmflg = CBool(yosikiDto.koinnmflg);                              //市区町村印字 公印
            res.styleDetailParam.koinpicflg = CBool(yosikiDto.koinpicflg);                            //電子更新印字公印
            res.styleDetailParam.dairisyaflg = CBool(yosikiDto.dairisyaflg);                          //職務代理者適用公印
            res.styleDetailParam.hakoflg = CBool(yosikiDto.hakoflg);                                  //帳票発行履歴更新フラグ
            res.styleDetailParam.naigaikbn = yosikiDto.naigaikbn;                                     //内外区分
            res.styleDetailParam.toiawasesakicd = CStr(yosikiDto.toiawasesakicd);                     //問い合わせ
            res.styleDetailParam.himozukejyokenid = yosikiDto.himozukejyokenid;                       //様式紐付け条件ID
            res.styleDetailParam.himozukevalue = yosikiDto.himozukevalue;                             //様式紐付け値
            res.styleDetailParam.updatesql = yosikiDto.updatesql;                                     //更新SQL
            res.styleDetailParam.updateflg = yosikiDto.updateflg;                                     //更新フラグ
            res.styleDetailParam.kacd = CNStr(yosikiDto.kacd);                                        //課コード
            res.styleDetailParam.kakaricd = CNStr(yosikiDto.kakaricd);                                //係コード
            res.styleDetailParam.yosikiUpddttm = yosikiDto.upddttm;                                   //様式更新日時
            res.styleDetailParam.orderseq = yosikiDto.orderseq;                                       //並びシーケンス
            var find = hanyoDtl.Find(x => x.hanyocd == yosikiDto.toiawasesakicd);
            res.styleDetailParam.hanyocd = CStr(find?.hanyokbn1);                                     //問い合わせ内容
        }

        /// <summary>
        /// データソースから検索条件情報リストを取得する
        /// </summary>
        public static List<SearchConditionVM> GetDataSourseConditionVmList(DaDbContext db, IEnumerable<tm_eudatasourcekensakuDto> sqljyokenDtl)
        {
            return sqljyokenDtl.Select(x => GetSearchConditionVm(db, x)).ToList();
        }

        /// <summary>
        /// データソースから検索条件情報を取得する
        /// </summary>
        private static SearchConditionVM GetSearchConditionVm(DaDbContext db, tm_eudatasourcekensakuDto dto)
        {
            var vm = new SearchConditionVM();
            vm.jyokenid = dto.jyokenid;                                 //条件ID
            vm.jyokenkbn = EnumToStr(Enum検索条件区分.通常条件);    //検索条件区分
            vm.jyokenlabel = dto.jyokenlabel;                           //ラベル
            vm.controlkbn = dto.controlkbn;                             //種類
            vm.label = dto.jyokenlabel;                                 //ラベル
            vm.itemnm = dto.sqlcolumn;                                  //テーブル別名.項目
            vm.datasourceid = dto.datasourceid;                         //データソースID
            vm.sql = dto.sql;                                           //SQL
            vm.variables = CStr(dto.variables);                         //変数名
            vm.tablealias = dto.tablealias;                             //テーブル名
            vm.mastercd = CStr(dto.mastercd);                           //名称マスタコード
            vm.masterpara = CStr(dto.masterpara);                       //名称マスタパラメータ
            vm.sansyomotosql = CStr(dto.sansyomotosql);                 //参照元SQL
            vm.datatype = (int)dto.datatype;                            //データ型
            vm.nendohanikbn = dto.nendohanikbn;                         //年度範囲区分
            vm.syokiti = dto.syokiti;                                   //初期値
            if (dto.controlkbn is Enumコントロール.年度 && !string.IsNullOrEmpty(dto.nendohanikbn))
            {
                (vm.nendo, vm.nendomax) = CommonUtil.GetNendoAndNendomax(db, dto.nendohanikbn); //年度範囲区分
            }
            if (dto.controlkbn is Enumコントロール.選択 or Enumコントロール.複数選択)
            {
                //選択リスト
                vm.selectlist = CommonUtil.GetSelectorList(db, dto.mastercd, dto.masterpara);
            }
            if (dto.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(dto.aimaikbn))
            {
                vm.aimaikbn = CStr(dto.aimaikbn);                                        //曖昧検索区分
            }
            return vm;
        }

        /// <summary>
        /// データソースから検索条件情報リストを取得する
        /// </summary>
        public static List<SearchConditionVM> GetEurptkensakuConditionVmList(DaDbContext db, IEnumerable<tm_eurptkensakuDto> sqljyokenDtl)
        {
            return sqljyokenDtl.Select(x => GetSearchEurpConditionVm(db, x)).ToList();
        }

        /// <summary>
        /// データソースから検索条件情報を取得する
        /// </summary>
        private static SearchConditionVM GetSearchEurpConditionVm(DaDbContext db, tm_eurptkensakuDto dto)
        {
            var vm = new SearchConditionVM();
            vm.jyokenid = CInt(dto.jyokenid);                                 //条件ID
            vm.jyokenkbn = EnumToStr(Enum検索条件区分.通常条件);                  //検索条件区分
            vm.jyokenlabel = CStr(dto.jyokenlabel);                           //ラベル
            vm.controlkbn = Enum.TryParse<Enumコントロール>(dto.controlkbn?.ToString(), out var ck) ? ck : Enumコントロール.文字入力;  //種類
            vm.label = CStr(dto.jyokenlabel);                                 //ラベル
            vm.itemnm = CStr(dto.sql);                                        //テーブル別名.項目
            vm.datasourceid = CStr(dto.datasourceid);                         //データソースID
            vm.sql = dto.sql;                                                 //SQL
            vm.variables = CStr(dto.variables);                               //変数名
            vm.tablealias = CStr(dto.tablealias);                             //テーブル名
            vm.mastercd = CStr(dto.mastercd);                                 //名称マスタコード
            vm.masterpara = CStr(dto.masterpara);                             //名称マスタパラメータ
            vm.sansyomotosql = CStr(dto.sansyomotosql);                       //参照元SQL
            vm.datatype = CInt(dto.datatype);                                 //データ型
            vm.nendohanikbn = dto.nendohanikbn;
            Enumコントロール enumValue;
            if (Enum.TryParse<Enumコントロール>(dto.controlkbn.ToString(), out enumValue))
            {
                if (enumValue == Enumコントロール.選択)
                {
                    //選択リスト
                    vm.selectlist = CommonUtil.GetSelectorList(db, dto.mastercd, dto.masterpara);
                }
            }

            if (dto.controlkbn == (int)Enumコントロール.文字入力 && !string.IsNullOrEmpty(dto.aimaikbn))
            {
                vm.aimaikbn = CStr(dto.aimaikbn);                                        //曖昧検索区分
            }
            return vm;
        }

        /// <summary>
        /// 帳票検索条件情報リストを取得する
        /// </summary>
        public static List<SearchConditionVM> GetReportCoditionVmList(DaDbContext db, IEnumerable<tm_eurptkensakuDto> sqljyokenDtl)
        {
            return sqljyokenDtl.Select(x => GetReportCoditionVm(db, x)).ToList();
        }

        /// <summary>
        /// 検索条件情報を取得する
        /// </summary>
        public static SearchConditionVM GetReportCoditionVm(DaDbContext db, tm_eurptkensakuDto dto)
        {
            var vm = new SearchConditionVM();

            //SQLがありの場合
            if (!string.IsNullOrEmpty(dto.sql))
            {
                var geIndex = dto.sql.IndexOf(DaStrPool.GE);
                var leIndex = dto.sql.IndexOf(DaStrPool.C_GE);
                var equalIndex = dto.sql.IndexOf(DaStrPool.C_EQ);
                var sqlIndex = 0;
                if (geIndex > 0)
                {
                    sqlIndex = geIndex;
                }
                if (leIndex > 0 )
                {
                    sqlIndex = leIndex;
                }
                if (geIndex < 0 && equalIndex > 0 )
                {
                    sqlIndex = equalIndex;
                }

                // 等号が見つかった場合
                if (sqlIndex > 0)
                {
                    // 等号の前の文字列をインターセプトする
                    var sqlcolumn = dto.sql[..sqlIndex].Trim();
                    var tableItemDto = GetTableItem(db, sqlcolumn);
                    if (tableItemDto != null)
                    {
                        vm.daibunrui = CStr(tableItemDto.daibunrui);    //大分類
                        vm.itemid = tableItemDto.itemid;                //項目ID
                        vm.sqlcolumn = tableItemDto.sqlcolumn;          //SQLカラム
                    }
                }
            }

            vm.jyokenid = CInt(dto.jyokenid);                           //条件ID
            vm.jyokenseq = dto.jyokenseq;                               //条件シーケンス
            vm.jyokenkbn = EnumToStr(Enum検索条件区分.通常条件);            //検索条件区分
            vm.jyokenlabel = CStr(dto.jyokenlabel);                     //ラベル
            vm.controlkbn = (Enumコントロール)dto.controlkbn!;          //コントロール区分
            vm.label = CStr(dto.jyokenlabel);                           //項目名
            vm.datasourceid = CStr(dto.datasourceid);                   //データソースID
            vm.hissuflg = CBool(dto.hissuflg);                          //必須フラグ
            vm.sql = dto.sql;                                           //SQL
            vm.variables = CStr(dto.variables);                         //変数名
            vm.tablealias = CStr(dto.tablealias);                       //テーブル名
            vm.mastercd = CStr(dto.mastercd);                           //名称マスタコード
            vm.masterpara = CStr(dto.masterpara);                       //名称マスタパラメータ
            vm.sansyomotosql = CStr(dto.sansyomotosql);                 //参照元SQL
            vm.nendohanikbn = dto.nendohanikbn;                         //年度範囲区分
            vm.syokiti = dto.syokiti;                                   //初期値
            vm.orderseq = dto.orderseq ?? 0;                            //並び替え
            //TODOi
            //vm.datatype = dto.datatype == null ? null : Enum.IsDefined(typeof(EnumDataType), dto.datatype) ? (int)dto.datatype : null; //データ型  
            vm.datatype = CNInt(dto.datatype);                          //データ型  
            if (dto.controlkbn == (int)Enumコントロール.選択 || dto.controlkbn == (int)Enumコントロール.複数選択)
            {
                //選択リスト
                vm.selectlist = CommonUtil.GetSelectorList(db, dto.mastercd, dto.masterpara);
            }

            if (dto.controlkbn == (int)Enumコントロール.年度)
            {
                vm.nendohanikbn = dto.nendohanikbn;                     //年度範囲区分
            }
            if (dto.controlkbn == (int)Enumコントロール.文字入力 && !string.IsNullOrEmpty(dto.aimaikbn))
            {
                vm.aimaikbn = dto.aimaikbn;                            //曖昧検索区分
            }

            return vm;
        }

        /// <summary>
        /// 新規検索条件情報を取得する
        /// </summary>
        public static List<DaSelectorModel> GetReportAddJokenVm(DaDbContext db, SearchJokenDetailRequest dto)
        {
            //選択リスト
            return CommonUtil.GetSelectorList(db, dto.mastercd, dto.masterpara);
        }
        
        /// <summary>
        /// EUCテーブル項目情報を取得
        /// </summary>
        private static tm_eutableitemDto GetTableItem(DaDbContext db, string sqlcolumn)
        {
            var tableitemDto = DaEucBasicService.GetTableItemDtoBySqlColumn(db, sqlcolumn);
            if (tableitemDto == null)
            {
                tableitemDto = db.tm_eutableitem.GetDtoByKey(sqlcolumn);
            }
            return tableitemDto;
        }

        /// <summary>
        /// SELECT文の解析
        /// </summary>
        public static List<ReportItemDetailVM> GetSqlItemList(IEnumerable<SelectPartItem> selectPartItems, IEnumerable<ReportItemDetailVM> sqlitemlist)
        {
            return selectPartItems.Select(x => GetSqlItem(x, sqlitemlist)).ToList();
        }

        /// <summary>
        /// SELECT文の解析
        /// </summary>
        private static ReportItemDetailVM GetSqlItem(SelectPartItem item, IEnumerable<ReportItemDetailVM> sqlitemlist)
        {
            var first = sqlitemlist.FirstOrDefault(x =>
                x.yosikiitemid.Equals(item.itemId, StringComparison.OrdinalIgnoreCase) && x.sqlcolumn.Equals(item.itemName, StringComparison.OrdinalIgnoreCase));
            var vm = new ReportItemDetailVM();
            vm.yosikiitemid = first?.yosikiitemid ?? item.itemId;       //様式項目ID
            vm.reportitemnm = item.itemComment;                         //帳票項目名称
            vm.csvitemnm = item.itemComment;                            //CSV項目名称
            vm.sqlcolumn = item.itemName;                               //SQLカラム
            vm.tablealias = item.tableId;                               //テーブル別名
            vm.orderkbn = first?.orderkbn ?? Enum並び替え.無し;         //並び替え
            vm.orderseq = first?.orderseq;                              //並びシーケンス
            vm.reportoutputflg = first?.reportoutputflg ?? true;        //帳票出力フラグ
            vm.csvoutputflg = first?.csvoutputflg ?? true;              //CSV出力フラグ
            vm.headerflg = first?.headerflg ?? true;                    //ヘッダーフラグ
            vm.kaipageflg = first?.kaipageflg ?? false;                 //改ページフラグ
            vm.itemkbn = first?.itemkbn ?? Enum出力項目区分.普通項目;   //項目区分
            vm.formatkbn = first?.formatkbn;                            //フォーマット区分
            vm.formatkbn2 = first?.formatkbn2;                          //フォーマット区分2
            vm.formatsyosai = first?.formatsyosai;                      //フォーマット詳細
            vm.height = first?.height;                                  //高
            vm.width = first?.width;                                    //幅
            vm.offsetx = first?.offsetx;                                //X軸オフセット
            vm.offsety = first?.offsety;                                //Y軸オフセット
            vm.blankvalue = first?.blankvalue;                          //白紙表示
            vm.mastercd = first?.mastercd;                              //名称マスタコード
            vm.masterpara = first?.masterpara;                          //名称マスタパラメータ
            vm.keyvaluepairsjson = first?.keyvaluepairsjson;            //複数のキー・値・ペアjson
            vm.crosskbn = first?.crosskbn;                              //集計区分
            vm.syukeihoho = first?.syukeihoho;                          //集計方法
            vm.kbn1 = first?.kbn1;                                      //小計区分
            vm.level = first?.level;                                    //集計レベル
            return vm;
        }

        /// <summary>
        /// SELECT文の解析
        /// </summary>
        public static List<SearchConditionVM> GetSqlConditionList(IEnumerable<WherePartItem> wherePartItems, IEnumerable<SearchConditionVM> sqlconditionlist)
        {
            return wherePartItems.Select(x => GetSqlCondition(x, sqlconditionlist)).ToList();
        }

        /// <summary>
        /// SELECT文の解析
        /// </summary>
        private static SearchConditionVM GetSqlCondition(WherePartItem wherePartItem, IEnumerable<SearchConditionVM> sqlconditionlist)
        {
            //todo ...
            var first = sqlconditionlist.FirstOrDefault(x => wherePartItem.VariableStr.Equals(x.variables));
            var vm = new SearchConditionVM();
            vm.jyokenid = first?.jyokenid ?? 0;                                         //条件ID
            vm.datasourceid = null!;                                                    //データソースID
            vm.hissuflg = true;                                                         //必須フラグ
            vm.jyokenkbn = first?.jyokenkbn ?? ((int)Enum検索条件区分.通常条件).ToString(); //検索条件区分
            vm.tableid = first?.tableid!;                                               //テーブルID
            vm.itemnm = first?.itemnm!;                                                 //項目物理名
            vm.jyokenlabel = first?.label ?? wherePartItem.Comment;                     //項目名  
            vm.controlkbn = first?.controlkbn ?? Enumコントロール.文字入力;             //種類
            vm.sql = first?.sql!;                                                       //SQL
            vm.selectlist = first?.selectlist;                                          //選択リスト
            vm.datatype = first?.datatype ?? (int)EnumDataType.文字列;                  //データタイプ
            vm.variables = first?.variables ?? wherePartItem.VariableStr;               //変数名
            if (first?.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(first?.aimaikbn))
            {
                vm.aimaikbn = CStr(first.aimaikbn);                                     //曖昧検索区分
            }
            return vm;
        }

        /// <summary>
        /// プロシージャの解析
        /// </summary>
        public static List<ReportItemDetailVM> GetFunctionItemList(IEnumerable<FunctionVM.Param> paramList, List<ReportItemDetailVM> itemlist)
        {
            return itemlist.Where(x => paramList.Any(y => y.Name == x.reportitemnm)).ToList();
        }

        /// <summary>
        /// プロシージャの解析
        /// </summary>
        public static List<SearchConditionVM> GetFunctionConditionList(IEnumerable<FunctionVM.Param> paramList, List<SearchConditionVM> conditionlist, DaDbContext db)
        {
            return paramList.Select((x, index) => GetFunctionCondition(x, conditionlist, index, db)).ToList();
        }

        /// <summary>
        /// プロシージャの解析
        /// </summary>
        private static SearchConditionVM GetFunctionCondition(FunctionVM.Param param, IEnumerable<SearchConditionVM> conditionlist,int index, DaDbContext db)
        {
            var first = conditionlist.FirstOrDefault(x =>x!=null && $"{DaStrPool.C_AT}{param.Name}".Equals(x.variables, StringComparison.OrdinalIgnoreCase));

            var vm = new SearchConditionVM();
            vm.jyokenid = first?.jyokenid ?? index + 1;                                 //条件ID
            vm.datasourceid = null!;                                                    //データソースID
            vm.hissuflg = false;                                                        //必須フラグ
            vm.jyokenkbn = first?.jyokenkbn ?? ((int)Enum検索条件区分.通常条件).ToString(); //TODO 検索条件区分
            vm.jyokenlabel = first?.jyokenlabel ?? param.Name;                          //ラベル
            vm.tableid = first?.tableid ?? string.Empty;                                //テーブルID
            vm.variables = $"{DaStrPool.C_AT}{param.Sqlcolumn}";                        //変数名
            vm.daibunrui = string.Empty;                                                //大分類
            vm.itemid = param.Id;                                                       //項目ID
            vm.itemnm = first?.itemnm ?? param.Name;                                    //項目物理名
            vm.label = first?.label ?? param.Name;                                      //項目名
            vm.controlkbn = first?.controlkbn ?? Enumコントロール.文字入力;             //種類
            vm.sql = first?.sql!;                                                       //SQL
            vm.tablealias = first?.tablealias ?? string.Empty;                          //テーブル名
            vm.mastercd = first?.mastercd ?? null;                                      //名称マスタコード
            vm.masterpara = first?.masterpara ?? null;                                  //名称マスタパラメータ
            vm.sansyomotosql = first?.sansyomotosql ?? null;                            //参照元SQL
            vm.nendohanikbn = first ? .nendohanikbn ?? null;                            //年度範囲区分
            if (vm.controlkbn is Enumコントロール.年度 && !string.IsNullOrEmpty(vm.nendohanikbn))
            {
                (vm.nendo, vm.nendomax) = CommonUtil.GetNendoAndNendomax(db, vm.nendohanikbn); //年度範囲区分
            }
            vm.datatype = first?.datatype ?? (param.DataType == null ? (int)EnumDataType.文字列 : (int)param.DataType.Value); //データ型
            vm.jyokenseq = first?.jyokenseq ?? 0;                                       //条件シーケンス
            vm.sqlcolumn = first?.sqlcolumn ?? param.Name;                              //SQLカラム
            vm.selectlist = first?.selectlist;                                          //選択リスト
            vm.aimaikbn = EnumToStr(Enum検索区分.完全検索);
            if (first?.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(first?.aimaikbn))
            {
                vm.aimaikbn = CStr(first.aimaikbn);                                        //曖昧検索区分
            }
            return vm;
        }

        /// <summary>
        /// Enum型へ変換
        /// </summary>
        private static TEnum? TryParseEnum<TEnum>(string? input) where TEnum : struct
        {
            if (string.IsNullOrEmpty(input))
                return null;

            if (Enum.TryParse<TEnum>(input, out var result))
                return result;

            return null;
        }

        /// <summary>
        /// 名称を取得
        /// </summary>
        private static string? GetName(Dictionary<string, string>? dic, string key)
        {
            return dic?.TryGetValue(key, out var value) == true ? value : null;
        }

        // AIplus 2024-06-24 SHOU ADD Start
        /// <summary>
        /// コントロールマスタ
        /// </summary>
        public static List<SearchCtlVM> GetVMList(List<tm_afctrlDto> dtl)
        {
            return dtl.Select(GetVM).ToList();
        }

        /// <summary>
        /// コントロールマスタ
        /// </summary>
        private static SearchCtlVM GetVM(tm_afctrlDto dto)
        {
            var vm = new SearchCtlVM();
            vm.ctrlcd = dto.ctrlcd;      //コントロールコード
            object value = dto.rangeflg ? new ValueVM(dto.value1, dto.value2) : dto.value1!;
            vm.value = value;            //値
            vm.upddttm = dto.upddttm;    //更新日時
            return vm;
        }
        // AIplus 2024-06-24 SHOU ADD End

    }
}