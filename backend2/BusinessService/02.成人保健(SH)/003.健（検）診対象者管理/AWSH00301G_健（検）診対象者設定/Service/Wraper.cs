// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診対象者設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00301G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検査方法一覧取得
        /// </summary>
        public static List<DaSelectorKeyModel> GetSelectorList(List<string> cdList, List<tm_afhanyoDto> dtl)
        {
            var list = new List<DaSelectorKeyModel>();
            foreach (var cd in cdList)
            {
                var subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd);
                var dtl2 = dtl.Where(e => e.hanyosubcd == subcd).ToList();
                foreach (var dto in dtl2)
                {
                    list.Add(new DaSelectorKeyModel(dto.hanyocd, dto.nm, cd));
                }
            }

            return list;
        }
        /// <summary>
        /// 明細行一覧取得
        /// </summary>
        public static List<RowVM> GetVMList(List<string> cdList1, List<string> cdList2, List<tm_shnendoDto> dtl)
        {
            var list = new List<RowVM>();
            foreach (var cd in cdList1)
            {
                var dtl2 = dtl.Where(e => e.jigyocd == cd).OrderBy(e => e.kensahohocd).ToList();
                if (dtl2.Count > 0)
                {
                    var flg = !cdList2.Contains(cd);
                    list.Add(GetVM(flg, dtl2));
                }
            }

            return list;
        }
        /// <summary>
        /// 排他情報一覧取得
        /// </summary>
        public static List<LockVM> GetVMList(List<RowVM> vmList, List<tm_shnendoDto> dtl, string kensahohocd)
        {
            var list = new List<LockVM>();
            foreach (var vm in vmList)
            {
                foreach (var row in vm.rows)
                {
                    var vm2 = new LockVM();
                    vm2.jigyocd = vm.jigyocd;//成人健（検）診事業コード
                    vm2.kensahohocd = row.kensahohocd;//検査方法コード
                    vm2.upddttm = dtl.Find(e => e.jigyocd == vm2.jigyocd &&
                                            e.kensahohocd == (vm2.kensahohocd != null ? vm2.kensahohocd : kensahohocd))!.upddttm;
                    list.Add(vm2);
                }
            }

            return list;
        }
        /// <summary>
        /// 明細行(事業単位)取得
        /// </summary>
        private static RowVM GetVM(bool kensahoho_setflg, List<tm_shnendoDto> dtl)
        {
            var vm = new RowVM();
            vm.jigyocd = dtl[0].jigyocd;                //成人健（検）診事業コード

            var list = new List<HohoRowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(kensahoho_setflg, dto));
            }
            vm.rows = list;                             //検査方法単位情報

            return vm;
        }
        /// <summary>
        /// 明細行(検査方法単位)取得
        /// </summary>
        private static HohoRowVM GetVM(bool kensahoho_setflg, tm_shnendoDto dto)
        {
            var vm = new HohoRowVM();
            if (kensahoho_setflg)
            {
                vm.kensahohocd = dto.kensahohocd;   //検査方法コード
            }
            vm.sex = CStr(dto.sex);                 //性別コード
            vm.age = dto.age;                       //年齢
            vm.kijunkbn = EnumToStr(dto.kijunkbn);  //年齢基準日区分コード
            vm.kijunymd = CStr(dto.kijunymd);       //年齢計算基準日
            vm.hokenkbn = CStr(dto.hokenkbn);       //保険区分コード
            vm.tokusyu = CStr(dto.tokusyu);         //特殊コード
            vm.sql = CStr(dto.sql);                 //SQL文

            return vm;
        }
    }
}