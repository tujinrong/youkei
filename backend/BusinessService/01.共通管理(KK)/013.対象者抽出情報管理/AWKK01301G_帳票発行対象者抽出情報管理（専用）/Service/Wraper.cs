// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.05.28
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK01301G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 抽出情報一覧(一覧画面)
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<RowVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetVM(db, row));
            }

            return vmList;
        }

        /// <summary>
        /// 抽出条件／抽出条件以外取得(詳細画面初期化)
        /// </summary>
        public static List<FreeItemTyusyutuVM> GetFreeItemVMList(DaDbContext db, InitDetailRequest req, List<tm_kktaisyosya_tyusyutufreeitemDto> mstDtl, List<tt_kktaisyosya_tyusyutufreeDto> dataDtl, string? nendoSetting)
        {
            var vmList = new List<FreeItemTyusyutuVM>();

            //フリー項目のデータタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            if (mstDtl != null)
            {
                foreach (tm_kktaisyosya_tyusyutufreeitemDto item in mstDtl)
                {
                    var vm = new FreeItemTyusyutuVM();
                    var dto = dataDtl.Find(x => x.itemcd == item.itemcd);
                    vmList.Add(GetVM(db, item, dto, datatypes, req.kinoid!));
                }
            }

            return vmList;
        }

        /// <summary>
        /// 抽出情報取得（全体）
        /// </summary>
        public static TyusyutuMainVM GetVM(DaDbContext db, tm_kktyusyutuDto mstDto, tt_kktaisyosya_tyusyutuDto? dataDto,
                                            List<tt_kktaisyosya_tyusyutu_subDto> subDataDtl, int? nendo, string tyusyutunaiyo)
        {
            var vm = new TyusyutuMainVM();

            vm.tyusyututaisyonm = mstDto.tyusyututaisyonm;
            vm.rptid = mstDto.rptid;
            vm.tyusyutunum = string.Format("{0:#,0}", subDataDtl.Select(e => e.atenano).Distinct().ToList().Count());

            //全体抽出参照モード／個別抽出抽出後
            if (dataDto != null && dataDto.regdttm != DateTime.MinValue)
            {
                vm.tyusyutunaiyo = dataDto.tyusyutunaiyo;
                vm.nendo = dataDto.nendo;
                vm.regdttm = FormatWaKjDttm(dataDto.regdttm);
            }
            //新規モード初期表示
            else
            {
                vm.nendo = nendo;                    //memochen KK01302Dの画面入力した抽出内容を設定
                vm.tyusyutunaiyo = tyusyutunaiyo;    //memochen KK01302Dの画面入力した抽出内容を設定
                vm.regdttm = string.Empty;
            }

            return vm;

        }

        /// <summary>
        /// 抽出結果取得
        /// </summary>
        public static ExtractVM GetVM(DataRowCollection rows)
        {
            ExtractVM vm = new ExtractVM();
            var result = rows.Count > 0 ? rows[0] : null;

            if (result == null)
            {
                return null!;
            }

            vm.messagetext = result.Wrap(nameof(ExtractVM.messagetext));
            vm.actresultkbn = CInt(result.Wrap(nameof(ExtractVM.actresultkbn)));
            vm.messageid = result.Wrap(nameof(ExtractVM.messageid));
            vm.tyusyutuseq = CLng(result.Wrap(nameof(ExtractVM.tyusyutuseq)));

            return vm;
        }

        /// <summary>
        /// 宛名情報取得
        /// </summary>
        public static AtenaVM GetVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new AtenaVM();
            vm.name = dto.simei_yusen;                                                                  //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                                      //カナ氏名
            vm.sex = DaNameService.GetName(db, EnumNmKbn.性別_システム共有, dto.sex);                   //性別
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);                  //住民区分
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);          //生年月日
            vm.age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd, DaUtil.Today);                  //年齢
            return vm;
        }

        /// <summary>
        /// 発券情報取得
        /// </summary>
        public static List<HakkenVM> GetVMList(DaDbContext db, tm_kktyusyutuDto mstDto, List<tt_kkhakkenDto> dtl)
        {
            var vmList = new List<HakkenVM>();

            if (dtl.Count > 0)
            {
                foreach (tt_kkhakkenDto dto in dtl)
                {
                    vmList.Add(GetVM(db, mstDto, dto));
                }
            }
            else
            {
                vmList.Add(GetVM(db, mstDto, null));
            }

            return vmList;
        }

        /// <summary>
        /// 発券情報取得（1検診）
        /// </summary>
        private static HakkenVM GetVM(DaDbContext db, tm_kktyusyutuDto mstDto, tt_kkhakkenDto? dataDto)
        {
            var vm = new HakkenVM();

            if (dataDto != null)
            {
                //既存の発券情報が存在する場合
                var maincd = mstDto.syosaikbnmaincd;
                var subcd = mstDto.syosaikbnsubcd;
                var dtl = DaHanyoService.GetHanyoDtl(db, maincd, subcd);
                var kensinsyubetunm = DaHanyoService.GetName(dtl, maincd, subcd, Enum名称区分.名称, dataDto.hakkendatasyosaikbn);
                vm.label = $"券番号({kensinsyubetunm})";
                vm.hakkenno = dataDto.hakkenno;
            }
            else
            {
                //既存の発券情報がない場合、空項目を一個追加
                vm.label = $"券番号(未抽出)";
                vm.hakkenno = "";
            }

            return vm;
        }


        /// <summary>
        /// 項目情報取得(1行)
        /// </summary>
        private static FreeItemTyusyutuVM GetVM(DaDbContext db, tm_kktaisyosya_tyusyutufreeitemDto mstDto, tt_kktaisyosya_tyusyutufreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid)
        {
            var vm = new FreeItemTyusyutuVM();
            //フリー項目の制御情報を初期化し、DB値を検索する
            vm = (FreeItemTyusyutuVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.対象者抽出, kinoid,
                                                                null, //事業コードパターンpatterno
                                                                dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                                mstDto.itemcd, mstDto.itemnm,
                                                                null, //グループ2
                                                                mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                                (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko,
                                                                null, //初期値
                                                                (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);

            //項目の入力タイプが年齢かどうか
            vm.isageflg = (Enum入力タイプ)mstDto.inputtype == Enum入力タイプ.年齢範囲＿抽出専用画面のみ使用可;

            return vm;
        }
        /// <summary>
        /// 発券情報が必要かどうかを取得
        /// </summary>
        public static bool GetHakkenSetting(DaDbContext db, tm_kktyusyutuDto dto)
        {
            return CBool(dto.hakkeninfoflg);
        }

        /// <summary>
        /// 抽出情報(一覧画面)1行
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM()
            {
                tyusyutuseq = row.CLng(nameof(RowVM.tyusyutuseq)),                                           //抽出シーケンス（全体のみデータあり）
                tyusyututaisyocd = row.Wrap(nameof(RowVM.tyusyututaisyocd)),                                 //抽出対象コード
                tyusyututaisyonm = row.Wrap(nameof(RowVM.tyusyututaisyonm)),                                 //抽出対象名
                nendo = row.CInt(nameof(RowVM.nendo)) == 9999 ? null : row.CInt(nameof(RowVM.nendo)),        //年度（年度管理されている場合）
                tyusyutunaiyo = row.Wrap(nameof(RowVM.tyusyutunaiyo)),                                       //抽出内容
                tyusyutunum = string.Format("{0:#,0}", row.CInt(nameof(RowVM.tyusyutunum))),                 //抽出人数
                regdttm = FormatWaKjDttm(row.CDate(nameof(RowVM.regdttm)))                                   //抽出日
            };

            return vm;
        }
    }
}