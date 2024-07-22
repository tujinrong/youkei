// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 自己負担金情報保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.05
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00601G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 自己負担金情報保守情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// 自己負担金情報保守情報(1行)
        /// </summary>
        public static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var rowvm = new RowVM();
            rowvm.kensin_jigyocd = row.Wrap(nameof(tm_shjikofutankinDto.kensin_jigyocd));                          //成人健（検）診事業コード
            rowvm.ryokinpattern = row.Wrap(nameof(tm_shjikofutankinDto.ryokinpattern));                            //料金パターン
            rowvm.kensahohocd = row.Wrap(nameof(tm_shjikofutankinDto.kensahohocd));                                //検査方法
            rowvm.sex = row.Wrap(nameof(tm_shjikofutankinDto.sex));                                                //性別
            rowvm.genmenkbncd = row.Wrap(nameof(tm_shjikofutankinDto.genmenkbn));                                  //減免区分
            rowvm.agehani = row.Wrap(nameof(tm_shjikofutankinDto.agehani));                                        //年齢範囲
            rowvm.jusinkingaku = CInt(row.Wrap(nameof(tm_shjikofutankinDto.jusinkingaku)));                        //受診金額
            rowvm.kingaku_sityosonhutan = CInt(row.Wrap(nameof(tm_shjikofutankinDto.kingaku_sityosonhutan)));      //金額（市区町村負担）
            rowvm.upddttm = row.CDate(nameof(tm_shjikofutankinDto.upddttm));                                       //更新日時

            return rowvm;
        }

        /// <summary>
        /// 排他情報一覧取得
        /// </summary>
        public static List<LockVM> GetVMList(List<RowVM> vmList, List<tm_shjikofutankinDto> dtl)
        {
            var list = new List<LockVM>();
            foreach (var vm in vmList)
            {
                var lockVM = new LockVM();
                lockVM.kensin_jigyocd = vm.kensin_jigyocd;                 //成人健（検）診事業コード
                lockVM.ryokinpattern = vm.ryokinpattern;                   //料金パターン
                lockVM.kensahohocd = vm.kensahohocd;                       //検査方法コード
                lockVM.sex = vm.sex;                                       //性別
                lockVM.agehani = vm.agehani;                               //年齢範囲
                lockVM.genmenkbncd = vm.genmenkbncd;                       //減免区分

                lockVM.upddttm = dtl.Find(e => e.kensin_jigyocd == lockVM.kensin_jigyocd &&
                                            e.ryokinpattern == lockVM.ryokinpattern &&
                                            e.kensahohocd == lockVM.kensahohocd &&
                                            e.sex == lockVM.sex &&
                                            e.agehani == lockVM.agehani &&
                                            e.genmenkbn == lockVM.genmenkbncd &&
                                            e.kensahohocd == lockVM.kensahohocd)!.upddttm;
                list.Add(lockVM);
            }

            return list;
        }
    }
}