// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診対象者設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.BatchService.ABSH00101G;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00301G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 年度マスタリスト
        /// </summary>
        public static List<tm_shnendoDto> GetDtl(int nendo, string kensahohocd, List<RowVM> vmList, List<string> cdList)
        {
            var dtl = new List<tm_shnendoDto>();
            foreach (var vm in vmList)
            {
                dtl.AddRange(GetDtl(nendo, kensahohocd, vm, cdList));
            }

            return dtl;
        }
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static ParameterModel GetParameters(SearchRequest req)
        {
            var paras = new ParameterModel();
            paras.nendo = req.nendo;    //年度
            return paras;
        }
        /// <summary>
        /// 年度マスタ(事業単位)
        /// </summary>
        private static List<tm_shnendoDto> GetDtl(int nendo, string kensahohocd, RowVM vm, List<string> cdList)
        {
            var dtl = new List<tm_shnendoDto>();
            foreach (var row in vm.rows)
            {
                var flg = !cdList.Contains(vm.jigyocd);
                dtl.Add(GetDto(nendo, kensahohocd, row, vm.jigyocd, flg));
            }

            return dtl;
        }
        /// <summary>
        /// 年度マスタ(1件)
        /// </summary>
        private static tm_shnendoDto GetDto(int nendo, string kensahohocd, HohoRowVM vm, string jigyocd, bool kensahoho_setflg)
        {
            var dto = new tm_shnendoDto();
            dto.nendo = nendo;                                      //年度  
            dto.jigyocd = jigyocd;                                  //成人健（検）診事業コード  
            if (kensahoho_setflg)
            {
                dto.kensahohocd = vm.kensahohocd!;                  //検査方法コード
            }
            else
            {
                dto.kensahohocd = kensahohocd;                      //検査方法コード
            }
            dto.sex = CNStr(vm.sex);                                //性別
            dto.age = vm.age;                                       //年齢
            dto.kijunkbn = (Enum年齢基準日区分)CInt(vm.kijunkbn);   //年齢基準日区分
            dto.kijunymd = CNStr(vm.kijunymd);                      //年齢計算基準日
            dto.hokenkbn = CNStr(vm.hokenkbn);                      //保険区分
            dto.tokusyu = CNStr(vm.tokusyu);                        //特殊
            dto.sql = CNStr(vm.sql);                                //SQL文

            return dto;
        }
    }
}