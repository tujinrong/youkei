// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 汎用情報保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.01.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00801G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 汎用メインマスタ
        /// </summary>
        public static void SetHeader(SearchResponse res, tm_afhanyo_mainDto dto)
        {
            res.biko = dto.biko ?? string.Empty;            //備考
            res.keta = dto.keta;                            //桁数
            res.userryoikikaisicd = dto.userryoikikaisicd;  //ユーザ領域開始コード
            res.iflg = dto.iflg;                            //INSERT可能フラグ
            res.uflg = dto.uflg;                            //UPDATE可能フラグ
            res.dflg = dto.dflg;                            //DELETE可能フラグ
        }

        /// <summary>
        /// 汎用マスタ
        /// </summary>
        public static List<HanyoVM> GetVMList(List<tm_afhanyoDto> dtl, tm_afhanyo_mainDto mainDto)
        {
            return dtl.Select(d =>
            {
                var vm = new HanyoVM();
                vm.hanyocd = d.hanyocd;                     //汎用コード
                vm.nm = d.nm;                               //名称
                vm.kananm = CStr(d.kananm);                 //カナ名称
                vm.shortnm = CStr(d.shortnm);               //略称
                vm.biko = CStr(d.biko);                     //備考
                vm.hanyokbn1 = CStr(d.hanyokbn1);           //汎用区分1
                vm.hanyokbn2 = CStr(d.hanyokbn2);           //汎用区分2
                vm.hanyokbn3 = CStr(d.hanyokbn3);           //汎用区分3
                vm.stopflg = d.stopflg;                     //使用停止フラグ
                vm.orderseq = d.orderseq;                   //並びシーケンス
                vm.upddttm = d.upddttm;                     //更新日時
                vm.hanyocdEditFlg = mainDto.uflg && IsNumber(d.hanyocd);    //汎用コード編集フラグ

                //ユーザ領域開始コードがある場合
                if (mainDto.userryoikikaisicd != null)
                {
                    //PKGコードフラグ
                    vm.pkgCdFlg = IsPKG(d.hanyocd, CInt(mainDto.userryoikikaisicd));      
                }
                
                return vm;
            }).ToList();
        }

        /// <summary>
        /// 汎用サブコード情報を取得
        /// </summary>
        public static SubCodeInfoVM GetSubCodeIndo(tm_afhanyo_mainDto dto)
        {
            var vm = new SubCodeInfoVM();
            vm.hanyomaincd = dto.hanyomaincd;               //汎用メインコード
            vm.hanyosubcd = dto.hanyosubcd;                 //汎用サブコード
            vm.hanyosubcdnm = dto.hanyosubcdnm;             //汎用サブコード名称
            vm.keta = dto.keta;                             //桁数
            vm.userryoikikaisicd = dto.userryoikikaisicd;   //ユーザ領域開始コード
            return vm;
        }

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afhanyo_mainDto> dtl, Enum名称区分 kbn)
        {
            switch (kbn)
            {
                case Enum名称区分.名称:
                    return dtl.Select(d => new DaSelectorModel(d.hanyosubcd.ToString(), d.hanyosubcdnm)).ToList();
                case Enum名称区分.カナ:
                    return dtl.Select(d => new DaSelectorModel(d.hanyosubcd.ToString(), d.kananm)).ToList();
                case Enum名称区分.略称:
                    return dtl.Select(d => new DaSelectorModel(d.hanyosubcd.ToString(), d.shortnm)).ToList();
                default:
                    throw new Exception("Enum名称区分 error");
            }
        }

        /// <summary>
        /// 数字のみ
        /// </summary>
        public static bool IsNumber(string value)
        {
            // 正規表現パターン：半角数字（0から9）
            string pattern = "^[0-9]+$";

            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// PKGコードフラグ
        /// </summary>
        public static bool IsPKG(string value, int userryoikikaisicd)
        {
            if (int.TryParse(value, out int cd))
            {
                return cd < userryoikikaisicd;
            }
            return false;
        }
    }
}
