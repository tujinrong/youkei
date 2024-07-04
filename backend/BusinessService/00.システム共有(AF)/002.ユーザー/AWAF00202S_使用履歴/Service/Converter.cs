// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 使用履歴
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.02.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00202S
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータを取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(DaRequestBase req)
        {
            List<AiKeyValue> paras = new List<AiKeyValue>()
            {
                new AiKeyValue($"{nameof(DaRequestBase.userid)}_in", req.userid)    //ユーザーID
            };
            return paras;
        }

        /// <summary>
        /// 使用履歴テーブル
        /// </summary>
        public static tt_afsiyorirekiDto GetDto(SaveRequest req)
        {
            var dto = new tt_afsiyorirekiDto();
            dto.userid = req.userid;          //ユーザーID
            dto.kinoid = req.kinoid;    //機能ID
            dto.syoridttm = DaUtil.Now;       //処理日時
            return dto;
        }
    }
}