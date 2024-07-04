// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目出力順編集
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00306D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 出力順情報取得(新規)
        /// </summary>
        public static tt_eusortDto GetAddSortDto(AddRequest req, int sortptnno)
        {
            var dto = new tt_eusortDto();
            dto.rptid = req.rptid;                       //帳票ID
            dto.yosikiid = req.yosikiid;                 //様式ID
            dto.sortptnno = sortptnno;                   //出力順パターン番号
            dto.sortptnnm = req.sortptnnm;               //出力順パターン名
            return dto;
        }

        /// <summary>
        /// 出力順パターンサブ情報リスト取得(新規)
        /// </summary>
        public static List<tt_eusort_subDto> GetAddSortSubDtl(AddRequest req, int sortptnno)
        {
            return req.sortsublist.Select((x, index) => GetSortSubDto(x, req.rptid, req.yosikiid, sortptnno, index + 1)).ToList();
        }

        /// <summary>
        /// 出力順情報取得(更新)
        /// </summary>
        public static tt_eusortDto GetUpdateSortDto(UpdateRequest req, int sortptnno)
        {
            var dto = new tt_eusortDto();
            dto.rptid = req.rptid;                      //帳票ID
            dto.yosikiid = req.yosikiid;                //様式ID
            dto.sortptnno = sortptnno;                  //出力順パターン番号
            dto.sortptnnm = req.sortptnnm;              //出力順パターン名
            dto.upduserid = req.userid;                 //ユーザーID
            return dto;
        }

        /// <summary>
        /// 出力順パターンサブ情報リスト取得(更新)
        /// </summary>
        public static List<tt_eusort_subDto> GetUpdateSortSubDtl(UpdateRequest req, int sortptnno)
        {
            return req.sortsublist.Select((x, index) => GetSortSubDto(x, req.rptid, req.yosikiid, sortptnno, index + 1)).ToList();
        }

        /// <summary>
        /// 出力順パターンサブ情報取得
        /// </summary>
        private static tt_eusort_subDto GetSortSubDto(SortSubVM vm, string rptid, string yosikiid, int sortptnno, int orderseq)
        {
            var dto = new tt_eusort_subDto();
            dto.rptid = rptid;                         //帳票ID
            dto.yosikiid = yosikiid;                   //様式ID
            dto.sortptnno = sortptnno;                 //出力順パターン番号
            dto.reportitemid = vm.reportitemid;        //帳票項目ID
            dto.descflg = vm.descflg;                  //降順フラグ
            dto.pageflg = vm.pageflg;                  //改ページフラグ
            dto.orderseq = orderseq;                   //並びシーケンス
            return dto;
        }
    }
}