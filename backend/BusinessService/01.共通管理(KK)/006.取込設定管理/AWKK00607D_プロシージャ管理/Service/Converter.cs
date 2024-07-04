// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00607D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// プロシージャマスタ
        /// </summary>
        public static tm_kktorinyuryoku_procDto GetkkprocDto(tm_kktorinyuryoku_procDto dtoOld, SaveRequest req, DateTime dttm)
        {
            var vm = req.procedureVM;
            var dto = new tm_kktorinyuryoku_procDto();
            dto.procnm = vm.procnm;                 //プロシージャ名
            dto.prockbn = vm.prockbn;               //プロシージャ区分

            //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                dto.reguserid = req.userid;         //登録ユーザーID
                dto.regdttm = dttm;                 //登録日時
            }
            else
            {
                dto.reguserid = dtoOld.reguserid;   //登録ユーザーID
                dto.regdttm = dtoOld.regdttm;       //登録日時
                dto.procseq = dtoOld.procseq;       //プロシージャシーケンス
            }
            dto.upduserid = req.userid;             //更新ユーザーID
            dto.upddttm = dttm;                     //更新日時

            return dto;
        }
    }
}