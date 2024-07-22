// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00601G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータを取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchListRequest.gyoumukbn)}_in", req.gyoumukbn),    //業務区分
                new($"{nameof(SearchListRequest.impnm)}_in", req.impnm)             //処理結果コード 
            };

            return paras;
        }

        /// <summary>
        /// 一括取込入力マスタ
        /// </summary>
        public static tm_kktorinyuryokuDto GetkkimpDto(tm_kktorinyuryokuDto dtoOld, SaveDetailRequest req, DateTime dttm)
        {
            HeaderVM vm = req.hearderData;
            var dto = new tm_kktorinyuryokuDto();
            dto.torinyuryokunm = vm.impnm;          //一括取込入力名
            dto.torinyuryokbn = vm.impkbn;          //一括取込入力区分
            dto.gyomukbn = vm.gyoumukbn;            //業務区分
            dto.nendohyojiflg = vm.yeardispflg;     //年度表示フラグ
            dto.torokukbn = vm.regupdkbn;           //登録区分
            dto.nendohanikbn = vm.nendohanikbn;     //年度範囲区分
            dto.comment = vm.memo;                  //説明
            dto.proccheck = vm.procchk;             //チェックプロシージャ名
            dto.procbefore = vm.procbefore;         //更新前プロシージャ名
            dto.procafter = vm.procafter;           //更新後プロシージャ名
            dto.orderseq = vm.orderseq;             //並び順シーケンス

            //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                dto.reguserid = req.userid;         //登録ユーザーID
                dto.regdttm = dttm;                 //登録日時
            }
            else
            {
                dto.reguserid = dtoOld.reguserid;   //登録ユーザーID
                dto.regdttm = dtoOld.regdttm;       //登録日時
                dto.torinyuryokuno = dtoOld.torinyuryokuno;
            }
            dto.upduserid = req.userid;             //更新ユーザーID
            dto.upddttm = dttm;                     //更新日時

            return dto;
        }

        /// <summary>
        /// 一括取込入力対象テーブルマスタ
        /// </summary>
        public static List<tm_kktorinyuryoku_taisyotableDto> GetTaishoTableDtl(string impno, HeaderVM vm)
        {
            var dtoList = new List<tm_kktorinyuryoku_taisyotableDto>();
            foreach (string tableid in vm.tableidList)
            {
                var dto = new tm_kktorinyuryoku_taisyotableDto();
                dto.torinyuryokuno = impno;         //取込シーケンス
                dto.tablenm = tableid;              //テーブル物理名
                dtoList.Add(dto);
            }

            return dtoList;
        }

        /// <summary>
        /// 取込基本情報マスタ
        /// </summary>
        public static tm_kktori_kihonDto GetFileInfoDto(string impno, FileInfoVM vm)
        {
            var dto = new tm_kktori_kihonDto();
            dto.torinyuryokuno = impno;             //一括取込入力No
            dto.filekeisiki = vm.filetype;          //ファイル形式
            dto.fileencode = vm.fileencode;         //ファイルエンコード
            dto.filenm = vm.filenmrule;             //ファイル名称
            dto.seikihyogen = vm.filenmruleflg;     //正規表現
            dto.datakeisiki = vm.datakbn;           //データ形式
            dto.recordlen = vm.recordlen;           //レコード長
            dto.inyofusonzaikbn = vm.quoteskbn;     //引用符存在区分
            dto.kugirikigo = vm.dividekbn;          //区切り記号
            dto.headerrows = vm.headerrows;         //ヘッダー行数
            dto.footerrows = vm.footerrows;         //フッター行数
            return dto;
        }

        /// <summary>
        /// 取込IFマスタ
        /// </summary>
        public static List<tm_kktori_interfaceDto> GetFileIFDtl(string impno, List<FileIFVM> fileifList)
        {
            var dtoList = new List<tm_kktori_interfaceDto>();

            foreach (FileIFVM vm in fileifList)
            {
                var dto = new tm_kktori_interfaceDto();
                dto.torinyuryokuno = impno;         //一括取込入力No
                dto.fileitemseq = vm.fileitemseq;   //ファイル項目ID
                dto.itemnm = vm.itemnm;             //項目名
                dto.keyflg = vm.keyflg;             //キーフラグ
                dto.hissuflg = vm.requiredflg;      //必須フラグ
                dto.datatype = vm.datatype;         //データ型
                dto.ketasu = vm.len;                //桁数
                dto.syosuketasu = vm.len2;          //桁数（小数部）
                dto.format = vm.format;             //フォーマット
                dto.formatcheck = vm.fmtcheck;      //フォーマットチェック
                dto.formathenkan = vm.fmtchange;    //フォーマット変換
                dto.biko = vm.memo;                 //備考

                dtoList.Add(dto);
            }

            return dtoList;
        }

        /// <summary>
        /// 取込変換コードマスタ
        /// </summary>
        public static List<tm_kktori_henkancodeDto> GetCodeChangeDtl(string impno, List<CodeChangeVM> vmList)
        {
            var dtoList = new List<tm_kktori_henkancodeDto>();
            foreach (CodeChangeVM vm in vmList)
            {
                if (vm.codechangedetailList != null && vm.codechangedetailList.Count > 0)
                {
                    foreach (CodeChangeDetailVM detailVM in vm.codechangedetailList)
                    {
                        var dto = new tm_kktori_henkancodeDto();
                        dto.torinyuryokuno = impno;                     //一括取込入力No
                        dto.codehenkankbn = vm.cdchangekbn;             //コード変換区分
                        dto.motocd = detailVM.oldcode;                  //元コード
                        dto.motocdcomment = detailVM.oldcodememo;       //元コード説明
                        dto.henkangocd = detailVM.newcode;              //変換後コード
                        dto.henkangocdcomment = detailVM.newcodememo;   //変換後コード説明

                        dtoList.Add(dto);
                    }
                }
            }
            return dtoList;
        }

        /// <summary>
        /// 取込項目マッピングマスタ
        /// </summary>
        public static List<tm_kktori_mappingDto> GetItemMappingDtl(string impno, List<ItemMappingVM> vmList)
        {
            var dtoList = new List<tm_kktori_mappingDto>();

            foreach (ItemMappingVM vm in vmList)
            {
                var dto = new tm_kktori_mappingDto();
                dto.torinyuryokuno = impno;             //一括取込入力No
                dto.gamenitemseq = vm.pageitemseq;      //画面項目ID
                dto.fileitemseq = vm.fileitemseq;       //ファイル項目ID
                dto.mappingkbn = vm.mappingkbn;         //マッピング区分
                dto.mappinghoho = vm.mappingmethod;     //マッピング方法
                dto.siteiketasufrom = vm.substrfrom;    //指定桁数（開始）
                dto.siteiketasuto = vm.substrto;        //指定桁数（終了）
                dtoList.Add(dto);
            }
            return dtoList;
        }

        /// <summary>
        /// 一括取込入力項目定義マスタ
        /// </summary>
        public static List<tm_kktorinyuryoku_itemDto> GetPageItemDtl(string impno, List<PageItemVM> vmList)
        {
            var dtoList = new List<tm_kktorinyuryoku_itemDto>();

            foreach (PageItemVM vm in vmList)
            {
                var dto = new tm_kktorinyuryoku_itemDto();

                dto.torinyuryokuno = impno;                 //一括取込入力No
                //※基本情報
                dto.gamenitemseq = vm.pageitemseq;          //画面項目ID
                dto.itemnm = vm.itemnm;                     //項目名
                dto.wktablecolnm = vm.wktablecolnm;         //ワークテーブルカラム名
                dto.inputkbn = vm.inputkbn;                 //入力区分
                dto.inputhoho = vm.inputtype;               //入力方法
                dto.hikisu = vm.hikisu;                     //引数
                dto.ketasu = vm.len;                        //桁数
                dto.syosuketasu = vm.len2;                  //桁数（小数部）
                dto.width = vm.width;                       //幅
                dto.format = vm.format;                     //フォーマット
                dto.hissuflg = vm.requiredflg;              //必須フラグ	
                dto.itiiflg = vm.uniqueflg;                 //一意フラグ	
                dto.seikihyogen = vm.seiki;                 //正規表現	"
                dto.hyojiinputkbn = vm.dispinputkbn;        //表示入力設定区分
                dto.orderseq = vm.sortno;                   //並び順

                //※マスタ参照
                dto.sansyomotoseq = vm.fromitemseq;         //参照元項目ID
                dto.sansyomotofield = vm.fromfieldid;       //参照元フィールド
                dto.syutokusakifield = vm.targetfieldid;    //取得先フィールド


                dto.nendoflg = vm.nendoflg;                 //年度フラグ
                dto.nendocheck = vm.yearchkflg;             //年度チェック
                dto.minvalue = vm.minval;                   //最小値
                dto.maxvalue = vm.maxval;                   //最大値
                dto.syokiti = vm.defaultval;                //初期値
                dto.koteiti = vm.fixedval;                  //固定値

                //※マスタ存在
                dto.masterchecktable = vm.msttable;         //マスタチェックテーブル
                dto.mastercheckjoken = vm.mstjyoken;        //マスタチェック条件
                dto.mastercheckitem = vm.mstfield;          //マスタチェック項目

                //※条件必須
                dto.jokenhissuerrorkbn = vm.jherrlelkbn;    //条件必須エラーレベル区分
                dto.jokenhissuitemseq = vm.jhitemseq;       //条件必須項目ID
                dto.jokenhissuenzansi = vm.jhenzan;         //条件必須演算子
                dto.jokenhissuvalue = vm.jhval;             //条件必須値

                dto.jigyocd = vm.jigyocd;                   //事業コード
                dto.itemtokuteikbn = vm.itemkbn;            //項目特定区分

                dtoList.Add(dto);
            }
            return dtoList;
        }

        /// <summary>
        /// 一括取込入力登録マスタ
        /// </summary>
        public static List<tm_kktorinyuryoku_torokuDto> GetInsertDetailDtl(string impno, List<InsertVM> vmList, List<tm_kktorinyuryoku_taisyotableDto> kkimptblsDtl)
        {
            var dtoList = new List<tm_kktorinyuryoku_torokuDto>();

            //テーブル物理名リスト
            var tableidList = kkimptblsDtl.Select(e => e.tablenm).ToList();

            foreach (InsertVM vm in vmList)
            {
                if (tableidList.Contains(vm.tableid) && vm.insertdetailList != null && vm.insertdetailList.Count > 0)
                {
                    //レコードNoリスト
                    List<int> recnoList = vm.insertdetailList.Select(e => e.recno).Distinct().ToList();
                    recnoList.Sort();

                    int no = 1; //順番にセット
                    foreach (int recno in recnoList)
                    {
                        var subList = vm.insertdetailList.Where(e => e.recno == recno).ToList();
                        foreach (InsertDetailVM detailVM in subList)
                        {
                            var dto = new tm_kktorinyuryoku_torokuDto();
                            dto.torinyuryokuno = impno;                     //一括取込入力No
                            dto.tableid = vm.tableid;                       //テーブル物理名
                            dto.recordno = no;                              //レコードNo
                            dto.fieldnm = detailVM.fieldid;                 //フィールド物理名
                            dto.syorikbn = detailVM.syorikbn;               //処理区分
                            dto.datamotoitemseq = detailVM.pageitemseq;     //データ元画面項目ID
                            dto.koteiti = detailVM.fixedval;                //固定値
                            dto.datamototablenm = detailVM.datamototablenm; //データ元テーブル
                            dto.datamotofieldnm = detailVM.datamotofieldnm; //データ元フィールド
                            dto.saibankey = detailVM.saibankey;             //採番キー 
                            dtoList.Add(dto);
                        }
                        no++;
                    }
                }
            }
            return dtoList;
        }

        /// <summary>
        /// 一括取込入力変換コードメインマスタ
        /// </summary>
        public static List<tm_kktorinyuryoku_henkancode_mainDto> GetChangeCodeMainDto(string impno, List<ChangeCodeMainVM> changeCodeMainList)
        {
            var dtoList = new List<tm_kktorinyuryoku_henkancode_mainDto>();

            foreach (ChangeCodeMainVM vm in changeCodeMainList)
            {
                var dto = new tm_kktorinyuryoku_henkancode_mainDto();

                dto.torinyuryokuno = impno;                 //一括取込入力No
                dto.codehenkankbn = vm.codehenkankbn;       //コード変換区分
                dto.henkankbnnm = vm.henkankbnnm;           //変換区分名称
                dto.codekanritablenm = vm.codekanritablenm; //コード管理テーブル名
                dto.maincd = vm.maincd;                     //メインコード
                dto.subcd = vm.subcd;                       //サブコード
                dto.sonotajoken = vm.sonotajoken;           //その他条件

                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}