// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00304D
{
    public class Converter : CmConerterBase
    {
        //確定更新処理
        private const string STATUS_UPD = "update";

        /// <summary>
        /// 警告内容検索処理
        /// </summary>
        public static List<AiKeyValue> GetParameters(long workSeq, tm_eurptDto rptDto)
        {
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchWarningsRequest.workseq)}_in", workSeq),            //ワークシーケンス
                new($"{nameof(tm_eurptgroupDto.rptgroupid)}_in", rptDto.rptgroupid),    //帳票グループID
            };
        }

        /// <summary>
        /// 宛名ワークテーブルサブ情報(警告内容)を取得
        /// </summary>
        public static List<wk_euatena_subDto> GetWarningDetails(UpdateWarningDetailsRequest req)
        {
            var dtls = new List<wk_euatena_subDto>();
            foreach (WarningContentVM info in req.warningContents)
            {
                var wk = new wk_euatena_subDto();
                wk.workseq = req.workseq;           //ワークシーケンス
                wk.atenano = info.atenano;          //宛名番号
                // 確定の場合
                if (STATUS_UPD.Equals(req.status))
                {
                    wk.formflg = info.formflg;      //出力フラグ
                    wk.taisyooutflg = info.formflg; //対象外出力可能フラグ
                }
                else
                {
                    //閉じるの場合
                    wk.formflg = info.formflgold;   //出力フラグ
                    wk.taisyooutflg = false;        //対象外出力可能フラグ
                }

                dtls.Add(wk);
            }
            return dtls;
        }

        /// <summary>
        /// 宛名ワークテーブルサブ情報(警告内容)を取得(チェック処理用)
        /// </summary>
        public static wk_euatena_subDto GetWarnDto(UpdateWarnCheckboxRequest req)
        {
            var dto = new wk_euatena_subDto();
            dto.workseq = req.workseq;             //ワークシーケンス
            dto.atenano = req.atenano;             //宛名番号
            // チェック確定の場合
            if (STATUS_UPD.Equals(req.status))
            {
                dto.formflg = req.formflg;         //出力フラグ
            }
            else
            {
                //チェック一時場合
                dto.formflg = req.formflgold;      //出力フラグ
                dto.taisyooutflg = req.formflg;    //対象外出力可能フラグ
            }

            return dto;
        }

        /// <summary>
        /// 宛名ワークテーブルサブ情報(警告内容)を取得
        /// </summary>
        public static List<wk_euatena_subDto> GetEuatenaSub(List<string> atenanoList, long workseq)
        {

            return atenanoList.Select(atenano => new wk_euatena_subDto
            {
                workseq = workseq,       // ワークシーケンス
                atenano = atenano,       // 宛名番号
                formflg = false          // 出力フラグ
            }).ToList();
        }
    }
}