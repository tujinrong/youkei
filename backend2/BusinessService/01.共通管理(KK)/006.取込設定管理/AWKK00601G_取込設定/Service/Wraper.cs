// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.CheckImporter;
using Microsoft.Extensions.Caching.Memory;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00601G
{
    public class Wraper : CmWraperBase
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;
        /// <summary>
        /// キャシュークリア
        /// </summary>
        public static void ClearCache()
        {
            _cache?.Clear();
        }

        /// <summary>
        /// 汎用取込設定情報一覧(一覧画面)
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<RowVM>();
            foreach (DataRow row in rows)
            {
                var impkbn = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokbn));            //一括取込入力区分
                var gyoumukbn = row.Wrap(nameof(tm_kktorinyuryokuDto.gyomukbn));              //業務

                var vm = new RowVM();
                vm.impno = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokuno));             //一括取込入力No
                vm.impnm = row.Wrap(nameof(tm_kktorinyuryokuDto.torinyuryokunm));             //一括取込入力名
                vm.impkbn = DaNameService.GetName(db, EnumNmKbn.取込区分, impkbn);            //一括取込入力区分
                vm.gyoumukbn = DaNameService.GetName(db, EnumNmKbn.取込業務区分, gyoumukbn);  //業務
                vm.memo = row.Wrap(nameof(tm_kktorinyuryokuDto.comment));                     //説明
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// ヘッダー情報を取得する(詳細画面)
        /// </summary>
        public static HeaderVM GetHeaderVM(tm_kktorinyuryokuDto kkimpDto, List<string> tablenmlist)
        {
            var vm = new HeaderVM();
            vm.gyoumukbn = kkimpDto.gyomukbn;           //業務区分
            vm.impno = kkimpDto.torinyuryokuno;         //一括取込入力No
            vm.impnm = kkimpDto.torinyuryokunm;         //一括取込入力名
            vm.impkbn = kkimpDto.torinyuryokbn;         //一括取込入力区分
            vm.yeardispflg = kkimpDto.nendohyojiflg;    //年度表示フラグ
            vm.regupdkbn = kkimpDto.torokukbn;          //登録区分
            vm.nendohanikbn = kkimpDto.nendohanikbn;    //年度範囲区分
            vm.memo = kkimpDto.comment;                 //説明
            vm.procchk = kkimpDto.proccheck;            //チェックプロシージャ名
            vm.procbefore = kkimpDto.procbefore;        //更新前プロシージャ名
            vm.procafter = kkimpDto.procafter;          //更新後プロシージャ名
            vm.orderseq = kkimpDto.orderseq;            //並び順シーケンス

            //テーブル物理名リスト
            vm.tableidList = tablenmlist;
            return vm;
        }

        /// <summary>
        /// 取込ファイル基本情報を取得する(詳細画面)
        /// </summary>
        public static FileInfoVM GetFileInfoVM(tm_kktori_kihonDto dto)
        {
            var vm = new FileInfoVM();
            vm.filetype = dto.filekeisiki;              //ファイル形式
            vm.fileencode = dto.fileencode;             //ファイルエンコード	
            vm.filenmrule = dto.filenm;                 //ファイル名称
            vm.filenmruleflg = dto.seikihyogen;         //正規表現
            vm.datakbn = dto.datakeisiki;               //データ形式	
            vm.recordlen = dto.recordlen;               //レコード長	
            vm.quoteskbn = dto.inyofusonzaikbn;         //引用符存在区分
            vm.dividekbn = dto.kugirikigo;              //区切り記号
            vm.headerrows = dto.headerrows;             //ヘッダー行数
            vm.footerrows = dto.footerrows;             //フッター行数
            return vm;
        }

        /// <summary>
        /// ファイルI/F情報を取得する(詳細画面)
        /// </summary>
        public static List<FileIFVM> GetFileIFVMList(DaDbContext db, List<tm_kktori_interfaceDto> dtl)
        {
            var vmList = new List<FileIFVM>();
            foreach (var dto in dtl)
            {
                var vm = new FileIFVM();
                vm.fileitemseq = dto.fileitemseq;                                               //ファイル項目ID	
                vm.itemnm = dto.itemnm;                                                         //項目名
                vm.keyflg = dto.keyflg;                                                         //キーフラグ
                vm.keyflgName = FormatFlgStr(dto.keyflg);                                       //キーフラグ（名称）
                vm.requiredflg = dto.hissuflg;                                                  //必須フラグ
                vm.requiredflgName = FormatFlgStr(dto.hissuflg);                                //必須フラグ（名称）
                vm.datatype = dto.datatype;                                                     //データ型
                vm.datatypeName = DaNameService.GetName(db, EnumNmKbn.入力方法, dto.datatype);  //データ型（名称）
                vm.len = dto.ketasu;                                                            //桁数
                vm.len2 = dto.syosuketasu;                                                      //桁数（小数部）
                //フォーマット
                vm.format = dto.format;
                if (!string.IsNullOrEmpty(dto.format))
                {
                    //フォーマット（名称）
                    vm.formatName = DaNameService.GetName(db, EnumNmKbn.フォーマット_日付, dto.format);
                }
                //フォーマットチェック
                vm.fmtcheck = dto.formatcheck;
                if (!string.IsNullOrEmpty(dto.formatcheck))
                {
                    //フォーマットチェック（名称）
                    vm.fmtcheckName = DaNameService.GetName(db, EnumNmKbn.フォーマットチェック関数, dto.formatcheck);
                }
                //フォーマット変換
                vm.fmtchange = dto.formathenkan;
                if (!string.IsNullOrEmpty(dto.formathenkan))
                {
                    //フォーマット変換（名称）
                    vm.fmtchangeName = DaNameService.GetName(db, EnumNmKbn.フォーマット変換関数, dto.formathenkan);
                }
                //備考
                vm.memo = dto.biko;
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 変換コードメイン情報を取得する(詳細画面)
        /// </summary>
        public static List<ChangeCodeMainVM> GetChangeCodeMainVMList(List<tm_kktorinyuryoku_henkancode_mainDto> dtl)
        {
            var vmList = new List<ChangeCodeMainVM>();
            foreach (var dto in dtl)
            {
                var vm = new ChangeCodeMainVM();

                vm.codehenkankbn = dto.codehenkankbn;       //コード変換区分
                vm.henkankbnnm = dto.henkankbnnm;           //変換区分名称
                vm.codekanritablenm = dto.codekanritablenm; //コード管理テーブル名
                vm.maincd = dto.maincd;                     //メインコード
                vm.subcd = dto.subcd;                       //サブコード
                vm.sonotajoken = dto.sonotajoken;           //その他条件

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 取込コード変換情報を取得する(詳細画面)
        /// </summary>
        public static List<CodeChangeVM> GetCodeChangeVMList(List<tm_kktori_henkancodeDto> changeCodeDtl)
        {
            //取込コード変換情報リスト
            var vmList = new List<CodeChangeVM>();
            //コード変換区分リスト
            var changeKbnList = changeCodeDtl.Select(e => e.codehenkankbn).Distinct().ToList();
            foreach (var changeKbn in changeKbnList)
            {
                //取込コード変換情報
                var vm = new CodeChangeVM();

                //コード変換区分
                vm.cdchangekbn = changeKbn;
                //取込コード変換情報明細リスト
                vm.codechangedetailList = new List<CodeChangeDetailVM>();

                var subList = changeCodeDtl.Where(d => d.codehenkankbn == changeKbn).ToList();
                foreach (var dto in subList)
                {
                    var detailVM = new CodeChangeDetailVM();

                    detailVM.cdchangekbn = dto.codehenkankbn;     //コード変換区分
                    detailVM.oldcode = dto.motocd;                //元コード
                    detailVM.oldcodememo = dto.motocdcomment;     //元コード説明
                    detailVM.newcode = dto.henkangocd;            //変換後コード
                    detailVM.newcodememo = dto.henkangocdcomment; //変換後コード説明

                    vm.codechangedetailList.Add(detailVM);
                }

                vmList.Add(vm);
            }

            return vmList;
        }

        /// <summary>
        /// マッピング設定情報を取得する(詳細画面)
        /// </summary>
        public static List<ItemMappingVM> GetItemMappingVMList(DaDbContext db, List<tm_kktori_mappingDto> dtl, List<FileIFVM> fileifList, List<PageItemVM> pageitemList)
        {
            var vmList = new List<ItemMappingVM>();
            foreach (var dto in dtl)
            {
                var vm = new ItemMappingVM();
                //画面項目ID
                vm.pageitemseq = dto.gamenitemseq;
                var pageitemData = pageitemList.Find(f => f.pageitemseq == vm.pageitemseq);
                //画面項目（名称）
                vm.pageitemnm = pageitemData == null ? string.Empty : pageitemData.itemnm;
                //ファイル項目(ファイル項目ID,カンマ区切り)
                vm.fileitemseq = dto.fileitemseq;
                if (!string.IsNullOrEmpty(dto.fileitemseq))
                {
                    var fileitemseqs = dto.fileitemseq.Split(',');
                    var listName = new List<string>();
                    foreach (string fileitemseq in fileitemseqs)
                    {
                        var fileifData = fileifList.Find(f => f.fileitemseq == CInt(fileitemseq));
                        if (fileifData != null)
                        {
                            //ファイル項目名（名称）
                            listName.Add(fileifData.itemnm);
                        }
                        else if (fileitemseq.Contains('\''))
                        {
                            //固定値
                            listName.Add(fileitemseq);
                        }
                    }
                    //ファイル項目（名称）(ファイル項目名,カンマ区切り)
                    vm.fileitemseqName = string.Join(',', listName);
                }
                //マッピング区分
                vm.mappingkbn = dto.mappingkbn;
                //マッピング区分（名称）
                vm.mappingkbnName = DaNameService.GetName(db, EnumNmKbn.マッピング区分, dto.mappingkbn);
                //マッピング方法
                vm.mappingmethod = dto.mappinghoho;
                if (!string.IsNullOrEmpty(dto.mappinghoho))
                {
                    //マッピング方法（名称）
                    vm.mappingmethodName = DaNameService.GetName(db, EnumNmKbn.マッピング方法, dto.mappinghoho);
                }
                //指定桁数（開始）
                vm.substrfrom = dto.siteiketasufrom;
                //指定桁数（終了）
                vm.substrto = dto.siteiketasuto;

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 画面項目情報を取得する(詳細画面)
        /// </summary>
        public static List<PageItemVM> GetPageItemVMList(DaDbContext db, List<tm_kktorinyuryoku_itemDto> pageItemDtl
            , List<tm_kktorinyuryoku_tableDto> tableDtl, List<tm_kktorinyuryoku_henkancode_mainDto> changeCodeMainDtl)
        {
            var vmList = new List<PageItemVM>();
            foreach (var dto in pageItemDtl)
            {
                var vm = new PageItemVM();

                //※基本情報
                //画面項目ID
                vm.pageitemseq = dto.gamenitemseq;
                //項目名
                vm.itemnm = dto.itemnm;
                //ワークテーブルカラム名
                vm.wktablecolnm = dto.wktablecolnm;
                //入力区分
                vm.inputkbn = dto.inputkbn;
                //入力区分（名称）
                vm.inputkbnName = DaNameService.GetName(db, EnumNmKbn.入力区分, dto.inputkbn);
                //入力方法
                vm.inputtype = dto.inputhoho;
                //引数
                if(vm.inputkbn == EnumToStr(Enum入力区分.関数))
                {
                    vm.hikisu = dto.hikisu;
                    if (!string.IsNullOrEmpty(dto.hikisu))
                    {
                        var gamenitemseqs = dto.hikisu.Split(',');
                        var listName = new List<string>();
                        foreach (string gamenitemseq in gamenitemseqs)
                        {
                            var gamenData = pageItemDtl.Find(f => f.gamenitemseq == CInt(gamenitemseq));
                            if (gamenData != null)
                            {
                                //画面項目名（名称）
                                listName.Add(gamenData.itemnm);
                            }
                            else if (gamenitemseq.Contains('\''))
                            {
                                //固定値
                                listName.Add(gamenitemseq);
                            }
                        }
                        //引数（名称）(画面項目名,カンマ区切り)
                        vm.hikisuName = string.Join(',', listName);
                    }
                }
                //桁数
                vm.len = dto.ketasu;
                //桁数（小数部）
                vm.len2 = dto.syosuketasu;
                //幅
                vm.width = dto.width;
                //フォーマット
                if ((vm.inputkbn.Equals(EnumToStr(Enum入力区分.テキスト))
                    && new string[] { EnumToStr(Enum入力方法.半角文字_半角数字), EnumToStr(Enum入力方法.半角文字_半角英数字) }.Contains(vm.inputtype)
                    ) || (vm.inputkbn.Equals(EnumToStr(Enum入力区分.画面検索)) && vm.inputtype.Equals(EnumToStr(Enum入力方法.宛名番号))))
                {
                    vm.format = dto.format;
                }
                else
                {
                    vm.format = null;
                }
                //フォーマット
                if (!string.IsNullOrEmpty(dto.format))
                {
                    //フォーマット（名称）
                    vm.formatName = DaNameService.GetName(db, EnumNmKbn.フォーマット_画面定義, dto.format);
                }
                //必須フラグ
                vm.requiredflg = dto.hissuflg;
                //必須フラグ（名称）
                vm.requiredflgName = DaNameService.GetName(db, EnumNmKbn.エラーレベル, dto.hissuflg);
                //一意フラグ	
                vm.uniqueflg = dto.itiiflg;
                //一意フラグ（名称）
                vm.uniqueflgName = FormatFlgStr(dto.itiiflg);
                //正規表現
                vm.seiki = dto.seikihyogen;
                //表示入力設定区分
                vm.dispinputkbn = dto.hyojiinputkbn;
                //表示入力設定区分（名称）
                vm.dispinputkbnName = DaNameService.GetName(db, EnumNmKbn.表示入力設定, dto.hyojiinputkbn);
                //並び順
                vm.sortno = dto.orderseq;

                //※マスタ参照
                //参照元項目ID
                vm.fromitemseq = dto.sansyomotoseq;
                //参照元フィールド
                vm.fromfieldid = dto.sansyomotofield;
                //取得先フィールド
                vm.targetfieldid = dto.syutokusakifield;
                //入力区分が○○マスタ参照の場合
                if (vm.inputkbn == EnumToStr(Enum入力区分.マスタ参照))
                {
                    //入力方法（名称）
                    var tableDto = tableDtl.Find(f => f.tablenm == vm.inputtype && f.sansyoflg);
                    //入力方法（名称）
                    vm.inputtypeName = tableDto == null ? string.Empty : tableDto.tableronrinm;
                    //参照元項目ID
                    if (vm.fromitemseq != null)
                    {
                        var pageItemDto = pageItemDtl.Find(f => f.gamenitemseq == vm.fromitemseq);
                        //参照元画面項目（名称）
                        vm.fromitemseqName = pageItemDto == null ? string.Empty : pageItemDto.itemnm;
                    }

                    //参照元フィールド
                    if (!string.IsNullOrEmpty(vm.fromfieldid))
                    {
                        //参照元フィールド（名称）
                        vm.fromfieldidName = GetFieldLogicName(db, vm.inputtype, vm.fromfieldid);
                    }
                    //取得先フィールド
                    if (!string.IsNullOrEmpty(vm.targetfieldid))
                    {
                        //取得先フィールド（名称）
                        vm.targetfieldidName = GetFieldLogicName(db, vm.inputtype, vm.targetfieldid);
                    }
                }
                else if (vm.inputkbn == EnumToStr(Enum入力区分.コード系))
                {
                    //入力方法で取込変換コードマスタ
                    var cdchangeDto = changeCodeMainDtl.Find(f => f.codehenkankbn == CInt(vm.inputtype));
                    //入力方法（名称）
                    vm.inputtypeName = cdchangeDto == null ? string.Empty : cdchangeDto.henkankbnnm;

                }
                else
                {
                    //入力区分より入力方法のドロップダウンリスト
                    var list = DaNameService.GetNameList(db, EnumNmKbn.入力方法).Where(x => x.hanyokbn1 == vm.inputkbn && x.nmcd == vm.inputtype).ToList();
                    if (list.Count > 0)
                    {
                        //入力方法（名称）
                        vm.inputtypeName = list[0].nm;
                    }
                    else
                    {
                        //入力方法（名称）
                        vm.inputtypeName = string.Empty;
                    }
                    //事業コード
                    vm.jigyocd = dto.jigyocd;

                    if (!string.IsNullOrEmpty(dto.jigyocd)
                        && (vm.inputtype.Equals(EnumToStr(Enum入力方法.医療機関)) || vm.inputtype.Equals(EnumToStr(Enum入力方法.事業従事者)) || vm.inputtype.Equals(EnumToStr(Enum入力方法.検診実施機関))))
                    {
                        //事業コード（名称）
                        vm.jigyocdName = GetHanyoName(db, EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード, dto.jigyocd);
                    }
                }

                //マスタ参照
                if (vm.inputkbn != EnumToStr(Enum入力区分.マスタ参照))
                {
                    //参照元項目ID
                    vm.fromitemseq = null;
                    //参照元フィールド
                    vm.fromfieldid = null;
                    //取得先フィールド
                    vm.targetfieldid = null;
                    //参照元画面項目（名称）
                    vm.fromitemseqName = "";
                    //参照元フィールド（名称）
                    vm.fromfieldidName = "";
                    //取得先フィールド（名称）
                    vm.targetfieldidName = "";
                }
                //年度フラグ
                vm.nendoflg = dto.nendoflg;
                //年度フラグ（名称）
                vm.nendoflgName = FormatFlgStr(CBool(dto.nendoflg));
                //※年度チェック
                if (vm.inputkbn == EnumToStr(Enum入力区分.テキスト) &&
                    (vm.inputtype == EnumToStr(Enum入力方法.半角文字_年)
                        || vm.inputtype == EnumToStr(Enum入力方法.半角文字_年_不詳あり)
                        || vm.inputtype == EnumToStr(Enum入力方法.半角文字_年月)
                        || vm.inputtype == EnumToStr(Enum入力方法.半角文字_時刻)
                        || vm.inputtype == EnumToStr(Enum入力方法.日付_年月日)
                        || vm.inputtype == EnumToStr(Enum入力方法.日付_年月日_不詳あり)
                        || vm.inputtype == EnumToStr(Enum入力方法.日時_年月日時分秒)
                    ))
                {
                    vm.yearchkflg = dto.nendocheck;
                    //年度チェック（名称）
                    vm.yearchkflgName = DaNameService.GetName(db, EnumNmKbn.エラーレベル, dto.nendocheck!);
                }
                //最小値
                vm.minval = dto.minvalue;
                //最大値
                vm.maxval = dto.maxvalue;
                //初期値
                vm.defaultval = dto.syokiti;
                //固定値
                vm.fixedval = dto.koteiti;

                //※マスタ存在
                //マスタチェックテーブル
                vm.msttable = dto.masterchecktable;
                if (!string.IsNullOrEmpty(vm.msttable))
                {
                    var tableDto = tableDtl.Find(f => f.tablenm == vm.msttable && f.sonzaicheckflg);
                    //マスタチェックテーブル（名称）
                    vm.msttableName = tableDto == null ? string.Empty : tableDto.tableronrinm;
                }
                //マスタチェック条件
                vm.mstjyoken = dto.mastercheckjoken;
                //マスタチェック項目
                vm.mstfield = dto.mastercheckitem;
                if (!string.IsNullOrEmpty(vm.msttable) && !string.IsNullOrEmpty(vm.mstfield))
                {
                    //マスタチェック項目（名称）
                    vm.mstfieldName = GetFieldLogicName(db, vm.msttable, vm.mstfield);
                }

                //※条件必須
                if (vm.requiredflg == EnumToStr(Enumエラーレベル.無視))
                {
                    //条件必須エラーレベル区分
                    vm.jherrlelkbn = dto.jokenhissuerrorkbn!;
                    //条件必須エラーレベル区分（名称）
                    vm.jherrlelkbnName = DaNameService.GetName(db, EnumNmKbn.エラーレベル, dto.jokenhissuerrorkbn!);
                    //条件必須項目ID
                    vm.jhitemseq = dto.jokenhissuitemseq;
                    if (dto.jokenhissuitemseq != null)
                    {
                        var pageItemDto = pageItemDtl.Find(f => f.gamenitemseq == vm.jhitemseq);
                        //条件必須項目（名称）
                        vm.jhitemseqName = pageItemDto == null ? string.Empty : pageItemDto.itemnm;
                    }
                    //条件必須演算子
                    vm.jhenzan = dto.jokenhissuenzansi;
                    if (!string.IsNullOrEmpty(dto.jokenhissuenzansi))
                    {
                        //条件必須演算子（名称）
                        vm.jhenzanName = DaNameService.GetName(db, EnumNmKbn.演算子, dto.jokenhissuenzansi);
                    }
                    //条件必須値
                    vm.jhval = dto.jokenhissuvalue;
                }

                //項目特定区分
                vm.itemkbn = dto.itemtokuteikbn;
                if (!string.IsNullOrEmpty(dto.itemtokuteikbn))
                {
                    //項目特定区分（名称）
                    vm.itemkbnName = DaNameService.GetName(db, EnumNmKbn.項目特定区分, dto.itemtokuteikbn);
                }

                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 取込登録詳細情報を取得する(詳細画面)
        /// </summary>
        public static List<InsertVM> GetInsertVMList(DaDbContext db, List<tm_kktorinyuryoku_torokuDto> insertdetailDtl, List<tm_kktorinyuryoku_tableDto> tableDtl, List<string> tableidList, List<PageItemVM> pageitemList)
        {
            //登録項目情報リスト
            var vmList = new List<InsertVM>();

            //テーブル物理名
            foreach (string tableid in tableidList)
            {
                //登録項目情報
                var vm = new InsertVM();
                //テーブル物理名
                vm.tableid = tableid;
                //登録項目設定明細情報
                var insertDetailVmList = new List<InsertDetailVM>();

                //該当取込テーブル項目
                var fieldList = ImDBUtil.GetFieldList(db, tableid);

                // レコードNo
                int maxrecno = 1;
                var subList = insertdetailDtl.Where(d => d.tableid == tableid).ToList();
                if (subList.Count > 0)
                {
                    maxrecno = subList.Max(d => d.recordno);
                }

                foreach (AiFieldInfo tableItemDto in fieldList)
                {
                    List<tm_kktorinyuryoku_torokuDto> insertdetailSubDtl = insertdetailDtl.Where(d => d.tableid == tableid && d.fieldnm == tableItemDto.FieldName).ToList();

                    //該当取込テーブル項目は既存の場合
                    if (insertdetailSubDtl != null && insertdetailSubDtl.Count > 0)
                    {
                        foreach (tm_kktorinyuryoku_torokuDto insertDto in insertdetailSubDtl)
                        {
                            var detailVM = new InsertDetailVM();
                            detailVM.tableid = insertDto.tableid;             //テーブル物理名
                            detailVM.recno = insertDto.recordno;              //レコードNo
                            detailVM.fieldid = insertDto.fieldnm;             //フィールド物理名
                            detailVM.fieldnm = tableItemDto.FieldComment;     //フィールド論理名
                            detailVM.syorikbn = insertDto.syorikbn;           //処理区分
                            detailVM.pageitemseq = insertDto.datamotoitemseq; //データ元画面項目ID
                            if (detailVM.pageitemseq != null)
                            {
                                var pageItem = pageitemList.Find(f => f.pageitemseq == detailVM.pageitemseq);
                                //データ元画面項目（名称）
                                detailVM.itemnm = pageItem == null ? string.Empty : pageItem.itemnm;
                            }
                            //固定値
                            detailVM.fixedval = insertDto.koteiti;
                            //処理区分（名称）
                            detailVM.syorikbnName = DaNameService.GetName(db, EnumNmKbn.処理区分, detailVM.syorikbn);

                            //処理区分が関連テーブルの項目から登録の場合
                            if (detailVM.syorikbn == EnumToStr(Enum処理区分.関連テーブルの項目から登録) &&
                                !string.IsNullOrEmpty(insertDto.datamototablenm))
                            {
                                //データ元テーブル
                                detailVM.datamototablenm = insertDto.datamototablenm;

                                //データ元テーブル(論理名)
                                var tableDto = tableDtl.Find(e => e.tablenm == insertDto.datamototablenm);
                                detailVM.datamototableronrinm = tableDto == null ? "" : tableDto.tableronrinm;

                                //データ元フィールド
                                detailVM.datamotofieldnm = insertDto.datamotofieldnm;
                                if (!string.IsNullOrEmpty(insertDto.datamotofieldnm) && tableDto != null)
                                {
                                    //データ元フィールド(論理名)
                                    detailVM.datamotofieldronrinm = GetFieldLogicName(db, insertDto.datamototablenm, insertDto.datamotofieldnm);
                                }
                            }
                            //処理区分が関連テーブルの項目から登録の場合
                            if (detailVM.syorikbn == EnumToStr(Enum処理区分.手動採番))
                            {
                                //採番キー
                                detailVM.saibankey = insertDto.saibankey;
                                if (!string.IsNullOrEmpty(insertDto.saibankey))
                                {
                                    //採番キー(論理名)
                                    detailVM.saibankeyronrinm = GetFieldLogicNames(db, tableid, insertDto.saibankey);
                                }
                            }
                            insertDetailVmList.Add(detailVM);
                        }
                    }
                    else
                    {
                        //該当取込テーブル項目は新規の場合
                        for (int i = 1; i <= maxrecno; i++)
                        {
                            //テーブルの登録項目設定明細情報を取得する
                            var detailVM = GetInsertDetailVM(db, tableid, i, tableItemDto);
                            insertDetailVmList.Add(detailVM);
                        }
                    }
                }
                vm.insertdetailList = insertDetailVmList.OrderBy(x => x.recno).ToList();
                vmList.Add(vm);
            }

            return vmList;
        }

        /// <summary>
        /// テーブルの登録項目設定明細情報を取得する(登録項目設定情報初期化の場合用)
        /// </summary>
        public static InsertDetailVM GetInsertDetailVM(DaDbContext db, string tableid, int recno, AiFieldInfo tableItemDto)
        {
            var detailVM = new InsertDetailVM();
            detailVM.tableid = tableid;                                 //テーブル物理名
            detailVM.recno = recno;                                     //レコードNo
            detailVM.fieldid = tableItemDto.FieldName;                  //フィールド物理名
            detailVM.fieldnm = tableItemDto.FieldComment;               //フィールド論理名
            detailVM.syorikbn = EnumToStr(Enum処理区分.設定しない); //処理区分:設定しない
            //処理区分（名称）
            detailVM.syorikbnName = DaNameService.GetName(db, EnumNmKbn.処理区分, detailVM.syorikbn);

            return detailVM;
        }

        /// <summary>
        /// 汎用データを取得
        /// </summary>
        private static string GetHanyoName(DaDbContext db, EnumHanyoKbn kbn, string cd)
        {
            //汎用データ一覧
            var hanyoDtl = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();

            var cdList = new List<string>(cd.Split(','));
            var nameList = hanyoDtl.OrderBy(e => cdList.IndexOf(e.value)).Where(e => cdList.Contains(e.value)).Select(e => e.label).ToList();

            if (nameList != null && nameList.Count > 0)
            {
                //名称
                return string.Join(',', nameList);
            }

            return string.Empty;
        }

        /// <summary>
        /// 該当テーブルのフィールド論理名を取得する
        /// </summary>
        public static string GetFieldLogicName(DaDbContext db, string tableid, string? fieldid)
        {
            if (fieldid == null)
            {
                return string.Empty;
            }
            var fieldList = ImDBUtil.GetFieldList(db, tableid);
            if (fieldList != null)
            {
                var tablefieldDto = fieldList.Find(f => f.FieldName == fieldid);
                //フィールド論理名
                return tablefieldDto == null ? string.Empty : tablefieldDto.FieldComment;
            }
            return string.Empty;
        }

        /// <summary>
        /// 該当テーブルのフィールド論理名(複数)を取得する
        /// </summary>
        public static string GetFieldLogicNames(DaDbContext db, string tableid, string? fieldids)
        {
            if (string.IsNullOrEmpty(fieldids))
            {
                return string.Empty;
            }
            var nameList = new List<string>();
            var fileds = fieldids.Split(",");
            foreach (string filed in fileds)
            {
                //該当テーブルのフィールド論理名を取得する
                var name = GetFieldLogicName(db, tableid, filed);
                if (!string.IsNullOrEmpty(name))
                {
                    nameList.Add(name);
                }
            }

            return string.Join(",", nameList);
        }
    }
}
