// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.08
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWBH00401G
{
    public class Wraper : CmWraperBase
    {
        //================================= 1.乳幼児一覧画面検索処理(一覧画面) =================================
        /// <summary>
        /// 住民情報一覧
        /// </summary>
        public static List<NyuyoujiListVM> GetNyuYouJiVMList(DaDbContext db, DataRowCollection rows, string bosikbn, bool alertviewflg)
        {
            return rows.Cast<DataRow>().Select(r => GetNyuYouJiVM(db, r, bosikbn, alertviewflg)).ToList();
        }

        /// <summary>
        /// 住民情報（一行）
        public static NyuyoujiListVM GetNyuYouJiVM(DaDbContext db, DataRow row, string bosikbn, bool alertviewflg)
        {
            var vm = new NyuyoujiListVM();

            vm.datasts = string.Empty;                                                  //状態
            vm.atenano = row.Wrap(nameof(vm.atenano));                                  //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                      //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                                  //性別
            vm.bymd = AWBH00301G.Wraper.GetBymd(row);                                   //生年月日
            var gyoseiku = row.Wrap(nameof(tt_afatenaDto.tosi_gyoseikucd));             //行政区(指定都市_行政区等コード)
            vm.gyoseiku = AWBH00301G.Wraper.MNm(db, gyoseiku, EnumNmKbn.指定都市_行政区等コード); //行政区名称
            var juminkbn = row.Wrap(nameof(vm.juminkbn));                               //住民区分コード
            vm.juminkbn = AWBH00301G.Wraper.MNm(db, juminkbn, EnumNmKbn.住民区分);      //住民区分名称
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));              //支援措置区分
            vm.syosai = Service.GetSyosaiStr(db, bosikbn, vm.atenano, 0);               //詳細内容
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 2.3.乳幼児詳細画面検索処理(一覧画面) =================================
        /// <summary>
        /// 乳幼児ヘッダー情報
        public static HeaderInfoVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new HeaderInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.kname = CStr(dto.simei_kana_yusen);                                      //カナ氏名（氏名_フリガナ_優先）
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto.sex));                             //性別
            var juminkbn = CStr(dto.juminkbn);                                          //住民区分コード
            vm.juminkbn = AWBH00301G.Wraper.MNm(db, juminkbn, EnumNmKbn.住民区分);      //住民区分名称
            vm.bymd = AWBH00301G.Wraper.GetBymd(dto);                                   //生年月日
            vm.kijunymd = FormatWaKjYMD(DateTime.Now);                                  //年齢計算基準日（システム日付の和暦表示）
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                               //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                                  //生年月日
            vm.age = AWBH00301G.Wraper.GetNenrei(bymd_fusyoflg, bymd, DateTime.Now);    //年齢
            var siensotikbn = CStr(dto.siensotikbn);                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 2.3.乳幼児詳細画面検索処理(一覧画面) =================================
        //================================= 4.乳幼児フリー検索処理（メニュー選択／タブ選択の場合） ===============
        //================================= 4.新規ボタンを押下 ===================================================
        /// <summary>
        /// メニュー名称リスト
        /// </summary>
        public static List<MenuInfoVM> GetMenuInfoVMList(DaDbContext db, IOrderedEnumerable<tm_bhkksyosaimenuDto> dtl, string bosikbn, string atenano)
        {
            List<MenuInfoVM> list = new List<MenuInfoVM>();
            foreach (tm_bhkksyosaimenuDto dto in dtl)
            {
                var vm = new MenuInfoVM();

                vm.menucd = dto.bhsyosaimenyucd;                                        //メニューコード
                vm.menuname = dto.bhsyosaimenyunm;                                      //メニュー名称
                vm.status = Service.GetMenuStatus(db, bosikbn, vm.menucd, atenano);     //メニュー文字色

                list.Add(vm);

            }
            return list;
        }

        /// <summary>
        /// タブ名称リスト（一覧）
        /// </summary>
        public static List<TabInfoVM> GetTabInfoVMList(DaDbContext db, IOrderedEnumerable<tm_bhkksyosaitabDto> dtl, string atenano)
        {
            List<TabInfoVM> list = new List<TabInfoVM>();
            foreach (tm_bhkksyosaitabDto dto in dtl)
            {
                list.Add(GetTabInfoVM(db, dto, atenano));
            }
            return list;
        }

        /// <summary>
        /// タブ名称リスト（一行）
        public static TabInfoVM GetTabInfoVM(DaDbContext db, tm_bhkksyosaitabDto dto, string atenano)
        {
            var vm = new TabInfoVM();

            vm.tabcd = dto.bhsyosaitabcd;                                               //タブコード
            vm.tabname = dto.bhsyosaitabnm;                                             //タブ名称
            vm.status = Service.GetTabStatus(db, dto, atenano);                         //タブ文字色

            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_bhkkfreeitemDto> mstDtl, List<tt_bhnyfreeDto> dataDtl, string kinoid, int patternno)
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
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_bhkkfreeitemDto mstDto, tt_bhnyfreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
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

        /// <summary>
        /// 宛名情報取得
        /// </summary>
        public static string GetAtenaInfo(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new AtenaInfoVM();

            vm.simei_yusen = CStr(dto.simei_yusen);                                                                               //氏名
            vm.jutoknm = AWBH00301G.Wraper.MNm(db, CStr((EnumNmKbn)dto.jutokbn), EnumNmKbn.住登区分);                             //住登区分名称
            if (CStr((EnumNmKbn)dto.jutokbn).Equals(住登区分._1))
            {
                //住民の場合
                vm.juminsyubetunm = AWBH00301G.Wraper.MNm(db, CStr((EnumNmKbn)dto.juminsyubetu), EnumNmKbn.住民種別_住民基本台帳);//住民種別名称
                vm.juminjotainm = AWBH00301G.Wraper.MNm(db, CStr(dto.juminjotai), EnumNmKbn.住民状態_住民基本台帳);               //住民状態名称
            }
            else if (CStr((EnumNmKbn)dto.jutokbn).Equals(住登区分._2))
            {
                //住登外の場合
                vm.juminsyubetunm = AWBH00301G.Wraper.MNm(db, CStr((EnumNmKbn)dto.juminsyubetu), EnumNmKbn.住民種別);             //住民種別名称
                vm.juminjotainm = AWBH00301G.Wraper.MNm(db, CStr(dto.juminjotai), EnumNmKbn.住民状態);                            //住民状態名称
            }
            vm.juminnm = AWBH00301G.Wraper.MNm(db, CStr(dto.juminkbn), EnumNmKbn.住民区分);                                       //住民区分名称

            var str = $"{vm.simei_yusen}{SPACE_FULL}{vm.jutoknm}{SPACE_FULL}{vm.juminsyubetunm}{SPACE_FULL}{vm.juminjotainm}{SPACE_FULL}{vm.juminnm}";

            return str;
        }
    }
}