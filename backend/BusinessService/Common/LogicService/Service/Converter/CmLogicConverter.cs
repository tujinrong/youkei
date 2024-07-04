// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ロジック共通仕様処理
//             DBデータへ変換処理
// 作成日　　: 2023.07.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.Service.Common
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検診固定検索条件取得：受診者を探す場合
        /// </summary>
        public static FrConditionModel GetFixedCondition(PersonSearchRequest req)
        {
            var fixedCondition = new FrConditionModel();
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.atenano), FrEnumValueOprator.EQ, req.atenano);
            }
            //個人番号
            if (!string.IsNullOrEmpty(req.personalno))
            {
                //検索のため暗号化
                fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno), FrEnumValueOprator.EQ, DaEncryptUtil.AesEncrypt(req.personalno));
            }
            //氏名
            if (!string.IsNullOrEmpty(req.name))
            {
                var cond = new FrConditionModel()
                    .Sub(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei), FrEnumValueOprator.LK, ToLikeStr(req.name)!)
                    .Or(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.tusyo), FrEnumValueOprator.LK, ToLikeStr(req.name)!)
                    .EndSub();
                fixedCondition.And(cond);
            }
            //カナ氏名
            if (!string.IsNullOrEmpty(req.kname))
            {
                var cond = new FrConditionModel()
                    .Sub(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                    .Or(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.tusyo_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                    .EndSub();
                fixedCondition.And(cond);
            }
            //生年月日
            if (!string.IsNullOrEmpty(req.bymd))
            {
                fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.bymd), FrEnumValueOprator.EQ, req.bymd);
            }

            return fixedCondition;
        }
    }
}