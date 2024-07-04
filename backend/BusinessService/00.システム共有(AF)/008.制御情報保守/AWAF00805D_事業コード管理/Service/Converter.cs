// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業コード管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00805D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 集約コード設定
        /// </summary>
        public static List<tm_afhanyoDto> GetDtl(SaveVM vm, tm_afhanyoDto? dto1, tm_afhanyoDto? dto2, tm_afhanyoDto? dto3, tm_afhanyoDto? dto4)
        {
            var dtl = new List<tm_afhanyoDto>();
            //個人連絡先
            if (!vm.flg1)
            {
                dto1!.hanyokbn1 = CNStr(DaSelectorService.GetCd(vm.cdnm1));
                dtl.Add(dto1);
            }
            //メモ情報
            if (!vm.flg2)
            {
                dtl.Add(GetDto(dto2!, vm.cdnmlist2));
            }
            //電子ファイル情報
            if (!vm.flg3)
            {
                dtl.Add(GetDto(dto3!, vm.cdnmlist3));
            }
            //フォロー管理
            if (!vm.flg4)
            {
                dtl.Add(GetDto(dto4!, vm.cdnmlist4));
            }

            return dtl;
        }
        /// <summary>
        /// 更新キーリスト取得
        /// </summary>
        public static List<object[]> GetKeyList(SaveVM vm, string cd)
        {
            var list = new List<object[]>();
            if (!vm.flg1)
            {
                list.Add(GetKey(cd, EnumHanyoKbn.連絡先事業コード管理));
            }
            if (!vm.flg2)
            {
                list.Add(GetKey(cd, EnumHanyoKbn.メモ事業コード管理));
            }
            if (!vm.flg3)
            {
                list.Add(GetKey(cd, EnumHanyoKbn.電子ファイル事業コード管理));
            }
            if (!vm.flg4)
            {
                list.Add(GetKey(cd, EnumHanyoKbn.フォロー事業コード管理));
            }

            return list;
        }
        /// <summary>
        /// 汎用マスタ
        /// </summary>
        private static tm_afhanyoDto GetDto(tm_afhanyoDto dto, List<string> cdList)
        {
            //集約コード設定
            dto.hanyokbn1 = ListToCommaStr(cdList);
            return dto;
        }
        /// <summary>
        /// 更新キー取得
        /// </summary>
        private static object[] GetKey(string cd, EnumHanyoKbn kbn)
        {
            var maincd = ((long)kbn / 100000000L).ToString();
            var subcd = (int)((long)kbn % 100000000L);
            return new object[] { maincd, subcd, cd };
        }
    }
}