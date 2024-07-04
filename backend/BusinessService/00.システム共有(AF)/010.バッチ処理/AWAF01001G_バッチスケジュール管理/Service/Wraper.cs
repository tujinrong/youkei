// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチスケジュール管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.BatchService;
using BCC.Affect.Service.AWKK00111G;
using NPOI.SS.Formula.Functions;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWAF01001G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// バッチスケジュール情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// バッチスケジュール情報(詳細画面)
        /// </summary>
        public static MainInfoVM GetShosaiVM(DaDbContext db, tm_aftaskscheduleDto dto)
        {
            var vm = new MainInfoVM();

            vm.taskid = dto.taskid;                                                         //タスクID         
            vm.zenjikkodttmf = dto.zenjikkodttmf;                                           //前回の実行日時（開始）
            vm.zenjikkodttmt = dto.zenjikkodttmt;                                           //前回の実行日時（終了）
            vm.jotai = string.IsNullOrEmpty(dto.renkeiid) ? "3" : dto.stopflg ? "2" : "1";  //状態
            vm.tasknm = dto.tasknm;                                                         //タスク名
            vm.statuscd = MNm(db, AiDataUtil.Nz(dto.statuscd), EnumNmKbn.処理結果コード);   //処理結果  
            vm.syorikbn = dto.syorikbn;                                                     //処理区分 
            vm.gyomukbn = dto.gyomukbn;                                                     //業務区分
            vm.biko = dto.biko;                                                             //説明
            vm.modulecd = dto.modulecd;                                                     //モジュール名
            vm.hikisu = dto.hikisu;                                                         //引数
            vm.yukoymdf = dto.yukoymdf;                                                     //有効年月日
            vm.yukotmf = FormatTime(dto.yukotmf);                                           //開始時刻
            vm.hindokbn = dto.hindokbn;                                                     //頻度区分
            vm.kurikaesikanflg = dto.kurikaesikanflg;                                       //繰り返し間隔フラグ
            vm.kurikaesikankbn = dto.kurikaesikankbn;                                       //繰り返し間隔区分
            vm.jikantaif = dto.jikantaif;                                                   //時間帯開始_時
            vm.jikantait = dto.jikantait;                                                   //時間帯終了_時
            vm.jikannaif = dto.jikannaif;                                                   //時間内開始_分
            vm.jikannait = dto.jikannait;                                                   //時間内終了_分

            //頻度詳細を設定する
            SetHindosyosai(vm, dto);
            return vm;
        }

        /// <summary>
        /// バッチスケジュール情報(一覧画面)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();

            vm.taskid = row.Wrap(nameof(tm_aftaskscheduleDto.taskid));                            //タスクID
            vm.tasknm = row.Wrap(nameof(tm_aftaskscheduleDto.tasknm));                            //タスク名
            vm.syorikbn = MNm(db, row.Wrap(nameof(tm_aftaskscheduleDto.syorikbn)), EnumNmKbn.連携処理区分);                           //処理区分
            vm.gyomukbn = MNm(db, row.Wrap(nameof(tm_aftaskscheduleDto.gyomukbn)), EnumNmKbn.システム業務区分);                        //業務区分
            vm.jikkohindo = MNm(db, row.Wrap(nameof(tm_aftaskscheduleDto.hindokbn)), EnumNmKbn.頻度区分);                             //頻度

            vm.hindosyosai = GetHindo(db, row);                                                   //頻度詳細
            vm.jikaijikkodttmt = string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.jikaijikkodttmt)).ToString()) ? "なし" : FormatWaKjDttm(row.CDate(nameof(tm_aftaskscheduleDto.jikaijikkodttmt)));
            vm.syoridttmt = string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.zenjikkodttmf)).ToString()) ? "なし" : FormatWaKjDttm(CNDate(row.CDate(nameof(tm_aftaskscheduleDto.zenjikkodttmf)))); //処理日時（開始）
            vm.statuscd = MNm(db, row.Wrap(nameof(tm_aftaskscheduleDto.statuscd)), EnumNmKbn.処理結果コード);           //処理結果コード
            vm.colorkbn = (Enum表示色区分)CInt(DaNameService.GetKbn1(db, EnumNmKbn.処理結果コード, row.Wrap(nameof(tm_aftaskscheduleDto.statuscd))));  //処理結果表示色区分
            vm.jotai = string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.renkeiid))) ? "未登録" :
                                MNm(db, BoolToStr(row.CBool(nameof(tm_aftaskscheduleDto.stopflg))), EnumNmKbn.停止フラグ);       //状態
            return vm;

        }

        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        private static string MNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 頻度詳細を設定する
        /// </summary>
        /// <param name="vm"></param>
        private static void SetHindosyosai(MainInfoVM vm, tm_aftaskscheduleDto dto)
        {
            //初期化
            InitVM(vm);

            switch (vm.hindokbn)
            {
                //0：一回のみ
                case "0":

                    return;
                //1：毎日
                case "1":
                    vm.syukustopflg = dto.syukustopflg;                                             //祝日停止フラグ
                    return;
                //2：毎週
                case "2":
                    vm.sunday = GetYobi(dto.yobi, 1);                                               //曜日(日)
                    vm.monday = GetYobi(dto.yobi, 2);                                               //曜日(月)
                    vm.tuesday = GetYobi(dto.yobi, 3);                                              //曜日(火)
                    vm.wednesday = GetYobi(dto.yobi, 4);                                            //曜日(水)
                    vm.thursday = GetYobi(dto.yobi, 5);                                             //曜日(木)
                    vm.friday = GetYobi(dto.yobi, 6);                                               //曜日(金)
                    vm.saturday = GetYobi(dto.yobi, 7);                                             //曜日(土)
                    vm.syukustopflg = dto.syukustopflg;                                             //祝日停止フラグ
                    return;
                //3：毎月
                case "3":
                    vm.maitukituki = StringConvertCdList(dto.maitukituki);                          //毎月の月
                    vm.maitukihiyobikbn = dto.maitukihiyobikbn;                                     //毎月の日・曜日区分
                                                                                                    //毎月の日・曜日区分：日の場合
                    if (vm.maitukihiyobikbn == "0")
                    {
                        vm.maitukihi = StringConvertCdList(dto.maitukihi);                          //毎月の日
                    }
                    else
                    {
                        vm.maitukisyu = StringConvertCdList(dto.maitukisyu, false);                 //毎月の週
                        vm.yobi = StringConvertCdList(dto.yobi, false);                             //毎月の週の曜日
                    }
                    vm.syukustopflg = dto.syukustopflg;                                             //祝日停止フラグ
                    return;
                //上記以外
                default:
                    return;
            }
        }

        /// <summary>
        /// 曜日を取得する
        /// </summary>
        private static bool? GetYobi(string? yobi, int location)
        {
            if (string.IsNullOrEmpty(yobi))
            {
                return false;
            }

            return yobi[location - 1] == '1';
        }

        /// <summary>
        /// 詳細画面の項目
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="idx"></param>
        private static void InitVM(MainInfoVM vm)
        {
            vm.syukustopflg = false;                     //祝日停止フラグ
            vm.monday = false;                           //曜日(月)
            vm.tuesday = false;                          //曜日(火)
            vm.wednesday = false;                        //曜日(水)
            vm.thursday = false;                         //曜日(木)
            vm.friday = false;                           //曜日(金)
            vm.saturday = false;                         //曜日(土)
            vm.sunday = false;                           //曜日(日)
            vm.maitukituki = new string[] { };           //毎月の月
            vm.maitukihiyobikbn = "0";                   //毎月の日・曜日区分
            vm.maitukihi = new string[] { };             //毎月の日
            vm.maitukisyu = new string[] { };            //毎月の週
            vm.yobi = new string[] { };                  //毎月の曜日
        }

        /// <summary>
        /// 位数の連結
        /// </summary>
        private static string[] StringConvertCdList(string? value, bool padKbn = true)
        {
            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '1')
                    {
                        if (!padKbn)
                        {
                            list.Add((i + 1).ToString());
                        }
                        else
                        {
                            list.Add((i + 1).ToString().PadLeft(2, '0'));
                        }

                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 頻度詳細を設定する
        /// </summary>
        private static string GetHindo(DaDbContext db, DataRow row)
        {
            var yukotmf = FormatTime(row.Wrap(nameof(tm_aftaskscheduleDto.yukotmf)));
            string hindoshosai = string.Empty;
            //一覧、頻度詳細
            if (row.Wrap(nameof(tm_aftaskscheduleDto.hindokbn ))== "0") //一回のみの場合
            {
                hindoshosai = row.Wrap(nameof(tm_aftaskscheduleDto.yukoymdf)) + " " + yukotmf + "に起動";


            }
            else if (row.Wrap(nameof(tm_aftaskscheduleDto.hindokbn)) == "1") //毎日の場合
            {
                hindoshosai = string.Format("毎日 {0}に起動", yukotmf);


            }
            else if (row.Wrap(nameof(tm_aftaskscheduleDto.hindokbn)) == "2")//毎週の場合
            {
                var yobilist = DaNameService.GetSelectorList(db, EnumNmKbn.曜日, Enum名称区分.名称);
                //(「,」区切り)
                var strlist = string.Join(",", StringConvertList(row.Wrap(nameof(tm_aftaskscheduleDto.yobi)), yobilist));
                hindoshosai = string.Format("{0} 以後毎週{1}、{2}に起動", row.Wrap(nameof(tm_aftaskscheduleDto.yukoymdf)), strlist,yukotmf);

            }
            else if (row.Wrap(nameof(tm_aftaskscheduleDto.hindokbn ))== "3")//毎月の場合
            {
                var maitukilist = DaNameService.GetSelectorList(db, EnumNmKbn.月, Enum名称区分.名称);
                var strlist = string.Join(",", StringConvertList(row.Wrap(nameof(tm_aftaskscheduleDto.maitukituki)), maitukilist));
                if (row.Wrap(nameof(tm_aftaskscheduleDto.maitukihiyobikbn)) == "0")   //日
                {
                    var maitukihilist = DaNameService.GetSelectorList(db, EnumNmKbn.日, Enum名称区分.名称);
                    var histrlist = string.Join(",", StringConvertList(row.Wrap(nameof(tm_aftaskscheduleDto.maitukihi)), maitukihilist));
                    hindoshosai = string.Format("{0} 以後の{1}の{2}、{3}に起動", row.Wrap(nameof(tm_aftaskscheduleDto.yukoymdf)), strlist, histrlist, yukotmf);
                }
                else
                {
                    var maitukisyuList = DaNameService.GetSelectorList(db, EnumNmKbn.週目, Enum名称区分.名称);
                    var maitukisyuStrList = string.Join(",", StringConvertList(row.Wrap(nameof(tm_aftaskscheduleDto.maitukisyu)), maitukisyuList));
                    var yobiList = DaNameService.GetSelectorList(db, EnumNmKbn.曜日, Enum名称区分.名称);
                    var yobiStrList = string.Join(",", StringConvertList(row.Wrap(nameof(tm_aftaskscheduleDto.yobi)), yobiList));
                    hindoshosai = string.Format("月：{0}、週: {1}、日: {2}に起動、開始日: {3}", strlist, maitukisyuStrList, yobiStrList, row.Wrap(nameof(tm_aftaskscheduleDto.yukoymdf)));

                }

            }
            if (row.CBool(nameof(tm_aftaskscheduleDto.kurikaesikanflg)))
            {
                //設定頻度詳細のメッセージ
                hindoshosai = SetHindoMsg(db, row, hindoshosai);

            }
            //祝日
            if (row.CBool(nameof(tm_aftaskscheduleDto.syukustopflg)))
            {
                hindoshosai = hindoshosai + " 祝日停止";
            }
            return hindoshosai;

        }
        /// <summary>
        /// 頻度詳細のメッセージを設定する
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="hindoshosai"></param>
        private static string SetHindoMsg(DaDbContext db, DataRow row, string hindoshosai)
        {
            var kurikaesikankbn = DaSelectorService.GetName(db, row.Wrap(nameof(tm_aftaskscheduleDto.kurikaesikankbn)), Enum名称区分.名称,
                            Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.繰り返し間隔));     //繰り返し間隔

            string jikantai = string.Empty;
            string jikannai = string.Empty;
            if (!string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.jikantaif))))
            {
                jikantai = string.Format("{0}", row.Wrap(nameof(tm_aftaskscheduleDto.jikantaif)) + "時");

            }
            if (!string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.jikantait))) && !string.IsNullOrEmpty(jikantai))
            {
                jikantai = jikantai + "～" + row.Wrap(nameof(tm_aftaskscheduleDto.jikantait)) + "時";
            }
            else
            {
                jikantai = string.Format("{0}", row.Wrap(nameof(tm_aftaskscheduleDto.jikantait)) + "時");
            }

            if (!string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.jikannaif))))
            {
                jikannai = string.Format("{0}", row.Wrap(nameof(tm_aftaskscheduleDto.jikannaif)) + "分");

            }
            if (!string.IsNullOrEmpty(row.Wrap(nameof(tm_aftaskscheduleDto.jikannait))) && !string.IsNullOrEmpty(jikannai))
            {
                jikannai = jikannai + "～" + row.Wrap(nameof(tm_aftaskscheduleDto.jikannait)) + "分";
            }
            else
            {
                jikannai = string.Format("{0}", row.Wrap(nameof(tm_aftaskscheduleDto.jikannait)) + "分");
            }

            string str = string.Format(" - トリガーされた後、{0}の{1}の間{2}ごとに実行されます。", jikantai, jikannai, kurikaesikankbn);
            hindoshosai = hindoshosai + str;


            return hindoshosai;
        }

        /// <summary>
        /// 取得した名前を文字列に連結する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valuelist"></param>
        /// <returns></returns>
        private static List<string> StringConvertList(string? value, List<DaSelectorModel> valuelist)
        {
            var strList = new List<string>();
            if (valuelist.Count <= 0 || string.IsNullOrEmpty(value))
            {
                return strList;
            }

            for (int i = 0; i < value.Length; i++)
            {
                //1つだけの場合は連結する
                if (value[i] == '1')
                {
                    strList.Add(valuelist[i].label);
                }
            }

            return strList;
        }
    }
}