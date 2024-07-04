// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.CheckImporter;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00701G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 汎用取込設定情報一覧
        /// </summary>
        public static List<KimpRowVM> GetKimpVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<KimpRowVM>();
            foreach (DataRow row in rows)
            {
                var vm = new KimpRowVM();
                vm.impno = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokuno));                                                    //一括取込入力No
                vm.impnm = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokunm));                                                    //一括取込入力名
                vm.impkbn = DaNameService.GetName(db, EnumNmKbn.取込区分, row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokbn)));     //一括取込入力区分
                vm.gyoumukbn = DaNameService.GetName(db, EnumNmKbn.取込業務区分, row.Wrap(nameof(tm_kktorinyuryokuDto.gyomukbn)));   //業務
                vm.memo = row.Wrap(nameof(tm_kktorinyuryokuDto.comment));                                                            //説明
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 未処理一覧
        /// </summary>
        public static List<KimpDataRowVM> GetKimpDataVMList(DaDbContext db, DataRowCollection rows, SearchKimpDataListResponse res)
        {
            var vmList = new List<KimpDataRowVM>();

            foreach (DataRow row in rows)
            {
                var vm = new KimpDataRowVM();

                vm.impexeid = row.CInt(nameof(tt_kktorinyuryoku_misyoriDto.impjikkoid));                                              //取込実行ID
                vm.impno = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokuno));                                                     //一括取込入力No
                vm.impnm = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokunm));                                                     //一括取込入力名
                vm.gyoumukbn = DaNameService.GetName(db, EnumNmKbn.取込業務区分, row.Wrap(nameof(tm_kktorinyuryokuDto.gyomukbn)));    //業務
                vm.filename = row.Wrap(nameof(tt_kktorinyuryoku_misyoriDto.filenm));                                                  //ファイル名
                vm.totalcnt = row.CInt(nameof(tt_kktorinyuryoku_misyoriDto.totalcnt));                                                //件数
                vm.errcnt = row.CInt(nameof(tt_kktorinyuryoku_misyoriDto.errcnt));                                                    //エラー件数
                vm.upduserid = row.Wrap(nameof(tt_kktorinyuryoku_misyoriDto.upduserid));                                              //更新ユーザーID(前回更新者)
                vm.upddttm = row.CDate(nameof(tt_kktorinyuryoku_misyoriDto.upddttm));                                                 //更新日時(前回更新時間)Lock用
                vm.upddttmShow = FormatWaKjDttm(row.CDate(nameof(tt_kktorinyuryoku_misyoriDto.upddttm)));                             //更新日時(前回更新時間)

                vmList.Add(vm);

            }
            return vmList;
        }

        /// <summary>
        /// 取込履歴一覧(一覧画面)
        /// </summary>
        public static List<KimpHistoryRowVM> GetKimpHistoryVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<KimpHistoryRowVM>();
            foreach (DataRow row in rows)
            {
                var vm = new KimpHistoryRowVM();

                vm.rirekiid = row.CInt(nameof(tt_kktorinyuryoku_rirekiDto.imprirekino));                                                  //履歴番号
                vm.regdttm = FormatWaKjDttm(row.CDate(nameof(tt_kktorinyuryoku_rirekiDto.regdttm)));                                      //登録日時(実行日時)
                vm.reguserid = row.Wrap(nameof(tt_kktorinyuryoku_rirekiDto.reguserid));                                                   //登録ユーザーID(担当者)
                vm.gyoumukbn = DaNameService.GetName(db, EnumNmKbn.取込業務区分, row.Wrap(nameof(tt_kktorinyuryoku_rirekiDto.gyomukbn))); //業務
                vm.impnm = row.Wrap(nameof(tt_kktorinyuryoku_rirekiDto.torinyuryokunm));                                                  //一括取込入力名
                vm.impkbn = DaNameService.GetName(db, EnumNmKbn.取込区分, row.Wrap(nameof(tt_kktorinyuryoku_rirekiDto.torinyuryokbn)));   //一括取込入力区分
                vm.filename = row.Wrap(nameof(tt_kktorinyuryoku_rirekiDto.filenm));                                                       //ファイル名
                vm.regcnt = row.CInt(nameof(tt_kktorinyuryoku_rirekiDto.torokucnt));                                                      //登録件数(処理件数)
                vm.errcnt = row.CInt(nameof(tt_kktorinyuryoku_rirekiDto.errcnt));                                                         //エラー件数

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 画面項目リスト(編集画面)
        /// </summary>
        public static List<KimpDetailRowVM> GetKimpDetailRowVMList(int impexeid, List<tt_kktorinyuryoku_misyoriitemDto> kkimpdatadetailDtl, List<tt_kktorinyuryoku_errDto>? kkimpdataerrDtl)
        {
            var vmList = new List<KimpDetailRowVM>();

            kkimpdatadetailDtl = kkimpdatadetailDtl.OrderBy(e => e.rowno).ThenBy(e => e.dataseq).ToList();
            var oldRowNo = 0;
            var vm = new KimpDetailRowVM();
            var errList = new List<tt_kktorinyuryoku_errDto>();
            foreach (var dto in kkimpdatadetailDtl)
            {
                if (oldRowNo != 0 && oldRowNo != dto.rowno)
                {
                    vmList.Add(vm);
                }

                if (oldRowNo == 0 || oldRowNo != dto.rowno)
                {
                    vm = new KimpDetailRowVM();
                    vm.impexeid = impexeid;     //取込実行ID
                    vm.rowno = dto.rowno;       //行番号
                    vm.PageItemBodyList = new List<PageItemBodyModel>();
                    errList = new List<tt_kktorinyuryoku_errDto>();
                    if (kkimpdataerrDtl != null)
                    {
                        errList = kkimpdataerrDtl.Where(e => e.rowno == dto.rowno).ToList();
                    }
                    //エラー内容
                    vm.errMsg = errList.Count == 0 ? "エラーなし" : "エラー表示";
                }

                var model = new PageItemBodyModel
                {
                    dataseq = dto.dataseq,                          //データID
                    val = dto.itemvalue,                            //項目値
                    pageitemseq = dto.itemseq,                      //項目ID
                    errkbn = GetErrKbn(errList, dto.dataseq)        //エラー区分
                };
                //エラーフラグ
                model.errflg = !model.errkbn.Equals(EnumToStr(Enumエラーレベル.無視));

                //画面項目リスト
                vm.PageItemBodyList.Add(model);

                oldRowNo = dto.rowno;
            }

            vmList.Add(vm);

            return vmList;
        }

        /// <summary>
        /// エラー区分を取得
        /// </summary>
        private static string GetErrKbn(List<tt_kktorinyuryoku_errDto> errList, int dataseq)
        {
            //エラー区分
            var errkbn = Enumエラーレベル.無視;

            //エラー件
            var errkbnList = errList.FindAll(e => e.dataseq == dataseq && e.errkbn.Equals(EnumToStr(Enumエラーレベル.エラー)));
            if (errkbnList != null && errkbnList.Count > 0)
            {
                //エラー区分
                errkbn = Enumエラーレベル.エラー;
            }
            else
            {
                //警告件
                errkbnList = errList.FindAll(e => e.dataseq == dataseq && e.errkbn.Equals(EnumToStr(Enumエラーレベル.警告)));
                if (errkbnList != null && errkbnList.Count > 0)
                {
                    //エラー区分
                    errkbn = Enumエラーレベル.警告;
                }
                else
                {
                    //情報件
                    errkbnList = errList.FindAll(e => e.dataseq == dataseq && e.errkbn.Equals(EnumToStr(Enumエラーレベル.情報)));
                    if (errkbnList != null && errkbnList.Count > 0)
                    {
                        //エラー区分
                        errkbn = Enumエラーレベル.情報;
                    }
                }
            }
            return EnumToStr(errkbn);
        }

        /// <summary>
        /// 画面項目ヘッダーデータを取得する
        /// </summary>
        public static List<PageItemHeaderModel> GetPageItemHeaderVMList(DaDbContext db, List<tm_kktorinyuryoku_itemDto> dtl)
        {
            var vmList = new List<PageItemHeaderModel>();
            int colCnt = dtl.Count;
            foreach (tm_kktorinyuryoku_itemDto dto in dtl)
            {
                var vm = new PageItemHeaderModel();
	
                vm.pageitemseq = dto.gamenitemseq;          //画面項目ID	
                vm.itemnm = dto.itemnm;                     //項目名	
                vm.wktablecolnm = dto.wktablecolnm;         //ワークテーブルカラム名	
                vm.inputkbn = dto.inputkbn;                 //入力区分	
                vm.inputtype = dto.inputhoho;               //入力方法	
                vm.hikisu = dto.hikisu;                     //引数	
                vm.len = dto.ketasu;                        //桁数	
                vm.len2 = dto.syosuketasu;                  //桁数（小数部）	
                vm.width = dto.width;                       //幅	
                vm.format = dto.format;                     //フォーマット	
                vm.requiredflg = dto.hissuflg;              //必須フラグ	
                vm.uniqueflg = dto.itiiflg;                 //一意フラグ	
                vm.dispinputkbn = dto.hyojiinputkbn;        //表示入力設定区分	
                vm.sortno = dto.orderseq;                   //並び順	
                vm.fromitemseq = dto.sansyomotoseq;         //参照元項目ID	
                vm.fromfieldid = dto.sansyomotofield;       //参照元フィールド	
                vm.targetfieldid = dto.syutokusakifield;    //取得先フィールド	
                vm.nendoflg = dto.nendoflg;                 //年度フラグ
                vm.yearchkflg = dto.nendocheck;             //年度チェック	
                vm.seiki = dto.seikihyogen;                 //正規表現	
                vm.minval = dto.minvalue;                   //最小値	
                vm.maxval = dto.maxvalue;                   //最大値	
                vm.defaultval = dto.syokiti;                //初期値	
                vm.fixedval = dto.koteiti;                  //固定値	
                vm.msttable = dto.masterchecktable;         //マスタチェックテーブル	
                vm.mstjyoken = dto.mastercheckjoken;        //マスタチェック条件	
                vm.mstfield = dto.mastercheckitem;          //マスタチェック項目	
                vm.jherrlelkbn = dto.jokenhissuerrorkbn;    //条件必須エラーレベル区分	
                vm.jhitemseq = dto.jokenhissuitemseq;       //条件必須項目ID	
                vm.jhenzan = dto.jokenhissuenzansi;         //条件必須演算子	
                vm.jhval = dto.jokenhissuvalue;             //条件必須値	
                vm.jigyocd = dto.jigyocd;                   //医療機関・事業従事者（担当者）事業コード

                //該当画面項目は参照元項目IDにする場合
                var fromitemseqList = dtl.Where(e => e.sansyomotoseq == dto.gamenitemseq).Select(e => e.gamenitemseq).ToList();
                if (fromitemseqList.Count > 0)
                {
                    //参照先項目ID
                    vm.targetitemseq = string.Join(",", fromitemseqList);
                }
                else
                {
                    //参照先項目ID
                    vm.targetitemseq = string.Empty;
                }
                vm.itemkbn = dto.itemtokuteikbn;            //項目特定区分
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 取込画面項目情報リストを取得する
        /// </summary>
        public static List<ImEditorColumnDef> GetImEditorColmunDefList(List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl, List<tm_kktorinyuryoku_torokuDto> insertdetailDtl)
        {
            var items = new List<ImEditorColumnDef>();
            foreach (var dto in kkimppageitemDtl)
            {
                var model = new ImEditorColumnDef();
                model.pageitemseq = dto.gamenitemseq;           //画面項目ID	
                model.itemnm = dto.itemnm;                      //項目名	
                model.inputkbn = dto.inputkbn;                  //入力区分	
                model.inputtype = dto.inputhoho;                //入力方法	
                model.len = dto.ketasu;                         //桁数	
                model.len2 = dto.syosuketasu;                   //桁数（小数部）	
                model.format = dto.format;                      //フォーマット	
                model.requiredflg = dto.hissuflg;               //必須フラグ	
                model.uniqueflg = dto.itiiflg;                  //一意フラグ	
                model.dispinputkbn = dto.hyojiinputkbn;         //表示入力設定区分	
                model.fromitemseq = dto.sansyomotoseq;          //参照元項目ID	
                model.fromfieldid = dto.sansyomotofield;        //参照元フィールド	
                model.targetfieldid = dto.syutokusakifield;     //取得先フィールド	
                model.nendoflg = dto.nendoflg;                  //年度フラグ
                model.yearchkflg = dto.nendocheck;              //年度チェック	
                model.seiki = dto.seikihyogen;                  //正規表現	
                model.minval = dto.minvalue;                    //最小値	
                model.maxval = dto.maxvalue;                    //最大値	
                model.defaultval = dto.syokiti;                 //初期値	
                model.fixedval = dto.koteiti;                   //固定値	
                model.msttable = dto.masterchecktable;          //マスタチェックテーブル	
                model.mstjyoken = dto.mastercheckjoken;         //マスタチェック条件	
                model.mstfield = dto.mastercheckitem;           //マスタチェック項目	
                model.jherrlelkbn = dto.jokenhissuerrorkbn;     //条件必須エラーレベル区分	
                model.jhitemseq = dto.jokenhissuitemseq;        //条件必須項目ID	
                model.jhenzan = dto.jokenhissuenzansi;          //条件必須演算子	
                model.jhval = dto.jokenhissuvalue;              //条件必須値	
                model.itemkbn = dto.itemtokuteikbn;             //項目特定区分

                int pageitemseq = dto.gamenitemseq;
                //データテーブル列名
                model.ColumnName = "Column" + pageitemseq;
                //テーブル,フィールド
                model.TableFieldList = insertdetailDtl.Where(x => x.datamotoitemseq == pageitemseq).Select(e => e.tableid + "," + e.fieldnm).ToList();
                items.Add(model);
            }

            return items;
        }

        /// <summary>
        /// 項目登録移送データを取得する（チェック用）
        /// </summary>
        public static List<ImInsertDetailDef> GetInsertDetailData(List<tm_kktorinyuryoku_torokuDto> insertdetailDtl)
        {
            var tables = new List<ImInsertDetailDef>();

            foreach (var dto in insertdetailDtl)
            {
                var imInsertDetailDef = new ImInsertDetailDef();
                imInsertDetailDef.Tableid = dto.tableid;    //テーブルid
                imInsertDetailDef.FieldId = dto.fieldnm;    //フィールドid
                imInsertDetailDef.Syorikbn = dto.syorikbn;  //処理区分
                imInsertDetailDef.ColumnName = "Column" + CStr(dto.datamotoitemseq);//データテーブル列名(データ元画面項目)
                imInsertDetailDef.Koteiti = dto.koteiti;    //固定値

                //項目登録移送データ
                tables.Add(imInsertDetailDef);
            }

            return tables;
        }
    }
}
