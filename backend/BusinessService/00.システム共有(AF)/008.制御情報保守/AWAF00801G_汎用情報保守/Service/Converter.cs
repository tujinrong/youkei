// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 汎用情報保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.01.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00801G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 汎用キーリスト(排他用)
        /// </summary>
        public static List<object[]> GetKeyList(string hanyomaincd, int hanyosubcd, List<string> hanyocdList)
        {
            return hanyocdList.Select(cd => new object[]
            {
                hanyomaincd, //汎用メインコード
                hanyosubcd,  //汎用サブコード
                cd           //汎用コード
            }).ToList();
        }

        /// <summary>
        /// 汎用データ情報一覧
        /// </summary>
        public static List<tm_afhanyoDto> GetDtl(List<HanyoVM> savelist, string hanyomaincd, int hanyosubcd)
        {
            return savelist.Select(d => GetDto(d, hanyomaincd, hanyosubcd)).ToList();
        }

        /// <summary>
        /// 汎用データ情報(1件)
        /// </summary>
        private static tm_afhanyoDto GetDto(HanyoVM vm, string hanyomaincd, int hanyosubcd)
        {
            var dto = new tm_afhanyoDto();
            dto.hanyomaincd = hanyomaincd;              //汎用メインコード
            dto.hanyosubcd = hanyosubcd;                //汎用サブコード
            dto.hanyocd = vm.hanyocd;                   //汎用コード
            dto.nm = vm.nm;                             //名称
            dto.kananm = CNStr(ToNKana(vm.kananm));     //カナ名称
            dto.shortnm = ToNStr(vm.shortnm);           //略称
            dto.biko = ToNStr(vm.biko);                 //備考
            dto.hanyokbn1 = ToNStr(vm.hanyokbn1);       //汎用区分1
            dto.hanyokbn2 = ToNStr(vm.hanyokbn2);       //汎用区分2
            dto.hanyokbn3 = ToNStr(vm.hanyokbn3);       //汎用区分3
            dto.stopflg = vm.stopflg;                   //使用停止フラグ
            dto.orderseq = vm.orderseq;                 //並びシーケンス
            return dto;
        }

        /// <summary>
        ///汎用メインマスタ情報を取得
        /// </summary>
        public static tm_afhanyo_mainDto GetMainDto(SubCodeInfoVM vm)
        {
            var dto = new tm_afhanyo_mainDto();
            dto.hanyomaincd = DaSelectorService.GetCd(vm.hanyomaincd);  //汎用メインコード
            dto.hanyosubcd = vm.hanyosubcd;                             //汎用サブコード
            dto.hanyosubcdnm = vm.hanyosubcdnm;                         //汎用サブコード名称
            dto.keta = vm.keta;                                         //桁数
            dto.userryoikikaisicd = vm.userryoikikaisicd;               //ユーザ領域開始コード
            dto.iflg = true;                                            //INSERT可能フラグ
            dto.uflg = true;                                            //UPDATE可能フラグ
            dto.dflg = true;                                            //DELETE可能フラグ

            return dto;
        }
    }
}