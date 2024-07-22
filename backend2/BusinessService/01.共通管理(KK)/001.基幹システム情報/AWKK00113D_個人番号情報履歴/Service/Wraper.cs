// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人番号情報履歴
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.InfantVaccination;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00113D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 住民情報履歴一覧
        /// </summary>
        public List<RowVM> GetVMList(DaDbContext db, List<tt_afpersonalnoDto> dtl, bool personalflg, string publickey)
        {
            var rirekinum = 0;
            var list = new List<RowVM>();

            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto, ++rirekinum, personalflg, publickey));
            }
            return list;
        }
        /// <summary>
        /// 住民情報履歴(1行)
        /// </summary>
        private RowVM GetVM(DaDbContext db, tt_afpersonalnoDto dto, int rirekinum, bool personalflg, string publickey)
        {
            var personalno = (personalflg && !string.IsNullOrEmpty(CStr(dto.personalno))) ?
                    DaEncryptUtil.AesDecryptAndRsaEncrypt(CStr(dto.personalno), publickey) : string.Empty;    //個人番号(暗号化)

            var vm = new RowVM
            {
                rirekinum = rirekinum,                      //履歴No.
                rirekino = dto.rirekino,                    //履歴番号
                personalno = personalno,                    //個人番号
                upddttm = FormatWaKjDttm(dto.upddttm),      //更新日時
                saisin = FormatFlgStr(dto.saisinflg),       //最新（名称）
            };

            return vm;
        }
    }
}