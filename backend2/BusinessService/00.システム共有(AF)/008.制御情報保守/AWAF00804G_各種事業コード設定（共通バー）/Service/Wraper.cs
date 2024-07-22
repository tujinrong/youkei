// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 各種事業コード設定（共通バー）
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00804G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 設定対象一覧取得
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tm_afmeisyoDto> dtl1, List<tm_afhanyoDto> dtl2, List<tm_afhanyoDto> dtl3, List<tm_afhanyoDto> dtl4, List<tm_afhanyoDto> dtl5)
        {
            var list = new List<RowVM>();
            foreach (var dto in dtl1)
            {
                //集約コード(個人連絡先)
                var cd1 = dtl2.Find(e => e.hanyocd == dto.nmcd)?.hanyokbn1;
                //集約コード(メモ情報)
                var cd2 = dtl3.Find(e => e.hanyocd == dto.nmcd)?.hanyokbn1;
                //集約コード(電子ファイル情報)
                var cd3 = dtl4.Find(e => e.hanyocd == dto.nmcd)?.hanyokbn1;
                //集約コード(フォロー管理)
                var cd4 = dtl5.Find(e => e.hanyocd == dto.nmcd)?.hanyokbn1;
                list.Add(GetVM(db, dto, cd1, cd2, cd3, cd4));
            }

            return list;
        }

        /// <summary>
        /// 設定対象(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tm_afmeisyoDto dto, string? cd1, string? cd2, string? cd3, string? cd4)
        {
            var vm = new RowVM();
            vm.cd = dto.nmcd;                               //設定対象コード(キー)
            vm.nm = dto.nm;                                 //設定対象表示名称
            vm.cdnm1 = GetCdnm(db, cd1);                    //集約コード名称(個人連絡先)
            vm.cdnm2 = GetCdnm(db, cd2);                    //集約コード名称(メモ情報)
            vm.cdnm3 = GetCdnm(db, cd3);                    //集約コード名称(電子ファイル情報)
            vm.cdnm4 = GetCdnm(db, cd4);                    //集約コード名称(フォロー管理)

            var flgList = CommaStrToList(dto.hanyokbn1)!;
            vm.flg1 = !CBool(flgList[0]);                   //設定不要フラグ(個人連絡先)
            vm.flg2 = !CBool(flgList[1]);                   //設定不要フラグ(メモ情報)
            vm.flg3 = !CBool(flgList[2]);                   //設定不要フラグ(電子ファイル情報)
            vm.flg4 = !CBool(flgList[3]);                   //設定不要フラグ(フォロー管理)

            return vm;
        }
        /// <summary>
        /// 集約コード名称取得
        /// </summary>
        private static string GetCdnm(DaDbContext db, string? cd)
        {
            var cdnm = string.Empty;
            var list = CommaStrToList(cd);
            if (list.Count > 0)
            {
                cdnm = string.Join(DaStrPool.COMMA, list.Select(e => DaNameService.GetName(db, EnumNmKbn.事業集約コード, e)).ToList());
            }

            return cdnm;
        }
    }
}