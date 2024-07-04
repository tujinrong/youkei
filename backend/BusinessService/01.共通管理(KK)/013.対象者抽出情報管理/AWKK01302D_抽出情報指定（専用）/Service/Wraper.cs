// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 抽出情報指定（専用）
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.06.05
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK01302D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 抽出情報取得(帳票出力画面遷移用)
        /// </summary>
        public static TyusyutuVM GetVM(DaDbContext db, tm_kktyusyutuDto mstDto, tt_kktaisyosya_tyusyutuDto dataDto, List<tt_kktaisyosya_tyusyutu_subDto> dataDtl)
        {
            var vm = new TyusyutuVM()
            {
                nendo = dataDto.nendo,                                                                                       //年度
                tyusyututaisyocd = mstDto.tyusyututaisyocd,                                                                  //抽出対象コード
                tyusyututaisyonm = mstDto.tyusyututaisyonm,                                                                  //抽出対象名
                rptid = mstDto.rptid,                                                                                        //帳票ID
                tyusyutuseq = dataDto.tyusyutuseq,                                                                           //抽出シーケンス
                tyusyutunaiyo = dataDto.tyusyutunaiyo,                                                                       //抽出内容
                tyusyutunum = string.Format("{0:#,0}", dataDtl.Select(e => e.atenano).Distinct().ToList().Count()),          //抽出人数
                regdttm = FormatWaKjDttm(dataDto.regdttm)                                                                    //登録日時
            };

            return vm;
        }
    }
}