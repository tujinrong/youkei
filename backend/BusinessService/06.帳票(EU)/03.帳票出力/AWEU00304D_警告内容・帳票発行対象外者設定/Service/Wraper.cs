// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定
// 　　　　　  DB項目から画面項目に変換 
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// *******************************************************************
namespace BCC.Affect.Service.AWEU00304D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 警告内容情報を取得
        /// </summary>
        public static List<WarningContentVM> GetWarningList(DaDbContext db,DataRowCollection rows, bool alertviewflg, long? workseq)
        {
            var keikokulist = new List<WarningContentVM>();
            foreach (DataRow row in rows)
            {
                var keikoku = new WarningContentVM();
                keikoku.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                                         //宛名番号
                keikoku.simei = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                                       //氏名
                var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));                                     //支援措置区分
                keikoku.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);                           //警告内容
                keikoku.taisyogairiyu = FormatStr(row.Wrap(nameof(tt_kkrpthakkotaisyogaisyaDto.taisyogairiyu)));   //対象外者/対象外理由
                keikoku.formflg = workseq == null ? false : row.CBool(nameof(wk_euatena_subDto.formflg));          //出力フラグ
                keikoku.formflgold = keikoku.formflg;                                                              //出力フラグ(旧)
                keikokulist.Add(keikoku);

            }      
            return keikokulist;
        }

        /// <summary>
        /// 記号変換
        /// </summary>
        public static string FormatStr(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : "○";
        }
    }
}