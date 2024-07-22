// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.24
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00401G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// フォロー管理一覧情報取得
        /// </summary>
        public static List<RowFollowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// フォロー管理内容一覧情報取得
        /// </summary>
        public static List<RowFollowContentVM> GetFollowContentVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetFollowContentVM(db, r)).ToList();
        }

        /// <summary>
        /// フォロー管理結果一覧情報取得
        /// </summary>
        public static List<RowFollowKekkaVM> GetFollowKekkaDetailVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetFollowKekkaDetailVM(db, r)).ToList();
        }

        /// <summary>
        /// フォロー管理一覧情報(1行)
        /// </summary>
        private static RowFollowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new RowFollowVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                                                             //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                                                            //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                                                      //カナ氏名
            vm.sex = DaNameService.GetName(db, EnumNmKbn.性別_システム共有,
                                    row.Wrap(nameof(tt_afatenaDto.sex)));                                                     //性別
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                                                                   //住民区分
            vm.bymd = CmLogicUtil.GetBymd(row);                                                                               //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                                                                      //住所
            vm.followyoteiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap(nameof(tt_kkfollowyoteiDto.followyoteiymd))));     //フォロー予定日
            vm.followjissiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap(nameof(tt_kkfollowkekkaDto.followjissiymd))));     //フォロー実施日
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));                                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);                                               //警告内容

            return vm;
        }

        /// <summary>
        /// フォロー管理内容情報取得(一覧)
        /// </summary>
        private static RowFollowContentVM GetFollowContentVM(DaDbContext db, DataRow row)
        {
            var vm = new RowFollowContentVM();
            vm.follownaiyoedano = CInt(row.Wrap($"{nameof(vm.follownaiyoedano)}_naiyo"));                                                       //フォロー内容枝番
            vm.haakukeiro = DaNameService.GetName(db, EnumNmKbn.把握経路_フォロー状況情報, row.Wrap($"{nameof(vm.haakukeiro)}_naiyo"));         //把握経路
            var haakujigyocd = row.Wrap($"{nameof(vm.haakujigyocd)}_naiyo");
            vm.haakujigyocd = string.IsNullOrEmpty(haakujigyocd) ?
                              string.Empty : DaHanyoService.GetName(db, EnumHanyoKbn.フォロー把握事業コード, Enum名称区分.名称, haakujigyocd);  //把握事業
            vm.follownaiyo = row.Wrap($"{nameof(vm.follownaiyo)}_naiyo");                                                                       //フォロー内容 
            vm.followstatus = DaNameService.GetName(db, EnumNmKbn.フォロー状況, row.Wrap($"{nameof(vm.followstatus)}_naiyo"));                  //フォロー状況
            var followjigyocd = row.Wrap($"{nameof(vm.followjigyocd)}_naiyo");
            vm.followjigyocd = string.IsNullOrEmpty(followjigyocd) ?
                               string.Empty : DaHanyoService.GetName(db, EnumHanyoKbn.フォロー事業コード, Enum名称区分.名称, followjigyocd);    //フォロー事業
            vm.followyoteiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followyoteiymd)}_naiyo")));                             //フォロー予定情報  予定日
            vm.followtm_yotei = row.Wrap($"{nameof(vm.followtm_yotei)}_naiyo");                                                                 //フォロー予定情報  時間
            vm.followkaijocd_yotei = row.Wrap($"{nameof(vm.followkaijocd_yotei)}_naiyo");                                                       //フォロー予定情報  会場
            vm.followstaffid_yotei = row.Wrap($"{nameof(vm.followstaffid_yotei)}_naiyo");                                                       //フォロー予定情報  担当者
            vm.followjissiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followjissiymd)}_naiyo")));                             //フォロー結果情報  実施日
            vm.followtm = row.Wrap($"{nameof(vm.followtm)}_naiyo");                                                                             //フォロー結果情報  時間
            vm.followkaijocd = row.Wrap($"{nameof(vm.followkaijocd)}_naiyo");                                                                   //フォロー結果情報  会場
            vm.followstaffid = row.Wrap($"{nameof(vm.followstaffid)}_naiyo");                                                                   //フォロー結果情報  担当者

            return vm;
        }

        /// <summary>
        /// フォロー内容情報取得(結果画面)
        /// </summary>
        public static RowFollowKekkaVM GetFollowKekkaVM(DaDbContext db, tt_kkfollownaiyoDto? dto, tt_kkfollowkekkaDto? dto2, List<string> sisyoList)

        {
            var vm = new RowFollowKekkaVM();
            vm.atenano = CStr(dto?.atenano);                                                                                                      //宛名番号
            vm.follownaiyoedano = CInt(dto?.follownaiyoedano);                                                                                    //フォロー内容枝番
            vm.haakukeiro = DaNameService.GetCdNm(db, EnumNmKbn.把握経路_フォロー状況情報, Enum名称区分.名称, CStr(dto?.haakukeiro));             //把握経路
            var haakujigyocd = dto?.haakujigyocd;
            vm.haakujigyocd = string.IsNullOrEmpty(haakujigyocd) ?
                              string.Empty : DaHanyoService.GetCdNm(db, EnumHanyoKbn.フォロー把握事業コード, Enum名称区分.名称, haakujigyocd);    //把握事業
            vm.followstatus = DaNameService.GetCdNm(db, EnumNmKbn.フォロー状況, Enum名称区分.名称, CStr(dto?.followstatus));                      //フォロー状況
            vm.follownaiyo = dto?.follownaiyo;                                                                                                    //フォロー内容 
            vm.upddttm = dto?.upddttm;                                                                                                            //更新日時(排他も利用)
            var regsisyo = dto?.regsisyo;                                                                                                         //登録支所
            //更新権限フラグ                                                                                                              
            vm.updflg = string.IsNullOrEmpty(regsisyo) || sisyoList.Contains(regsisyo);

            return vm;
        }

        /// <summary>
        /// フォロー管理結果情報取得(一覧)
        /// </summary>
        private static RowFollowKekkaVM GetFollowKekkaDetailVM(DaDbContext db, DataRow row)
        {
            var vm = new RowFollowKekkaVM();
            vm.atenano = row.Wrap($"{nameof(vm.atenano)}_kekka");                                                                              //宛名番号
            vm.follownaiyoedano = CInt(row.Wrap($"{nameof(vm.follownaiyoedano)}_kekka"));                                                      //フォロー内容枝番
            vm.edano = CInt(row.Wrap($"{nameof(vm.edano)}_kekka"));                                                                            //枝番

            var followjigyocd = row.Wrap($"{nameof(vm.followjigyocd)}_kekka");
            vm.followjigyocd = string.IsNullOrEmpty(followjigyocd) ?
                               string.Empty : DaHanyoService.GetName(db, EnumHanyoKbn.フォロー事業コード, Enum名称区分.名称, followjigyocd);   //フォロー事業
            vm.followhoho_yotei = DaNameService.GetName(db, EnumNmKbn.フォロー方法, row.Wrap($"{nameof(vm.followhoho_yotei)}_kekka"));         //フォロー予定情報  方法
            vm.followyoteiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followyoteiymd)}_kekka")));                            //フォロー予定情報  予定日
            vm.followtm_yotei = row.Wrap($"{nameof(vm.followtm_yotei)}_kekka");                                                                //フォロー予定情報  時間
            vm.followkaijocd_yotei = row.Wrap($"{nameof(vm.followkaijocd_yotei)}_kekka");                                                      //フォロー予定情報  会場
            vm.followstaffid_yotei = row.Wrap($"{nameof(vm.followstaffid_yotei)}_kekka");                                                      //フォロー予定情報  担当者
            vm.followriyu = row.Wrap($"{nameof(vm.followriyu)}_kekka");                                                                        //フォロー予定情報  理由
            vm.followhoho = DaNameService.GetName(db, EnumNmKbn.フォロー方法, row.Wrap($"{nameof(vm.followhoho)}_kekka"));                     //フォロー結果情報  方法
            vm.followjissiymd = DaFormatUtil.FormatWaKjYMD(CNDate(row.Wrap($"{nameof(vm.followjissiymd)}_kekka")));                            //フォロー結果情報  実施日
            vm.followtm = row.Wrap($"{nameof(vm.followtm)}_kekka");                                                                            //フォロー結果情報  時間
            vm.followkaijocd = row.Wrap($"{nameof(vm.followkaijocd)}_kekka");                                                                  //フォロー結果情報  会場
            vm.followstaffid = row.Wrap($"{nameof(vm.followstaffid)}_kekka");                                                                  //フォロー結果情報  担当者
            vm.followkekka = row.Wrap($"{nameof(vm.followkekka)}_kekka");                                                                      //フォロー結果情報  フォロー結果

            return vm;
        }

        /// <summary>
        /// フォロー管理詳細情報取得
        /// </summary>
        public static FollowDetailVM GetFollowDetailNaiyoVM(DaDbContext db, tt_kkfollownaiyoDto dto, int sinkiEdano)
        {
            var vm = new FollowDetailVM();
            vm.atenano = dto.atenano;                                                                                                           //宛名番号                                                                   
            vm.follownaiyoedano = dto.follownaiyoedano;                                                                                         //フォロー内容枝番
            vm.haakukeiro = DaNameService.GetCdNm(db, EnumNmKbn.把握経路_フォロー状況情報, Enum名称区分.名称, CStr(dto?.haakukeiro));           //把握経路
            var haakujigyocd = dto?.haakujigyocd;
            vm.haakujigyocd = string.IsNullOrEmpty(haakujigyocd) ?
                              string.Empty : DaHanyoService.GetCdNm(db, EnumHanyoKbn.フォロー把握事業コード, Enum名称区分.名称, haakujigyocd);  //把握事業
            vm.follownaiyo = CStr(dto?.follownaiyo);                                                                                            //フォロー内容 
            vm.sinkiEdano = sinkiEdano;                                                                                                         //最大枝番
            vm.edano = sinkiEdano;

            return vm;
        }

        /// <summary>
        /// フォロー管理詳細情報取得
        /// </summary>
        public static FollowDetailVM GetFollowDetailVM(DaDbContext db, tt_kkfollownaiyoDto dto, tt_kkfollowyoteiDto dto2
                                                        , tt_kkfollowkekkaDto dto3, List<string> sisyoList, List<tm_afhanyoDto> dtl1
                                                        , int sinkiEdano, FollowDetailVM followdetailvm)
        {
            //既存のVMを初期化
            var vm = followdetailvm;
            vm.atenano = dto.atenano;                                                                                                      　　 //宛名番号
            vm.follownaiyoedano = dto.follownaiyoedano;                                                                                    　　 //フォロー内容枝番
            vm.edano = dto2.edano == 0 ? dto3.edano : dto2.edano;                                                                          　　 //枝番
            vm.haakukeiro = DaNameService.GetCdNm(db, EnumNmKbn.把握経路_フォロー状況情報, Enum名称区分.名称, dto.haakukeiro);             　　 //把握経路
            var haakujigyocd = dto.haakujigyocd;
            vm.haakujigyocd = string.IsNullOrEmpty(haakujigyocd) ?
                              string.Empty : DaHanyoService.GetCdNm(db, EnumHanyoKbn.フォロー把握事業コード, Enum名称区分.名称, haakujigyocd);  //把握事業
            vm.follownaiyo = CStr(dto.follownaiyo);                                                                                             //フォロー内容 
            vm.sinkiEdano = sinkiEdano;                                                                                                         //最大枝番
            var followjigyocd = dto2.followjigyocd;
            vm.followjigyocd = string.IsNullOrEmpty(followjigyocd) ?
                               "" : DaHanyoService.GetCdNm(db, EnumHanyoKbn.フォロー事業コード, Enum名称区分.名称, followjigyocd);              //フォロー事業
            vm.followhoho_yotei = DaNameService.GetCdNm(db, EnumNmKbn.フォロー方法, Enum名称区分.名称, CStr(dto2.followhoho));                  //フォロー予定情報 フォロー方法
            vm.followyoteiymd = dto2.followyoteiymd;                                                                                            //フォロー予定情報  予定日
            vm.followtm_yotei = dto2.followtm;                                                                                                  //フォロー予定情報  時間
            var followkaijocd_yotei = dto2.followkaijocd;
            var kaijocd_yoteinm = string.IsNullOrEmpty(followkaijocd_yotei) ? "" : db.tm_afkaijo.GetDtoByKey(followkaijocd_yotei).kaijonm;
            vm.followkaijocd_yotei = string.IsNullOrEmpty(followkaijocd_yotei) ?
                                    "" : $"{followkaijocd_yotei}{DaConst.SELECTOR_DELIMITER}{kaijocd_yoteinm}";                                 //フォロー予定情報  会場
            vm.followstaffid_yotei = dto2.followstaffid;                                                                                        //フォロー予定情報  担当者
            var dtoafstaff_yotei = db.tm_afstaff.GetDtoByKey(CStr(dto2.followstaffid));
            vm.followstaffid_yoteinm = dtoafstaff_yotei?.staffsimei;                                                                            //フォロー予定情報  担当者名称
            vm.followriyu = dto2.followriyu;                                                                                                    //フォロー予定情報  理由
            vm.followhoho = DaNameService.GetCdNm(db, EnumNmKbn.フォロー方法, Enum名称区分.名称, CStr(dto3.followhoho));                        //フォロー結果情報  方法
            vm.followjissiymd = dto3.followjissiymd;                                                                                            //フォロー結果情報  実施日
            vm.followtm = dto3.followtm;                                                                                                        //フォロー結果情報  時間
            var followkaijocd = dto3.followkaijocd;
            var followkaijocdnm = string.IsNullOrEmpty(followkaijocd) ? "" : db.tm_afkaijo.GetDtoByKey(followkaijocd).kaijonm;
            vm.followkaijocd = string.IsNullOrEmpty(followkaijocd) ?
                                "" : $"{followkaijocd}{DaConst.SELECTOR_DELIMITER}{followkaijocdnm}";                                           //フォロー結果情報  会場
            vm.followstaffid = dto3.followstaffid;                                                                                              //フォロー結果情報  担当者
            var dtoafstaff = db.tm_afstaff.GetDtoByKey(CStr(dto3.followstaffid));
            vm.followstaffid_nm = dtoafstaff?.staffsimei;                                                                                       //フォロー結果情報  担当者名称
            vm.followkekka = dto3.followkekka;                                                                                                  //フォロー結果情報  フォロー結果
            vm.upddttmyotei = dto2.upddttm;                                                                                                     //更新日時(排他も利用)
            vm.upddttmkekka = dto3.upddttm;                                                                                                     //更新日時(排他も利用)

            vm.yoteiinputflg = !(string.IsNullOrEmpty(vm.followhoho_yotei)
                                                      && string.IsNullOrEmpty(vm.followyoteiymd)
                                                      && string.IsNullOrEmpty(vm.followtm_yotei)
                                                      && string.IsNullOrEmpty(vm.followkaijocd_yotei)
                                                      && string.IsNullOrEmpty(vm.followstaffid_yotei)
                                                      && string.IsNullOrEmpty(vm.followstaffid_yoteinm)
                                                      && string.IsNullOrEmpty(vm.followriyu));                                                  //フォロー予定入力フラグ

            vm.kekkainputflg = !(string.IsNullOrEmpty(vm.followhoho)
                                                      && string.IsNullOrEmpty(vm.followjissiymd)
                                                      && string.IsNullOrEmpty(vm.followtm)
                                                      && string.IsNullOrEmpty(vm.followkaijocd)
                                                      && string.IsNullOrEmpty(vm.followstaffid)
                                                      && string.IsNullOrEmpty(vm.followstaffid_nm)
                                                      && string.IsNullOrEmpty(vm.followkekka));                                                 //フォロー結果入力フラグ

            //更新権限フラグ
            vm.updflg = string.IsNullOrEmpty(dto.regsisyo) || sisyoList.Contains(dto.regsisyo);

            return vm;
        }

        /// <summary>
        /// フォロー管理詳細予定情報取得
        /// </summary>
        public static FollowDetailKekkaInfoVM GetFollowDetailKekkaVM(FollowDetailYoteiInfoVM detailYoteiInfoVM, FollowDetailVM followdetailvm)
        {
            //既存のVMを初期化
            var vm = followdetailvm;
            vm.followhoho = detailYoteiInfoVM.followhoho_yotei;                                //フォロー結果情報  方法
            vm.followjissiymd = detailYoteiInfoVM.followyoteiymd;                              //フォロー結果情報  実施日
            vm.followtm = detailYoteiInfoVM.followtm_yotei;                                    //フォロー結果情報  時間
            vm.followkaijocd = detailYoteiInfoVM.followkaijocd_yotei;                          //フォロー結果情報  会場
            vm.followstaffid = detailYoteiInfoVM.followstaffid_yotei;                          //フォロー結果情報  担当者
            vm.followstaffid_nm = detailYoteiInfoVM.followstaffid_yoteinm;                     //フォロー結果情報  担当者名称

            return vm;
        }
    }
}
