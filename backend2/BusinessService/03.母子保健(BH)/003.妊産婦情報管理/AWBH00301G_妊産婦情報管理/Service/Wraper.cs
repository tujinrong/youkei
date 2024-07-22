// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWBH00301G
{
    public class Wraper : CmWraperBase
    {
        //定数定義
        private const string FUSYO = "不詳";          //生年月日が不詳の場合は利用

        //================================= 1.妊産婦一覧画面検索処理(一覧画面) =================================
        /// <summary>
        /// 住民情報一覧
        /// </summary>
        public static List<NinsanpuListVM> GetNinSanPuVMList(DaDbContext db, DataRowCollection rows, string bosikbn, bool alertviewflg)
        {
            return rows.Cast<DataRow>().Select(r => GetNinsanpuVM(db, r, bosikbn, alertviewflg)).ToList();
        }

        /// <summary>
        /// 住民情報（一行）
        public static NinsanpuListVM GetNinsanpuVM(DaDbContext db, DataRow row, string bosikbn, bool alertviewflg)
        {
            var vm = new NinsanpuListVM();

            vm.datasts = string.Empty;                                                  //状態
            vm.atenano = row.Wrap(nameof(vm.atenano));                                  //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                      //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                //カナ氏名
            var sex = row.Wrap(nameof(tt_afatenaDto.sex));                              //性別（コード）
            vm.sex = MNm(db, sex, EnumNmKbn.性別_システム共有);                         //性別（名称）
            vm.bymd = GetBymd(row);                                                     //生年月日
            var gyoseiku = row.Wrap(nameof(tt_afatenaDto.tosi_gyoseikucd));             //行政区(指定都市_行政区等コード)
            vm.gyoseiku = MNm(db, gyoseiku, EnumNmKbn.指定都市_行政区等コード);         //行政区名称
            var juminkbn = row.Wrap(nameof(vm.juminkbn));                               //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));              //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            vm.bhtetyono = CStr(row.Wrap(nameof(tt_bhnsbosikenkotetyokofuDto.bositetyokofuno)));    //母子手帳番号
            vm.torokuno = CLng(row.Wrap(nameof(tt_bhnsbosikenkotetyokofuDto.torokuno))); //登録番号
            vm.syosai = Service.GetSyosaiStr(db, bosikbn, vm.atenano, vm.torokuno);     //詳細内容

            return vm;
        }

        //================================= 2.3.妊産婦詳細画面検索処理(一覧画面) =================================
        /// <summary>
        /// 妊産婦ヘッダー情報
        public static HeaderInfoVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new HeaderInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.kname = CStr(dto.simei_kana_yusen);                                      //カナ氏名（氏名_フリガナ_優先）
            var sex = CStr(dto.sex);                                                    //性別（コード）
            vm.sex = MNm(db, sex, EnumNmKbn.性別_システム共有);                         //性別（名称）
            var juminkbn = CStr(dto.juminkbn);                                          //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            vm.bymd = GetBymd(dto);                                                     //生年月日
            vm.kijunymd = FormatWaKjYMD(DateTime.Now);                                  //年齢計算基準日（システム日付の和暦表示）
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                               //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                                  //生年月日
            vm.age = GetNenrei(bymd_fusyoflg, bymd, DateTime.Now);                      //年齢
            var siensotikbn = CStr(dto.siensotikbn);                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 2.3.妊産婦詳細画面検索処理(一覧画面) =================================
        //================================= 4.妊産婦フリー検索処理（メニュー選択／タブ選択の場合） ===============
        //================================= 4.新規ボタンを押下 ===================================================
        /// <summary>
        /// メニュー名称リスト
        /// </summary>
        public static List<MenuInfoVM> GetMenuInfoVMList(DaDbContext db, IOrderedEnumerable<tm_bhkksyosaimenyuDto> dtl, string bosikbn, string atenano, long torokuno)
        {
            List<MenuInfoVM> list = new List<MenuInfoVM>();
            foreach (tm_bhkksyosaimenyuDto dto in dtl)
            {
                var vm = new MenuInfoVM();

                vm.menucd = dto.bhsyosaimenyucd;                                        //メニューコード
                vm.menuname = dto.bhsyosaimenyunm;                                      //メニュー名称
                vm.status = Service.GetMenuStatus(db, bosikbn, vm.menucd, atenano, torokuno);    //メニュー文字色

                list.Add(vm);

            }
            return list;
        }

        /// <summary>
        /// タブ名称リスト（一覧）
        /// </summary>
        public static List<TabInfoVM> GetTabInfoVMList(DaDbContext db, IOrderedEnumerable<tm_bhkksyosaitabDto> dtl, string atenano, long torokuno)
        {
            List<TabInfoVM> list = new List<TabInfoVM>();
            foreach (tm_bhkksyosaitabDto dto in dtl)
            {
                list.Add(GetTabInfoVM(db, dto, atenano, torokuno));
            }
            return list;
        }

        /// <summary>
        /// タブ名称リスト（一行）
        public static TabInfoVM GetTabInfoVM(DaDbContext db, tm_bhkksyosaitabDto dto, string atenano, long torokuno)
        {
            var vm = new TabInfoVM();

            vm.tabcd = dto.bhsyosaitabcd;                                               //タブコード
            vm.tabname = dto.bhsyosaitabnm;                                             //タブ名称
            vm.status = Service.GetTabStatus(db, dto, atenano, torokuno);               //タブ文字色

            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_bhkkfreeitemDto> mstDtl, List<tt_bhnsfreeDto> dataDtl, string kinoid, int patternno)
        {
            //保健指導フリー項目データタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            var list = new List<FreeItemDispInfoVM>();
            foreach (var item in mstDtl)
            {
                var vm = new FreeItemDispInfoVM();
                var dto = dataDtl.Find(x => x.itemcd == item.itemcd);
                vm = GetVM(db, item, dto, datatypes, kinoid, patternno);
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_bhkkfreeitemDto mstDto, tt_bhnsfreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.母子, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                           mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                           (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko, mstDto.syokiti, (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                    //グループID
            vm.groupid2 = mstDto.groupid2;                  //グループID

            vm.orderseq = mstDto.orderseq;                  //並びシーケンス

            return vm;
        }

        /// <summary>
        /// 回数リスト取得
        /// </summary>
        public static List<KaisuInfoVM> GetKaisuVMList(DataTable dt)
        {
            List<KaisuInfoVM> kaisulist = new List<KaisuInfoVM>();
            foreach (DataRow row in dt.Rows)
            {
                var vm = new KaisuInfoVM()
                {
                    kaisu = CInt(row.Wrap("kaisu")),
                };
                kaisulist.Add(vm);
            }

            return kaisulist;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        public static string MNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 生年月日表記取得
        /// </summary>
        public static string GetBymd(tt_afatenaDto dto)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);
            //生年月日
            var bymd = CStr(dto.bymd);
            //生年月日_不詳表記
            var bymd_fusyohyoki = CNStr(dto.bymd_fusyohyoki);

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (!CBool(bymd_fusyoflg) && string.IsNullOrEmpty(bymd.Trim())) { return string.Empty; }

            return CmLogicUtil.GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }

        /// <summary>
        /// 生年月日表記取得（不詳フラグ=falseまたは生年月日=nullの場合空白で戻る）
        /// </summary>
        public static string GetBymd(DataRow row)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = row.CNBool(nameof(tt_afatenaDto.bymd_fusyoflg));
            //生年月日
            var bymd = row.CStr(nameof(tt_afatenaDto.bymd));
            //生年月日_不詳表記
            var bymd_fusyohyoki = row.CStr(nameof(tt_afatenaDto.bymd_fusyohyoki));

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (!CBool(bymd_fusyoflg) && string.IsNullOrEmpty(bymd.Trim())) { return string.Empty; }

            return CmLogicUtil.GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }

        /// <summary>
        /// 生年月日と実施日からから結果情報の実施日時点年齢を取得（「〇歳〇カ月」）
        /// </summary>
        public static string GetNenrei(bool bymd_fusyoflg, string bymd, DateTime kijyundate)
        {
            var agestr = string.Empty;

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (CBool(bymd_fusyoflg))
            {
                agestr = FUSYO;
            }
            else if (string.IsNullOrEmpty(bymd))
            {
                agestr = string.Empty;
            }
            else
            {
                DateTime sysymd = DateTime.Parse(bymd);              //生年月日（DateTime型）

                DateTime time;
                if (kijyundate <= sysymd)
                {
                    time = DateTime.MinValue + (sysymd - kijyundate);
                }
                else
                {
                    time = DateTime.MinValue + (kijyundate - sysymd);
                }

                agestr = $"{time.Year - 1}歳{time.Month - 1}カ月";
            }

            return agestr;
        }
    }
}