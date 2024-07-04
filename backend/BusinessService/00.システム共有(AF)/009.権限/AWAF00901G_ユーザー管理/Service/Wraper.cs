// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ユーザー管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWAF00901G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ユーザー情報一覧
        /// </summary>
        public static List<UserRowVM> GetVMList(DataRowCollection rows, int maxnum, bool flg, int days)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(r, maxnum, flg, days)).ToList();
        }

        /// <summary>
        /// 所属情報一覧
        /// </summary>
        public static List<SyozokuRowVM> GetVMList(DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(GetVM).ToList();
        }

        /// <summary>
        /// ユーザー情報(基本情報)
        /// </summary>
        public static UserInfoVM GetVM(DaDbContext db, Enum編集区分 kbn, tm_afuserDto dto, string userid, List<tm_afhanyoDto> dtl1, List<tt_afauthsisyoDto> dtl2, List<tt_afuser_sisyoDto> dtl3)
        {
            if (kbn == Enum編集区分.新規) return new UserInfoVM();

            var vm = new UserInfoVM();

            //所属
            if (!string.IsNullOrEmpty(dto.syozokucd))
            {
                vm.syozoku = DaSelectorService.GetCdNm(db, dto.syozokucd, Enum名称区分.名称, Enumマスタ区分.所属グループマスタ);
            }
            vm.authsetflg = dto.authsetflg;                                             //権限設定フラグ
            vm.stopflg = dto.stopflg;                                                   //使用停止フラグ
            vm.usernm = dto.usernm;                                                     //ユーザー名
            vm.yukoymdf = dto.yukoymdf;                                                 //有効年月日（開始）
            vm.yukoymdt = dto.yukoymdt;                                                 //有効年月日（終了）
            vm.errorkaisu = dto.errorkaisu ?? 0;                                        //ログインエラー回数
            vm.regsisyolist = dtl3.Select(e => GetSisyoVM(e.sisyocd, dtl1)).ToList();   //登録支所一覧

            vm.kanrisyaflg = dto.kanrisyaflg;                                           //管理者フラグ
            vm.pnoeditflg = dto.pnoeditflg;                                             //個人番号操作権限付与フラグ
            vm.alertviewflg = dto.alertviewflg;                                         //警告参照フラグ
            vm.editsisyolist = dtl2.Select(e => GetSisyoVM(e.sisyocd, dtl1)).ToList();  //更新可能支所一覧

            vm.kanrisyakeisyoflg = dto.kanrisyakeisyoflg;                               //管理者継承フラグ
            vm.pnoeditkeisyoflg = dto.pnoeditkeisyoflg;                                 //個人番号操作権限付与継承フラグ
            vm.alertviewkeisyoflg = dto.alertviewkeisyoflg;                             //警告参照継承フラグ
            vm.authsisyokeisyoflg = dto.authsisyokeisyoflg;                             //部署（支所）別更新権限継承フラグ

            vm.upddttm = dto.upddttm;                                                   //更新日時(排他用)

            return vm;
        }

        /// <summary>
        /// 所属グループ情報(基本情報)
        /// </summary>
        public static SyozokuInfoVM GetVM(Enum編集区分 kbn, tm_afsyozokuDto dto, string syozokucd, List<tm_afhanyoDto> dtl1, List<tt_afauthsisyoDto> dtl2, List<tm_afuserDto> dtl3, List<tm_afsyozokuDto> dtl4, int maxnum, bool flg, int days)
        {
            var vm = new SyozokuInfoVM();

            //全ユーザー情報一覧
            vm.userlist2 = dtl3.Select(e => GetVM(e, dto?.syozokucd, maxnum, flg, days, dtl4)).ToList();

            if (kbn == Enum編集区分.新規) return vm;

            vm.stopflg = dto.stopflg;                                                   //使用停止フラグ
            vm.syozokunm = dto.syozokunm;                                               //所属グループ名

            vm.kanrisyaflg = dto.kanrisyaflg;                                           //管理者フラグ
            vm.pnoeditflg = dto.pnoeditflg;                                             //個人番号操作権限付与フラグ
            vm.alertviewflg = dto.alertviewflg;                                         //警告参照フラグ
            vm.editsisyolist = dtl2.Select(e => GetSisyoVM(e.sisyocd, dtl1)).ToList();  //更新可能支所一覧

            //該当所属ユーザー情報一覧
            vm.userlist1 = vm.userlist2.Select(e => (UserRowVM)e).Where(e => e.syozokucd == syozokucd).ToList();

            vm.upddttm = dto.upddttm;                                                   //更新日時(排他用)

            return vm;
        }

        /// <summary>
        /// 画面機能権限情報一覧
        /// </summary>
        public static List<GamenVM> GetVMList(List<tm_afmenuDto> dtl1, List<tt_afauthgamenDto> dtl2)
        {
            var list = new List<GamenVM>();
            //画面権限データ
            var lst = dtl2.Where(d => d.programkbn == Enumプログラム区分.画面).ToList();

            foreach (var dto in dtl1)
            {
                list.Add(GetVM(dto, dtl2));
            }

            return list;
        }

        /// <summary>
        /// 共通機能権限情報一覧
        /// </summary>
        public static List<CmBarVM> GetVMList(List<tm_afmeisyoDto> dtl1, List<tt_afauthgamenDto> dtl2)
        {
            var list = new List<CmBarVM>();
            //共通機能権限データ
            var lst = dtl2.Where(d => d.programkbn == Enumプログラム区分.共通バー機能).ToList();
            //並び順
            dtl1 = dtl1.OrderBy(e => CInt(e.nmcd)).ToList();
            foreach (var dto in dtl1)
            {
                list.Add(GetVM(dto, dtl2));
            }

            return list;
        }

        /// <summary>
        /// 帳票権限情報一覧
        /// </summary>
        public static List<ReportVM> GetVMList(List<tm_eurptgroupDto> dtl1, List<tt_afauthreportDto> dtl2)
        {
            var list = new List<ReportVM>();
            foreach (var dto in dtl1)
            {
                list.Add(GetVM(dto, dtl2));
            }

            return list.OrderBy(e => CInt(e.repgroupid)).ToList();
        }

        /// <summary>
        /// 支所一覧(全支所)
        /// </summary>
        public static List<CmSisyoVM> GetVMList(List<tm_afhanyoDto> dtl)
        {
            var list = new List<CmSisyoVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetSisyoVM(dto.hanyocd, dtl));
            }

            return list.OrderBy(e => e.sisyocd).ToList();
        }

        /// <summary>
        /// 所属権限関連項目情報(画面所属変更再検索用)
        /// </summary>
        public static RoleAuthBaseVM GetVM(tm_afsyozokuDto dto, List<tm_afhanyoDto> dtl1, List<tt_afauthsisyoDto> dtl2)
        {
            var vm = new RoleAuthBaseVM();

            vm.kanrisyaflg = dto.kanrisyaflg;                                           //管理者フラグ
            vm.pnoeditflg = dto.pnoeditflg;                                             //個人番号操作権限付与フラグ
            vm.alertviewflg = dto.alertviewflg;                                         //警告参照フラグ
            vm.editsisyolist = dtl2.Select(e => GetSisyoVM(e.sisyocd, dtl1)).ToList();  //更新可能支所一覧

            return vm;
        }

        /// <summary>
        /// ユーザー状態取得
        /// </summary>
        public static Enumユーザー状態 GetStatus(bool stopflg, int? errorkaisu, DateTime yukoymdf, DateTime yukoymdt, DateTime pwdymd, int maxnum, bool flg, int days)
        {
            //使用停止の場合
            if (stopflg) return Enumユーザー状態.停止;

            //パスワードエラー回数上限を超えて、ロックになる場合
            if (errorkaisu >= maxnum) return Enumユーザー状態.ロック;

            //アカウント無効またはパスワード無効の場合
            var today = DaUtil.Today;
            if ((yukoymdf > today || yukoymdt < today) || (flg && days > 0 && today > pwdymd.AddDays(days - 1))) return Enumユーザー状態.無効;

            return Enumユーザー状態.正常;
        }

        /// <summary>
        /// ユーザー情報(1行)
        /// </summary>
        private static UserRowVM GetVM(DataRow row, int maxnum, bool flg, int days)
        {
            var vm = new UserRowVM();

            vm.userid = row.Wrap(nameof(tm_afuserDto.userid));          //ユーザーID
            vm.usernm = row.Wrap(nameof(tm_afuserDto.usernm));          //ユーザー名
            vm.syozokucd = row.Wrap(nameof(tm_afuserDto.syozokucd));    //所属グループコード
            vm.syozokunm = row.Wrap(nameof(tm_afsyozokuDto.syozokunm)); //所属グループ名
            var yukoymdf = row.CDate(nameof(tm_afuserDto.yukoymdf));
            vm.yukoymdf = FormatWaKjYMD(yukoymdf);                      //有効年月日（開始）
            var yukoymdt = row.CDate(nameof(tm_afuserDto.yukoymdt));
            vm.yukoymdt = FormatWaKjYMD(yukoymdt);                      //有効年月日（終了）
            //使用停止フラグ
            var stopflg = row.CBool(nameof(tm_afuserDto.stopflg));
            //ログインエラー回数
            var errorkaisu = row.CInt(nameof(tm_afuserDto.errorkaisu));
            //パスワード変更日
            var pwordhenkoymd = row.CDate(nameof(tm_afuserDto.pwordhenkoymd));
            //状態取得
            var status = GetStatus(stopflg, errorkaisu, yukoymdf, yukoymdt, pwordhenkoymd, maxnum, flg, days);
            vm.status = status.ToString();                              //状態

            return vm;
        }

        /// <summary>
        /// 所属情報(1行)
        /// </summary>
        private static SyozokuRowVM GetVM(DataRow row)
        {
            var vm = new SyozokuRowVM();
            vm.syozokucd = row.Wrap(nameof(tm_afsyozokuDto.syozokucd)); //所属グループID
            vm.syozokunm = row.Wrap(nameof(tm_afsyozokuDto.syozokunm)); //所属グループ名
            return vm;
        }

        /// <summary>
        /// ユーザー情報(1行)
        /// </summary>
        private static UserDetailVM GetVM(tm_afuserDto dto, string? syozokucd, int maxnum, bool flg, int days, List<tm_afsyozokuDto> dtl)
        {
            var vm = new UserDetailVM();

            vm.userid = dto.userid;                     //ユーザーID
            vm.usernm = dto.usernm;                     //ユーザー名

            var syozokuDto = dtl.Find(e => e.syozokucd == dto.syozokucd);
            if (!string.IsNullOrEmpty(syozokuDto?.syozokucd))
            {
                vm.syozokucd = syozokuDto.syozokucd;    //所属グループコード
                vm.syozokunm = syozokuDto.syozokunm;    //所属グループ名
            }
            var yukoymdf = CDate(dto.yukoymdf);
            vm.yukoymdf = FormatWaKjYMD(yukoymdf);      //有効年月日（開始）
            var yukoymdt = CDate(dto.yukoymdt);
            vm.yukoymdt = FormatWaKjYMD(yukoymdt);      //有効年月日（終了）
            //使用停止フラグ
            var stopflg = dto.stopflg;
            //ログインエラー回数
            var errorkaisu = dto.errorkaisu;
            //パスワード変更日
            var pwordhenkoymd = CDate(dto.pwordhenkoymd);
            //状態取得
            var status = GetStatus(stopflg, errorkaisu, yukoymdf, yukoymdt, pwordhenkoymd, maxnum, flg, days);
            vm.status = status.ToString();              //状態

            //編集フラグ
            if (!string.IsNullOrEmpty(vm.syozokucd) && (vm.syozokucd != syozokucd))
            {
                vm.editflg = false;
            }
            else
            {
                vm.editflg = true;
            }

            return vm;
        }

        /// <summary>
        /// 画面機能権限情報(1行)
        /// </summary>
        private static GamenVM GetVM(tm_afmenuDto dto, List<tt_afauthgamenDto> authDtl)
        {
            //DB対応権限データを取得
            var authDto = authDtl.Find(a => a.kinoid == dto.kinoid);

            var vm = new GamenVM();

            vm.kinoid = dto.kinoid;                                                       //機能ID
            vm.programkbn = Enumプログラム区分.画面;                                            //プログラム区分
            vm.viewflg = authDto != null;                                                       //アクセス権限フラグ
            vm.addflg = dto.addctrlflg ? authDto is { addflg: true } : null;                    //追加権限フラグ
            vm.updflg = dto.updctrlflg ? authDto is { updateflg: true } : null;                 //修正権限フラグ
            vm.delflg = dto.delctrlflg ? authDto is { deleteflg: true } : null;                 //削除権限フラグ
            vm.personalnoflg = dto.pnousectrlflg ? authDto is { personalnoflg: true } : null;   //個人番号利用権限フラグ
            if (authDto == null)
            {
                vm.keisyoflg = null;                                                            //継承可能フラグ
            }
            //DBデータがある場合、排他必要
            else
            {
                vm.keisyoflg = authDto.keisyoflg;                                               //継承可能フラグ
                vm.upddttm = authDto.upddttm;                                                   //更新日時(排他用)
            }
            return vm;
        }

        /// <summary>
        /// 共通機能権限情報(1行)
        /// </summary>
        private static CmBarVM GetVM(tm_afmeisyoDto dto, List<tt_afauthgamenDto> authDtl)
        {
            //DB対応権限データを取得
            var authDto = authDtl.Find(a => a.kinoid == dto.hanyokbn1);

            var vm = new CmBarVM();

            vm.kinoid = dto.hanyokbn1!;                                                  //機能ID
            vm.programkbn = Enumプログラム区分.共通バー機能;                                //プログラム区分
            vm.kinonm = dto.nm;                                                             //機能名
            vm.viewflg = authDto != null;                                                   //アクセス権限フラグ
            var auths = dto.hanyokbn2!.Split(DaStrPool.COMMA);
            vm.addflg = CBool(auths[0]) ? authDto is { addflg: true } : null;               //追加権限フラグ
            vm.updflg = CBool(auths[1]) ? authDto is { updateflg: true } : null;            //修正権限フラグ
            vm.delflg = CBool(auths[2]) ? authDto is { deleteflg: true } : null;            //削除権限フラグ
            vm.personalnoflg = CBool(auths[3]) ? authDto is { personalnoflg: true } : null; //個人番号利用権限フラグ
            if (authDto == null)
            {
                vm.keisyoflg = null;                                                        //継承可能フラグ
            }
            //DBデータがある場合、排他必要
            else
            {
                vm.keisyoflg = authDto.keisyoflg;                                           //継承可能フラグ
                vm.upddttm = authDto.upddttm;                                               //更新日時(排他用)
            }
            return vm;
        }

        /// <summary>
        /// 帳票権限情報(1行)
        /// </summary>
        private static ReportVM GetVM(tm_eurptgroupDto dto, List<tt_afauthreportDto> authDtl)
        {
            //DB対応権限データを取得
            var authDto = authDtl.Find(a => a.repgroupid == dto.rptgroupid);

            var vm = new ReportVM();

            vm.repgroupid = dto.rptgroupid;                             //帳票グループID
            vm.reportgroupnm = $"{dto.rptgroupid}　{dto.rptgroupnm}";   //帳票グループ名
            vm.viewflg = authDto != null;                               //アクセス権限

            //TODO
            //vm.tutisyooutflg = authDto is { tutisyooutflg: true };      //通知書出力フラグ
            vm.pdfoutflg = authDto is { pdfoutflg: true };              //PDF出力フラグ
            vm.exceloutflg = authDto is { exceloutflg: true };          //EXCEL出力フラグ
            vm.othersflg = authDto is { othersflg: true };              //その他出力フラグ
            //TODO
            //vm.personalnoflg = authDto is { personalnoflg: true };      //個人番号利用フラグ
            if (authDto == null)
            {
                vm.keisyoflg = null;                                    //継承可能フラグ
            }
            //DBデータがある場合、排他必要
            else
            {
                vm.keisyoflg = authDto.keisyoflg;                       //継承可能フラグ
                vm.upddttm = authDto.upddttm;                           //更新日時(排他用)
            }
            return vm;
        }

        /// <summary>
        /// 支所リスト取得
        /// </summary>
        private static CmSisyoVM GetSisyoVM(string sisyocd, List<tm_afhanyoDto> sisyoDtl)
        {
            var vm = new CmSisyoVM();
            vm.sisyocd = sisyocd;                                                       //支所コード
            vm.sisyonm = sisyoDtl.Find(s => s.hanyocd == sisyocd)?.nm ?? string.Empty;  //支所名
            return vm;
        }
    }
}